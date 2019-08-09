using System;
using System.Collections.Generic;

namespace Cart_CleanCodePractices
{
    public class CategoryDiscount : IDiscount
    {

        private Dictionary<Category, int> _discountOnCategory = new Dictionary<Category, int>();

        public int GetDiscount(Category category)
        {
            if (_discountOnCategory.ContainsKey(category))
            {
                return _discountOnCategory[category];
            }
            else
            {
                return 0;
            }
        }

        public void SetDiscount(Category category, int discountValue)
        {
            if (_discountOnCategory.ContainsKey(category))
            {
                _discountOnCategory[category] = discountValue;
            }
            else
            {
                _discountOnCategory.Add(category, discountValue);
            }
        }

        public void RemoveProductDiscount(Category category)
        {
            _discountOnCategory.Remove(category);
        }



        // Functions not implemented in this class as there is not requirement
        public int GetDiscount()
        {
            throw new System.NotImplementedException();
        }

        public int GetDiscount(Product product)
        {
            throw new System.NotImplementedException();
        }

        
    }
}
