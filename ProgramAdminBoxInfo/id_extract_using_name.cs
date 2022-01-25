

using MySql.Data.MySqlClient;

namespace ProgramAdminBoxInfo
{
    internal class id_extract_using_name
    {
        public string id_name(string name_usa)
        {
            DB db = new DB();
            string id = "";
            MySqlCommand command = new MySqlCommand("SELECT id FROM boxers WHERE name_usa = @name_usa", db.getConnection());
            command.Parameters.Add("@name_usa", MySqlDbType.VarChar).Value = name_usa;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id = reader.GetString("id");
            }
            reader.Close();
            db.closeConnection();
            return id;
        }
    }
}
