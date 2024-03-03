using Lesson07.ViewModels;
using System.Windows.Controls;

namespace Lesson07.Views
{
    public partial class CustomersView : UserControl
    {
        public CustomersView()
        {
            InitializeComponent();
            DataContext = new CustomersViewModel();
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
