using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Web.Mvc;
using System.Web.Routing;
using Core.Model;
using IoCStructureMap;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcChallenge.Controllers;

namespace MvcChallenge.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestInitialize]
        public void Setup()
        {
            Initializer.Initialize(); //Calling strucuremap initialize method
        }

        /// <summary>
        /// Checking Titles data count
        /// </summary>
        [TestMethod]
        public void Index()
        {
                 // Arrange
                var controller = new HomeController();
                // Act
                var result = controller.Index() as ViewResult;


                var cacheTitlesData = MemoryCache.Default;
                var tilesCount = 0;
                if (cacheTitlesData.Contains("ListTitles"))
                    tilesCount = ((List<TitleSearch>)cacheTitlesData["ListTitles"]).Count;

                // Assert
                Assert.AreEqual(25, tilesCount);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
