using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_topic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Text = "請選擇數字 10 ~ 20";
            label1.Visible = false;
            button1.Visible = false;
            label2.Text = "請點擊上方按鈕\r\n將有遊戲規則說明";
            label2.Visible = false;
            label3.Visible = false;
            label3.Text = "您的目前分數為 :";
            label4.Visible = false;
            label4.Text = "0";
        }
        static private int[] n1 = new int[30];
        static private int[] a1 = { };
        Random r = new Random();

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string t = comboBox1.SelectedItem.ToString();
            label1.Text = t;
            label1.Visible = true;
            button1.Text = "您選擇的數字為 " + t;
            button1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            button2.Text = "??";
            button3.Text = "??";
            button4.Text = "??";
            button5.Text = "??";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("這是個套圈圈小遊戲\r\n按鈕內為您選擇的數字\r\n" +
               "請將下方的數字拖移到右方的框框內\r\n每個框框內的數字範圍皆不同\r\n舉例 :" +
               "\r\n若您選擇15\r\n則第一個框框的範圍為14 ~ 16\r\n第二個為13 ~ 17\r\n" +
               "以此類推\r\n若選中，得到分數也不同\r\n第一個框框得分為5分，第二個為15分，皆向上加10\r\n" +
               "若沒選中，失分皆為5分\r\np.s.每玩一次框框內數字皆會變動，建議別記數字\r\n\r\n祝您玩的愉快");
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(label1.Text, DragDropEffects.Copy);
        }

        
        private void button_DragEnter(object sender, DragEventArgs e)
        {
            //MessageBox.Show(((Button)sender).Name.ToString());
            e.Effect = DragDropEffects.Copy;
            //MessageBox.Show(e.ToString());
        }

        int sum = 0;
        private void button_DragDrop(object sender, DragEventArgs e)
        {
            //List<Button> myBtn = new List<Button> { button2, button3, button4, button5 };
            int num = int.Parse(e.Data.GetData(DataFormats.Text).ToString());
            //MessageBox.Show(num.ToString());
            String oneBtn = ((Button)sender).Name.ToString();
            int a = 0;
            switch (oneBtn) {
                case "button2":
                    a = r.Next(num - 1, num + 2);
                    if (a == num)
                    {
                        sum += 5;
                    }
                    else
                    {
                        sum -= 5;
                    }
                    break;
                case "button3":
                    a = r.Next(num - 2, num + 3);
                    if (a == num)
                    {
                        sum += 15;
                    }
                    else
                    {
                        sum -= 5;
                    }
                    break;
                case "button4":
                    a = r.Next(num - 3, num + 4);
                    if (a == num)
                    {
                        sum += 25;
                    }
                    else
                    {
                        sum -= 5;
                    }
                    break;
                case "button5":
                    a = r.Next(num - 4, num + 5);
                    if (a == num)
                    {
                        sum += 35;
                    }
                    else
                    {
                        sum -= 5;
                    }
                    break;
            }
            MessageBox.Show("按鈕內數字為" + a.ToString() + "\r\n您的分數變為"+ sum.ToString());
            label4.Text = sum.ToString();
        }
    }
}
