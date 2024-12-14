using System.Windows;
using System.Windows.Controls;

namespace budget_calc;
public class BudgetUpdater
{
    private readonly MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
    private readonly string DictKey;
    private readonly int RowCount;
    public BudgetUpdater(string dictKey,int rowCount)
    {
        this.DictKey = dictKey;
        this.RowCount = rowCount;
    }
    public void UpdateBudget(string key, TextBox textBox)
    {
        try
        {
            if (mainWindow.budget.ContainsKey(key))
            {
                mainWindow.budget[key] = double.Parse(textBox.Text);
            }
            else
            {
                mainWindow.budget.Add(key, double.Parse(textBox.Text));
            }
        }
        catch (Exception)
        {
            MessageBox.Show("НЕЛЬЗЯ БУКВЫ ВВОДИТЬ, КЛОУН!!!", "ТЫ КЛОУН!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            textBox.Text = "0";
        }
    }
    public void UpdateTextBoxFromBudget(string key, TextBox textBox)
    {
        if (mainWindow.budget.ContainsKey(key))
        {
            textBox.Text = mainWindow.budget[key].ToString();
        }
    }
    public void UpdateTextBlock(TextBox planned, TextBox actual, TextBlock result)
    {
        if (!string.IsNullOrWhiteSpace(planned.Text) && !string.IsNullOrWhiteSpace(actual.Text))
        {
            try
            {
                double plannedValue = double.Parse(planned.Text);
                double actualValue = double.Parse(actual.Text);
                result.Text = ((plannedValue - actualValue).ToString()) + " руб.";
            }
            catch (FormatException)
            {
                MessageBox.Show("ТОЛЬКО ЧИСЛА,КЛОУН!!!!!!", "КЛОУН!!!!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                result.Text = "0 руб.";
            }
        }
        else
        {
            result.Text = "0 руб.";
        }
    }
    public string UpdateTotal()
    {
        double total = 0;
        for (int i = 1; i <= RowCount; i++)
        {
            if (mainWindow.budget.ContainsKey(DictKey + "Planned" + i.ToString()) && mainWindow.budget.ContainsKey(DictKey + "Actual" + i.ToString()))
            {
                total += (mainWindow.budget[DictKey + "Planned" + i.ToString()] - mainWindow.budget[DictKey + "Actual" + i.ToString()]);
            }
        }
        return (total.ToString() + " руб.");
    }
}