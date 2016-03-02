namespace Simon
{
    partial class playScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.greenButton = new System.Windows.Forms.Button();
            this.redButton = new System.Windows.Forms.Button();
            this.blueButton = new System.Windows.Forms.Button();
            this.yellowButton = new System.Windows.Forms.Button();
            this.cheaterLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // greenButton
            // 
            this.greenButton.BackColor = System.Drawing.Color.Transparent;
            this.greenButton.Location = new System.Drawing.Point(100, 100);
            this.greenButton.Name = "greenButton";
            this.greenButton.Size = new System.Drawing.Size(100, 100);
            this.greenButton.TabIndex = 0;
            this.greenButton.UseVisualStyleBackColor = false;
            this.greenButton.Click += new System.EventHandler(this.button_Press);
            // 
            // redButton
            // 
            this.redButton.BackColor = System.Drawing.Color.Transparent;
            this.redButton.Location = new System.Drawing.Point(210, 100);
            this.redButton.Name = "redButton";
            this.redButton.Size = new System.Drawing.Size(100, 100);
            this.redButton.TabIndex = 1;
            this.redButton.UseVisualStyleBackColor = false;
            this.redButton.Click += new System.EventHandler(this.button_Press);
            // 
            // blueButton
            // 
            this.blueButton.BackColor = System.Drawing.Color.Transparent;
            this.blueButton.Location = new System.Drawing.Point(100, 210);
            this.blueButton.Name = "blueButton";
            this.blueButton.Size = new System.Drawing.Size(100, 100);
            this.blueButton.TabIndex = 2;
            this.blueButton.UseVisualStyleBackColor = false;
            this.blueButton.Click += new System.EventHandler(this.button_Press);
            // 
            // yellowButton
            // 
            this.yellowButton.BackColor = System.Drawing.Color.Transparent;
            this.yellowButton.Location = new System.Drawing.Point(210, 210);
            this.yellowButton.Name = "yellowButton";
            this.yellowButton.Size = new System.Drawing.Size(100, 100);
            this.yellowButton.TabIndex = 3;
            this.yellowButton.UseVisualStyleBackColor = false;
            this.yellowButton.Click += new System.EventHandler(this.button_Press);
            // 
            // cheaterLabel
            // 
            this.cheaterLabel.AutoSize = true;
            this.cheaterLabel.BackColor = System.Drawing.Color.Black;
            this.cheaterLabel.Font = new System.Drawing.Font("Miriam", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cheaterLabel.ForeColor = System.Drawing.Color.Snow;
            this.cheaterLabel.Location = new System.Drawing.Point(100, 65);
            this.cheaterLabel.Name = "cheaterLabel";
            this.cheaterLabel.Size = new System.Drawing.Size(0, 20);
            this.cheaterLabel.TabIndex = 4;
            // 
            // playScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.cheaterLabel);
            this.Controls.Add(this.yellowButton);
            this.Controls.Add(this.blueButton);
            this.Controls.Add(this.redButton);
            this.Controls.Add(this.greenButton);
            this.Name = "playScreen";
            this.Size = new System.Drawing.Size(450, 450);
            this.Load += new System.EventHandler(this.playScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button greenButton;
        private System.Windows.Forms.Button redButton;
        private System.Windows.Forms.Button blueButton;
        private System.Windows.Forms.Button yellowButton;
        private System.Windows.Forms.Label cheaterLabel;
    }
}
