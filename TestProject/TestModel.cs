using Module10Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class TestModel
    {

        Product product { get; set; }


        [SetUp]      
        public void Setup()
        {
            //Arrange
            product = new Product();

        }

        [Test]
        public void TestingModel()
        {
            //Act
           product.Name = "something";

            var proName = product.Name;

           
            //Assert
            Assert.AreEqual(typeof(string), proName.GetType());

            Assert.That(typeof(string), Is.EqualTo(proName.GetType()));
        }



    }
}
