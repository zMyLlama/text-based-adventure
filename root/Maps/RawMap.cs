namespace root.Maps;

public static class RawMap
{
    /*
     * The renderer demands the whole map to be a square, failure in doing so will cause... issues.
     * When a blackslash (\) is used it, it has to be a doubble backslash to prevent an escape sequence.
     * A double backslash only counts as ONE CHARACTER, but is shown as two, you should therefor allow the map to expand and not remove empty space to fix the offset.
     */
    public static readonly List<string> PALLET_TOWN = new List<string>()
    {
        "                                                                                              ^^^^^^",
        "             ;;;;;;;;                          ___                 ___                        FFFFFF",
        "           ;;;;;;;;;;;;;;                     /   \\               /   \\                       FFFFFF",
        "                ;;;;;;                       /     \\             /     \\                      FFFFFF",
        "                                             | D W |             | D W |                      FFFFFF",
        "                                             |_D___|             |_D___|                      FFFFFF",
        "                                                                                              FFFFFF",
        "                                                                                              FFFFFF",
        "                                                                   ;;;;;;;;;;;;;;;            FFFFFF",
        "                                                                     ;;;;;;;                  FFFFFF",
        "                                                                  ;;;;;;;;;;;;;               FFFFFF",
        "                                                                                              FFFFFF",
        "               ;;;;;;;;;;;;;;;                                                                FFFFFF",
        "                    ;;;;;;;;                                                                  FFFFFF",
    };
}