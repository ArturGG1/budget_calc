﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace budget_calc;
public partial class MainWindow : Window
{
    public Dictionary<string, double> budget = new Dictionary<string, double>();
    public MainWindow()
    {
        InitializeComponent();
    }
    private void Button_OnClick(object sender, RoutedEventArgs e)
    {
        //TODO: добавить вкладку "кредиты"              (Credits)
        //TODO: добавить вкладку "страхование"          (Insurance)
        //TODO: добавить вкладку "налоги"               (Taxes)
        //TODO: добавить вкладку "еда"                  (Food)
        //TODO: добавить вкладку "инвестиции"           (Invest)
        //TODO: добавить вкладку "питомцы"              (Pets)
        //TODO: добавить вкладку "пожертвования"        (Gifts)
        //TODO: добавить вкладку "личная гигиена"       (Hygiene)
        //TODO: добавить вкладку "юридические расходы"  (LegalSpending)
        //TODO: добавить вкладку "итоговые затраты"     (TotalSpending)
        string name = ((Button)sender).Name.Substring(6) + ".xaml";
        try
        {
            FrameContent.Source = new Uri(name, UriKind.Relative);
        }
        catch
        {
            MessageBox.Show("Вкладка ещё не добавлена.","Внимание!",MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
    private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        //TODO: разобраться с динамическими размерами
        //Grid1.ColumnDefinitions[0].Width = new GridLength(this.ActualWidth / 8);
    }
}