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

        protected int num = 1;
        protected int bombCount;
        protected int flagCount;
        protected int score;
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

        MediaPlayer clickSound = new MediaPlayer() { Volume = 1.0 };
        MediaPlayer bruhSound = new MediaPlayer() { Volume = 1.0 };
        MediaPlayer flagSound = new MediaPlayer() { Volume = 1.0 };
        MediaPlayer gameLossSound = new MediaPlayer() { Volume = 1.0 };
        MediaPlayer hornSound = new MediaPlayer() { Volume = 1.0 };
        GameResponder responder;
        GameNotifier notifier;

        public GamePageTest()
        {
            this.InitializeComponent();
            WIDTH = canvas.Width;
            HEIGHT = canvas.Height;
            responder = new GameResponderImp(this);
            Rect gameBoard = GetBoardRegion(WIDTH, HEIGHT);
            gameBoardConfig = new GameBoardConfig(gameBoard, 30, 10, 5, 5);

        }


        protected override void OnNavigatedTo(NavigationEventArgs args)
        {
            if (args.Parameter as GameNotifier == null)
            {

                throw new ArgumentException("Expected a GameNotifer Parameter on Page Navigate");
                //Throw exception- expect the minersweper obejct
                //Navigate to page using Frame.Navigate(sourcePageType, minesweeperObject);
            }


            notifier = args.Parameter as GameNotifier;
            responder.Notifier = notifier;
            notifier.Responder = responder;
        }

        private void Canvas_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            var fontFormat = new Microsoft.Graphics.Canvas.Text.CanvasTextFormat
            {
                FontSize = 28,

            };

            args.DrawingSession.DrawRectangle(gameBoardConfig.GameBoard, Colors.Red);
            drawGameBoard(args, gameBoardConfig);

            scoreTextBox.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                () => { scoreTextBox.Text = $"Score: {score}"; });
            bombsTextBox.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
             () => { bombsTextBox.Text = $"Bombs: {bombCount} bombs"; });
            flagsTextBox.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
             () => { flagsTextBox.Text = $"Flags: {flagCount} flags"; });
            timeTextBox.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
             () => { timeTextBox.Text = $"Time: {num} seconds"; });


            /*args.DrawingSession.DrawText($"Score: {score} seconds", 100, 25, Colors.Black, fontFormat);
            args.DrawingSession.DrawText($"Flags: {flagCount} seconds", 100, 25 + 50, Colors.Black, fontFormat);
            args.DrawingSession.DrawText($"Bombs: {bombCount} bomb", 100, 25 +100, Colors.Black, fontFormat);
            args.DrawingSession.DrawText($"Time: {num} seconds", 100, 25 + 150, Colors.Black, fontFormat);
            */
            if (lastpair.HasValue) {
                CoordPair pair = lastpair.Value;
                args.DrawingSession.DrawText($"Coords: ({pair.indexX},{pair.indexY})", 100, 25, Colors.Black, fontFormat);
            }


            if (lastPoint.HasValue) {

                Point point = lastPoint.Value;

                double x = point.X;
                double y = point.Y;
                System.Numerics.Vector2 vec = new System.Numerics.Vector2(Convert.ToSingle(x), Convert.ToSingle(y));
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


                    yCord += config.SpaceHeight;
                    yCord += config.SpaceYMargin;
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
            bruhSound.Source = createLocalMedia("Assets/Sound/Bruh_Sound_Effect2.mp3");
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
            int random = new Random().Next(5);

            switch (random) {
                case 0: clickSound.Play(); break;
                case 1: flagSound.Play(); break;
                case 2: gameLossSound.Play(); break;
                case 3: hornSound.Play(); break;
                case 4: bruhSound.Play(); break;
            }


            if (lastpair.HasValue) {

                responder.RaiseClick(lastpair.Value.indexX, lastpair.Value.indexY);
            }
      
        }

        private Rect GetBoardRegion(double canvasWidth, double canvasHeight) {
            double widthMargins = 0.0;
            double boardWidth = canvasWidth - 2 * widthMargins;
            double boardy = 0.1 * canvasHeight;
            double heightMargin = 0;

            double boardehigh = canvasHeight - boardy - heightMargin;

            return new Rect(widthMargins, boardy, boardWidth, boardehigh);
        }


        private CoordPair? GetBoardSpaceClick(GameBoardConfig config, Point mouseClick) {
            Rect board = config.GameBoard;

            if (mouseClick.X < board.X || mouseClick.X > board.X + board.Width)
            {
                return null;
            }
            else if (mouseClick.Y < board.Y || mouseClick.Y > board.Y + board.Height)
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

            public double SpaceWidth { get; }

            public double SpaceHeight { get; }

        }

        public class GameResponderImp : GameResponder
        {
            private GamePageTest page;


            public GameResponderImp(GamePageTest page) : base()
            {
                this.page = page;
            }

            public override void OnBombClick(int x, int y, bool set)
            {
                page.gameLossSound.Play();
            }

            public override void OnFlagClick(int x, int y, bool set)
            {
                page.flagSound.Play();
            }

            public override void OnReveal(int x, int y)
            {
                page.clickSound.Play();
            }

            public override void OnWin()
            {
                page.hornSound.Play();
            }
        }

    }



   

}
