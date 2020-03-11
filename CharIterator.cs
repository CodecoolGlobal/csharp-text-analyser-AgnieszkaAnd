using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextAnalyzer {
    class CharIterator : Iterator {
        private int index;
        private List<string> data = new List<string>(); // lista lub tabela, moze byc zewn. zrodlo danych, losowa liczba

        public string FirstItem {
            get {
                index = 0;
                return data[this.index];
            }
        }
        public string CurrentItem {
            get {
                return data[this.index];
            }
        }
        public CharIterator(FileContent fileContent) {
            this.index = 0;
            foreach (char letter in fileContent.GetFileText()){
                if (isAlphaNumeric(letter.ToString())) {
                    data.Add(letter.ToString().ToLower());
                }
            }
        }
        public bool HasNext() {
            if (this.index < data.Count) {
                return true;
            }
            return false;
        }
        public string MoveNext() {
            this.index++;
            if (HasNext()) {
                return data[this.index];
            } else {
                return string.Empty;
            }
        }
        public void Remove() {}
        
        public static bool isAlphaNumeric(string strToCheck) {
            Regex rg = new Regex(@"^[a-zA-Z0-9]*$");
            return rg.IsMatch(strToCheck);
        }
    }
}
/*successively iterates over alphabetic characters (single letters) of the text.
It skips all other characters (like white-spaces). Implements MoveNext() and HasNext()
from **Iterator ** interface. NOTE: Chars are represented as Strings
for the sake of simplicity. Remember that characters’ case (UPPER or lower)
should be consistent in our analysis.*/
