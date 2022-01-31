

using AngleSharp;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProgramAdminBoxInfo
{
    internal class Parser_wiki_url_ua
    {
        public async Task wiki_url_ua()
        {
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
            string wiki_url_ua = "";
            int id;
            int num_id = Convert.ToInt32(Program.f1.textBox4.Text);
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

                //значення імя та юрл з бази
                id = reader2.GetInt32(reader2.GetOrdinal("id"));
                if (Program.f1.textBox4.Text == "STOP")
                {
                    Program.f1.textBox4.Text = id.ToString();
                    return;
                }
                name_usa = reader2.GetString(reader2.GetOrdinal("name_usa"));
                wiki_url_en = reader2.GetString(reader2.GetOrdinal("wiki_url_en"));
                Program.f1.textBox_Test.Text += Environment.NewLine + "ID " + id.ToString();
                //перевірка на виключення з бази виключених силок
                MySqlCommand command7 = new MySqlCommand("SELECT * FROM exclusion_wiki_url WHERE url_en = @wiki_url_en", db.getConnection());
                command7.Parameters.Add("@wiki_url_en", MySqlDbType.VarChar).Value = wiki_url_en;
                //відкриваємо зєднання
                db.openConnection();
                if (command7.ExecuteReader().HasRows)
                {
                    //Закриваємо з"єднання
                    db.closeConnection();
                    continue;
                }
                //Закриваємо з"єднання
                db.closeConnection();
                //всякі важливі штуки для парсінгу
                var config = Configuration.Default.WithDefaultLoader().WithRequesters();
                using var context = BrowsingContext.New(config);
                //Відкриваємо юрл
                using var doc = await context.OpenAsync(wiki_url_en);
                //якщо юрл наявне то починаємо його парсити
                if (wiki_url_en != "")
                {
                    wiki_url_ua = "";
                    //Виводимо юрл яке парситься на данний час

                    var table2_doc = doc.QuerySelectorAll("li.interlanguage-link.interwiki-uk.mw-list-item");
                    foreach (var item in table2_doc)
                    {
                        if (item != null)
                        {
                            var table3_doc = table2_doc[0].QuerySelectorAll("a");
                            wiki_url_ua = table3_doc[0].GetAttribute("href");
                        }

                    }
                    if (wiki_url_ua != "")
                    {
                        Program.f1.textBox_Test.Text += Environment.NewLine + "Додаємо силку на вікі ЮА - " + name_usa;
                        //Робимо запрос
                        MySqlCommand command6 = new MySqlCommand("UPDATE boxers SET wiki_url_ua = @wiki_url_ua WHERE name_usa = @name_usa", db.getConnection());
                        //маскуємо запроси
                        command6.Parameters.Add("@name_usa", MySqlDbType.VarChar).Value = name_usa;
                        command6.Parameters.Add("@wiki_url_ua", MySqlDbType.VarChar).Value = wiki_url_ua;
                        db.openConnection();
                        command6.ExecuteNonQuery();
                        db.closeConnection();
                    }

                    





                }

            }
            Program.f1.textBox_Test.Text += Environment.NewLine + "Збір силок завершено";
        }
    }
}
