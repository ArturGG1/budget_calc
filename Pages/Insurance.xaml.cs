using System.Windows;
using System.Windows.Controls;

namespace budget_calc;
public partial class Insurance : Page
{
    private const string PageName = "Insurance";
    private const int RowCount = 4;
    private BudgetUpdater budgetUpdater = ((MainWindow)Application.Current.MainWindow).budgetUpdater;
    public Insurance()
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