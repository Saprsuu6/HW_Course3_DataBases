using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoppingFiles
{
    public partial class Form1 : Form
    {
        private uint limit = 4096;
        private string fileName;

        public Form1()
        {
            InitializeComponent();
        }

        private void BrowseFrom_Click(object sender, EventArgs e)
        {
            if (OpneFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = OpneFile.FileName;
                fileName = Path.GetFileName(filePath);
                int index = fileName.IndexOf('.');
                fileName = fileName.Insert(index, "_Copy");
                From.Text = filePath;
            }
        }

        private void BrowseTo_Click(object sender, EventArgs e)
        {
            if (OpenFolder.ShowDialog() == DialogResult.OK)
            {
                string filePath = OpenFolder.SelectedPath;
                To.Text = filePath;
            }
        }

        private byte[] Read()
        {
            return File.ReadAllBytes(From.Text);
        }

        private void WriteToFile(byte[] bytes)
        {
            string path = To.Text + "\\" + fileName;

            using (FileStream stream = File.Open(path, FileMode.OpenOrCreate))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    uint counter = 0;
                    uint temp = 0;
                    uint i = 0;

                    while (counter < bytes.Length)
                    {
                        byte[] buffer = new byte[limit];

                        for (i = 0; i < limit; i++)
                        {
                            if (i + counter == bytes.Length)
                                break;

                            buffer[i] = bytes[i + counter];
                            temp++;
                        }

                        counter = temp;
                        writer.Write(buffer);

                        Progress.Invoke(
                            new Action(() => Progress.Value += Progress.Step));
                    }

                    Progress.Invoke(
                        new Action(() => Progress.Value = 0));
                }
            }
        }

        private async void CoppyFile()
        {
            byte[] bytes = await Task.Run(() => Read());

            Progress.Invoke(
                new Action(() => Progress.Maximum = bytes.Length * (int)limit));
            Progress.Invoke(
                 new Action(() => Progress.Step = (int)limit));

            if (bytes.Length <= 4096)
                MessageBox.Show("File size less then 4096", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("File size more then 4096", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            await Task.Run(() => WriteToFile(bytes));

            MessageBox.Show("File was copyed", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            Task.Run(() => CoppyFile());
        }
    }
}
