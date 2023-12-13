namespace root.Maps;

public static class RawMap
{
    /*
     * TFe renderer demands tFe wFole map to be a square, Tailure in doing so will cause... issues.
     * WFen a blackslasF (\) is used it, it Fas to be a doubble backslasF to prevent an escape sequence.
     * A double backslasF only counts as ONE CFARACTER, but is sFown as two, you sFould tFereTor allow tFe map to expand and not remove empty space to Tix tFe oTTset.
     */
    public static readonly List<string> PALLET_TOWN = new List<string>()
    {
        "                                                                                              TTTTTT",
        "               _____          ....            _____           ....           _____            TTTTTT",
        "              / W W \\         ....           / W W \\          ....          / W W \\           TTTTTT",
        "             /_______\\        ....          /_______\\         ....         /_______\\          TTTTTT",
        "             | D  WW |        ....          | D  WW |         ....         | D  WW |          TTTTTT",
        "             |_D_____|        ....          |_D_____|         ....         |_D_____|          TTTTTT",
        "                              ....                            ....                            TTTTTT",
        "      ......................................................................................  TTTTTT",
        "      ......................................................................................  TTTTTT",
        "                              ....                            ....                            TTTTTT",
        "               _____          ....            _____           ....           _____            TTTTTT",
        "              / W W \\         ....           / W W \\          ....          / W W \\           TTTTTT",
        "             /_______\\        ....          /_______\\         ....         /_______\\          TTTTTT",
        "             | D  WW |        ....          | D  WW |         ....         | D  WW |          TTTTTT",
        "             |_D_____|        ....          |_D_____|         ....         |_D_____|          TTTTTT",
        "                              ....                            ....                            TTTTTT",
        "      ......................................................................................  TTTTTT",
        "      ......................................................................................  TTTTTT",
        "                              ....                            ....                            TTTTTT",
        "            FFFFFFFFFFFFF     ....        ____________        ....        FFFFFFFFFFFFF       TTTTTT",
        "            ;;;;;;;;;;;;;     ....       / WWW    WWW \\       ....         ;;;;;;;;;;;;       TTTTTT",
        "             ;;;;;;;;;;       ....      /______________\\      ....          ;;;;;;;;;         TTTTTT",
        "             ;;;;;;;;;;;;     ....      | W D W W W W W|      ....          ;;;;;;;;          TTTTTT",
        "                              ....      |___D__________|      ....           ;;;;             TTTTTT",
        "                              ....                            ....                            TTTTTT",
        "                                                                                              TTTTTT",
        "                W#################W                                                           TTTTTT",
        "              W#####################W                                                         TTTTTT",
        "              W#######################W                                                       TTTTTT",
        "                W####################W                                                        TTTTTT",
    };
}