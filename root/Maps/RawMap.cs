namespace root.Maps;

public static class RawMap
{
    /*
     * The renderer demands the whole map to be a square, failure in doing so will cause... issues.
     * When a blackslash (\) is used it, it has to be a doubble backslash to prevent an escape sequence.
     * A double backslash only counts as ONE CHARACTER, but is shown as two, you should therefor allow the map to expand and not remove empty space to fix the offset.
     */
    public static List<string> PALLET_TOWN = new List<string>()
    {
        "                                                                                              FFFFFF",
        "               _____          [][]            _____           [][]           _____            FFFFFF",
        "              / W W \\         [][]           / W W \\         [][]          / W W \\          FFFFFF",
        "             /_______\\        [][]          /_______\\        [][]         /_______\\         FFFFFF",
        "             | D  WW |        [][]          | D  WW |         [][]         | D  WW |          FFFFFF",
        "             |_D_____|        [][]          |_D_____|         [][]         |_D_____|          FFFFFF",
        "                              [][]                            [][]                            FFFFFF",
        "      [][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]  FFFFFF",
        "      [][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]  FFFFFF",
        "                              [][]                            [][]                            FFFFFF",
        "               _____          [][]            _____           [][]           _____            FFFFFF",
        "              / W W \\         [][]           / W W \\         [][]          / W W \\          FFFFFF",
        "             /_______\\        [][]          /_______\\        [][]         /_______\\         FFFFFF",
        "             | D  WW |        [][]          | D  WW |         [][]         | D  WW |          FFFFFF",
        "             |_D_____|        [][]          |_D_____|         [][]         |_D_____|          FFFFFF",
        "                              [][]                            [][]                            FFFFFF",
        "      [][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]  FFFFFF",
        "      [][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]  FFFFFF",
        "                              [][]                            [][]                            FFFFFF",
        "            HHHHHHHHHHHHH     [][]        ____________        [][]        HHHHHHHHHHHHH       FFFFFF",
        "            ;;;;;;;;;;;;;     [][]       / WWW    WWW \\       [][]         ;;;;;;;;;;;;       FFFFFF",
        "             ;;;;;;;;;;       [][]      /______________\\      [][]          ;;;;;;;;;         FFFFFF",
        "             ;;;;;;;;;;;;     [][]      | W D W W W W W|      [][]          ;;;;;;;;          FFFFFF",
        "                              [][]      |___D__________|      [][]           ;;;;             FFFFFF",
        "                              [][]                            [][]                            FFFFFF",
        "                                                                                              FFFFFF",
        "                W#################W                                                           FFFFFF",
        "              W#####################W                                                         FFFFFF",
        "              W#######################W                                                       FFFFFF",
        "                W####################W                                                        FFFFFF",
    };
}