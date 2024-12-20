using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace budget_calc;
public class BudgetUpdater
{
    private string PathToBudget = "budget.json";
    private Dictionary<string, double> Budget;
    private Dictionary<string, int> PagesRowCount = new()
    {
        {"Housing",10},
        {"Entertainment",7},
        {"Transport",6},
        {"Credits",4},
        {"Insurance",4},
        {"Taxes",5},
        {"Food", 4},
        {"Invest", 3},
        {"Pets", 5},
        {"Hygiene", 6},
        {"LegalSpending", 4}
    };
    public BudgetUpdater()
    {
        LoadBudget();
    }
    private string UpdateTotal(string pageName)
    {
        if (!(PagesRowCount.ContainsKey(pageName))) return "0 руб.";
        double total = 0;
        for (int i = 1; i <= PagesRowCount[pageName]; i++)
        {
            if (!Budget.ContainsKey(pageName + "Planned" + i.ToString()) || !Budget.ContainsKey(pageName + "Actual" + i.ToString())) continue;
            total += (Budget[pageName + "Planned" + i.ToString()] - Budget[pageName + "Actual" + i.ToString()]);
        }
        return (total.ToString() + " руб.");
    }
    private void UpdateTextBoxFromBudget(string key, TextBox textBox)
    {
        if (!Budget.ContainsKey(key)) return;
        textBox.Text = Budget[key].ToString();
    }
    public void UpdateBudget(string key, TextBox textBox)
    {
        try
        {
            if (Budget.ContainsKey(key)) Budget[key] = double.Parse(textBox.Text);
            else Budget.Add(key, double.Parse(textBox.Text));
        }
        catch (Exception)
        {
            MessageBox.Show("Введите число!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            textBox.Text = "0";
        }
    }
    public void UpdateTextBlock(TextBox planned, TextBox actual, TextBlock result)
    {
        if (string.IsNullOrWhiteSpace(planned.Text) || string.IsNullOrWhiteSpace(actual.Text)) return;
        try
        {
            double plannedValue = double.Parse(planned.Text);
            double actualValue = double.Parse(actual.Text);
            result.Text = ((plannedValue - actualValue).ToString()) + " руб.";
        }
        catch (FormatException)
        {
            MessageBox.Show("Введите число!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            result.Text = "0 руб.";
        }
    }
    public void UpdateIncome(TextBox textBox)
    {
        double IncomeValue = 0;
        string IncomeType = string.Empty;
        if (textBox.Name.Contains("Planned")) IncomeType = "PlannedIncome";
        if (textBox.Name.Contains("Actual")) IncomeType = "ActualIncome";
        if (string.IsNullOrEmpty(IncomeType)) return;
        try
        {
            IncomeValue = double.Parse(textBox.Text);
        }
        catch (Exception e)
        {
            MessageBox.Show("Введите число!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            textBox.Text = "0";
            return;
        }
        if (Budget.ContainsKey(IncomeType)) Budget[IncomeType] = IncomeValue;
        else Budget.Add(IncomeType, IncomeValue);
    }
    public void UpdateIncomeFromBudget(TextBox textBox)
    {
        string IncomeType = textBox.Name.Substring(7);
        UpdateTextBoxFromBudget(IncomeType, textBox);
    }
    public string UpdateTextBlocks(string pageName, Page page)
    {
        for (int i = 1; i <= PagesRowCount[pageName]; i++)
        {
            try
            {
                UpdateTextBlock((TextBox)page.FindName("TextBoxPlanned" + i.ToString()), (TextBox)page.FindName("TextBoxActual" + i.ToString()), (TextBlock)page.FindName("TextBlockLeft" + i.ToString()));
            }
            catch {}
        }
        return UpdateTotal(pageName);
    }
    public void UpdateTextBoxesFromBudget(string pageName, Page page)
    {
        for (int i = 1; i <= PagesRowCount[pageName]; i++)
        {
            UpdateTextBoxFromBudget(pageName + "Planned" + i.ToString(), (TextBox)page.FindName("TextBoxPlanned" + i.ToString()));
            UpdateTextBoxFromBudget(pageName + "Actual" + i.ToString(), (TextBox)page.FindName("TextBoxActual" + i.ToString()));
        }
    }
    public (double, double) GetTotalIncome()
    {
        if (Budget.Count == 0) return (0, 0);
        if (!Budget.ContainsKey("PlannedIncome") || !Budget.ContainsKey("ActualIncome")) return (0, 0);
        return (Budget["PlannedIncome"], Budget["ActualIncome"]);
    }
    public (double, double) GetTotalSpending()
    {
        if (Budget.Count == 0) return (0, 0);
        double PlannedTotal = 0, ActualTotal = 0;
        foreach (KeyValuePair<string, double> kvp in Budget)
        {
            if (kvp.Key.Contains("Income")) continue;
            if (kvp.Key.Contains("Planned")) PlannedTotal += kvp.Value;
            if (kvp.Key.Contains("Actual")) ActualTotal += kvp.Value;
        }
        return (PlannedTotal, ActualTotal);
    }
    public void SaveBudget()
    {
        File.WriteAllText(PathToBudget, JsonSerializer.Serialize(Budget));
    }
    public void LoadBudget()
    {
        if (!File.Exists(PathToBudget)) return;
        Budget = JsonSerializer.Deserialize<Dictionary<string, double>>(File.ReadAllText(PathToBudget));
    }
}