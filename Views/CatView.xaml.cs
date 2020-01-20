﻿using project_ramverket.Processor;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace project_ramverket.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CatView : Page
    {
        public CatView()
        {
            this.InitializeComponent();
        }

        public async void Button_Click(object sender, RoutedEventArgs e)
        {
            var res = await CatProcessor.LoadFact();
            var resImg = await ImageProcessor.LoadImage();

            catText.Text = res.text;
            catImg.Source = new BitmapImage(new Uri(resImg.url.ToString(), UriKind.Absolute));
            //catImg.Height = resImg.height;
            //catImg.Width = resImg.width;
            //catImg.Source = new BitmapImage(new Uri(resImg.url.ToString(), UriKind.Absolute));
        }
    }
}