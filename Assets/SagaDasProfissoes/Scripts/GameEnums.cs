    
public enum SFxClip{
    /// <summary>
    /// The click on Acept/Cancel button.
    /// </summary>
    ClickButtonAceptCancel,
    /// <summary>
    /// The click on Button next speech.
    /// </summary>
    ClickButtonNextSpeech,
    /// <summary>
    /// The click on menu button.
    /// </summary>
    ClickButtonMenu,
    /// <summary>
    /// The select of an item or kit.
    /// </summary>
    SelectItem,
    /// <summary>
    /// The next or previous item or kit on Store.
    /// </summary>
    NextPreviousItem,
    /// <summary>
    /// The money sound used when an item or kit is bought on Store.
    /// </summary>
    MoneySound,
    /// <summary>
    /// The Plim Sound when player buys an item/kit.
    /// </summary>
    Plim,
    /// <summary>
    /// The diary bonus reward (Days one to 6).
    /// </summary>
    DiaryBonusReward1st6th,
    /// <summary>
    /// The diary bonus reward on 7th day.
    /// </summary>
    DiaryBonusReward7th,
    /// <summary>
    /// Equip an item or kit.
    /// </summary>
    EquipItem,
    /// <summary>
    /// The flip flap display.
    /// </summary>
    FlipFlapDisplay,
    /// <summary>
    /// The Knowledge Arena result.
    /// </summary>
    KnowledgeArenaResult,
    /// <summary>
    /// The masters arena Player vs Player.
    /// </summary>
    MastersArenaPvP,
    /// <summary>
    /// The masters arena victory.
    /// </summary>
    MastersArenaVictory,
    /// <summary>
    /// The masters arena defeat.
    /// </summary>
    MastersArenaDefeat,
}

public enum MusicClip
{
    TitleScreen,
    MissionsScreen,
    Map1stYear,
    Map2ndYear,
    Map3rdYear,
    KnowledgeArena,
    MastersArena,
    Store,
    CheckPoint,
    PlayerMenu,
    NoteBook,
}

public enum GENDER
{
    male,
    female
}

public enum MissionStatus
{
    locked,
    unlocked,
    active,
    complete
};

public enum MochilaSlotStatus
{
	locked,
    empty,
    full
}

public enum EixoNome
{ 
	ENGENHARIA,
	HUMANAS,
	NEGOCIOS,
	SAUDE,
    NENHUM
};

public enum ItemTipo
{
	CARTEIRA,
	ITEM,
	ROUPA
}

public enum Direction
{
    RIGHT,
    LEFT
}

public enum TutorialState
{
	ATIVO,
    TELA_MISSAO,
    PRIMEIRA_MISSAO,
    LOJA,
    MOCHILA,
    RANKING,
    ARENA,
    COMPLETO = 99

}

public enum MentorName
{
    MESTRE,
    EMPRESARIA,
    ENGENHARIA1,
    ENGENHARIA2,
    HUMANAS,
    NEGOCIOS,
    SAUDE,
}


public enum MentorMood
{
    NORMAL,
    HAPPY,
    ANGRY,
    SAD
}