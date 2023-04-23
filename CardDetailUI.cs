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
                //�÷��̾� ����ġ ���� Text
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
                //��ũ�� ������ ����.
                CurrentPage = (int)ePageActiveType.FIRST,
                //���� ������ �����ΰ� ����
                IsHaveCardSlot = bIsHaveSlotCard,
                OnCloseCallback = CloseCallback,
                OnUpgrageCallback = UpgradeCallback,
                OnClickPageCallback = ClickPageButton,
                OnClickTutorialCallback = ClickTutorialBtn,
                OnClickSetMainHeroCallback = ClickSetMainHeroButton,
                CardPreviewUIContext = new UI.CardPreview.CardPreviewUIContext()
            };

            mWindow.view.SetContext(mContext);
            //�׼� ī�� �ΰ� ����ī�� �ΰ� ����
            mContext.IsActionCardDetail = mIsActionDetail;            
            //ī�� ���� ����
            mSlotContext = new UI.Card.CardSlotUIContext();
            //ī�� ���� ����
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
        /// �׼�ī�� �� ����
        /// </summary>        
        public void ShowCardDetailUI(eDetailShowType aShowType, ActionCard aAction, Action<eDetailCloseType> aEndCallback = null)
        {
            //�׼�ī�� �� ����
            mIsActionDetail = true;
            //��Ÿ�� ����
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

                       //�ʱ�ȭ
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
        /// ����ī�� �󼼺���
        /// </summary>        
        public void ShowCardDetailUI(eDetailShowType aShowType, UnitCard aUnit, Action<eDetailCloseType> aEndCallback = null)
        {
            //�׼�ī�� �� ����
            mIsActionDetail = false;
            //��Ÿ�� ����
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

                       //�ʱ�ȭ
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
            //�׼�ī�� �� ����
            mIsActionDetail = false;
            //��Ÿ�� ����
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
                       //�ʱ�ȭ
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
            //�󼼺��� Ÿ�� ����
            mContext.DetailShowType = mShowType;
            //�׼� ī�� �ΰ� ����ī�� �ΰ� ����
            mContext.IsActionCardDetail = mIsActionDetail;
            if (mIsActionDetail == true)
            {
                RefreshUIAction();
            }
            else
            {
                RefreshUIHero();
            }
            //�ɷ�ġ ����.
            SettingCardAbilitySlot();
        }
        #endregion

        #region [Private Method]
        /// <summary>
        /// UI ���½� ȣ��
        /// </summary>
        private void OpenUI()
        {
            //ī�� �̸����� ����
            SettingCardPreviewPage();
            ChangePage(ePageActiveType.FIRST);
        }

        /// <summary>
        /// �׼� ī�� ��ȭ �ݾ� ����
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
        /// ���� ī�� ��ȭ �ݾ� ����
        /// </summary>
        private string SettingUpgradePriceByHeroCard()
        {
            BigUnitGrowthMetaData gMeta = MetaDataManager.Instance.GetBigUnitGrowthMetaData(mHeroCard.Level);
            if (mHeroCard.IsMaxLevel == false)
            {
                gMeta = MetaDataManager.Instance.GetBigUnitGrowthMetaData(mHeroCard.Level + 1);
            }
            //���� ������ ��ȭ ���� ����
            BigUnitGrowthInfo gInfo = gMeta.BigUnitGrowthInfoDic[eExpGoodsType.RESOURCE];
            string sPriceForm = string.Format(MetaDataManager.Instance.GetText(TextID.GOLD_ICON_FORM), gInfo.NeedValue.ToString("N0"));
            return sPriceForm;
        }

        /// <summary>
        /// �÷��̾� ����ġ ȹ�� : �׼�ī�� ��ȭ ��
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
        /// �÷��̾� ����ġ ȹ�� : ����ī�� ��ȭ ��
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
        /// Ʃ�丮�� Ŭ���� ���� : ���� �׼�ī�常 Ʃ�丮�� ��������.
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
        /// �׼�ī�� ����
        /// </summary>
        private void RefreshUIAction()
        {
            //�׼� ī�� ����
            mSlotContext.SetActionCard(eCardSlotShowType.DETAIL_MAIN_SLOT, mActionCard);
            //��ư Ŭ�� ��Ȱ��
            mSlotContext.IsDisableCardButton = true;
            //�̸� ����
            mContext.CardName = mActionCard.Name;
            //ī�� ���� ����.
            mContext.CardDesc = MetaDataManager.Instance.GetDescText(mActionCard.MetaID);
            //ī�� Ÿ�� ����
            mContext.CardTypeValue = MetaDataManager.Instance.GetText(mActionCard.ActionMetaData.TypeTextID);
            //��ȭ ���� ����
            mContext.UpgradePrice = SettingUpgradePriceByActionCard();
            //�÷��̾� ����ġ ����
            mContext.PlayerExpInfoValue = SettingPlayerExpValueByActionCard();
            //Ʃ�丮�� Ŭ���� ����
            mContext.IsClearCommandTutorial = IsClearCommandTutorial();
            //���� ī�� ������ ���� ����
            mContext.IsHeroLastSlot = false;
            SettingButtonRoot();
        }

        /// <summary>
        /// ����ī�� ����
        /// </summary>
        private void RefreshUIHero()
        {
            mSlotContext.SetHeroCard(eCardSlotShowType.DETAIL_MAIN_SLOT, mHeroCard);
            //��ư Ŭ�� ��Ȱ��
            mSlotContext.IsDisableCardButton = true;
            //�̸� ����
            mContext.CardName = mHeroCard.Name;
            //ī�� ���� ����.
            mContext.CardDesc = MetaDataManager.Instance.GetDescText(mHeroCard.MetaID);
            //��ȭ ���� ����
            mContext.UpgradePrice = SettingUpgradePriceByHeroCard();
            //�÷��̾� ����ġ ����
            mContext.PlayerExpInfoValue = SettingPlayerExpValueByHeroCard();
            //Ʃ�丮�� Ŭ���� ����
            mContext.IsClearCommandTutorial = IsClearCommandTutorial();
            //���� ī�� ������ ���� ����
            mContext.IsHeroLastSlot = mShowType == eDetailShowType.LAST_DECK_SLOT;
            SettingButtonRoot();
        }

        /// <summary>
        /// �׼�ī�� ��ȭ
        /// </summary>
        private void ProcessActionUpgrade()
        {
            if (mActionCard.IsMaxLevel)
            {
                DlgBaseUI.ShowDlg(MetaDataManager.Instance.GetText(TextID.ALREADY_MAX_LEVEL));
                return;
            }

            GrowthMetaData gMeta = MetaDataManager.Instance.GetActionGrowthMetaData(mActionCard.Level + 1);
            //�ڿ� üũ.
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
        /// ����ī�� ��ȭ
        /// </summary>
        private void ProcessHeroUpgrade()
        {
            if (mHeroCard.IsMaxLevel)
            {
                DlgBaseUI.ShowDlg(MetaDataManager.Instance.GetText(TextID.ALREADY_MAX_LEVEL));
                return;
            }

            BigUnitGrowthMetaData gMeta = MetaDataManager.Instance.GetBigUnitGrowthMetaData(mHeroCard.Level + 1);
            //�ڿ� üũ.
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
        /// ī�� �ɷ�ġ ����
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

            //���� Meta ���� ����.
            StatMarkMetaData statMeta = MetaDataManager.Instance.GetStatMarkMetaData(iMetaID);
            if (statMeta == null) return;
            //�ɷ�ġ�� ����� ����Ʈ ����.
            List<NextStatTypeInfo> changeList = statMeta.GetCardStatListIncludeChangeValue(iLevel, iNextLevel);

            UI.Deck.CardStatSlotUIContext[] slotArr = new UI.Deck.CardStatSlotUIContext[Constants.CARD_DETAIL_ABILITY_SLOT_COUNT];

            for (int i = 0; i < slotArr.Length; i++)
            {
                UI.Deck.CardStatSlotUIContext slot = new UI.Deck.CardStatSlotUIContext();
                slot.AbilityShowType = eCardAbilityShowType.NONE;
                if (i < changeList.Count)
                {
                    slot.SlotIndex = i;
                    //Ÿ�� ����
                    slot.AbilityShowType = changeList[i].AddValue > 0 ? eCardAbilityShowType.UPGRADE : eCardAbilityShowType.NORMAL;
                    //�̹��� ����
                    slot.IconName = changeList[i].StatIconNameText;
                    //Ÿ��Ʋ ����.
                    slot.TitleText = changeList[i].StatTitleText;
                    //�� ����.
                    slot.StatValue = changeList[i].StatValue;
                    //�߰� �� ����.
                    slot.StatAddValue = string.Format(MetaDataManager.Instance.GetText(TextID.PLUS_VALUE_FORM), changeList[i].AddValue);
                    //��ũ ����
                    slot.IsLinked = changeList[i].IsLinked;
                    //��ũ �ε���
                    slot.LinkMetaID = changeList[i].LinkedMetaID;
                    //�ִ� ���� �����ֱ� ����.
                    slot.IsShowMaxLevel = aIsShowMaxLevel;
                    //��ũ ��ư �ݹ�
                    slot.OnClickLinkCallback = OnClickLinkedCallback;
                }
                slotArr[i] = slot;
            }
            mContext.CardStatSlotArr = slotArr;
        }

        /// <summary>
        /// �̸����� ����
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
        /// ������ ����
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
        /// ���� �̸����� ����
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
        /// ��ȭ �ݹ�
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
        /// Max ��ư ������ ������
        /// </summary>
        public void PressDownMaxLevelBtn()
        {
            int iMaxLevel = mIsActionDetail ? MetaDataManager.Instance.GetActionGrowthMaxLevel() : MetaDataManager.Instance.GetBigUnitGrowthMaxLevel();
            mSlotContext.LevelForm = string.Format(MetaDataManager.Instance.GetText(TextID.LEVEL_FORM), iMaxLevel);
            SettingCardAbilitySlot(true);
        }

        /// <summary>
        /// Max ��ư ������ ���
        /// </summary>
        public void PressUpMaxLevelBtn()
        {
            int iLevel = mIsActionDetail ? mActionCard.Level : mHeroCard.Level;
            mSlotContext.LevelForm = string.Format(MetaDataManager.Instance.GetText(TextID.LEVEL_FORM), iLevel);
            SettingCardAbilitySlot(false);
        }

        /// <summary>
        /// Ʃ�丮�� ��ư �ݹ�
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
            //���� ���� üũ.
            bool bIsPlayAble = PlayerDataManager.Instance.TutorialData.CheckOutTutorialByStartCondition(category, iTutorialStep, iOrder);
            if (bIsPlayAble == false)
            {
                //"���� Ʃ�丮���� ��� �Ϸ��ϼ���."
                DlgBaseUI.ShowDlg(TextID.NOT_COMPLETE_TUTORIAL);
                return;
            }
            PlayerDataManager.Instance.TutorialData.SettingStepByOrder(category, iTutorialStep, iOrder);

            //Ʃ�丮�� ���� ��Ȳ ����.
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
        /// Ʃ�丮�� ���� �� ����
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
        /// ��ũ ��ư ������ ȣ��
        /// </summary>
        public void OnClickLinkedCallback(int aSlotIndex, int aLinkedMetaID)
        {
            //�ش� ���� �ε����� ���� ���� ���� ����
            UI.Deck.CardStatSlotUIContext slotContext = mContext.CardStatSlotArr[aSlotIndex];
            RectTransform rectTr = slotContext.RectTr;
            //ī�� Ÿ�Կ� ���� ��ī�� MetaID ����
            int iMetaID = mIsActionDetail ? mActionCard.MetaID : mHeroCard.MetaID;
            int iLevel = mIsActionDetail ? mActionCard.Level : mHeroCard.Level;
            //Ȧ�� ����
            bool bIsOdd = aSlotIndex % 2 != 0;
            CardDetailLinkStatUI linkUI = UIBaseList.Get<CardDetailLinkStatUI>() as CardDetailLinkStatUI;
            linkUI.ShowLinkStatUI(mIsActionDetail, iMetaID, iLevel, aLinkedMetaID, bIsOdd, rectTr);
        }
        #endregion
    }
}
