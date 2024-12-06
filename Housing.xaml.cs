using System.Windows;
using System.Windows.Controls;

namespace budget_calc;
public partial class Housing : Page
{
    private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
    private const int RowCount = 10;
    public Housing()
    {
        InitializeComponent();
        for (int i = 1; i <= RowCount; i++)
        {
            UpdateTextBoxFromBudget("HousingPlanned" + i.ToString(), (TextBox)this.FindName("TextBoxPlanned" + i.ToString()));
            UpdateTextBoxFromBudget("HousingActual" + i.ToString(), (TextBox)this.FindName("TextBoxActual" + i.ToString()));
        }
    }
    private void UpdateTextBlock(TextBox planned, TextBox actual, TextBlock result)
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
    private void UpdateTextBlocks()
    {
        for (int i = 1; i <= RowCount; i++)
        {
            try
            {
                UpdateTextBlock((TextBox)this.FindName("TextBoxPlanned" + i.ToString()),
                                 (TextBox)this.FindName("TextBoxActual" + i.ToString()),
                                  (TextBlock)this.FindName("TextBlockLeft" + i.ToString()));
            }
            catch {}
        }
        double total = 0;
        for (int i = 1; i <= RowCount; i++)
        {
            if (mainWindow.budget.ContainsKey("HousingPlanned" + i.ToString()) && mainWindow.budget.ContainsKey("HousingActual" + i.ToString()))
            {
                total += (mainWindow.budget["HousingPlanned" + i.ToString()] - mainWindow.budget["HousingActual" + i.ToString()]);
            }
        }
        TextBlockTotal.Text = total.ToString() + " руб.";
    }
    private void UpdateTextBoxFromBudget(string key, TextBox textBox)
    {
        if (mainWindow.budget.ContainsKey(key))
        {
            textBox.Text = mainWindow.budget[key].ToString();
        }
    }
    private void UpdateBudget(string key, TextBox textBox)
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
    private void TextBoxPlanned1_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingPlanned1", TextBoxPlanned1);
        UpdateTextBlocks();
    }

    private void TextBoxPlanned2_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingPlanned2", TextBoxPlanned2);
        UpdateTextBlocks();
    }

    private void TextBoxPlanned3_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingPlanned3", TextBoxPlanned3);
        UpdateTextBlocks();
    }

    private void TextBoxPlanned4_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingPlanned4", TextBoxPlanned4);
        UpdateTextBlocks();
    }

    private void TextBoxPlanned5_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingPlanned5", TextBoxPlanned5);
        UpdateTextBlocks();
    }

    private void TextBoxPlanned6_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingPlanned6", TextBoxPlanned6);
        UpdateTextBlocks();
    }

    private void TextBoxPlanned7_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingPlanned7", TextBoxPlanned7);
        UpdateTextBlocks();
    }

    private void TextBoxPlanned8_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingPlanned8", TextBoxPlanned8);
        UpdateTextBlocks();
    }

    private void TextBoxPlanned9_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingPlanned9", TextBoxPlanned9);
        UpdateTextBlocks();
    }

    private void TextBoxPlanned10_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingPlanned10", TextBoxPlanned10);
        UpdateTextBlocks();
    }

    private void TextBoxActual1_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual1", TextBoxActual1);
        UpdateTextBlocks();
    }
    private void TextBoxActual2_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual2", TextBoxActual2);
        UpdateTextBlocks();
    }

    private void TextBoxActual3_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual3", TextBoxActual3);
        UpdateTextBlocks();
    }

    private void TextBoxActual4_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual4", TextBoxActual4);
        UpdateTextBlocks();
    }

    private void TextBoxActual5_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual5", TextBoxActual5);
        UpdateTextBlocks();
    }

    private void TextBoxActual6_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual6", TextBoxActual6);
        UpdateTextBlocks();
    }

    private void TextBoxActual7_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual7", TextBoxActual7);
        UpdateTextBlocks();
    }

    private void TextBoxActual8_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual8", TextBoxActual8);
        UpdateTextBlocks();
    }

    private void TextBoxActual9_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual9", TextBoxActual9);
        UpdateTextBlocks();
    }

    private void TextBoxActual10_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual10", TextBoxActual10);
        UpdateTextBlocks();
    }
}