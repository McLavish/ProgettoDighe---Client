namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ultrasuoni = new System.IO.Ports.SerialPort(this.components);
            this.router = new System.IO.Ports.SerialPort(this.components);
            this.txtMisuraRilevata = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtErrori = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.picColor = new System.Windows.Forms.PictureBox();
            this.controlloPeriodico = new System.Windows.Forms.Timer(this.components);
            this.lblAttesa = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).BeginInit();
            this.SuspendLayout();
            // 
            // ultrasuoni
            // 
            this.ultrasuoni.DtrEnable = true;
            this.ultrasuoni.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ultrasuoni_DataReceived);
            // 
            // router
            // 
            this.router.BaudRate = 115200;
            this.router.DtrEnable = true;
            // 
            // txtMisuraRilevata
            // 
            this.txtMisuraRilevata.Enabled = false;
            this.txtMisuraRilevata.Location = new System.Drawing.Point(12, 41);
            this.txtMisuraRilevata.Name = "txtMisuraRilevata";
            this.txtMisuraRilevata.ReadOnly = true;
            this.txtMisuraRilevata.Size = new System.Drawing.Size(100, 20);
            this.txtMisuraRilevata.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Misura rilevata";
            // 
            // txtErrori
            // 
            this.txtErrori.Location = new System.Drawing.Point(483, 25);
            this.txtErrori.Multiline = true;
            this.txtErrori.Name = "txtErrori";
            this.txtErrori.Size = new System.Drawing.Size(305, 413);
            this.txtErrori.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(480, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Errori";
            // 
            // picColor
            // 
            this.picColor.BackColor = System.Drawing.Color.Green;
            this.picColor.Location = new System.Drawing.Point(12, 80);
            this.picColor.Name = "picColor";
            this.picColor.Size = new System.Drawing.Size(100, 50);
            this.picColor.TabIndex = 10;
            this.picColor.TabStop = false;
            // 
            // controlloPeriodico
            // 
            this.controlloPeriodico.Tick += new System.EventHandler(this.controlloPeriodico_Tick);
            // 
            // lblAttesa
            // 
            this.lblAttesa.AutoSize = true;
            this.lblAttesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttesa.Location = new System.Drawing.Point(82, 241);
            this.lblAttesa.Name = "lblAttesa";
            this.lblAttesa.Size = new System.Drawing.Size(309, 24);
            this.lblAttesa.TabIndex = 11;
            this.lblAttesa.Text = "In attesa del messaggio del server...";
            this.lblAttesa.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAttesa);
            this.Controls.Add(this.picColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtErrori);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMisuraRilevata);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort ultrasuoni;
        private System.IO.Ports.SerialPort router;
        private System.Windows.Forms.TextBox txtMisuraRilevata;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtErrori;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picColor;
        private System.Windows.Forms.Timer controlloPeriodico;
        private System.Windows.Forms.Label lblAttesa;
    }
}

