using System.Windows;
using System.Windows.Controls;

namespace budget_calc;
public partial class Pets : Page
{
    private const string PageName = "Pets";
    private const int RowCount = 5;
    private BudgetUpdater budgetUpdater = ((MainWindow)Application.Current.MainWindow).budgetUpdater;
    
    public Pets()
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