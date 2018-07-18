namespace OrBrApDs
{
    partial class FrmAppDs
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
            this.lblLink = new System.Windows.Forms.Label();
            this.linkLbl = new System.Windows.Forms.LinkLabel();
            this.txbEnter = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnEnter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Location = new System.Drawing.Point(29, 9);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(30, 13);
            this.lblLink.TabIndex = 0;
            this.lblLink.Text = "Link:";
            // 
            // linkLbl
            // 
            this.linkLbl.AutoSize = true;
            this.linkLbl.Location = new System.Drawing.Point(77, 9);
            this.linkLbl.Name = "linkLbl";
            this.linkLbl.Size = new System.Drawing.Size(55, 13);
            this.linkLbl.TabIndex = 1;
            this.linkLbl.TabStop = true;
            this.linkLbl.Text = "linkLabel1";
            // 
            // txbEnter
            // 
            this.txbEnter.Location = new System.Drawing.Point(32, 35);
            this.txbEnter.Name = "txbEnter";
            this.txbEnter.Size = new System.Drawing.Size(164, 20);
            this.txbEnter.TabIndex = 2;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(32, 67);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(32, 242);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(226, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(32, 274);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(237, 163);
            this.webBrowser1.TabIndex = 5;
            this.webBrowser1.Url = new System.Uri("http://localhost:49368/Index.aspx", System.UriKind.Absolute);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(210, 9);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(49, 20);
            this.BtnClose.TabIndex = 6;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnEnter
            // 
            this.BtnEnter.Location = new System.Drawing.Point(210, 35);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(48, 23);
            this.BtnEnter.TabIndex = 7;
            this.BtnEnter.Text = "Enter";
            this.BtnEnter.UseVisualStyleBackColor = true;
            this.BtnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // FrmAppDs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 449);
            this.Controls.Add(this.BtnEnter);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.txbEnter);
            this.Controls.Add(this.linkLbl);
            this.Controls.Add(this.lblLink);
            this.Name = "FrmAppDs";
            this.Text = "AppDs";
            this.Load += new System.EventHandler(this.FrmAppDs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLink;
        private System.Windows.Forms.LinkLabel linkLbl;
        private System.Windows.Forms.TextBox txbEnter;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnEnter;
    }
}

