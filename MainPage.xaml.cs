using project_ramverket.DataProvider;
using project_ramverket.Processor;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using project_ramverket;
using Windows.Media.SpeechSynthesis;
using System.Linq;

namespace project_ramverket
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApiHelper.InitClient();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var res = await CatProcessor.LoadFact();
            var resImg = await ImageProcessor.LoadImage();
            Result.Text = res.text;
            //catImg.Height = resImg.height;
            //catImg.Width = resImg.width;
            catImg.Source = new BitmapImage(new Uri(resImg.url.ToString(), UriKind.Absolute));
        }

        private async void Get_Programming_Joke()
        {
            var res = await ProgrammingProcessor.LoadFact();
            var resImg = await XkcdProcessor.LoadImage();
            catImg.Source = new BitmapImage(new Uri(resImg.img.ToString(), UriKind.Absolute));
            Result.Text = res.en;
            //var tmp = resImg.transcript.Replace('[', ' ');
            ReadText(res.en);
        }

        private async void ReadText(string mytext)
        {
            var speechText = mytext;
            var synth = new SpeechSynthesizer();
            var speechStream = await synth.SynthesizeTextToStreamAsync(speechText);
            this.mediaElement.AutoPlay = true;
            this.mediaElement.SetSource(speechStream, speechStream.ContentType);
            this.mediaElement.Play();
        }
        private void MenuSelected(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = nv.SelectedItem as NavigationViewItem;
            switch (item.Tag)
            {
                case "catFact":
                    Button_Click(null, null);
                    break;
                case "programmingJoke":
                    Get_Programming_Joke();
                    break;
            }
            nv.SelectedItem = HiddenItem;
        }
    }
}