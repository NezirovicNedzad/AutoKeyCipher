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
        int vrsta, kolona;
        int brojac = 0;
        string encrypt;
        private static String alphabet
    = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public ProfilePage()
        {
            InitializeComponent();
        }

        int k=7;

        private void CreateMatrix()
        {
            string m= " ABCDEFGHIJKLMNOPQRSTUVWXYZAABCDEFGHIJKLMNOPQRSTUVWXYZBBCDEFGHIJKLMNOPQRSTUVWXYZACCDEFGHIJKLMNOPQRSTUVWXYZAB"+
                      "DDEFGHIJKLMNOPQRSTUVWXYZABCEEFGHIJKLMNOPQRSTUVWXYZABCDFFGHIJKLMNOPQRSTUVWXYZABCDEGGHIJKLMNOPQRSTUVWXYZ"+
            "ABCDEFHHIJKLMNOPQRSTUVWXYZABCDEFGIIJKLMNOPQRSTUVWXYZABCDEFGHJJKLMNOPQRSTUVWXYZABCDEFGHIKKLMNOPQRSTUVWXYZ" +
            "ABCDEFGHIJLLMNOPQRSTUVWXYZABCDEFGHIJKMMNOPQRSTUVWXYZABCDEFGHIJKLNNOPQRSTUVWXYZABCDEFGHIJKLMOOPQRSTUVWXYZ" +
            "ABCDEFGHIJKLMNPPQRSTUVWXYZABCDEFGHIJKLMNOQQRSTUVWXYZABCDEFGHIJKLMNOPRRSTUVWXYZABCDEFGHIJKLMNOPQSSTUVWXYZ" +
             "ABCDEFGHIJKLMNOPQRTTUVWXYZABCDEFGHIJKLMNOPQRSUUVWXYZABCDEFGHIJKLMNOPQRSTVVWXYZABCDEFGHIJKLMNOPQRSTUWWXYZ" +
            "ABCDEFGHIJKLMNOPQRSTUVXXYZABCDEFGHIJKLMNOPQRSTUVWYYZABCDEFGHIJKLMNOPQRSTUVWXZZABCDEFGHIJKLMNOPQRSTUVWXYZ";
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

            for (int i = 0; i <28 ; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                MatrixGrid.RowDefinitions.Add(rowDef);

                ColumnDefinition colDef = new ColumnDefinition();
                MatrixGrid.ColumnDefinitions.Add(colDef);
            }

            // dodavanje elemenata u matricu
            for (int i = 0; i < 27; i++)
            {
                for (int j = 0; j <27; j++)
                {

                    TextBlock T= new TextBlock();

                    T.FontSize = 9;

                 
                    T.Text = $"{dvodi[i, j]}";


                   
                   
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
            t.Visibility = Visibility.Visible;
            CreateMatrix();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            StartD.Visibility=Visibility.Visible;   

        }

        public void vratiPoz()
        {
          
            string autokey = Autokey.Text;
            string plainText=PlainText.Text;


            if (brojac < autokey.Length)
            {
                int first = alphabet.IndexOf(plainText[brojac])+1;//index vrste
                int second = alphabet.IndexOf(autokey[brojac]);//index kol


                vrsta = first;
                kolona = second+1;

                int index = (first + second-1) % 26;

                encrypt += alphabet[index];



                brojac += 1;
            }

        }

        private void StepOver_Click(object sender, RoutedEventArgs e)
        {


            string m = " ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                      "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ" +
            "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ" +
            "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ" +
            "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ" +
             "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ" +
            "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ";
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
                    if(i==vrsta && j==kolona    )
                    { 
                    
                        
                     
                        TextBlock T = new TextBlock();

                        T.FontSize = 9;

                        T.Text = $"{dvodi[i, j-1]}";
                        T.Foreground = Brushes.White;
                        T.Background =Brushes.Red;


                      



                        Grid.SetRow(T, i);
                       
                        Grid.SetColumn(T, j);


                          MatrixGrid.Children.Add(T);

                      

                    }
                    if (i == 0 && j==kolona)
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


          
        }
    }
}
