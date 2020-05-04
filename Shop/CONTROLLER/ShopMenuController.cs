using System;
using System.Collections.Generic;
using System.Threading;

namespace Shop {
    public class ShopMenuController {
        private Menu shopMainMenu = new Menu();

        public ShopMenuController() {
            shopMainMenu.menuContent.Add("//\\\\//                        = =   START_SHOPPING   = =                          \\\\//\\\\");
            shopMainMenu.menuContent.Add("\\\\//\\\\                        = =   REGISTER_USER    = =                          //\\\\//");
            shopMainMenu.menuContent.Add("//\\\\//                        = =        QUIT        = =                          \\\\//\\\\");

            foreach(string item in shopMainMenu.menuContent){
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
                        case "//\\\\//                        = =   START_SHOPPING   = =                          \\\\//\\\\": // START_SHOPPING
                            ShopMenuView.PutToCart();
                            break;
                        case "\\\\//\\\\                        = =   REGISTER_USER    = =                          //\\\\//": // REGISTER_USER
                            ShopMenuView.RegisterClient();
                            break;
                        case "//\\\\//                        = =        QUIT        = =                          \\\\//\\\\": // QUIT
                            shopMainMenu.menuDisplayed = false;
                            break;
                    }
                }
                else if (pressedKey == ConsoleKey.C) {
                    var menuCMS = new CMSmenuController();
                    menuCMS.PrintmainMenu();
                    
                }
                
                shopMainMenu.NavigateMenu(pressedKey);
            }
        }

    }
}