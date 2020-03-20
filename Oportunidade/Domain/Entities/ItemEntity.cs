using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class ItemEntity
    {
        public string Title { get; set; }
        public string Creator { get; set; }
        public List<string> Category { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Encoded { get; set; }
        public DateTime PubDate { get; set; }

        public int TotalWordsBlog { get; set; }
        public List<WordsEntity> Words { get; set; }

        public int TotalWords(string text)
        {
            return text.Trim().Split(' ').Count();
        }

        public List<WordsEntity> GetRepeatedWords(string text)
        {
            List<WordsEntity> wordsEntity = new List<WordsEntity>();

            StringBuilder sb = new StringBuilder("");
            foreach (string word in text.Split(' '))
            {
                if ((sb.ToString().ToLower().IndexOf(string.Concat("|", word, "|"), StringComparison.CurrentCultureIgnoreCase) == -1))
                {
                    sb.AppendLine(string.Concat("|", word, "|"));
                }
            }

            List<WordsEntity> result = new List<WordsEntity>();
            foreach (string word in sb.ToString().Split('|'))
            {
                var _word = word.Trim();
                if (!string.IsNullOrWhiteSpace(_word))
                {
                    wordsEntity.Add(new WordsEntity()
                    {
                        Word = _word,
                        TotalTimesUsed = TotalRepeatedWords(text, _word),
                    });
                }
            }

            return wordsEntity.OrderByDescending(x => x.TotalTimesUsed).Take(10).ToList();
        }

        private int TotalRepeatedWords(string text, string word)
        {
            string[] words = text.Split(' ');

            int count = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (word.Equals(words[i]))
                    count++;
            }

            return count;
        }
    }
}
