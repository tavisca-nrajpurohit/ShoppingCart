namespace Cart_CleanCodePractices
{
    public interface IDiscount
    {
        int GetDiscount();
        int GetDiscount(Product product);
        int GetDiscount(Category category);
    }    
}
