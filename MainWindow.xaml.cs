using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hanoi_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            int dieAmount = 8;

            // Generate grids
            Grid[] towerGrids = new Grid[3];
            for (int i = 0; i < towerGrids.Length; i++)
            {
                towerGrids[i] = new Grid();
                towerGrids[i].ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(10) }); // Padding
                towerGrids[i].RowDefinitions.Add(new RowDefinition() { Height = new GridLength(10) }); // Padding

                // Add rows and columns for each die
                for (int dieI = 0; dieI < dieAmount; dieI++)
                {
                    // Add 2 "*" length column
                    towerGrids[i].ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                    towerGrids[i].ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                    // Add 1 "*" length row
                    towerGrids[i].RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                }
                towerGrids[i].ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(10) }); // Padding

                // Add this grid to the main grid
                Grid_Main.Children.Add(towerGrids[i]);
                towerGrids[i].SetValue(Grid.RowProperty, 3);
                towerGrids[i].SetValue(Grid.ColumnProperty, i+1);
            }

            // Generate dies
            Rectangle[] dies = new Rectangle[dieAmount];
            for (int i=0; i<dieAmount; i++)
            {
                dies[i] = new Rectangle()
                {
                    Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF820000"),
                    Stroke = Brushes.Black,
                    Name = "Die_" + i
                };

                // Add this die to the leftmost grid
                towerGrids[0].Children.Add(dies[i]);
                dies[i].SetValue(Grid.RowProperty, dieAmount-i);
                dies[i].SetValue(Grid.ColumnProperty, i+1);
                dies[i].SetValue(Grid.ColumnSpanProperty, (dieAmount-i)*2);
            }
        }
    }
}
