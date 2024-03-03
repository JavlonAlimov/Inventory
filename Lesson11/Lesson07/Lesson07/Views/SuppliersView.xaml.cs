using Lesson07.ViewModels;
using System.Windows.Controls;

namespace Lesson07.Views
{
    public partial class SuppliersView : UserControl
    {
        public SuppliersView()
        {
            InitializeComponent();
            DataContext = new SuppliersViewModal();
        }
        protected override async void OnInitialized(EventArgs e)
        {
            if (DataContext is CustomersViewModel vm)
            {
                await vm.LoadAsync();
            }
            base.OnInitialized(e);
        }
    }
}
