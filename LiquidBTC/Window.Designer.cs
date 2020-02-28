namespace LiquidBTCTrend
{
    partial class App
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Trend = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.High = new System.Windows.Forms.TextBox();
            this.Low = new System.Windows.Forms.TextBox();
            this.Offer = new System.Windows.Forms.TextBox();
            this.Predict = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PairBox = new System.Windows.Forms.ComboBox();
            this.Strategy = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.Latency = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.Latency)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "HIGH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(12, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "LOW";
            // 
            // Trend
            // 
            this.Trend.AutoSize = true;
            this.Trend.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Trend.Location = new System.Drawing.Point(12, 183);
            this.Trend.Name = "Trend";
            this.Trend.Size = new System.Drawing.Size(91, 31);
            this.Trend.TabIndex = 2;
            this.Trend.Text = "TRND";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "OFFER";
            // 
            // High
            // 
            this.High.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.High.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.High.Location = new System.Drawing.Point(118, 54);
            this.High.Name = "High";
            this.High.ReadOnly = true;
            this.High.Size = new System.Drawing.Size(285, 35);
            this.High.TabIndex = 5;
            // 
            // Low
            // 
            this.Low.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Low.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Low.Location = new System.Drawing.Point(118, 141);
            this.Low.Name = "Low";
            this.Low.ReadOnly = true;
            this.Low.Size = new System.Drawing.Size(285, 35);
            this.Low.TabIndex = 6;
            // 
            // Offer
            // 
            this.Offer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Offer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Offer.Location = new System.Drawing.Point(118, 99);
            this.Offer.Name = "Offer";
            this.Offer.ReadOnly = true;
            this.Offer.Size = new System.Drawing.Size(285, 35);
            this.Offer.TabIndex = 7;
            // 
            // Predict
            // 
            this.Predict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Predict.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Predict.Location = new System.Drawing.Point(118, 184);
            this.Predict.Name = "Predict";
            this.Predict.ReadOnly = true;
            this.Predict.Size = new System.Drawing.Size(285, 35);
            this.Predict.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 31);
            this.label4.TabIndex = 9;
            this.label4.Text = "PAIR";
            // 
            // PairBox
            // 
            this.PairBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PairBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PairBox.FormattingEnabled = true;
            this.PairBox.Items.AddRange(new object[] {
            "BTCUSD/1"});
            this.PairBox.Location = new System.Drawing.Point(118, 9);
            this.PairBox.Name = "PairBox";
            this.PairBox.Size = new System.Drawing.Size(285, 37);
            this.PairBox.TabIndex = 11;
            // 
            // Strategy
            // 
            this.Strategy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Strategy.Location = new System.Drawing.Point(18, 278);
            this.Strategy.Name = "Strategy";
            this.Strategy.Size = new System.Drawing.Size(385, 35);
            this.Strategy.TabIndex = 12;
            this.Strategy.Text = "SHORT";
            this.Strategy.UseVisualStyleBackColor = true;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Status.Location = new System.Drawing.Point(12, 227);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(64, 31);
            this.Status.TabIndex = 13;
            this.Status.Text = "LAT";
            // 
            // Latency
            // 
            this.Latency.Location = new System.Drawing.Point(118, 227);
            this.Latency.Maximum = 5000;
            this.Latency.Minimum = 100;
            this.Latency.Name = "Latency";
            this.Latency.Size = new System.Drawing.Size(285, 45);
            this.Latency.TabIndex = 15;
            this.Latency.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Latency.Value = 2000;
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 320);
            this.Controls.Add(this.Latency);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Strategy);
            this.Controls.Add(this.PairBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Predict);
            this.Controls.Add(this.Offer);
            this.Controls.Add(this.Low);
            this.Controls.Add(this.High);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Trend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "App";
            this.Text = "Trend from Liquid";
            ((System.ComponentModel.ISupportInitialize)(this.Latency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Trend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox High;
        private System.Windows.Forms.TextBox Low;
        private System.Windows.Forms.TextBox Offer;
        private System.Windows.Forms.TextBox Predict;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox PairBox;
        private System.Windows.Forms.Button Strategy;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.TrackBar Latency;
    }
}

