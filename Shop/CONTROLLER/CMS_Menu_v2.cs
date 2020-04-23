using System;
using System.Collections.Generic;

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
            foreach (Menu item in this.EqualsmenuItems) {
                System.Console.WriteLine(item);
            }
        }
    //         // Menu StartGame = new Menu("Start Game");
    //         // Menu EndGame = new Menu("End Game");
    //         // Console.WriteLine(StartGame);
    //         // Console.WriteLine(EndGame);
    //         int i = 0;

    //         while (true)
    //         {   

    //             var current = menuItems[i];
    //             current.isChecked = true;
    //             HighlightCurrent(menuItems);

    //             var ch = Console.ReadKey(false).Key;
    //             current.isChecked = false;

    //             if (ch == ConsoleKey.Enter) {
    //                 // RUN: current.Content
    //                 System.Console.WriteLine("clicked");
    //                 Thread.Sleep(5000);
    //                 // TODO
    //                 // var method = Type.GetType(Main).GetMethod(current.Content);

    //                 // if (method != null)
    //                 // { method.Invoke(null, null); }
    //             }

    //             switch (ch)
    //             {

    //                 case ConsoleKey.UpArrow:
    //                     // StartGame.isChecked = true;
    //                     // HighlightStartGame();
    //                     Console.BackgroundColor = ConsoleColor.Black;
    //                     if (i != 0 ) current = menuItems[i--]; else current = menuItems[0];
    //                     break;

    //                 case ConsoleKey.DownArrow:
    //                     // EndGame.isChecked = true;
    //                     // HighlightEndGame();
    //                     Console.BackgroundColor = ConsoleColor.Black;
    //                     if (i != menuItems.Count-1 ) current = menuItems[i++]; else current = menuItems[menuItems.Count-1];
    //                     break;
    //             }
    //         }
    //     }
        
    //     static void item1() { Console.Clear(); System.Console.WriteLine("item 1");}
    //     static void item2() { Console.Clear(); System.Console.WriteLine("item 2");}
    //     static void item3() { Console.Clear(); System.Console.WriteLine("item 3");}

    //     static void HighlightCurrent(List<Menu> menuIt)
    //     {
    //         Console.Clear();
    //         Console.ResetColor();
    //         foreach (Menu item in menuIt) {
    //             System.Console.WriteLine(item);
    //         }
    //     }
    //     static void HighlightStartGame()
    //     {
    //         Console.Clear();
    //         Menu StartGame = new Menu("Start Game");
    //         Menu EndGame = new Menu("End Game");
    //         Console.ResetColor();
    //         StartGame.isChecked = true;
    //         Console.WriteLine(StartGame);
    //         EndGame.isChecked = false;
    //         Console.WriteLine(EndGame);
    //     }

    //     static void HighlightEndGame()
    //     {
    //         Menu StartGame = new Menu("Start Game");
    //         Menu EndGame = new Menu("End Game");
    //         Console.Clear();
    //         Console.ResetColor();
    //         StartGame.isChecked = false;
    //         Console.WriteLine(StartGame);
    //         EndGame.isChecked = true;
    //         Console.WriteLine(EndGame);
    //     }
    // }
    // class Menu
    // {
    //     public string Content { get; private set; }
    //     // public bool isChecked = true;
    //     public bool isChecked = false;


    //     public Menu(string Content)
    //     {
    //         this.Content = Content;
    //     }
    //     public void CheckCondition()
    //     {
    //         if (isChecked)
    //         {
    //             Console.BackgroundColor = ConsoleColor.White;
    //             Console.ForegroundColor = ConsoleColor.Black;
    //         }
    //         else
    //         {
    //             Console.ResetColor();
    //         }
    //     }
    //     public override string ToString()
    //     {
    //         this.CheckCondition();
    //         return this.Content;
    //     }
    }
}