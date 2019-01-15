using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FileUpload.Client.FileUploadProxy;

namespace FileUpload.Client
{
    public partial class Form1 : Form
    {
        private readonly FileServiceClient client;

        public Form1()
        {
            InitializeComponent();
            client = new FileServiceClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (csvOpenDialog.ShowDialog() != DialogResult.OK) return;


            var fileInfo = new FileInfo(csvOpenDialog.FileName);
            if (cmboFileName.Items.Contains(fileInfo.Name))
            {
                MessageBox.Show("File already Exist");
                return;
            }

            var uploadRequestInfo = new RemoteFileInfo();

            using (
                var stream = new FileStream(fileInfo.FullName, FileMode.Open,
                    FileAccess.Read))
            {
                uploadRequestInfo.FileName = fileInfo.Name;
                uploadRequestInfo.Length = fileInfo.Length;
                uploadRequestInfo.FileByteStream = stream;
                client.UploadFile(uploadRequestInfo.FileName, uploadRequestInfo.Length,
                    uploadRequestInfo.FileByteStream);


                cmboFileName.Items.Add(fileInfo.Name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            if (cmboFileName.SelectedItem == null)
            {
                MessageBox.Show("Please Select File name");
                return;
            }
            var selectedFile = cmboFileName.SelectedItem.ToString();
            dataGridView1.DataSource = client.GetData(selectedFile);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var refData = client.GetAllFileName();
            var files = refData.FilesName.Select(i => Path.GetFileName(i)).ToArray();
            cmboFileName.Items.AddRange(files);
            sessionId.Text = $"Session Id :  {refData.SessionId}";
            var login = new frmLogin();
            login.OnLogin += (s, s1) => MessageBox.Show(client.Authenticate(s, s1));
            if (login.ShowDialog() != DialogResult.OK)
            {
               Application.Exit();
            }
        }
    }
}