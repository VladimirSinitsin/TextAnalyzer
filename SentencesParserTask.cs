using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            text = text.ToLower();
            var sentencesList = new List<List<string>>();


            char[] tochka = { '.', '?', '!', ';', ':', '(', ')'};
            string[] sentences = text.Split(tochka, StringSplitOptions.RemoveEmptyEntries);
            foreach(var sent in sentences)
            {
                var list = new List<string>();
                char[] points = new char[] { ' ', '^', '#', '$', '-', '+', '=', '\t', '\n', '\r',  '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
                string[] words = sent.Split(points, StringSplitOptions.RemoveEmptyEntries);
                foreach(var word in words)
                {
                    var sb = new StringBuilder();
                    foreach(var symb in word)
                    {
                        if (Char.IsLetter(symb) || symb == '\'')
                        {
                            sb.Append(symb);
                        }
                    }
                    string new_word = sb.ToString();
                    list.Add(new_word);
                }
                sentencesList.Add(list);
            }


            return sentencesList;
        }
    }
}