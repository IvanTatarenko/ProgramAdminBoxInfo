using MySql.Data.MySqlClient;

namespace ProgramAdminBoxInfo
{
    internal class SELECT_boxers
    {

        public void SELEKT_query(string query)
        {
            query = query.Replace(" ", "/");
            string[] query_mas = query.Split('/');
            query = "SELECT ";
            foreach (string s in query_mas)
            {
                query = query + s + ", ";
            }
            query = query + "id FROM boxers";
            DB db = new DB();
            MySqlCommand command = new MySqlCommand(query, db.getConnection());
            db.openConnection();
            var reader = command.ExecuteReader();
            var list = new List<boxer_sp>();
            
            while (reader.Read())
            {
                
                var boxer = new boxer_sp();
                boxer.id = reader.GetInt32("id");
                foreach (string s in query_mas)
                {
                    if (s == "name_ua" && !reader.IsDBNull(reader.GetOrdinal("name_ua"))) boxer.name_ua = reader.GetString("name_ua");
                    if (s == "name_usa" && !reader.IsDBNull(reader.GetOrdinal("name_usa"))) boxer.name_usa = reader.GetString("name_usa");
                    if (s == "height" && !reader.IsDBNull(reader.GetOrdinal("height"))) boxer.height = reader.GetString("height");
                    if (s == "reach" && !reader.IsDBNull(reader.GetOrdinal("reach"))) boxer.reach = reader.GetString("reach");
                    if (s == "stance" && !reader.IsDBNull(reader.GetOrdinal("stance"))) boxer.stance = reader.GetString("stance");
                    if (s == "wiki_url_en" && !reader.IsDBNull(reader.GetOrdinal("wiki_url_en"))) boxer.wiki_url_en = reader.GetString("wiki_url_en");
                    if (s == "wiki_url_ua" && !reader.IsDBNull(reader.GetOrdinal("wiki_url_ua"))) boxer.wiki_url_ua = reader.GetString("wiki_url_ua");
                    if (s == "boxreg_url" && !reader.IsDBNull(reader.GetOrdinal("boxreg_url"))) boxer.boxreg_url = reader.GetString("boxreg_url");
                    if (s == "nationality" && !reader.IsDBNull(reader.GetOrdinal("nationality"))) boxer.nationality = reader.GetString("nationality");
                    if (s == "residence" && !reader.IsDBNull(reader.GetOrdinal("residence"))) boxer.residence = reader.GetString("residence");
                    if (s == "birth_place" && !reader.IsDBNull(reader.GetOrdinal("birth_place"))) boxer.birth_place = reader.GetString("birth_place");
                    if (s == "division" && !reader.IsDBNull(reader.GetOrdinal("division"))) boxer.division = reader.GetString("division");
                    

                }
                list.Add(boxer);
                
            }
            reader.Close();
            db.closeConnection();
            Program.f1.dataGridView1.ClearSelection();
            Program.f1.dataGridView1.DataSource = list;
        }

        
    }
}
