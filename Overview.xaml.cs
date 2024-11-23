using System.Windows;
using System.Windows.Controls;

namespace budget_calc;

public partial class Overview : Page
{
    private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
    public Overview()
    {
        InitializeComponent();
    }
}