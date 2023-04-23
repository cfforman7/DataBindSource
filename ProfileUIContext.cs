using Slash.Unity.DataBind.Core.Data;
using UnityEngine;
using UI.Main.BattleRecord;

namespace UI.Profile
{
    public class ProfileUIContext : Context
    {
        /// <summary>
        /// ������ Text
        /// </summary>
        private readonly Property<string> profileTitleTextProperty = new Property<string>();
        public string ProfileTitleText { get => profileTitleTextProperty.Value; set => profileTitleTextProperty.Value = value; }

        /// <summary>
        /// No Guild Text
        /// </summary>
        private readonly Property<string> noGuildTextProperty = new Property<string>();
        public string NoGuildText { get => noGuildTextProperty.Value; set => noGuildTextProperty.Value = value; }

        /// <summary>
        /// ���� �̸�
        /// </summary>
        private readonly Property<string> userNameProperty = new Property<string>();
        public string UserName { get => userNameProperty.Value; set => userNameProperty.Value = value; }

        /// <summary>
        /// ���� �±�
        /// </summary>
        private readonly Property<string> userTagProperty = new Property<string>();
        public string UserTag { get => userTagProperty.Value; set => userTagProperty.Value = value; }

        /// <summary>
        /// �������� Form Lv.{0}
        /// </summary>
        private readonly Property<string> userLevelFormProperty = new Property<string>();
        public string UserLevelForm { get => userLevelFormProperty.Value; set => userLevelFormProperty.Value = value; }

        /// <summary>
        /// ���� ����ġ ������ ��
        /// </summary>
        private readonly Property<float> userExpSliderValueProperty = new Property<float>();
        public float UserExpSliderValue { get => userExpSliderValueProperty.Value; set => userExpSliderValueProperty.Value = value; }

        /// <summary>
        /// ������ ���� ���� �ʿ� ����ġ
        /// </summary>
        private readonly Property<float> expSliderMaxValueProperty = new Property<float>();
        public float ExpSliderMaxValue { get => expSliderMaxValueProperty.Value; set => expSliderMaxValueProperty.Value = value; }

        /// <summary>
        /// ���� ����ġ Form {0}/{1}
        /// </summary>
        private readonly Property<string> userExpFormProperty = new Property<string>();
        public string UserExpForm { get => userExpFormProperty.Value; set => userExpFormProperty.Value = value; }

        /// <summary>
        /// ��� �̸�
        /// </summary>
        private readonly Property<string> guildNameProperty = new Property<string>();
        public string GuildName { get => guildNameProperty.Value; set => guildNameProperty.Value = value; }

        /// <summary>
        /// ���� �̹��� �̸�
        /// </summary>
        private readonly Property<string> mainImageNameProperty = new Property<string>();
        public string MainImageName { get => mainImageNameProperty.Value; set => mainImageNameProperty.Value = value; }

        /// <summary>
        /// ��帶ũ ������ �̸�
        /// </summary>
        private readonly Property<string> guildMarkIconNameProperty = new Property<string>();
        public string GuildMarkIconName { get => guildMarkIconNameProperty.Value; set => guildMarkIconNameProperty.Value = value; }

        /// <summary>
        /// ��� ����
        /// </summary>
        private readonly Property<bool> isHaveGuildProperty = new Property<bool>();
        public bool IsHaveGuild { get => isHaveGuildProperty.Value; set => isHaveGuildProperty.Value = value; }

        /// <summary>
        /// ���� ��ũ �̸�
        /// </summary>
        private readonly Property<string> regionMarkNameProperty = new Property<string>();
        public string RegionMarkName { get => regionMarkNameProperty.Value; set => regionMarkNameProperty.Value = value; }

        /// <summary>
        /// ���� ���� �̹��� �̸�
        /// </summary>
        private readonly Property<string> meleeUnitImageNameProperty = new Property<string>();
        public string MeleeUnitImageName { get => meleeUnitImageNameProperty.Value; set => meleeUnitImageNameProperty.Value = value; }

        /// <summary>
        /// ���Ÿ� ���� �̹��� �̸�
        /// </summary>
        private readonly Property<string> archerUnitImageNameProperty = new Property<string>();
        public string ArcherUnitImageName { get => archerUnitImageNameProperty.Value; set => archerUnitImageNameProperty.Value = value; }

        /// <summary>
        /// ����� ���� �̹��� �̸�
        /// </summary>
        private readonly Property<string> guardianUnitImageNameProperty = new Property<string>();
        public string GuardianUnitImageName { get => guardianUnitImageNameProperty.Value; set => guardianUnitImageNameProperty.Value = value; }

        /// <summary>
        /// �Ʒ��� ��� �̹��� �̸�
        /// </summary>
        private readonly Property<string> arenaGradeImageNameProperty = new Property<string>();
        public string ArenaGradeImageName { get => arenaGradeImageNameProperty.Value; set => arenaGradeImageNameProperty.Value = value; }

        /// <summary>
        /// �Ʒ��� ��� Form
        /// </summary>
        private readonly Property<string> arenaGradeFormProperty = new Property<string>();
        public string ArenaGradeForm { get => arenaGradeFormProperty.Value; set => arenaGradeFormProperty.Value = value; }

        /// <summary>
        /// �Ʒ��� ����Ʈ
        /// </summary>
        private readonly Property<string> trophyValueProperty = new Property<string>();
        public string TrophyValue { get => trophyValueProperty.Value; set => trophyValueProperty.Value = value; }

        /// <summary>
        /// ��ŷ ��
        /// </summary>
        private readonly Property<string> rankValueProperty = new Property<string>();
        public string RankValue { get => rankValueProperty.Value; set => rankValueProperty.Value = value; }

        /// <summary>
        /// ��ո��� ��
        /// </summary>
        private readonly Property<string> averageManaValueProperty = new Property<string>();
        public string AverageManaValue { get => averageManaValueProperty.Value; set => averageManaValueProperty.Value = value; }


        /// <summary>
        /// ��ũ Text
        /// </summary>
        private readonly Property<string> rankTextProperty = new Property<string>();
        public string RankText { get => rankTextProperty.Value; set => rankTextProperty.Value = value; }

        /// <summary>
        /// ���� Text
        /// </summary>
        private readonly Property<string> heroTextProperty = new Property<string>();
        public string HeroText { get => heroTextProperty.Value; set => heroTextProperty.Value = value; }

        /// <summary>
        /// �׼� Text
        /// </summary>
        private readonly Property<string> actionTextProperty = new Property<string>();
        public string ActionText { get => actionTextProperty.Value; set => actionTextProperty.Value = value; }

        /// <summary>
        /// ��ո��� Text
        /// </summary>
        private readonly Property<string> averageManaTextProperty = new Property<string>();
        public string AverageManaText { get => averageManaTextProperty.Value; set => averageManaTextProperty.Value = value; }
        
        /// <summary>
        /// ������UI ������ ��ư �����
        /// </summary>
        private readonly Property<eProfileViewType> viewTypeProperty = new Property<eProfileViewType>();
        public eProfileViewType ViewType { get => viewTypeProperty.Value; set => viewTypeProperty.Value = value; }

        /// <summary>
        /// ������ ���� ���� UI
        /// </summary>
        private readonly Property<SimpleHeroSlotContext[]> equipedHeroArrProperty = new Property<SimpleHeroSlotContext[]>();
        public SimpleHeroSlotContext[] EquipedHeroArr { get => equipedHeroArrProperty.Value; set => equipedHeroArrProperty.Value = value; }

        /// <summary>
        /// ������ �׼�ī�� ���� UI
        /// </summary>
        private readonly Property<SimpleCardSlotContext[]> equipedActionArrProperty = new Property<SimpleCardSlotContext[]>();
        public SimpleCardSlotContext[] EquipedActionArr { get => equipedActionArrProperty.Value; set => equipedActionArrProperty.Value = value; }

        /// <summary>
        /// ������ ����ī�� ���� UI
        /// </summary>
        private readonly Property<SimpleCardSlotContext> equipedHiddenActionProperty = new Property<SimpleCardSlotContext>();
        public SimpleCardSlotContext EquipedHiddenAction { get => equipedHiddenActionProperty.Value; set => equipedHiddenActionProperty.Value = value; }

        /// <summary>
        /// �ʴ� ��ư Text
        /// </summary>
        private readonly Property<string> inviteTextProperty = new Property<string>();
        public string InviteText { get => inviteTextProperty.Value; set => inviteTextProperty.Value = value; }

        /// <summary>
        /// �ʴ� ��� ��ư Text
        /// </summary>
        private readonly Property<string> cancelInviteTextProperty = new Property<string>();
        public string CancelInviteText { get => cancelInviteTextProperty.Value; set => cancelInviteTextProperty.Value = value; }

        /// <summary>
        /// �̸� ���� ��ư Text
        /// </summary>
        private readonly Property<string> editNameTextProperty = new Property<string>();
        public string EditNameText { get => editNameTextProperty.Value; set => editNameTextProperty.Value = value; }

        /// <summary>
        /// Free Text
        /// </summary>
        private readonly Property<string> freeTextProperty = new Property<string>();
        public string FreeText { get => freeTextProperty.Value; set => freeTextProperty.Value = value; }

        /// <summary>
        /// ���� ����
        /// </summary>
        private readonly Property<bool> isFreeEditNameProperty = new Property<bool>();
        public bool IsFreeEditName { get => isFreeEditNameProperty.Value; set => isFreeEditNameProperty.Value = value; }

        #region [Member Variables]
        private ProfileServerInfo profileInfo;
        #endregion

        #region [Delegate]
        public delegate void ClickCloseCallback();
        public ClickCloseCallback OnClickCloseCallback { get; set; }

        public delegate void ClickDeckCopyCallback();
        public ClickDeckCopyCallback OnClickDeckCopyCallback { get; set; }

        public delegate void ClickEditProfileCallback();
        public ClickEditProfileCallback OnClickEditProfileCallback { get; set; }

        public delegate void ClickEditNameCallback(bool aIsFree);
        public ClickEditNameCallback OnClickEditNameCallback { get; set; }

        public delegate void ClickEditFlagCallback();
        public ClickEditFlagCallback OnClickEditFlagCallback { get; set; }

        public delegate void ClickBaseUnitTooltipCallback(Vector3 aTarget);
        public ClickBaseUnitTooltipCallback OnClickBaseUnitTooltipCallback { get; set; }

        public delegate void ClickBaseUnitCallback(int aMetaID);
        public ClickBaseUnitCallback OnClickBaseUnitCallback { get; set; }
        #endregion

        #region [Public Method]
        /// <summary>
        /// �ʱ�ȭ.
        /// </summary>
        public void Initialize(bool aIsOwn)
        {
            ViewType = aIsOwn ? eProfileViewType.OWN : eProfileViewType.OTHER_NOTHING;
            ProfileTitleText = MetaDataManager.Instance.GetText(TextID.PROFILE);
            NoGuildText = MetaDataManager.Instance.GetText(TextID.NO_GUILD);
            RankText = MetaDataManager.Instance.GetText(TextID.RANK);
            HeroText = MetaDataManager.Instance.GetText(TextID.HERO_TEXT);
            ActionText = MetaDataManager.Instance.GetText(TextID.CARD_TEXT);
            AverageManaText = MetaDataManager.Instance.GetText(TextID.AVERAGE);
            EditNameText = MetaDataManager.Instance.GetText(TextID.CHANGE_NICK_NAME);
            FreeText = MetaDataManager.Instance.GetText(TextID.FREE);
            InviteText = MetaDataManager.Instance.GetText(TextID.INVITE);
            CancelInviteText = MetaDataManager.Instance.GetText(TextID.CANCEL_INVITE);
        }

        /// <summary>
        /// �ڱ� �ڽ� ����
        /// </summary>
        public void SettingOwnInfo()
        {
            MainImageName = PlayerDataManager.Instance.ProfileData.ProfileImageName;
            UserName = PlayerDataManager.Instance.ProfileData.UserName;
            UserTag = PlayerDataManager.Instance.ProfileData.UserIndex.ToString();
            FlagMetaData fMeta = MetaDataManager.Instance.FlagLoader.GetCountryMetaDataByMetaID(PlayerDataManager.Instance.ProfileData.CountryID);
            RegionMarkName = fMeta.AtlasSpriteName;
            IsHaveGuild = PlayerDataManager.Instance.GuildData != null ? true : false;
            GuildName = IsHaveGuild ? PlayerDataManager.Instance.GuildData.PlayerGuildInfo.GuildName : MetaDataManager.Instance.GetText(TextID.NO_GUILD);
            IsFreeEditName = !PlayerDataManager.Instance.ProfileData.IsPaidChangeNickname;

            //�⺻ ���� ����
            SettingBaseUnit();
            //���� �� ����ġ
            SettingUserExp();
            //�Ʒ��� �� ��ũ
            SettingArenaAndRank();
            //���� ����
            SettingHeroCardByOwn();
            //�׼� ����
            SettingActionCardByOwn();
            //���� ����
            SettingHiddenCardByOwn();
            //���� ����
            SettingAverageManaByOwn();
        }

        /// <summary>
        /// �ٸ� ��� ����
        /// </summary>
        public void SettingOtherInfo(ProfileServerInfo aInfo)
        {
            //������ ���� ����
            profileInfo = aInfo;
            //������ �̹��� ����
            ProfileImageMetaData profileMeta = MetaDataManager.Instance.GetProfileImageMetaDataByMetaID(profileInfo.ProfileMetaID);
            MainImageName = profileMeta.FilePath;
            //�г���
            UserName = profileInfo.UserNick;
            //���� �±�
            UserTag = profileInfo.UserTag.ToString();
            //���� �̹���
            FlagMetaData fMeta = MetaDataManager.Instance.FlagLoader.GetCountryMetaDataByMetaID(profileInfo.FlagID);
            RegionMarkName = fMeta.AtlasSpriteName;
            //��� ����
            IsHaveGuild = profileInfo.IsHaveGuild;
            //��� �̸�
            GuildName = IsHaveGuild ? profileInfo.GuildName : MetaDataManager.Instance.GetText(TextID.NO_GUILD);
            //�⺻ ���� ����
            SettingBaseUnit();
            //���� �� ����ġ
            SettingUserExp();
            //�Ʒ��� �� ��ũ
            SettingArenaAndRank();
            //���� ����
            SettingHeroCardByOther();
            //�׼� ����
            SettingActionCardByOther();
            //���� ����
            SettingHiddenCardByOther();
            //���� ����
            SettingAverageManaByOther();
        }
        #endregion

        #region [Private Method]
        /// <summary>
        /// �⺻ ���� ����
        /// </summary>
        private void SettingBaseUnit()
        {
            int iMeleeUnitMetaID = MetaDataManager.Instance.GetSettingValueByType(eSettingMetaType.BASE_SHORT_UNIT_ID);
            MeleeUnitImageName = MetaDataManager.Instance.GetImageKey(iMeleeUnitMetaID);
            int iArcherUnitMetaID = MetaDataManager.Instance.GetSettingValueByType(eSettingMetaType.BASE_LONG_UNIT_ID);
            ArcherUnitImageName = MetaDataManager.Instance.GetImageKey(iArcherUnitMetaID);
            int iGuardianUnitMetaID = MetaDataManager.Instance.GetSettingValueByType(eSettingMetaType.GUARDIAN_META_ID);
            GuardianUnitImageName = MetaDataManager.Instance.GetImageKey(iGuardianUnitMetaID);
        }

        /// <summary>
        /// ���� �� ����ġ ����
        /// </summary>
        private void SettingUserExp()
        {
            int iTotalExp = ViewType == eProfileViewType.OWN ? PlayerDataManager.Instance.PlayerTotalExp : profileInfo.UserExp;
            int iLevel = 1;
            int iRemainExp = MetaDataManager.Instance.CalculatePlayerRemainExpAndLevel(iTotalExp, out iLevel);
            UserLevelForm = string.Format(MetaDataManager.Instance.GetText(TextID.LEVEL_FORM), iLevel);
            bool bIsMaxLevel = iLevel >= MetaDataManager.Instance.GetPlayerMaxLevel();
            int iNextLevel = bIsMaxLevel ? iLevel : iLevel + 1;
            int iMaxValue = MetaDataManager.Instance.GetNeedExpByPlayerLevel(iNextLevel);
            ExpSliderMaxValue = iMaxValue;
            UserExpSliderValue = iRemainExp;
            UserExpForm = string.Format(MetaDataManager.Instance.GetText(TextID.TWO_VALUE_FORM), iRemainExp, iMaxValue);
        }

        /// <summary>
        /// �Ʒ��� �� ��ũ ����.
        /// </summary>
        private void SettingArenaAndRank()
        {
            int iGrade = ViewType == eProfileViewType.OWN ? PlayerDataManager.Instance.ArenaData.ArenaGrade : profileInfo.ArenaGrade;
            int iTrophy = ViewType == eProfileViewType.OWN ? PlayerDataManager.Instance.ArenaData.ArenaPoint : profileInfo.RankPoint;
            int iRank = ViewType == eProfileViewType.OWN ? PlayerDataManager.Instance.Rank : profileInfo.Ranking;

            int iNameID = MetaDataManager.Instance.GetArenaGradeNameByTier(iGrade);
            string sArenaGrade = MetaDataManager.Instance.GetText(iNameID);
            ArenaGradeForm = sArenaGrade;
            
            ArenaMetaData arenaMetaData = MetaDataManager.Instance.GetArenaMetaDataByRankPoint(iTrophy);
            ArenaGradeImageName = arenaMetaData.IconName;
            TrophyValue = string.Format(MetaDataManager.Instance.GetText(TextID.ARENA_POINT_FORM), iTrophy.ToString("N0"));
            int iLimitRank = MetaDataManager.Instance.GetSettingValueByType(eSettingMetaType.RANK_TOTAL);
            RankValue = iRank < iLimitRank ? "-" : iRank.ToString();
        }

        /// <summary>
        /// ����ī�� ���� : �ڽ��� ����
        /// </summary>
        private void SettingHeroCardByOwn()
        {
            EquipedHeroArr = null;
            SimpleHeroSlotContext[] heroContextArr = new SimpleHeroSlotContext[Constants.BIG_UNIT_DECK_COUNT];
            //���� �� ����
            DeckSlotInfo dInfo = PlayerDataManager.Instance.GetCurrentDeck();
            for (int i = 0; i < dInfo.BigUnits.Length; i++)
            {
                UnitCard unit = PlayerDataManager.Instance.GetBigUnitCard(dInfo.BigUnits[i]);
                if (unit == null)
                {
                    heroContextArr[i] = null;
                    continue;
                }
                if (heroContextArr[i] == null)
                {
                    heroContextArr[i] = new SimpleHeroSlotContext();
                }
                Thor.CardInfo cInfo = new Thor.CardInfo();
                cInfo.index = unit.MetaID;
                cInfo.level = (short)unit.Level;
                heroContextArr[i].SetCardInfo(cInfo);
                heroContextArr[i].ButtonDisable = true;
            }
            EquipedHeroArr = heroContextArr;
        }

        /// <summary>
        /// ����ī�� ���� : Ÿ���� ����
        /// </summary>
        private void SettingHeroCardByOther()
        {
            EquipedHeroArr = null;
            SimpleHeroSlotContext[] heroContextArr = new SimpleHeroSlotContext[Constants.BIG_UNIT_DECK_COUNT];
            //���� �� ����
            for (int i = 0; i < profileInfo.DeckInfo.big_unit.Length; i++)
            {
                if (profileInfo.DeckInfo.big_unit[i].index == 0)
                {
                    heroContextArr[i] = null;
                    continue;
                }
                if (heroContextArr[i] == null)
                {
                    heroContextArr[i] = new SimpleHeroSlotContext();
                }
                Thor.CardInfo cInfo = new Thor.CardInfo();
                cInfo.index = profileInfo.DeckInfo.big_unit[i].index;
                cInfo.level = (short)profileInfo.DeckInfo.big_unit[i].lv;
                heroContextArr[i].SetCardInfo(cInfo);
                heroContextArr[i].ButtonDisable = true;
            }
            EquipedHeroArr = heroContextArr;
        }

        /// <summary>
        /// �׼� ī�� ���� : �ڽ��� �׼�ī��
        /// </summary>
        private void SettingActionCardByOwn()
        {
            EquipedActionArr = null;
            SimpleCardSlotContext[] actionContextArr = new SimpleCardSlotContext[Constants.DECK_CARD_COUNT];
            DeckSlotInfo dInfo = PlayerDataManager.Instance.GetCurrentDeck();
            for (int i = 0; i < dInfo.Actions.Length; i++)
            {
                ActionCard action = PlayerDataManager.Instance.GetActionCard(dInfo.Actions[i]);
                if (action == null)
                {
                    actionContextArr[i] = null;
                    continue;
                }
                if (actionContextArr[i] == null)
                {
                    actionContextArr[i] = new SimpleCardSlotContext();
                }
                Thor.CardInfo cInfo = new Thor.CardInfo();
                cInfo.index = action.MetaID;
                cInfo.level = (short)action.Level;
                actionContextArr[i].SetCardInfo(cInfo);
                actionContextArr[i].ButtonDisable = true;
            }
            EquipedActionArr = actionContextArr;
        }

        /// <summary>
        /// �׼� ī�� ���� : Ÿ���� �׼�ī��
        /// </summary>
        private void SettingActionCardByOther()
        {
            EquipedActionArr = null;
            SimpleCardSlotContext[] actionContextArr = new SimpleCardSlotContext[Constants.DECK_CARD_COUNT];
            //���� �� ����
            for (int i = 0; i < profileInfo.DeckInfo.action_card.Length; i++)
            {
                if (profileInfo.DeckInfo.action_card[i].index == 0)
                {
                    actionContextArr[i] = null;
                    continue;
                }
                if (actionContextArr[i] == null)
                {
                    actionContextArr[i] = new SimpleCardSlotContext();
                }
                Thor.CardInfo cInfo = new Thor.CardInfo();
                cInfo.index = profileInfo.DeckInfo.action_card[i].index;
                cInfo.level = (short)profileInfo.DeckInfo.action_card[i].lv;
                actionContextArr[i].ButtonDisable = true; 
                actionContextArr[i].SetCardInfo(cInfo);
            }
            EquipedActionArr = actionContextArr;
        }

        /// <summary>
        /// ���� ī�� ���� : �ڽ��� ����ī��.
        /// </summary>
        private void SettingHiddenCardByOwn()
        {
            EquipedHiddenAction = null;
            DeckSlotInfo dInfo = PlayerDataManager.Instance.GetCurrentDeck();
            ActionCard hidden = PlayerDataManager.Instance.GetActionCard(dInfo.Hidden);
            if (hidden == null)
            {
                EquipedHiddenAction = null;
            }
            else
            {
                EquipedHiddenAction = new SimpleCardSlotContext();
                Thor.CardInfo cInfo = new Thor.CardInfo();
                cInfo.index = hidden.MetaID;
                cInfo.level = (short)hidden.Level;
                EquipedHiddenAction.SetCardInfo(cInfo);
                EquipedHiddenAction.ButtonDisable = true;
            }
        }

        /// <summary>
        /// ���� ī�� ���� : Ÿ���� ����ī��.
        /// </summary>
        private void SettingHiddenCardByOther()
        {
            EquipedHiddenAction = null;
            
            if (profileInfo.DeckInfo.hidden_card.index == 0)
            {
                EquipedHiddenAction = null;
            }
            else
            {
                EquipedHiddenAction = new SimpleCardSlotContext();
                Thor.CardInfo cInfo = new Thor.CardInfo();
                cInfo.index = profileInfo.DeckInfo.hidden_card.index;
                cInfo.level = (short)profileInfo.DeckInfo.hidden_card.lv;
                EquipedHiddenAction.SetCardInfo(cInfo);
                EquipedHiddenAction.ButtonDisable = true;
            }
        }

        /// <summary>
        /// ��� ���� ���� : �ڽ�
        /// </summary>
        private void SettingAverageManaByOwn()
        {
            int iTotalCost = 0;
            int iActionCount = 0;
            DeckSlotInfo dInfo = PlayerDataManager.Instance.GetCurrentDeck();
            for (int i = 0; i < dInfo.Actions.Length; i++)
            {
                ActionCard card = PlayerDataManager.Instance.GetActionCard(dInfo.Actions[i]);
                if (card == null) continue;
                iTotalCost += card.Cost;
                iActionCount++;
            }
            //��� ����.
            AverageManaValue = iActionCount == 0 ? "0" : ((float)iTotalCost / (float)iActionCount).ToString("N1");
        }

        /// <summary>
        /// ��� ���� ���� : Ÿ��
        /// </summary>
        private void SettingAverageManaByOther()
        {
            int iTotalCost = 0;
            int iActionCount = 0;
            for (int i = 0; i < profileInfo.DeckInfo.action_card.Length; i++)
            {
                int iMetaID = profileInfo.DeckInfo.action_card[i].index;
                if (iMetaID == 0) continue;
                ActionMetaData meta = MetaDataManager.Instance.GetActionMetaData(iMetaID);
                if (meta == null)
                {
                    LogConsole.Err("���� ī�� �� : " + iMetaID);
                    return;
                }
                iTotalCost += meta.Cost;
                iActionCount++;
            }
            //��� ����.
            AverageManaValue = iActionCount == 0 ? "0" : ((float)iTotalCost / (float)iActionCount).ToString("N1");
        }
        #endregion

        #region [Event Method]
        /// <summary>
        /// �⺻ ���� ���� �˾�
        /// </summary>
        public void ClickUnitInfo(Vector3 aTarget)
        {
            OnClickBaseUnitTooltipCallback?.Invoke(aTarget);
        }

        public void ClickClose()
        {
            OnClickCloseCallback?.Invoke();
        }

        public void ClickDeckCopy()
        {
            if (ViewType == eProfileViewType.OWN) return;
            OnClickDeckCopyCallback?.Invoke();
        }

        /// <summary>
        /// ��ǥ �̹��� ����
        /// </summary>
        public void ClickEditProfile()
        {
            if (ViewType != eProfileViewType.OWN) return;
            OnClickEditProfileCallback?.Invoke();
        }

        /// <summary>
        /// �г��� ����
        /// </summary>
        public void ClickEditName()
        {
            if (ViewType != eProfileViewType.OWN) return;
            OnClickEditNameCallback?.Invoke(IsFreeEditName);
        }

        /// <summary>
        /// Ȱ�� ���� ����
        /// </summary>
        public void ClickEditRegion()
        {
            OnClickEditFlagCallback?.Invoke();
        }

        /// <summary>
        /// ��� �ʴ�
        /// </summary>
        public void ClickInvite()
        {

        }

        /// <summary>
        /// ��� �ʴ� ���
        /// </summary>
        public void ClickCancelInvite()
        {
        }

        public void ClickMeleeUnit()
        {
            int iMetaID = MetaDataManager.Instance.GetSettingValueByType(eSettingMetaType.BASE_SHORT_UNIT_ID);
            OnClickBaseUnitCallback?.Invoke(iMetaID);
        }

        public void ClickArcherUnit()
        {
            int iMetaID = MetaDataManager.Instance.GetSettingValueByType(eSettingMetaType.BASE_LONG_UNIT_ID);
            OnClickBaseUnitCallback?.Invoke(iMetaID);
        }

        public void ClickGuardian()
        {
            int iMetaID = MetaDataManager.Instance.GetSettingValueByType(eSettingMetaType.GUARDIAN_META_ID);
            OnClickBaseUnitCallback?.Invoke(iMetaID);
        }
        #endregion
    }
}
