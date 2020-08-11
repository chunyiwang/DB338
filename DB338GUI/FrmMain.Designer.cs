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
            this.TxtResults = new System.Windows.Forms.TextBox();
            this.ResultSummary = new System.Windows.Forms.TextBox();
            this.SaveBox = new System.Windows.Forms.PictureBox();
            this.PrintBox = new System.Windows.Forms.PictureBox();
            this.ClearBox = new System.Windows.Forms.PictureBox();
            this.BtnSubmitQueryBox = new System.Windows.Forms.PictureBox();
            this.SaveResult = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SaveBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClearBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSubmitQueryBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveResult)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtQuery
            // 
            this.TxtQuery.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtQuery.Location = new System.Drawing.Point(18, 80);
            this.TxtQuery.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtQuery.Multiline = true;
            this.TxtQuery.Name = "TxtQuery";
            this.TxtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtQuery.Size = new System.Drawing.Size(1127, 168);
            this.TxtQuery.TabIndex = 1;
            this.TxtQuery.Text = resources.GetString("TxtQuery.Text");
            // 
            // TxtResults
            // 
            this.TxtResults.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtResults.Location = new System.Drawing.Point(18, 260);
            this.TxtResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtResults.Multiline = true;
            this.TxtResults.Name = "TxtResults";
            this.TxtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtResults.Size = new System.Drawing.Size(1127, 217);
            this.TxtResults.TabIndex = 3;
            // 
            // ResultSummary
            // 
            this.ResultSummary.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultSummary.Location = new System.Drawing.Point(18, 487);
            this.ResultSummary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ResultSummary.Multiline = true;
            this.ResultSummary.Name = "ResultSummary";
            this.ResultSummary.Size = new System.Drawing.Size(1127, 114);
            this.ResultSummary.TabIndex = 7;
            // 
            // SaveBox
            // 
            this.SaveBox.Image = global::EduDBGUI.Properties.Resources.Save_icon;
            this.SaveBox.Location = new System.Drawing.Point(153, 12);
            this.SaveBox.Name = "SaveBox";
            this.SaveBox.Size = new System.Drawing.Size(110, 59);
            this.SaveBox.TabIndex = 11;
            this.SaveBox.TabStop = false;
            this.SaveBox.Click += new System.EventHandler(this.SaveBox_Click);
            this.SaveBox.MouseHover += new System.EventHandler(this.SaveBox_MouseHover);
            // 
            // PrintBox
            // 
            this.PrintBox.Image = global::EduDBGUI.Properties.Resources.Printer_icon;
            this.PrintBox.InitialImage = null;
            this.PrintBox.Location = new System.Drawing.Point(279, 12);
            this.PrintBox.Name = "PrintBox";
            this.PrintBox.Size = new System.Drawing.Size(110, 59);
            this.PrintBox.TabIndex = 10;
            this.PrintBox.TabStop = false;
            this.PrintBox.Click += new System.EventHandler(this.PrintBox_Click);
            this.PrintBox.MouseHover += new System.EventHandler(this.PrintBox_MouseHover);
            // 
            // ClearBox
            // 
            this.ClearBox.Image = global::EduDBGUI.Properties.Resources.Eraser_icon;
            this.ClearBox.Location = new System.Drawing.Point(408, 12);
            this.ClearBox.Name = "ClearBox";
            this.ClearBox.Size = new System.Drawing.Size(110, 59);
            this.ClearBox.TabIndex = 12;
            this.ClearBox.TabStop = false;
            this.ClearBox.Click += new System.EventHandler(this.ClearBox_Click);
            this.ClearBox.MouseHover += new System.EventHandler(this.ClearBox_MouseHover);
            // 
            // BtnSubmitQueryBox
            // 
            this.BtnSubmitQueryBox.Image = global::EduDBGUI.Properties.Resources.Start_icon;
            this.BtnSubmitQueryBox.Location = new System.Drawing.Point(30, 12);
            this.BtnSubmitQueryBox.Name = "BtnSubmitQueryBox";
            this.BtnSubmitQueryBox.Size = new System.Drawing.Size(110, 59);
            this.BtnSubmitQueryBox.TabIndex = 13;
            this.BtnSubmitQueryBox.TabStop = false;
            this.BtnSubmitQueryBox.Click += new System.EventHandler(this.BtnSubmitQueryBox_Click);
            this.BtnSubmitQueryBox.MouseHover += new System.EventHandler(this.BtnSubmitQueryBox_MouseHover);
            // 
            // SaveResult
            // 
            this.SaveResult.Image = global::EduDBGUI.Properties.Resources.File_CSV_icon;
            this.SaveResult.Location = new System.Drawing.Point(537, 12);
            this.SaveResult.Name = "SaveResult";
            this.SaveResult.Size = new System.Drawing.Size(110, 59);
            this.SaveResult.TabIndex = 15;
            this.SaveResult.TabStop = false;
            this.SaveResult.Click += new System.EventHandler(this.SaveResult_Click);
            this.SaveResult.MouseHover += new System.EventHandler(this.SaveResult_MouseHover);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 615);
            this.Controls.Add(this.SaveResult);
            this.Controls.Add(this.BtnSubmitQueryBox);
            this.Controls.Add(this.ClearBox);
            this.Controls.Add(this.SaveBox);
            this.Controls.Add(this.PrintBox);
            this.Controls.Add(this.ResultSummary);
            this.Controls.Add(this.TxtResults);
            this.Controls.Add(this.TxtQuery);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.Text = "DB338 0.02 Alpha";
            ((System.ComponentModel.ISupportInitialize)(this.SaveBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClearBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSubmitQueryBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtQuery;
        private System.Windows.Forms.TextBox TxtResults;
        private System.Windows.Forms.TextBox ResultSummary;
        private PictureBox PrintBox;
        private PictureBox SaveBox;
        private PictureBox ClearBox;
        private PictureBox BtnSubmitQueryBox;
        private PictureBox SaveResult;
    }
}

