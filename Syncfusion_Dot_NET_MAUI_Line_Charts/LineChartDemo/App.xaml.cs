using Charts;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Microsoft.Maui.Graphics;
using Application = Microsoft.Maui.Controls.Application;
using TabbedPage = Microsoft.Maui.Controls.TabbedPage;

namespace MauiApp2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            TabbedPage tab = new TabbedPage() { BarTextColor = Colors.White };
            tab.Children.Add(new MainPage() { Title = "Using xaml" });
            tab.Children.Add(new LineDemo() { Title = "Using C#" });
            MainPage = tab;
        }
    }
}
