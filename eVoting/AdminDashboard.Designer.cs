namespace eVoting
{
    partial class AdminDashboard
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.postionAndCandidates = new System.Windows.Forms.TabPage();
            this.dgvCandidates = new System.Windows.Forms.DataGridView();
            this.newCandidate = new System.Windows.Forms.GroupBox();
            this.btnDashClear = new System.Windows.Forms.Button();
            this.btnAddCandidate = new System.Windows.Forms.Button();
            this.btnUploadImg = new System.Windows.Forms.Button();
            this.candidatePic = new System.Windows.Forms.PictureBox();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProgramme = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCandidateId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.newPositon = new System.Windows.Forms.GroupBox();
            this.btnAddPosition = new System.Windows.Forms.Button();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.TabPage();
            this.resultsPanel = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.postionAndCandidates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandidates)).BeginInit();
            this.newCandidate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.candidatePic)).BeginInit();
            this.newPositon.SuspendLayout();
            this.result.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.postionAndCandidates);
            this.tabControl1.Controls.Add(this.result);
            this.tabControl1.Font = new System.Drawing.Font("Castellar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(517, 452);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            // 
            // postionAndCandidates
            // 
            this.postionAndCandidates.Controls.Add(this.dgvCandidates);
            this.postionAndCandidates.Controls.Add(this.newCandidate);
            this.postionAndCandidates.Controls.Add(this.newPositon);
            this.postionAndCandidates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postionAndCandidates.Location = new System.Drawing.Point(4, 28);
            this.postionAndCandidates.Name = "postionAndCandidates";
            this.postionAndCandidates.Padding = new System.Windows.Forms.Padding(3);
            this.postionAndCandidates.Size = new System.Drawing.Size(509, 420);
            this.postionAndCandidates.TabIndex = 0;
            this.postionAndCandidates.Text = "Position and Candidates";
            this.postionAndCandidates.UseVisualStyleBackColor = true;
            // 
            // dgvCandidates
            // 
            this.dgvCandidates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCandidates.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCandidates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCandidates.Location = new System.Drawing.Point(3, 168);
            this.dgvCandidates.Name = "dgvCandidates";
            this.dgvCandidates.RowHeadersVisible = false;
            this.dgvCandidates.Size = new System.Drawing.Size(217, 241);
            this.dgvCandidates.TabIndex = 2;
            // 
            // newCandidate
            // 
            this.newCandidate.Controls.Add(this.btnDashClear);
            this.newCandidate.Controls.Add(this.btnAddCandidate);
            this.newCandidate.Controls.Add(this.btnUploadImg);
            this.newCandidate.Controls.Add(this.candidatePic);
            this.newCandidate.Controls.Add(this.cmbPosition);
            this.newCandidate.Controls.Add(this.label5);
            this.newCandidate.Controls.Add(this.txtProgramme);
            this.newCandidate.Controls.Add(this.label4);
            this.newCandidate.Controls.Add(this.txtFullName);
            this.newCandidate.Controls.Add(this.label3);
            this.newCandidate.Controls.Add(this.txtCandidateId);
            this.newCandidate.Controls.Add(this.label2);
            this.newCandidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newCandidate.Location = new System.Drawing.Point(226, 6);
            this.newCandidate.Name = "newCandidate";
            this.newCandidate.Size = new System.Drawing.Size(277, 403);
            this.newCandidate.TabIndex = 1;
            this.newCandidate.TabStop = false;
            this.newCandidate.Text = "Add Candidate";
            // 
            // btnDashClear
            // 
            this.btnDashClear.BackColor = System.Drawing.Color.Gray;
            this.btnDashClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashClear.ForeColor = System.Drawing.Color.White;
            this.btnDashClear.Location = new System.Drawing.Point(149, 360);
            this.btnDashClear.Name = "btnDashClear";
            this.btnDashClear.Size = new System.Drawing.Size(99, 28);
            this.btnDashClear.TabIndex = 13;
            this.btnDashClear.Text = "Clear";
            this.btnDashClear.UseVisualStyleBackColor = false;
            this.btnDashClear.Click += new System.EventHandler(this.btnDashClear_Click);
            // 
            // btnAddCandidate
            // 
            this.btnAddCandidate.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAddCandidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCandidate.ForeColor = System.Drawing.Color.White;
            this.btnAddCandidate.Location = new System.Drawing.Point(16, 360);
            this.btnAddCandidate.Name = "btnAddCandidate";
            this.btnAddCandidate.Size = new System.Drawing.Size(99, 28);
            this.btnAddCandidate.TabIndex = 3;
            this.btnAddCandidate.Text = "Add";
            this.btnAddCandidate.UseVisualStyleBackColor = false;
            this.btnAddCandidate.Click += new System.EventHandler(this.btnAddCandidate_Click);
            // 
            // btnUploadImg
            // 
            this.btnUploadImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadImg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUploadImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadImg.Location = new System.Drawing.Point(184, 89);
            this.btnUploadImg.Name = "btnUploadImg";
            this.btnUploadImg.Size = new System.Drawing.Size(87, 25);
            this.btnUploadImg.TabIndex = 12;
            this.btnUploadImg.Text = "Upload Image";
            this.btnUploadImg.UseVisualStyleBackColor = true;
            this.btnUploadImg.Click += new System.EventHandler(this.btnUploadImg_Click);
            // 
            // candidatePic
            // 
            this.candidatePic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.candidatePic.Location = new System.Drawing.Point(184, 13);
            this.candidatePic.Name = "candidatePic";
            this.candidatePic.Size = new System.Drawing.Size(87, 70);
            this.candidatePic.TabIndex = 11;
            this.candidatePic.TabStop = false;
            // 
            // cmbPosition
            // 
            this.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(16, 318);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(232, 28);
            this.cmbPosition.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Position";
            // 
            // txtProgramme
            // 
            this.txtProgramme.Location = new System.Drawing.Point(16, 260);
            this.txtProgramme.Name = "txtProgramme";
            this.txtProgramme.Size = new System.Drawing.Size(232, 26);
            this.txtProgramme.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Programme";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(16, 204);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(232, 26);
            this.txtFullName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Full Name";
            // 
            // txtCandidateId
            // 
            this.txtCandidateId.Location = new System.Drawing.Point(16, 147);
            this.txtCandidateId.Name = "txtCandidateId";
            this.txtCandidateId.Size = new System.Drawing.Size(232, 26);
            this.txtCandidateId.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Candidate ID";
            // 
            // newPositon
            // 
            this.newPositon.Controls.Add(this.btnAddPosition);
            this.newPositon.Controls.Add(this.txtPosition);
            this.newPositon.Controls.Add(this.label1);
            this.newPositon.Location = new System.Drawing.Point(7, 6);
            this.newPositon.Name = "newPositon";
            this.newPositon.Size = new System.Drawing.Size(200, 135);
            this.newPositon.TabIndex = 0;
            this.newPositon.TabStop = false;
            this.newPositon.Text = "New Positon";
            // 
            // btnAddPosition
            // 
            this.btnAddPosition.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAddPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPosition.ForeColor = System.Drawing.Color.White;
            this.btnAddPosition.Location = new System.Drawing.Point(11, 93);
            this.btnAddPosition.Name = "btnAddPosition";
            this.btnAddPosition.Size = new System.Drawing.Size(183, 28);
            this.btnAddPosition.TabIndex = 2;
            this.btnAddPosition.Text = "Add";
            this.btnAddPosition.UseVisualStyleBackColor = false;
            this.btnAddPosition.Click += new System.EventHandler(this.btnAddPosition_Click);
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(11, 61);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(183, 26);
            this.txtPosition.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Position";
            // 
            // result
            // 
            this.result.Controls.Add(this.resultsPanel);
            this.result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result.Location = new System.Drawing.Point(4, 28);
            this.result.Name = "result";
            this.result.Padding = new System.Windows.Forms.Padding(3);
            this.result.Size = new System.Drawing.Size(509, 420);
            this.result.TabIndex = 1;
            this.result.Text = "Results";
            this.result.UseVisualStyleBackColor = true;
            // 
            // resultsPanel
            // 
            this.resultsPanel.AutoScroll = true;
            this.resultsPanel.Location = new System.Drawing.Point(-4, 0);
            this.resultsPanel.Name = "resultsPanel";
            this.resultsPanel.Size = new System.Drawing.Size(513, 417);
            this.resultsPanel.TabIndex = 0;
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 452);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminDashboard";
            this.Text = "Admin Dashboard";
            this.Load += new System.EventHandler(this.AdminDashboard_Load);
            this.tabControl1.ResumeLayout(false);
            this.postionAndCandidates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandidates)).EndInit();
            this.newCandidate.ResumeLayout(false);
            this.newCandidate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.candidatePic)).EndInit();
            this.newPositon.ResumeLayout(false);
            this.newPositon.PerformLayout();
            this.result.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage postionAndCandidates;
        private System.Windows.Forms.GroupBox newCandidate;
        private System.Windows.Forms.GroupBox newPositon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddPosition;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProgramme;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCandidateId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox candidatePic;
        private System.Windows.Forms.Button btnUploadImg;
        private System.Windows.Forms.DataGridView dgvCandidates;
        private System.Windows.Forms.Button btnAddCandidate;
        private System.Windows.Forms.Button btnDashClear;
        private System.Windows.Forms.TabPage result;
        private System.Windows.Forms.Panel resultsPanel;
    }
}