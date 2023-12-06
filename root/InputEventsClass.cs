namespace root;

public static class InputEventsClass
{
    public static readonly Dictionary<string, InputEventTypes> Dictionary = new Dictionary<string, InputEventTypes>()
    {
        {"movebackwards", InputEventTypes.MOVEBACKWARDS},
        {"movebackward", InputEventTypes.MOVEBACKWARDS},
        {"move", InputEventTypes.MOVEFORWARDS},
        {"use", InputEventTypes.BATTLE},
        {"attack", InputEventTypes.BATTLE},
        {"useattack", InputEventTypes.BATTLE},
        {"rerender", InputEventTypes.RERENDER},
    };
}