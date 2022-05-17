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
using System.Windows.Shapes;
using Games;

namespace WpfView
{
    /// <summary>
    /// Interaction logic for FigureChoose.xaml
    /// </summary>
    public partial class FigureChoose : Window
    {
        public static int figureId = 0;
        public FigureChoose()
        {
            InitializeComponent();
        }
        /// <summary>
        /// event works when player have chose queen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Queen_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Owner = app_window;
            figureId = 1;
            RunChoosing((MainWindow)App.Current.MainWindow);
            this.Hide();
        }
        MainWindow app_window ;
        /// <summary>
        /// method works when player must choose figure to change with pawn
        /// </summary>
        /// <param name="w"></param>
        public void RunChoosing(MainWindow w)
        {
            Owner = app_window;           
            w.ChooseFigure();
            w.Remove((w.StartPosition().Item1, w.StartPosition().Item2));
            w.Add((w.StartPosition().Item3, w.StartPosition().Item4));
            w.ColorSwap();
            w.CheckOrMateAfterMove();
            MainWindow.IsChoosen = false;
            if (w.StartPosition().Item4 == 0)
                BlackFiguresUrlInit();
            else
                WhiteFiguresUrlInit();

        }
        /// <summary>
        /// initializing black figures url
        /// </summary>
        void BlackFiguresUrlInit()
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(@"image\BQueen.png", UriKind.Relative);
            Queen.Source = bi3;
            bi3.UriSource = new Uri(@"image\BRook.png", UriKind.Relative);
            Rook.Source = bi3;
            bi3.UriSource = new Uri(@"image\BBishop.png", UriKind.Relative);
            Bishop.Source = bi3;
            bi3.UriSource = new Uri(@"image\BKnight.png", UriKind.Relative);
            Knight.Source = bi3;
            bi3.EndInit();
        }
        /// <summary>
        /// initializing white figures url
        /// </summary>
        void WhiteFiguresUrlInit()
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(@"image\WQueen.png", UriKind.Relative);
            Queen.Source = bi3;
            bi3.UriSource = new Uri(@"image\WRook.png", UriKind.Relative);
            Rook.Source = bi3;
            bi3.UriSource = new Uri(@"image\WBishop.png", UriKind.Relative);
            Bishop.Source = bi3;
            bi3.UriSource = new Uri(@"image\WKnight.png", UriKind.Relative);
            Knight.Source = bi3;
            bi3.EndInit();
        }
        /// <summary>
        /// event works when player have chose rook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rook_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Owner = app_window;
            figureId = 2;
            RunChoosing((MainWindow)App.Current.MainWindow);
            this.Hide();
        }
        /// <summary>
        /// event works when player have chose bishop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bishop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Owner = app_window;
            figureId = 3;
            RunChoosing((MainWindow)App.Current.MainWindow);
            this.Hide();
        }
        /// <summary>
        /// event works when player have chose knight
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Knight_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Owner = app_window;
            figureId = 4;
            RunChoosing((MainWindow)App.Current.MainWindow);
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.IsChoosen = false;
        }
    }
}
