using AngleSharp;


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
            string id = dataGridView1["id", e.RowIndex].Value.ToString();
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
    }
}