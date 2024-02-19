using System.IO.Ports;

namespace GenericGecko
{
    public partial class GenericGecko : Form
    {
        private SerialPort? gecko;
        private bool shouldRead = true;

        public GenericGecko()
        {
            InitializeComponent();
        }

        void ConnectToGecko()
        {
            UpdateStatus("Connecting to Gecko...", false);
            gecko = new SerialPort();
            gecko.PortName = "COM7";//"COM3";
            gecko.BaudRate = 9600;
            gecko.ReadTimeout = 500;
            gecko.WriteTimeout = 500;
            gecko.Open();
            UpdateStatus("", true);
            Task.Run(ReadThread);
        }

        void ReadThread()
        {
            if (gecko == null) return;
            while (shouldRead)
            {
                try
                {
                    string read = gecko.ReadLine();
                    Invoke(() => console.AppendText(read + "\r\n"));
                }
                catch (TimeoutException)
                {

                }
            }
            Thread.Sleep(3500);
            Task.Run(ConnectToGecko);
        }

        void UpdateStatus(string status, bool buttons, int progStart = 0, int progEnd = 0)
        {
            Invoke(() =>
            {
                statusText.Text = status;
                bmButton.Enabled = buttons;
                wlButton.Enabled = buttons;
                if (progEnd != 0)
                {
                    progress.Visible = true;
                    bmButton.Visible = false;
                    wlButton.Visible = false;
                    progress.Value = progStart;
                    progress.Maximum = progEnd;
                }
                else
                {
                    progress.Visible = false;
                    bmButton.Visible = true;
                    wlButton.Visible = true;
                }
            });
        }

        private static int blocksize = 0xF800;
        void Wiiload(string file)
        {
            if (gecko == null) return;
            try
            {
                UpdateStatus("Initiating transfer...", false);
                string filename = Path.GetFileName(file);
                byte[] filecontent = File.ReadAllBytes(file);
                int filesize = filecontent.Length;
                byte[] startpacket = { (byte)'H', (byte)'A', (byte)'X', (byte)'X' };
                byte[] versionpacket = { 0x00, 0x05 /*wiiload 0.5*/, 0x00, (byte)filename.Length };
                byte[] sizepacket = BitConverter.GetBytes(filesize);
                Array.Reverse(sizepacket);
                //header
                gecko.Write(startpacket, 0, 4);
                //version + args len
                gecko.Write(versionpacket, 0, 4);
                //size (uncompress+compress)
                //TODO: actually compress
                gecko.Write(sizepacket, 0, 4);
                gecko.Write(sizepacket, 0, 4);
                int donebytes = 0;
                while (donebytes < filesize)
                {
                    int bytestoupload = blocksize;
                    if (filesize - donebytes < bytestoupload)
                        bytestoupload = filesize - donebytes;
                    UpdateStatus($"Uploading {filename}... ({donebytes}/{filesize} bytes)", false, donebytes, filesize);
                    gecko.Write(filecontent, donebytes, bytestoupload);
                    donebytes += bytestoupload;
                    Thread.Sleep(100);//no idea if this helps
                }
                UpdateStatus("Sending filename...", false);
                gecko.Write(filename);
                UpdateStatus("Done!", false);
                Thread.Sleep(1500);
                UpdateStatus("", true);
            }
            catch (TimeoutException)
            {
                shouldRead = false;
                UpdateStatus("Error sending file!", false);
            }
        }
        void BootMiiUpload(string file)
        {
            if (gecko == null) return;
            try
            {
                UpdateStatus("Initiating transfer...", false);
                string filename = Path.GetFileName(file);
                byte[] filecontent = File.ReadAllBytes(file);
                int filesize = filecontent.Length;
                byte[] startpacket = { (byte)'B', (byte)'A', (byte)'R', (byte)'M' };
                // if it's an ELF file then boot it
                if (filecontent[0] == 0x7F)
                    startpacket = new byte[] { (byte)'B', (byte)'P', (byte)'P', (byte)'C' };
                byte[] sizepacket = BitConverter.GetBytes(filesize);
                Array.Reverse(sizepacket);
                //header
                gecko.Write(startpacket, 0, 4);
                //size
                gecko.Write(sizepacket, 0, 4);
                int donebytes = 0;
                while (donebytes < filesize)
                {
                    int bytestoupload = blocksize;
                    if (filesize - donebytes < bytestoupload)
                        bytestoupload = filesize - donebytes;
                    UpdateStatus($"Uploading {filename}... ({donebytes}/{filesize} bytes)", false, donebytes, filesize);
                    gecko.Write(filecontent, donebytes, bytestoupload);
                    donebytes += bytestoupload;
                    Thread.Sleep(100);//no idea if this helps
                }
                UpdateStatus("Done!", false);
                Thread.Sleep(1500);
                UpdateStatus("", true);
            }
            catch (TimeoutException)
            {
                shouldRead = false;
                UpdateStatus("Error sending file!", false);
            }
        }

        private void GenericGecko_Load(object sender, EventArgs e)
        {
            Task.Run(ConnectToGecko);
        }

        private void wlButton_Click(object sender, EventArgs e)
        {
            DialogResult r = openFileDialog1.ShowDialog();
            if (r == DialogResult.OK)
            {
                Task.Run(() => Wiiload(openFileDialog1.FileName));
            }
        }

        private void bmButton_Click(object sender, EventArgs e)
        {
            DialogResult r = openFileDialog1.ShowDialog();
            if (r == DialogResult.OK)
            {
                Task.Run(() => BootMiiUpload(openFileDialog1.FileName));
            }
        }
    }
}