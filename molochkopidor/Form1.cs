using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace molochkopidor

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            chart.Size = new System.Drawing.Size(900, 900);

            // Создаем область построения
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);
            // Устанавливаем шаг сетки по оси X равным 5
            chartArea.AxisX.MajorGrid.Interval = 5;
            chartArea.AxisX.Interval = 5;

            // Назначаем подписи осей
            chartArea.AxisX.Title = "X";
            chartArea.AxisY.Title = "Y";
            // Добавляем серию и точки
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;

            Series zeroPoints = new Series();
            zeroPoints.ChartType = SeriesChartType.Point;
            zeroPoints.Color = System.Drawing.Color.Red;
            zeroPoints.MarkerSize = 8;
            zeroPoints.MarkerStyle = MarkerStyle.Circle;

            double prevX = -9.999;
            double prevY = prevX * prevX - Math.Sin(3 * prevX);
            series.Points.AddXY(prevX, prevY);

            for (double i = -9.999; i < 10; i += 0.001)
            {
                double y = i * i - Math.Sin(3 * i);
                series.Points.AddXY(i, y);

                if ((prevY > 0 && y <= 0) || (prevY < 0 && y >= 0))
                {
                    // Добавляем точку нуля функции примерно на середине между prevX и i
                    double zeroX = (prevX + i) / 2;
                    double zeroY = 0;
                    zeroPoints.Points.AddXY(zeroX, zeroY);
                }
                prevX = i;
                prevY = y;
            }

            chart.Series.Add(series);
            chart.Series.Add(zeroPoints);
            this.Controls.Add(chart);
        }
    }
}
