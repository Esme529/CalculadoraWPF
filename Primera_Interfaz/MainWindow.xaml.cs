using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Data;

namespace Primera_Interfaz
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Pantalla.Text = "0";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button Numero = (Button)sender;

            if (Numero.Content.ToString() == "." && Cadena.Count > 0)
            {
                if (!Regex.IsMatch(Cadena.Peek(), "[.]")) //Verifica que no hayan dos puntos de seguidos
                {
                    Pantalla.Text = Pantalla.Text + Numero.Content;
                    Cadena.Push(Numero.Content.ToString());
                }
            }

            else if (Numero.Content.ToString() == "+" && Cadena.Count > 0)
            {
                if (!Regex.IsMatch(Cadena.Peek(), "[-+*/.]"))
                { 
                    Pantalla.Text = Pantalla.Text + Numero.Content;
                    Cadena.Push(Numero.Content.ToString());
                }

            }

            else if(Numero.Content.ToString() == "-" && Cadena.Count > 0)
            {
                if (!Regex.IsMatch(Cadena.Peek(), "[-+*/.]"))
                {
                    Pantalla.Text = Pantalla.Text + Numero.Content;
                    Cadena.Push(Numero.Content.ToString());
                }

            }

            else if(Numero.Content.ToString() == "*" && Cadena.Count > 0)
            {
                if (!Regex.IsMatch(Cadena.Peek(), "[-+*/.]"))
                {
                    Pantalla.Text = Pantalla.Text + Numero.Content;
                    Cadena.Push(Numero.Content.ToString());
                }

            }

            else if(Numero.Content.ToString() == "/" && Cadena.Count > 0)
            {
                if (!Regex.IsMatch(Cadena.Peek(), "[-+*/.]"))
                {
                    Pantalla.Text = Pantalla.Text + Numero.Content;
                    Cadena.Push(Numero.Content.ToString());
                }

            }

            else if (!Regex.IsMatch(Numero.Content.ToString(), "[-+*/.]"))
            {
                if (Pantalla.Text == "0" || Pantalla.Text == Convert.ToString(Resultado)) Pantalla.Text = ""; //No deja colocar 0 al principio
                
                Pantalla.Text = Pantalla.Text + Numero.Content;
                Cadena.Push(Numero.Content.ToString());
            }

        }

        private void Button_Click_Borrar(object sender, RoutedEventArgs e)
        {
            Pantalla.Text = "0";
            Cadena.Clear();
        }

        private void Button_Click_Retroceder(object sender, RoutedEventArgs e)
        {
            if (Pantalla.Text == "" || Pantalla.Text == Convert.ToString(Resultado)) Pantalla.Text = "0";

            else if (Pantalla.Text.Length > 0)
            {
                Pantalla.Text = Pantalla.Text.Remove(Pantalla.Text.Length - 1, 1);
                if (Cadena.Count > 0) Cadena.Pop();
            }           
        }


        private void Button_Click_Igual(object sender, RoutedEventArgs e)
        {
            int Contador = Cadena.Count;

            for (int i = 0; i < Contador; i++)
            {
                DePaso = DePaso + Cadena.Pop();
            }

            string NuevaCadena = Invertir(DePaso);

            Resultado = Convert.ToDouble(new DataTable().Compute(NuevaCadena, null));

            Pantalla.Text = Convert.ToString(Resultado);

            DePaso = "";
        }

        static string Invertir(string text)
        {
            char[] charArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = charArray.Length - 1; i >= 0; i--)
            {
                reverse += charArray[i];
            }
            return reverse;
        }

        string DePaso; double Resultado;
        Stack<string> Cadena = new Stack<string>();

    }
}

