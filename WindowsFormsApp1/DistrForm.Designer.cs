namespace WindowsFormsApp1
{
    partial class DistrForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistrForm));
            this.qualGrid = new System.Windows.Forms.DataGridView();
            this.QualRaspr = new System.Windows.Forms.Button();
            this.countCBQual = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TourWebButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupCBQual = new System.Windows.Forms.ComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.qualGridParticipants = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qualGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qualGridParticipants)).BeginInit();
            this.SuspendLayout();
            // 
            // qualGrid
            // 
            this.qualGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.qualGrid.ColumnHeadersHeight = 25;
            this.qualGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.qualGrid.Location = new System.Drawing.Point(12, 430);
            this.qualGrid.Name = "qualGrid";
            this.qualGrid.RowHeadersWidth = 50;
            this.qualGrid.Size = new System.Drawing.Size(508, 175);
            this.qualGrid.TabIndex = 0;
            // 
            // QualRaspr
            // 
            this.QualRaspr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.QualRaspr.Location = new System.Drawing.Point(12, 136);
            this.QualRaspr.Name = "QualRaspr";
            this.QualRaspr.Size = new System.Drawing.Size(508, 57);
            this.QualRaspr.TabIndex = 1;
            this.QualRaspr.Text = "Распределить";
            this.QualRaspr.UseVisualStyleBackColor = true;
            this.QualRaspr.Click += new System.EventHandler(this.QualRaspr_Click);
            // 
            // countCBQual
            // 
            this.countCBQual.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.countCBQual.FormattingEnabled = true;
            this.countCBQual.Items.AddRange(new object[] {
            "16",
            "24",
            "32",
            "48",
            "64"});
            this.countCBQual.Location = new System.Drawing.Point(273, 93);
            this.countCBQual.Name = "countCBQual";
            this.countCBQual.Size = new System.Drawing.Size(69, 33);
            this.countCBQual.TabIndex = 2;
            this.countCBQual.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(12, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Количество участников:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(7, 401);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(316, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Группы после квалификации:";
            // 
            // TourWebButton
            // 
            this.TourWebButton.Enabled = false;
            this.TourWebButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.TourWebButton.Location = new System.Drawing.Point(12, 611);
            this.TourWebButton.Name = "TourWebButton";
            this.TourWebButton.Size = new System.Drawing.Size(508, 57);
            this.TourWebButton.TabIndex = 6;
            this.TourWebButton.Text = "Турнирная сетка";
            this.TourWebButton.UseVisualStyleBackColor = true;
            this.TourWebButton.Click += new System.EventHandler(this.TourWebButtonMale_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label5.Location = new System.Drawing.Point(183, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 26);
            this.label5.TabIndex = 3;
            this.label5.Text = "Введите данные";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label6.Location = new System.Drawing.Point(12, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 26);
            this.label6.TabIndex = 3;
            this.label6.Text = "Количество групп:";
            // 
            // groupCBQual
            // 
            this.groupCBQual.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.groupCBQual.FormattingEnabled = true;
            this.groupCBQual.Items.AddRange(new object[] {
            "4",
            "8",
            "16"});
            this.groupCBQual.Location = new System.Drawing.Point(273, 51);
            this.groupCBQual.Name = "groupCBQual";
            this.groupCBQual.Size = new System.Drawing.Size(69, 33);
            this.groupCBQual.TabIndex = 2;
            this.groupCBQual.Text = "0";
            // 
            // qualGridParticipants
            // 
            this.qualGridParticipants.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.qualGridParticipants.ColumnHeadersHeight = 25;
            this.qualGridParticipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.qualGridParticipants.Location = new System.Drawing.Point(12, 223);
            this.qualGridParticipants.Name = "qualGridParticipants";
            this.qualGridParticipants.RowHeadersWidth = 50;
            this.qualGridParticipants.Size = new System.Drawing.Size(508, 175);
            this.qualGridParticipants.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(12, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Участники:";
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.backButton.Location = new System.Drawing.Point(12, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(96, 35);
            this.backButton.TabIndex = 33;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // DistrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 681);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.TourWebButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupCBQual);
            this.Controls.Add(this.countCBQual);
            this.Controls.Add(this.qualGridParticipants);
            this.Controls.Add(this.QualRaspr);
            this.Controls.Add(this.qualGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DistrForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Группы после квалификации";
            ((System.ComponentModel.ISupportInitialize)(this.qualGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qualGridParticipants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView qualGrid;
        private System.Windows.Forms.Button QualRaspr;
        private System.Windows.Forms.ComboBox countCBQual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button TourWebButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox groupCBQual;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView qualGridParticipants;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button backButton;
    }
}

