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

        const int N = 6;
        const int M = 8;
        Button[,] mas = new Button[N, M];
        Label[,] lbl = new Label[N, 2];
        int v = 5; // индекс видимого ряда

        private void Form1_Load(object sender, EventArgs e)
        {
            int left = 60, top = 10;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    mas[i, j] = new Button();
                    mas[i, j].Name = "btn_" + i + "_" + j;
                    mas[i, j].Top = top;
                    mas[i, j].Left = left;
                    mas[i, j].Text = i + "_" + j;
                    mas[i, j].Width = 50;
                    mas[i, j].Height = 50;
                    mas[i, j].Click += btn_click;
                    Controls.Add(mas[i, j]);
                    left += 60;
                }
                lbl[i, 0] = new Label();
                lbl[i, 0].Name = "lbl_" + i + "_" + 0;
                lbl[i, 0].Top = top + 20;
                lbl[i, 0].Left = 20;
                lbl[i, 0].AutoSize = true;
                lbl[i, 0].Text = i + " 0"; // random.next();
                Controls.Add(lbl[i, 0]);

                lbl[i, 1] = new Label();
                lbl[i, 1].Name = "lbl_" + i + "_" + 0;
                lbl[i, 1].Top = top + 20;
                lbl[i, 1].Left = mas[i, M - 1].Left + 10 + mas[i, M - 1].Width;
                lbl[i, 1].AutoSize = true;
                lbl[i, 1].Text = i + " 1"; // random.next();
                Controls.Add(lbl[i, 1]);
                top += 60;
                left = 60;
            }
        }

        private void btn_click(object sender, EventArgs e)
        {
            int x, y;
            x = Convert.ToInt32((sender as Button).Name.Split('_')[1]);
            y = Convert.ToInt32((sender as Button).Name.Split('_')[2]);
            for (int i = x; i < N - 1; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    mas[i, j].Text = mas[i + 1, j].Text;
                }
                lbl[i, 0].Text = lbl[i + 1, 0].Text;
                lbl[i, 1].Text = lbl[i + 1, 1].Text;
            }

            // скрывает ряд кнопок
            if (v > 0)
            {
                for (int j = 0; j < M; j++)
                    mas[v, j].Visible = false;
                lbl[v, 0].Visible = false;
                lbl[v, 1].Visible = false;
                v--;
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        { // делает видимыми кнопки
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
                lbl[v, 0].Text = "0";
                lbl[v, 1].Text = "1";
                ActiveForm.Text = v.ToString();
            }
        }
    }
}
