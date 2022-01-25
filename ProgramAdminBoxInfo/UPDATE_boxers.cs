

using MySql.Data.MySqlClient;

namespace ProgramAdminBoxInfo
{
    internal class UPDATE_boxers
    {
        public void Update_query(string id, string name_usa = "", string name_ua = "", string height = "", string reach = "", string stance = "", string wiki_url_en = "", string wiki_url_ua = "", string boxreg_url = "")
        {
            string query = "UPDATE boxers SET";
            if (name_usa != "") query = query + " name_usa = @name_usa,";
            if (name_ua != "") query = query + " name_ua = @name_ua,";
            if (height != "") query = query + " height = @height,";
            if (reach != "") query = query + " reach = @reach,";
            if (stance != "") query = query + " stance = @stance,";
            if (wiki_url_en != "") query = query + " wiki_url_en = @wiki_url_en,";
            if (wiki_url_ua != "") query = query + " wiki_url_ua = @wiki_url_ua,";
            if (boxreg_url != "") query = query + " boxreg_url = @boxreg_url,";
            
            query = query + " id = @id WHERE id = @id";
            DB db = new DB();
            //Робимо запрос
            MySqlCommand command = new MySqlCommand(query, db.getConnection());
            //маскуємо запроси
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@name_usa", MySqlDbType.VarChar).Value = name_usa;
            command.Parameters.Add("@name_ua", MySqlDbType.VarChar).Value = name_ua;
            command.Parameters.Add("@height", MySqlDbType.VarChar).Value = height;
            command.Parameters.Add("@reach", MySqlDbType.VarChar).Value = reach;
            command.Parameters.Add("@stance", MySqlDbType.VarChar).Value = stance;
            command.Parameters.Add("@wiki_url_en", MySqlDbType.VarChar).Value = wiki_url_en;
            command.Parameters.Add("@wiki_url_ua", MySqlDbType.VarChar).Value = wiki_url_ua;
            command.Parameters.Add("@boxreg_url", MySqlDbType.VarChar).Value = boxreg_url;
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
        }
    }
}
