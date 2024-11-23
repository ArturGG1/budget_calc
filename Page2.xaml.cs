using System.Windows;
using System.Windows.Controls;

namespace budget_calc;

public partial class Page2 : Page
{
    public Page2()
    {
        InitializeComponent();
    }

    private void B2_OnClick(object sender, RoutedEventArgs e)
    {
        Page1 page1 = new Page1();
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        mainWindow.Content = page1;
    }
}