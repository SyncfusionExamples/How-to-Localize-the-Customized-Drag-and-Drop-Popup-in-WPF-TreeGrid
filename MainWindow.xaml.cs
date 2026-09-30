using Syncfusion.SfSkinManager;
using System.Windows;

namespace SfTreeGrid_CustomDrag
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            SfSkinManager.ApplyThemeAsDefaultStyle = true; 
            SfSkinManager.ApplicationTheme = new Theme("FluentLight");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-FR");
            InitializeComponent();
        }
    } 
}