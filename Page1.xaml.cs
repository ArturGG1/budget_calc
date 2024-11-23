using System.Windows;
using System.Windows.Controls;

namespace budget_calc;

public partial class Page1 : Page
{
    public Page1()
    {
        InitializeComponent();
    }

    private void B1_OnClick(object sender, RoutedEventArgs e)
    {
        Page2 page2 = new Page2();
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        mainWindow.Content = page2;
    }
}