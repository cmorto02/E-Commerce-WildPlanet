using MyShop.Models;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void ProductSetterID()
        {
            Product p = new Product
            {
                ID = 1
            };
            var expectedOutput = 1;
            Assert.Equal(expectedOutput, p.ID);

        }
        [Fact]
        public void ProductSetterName()
        {
            Product p = new Product
            {
              Name = "Billy"
            };
            var expectedOutput = "Billy";
            Assert.Equal(expectedOutput, p.Name);

        }
        [Fact]
        public void ProductSetterPrice()
        {
            Product p = new Product
            {
                Price = 1200
            };
            var expectedOutput = 1200;
            Assert.Equal(expectedOutput, p.Price);

        }
        [Fact]
        public void ProductSetterDescription()
        {
            Product p = new Product
            {
                Description = "This is a great dscription"
            };
            var expectedOutput = "This is a great dscription";
            Assert.Equal(expectedOutput, p.Description);

        }
        [Fact]
        public void ProductSetterImageStuffedAnimal()
        {
            Product p = new Product
            {
                ImageStuffedAnimal = "This is a great Stuffed animal"
            };
            var expectedOutput = "This is a great Stuffed animal";
            Assert.Equal(expectedOutput, p.ImageStuffedAnimal);

        }
        [Fact]
        public void ProductSetterImageAnimal()
        {
            Product p = new Product
            {
                ImageAnimal = "This is a great animal"
            };
            var expectedOutput = "This is a great animal";
            Assert.Equal(expectedOutput, p.ImageAnimal);

        }
        [Fact]
        public void ProductSetterSummary()
        {
            Product p = new Product
            {
                Summary = "This is a great summary"
            };
            var expectedOutput = "This is a great summary";
            Assert.Equal(expectedOutput, p.Summary);

        }
        [Fact]
        public void ProductSetterAmountLeft()
        {
            Product p = new Product
            {
                AmmountLeft = 12
            };
            var expectedOutput = 12;
            Assert.Equal(expectedOutput, p.AmmountLeft);

        }
        //[Fact]
        public void UserPropFirstName()
        {
            ApplicationUser app = new ApplicationUser
            {
                FirstName = "Tanner"
            };
            var expectedOutput = "Tanner";
            Assert.Equal(expectedOutput, app.FirstName);
        }
      //  [Fact]
        public void UserPropLastName()
        {
            ApplicationUser app = new ApplicationUser
            {
                LastName = "TannerQ"
            };
            var expectedOutput = "TannerQ";
            Assert.Equal(expectedOutput, app.LastName);
        }
       // [Fact]
        public void UserPropLovesAnimals()
        {
            ApplicationUser app = new ApplicationUser
            {
                LoveAnimals = "YES"
            };
            var it = "YES";
            Assert.Equal(it, app.LoveAnimals);

        }
    }
}
