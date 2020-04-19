using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Windows.UI;
using Windows.UI.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MineSweeper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePageTest : Page
    {

        int num = 1;
        int bombCount;
        int flagCount;
        int score;
        Point? lastPoint = null;
        double WIDTH;
        double HEIGHT;
        Rect gameBoard;
        double verticalMargin = 5;
        double horizontalMargin = 5;
        CoordPair? lastpair;

        GameBoardConfig gameBoardConfig;

        public GamePageTest()
        {
            this.InitializeComponent();
            WIDTH = Window.Current.Bounds.Width;
            HEIGHT = Window.Current.Bounds.Height;

            gameBoard = GetBoardRegion(WIDTH, HEIGHT);
            gameBoardConfig = new GameBoardConfig(gameBoard, 30, 10, 5, 5);

        }

        private void Canvas_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            var fontFormat = new Microsoft.Graphics.Canvas.Text.CanvasTextFormat
            {
                FontSize = 28,
                FontStretch = Windows.UI.Text.FontStretch.UltraCondensed
                
            };


        
            args.DrawingSession.DrawRectangle(gameBoard, Colors.Red);
            drawGameBoard(args, gameBoardConfig);

            args.DrawingSession.DrawText($"Score: {score} seconds", 100, 25, Colors.Black, fontFormat);
            args.DrawingSession.DrawText($"Flags: {flagCount} seconds", 100, 25 + 50, Colors.Black, fontFormat);
            args.DrawingSession.DrawText($"Bombs: {bombCount} bomb", 100, 25 +100, Colors.Black, fontFormat);
            args.DrawingSession.DrawText($"Time: {num} seconds", 100, 25 + 150, Colors.Black, fontFormat);

            if (lastpair.HasValue) {
                CoordPair pair = lastpair.Value;
                args.DrawingSession.DrawText($"Coords: ({pair.indexX},{pair.indexY})", 100, 25 + 200, Colors.Black, fontFormat);
            }
    

            if (lastPoint.HasValue) {

                Point point = lastPoint.Value;
       
                double x = point.X;
                double y = point.Y;
                System.Numerics.Vector2 vec = new System.Numerics.Vector2(Convert.ToSingle(x),Convert.ToSingle(y));
                args.DrawingSession.DrawEllipse(vec, 10, 10, Colors.Red);

             }

        }


        private void drawGameBoard(CanvasAnimatedDrawEventArgs args, GameBoardConfig config) {
           

            double xCord = config.GameBoard.X;


            for (int xUnit = 0; xUnit < config.SpaceCountX; xUnit += 1)
            {

                xCord += horizontalMargin;
                double yCord = config.GameBoard.Y;
                for (int yUnit = 0; yUnit < config.SpaceCountY; yUnit += 1)
                {
                    yCord += verticalMargin;
                    CanvasBitmap e;
                    Rect spaceRect = new Rect(xCord, yCord, config.SpaceWidth, config.SpaceHeight);
                    args.DrawingSession.DrawRectangle(spaceRect, Colors.Blue);
                    //public void DrawImage(CanvasBitmap bitmap, Rect destinationRectangle);

                    yCord += config.SpaceHeight;
                    yCord += config.SpaceYMargin ;
                }
                xCord += config.SpaceWidth;
                xCord += config.SpaceXMargin;
            }
        }

        private void Canvas_CreateResources(CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {
            //args.TrackAsyncAction(CreateResources(sender).AsAsyncAction());
        }

       /* async Task CreateResources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender)
        {
            ballImage = await CanvasBitmap.LoadAsync(sender, "Assets/ball.png");
            pong.setBallImage(ballImage);
        }*/

        private void Canvas_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args)
        {
            num += 1;
            bombCount = num % 20;
            flagCount = num % 100;
            score = bombCount * flagCount;
        }

        private void canvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            lastPoint = e.GetCurrentPoint(canvas).Position;
            lastpair = GetBoardSpaceClick(gameBoardConfig, lastPoint.Value);
        }

        private Rect GetBoardRegion(double canvasWidth, double canvasHeight) {
            double widthMargins = 25.0;
            double boardWidth = canvasWidth - 2 * widthMargins;
            double boardy = 0.4 * canvasHeight;
            double heightMargin = 30;

            double boardehigh = canvasHeight - boardy - heightMargin;

            return new Rect(widthMargins, boardy, boardWidth, boardehigh);
        }


        private CoordPair? GetBoardSpaceClick(GameBoardConfig config, Point mouseClick) {
            Rect board = config.GameBoard;

            if (mouseClick.X < board.X || mouseClick.X > board.X + board.Width)
            {
                return null;
            }
            else  if (mouseClick.Y < board.Y || mouseClick.Y > board.Y +board.Height)
            {
                return null;
            }

            double totalWidth = config.SpaceWidth + 2 * config.SpaceXMargin;
            double totalHeight = config.SpaceHeight + 2 * config.SpaceYMargin;
            double rootedX = mouseClick.X - board.X;
            double rootedY = mouseClick.Y - board.Y;

            int indexX = (int)Math.Floor(rootedX / totalWidth);
            int indexY = (int)Math.Floor(rootedY / totalHeight);

            double coordX = board.X + config.SpaceXMargin + totalWidth * indexX;
            double coordY = board.Y + config.SpaceYMargin + totalHeight * indexY;

            if (mouseClick.X < coordX || mouseClick.X > coordX + config.SpaceWidth)
            {
                return null;
            }
            else if (mouseClick.Y < coordY || mouseClick.Y > coordY + config.SpaceHeight)
            {
                return null;
            }

            CoordPair pair = new CoordPair();
            pair.indexX = indexX;
            pair.indexY = indexY;
            return pair;

        }


        private struct CoordPair {
           public int indexX { get; set; }
           public int indexY { get; set; }
        
        }


        private class GameBoardConfig {


            public GameBoardConfig(Rect gameBoard, double spaceCountx, double spaceCounty, double yMargin, double xMargin) {
                GameBoard = gameBoard;
                SpaceCountX = spaceCountx;
                SpaceCountY = spaceCounty;
                SpaceXMargin = xMargin;
                SpaceYMargin = yMargin;

                double leftOverWidth = gameBoard.Width - 2 * xMargin * spaceCountx;
                double leftOverHeight = gameBoard.Height - 2 * yMargin * spaceCounty;

                SpaceWidth = leftOverWidth / spaceCountx;
                SpaceHeight = leftOverHeight / spaceCounty;

            }
        
            public Rect GameBoard { get; }

            public double SpaceCountX { get; }

            public double SpaceCountY { get; }

            public double SpaceXMargin { get; }

            public double SpaceYMargin { get; }

            public double SpaceWidth{ get; }

            public double SpaceHeight { get; }

        }
    }
}
