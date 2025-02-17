﻿using System.ComponentModel;
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
    public BudgetUpdater budgetUpdater = new();
    public MainWindow()
    {
        InitializeComponent();
    }
    // При закрытии программы: сначала сохранение бюджета, потом закрытие
    protected override void OnClosing(CancelEventArgs e)
    {
        budgetUpdater.SaveBudget();
        base.OnClosing(e);
    }
    /*
     * При нажатии на кнопку: переключение на выбранную страницу
     * (При добавлении новых кнопок их название должно быть "Button" + название страницы,
     * чтобы архитектура не сломалась)
     */
    private void Button_OnClick(object sender, RoutedEventArgs e)
    {
        string name = "Pages/" + ((Button)sender).Name.Substring(6) + ".xaml";
        FrameContent.Source = new Uri(name, UriKind.Relative);
    }
    // При изменении размеров окна: изменение размеров контента в FrameContent
    private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        #region чёрная магия, не трогать!
        Grid1.ColumnDefinitions[0].MaxWidth = e.NewSize.Width * 0.5;
        (FrameContent.Content as Page).Width = e.NewSize.Width * 0.75;
        (FrameContent.Content as Page).Height = e.NewSize.Height * (8.0 / 9);
        #endregion
    }
}