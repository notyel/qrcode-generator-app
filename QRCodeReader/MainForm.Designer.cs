namespace QRCodeReader
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblQRContent;

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
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblQRContent = new System.Windows.Forms.Label();
            this.btnGenerarQR = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(12, 12);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(120, 30);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Abrir archivo";
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // pbPreview
            // 
            this.pbPreview.Location = new System.Drawing.Point(12, 48);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(300, 300);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview.TabIndex = 1;
            this.pbPreview.TabStop = false;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(12, 360);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 15);
            this.lblResult.TabIndex = 2;
            // 
            // lblQRContent
            // 
            this.lblQRContent.AutoSize = true;
            this.lblQRContent.Location = new System.Drawing.Point(12, 380);
            this.lblQRContent.Name = "lblQRContent";
            this.lblQRContent.Size = new System.Drawing.Size(0, 15);
            this.lblQRContent.TabIndex = 3;
            // 
            // btnGenerarQR
            // 
            this.btnGenerarQR.Location = new System.Drawing.Point(138, 12);
            this.btnGenerarQR.Name = "btnGenerarQR";
            this.btnGenerarQR.Size = new System.Drawing.Size(174, 30);
            this.btnGenerarQR.TabIndex = 4;
            this.btnGenerarQR.Text = "Generar un QR de ejemplo";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(324, 408);
            this.Controls.Add(this.btnGenerarQR);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.pbPreview);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblQRContent);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lector de Código QR";
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button btnGenerarQR;
    }
}
