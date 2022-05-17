using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Games;

namespace WpfView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BlacksOnBoard();
            WhitesOnBoard();
            game.GetBoard().allFigures = game.GetBoard().GetAllFigures();
        }

        /// makes textbox clean after doubleclick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void letter_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            letter.Text = string.Empty;
        }
        bool end = false;
        /// <summary>
        /// when we try to promote pawn to other figure false when we need to choose true when we already have chose
        /// </summary>
        public static bool IsChoosen { get; set; } = false;
        /// <summary>
        /// makes textbox clean after doubleclick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numberBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numberBox.Text = string.Empty;
        }
        /// <summary>
        /// after move button click method will find figur's indexes and draw it on board
        /// </summary>
        /// <param name="sender"></param>``
        /// <param name="e"></param>
        private void MoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (game.Move((StartPosition().Item1, StartPosition().Item2),
                          (StartPosition().Item3, StartPosition().Item4)))
            {
                if (!end)
                {
                    if (game.GetIsMate() == false)
                    {
                        if (CheckIsMate((StartPosition().Item1, StartPosition().Item2)) == false)
                        {
                            if (game.GetIsCheck() == false)
                            {
                                if (CheckIsCheck((StartPosition().Item1, StartPosition().Item2)) == false)
                                {
                                    TryMakeRocksFalse();
                                    Remove((StartPosition().Item1, StartPosition().Item2));
                                    Add((StartPosition().Item3, StartPosition().Item4));
                                    game.GetLastMove = (StartPosition().Item1, StartPosition().Item2,StartPosition().Item3,StartPosition().Item4);
                                    ColorSwap();
                                    CheckOrMateAfterMove();
                                }
                                else
                                {
                                    MessageBox.Show("Position Is Under Check");
                                }
                            }
                            else if (CheckIsCheck((StartPosition().Item1, StartPosition().Item2)) == false)
                            {
                                TryMakeRocksFalse();
                                Remove((StartPosition().Item1, StartPosition().Item2));
                                Add((StartPosition().Item3, StartPosition().Item4));
                                game.GetLastMove = (StartPosition().Item1, StartPosition().Item2, StartPosition().Item3, StartPosition().Item4);
                                ColorSwap();
                                CheckOrMateAfterMove();
                            }
                            else
                            {
                                MessageBox.Show("Check");
                            }

                        }
                    }
                }
            }  
            else if (game.GetCanRock((StartPosition().Item1, StartPosition().Item2),         
                (StartPosition().Item3, StartPosition().Item4)))
            {
                DoRock((StartPosition().Item3, StartPosition().Item4));
                game.GetLastMove = (StartPosition().Item1, StartPosition().Item2, StartPosition().Item3, StartPosition().Item4);
                if (game.turn == game.GetWhiteColor())
                    game.turn = game.GetBlackColor();
                else
                    game.turn = game.GetWhiteColor();
                if (game.GetIsCheck())
                {
                    if (game.GetIsMate())
                    {
                        MessageBox.Show("Mate");
                        end = true;
                    }
                    else
                    {
                        MessageBox.Show("Check");
                    }
                }
           }
           else if (game.GetBoard().CanChangePawnToFigure(game.turn, (StartPosition().Item1, StartPosition().Item2), (StartPosition().Item3, StartPosition().Item4)))
           {
                if (!IsChoosen && !game.GetIsCheck())
                {
                    FigureChoose choose = new FigureChoose();
                    game.GetLastMove = (StartPosition().Item1, StartPosition().Item2, StartPosition().Item3, StartPosition().Item4);
                    if (game.turn == game.GetBlackColor())
                    {
                        BitmapImage bi3 = new BitmapImage();
                        bi3.BeginInit();
                        bi3.UriSource = new Uri(@"image\BQueen.png", UriKind.Relative);
                        bi3.EndInit();
                        choose.Queen.Source = bi3;
                        BitmapImage bi4 = new BitmapImage();
                        bi4.BeginInit();
                        bi4.UriSource = new Uri(@"image\BRook.png", UriKind.Relative);
                        bi4.EndInit();
                        choose.Rook.Source = bi4;
                        BitmapImage bi5 = new BitmapImage();
                        bi5.BeginInit();
                        bi5.UriSource = new Uri(@"image\BBishop.png", UriKind.Relative);
                        bi5.EndInit();
                        choose.Bishop.Source = bi5;
                        BitmapImage bi6 = new BitmapImage();
                        bi6.BeginInit();
                        bi6.UriSource = new Uri(@"image\BKnight.png", UriKind.Relative);
                        bi6.EndInit();
                        choose.Knight.Source = bi6;
                    }
                    else
                    {
                        BitmapImage bi3 = new BitmapImage();
                        bi3.BeginInit();
                        bi3.UriSource = new Uri(@"image\WQueen.png", UriKind.Relative);
                        bi3.EndInit();
                        choose.Queen.Source = bi3;
                        BitmapImage bi4 = new BitmapImage();
                        bi4.BeginInit();
                        bi4.UriSource = new Uri(@"image\WRook.png", UriKind.Relative);
                        bi4.EndInit();
                        choose.Rook.Source = bi4;
                        BitmapImage bi5 = new BitmapImage();
                        bi5.BeginInit();
                        bi5.UriSource = new Uri(@"image\WBishop.png", UriKind.Relative);
                        bi5.EndInit();
                        choose.Bishop.Source = bi5;
                        BitmapImage bi6 = new BitmapImage();
                        bi6.BeginInit();
                        bi6.UriSource = new Uri(@"image\WKnight.png", UriKind.Relative);
                        bi6.EndInit();
                        choose.Knight.Source = bi6;
                    }
                    choose.Show();
                    IsChoosen = true;
                }                
           }

           else if (game.GetEnPassant((StartPosition().Item1, StartPosition().Item2), (StartPosition().Item3, StartPosition().Item4)))
           {
                if (!game.GetIsCheck())
                {
                    for (int k = 0; k < 32; k++)
                    {
                        if ((game.GetLastMove.Item3, game.GetLastMove.Item4) == game.GetBoard()?.allFigures[k]?.position)
                        {
                            FigureGrid.Children.Remove(images[k]);
                            images[k] = null;
                        }
                        if ((StartPosition().Item1, StartPosition().Item2) == game.GetBoard()?.allFigures[k]?.position)
                        {
                            FigureGrid.Children.Remove(images[k]);
                            game.GetBoard().allFigures[k].position = (StartPosition().Item3, StartPosition().Item4);
                        }
                    }
                }
                Add((StartPosition().Item3, StartPosition().Item4));
                game.GetLastMove = StartPosition();
                ColorSwap();
                CheckOrMateAfterMove();
            }
        }
        /// <summary>
        /// method for choosing figure in which you want to be changed
        /// </summary>
        public void ChooseFigure()
        {
            for (int i = 0; i < 32; i++)
            {
                if (game.GetBoard().allFigures[i] != null)
                {
                    if (game.GetBoard().allFigures[i].position == (StartPosition().Item1, StartPosition().Item2))
                    {
                          game.GetBoard().FindFigureForChange(FigureChoose.figureId, game.turn, (StartPosition().Item1, StartPosition().Item2), (StartPosition().Item3, StartPosition().Item4));                       
                    }
                }
            }
        }
        /// <summary>
        /// swaps color
        /// </summary>
        public void ColorSwap()
        {
            if (game.turn == game.GetWhiteColor())
                game.turn = game.GetBlackColor();
            else
                game.turn = game.GetWhiteColor();
        }
        /// <summary>
        /// checks is check or mate after move
        /// </summary>
        public void CheckOrMateAfterMove()
        {
            if (game.GetIsCheck())
            {
                if (game.GetIsMate())
                {
                    MessageBox.Show("Mate");
                    end = true;
                }
                else
                {
                    MessageBox.Show("Check");
                }
            }
        }
        /// <summary>
        /// method does rock
        /// </summary>
        /// <param name="position" which rock short or long must be done></param>
        void DoRock((int,int) position)
        {
            if (position == (6,0))
            {
                FigureGrid.Children.Remove(images[4]);
                game.GetBoard().allFigures[4].position = (6, 0);
                th.Left = 250;
                th.Top = 300;
                FigureGrid.Children.Add(CreateImage(GetUri((6, 0)), out images[4]));
                FigureGrid.Children.Remove(images[7]);
                game.GetBoard().allFigures[7].position = (5, 0);
                th.Left = 150;
                th.Top = 300;
                FigureGrid.Children.Add(CreateImage(GetUri((5, 0)), out images[7]));
            }
            if (position == (2, 0))
            {
                FigureGrid.Children.Remove(images[4]);
                game.GetBoard().allFigures[4].position = (2, 0);
                th.Left = -150;
                th.Top = 300;
                FigureGrid.Children.Add(CreateImage(GetUri((2, 0)), out images[4]));
                FigureGrid.Children.Remove(images[0]);
                game.GetBoard().allFigures[0].position = (3, 0);
                th.Left = -50;
                th.Top = 300;
                FigureGrid.Children.Add(CreateImage(GetUri((3, 0)), out images[0]));
            }
            if (position == (2, 7))
            {
                FigureGrid.Children.Remove(images[20]);
                game.GetBoard().allFigures[20].position = (2, 7);
                th.Left = -150;
                th.Top = -400;
                FigureGrid.Children.Add(CreateImage(GetUri((2, 7)), out images[20]));
                FigureGrid.Children.Remove(images[16]);
                game.GetBoard().allFigures[16].position = (3, 7);
                th.Left = -50;
                th.Top = -400;
                FigureGrid.Children.Add(CreateImage(GetUri((3, 7)), out images[16]));
            }
            if (position == (6, 7))
            {
                FigureGrid.Children.Remove(images[20]);
                game.GetBoard().allFigures[20].position = (6, 7);
                th.Left = 250;
                th.Top = -400;
                FigureGrid.Children.Add(CreateImage(GetUri((6, 7)), out images[20]));
                FigureGrid.Children.Remove(images[23]);
                game.GetBoard().allFigures[23].position = (5, 7);
                th.Left = 150;
                th.Top = -400;
                FigureGrid.Children.Add(CreateImage(GetUri((5, 7)), out images[23]));
            }
        }
        /// <summary>
        /// checks after move is any rock available yet
        /// </summary>
        void TryMakeRocksFalse()
        {
            if (game.GetBoard()?.allFigures[4]?.position == (StartPosition().Item1, StartPosition().Item2))
            {
                game.GetBoard().WhiteShortRock = false;
                game.GetBoard().WhiteLongRock = false;
            }
            else if (game.GetBoard()?.allFigures[0]?.position == (StartPosition().Item1, StartPosition().Item2))
                game.GetBoard().WhiteLongRock = false;
            else if (game.GetBoard()?.allFigures[7]?.position == (StartPosition().Item1, StartPosition().Item2))
                game.GetBoard().WhiteShortRock = false;
            else if (game.GetBoard()?.allFigures[20]?.position == (StartPosition().Item1, StartPosition().Item2))
            {
                game.GetBoard().BlackLongRock = false;
                game.GetBoard().BlackShortRock = false;
            }
            else if (game.GetBoard()?.allFigures[16]?.position == (StartPosition().Item1, StartPosition().Item2))
                game.GetBoard().BlackLongRock = false;
            else if (game.GetBoard()?.allFigures[23]?.position == (StartPosition().Item1, StartPosition().Item2))
                game.GetBoard().BlackShortRock = false;
        }
        /// <summary>
        /// moving figures new position
        /// </summary>
        void FindNewPosition()
            {
                int k = 0;
                while (k < 8)
                {
                    for (int i = -350; i < 351; i += 100)
                    {
                        if (StartPosition().Item3 == k)
                        {
                            th.Left = i;
                            break;
                        }
                        k++;
                    }
                    k = 9;
                }
                k = 0;
                for (int i = 300; i >= -400; i -= 100)
                {
                    if (StartPosition().Item4 == k)
                    {
                        th.Top = i;
                        break;
                    }
                    k++;
                }
            }
        /// <summary>
        /// removes figure when figure have been eaten
        /// </summary>
        /// <param name="position"></param>
        public void Remove((int, int) position)
        {                                            
            for (int k = 0; k < 32; k++)
            {
                if (position == game.GetBoard()?.allFigures[k]?.position)
                {
                    FigureGrid.Children.Remove(images[k]);
                    game.GetBoard().allFigures[k].position = (StartPosition().Item3, StartPosition().Item4);
                }
            }
        }                
        /// <summary>
        /// adds new figure on new position
        /// </summary>
        /// <param name="position"></param>
        public void Add((int, int) position)
        {
            for (int i = 0; i < game.GetBoard()?.allFigures?.Count; i++)
            {
                FindNewPosition();
                if (position == game.GetBoard()?.allFigures[i]?.position)
                {
                    if (game.turn == game.GetBoard()?.allFigures[i]?.color)
                        FigureGrid.Children.Add(CreateImage(GetUri((StartPosition().Item3, StartPosition().Item4)), out images[i]));              
                }
            }
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (images[i + 16]?.Margin != null && images[j]?.Margin != null)
                    {
                        if (images[i + 16].Margin == images[j].Margin)
                        {
                            if (game.turn == game.GetBlackColor())
                            {
                                game.GetBoard().allFigures[j] = null;
                                FigureGrid.Children.Remove(images[j]);
                                images[j] = null;
                            }
                            else
                            {
                                game.GetBoard().allFigures[i + 16] = null;
                                FigureGrid.Children.Remove(images[i + 16]);
                                images[i + 16] = null;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// gets figures URL which is on given position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        string GetUri((int, int) position)
            {
                string uri = @"image/";
                if ((position == game.GetBoard()?.allFigures[0]?.position || position == game.GetBoard()?.allFigures[7]?.position) && game.turn == game.GetWhiteColor())
                    uri += "WRook.png";
                else if ((position == game.GetBoard()?.allFigures[16]?.position || position == game.GetBoard()?.allFigures[23]?.position) && game.turn == game.GetBlackColor())
                    uri += "BRook.png";
                else if ((position == game.GetBoard()?.allFigures[1]?.position || position == game.GetBoard()?.allFigures[6]?.position) && game.turn == game.GetWhiteColor())
                    uri += "WKnight.png";
                else if ((position == game.GetBoard()?.allFigures[17]?.position || position == game.GetBoard()?.allFigures[22]?.position) && game.turn == game.GetBlackColor())          
                    uri += "BKnight.png";
                else if ((position == game.GetBoard()?.allFigures[2]?.position || position == game.GetBoard()?.allFigures[5]?.position) && game.turn == game.GetWhiteColor())
                    uri += "WBishop.png";
                else if ((position == game.GetBoard()?.allFigures[18]?.position || position == game.GetBoard()?.allFigures[21]?.position) && game.turn == game.GetBlackColor())
                    uri += "BBishop.png";
                else if (position == game.GetBoard()?.allFigures[3]?.position && game.turn == game.GetWhiteColor())
                    uri += "WQueen.png";
                else if (position == game.GetBoard()?.allFigures[19]?.position && game.turn == game.GetBlackColor())
                    uri += "BQueen.png";
                else if (position == game.GetBoard()?.allFigures[4]?.position && game.turn == game.GetWhiteColor())
                    uri += "WKing.png";
                else if (position == game.GetBoard()?.allFigures[20]?.position && game.turn == game.GetBlackColor())
                    uri += "BKing.png";
                else
                {
                    for (int i = 8; i < 16; i++)
                    {
                        if (position == game.GetBoard()?.allFigures[i+16]?.position &&  game.turn == game.GetBlackColor())
                        {
                            if (game.GetBoard()?.allFigures[i+16].GetLetter() == 'p')                          
                                uri += "BPawn.png";
                            else if (game.GetBoard()?.allFigures[i + 16].GetLetter() == 'q')
                                uri += "BQueen.png";
                            else if (game.GetBoard()?.allFigures[i + 16].GetLetter() == 'r')
                                uri += "BRook.png";
                            else if (game.GetBoard()?.allFigures[i + 16].GetLetter() == 'b')
                                uri += "BBishop.png";
                            else if (game.GetBoard()?.allFigures[i + 16].GetLetter() == 'n')
                                uri += "BKnight.png";
                        }
                        else if (position == game.GetBoard()?.allFigures[i]?.position && game.turn == game.GetWhiteColor())
                        {
                            if (game.GetBoard()?.allFigures[i].GetLetter() == 'P')
                                uri += "WPawn.png";
                            else if(game.GetBoard()?.allFigures[i].GetLetter() == 'Q')
                                uri += "WQueen.png";
                            else if (game.GetBoard()?.allFigures[i].GetLetter() == 'R')
                                uri += "WRook.png";
                            else if (game.GetBoard()?.allFigures[i].GetLetter() == 'B')
                                uri += "WBishop.png";
                            else if (game.GetBoard()?.allFigures[i].GetLetter() == 'N')
                                uri += "WKnight.png";
                        }       
                    }
                }
                return uri;
            }
        /// <summary>
        /// checks is check after move
        /// </summary>
        /// <param name="position"></param>
        /// <returns>rturns true if check after move otherwise returns false</returns>
        bool CheckIsCheck((int, int) position)
            {
                for (int k = 0; k < game.GetBoard()?.allFigures?.Count; k++)
                {
                    if (position == game.GetBoard()?.allFigures[k]?.position)
                    {
                        game.GetBoard().allFigures[k].position = (StartPosition().Item3, StartPosition().Item4);
                        if (game.GetIsCheck() == false)
                        {
                            game.GetBoard().allFigures[k].position = position;
                            return false;
                        }
                        else
                        {
                            game.GetBoard().allFigures[k].position = position;
                        }
                    }
                }
                return true;
            }
        /// <summary>
        /// checks is mate after move
        /// </summary>
        /// <param name="position"></param>
        /// <returns>returns true if there is mate after move else returns false</returns>
        bool CheckIsMate((int, int) position)
        {
            for (int i = 0; i < game.GetBoard()?.allFigures?.Count; i++)
            {
                if (position == game.GetBoard()?.allFigures[i]?.position)
                {
                    game.GetBoard().allFigures[i].position = (StartPosition().Item3, StartPosition().Item4);
                    if (game.GetIsMate() == false)
                    {
                        game.GetBoard().allFigures[i].position = position;
                        return false;
                    }
                    else
                    {
                        game.GetBoard().allFigures[i].position = position;
                    }
                }
            }
            return true;
        }
    }
}



