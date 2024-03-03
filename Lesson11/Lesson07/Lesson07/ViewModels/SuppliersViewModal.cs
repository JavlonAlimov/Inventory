using Lesson07.Data;
using Lesson07.Models;
using Lesson07.Stores;
using Lesson07.Views;
using MaterialDesignThemes.Wpf;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;

namespace Lesson07.ViewModels
{
    internal class SuppliersViewModal : BaseViewModel
    {
        private readonly InventoryDbContext _context;
        private readonly SuppliersDataStore _dataStore;
        public ObservableCollection<Supplier> Suppliers { get; set; }

        private string _search;
        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                FilterSupplier();
            }
        }

        #region Pages
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

        private Supplier _selectedSuplier;
        public Supplier SelectedSuplier
        {
            get => _selectedSuplier;
            set => SetProperty(ref _selectedSuplier, value);
        }

        private string _pageString;
        public string PageString
        {
            get => _pageString;
            set => SetProperty(ref _pageString, value);
        }

        private int _firstPage = 0;
        public int FirstPage
        {
            get => _firstPage;
            set => SetProperty(ref _firstPage, value);
        }

        private int _secondPage = 1;
        public int SecondPage
        {
            get => _secondPage;
            set => SetProperty(ref _secondPage, value);
        }
        private int _thirdPage = 2;
        public int ThirdPage
        {
            get => _thirdPage;
            set => SetProperty(ref _thirdPage, value);
        }
        #endregion

        #region Enables

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

        private bool _isEnableFirstPage = false;
        public bool IsEnableFirstPage
        {
            get => _isEnableFirstPage;
            set => SetProperty(ref _isEnableFirstPage, value); 
        }

        private bool _isEnableSecondPage = true;
        public bool IsEnableSecondPage
        {
            get => _isEnableSecondPage;
            set => SetProperty(ref _isEnableSecondPage, value); 
        }

        private bool _isEnableThirdPage = true;
        public bool IsEnableThirdPage
        {
            get => _isEnableThirdPage;
            set => SetProperty(ref _isEnableThirdPage, value);
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

        #region IAsyncCommand
        public IAsyncCommand InfoCommand { get; }
        public IAsyncCommand PrimaryPageCommand { get; }
        public IAsyncCommand PrevPageCommand { get; }
        public IAsyncCommand FirstPageCommand { get; }
        public IAsyncCommand SecondPageCommand { get; }
        public IAsyncCommand ThirdPageCommand { get; }
        public IAsyncCommand NextPageCommand { get; }
        public IAsyncCommand LastPageCommand { get; }
        public IAsyncCommand FifteenPageCommand { get; }
        public IAsyncCommand ThirtyPageCommand { get; }
        public IAsyncCommand FiftyPageCommand { get; }
        public IAsyncCommand CreateCommand { get; }
        public IAsyncCommand DeleteCommand { get; }
        public IAsyncCommand EditCommand { get; }

        #endregion

        public SuppliersViewModal()
        {
            _context = new InventoryDbContext();
            _dataStore = new SuppliersDataStore();
            Suppliers = new ObservableCollection<Supplier>();

            PageString = $"{CurrentPage} page of {TotalPages}";

            NextPageCommand = new AsyncCommand(OnNextPage);
            PrevPageCommand = new AsyncCommand(OnPrevPage);
            LastPageCommand = new AsyncCommand(OnLastPage);
            PrimaryPageCommand = new AsyncCommand(OnPrimaryPage);
            FirstPageCommand = new AsyncCommand(OnFirstPage);
            SecondPageCommand = new AsyncCommand(OnSecondPage);
            ThirdPageCommand = new AsyncCommand(OnThirdPage);
            CreateCommand = new AsyncCommand(OnCreate);
            DeleteCommand = new AsyncCommand(OnDelete);
            EditCommand = new AsyncCommand(OnEdit);
            FifteenPageCommand = new AsyncCommand(OnFifteenPage);
            ThirtyPageCommand = new AsyncCommand(OnThirtyPage);
            FiftyPageCommand = new AsyncCommand(OnFiftyPage);
            InitializeAsync();
        }
        private async Task InitializeAsync()
        {
            await LoadAsync();
        }

        private async Task FilterSupplier()
        {
            var suplier = await _dataStore.GetSupplierAsync(_pageList, CurrentPage, _search);

            Suppliers.Clear();

            foreach (var item in suplier)
            {
                Suppliers.Add(item);
            }
        }

        public async Task LoadAsync()
        {
            await GetTotalPages();
            var loadedCustomers = await _dataStore.GetSupplierAsync(_pageList, _currentPage);
            Suppliers.Clear();
            foreach (var customer in loadedCustomers)
            {
                Suppliers.Add(customer);
            }

        }

        public async Task GetTotalPages()
        {
            try
            {
                int salesCount = await _dataStore.GetSupplierCountAsync();

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

        public async Task OnNextPage()
        {
            try
            {
                CurrentPage++;

                FirstPage = CurrentPage - 1;
                SecondPage = CurrentPage;
                ThirdPage = CurrentPage + 1;

                await LoadAsync();
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

                FirstPage = CurrentPage - 1;
                SecondPage = CurrentPage;
                ThirdPage = CurrentPage + 1;

                await LoadAsync();
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

                FirstPage = TotalPages - 1;
                SecondPage = TotalPages;
                ThirdPage = 0;

                await LoadAsync();
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

                FirstPage = 0;
                SecondPage = 1;
                ThirdPage = 2;

                await LoadAsync();
                await CheckEnables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public async Task OnFirstPage()
        {
            try
            {
                CurrentPage = FirstPage;

                FirstPage--;
                SecondPage = CurrentPage;
                ThirdPage = CurrentPage + 1;

                await LoadAsync();
                await CheckEnables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public async Task OnSecondPage()
        {
            try
            {
                CurrentPage = SecondPage;

                await LoadAsync();
                await CheckEnables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public async Task OnThirdPage()
        {
            try
            {
                CurrentPage = ThirdPage;

                FirstPage++;
                SecondPage = CurrentPage;
                ThirdPage = CurrentPage + 1;

                await LoadAsync();
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

                    FirstPage = CurrentPage - 1;
                    SecondPage = CurrentPage;
                    ThirdPage = 0;
                }

                await LoadAsync();
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

                    FirstPage = CurrentPage - 1;
                    SecondPage = CurrentPage;
                    ThirdPage = 0;
                }

                if (CurrentPage >= TotalPages)
                {
                    CurrentPage = TotalPages;

                    FirstPage = TotalPages - 1;
                    SecondPage = TotalPages;
                    ThirdPage = 0;
                }

                await LoadAsync();
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

                    FirstPage = TotalPages - 1;
                    SecondPage = TotalPages;
                    ThirdPage = 0;
                }

                await LoadAsync();
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
                    IsEnableFirstPage = false;
                    IsEnableSecondPage = true;
                    IsEnableThirdPage = true;
                }
                else if (CurrentPage > 1 && CurrentPage < TotalPages)
                {
                    IsEnablePrevPage = true;
                    IsEnableNextPage = true;
                    IsEnablePrimaryPage = true;
                    IsEnableLastPage = true;
                    IsEnableFirstPage = true;
                    IsEnableSecondPage = true;
                    IsEnableThirdPage = true;
                }
                else if (CurrentPage == TotalPages)
                {
                    IsEnablePrevPage = true;
                    IsEnableNextPage = false;
                    IsEnablePrimaryPage = true;
                    IsEnableLastPage = false;
                    IsEnableFirstPage = true;
                    IsEnableSecondPage = true;
                    IsEnableThirdPage = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public async Task OnCreate()
        {
            if (Suppliers is null)
            {
                return;
            }
            var view = new SupplierDialog();
            var result = await DialogHost.Show(view, "MainDialog");


            if (result is not Supplier supplier)
            {
                return;
            }
            try
            {
                _dataStore.CreateSupplier(supplier);
                MessageBox.Show($"Customre: {supplier.LastName} was successfully added", "Succses", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eror adding Customer: {supplier.LastName} to database", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
            }
            Suppliers.Insert(0, supplier);

        }

        public async Task OnEdit()
        {
            if (SelectedSuplier is null)
            {
                return;
            }
            var view = new SupplierDialog(SelectedSuplier);
            var result = await DialogHost.Show(view, "MainDialog");
            if (result is not Supplier supplier)
            {
                return;
            }
            try
            {
                _dataStore.UpdateSupplier(supplier);
                MessageBox.Show($"Supplier: {supplier.LastName} was successfully updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                var index = Suppliers.IndexOf(supplier);
                if (index == -1)
                {

                }
                Suppliers.Remove(supplier);
                Suppliers.Insert(index, supplier);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating supplier: {supplier.LastName} to database", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
            }
            _dataStore.UpdateSupplier(supplier);
        }

        private async Task OnDelete()
        {
            var customerToDelete = SelectedSuplier;
            if (customerToDelete is null)
            {
                return;
            }
            var result = MessageBox.Show($"Are you sure you to delete product:{customerToDelete.FirstName}?", "Confirum action", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes)
            { return; }
            try
            {
                int affectedRows = await _dataStore.DeleteSuppler(customerToDelete.Id);
                if (affectedRows < 1)
                {
                    MessageBox.Show($"Something went wrong while deliting product with name: ${customerToDelete.FirstName}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Suppliers.Remove(customerToDelete);
                MessageBox.Show($"Successfuly deleted product with name: {customerToDelete.FirstName}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show($"Eror deleting product with id: {customerToDelete.Id}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
