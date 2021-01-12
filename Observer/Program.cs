using System;
using System.Collections.Generic;

namespace Observer
{
    static class Program
    {
        static void Main(string[] args)
        {
            LikeService userService = new LikeService();
            userService.Like();

            FollowService followService = new FollowService();
            followService.Follow();

            Console.ReadKey();
        }

        abstract class Observer
        {
            public abstract void Update(string message);
        }


        class Notification : Observer
        {
            public override void Update(string message)
            {
                Console.WriteLine(message);
            }
        }

        class LikeService
        {
            List<Observer> Observers { get; set; } = new List<Observer>();
            public LikeService()
            {
                Observers.Add(new Notification());
            }

            public void Like()
            {
                Console.WriteLine("Kullanıcının gönderisi beğenildi.");
                Observers.ForEach(x =>
                {
                    x.Update("Kullanıcının gönderisi beğenildi bildirimi gönderildi.");
                });
            }
        }

        class FollowService
        {
            List<Observer> Observers { get; set; } = new List<Observer>();
            public FollowService()
            {
                Observers.Add(new Notification());
            }

            public void Follow()
            {
                Console.WriteLine("Kullanıcıya takip isteği gönderildi.");
                Observers.ForEach(x =>
                {
                    x.Update("Kullanıcıya takip isteği bildirimi gönderildi.");
                });
            }
        }

    }
}
