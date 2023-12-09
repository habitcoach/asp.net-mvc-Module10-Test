using Microsoft.AspNetCore.Mvc;
using Module10Test.Controllers;
using Module10Test.Models;
using Module10Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class TestController
    {
        FakeProductRepo productRepository { get; set; }
        ProductController productController { get; set; }

        [SetUp]
        public void Setup()
        {
            //Arrange
            productRepository = new FakeProductRepo();

            productRepository.Products = new List<Product> { new Product(), new Product(), new Product() };

             productController = new ProductController(productRepository);

        }

        [Test]
        public void TestingController()
        {

            // Act

            var result = productController.Index() as ViewResult;

            Assert.AreEqual(typeof(List<Product>), result.Model.GetType());


        }


    }
}
