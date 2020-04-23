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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MineSweeper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Canvas_CreateResources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {

        }

        private void Canvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args)
        {

        }

        private void Canvas_Update(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedUpdateEventArgs args)
        {

        }

        private void canvas_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void easyMode_Button_Click(object sender, RoutedEventArgs e)
        {
            GridDefinition GridDef = new GridDefinition(9, 9, 10);
            Frame rootFrame = Window.Current.Content as Frame;
            
            rootFrame.Navigate(typeof(GamePageTest), GridDef);
        }

        private void normalMode_Button_Click(object sender, RoutedEventArgs e)
        {
            GridDefinition GridDef = new GridDefinition(16, 16, 40);
            Frame rootFrame = Window.Current.Content as Frame;

            rootFrame.Navigate(typeof(GamePageTest), GridDef);
        }

        private void hardMode_Button_Click(object sender, RoutedEventArgs e)
        {
            GridDefinition GridDef = new GridDefinition(16, 30, 90);
            Frame rootFrame = Window.Current.Content as Frame;

            rootFrame.Navigate(typeof(GamePageTest), GridDef);
        }
        
        private void rouletteMode_Button_Click(object sender, RoutedEventArgs e)
        {
            GridDefinition GridDef = new GridDefinition(16, 30, 16 *30 -2);
            Frame rootFrame = Window.Current.Content as Frame;

            rootFrame.Navigate(typeof(GamePageTest), GridDef);
        }
        
        private void customMode_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(GamePageTest));
        }

        private void howToPlay_Button_Click(object sender, RoutedEventArgs e)
        {

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Instructions));
                        
        }

        private void quitGame_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit(); //https://stackoverflow.com/questions/24673207/how-to-provide-an-exit-menu-item
        }

    }
}
