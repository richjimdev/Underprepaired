using System;
using Underprepaired.Models;
using Xunit;

namespace UnderprepairedTests
{
    public class UnitTest1
    {
        /// <summary>
        /// Getter test for product model
        /// </summary>
        [Fact]
        public void GetterTestForProductModel()
        {
            Product product = new Product();
            product.Name = "Sock";

            Assert.Equal("Sock", product.Name);
        }
        
        /// <summary>
        /// Setter test for product model
        /// </summary>
        [Fact]
        public void SetterTestForProductModel()
        {
            Product product = new Product();
            product.Name = "Sock";

            product.Name = "Shirt";

            Assert.Equal("Shirt", product.Name);
        }
    }
}
