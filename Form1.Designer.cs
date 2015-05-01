namespace WindowsFormsApplication1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Log = new System.Windows.Forms.ListBox();
            this.Czat = new System.Windows.Forms.ListBox();
            this.wyslij = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.transparentMessagePanel1 = new WindowsFormsApplication1.TransparentMessagePanel();
            this.SuspendLayout();
            // 
            // Log
            // 
            this.Log.Cursor = System.Windows.Forms.Cursors.Default;
            this.Log.FormattingEnabled = true;
            this.Log.Location = new System.Drawing.Point(410, 12);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(253, 147);
            this.Log.TabIndex = 10;
            // 
            // Czat
            // 
            this.Czat.FormattingEnabled = true;
            this.Czat.Location = new System.Drawing.Point(410, 180);
            this.Czat.Name = "Czat";
            this.Czat.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.Czat.Size = new System.Drawing.Size(253, 173);
            this.Czat.TabIndex = 11;
            // 
            // wyslij
            // 
            this.wyslij.Location = new System.Drawing.Point(590, 359);
            this.wyslij.Name = "wyslij";
            this.wyslij.Size = new System.Drawing.Size(73, 27);
            this.wyslij.TabIndex = 12;
            this.wyslij.Text = "Wyślij";
            this.wyslij.UseVisualStyleBackColor = true;
            this.wyslij.Click += new System.EventHandler(this.wyslij_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(412, 362);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(167, 20);
            this.textBox1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Log";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Czat";
            // 
            // transparentMessagePanel1
            // 
            this.transparentMessagePanel1.Location = new System.Drawing.Point(0, 2);
            this.transparentMessagePanel1.Name = "transparentMessagePanel1";
            this.transparentMessagePanel1.Size = new System.Drawing.Size(400, 400);
            this.transparentMessagePanel1.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1073, 408);
            this.Controls.Add(this.transparentMessagePanel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.wyslij);
            this.Controls.Add(this.Czat);
            this.Controls.Add(this.Log);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Log;
        private System.Windows.Forms.ListBox Czat;
        private System.Windows.Forms.Button wyslij;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private TransparentMessagePanel transparentMessagePanel1;
    }
}

