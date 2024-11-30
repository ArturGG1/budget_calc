using System.Windows;
using System.Windows.Controls;

namespace budget_calc;
//TODO: прописать логику
public partial class Housing : Page
{
    private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
    public Housing()
    {
        InitializeComponent();
        
        UpdateTextBoxFromBudget("HousingPlanned1", TextBoxPlanned1);
        UpdateTextBoxFromBudget("HousingPlanned2", TextBoxPlanned2);
        UpdateTextBoxFromBudget("HousingPlanned3", TextBoxPlanned3);
        UpdateTextBoxFromBudget("HousingPlanned4", TextBoxPlanned4);
        UpdateTextBoxFromBudget("HousingPlanned5", TextBoxPlanned5);
        UpdateTextBoxFromBudget("HousingPlanned6", TextBoxPlanned6);
        UpdateTextBoxFromBudget("HousingPlanned7", TextBoxPlanned7);
        UpdateTextBoxFromBudget("HousingPlanned8", TextBoxPlanned8);
        UpdateTextBoxFromBudget("HousingPlanned9", TextBoxPlanned9);
        UpdateTextBoxFromBudget("HousingPlanned10", TextBoxPlanned10);

        UpdateTextBoxFromBudget("HousingActual1", TextBoxActual1);
        UpdateTextBoxFromBudget("HousingActual2", TextBoxActual2);
        UpdateTextBoxFromBudget("HousingActual3", TextBoxActual3);
        UpdateTextBoxFromBudget("HousingActual4", TextBoxActual4);
        UpdateTextBoxFromBudget("HousingActual5", TextBoxActual5);
        UpdateTextBoxFromBudget("HousingActual6", TextBoxActual6);
        UpdateTextBoxFromBudget("HousingActual7", TextBoxActual7);
        UpdateTextBoxFromBudget("HousingActual8", TextBoxActual8);
        UpdateTextBoxFromBudget("HousingActual9", TextBoxActual9);
        UpdateTextBoxFromBudget("HousingActual10", TextBoxActual10);
    }
    private void UpdateTextBlock(TextBox planned, TextBox actual, TextBlock result)
    {
        if (!string.IsNullOrWhiteSpace(planned.Text) && !string.IsNullOrWhiteSpace(actual.Text))
        {
            try
            {
                double plannedValue = double.Parse(planned.Text);
                double actualValue = double.Parse(actual.Text);
                result.Text = (plannedValue - actualValue).ToString();
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
        UpdateTextBlock(TextBoxPlanned1, TextBoxActual1, TextBlockLeft1);
        UpdateTextBlock(TextBoxPlanned2, TextBoxActual2, TextBlockLeft2);
        UpdateTextBlock(TextBoxPlanned3, TextBoxActual3, TextBlockLeft3);
        UpdateTextBlock(TextBoxPlanned4, TextBoxActual4, TextBlockLeft4);
        UpdateTextBlock(TextBoxPlanned5, TextBoxActual5, TextBlockLeft5);
        UpdateTextBlock(TextBoxPlanned6, TextBoxActual6, TextBlockLeft6);
        UpdateTextBlock(TextBoxPlanned7, TextBoxActual7, TextBlockLeft7);
        UpdateTextBlock(TextBoxPlanned8, TextBoxActual8, TextBlockLeft8);
        UpdateTextBlock(TextBoxPlanned9, TextBoxActual9, TextBlockLeft9);
        UpdateTextBlock(TextBoxPlanned10, TextBoxActual10, TextBlockLeft10);
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
    }

    private void TextBoxPlanned3_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingPlanned3", TextBoxPlanned3);
    }

    private void TextBoxPlanned4_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingPlanned4", TextBoxPlanned4);
    }

    private void TextBoxPlanned5_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingPlanned5", TextBoxPlanned5);
    }

    private void TextBoxPlanned6_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingPlanned6", TextBoxPlanned6);
    }

    private void TextBoxPlanned7_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingPlanned7", TextBoxPlanned7);
    }

    private void TextBoxPlanned8_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingPlanned8", TextBoxPlanned8);
    }

    private void TextBoxPlanned9_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingPlanned9", TextBoxPlanned9);
    }

    private void TextBoxPlanned10_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingPlanned10", TextBoxPlanned10);
    }

    private void TextBoxActual1_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual1", TextBoxActual1);
    }
    private void TextBoxActual2_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual2", TextBoxActual2);
    }

    private void TextBoxActual3_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual3", TextBoxActual3);
    }

    private void TextBoxActual4_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual4", TextBoxActual4);
    }

    private void TextBoxActual5_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual5", TextBoxActual5);
    }

    private void TextBoxActual6_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual6", TextBoxActual6);
    }

    private void TextBoxActual7_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual7", TextBoxActual7);
    }

    private void TextBoxActual8_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual8", TextBoxActual8);
    }

    private void TextBoxActual9_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual9", TextBoxActual9);
    }

    private void TextBoxActual10_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("HousingActual10", TextBoxActual10);
    }
}