using System.Collections.ObjectModel;
using System.Windows;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;

namespace budget_calc;

public class ChartHandler
{
    private readonly BudgetUpdater budgetUpdater = ((MainWindow)Application.Current.MainWindow).budgetUpdater;
    public ObservableCollection<ISeries[]> Series;
    public ObservableCollection<ObservablePoint> PlannedValues = new();
    public ObservableCollection<ObservablePoint> ActualValues = new();
    public ChartHandler(string pageName)
    {
        List<double> pv;
        List<double> av;
        (pv, av) = budgetUpdater.GetValues(pageName);
        for (int i = 0; i < pv.Count; i++) PlannedValues.Add(new ObservablePoint(i, pv[i]));
        for (int i = 0; i < av.Count; i++) ActualValues.Add(new ObservablePoint(i, av[i]));
        //TODO: когда-нибудь
    }
}