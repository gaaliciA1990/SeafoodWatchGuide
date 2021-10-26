using System;
using System.Collections.Generic;
using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;
using Moq;

namespace UnitTests.Pages.Create
{
    public class CreateTests
    {

        #region TestSetup
        public static CreateModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<CreateModel>>();

            pageModel = new CreateModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }
    }
}