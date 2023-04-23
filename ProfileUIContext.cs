using Slash.Unity.DataBind.Core.Data;
using UnityEngine;
using UI.Main.BattleRecord;

namespace UI.Profile
{
    public class ProfileUIContext : Context
    {
        /// <summary>
        /// 프로필 Text
        /// </summary>
        private readonly Property<string> profileTitleTextProperty = new Property<string>();
        public string ProfileTitleText { get => profileTitleTextProperty.Value; set => profileTitleTextProperty.Value = value; }

        /// <summary>
        /// No Guild Text
        /// </summary>
        private readonly Property<string> noGuildTextProperty = new Property<string>();
        public string NoGuildText { get => noGuildTextProperty.Value; set => noGuildTextProperty.Value = value; }

        /// <summary>
        /// 유저 이름
        /// </summary>
        private readonly Property<string> userNameProperty = new Property<string>();
        public string UserName { get => userNameProperty.Value; set => userNameProperty.Value = value; }

        /// <summary>
        /// 유저 태그
        /// </summary>
        private readonly Property<string> userTagProperty = new Property<string>();
        public string UserTag { get => userTagProperty.Value; set => userTagProperty.Value = value; }

        /// <summary>
        /// 유저레벨 Form Lv.{0}
        /// </summary>
        private readonly Property<string> userLevelFormProperty = new Property<string>();
        public string UserLevelForm { get => userLevelFormProperty.Value; set => userLevelFormProperty.Value = value; }

        /// <summary>
        /// 유저 경험치 게이지 값
        /// </summary>
        private readonly Property<float> userExpSliderValueProperty = new Property<float>();
        public float UserExpSliderValue { get => userExpSliderValueProperty.Value; set => userExpSliderValueProperty.Value = value; }

        /// <summary>
        /// 유저의 다음 레벨 필요 경험치
        /// </summary>
        private readonly Property<float> expSliderMaxValueProperty = new Property<float>();
        public float ExpSliderMaxValue { get => expSliderMaxValueProperty.Value; set => expSliderMaxValueProperty.Value = value; }

        /// <summary>
        /// 유저 경험치 Form {0}/{1}
        /// </summary>
        private readonly Property<string> userExpFormProperty = new Property<string>();
        public string UserExpForm { get => userExpFormProperty.Value; set => userExpFormProperty.Value = value; }

        /// <summary>
        /// 길드 이름
        /// </summary>
        private readonly Property<string> guildNameProperty = new Property<string>();
        public string GuildName { get => guildNameProperty.Value; set => guildNameProperty.Value = value; }

        /// <summary>
        /// 메인 이미지 이름
        /// </summary>
        private readonly Property<string> mainImageNameProperty = new Property<string>();
        public string MainImageName { get => mainImageNameProperty.Value; set => mainImageNameProperty.Value = value; }

        /// <summary>
        /// 길드마크 아이콘 이름
        /// </summary>
        private readonly Property<string> guildMarkIconNameProperty = new Property<string>();
        public string GuildMarkIconName { get => guildMarkIconNameProperty.Value; set => guildMarkIconNameProperty.Value = value; }

        /// <summary>
        /// 길드 여부
        /// </summary>
        private readonly Property<bool> isHaveGuildProperty = new Property<bool>();
        public bool IsHaveGuild { get => isHaveGuildProperty.Value; set => isHaveGuildProperty.Value = value; }

        /// <summary>
        /// 지역 마크 이름
        /// </summary>
        private readonly Property<string> regionMarkNameProperty = new Property<string>();
        public string RegionMarkName { get => regionMarkNameProperty.Value; set => regionMarkNameProperty.Value = value; }

        /// <summary>
        /// 근접 유닛 이미지 이름
        /// </summary>
        private readonly Property<string> meleeUnitImageNameProperty = new Property<string>();
        public string MeleeUnitImageName { get => meleeUnitImageNameProperty.Value; set => meleeUnitImageNameProperty.Value = value; }

        /// <summary>
        /// 원거리 유닛 이미지 이름
        /// </summary>
        private readonly Property<string> archerUnitImageNameProperty = new Property<string>();
        public string ArcherUnitImageName { get => archerUnitImageNameProperty.Value; set => archerUnitImageNameProperty.Value = value; }

        /// <summary>
        /// 가디언 유닛 이미지 이름
        /// </summary>
        private readonly Property<string> guardianUnitImageNameProperty = new Property<string>();
        public string GuardianUnitImageName { get => guardianUnitImageNameProperty.Value; set => guardianUnitImageNameProperty.Value = value; }

        /// <summary>
        /// 아레나 등급 이미지 이름
        /// </summary>
        private readonly Property<string> arenaGradeImageNameProperty = new Property<string>();
        public string ArenaGradeImageName { get => arenaGradeImageNameProperty.Value; set => arenaGradeImageNameProperty.Value = value; }

        /// <summary>
        /// 아레나 등급 Form
        /// </summary>
        private readonly Property<string> arenaGradeFormProperty = new Property<string>();
        public string ArenaGradeForm { get => arenaGradeFormProperty.Value; set => arenaGradeFormProperty.Value = value; }

        /// <summary>
        /// 아레나 포인트
        /// </summary>
        private readonly Property<string> trophyValueProperty = new Property<string>();
        public string TrophyValue { get => trophyValueProperty.Value; set => trophyValueProperty.Value = value; }

        /// <summary>
        /// 랭킹 값
        /// </summary>
        private readonly Property<string> rankValueProperty = new Property<string>();
        public string RankValue { get => rankValueProperty.Value; set => rankValueProperty.Value = value; }

        /// <summary>
        /// 평균마나 값
        /// </summary>
        private readonly Property<string> averageManaValueProperty = new Property<string>();
        public string AverageManaValue { get => averageManaValueProperty.Value; set => averageManaValueProperty.Value = value; }


        /// <summary>
        /// 랭크 Text
        /// </summary>
        private readonly Property<string> rankTextProperty = new Property<string>();
        public string RankText { get => rankTextProperty.Value; set => rankTextProperty.Value = value; }

        /// <summary>
        /// 영웅 Text
        /// </summary>
        private readonly Property<string> heroTextProperty = new Property<string>();
        public string HeroText { get => heroTextProperty.Value; set => heroTextProperty.Value = value; }

        /// <summary>
        /// 액션 Text
        /// </summary>
        private readonly Property<string> actionTextProperty = new Property<string>();
        public string ActionText { get => actionTextProperty.Value; set => actionTextProperty.Value = value; }

        /// <summary>
        /// 평균마나 Text
        /// </summary>
        private readonly Property<string> averageManaTextProperty = new Property<string>();
        public string AverageManaText { get => averageManaTextProperty.Value; set => averageManaTextProperty.Value = value; }
        
        /// <summary>
        /// 프로필UI 열릴때 버튼 컨디션
        /// </summary>
        private readonly Property<eProfileViewType> viewTypeProperty = new Property<eProfileViewType>();
        public eProfileViewType ViewType { get => viewTypeProperty.Value; set => viewTypeProperty.Value = value; }

        /// <summary>
        /// 장착된 영웅 정보 UI
        /// </summary>
        private readonly Property<SimpleHeroSlotContext[]> equipedHeroArrProperty = new Property<SimpleHeroSlotContext[]>();
        public SimpleHeroSlotContext[] EquipedHeroArr { get => equipedHeroArrProperty.Value; set => equipedHeroArrProperty.Value = value; }

        /// <summary>
        /// 장착된 액션카드 정보 UI
        /// </summary>
        private readonly Property<SimpleCardSlotContext[]> equipedActionArrProperty = new Property<SimpleCardSlotContext[]>();
        public SimpleCardSlotContext[] EquipedActionArr { get => equipedActionArrProperty.Value; set => equipedActionArrProperty.Value = value; }

        /// <summary>
        /// 장착된 히든카드 정보 UI
        /// </summary>
        private readonly Property<SimpleCardSlotContext> equipedHiddenActionProperty = new Property<SimpleCardSlotContext>();
        public SimpleCardSlotContext EquipedHiddenAction { get => equipedHiddenActionProperty.Value; set => equipedHiddenActionProperty.Value = value; }

        /// <summary>
        /// 초대 버튼 Text
        /// </summary>
        private readonly Property<string> inviteTextProperty = new Property<string>();
        public string InviteText { get => inviteTextProperty.Value; set => inviteTextProperty.Value = value; }

        /// <summary>
        /// 초대 취소 버튼 Text
        /// </summary>
        private readonly Property<string> cancelInviteTextProperty = new Property<string>();
        public string CancelInviteText { get => cancelInviteTextProperty.Value; set => cancelInviteTextProperty.Value = value; }

        /// <summary>
        /// 이름 변경 버튼 Text
        /// </summary>
        private readonly Property<string> editNameTextProperty = new Property<string>();
        public string EditNameText { get => editNameTextProperty.Value; set => editNameTextProperty.Value = value; }

        /// <summary>
        /// Free Text
        /// </summary>
        private readonly Property<string> freeTextProperty = new Property<string>();
        public string FreeText { get => freeTextProperty.Value; set => freeTextProperty.Value = value; }

        /// <summary>
        /// 무료 여부
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
        /// 초기화.
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
        /// 자기 자신 셋팅
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

            //기본 유닛 셋팅
            SettingBaseUnit();
            //레벨 및 경험치
            SettingUserExp();
            //아레나 및 랭크
            SettingArenaAndRank();
            //영웅 슬롯
            SettingHeroCardByOwn();
            //액션 슬롯
            SettingActionCardByOwn();
            //히든 슬롯
            SettingHiddenCardByOwn();
            //마나 셋팅
            SettingAverageManaByOwn();
        }

        /// <summary>
        /// 다른 사람 셋팅
        /// </summary>
        public void SettingOtherInfo(ProfileServerInfo aInfo)
        {
            //프로필 정보 저장
            profileInfo = aInfo;
            //프로필 이미지 리턴
            ProfileImageMetaData profileMeta = MetaDataManager.Instance.GetProfileImageMetaDataByMetaID(profileInfo.ProfileMetaID);
            MainImageName = profileMeta.FilePath;
            //닉네임
            UserName = profileInfo.UserNick;
            //유저 태그
            UserTag = profileInfo.UserTag.ToString();
            //지역 이미지
            FlagMetaData fMeta = MetaDataManager.Instance.FlagLoader.GetCountryMetaDataByMetaID(profileInfo.FlagID);
            RegionMarkName = fMeta.AtlasSpriteName;
            //길드 여부
            IsHaveGuild = profileInfo.IsHaveGuild;
            //길드 이름
            GuildName = IsHaveGuild ? profileInfo.GuildName : MetaDataManager.Instance.GetText(TextID.NO_GUILD);
            //기본 유닛 셋팅
            SettingBaseUnit();
            //레벨 및 경험치
            SettingUserExp();
            //아레나 및 랭크
            SettingArenaAndRank();
            //영웅 슬롯
            SettingHeroCardByOther();
            //액션 슬롯
            SettingActionCardByOther();
            //히든 슬롯
            SettingHiddenCardByOther();
            //마나 셋팅
            SettingAverageManaByOther();
        }
        #endregion

        #region [Private Method]
        /// <summary>
        /// 기본 유닛 셋팅
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
        /// 레벨 및 경험치 셋팅
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
        /// 아레나 및 랭크 셋팅.
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
        /// 영웅카드 셋팅 : 자신의 영웅
        /// </summary>
        private void SettingHeroCardByOwn()
        {
            EquipedHeroArr = null;
            SimpleHeroSlotContext[] heroContextArr = new SimpleHeroSlotContext[Constants.BIG_UNIT_DECK_COUNT];
            //현재 덱 리턴
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
        /// 영웅카드 셋팅 : 타인의 영웅
        /// </summary>
        private void SettingHeroCardByOther()
        {
            EquipedHeroArr = null;
            SimpleHeroSlotContext[] heroContextArr = new SimpleHeroSlotContext[Constants.BIG_UNIT_DECK_COUNT];
            //현재 덱 리턴
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
        /// 액션 카드 셋팅 : 자신의 액션카드
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
        /// 액션 카드 셋팅 : 타인의 액션카드
        /// </summary>
        private void SettingActionCardByOther()
        {
            EquipedActionArr = null;
            SimpleCardSlotContext[] actionContextArr = new SimpleCardSlotContext[Constants.DECK_CARD_COUNT];
            //현재 덱 리턴
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
        /// 히든 카드 셋팅 : 자신의 히든카드.
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
        /// 히든 카드 셋팅 : 타인의 히든카드.
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
        /// 평균 마나 셋팅 : 자신
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
            //평균 셋팅.
            AverageManaValue = iActionCount == 0 ? "0" : ((float)iTotalCost / (float)iActionCount).ToString("N1");
        }

        /// <summary>
        /// 평균 마나 셋팅 : 타인
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
                    LogConsole.Err("없는 카드 임 : " + iMetaID);
                    return;
                }
                iTotalCost += meta.Cost;
                iActionCount++;
            }
            //평균 셋팅.
            AverageManaValue = iActionCount == 0 ? "0" : ((float)iTotalCost / (float)iActionCount).ToString("N1");
        }
        #endregion

        #region [Event Method]
        /// <summary>
        /// 기본 유닛 정보 팝업
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
        /// 대표 이미지 변경
        /// </summary>
        public void ClickEditProfile()
        {
            if (ViewType != eProfileViewType.OWN) return;
            OnClickEditProfileCallback?.Invoke();
        }

        /// <summary>
        /// 닉네임 변경
        /// </summary>
        public void ClickEditName()
        {
            if (ViewType != eProfileViewType.OWN) return;
            OnClickEditNameCallback?.Invoke(IsFreeEditName);
        }

        /// <summary>
        /// 활동 지역 변경
        /// </summary>
        public void ClickEditRegion()
        {
            OnClickEditFlagCallback?.Invoke();
        }

        /// <summary>
        /// 길드 초대
        /// </summary>
        public void ClickInvite()
        {

        }

        /// <summary>
        /// 길드 초대 취소
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
