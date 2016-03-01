using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Clear.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BrushConverter bc = new BrushConverter();
        public MainWindow()
        {
            InitializeComponent();

            ClearMainWindow.Background = (Brush)bc.ConvertFrom("#1F1F1F");

            PrepareRows();
            //var rows = Grid1.RowDefinitions;

            //var r1 = rows[0];
            
            //r1.Style.

            /*
            for (int i = 0; i < rows.Count; i++)
            {
                var da = rows[i];
            }
            */
        }

        private void PrepareRows()
        {
            /*
             * .l1{background: #EEB937}
			.l2{background: #ECA235}
			.l3{background: #ED8B34}
			.l4{background: #E96D31}
			.l5{background: #E7512E}
			.l6{background: #E4362D}
			.l7{background: #E4252C}
             */
            Row1.Background = (Brush)bc.ConvertFrom("#E4252C");
            Row2.Background = (Brush)bc.ConvertFrom("#E4362D");
            Row3.Background = (Brush)bc.ConvertFrom("#E7512E");
            Row4.Background = (Brush)bc.ConvertFrom("#E96D31");
            Row5.Background = (Brush)bc.ConvertFrom("#ED8B34");
            Row6.Background = (Brush)bc.ConvertFrom("#ECA235");
            Row7.Background = (Brush)bc.ConvertFrom("#EEB937");
        }
    }
}
