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
using OxyPlot;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.Wpf;

namespace OxyPlot_testing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var myModel = new PlotModel { PlotMargins = new OxyThickness(10), Padding = new OxyThickness(50, 30, 50, 30) };
            var lb = new Legend() { LegendPlacement = LegendPlacement.Outside, LegendPosition = LegendPosition.RightBottom, LegendOrientation = LegendOrientation.Vertical };
            myModel.Legends.Add(lb);

            var pieSeries = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.5,
                AngleSpan = 360,
                StartAngle = 0
            };
            pieSeries.OutsideLabelFormat = "{1}\n{0:0}";
            pieSeries.TickHorizontalLength = 5;
            pieSeries.TickRadialLength = 15;
            pieSeries.InsideLabelFormat = "{2:0}%";
            pieSeries.InsideLabelPosition = 0.7;
            pieSeries.TrackerFormatString = "{1}: {2:0.#} ({3:P1})";

            // Add slices to the pie series
            pieSeries.Slices.Add(new PieSlice("Slice 1", 40) { IsExploded = true });
            pieSeries.Slices.Add(new PieSlice("Slice 2", 30) { IsExploded = false });
            pieSeries.Slices.Add(new PieSlice("Slice 3", 10) { IsExploded = false });
            pieSeries.Slices.Add(new PieSlice("Slice 4", 20) { IsExploded = false });

            myModel.Series.Add(pieSeries);

            // Set the model to the plot view
            PieChartPlotView.Model = myModel;
        }
    }
}