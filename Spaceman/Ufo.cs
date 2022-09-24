using System;
using static System.Console;


namespace Spaceman
{
    public static class Ufo
    {
        private static string s0 = "" +
        "                 .                            \n" +
        "                 |                            \n" +
        "              .-\"^\"-.                       \n" +
        "             /_....._\\                       \n" +
        "         .-\"`         `\"-.                  \n" +
        "        (  ooo  ooo  ooo  )                   \n" +
        "         '-.,_________,.-'    ,-----------.   \n" +
        "              /     \\        (   救命啊！  ) \n" +
        "             /   0   \\      / `-----------'  \n" +
        "            /  --|--  \\    /                 \n" +
        "           /     |     \\                     \n" +
        "          /     / \\     \\                   \n" +
        "         /               \\                   \n";

        private static string s1 = "" +
        "                 .                            \n" +
        "                 |                            \n" +
        "              .-\"^\"-.                       \n" +
        "             /_....._\\                       \n" +
        "         .-\"`         `\"-.                  \n" +
        "        (  ooo  ooo  ooo  )                   \n" +
        "         '-.,_________,.-'    ,------------------.   \n" +
        "              /  0  \\        (  啊啊啊啊啊啊啊！  ) \n" +
        "             / --|-- \\      / `------------------'  \n" +
        "            /    |    \\    /                 \n" +
        "           /    / \\    \\                    \n" +
        "          /             \\                    \n" +
        "         /               \\                   \n";

        private static string s2 = "" +
        "                 .                            \n" +
        "                 |                            \n" +
        "              .-\"^\"-.                       \n" +
        "             /_....._\\                       \n" +
        "         .-\"`         `\"-.                  \n" +
        "        (  ooo  ooo  ooo  )                   \n" +
        "         '-.,_________,.-'    ,-----------.   \n" +
        "              /--|--\\        (  救人啦！  ) \n" +
        "             /   |   \\      / `-----------'  \n" +
        "            /   / \\   \\    /                \n" +
        "           /           \\                     \n" +
        "          /             \\                    \n" +
        "         /               \\                   \n";

        private static string s3 = "" +
        "                 .                            \n" +
        "                 |                            \n" +
        "              .-\"^\"-.                       \n" +
        "             /_....._\\                       \n" +
        "         .-\"`         `\"-.                  \n" +
        "        (  ooo  ooo  ooo  )                   \n" +
        "         '-.,_________,.-'    ,-------------.   \n" +
        "              /  |  \\        (  好好猜啊！  ) \n" +
        "             /  / \\  \\      / `-------------' \n" +
        "            /         \\    /                 \n" +
        "           /           \\                     \n" +
        "          /             \\                    \n" +
        "         /               \\                   \n";

        private static string s4 = "" +
        "                 .                            \n" +
        "                 |                            \n" +
        "              .-\"^\"-.                       \n" +
        "             /_....._\\                       \n" +
        "         .-\"`         `\"-.                  \n" +
        "        (  ooo  ooo  ooo  )                   \n" +
        "         '-.,_________,.-'    ,----------------.   \n" +
        "              / / \\ \\        (  救命啊啊啊！  )\n" +
        "             /       \\      / `---------------'  \n" +
        "            /         \\    /                 \n" +
        "           /           \\                     \n" +
        "          /             \\                    \n" +
        "         /               \\                   \n";

        private static string s5 = "" +
        "                 .                            \n" +
        "                 |                            \n" +
        "              .-\"^\"-.                       \n" +
        "             /_....._\\                       \n" +
        "         .-\"`         `\"-.                  \n" +
        "        (  ooo  ooo  ooo  )                   \n" +
        "         '-.,_________,.-'    ,-----------.   \n" +
        "              /     \\        (  要完蛋啦！  ) \n" +
        "             /       \\      / `-----------'  \n" +
        "            /         \\    /                 \n" +
        "           /           \\                     \n" +
        "          /             \\                    \n" +
        "         /               \\                   \n";
        
        private static string[] ufoStage =
            new string[] { s0, s1, s2, s3, s4, s5 };
        public static int stage = 0;

        public static void AddPart()
        {
            stage++;
            if (stage >= ufoStage.Length)
            {
                stage = ufoStage.Length;
            }
        }

        public static string Stringify()
        {
            return ufoStage[stage];
        }
    }
}