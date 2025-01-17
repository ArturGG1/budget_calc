using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace budget_calc;

public partial class TotalSpending : Page
{
    private BudgetUpdater budgetUpdater = ((MainWindow)Application.Current.MainWindow).budgetUpdater;
    public TotalSpending()
    {
        InitializeComponent();
        double[] Total = budgetUpdater.GetTotalSpending();
        double Planned = Total[0];
        double Actual = Total[1];
        if (Planned - Actual < 0) Difference.Foreground = Brushes.Red;
        PlannedSpending.Text = Planned.ToString() + " руб.";
        ActualSpending.Text = Actual.ToString() + " руб.";
        Difference.Text = (Planned - Actual).ToString() + " руб.";
    }
}