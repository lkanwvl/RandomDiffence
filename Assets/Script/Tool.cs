
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
}