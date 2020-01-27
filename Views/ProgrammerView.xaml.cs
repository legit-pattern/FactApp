using project_ramverket.Processor;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace project_ramverket.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProgrammerView : Page
    {
        public ProgrammerView()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }
        public async void Get_Programming_Joke(object sender, RoutedEventArgs e)
        {
            var res = await ProgrammingProcessor.LoadFact();
            var resImg = await XkcdProcessor.LoadImage();

            programmerImg.Source = new BitmapImage(new Uri(resImg.img.ToString(), UriKind.Absolute));
            programmerText.Text = res.en;
        }
    }
}
