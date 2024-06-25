namespace yapay_zeka_final
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtGridSize = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.panelGrid = new System.Windows.Forms.TableLayoutPanel();
            this.lblError = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFindPath = new System.Windows.Forms.Button();
            this.btnPlaceStart = new System.Windows.Forms.Button();
            this.btnPlaceEnd = new System.Windows.Forms.Button();
            this.lblGridSize = new System.Windows.Forms.Label();
            this.panelLine = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtGridSize
            // 
            this.txtGridSize.Location = new System.Drawing.Point(656, 15);
            this.txtGridSize.Margin = new System.Windows.Forms.Padding(2);
            this.txtGridSize.Name = "txtGridSize";
            this.txtGridSize.Size = new System.Drawing.Size(93, 20);
            this.txtGridSize.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(666, 46);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(78, 30);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Başla";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panelGrid
            // 
            this.panelGrid.ColumnCount = 1;
            this.panelGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelGrid.Location = new System.Drawing.Point(1, 31);
            this.panelGrid.Margin = new System.Windows.Forms.Padding(2);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.RowCount = 1;
            this.panelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelGrid.Size = new System.Drawing.Size(450, 467);
            this.panelGrid.TabIndex = 2;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(9, 515);
            this.lblError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 5;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(504, 476);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(81, 36);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Temizle";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnFindPath
            // 
            this.btnFindPath.Location = new System.Drawing.Point(630, 476);
            this.btnFindPath.Margin = new System.Windows.Forms.Padding(2);
            this.btnFindPath.Name = "btnFindPath";
            this.btnFindPath.Size = new System.Drawing.Size(81, 36);
            this.btnFindPath.TabIndex = 7;
            this.btnFindPath.Text = "Yolu Bul";
            this.btnFindPath.UseVisualStyleBackColor = true;
            this.btnFindPath.Click += new System.EventHandler(this.btnFindPath_Click);
            // 
            // btnPlaceStart
            // 
            this.btnPlaceStart.Location = new System.Drawing.Point(470, 161);
            this.btnPlaceStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlaceStart.Name = "btnPlaceStart";
            this.btnPlaceStart.Size = new System.Drawing.Size(104, 45);
            this.btnPlaceStart.TabIndex = 8;
            this.btnPlaceStart.Text = "Başlangıç";
            this.btnPlaceStart.UseVisualStyleBackColor = true;
            this.btnPlaceStart.Click += new System.EventHandler(this.btnPlaceStart_Click);
            // 
            // btnPlaceEnd
            // 
            this.btnPlaceEnd.Location = new System.Drawing.Point(470, 210);
            this.btnPlaceEnd.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlaceEnd.Name = "btnPlaceEnd";
            this.btnPlaceEnd.Size = new System.Drawing.Size(104, 44);
            this.btnPlaceEnd.TabIndex = 9;
            this.btnPlaceEnd.Text = "Bitiş";
            this.btnPlaceEnd.UseVisualStyleBackColor = true;
            this.btnPlaceEnd.Click += new System.EventHandler(this.btnPlaceEnd_Click);
            // 
            // lblGridSize
            // 
            this.lblGridSize.AutoSize = true;
            this.lblGridSize.Location = new System.Drawing.Point(462, 18);
            this.lblGridSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGridSize.Name = "lblGridSize";
            this.lblGridSize.Size = new System.Drawing.Size(190, 13);
            this.lblGridSize.TabIndex = 10;
            this.lblGridSize.Text = "Matris boyutunu satır sütun olarak girin:";
            // 
            // panelLine
            // 
            this.panelLine.BackColor = System.Drawing.Color.Black;
            this.panelLine.Location = new System.Drawing.Point(455, 0);
            this.panelLine.Name = "panelLine";
            this.panelLine.Size = new System.Drawing.Size(2, 661);
            this.panelLine.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(753, 537);
            this.Controls.Add(this.lblGridSize);
            this.Controls.Add(this.btnPlaceEnd);
            this.Controls.Add(this.btnPlaceStart);
            this.Controls.Add(this.btnFindPath);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtGridSize);
            this.Controls.Add(this.panelLine);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "A* Algoritması";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtGridSize;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TableLayoutPanel panelGrid;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnFindPath;
        private System.Windows.Forms.Button btnPlaceStart;
        private System.Windows.Forms.Button btnPlaceEnd;
        private System.Windows.Forms.Label lblGridSize;
        private System.Windows.Forms.Panel panelLine;
    }
}