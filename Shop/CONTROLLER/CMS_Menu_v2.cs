using System;
using System.Collections.Generic;
using System.Threading;

namespace Shop {
    public class CMS_Menu_v2 {

        private List<Menu> menuItems = new List<Menu>();

        public CMS_Menu_v2()
        {
            foreach(string item in Enum.GetNames(typeof(CMSmenuOptions_lvl1))){
                menuItems.Add(new Menu(item));
            }
        }

        public void PrintCMSmenu_v2() {
            foreach (Menu item in this.menuItems) {
                System.Console.WriteLine(item);
            }
            int i = 0;

            while (true) {   
                var current = menuItems[i];
                current.isChecked = true;
                HighlightCurrent(menuItems);

                var pressedKey = Console.ReadKey(false).Key;
                current.isChecked = false;

                if (pressedKey == ConsoleKey.Enter) {
                    CMSmenuOptions_lvl1 temp;
                    Enum.TryParse(current.Content, out temp);
                    switch ((int) temp) {
                        case 0: System.Console.WriteLine("add"); break;
                        case 1: System.Console.WriteLine("find"); break;
                        case 2: System.Console.WriteLine("update"); break;
                        case 3: System.Console.WriteLine("delete"); break;
                        case 4: System.Console.WriteLine("search"); break;
                        case 5: System.Console.WriteLine("preview all"); break;
                        case 6: System.Console.WriteLine("exit"); break;
                        default: System.Console.WriteLine("default"); break;
                    }
                    // RUN: current.Content
                    System.Console.WriteLine("clicked");
                    Thread.Sleep(5000);
                    // TODO
                    // var method = Type.GetType(Main).GetMethod(current.Content);

                    // if (method != null)
                    // { method.Invoke(null, null); }
                }
                    
                switch (pressedKey)
                {
                    case ConsoleKey.UpArrow:
                        Console.BackgroundColor = ConsoleColor.Black;
                        if (i != 0 ) current = menuItems[i--]; else current = menuItems[0];
                        break;

                    case ConsoleKey.DownArrow:
                        Console.BackgroundColor = ConsoleColor.Black;
                        if (i != menuItems.Count-1 ) current = menuItems[i++]; else current = menuItems[menuItems.Count-1];
                        break;
                }
            }
        }
        
        static void HighlightCurrent(List<Menu> menuIt)
        {
            Console.Clear();
            Console.ResetColor();
            foreach (Menu item in menuIt) {
                System.Console.WriteLine(item);
            }
        }
    }
    class Menu {
        public string Content { get; private set; }
        public bool isChecked = false;


        public Menu(string Content) {
            this.Content = Content;
        }
        public void CheckCondition()
        {
            if (isChecked) {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            } else { Console.ResetColor(); }
        }
        public override string ToString() {
            this.CheckCondition();
            return this.Content;
        }
    }
}