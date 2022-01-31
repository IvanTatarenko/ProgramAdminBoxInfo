using AngleSharp;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProgramAdminBoxInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Program.f1 = this;
            InitializeComponent();
            SELECT_boxers S_boxers = new SELECT_boxers();
            S_boxers.SELEKT_query("name_ua name_usa height reach stance wiki_url_en wiki_url_ua boxreg_url nationality residence birth_place division");
        }

        
        
        private void button1_Click(object sender, EventArgs e)
        {
            int id_row = dataGridView1.CurrentCell.RowIndex;
            string id = dataGridView1["id", id_row].Value.ToString();
            string name = dataGridView1["name_usa", id_row].Value.ToString();
            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете видалити боксера " + name + "?",
                "Видалити?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                DELETE_boxers d_boxer = new DELETE_boxers();
                d_boxer.Delete_query(id);
                MessageBox.Show("Боксера " + name + " видалено");
            }
            SELECT_boxers S_boxers = new SELECT_boxers();
            S_boxers.SELEKT_query("name_ua name_usa height reach stance wiki_url_en wiki_url_ua boxreg_url nationality residence birth_place division");

        }

        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string text_edit = "";
            string id;
            if (dataGridView1["id", e.RowIndex].Value == null)
            {
                return;
            }
            else
            {
                id = dataGridView1["id", e.RowIndex].Value.ToString();
            }
            
            if(dataGridView1[e.ColumnIndex, e.RowIndex].Value != null)
            {
                text_edit = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            string text_column = dataGridView1.Columns[e.ColumnIndex].Name;
            UPDATE_boxers U_boxers = new UPDATE_boxers();
            if (text_column == "name_usa") U_boxers.Update_query(id, text_edit, "", "", "", "", "", "", "", "", "", "", "");
            if (text_column == "name_ua") U_boxers.Update_query(id, "", text_edit, "", "", "", "", "", "", "", "", "", "");
            if (text_column == "height") U_boxers.Update_query(id, "", "", text_edit, "", "", "", "", "", "", "", "", "");
            if (text_column == "reach") U_boxers.Update_query(id, "", "", "", text_edit, "", "", "", "", "", "", "", "");
            if (text_column == "stance") U_boxers.Update_query(id, "", "", "", "", text_edit, "", "", "", "", "", "", "");
            if (text_column == "wiki_url_en") U_boxers.Update_query(id, "", "", "", "", "", text_edit, "", "", "", "", "", "");
            if (text_column == "wiki_url_ua") U_boxers.Update_query(id, "", "", "", "", "", "", text_edit, "", "", "", "", "");
            if (text_column == "boxreg_url") U_boxers.Update_query(id, "", "", "", "", "", "", "", text_edit, "", "", "", "");
            if (text_column == "nationality") U_boxers.Update_query(id, "", "", "", "", "", "", "", "", text_edit, "", "", "");
            if (text_column == "residence") U_boxers.Update_query(id, "", "", "", "", "", "", "", "", "", text_edit, "", "");
            if (text_column == "birth_place") U_boxers.Update_query(id, "", "", "", "", "", "", "", "", "", "", text_edit, "");
            if (text_column == "division") U_boxers.Update_query(id, "", "", "", "", "", "", "", "", "", "", "", text_edit);

            MessageBox.Show("Відредаговано");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id_box_reg = 1;
            if (textBox1.Text != "") id_box_reg = Convert.ToInt32(textBox1.Text);
            textBox_Test.Text += Environment.NewLine + "Парсінг Персон BoxReg" + Environment.NewLine + "Початковий ID - " + id_box_reg;
            Parsing_boxreg pr_br = new Parsing_boxreg();
            pr_br.Person(id_box_reg);
            
        }

        private void textBox_Test_TextChanged_1(object sender, EventArgs e)
        {
            textBox_Test.SelectionStart = textBox_Test.Text.Length;
            textBox_Test.ScrollToCaret();
            textBox_Test.Refresh();
        }

        private void bt_stop_Click(object sender, EventArgs e)
        {
            textBox1.Text = "STOP";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            SELECT_boxers S_boxers = new SELECT_boxers();
            S_boxers.SELEKT_query("name_ua name_usa height reach stance wiki_url_en wiki_url_ua boxreg_url nationality residence birth_place division");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bd_site_Insert add = new bd_site_Insert();
            textBox_Test.Text += Environment.NewLine + "Початок додавання бази боксерів на сайт";
            add.add();
            textBox_Test.Text += Environment.NewLine + "База боксерів додана на сайт";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Parser_wiki_url_en parser_wiki_en = new Parser_wiki_url_en();
            parser_wiki_en.Parser_Wiki_en();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox3.Text = "STOP";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string nulll = "";
            string quary = "";
            if (comboBox1.Text == "name_ua") quary = "DELETE FROM boxers WHERE name_ua = @null";
            if (comboBox1.Text == "name_usa") quary = "DELETE FROM boxers WHERE name_usa = @null";
            if (comboBox1.Text == "height") quary = "DELETE FROM boxers WHERE height = @null";
            if (comboBox1.Text == "reach") quary = "DELETE FROM boxers WHERE reach = @null";
            if (comboBox1.Text == "stance") quary = "DELETE FROM boxers WHERE stance = @null";
            if (comboBox1.Text == "wiki_url_en") quary = "DELETE FROM boxers WHERE wiki_url_en = @null";
            if (comboBox1.Text == "wiki_url_ua") quary = "DELETE FROM boxers WHERE wiki_url_ua = @null";
            DB db = new DB();
            MySqlCommand command = new MySqlCommand(quary, db.getConnection());
            command.Parameters.Add("@null", MySqlDbType.VarChar).Value = nulll;
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
            textBox_Test.Text += Environment.NewLine + "Видалено всі без " + comboBox1.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Parser_wiki_url_ua wiki_url_ua = new Parser_wiki_url_ua();
            wiki_url_ua.wiki_url_ua();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox4.Text = "STOP";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox_Test.Text += Environment.NewLine + "Видалення сміття розпочато";
            // підлючення  до бд
            DB db = new DB();
            //Команда бд
            MySqlCommand command2 = new MySqlCommand("SELECT * FROM boxers", db.getConnection());
            //створюємо таблицю в яку будемо додавати данні
            DataTable dt = new DataTable("name_boxers");
            //Називаємо ствбці в таблиці
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name_usa", typeof(string));
            //відкриваємо зєднання
            db.openConnection();
            //створюємо ріадер для зчитування данних з Mysql
            MySqlDataReader reader = command2.ExecuteReader();
            //створюємо перемінні для аналізу
            string name_usa;
            int id;
            //Витаскуємо данні з бази
            while (reader.Read())
            {
                id = reader.GetInt32(reader.GetOrdinal("id"));
                name_usa = reader.GetString(reader.GetOrdinal("name_usa"));
                //вносимо в таблицю данні
                dt.Rows.Add(new Object[] { id, name_usa });
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
                string[] ggg = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Boxing" };
                name_usa = reader2.GetString(reader2.GetOrdinal("name_usa"));
                id = reader2.GetInt32(reader2.GetOrdinal("id"));
                foreach (string g in ggg)
                {
                    if (name_usa.Contains(g))
                    {
                        DELETE_boxers del = new DELETE_boxers();
                        del.Delete_query(id.ToString(id.ToString()));
                        textBox_Test.Text += Environment.NewLine + "Видалено " + id + " " + name_usa;
                    }
                }
                
            }
            textBox_Test.Text += Environment.NewLine + "Видалення сміття завершено";
        }

        
    }
}