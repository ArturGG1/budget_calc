using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace budget_calc;
public class BudgetUpdater
{
    // Путь к файлу, где хранится бюджет
    private string PathToBudget = "budget.json";
    // Сам бюджет
    private Dictionary<string, double> Budget;
    // Кол-во рядов с данными на каждой странице
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
    // Конструктор просто загружает бюджет, поэтому его запись можно так сократить
    public BudgetUpdater() => LoadBudget();
    /// <summary>
    /// Обновляет промежуточный итог
    /// </summary>
    /// <param name="pageName">Название страницы</param>
    /// <returns>Возвращает строку с промежуточным итогом</returns>
    private string UpdateTotal(string pageName)
    {
        if (!(PagesRowCount.ContainsKey(pageName))) return "0 руб.";
        double total = 0;
        for (int i = 1; i <= PagesRowCount[pageName]; i++)
        {
            if (!Budget.ContainsKey(pageName + "Planned" + i.ToString()) || !Budget.ContainsKey(pageName + "Actual" + i.ToString())) continue;
            total += (Budget[pageName + "Planned" + i.ToString()] - Budget[pageName + "Actual" + i.ToString()]);
        }
        return total.ToString() + " руб.";
    }
    /// <summary>
    /// Обновляет TextBox значением из бюджета
    /// </summary>
    /// <param name="key">Ключ для поиска в бюджете</param>
    /// <param name="textBox">TextBox, который нужно обновить</param>
    private void UpdateTextBoxFromBudget(string key, TextBox textBox)
    {
        if (!Budget.ContainsKey(key)) return;
        textBox.Text = Budget[key].ToString();
    }
    /// <summary>
    /// Обновляет TextBlock по значениям из TextBox'ов
    /// </summary>
    /// <param name="planned">TextBox с запланированными затратами</param>
    /// <param name="actual">TextBox с фактическими затратами</param>
    /// <param name="result">TextBlock с разницей</param>
    private void UpdateTextBlock(TextBox planned, TextBox actual, TextBlock result)
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
    /// <summary>
    /// Обновляет бюджет значением из TextBox
    /// </summary>
    /// <param name="key">Ключ, по которому значение нужно обновить</param>
    /// <param name="textBox">TextBox, из которого берётся значение</param>
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
    /// <summary>
    /// Обновляет бюджет значением дохода из TextBox
    /// </summary>
    /// <param name="textBox">TextBox, из которого берётся значение</param>
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
        catch (Exception)
        {
            MessageBox.Show("Введите число!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            textBox.Text = "0";
            return;
        }
        if (Budget.ContainsKey(IncomeType)) Budget[IncomeType] = IncomeValue;
        else Budget.Add(IncomeType, IncomeValue);
    }
    /// <summary>
    /// Обновляет TextBox значением дохода из бюджета
    /// </summary>
    /// <param name="textBox">TextBox, который нужно обновить</param>
    public void UpdateIncomeFromBudget(TextBox textBox)
    {
        string IncomeType = textBox.Name.Substring(7);
        UpdateTextBoxFromBudget(IncomeType, textBox);
    }
    /// <summary>
    /// Обновляет все TextBlock'и на странице
    /// </summary>
    /// <param name="pageName">Название страницы</param>
    /// <param name="page">Страница</param>
    /// <returns></returns>
    public string UpdateTextBlocks(string pageName, Page page)
    {
        try
        {
            for (int i = 1; i <= PagesRowCount[pageName]; i++)
                UpdateTextBlock((TextBox)page.FindName("TextBoxPlanned" + i.ToString()),
                                (TextBox)page.FindName("TextBoxActual" + i.ToString()),
                                (TextBlock)page.FindName("TextBlockLeft" + i.ToString()));
        }
        catch {}
        return UpdateTotal(pageName);
    }
    /// <summary>
    /// Обновляет все TextBox'ы на странице данными из бюджета
    /// </summary>
    /// <param name="pageName">Название страницы</param>
    /// <param name="page">Страница</param>
    public void UpdateTextBoxesFromBudget(string pageName, Page page)
    {
        for (int i = 1; i <= PagesRowCount[pageName]; i++)
        {
            UpdateTextBoxFromBudget(pageName + "Planned" + i.ToString(), (TextBox)page.FindName("TextBoxPlanned" + i.ToString()));
            UpdateTextBoxFromBudget(pageName + "Actual" + i.ToString(), (TextBox)page.FindName("TextBoxActual" + i.ToString()));
        }
    }
    /// <summary>
    /// Получает доходы из бюджета
    /// </summary>
    /// <returns>Возвращает массив с запланированным и фактическим доходами</returns>
    public double[] GetTotalIncome()
    {
        if (!Budget.ContainsKey("PlannedIncome") || !Budget.ContainsKey("ActualIncome")) return new double[2];
        return new double[] { Budget["PlannedIncome"], Budget["ActualIncome"] };
    }
    /// <summary>
    /// Получает сумму расходов из бюджета
    /// </summary>
    /// <returns>Возвращает массив с суммой запланированных и фактических расходов</returns>
    public double[] GetTotalSpending()
    {
        if (Budget.Count == 0) return new double[2];
        var Total  = new double[2]; 
        foreach (KeyValuePair<string, double> kvp in Budget)
        {
            if (kvp.Key.Contains("Income")) continue;
            if (kvp.Key.Contains("Planned")) Total[0] += kvp.Value;
            if (kvp.Key.Contains("Actual")) Total[1] += kvp.Value;
        }
        return Total;
    }
    /// <summary>
    /// Записывает бюджет в файл
    /// </summary>
    public void SaveBudget()
    {
        File.WriteAllText(PathToBudget, JsonSerializer.Serialize(Budget));
    }
    /// <summary>
    /// Загружает бюджет из файла
    /// </summary>
    public void LoadBudget()
    {
        Budget = new Dictionary<string, double>();
        if (!File.Exists(PathToBudget)) return;
        Budget = JsonSerializer.Deserialize<Dictionary<string, double>>(File.ReadAllText(PathToBudget));
    }
    /// <summary>
    /// Обновляет диаграмму данными из бюджета
    /// </summary>
    /// <param name="pageName">Название страницы</param>
    /// <param name="chartControl">UserControl с диаграммой</param>
    public void UpdateChart(string pageName, UserControl chartControl)
    {
        List<double> PlannedValues = new List<double>();
        List<double> ActualValues = new List<double>();
        for (int i = 1; i <= PagesRowCount[pageName]; i++)
        {
            if (Budget.ContainsKey(pageName + "Planned" + i.ToString())) PlannedValues.Add(Budget[pageName + "Planned" + i.ToString()]);
            if (Budget.ContainsKey(pageName + "Actual" + i.ToString())) ActualValues.Add(Budget[pageName + "Actual" + i.ToString()]);
        }
        chartControl.DataContext = new ChartHandler(PlannedValues, ActualValues);
    }
}