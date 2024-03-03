using Lesson07.Models;
using MaterialDesignThemes.Wpf;
using MvvmHelpers.Commands;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lesson07.Views
{
    public partial class SupplierDialog : UserControl
    {
        public ICommand CancelCommand { get; }
        public ICommand SaveCommande { get; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }

        private Supplier supplier;
        public SupplierDialog()
        {
            InitializeComponent();
            DataContext = this;
            supplier = new Supplier();
            CancelCommand = new Command(OnCancel);
            SaveCommande = new Command(OnSave);
            Title = "Create Supplier";
        }
        public SupplierDialog(Supplier supplier)
           : this()
        {
            ArgumentNullException.ThrowIfNull(supplier, nameof(supplier));
            Title = "Edit Customers";
            this.supplier = supplier;
            Load();
        }
        private void Load()
        {
            FirstName = supplier.FirstName;
            LastName = supplier.LastName;
            Company = supplier.Company;
            PhoneNumber = supplier.PhoneNumber;
        }
        private void OnCancel()
        {
            var result = MessageBox.Show("Are you sure you want to close?", "Confirm action", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (result == MessageBoxResult.Yes)
            {
                DialogHost.Close("MainDialog");
            }
        }
        private void OnSave()
        {
            supplier.FirstName = FirstName;
            supplier.LastName = LastName;
            supplier.Company = Company;
            supplier.PhoneNumber = PhoneNumber;
            DialogHost.Close("MainDialog", supplier);
        }
    }
}
