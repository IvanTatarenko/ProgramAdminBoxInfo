

using MySql.Data.MySqlClient;

namespace ProgramAdminBoxInfo
{
    internal class Audit_name_duble
    {
        public bool AuditBoxerNameBoxers(string name)//перевірка наявності співпадіння імені в базі данних боксерів true = є, false = нема
        {
            Replace_text replace_Text = new Replace_text();
            name = replace_Text.Replace_all_letters(name);
            // підлючення  до бд
            DB db = new DB();
            string nameBaza;
            //Команда бд
            MySqlCommand command = new MySqlCommand("SELECT name_usa FROM boxers", db.getConnection());
            //відкриваємо зєднання
            db.openConnection();
            //створюємо ріадер для зчитування данних з Mysql
            MySqlDataReader reader = command.ExecuteReader();
            //Витаскуємо данні з бази, аналізуємо та прогнозуємо переможця
            while (reader.Read())
            {
                nameBaza = reader.GetString("name_usa").ToUpper();
                if (nameBaza == name.ToUpper())
                {
                    reader.Close();
                    db.closeConnection();
                    return true;
                }
            }
            //закриваємо ріадер
            reader.Close();
            //Закриваємо з"єднання
            db.closeConnection();
            return false;
        }
    }
}
