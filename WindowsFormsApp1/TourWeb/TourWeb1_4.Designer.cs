namespace WindowsFormsApp1
{
    partial class TourWeb1_4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TourWeb1_4));
            this.backButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.GridRace1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.GridRace2 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.GridRace3 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.GridRace4 = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridRace1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridRace2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridRace3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridRace4)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.backButton.Location = new System.Drawing.Point(12, 589);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(130, 80);
            this.backButton.TabIndex = 32;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click_1);
            // 
            // nextButton
            // 
            this.nextButton.Enabled = false;
            this.nextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.nextButton.Location = new System.Drawing.Point(341, 589);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(179, 80);
            this.nextButton.TabIndex = 33;
            this.nextButton.Text = "Далее: 1/2 Финала";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label18.Location = new System.Drawing.Point(12, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(517, 26);
            this.label18.TabIndex = 30;
            this.label18.Text = "Отметьте победителей(Q), выбывших и их места";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.GridRace1);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.GridRace2);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.GridRace3);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.GridRace4);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 35);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(508, 548);
            this.flowLayoutPanel1.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 26);
            this.label2.TabIndex = 23;
            this.label2.Text = "Заезд 1";
            // 
            // GridRace1
            // 
            this.GridRace1.AllowUserToAddRows = false;
            this.GridRace1.AllowUserToDeleteRows = false;
            this.GridRace1.ColumnHeadersHeight = 25;
            this.GridRace1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridRace1.Location = new System.Drawing.Point(3, 29);
            this.GridRace1.Name = "GridRace1";
            this.GridRace1.RowHeadersWidth = 50;
            this.GridRace1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GridRace1.Size = new System.Drawing.Size(479, 120);
            this.GridRace1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(3, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 26);
            this.label3.TabIndex = 25;
            this.label3.Text = "Заезд 2";
            // 
            // GridRace2
            // 
            this.GridRace2.AllowUserToAddRows = false;
            this.GridRace2.AllowUserToDeleteRows = false;
            this.GridRace2.ColumnHeadersHeight = 25;
            this.GridRace2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridRace2.Location = new System.Drawing.Point(3, 181);
            this.GridRace2.Name = "GridRace2";
            this.GridRace2.RowHeadersWidth = 50;
            this.GridRace2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GridRace2.Size = new System.Drawing.Size(479, 120);
            this.GridRace2.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(3, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 26);
            this.label4.TabIndex = 27;
            this.label4.Text = "Заезд 3";
            // 
            // GridRace3
            // 
            this.GridRace3.AllowUserToAddRows = false;
            this.GridRace3.AllowUserToDeleteRows = false;
            this.GridRace3.ColumnHeadersHeight = 25;
            this.GridRace3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridRace3.Location = new System.Drawing.Point(3, 333);
            this.GridRace3.Name = "GridRace3";
            this.GridRace3.RowHeadersWidth = 50;
            this.GridRace3.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GridRace3.Size = new System.Drawing.Size(479, 120);
            this.GridRace3.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label5.Location = new System.Drawing.Point(3, 456);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 26);
            this.label5.TabIndex = 29;
            this.label5.Text = "Заезд 4";
            // 
            // GridRace4
            // 
            this.GridRace4.AllowUserToAddRows = false;
            this.GridRace4.AllowUserToDeleteRows = false;
            this.GridRace4.ColumnHeadersHeight = 25;
            this.GridRace4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridRace4.Location = new System.Drawing.Point(3, 485);
            this.GridRace4.Name = "GridRace4";
            this.GridRace4.RowHeadersWidth = 50;
            this.GridRace4.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GridRace4.Size = new System.Drawing.Size(479, 120);
            this.GridRace4.TabIndex = 28;
            // 
            // TourWeb1_4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 681);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TourWeb1_4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "1/4 Финала";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridRace1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridRace2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridRace3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridRace4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView GridRace1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView GridRace2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView GridRace3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView GridRace4;
    }
}