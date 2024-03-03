using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lesson07.Views
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        public ObservableCollection<LineChartModel> DataPoints { get; private set; }
        public ObservableCollection<SalesByCategoryModel> CategoryDataPoints { get; private set; }
        public decimal TotalSales { get; set; } = 550;
        public decimal TotalSupplies { get; set; } = 420;
        public int LowStockProducts { get; set; } = 12;

        public DashboardView()
        {
            InitializeComponent();

            DataContext = this;

            LoadData();
        }

        private void LoadData()
        {
            DataPoints = new ObservableCollection<LineChartModel>();
            CategoryDataPoints = new ObservableCollection<SalesByCategoryModel>();
            DateTime year = new DateTime(2020, 1, 1);

            DataPoints.Add(new LineChartModel { Year = year.AddYears(1), Sales = 20, Supplies = 30 } );
            DataPoints.Add(new LineChartModel { Year = year.AddYears(2), Sales = 35, Supplies = 80 });
            DataPoints.Add(new LineChartModel { Year = year.AddYears(3), Sales = 40, Supplies = 23 });
            DataPoints.Add(new LineChartModel { Year = year.AddYears(4), Sales = 65, Supplies = 30 });
            DataPoints.Add(new LineChartModel { Year = year.AddYears(5), Sales = 76, Supplies = 62 });
            DataPoints.Add(new LineChartModel { Year = year.AddYears(6), Sales = 22, Supplies = 45 });
            DataPoints.Add(new LineChartModel { Year = year.AddYears(7), Sales = 29, Supplies = 15 });
            DataPoints.Add(new LineChartModel { Year = year.AddYears(8), Sales = 40, Supplies = 32 });

            CategoryDataPoints.Add(new SalesByCategoryModel { Category = "Category 1", Percentage = 20 });
            CategoryDataPoints.Add(new SalesByCategoryModel { Category = "Category 2", Percentage = 10 });
            CategoryDataPoints.Add(new SalesByCategoryModel { Category = "Category 3", Percentage = 10 });
            CategoryDataPoints.Add(new SalesByCategoryModel { Category = "Category 4", Percentage = 15 });
            CategoryDataPoints.Add(new SalesByCategoryModel { Category = "Category 5", Percentage = 15 });
            CategoryDataPoints.Add(new SalesByCategoryModel { Category = "Category 6", Percentage = 30 });
        }
    }

    public class LineChartModel
    {
        public DateTime Year { get; set; }
        public double Supplies { get; set; }
        public double Sales { get; set; }
    }

    public class SalesByCategoryModel
    {
        public string Category { get; set; }
        public double Percentage { get; set; }
    }
}
