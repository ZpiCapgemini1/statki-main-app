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
            this.lb_Log = new System.Windows.Forms.ListBox();
            this.lb_Czat = new System.Windows.Forms.ListBox();
            this.b_Wyslij = new System.Windows.Forms.Button();
            this.tb_Czat = new System.Windows.Forms.TextBox();
            this.label_Log = new System.Windows.Forms.Label();
            this.label_Czat = new System.Windows.Forms.Label();
            this.tb_NickGracza = new System.Windows.Forms.TextBox();
            this.b_Polacz = new System.Windows.Forms.Button();
            this.lb_ListaGraczy = new System.Windows.Forms.ListBox();
            this.b_Graj = new System.Windows.Forms.Button();
            this.label_Nick = new System.Windows.Forms.Label();
            this.label_Lista = new System.Windows.Forms.Label();
            this.label_Graj = new System.Windows.Forms.Label();
            this.pb_Tura = new System.Windows.Forms.PictureBox();
            this.label_Tura = new System.Windows.Forms.Label();
            this.TransparentPanel = new WindowsFormsApplication1.TransparentMessagePanel();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Tura)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Log
            // 
            this.lb_Log.Cursor = System.Windows.Forms.Cursors.Default;
            this.lb_Log.FormattingEnabled = true;
            this.lb_Log.Location = new System.Drawing.Point(410, 12);
            this.lb_Log.Name = "lb_Log";
            this.lb_Log.Size = new System.Drawing.Size(253, 108);
            this.lb_Log.TabIndex = 10;
            // 
            // lb_Czat
            // 
            this.lb_Czat.FormattingEnabled = true;
            this.lb_Czat.Location = new System.Drawing.Point(406, 145);
            this.lb_Czat.Name = "lb_Czat";
            this.lb_Czat.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lb_Czat.Size = new System.Drawing.Size(253, 173);
            this.lb_Czat.TabIndex = 11;
            this.lb_Czat.Visible = false;
            // 
            // b_Wyslij
            // 
            this.b_Wyslij.Location = new System.Drawing.Point(590, 324);
            this.b_Wyslij.Name = "b_Wyslij";
            this.b_Wyslij.Size = new System.Drawing.Size(73, 27);
            this.b_Wyslij.TabIndex = 12;
            this.b_Wyslij.Text = "Wyślij";
            this.b_Wyslij.UseVisualStyleBackColor = true;
            this.b_Wyslij.Visible = false;
            this.b_Wyslij.Click += new System.EventHandler(this.b_Wyslij_Click);
            // 
            // tb_Czat
            // 
            this.tb_Czat.Location = new System.Drawing.Point(413, 324);
            this.tb_Czat.Name = "tb_Czat";
            this.tb_Czat.Size = new System.Drawing.Size(167, 20);
            this.tb_Czat.TabIndex = 13;
            this.tb_Czat.Visible = false;
            // 
            // label_Log
            // 
            this.label_Log.AutoSize = true;
            this.label_Log.Location = new System.Drawing.Point(410, 1);
            this.label_Log.Name = "label_Log";
            this.label_Log.Size = new System.Drawing.Size(25, 13);
            this.label_Log.TabIndex = 14;
            this.label_Log.Text = "Log";
            // 
            // label_Czat
            // 
            this.label_Czat.AutoSize = true;
            this.label_Czat.Location = new System.Drawing.Point(410, 136);
            this.label_Czat.Name = "label_Czat";
            this.label_Czat.Size = new System.Drawing.Size(28, 13);
            this.label_Czat.TabIndex = 15;
            this.label_Czat.Text = "Czat";
            this.label_Czat.Visible = false;
            // 
            // tb_NickGracza
            // 
            this.tb_NickGracza.Location = new System.Drawing.Point(425, 186);
            this.tb_NickGracza.Name = "tb_NickGracza";
            this.tb_NickGracza.Size = new System.Drawing.Size(100, 20);
            this.tb_NickGracza.TabIndex = 17;
            // 
            // b_Polacz
            // 
            this.b_Polacz.Location = new System.Drawing.Point(531, 183);
            this.b_Polacz.Name = "b_Polacz";
            this.b_Polacz.Size = new System.Drawing.Size(75, 23);
            this.b_Polacz.TabIndex = 18;
            this.b_Polacz.Text = "Połącz";
            this.b_Polacz.UseVisualStyleBackColor = true;
            this.b_Polacz.Click += new System.EventHandler(this.b_Polacz_Click);
            // 
            // lb_ListaGraczy
            // 
            this.lb_ListaGraczy.FormattingEnabled = true;
            this.lb_ListaGraczy.Location = new System.Drawing.Point(425, 230);
            this.lb_ListaGraczy.Name = "lb_ListaGraczy";
            this.lb_ListaGraczy.Size = new System.Drawing.Size(183, 121);
            this.lb_ListaGraczy.TabIndex = 19;
            // 
            // b_Graj
            // 
            this.b_Graj.Location = new System.Drawing.Point(477, 368);
            this.b_Graj.Name = "b_Graj";
            this.b_Graj.Size = new System.Drawing.Size(75, 23);
            this.b_Graj.TabIndex = 20;
            this.b_Graj.Text = "Graj";
            this.b_Graj.UseVisualStyleBackColor = true;
            this.b_Graj.Visible = false;
            this.b_Graj.Click += new System.EventHandler(this.b_Graj_Click);
            // 
            // label_Nick
            // 
            this.label_Nick.AutoSize = true;
            this.label_Nick.Location = new System.Drawing.Point(432, 172);
            this.label_Nick.Name = "label_Nick";
            this.label_Nick.Size = new System.Drawing.Size(83, 13);
            this.label_Nick.TabIndex = 21;
            this.label_Nick.Text = "Wpisz swój nick";
            // 
            // label_Lista
            // 
            this.label_Lista.AutoSize = true;
            this.label_Lista.Location = new System.Drawing.Point(435, 217);
            this.label_Lista.Name = "label_Lista";
            this.label_Lista.Size = new System.Drawing.Size(117, 13);
            this.label_Lista.TabIndex = 22;
            this.label_Lista.Text = "Lista aktywnych graczy";
            // 
            // label_Graj
            // 
            this.label_Graj.AutoSize = true;
            this.label_Graj.Location = new System.Drawing.Point(410, 352);
            this.label_Graj.Name = "label_Graj";
            this.label_Graj.Size = new System.Drawing.Size(232, 13);
            this.label_Graj.TabIndex = 23;
            this.label_Graj.Text = "Wybierz przeciwnika z listy i wciśnij przycisk graj";
            // 
            // pb_Tura
            // 
            this.pb_Tura.Location = new System.Drawing.Point(413, 375);
            this.pb_Tura.Name = "pb_Tura";
            this.pb_Tura.Size = new System.Drawing.Size(30, 30);
            this.pb_Tura.TabIndex = 24;
            this.pb_Tura.TabStop = false;
            // 
            // label_Tura
            // 
            this.label_Tura.AutoSize = true;
            this.label_Tura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_Tura.Location = new System.Drawing.Point(449, 382);
            this.label_Tura.Name = "label_Tura";
            this.label_Tura.Size = new System.Drawing.Size(46, 17);
            this.label_Tura.TabIndex = 25;
            this.label_Tura.Text = "label1";
            // 
            // TransparentPanel
            // 
            this.TransparentPanel.Location = new System.Drawing.Point(0, 2);
            this.TransparentPanel.Name = "TransparentPanel";
            this.TransparentPanel.Size = new System.Drawing.Size(400, 400);
            this.TransparentPanel.TabIndex = 16;
            this.TransparentPanel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1073, 416);
            this.Controls.Add(this.label_Tura);
            this.Controls.Add(this.pb_Tura);
            this.Controls.Add(this.label_Graj);
            this.Controls.Add(this.label_Lista);
            this.Controls.Add(this.label_Nick);
            this.Controls.Add(this.b_Graj);
            this.Controls.Add(this.lb_ListaGraczy);
            this.Controls.Add(this.b_Polacz);
            this.Controls.Add(this.tb_NickGracza);
            this.Controls.Add(this.TransparentPanel);
            this.Controls.Add(this.label_Czat);
            this.Controls.Add(this.label_Log);
            this.Controls.Add(this.tb_Czat);
            this.Controls.Add(this.b_Wyslij);
            this.Controls.Add(this.lb_Czat);
            this.Controls.Add(this.lb_Log);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Tura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Log;
        private System.Windows.Forms.ListBox lb_Czat;
        private System.Windows.Forms.Button b_Wyslij;
        private System.Windows.Forms.TextBox tb_Czat;
        private System.Windows.Forms.Label label_Log;
        private System.Windows.Forms.Label label_Czat;
        private TransparentMessagePanel TransparentPanel;
        private System.Windows.Forms.TextBox tb_NickGracza;
        private System.Windows.Forms.Button b_Polacz;
        private System.Windows.Forms.ListBox lb_ListaGraczy;
        private System.Windows.Forms.Button b_Graj;
        private System.Windows.Forms.Label label_Nick;
        private System.Windows.Forms.Label label_Lista;
        private System.Windows.Forms.Label label_Graj;
        private System.Windows.Forms.PictureBox pb_Tura;
        private System.Windows.Forms.Label label_Tura;
    }
}

