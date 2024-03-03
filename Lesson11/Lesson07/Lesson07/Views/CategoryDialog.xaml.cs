using Lesson07.Models;
using Lesson07.Stores;
using MaterialDesignThemes.Wpf;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lesson07.Views
{
    public partial class CategoryDialog : UserControl
    {
        public ICommand CancelCommand { get; }
        public ICommand SaveCommand { get; }
        public string Title { get; set; }
        public string CategoryName { get; set; }

        private Category category;
        public CategoryDialog()
        {
            InitializeComponent();
            DataContext = this;
            CancelCommand = new Command(OnCancel);
            SaveCommand = new Command(OnSave);
            category = new Category();
            Title = "Create Category";
        }
        public CategoryDialog(Category category)
            : this()
        {
            ArgumentNullException.ThrowIfNull(category, nameof(category));

            Title = "Edit Category";

            this.category = category;

            Population();
        }
        private void Population()
        {
            CategoryName = category.Name;
        }
        private void OnCancel()
        {
            var result = MessageBox.Show($"Are you sure you cant to close?", "Confirm action", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.Yes)
            {
                DialogHost.Close("MainDialog");
            }
        }
        private void OnSave()
        {
            category.Name = CategoryName;

            DialogHost.Close("MainDialog", category);
        }
    }
}
