using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace budget_calc.Pages;

public partial class TotalSpending : Page
{
    private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
    private BudgetUpdater budgetUpdater = ((MainWindow)Application.Current.MainWindow).budgetUpdater;
    public TotalSpending()
    {
        InitializeComponent();
        double Planned = 0;
        double Actual = 0;
        (Planned, Actual) = budgetUpdater.GetTotalSpending();
        PlannedSpending.Text = Planned.ToString() + " руб.";
        ActualSpending.Text = Actual.ToString() + " руб.";
        Difference.Text = (Planned - Actual).ToString() + " руб.";
        if (Planned - Actual < 0) Difference.Foreground = Brushes.Red;
        this.Width = mainWindow.ActualWidth * 0.75;
        this.Height = mainWindow.ActualHeight * (2.0 / 3.0);
    }
}