using GalaSoft.MvvmLight.Messaging;
using Lesson07.Models;
using Lesson07.Stores;
using Lesson07.ViewModels;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lesson07.Views
{
    public partial class CustomerDialog : UserControl
    {
        //private readonly CustomresDataStore _store;


        public ICommand CancelCommand { get; }
        public ICommand SaveCommande { get; }

        //public ObservableCollection<Customer> Customres { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }

        private Customer customer;


        public CustomerDialog()
        {
            InitializeComponent();

            DataContext = this;
            //_store = new CustomresDataStore();
            customer = new Customer();
            CancelCommand = new Command(OnCancel);
            SaveCommande = new Command(OnSave);
            Title = "Create Customers";



        }

        public CustomerDialog(Customer customer)
            : this()
        {
            ArgumentNullException.ThrowIfNull(customer, nameof(customer));
            Title = "Edit Customers";
            this.customer = customer;
            Load();
        }
        private void Load()
        {
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            PhoneNumber = customer.PhoneNumber;
            Address = customer.Address;
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
            customer.FirstName = FirstName;
            customer.LastName = LastName;
            customer.PhoneNumber = PhoneNumber;
            customer.Address = Address;
            DialogHost.Close("MainDialog", customer);
        }

    }

}
