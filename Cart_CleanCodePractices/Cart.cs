using System;
using System.Collections.Generic;
using System.Text;

namespace Cart_CleanCodePractices
{
    public class Cart
    {
        // Disctionary structure --> <Product, Quantity>
        private Dictionary<Product,int> _cartItemList;

        private int _percentageDiscountOnCart;
        
        public Cart()
        {
            _cartItemList = new Dictionary<Product, int>();
            _percentageDiscountOnCart = ServerConfiguration.GetPercentageDiscount();
        }
        public void Add(Product product, int quantity)
        {
            if(_cartItemList.ContainsKey(product))
            {
                _cartItemList[product] += quantity;
            }
            else
            {
                _cartItemList.Add(product,quantity);
            }
        }

        public void Delete(Product product, int quantity)
        {
            if (_cartItemList.ContainsKey(product))
            {
                if(quantity < _cartItemList[product])
                {
                    _cartItemList[product] -= quantity;
                }else
                {
                    _cartItemList.Remove(product);
                }
            }
            
        }

        public Dictionary<Product,int> GetItemList()
        {
            return _cartItemList;
        }

        public Double GetTotalCost()
        {
            Double totalCost = 0;
            Double totalCostAfterDiscount = 0;
        
            foreach (var item in _cartItemList)
            {
                Double itemCost = 0;
                itemCost = item.Key.Price * item.Value ;

                totalCost += itemCost;
            }
            totalCostAfterDiscount = totalCost * ((100 - GetPercentageDiscount()) / 100);
            return totalCostAfterDiscount;
        }

        public int GetPercentageDiscount()
        {
            return _percentageDiscountOnCart;
        }
    }
}
