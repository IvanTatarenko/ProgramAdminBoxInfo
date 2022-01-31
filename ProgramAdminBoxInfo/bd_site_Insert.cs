

using MySql.Data.MySqlClient;

namespace ProgramAdminBoxInfo
{
    internal class bd_site_Insert
    {
        public void add()
        {
            string quary_insert = "INSERT INTO `boxers` (`id`, `name_ua`, `name_usa`, `height_ua`, `reach_ua`, `stance_ua`, `wiki_url_en`, `wiki_url_ua`) VALUES ";
            string quary_update = "";
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM boxers", db.getConnection());
            db.openConnection();
            var list = new List<boxer_sp>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var boxer = new boxer_sp();
                boxer.id = reader.GetInt32("id");
                if (!reader.IsDBNull(reader.GetOrdinal("name_ua")) && reader.GetString("name_ua") != "") boxer.name_ua = reader.GetString("name_ua");
                if (!reader.IsDBNull(reader.GetOrdinal("name_usa")) && reader.GetString("name_usa") != "") boxer.name_usa = reader.GetString("name_usa");
                if (!reader.IsDBNull(reader.GetOrdinal("height")) && reader.GetString("height") != "") boxer.height = reader.GetString("height");
                if (!reader.IsDBNull(reader.GetOrdinal("reach")) && reader.GetString("reach") != "") boxer.reach = reader.GetString("reach");
                if (!reader.IsDBNull(reader.GetOrdinal("stance")) && reader.GetString("stance") != "") boxer.stance = reader.GetString("stance");
                if (!reader.IsDBNull(reader.GetOrdinal("wiki_url_en")) && reader.GetString("wiki_url_en") != "") boxer.wiki_url_en = reader.GetString("wiki_url_en");
                if (!reader.IsDBNull(reader.GetOrdinal("wiki_url_ua")) && reader.GetString("wiki_url_ua") != "") boxer.wiki_url_ua = reader.GetString("wiki_url_ua");
                if (!reader.IsDBNull(reader.GetOrdinal("boxreg_url")) && reader.GetString("boxreg_url") != "") boxer.boxreg_url = reader.GetString("boxreg_url");
                if (!reader.IsDBNull(reader.GetOrdinal("nationality")) && reader.GetString("nationality") != "") boxer.nationality = reader.GetString("nationality");
                if (!reader.IsDBNull(reader.GetOrdinal("residence")) && reader.GetString("residence") != "") boxer.residence = reader.GetString("residence");
                if (!reader.IsDBNull(reader.GetOrdinal("birth_place")) && reader.GetString("birth_place") != "") boxer.birth_place = reader.GetString("birth_place");
                if (!reader.IsDBNull(reader.GetOrdinal("division")) && reader.GetString("division") != "") boxer.division = reader.GetString("division");
                list.Add(boxer);
            }
            reader.Close();
            db.closeConnection();

            foreach (var boxer in list)
            {
                Audit_name_site audit_boxer = new Audit_name_site();
                if (audit_boxer.AuditBoxerNameBoxers(boxer.name_usa) == false)
                {
                    Program.f1.textBox_Test.Text += Environment.NewLine + "Додаємо " + boxer.name_usa;
                    quary_insert = quary_insert + " (NULL, '" + boxer.name_ua + "', '" + boxer.name_usa + "', '" + boxer.height + "', '" + boxer.reach + "', '" + boxer.stance + "', '" + boxer.wiki_url_en + "', '" + boxer.wiki_url_ua + "'),";
                    
                    
                }
                else if (audit_boxer.AuditBoxerNameBoxers(boxer.name_usa) == true)
                {
                    Program.f1.textBox_Test.Text += Environment.NewLine + "Редагуємо " + boxer.name_usa;
                    quary_update = quary_update + "UPDATE `boxers` SET `name_ua` = '" + boxer.name_ua + "', `height_ua` = '" + boxer.height + "', `reach_ua` = '" + boxer.reach + "', `stance_ua` = '" + boxer.stance + "', `wiki_url_en` = '" + boxer.wiki_url_en + "', `wiki_url_ua` = '" + boxer.wiki_url_ua + "' WHERE `boxers`.`name_usa` = '" + boxer.name_usa + "';";

                }
                
            }
            if (quary_insert != "INSERT INTO `boxers` (`id`, `name_ua`, `name_usa`, `height_ua`, `reach_ua`, `stance_ua`, `wiki_url_en`, `wiki_url_ua`) VALUES ")
            {
                int l = quary_insert.Length;
                quary_insert = quary_insert.Remove(l - 1);
                quary_insert = quary_insert.Insert(l - 1, ";");
                DB2 db2 = new DB2();
                MySqlCommand command2 = new MySqlCommand(quary_insert, db2.getConnection());
                db2.openConnection();
                command2.ExecuteReader();
                db2.closeConnection();
                Program.f1.textBox_Test.Text += Environment.NewLine + "Боксери додані";
            }
            if (quary_update != "")
            {
                DB2 db2 = new DB2();
                MySqlCommand command2 = new MySqlCommand(quary_update, db2.getConnection());
                db2.openConnection();
                command2.ExecuteReader();
                db2.closeConnection();
                Program.f1.textBox_Test.Text += Environment.NewLine + "Боксери оновлені";
            }
            
        }
    }
}
