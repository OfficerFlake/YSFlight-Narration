namespace YSF_Narrator
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
            this.label_Demonstration = new System.Windows.Forms.Label();
            this.label_Manoeuvre = new System.Windows.Forms.Label();
            this.label_Pilots = new System.Windows.Forms.Label();
            this.textBox_Pilots = new System.Windows.Forms.TextBox();
            this.richTextBox_Narration = new System.Windows.Forms.RichTextBox();
            this.button_Next = new System.Windows.Forms.Button();
            this.button_Previous = new System.Windows.Forms.Button();
            this.comboBox_Demonstration = new System.Windows.Forms.ComboBox();
            this.comboBox_Manoeuvre = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label_Demonstration
            // 
            this.label_Demonstration.AutoSize = true;
            this.label_Demonstration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Demonstration.Location = new System.Drawing.Point(13, 13);
            this.label_Demonstration.Name = "label_Demonstration";
            this.label_Demonstration.Size = new System.Drawing.Size(92, 13);
            this.label_Demonstration.TabIndex = 0;
            this.label_Demonstration.Text = "Demonstration:";
            // 
            // label_Manoeuvre
            // 
            this.label_Manoeuvre.AutoSize = true;
            this.label_Manoeuvre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Manoeuvre.Location = new System.Drawing.Point(313, 13);
            this.label_Manoeuvre.Name = "label_Manoeuvre";
            this.label_Manoeuvre.Size = new System.Drawing.Size(74, 13);
            this.label_Manoeuvre.TabIndex = 2;
            this.label_Manoeuvre.Text = "Manoeuvre:";
            // 
            // label_Pilots
            // 
            this.label_Pilots.AutoSize = true;
            this.label_Pilots.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Pilots.Location = new System.Drawing.Point(592, 13);
            this.label_Pilots.Name = "label_Pilots";
            this.label_Pilots.Size = new System.Drawing.Size(95, 13);
            this.label_Pilots.TabIndex = 4;
            this.label_Pilots.Text = "Pilots Involved:";
            // 
            // textBox_Pilots
            // 
            this.textBox_Pilots.Location = new System.Drawing.Point(693, 10);
            this.textBox_Pilots.Name = "textBox_Pilots";
            this.textBox_Pilots.Size = new System.Drawing.Size(200, 20);
            this.textBox_Pilots.TabIndex = 5;
            // 
            // richTextBox_Narration
            // 
            this.richTextBox_Narration.Location = new System.Drawing.Point(12, 36);
            this.richTextBox_Narration.Name = "richTextBox_Narration";
            this.richTextBox_Narration.Size = new System.Drawing.Size(882, 435);
            this.richTextBox_Narration.TabIndex = 6;
            this.richTextBox_Narration.Text = "";
            // 
            // button_Next
            // 
            this.button_Next.Location = new System.Drawing.Point(493, 477);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(400, 23);
            this.button_Next.TabIndex = 7;
            this.button_Next.Text = "Next";
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.goNext);
            // 
            // button_Previous
            // 
            this.button_Previous.Location = new System.Drawing.Point(16, 478);
            this.button_Previous.Name = "button_Previous";
            this.button_Previous.Size = new System.Drawing.Size(400, 23);
            this.button_Previous.TabIndex = 8;
            this.button_Previous.Text = "Previous";
            this.button_Previous.UseVisualStyleBackColor = true;
            this.button_Previous.Click += new System.EventHandler(this.goPrevious);
            // 
            // comboBox_Demonstration
            // 
            this.comboBox_Demonstration.FormattingEnabled = true;
            this.comboBox_Demonstration.Location = new System.Drawing.Point(111, 10);
            this.comboBox_Demonstration.Name = "comboBox_Demonstration";
            this.comboBox_Demonstration.Size = new System.Drawing.Size(200, 21);
            this.comboBox_Demonstration.TabIndex = 9;
            this.comboBox_Demonstration.SelectedIndexChanged += new System.EventHandler(this.ChangeDemonstration);
            // 
            // comboBox_Manoeuvre
            // 
            this.comboBox_Manoeuvre.FormattingEnabled = true;
            this.comboBox_Manoeuvre.Location = new System.Drawing.Point(393, 10);
            this.comboBox_Manoeuvre.Name = "comboBox_Manoeuvre";
            this.comboBox_Manoeuvre.Size = new System.Drawing.Size(200, 21);
            this.comboBox_Manoeuvre.TabIndex = 10;
            this.comboBox_Manoeuvre.SelectedIndexChanged += new System.EventHandler(this.ChangeManoeuvre);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 522);
            this.Controls.Add(this.comboBox_Manoeuvre);
            this.Controls.Add(this.comboBox_Demonstration);
            this.Controls.Add(this.button_Previous);
            this.Controls.Add(this.button_Next);
            this.Controls.Add(this.richTextBox_Narration);
            this.Controls.Add(this.textBox_Pilots);
            this.Controls.Add(this.label_Pilots);
            this.Controls.Add(this.label_Manoeuvre);
            this.Controls.Add(this.label_Demonstration);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LoadFiles);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Demonstration;
        private System.Windows.Forms.Label label_Manoeuvre;
        private System.Windows.Forms.Label label_Pilots;
        private System.Windows.Forms.TextBox textBox_Pilots;
        private System.Windows.Forms.RichTextBox richTextBox_Narration;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.Button button_Previous;
        private System.Windows.Forms.ComboBox comboBox_Demonstration;
        private System.Windows.Forms.ComboBox comboBox_Manoeuvre;
    }
}

