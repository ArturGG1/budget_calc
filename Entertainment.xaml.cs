using System.Windows;
using System.Windows.Controls;

namespace budget_calc;
public partial class Entertainment : Page
{
    private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
    private const int RowCount = 7;
    
    public Entertainment()
    {
        InitializeComponent();
        for (int i = 1; i <= RowCount; i++)
        {
            UpdateTextBoxFromBudget("EntertainmentPlanned" + i.ToString(), (TextBox)this.FindName("TextBoxPlanned" + i.ToString()));
            UpdateTextBoxFromBudget("EntertainmentActual" + i.ToString(), (TextBox)this.FindName("TextBoxActual" + i.ToString()));
        }
    }

    private void UpdateTextBoxFromBudget(string key, TextBox textBox)
    {
        if (mainWindow.budget.ContainsKey(key))
        {
            textBox.Text = mainWindow.budget[key].ToString();
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
        double total = 0;
        for (int i = 1; i <= RowCount; i++)
        {
            try
            {
                UpdateTextBlock((TextBox)this.FindName("TextBoxPlanned" + i.ToString()),
                                (TextBox)this.FindName("TextBoxActual" + i.ToString()),
                                (TextBlock)this.FindName("TextBlockLeft" + i.ToString()));

                if (mainWindow.budget.ContainsKey("EntertainmentPlanned" + i.ToString()) && mainWindow.budget.ContainsKey("EntertainmentActual" + i.ToString()))
                {
                    total += (mainWindow.budget["EntertainmentPlanned" + i.ToString()] - mainWindow.budget["EntertainmentActual" + i.ToString()]);
                }
            }
            catch {}
        }
        TextBlockTotal.Text = total.ToString() + " руб.";
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
        UpdateBudget("EntertainmentPlanned1", (TextBox)sender);
        UpdateTextBlocks();
    }

    private void TextBoxPlanned2_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("EntertainmentPlanned2", (TextBox)sender);
        UpdateTextBlocks();
    }

    private void TextBoxPlanned3_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("EntertainmentPlanned3", (TextBox)sender);
        UpdateTextBlocks();
    }

    private void TextBoxPlanned4_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("EntertainmentPlanned4", (TextBox)sender);
        UpdateTextBlocks();
    }

    private void TextBoxPlanned5_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("EntertainmentPlanned5", (TextBox)sender);
        UpdateTextBlocks();
    }

    private void TextBoxPlanned6_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("EntertainmentPlanned6", (TextBox)sender);
        UpdateTextBlocks();
    }

    private void TextBoxPlanned7_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("EntertainmentPlanned7", (TextBox)sender);
        UpdateTextBlocks();
    }

    private void TextBoxActual1_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("EntertainmentActual1", (TextBox)sender);
        UpdateTextBlocks();
    }

    private void TextBoxActual2_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("EntertainmentActual2", (TextBox)sender);
        UpdateTextBlocks();
    }

    private void TextBoxActual3_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("EntertainmentActual3", (TextBox)sender);
        UpdateTextBlocks();
    }

    private void TextBoxActual4_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("EntertainmentActual4", (TextBox)sender);
        UpdateTextBlocks();
    }

    private void TextBoxActual5_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("EntertainmentActual5", (TextBox)sender);
        UpdateTextBlocks();
    }

    private void TextBoxActual6_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("EntertainmentActual6", (TextBox)sender);
        UpdateTextBlocks();
    }

    private void TextBoxActual7_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateBudget("EntertainmentActual7", (TextBox)sender);
        UpdateTextBlocks();
    }
}