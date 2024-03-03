using Lesson07.Models;
using Lesson07.ViewModels;
using System.Windows.Controls;

namespace Lesson07.Views
{
    public partial class SuppliesView : UserControl
    {
        public SuppliesView()
        {
            InitializeComponent();
            DataContext = new SuppliesViewModel();
        }
    }
}
