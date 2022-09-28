using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Final_topic
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            label1.Text = "建立目錄或檔案 :(請由上往下按)";
            button1.Text = "選擇路徑";
            label2.Text = "輸入目錄名稱";
            label3.Text = "輸入檔案名稱";
            button2.Text = "建立目錄";
            button3.Text = "建立檔案";
            label4.Text = "下方請輸入想對自己說的話(secret)";
            button4.Text = "讀取檔案內容";
            button5.Text = "將 secret 輸入檔案";
        }
        string path = "";

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
            path += textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
            dir.CreateSubdirectory(textBox2.Text);
            path += "\\" + textBox2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string p1 = path + "\\" + textBox3.Text;
            FileInfo f = new FileInfo(p1);
            FileStream fs = f.Create();
            fs.Close();
            //f.Create();
            path += "\\" + textBox3.Text;
            
        }


        private void button4_Click(object sender, EventArgs e)
        {
            //path = textBox1.Text + "\\" + textBox2.Text + "\\" + textBox3.Text;
            //openFileDialog1.InitialDirectory = "D:\\Tim\\Desktop";
            //openFileDialog1.ShowDialog();
            openFileDialog1.FileName = path;
            //openFileDialog1.FileName = textBox1.Text + "\\" + textBox2.Text + "\\" + textBox3.Text;
            //path = openFileDialog1.FileName;
            FileInfo f = new FileInfo(openFileDialog1.FileName);
            StreamReader sr = f.OpenText();
            while (sr.Peek() >= 0)
            {
                richTextBox1.Text += sr.ReadLine() + "\n";
            }
            sr.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = path;
            FileInfo f = new FileInfo(saveFileDialog1.FileName);
            StreamWriter sw = f.AppendText();
            sw.WriteLine(richTextBox1.Text);
            sw.Close();
            //openFileDialog1.InitialDirectory = path;
            //openFileDialog1.ShowDialog();
            MessageBox.Show("修改成功");
        }
    }
}
