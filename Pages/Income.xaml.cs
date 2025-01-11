using System.Windows;
using System.Windows.Controls;

namespace budget_calc;

public partial class Income : Page
{
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
}