using AngleSharp;
using AngleSharp.Dom;
using System.Text.RegularExpressions;

namespace ProgramAdminBoxInfo
{
    internal class Parsing_boxreg
    {
        public async Task Person(int id_box_reg)
        {
            int download_all = 1100000;
            int download_id = 0;
            Program.f1.textBox_Test.Text += Environment.NewLine + "Налаштовуємо парсер";
            //parsing settings
            var config = Configuration.Default.WithDefaultLoader();
            using var context = BrowsingContext.New(config);
            var boxer = new boxer_sp();
            while (id_box_reg < 1100000)
            {
                download_id++;
                double iii;
                iii = Convert.ToDouble(download_id) / Convert.ToDouble(download_all) * 100.00;
                Program.f1.label6.Text = iii.ToString() + "%";
                boxer.reach = "";
                boxer.stance = "";
                boxer.height = "";
                boxer.nationality = "";
                boxer.residence = "";
                boxer.birth_place = "";
                boxer.division = "";
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
                Program.f1.textBox_Test.Text += Environment.NewLine + table2;
                Redex_table rd = new Redex_table();
                boxer.stance = rd.redex_quary(@"stance(\s\w*)", table2);
                if (boxer.stance != "")
                {
                    boxer.stance = boxer.stance.Replace("stance ", "");
                    Program.f1.textBox_Test.Text += Environment.NewLine + "Стійка " + boxer.stance;
                }
                boxer.height = rd.redex_quary(@"height(\s\w*)′(\s\w*)″(\s*)/(\s*\w*)", table2);
                if (boxer.height != "")
                {
                    boxer.height = boxer.height.Replace("height ", "");
                    string[] height_mas = boxer.height.Split("/");
                    boxer.height = height_mas[1].ToString();
                    boxer.height = boxer.height.Replace(" ", "");
                    Program.f1.textBox_Test.Text += Environment.NewLine + "Зріст " + boxer.height;
                }
                boxer.reach = rd.redex_quary(@"reach(\s\w*)½″(\s*)/(\s*\w*)", table2);
                if (boxer.reach == "")
                {
                    boxer.reach = rd.redex_quary(@"reach(\s\w*)″(\s*)/(\s*\w*)", table2);
                }
                if (boxer.reach != "")
                {
                    string[] reach_mas = boxer.reach.Split("/");
                    boxer.reach = reach_mas[1].ToString();
                    boxer.reach = boxer.reach.Replace(" ", "");
                    Program.f1.textBox_Test.Text += Environment.NewLine + "Розмах рук " + boxer.reach;
                }
                boxer.nationality = rd.redex_quary(@"nationality(\s\w*)", table2);
                if (boxer.nationality != "")
                {
                    boxer.nationality = boxer.nationality.Replace("nationality ", "");
                    if (boxer.nationality == "South") boxer.nationality = "South Africa";
                    if (boxer.nationality == "United") boxer.nationality = "United Kingdom";
                    if (boxer.nationality == "Puerto") boxer.nationality = "Puerto Rico";

                    
                    Program.f1.textBox_Test.Text += Environment.NewLine + "Національність " + boxer.nationality;
                }
                boxer.residence = rd.redex_quary(@"residence(\D*)birth place", table2);
                if (boxer.residence != "")
                {
                    boxer.residence = boxer.residence.Replace("residence ", "");
                    boxer.residence = boxer.residence.Replace(" birth place", "");
                    Program.f1.textBox_Test.Text += Environment.NewLine + "Місце проживання " + boxer.residence;
                }
                boxer.birth_place = rd.redex_quary(@"birth place(\D*)manager/agent", table2);
                if ( boxer.birth_place != "")
                {
                    boxer.birth_place = boxer.birth_place.Replace("birth place ", "");
                    boxer.birth_place = boxer.birth_place.Replace(" manager/agent", "");
                    Program.f1.textBox_Test.Text += Environment.NewLine + "Місце народження " + boxer.birth_place;
                }
                else if (boxer.birth_place == "")
                {
                    boxer.birth_place = rd.redex_quary(@"birth place(\D*)promoter", table2);
                    if (boxer.birth_place != "")
                    {
                        boxer.birth_place = boxer.birth_place.Replace("birth place ", "");
                        boxer.birth_place = boxer.birth_place.Replace(" promoter", "");
                        Program.f1.textBox_Test.Text += Environment.NewLine + "Місце народження " + boxer.birth_place;
                    }
                }
                if (boxer.birth_place == "")
                {
                    boxer.birth_place = rd.redex_quary(@"birth place(\D*)", table2);
                    if (boxer.birth_place != "")
                    {
                        boxer.birth_place = boxer.birth_place.Replace("birth place ", "");
                        Program.f1.textBox_Test.Text += Environment.NewLine + "Місце народження " + boxer.birth_place;
                    }
                }
                boxer.division = rd.redex_quary(@"division(\s\w*)", table1);
                if (boxer.division != "")
                {
                    boxer.division = boxer.division.Replace("division ", "");
                    Program.f1.textBox_Test.Text += Environment.NewLine + "Вагова категорія " + boxer.division;
                }




















                Audit_name_duble audit_boxer = new Audit_name_duble();
                if (audit_boxer.AuditBoxerNameBoxers(boxer.name_usa) == false)
                {
                    Program.f1.textBox_Test.Text += Environment.NewLine + "Додаємо " + boxer.name_usa;
                    INSERT_boxers ins_b = new INSERT_boxers();
                    ins_b.Insert_query(boxer.name_usa, boxer.name_ua , boxer.height, boxer.reach, boxer.stance, boxer.wiki_url_en, boxer.wiki_url_ua, boxer.boxreg_url, boxer.nationality, boxer.residence, boxer.birth_place, boxer.division);
                }
                else if (audit_boxer.AuditBoxerNameBoxers(boxer.name_usa) == true)
                {
                    Program.f1.textBox_Test.Text += Environment.NewLine + "Редагуємо " + boxer.name_usa;
                    UPDATE_boxers upd_b = new UPDATE_boxers();
                    id_extract_using_name id_n = new id_extract_using_name();
                    string id = id_n.id_name(boxer.name_usa);
                    upd_b.Update_query(id, boxer.name_usa, boxer.name_ua, boxer.height, boxer.reach, boxer.stance, boxer.wiki_url_en, boxer.wiki_url_ua, boxer.boxreg_url, boxer.nationality, boxer.residence, boxer.birth_place, boxer.division);
                }


                id_box_reg++;
                if (Program.f1.textBox1.Text == "STOP")
                {
                    Program.f1.textBox1.Text = id_box_reg.ToString();
                    return;
                }
                
            }
        }
    }
}
