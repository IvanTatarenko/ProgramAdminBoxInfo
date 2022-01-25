using MySql.Data.MySqlClient;

namespace ProgramAdminBoxInfo
{
    internal class DELETE_boxers
    {
        public void Delete_query(string id)
        {
            // підлючення  до бд
            DB db = new DB();
            //Команда бд
            MySqlCommand command = new MySqlCommand("DELETE FROM boxers WHERE id = @id", db.getConnection());
            //маскуємо запроси
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
        }
    }
}
