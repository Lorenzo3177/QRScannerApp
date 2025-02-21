namespace QRScannerApp
{
    partial class QRScannerForm
    {
        private System.ComponentModel.IContainer components = null;

        #region Код, необходимый для конструктора формы

        /// <summary>
        /// Требуемая метод для поддержки конструктора формы.
        /// Не изменяйте содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLanguage = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();

            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(10, 10);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(300, 300);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;

            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(320, 10);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(150, 30);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Загрузить изображение";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.LoadImage);

            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(320, 50);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(150, 30);
            this.btnScan.TabIndex = 2;
            this.btnScan.Text = "Сканировать";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.ScanQRCode);

            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(10, 320);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(460, 50);
            this.txtResult.TabIndex = 3;

            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(320, 90);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Сохранить текст";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.SaveText);

            // 
            // btnLanguage
            // 
            this.btnLanguage.Location = new System.Drawing.Point(320, 130);
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.Size = new System.Drawing.Size(150, 30);
            this.btnLanguage.TabIndex = 5;
            this.btnLanguage.Text = "EN / RU";
            this.btnLanguage.UseVisualStyleBackColor = true;
            this.btnLanguage.Click += new System.EventHandler(this.ToggleLanguage);

            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";

            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "saveFileDialog";

            // 
            // QRScannerForm
            // 
            this.ClientSize = new System.Drawing.Size(484, 381);
            this.Controls.Add(this.btnLanguage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.pictureBox);
            this.Name = "QRScannerForm";
            this.Text = "QR Scanner";

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLanguage;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}
