using MvvmHelpers;
using System.ComponentModel;

namespace Lesson07.Models;

public class SaleProduct : ObservableObject
{
    public int Id { get; set; }
    private decimal _price;
    public decimal UnitPrice 
    {
        get => _price;
        set
        {
            if (value > 0)
            {
                SetProperty(ref _price, value);
            }
        }
    }

    private int _quantity;
    public int Quantity 
    {
        get => _quantity;
        set
        {
            if (value > 0)
            {
                SetProperty(ref _quantity, value);
            }
        }
    }

    private decimal _discount;
    public decimal Discount 
    {
        get => _discount;
        set
        {
            if (value >= 0 && value < UnitPrice)
            {
                SetProperty(ref _discount, value);
            }
        }
    }

    public int  SaleId  { get; set; }
    public virtual Sale Sale { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
}
