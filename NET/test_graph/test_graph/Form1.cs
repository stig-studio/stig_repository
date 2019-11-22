using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using test_graph.module;

namespace test_graph {

    public partial class Form1 : Form {

        Chart chart;

        List<double> x, y;
        double step = 1;

        public Form1() {

            InitializeComponent();
            
            chart = new Chart();
            chart.Dock = DockStyle.Fill;

            x = new List<double>();
            y = new List<double>();
            x.Add( 0.0 );
            y.Add( 0.0 );

            chart.ChartAreas.Add( "area" );
            chart.Series.Add( "serie" );
            chart.Series["serie"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart.Series["serie"].BorderWidth = 3;
            chart.Series["serie"].Color = Color.Green;

            chart.ChartAreas["area"].AxisX.MajorGrid.Interval = step;

            panel_graph.Controls.Add( chart );
        }

        private void btn_create_Click(object sender, EventArgs e) {

            chart.Series["serie"].Points.Clear();

            x.Add( x.Last() + step );
            y.Add( Convert.ToDouble( this.txtb_temp.Text ) );

            chart.Series["serie"].Points.DataBindXY( x, y );
            
        }
    }
}