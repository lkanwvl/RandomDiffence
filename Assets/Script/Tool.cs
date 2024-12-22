
public static class Tool
{
    public static bool isEnterFirstScene = false;

    public static string GetGameTag(GameTag _value)
    {
        return _value.ToString();
    }
}
public enum GameTag
{
    Enemy,
    Ammo,
    Stun,
}

public enum eCharacter //∆—≈‰∏Æ ∆–≈œ
{
    Plyaer,
    Monster,
}

public enum eSkill
{
    Normal_Near,
    Normal_Far
}

public enum eEnemy
{
    Idle,
    Attack,
}
