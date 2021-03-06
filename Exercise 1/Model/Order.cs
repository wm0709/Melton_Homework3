using System;
using System.Net.Mail;
using HW3EX1B4.Services;
using HW3EX1B4.Utility;

namespace HW3EX1B4.Model
{
    public class Order
    {
        public void Checkout(Cart cart, PaymentDetails paymentDetails, bool notifyCustomer)
        {
            if (paymentDetails.PaymentMethod == PaymentMethod.CreditCard)
            {
                CreditCard.ChargeCard(paymentDetails, cart);
                
            }

            InventorySystem.ReserveInventory(cart);

            if(notifyCustomer)
            {
                CustomerNotification.NotifyCustomer(cart);
            }
        }
    }
}     