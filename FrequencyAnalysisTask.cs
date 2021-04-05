using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        static Dictionary<string, Dictionary<string, int>> GetUnfiltredBigram(List<List<string>> text)
        {
            var freq = new Dictionary<string, Dictionary<string, int>>();

            foreach(var sentence in text)
            {
                for(int i=0; i < sentence.Count - 1; i++)
                {
                    var head = sentence[i];
                    var tail = sentence[i + 1];

                    if (!freq.ContainsKey(head))
                    {
                        var dict = new Dictionary<string, int>();
                        dict.Add(tail, 1);
                        freq.Add(head, dict);
                    }
                    else
                    {
                        if (!freq[head].ContainsKey(tail))
                        {
                            freq[head].Add(tail, 1);
                        }
                        else
                        {
                            freq[head][tail]++;
                        }
                    }
                }
            }

            return freq;
        }

        static Dictionary<string, Dictionary<string, int>> GetUnfiltredThreegram(List<List<string>> text)
        {
            var freq = new Dictionary<string, Dictionary<string, int>>();

            foreach (var sentence in text)
            {
                for (int i = 0; i < sentence.Count - 2; i++)
                {
                    var head = sentence[i] + " " + sentence[i + 1];
                    var tail = sentence[i + 2];

                    if (!freq.ContainsKey(head))
                    {
                        var dict = new Dictionary<string, int>();
                        dict.Add(tail, 1);
                        freq.Add(head, dict);
                    }
                    else
                    {
                        if (!freq[head].ContainsKey(tail))
                        {
                            freq[head].Add(tail, 1);
                        }
                        else
                        {
                            freq[head][tail]++;
                        }
                    }
                }
            }

            return freq;
        }


        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();

            var bigram_freq = GetUnfiltredBigram(text);
            var threegram_freq = GetUnfiltredThreegram(text);

            var arr = new Dictionary<string, Dictionary<string, int>>[] { bigram_freq, threegram_freq };
            foreach (var freq in arr)
            {
                foreach(var head in freq.Keys)
                {
                    int max = -1;
                    foreach(var val in freq[head].Values)
                    {
                        if (val > max) { max = val; }
                    }

                    string current_tail = "яяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяяя";
                    foreach(var pair in freq[head])
                    {
                        if (pair.Value == max && string.CompareOrdinal(pair.Key, current_tail) < 0)
                        {
                            current_tail = pair.Key;
                        }
                    }
                    result.Add(head, current_tail);
                }
            }

            return result;
        }
   }
}