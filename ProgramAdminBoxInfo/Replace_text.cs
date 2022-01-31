using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramAdminBoxInfo
{
    internal class Replace_text
    {
        //change of unique Latin letters of different countries to standard Latin letters
        public string Replace_all_letters(string text)
        {
            string[][] alphabets = new string[39][];
            alphabets[0] = new string[] { "A", "À", "Á", "Â", "Ã", "Ä", "Å", "Æ", "Ā", "Ă", "Ą", };
            alphabets[1] = new string[] { "a", "à", "á", "â", "ã", "ä", "å", "æ", "ā", "ă", "ą", };
            alphabets[2] = new string[] { "C", "Ç", "Ć", "Ĉ", "Ċ", "Č" };
            alphabets[3] = new string[] { "c", "ç", "ć", "ĉ", "ċ", "č" };
            alphabets[4] = new string[] { "D", "Ð", "Ď", "Đ", };
            alphabets[5] = new string[] { "d", "ð", "ď", "đ", };
            alphabets[6] = new string[] { "E", "È", "É", "Ê", "Ë", "Ē", "Ė", "Ę", "Ě", "Ə" };
            alphabets[7] = new string[] { "e", "è", "é", "ê", "ë", "ē", "ė", "ę", "ě", "ə", };
            alphabets[8] = new string[] { "G", "Ĝ", "Ğ", "Ġ", "Ģ" };
            alphabets[9] = new string[] { "g", "ĝ", "ğ", "ġ", "ģ" };
            alphabets[10] = new string[] { "H", "Ĥ", "Ħ" };
            alphabets[11] = new string[] { "h", "ĥ", "ħ" };
            alphabets[12] = new string[] { "I", "Ì", "Í", "Î", "Ï", "Ī", "Į", "İ", "I" };
            alphabets[13] = new string[] { "i", "ì", "í", "î", "ï", "ī", "į", "i", "ı" };
            alphabets[14] = new string[] { "J", "Ĳ", "Ĵ", };
            alphabets[15] = new string[] { "j", "ĳ", "ĵ", };
            alphabets[16] = new string[] { "K", "Ķ" };
            alphabets[17] = new string[] { "k", "ķ" };
            alphabets[18] = new string[] { "L", "Ļ", "Ł" };
            alphabets[19] = new string[] { "l", "ļ", "ł" };
            alphabets[20] = new string[] { "N", "Ñ", "Ń", "Ņ", "Ň" };
            alphabets[21] = new string[] { "n", "ñ", "ń", "ņ", "ň" };
            alphabets[22] = new string[] { "O", "Ò", "Ó", "Ô", "Õ", "Ö", "Ø", "Ő", "Œ", "Ơ" };
            alphabets[23] = new string[] { "o", "ò", "ó", "ô", "õ", "ö", "ø", "ő", "œ", "ơ" };
            alphabets[24] = new string[] { "R", "Ŕ", "Ř" };
            alphabets[25] = new string[] { "r", "ŕ", "ř" };
            alphabets[26] = new string[] { "S", "ẞ", "Ś", "Ŝ", "Ş", "Ș", "Š" };
            alphabets[27] = new string[] { "s", "ß", "ś", "ŝ", "ş", "ș", "š" };
            alphabets[28] = new string[] { "T", "Þ", "Ţ", "Ť" };
            alphabets[29] = new string[] { "t", "þ", "ţ", "ť" };
            alphabets[30] = new string[] { "U", "Ù", "Ú", "Û", "Ü", "Ū", "Ŭ", "Ů", "Ű", "Ų", "Ư" };
            alphabets[31] = new string[] { "u", "ù", "ú", "û", "ü", "ū", "ŭ", "ů", "ű", "ų", "ư" };
            alphabets[32] = new string[] { "W", "Ŵ" };
            alphabets[33] = new string[] { "w", "ŵ" };
            alphabets[34] = new string[] { "Y", "Ý", "Ŷ", "Ÿ" };
            alphabets[35] = new string[] { "y", "ý", "ŷ", "ÿ" };
            alphabets[36] = new string[] { "Z", "Ź", "Ż", "Ž" };
            alphabets[37] = new string[] { "z", "ź", "ż", "ž" };
            alphabets[38] = new string[] { "", "'" };
            foreach (string[] letters in alphabets)
            {
                foreach (string letter in letters)
                {
                    if (letter == letters[0]) continue;
                    text = text.Replace(letter, letters[0]);
                }
            }
            return text;
        }
        //Remove all extra spaces, hyphens, paragraphs from the text
        public string Replace_gap_text(string text)
        {
            text = text.Replace("\n", " ");
            text = text.Replace("	", " ");
            text = text.Replace("                    ", " ");
            text = text.Replace("                   ", " ");
            text = text.Replace("                  ", " ");
            text = text.Replace("                 ", " ");
            text = text.Replace("                ", " ");
            text = text.Replace("               ", " ");
            text = text.Replace("              ", " ");
            text = text.Replace("             ", " ");
            text = text.Replace("            ", " ");
            text = text.Replace("           ", " ");
            text = text.Replace("          ", " ");
            text = text.Replace("         ", " ");
            text = text.Replace("        ", " ");
            text = text.Replace("       ", " ");
            text = text.Replace("      ", " ");
            text = text.Replace("     ", " ");
            text = text.Replace("    ", " ");
            text = text.Replace("   ", " ");
            text = text.Replace("  ", " ");
            return text;
        }

    }
}
