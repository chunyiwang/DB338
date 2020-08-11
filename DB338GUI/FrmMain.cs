using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB338Core;
using System.Drawing.Printing;

namespace DB338GUI
{
    public partial class FrmMain : Form
    {
        public DB338 db;

        public FrmMain()
        {
            InitializeComponent();
            db = new DB338();
        }

        private void BtnSubmitQueryBox_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < TxtQuery.Lines.Length; ++i)
            {
                QueryResult queryResult = db.SubmitQuery(TxtQuery.Lines[i]);
                string[,] queryResults = queryResult.Results;
                if (queryResult.Error != "none")
                {
                    //null means error
                    MessageBox.Show("Input SQL contained a " + queryResult.Error + " error.");
                }
                else {
                    Output(queryResult);
                }
            }
        }

        public void Output(QueryResult results)
        {
            string s = "";
            for (int i = 0; i <= results.Results.GetUpperBound(0); ++i)
            {
                for (int j = 0; j <= results.Results.GetUpperBound(1); ++j)
                {
                    s += results.Results[i, j] + ", ";
                }
                s += Environment.NewLine;
            }
            TxtResults.Text = s;
            int numRow = results.Results.GetUpperBound(0) + 1;
            int numCol = results.Results.GetUpperBound(1) + 1;
            ResultSummary.Text = "Results: " + numRow + " rows, " + numCol + " columns" + " returned in " + results.Time + " Milliseconds"; ;

        }



        private void PrintDocumentOnPrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(TxtQuery.Text, TxtQuery.Font, Brushes.Black, 10, 25);
        }

        private void PrintBox_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                PrintDocument document = new PrintDocument();
                document.PrintPage += PrintDocumentOnPrintPage;
                document.Print();
            }
        }

        private void PrintBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.PrintBox, "Print SQL Query");
        }

        private void SaveBox_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Text files (*.txt)|*.sql";
            sf.FilterIndex = 2;
            sf.RestoreDirectory = true;
            if (sf.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(sf.FileName, TxtQuery.Text);
            }
        }

        private void SaveBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.SaveBox, "Save SQL File");
        }

        private void ClearBox_Click(object sender, EventArgs e)
        {
            TxtQuery.Text = "";
        }

        private void ClearBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.ClearBox, "Clear SQL Query");
        }


        private void BtnSubmitQueryBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.BtnSubmitQueryBox, "Run SQL Query");
        }
    }
}
