using System.Windows;
using System.Windows.Controls;

namespace budget_calc;
public partial class Invest : Page
{
    private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
    private BudgetUpdater budgetUpdater = ((MainWindow)Application.Current.MainWindow).budgetUpdater;
    
    public Invest()
    {
        InitializeComponent();
        budgetUpdater.UpdateTextBoxesFromBudget(this.Title, this);
        this.Width = mainWindow.ActualWidth * 0.75;
        this.Height = mainWindow.ActualHeight * (2.0 / 3.0);
    }
    
    private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        string key = this.Title + textBox.Name.Substring(7);
        budgetUpdater.UpdateBudget(key, textBox);
        TextBlockTotal.Text = budgetUpdater.UpdateTextBlocks(this.Title, this);
    }
}