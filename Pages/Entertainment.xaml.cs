using System.Windows;
using System.Windows.Controls;

namespace budget_calc;
public partial class Entertainment : Page
{
    private BudgetUpdater budgetUpdater = ((MainWindow)Application.Current.MainWindow).budgetUpdater;
    public Entertainment()
    {
        InitializeComponent();
        budgetUpdater.UpdateTextBoxesFromBudget(this.Title, this);
    }
    private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        string key = this.Title + textBox.Name.Substring(7);
        budgetUpdater.UpdateBudget(key, textBox);
        TextBlockTotal.Text = budgetUpdater.UpdateTextBlocks(this.Title, this);
        budgetUpdater.UpdateChart(this.Title, UserControl);
    }
}