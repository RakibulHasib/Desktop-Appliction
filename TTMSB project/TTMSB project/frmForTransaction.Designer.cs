namespace TTMSB_project
{
    partial class frmForTransaction
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMonthName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.btnInsertAll = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.spot = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.NetPropit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(294, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Net Propit Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(166, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Month Name :";
            // 
            // txtMonthName
            // 
            this.txtMonthName.Location = new System.Drawing.Point(53, 125);
            this.txtMonthName.Multiline = true;
            this.txtMonthName.Name = "txtMonthName";
            this.txtMonthName.Size = new System.Drawing.Size(360, 47);
            this.txtMonthName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(604, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Days :";
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(467, 125);
            this.txtDays.Multiline = true;
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(360, 47);
            this.txtDays.TabIndex = 1;
            // 
            // btnInsertAll
            // 
            this.btnInsertAll.BackColor = System.Drawing.Color.DarkGreen;
            this.btnInsertAll.ForeColor = System.Drawing.Color.White;
            this.btnInsertAll.Location = new System.Drawing.Point(351, 408);
            this.btnInsertAll.Name = "btnInsertAll";
            this.btnInsertAll.Size = new System.Drawing.Size(199, 49);
            this.btnInsertAll.TabIndex = 2;
            this.btnInsertAll.Text = "Insert All";
            this.btnInsertAll.UseVisualStyleBackColor = false;
            this.btnInsertAll.Click += new System.EventHandler(this.btnInsertAll_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.spot,
            this.NetPropit});
            this.dataGridView1.Location = new System.Drawing.Point(53, 192);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 72;
            this.dataGridView1.RowTemplate.Height = 31;
            this.dataGridView1.Size = new System.Drawing.Size(774, 210);
            this.dataGridView1.TabIndex = 3;
            // 
            // spot
            // 
            this.spot.HeaderText = "Spot";
            this.spot.MinimumWidth = 9;
            this.spot.Name = "spot";
            // 
            // NetPropit
            // 
            this.NetPropit.HeaderText = "Net Propit";
            this.NetPropit.MinimumWidth = 9;
            this.NetPropit.Name = "NetPropit";
            // 
            // frmForTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(873, 469);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnInsertAll);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMonthName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmForTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmForTransaction";
            this.Load += new System.EventHandler(this.frmForTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMonthName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Button btnInsertAll;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewComboBoxColumn spot;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetPropit;
    }
}