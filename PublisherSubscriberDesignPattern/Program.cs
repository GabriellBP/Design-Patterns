using System;
using System.Threading.Tasks;

namespace PublisherSubscriberDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating Instance of Publishers
            Publisher youtube = new Publisher("Youtube.Com", 2000);
            Publisher facebook = new Publisher("Facebook.com", 5000);

            //Create Instances of Subscribers
            Subscriber sub1 = new Subscriber("Gabriel");
            Subscriber sub2 = new Subscriber("Dua");
            Subscriber sub3 = new Subscriber("Ed");

            //Pass the publisher obj to their Subscribe function
            sub1.Subscribe(facebook); //sub1 subscribes to facebook publisher
            sub3.Subscribe(facebook);

            sub1.Subscribe(youtube);
            sub2.Subscribe(youtube);

            //sub1.Unsubscribe(facebook);


            // Concurrently running multiple publishers thread for mocking continious notification update firing.
            Task task1 = Task.Factory.StartNew(() => youtube.Publish());
            Task task2 = Task.Factory.StartNew(() => facebook.Publish());
            Task.WaitAll(task1, task2);
        }
    }
}
