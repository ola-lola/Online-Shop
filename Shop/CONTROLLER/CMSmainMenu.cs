using System;
using System.Collections.Generic;
using System.Threading;

namespace Shop {
        
    ///
    // CMS_Menu_v2 class represents main CMS mode menu object
    ///
    public class CMSmainMenu {

        private List<MenuItem> menuItems = new List<MenuItem>();
        private bool menuDisplayed;
        private int currentItemIndex;
        private MenuItem current;

        ///
        // CMS_Menu_v2 constructor creates a list of menu items from Enum CMSmenuOptions_lvl1
        ///
        public CMSmainMenu() {

            // Save all menu items to list (names = enum CMSmenuOptions_lvl1)
            foreach(string item in Enum.GetNames(typeof(CMSmenuOptions_lvl1))){
                menuItems.Add(new MenuItem(item));
            }

            menuDisplayed = true;
            currentItemIndex = 0;
        }

        public void PrintCMSmenu_v2() {
            
            while (this.menuDisplayed) {

                current = menuItems[currentItemIndex];
                
                // TODO: think about List<Menu> change to HashMap<Menu><bool>
                //       to store info about current menu item
                current.isChecked = true;
                CMSmenuView.PrintMainMenuCMS(menuItems);
                current.isChecked = false;

                var pressedKey = Console.ReadKey().Key;

                if (pressedKey == ConsoleKey.Enter) {

                    // Parse current menu item content (string) to defined enum
                    Enum.TryParse(current.Content, out CMSmenuOptions_lvl1 temp);
                    
                    switch ((int) temp) {
                        case 0: // CREATE_NEW_RECORD
                            CMSmenuView.AddNewData();
                            break;
                        case 1: // READ_RECORDS
                            CMSmenuView.SearchInStock();
                            break;
                        case 2: // UPDATE_OR_DELETE_RECORD
                            CMSmenuView.UpdateOrDelete();
                            break;
                        case 3: // PREVIEW_ALL_ITEMS_IN_STOCK
                            // TODO by Agnieszka
                            ConnectDB conection_DB_100 = new ConnectDB();
                            conection_DB_100.ReadTable("products", new List<string>() {"name", "division", "status"});
                            Console.ReadKey();
                            break;
                        case 4: // EXIT_CMS
                            menuDisplayed = false;
                            break;
                    }
                }
                
                this.NavigateMenu(pressedKey);
            }
        }

        ///
        // NavigateMenu method moves up-down through menu list
        ///
        public void NavigateMenu(ConsoleKey input) {

            switch (input) {
                
                case ConsoleKey.UpArrow:
                    Console.BackgroundColor = ConsoleColor.Black;
                    // TODO: add currentItemIndex and menuItems as method parameters
                    // What to return in the method (?) CMS_Menu_v2 object?
                    if (currentItemIndex != 0 ) current = menuItems[currentItemIndex--];
                    else current = menuItems[0];
                    break;

                case ConsoleKey.DownArrow:
                    Console.BackgroundColor = ConsoleColor.Black;
                    // TODO: add currentItemIndex and menuItems as method parameters
                    // What to return in the method (?) CMS_Menu_v2 object?
                    if (currentItemIndex != menuItems.Count-1 ) current = menuItems[currentItemIndex++];
                    else current = menuItems[menuItems.Count-1];
                    break;
            } 
        }
    }
}