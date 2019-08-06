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
            Product cornFlakes = new Product("Corn Flakes",125);
            Product milk = new Product("Milk", 48);
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
            Product cornFlakes = new Product("Corn Flakes", 125);
            Product milk = new Product("Milk", 48);
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
            Product cornFlakes = new Product("Corn Flakes", 125);
            Product milk = new Product("Milk", 48);
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
            Product cornFlakes = new Product("Corn Flakes", 125);
            Product milk = new Product("Milk", 48);
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
            Product cornFlakes = new Product("Corn Flakes", 125);
            Product milk = new Product("Milk", 48);
            Cart cart = new Cart();
            Dictionary<Product,int> expectedList = new Dictionary<Product, int>();
                        
            cart.Add(cornFlakes,2);
            cart.Add(cornFlakes, 2);
            expectedList.Add(cornFlakes,4);

            var actualList = cart.GetItemList();

            Assert.Equal(expectedList, actualList);
        }
    }
}
