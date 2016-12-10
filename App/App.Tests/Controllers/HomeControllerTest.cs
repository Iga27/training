using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Web.Controllers;
using System.Web.Mvc;

namespace App.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
         HomeController controller;
         ViewResult result;

        [TestInitialize]
        public void SetupContext()
        {
            controller = new HomeController();
            result = controller.Index() as ViewResult;
        }
        [TestMethod]
        public void IndexViewEqualIndexCshtml()
        {          
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
