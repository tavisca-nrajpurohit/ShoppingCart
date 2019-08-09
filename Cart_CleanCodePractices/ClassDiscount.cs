namespace Cart_CleanCodePractices
{
    public class ClassDiscount:IDiscount
    {
        private int _discount;

        public int GetDiscount()
        {
            return _discount;
        }

        public void SetDiscount(int newDiscount)
        {
            _discount = newDiscount;
        }

        // functions not in use for this class...
        public int GetDiscount(Product product)
        {
            throw new System.NotImplementedException();
        }

        public int GetDiscount(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}
