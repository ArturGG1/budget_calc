using System.Windows;
using System.Windows.Controls;

namespace budget_calc;
public partial class Housing : Page
{
    private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
    private const string DictKey = "Housing";
    private const int RowCount = 10;
    private BudgetUpdater budgetUpdater = new BudgetUpdater(DictKey, RowCount);
    public Housing()
    {
        InitializeComponent();
        for (int i = 1; i <= RowCount; i++)
        {
            budgetUpdater.UpdateTextBoxFromBudget(DictKey + "Planned" + i.ToString(), (TextBox)this.FindName("TextBoxPlanned" + i.ToString()));
            budgetUpdater.UpdateTextBoxFromBudget(DictKey + "Actual" + i.ToString(), (TextBox)this.FindName("TextBoxActual" + i.ToString()));
        }
    }
    private void UpdateTextBlocks()
    {
        for (int i = 1; i <= RowCount; i++)
        {
            try
            {
                budgetUpdater.UpdateTextBlock((TextBox)this.FindName("TextBoxPlanned" + i.ToString()),
                                 (TextBox)this.FindName("TextBoxActual" + i.ToString()),
                                  (TextBlock)this.FindName("TextBlockLeft" + i.ToString()));
            }
            catch {}
        }
        TextBlockTotal.Text = budgetUpdater.UpdateTotal();
    }
    private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        string key = DictKey + textBox.Name.Substring(7);
        budgetUpdater.UpdateBudget(key, textBox);
        UpdateTextBlocks();
    }
}