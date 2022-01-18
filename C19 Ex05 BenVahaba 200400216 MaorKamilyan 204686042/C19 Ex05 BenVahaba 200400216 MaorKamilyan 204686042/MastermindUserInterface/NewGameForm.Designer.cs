namespace MastermindUserInterface
{
    partial class NewGameForm
    {
        private System.Windows.Forms.Button i_NumberOfChancesBotton;
        private System.Windows.Forms.Button startButton;
        private System.ComponentModel.IContainer components = null;
        
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
            this.i_NumberOfChancesBotton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // i_NumberOfChancesBotton
            // 
            this.i_NumberOfChancesBotton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.i_NumberOfChancesBotton.Location = new System.Drawing.Point(15, 28);
            this.i_NumberOfChancesBotton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.i_NumberOfChancesBotton.Name = "i_NumberOfChancesBotton";
            this.i_NumberOfChancesBotton.Size = new System.Drawing.Size(303, 30);
            this.i_NumberOfChancesBotton.TabIndex = 1;
            this.i_NumberOfChancesBotton.UseVisualStyleBackColor = false;
            this.i_NumberOfChancesBotton.Click += new System.EventHandler(this.I_NumberOfChancesBotton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(217, 81);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(100, 39);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // NewGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 134);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.i_NumberOfChancesBotton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bool Pgia";
            this.Load += new System.EventHandler(this.NewGameForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}