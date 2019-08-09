using System;
using System.Collections.Generic;
using System.Text;

namespace Cart_CleanCodePractices
{
    public class Cart
    {
        // Disctionary structure --> <Product, Quantity>
        private Dictionary<Product,int> _cartItemList;
        private ClassDiscount classDiscount = new ClassDiscount();
        ProductDiscount discountOnProduct = new ProductDiscount();
        CategoryDiscount discountOnCategory = new CategoryDiscount();

        public Cart()
        {
            _cartItemList = new Dictionary<Product, int>();
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
                Double itemCost;
                itemCost = item.Key.Price * item.Value;
                itemCost = itemCost * (100 - GetProductDiscount(item.Key)) / 100;
                itemCost = itemCost * (100 - GetCategoryDiscount(item.Key.category)) / 100;

                totalCost += itemCost;
            }
            totalCostAfterDiscount = totalCost * (100 - GetPercentageDiscount()) / 100;
            
            return totalCostAfterDiscount;
        }

        public int GetPercentageDiscount()
        {
            return classDiscount.GetDiscount();
        }

        public void SetPercentageDiscount(int discountValue)
        {
            classDiscount.SetDiscount(discountValue);
        }

        public int GetCategoryDiscount(Category category)
        {
            return discountOnCategory.GetDiscount(category);
        }

        public void SetCategoryDiscount(Category category,int discountValue)
        {
            discountOnCategory.SetDiscount(category,discountValue);
        }

        public int GetProductDiscount(Product product)
        {
            return discountOnProduct.GetDiscount(product);
        }

        public void SetProductDiscount(Product product, int discountValue)
        {
            discountOnProduct.SetDiscount(product, discountValue);
        }
    }
}
