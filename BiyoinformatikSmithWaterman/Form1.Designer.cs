
namespace BiyoinformatikSmithWaterman
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.labelMatch = new System.Windows.Forms.Label();
            this.textBoxMatch = new System.Windows.Forms.TextBox();
            this.textBoxMiss = new System.Windows.Forms.TextBox();
            this.labelMiss = new System.Windows.Forms.Label();
            this.textBoxGap = new System.Windows.Forms.TextBox();
            this.labelGap = new System.Windows.Forms.Label();
            this.buttonSmithWaterman = new System.Windows.Forms.Button();
            this.buttonNeedlemanWunsch = new System.Windows.Forms.Button();
            this.textBoxScore = new System.Windows.Forms.TextBox();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelRunTime = new System.Windows.Forms.Label();
            this.labelSeq1 = new System.Windows.Forms.Label();
            this.textBoxSeq1 = new System.Windows.Forms.TextBox();
            this.textBoxSeq2 = new System.Windows.Forms.TextBox();
            this.labelSeq2 = new System.Windows.Forms.Label();
            this.labelAlignment = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(248, 25);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(1185, 482);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView_ColumnAdded);
            // 
            // labelMatch
            // 
            this.labelMatch.AutoSize = true;
            this.labelMatch.Location = new System.Drawing.Point(23, 68);
            this.labelMatch.Name = "labelMatch";
            this.labelMatch.Size = new System.Drawing.Size(46, 17);
            this.labelMatch.TabIndex = 1;
            this.labelMatch.Text = "Match";
            // 
            // textBoxMatch
            // 
            this.textBoxMatch.Location = new System.Drawing.Point(75, 65);
            this.textBoxMatch.Name = "textBoxMatch";
            this.textBoxMatch.Size = new System.Drawing.Size(121, 22);
            this.textBoxMatch.TabIndex = 2;
            this.textBoxMatch.Text = "1";
            // 
            // textBoxMiss
            // 
            this.textBoxMiss.Location = new System.Drawing.Point(75, 104);
            this.textBoxMiss.Name = "textBoxMiss";
            this.textBoxMiss.Size = new System.Drawing.Size(121, 22);
            this.textBoxMiss.TabIndex = 4;
            this.textBoxMiss.Text = "-1";
            // 
            // labelMiss
            // 
            this.labelMiss.AutoSize = true;
            this.labelMiss.Location = new System.Drawing.Point(23, 107);
            this.labelMiss.Name = "labelMiss";
            this.labelMiss.Size = new System.Drawing.Size(36, 17);
            this.labelMiss.TabIndex = 3;
            this.labelMiss.Text = "Miss";
            // 
            // textBoxGap
            // 
            this.textBoxGap.Location = new System.Drawing.Point(75, 144);
            this.textBoxGap.Name = "textBoxGap";
            this.textBoxGap.Size = new System.Drawing.Size(121, 22);
            this.textBoxGap.TabIndex = 6;
            this.textBoxGap.Text = "-2";
            // 
            // labelGap
            // 
            this.labelGap.AutoSize = true;
            this.labelGap.Location = new System.Drawing.Point(23, 147);
            this.labelGap.Name = "labelGap";
            this.labelGap.Size = new System.Drawing.Size(46, 17);
            this.labelGap.TabIndex = 5;
            this.labelGap.Text = "Match";
            // 
            // buttonSmithWaterman
            // 
            this.buttonSmithWaterman.Location = new System.Drawing.Point(53, 194);
            this.buttonSmithWaterman.Name = "buttonSmithWaterman";
            this.buttonSmithWaterman.Size = new System.Drawing.Size(154, 35);
            this.buttonSmithWaterman.TabIndex = 7;
            this.buttonSmithWaterman.Text = "Smith-Waterman";
            this.buttonSmithWaterman.UseVisualStyleBackColor = true;
            this.buttonSmithWaterman.Click += new System.EventHandler(this.buttonSmithWaterman_Click);
            // 
            // buttonNeedlemanWunsch
            // 
            this.buttonNeedlemanWunsch.Location = new System.Drawing.Point(53, 248);
            this.buttonNeedlemanWunsch.Name = "buttonNeedlemanWunsch";
            this.buttonNeedlemanWunsch.Size = new System.Drawing.Size(154, 35);
            this.buttonNeedlemanWunsch.TabIndex = 8;
            this.buttonNeedlemanWunsch.Text = "Needleman–Wunsch";
            this.buttonNeedlemanWunsch.UseVisualStyleBackColor = true;
            this.buttonNeedlemanWunsch.Click += new System.EventHandler(this.buttonNeedlemanWunsch_Click);
            // 
            // textBoxScore
            // 
            this.textBoxScore.Location = new System.Drawing.Point(75, 410);
            this.textBoxScore.Name = "textBoxScore";
            this.textBoxScore.Size = new System.Drawing.Size(121, 22);
            this.textBoxScore.TabIndex = 10;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Location = new System.Drawing.Point(23, 413);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(45, 17);
            this.labelScore.TabIndex = 9;
            this.labelScore.Text = "Score";
            // 
            // labelRunTime
            // 
            this.labelRunTime.AutoSize = true;
            this.labelRunTime.Location = new System.Drawing.Point(24, 337);
            this.labelRunTime.Name = "labelRunTime";
            this.labelRunTime.Size = new System.Drawing.Size(0, 17);
            this.labelRunTime.TabIndex = 11;
            // 
            // labelSeq1
            // 
            this.labelSeq1.AutoSize = true;
            this.labelSeq1.Location = new System.Drawing.Point(72, 572);
            this.labelSeq1.Name = "labelSeq1";
            this.labelSeq1.Size = new System.Drawing.Size(41, 17);
            this.labelSeq1.TabIndex = 12;
            this.labelSeq1.Text = "Seq1";
            // 
            // textBoxSeq1
            // 
            this.textBoxSeq1.Location = new System.Drawing.Point(147, 569);
            this.textBoxSeq1.Multiline = true;
            this.textBoxSeq1.Name = "textBoxSeq1";
            this.textBoxSeq1.Size = new System.Drawing.Size(1286, 62);
            this.textBoxSeq1.TabIndex = 13;
            // 
            // textBoxSeq2
            // 
            this.textBoxSeq2.Location = new System.Drawing.Point(147, 688);
            this.textBoxSeq2.Multiline = true;
            this.textBoxSeq2.Name = "textBoxSeq2";
            this.textBoxSeq2.Size = new System.Drawing.Size(1286, 62);
            this.textBoxSeq2.TabIndex = 15;
            // 
            // labelSeq2
            // 
            this.labelSeq2.AutoSize = true;
            this.labelSeq2.Location = new System.Drawing.Point(72, 691);
            this.labelSeq2.Name = "labelSeq2";
            this.labelSeq2.Size = new System.Drawing.Size(41, 17);
            this.labelSeq2.TabIndex = 14;
            this.labelSeq2.Text = "Seq2";
            // 
            // labelAlignment
            // 
            this.labelAlignment.AutoSize = true;
            this.labelAlignment.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAlignment.Location = new System.Drawing.Point(745, 523);
            this.labelAlignment.Name = "labelAlignment";
            this.labelAlignment.Size = new System.Drawing.Size(136, 22);
            this.labelAlignment.TabIndex = 16;
            this.labelAlignment.Text = "After Alignment";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1476, 794);
            this.Controls.Add(this.labelAlignment);
            this.Controls.Add(this.textBoxSeq2);
            this.Controls.Add(this.labelSeq2);
            this.Controls.Add(this.textBoxSeq1);
            this.Controls.Add(this.labelSeq1);
            this.Controls.Add(this.labelRunTime);
            this.Controls.Add(this.textBoxScore);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.buttonNeedlemanWunsch);
            this.Controls.Add(this.buttonSmithWaterman);
            this.Controls.Add(this.textBoxGap);
            this.Controls.Add(this.labelGap);
            this.Controls.Add(this.textBoxMiss);
            this.Controls.Add(this.labelMiss);
            this.Controls.Add(this.textBoxMatch);
            this.Controls.Add(this.labelMatch);
            this.Controls.Add(this.dataGridView);
            this.Name = "Form1";
            this.Text = "Smith-Waterman && Needleman–Wunsch";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label labelMatch;
        private System.Windows.Forms.TextBox textBoxMatch;
        private System.Windows.Forms.TextBox textBoxMiss;
        private System.Windows.Forms.Label labelMiss;
        private System.Windows.Forms.TextBox textBoxGap;
        private System.Windows.Forms.Label labelGap;
        private System.Windows.Forms.Button buttonSmithWaterman;
        private System.Windows.Forms.Button buttonNeedlemanWunsch;
        private System.Windows.Forms.TextBox textBoxScore;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelRunTime;
        private System.Windows.Forms.Label labelSeq1;
        private System.Windows.Forms.TextBox textBoxSeq1;
        private System.Windows.Forms.TextBox textBoxSeq2;
        private System.Windows.Forms.Label labelSeq2;
        private System.Windows.Forms.Label labelAlignment;
    }
}

