using AngleSharp;
using AngleSharp.Dom;

namespace ProgramAdminBoxInfo
{
    internal class Parsing_boxreg
    {
        public async Task Person(int id_box_reg)
        {
            Program.f1.textBox_Test.Text += Environment.NewLine + "Налаштовуємо парсер";
            //parsing settings
            var config = Configuration.Default.WithDefaultLoader();
            using var context = BrowsingContext.New(config);
            var boxer = new boxer_sp();
            while (id_box_reg < 2000000)
            {

                //Determine the link to the page
                string url = "https://boxrec.com/en/proboxer/" + id_box_reg;
                Program.f1.textBox_Test.Text += Environment.NewLine + "Відкриваємо сторінку" + url;
                using var doc = await context.OpenAsync(url);
                //check for page availability
                if (doc.Title == "BoxRec: not found")
                {
                    Program.f1.textBox_Test.Text += Environment.NewLine + "Сторінки не існує";
                    id_box_reg++;
                    continue;
                }
                var query_h1 = doc.QuerySelectorAll("h1");
                //Name Eng
                boxer.name_usa = query_h1[1].Text().Trim();
                Program.f1.textBox_Test.Text += Environment.NewLine + "Ім'я Англ - " + boxer.name_usa;
                //link box_reg
                boxer.boxreg_url = url + "/";
                var table_rowTable = doc.QuerySelectorAll("table.rowTable");
                string table1 = table_rowTable[0].Text().Trim();
                string table2 = table_rowTable[1].Text().Trim();







                id_box_reg++;
            }
        }
    }
}
