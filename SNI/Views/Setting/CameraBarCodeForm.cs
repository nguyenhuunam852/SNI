using System;
using System.Windows.Forms;
using TouchlessLib;
using System.Drawing;
using System.Diagnostics;
using ZXing;

namespace SNI.Views.Setting
{
    public partial class CameraBarCodeForm : Form
    {
        private TouchlessMgr _touch;
        private const int _previewWidth = 640;
        private const int _previewHeight = 480;

        public CameraBarCodeForm()
        {
            InitializeComponent();
            // Initialize Touchless
        }
        Timer timer1;
        private void StartCamera()
        {
            _touch = new TouchlessMgr();
            
            if (_touch.Cameras.Count == 0)
            {
                MessageBox.Show("No USB webcam connected");
                return;
            }
           

            // Start to acquire images
            _touch.CurrentCamera = _touch.Cameras[0];
            _touch.CurrentCamera.CaptureWidth = _previewWidth; // Set width
            _touch.CurrentCamera.CaptureWidth = _previewHeight; // Set height
            _touch.CurrentCamera.OnImageCaptured += new EventHandler<CameraEventArgs>(OnImageCaptured); // Set preview callback function

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
          
        }

        private void OnImageCaptured(object sender, CameraEventArgs args)
        {
            
                Bitmap bitmap = args.Image;
       
                pictureBox1.Image = bitmap;
        }
        private void StopCamera()
        {
            if (_touch.CurrentCamera != null)
            {
                _touch.CurrentCamera.OnImageCaptured -= new EventHandler<CameraEventArgs>(OnImageCaptured);
            }
            _touch.Dispose();
        }
        private void ReadBarcode(Bitmap img)
        {
            if (img != null)
            {
                BarcodeReader Reader = new BarcodeReader();
                Result result = Reader.Decode(img);
                try
                {
                    string decoded = result.ToString().Trim();
                    textBox1.Text = decoded;
                    img.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "");
                }

            }
        }

        private void CameraBarCodeForm_Load(object sender, EventArgs e)
        {
            StartCamera();
            this.FormClosing += CameraBarCodeForm_FormClosing;
        }

        private void CameraBarCodeForm_FormClosed1(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CameraBarCodeForm_FormClosing1(object sender, FormClosingEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CameraBarCodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
        }

        private void CameraBarCodeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopCamera();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please load an image!");
                return;
            }

            ReadBarcode((Bitmap)pictureBox1.Image);
        }
    }
}
