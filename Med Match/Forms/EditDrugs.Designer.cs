namespace Med_Match.Forms
{
    partial class EditDrugs
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
            this.components = new System.ComponentModel.Container();
            this.cbDrugs = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.drugCat_txt = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.activeIngredient_txt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.drugPrice_txt = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Drugname_txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbDrugs
            // 
            this.cbDrugs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDrugs.ForeColor = System.Drawing.Color.Gray;
            this.cbDrugs.FormattingEnabled = true;
            this.cbDrugs.Location = new System.Drawing.Point(580, 68);
            this.cbDrugs.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cbDrugs.Name = "cbDrugs";
            this.cbDrugs.Size = new System.Drawing.Size(228, 33);
            this.cbDrugs.TabIndex = 0;
            this.cbDrugs.Text = "Drug";
            this.cbDrugs.SelectedIndexChanged += new System.EventHandler(this.cbDrugs_SelectedIndexChanged);
            this.cbDrugs.TextChanged += new System.EventHandler(this.cbDrugs_TextChanged);
            this.cbDrugs.Enter += new System.EventHandler(this.cbDrugs_Enter);
            this.cbDrugs.Leave += new System.EventHandler(this.cbDrugs_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(580, 113);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(235, 1);
            this.panel2.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(756, 391);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 25);
            this.label5.TabIndex = 40;
            this.label5.Text = "Drug category";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(158, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 25);
            this.label4.TabIndex = 39;
            this.label4.Text = "Drug activeIngredient";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(756, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 25);
            this.label3.TabIndex = 38;
            this.label3.Text = "Drug price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(158, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 37;
            this.label2.Text = "Drug name";
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.LimeGreen;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_btn.Location = new System.Drawing.Point(625, 559);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(110, 31);
            this.save_btn.TabIndex = 36;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Location = new System.Drawing.Point(902, 405);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(277, 1);
            this.panel4.TabIndex = 35;
            // 
            // drugCat_txt
            // 
            this.drugCat_txt.BackColor = System.Drawing.Color.White;
            this.drugCat_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.drugCat_txt.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drugCat_txt.ForeColor = System.Drawing.Color.Black;
            this.drugCat_txt.Location = new System.Drawing.Point(902, 380);
            this.drugCat_txt.Name = "drugCat_txt";
            this.drugCat_txt.Size = new System.Drawing.Size(257, 26);
            this.drugCat_txt.TabIndex = 34;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Location = new System.Drawing.Point(343, 403);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(277, 1);
            this.panel3.TabIndex = 33;
            // 
            // activeIngredient_txt
            // 
            this.activeIngredient_txt.BackColor = System.Drawing.Color.White;
            this.activeIngredient_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.activeIngredient_txt.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeIngredient_txt.ForeColor = System.Drawing.Color.Black;
            this.activeIngredient_txt.Location = new System.Drawing.Point(343, 378);
            this.activeIngredient_txt.Name = "activeIngredient_txt";
            this.activeIngredient_txt.Size = new System.Drawing.Size(257, 26);
            this.activeIngredient_txt.TabIndex = 32;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(902, 255);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 1);
            this.panel1.TabIndex = 30;
            // 
            // drugPrice_txt
            // 
            this.drugPrice_txt.BackColor = System.Drawing.Color.White;
            this.drugPrice_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.drugPrice_txt.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drugPrice_txt.ForeColor = System.Drawing.Color.Black;
            this.drugPrice_txt.Location = new System.Drawing.Point(902, 230);
            this.drugPrice_txt.Name = "drugPrice_txt";
            this.drugPrice_txt.Size = new System.Drawing.Size(257, 26);
            this.drugPrice_txt.TabIndex = 28;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel5.Location = new System.Drawing.Point(317, 255);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(277, 1);
            this.panel5.TabIndex = 31;
            // 
            // Drugname_txt
            // 
            this.Drugname_txt.BackColor = System.Drawing.Color.White;
            this.Drugname_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Drugname_txt.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Drugname_txt.ForeColor = System.Drawing.Color.Black;
            this.Drugname_txt.Location = new System.Drawing.Point(317, 230);
            this.Drugname_txt.Name = "Drugname_txt";
            this.Drugname_txt.Size = new System.Drawing.Size(257, 26);
            this.Drugname_txt.TabIndex = 29;
            // 
            // EditDrugs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.drugCat_txt);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.activeIngredient_txt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.drugPrice_txt);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.Drugname_txt);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cbDrugs);
            this.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "EditDrugs";
            this.Size = new System.Drawing.Size(1400, 800);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDrugs;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox drugCat_txt;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox activeIngredient_txt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox drugPrice_txt;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox Drugname_txt;
    }
}
