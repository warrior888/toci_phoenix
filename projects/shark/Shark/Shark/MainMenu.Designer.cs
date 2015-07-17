namespace Shark
{
    partial class MainMenu
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
            this.newClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newClient
            // 
            this.newClient.Location = new System.Drawing.Point(21, 23);
            this.newClient.Name = "newClient";
            this.newClient.Size = new System.Drawing.Size(75, 23);
            this.newClient.TabIndex = 0;
            this.newClient.Text = "Nowy klient";
            this.newClient.UseVisualStyleBackColor = true;
            this.newClient.Click += new System.EventHandler(this.newClient_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 442);
            this.Controls.Add(this.newClient);
            this.Name = "MainMenu";
            this.Text = "Shark";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newClient;
    }
}

