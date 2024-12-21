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
        this.Width = mainWindow.ActualWidth * 0.75;
        this.Height = mainWindow.ActualHeight * (2.0 / 3.0);
    }
    private void TextBoxIncome_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        budgetUpdater.UpdateIncome(textBox);
    }
}