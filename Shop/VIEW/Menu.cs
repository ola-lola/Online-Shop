using System;
using System.Collections.Generic;

namespace Shop {
    public class Menu {
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
    }
}