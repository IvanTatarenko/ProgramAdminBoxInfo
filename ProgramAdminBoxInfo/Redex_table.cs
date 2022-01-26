

using System.Text.RegularExpressions;

namespace ProgramAdminBoxInfo
{
    internal class Redex_table
    {
        public string redex_quary(string rdx, string table_text)
        {
            string text = "";
            Regex regex = new Regex(rdx);
            if (regex.IsMatch(table_text) == true)
            {
                MatchCollection matches = regex.Matches(table_text);
                text = matches[0].Value;
            }
            

            return text;
        }
    }
}
