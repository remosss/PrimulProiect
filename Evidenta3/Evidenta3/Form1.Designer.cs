namespace Evidenta3
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
            this.remossButton = new System.Windows.Forms.Button();
            this.rmsroadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // remossButton
            // 
            this.remossButton.BackColor = System.Drawing.SystemColors.Info;
            this.remossButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remossButton.Location = new System.Drawing.Point(136, 145);
            this.remossButton.Name = "remossButton";
            this.remossButton.Size = new System.Drawing.Size(222, 114);
            this.remossButton.TabIndex = 0;
            this.remossButton.Text = "Remoss";
            this.remossButton.UseVisualStyleBackColor = false;
            this.remossButton.Click += new System.EventHandler(this.remossButton_Click);
            // 
            // rmsroadButton
            // 
            this.rmsroadButton.BackColor = System.Drawing.SystemColors.Info;
            this.rmsroadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rmsroadButton.Location = new System.Drawing.Point(406, 145);
            this.rmsroadButton.Name = "rmsroadButton";
            this.rmsroadButton.Size = new System.Drawing.Size(222, 114);
            this.rmsroadButton.TabIndex = 1;
            this.rmsroadButton.Text = "RMS Road";
            this.rmsroadButton.UseVisualStyleBackColor = false;
            this.rmsroadButton.Click += new System.EventHandler(this.rmsroadButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rmsroadButton);
            this.Controls.Add(this.remossButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button remossButton;
        private System.Windows.Forms.Button rmsroadButton;
    }
}

