using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB338Core;

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

        private void BtnSubmitQuery_Click(object sender, EventArgs e)
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

        private void Clear_Click(object sender, EventArgs e)
        {
            TxtQuery.Text = "";

        }

    }
}
