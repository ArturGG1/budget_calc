using System.Windows;
using System.Windows.Controls;

namespace budget_calc;
public partial class Credits : Page
{
    private const string PageName = "Credits";
    private const int RowCount = 4;
    private BudgetUpdater budgetUpdater = ((MainWindow)Application.Current.MainWindow).budgetUpdater;
    public Credits()
    {
        InitializeComponent();
        budgetUpdater.UpdateTextBoxesFromBudget(PageName, this);
    }
    private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        string key = PageName + textBox.Name.Substring(7);
        budgetUpdater.UpdateBudget(key, textBox);
        TextBlockTotal.Text = budgetUpdater.UpdateTextBlocks(PageName, this);
    }
}