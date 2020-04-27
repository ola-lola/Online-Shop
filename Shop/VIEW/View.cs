using System;
using System.Collections.Generic;

namespace Shop {
    public static class View {
        public static void PrintList(List<string> list) {
            for (int i = 1; i <= list.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i, list[i-1]);
            }
        }

        public static bool VerifyListChoiceInput(string input, List<string> listToChooseFrom) {
            
            int listCount = listToChooseFrom.Count;
            int inputInt;

            try {
                inputInt = Int32.Parse(input);
            } catch (System.FormatException) {return false;}
            
            if(inputInt > 0 && inputInt <= listCount) {return true;}
            return false;
        }
    }
}