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

//using System.Drawing;
using Clear.Model;

namespace Clear.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BrushConverter bc = new BrushConverter();
        ITaskRepository taskRepository;

        public MainWindow()
        {
            taskRepository = new TaskRepository();
            InitializeComponent();

            ClearMainWindow.Background = (Brush)bc.ConvertFrom("#1F1F1F");

            AddRows();
            //PrepareRows();
        }

        private void AddRows()
        {
            int totalRows = 10;
            RowDefinition rowDefinition;
            Grid gridRecord;
            TextBlock textBlockRecord;

            // starter color
            int jump = 5;
            //byte lastR = 228, lastG = 54, lastB = 45;
            byte lastR = 17, lastG = 127, lastB = 248;
            //byte lastR = 87, lastG = 163, lastB = 13;
            //byte lastR = 88, lastG = 164, lastB = 14;
            //byte lastR = 127, lastG = 47, lastB = 246;

            Color rowColor = new Color() { R = lastR, G = lastG, B = lastB };
            HSLColor rowHsl = new HSLColor(rowColor.R, rowColor.G, rowColor.B);
            string rowHex = RGBToHex(rowColor);

            var tasks = taskRepository.GetTasks();
            
            int i = 0;
            foreach (var task in tasks)
            {
                textBlockRecord = new TextBlock();
                gridRecord = new Grid();
                rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(40);

                // color
                if (i > 0)
                {
                    rowHsl = new HSLColor(((rowHsl.Hue) + jump), rowHsl.Saturation + 2, rowHsl.Luminosity + 2);
                    rowColor = new Color() { R = rowHsl.GetR(), G = rowHsl.GetG(), B = rowHsl.GetB() };
                    rowHex = RGBToHex(rowColor);
                }

                // add row definition
                Grid1.RowDefinitions.Add(rowDefinition);

                gridRecord.Background = (Brush)bc.ConvertFrom(rowHex);

                Grid.SetRow(gridRecord, i);
                Grid.SetColumn(gridRecord, i);

                textBlockRecord.Text = task.Name;
                textBlockRecord.Style = (Style)FindResource("RowCommonStyle");

                // add textblock to grid record
                gridRecord.Children.Add(textBlockRecord);

                // add record to grid
                Grid1.Children.Add(gridRecord);
                i++;
            }


        }

        string RGBToHex(Color myColor)
        {
            return "#" + myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
        }
    }
}
