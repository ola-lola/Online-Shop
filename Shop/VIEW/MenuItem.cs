using System;

namespace Shop {
    public class MenuItem {
        public string Content { get; set; }
        public bool isChecked = false;


        public MenuItem(string Content) {
            this.Content = Content;
        }
        public void CheckCondition() {
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