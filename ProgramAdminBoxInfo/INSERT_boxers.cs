
using MySql.Data.MySqlClient;



namespace ProgramAdminBoxInfo
{
    internal class INSERT_boxers
    {
        public void Insert_query(string name_usa, string name_ua = "", string height = "", string reach = "", string stance = "", string wiki_url_en = "", string wiki_url_ua = "", string boxreg_url = "", string nationality = "", string residence = "", string birth_place = "", string division = "")
        {
            //connection to the database
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `boxers` (`name_usa`, `name_ua`, `height`, `reach`, `stance`, `wiki_url_en`, `wiki_url_ua`, `boxreg_url`, `nationality`, `residence`, `birth_place`, `division`) VALUES (@name_usa, @name_ua, @height, @reach, @stance, @wiki_url_en, @wiki_url_ua, @boxreg_url, @nationality, @residence, @birth_place, @division)", db.getConnection());
            //mask requests
            command.Parameters.Add("@name_usa", MySqlDbType.VarChar).Value = name_usa;
            command.Parameters.Add("@name_ua", MySqlDbType.VarChar).Value = name_ua;
            command.Parameters.Add("@height", MySqlDbType.VarChar).Value = height;
            command.Parameters.Add("@reach", MySqlDbType.VarChar).Value = reach;
            command.Parameters.Add("@stance", MySqlDbType.VarChar).Value = stance;
            command.Parameters.Add("@wiki_url_en", MySqlDbType.VarChar).Value = wiki_url_en;
            command.Parameters.Add("@wiki_url_ua", MySqlDbType.VarChar).Value = wiki_url_ua;
            command.Parameters.Add("@boxreg_url", MySqlDbType.VarChar).Value = boxreg_url;
            command.Parameters.Add("@nationality", MySqlDbType.VarChar).Value = nationality;
            command.Parameters.Add("@residence", MySqlDbType.VarChar).Value = residence;
            command.Parameters.Add("@birth_place", MySqlDbType.VarChar).Value = birth_place;
            command.Parameters.Add("@division", MySqlDbType.VarChar).Value = division;
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
        }
    }
}
