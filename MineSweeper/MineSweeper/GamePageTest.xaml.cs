﻿using System;
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
using Windows.UI.Xaml.Media;
using System.Threading.Tasks;
using Windows.UI.Input;
using Windows.Media.Playback;
using Windows.Media.Core;
using Microsoft.Graphics.Canvas.Text;

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
        CoordPair? lastpair;

        CanvasTextFormat fontFormatSpace = new CanvasTextFormat
        {
            FontSize = 20,

        };


        GameBoardConfig gameBoardConfig;

        CanvasBitmap bombImage;
        CanvasBitmap flagImage;

        MediaPlayer clickSound = new MediaPlayer() { Volume = 1.0};
        MediaPlayer bruhSound = new MediaPlayer() { Volume = 1.0 };
        MediaPlayer flagSound = new MediaPlayer() { Volume = 1.0 };
        MediaPlayer gameLossSound = new MediaPlayer() { Volume = 1.0 };
        MediaPlayer hornSound = new MediaPlayer() { Volume = 1.0 };

        public GamePageTest()
        {
            this.InitializeComponent();
            WIDTH = Window.Current.Bounds.Width;
            HEIGHT = Window.Current.Bounds.Height;

            Rect gameBoard = GetBoardRegion(WIDTH, HEIGHT);
            gameBoardConfig = new GameBoardConfig(gameBoard, 30, 10, 5, 5);

        }

        private void Canvas_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            var fontFormat = new Microsoft.Graphics.Canvas.Text.CanvasTextFormat
            {
                FontSize = 28,
                
            };


        
            args.DrawingSession.DrawRectangle(gameBoardConfig.GameBoard, Colors.Red);
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


        private void drawSpace(CanvasDrawingSession session, Rect spaceRect, bool revealed, bool bomb, bool flag, int bombCount) {
            if (revealed)
            {
                session.FillRectangle(spaceRect, Colors.Gray);
                if (bomb)
                {
                    session.DrawImage(bombImage, spaceRect);
                }
                else if (flag)
                {
                    session.DrawImage(flagImage, spaceRect);
                }
                else if (bombCount > 0)
                {
                    session.DrawText($"{bombCount}", spaceRect, Colors.Black, fontFormatSpace);
                }

            }
            else {
                session.FillRectangle(spaceRect, Colors.Navy);
            }
        }


        private void drawGameBoard(CanvasAnimatedDrawEventArgs args, GameBoardConfig config) {
           

            double xCord = config.GameBoard.X;
            Random random = new Random();

            for (int xUnit = 0; xUnit < config.SpaceCountX; xUnit += 1)
            {

                xCord += config.SpaceXMargin;
                double yCord = config.GameBoard.Y;
                for (int yUnit = 0; yUnit < config.SpaceCountY; yUnit += 1)
                {
                    yCord += config.SpaceYMargin;

                    bool revealed = yUnit >= 2;
                    bool bomb = yUnit == 3;
                    bool flag = xUnit % 3 == 0;
                    int number = (int)xUnit / 4;
                    Rect spaceRect = new Rect(xCord, yCord, config.SpaceWidth, config.SpaceHeight);


                    drawSpace(args.DrawingSession, spaceRect, revealed, bomb, flag, number);

                  // CanvasBitmap selected = yUnit % 2 == 0 ? bombImage : flagImage;
                  // args.DrawingSession.FillRectangle(spaceRect, Colors.Gray);
                 // args.DrawingSession.DrawImage(selected, spaceRect);
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
           args.TrackAsyncAction(CreateResources(sender).AsAsyncAction());
        }

        async Task CreateResources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender)
        {
            bombImage = await CanvasBitmap.LoadAsync(sender, "Assets/Image/bomb.jpg");
            flagImage = await CanvasBitmap.LoadAsync(sender, "Assets/Image/flag.jpg");



            clickSound.Source = createLocalMedia("Assets/Sound/click.mp3");
            flagSound.Source = createLocalMedia("Assets/Sound/flag.mp3");
            gameLossSound.Source = createLocalMedia("Assets/Sound/game_loss.mp3");
            hornSound.Source = createLocalMedia("Assets/Sound/PartyHorn.mp3");
            bruhSound.Source = createLocalMedia("Assets/Sound/Bruh Sound Effect #2.mp3");



        }

        private MediaSource createLocalMedia(string path) {
            return MediaSource.CreateFromUri(new Uri("ms-appx:///" + path));
        }

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
              bruhSound.Play();
                /*int random = new Random().Next(5);

            switch (random) {
                case 0: clickSound.Play(); break;
                case 1: flagSound.Play(); break;
                case 2: gameLossSound.Play(); break;
                case 3: hornSound.Play(); break;
                case 4: bruhSound.Play(); break;
            }*/

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
