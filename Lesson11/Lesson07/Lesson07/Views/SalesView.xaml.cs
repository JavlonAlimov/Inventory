using Lesson07.ViewModels;
using System.Windows.Controls;

namespace Lesson07.Views
{
    public partial class SalesView : UserControl
    {
        public SalesView()
        {
            InitializeComponent();
            DataContext = new SalesViewModal();
        }
    }
}
