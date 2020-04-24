using System;

namespace Shop {
    public class Menu {
        public string Content { get; private set; }
        public bool isChecked = false;


        public Menu(string Content) {
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