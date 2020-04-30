using System;
using System.Collections.Generic;

namespace Shop {
    public class Menu {
        public List<string> menuContent = new List<string>();
        public List<MenuItem> menuItems = new List<MenuItem>();
        public bool menuDisplayed;
        public int currentItemIndex;
        public MenuItem current;

        public Menu()
        {
            // TODO: how to pass concrete enum as constructor parameter?
            // foreach(string item in Enum.GetNames(typeof(CMSmenuOptions_lvl1))){
            //     menuItems.Add(new MenuItem(item));
            // }

            menuDisplayed = true;
            currentItemIndex = 0;
        }

        public void PrintMenuList() {
            foreach (MenuItem item in this.menuItems) {
                foreach (char i in item.Content) {
                    if (i == '/' || i == '\\' || i == ' ' | i == '=' | i == '-') {
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    } else {item.CheckCondition();}
                    System.Console.Write(i);
                }
                Console.WriteLine();
            }
        }


        ///
        // NavigateMenu method moves up-down through menu list
        ///
        public void NavigateMenu(ConsoleKey input) {

            switch (input) {
                
                case ConsoleKey.UpArrow:
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (this.currentItemIndex != 0 ) this.current = this.menuItems[this.currentItemIndex--];
                    else this.current = this.menuItems[0];
                    break;

                case ConsoleKey.DownArrow:
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (this.currentItemIndex != this.menuItems.Count-1 ) this.current = this.menuItems[this.currentItemIndex++];
                    else this.current = this.menuItems[this.menuItems.Count-1];
                    break;
            } 
        }
    }
}