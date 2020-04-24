using System;
using System.Collections.Generic;

namespace Shop {
    public class MenuViewFormatting {
        public static void HighlightCurrent(List<Menu> menuIt) {
            Console.Clear();
            Console.ResetColor();
            CMSmenuView.PrintMenu(menuIt);
        }
    }
}