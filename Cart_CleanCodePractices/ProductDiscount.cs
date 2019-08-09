using System.Collections.Generic;

namespace Cart_CleanCodePractices
{
    public class ProductDiscount : IDiscount
    {

        private Dictionary<Product, int> _discountOnProducts = new Dictionary<Product, int>();

        public int GetDiscount(Product product)
        {
            if (_discountOnProducts.ContainsKey(product))
            {
                return _discountOnProducts[product];
            }
            else
            {
                return 0;
            }
        }

        public void SetDiscount(Product product, int discountValue)
        {
            if (_discountOnProducts.ContainsKey(product))
            {
                _discountOnProducts[product] = discountValue;
            }
            else
            {
                _discountOnProducts.Add(product, discountValue);
            }
        }

        public void RemoveProductDiscount(Product product)
        {
            _discountOnProducts.Remove(product);
        }


        // Functions not implemented here in this class....
        public int GetDiscount()
        {
            throw new System.NotImplementedException();
        }

        public int GetDiscount(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}
