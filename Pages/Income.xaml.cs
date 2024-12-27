using System.Windows;
using System.Windows.Controls;

namespace budget_calc;

public partial class Income : Page
{
    private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
    private BudgetUpdater budgetUpdater = ((MainWindow)Application.Current.MainWindow).budgetUpdater;
    public Income()
    {
        InitializeComponent();
        budgetUpdater.UpdateIncomeFromBudget(TextBoxPlannedIncome);
        budgetUpdater.UpdateIncomeFromBudget(TextBoxActualIncome);
    }
    private void TextBoxIncome_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        budgetUpdater.UpdateIncome(textBox);
    }
    private void Income_OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        TextBoxPlannedIncome.Width = e.NewSize.Width * (1.0 / 2.0) - 50;
        TextBoxActualIncome.Width = e.NewSize.Width * (1.0 / 2.0) - 50;
    }
}