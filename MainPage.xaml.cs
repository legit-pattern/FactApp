using project_ramverket.DataProvider;
using Windows.UI.Xaml.Controls;
using System.ComponentModel;
using project_ramverket.Views;
using Windows.UI.ViewManagement;

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
            string _header = "Welcome to Fun Facts App!";
            public string HeaderName
            {
                get { return _header; }
                set
                {
                    _header = value; OnPropertyRaised("HeaderName");
                }
            }
            string _image = "Assets/background.jpg";
            public string HeaderImage
            {
                get { return _image; }
                set
                {
                    _image = value; OnPropertyRaised("HeaderImage");
                }
            }
            string _selected = "";
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
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Windows.Foundation.Size(500, 500));
        }

        private void MenuSelected(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = nv.SelectedItem as NavigationViewItem;
            BaseHeader.HeaderName = item.Content.ToString();
            
            switch (item.Tag)
            {
                case "catFact":
                    ContentFrame.Navigate(typeof(CatView));
                    BaseHeader.HeaderImage = "Assets/cat.jpg";
                    break;
                case "programmingJoke":
                    ContentFrame.Navigate(typeof(ProgrammerView));
                    BaseHeader.HeaderImage = "Assets/programming.jpg";
                    break;
                case "about":
                    ContentFrame.Navigate(typeof(AboutView));
                    BaseHeader.HeaderImage = "Assets/background.jpg";
                    break;
            }
            count = 0;
        }

        // Count: Used to simulate navigation view button click after it's been selected
        public int count;
        private void NavigationViewItem_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var item = nv.SelectedItem as NavigationViewItem;
            if (item.IsSelected)
            {
                count += 1;
                BaseHeader.SelectedItem = item.Tag.ToString();
            }

            if (count > 1 && BaseHeader.SelectedItem == item.Tag.ToString())
            {
                count = 1;
                if (item.Tag.ToString() == "catFact")
                {
                    CatView invokedItem = ContentFrame.Content as CatView;
                    invokedItem.Button_Click(null, null);
                }
                if (item.Tag.ToString() == "programmingJoke")
                {
                    ProgrammerView invokedItem = ContentFrame.Content as ProgrammerView;
                    invokedItem.Get_Programming_Joke(null, null);
                }
            }
            nv.IsPaneOpen = false;
        }
    }
}