using System.Text;
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
    private void ButtonOverview_OnClick(object sender, RoutedEventArgs e)
    {
        FrameContent.Source = new Uri("Overview.xaml", UriKind.Relative);
    }

    private void ButtonIncome_OnClick(object sender, RoutedEventArgs e)
    {
        FrameContent.Source = new Uri("Income.xaml", UriKind.Relative);
    }

    private void ButtonHousing_OnClick(object sender, RoutedEventArgs e)
    {
        FrameContent.Source = new Uri("Housing.xaml", UriKind.Relative);
    }

    private void ButtonEntertainment_OnClick(object sender, RoutedEventArgs e)
    {
        FrameContent.Source = new Uri("Entertainment.xaml", UriKind.Relative);
    }

    private void ButtonTransport_OnClick(object sender, RoutedEventArgs e)
    {
        //TODO: добавить вкладку "транспорт"
    }

    private void ButtonCredits_OnClick(object sender, RoutedEventArgs e)
    {
        //TODO: добавить вкладку "кредиты"
    }

    private void ButtonInsurance_OnClick(object sender, RoutedEventArgs e)
    {
        //TODO: добавить вкладку "страхование"
    }

    private void ButtonTaxes_OnClick(object sender, RoutedEventArgs e)
    {
        //TODO: добавить вкладку "налоги"
    }

    private void ButtonFood_OnClick(object sender, RoutedEventArgs e)
    {
        //TODO: добавить вкладку "еда"
    }

    private void ButtonInvest_OnClick(object sender, RoutedEventArgs e)
    {
        //TODO: добавить вкладку "инвестиции"
    }

    private void ButtonPets_OnClick(object sender, RoutedEventArgs e)
    {
        //TODO: добавить вкладку "питомцы"
    }

    private void ButtonGifts_OnClick(object sender, RoutedEventArgs e)
    {
        //TODO: добавить вкладку "пожертвования"
    }

    private void ButtonHygiene_OnClick(object sender, RoutedEventArgs e)
    {
        //TODO: добавить вкладку "личная гигиена"
    }

    private void ButtonLegalSpending_OnClick(object sender, RoutedEventArgs e)
    {
        //TODO: добавить вкладку "юридические расходы"
    }

    private void ButtonTotalSpending_OnClick(object sender, RoutedEventArgs e)
    {
        //TODO: добавить вкладку "итоговые затраты"
    }

    private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        //TODO: разобраться с динамическими размерами
        //Grid1.ColumnDefinitions[0].Width = new GridLength(this.ActualWidth / 8);
    }
}