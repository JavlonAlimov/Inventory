using Lesson07.ViewModels;
using System.Windows.Controls;

namespace Lesson07.Views
{
    public partial class CategoriesView : UserControl
    {
        public CategoriesView()
        {
            InitializeComponent();

            DataContext = new CategoriesViewModel();
        }
        protected override async void OnInitialized(EventArgs e)
        {
            if (DataContext is CategoriesViewModel vm)
            {
                await vm.LoadAsync();
            }
            base.OnInitialized(e);
        }
    }
}
