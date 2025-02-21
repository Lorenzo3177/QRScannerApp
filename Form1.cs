using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using System.IO;

namespace QRScannerApp
{
    public partial class QRScannerForm : Form
    {
        private string currentLanguage = "ru";
        private Image<Bgr, byte>? loadedImage;
        private string logFilePath = "app_log.txt"; 

        public QRScannerForm()
        {
            InitializeComponent();
            InitializeLogging(); 
        }

        private void InitializeLogging()
        {
            if (!File.Exists(logFilePath))
            {
                File.Create(logFilePath).Close(); 
            }
        }

        private void LogMessage(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в лог: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadImage(object sender, EventArgs e)
        {
            try
            {
                LogMessage("Загрузка изображения началась.");
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                    txtResult.Text = "";
                    loadedImage = new Image<Bgr, byte>(openFileDialog.FileName);  
                    LogMessage($"Изображение загружено: {openFileDialog.FileName}");
                }
                else
                {
                    LogMessage("Изображение не выбрано пользователем.");
                }
            }
            catch (Exception ex)
            {
                string errorMsg = $"Ошибка при загрузке изображения: {ex.Message}";
                MessageBox.Show(errorMsg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogMessage(errorMsg); 
            }
        }

        private void ScanQRCode(object sender, EventArgs e)
        {
            if (loadedImage == null)
            {
                string errorMsg = "Загрузите изображение перед сканированием.";
                MessageBox.Show(errorMsg);
                LogMessage(errorMsg);
                return;
            }

            try
            {
                LogMessage("Сканирование QR-кода началось.");

                Mat imageMat = loadedImage.Mat;  
                LogMessage("Изображение преобразовано в Mat.");

                if (imageMat.IsEmpty)
                {
                    string errorMsg = "Ошибка: Матрица изображения пустая после преобразования!";
                    MessageBox.Show(errorMsg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogMessage(errorMsg);
                    return;
                }

                LogMessage($"Размер изображения: {imageMat.Width}x{imageMat.Height}");

                Mat grayImage = new Mat();
                try
                {
                    LogMessage("Преобразование в градации серого началось.");
                    CvInvoke.CvtColor(imageMat, grayImage, ColorConversion.Bgr2Gray);
                    LogMessage("Изображение преобразовано в градации серого.");
                }
                catch (Exception ex)
                {
                    string errorMsg = $"Ошибка при конвертации в серый цвет: {ex.Message}";
                    MessageBox.Show(errorMsg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogMessage(errorMsg);
                    return;
                }

                QRCodeDetector qrCodeDetector = new QRCodeDetector();

                using (VectorOfPointF points = new VectorOfPointF())
                {
                    bool detected = qrCodeDetector.Detect(grayImage, points);
                    LogMessage($"QR-код детектирован: {detected}");

                    if (detected)
                    {
                        string decodedText = qrCodeDetector.Decode(grayImage, points);
                        if (!string.IsNullOrEmpty(decodedText))
                        {
                            txtResult.Text = decodedText;
                            LogMessage($"QR-код расшифрован: {decodedText}");
                        }
                        else
                        {
                            string errorMsg = "QR-код не найден.";
                            MessageBox.Show(errorMsg);
                            LogMessage(errorMsg);
                        }
                    }
                    else
                    {
                        string errorMsg = "QR-код не найден.";
                        MessageBox.Show(errorMsg);
                        LogMessage(errorMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMsg = $"Ошибка при сканировании QR-кода: {ex.Message}";
                MessageBox.Show(errorMsg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogMessage(errorMsg);
            }
        }

        private void SaveText(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResult.Text))
            {
                string errorMsg = "Нет текста для сохранения.";
                MessageBox.Show(errorMsg);
                LogMessage(errorMsg);
                return;
            }

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, txtResult.Text);
                    LogMessage($"Текст сохранён: {saveFileDialog.FileName}");
                }
            }
            catch (Exception ex)
            {
                string errorMsg = $"Ошибка при сохранении файла: {ex.Message}";
                MessageBox.Show(errorMsg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogMessage(errorMsg);
            }
        }

        private void ToggleLanguage(object sender, EventArgs e)
        {
            currentLanguage = (currentLanguage == "ru") ? "en" : "ru";
            UpdateUI();
            LogMessage($"Язык переключён: {currentLanguage}");
        }

        private void UpdateUI()
        {
            Text = GetLocalizedText("QR-сканер", "QR Scanner");
            btnLoad.Text = GetLocalizedText("Загрузить изображение", "Load Image");
            btnScan.Text = GetLocalizedText("Сканировать", "Scan");
            btnSave.Text = GetLocalizedText("Сохранить текст", "Save Text");
            btnLanguage.Text = "EN / RU";
        }

        private string GetLocalizedText(string ruText, string enText)
        {
            return currentLanguage == "ru" ? ruText : enText;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
