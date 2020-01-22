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
using project_ramverket.Views;
using Windows.UI.Popups;

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
            string _header = "Welcome to FunFacts!";
            string _image = "Assets/cat-whiskers-kitty-tabby-20787.jpg";
            string _selected = "";
            public string HeaderName
            {
                get { return _header; }
                set
                {
                    _header = value; OnPropertyRaised("HeaderName");
                }
            }
            public string HeaderImage
            {
                get { return _image; }
                set
                {
                    _image = value; OnPropertyRaised("HeaderImage");
                }
            }
            public string SelectedItem
            {
                get { return _selected; }
                set
                {
                    _selected = value;
                }
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
            ApiHelper.InitClient();
        }

        private void MenuSelected(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = nv.SelectedItem as NavigationViewItem;
            BaseHeader.HeaderName = item.Content.ToString();

            switch (item.Tag)
            {
                case "catFact":
                    BaseHeader.SelectedItem = "cat";
                    ContentFrame.Navigate(typeof(CatView));
                    BaseHeader.HeaderImage = "Assets/cat-whiskers-kitty-tabby-20787.jpg";
                    break;
                case "programmingJoke":
                    BaseHeader.SelectedItem = "dev";
                    ContentFrame.Navigate(typeof(ProgrammerView));
                    BaseHeader.HeaderImage = "Assets/gray-laptop-computer-showing-html-codes-in-shallow-focus-160107.jpg";
                    break;
            }
        }
    }
}