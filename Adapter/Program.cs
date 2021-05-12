using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            IPaymentAdapter paymentAdapter = new CardAdapter(new CardPayment());
            paymentAdapter.Pay();

            IPaymentAdapter paymentAdapter2 = new CashAdapter(new CashPayment());
            paymentAdapter2.Pay();

            Console.Read();
        }

        public interface ICardPayment
        {
            public void PayWithCard();
        }

        public interface ICashPayment
        {
            public void PayWithCash();
        }

        public class CardPayment : ICardPayment
        {
            public void PayWithCard()
            {
                Console.WriteLine("Kart ile ödeme yapıldı.");
            }
        }

        public class CashPayment : ICashPayment
        {
            public void PayWithCash()
            {
                Console.WriteLine("Nakit ile ödeme yapıldı.");
            }
        }

        public interface IPaymentAdapter
        {
            void Pay();
        }

        public class CardAdapter : IPaymentAdapter
        {
            private ICardPayment CardPayment { get; set; }
            public CardAdapter(ICardPayment cardPayment)
            {
                this.CardPayment = cardPayment;
            }
            public void Pay()
            {
                CardPayment.PayWithCard();
            }
        }

        public class CashAdapter : IPaymentAdapter
        {
            private ICashPayment CashPayment { get; set; }
            public CashAdapter(ICashPayment cashPayment)
            {
                this.CashPayment = cashPayment;
            }
            public void Pay()
            {
                CashPayment.PayWithCash();
            }
        }
    }
}
