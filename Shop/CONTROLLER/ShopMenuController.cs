using System;
using System.Collections.Generic;
using System.Threading;

namespace Shop {
    public class ShopMenuController {
        private Menu shopMainMenu = new Menu();

        public ShopMenuController() {
            List<string> _mainShopMenu = new List<string>();
            _mainShopMenu.Add("//\\\\//                    = =   START_SHOPPING   = =                  \\\\//\\\\");
            _mainShopMenu.Add("\\\\//\\\\                    = =   REGISTER_USER    = =                  //\\\\//");
            _mainShopMenu.Add("//\\\\//                    = =        QUIT        = =                  \\\\//\\\\");

            foreach(string item in _mainShopMenu){
                shopMainMenu.menuItems.Add(new MenuItem(item));
            }
        }


        public void PrintMainShopMenu() {
            
            while (this.shopMainMenu.menuDisplayed) {

                shopMainMenu.current = shopMainMenu.menuItems[shopMainMenu.currentItemIndex];
                
                // TODO: think about List<Menu> change to HashMap<Menu><bool>
                //       to store info about current menu item
                shopMainMenu.current.isChecked = true;
                ShopMenuView.PrintMainMenuShop(shopMainMenu);
                shopMainMenu.current.isChecked = false;

                var pressedKey = Console.ReadKey().Key;

                if (pressedKey == ConsoleKey.Enter) {

                    // Parse current menu item content (string) to defined enum
                    
                    switch (shopMainMenu.current.Content) {
                        case "//\\\\//                    = =   START_SHOPPING   = =                  \\\\//\\\\": // START_SHOPPING
                            ShopMenuView.PutToCart();
                            break;
                        case "\\\\//\\\\                    = =   REGISTER_USER    = =                  //\\\\//": // REGISTER_USER
                            System.Console.WriteLine("register user");
                            Thread.Sleep(1000);
                            break;
                        case "//\\\\//                    = =        QUIT        = =                  \\\\//\\\\": // QUIT
                            shopMainMenu.menuDisplayed = false;
                            break;
                    }
                }
                
                shopMainMenu.NavigateMenu(pressedKey);
            }
        }

    }
}