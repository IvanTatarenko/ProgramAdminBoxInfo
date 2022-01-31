using MySql.Data.MySqlClient;


namespace ProgramAdminBoxInfo
{
    internal class Audit_name_site
    {
        public bool AuditBoxerNameBoxers(string name)//true = є, false = нема
        {
            Replace_text replace_Text = new Replace_text();
            name = replace_Text.Replace_all_letters(name);
            DB2 db = new DB2();
            string nameBaza;
            MySqlCommand command = new MySqlCommand("SELECT name_usa FROM boxers", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
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
            reader.Close();
            db.closeConnection();
            return false;
        }
    }
}
