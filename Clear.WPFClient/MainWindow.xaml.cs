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

            for (int i = 0; i <= totalRows; i++)
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

                textBlockRecord.Text = "Test " + i.ToString();
                textBlockRecord.Style = (Style)FindResource("RowCommonStyle");

                // add textblock to grid record
                gridRecord.Children.Add(textBlockRecord);

                // add record to grid
                Grid1.Children.Add(gridRecord);
            }
        }

        /*
        private void PrepareRows()
        {
            int jump = 5;

            // color1 is bright red:
            // Hue 0.0 (red), saturation 240.0 (full), luminosity 120.0 (normal)
            Color row1Color = new Color() { R = 228, G = 54, B = 45 };
            HSLColor row1Hsl = new HSLColor(row1Color.R, row1Color.G, row1Color.B);
            var row1Hex = RGBToHex(row1Color);

            var row2Hsl = new HSLColor(((row1Hsl.Hue) + jump), row1Hsl.Saturation, row1Hsl.Luminosity);
            var row2Color = new Color() { R = row2Hsl.GetR(), G = row2Hsl.GetG(), B = row2Hsl.GetB() };
            var row2Hex = RGBToHex(row2Color);

            var row3Hsl = new HSLColor(((row2Hsl.Hue) + jump), row2Hsl.Saturation, row2Hsl.Luminosity);
            var row3Color = new Color() { R = row3Hsl.GetR(), G = row3Hsl.GetG(), B = row3Hsl.GetB() };
            var row3Hex = RGBToHex(row3Color);

            var row4Hsl = new HSLColor(((row3Hsl.Hue) + jump), row3Hsl.Saturation, row3Hsl.Luminosity);
            var row4Color = new Color() { R = row4Hsl.GetR(), G = row4Hsl.GetG(), B = row4Hsl.GetB() };
            var row4Hex = RGBToHex(row4Color);

            var row5Hsl = new HSLColor(((row4Hsl.Hue) + jump), row4Hsl.Saturation, row4Hsl.Luminosity);
            var row5Color = new Color() { R = row5Hsl.GetR(), G = row5Hsl.GetG(), B = row5Hsl.GetB() };
            var row5Hex = RGBToHex(row5Color);

            var row6Hsl = new HSLColor(((row5Hsl.Hue) + jump), row5Hsl.Saturation, row5Hsl.Luminosity);
            var row6Color = new Color() { R = row6Hsl.GetR(), G = row6Hsl.GetG(), B = row6Hsl.GetB() };
            var row6Hex = RGBToHex(row6Color);

            var row7Hsl = new HSLColor(((row6Hsl.Hue) + jump), row6Hsl.Saturation, row6Hsl.Luminosity);
            var row7Color = new Color() { R = row7Hsl.GetR(), G = row7Hsl.GetG(), B = row7Hsl.GetB() };
            var row7Hex = RGBToHex(row7Color);

            Row1.Background = (Brush)bc.ConvertFrom(row1Hex);
            Row2.Background = (Brush)bc.ConvertFrom(row2Hex);
            Row3.Background = (Brush)bc.ConvertFrom(row3Hex);
            Row4.Background = (Brush)bc.ConvertFrom(row4Hex);
            Row5.Background = (Brush)bc.ConvertFrom(row5Hex);
            Row6.Background = (Brush)bc.ConvertFrom(row6Hex);
            Row7.Background = (Brush)bc.ConvertFrom(row7Hex);


            
        }
        */

        /*
            Row1.Background = (Brush)bc.ConvertFrom("#E4252C");
            Row2.Background = (Brush)bc.ConvertFrom("#E4362D");
            Row3.Background = (Brush)bc.ConvertFrom("#E7512E");
            Row4.Background = (Brush)bc.ConvertFrom("#E96D31");
            Row5.Background = (Brush)bc.ConvertFrom("#ED8B34");
            Row6.Background = (Brush)bc.ConvertFrom("#ECA235");
            Row7.Background = (Brush)bc.ConvertFrom("#EEB937");
            */

        string RGBToHex(Color myColor)
        {
            return "#" + myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
        }
    }
}
