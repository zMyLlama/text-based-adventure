namespace root;

public static class InputEventsClass
{
    public static readonly Dictionary<string, InputEventTypes> Dictionary = new Dictionary<string, InputEventTypes>()
    {
        {"movebackwards", InputEventTypes.MOVEBACKWARDS},
        {"movebackward", InputEventTypes.MOVEBACKWARDS},
        {"movedown", InputEventTypes.MOVEBACKWARDS},
        
        {"move", InputEventTypes.MOVEFORWARDS},
        {"moveforwards", InputEventTypes.MOVEFORWARDS},
        {"moveforward", InputEventTypes.MOVEFORWARDS},
        {"moveupwards", InputEventTypes.MOVEFORWARDS},
        {"moveupward", InputEventTypes.MOVEFORWARDS},
        {"moveup", InputEventTypes.MOVEFORWARDS},
        
        {"moveright", InputEventTypes.MOVERIGHT},
        
        {"moveleft", InputEventTypes.MOVELEFT},
        
        {"use", InputEventTypes.BATTLE},
        {"attack", InputEventTypes.BATTLE},
        {"useattack", InputEventTypes.BATTLE},
        {"rerender", InputEventTypes.RERENDER},
    };
}