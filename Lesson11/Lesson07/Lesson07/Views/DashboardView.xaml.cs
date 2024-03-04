using Lesson07.Stores;
using Lesson07.ViewModels;
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

        public DashboardView()
        {
            DataContext = new DashboardViewModal();

            InitializeComponent();
        }
        protected override async void OnInitialized(EventArgs e)
        {
            if (DataContext is DashboardViewModal vm)
            {
                await vm.LoadData();
            }

            base.OnInitialized(e);
        }


    }

  
}
