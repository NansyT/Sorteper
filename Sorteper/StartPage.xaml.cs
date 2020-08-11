using SorteperGame;
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
using System.Diagnostics;

namespace Sorteper
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        GamePage gamePage = new GamePage();
        static Game game = new Game();
        CardConverter converter = new CardConverter();
        Player human = game.GetPlayers()[0];
        Player computer = game.GetPlayers()[1];
        private void Startbtn_Click(object sender, RoutedEventArgs e)
        {
            #region insert image
            //List<string> cardNames = new List<string>() { "bear" };
            //int currentP = 1;
            //for (int i = 0; i < 20; i++)
            //{

            //    Image image = new Image();
            //    image.Source = new BitmapImage(new Uri("pack://application:,,,/Cards/bear.png"));
            //    image.Name = "bear";

            //    if (currentP == 1)
            //    {
            //        gamePage.playerCards.Children.Add(image);
            //        currentP = 2;
            //    }
            //    else
            //    {
            //        gamePage.computerCards.Children.Add(image);
            //        currentP = 1;
            //    }
            //}

            //Label label = new Label();

            //label.Content = "Antal kort: " + gamePage.playerCards.Children.Count;

            //gamePage.playerInfo.Children.Add(label);

            //label.Content = "Antal kort: " + gamePage.computerCards.Children.Count;
            //gamePage.computerInfo.Children.Add(label);
            #endregion
            game.StartGame();
            human.CardDrawn += Human_CardDrawn;

            for (int i = 0; i < human.Hand.Count; i++)
            {
                Image image = new Image();
                image.Source = new BitmapImage((Uri)converter.Convert(human.Hand[i], null, null, null));
                image.Name = human.Hand[i].Name;
                gamePage.playerCards.Children.Add(image);
            }
            for (int i = 0; i < computer.Hand.Count; i++)
            {
                Image image = new Image();
                image.Source = new BitmapImage((Uri)converter.Convert(computer.Hand[i], null, null, null));
                image.Name = computer.Hand[i].Name;
                gamePage.computerCards.Children.Add(image);
                image.MouseLeftButtonDown += Image_MouseLeftButtonDown;
            }
            NavigationService.Navigate(gamePage);
        }

        private void Human_CardDrawn(object sender, EventArgs e)
        {
            if (e is DrawEventArgs)
            {
                gamePage.computerCards.Children.RemoveAt(((DrawEventArgs)e).Index);
                Debug.WriteLine("Card drawn " + ((DrawEventArgs)e).Card.Name);
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine(sender.ToString() + "" + sender.GetType());

            int index = gamePage.computerCards.Children.IndexOf((Image)sender);
            Debug.WriteLine(index);
            human.Draw(index, computer);
            
        }

        private void Exitbtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
