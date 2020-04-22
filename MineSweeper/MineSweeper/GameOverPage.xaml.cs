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
        Frame rootFrame = Window.Current.Content as Frame;
        public GameOverPage()
        {
            int time = 999999999;
            int score = 12;
            this.InitializeComponent();
            score_label.Text = $"Score: {score}\nTime: {time}";
        }

        private void play_button_Click(object sender, RoutedEventArgs e)
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
    }
}
