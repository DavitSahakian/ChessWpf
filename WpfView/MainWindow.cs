using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Games;
namespace WpfView
{
    public partial class MainWindow : Window
    {
        FromBaseToGame game = new FromBaseToGame();
        public static Image[] images = new Image[32];
        public List<Image> imagesList = new List<Image>(images);
        Thickness th;
        /// <summary>
        /// finds figures position start position and where figure want to go
        /// </summary>
        /// <returns></returns>
        public (int, int, int, int) StartPosition()
        {
            (int, int, int, int) data = (-1,-1,-1,-1);
            for (int i = 0; i < 9; i++)
            {
                if (game.GetChessCoordinate(letter.Text.ToLower()).Item1 == i)
                {
                    data.Item1 = i;
                }
                if (game.GetChessCoordinate(letter.Text.ToLower()).Item2 == i)
                {
                    data.Item2 = i;
                }
                if (game.GetChessCoordinate(numberBox.Text.ToLower()).Item1 == i)
                {
                    data.Item3 = i;
                }
                if (game.GetChessCoordinate(numberBox.Text.ToLower()).Item2 == i)
                {
                    data.Item4 = i;
                }
            }
            return data;
        }     
        /// <summary>
        /// creates image with given uri and image
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="img"></param>
        /// <returns>image</returns>
        private Image CreateImage(string uri, out Image img)
        {
            Image currentImage = new Image();
            img = currentImage;
            img.Width = 50;
            img.Height = 50;
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(uri, UriKind.Relative);
            bi3.EndInit();
            img.Source = bi3;
            img.Margin = th;
            img.Cursor = Cursors.Hand;
            return img;
        } 
        /// <summary>
        /// initializes black figures on their start position
        /// </summary>
        private void BlacksOnBoard()
        {
            th.Left = -350;
            th.Top = -400;           
            imagesList[0 + 16] = CreateImage(@"image/BRook.png", out images[0+16]);
            FigureGrid.Children.Add(images[0 + 16]);
            th.Left += 100;
            imagesList[1 + 16] = CreateImage(@"image/BKnight.png", out images[1 + 16]);
            FigureGrid.Children.Add(images[1 + 16]);
            th.Left += 100;
            imagesList[2 + 16] = CreateImage(@"image/BBishop.png", out images[2 + 16]);
            FigureGrid.Children.Add(images[2 + 16]);
            th.Left += 100;
            imagesList[3 + 16] = CreateImage(@"image/BQueen.png", out images[3 + 16]);
            FigureGrid.Children.Add(images[3 + 16]);
            th.Left += 100;
            imagesList[4 + 16] = CreateImage(@"image/BKing.png", out images[4 + 16]);
            FigureGrid.Children.Add(images[4 + 16]);
            th.Left += 100;
            imagesList[5 + 16] = CreateImage(@"image/BBishop.png", out images[5 + 16]);
            FigureGrid.Children.Add(images[5 + 16]);
            th.Left += 100;
            imagesList[6 + 16] = CreateImage(@"image/BKnight.png", out images[6 + 16]);
            FigureGrid.Children.Add(images[6 + 16]);
            th.Left += 100;
            imagesList[7 + 16] = CreateImage(@"image/BRook.png", out images[7 + 16]);
            FigureGrid.Children.Add(images[7 + 16]);
            th.Top += 100;
            th.Left = -450;
                for (int k = 24; k < 32; k++)
                {
                    th.Left += 100;
                    imagesList[k] = CreateImage(@"image/BPawn.png", out images[k]);
                    FigureGrid.Children.Add(images[k]);
                }            
        }
        /// <summary>
        ///  initializes black figures on their start position
        /// </summary>
        private void WhitesOnBoard()
        {
            th.Left = -350;
            th.Top = 300;
            imagesList[16 - 16] = CreateImage(@"image/WRook.png", out images[16-16]);
            FigureGrid.Children.Add(images[16 - 16]);
            th.Left += 100;
            imagesList[17 - 16] = CreateImage(@"image/WKnight.png", out images[17 - 16]);
            FigureGrid.Children.Add(images[17 - 16]);
            th.Left += 100;
            imagesList[18 - 16] = CreateImage(@"image/WBishop.png", out images[18 - 16]);
            FigureGrid.Children.Add(images[18 - 16]);
            th.Left += 100;
            imagesList[19 - 16] = CreateImage(@"image/WQueen.png", out images[19 - 16]);
            FigureGrid.Children.Add(images[19 - 16]);
            th.Left += 100;
            imagesList[20 - 16] = CreateImage(@"image/WKing.png", out images[20 - 16]);
            FigureGrid.Children.Add(images[20 - 16]);
            th.Left += 100;
            imagesList[21 - 16] = CreateImage(@"image/WBishop.png", out images[21 - 16]);
            FigureGrid.Children.Add(images[21 - 16]);
            th.Left += 100;
            imagesList[22 - 16] = CreateImage(@"image/WKnight.png", out images[22 - 16]);
            FigureGrid.Children.Add(images[22 - 16]);
            th.Left += 100;
            imagesList[23 - 16] = CreateImage(@"image/WRook.png", out images[23 - 16]);
            FigureGrid.Children.Add(images[23 - 16]);
            th.Top -= 100;
            th.Left = -450;
                for (int k = 8; k < 16; k++)
                {
                    th.Left += 100 ;
                    imagesList[k] = CreateImage(@"image/WPawn.png", out images[k]);
                    FigureGrid.Children.Add(images[k]);
                }
            
        } 
    }
}
