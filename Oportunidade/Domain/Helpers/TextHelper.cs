using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.Helpers
{
    public class TextHelper
    {
        public readonly static string[] Articles_Prepositions =
            {
                " a ", " com ",  " as ", " o ", " os ", " uma ", " um ", " uns ", " em ", " de ", " do ", " como ", " para ", " ao ", " aos ",
                " por ", " à ",  " sem ",   " após ", " até ", " nas ", " num ", " nessa ", " pelo ", " pelas "," contra ", " aonde ", " umas ",
                " desde ", " entre ", " perante ", " sob ", " sobre ", " trás ", " afora ",  " conforme ", " consoante ", " durante ", " exceto ",
                " feito ", " fora ", " mediante ", " menos ", " salvo ", " segundo ", " senão ", " tirante ", " visto ",  " ante ", " duma ",
                " àquele ", " aquele ", " duma ", " disto ",
            };

        public static string RemoveTagsHtml(string text)
        {
            return Regex.Replace(text, "<.*?>", string.Empty);
        }

        public static string RemovePunctuation(string text)
        {
            return text.Replace(",", "")
               .Replace(".", "")
               .Replace(";", "")
               .Replace("!", "")
               .Replace("?", "")
               .Replace(":", "")
               .Replace(@"/", "")
               .Replace(@"\", "")
               .Replace("(", "")
               .Replace(")", "");
        }

        public static string RemoveArticlePrepostions(string text)
        {
            try
            {
                foreach (string artPrep in Articles_Prepositions)
                {
                    text = text.Replace(artPrep, " ");
                }

                return text;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string RemoveSpaces(string text)
        {
            try
            {
                while (text.Contains("  "))
                {
                    text = text.Replace("  ", " ");
                }

                return text;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
