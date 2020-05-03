using System;

namespace Shop {
        
    ///
    // CMS_Menu_v2 class represents main CMS mode menu object
    ///
    public class CMSmenuController {

        private Menu mainMenu = new Menu();
        

        ///
        // CMS_Menu_v2 constructor creates a list of menu items from Enum CMSmenuOptions_lvl1
        ///
        public CMSmenuController() {

            // Save all menu items to list (names = enum CMSmenuOptions_lvl1)
            foreach(string item in Enum.GetNames(typeof(CMSmenuOptions))){
                mainMenu.menuItems.Add(new MenuItem(item));
            }
        }

        public void PrintmainMenu() {
            
            while (this.mainMenu.menuDisplayed) {

                mainMenu.current = mainMenu.menuItems[mainMenu.currentItemIndex];
                
                // TODO: think about List<Menu> change to HashMap<Menu><bool>
                //       to store info about current menu item
                mainMenu.current.isChecked = true;
                CMSmenuView.PrintMainMenuCMS(mainMenu);
                mainMenu.current.isChecked = false;

                var pressedKey = Console.ReadKey().Key;

                if (pressedKey == ConsoleKey.Enter) {

                    // Parse current menu item content (string) to defined enum
                    Enum.TryParse(mainMenu.current.Content, out CMSmenuOptions temp);
                    
                    switch ((int) temp) {
                        case 0: // CREATE_NEW_RECORD
                            CMSmenuView.MainAddNewProduct();
                            break;
                        case 1: // READ_RECORDS
                            CMSmenuView.SearchInStock();
                            break;
                        case 2: // UPDATE_OR_DELETE_RECORD
                            CMSmenuView.UpdateOrDelete();
                            break;
                        case 3: // PREVIEW_ALL_ITEMS_IN_STOCK
                            CMSmenuView.PreviewAllItemsInStock();
                            break;
                        case 4: // EXIT_CMS
                            mainMenu.menuDisplayed = false;
                            break;
                        }
                    }
                else if (pressedKey == ConsoleKey.S) {
                    var menuCMS = new ShopMenuController();
                    menuCMS.PrintMainShopMenu();    
                }
                
                mainMenu.NavigateMenu(pressedKey);
            }
        }

    }
}