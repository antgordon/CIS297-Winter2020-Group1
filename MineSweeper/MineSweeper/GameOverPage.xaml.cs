using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MineSweeper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GameOverPage : Page
    {

        private GameOverData data;

        public GameOverPage()
        {
            int time = 999999999;
            int score = 12;
            this.InitializeComponent();
            score_label.Text = $"Score: {score}\nTime: {time}";
        }


        protected override void OnNavigatedTo(NavigationEventArgs args)
        {
            if (args.Parameter as GameOverData == null)
            {

                throw new ArgumentException("Expected a GameOver Data Parameter on Page Navigate");
                //Throw exception- expect the minersweper obejct
                //Navigate to page using Frame.Navigate(sourcePageType, minesweeperObject);
            }

            data = args.Parameter as GameOverData;
            scoreTextBox.Text = $"Score: {data.Score}";

        }

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(GamePageTest), new TestNotifier() );
        }

        private void quit_button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }

    public class TestNotifier : GameNotifier
    {
        public override void OnClick(int x, int y)
        {
            MessageDialog dialog = new MessageDialog($"({x},{y})");
            dialog.ShowAsync();
        }

        public class GameOverData {

            public GameOverData(GridDefinition grid, int score) {
                Definition = grid;
                Score = score;
            }

            public GridDefinition Definition { get; }

            public int Score { get; }
        }

        private void playAgainButton_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(GamePageTest), data.Definition);

        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage));
        }
    }
}
