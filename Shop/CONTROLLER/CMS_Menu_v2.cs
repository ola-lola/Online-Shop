using System;
using System.Collections.Generic;
using System.Threading;

namespace Shop {
        
    ///
    // CMS_Menu_v2 class represents main CMS mode menu object
    ///
    public class CMS_Menu_v2 {

        private List<Menu> menuItems = new List<Menu>();
        private int currentItemIndex = 0;
        private bool menuDisplayed = true;

        ///
        // CMS_Menu_v2 constructor creates a list of menu items from Enum CMSmenuOptions_lvl1
        ///
        public CMS_Menu_v2() {
            foreach(string item in Enum.GetNames(typeof(CMSmenuOptions_lvl1))){
                menuItems.Add(new Menu(item));
            }
        }

        public void PrintCMSmenu_v2() {
            
            while (this.menuDisplayed) {   
                CMSmenuView.PrintMenu(this.menuItems);
                
                var current = menuItems[currentItemIndex];
                current.isChecked = true;
                MenuViewFormatting.HighlightCurrent(menuItems);

                var pressedKey = Console.ReadKey(false).Key;
                current.isChecked = false;

                if (pressedKey == ConsoleKey.Enter) {
                    CMSmenuOptions_lvl1 temp;
                    Enum.TryParse(current.Content, out temp);
                    switch ((int) temp) {
                        case 0: // ADD_NEW_DATA
                            CMSmenuView.AddNewData();
                            break;
                        case 1: // FIND_ITEMS
                            CMSmenuView.FindByCategory();
                            break;
                        case 2: // UPDATE_ITEMS
                            Console.WriteLine("Update");
                            Console.ReadKey();
                            break;
                        case 3: // DELETE_ITEMS
                            Console.WriteLine("Delete");
                            Console.ReadKey();
                            break;
                        case 4: // SEARCH_IN_STOCK
                            CMSmenuView.SearchInStock();
                            break;
                        case 5: // PREVIEW_ALL_ITEMS_IN_STOCK
                            break;
                        case 6: // EXIT_CMS
                            menuDisplayed = false;
                            break;
                        default:
                            break;
                    }
                }
                    
                switch (pressedKey)
                {
                    case ConsoleKey.UpArrow:
                        Console.BackgroundColor = ConsoleColor.Black;
                        if (currentItemIndex != 0 ) current = menuItems[currentItemIndex--]; else current = menuItems[0];
                        break;

                    case ConsoleKey.DownArrow:
                        Console.BackgroundColor = ConsoleColor.Black;
                        if (currentItemIndex != menuItems.Count-1 ) current = menuItems[currentItemIndex++]; else current = menuItems[menuItems.Count-1];
                        break;
                }
            }
        }
        

    }
}