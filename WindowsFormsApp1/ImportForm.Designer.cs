namespace WindowsFormsApp1
{
    partial class ImportForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.QualGridMale = new System.Windows.Forms.DataGridView();
            this.QualGridFemale = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nextButtonFemale = new System.Windows.Forms.Button();
            this.labelMale = new System.Windows.Forms.Label();
            this.labelFemale = new System.Windows.Forms.Label();
            this.nextButtonMale = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QualGridMale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QualGridFemale)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button1.Location = new System.Drawing.Point(12, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(508, 60);
            this.button1.TabIndex = 9;
            this.button1.Text = "Импорт";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label5.Location = new System.Drawing.Point(43, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(452, 26);
            this.label5.TabIndex = 8;
            this.label5.Text = "Импортируйте информацию об участниках";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QualGridMale
            // 
            this.QualGridMale.ColumnHeadersHeight = 25;
            this.QualGridMale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.QualGridMale.Location = new System.Drawing.Point(12, 185);
            this.QualGridMale.Name = "QualGridMale";
            this.QualGridMale.RowHeadersWidth = 50;
            this.QualGridMale.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.QualGridMale.Size = new System.Drawing.Size(508, 130);
            this.QualGridMale.TabIndex = 10;
            // 
            // QualGridFemale
            // 
            this.QualGridFemale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.QualGridFemale.Location = new System.Drawing.Point(12, 394);
            this.QualGridFemale.Name = "QualGridFemale";
            this.QualGridFemale.RowHeadersWidth = 50;
            this.QualGridFemale.Size = new System.Drawing.Size(508, 130);
            this.QualGridFemale.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(12, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Мужчины:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(12, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Женщины:";
            // 
            // nextButtonFemale
            // 
            this.nextButtonFemale.Enabled = false;
            this.nextButtonFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.nextButtonFemale.Location = new System.Drawing.Point(153, 328);
            this.nextButtonFemale.Name = "nextButtonFemale";
            this.nextButtonFemale.Size = new System.Drawing.Size(367, 60);
            this.nextButtonFemale.TabIndex = 9;
            this.nextButtonFemale.Text = "Распределить женщин на группы";
            this.nextButtonFemale.UseVisualStyleBackColor = true;
            this.nextButtonFemale.Click += new System.EventHandler(this.nextButtonFemale_Click);
            // 
            // labelMale
            // 
            this.labelMale.AutoSize = true;
            this.labelMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelMale.Location = new System.Drawing.Point(12, 153);
            this.labelMale.Name = "labelMale";
            this.labelMale.Size = new System.Drawing.Size(0, 26);
            this.labelMale.TabIndex = 8;
            // 
            // labelFemale
            // 
            this.labelFemale.AutoSize = true;
            this.labelFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelFemale.Location = new System.Drawing.Point(12, 362);
            this.labelFemale.Name = "labelFemale";
            this.labelFemale.Size = new System.Drawing.Size(0, 26);
            this.labelFemale.TabIndex = 8;
            // 
            // nextButtonMale
            // 
            this.nextButtonMale.Enabled = false;
            this.nextButtonMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.nextButtonMale.Location = new System.Drawing.Point(161, 119);
            this.nextButtonMale.Name = "nextButtonMale";
            this.nextButtonMale.Size = new System.Drawing.Size(359, 60);
            this.nextButtonMale.TabIndex = 12;
            this.nextButtonMale.Text = "Распределить мужчин на группы";
            this.nextButtonMale.UseVisualStyleBackColor = true;
            this.nextButtonMale.Click += new System.EventHandler(this.nextButtonMale_Click);
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 536);
            this.Controls.Add(this.nextButtonMale);
            this.Controls.Add(this.QualGridFemale);
            this.Controls.Add(this.QualGridMale);
            this.Controls.Add(this.nextButtonFemale);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelFemale);
            this.Controls.Add(this.labelMale);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Name = "ImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Импорт";
            ((System.ComponentModel.ISupportInitialize)(this.QualGridMale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QualGridFemale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView QualGridMale;
        private System.Windows.Forms.DataGridView QualGridFemale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button nextButtonFemale;
        private System.Windows.Forms.Label labelMale;
        private System.Windows.Forms.Label labelFemale;
        private System.Windows.Forms.Button nextButtonMale;
    }
}