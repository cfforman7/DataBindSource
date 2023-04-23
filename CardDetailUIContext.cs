using Slash.Unity.DataBind.Core.Data;
using System;
using UI.CardPreview;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Deck
{
    public class CardDetailUIContext : Context
    {
        /// <summary>
        /// ������ ���� Ÿ��
        /// </summary>
        private readonly Property<eDetailShowType> detailShowTypeProperty = new Property<eDetailShowType>();
        public eDetailShowType DetailShowType { get => detailShowTypeProperty.Value; set => detailShowTypeProperty.Value = value; }

        /// <summary>
        /// �׼� ī�� �ΰ� ����
        /// </summary>
        private readonly Property<bool> isActionCardDetailProperty = new Property<bool>();
        public bool IsActionCardDetail { get => isActionCardDetailProperty.Value; set => isActionCardDetailProperty.Value = value; }

        /// <summary>
        /// ī�� ���� ����
        /// </summary>
        private readonly Property<Card.CardSlotUIContext> cardSlotProperty = new Property<Card.CardSlotUIContext>();
        public Card.CardSlotUIContext CardSlot { get => cardSlotProperty.Value; set => cardSlotProperty.Value = value; }
        
        /// <summary>
        /// ī�� �̸�
        /// </summary>
        private readonly Property<string> cardNameProperty = new Property<string>();
        public string CardName { get => cardNameProperty.Value; set => cardNameProperty.Value = value; }

        /// <summary>
        /// ī�� ����
        /// </summary>
        private readonly Property<string> cardDescProperty = new Property<string>();
        public string CardDesc { get => cardDescProperty.Value; set => cardDescProperty.Value = value; }

        /// <summary>
        /// Ÿ�� �� Text
        /// </summary>
        private readonly Property<string> cardTypeValueProperty = new Property<string>();
        public string CardTypeValue { get => cardTypeValueProperty.Value; set => cardTypeValueProperty.Value = value; }

        /// <summary>
        /// ���׷��̵� �ؽ�Ʈ
        /// </summary>
        private readonly Property<string> upgradeTextProperty = new Property<string>();
        public string UpgradeText { get => upgradeTextProperty.Value; set => upgradeTextProperty.Value = value; }

        /// <summary>
        /// ���׷��̵� ��� text
        /// </summary>
        private readonly Property<string> upgradePriceProperty = new Property<string>();
        public string UpgradePrice { get => upgradePriceProperty.Value; set => upgradePriceProperty.Value = value; }

        /// <summary>
        /// ��ü text
        /// </summary>
        private readonly Property<string> swapTextProperty = new Property<string>();
        public string SwapText { get => swapTextProperty.Value; set => swapTextProperty.Value = value; }

        /// <summary>
        /// �÷��̾� ����ġ ���� Text
        /// </summary>
        private readonly Property<string> playerExpInfoTextProperty = new Property<string>();
        public string PlayerExpInfoText { get => playerExpInfoTextProperty.Value; set => playerExpInfoTextProperty.Value = value; }

        /// <summary>
        /// �÷��̾� ����ġ ��
        /// </summary>
        private readonly Property<string> playerExpInfoValueProperty = new Property<string>();
        public string PlayerExpInfoValue { get => playerExpInfoValueProperty.Value; set => playerExpInfoValueProperty.Value = value; }

        /// <summary>
        /// �÷��̾� Ʃ�丮�� �ؽ�Ʈ
        /// </summary>
        private readonly Property<string> playTutorialTextProperty = new Property<string>();
        public string PlayTutorialText { get => playTutorialTextProperty.Value; set => playTutorialTextProperty.Value = value; }

        /// <summary>
        /// �÷��̾� Ʃ�丮�� �ȳ� �ؽ�Ʈ
        /// </summary>
        private readonly Property<string> playTutorialInfoTextProperty = new Property<string>();
        public string PlayTutorialInfoText { get => playTutorialInfoTextProperty.Value; set => playTutorialInfoTextProperty.Value = value; }

        /// <summary>
        /// ���� Text
        /// </summary>
        private readonly Property<string> equipTextProperty = new Property<string>();
        public string EquipText { get => equipTextProperty.Value; set => equipTextProperty.Value = value; }

        /// <summary>
        /// �ν�Ʈ Text
        /// </summary>
        private readonly Property<string> boostTextProperty = new Property<string>();
        public string BoostText { get => boostTextProperty.Value; set => boostTextProperty.Value = value; }

        /// <summary>
        /// ���� Text
        /// </summary>
        private readonly Property<string> resetTextProperty = new Property<string>();
        public string ResetText { get => resetTextProperty.Value; set => resetTextProperty.Value = value; }

        /// <summary>
        /// MAX Text
        /// </summary>
        private readonly Property<string> maxTextProperty = new Property<string>();
        public string MaxText { get => maxTextProperty.Value; set => maxTextProperty.Value = value; }

        /// <summary>
        /// ���� �Ұ� Text
        /// </summary>
        private readonly Property<string> noChangeTextProperty = new Property<string>();
        public string NoChangeText { get => noChangeTextProperty.Value; set => noChangeTextProperty.Value = value; }

        /// <summary>
        /// Ʃ�丮�� Ŭ���� ����
        /// </summary>
        private readonly Property<bool> isClearCommandTutorialProperty = new Property<bool>();
        public bool IsClearCommandTutorial { get => isClearCommandTutorialProperty.Value; set => isClearCommandTutorialProperty.Value = value; }

        /// <summary>
        /// ��ư Ȱ��ȭ ����
        /// </summary>
        private readonly Property<bool> isShowActiveButtonRootProperty = new Property<bool>();
        public bool IsShowActiveButtonRoot { get => isShowActiveButtonRootProperty.Value; set => isShowActiveButtonRootProperty.Value = value; }

        /// <summary>
        /// �� ������ ����
        /// </summary>
        private readonly Property<bool> isHaveCardSlotProperty = new Property<bool>();
        public bool IsHaveCardSlot { get => isHaveCardSlotProperty.Value; set => isHaveCardSlotProperty.Value = value; }

        /// <summary>
        /// ���� ����
        /// </summary>
        private readonly Property<bool> isMaxLevelProperty = new Property<bool>();
        public bool IsMaxLevel { get => isMaxLevelProperty.Value; set => isMaxLevelProperty.Value = value; }

        /// <summary>
        /// ������ ��ư Ÿ��
        /// </summary>
        private readonly Property<ePageActiveType> pageBtnTypeProperty = new Property<ePageActiveType>();
        public ePageActiveType PageBtnType { get => pageBtnTypeProperty.Value; set => pageBtnTypeProperty.Value = value; }

        /// <summary>
        /// ���� ���� ������ ���� ����
        /// </summary>
        private readonly Property<bool> isHeroLastSlotProperty = new Property<bool>();
        public bool IsHeroLastSlot { get => isHeroLastSlotProperty.Value; set => isHeroLastSlotProperty.Value = value; }

        /// <summary>
        /// �ɷ�ġ ����Ʈ Context
        /// </summary>
        private readonly Property<CardStatSlotUIContext[]> cardStatSlotArrProperty = new Property<CardStatSlotUIContext[]>();
        public CardStatSlotUIContext[] CardStatSlotArr { get => cardStatSlotArrProperty.Value; set => cardStatSlotArrProperty.Value = value; }

        /// <summary>
        /// ��ũ�� ���� ������
        /// </summary>
        private readonly Property<int> currentPageProperty = new Property<int>();
        public int CurrentPage { get => currentPageProperty.Value; set => currentPageProperty.Value = value; }

        /// <summary>
        /// �ƽ� ��ư ������Ʈ
        /// </summary>
        private readonly Property<GameObject> maxButtonProperty = new Property<GameObject>();
        public GameObject MaxButton { get => maxButtonProperty.Value; set => maxButtonProperty.Value = value; }

        /// <summary>
        /// ���� ������ ��ư Ȱ��ȭ
        /// </summary>
        private readonly Property<bool> isActiveNextPageBtnProperty = new Property<bool>(true);
        public bool IsActiveNextPageBtn { get => isActiveNextPageBtnProperty.Value; set => isActiveNextPageBtnProperty.Value = value; }

        private readonly Property<CardPreviewUIContext> cardPreviewUIContextProperty = new Property<CardPreviewUIContext>();
        public CardPreviewUIContext CardPreviewUIContext { get => cardPreviewUIContextProperty.Value; set => cardPreviewUIContextProperty.Value = value; }

        private readonly Property<bool> isActiveHeroPreviewProperty = new Property<bool>();
        public bool IsActiveHeroPreview { get => isActiveHeroPreviewProperty.Value; set => isActiveHeroPreviewProperty.Value = value; }

        private readonly Property<Texture> heroPreviewRawImageProperty = new Property<Texture>();
        public Texture HeroPreviewRawImage { get => heroPreviewRawImageProperty.Value; set => heroPreviewRawImageProperty.Value = value; }

        private readonly Property<RawImage> rawImageComponentProperty = new Property<RawImage>();
        public RawImage RawImageComponent { get => rawImageComponentProperty.Value; set => rawImageComponentProperty.Value = value; }

        #region [Delegate Method]
        public delegate void ClickPageButtonCallback(bool aIsNext);
        public ClickPageButtonCallback OnClickPageCallback { get; set; }

        public delegate void ClickCloseCallback(eDetailCloseType aCloseType);
        public ClickCloseCallback OnCloseCallback { get; set; }

        public delegate void UpgradeCallback();
        public UpgradeCallback OnUpgrageCallback { get; set; }

        public delegate void ClickTutorialButtonCallback();
        public ClickTutorialButtonCallback OnClickTutorialCallback { get; set; }

        public delegate void ClickSetMainHeroButtonCallback();
        public ClickSetMainHeroButtonCallback OnClickSetMainHeroCallback { get; set; }

        #endregion


        #region [Event Method]
        /// <summary>
        /// �ݱ� ��ư
        /// </summary>
        public void ClickCloseBtn()
        {
            OnCloseCallback?.Invoke(eDetailCloseType.NONE);
        }

        /// <summary>
        /// ��ȭ ��ư
        /// </summary>
        public void ClickUpgradeBtn()
        {
            OnUpgrageCallback?.Invoke();
        }

        /// <summary>
        /// ��ü ��ư
        /// </summary>
        public void ClickSwapBtn()
        {
            if (IsActionCardDetail)
            {
                OnCloseCallback?.Invoke(eDetailCloseType.SWAP_ACTION);
            }
            else
            {
                OnCloseCallback?.Invoke(eDetailCloseType.SWAP_HERO);
            }
        }

        /// <summary>
        /// ���� ��ư
        /// </summary>
        public void ClickEquipBtn()
        {
            if (IsActionCardDetail)
            {
                OnCloseCallback?.Invoke(eDetailCloseType.EQUIP_ACTION);
            }
            else
            {
                OnCloseCallback?.Invoke(eDetailCloseType.EQUIP_HERO);
            }
        }

        /// <summary>
        /// Ʃ�丮�� ��ư
        /// </summary>
        public void ClickTutorialBtn()
        {
            OnClickTutorialCallback?.Invoke();
        }

        /// <summary>
        /// ���� ��ư
        /// </summary>
        public void ClickPrevBtn()
        {
            OnClickPageCallback?.Invoke(false);
        }

        /// <summary>
        /// ���� ��ư
        /// </summary>
        public void ClickNextBtn()
        {
            OnClickPageCallback?.Invoke(true);
        }

        /// <summary>
        /// �ν�Ʈ ��ư Ŭ��
        /// </summary>
        public void ClickBoostBtn()
        {

        }

        public void ClickResetBtn()
        {

        }

        /// <summary>
        /// ��ǥ ĳ���� ���� ��ư Ŭ��
        /// </summary>
        public void OnClickSetMainHeroBtn()
        {
            OnClickSetMainHeroCallback?.Invoke();
        }

        public Action OnClickHeroPreviewCallback { get; set; }
        public Action OnBeginDragHeroPreviewCallback { get; set; }
        public Action OnEndDragHeroPreviewCallback { get; set; }
        public Action OnDragPreviewCallback { get; set; }

        /// <summary>
        /// ���� �̸����� ��ư Ŭ��
        /// </summary>
        public void OnClickHeroPreviewButton()
        {
            OnClickHeroPreviewCallback?.Invoke();
        }

        public void OnBeginDragPreview()
        {
            OnBeginDragHeroPreviewCallback?.Invoke();
        }
        public void OnEndDragPreview()
        {
            OnEndDragHeroPreviewCallback?.Invoke();
        }
        public void OnDragPreview()
        {
            OnDragPreviewCallback?.Invoke();
        }
        #endregion
    }
}
