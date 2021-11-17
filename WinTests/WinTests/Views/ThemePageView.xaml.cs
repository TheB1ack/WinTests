using System;
using System.Windows;
using System.Windows.Controls;
using Unity;
using WinTests.ViewModels;

namespace WinTests.Views
{
    public partial class ThemePageView : Page
    {
        [Dependency]
        public ThemePageViewModel ViewModel
        {
            get => DataContext as ThemePageViewModel;
            set
            {
                DataContext = value;
            }
        }

        public ThemePageView()
        {
            InitializeComponent();

            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            dockPanel.MaxHeight = ActualHeight;
        }
    }
}
