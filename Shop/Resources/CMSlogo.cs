using System;
using System.Collections.Generic;

namespace Shop {
    public static class CMSlogo {
        public static string[] ShopLogo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string[] logo = new string[12] {
            " ██████╗███╗   ███╗███████╗    ███╗   ███╗ ██████╗ ██████╗ ███████╗",
            "██╔════╝████╗ ████║██╔════╝    ████╗ ████║██╔═══██╗██╔══██╗██╔════╝",
            "██║     ██╔████╔██║███████╗    ██╔████╔██║██║   ██║██║  ██║█████╗  ",
            "██║     ██║╚██╔╝██║╚════██║    ██║╚██╔╝██║██║   ██║██║  ██║██╔══╝  ",
            "╚██████╗██║ ╚═╝ ██║███████║    ██║ ╚═╝ ██║╚██████╔╝██████╔╝███████╗",
            " ╚═════╝╚═╝     ╚═╝╚══════╝    ╚═╝     ╚═╝ ╚═════╝ ╚═════╝ ╚══════╝",
            "",
            "                           \\________",
            "                        ~   \\######/",     
            "                         ~   |####/ ",
            "                        ~    |____. ",
            "                       ______o____o_________",
            };
            Console.ResetColor();
            return logo;
            
        }
    }
}