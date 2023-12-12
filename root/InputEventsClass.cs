namespace root;

public static class InputEventsClass
{
    public static readonly Dictionary<string, InputEventTypes> Dictionary = new Dictionary<string, InputEventTypes>()
    {
        {"movebackwards", InputEventTypes.MOVEBACKWARDS},
        {"movebackward", InputEventTypes.MOVEBACKWARDS},
        {"movedown", InputEventTypes.MOVEBACKWARDS},
        {"moved", InputEventTypes.MOVEBACKWARDS},
        {"down", InputEventTypes.MOVEBACKWARDS},
        {"back", InputEventTypes.MOVEBACKWARDS},
        {"d", InputEventTypes.MOVEBACKWARDS},
        
        {"move", InputEventTypes.MOVEFORWARDS},
        {"moveforwards", InputEventTypes.MOVEFORWARDS},
        {"moveforward", InputEventTypes.MOVEFORWARDS},
        {"moveupwards", InputEventTypes.MOVEFORWARDS},
        {"moveupward", InputEventTypes.MOVEFORWARDS},
        {"moveup", InputEventTypes.MOVEFORWARDS},
        {"moveu", InputEventTypes.MOVEFORWARDS},
        {"movef", InputEventTypes.MOVEFORWARDS},
        {"up", InputEventTypes.MOVEFORWARDS},
        {"forwards", InputEventTypes.MOVEFORWARDS},
        {"u", InputEventTypes.MOVEFORWARDS},
        {"f", InputEventTypes.MOVEFORWARDS},
        
        {"moveright", InputEventTypes.MOVERIGHT},
        {"mover", InputEventTypes.MOVERIGHT},
        {"right", InputEventTypes.MOVERIGHT},
        {"r", InputEventTypes.MOVERIGHT},
        
        {"moveleft", InputEventTypes.MOVELEFT},
        {"movel", InputEventTypes.MOVELEFT},
        {"left", InputEventTypes.MOVELEFT},
        {"l", InputEventTypes.MOVELEFT},
        
        {"use", InputEventTypes.BATTLE},
        {"attack", InputEventTypes.BATTLE},
        {"useattack", InputEventTypes.BATTLE},
        {"rerender", InputEventTypes.RERENDER},
    };
}