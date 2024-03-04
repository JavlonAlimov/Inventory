using Lesson07.Constants;
using Lesson07.Data;
using Lesson07.Models;
using Lesson07.Stores;
using Lesson07.ViewModels.Dialogs;
using Lesson07.Views.Dialogs;
using MaterialDesignThemes.Wpf;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;

namespace Lesson07.ViewModels
{
    internal class SalesViewModal : BaseViewModel
    {
        private readonly SalesDataStore store;
        private readonly CustomersDataStore _customersStore;
        private readonly ProductsDataStore _productsStore;

        public ObservableCollection<Sale> Sales { get; set; }

        private DateTime _selectedDate = DateTime.Now;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                SetProperty(ref _selectedDate, value);
                FiltrSales();
            }
        }

        private DateTime _startDate = new(DateTime.Now.Year, DateTime.Now.Month, 1);
        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        private DateTime _endDate = DateTime.Now;
        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        private Sale _selectedSales;
        public Sale SelectedSales
        {
            get => _selectedSales;
            set => SetProperty(ref _selectedSales, value);
        }

        #region Variables

        private int _totalPages;
        public int TotalPages
        {
            get => _totalPages;
            set => SetProperty(ref _totalPages, value);
        }
        private int _currentPage = 1;
        public int CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value);
        }
        private int _pageList = 15;
        public int PageList
        {
            get => _pageList;
            set => SetProperty(ref _pageList, value);
        }

        #endregion

        #region  Elements

        private string _pageString;
        public string PageString
        {
            get => _pageString;
            set => SetProperty(ref _pageString, value);
        }

        #endregion

        #region Pagination properties

        private bool _isEnablePrimaryPage = false;
        public bool IsEnablePrimaryPage
        {
            get => _isEnablePrimaryPage;
            set => SetProperty(ref _isEnablePrimaryPage, value);
        }

        private bool _isEnablePrevPage = false;
        public bool IsEnablePrevPage
        {
            get => _isEnablePrevPage;
            set => SetProperty(ref _isEnablePrevPage, value);
        }

        private bool _isEnableNextPage = true;
        public bool IsEnableNextPage
        {
            get => _isEnableNextPage;
            set => SetProperty(ref _isEnableNextPage, value);
        }

        private bool _isEnableLastPage = true;
        public bool IsEnableLastPage
        {
            get => _isEnableLastPage;
            set => SetProperty(ref _isEnableLastPage, value);
        }
        #endregion

        #region Commands
        public IAsyncCommand CreateCommand { get; }
        public IAsyncCommand PrimaryPageCommand { get; }
        public IAsyncCommand PrevPageCommand { get; }
        public IAsyncCommand NextPageCommand { get; }
        public IAsyncCommand LastPageCommand { get; }
        public IAsyncCommand FifteenPageCommand { get; }
        public IAsyncCommand ThirtyPageCommand { get; }
        public IAsyncCommand FiftyPageCommand { get; }

        #endregion

        public SalesViewModal()
        {
            store = new SalesDataStore();
            _productsStore = new ProductsDataStore();
            _customersStore = new CustomersDataStore();
            Sales = new ObservableCollection<Sale>();

            CreateCommand = new AsyncCommand(OnCreate);
            NextPageCommand = new AsyncCommand(OnNextPage);
            PrevPageCommand = new AsyncCommand(OnPrevPage);
            LastPageCommand = new AsyncCommand(OnLastPage);
            PrimaryPageCommand = new AsyncCommand(OnPrimaryPage);
            FifteenPageCommand = new AsyncCommand(OnFifteenPage);
            ThirtyPageCommand = new AsyncCommand(OnThirtyPage);
            FiftyPageCommand = new AsyncCommand(OnFiftyPage);

            Load();
        }

        private async Task FiltrSales()
        {

            var products = await store.GetSales(_pageList, CurrentPage, SelectedDate);

            Sales.Clear();

            foreach (var product in products)
            {
                Sales.Add(product);
            }
        }

        private async Task Load()
        {
            await GetTotalPages();

            var listOnePage = await store.GetSales(_pageList, _currentPage);
            Sales.Clear();
            foreach (var item in listOnePage)
            {
                Sales.Add(item);
            }

            PageString = $"{CurrentPage} page of {TotalPages}";
        }

        public async Task GetTotalPages()
        {
            try
            {
                int salesCount = await store.GetCountSalesAsync();

                if (salesCount <= 0)
                {
                    return;
                }

                _totalPages = salesCount / _pageList +
                    (salesCount % _pageList == 0 ? 0 : 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public async Task OnCreate()
        {
            try
            {
                var customers = await _customersStore.GetCustomersAsync();
                var products = await _productsStore.GetProductsAsync();

                var dialog = new SaleDialog()
                {
                    DataContext = new SaleDialogViewModel(products, customers)
                };

                var result = await DialogHost.Show(dialog, DialogAreas.MainDialog);

                if (result is not Sale sale)
                {
                    return;
                }
                await Task.Delay(1000);
                var createdSale = await store.CreateAsync(sale);
                Sales.Insert(0, sale);
                MessageBox.Show(
                    "Sale successfully created!", 
                    "Success", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show(
                    "There was an error creating sale. Please, try again.",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public async Task OnNextPage()
        {
            try
            {
                CurrentPage++;

                await Load();
                await CheckEnables();

                if (TotalPages <= CurrentPage)
                {
                    IsEnableNextPage = false;
                }
                if (CurrentPage > 0)
                {
                    IsEnablePrevPage = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public async Task OnPrevPage()
        {
            try
            {
                CurrentPage--;

                await Load();
                await CheckEnables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public async Task OnLastPage()
        {
            try
            {
                CurrentPage = TotalPages;

                await Load();
                await CheckEnables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public async Task OnPrimaryPage()
        {
            try
            {
                CurrentPage = 1;

                await Load();
                await CheckEnables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

       

        public async Task OnFifteenPage()
        {
            try
            {
                if (PageList > 15 && CurrentPage == TotalPages)
                {
                    PageList = 15;
                    await GetTotalPages();
                    CurrentPage = TotalPages;
                }

                await Load();
                await CheckEnables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task OnThirtyPage()
        {
            try
            {
                bool UpToDown = CurrentPage == TotalPages
                    && PageList > 30;

                PageList = 30;
                await GetTotalPages();

                if (UpToDown)
                {
                    CurrentPage = TotalPages;
                }

                if (CurrentPage >= TotalPages)
                {
                    CurrentPage = TotalPages;
                }

                await Load();
                await CheckEnables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task OnFiftyPage()
        {
            try
            {
                PageList = 50;

                await GetTotalPages();

                if (CurrentPage >= TotalPages)
                {
                    CurrentPage = TotalPages;
                }

                await Load();
                await CheckEnables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task CheckEnables()
        {
            try
            {
                PageString = $"{CurrentPage} page of {TotalPages}";

                if (CurrentPage == 1)
                {
                    IsEnablePrevPage = false;
                    IsEnableNextPage = true;
                    IsEnablePrimaryPage = false;
                    IsEnableLastPage = true;
                }
                else if (CurrentPage > 1 && CurrentPage < TotalPages)
                {
                    IsEnablePrevPage = true;
                    IsEnableNextPage = true;
                    IsEnablePrimaryPage = true;
                    IsEnableLastPage = true;
                }
                else if (CurrentPage == TotalPages)
                {
                    IsEnablePrevPage = true;
                    IsEnableNextPage = false;
                    IsEnablePrimaryPage = true;
                    IsEnableLastPage = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
