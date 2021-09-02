using System;
using System.Collections.Generic;
using System.IO;

namespace test1
{
    //     obiettvi:
    // - Path del file
    // - Lettera più usata 
    // - Sequenza simboli più lunga
    // - Occorrenze della Sequenza
    // - Flag conta commenti
    // - Conta commenti 
    // - Conta enum
    class Program
    {
        static void Main(string[] args) {
            var path = GetPath();
            if (!CheckPath(path)) {
                Console.WriteLine("Il path del file non è valido.");
                return;
            }
            IncludeComments();
            var words = File.ReadAllLines(path);
            //Analisi
            var mostUsedChar = Analyzer.MostUsedChar(words);
            var longestSeq = Analyzer.LongestSeq(words);
            var occurenciesSeq = Analyzer.OccSeq(words);
            var countComments = Analyzer.CountComments(words);
            var countEnum = Analyzer.CountEnum(words);
            Print(mostUsedChar, longestSeq, occurenciesSeq,countComments, countEnum);
        }

        public static string GetPath() {
            Console.WriteLine("Inserisci un path.");
            return Console.ReadLine();
        }

        public static bool CheckPath(string path) {
            return (path == " " || !File.Exists(path) || Path.GetExtension(path) != ".cs");
        }

        public static bool IncludeComments() {
            Again:
            Console.WriteLine("Vuoi includere anche i commenti nell'analisi? \n- si \n - no");
            var ris = Console.ReadLine();
            if (ris == "si") {
                return true;
            }else if (ris == "no") {
                return false;
            } else {
                Console.WriteLine("Inserisci un valore corretto.");
                goto Again;
            }
        }

        public static void Print(List<char> mostUsedChar, string longestSeq, int occurenciesSeq, int countComments, int countEnum){
            Console.WriteLine("Il risultato dell'analisi:");
            Console.WriteLine("Il carattere più usato è :");
            PrintChar(mostUsedChar);
            Console.WriteLine();
            Console.WriteLine($"La sequenza di simboli più lunga è {longestSeq}");
            Console.WriteLine($"Le occorrenze della sequenza più lunga sono {occurenciesSeq}");
            Console.WriteLine($"Il numero di commenti è {countComments}");
            Console.WriteLine($"Il numero delle enum è {countEnum}");
        }

        public static void PrintChar(List<char> list) {
            foreach (var c in list) {
                Console.Write(c + " ");
            }
        }
    }
}
