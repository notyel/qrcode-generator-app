using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace QRCodeReader
{
    public partial class MainForm : Form
    {
        private bool isLink;

        public MainForm()
        {
            InitializeComponent();
            lblQRContent.Click += lblQRContent_Click;
            btnGenerarQR.Click += btnGenerarQR_Click;
        }

        private void btnGenerarQR_Click(object sender, EventArgs e)
        {
            string qrText;

            do
            {
                // Abrir un cuadro de diálogo de entrada de texto para solicitar el contenido del código QR
                qrText = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el texto para el código QR:", "Generar QR");

                // Validar si el texto está vacío
                if (string.IsNullOrWhiteSpace(qrText))
                {
                    var result = MessageBox.Show("El texto ingresado está vacío. ¿Desea intentar nuevamente?", "Generar QR", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        return; // Salir del método si el usuario no desea intentar nuevamente
                }
            } while (string.IsNullOrWhiteSpace(qrText));

            // Generar el código QR con el texto proporcionado
            BarcodeWriter barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Width = 300,
                    Height = 300,
                    Margin = 10
                }
            };

            Bitmap qrCodeBitmap = barcodeWriter.Write(qrText);

            // Obtener la ruta de destino del archivo a guardar
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de imagen (*.png)|*.png";
            saveFileDialog.Title = "Guardar código QR";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Guardar el código QR en el archivo seleccionado
                qrCodeBitmap.Save(filePath);

                MessageBox.Show("Código QR generado exitosamente.\n\nArchivo guardado en: " + filePath, "Generar QR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                Bitmap image = new Bitmap(filePath);

                pbPreview.Image = image;

                BarcodeReader barcodeReader = new BarcodeReader();
                barcodeReader.Options.PossibleFormats = new[] { BarcodeFormat.QR_CODE };

                Result result = barcodeReader.Decode(image);

                if (result != null)
                {
                    lblResult.Text = "El contenido del código QR es:";

                    lblQRContent.Text = result.Text;
                    isLink = result.Text.StartsWith("http");
                    lblQRContent.ForeColor = isLink ? Color.Blue : Color.Black;
                    lblQRContent.Cursor = isLink ? Cursors.Hand : Cursors.Default;
                }
                else
                {
                    lblResult.Text = "No se pudo leer el código QR.";
                    lblQRContent.Text = string.Empty;
                    lblQRContent.ForeColor = Color.Black;
                    lblQRContent.Cursor = Cursors.Default;
                    isLink = false;
                }
            }
        }

        private void lblQRContent_Click(object sender, EventArgs e)
        {
            if (isLink)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = lblQRContent.Text,
                        UseShellExecute = true
                    };

                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo abrir el enlace: {ex.Message}");
                }
            }
        }
    }
}
