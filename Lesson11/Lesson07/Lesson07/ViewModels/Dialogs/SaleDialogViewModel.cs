using GalaSoft.MvvmLight.Messaging;
using Lesson07.Constants;
using Lesson07.Models;
using MaterialDesignThemes.Wpf;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lesson07.ViewModels.Dialogs
{
    public class SaleDialogViewModel : BaseViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<SaleProduct> SaleProducts { get; set; }

        private DateTime _selectedDate = DateTime.Now;
        public DateTime SelectedDate 
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value);
        }

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                SetProperty(ref _selectedCustomer, value);
                CanCreate = SaleProducts.Any();
            }
        }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        private decimal _totalDue;
        public decimal TotalDue
        {
            get => _totalDue;
            set => SetProperty(ref _totalDue, value);
        }

        private bool _canCreate;
        public bool CanCreate
        {
            get => _canCreate;
            set => SetProperty(ref _canCreate, value);
        }

        private decimal _paymentAmount = 0;
        public decimal PaymentAmount
        {
            get => _paymentAmount;
            set => SetProperty(ref _paymentAmount, value);
        }

        public ICommand AddItemCommand { get; }
        public ICommand DeleteItemCommand { get; }
        public ICommand CloseCommand { get; }
        public ICommand CreateSaleCommand { get; }

        public SaleDialogViewModel(List<Product> products, List<Customer> customers)
        {
            Customers = new ObservableCollection<Customer>(customers);
            Products = new ObservableCollection<Product>(products);
            SaleProducts = new ObservableCollection<SaleProduct>();

            AddItemCommand = new Command(OnAdd);
            DeleteItemCommand = new Command<SaleProduct>(OnDelete);
            CloseCommand = new Command(OnClose);
            CreateSaleCommand = new Command(OnCreateSale);
        }

        private void OnAdd()
        {
            if (SaleProducts.Any(x => x.ProductId == SelectedProduct.Id))
            {
                return;
            }

            var item = new SaleProduct
            {
                ProductId = SelectedProduct.Id,
                Product = SelectedProduct,
                Quantity = 1,
                UnitPrice = SelectedProduct.Price
            };

            item.PropertyChanged += SaleProductChanged;

            TotalDue += item.UnitPrice * item.Quantity;
            CanCreate = SelectedCustomer is not null;
            SaleProducts.Add(item);
        }

        private void SaleProductChanged(object sender, EventArgs e)
        {
            TotalDue = SaleProducts.Sum(x => x.UnitPrice * x.Quantity);
        }

        private void OnDelete(SaleProduct saleProduct)
        {
            if (saleProduct is null)
            {
                return;
            }

            var item = SaleProducts.FirstOrDefault(x => x.ProductId == saleProduct.ProductId);

            if (item is null)
            {
                return;
            }

            SaleProducts.Remove(item);
            TotalDue -= item.Quantity * item.UnitPrice;
            CanCreate = SaleProducts.Any() && SelectedCustomer is not null;
        }

        private void OnClose()
        {
            if (!SaleProducts.Any())
            {
                DialogHost.Close(DialogAreas.MainDialog);
                return;
            }

            var result = MessageBox.Show("Confirm action.", "Are you sure you want to close?", MessageBoxButton.YesNoCancel);

            if (result == MessageBoxResult.Yes)
            {
                DialogHost.Close(DialogAreas.MainDialog);
            }
        }

        private void OnCreateSale()
        {
            var sale = new Sale
            {
                SaleDate = SelectedDate,
                CustomerId = SelectedCustomer.Id,
                Customer = SelectedCustomer,
                TotalDue = TotalDue,
                SaleProducts = SaleProducts
            };

            DialogHost.Close(DialogAreas.MainDialog, sale);
        }
    }
}
