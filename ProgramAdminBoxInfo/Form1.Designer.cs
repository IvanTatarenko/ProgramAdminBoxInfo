namespace ProgramAdminBoxInfo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Test = new System.Windows.Forms.RichTextBox();
            this.bt_stop = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.bt_stop_2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(949, 353);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(489, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(472, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "Видалити запис";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 601);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "Парсінг персон boxrec";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 572);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(181, 23);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 575);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Початковий ID";
            // 
            // textBox_Test
            // 
            this.textBox_Test.Location = new System.Drawing.Point(967, 12);
            this.textBox_Test.Name = "textBox_Test";
            this.textBox_Test.Size = new System.Drawing.Size(495, 618);
            this.textBox_Test.TabIndex = 7;
            this.textBox_Test.Text = "";
            this.textBox_Test.TextChanged += new System.EventHandler(this.textBox_Test_TextChanged_1);
            // 
            // bt_stop
            // 
            this.bt_stop.Location = new System.Drawing.Point(219, 601);
            this.bt_stop.Name = "bt_stop";
            this.bt_stop.Size = new System.Drawing.Size(75, 29);
            this.bt_stop.TabIndex = 8;
            this.bt_stop.Text = "STOP";
            this.bt_stop.UseVisualStyleBackColor = true;
            this.bt_stop.Click += new System.EventHandler(this.bt_stop_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 371);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(472, 29);
            this.button3.TabIndex = 9;
            this.button3.Text = "Оновити";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(327, 601);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(201, 29);
            this.button5.TabIndex = 10;
            this.button5.Text = "Парсінг боїв BoxReg";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(428, 572);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(181, 23);
            this.textBox2.TabIndex = 11;
            // 
            // bt_stop_2
            // 
            this.bt_stop_2.Location = new System.Drawing.Point(534, 601);
            this.bt_stop_2.Name = "bt_stop_2";
            this.bt_stop_2.Size = new System.Drawing.Size(75, 29);
            this.bt_stop_2.TabIndex = 12;
            this.bt_stop_2.Text = "STOP";
            this.bt_stop_2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 575);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Початковий ID";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 406);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(472, 29);
            this.button6.TabIndex = 15;
            this.button6.Text = "Залити базу боксерів на сайт";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(656, 601);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(201, 29);
            this.button7.TabIndex = 16;
            this.button7.Text = "Парсінг силок на WIKI_EN";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(656, 575);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Початковий ID";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(757, 572);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(181, 23);
            this.textBox3.TabIndex = 17;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(863, 601);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 29);
            this.button8.TabIndex = 19;
            this.button8.Text = "STOP";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(106, 466);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(116, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Видалити";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "name_ua",
            "name_usa",
            "height",
            "reach",
            "stance",
            "wiki_url_en",
            "wiki_url_ua\t"});
            this.comboBox1.Location = new System.Drawing.Point(12, 466);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(88, 23);
            this.comboBox1.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 448);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "Видалення записів з відсутнім полем";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(863, 516);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 29);
            this.button10.TabIndex = 26;
            this.button10.Text = "STOP";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(656, 490);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Початковий ID";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(757, 487);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(181, 23);
            this.textBox4.TabIndex = 24;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(656, 516);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(201, 29);
            this.button11.TabIndex = 23;
            this.button11.Text = "Парсінг силок на WIKI_UA";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(12, 503);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(210, 55);
            this.button12.TabIndex = 27;
            this.button12.Text = "Знищити сміття з бази";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 642);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bt_stop_2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.bt_stop);
            this.Controls.Add(this.textBox_Test);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        public TextBox textBox1;
        private Label label1;
        public RichTextBox textBox_Test;
        public Button bt_stop;
        private Button button3;
        private Button button4;
        private Button button5;
        private TextBox textBox2;
        public Button bt_stop_2;
        private Label label2;
        private Button button6;
        private Button button7;
        private Label label3;
        public TextBox textBox3;
        public Button button8;
        private Button button9;
        private ComboBox comboBox1;
        private Label label4;
        public Button button10;
        private Label label5;
        public TextBox textBox4;
        private Button button11;
        private Button button12;
    }
}