using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel.Events;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using SkiaSharp;
namespace budget_calc;

public class ViewModel
{
    // you can convert any array, list or IEnumerable<T> to a pie series collection:
    public IEnumerable<ISeries> Series { get; set; } =
        new[] { 2, 4, 1, 4, 3 }.AsPieSeries();

    // the expression above is equivalent to the next series collection:
    public IEnumerable<ISeries> Series2 { get; set; } =
    [
        new PieSeries<int> { Values = [2] },
        new PieSeries<int> { Values = [4] },
        new PieSeries<int> { Values = [1] },
        new PieSeries<int> { Values = [4] },
        new PieSeries<int> { Values = [3] },
    ];

    public LabelVisual Title { get; set; } =
        new LabelVisual
        {
            Text = "прочитал - клоун!!!",
            TextSize = 25,
            Padding = new LiveChartsCore.Drawing.Padding(0)
        };
}