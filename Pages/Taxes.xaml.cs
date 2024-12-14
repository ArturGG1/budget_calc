using System.Windows;
using System.Windows.Controls;

namespace budget_calc;
public partial class Taxes : Page
{
    private const string PageName = "Taxes";
    private const int RowCount = 5;
    private BudgetUpdater budgetUpdater = ((MainWindow)Application.Current.MainWindow).budgetUpdater;
    
    public Taxes()
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