using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryGame777
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rand = new Random();
        Random rand2 = new Random();
        string prev = "0"; 

        private string generate(int lvl)
        {
            double k;
            do { k = Math.Pow(2, rand.Next(8)); }
            while (k.ToString() == prev);
            switch (lvl)
            {
                case 2: k++;
                    break;
                case 3: k += Math.Pow(2, rand2.Next(5));
                    break;
                case 4: k += rand.Next(256 - Convert.ToInt32(k));
                    break;
            };
            prev = k.ToString();
            return prev;
        }


        const int N = 6;
        const int M = 8;
        Button[,] mas = new Button[N, M];
        Label[,] lbl = new Label[N, 2];
        int v = -1; // индекс видимого ряда

        private void Form1_Load(object sender, EventArgs e)
        {
            int left = 60, top = 50;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    mas[i, j] = new Button();
                    mas[i, j].Name = "btn_" + i + "_" + (7 - j);
                    mas[i, j].Top = top;
                    mas[i, j].Left = left;
                    mas[i, j].Text = "0";
                    mas[i, j].Width = 50;
                    mas[i, j].Height = 50;
                    mas[i, j].Click += btn_click;
                    mas[i, j].Visible = false;
                    Controls.Add(mas[i, j]);
                    //mas[i, j].BringToFront();
                    left += 60;
                }
                lbl[i, 0] = new Label();
                lbl[i, 0].Name = "lbl_" + i + "_" + 0;
                lbl[i, 0].Top = top + 20;
                lbl[i, 0].Left = 20;
                lbl[i, 0].AutoSize = true;
                lbl[i, 0].Text = generate(y1);
                lbl[i, 0].Visible = false;
                //lbl[i, 0].BringToFront();
                Controls.Add(lbl[i, 0]);

                lbl[i, 1] = new Label();
                lbl[i, 1].Name = "lbl_" + i + "_" + 0;
                lbl[i, 1].Top = top + 20;
                lbl[i, 1].Left = mas[i, M - 1].Left + 10 + mas[i, M - 1].Width;
                lbl[i, 1].AutoSize = true;
                lbl[i, 1].Text = "0";
                lbl[i, 1].Visible = false;
                //lbl[i, 1].BringToFront();
                Controls.Add(lbl[i, 1]);
                top += 60;
                left = 60;
            }
            label1.Text = "Очки: " + p;
            pictureBox1.SendToBack();
            if (v == 6)
            {
                Application.Exit();
                this.Close();
            }
        }

        int p = 0;

        private void btn_click(object sender, EventArgs e)
        {
            int x, y;
            double k = 0;
            x = Convert.ToInt32((sender as Button).Name.Split('_')[1]);
            y = 7 - Convert.ToInt32((sender as Button).Name.Split('_')[2]);
            if (mas[x, y].Text == "0")
                mas[x, y].Text = "1";
            else mas[x, y].Text = "0";
                for (int j = 0; j < M; j++)
                {
                    if (mas[x,j].Text == "1")
                    k += Math.Pow(2, Convert.ToInt32(mas[x, j].Name.Split('_')[2]));
                }
            lbl[x, 1].Text = k.ToString();
            if (lbl[x, 0].Text == lbl[x, 1].Text)
            {
                for (int i = x; i < N - 1; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        mas[i, j].Text = mas[i + 1, j].Text;
                    }
                    lbl[i, 0].Text = lbl[i + 1, 0].Text;
                    lbl[i, 1].Text = lbl[i + 1, 1].Text;
                    
                }
                p += 100 * y1;
                //скрывает ряд кнопок
                if (v >= 0)
                {
                    for (int j = 0; j < M; j++)
                        mas[v, j].Visible = false;
                    lbl[v, 0].Visible = false;
                    lbl[v, 1].Visible = false;
                    v--;
                }
            }
            //else
              //  p -= 25 * y1;
            label1.Text = "Очки: " + p;
        }

        private void Form1_Click(object sender, EventArgs e)
        { // делает видимыми кнопки
            
        }


        int t = 0;
        int y1 = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 4000 + rand.Next(200);
            if (v < N - 1)
            {
                v++;
                for (int j = 0; j < M; j++)
                {
                    mas[v, j].Visible = true;
                    mas[v, j].Text = "0";
                }
                lbl[v, 0].Visible = true;
                lbl[v, 1].Visible = true;
                lbl[v, 0].Text = generate(y1);
                lbl[v, 1].Text = "0";

                t++;

                if (t == 10) y1 = 2;
                else if (t == 20) y1 = 3;
                else if (t == 30) y1 = 4;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
