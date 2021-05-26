using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentOperation paymentOperation = new PaymentOperation();
            paymentOperation.EftTransfer(500);
            paymentOperation.FastPayTransfer(250);
            Console.ReadLine();
        }

        class Eft
        {
            public void Transfer(int price)
            {
                Console.WriteLine($"Hesaptan {price} TL Eft yöntemi ile transfer edildi.");
            }
        }

        class FastPay
        {
            public void Transfer(int price)
            {
                Console.WriteLine($"Hesaptan {price} TL Fast Pay yöntemi ile transfer edildi.");
            }
        }

        class Account
        {
            public void Update(int price)
            {
                Console.WriteLine($"Hesaptan {price} TL düşüldü.");
            }
        }

        //Facade
        class PaymentOperation
        {
            readonly Eft _eft;
            readonly FastPay _fastPay;
            readonly Account _account;
            public PaymentOperation()
            {
                _eft = new Eft();
                _fastPay = new FastPay();
                _account = new Account();
            }


            public void EftTransfer(int price)
            {
                _eft.Transfer(price);
                _account.Update(price);
            }

            public void FastPayTransfer(int price)
            {
                _fastPay.Transfer(price);
                _account.Update(price);
            }
        }

    }
}
