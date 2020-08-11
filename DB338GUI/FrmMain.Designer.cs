using System.Windows.Forms;

namespace DB338GUI
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.TxtQuery = new System.Windows.Forms.TextBox();
            this.BtnSubmitQuery = new System.Windows.Forms.Button();
            this.TxtResults = new System.Windows.Forms.TextBox();
            this.ResultSummary = new System.Windows.Forms.TextBox();
            this.Clear = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Print = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtQuery
            // 
            this.TxtQuery.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtQuery.Location = new System.Drawing.Point(18, 18);
            this.TxtQuery.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtQuery.Multiline = true;
            this.TxtQuery.Name = "TxtQuery";
            this.TxtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtQuery.Size = new System.Drawing.Size(1006, 230);
            this.TxtQuery.TabIndex = 1;
            this.TxtQuery.Text = resources.GetString("TxtQuery.Text");
            // 
            // BtnSubmitQuery
            // 
            this.BtnSubmitQuery.Location = new System.Drawing.Point(1035, 92);
            this.BtnSubmitQuery.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnSubmitQuery.Name = "BtnSubmitQuery";
            this.BtnSubmitQuery.Size = new System.Drawing.Size(144, 45);
            this.BtnSubmitQuery.TabIndex = 2;
            this.BtnSubmitQuery.Text = "Run";
            this.BtnSubmitQuery.UseVisualStyleBackColor = true;
            this.BtnSubmitQuery.Click += new System.EventHandler(this.BtnSubmitQuery_Click);
            // 
            // TxtResults
            // 
            this.TxtResults.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtResults.Location = new System.Drawing.Point(18, 260);
            this.TxtResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtResults.Multiline = true;
            this.TxtResults.Name = "TxtResults";
            this.TxtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtResults.Size = new System.Drawing.Size(1006, 217);
            this.TxtResults.TabIndex = 3;
            // 
            // ResultSummary
            // 
            this.ResultSummary.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultSummary.Location = new System.Drawing.Point(18, 487);
            this.ResultSummary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ResultSummary.Multiline = true;
            this.ResultSummary.Name = "ResultSummary";
            this.ResultSummary.Size = new System.Drawing.Size(1006, 114);
            this.ResultSummary.TabIndex = 7;
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(1035, 37);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(143, 41);
            this.Clear.TabIndex = 4;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(1035, 147);
            this.Save.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(144, 45);
            this.Save.TabIndex = 8;
            this.Save.Text = "Save SQL File";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Print
            // 
            this.Print.Location = new System.Drawing.Point(1035, 203);
            this.Print.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(144, 45);
            this.Print.TabIndex = 9;
            this.Print.Text = "Print";
            this.Print.UseVisualStyleBackColor = true;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 615);
            this.Controls.Add(this.Print);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.ResultSummary);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.TxtResults);
            this.Controls.Add(this.BtnSubmitQuery);
            this.Controls.Add(this.TxtQuery);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.Text = "DB338 0.02 Alpha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtQuery;
        private System.Windows.Forms.Button BtnSubmitQuery;
        private System.Windows.Forms.TextBox TxtResults;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.TextBox ResultSummary;
        private Button Save;
        private Button Print;
    }
}

