using AngleSharp;
using AngleSharp.Dom;
using System.Text.RegularExpressions;

namespace ProgramAdminBoxInfo
{
    internal class Parsing_boxreg
    {
        public async Task Person(int id_box_reg)
        {
            Program.f1.textBox_Test.Text += Environment.NewLine + "Налаштовуємо парсер";
            //parsing settings
            var config = Configuration.Default.WithDefaultLoader();
            using var context = BrowsingContext.New(config);
            var boxer = new boxer_sp();
            while (id_box_reg < 2000000)
            {
                Replace_text replace_Text = new Replace_text();
                //Determine the link to the page
                string url = "https://boxrec.com/en/proboxer/" + id_box_reg;
                Program.f1.textBox_Test.Text += Environment.NewLine + "Відкриваємо сторінку" + url;
                using var doc = await context.OpenAsync(url);
                //check for page availability
                if (doc.Title == "BoxRec: not found")
                {
                    Program.f1.textBox_Test.Text += Environment.NewLine + "Сторінки не існує";
                    id_box_reg++;
                    continue;
                }
                var query_h1 = doc.QuerySelectorAll("h1");
                //Name Eng
                boxer.name_usa = replace_Text.Replace_all_letters(query_h1[1].Text().Trim());
                Program.f1.textBox_Test.Text += Environment.NewLine + "Ім'я Англ - " + boxer.name_usa;
                //link box_reg
                boxer.boxreg_url = url + "/";
                var table_rowTable = doc.QuerySelectorAll("table.rowTable");

                string table1 = replace_Text.Replace_gap_text(table_rowTable[0].Text().Trim());
                string table2 = replace_Text.Replace_gap_text(table_rowTable[1].Text().Trim());
                //Program.f1.textBox_Test.Text += Environment.NewLine + table1;
                //Program.f1.textBox_Test.Text += Environment.NewLine + table2;

                //extract stance
                boxer.stance = "";
                Regex regex_stance = new Regex(@"stance(\s\w*)");
                if (regex_stance.IsMatch(table2) == true)
                {
                    MatchCollection matches_stance = regex_stance.Matches(table2);
                    boxer.stance = matches_stance[0].Value;
                    boxer.stance = boxer.stance.Replace("stance ", "");
                }
                //extract height
                boxer.height = "";
                Regex regex_height = new Regex(@"height(\s\w*)′(\s\w*)″(\s*)/(\s*\w*)");
                if (regex_height.IsMatch(table2) == true)
                {
                    MatchCollection matches_height = regex_height.Matches(table2);
                    boxer.height = matches_height[0].Value;
                    boxer.height = boxer.height.Replace("height ", "");
                    string[] height_mas = boxer.height.Split("/");
                    boxer.height = height_mas[1].ToString();
                    boxer.height = boxer.height.Replace(" ", "");
                    Program.f1.textBox_Test.Text += Environment.NewLine + "Зріст " + boxer.height;
                }
                //extract reach
                boxer.reach = "";
                Regex regex_reach = new Regex(@"reach(\s\w*)½″(\s*)/(\s*\w*)");
                Regex regex_reach2 = new Regex(@"reach(\s\w*)″(\s*)/(\s*\w*)");
                if (regex_reach.IsMatch(table2) == true)
                {
                    MatchCollection matches_reach = regex_reach.Matches(table2);
                    boxer.reach = matches_reach[0].Value;
                    boxer.reach = boxer.reach.Replace("reach ", "");
                    string[] reach_mas = boxer.reach.Split("/");
                    boxer.reach = reach_mas[1].ToString();
                    boxer.reach = boxer.reach.Replace(" ", "");
                    Program.f1.textBox_Test.Text += Environment.NewLine + "Розмах рук 1 " + boxer.reach;
                }
                else if (regex_reach2.IsMatch(table2))
                {
                    MatchCollection matches_reach2 = regex_reach2.Matches(table2);
                    boxer.reach = matches_reach2[0].Value;
                    boxer.reach = boxer.reach.Replace("reach ", "");
                    string[] reach_mas = boxer.reach.Split("/");
                    boxer.reach = reach_mas[1].ToString();
                    boxer.reach = boxer.reach.Replace(" ", "");
                    Program.f1.textBox_Test.Text += Environment.NewLine + "Розмах рук 2 " + boxer.reach;
                }
                Audit_name_duble audit_boxer = new Audit_name_duble();
                if (audit_boxer.AuditBoxerNameBoxers(boxer.name_usa) == false)
                {
                    Program.f1.textBox_Test.Text += Environment.NewLine + "Додаємо " + boxer.name_usa;
                    INSERT_boxers ins_b = new INSERT_boxers();
                    ins_b.Insert_query(boxer.name_usa, boxer.name_ua , boxer.height, boxer.reach, boxer.stance, boxer.wiki_url_en, boxer.wiki_url_ua, boxer.boxreg_url, boxer.nationality, boxer.residence, boxer.birth_place);
                }
                else if (audit_boxer.AuditBoxerNameBoxers(boxer.name_usa) == true)
                {
                    Program.f1.textBox_Test.Text += Environment.NewLine + "Редагуємо " + boxer.name_usa;
                    UPDATE_boxers upd_b = new UPDATE_boxers();
                    id_extract_using_name id_n = new id_extract_using_name();
                    string id = id_n.id_name(boxer.name_usa);
                    upd_b.Update_query(id, boxer.name_usa, boxer.name_ua, boxer.height, boxer.reach, boxer.stance, boxer.wiki_url_en, boxer.wiki_url_ua, boxer.boxreg_url, boxer.nationality, boxer.residence, boxer.birth_place);
                }


                id_box_reg++;
            }
        }
    }
}
