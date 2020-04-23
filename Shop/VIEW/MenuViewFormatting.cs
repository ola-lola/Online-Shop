using System;
using System.Collections.Generic;

namespace Shop {
    public class MenuViewFormatting {
        public static void HighlightCurrent(List<Menu> menuIt) {
            Console.Clear();
            Console.ResetColor();
            CMSmenuView.LogoScreen();
            foreach (Menu item in menuIt) {
                // Console.SetCursorPosition((Console.WindowWidth - item.Content.Length) / 2, Console.CursorTop);
                Console.WriteLine(item);
            }
        }
    }
}