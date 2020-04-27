using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Shop {
    public class ShopMenuView {

        public static void PrintMainMenuShop(Menu menuInstance) {
            Console.Clear(); Console.ResetColor();
            
            ShopMenuView.LogoScreenShop(ShopLogo.ShopLogoPart1);
            menuInstance.PrintMenuList();
            ShopMenuView.LogoScreenShop(ShopLogo.ShopLogoPart2);
        }

        public static void LogoScreenShop(List<string> logo) {
            // Console.Clear();
            foreach (string line in logo) {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(line);
            }
            Console.ResetColor();
            
        }
    }
}
