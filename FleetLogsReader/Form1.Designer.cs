namespace FleetLogsReader
{
    partial class Form1
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
            this.btnCopyLogFiles = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.AddToDBBTN = new System.Windows.Forms.Button();
            this.btnDeleteLogfiles = new System.Windows.Forms.Button();
            this.btnMoveRar = new System.Windows.Forms.Button();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetUniq = new System.Windows.Forms.Button();
            this.dgGrid = new System.Windows.Forms.DataGridView();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnLoginLength = new System.Windows.Forms.Button();
            this.txSearchMessage = new System.Windows.Forms.TextBox();
            this.btnSearchMsg = new System.Windows.Forms.Button();
            this.cbLogType = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSiteId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAccountId = new System.Windows.Forms.TextBox();
            this.cbSort = new System.Windows.Forms.ComboBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.dtStartSession = new System.Windows.Forms.DateTimePicker();
            this.dtEndSession = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRunSession = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCopyLogFiles
            // 
            this.btnCopyLogFiles.Location = new System.Drawing.Point(12, 12);
            this.btnCopyLogFiles.Name = "btnCopyLogFiles";
            this.btnCopyLogFiles.Size = new System.Drawing.Size(126, 23);
            this.btnCopyLogFiles.TabIndex = 0;
            this.btnCopyLogFiles.Text = "Copy Log Files";
            this.btnCopyLogFiles.UseVisualStyleBackColor = true;
            this.btnCopyLogFiles.Click += new System.EventHandler(this.btnCopyFiles_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.Location = new System.Drawing.Point(12, 41);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(126, 23);
            this.btnArchive.TabIndex = 1;
            this.btnArchive.Text = "Archive Log Files";
            this.btnArchive.UseVisualStyleBackColor = true;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // AddToDBBTN
            // 
            this.AddToDBBTN.Location = new System.Drawing.Point(13, 71);
            this.AddToDBBTN.Name = "AddToDBBTN";
            this.AddToDBBTN.Size = new System.Drawing.Size(125, 23);
            this.AddToDBBTN.TabIndex = 2;
            this.AddToDBBTN.Text = "AddToDB";
            this.AddToDBBTN.UseVisualStyleBackColor = true;
            this.AddToDBBTN.Click += new System.EventHandler(this.AddToDBBTN_Click);
            // 
            // btnDeleteLogfiles
            // 
            this.btnDeleteLogfiles.Location = new System.Drawing.Point(13, 101);
            this.btnDeleteLogfiles.Name = "btnDeleteLogfiles";
            this.btnDeleteLogfiles.Size = new System.Drawing.Size(125, 23);
            this.btnDeleteLogfiles.TabIndex = 3;
            this.btnDeleteLogfiles.Text = "DeleteLogfiles";
            this.btnDeleteLogfiles.UseVisualStyleBackColor = true;
            this.btnDeleteLogfiles.Click += new System.EventHandler(this.btnDeleteLogfiles_Click);
            // 
            // btnMoveRar
            // 
            this.btnMoveRar.Location = new System.Drawing.Point(13, 131);
            this.btnMoveRar.Name = "btnMoveRar";
            this.btnMoveRar.Size = new System.Drawing.Size(125, 23);
            this.btnMoveRar.TabIndex = 4;
            this.btnMoveRar.Text = "MoveRarToSite";
            this.btnMoveRar.UseVisualStyleBackColor = true;
            this.btnMoveRar.Click += new System.EventHandler(this.btnMoveRar_Click);
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(261, 40);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 20);
            this.dtStart.TabIndex = 5;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(503, 40);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(200, 20);
            this.dtEnd.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "End Date";
            // 
            // btnGetUniq
            // 
            this.btnGetUniq.Location = new System.Drawing.Point(730, 36);
            this.btnGetUniq.Name = "btnGetUniq";
            this.btnGetUniq.Size = new System.Drawing.Size(75, 23);
            this.btnGetUniq.TabIndex = 9;
            this.btnGetUniq.Text = "RUN Uniq";
            this.btnGetUniq.UseVisualStyleBackColor = true;
            this.btnGetUniq.Click += new System.EventHandler(this.btnGetUniq_Click);
            // 
            // dgGrid
            // 
            this.dgGrid.AllowUserToAddRows = false;
            this.dgGrid.AllowUserToDeleteRows = false;
            this.dgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGrid.Location = new System.Drawing.Point(180, 168);
            this.dgGrid.Name = "dgGrid";
            this.dgGrid.Size = new System.Drawing.Size(1057, 749);
            this.dgGrid.TabIndex = 10;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(258, 152);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 13);
            this.lblResult.TabIndex = 12;
            // 
            // btnLoginLength
            // 
            this.btnLoginLength.Location = new System.Drawing.Point(822, 36);
            this.btnLoginLength.Name = "btnLoginLength";
            this.btnLoginLength.Size = new System.Drawing.Size(93, 23);
            this.btnLoginLength.TabIndex = 13;
            this.btnLoginLength.Text = "Login Length";
            this.btnLoginLength.UseVisualStyleBackColor = true;
            this.btnLoginLength.Click += new System.EventHandler(this.btnLoginLength_Click);
            // 
            // txSearchMessage
            // 
            this.txSearchMessage.Location = new System.Drawing.Point(947, 40);
            this.txSearchMessage.Name = "txSearchMessage";
            this.txSearchMessage.Size = new System.Drawing.Size(100, 20);
            this.txSearchMessage.TabIndex = 14;
            // 
            // btnSearchMsg
            // 
            this.btnSearchMsg.Location = new System.Drawing.Point(1063, 36);
            this.btnSearchMsg.Name = "btnSearchMsg";
            this.btnSearchMsg.Size = new System.Drawing.Size(112, 23);
            this.btnSearchMsg.TabIndex = 15;
            this.btnSearchMsg.Text = "Search Message";
            this.btnSearchMsg.UseVisualStyleBackColor = true;
            this.btnSearchMsg.Click += new System.EventHandler(this.btnSearchMsg_Click);
            // 
            // cbLogType
            // 
            this.cbLogType.FormattingEnabled = true;
            this.cbLogType.Items.AddRange(new object[] {
            "Warn",
            "Trace",
            "DBTrace",
            "JSError",
            "Fatal",
            "Error"});
            this.cbLogType.Location = new System.Drawing.Point(261, 88);
            this.cbLogType.Name = "cbLogType";
            this.cbLogType.Size = new System.Drawing.Size(121, 21);
            this.cbLogType.TabIndex = 16;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(642, 85);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Log Type";
            // 
            // txtSiteId
            // 
            this.txtSiteId.Location = new System.Drawing.Point(408, 88);
            this.txtSiteId.Name = "txtSiteId";
            this.txtSiteId.Size = new System.Drawing.Size(100, 20);
            this.txtSiteId.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(409, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "SiteId";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(525, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "AccountId";
            // 
            // txtAccountId
            // 
            this.txtAccountId.Location = new System.Drawing.Point(524, 88);
            this.txtAccountId.Name = "txtAccountId";
            this.txtAccountId.Size = new System.Drawing.Size(100, 20);
            this.txtAccountId.TabIndex = 19;
            // 
            // cbSort
            // 
            this.cbSort.FormattingEnabled = true;
            this.cbSort.Items.AddRange(new object[] {
            "InsertDate",
            "Trace",
            "Message"});
            this.cbSort.Location = new System.Drawing.Point(261, 115);
            this.cbSort.Name = "cbSort";
            this.cbSort.Size = new System.Drawing.Size(121, 21);
            this.cbSort.TabIndex = 16;
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(408, 113);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(75, 23);
            this.btnSort.TabIndex = 17;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // dtStartSession
            // 
            this.dtStartSession.Location = new System.Drawing.Point(779, 138);
            this.dtStartSession.Name = "dtStartSession";
            this.dtStartSession.Size = new System.Drawing.Size(200, 20);
            this.dtStartSession.TabIndex = 5;
            // 
            // dtEndSession
            // 
            this.dtEndSession.Location = new System.Drawing.Point(1021, 138);
            this.dtEndSession.Name = "dtEndSession";
            this.dtEndSession.Size = new System.Drawing.Size(200, 20);
            this.dtEndSession.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(776, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Start Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1021, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "End Date";
            // 
            // btnRunSession
            // 
            this.btnRunSession.Location = new System.Drawing.Point(1247, 138);
            this.btnRunSession.Name = "btnRunSession";
            this.btnRunSession.Size = new System.Drawing.Size(75, 23);
            this.btnRunSession.TabIndex = 20;
            this.btnRunSession.Text = "Run";
            this.btnRunSession.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1431, 978);
            this.Controls.Add(this.btnRunSession);
            this.Controls.Add(this.txtAccountId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSiteId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbSort);
            this.Controls.Add(this.cbLogType);
            this.Controls.Add(this.btnSearchMsg);
            this.Controls.Add(this.txSearchMessage);
            this.Controls.Add(this.btnLoginLength);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.dgGrid);
            this.Controls.Add(this.btnGetUniq);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtEndSession);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtStartSession);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.btnMoveRar);
            this.Controls.Add(this.btnDeleteLogfiles);
            this.Controls.Add(this.AddToDBBTN);
            this.Controls.Add(this.btnArchive);
            this.Controls.Add(this.btnCopyLogFiles);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCopyLogFiles;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.Button AddToDBBTN;
        private System.Windows.Forms.Button btnDeleteLogfiles;
        private System.Windows.Forms.Button btnMoveRar;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetUniq;
        private System.Windows.Forms.DataGridView dgGrid;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnLoginLength;
        private System.Windows.Forms.TextBox txSearchMessage;
        private System.Windows.Forms.Button btnSearchMsg;
        private System.Windows.Forms.ComboBox cbLogType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSiteId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAccountId;
        private System.Windows.Forms.ComboBox cbSort;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.DateTimePicker dtStartSession;
        private System.Windows.Forms.DateTimePicker dtEndSession;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRunSession;
    }
}

