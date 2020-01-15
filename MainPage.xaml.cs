using project_ramverket.DataProvider;
using project_ramverket.Processor;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using project_ramverket;
using Windows.Media.SpeechSynthesis;
using System.Linq;
using System.ComponentModel;

namespace project_ramverket
{
    public sealed partial class MainPage : Page
    {
        public class NotifyPropertyChanged : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyRaised(string propName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }
        public BaseItem BaseHeader { get; set; } = new BaseItem();

        public class BaseItem : NotifyPropertyChanged
        {
            string _header = string.Empty;
            public string HeaderName
            {
                get { return _header; }
                set
                {
                    _header = value; OnPropertyRaised("HeaderName");
                }
            }
        }

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

            // Voice thingie
            //ReadText(res.en);
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
            BaseHeader.HeaderName = item.Content.ToString();
        }

        private void NavigationViewItem_Tapped2(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            Get_Programming_Joke();
        }

        private void NavigationViewItem_Tapped1(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            Button_Click(null, null);
        }
    }
}