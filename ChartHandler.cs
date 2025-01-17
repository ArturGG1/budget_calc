using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Drawing;
using LiveChartsCore.Kernel.Events;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace budget_calc;

public partial class ChartHandler
{
    // Значения для диаграммы
    private readonly ObservableCollection<ObservablePoint> PlannedValues = new();
    private readonly ObservableCollection<ObservablePoint> ActualValues = new();
    // Переменная, через которую диаграмма получает необходимые данные
    public ISeries[] Series { get; set; }
    // Реальный конструктор, заполняющий Series
    public ChartHandler(List<double> plannedValues, List<double> actualValues)
    {
        for (var i = 0; i < plannedValues.Count; i++) PlannedValues.Add(new ObservablePoint(i, plannedValues[i]));
        for (var i = 0; i < actualValues.Count; i++) ActualValues.Add(new ObservablePoint(i, actualValues[i]));
        Series = new ISeries[]
        {
            new ColumnSeries<ObservablePoint>
            {
                Name = "Запланировано: ",
                Values = PlannedValues,
                DataPadding = new(0, 1),
                Fill = new SolidColorPaint(SKColors.CornflowerBlue)
            },
            new ColumnSeries<ObservablePoint>
            {
                Name = "Фактически: ",
                Values = ActualValues,
                DataPadding = new LvcPoint(0, 1),
                Fill = new SolidColorPaint(SKColors.IndianRed)
            }
        }; 
    }
    // Конструктор по умолчанию не убирать! Иначе страница не загрузится, а программа умрёт!
    public ChartHandler()
    {
        return;
    }
}