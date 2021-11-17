using Bunit;
using NUnit.Framework;
using ContosoCrafts.WebSite.Components;
using Microsoft.Extensions.DependencyInjection;
using ContosoCrafts.WebSite.Services;
using System.Linq;

namespace UnitTests.Components
{
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        [Test]
        public void ProductList_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("BEST_CHOICE"));
        }

        #region SelectProduct
        /// <summary>
        /// Pass as part of the parameters to the ProductList Component, the Region of Central
        /// Then find the Div that holds the Best Choice items
        /// Look inside that inner HTML for that div, looking for the items
        /// Tuna should be there
        /// Octopus should not
        /// </summary>
        [Test]
        public void SelectRegion_Valid_Region_Central_Best_Choice_Should_Contain_Tuna()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "div_BEST_CHOICE";

            var page = RenderComponent<ProductList>(parameters => parameters.Add(p => p.region, "Central"));

            var resultTest = page.Markup;

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Div");

            // Act

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Assert
            Assert.AreEqual(true, button.InnerHtml.Contains("Tuna-Albacore"));

            Assert.AreEqual(false, button.InnerHtml.Contains("Octopus"));
        }

        /// <summary>
        /// Pass as part of the parameters to the ProductList Component, the Region of Hawaii, search key as Oysters
        /// Then find the Div that holds the Best Choice items
        /// Look inside that inner HTML for that div, looking for the items
        /// Oysters should be there
        /// Octopus should not 
        /// </summary>
        [Test]
        public void SearchTitle_Valid_Title_Oysters_Result_Should_Contain_Oysters()
        {
            //Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            var divID = "div_BEST_CHOICE";

            var page = RenderComponent<ProductList>(parameters => parameters.Add(p => p.search, "Oysters").Add(p => p.region, "Hawaii"));
            var resultTest = page.Markup;

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Div");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(divID));

            // Assert
            Assert.AreEqual(true, button.InnerHtml.Contains("Oysters"));
            Assert.AreEqual(false, button.InnerHtml.Contains("Octopus"));
        }
        #endregion SelectProduct
    }
}