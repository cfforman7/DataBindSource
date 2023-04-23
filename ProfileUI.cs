using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVM
{
    public class ProfileUI : UIBase
    {
        private UIWindow mWindow;
        private UI.Profile.ProfileUIContext context;

        private eProfileViewType profileViewType;

        private ProfileServerInfo profileInfo;
        private bool isOwn = false;
        private Action<bool> endCall;
        private bool isNeedRefresh = false;

        public override void Close(Action aEndCall = null)
        {
            mWindow?.Close(aEndCall);
        }

        public override void InitUI()
        {
            context = new UI.Profile.ProfileUIContext();
            context.Initialize(isOwn);
            context.OnClickCloseCallback = ClickCloseCallback;
            if (isOwn)
            {
                context.OnClickEditFlagCallback = ClickEditFlagCallback;
                context.OnClickEditNameCallback = ClickEditNickNameCallback;
                context.OnClickEditProfileCallback = ClickEditProfileImageCallback;
            }
            else
            {
                context.OnClickDeckCopyCallback = ClickDeckCopyCallback;
            }
            context.OnClickBaseUnitCallback = ClickBaseUnitSlotCallback;
            context.OnClickBaseUnitTooltipCallback = ClickBaseUnitTooltipCallback;
            mWindow.view.SetContext(context);
        }

        public override void Show()
        {
            mWindow?.Open();
        }

        #region [Public Method]
        public void ShowProfileUI(bool aIsOwn, ProfileServerInfo aServerInfo, Action<bool> aEndCall)
        {
            //자기 자신 여부
            isOwn = aIsOwn;
            profileViewType = isOwn ? eProfileViewType.OWN : eProfileViewType.OTHER_NOTHING;
            //프로필 정보
            profileInfo = aServerInfo;
            //종료 콜백
            endCall = aEndCall;
            //갱신 여부 
            isNeedRefresh = false;

            if (mWindow == null)
            {
                UIManager.Instance.OpenUI<UIWindow>(eUIID.PROFILE,
                   (win) =>
                   {
                       mWindow = win;
                       //초기화
                       InitUI();
                       RefreshUI();
                   });
            }
            else
            {
                mWindow?.Open();
                RefreshUI();
            }
        }

        /// <summary>
        /// UI 갱신
        /// </summary>
        public void RefreshUI()
        {
            context.ViewType = isOwn ? eProfileViewType.OWN : eProfileViewType.OTHER_NOTHING;
            switch (profileViewType)
            {
                case eProfileViewType.OWN:
                    context.SettingOwnInfo(); break;
                case eProfileViewType.OTHER_NOTHING:
                    context.SettingOtherInfo(profileInfo); break;
            }
        }
        #endregion

        #region [Callback Method]
        public void ClickCloseCallback()
        {
            endCall?.Invoke(isNeedRefresh);
            Close();
        }

        /// <summary>
        /// 프로필 이미지 변경 콜백
        /// </summary>
        public void ClickEditProfileImageCallback()
        {
            ProfileEditMainImageUI imageUI = UIBaseList.Get<ProfileEditMainImageUI>() as ProfileEditMainImageUI;
            imageUI.ShowEditMainImage(
                (isChange) =>
                {
                    if (isChange)
                    {
                        isNeedRefresh = true;
                        RefreshUI();
                    }
                });
        }

        /// <summary>
        /// 닉네임 변경
        /// </summary>
        public void ClickEditNickNameCallback(bool aIsFree)
        {
            ProfileEditNickNameUI nameUI = UIBaseList.Get<ProfileEditNickNameUI>();
            nameUI.ShowEditNickNameUI(aIsFree,
                (isChange) =>
                {
                    if (isChange)
                    {
                        isNeedRefresh = true;
                        RefreshUI();
                    }
                });
        }

        /// <summary>
        /// 국가 변경
        /// </summary>
        public void ClickEditFlagCallback()
        {
            ProfileEditFlagUI regionUI = UIBaseList.Get<ProfileEditFlagUI>() as ProfileEditFlagUI;
            regionUI.ShowEditRegionUI(
                (isChange) =>
                {
                    if (isChange)
                    {
                        isNeedRefresh = true;
                        RefreshUI();
                    }
                });
        }

        /// <summary>
        /// 기본유닛 툴팁 클릭
        /// </summary>
        public void ClickBaseUnitTooltipCallback(Vector3 aTarget)
        {
            int[] iTextIDArr = new int[] { TextID.BASE_UNIT_TIP_INFO, TextID.BASE_UNIT_LEVEL_INFO };
            TooltipUI tipUI = UIBaseList.Get<TooltipUI>() as TooltipUI;
            tipUI.ShowTooltipUI(aTarget, iTextIDArr);
        }

        public void ClickInviteCallback()
        {
        }

        public void ClickCancelInviteCallback()
        {

        }

        public void ClickDeckCopyCallback()
        {
            if (isOwn) return;
            DeckCopyUI copyUI = UIBaseList.Get<DeckCopyUI>() as DeckCopyUI;
            copyUI.ShowDeckCopyUIByProfile(profileInfo.UserTag, profileInfo.DeckInfo);
        }

        /// <summary>
        /// 영웅 슬롯 클릭 콜백
        /// </summary>
        public void OnClickHeroSlot(int aMetaID)
        {
            CardDetailUI detailUI = UIBaseList.Get<CardDetailUI>() as CardDetailUI;
            if (profileViewType == eProfileViewType.OWN)
            {
                UnitCard unit = PlayerDataManager.Instance.GetBigUnitCard(aMetaID);
                detailUI.ShowCardDetailUI(eDetailShowType.DEFUALT, unit);
            }
            else
            {
                BigUnitGroupMetaData unit = MetaDataManager.Instance.GetBigUnitGroupMetaData(aMetaID);
                //detailUI.ShowCardDetailUI(eDetailShowType.DEFUALT, unit);
            }
        }

        /// <summary>
        /// 액션카드 클릭 콜백
        /// </summary>
        public void OnClickActionSlot(int aMetaID)
        {
            CardDetailUI detailUI = UIBaseList.Get<CardDetailUI>() as CardDetailUI;
            if (profileViewType == eProfileViewType.OWN)
            {
                ActionCard action = PlayerDataManager.Instance.GetActionCard(aMetaID);
                detailUI.ShowCardDetailUI(eDetailShowType.DEFUALT, action);
            }
            else
            {
                //detailUI.ShowCardDetailUI(eDetailShowType.DEFUALT, unit);
            }
        }

        /// <summary>
        /// 기본 유닛 아이콘 클릭 콜백
        /// </summary>
        public void ClickBaseUnitSlotCallback(int aMetaID)
        {
            UnitCard unit = new UnitCard(aMetaID);
            CardDetailUI detailUI = UIBaseList.Get<CardDetailUI>() as CardDetailUI;
            detailUI.ShowCardDetailUI(eDetailShowType.DEFUALT, unit);
        }
        #endregion
    }
}
