using GalaSoft.MvvmLight;
using Lesson07.Models;
using Lesson07.TestDataCreator;
using Lesson07.Views;
using MaterialDesignThemes.Wpf;
using MvvmHelpers;
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
using System.Windows.Threading;

namespace Lesson07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<SampleItem> SampleList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            SampleList =
            [
                new SampleItem
                {
                    Title = "Home",
                    SelectedIcon = PackIconKind.Home,
                    UnselectedIcon = PackIconKind.HomeOutline,
                    Notification = 1
                },
                new SampleItem
                {
                    Title = "Products",
                    SelectedIcon = PackIconKind.Package,
                    UnselectedIcon = PackIconKind.HomeOutline,
                },
                new SampleItem
                {
                    Title = "Categories",
                    SelectedIcon = PackIconKind.Category,
                    UnselectedIcon = PackIconKind.StarOutline,
                },
                new SampleItem
                {
                    Title = "Customers",
                    SelectedIcon = PackIconKind.PeopleGroup,
                    UnselectedIcon = PackIconKind.UsersOutline,
                },
                new SampleItem
                {
                    Title = "Sales",
                    SelectedIcon = PackIconKind.Finance,
                    UnselectedIcon = PackIconKind.FolderOutline,
                },
                new SampleItem
                {
                    Title = "Suppliers",
                    SelectedIcon = PackIconKind.People,
                    UnselectedIcon = PackIconKind.Bookshelf,
                },
                new SampleItem
                {
                    Title = "Supplies",
                    SelectedIcon = PackIconKind.Dolly,
                    UnselectedIcon = PackIconKind.Bookshelf,
                },
            ];
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is not ListBox listBox) return;

            var selectedIndex = listBox.SelectedIndex;

            UserControl content = selectedIndex switch
            {
                0 => new DashboardView(),
                1 => new ProductsView(),
                2 => new CategoriesView(),
                3 => new CustomersView(),
                4 => new SalesView(),
                5 => new SuppliersView(),
                6=> new SuppliesView(),
                _ => new DashboardView()
            };

            mainContent.Content = content;
        }

        private void Close_Clicked(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to close application?", "Confirm action", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Close();
                
            }
        }

        private void Minimize_Clicked(object sender, RoutedEventArgs e)
        {
            //change the WindowStyle to single border just before minimising it
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            this.WindowState = WindowState.Minimized;
        }

        protected override void OnActivated(EventArgs e)
        {
            //change the WindowStyle back to None, but only after the Window has been activated
            Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() => WindowStyle = WindowStyle.None));
            base.OnActivated(e);
        }
    }

    public class SampleItem : BaseViewModel
    {
        public string? Title { get; set; }
        public PackIconKind SelectedIcon { get; set; }
        public PackIconKind UnselectedIcon { get; set; }
        private object? _notification = null;

        public object? Notification
        {
            get { return _notification; }
            set { SetProperty(ref _notification, value); }
        }
    }
}