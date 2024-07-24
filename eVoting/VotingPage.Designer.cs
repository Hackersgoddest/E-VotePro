namespace eVoting
{
    partial class VotingPage
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
            this.votingPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // votingPanel
            // 
            this.votingPanel.AutoScroll = true;
            this.votingPanel.Location = new System.Drawing.Point(-2, 0);
            this.votingPanel.Name = "votingPanel";
            this.votingPanel.Size = new System.Drawing.Size(515, 452);
            this.votingPanel.TabIndex = 0;
            this.votingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.votingPanel_Paint);
            // 
            // VotingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 451);
            this.Controls.Add(this.votingPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VotingPage";
            this.Text = "Voting Page";
            this.Load += new System.EventHandler(this.VotingPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel votingPanel;
    }
}