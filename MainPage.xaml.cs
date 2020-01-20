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

        private void MenuSelected(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = nv.SelectedItem as NavigationViewItem;
            BaseHeader.HeaderName = item.Content.ToString();
            switch (item.Tag)
            {
                case "catFact":
                    ContentFrame.Navigate(typeof(CatView));
                    break;
                case "programmingJoke":
                    ContentFrame.Navigate(typeof(ProgrammerView));
                    break;
            }
        }
    }
}