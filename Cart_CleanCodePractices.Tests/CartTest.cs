using System;
using System.Collections.Generic;
using Xunit;

namespace Cart_CleanCodePractices.Tests
{
    public class CartTest
    {
        [Fact]
        public void AddProductToCartTest()
        {
            Product cornFlakes = new Product("Corn Flakes",125, Category.Food);
            Product milk = new Product("Milk", 48, Category.Dairy);
            Cart cart = new Cart();
            Dictionary<Product, int> expectedList = new Dictionary<Product, int>();

            cart.Add(cornFlakes, 2);
            expectedList.Add(cornFlakes, 2);

            cart.Add(milk, 5);
            expectedList.Add(milk, 5);

            var actualList = cart.GetItemList();

            Assert.Equal(expectedList,actualList);
        }

        [Fact]
        public void DeleteProductCompletelyFromCartTest()
        {
            Product cornFlakes = new Product("Corn Flakes", 125, Category.Food);
            Product milk = new Product("Milk", 48, Category.Dairy);
            Cart cart = new Cart();
            Dictionary<Product, int> expectedList = new Dictionary<Product, int>();

            cart.Add(cornFlakes, 2);
            expectedList.Add(cornFlakes, 2);

            cart.Add(milk, 5);

            cart.Delete(milk,5);

            var actualList = cart.GetItemList();

            Assert.Equal(expectedList, actualList);
        }

        [Fact]
        public void DeleteProductPartlyFromCartTest()
        {
            Product cornFlakes = new Product("Corn Flakes", 125, Category.Food);
            Product milk = new Product("Milk", 48, Category.Dairy);
            Cart cart = new Cart();
            Dictionary<Product, int> expectedList = new Dictionary<Product, int>();

            cart.Add(cornFlakes, 2);
            expectedList.Add(cornFlakes, 2);

            cart.Add(milk, 5);
            expectedList.Add(milk, 3);
            cart.Delete(milk, 2);

            var actualList = cart.GetItemList();

            Assert.Equal(expectedList, actualList);
        }

        [Fact]
        public void DeleteNonExistingFromCartTest()
        {
            Product cornFlakes = new Product("Corn Flakes", 125, Category.Food);
            Product milk = new Product("Milk", 48, Category.Dairy);
            Cart cart = new Cart();
            Dictionary<Product, int> expectedList = new Dictionary<Product, int>();

            cart.Add(cornFlakes, 2);
            expectedList.Add(cornFlakes, 2);
            
            cart.Delete(milk, 2);

            var actualList = cart.GetItemList();

            Assert.Equal(expectedList, actualList);
        }



        [Fact]
        public void AddExistingProductToCartTest()
        {
            Product cornFlakes = new Product("Corn Flakes", 125, Category.Food);
            Product milk = new Product("Milk", 48, Category.Dairy);
            Cart cart = new Cart();
            Dictionary<Product,int> expectedList = new Dictionary<Product, int>();
                        
            cart.Add(cornFlakes,2);
            cart.Add(cornFlakes, 2);
            expectedList.Add(cornFlakes,4);

            var actualList = cart.GetItemList();

            Assert.Equal(expectedList, actualList);
        }

        [Fact]
        public void CartLevelDiscountTest()
        {
            Product cornFlakes = new Product("Corn Flakes", 100, Category.Food);
            Product milk = new Product("Milk", 50, Category.Dairy);
            Cart cart = new Cart();
            cart.SetPercentageDiscount(5);

            cart.Add(cornFlakes, 2);
            cart.Add(milk, 2);

            var expectedCost = 285;
            var actualCost = cart.GetTotalCost();

            Assert.Equal(expectedCost, actualCost);
        }

        [Fact]
        public void CategoryLevelDiscountTest()
        {
            Product cornFlakes = new Product("Corn Flakes", 100, Category.Food);
            Product milk = new Product("Milk", 50, Category.Dairy);
            Cart cart = new Cart();
            cart.SetCategoryDiscount(Category.Food,20);

            cart.Add(cornFlakes, 2);
            cart.Add(milk, 2);

            var expectedCost = 260;
            var actualCost = cart.GetTotalCost();

            Assert.Equal(expectedCost, actualCost);
        }

        [Fact]
        public void SetAllDiscountTypesAtOnceTest()
        {
            Product cornFlakes = new Product("Corn Flakes", 100, Category.Food);
            Product milk = new Product("Milk", 100, Category.Dairy);
            Cart cart = new Cart();

            cart.SetProductDiscount(cornFlakes, 20);
            cart.SetCategoryDiscount(Category.Dairy, 10);
            cart.SetPercentageDiscount(50);

            cart.Add(cornFlakes, 2);
            cart.Add(milk, 2);

            var expectedCost = 170;
            var actualCost = cart.GetTotalCost();

            Assert.Equal(expectedCost, actualCost);
        }


        [Fact]
        public void UsingAllDiscountsTest()
        {
            Product cornFlakes = new Product("Corn Flakes", 100, Category.Food);
            Product milk = new Product("Milk", 100, Category.Dairy);
            Cart cart = new Cart();

            cart.SetProductDiscount(cornFlakes, 20);
            cart.SetProductDiscount(milk, 10);
            cart.SetCategoryDiscount(Category.Dairy, 10);
            cart.SetCategoryDiscount(Category.Food, 20);
            cart.SetPercentageDiscount(50);


            cart.SetProductDiscount(milk, 0);
            cart.SetCategoryDiscount(Category.Food, 0);

            cart.Add(cornFlakes, 2);
            cart.Add(milk, 2);

            var expectedCost = 170;
            var actualCost = cart.GetTotalCost();

            Assert.Equal(expectedCost, actualCost);
        }
    }
}
