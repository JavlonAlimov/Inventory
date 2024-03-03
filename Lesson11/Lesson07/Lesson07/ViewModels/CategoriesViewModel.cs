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
using System.Windows.Input;

namespace Lesson07.ViewModels
{
    internal class CategoriesViewModel : BaseViewModel
    {
        private readonly InventoryDbContext context;
        private readonly CategoriesStore store;
        public ObservableCollection<Category> Categories { get; set; }

        #region Search

        private string _search;
        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                FiltrCatigories();
            }
        }

        private string _categoryName;
        public string CategoryName
        {
            get => _categoryName;
            set => SetProperty(ref _categoryName, value);
        }
        #endregion

        #region Pages

        private int _totalPages;
        public int TotalPages
        {
            get => _totalPages;
            set
            {
                SetProperty(ref _totalPages, value);
            }
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

        private Category _selectedCategorie;
        public Category SelectedCategorie
        {
            get => _selectedCategorie;
            set => SetProperty(ref _selectedCategorie, value);
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
        public ICommand CreateCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        #endregion

        public CategoriesViewModel()
        {
            store = new CategoriesStore();
            Categories = new ObservableCollection<Category>();
            context = new InventoryDbContext();
            PageString = $"{CurrentPage} page of {TotalPages}";

            NextPageCommand = new AsyncCommand(OnNextPage);
            PrevPageCommand = new AsyncCommand(OnPrevPage);
            LastPageCommand = new AsyncCommand(OnLastPage);
            PrimaryPageCommand = new AsyncCommand(OnPrimaryPage);
            FirstPageCommand = new AsyncCommand(OnFirstPage);
            SecondPageCommand = new AsyncCommand(OnSecondPage);
            ThirdPageCommand = new AsyncCommand(OnThirdPage);
            FifteenPageCommand = new AsyncCommand(OnFifteenPage);
            ThirtyPageCommand = new AsyncCommand(OnThirtyPage);
            FiftyPageCommand = new AsyncCommand(OnFiftyPage);
            CreateCommand = new AsyncCommand(OnCreate);
            EditCommand = new AsyncCommand(OnEdit);
            DeleteCommand = new AsyncCommand(OnDelete);


            InitializeAsync();
        }
        private async Task InitializeAsync()
        {
            await LoadAsync();
        }
        public async Task LoadAsync()
        {
            await GetTotalPages();
            var categories = await store.GetCategoriesAsync(_pageList, CurrentPage, _search);

            Categories.Clear();

            foreach (var categorie in categories)
            {
                Categories.Add(categorie);
            }
        }
        private async Task OnCreate()
        {
            var view = new CategoryDialog();
            var result = await DialogHost.Show(view, "MainDialog");
            if (result is not Category category)
            {
                return;
            }
            try
            {
                store.CreateCatigory(category);
                MessageBox.Show($"Category: {category.Name} was successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding category: {category.Name} to database", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
            }
            Categories.Insert(0, category);
        }
        public async Task OnEdit()
        {
            if (SelectedCategorie is null)
            {
                return;
            }
            var view = new CategoryDialog(SelectedCategorie);
            var result = await DialogHost.Show(view, "MainDialog");
            if (result is not Category category)
            {
                return;
            }

            try
            {
                store.UpdateCatigory(category);
                MessageBox.Show($"Category: {category.Name} was successfully updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                var index = Categories.IndexOf(category);
                if(index==-1)
                {

                }
                Categories.Remove(category);
                Categories.Insert(index, category);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating category: {category.Name} to database", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
            }
        }
        private async Task OnDelete()
        {
            var categoryToDelete = SelectedCategorie;
            if (categoryToDelete is null)
            {
                return; 
            }
            var result = MessageBox.Show($"Are you sure you to delete product:{categoryToDelete.Name}?", "Confirum action", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if(result !=MessageBoxResult.Yes)
            { return; }
            try
            {
                int affectedRows = await store.DeleteCategory(categoryToDelete.Id);
                if (affectedRows<1)
                {
                    MessageBox.Show($"Something went wrong while deliting product with name: ${categoryToDelete.Name}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
               
                Categories.Remove(categoryToDelete);
                MessageBox.Show($"Successfuly deleted product with name: {categoryToDelete.Name}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show($"Eror deleting product with id: {categoryToDelete.Id}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async Task FiltrCatigories()
        {
            var categories = await store.GetCategoriesAsync(_pageList, CurrentPage, _search);

            Categories.Clear();

            foreach (var categorie in categories)
            {
                Categories.Add(categorie);
            }
        }
        public async Task GetTotalPages()
        {
            try
            {
                int salesCount = await store.GetCustomersCountAsync();

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
    }
}
