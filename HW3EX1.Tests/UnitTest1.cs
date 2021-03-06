using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW3EX1B4.Model;
using HW3EX1B4.Services;
using HW3EX1B4.Utility;
using System.Linq;

namespace HW3EX1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(OrderException))]
        public void CreditCard_ChargeCard_ReturnsTrue()
        {
            PaymentDetails paymentDetails = new PaymentDetails();
            Cart cart = new Cart();

            CreditCard.ChargeCard(paymentDetails, cart);
        }

        [TestMethod]
        [ExpectedException(typeof(OrderException))]
        public void InventoryReserved()
        {
            Cart cart = new Cart();

            cart.TotalAmount = 100;
            cart.Items.First().Sku = "11111";
            cart.Items.First().Quantity = 5;
            cart.CustomerEmail = "Test";

            InventorySystem.ReserveInventory(cart);
        }

        [TestMethod]
        [ExpectedException(typeof(LoggerException))]
        public void NotificationEmailFails()
        {
            Cart cart = new Cart();
            cart.CustomerEmail = "testEmail@test.com";

            CustomerNotification.NotifyCustomer(cart);
        }
    }
}
