using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace budget_calc;

public partial class Overview : Page
{
    private BudgetUpdater budgetUpdater = ((MainWindow)Application.Current.MainWindow).budgetUpdater;
    public Overview()
    {
        InitializeComponent();
        double PlannedIncome = 0, ActualIncome = 0, PlannedSpending = 0, ActualSpending = 0;
        (PlannedIncome, ActualIncome) = budgetUpdater.GetTotalIncome();
        (PlannedSpending, ActualSpending) = budgetUpdater.GetTotalSpending();
        PlannedLeft.Text = (PlannedIncome - PlannedSpending).ToString();
        ActualLeft.Text = (ActualIncome - ActualSpending).ToString();
        Difference.Text = (double.Parse(PlannedLeft.Text) - double.Parse(ActualLeft.Text)).ToString() + " руб.";
        if ((double.Parse(PlannedLeft.Text) - double.Parse(ActualLeft.Text)) < 0) Difference.Foreground = Brushes.Red;
        PlannedLeft.Text = PlannedLeft.Text + " руб.";
        ActualLeft.Text = ActualLeft.Text + " руб.";
    }
}