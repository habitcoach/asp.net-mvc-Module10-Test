using Microsoft.AspNetCore.Mvc;
using Module10Test.Controllers;
using Module10Test.Models;
using Module10Test.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class TestControllerMock
    {
        Mock<IProductRepo> productRepositoryMock { get; set; }
        ProductController productController { get; set; }

        Product product { get; set; }

       [SetUp]
        public void Setup()
        {
            //Arrange
            productRepositoryMock = new Mock<IProductRepo>();
             product = new Product() { Name="some",Id=1,BasePrice=99};

            productRepositoryMock.Setup(x =>x.Add(product)).Returns( new Product() { Name="name"});

             productController = new ProductController(productRepositoryMock.Object);

        }

        [Test]
        public void TestingControllerMock()
        {

            // Act

            var result = productController.Create(product) as ViewResult;

            Assert.AreEqual(typeof(Product), result.Model.GetType());


        }

        [Test]
        public void TestingControllerName()
        {

            // Act

            var result = (productController.Create(product) as ViewResult).Model as Product ;

            Assert.AreEqual("namen", result.Name);


        }
    }
}
