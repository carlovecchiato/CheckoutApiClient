using System.Linq;
using System.Net;
using FluentAssertions;
using NUnit.Framework;
using Tests.Utils;

namespace Tests.DrinkService
{
    [TestFixture(Category = "DrinksApi")]
    public class DrinkServiceTests : BaseServiceTests
    {
        [Test, Order(4)]
        public void CreateDrink()
        {
            var drinkModel = TestHelper.GetDrinkModel();
            var response = CheckoutClient.DrinkService.CreateDrink(drinkModel);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Should().Be(drinkModel.Quantity);
        }

        [Test, Order(5)]
        public void DeleteDrink()
        {
            var drinkId = TestHelper.ExistingDrinkName;

            var response = CheckoutClient.DrinkService.DeleteDrink(drinkId);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Message.Should().BeEquivalentTo("Ok");
        }

        [Test, Order(2)]
        public void GetDrink()
        {
            var drinkId = TestHelper.ExistingDrinkName;

            var response = CheckoutClient.DrinkService.GetDrink(drinkId);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Name.Should().Be(TestHelper.ExistingDrinkName);
            response.Model.Quantity.Should().Be(TestHelper.ExistingDrinkQuantity);
        }

        [Test, Order(1)]
        public void GetDrinkList()
        {
            var response = CheckoutClient.DrinkService.GetDrinkList();

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Count.Should().Be(4);
        }

        [Test, Order(3)]
        public void UpdateDrink()
        {
            var response = CheckoutClient.DrinkService.UpdateDrink(TestHelper.UpdateDrinkModel());

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Message.Should().BeEquivalentTo("Ok");
        }
    }
}
