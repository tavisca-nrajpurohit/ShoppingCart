namespace Cart_CleanCodePractices
{
    public class ClassDiscount:IDiscount
    {
        private static int _staticDiscount = 15;

        public int GetDiscount()
        {
            return 15;
        }

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
