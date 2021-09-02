using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    public class Analyzer
    {
        public static List<char> MostUsedChar(string[] words) {
            List<char> mostUsed = new List<char>();
            var occ = CharCount(words);
            var max = 0;
            for (int i = 0; i < occ.Length; i++) {          
                if (char.IsWhiteSpace((char) i) || !IsLetter((char)i)) {
                    continue;
                }
                if (occ[i] > max) {
                    max = occ[i];
                }
            }
            for (int j = 0; j < occ.Length; j++) {
                if (occ[j] == max) {
                    mostUsed.Add((char)j);
                }
            }
            return mostUsed;
        }

        private static int[] CharCount(string[] words) {
            var occ = new int[char.MaxValue+1];
            foreach (var line in words) {
                foreach (var c in line) {
                    var newc = char.ToLower(c);
                    occ[newc]++;
                }
            }
            return occ;
        }

        public static string LongestSeq(string[] words) {
            var arrayNoCharSeq = NotCharSeq(words);
            var maxLength = 0;
            var longest = "";
            for (int i = 0; i < arrayNoCharSeq.Length; i++) {
                if (arrayNoCharSeq[i] == null) {
                    continue;
                }
                if (arrayNoCharSeq[i].Length > maxLength) {
                    maxLength = arrayNoCharSeq[i].Length;
                    longest = arrayNoCharSeq[i];
                }
            }
            return longest;
        }

        private static string[] NotCharSeq(string[] words) {
            var i = 0;
            var noCharSeq = new string[char.MaxValue + 1];
            foreach (var line in words) {
                foreach (var c in line) {
                    if (IsLetter(c) || char.IsWhiteSpace(c)) {
                         continue;
                    } else {
                        noCharSeq[i] = "" + noCharSeq[i] + c;
                    }
                }
                i++;
            }
            return noCharSeq;
        }

        private static bool IsLetter(char c) {
            bool ris = false;
            for (int i = (int)'a'; i <= (int)'z'; i++) {
                if (c == (char)i) {
                    ris = true;
                }
            }
            for (int j = (int)'A'; j <= (int)'Z'; j++) {
                if (c == (char)j) {
                    ris = true;
                }
            }
            return ris;
        }

        public static int OccSeq(string[] words) {
            var longestSeq = LongestSeq(words);
            var notCharSeq = NotCharSeq(words);
            var count = 0;
            for (int i = 0; i < notCharSeq.Length; i++) {
                if (longestSeq.Equals(notCharSeq[i])) {
                    count++;
                }
            }
            return count;
        }

        public static int CountComments(string[] words) {
            var count = 0;
            foreach (var l in words) {
                if (l.Contains("//")) {
                    count++;
                    continue;
                }
            }
            return count;
        }

        public static int CountEnum(string[] words) {
            var count = 0;
            foreach (var l in words) {
                if (l.Contains("enum")) {
                    count++;
                }
            }
            return count;
        }
    }
}
