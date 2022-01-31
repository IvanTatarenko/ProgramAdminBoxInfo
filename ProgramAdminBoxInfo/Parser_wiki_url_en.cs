

using AngleSharp;
using AngleSharp.Dom;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProgramAdminBoxInfo
{
    internal class Parser_wiki_url_en
    {
        public async Task Parser_Wiki_en()
        {
            int download_all = 0;
            int download_id = 0;
            Replace_text replace_Text = new Replace_text();
            Audit_name_duble audit_boxer = new Audit_name_duble();
            // підлючення  до бд
            DB db = new DB();
            //Команда бд
            MySqlCommand command2 = new MySqlCommand("SELECT * FROM boxers WHERE wiki_url_en IS NOT NULL", db.getConnection());
            //створюємо таблицю в яку будемо додавати данні
            DataTable dt = new DataTable("name_boxers");
            //Називаємо ствбці в таблиці
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name_usa", typeof(string));
            dt.Columns.Add("wiki_url_en", typeof(string));

            //відкриваємо зєднання
            db.openConnection();
            //створюємо ріадер для зчитування данних з Mysql
            MySqlDataReader reader = command2.ExecuteReader();
            //створюємо перемінні для аналізу
            string name_usa;
            string wiki_url_en;
            int id;
            int num_id = Convert.ToInt32(Program.f1.textBox3.Text);
            //перемінні для запросів ангел шарп
            string table_wikitable = "table.wikitable";
            //Витаскуємо данні з бази
            while (reader.Read())
            {
                if (reader.GetInt32(reader.GetOrdinal("id")) < num_id)
                {
                    continue;
                }
                id = reader.GetInt32(reader.GetOrdinal("id"));
                name_usa = reader.GetString(reader.GetOrdinal("name_usa"));
                wiki_url_en = reader.GetString(reader.GetOrdinal("wiki_url_en"));

                //вносимо в таблицю данні
                dt.Rows.Add(new Object[] { id, name_usa, wiki_url_en });
                download_all++;
            }
            //закриваємо ріадер
            reader.Close();
            //Закриваємо з"єднання
            db.closeConnection();
            //Створюємо ріадер для зчитування таблиці в витянутими данними
            DataTableReader reader2 = dt.CreateDataReader();
            //Перебираємо боксерів та їх силки на вікі
            while (reader2.Read())
            {
                download_id++;
                double iii;
                iii = Convert.ToDouble(download_id) / Convert.ToDouble(download_all) * 100.00;
                Program.f1.label6.Text = iii.ToString() + "%";
                //значення імя та юрл з бази
                id = reader2.GetInt32(reader2.GetOrdinal("id"));
                name_usa = reader2.GetString(reader2.GetOrdinal("name_usa"));
                wiki_url_en = reader2.GetString(reader2.GetOrdinal("wiki_url_en"));
                
                //перевірка на виключення з бази виключених силок
                MySqlCommand command6 = new MySqlCommand("SELECT * FROM exclusion_wiki_url WHERE url_en = @wiki_url_en", db.getConnection());
                command6.Parameters.Add("@wiki_url_en", MySqlDbType.VarChar).Value = wiki_url_en;
                //відкриваємо зєднання
                db.openConnection();
                if (command6.ExecuteReader().HasRows)
                {
                    //Закриваємо з"єднання
                    db.closeConnection();
                    continue;
                }
                //Закриваємо з"єднання
                db.closeConnection();
                //всякі важливі штуки для парсінгу
                var config = Configuration.Default.WithDefaultLoader();
                using var context = BrowsingContext.New(config);
                //Відкриваємо юрл
                using var doc = await context.OpenAsync(wiki_url_en);
                //якщо юрл наявне то починаємо його парсити
                if (wiki_url_en != "")
                {
                    Program.f1.textBox_Test.Text += Environment.NewLine + "ID " + id.ToString();
                    //Виводимо юрл яке парситься на данний час
                    Program.f1.textBox_Test.Text += Environment.NewLine + "URL " + wiki_url_en;
                    //перевіряємо наявність таблиці з боями
                    if (doc.QuerySelector(table_wikitable) == null)
                    {
                        continue;
                    }

                    //шукаємо всі таблиці на сторінці
                    var table1_doc = doc.QuerySelectorAll(table_wikitable);
                    //шукаємо всі строки в таблиці номер 1
                    var table2_doc = table1_doc[0].QuerySelectorAll("tr");
                    //рахуємо кількість стовпців в таблиці
                    var nums = table1_doc[0].QuerySelectorAll("tr").Length;
                    //визначаємо кількість таблиць і відносно цього вибираємо потрібну нам
                    if (doc.QuerySelectorAll(table_wikitable).Length > 1)
                    {
                        if (table1_doc[1].QuerySelectorAll("tr").Length <= 1)
                        {
                            continue;
                        }
                        table2_doc = table1_doc[1].QuerySelectorAll("tr");
                        if (table2_doc[1].QuerySelectorAll("td").Length < 4)
                        {
                            continue;
                        }
                        nums = table1_doc[1].QuerySelectorAll("tr").Length;
                    }
                    else if (doc.QuerySelectorAll(table_wikitable).Length == 1)
                    {

                        table2_doc = table1_doc[0].QuerySelectorAll("tr");

                        if (table2_doc[0].QuerySelectorAll("td").Length < 5)
                        {
                            continue;
                        }

                        nums = table1_doc[0].QuerySelectorAll("tr").Length;

                    }


                    nums--;
                    //перебираємо строки таблиці поки вони не закінчаться
                    while (nums > 0)
                    {

                        //обявяємо перемінні
                        string opponent = "";
                        string opponent_wiki_url = "";

                        //знаходимо всі стовпці в таблиці
                        var table3_doc = table2_doc[nums].QuerySelectorAll("td");
                        //обявляємо перемінну
                        var table4_doc = table1_doc[0].QuerySelectorAll("a").Where(item => item.HyperReference != null);
                        try
                        {
                            table4_doc = table3_doc[3].QuerySelectorAll("a").Where(item => item.HyperReference != null);
                        }
                        catch
                        {
                            
                            Program.f1.textBox_Test.Text += Environment.NewLine + "Помилка пошуку опонента" + nums.ToString();
                            nums--;
                            continue;
                        }
                        List<string> fff = new List<string>();
                        //якщо стовпців в таблиці 8(відсутній номер бою)
                        if (table2_doc[nums].QuerySelectorAll("td").Length == 8)
                        {
                            //визначаємо імя боксера
                            opponent = table3_doc[2].Text().Trim();
                            opponent = replace_Text.Replace_all_letters(opponent);
                            //визначаємо ссилку на боксера якщо вона є
                            table4_doc = table3_doc[2].QuerySelectorAll("a").Where(item => item.HyperReference != null);
                            foreach (var item in table4_doc)
                            {
                                if (item.HyperReference != null)
                                {
                                    fff.Add(item.GetAttribute("href"));
                                }
                            }
                            if (fff.Count > 1)
                            {
                                opponent_wiki_url = fff[1];
                                opponent_wiki_url = "https://en.wikipedia.org" + opponent_wiki_url;
                            }
                        }
                        else if (table2_doc[nums].QuerySelectorAll("td").Length == 9)
                        {
                            //визначаємо імя боксера
                            opponent = table3_doc[3].Text().Trim();
                            opponent = replace_Text.Replace_all_letters(opponent);
                            //визначаємо ссилку на боксера якщо вона є
                            table4_doc = table3_doc[3].QuerySelectorAll("a").Where(item => item.HyperReference != null);
                            foreach (var item in table4_doc)
                            {
                                if (item.HyperReference != null)
                                {
                                    fff.Add(item.GetAttribute("href"));
                                }
                            }
                            if (fff.Count > 1)
                            {
                                opponent_wiki_url = fff[1];
                                opponent_wiki_url = "https://en.wikipedia.org" + opponent_wiki_url;
                            }
                        }
                        else if (table2_doc[nums].QuerySelectorAll("td").Length == 10)
                        {
                            //визначаємо імя боксера
                            opponent = table3_doc[3].Text().Trim();
                            opponent = replace_Text.Replace_all_letters(opponent);
                            //визначаємо ссилку на боксера якщо вона є
                            table4_doc = table3_doc[3].QuerySelectorAll("a").Where(item => item.HyperReference != null);
                            foreach (var item in table4_doc)
                            {
                                if (item.HyperReference != null)
                                {
                                    fff.Add(item.GetAttribute("href"));
                                }
                            }
                            if (fff.Count > 1)
                            {
                                opponent_wiki_url = fff[1];
                                opponent_wiki_url = "https://en.wikipedia.org" + opponent_wiki_url;
                            }
                        }
                        //Перевірка на наявність боксера в базі
                        bool query_boxer = audit_boxer.AuditBoxerNameBoxers(opponent);

                        if (query_boxer == false)
                        {
                            Program.f1.textBox_Test.Text += Environment.NewLine + "додаємо " + opponent;
                            //Робимо запрос
                            MySqlCommand command3 = new MySqlCommand("INSERT INTO `boxers` (`name_usa`, `wiki_url_en`) VALUES (@name_usa, @wiki_url_en)", db.getConnection());
                            //маскуємо запроси
                            command3.Parameters.Add("@name_usa", MySqlDbType.VarChar).Value = opponent;
                            command3.Parameters.Add("@wiki_url_en", MySqlDbType.VarChar).Value = opponent_wiki_url;
                            db.openConnection();
                            command3.ExecuteNonQuery();
                            db.closeConnection();
                        }
                        if (query_boxer == true)
                        {
                            nums--;
                            continue;
                            Program.f1.textBox_Test.Text += Environment.NewLine + "Редагуємо " + opponent;
                            //Робимо запрос
                            MySqlCommand command4 = new MySqlCommand("UPDATE boxers SET wiki_url_en = @wiki_url_en WHERE name_usa = @name_usa", db.getConnection());
                            //маскуємо запроси
                            command4.Parameters.Add("@name_usa", MySqlDbType.VarChar).Value = opponent;
                            command4.Parameters.Add("@wiki_url_en", MySqlDbType.VarChar).Value = opponent_wiki_url;
                            db.openConnection();
                            command4.ExecuteNonQuery();
                            db.closeConnection();
                        }
                        //віднімаємо кількість строк в таблиці
                        nums--;
                        if (Program.f1.textBox3.Text == "STOP")
                        {
                            Program.f1.textBox3.Text = id.ToString();
                            return;
                        }
                    }



                }








            }
            reader2.Close();

            MessageBox.Show("Пройшли по всім");







        }
    }
}
