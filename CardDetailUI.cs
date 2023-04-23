using System;
using System.Collections;
using System.Collections.Generic;
using Thor;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM
{
    public class CardDetailUI : UIBase
    {
        #region [Variables]
        private UIWindow mWindow;
        private UI.Deck.CardDetailUIContext mContext;
        private ActionCard mActionCard;
        private UnitCard mHeroCard;
        private eDetailShowType mShowType;
        private eDetailCloseType mCloseType = eDetailCloseType.NONE;
        private Action<eDetailCloseType> mEndCall;
        private bool mIsActionDetail = false;
        private UI.Card.CardSlotUIContext mSlotContext;
        private LobbyMainCharacter previewHero = null;
        private DragRotationObject dragRotation;
        #endregion

        public Canvas RootCanvas => mWindow?.CurrentCanvas;

        #region [Override Method]
        public override void Show()
        {
            mWindow?.Open();
        }

        public override void Close(Action aEndCall = null)
        {
            Clear();
        
            mWindow?.Close(aEndCall);
        }

        public override void CloseNoAction()
        {
            Clear();
            mWindow?.Close(immediate: true);
        }

        private void Clear()
        {
            mActionCard = null;
            mHeroCard = null;
            UIBaseList.Get<MVVM.CardPreviewUI>().Close();
            HideHeroPreview();
        }

        public override void InitUI()
        {
            bool bIsHaveSlotCard = mShowType == eDetailShowType.MY_DECK ? true : false;
            mContext = new UI.Deck.CardDetailUIContext()
            {
                //플레이어 경험치 정보 Text
                PlayerExpInfoText = MetaDataManager.Instance.GetText(TextID.UPGRADE_INFO),
                BoostText = MetaDataManager.Instance.GetText(TextID.BOOST),
                ResetText = MetaDataManager.Instance.GetText(TextID.RESET),
                MaxText = MetaDataManager.Instance.GetText(TextID.MAX),
                UpgradeText = MetaDataManager.Instance.GetText(TextID.UPGRADE),
                SwapText = MetaDataManager.Instance.GetText(TextID.SWAP),
                EquipText = MetaDataManager.Instance.GetText(TextID.EQUIP),
                PlayTutorialText = MetaDataManager.Instance.GetText(TextID.TUTORIAL_PLAY),
                PlayTutorialInfoText = MetaDataManager.Instance.GetText(TextID.TUTORIAL_PLAY_INFO),
                NoChangeText = MetaDataManager.Instance.GetText(TextID.NO_CHANGE),
                PageBtnType = ePageActiveType.FIRST,
                //스크롤 페이지 셋팅.
                CurrentPage = (int)ePageActiveType.FIRST,
                //내가 보유한 슬롯인가 여부
                IsHaveCardSlot = bIsHaveSlotCard,
                OnCloseCallback = CloseCallback,
                OnUpgrageCallback = UpgradeCallback,
                OnClickPageCallback = ClickPageButton,
                OnClickTutorialCallback = ClickTutorialBtn,
                OnClickSetMainHeroCallback = ClickSetMainHeroButton,
                CardPreviewUIContext = new UI.CardPreview.CardPreviewUIContext()
            };

            mWindow.view.SetContext(mContext);
            //액션 카드 인가 영웅카드 인가 여부
            mContext.IsActionCardDetail = mIsActionDetail;            
            //카드 정보 생성
            mSlotContext = new UI.Card.CardSlotUIContext();
            //카드 정보 셋팅
            mContext.CardSlot = mSlotContext;
            Utility.RunCallbackOneFrameLater(
                () =>
                {
                    if (mContext.MaxButton != null)
                    {
                        ButtonCallback callback = mContext.MaxButton.GetComponent<ButtonCallback>();
                        callback.OnPointerDownCallback = PressDownMaxLevelBtn;
                        callback.OnPointerUpCallback = PressUpMaxLevelBtn;
                    }
                });
        }
        #endregion

        #region [Public Method]
        /// <summary>
        /// 액션카드 상세 보기
        /// </summary>        
        public void ShowCardDetailUI(eDetailShowType aShowType, ActionCard aAction, Action<eDetailCloseType> aEndCallback = null)
        {
            //액션카드 상세 여부
            mIsActionDetail = true;
            //쇼타입 저장
            mShowType = aShowType;
            mActionCard = aAction;
            mEndCall = aEndCallback;
            mCloseType = eDetailCloseType.NONE;

            if (mWindow == null)
            {
                UIManager.Instance.OpenUI<UIWindow>(eUIID.CARD_DETAIL,
                   (win) =>
                   {
                       mWindow = win;
                       mWindow.DestroyCallback = (window) =>
                       {
                           UIBaseList.Get<CardPreviewUI>().Destroy();
                       };

                       //초기화
                       InitUI();
                       RefreshUI();
                       OpenUI();
                   });
            }
            else
            {
                mWindow?.Open();
                RefreshUI();
                OpenUI();
            }
        }

        /// <summary>
        /// 영웅카드 상세보기
        /// </summary>        
        public void ShowCardDetailUI(eDetailShowType aShowType, UnitCard aUnit, Action<eDetailCloseType> aEndCallback = null)
        {
            //액션카드 상세 여부
            mIsActionDetail = false;
            //쇼타입 저장
            mShowType = aShowType;
            mHeroCard = aUnit;
            mEndCall = aEndCallback;
            mCloseType = eDetailCloseType.NONE;

            if (mWindow == null)
            {
                UIManager.Instance.OpenUI<UIWindow>(eUIID.CARD_DETAIL,
                   (win) =>
                   {
                       mWindow = win;
                       mWindow.DestroyCallback = (window) =>
                       {
                           UIBaseList.Get<CardPreviewUI>().Destroy();
                       };

                       //초기화
                       InitUI();
                       RefreshUI();
                       OpenUI();
                   });
            }
            else
            {
                mWindow?.Open();
                RefreshUI();
                OpenUI();
            }
        }

        public void ShowHeroCardDetailByDefault(UnitMetaData aUnitMeta, Action<eDetailCloseType> aEndCallback = null)
        {
            //액션카드 상세 여부
            mIsActionDetail = false;
            //쇼타입 저장
            mShowType = eDetailShowType.DEFUALT;
            mActionCard = null;
            mHeroCard = null;
            mEndCall = aEndCallback;
            mCloseType = eDetailCloseType.NONE;

            if (mWindow == null)
            {
                UIManager.Instance.OpenUI<UIWindow>(eUIID.CARD_DETAIL,
                   (win) =>
                   {
                       mWindow = win;
                       //초기화
                       InitUI();
                       RefreshUI();
                       OpenUI();
                   });
            }
            else
            {
                mWindow?.Open();
                RefreshUI();
                OpenUI();
            }
        }
        #endregion

        #region [Public Method]
        public void RefreshUI()
        {
            //상세보기 타입 셋팅
            mContext.DetailShowType = mShowType;
            //액션 카드 인가 영웅카드 인가 여부
            mContext.IsActionCardDetail = mIsActionDetail;
            if (mIsActionDetail == true)
            {
                RefreshUIAction();
            }
            else
            {
                RefreshUIHero();
            }
            //능력치 셋팅.
            SettingCardAbilitySlot();
        }
        #endregion

        #region [Private Method]
        /// <summary>
        /// UI 오픈시 호출
        /// </summary>
        private void OpenUI()
        {
            //카드 미리보기 설정
            SettingCardPreviewPage();
            ChangePage(ePageActiveType.FIRST);
        }

        /// <summary>
        /// 액션 카드 강화 금액 셋팅
        /// </summary>
        private string SettingUpgradePriceByActionCard()
        {
            GrowthMetaData gMeta = null;
            if (mActionCard.IsMaxLevel)
            {
                gMeta = MetaDataManager.Instance.GetActionGrowthMetaData(mActionCard.Level);
            }
            else
            {
                gMeta = MetaDataManager.Instance.GetActionGrowthMetaData(mActionCard.Level + 1);
            }
            GrowthInfo gInfo = gMeta.GrowthInfoDic[eExpGoodsType.RESOURCE];
            string sPriceForm = string.Format(MetaDataManager.Instance.GetText(TextID.GOLD_ICON_FORM), gInfo.NeedValueByGrade[mActionCard.Grade].ToString("N0"));
            return sPriceForm;
        }

        /// <summary>
        /// 영웅 카드 강화 금액 셋팅
        /// </summary>
        private string SettingUpgradePriceByHeroCard()
        {
            BigUnitGrowthMetaData gMeta = MetaDataManager.Instance.GetBigUnitGrowthMetaData(mHeroCard.Level);
            if (mHeroCard.IsMaxLevel == false)
            {
                gMeta = MetaDataManager.Instance.GetBigUnitGrowthMetaData(mHeroCard.Level + 1);
            }
            //다음 레벨의 강화 정보 리턴
            BigUnitGrowthInfo gInfo = gMeta.BigUnitGrowthInfoDic[eExpGoodsType.RESOURCE];
            string sPriceForm = string.Format(MetaDataManager.Instance.GetText(TextID.GOLD_ICON_FORM), gInfo.NeedValue.ToString("N0"));
            return sPriceForm;
        }

        /// <summary>
        /// 플레이어 경험치 획득 : 액션카드 강화 시
        /// </summary>
        private string SettingPlayerExpValueByActionCard()
        {
            GrowthMetaData gMeta = null;
            if (mActionCard.IsMaxLevel)
            {
                gMeta = MetaDataManager.Instance.GetActionGrowthMetaData(mActionCard.Level);
            }
            else
            {
                gMeta = MetaDataManager.Instance.GetActionGrowthMetaData(mActionCard.Level + 1);
            }
            int iPlayerExp = gMeta.PlayerGetExpDic[mActionCard.Grade];
            string sForm = string.Format(MetaDataManager.Instance.GetText(TextID.PLUS_VALUE_FORM), iPlayerExp);
            return sForm;
        }

        /// <summary>
        /// 플레이어 경험치 획득 : 영웅카드 강화 시
        /// </summary>
        private string SettingPlayerExpValueByHeroCard()
        {
            BigUnitGrowthMetaData gMeta = MetaDataManager.Instance.GetBigUnitGrowthMetaData(mHeroCard.Level);
            if (mHeroCard.IsMaxLevel == false)
            {
                gMeta = MetaDataManager.Instance.GetBigUnitGrowthMetaData(mHeroCard.Level + 1);
            }
            string sForm = string.Format(MetaDataManager.Instance.GetText(TextID.PLUS_VALUE_FORM), gMeta.GetPlayerExp);
            return sForm;
        }

        /// <summary>
        /// 튜토리얼 클리어 여부 : 현재 액션카드만 튜토리얼 잡혀있음.
        /// </summary>
        private bool IsClearCommandTutorial()
        {
            if (mIsActionDetail == false) return true;
            if (GameSetting.Instance.USE_TUTORIAL == false) return true;
            if (mActionCard.CommandType == eCommandType.NONE || mActionCard.CommandType == eCommandType.NORMAL) return true;
            bool bIsClear = false;
            switch (mActionCard.CommandType)
            {
                case eCommandType.DRAG:
                    bIsClear = PlayerDataManager.Instance.TutorialData.IsClearTutorial(eOutTutorialCategory.COMMAND_DRAG);
                    break;
                case eCommandType.DOUBLE:
                    bIsClear = PlayerDataManager.Instance.TutorialData.IsClearTutorial(eOutTutorialCategory.COMMAND_DOUBLE);
                    break;
                case eCommandType.CHARGE:
                    bIsClear = PlayerDataManager.Instance.TutorialData.IsClearTutorial(eOutTutorialCategory.COMMAND_CHARGE);
                    break;
            }
            return bIsClear;
        }

        /// <summary>
        /// 액션카드 갱신
        /// </summary>
        private void RefreshUIAction()
        {
            //액션 카드 셋팅
            mSlotContext.SetActionCard(eCardSlotShowType.DETAIL_MAIN_SLOT, mActionCard);
            //버튼 클릭 비활성
            mSlotContext.IsDisableCardButton = true;
            //이름 셋팅
            mContext.CardName = mActionCard.Name;
            //카드 설명 셋팅.
            mContext.CardDesc = MetaDataManager.Instance.GetDescText(mActionCard.MetaID);
            //카드 타입 셋팅
            mContext.CardTypeValue = MetaDataManager.Instance.GetText(mActionCard.ActionMetaData.TypeTextID);
            //강화 가격 셋팅
            mContext.UpgradePrice = SettingUpgradePriceByActionCard();
            //플레이어 경험치 셋팅
            mContext.PlayerExpInfoValue = SettingPlayerExpValueByActionCard();
            //튜토리얼 클리어 여부
            mContext.IsClearCommandTutorial = IsClearCommandTutorial();
            //영웅 카드 마지막 슬롯 여부
            mContext.IsHeroLastSlot = false;
            SettingButtonRoot();
        }

        /// <summary>
        /// 영웅카드 갱신
        /// </summary>
        private void RefreshUIHero()
        {
            mSlotContext.SetHeroCard(eCardSlotShowType.DETAIL_MAIN_SLOT, mHeroCard);
            //버튼 클릭 비활성
            mSlotContext.IsDisableCardButton = true;
            //이름 셋팅
            mContext.CardName = mHeroCard.Name;
            //카드 설명 셋팅.
            mContext.CardDesc = MetaDataManager.Instance.GetDescText(mHeroCard.MetaID);
            //강화 가격 셋팅
            mContext.UpgradePrice = SettingUpgradePriceByHeroCard();
            //플레이어 경험치 셋팅
            mContext.PlayerExpInfoValue = SettingPlayerExpValueByHeroCard();
            //튜토리얼 클리어 여부
            mContext.IsClearCommandTutorial = IsClearCommandTutorial();
            //영웅 카드 마지막 슬롯 여부
            mContext.IsHeroLastSlot = mShowType == eDetailShowType.LAST_DECK_SLOT;
            SettingButtonRoot();
        }

        /// <summary>
        /// 액션카드 강화
        /// </summary>
        private void ProcessActionUpgrade()
        {
            if (mActionCard.IsMaxLevel)
            {
                DlgBaseUI.ShowDlg(MetaDataManager.Instance.GetText(TextID.ALREADY_MAX_LEVEL));
                return;
            }

            GrowthMetaData gMeta = MetaDataManager.Instance.GetActionGrowthMetaData(mActionCard.Level + 1);
            //자원 체크.
            int iHaveGold = PlayerDataManager.Instance.Gold;
            GrowthInfo gInfo = gMeta.GrowthInfoDic[eExpGoodsType.RESOURCE];
            int iNeedGold = gInfo.NeedValueByGrade[mActionCard.Grade];

            if (iHaveGold < iNeedGold)
            {
                DlgBaseUI.ShowDlg(MetaDataManager.Instance.GetText(TextID.NOT_ENOUGH_GOLD));
                return;
            }

            if (mActionCard.Total < mActionCard.GetNextLevelNeedCount())
            {
                DlgBaseUI.ShowDlg(MetaDataManager.Instance.GetText(TextID.NOT_ENOUGH_ACTION_CARD));
                return;
            }

            ActionCard beforeCard = new ActionCard(mActionCard.MetaID, mActionCard.Level, mActionCard.Total, mActionCard.GetCount);
            beforeCard.Init();
            NetworkManager.Instance.SendUpgradeActionCard(mActionCard.MetaID, mActionCard.Level,
                () =>
                {                  
                    mCloseType = eDetailCloseType.UPGRADE;
                    UpgradeUI upgradeUI = UIBaseList.Get<UpgradeUI>() as UpgradeUI;
                    upgradeUI.ShowUpgradeUIByActionCard(beforeCard, mActionCard,
                        () =>
                        {
                            if (PlayerDataManager.Instance.IsProductionLevel)
                            {
                                PlayerLevelUPUI levelUpUI = UIBaseList.Get<PlayerLevelUPUI>() as PlayerLevelUPUI;
                                levelUpUI.ShowPlayerLevelUP();
                            }
                            RefreshUI();
                        });
                });
        }

        /// <summary>
        /// 영웅카드 강화
        /// </summary>
        private void ProcessHeroUpgrade()
        {
            if (mHeroCard.IsMaxLevel)
            {
                DlgBaseUI.ShowDlg(MetaDataManager.Instance.GetText(TextID.ALREADY_MAX_LEVEL));
                return;
            }

            BigUnitGrowthMetaData gMeta = MetaDataManager.Instance.GetBigUnitGrowthMetaData(mHeroCard.Level + 1);
            //자원 체크.
            int iHaveGold = PlayerDataManager.Instance.Gold;
            BigUnitGrowthInfo gInfo = gMeta.BigUnitGrowthInfoDic[eExpGoodsType.RESOURCE];
            int iNeedGold = gInfo.NeedValue;

            if (iHaveGold < iNeedGold)
            {
                DlgBaseUI.ShowDlg(MetaDataManager.Instance.GetText(TextID.NOT_ENOUGH_GOLD));
                return;
            }

            BigUnitGrowthInfo sameInfo = gMeta.BigUnitGrowthInfoDic[eExpGoodsType.SAME_CARD];
            if (mHeroCard.Total < sameInfo.NeedValue)
            {
                DlgBaseUI.ShowDlg(MetaDataManager.Instance.GetText(TextID.NOT_ENOUGH_HERO_CARD));
                return;
            }

            UnitCard beforeCard = new UnitCard(mHeroCard.MetaID, mHeroCard.Level, mHeroCard.Total, mHeroCard.GetCount);
            beforeCard.Init();
            NetworkManager.Instance.SendUpgradeUnitCard(mHeroCard.MetaID, mHeroCard.Level,
                () =>
                {
                    mCloseType = eDetailCloseType.UPGRADE;

                    UpgradeUI upgradeUI = UIBaseList.Get<UpgradeUI>() as UpgradeUI;
                    upgradeUI.ShowUpgradeUIByHeroCard(beforeCard, mHeroCard,
                        () =>
                        {
                            if (PlayerDataManager.Instance.IsProductionLevel)
                            {
                                PlayerLevelUPUI levelUpUI = UIBaseList.Get<PlayerLevelUPUI>() as PlayerLevelUPUI;
                                levelUpUI.ShowPlayerLevelUP();
                            }
                            RefreshUI();
                        });
                });
        }

        /// <summary>
        /// 카드 능력치 셋팅
        /// </summary>
        private void SettingCardAbilitySlot(bool aIsShowMaxLevel = false)
        {
            int iMetaID = mIsActionDetail ? mActionCard.MetaID : mHeroCard.MetaID;
            int iLevel = mIsActionDetail ? mActionCard.Level : mHeroCard.Level;
            int iNextLevel = 1;
            if (mIsActionDetail)
            {
                iNextLevel = mActionCard.IsMaxLevel ? iLevel : iLevel + 1;
            }
            else
            {
                iNextLevel = mHeroCard.IsMaxLevel ? iLevel : iLevel + 1;
            }

            if (aIsShowMaxLevel)
            {
                iLevel = iNextLevel = mIsActionDetail ? MetaDataManager.Instance.GetActionGrowthMaxLevel() : MetaDataManager.Instance.GetBigUnitGrowthMaxLevel();
            }

            //스탯 Meta 정보 리턴.
            StatMarkMetaData statMeta = MetaDataManager.Instance.GetStatMarkMetaData(iMetaID);
            if (statMeta == null) return;
            //능력치가 변경된 리스트 리턴.
            List<NextStatTypeInfo> changeList = statMeta.GetCardStatListIncludeChangeValue(iLevel, iNextLevel);

            UI.Deck.CardStatSlotUIContext[] slotArr = new UI.Deck.CardStatSlotUIContext[Constants.CARD_DETAIL_ABILITY_SLOT_COUNT];

            for (int i = 0; i < slotArr.Length; i++)
            {
                UI.Deck.CardStatSlotUIContext slot = new UI.Deck.CardStatSlotUIContext();
                slot.AbilityShowType = eCardAbilityShowType.NONE;
                if (i < changeList.Count)
                {
                    slot.SlotIndex = i;
                    //타입 셋팅
                    slot.AbilityShowType = changeList[i].AddValue > 0 ? eCardAbilityShowType.UPGRADE : eCardAbilityShowType.NORMAL;
                    //이미지 셋팅
                    slot.IconName = changeList[i].StatIconNameText;
                    //타이틀 셋팅.
                    slot.TitleText = changeList[i].StatTitleText;
                    //값 셋팅.
                    slot.StatValue = changeList[i].StatValue;
                    //추가 값 셋팅.
                    slot.StatAddValue = string.Format(MetaDataManager.Instance.GetText(TextID.PLUS_VALUE_FORM), changeList[i].AddValue);
                    //링크 여부
                    slot.IsLinked = changeList[i].IsLinked;
                    //링크 인덱스
                    slot.LinkMetaID = changeList[i].LinkedMetaID;
                    //최대 레벨 보여주기 여부.
                    slot.IsShowMaxLevel = aIsShowMaxLevel;
                    //링크 버튼 콜백
                    slot.OnClickLinkCallback = OnClickLinkedCallback;
                }
                slotArr[i] = slot;
            }
            mContext.CardStatSlotArr = slotArr;
        }

        /// <summary>
        /// 미리보기 설정
        /// </summary>
        private void SettingCardPreviewPage()
        {
            UIBaseList.Get<MVVM.CardPreviewUI>().InitUI(
                mContext.CardPreviewUIContext, mActionCard != null ? (CardBase)mActionCard : (CardBase)mHeroCard);
        }

        private void SettingButtonRoot()
        {
            switch (mShowType)
            {
                case eDetailShowType.DEFUALT:
                    {
                        mContext.IsShowActiveButtonRoot = false;
                        mContext.IsClearCommandTutorial = true;
                    }break;
                case eDetailShowType.LAST_DECK_SLOT:
                case eDetailShowType.MY_DECK_EQUIPED:
                case eDetailShowType.MY_DECK:
                    {
                        mContext.IsShowActiveButtonRoot = mContext.IsClearCommandTutorial;
                    }break;
            }
        }

        /// <summary>
        /// 페이지 변경
        /// </summary>
        private void ChangePage(ePageActiveType page)
        {
            if (mContext.PageBtnType != page)
            {
                mContext.IsActiveNextPageBtn = mContext.IsActionCardDetail ? page < ePageActiveType.MIDDLE : page < ePageActiveType.END;
                mContext.CurrentPage = (int)page;
                mContext.PageBtnType = page;

                switch (mContext.PageBtnType)
                {
                    case ePageActiveType.FIRST:
                        UIBaseList.Get<MVVM.CardPreviewUI>().EndPreview();
                        HideHeroPreview();
                        break;
                    case ePageActiveType.MIDDLE:
                        UIBaseList.Get<MVVM.CardPreviewUI>().PlayPreview();
                        HideHeroPreview();
                        break;
                    case ePageActiveType.END:
                        UIBaseList.Get<MVVM.CardPreviewUI>().EndPreview();
                        CreateHeroPreview();
                        break;
                }
            }
        }


        /// <summary>
        /// 영웅 미리보기 생성
        /// </summary>
        private async void CreateHeroPreview()
        {
            if (mHeroCard == null) return;

            var hero = await LobbyHeroPool.Instance.LoadOrGetHeroAsync(mHeroCard.MetaID);
            if (hero == null) return;

            hero.Show(true);
            hero.InitializeByLobbyCharacter();
            hero.MainCharacterPlay(Constants.MAIN_CHARACTER_APPEAR_ANIMATION_KEY);
            //hero.SetFov(15);
            var rt = LobbyHeroPool.Instance.RT;
            hero.Camera.targetTexture = rt;
            mContext.HeroPreviewRawImage = rt;
            mContext.IsActiveHeroPreview = true;
            previewHero = hero;

            mContext.OnClickHeroPreviewCallback = previewHero.OnClick;
            mContext.OnBeginDragHeroPreviewCallback = previewHero.OnBeginDrag;
            mContext.OnEndDragHeroPreviewCallback = previewHero.OnEndDrag;
            mContext.OnDragPreviewCallback = previewHero.OnDrag;
            mContext.RawImageComponent.SetNativeSize();
        }

        private void HideHeroPreview()
        {
            if(previewHero != null)
            {
                mContext.IsActiveHeroPreview = false;
                previewHero.RestoreFov();
                previewHero.Show(false);
                previewHero = null;
            }
        }
        #endregion

        #region [Callback Method]
        public void CloseCallback(eDetailCloseType aCloseType)
        {
            if (mCloseType != eDetailCloseType.NONE)
            {
                mEndCall?.Invoke(mCloseType);
            }
            else
            {
                mEndCall?.Invoke(aCloseType);
            }
            Close();
        }

        public void ClickPageButton(bool aIsNext)
        {
            ePageActiveType page = mContext.PageBtnType;
            if (aIsNext == false)
            {
                if (mContext.CurrentPage == (int)ePageActiveType.FIRST) return;
                page = (ePageActiveType)(mContext.CurrentPage - 1);
            }
            else
            {
                if (mContext.CurrentPage == (int)ePageActiveType.END) return;
                page = (ePageActiveType)(mContext.CurrentPage + 1);
            }

            ChangePage(page);
        }

        /// <summary>
        /// 강화 콜백
        /// </summary>
        public void UpgradeCallback()
        {
            if (mIsActionDetail)
            {
                ProcessActionUpgrade();
            }
            else
            {
                ProcessHeroUpgrade();
            }
        }

        /// <summary>
        /// Max 버튼 누르고 있을시
        /// </summary>
        public void PressDownMaxLevelBtn()
        {
            int iMaxLevel = mIsActionDetail ? MetaDataManager.Instance.GetActionGrowthMaxLevel() : MetaDataManager.Instance.GetBigUnitGrowthMaxLevel();
            mSlotContext.LevelForm = string.Format(MetaDataManager.Instance.GetText(TextID.LEVEL_FORM), iMaxLevel);
            SettingCardAbilitySlot(true);
        }

        /// <summary>
        /// Max 버튼 떼었을 경우
        /// </summary>
        public void PressUpMaxLevelBtn()
        {
            int iLevel = mIsActionDetail ? mActionCard.Level : mHeroCard.Level;
            mSlotContext.LevelForm = string.Format(MetaDataManager.Instance.GetText(TextID.LEVEL_FORM), iLevel);
            SettingCardAbilitySlot(false);
        }

        /// <summary>
        /// 튜토리얼 버튼 콜백
        /// </summary>
        public void ClickTutorialBtn()
        {
            eOutTutorialCategory category = eOutTutorialCategory.NONE;
            int iTutorialStep = Constants.TUTORIAL_STEP_1;
            int iOrder = Constants.TUTORIAL_ORDER_1;
            switch (mActionCard.CommandType)
            {
                case eCommandType.DOUBLE:
                    category = eOutTutorialCategory.COMMAND_DOUBLE;
                    break;
                case eCommandType.CHARGE:
                    category = eOutTutorialCategory.COMMAND_CHARGE;
                    break;
                case eCommandType.DRAG:
                    category = eOutTutorialCategory.COMMAND_DRAG;
                    break;
            }
            //시작 조건 체크.
            bool bIsPlayAble = PlayerDataManager.Instance.TutorialData.CheckOutTutorialByStartCondition(category, iTutorialStep, iOrder);
            if (bIsPlayAble == false)
            {
                //"이전 튜토리얼을 모두 완료하세요."
                DlgBaseUI.ShowDlg(TextID.NOT_COMPLETE_TUTORIAL);
                return;
            }
            PlayerDataManager.Instance.TutorialData.SettingStepByOrder(category, iTutorialStep, iOrder);

            //튜토리얼 진행 상황 셋팅.
            MainManager.Instance.SettingTutorialBattle(true);
            PlayerDataManager.Instance.HostPlayer = true;
            CoroutineManager.Instance.StartCoroutine(Coroutine_ChangeBattleScene());
        }

        public void ClickSetMainHeroButton()
        {
            PlayerPrefsManager.SetValue(PlayerPrefsManager.MAIN_HERO_META_ID, mHeroCard.MetaID);

            DlgBaseUI.ShowDlg(TextID.COMLETE_CHANGE_HERO);
        }

        /// <summary>
        /// 튜토리얼 전투 씬 변경
        /// </summary>
        private IEnumerator Coroutine_ChangeBattleScene()
        {
            Close(
                () =>
                {
                    MainUI main = UIBaseList.Get<MainUI>() as MainUI;
                    main.CloseNoAction();
                });
            CustomScene.SceneManager.Instance.ChangeScene(eSceneID.TUTORIAL);
            while (!CustomScene.SceneManager.Instance.IsDone)
            {
                yield return null;
            }
            yield return new WaitForSeconds(1f);
        }

        /// <summary>
        /// 링크 버튼 누르면 호출
        /// </summary>
        public void OnClickLinkedCallback(int aSlotIndex, int aLinkedMetaID)
        {
            //해당 슬롯 인덱스의 스탯 슬롯 정보 리턴
            UI.Deck.CardStatSlotUIContext slotContext = mContext.CardStatSlotArr[aSlotIndex];
            RectTransform rectTr = slotContext.RectTr;
            //카드 타입에 따른 상세카드 MetaID 리턴
            int iMetaID = mIsActionDetail ? mActionCard.MetaID : mHeroCard.MetaID;
            int iLevel = mIsActionDetail ? mActionCard.Level : mHeroCard.Level;
            //홀수 여부
            bool bIsOdd = aSlotIndex % 2 != 0;
            CardDetailLinkStatUI linkUI = UIBaseList.Get<CardDetailLinkStatUI>() as CardDetailLinkStatUI;
            linkUI.ShowLinkStatUI(mIsActionDetail, iMetaID, iLevel, aLinkedMetaID, bIsOdd, rectTr);
        }
        #endregion
    }
}
