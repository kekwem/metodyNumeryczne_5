using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calkowanie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double funkcja(double x)
        {
            //x^3-2x^2+x-1
            return Math.Sqrt(x + 1);//Math.Pow(x, 3) - 2 * Math.Pow(x, 2) + x - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = Double.Parse(textBox1.Text);
            double b = Double.Parse(textBox2.Text);
            double h = Double.Parse(textBox3.Text);
            int liczba = 0;
            double bufer = a;
            do
            {
                liczba++;
                bufer += h;
            } while (bufer <= b);
            double[,] tablica = new double[liczba, 2];
            bufer = a;
            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                tablica[i, 0] = bufer;
                bufer += h;
            }
            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                tablica[i, 1] = funkcja(tablica[i, 0]);
            }
            label1.Text = "";
            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                for (int j = 0; j < tablica.GetLength(1); j++)
                {
                    label1.Text += tablica[i, j] + "   ";
                }
                label1.Text += "\n";
            }
            double first = tablica[0, 1] / 2;
            double last = tablica[tablica.GetLength(0) - 1, 1] / 2;
            double suma_mnozenia = 0;
            for (int i = 1; i < tablica.GetLength(0) - 1; i++)
            {
                suma_mnozenia += tablica[i, 1];
            }
            suma_mnozenia += first;
            suma_mnozenia += last;
            double k_x = h * suma_mnozenia;
            label2.Text = "K(x) = " + k_x.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double a = Double.Parse(textBox1.Text);
            double b = Double.Parse(textBox2.Text);
            double h = Double.Parse(textBox3.Text);
            int liczba = 0;
            double bufer = a;
            do
            {
                liczba++;
                bufer += h;
            } while (bufer <= b);
            double[,] tablica = new double[liczba, 4];
            bufer = a;
            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                tablica[i, 0] = bufer;
                bufer += h;
            }
            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                tablica[i, 1] = funkcja(tablica[i, 0]);
            }
            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                tablica[i, 2] = tablica[i, 1] * 2;
            }
            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                tablica[i, 3] = tablica[i, 1] * 4;
            }
            //
            double suma = 0;
            suma += tablica[0, 1];
            suma += tablica[tablica.GetLength(0) - 1, 1];

            for (int i = 1; i < tablica.GetLength(0) - 1; i++)
            {
                if (i % 2 == 0)
                {
                    suma += tablica[i, 2];
                }
                else
                {
                    suma += tablica[i, 3];
                }
            }
            double final = (h / 3) * suma;
            //
            label1.Text = "";
            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                for (int j = 0; j < tablica.GetLength(1); j++)
                {
                    label1.Text += tablica[i, j] + " ";
                }
                label1.Text += '\n';
            }
            label2.Text = "K(x) = " + final.ToString();
        }
    }
}
