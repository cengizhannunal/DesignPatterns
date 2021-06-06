using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentProxy paymentProxy = new PaymentProxy();
            paymentProxy.Pay();

            Console.ReadLine();
        }
    }

    interface IPayment
    {
        void Pay();
    }

    class PaymentService : IPayment
    {
        public void Pay()
        {
            Console.WriteLine("Ödeme gerçekleştirildi.");
        }
    }
    class PaymentProxy : IPayment
    {
        PaymentService paymentService = new PaymentService();
        public void Pay()
        {
            //authorization,cache,log,performance
            Console.WriteLine("Yetki kontrolü yapıldı.");
            Console.WriteLine("Ödeme işlemi başlıyor.");
            paymentService.Pay();
            Console.WriteLine("Ödeme işlemi bitti.");
            Console.WriteLine($"Ödeme işlemi boyunca geçen süre {DateTime.Now.Minute}.");
        }
    }
}
