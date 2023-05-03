using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using static System.Windows.Forms.AxHost;

namespace Prac_14_3_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Output_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            bool flag = true;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Заполните поле ввода данных");
                flag = false;
            }
            else
            {
                for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    if (!Char.IsDigit(textBox1.Text[i]))
                    {
                        MessageBox.Show("Введите только числа");
                        flag = false;
                    }
                }
            }
            if (flag == true)
            {
                string num = textBox1.Text;
                int n = int.Parse(num);
                Queue<int> queue = new Queue<int>();
                for (int i = 1; i <= n; i++)
                {
                    queue.Enqueue(i);
                }
                foreach (var count in queue)
                {
                    label2.Text = label2.Text + $"{count} ";
                }
            }
        }

        private void zadanie4_Click(object sender, EventArgs e)
        {
            Queue molodye = new Queue();
            Queue starye = new Queue();
            if (File.Exists("text.txt"))
            {
                listBox1.Items.Clear();

                StreamReader sr = File.OpenText("text.txt");
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    string[] ss = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string fam = ss[0];
                    string name = ss[1];
                    string otch = ss[2];
                    int old = int.Parse(ss[3]);
                    double ves = double.Parse(ss[4]);
                    if (old < 40)
                    {
                        molodye.Enqueue($"{fam} {name} {otch} {old} {ves}");
                    }
                    else
                    {
                        starye.Enqueue($"{fam} {name} {otch} {old} {ves}");
                    }
                }
                sr.Close();
                foreach (string pers in molodye)
                {
                    listBox1.Items.Add(pers);
                }
                foreach (string pers in starye)
                {
                    listBox1.Items.Add(pers);
                }

            }

        }

        private void zadanie5_Click(object sender, EventArgs e)
        {
            Queue people = new Queue();
            if (File.Exists("text.txt"))
            {
                listBox2.Items.Clear();

                StreamReader sr = File.OpenText("text.txt");
                while (!sr.EndOfStream)
                {
                   people.Enqueue(sr.ReadLine());
                }
                sr.Close();
                people = new Queue<string>(people.OrderBy(p => int.Parse(p.Split()[3])));
                Queue sortedPeople = new Queue();

                foreach (string person in people)
                {
                    string[] parts = person.Split();
                    sortedPeople.Enqueue($"{parts[0]} {parts[1]} {parts[2]}, возраст: {parts[3]}, вес: {parts[4]}");
                }
                foreach (string person in sortedPeople) { listBox2.Items.Add(person); }

            }
        }
    }
}
