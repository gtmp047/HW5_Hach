using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW5_Hach
{
    public partial class Form1 : Form
    {
        byte mode = 0;
        int sizeOfHash = 10; // так захотел ^^
        int hashModule = 10;
        double factorOfFullment = 0.8; // испотзуется при генерации; Процент заполнения

        TreeNode FindElement(TreeNodeCollection arr, string str) // хз почему но стандартный метод не робит
        {
            foreach (TreeNode item in arr)
            {
                if (item.Text.CompareTo(str) == 0)
                    return item;
            }
            return null;
        }
        int AddToHash (String str)
        {
            int value = Math.Abs(str.GetHashCode()) % hashModule;
            switch (mode)
            {
                case 0:
                    if (treeView1.Nodes[value].Text.CompareTo("") == 0)
                    {
                        treeView1.Nodes[value].Text = str;
                        return 0;
                    }
                    else
                    {
                        if (FindElement(treeView1.Nodes[value].Nodes, str) == null && treeView1.Nodes[value].Text.CompareTo(str) != 0)
                        {
                            treeView1.Nodes[value].Nodes.Add(str);
                            return 1;
                        }
                        else
                        {
                            MessageBox.Show("Элемент найден");
                            return -1;
                        }
                    }
                        break;
                case 1:
                    if (treeView1.Nodes[value].Text.CompareTo("") == 0)
                    {
                        treeView1.Nodes[value].Text = str;
                        return 0;
                    }
                    else
                    {
                        if (treeView1.Nodes[value].Text.CompareTo(str) == 0)
                        {
                            MessageBox.Show("Элемент найден");
                            return -1;
                        } 
                        for (int i = 0; i < treeView1.Nodes.Count; i++)
                        {
                            if(treeView1.Nodes[i].Text.CompareTo("") == 0)
                            {
                                treeView1.Nodes[i].Text = str;
                                return 1;
                            }
                        }
                    MessageBox.Show("Добавить элемент не удалось, так как все позиции заняты");
                    }
                    break;
                default:
                    break;
            }
            return 0;
        }
        void generateDataLine()
        {
            Random rn = new Random(((TimeSpan)(DateTime.Now - new DateTime(1970, 1, 1))).Seconds);
            int count = (int)(sizeOfHash * factorOfFullment);
            int lenghtOfWord = rn.Next(1, 8);

            for (int i = 0; i < count; i++)
            {
                string str = "";
                for (int y = 0; y < lenghtOfWord; y++)
                {
                    str += (char)rn.Next((int)'a', (int)'z');
                }
                treeView1.Nodes[i].Text = str;
                lenghtOfWord = rn.Next(1, 8);
            }
        }
        void generateData()
        {

            Random rn = new Random(((TimeSpan)(DateTime.Now - new DateTime(1970, 1, 1))).Seconds);
            int count = (int)(sizeOfHash * factorOfFullment);
            int lenghtOfWord = rn.Next(1,5);

            for (int i = 0; i < count; i++)
            {
                string str = "";
                for (int y = 0; y < lenghtOfWord; y++)
                {
                    str += (char)rn.Next((int)'a', (int)'z');
                }
                AddToHash(str);
                lenghtOfWord = rn.Next(1, 5);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор - Бурыгин Антон");
        }

        private void radiobutton1_CheckedChanged(object sender, EventArgs e)
        {
            mode = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            mode = 1;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            for (int i = 0; i < sizeOfHash; i++)
            {
                treeView1.Nodes.Add("");
            }
            switch (mode)
            {
                case 0:
                    generateData();
                    break;
                case 1:
                    generateDataLine();
                    break;
                default:
                    break;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            for (int i = 0; i < sizeOfHash; i++)
            {
                treeView1.Nodes.Add("");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                sizeOfHash = int.Parse(textBox1.Text);
                hashModule = int.Parse(textBox2.Text);
                factorOfFullment = double.Parse(textBox3.Text);
                if (hashModule > sizeOfHash)
                    throw new Exception("Модуль не может быть больше размера");
                if (factorOfFullment > 1.0)
                    throw new Exception("Коэфицент должен лежать в пределах 0-1");
                treeView1.Nodes.Clear();
                for (int i = 0; i < sizeOfHash; i++)
                {
                    treeView1.Nodes.Add("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int res = AddToHash(textBox4.Text);
                switch (res)
                {
                    case 0:
                        MessageBox.Show("Элемент добавлен");
                        break;
                    case -1:
                        MessageBox.Show("Элемент добавлен с разрешением коллизии");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < sizeOfHash; i++)
            {
                treeView1.Nodes.Add("");
            }
        }
    }
}
