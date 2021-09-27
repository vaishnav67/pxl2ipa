using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pxl2ipa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            textBox2.Text = saveFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(".\\PXL2IPATEMP");
            ZipFile.ExtractToDirectory(textBox1.Text, ".\\PXL2IPATEMP");
            List<string> plist = File.ReadAllLines(".\\PXL2IPATEMP\\PxlPkg.plist").ToList();
            Directory.CreateDirectory(".\\PXL2IPATEMP\\TheIpa");
            Directory.CreateDirectory(".\\PXL2IPATEMP\\TheIpa\\Payload");
            Directory.Move(".\\PXL2IPATEMP\\app", $".\\PXL2IPATEMP\\TheIpa\\Payload\\{textBox1.Text.Split('\\')[textBox1.Text.Split('\\').Length - 1]}.app");
            ZipFile.CreateFromDirectory(".\\PXL2IPATEMP\\TheIpa", textBox2.Text);
        }
    }
}
