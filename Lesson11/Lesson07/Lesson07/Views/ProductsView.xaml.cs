using Lesson07.ViewModels;
using System.Windows.Controls;

namespace Lesson07.Views
{
    /// <summary>
    /// Interaction logic for ProductsView.xaml
    /// </summary>
    public partial class ProductsView : UserControl
    {
        public ProductsView()
        {
            DataContext = new ProductsViewModel();

            InitializeComponent();
        }

        protected override async void OnInitialized(EventArgs e)
        {
            if (DataContext is ProductsViewModel vm)
            {
                await vm.LoadData();
            }

            base.OnInitialized(e);
        }
    }
}
