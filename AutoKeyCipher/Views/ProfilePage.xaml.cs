using AutoKeyCipher.ViewModels;
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

namespace AutoKeyCipher.Views
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : UserControl
    {

        private string m = " ABCDEFGHIJKLMNOPQRSTUVWXYZAABCDEFGHIJKLMNOPQRSTUVWXYZBBCDEFGHIJKLMNOPQRSTUVWXYZACCDEFGHIJKLMNOPQRSTUVWXYZAB" +
                    "DDEFGHIJKLMNOPQRSTUVWXYZABCEEFGHIJKLMNOPQRSTUVWXYZABCDFFGHIJKLMNOPQRSTUVWXYZABCDEGGHIJKLMNOPQRSTUVWXYZ" +
          "ABCDEFHHIJKLMNOPQRSTUVWXYZABCDEFGIIJKLMNOPQRSTUVWXYZABCDEFGHJJKLMNOPQRSTUVWXYZABCDEFGHIKKLMNOPQRSTUVWXYZ" +
          "ABCDEFGHIJLLMNOPQRSTUVWXYZABCDEFGHIJKMMNOPQRSTUVWXYZABCDEFGHIJKLNNOPQRSTUVWXYZABCDEFGHIJKLMOOPQRSTUVWXYZ" +
          "ABCDEFGHIJKLMNPPQRSTUVWXYZABCDEFGHIJKLMNOQQRSTUVWXYZABCDEFGHIJKLMNOPRRSTUVWXYZABCDEFGHIJKLMNOPQSSTUVWXYZ" +
           "ABCDEFGHIJKLMNOPQRTTUVWXYZABCDEFGHIJKLMNOPQRSUUVWXYZABCDEFGHIJKLMNOPQRSTVVWXYZABCDEFGHIJKLMNOPQRSTUWWXYZ" +
          "ABCDEFGHIJKLMNOPQRSTUVXXYZABCDEFGHIJKLMNOPQRSTUVWYYZABCDEFGHIJKLMNOPQRSTUVWXZZABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int vrsta, kolona;
        int brojac = 0;
        string encrypt;
        private static String alphabet
    = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public ProfilePage()
        {
            InitializeComponent();
             CreateMatrix();



        }
        private void CreateMatrix()
        {

            char[] characters = m.ToCharArray();

            int brojVrsta = 27;
            int brojKolona = 27;
            char[,] matrica = new char[brojVrsta, brojKolona];

            int brojac = 0;
            for (int i = 0; i < brojVrsta; i++)
            {
                for (int j = 0; j < brojKolona; j++)
                {
                    matrica[i, j] = characters[brojac];
                    brojac++;
                }
            }

            for (int i = 0; i < 28; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                MatrixGrid.RowDefinitions.Add(rowDef);

                ColumnDefinition colDef = new ColumnDefinition();
                MatrixGrid.ColumnDefinitions.Add(colDef);
            }

            // dodavanje elemenata u matricu
            for (int i = 0; i < 27; i++)
            {
                for (int j = 0; j < 27; j++)
                {

                    TextBlock T = new TextBlock();

                    T.FontSize = 9;


                    T.Text = $"{matrica[i, j]}";




                    Grid.SetRow(T, i);
                    Grid.SetColumn(T, j);

                    MatrixGrid.Children.Add(T);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Bord.Visibility = Visibility.Visible;
            StartD.Visibility = Visibility.Collapsed;
            StepOver.Visibility = Visibility.Visible;
            Skip.Visibility = Visibility.Visible;
            t.Visibility = Visibility.Visible;
            Start.Visibility = Visibility.Collapsed;



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            
            
            string plainText = Pltxt.Text.Replace(" ", "");
            string autoKey = Keytxt.Text;

               if (plainText.Length == 0)
            {

                PlaintxtError.Text = "Moraju biti popunjena sva polja";
                PlaintxtError.Foreground = Brushes.Red;
            }
            else if (autoKey.Length == 0)
            {

                KeytxtError.Text = "Moraju biti popunjena sva polja";
                KeytxtError.Foreground = Brushes.Red;
            }
            else  if (autoKey.Contains(" "))
            {
                KeytxtError.Text = "Ključ mora biti jedna reč";
                KeytxtError.Foreground = Brushes.Red;
            }
            else if (autoKey.Length > plainText.Length)
            {
                KeytxtError.Text = "Ključ mora biti manje dužine od samog texta";
                KeytxtError.Foreground = Brushes.Red;
            }
            
          
            else
            {
                PlaintxtError.Text = "";
                KeytxtError.Text = "";
                // generating the keystream
                string newKey = autoKey + plainText;



                string k = newKey.Replace(" ", "");

                k = k.Substring(0, k.Length
              - autoKey.Length);

                k = k.Substring(0, k.Length);

                Autokey.Text = k.ToUpper();
                PlainText.Text = plainText.ToUpper().Replace(" ", "");





                StartD.Visibility = Visibility.Visible;
            }
        }

        public void vratiPoz()
        {

            string autokey = Autokey.Text;
            string plainText = PlainText.Text;


            if (brojac < autokey.Length)
            {
                int first = alphabet.IndexOf(plainText[brojac]) + 1;//index vrste
                int second = alphabet.IndexOf(autokey[brojac]);//index kol


                vrsta = first;
                kolona = second + 1;

                int index = (first + second - 1) % 26;

                encrypt += alphabet[index];





                brojac += 1;



            }

        }

        private async void Skip_Click(object sender, RoutedEventArgs e)
        {



            char[] characters = m.ToCharArray();


            int brojVrsta = 27;
            int brojKolona = 27;
            char[,] dvodi = new char[brojVrsta, brojKolona];

            int brojac = 0;
            for (int i = 0; i < brojVrsta; i++)
            {
                for (int j = 0; j < brojKolona; j++)
                {
                    dvodi[i, j] = characters[brojac];
                    brojac++;
                }
            }
            // dodavanje elemenata u matricu
            string l = PlainText.Text;
            vratiPoz();


            for (int k = 0; k < l.Length; k++)
            {


                for (int i = 0; i < 27; i++)
                {
                    for (int j = 0; j < 27; j++)
                    {
                        if (i == vrsta && j == kolona)
                        {



                            TextBlock T = new TextBlock();

                            T.FontSize = 9;

                            T.Text = $"{dvodi[i, j - 1]}";
                            T.Foreground = Brushes.White;
                            T.Background = Brushes.Red;






                            Grid.SetRow(T, i);

                            Grid.SetColumn(T, j);


                            MatrixGrid.Children.Add(T);



                        }
                        if (i == 0 && j == kolona)
                        {
                            TextBlock T = new TextBlock();

                            T.FontSize = 9;

                            T.Text = $"{dvodi[i, j]}";
                            T.Foreground = Brushes.White;
                            T.Background = Brushes.Cyan;
                            Grid.SetRow(T, i);

                            Grid.SetColumn(T, j);


                            MatrixGrid.Children.Add(T);

                        }
                        if (j == 0 && i == vrsta)
                        {
                            TextBlock T = new TextBlock();

                            T.FontSize = 9;

                            T.Text = $"{dvodi[i, j]}";
                            T.Foreground = Brushes.White;
                            T.Background = Brushes.Yellow;
                            Grid.SetRow(T, i);

                            Grid.SetColumn(T, j);


                            MatrixGrid.Children.Add(T);

                        }



                        dekodiran.Text = encrypt;

                    }

                }

                await Task.Delay(2000);
                vratiPoz();

            }


            StepOver.Visibility = Visibility.Hidden;
            Retry.Visibility = Visibility.Visible;
            Skip.Visibility = Visibility.Hidden;






        }


        public void RestartMartrix()
        {

            char[] characters = m.ToCharArray();


            int brojVrsta = 27;
            int brojKolona = 27;
            char[,] dvodi = new char[brojVrsta, brojKolona];

            int brojac = 0;
            for (int i = 0; i < brojVrsta; i++)
            {
                for (int j = 0; j < brojKolona; j++)
                {
                    dvodi[i, j] = characters[brojac];
                    brojac++;
                }
            }
            for (int i = 0; i < 27; i++)
            {
                for (int j = 0; j < 27; j++)
                {




                    TextBlock T = new TextBlock();

                    T.FontSize = 9;

                    T.Text = $"{dvodi[i, j]}";
                    T.Background = Brushes.White;
                    T.Foreground = Brushes.Black;







                    Grid.SetRow(T, i);

                    Grid.SetColumn(T, j);


                    MatrixGrid.Children.Add(T);







                }

            }

        }
        private void Retry_Click(object sender, RoutedEventArgs e)
        {

            Bord.Visibility = Visibility.Collapsed;

            Retry.Visibility = Visibility.Hidden;
            Skip.Visibility = Visibility.Hidden;
            t.Visibility = Visibility.Hidden;
            dekodiran.Text = "";
            Pltxt.Text = "";
            Keytxt.Text = "";

            RestartMartrix();
            brojac = 0;
            Autokey.Text = "";
            PlainText.Text = "";
            encrypt = "";


            Start.Visibility = Visibility.Visible;

        }

        

        private void StepOver_Click(object sender, RoutedEventArgs e)
        {


            char[] characters = m.ToCharArray();


            int brojVrsta = 27;
            int brojKolona = 27;
            char[,] dvodi = new char[brojVrsta, brojKolona];

            int brojac = 0;
            for (int i = 0; i < brojVrsta; i++)
            {
                for (int j = 0; j < brojKolona; j++)
                {
                    dvodi[i, j] = characters[brojac];
                    brojac++;
                }
            }
            // dodavanje elemenata u matricu
            vratiPoz();
            for (int i = 0; i < 27; i++)
            {
                for (int j = 0; j < 27; j++)
                {
                    if (i == vrsta && j == kolona)
                    {



                        TextBlock T = new TextBlock();

                        T.FontSize = 9;

                        T.Text = $"{dvodi[i, j - 1]}";
                        T.Foreground = Brushes.White;
                        T.Background = Brushes.Red;






                        Grid.SetRow(T, i);

                        Grid.SetColumn(T, j);


                        MatrixGrid.Children.Add(T);



                    }
                    if (i == 0 && j == kolona)
                    {
                        TextBlock T = new TextBlock();

                        T.FontSize = 9;

                        T.Text = $"{dvodi[i, j]}";
                        T.Foreground = Brushes.White;
                        T.Background = Brushes.Cyan;
                        Grid.SetRow(T, i);

                        Grid.SetColumn(T, j);


                        MatrixGrid.Children.Add(T);

                    }
                    if (j == 0 && i == vrsta)
                    {
                        TextBlock T = new TextBlock();

                        T.FontSize = 9;

                        T.Text = $"{dvodi[i, j]}";
                        T.Foreground = Brushes.White;
                        T.Background = Brushes.Yellow;
                        Grid.SetRow(T, i);

                        Grid.SetColumn(T, j);


                        MatrixGrid.Children.Add(T);

                    }

                    dekodiran.Text = encrypt;

                }

            }



            if (encrypt.Length == Autokey.Text.Length)
            {
                Skip.Visibility = Visibility.Hidden;
                StepOver.Visibility = Visibility.Hidden;
                Retry.Visibility = Visibility.Visible;
            }

        }

    }
}