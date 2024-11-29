using System.Windows;
using System.Windows.Controls;

namespace budget_calc;

public partial class Income : Page
{
    private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
    private double PlannedIncome = 0;
    private double ActualIncome = 0;
    public Income()
    {
        InitializeComponent();
        if (mainWindow.budget.ContainsKey("PlannedIncome"))
        {
            TextBoxPlannedIncome.Text = mainWindow.budget["PlannedIncome"].ToString();
        }
        if (mainWindow.budget.ContainsKey("ActualIncome"))
        {
            TextBoxActualIncome.Text = mainWindow.budget["ActualIncome"].ToString();
        }
    }

    private void TextBoxPlannedIncome_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            PlannedIncome = double.Parse(TextBoxPlannedIncome.Text);
        }
        catch (Exception exception)
        {
            MessageBox.Show("НЕЛЬЗЯ БУКВЫ ВВОДИТЬ, КЛОУН!!!", "ТЫ КЛОУН!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            TextBoxPlannedIncome.Text = "0";
        }
        if (mainWindow.budget.ContainsKey("PlannedIncome"))
        {
            mainWindow.budget["PlannedIncome"] = PlannedIncome;
        }
        else
        {
            mainWindow.budget.Add("PlannedIncome", PlannedIncome);
        }
    }

    private void TextBoxActualIncome_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            ActualIncome = double.Parse(TextBoxActualIncome.Text);
        }
        catch (Exception exception)
        {
            MessageBox.Show("НЕЛЬЗЯ БУКВЫ ВВОДИТЬ, КЛОУН!!!", "ТЫ КЛОУН!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            TextBoxActualIncome.Text = "0";
        }
        if (mainWindow.budget.ContainsKey("ActualIncome"))
        {
            mainWindow.budget["ActualIncome"] = ActualIncome;
        }
        else
        {
            mainWindow.budget.Add("ActualIncome", ActualIncome);
        }
    }
}