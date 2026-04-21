using System;
using System.Collections.Generic;

// Step 2: Subscriber Interface
public interface IObserver
{
    void Update(string news);
}

// Step 2: Concrete Subscriber
public class Reader : IObserver
{
    private string name;

    public Reader(string name)
    {
        this.name = name;
    }

    public void Update(string news)
    {
        Console.WriteLine($"{name} received news: {news}");
    }
}

// Step 1 + Step 3 + Step 4: Publisher
public class NewsAgency
{
    private List<IObserver> subscribers = new List<IObserver>();
    private string latestNews;

    // Subscribe
    public void Subscribe(IObserver observer)
    {
        subscribers.Add(observer);
    }

    // Unsubscribe
    public void Unsubscribe(IObserver observer)
    {
        subscribers.Remove(observer);
    }

    // Publish news
    public void Publish(string news)
    {
        latestNews = news;
        NotifyAllSubscribers();
    }

    // Notify all subscribers
    private void NotifyAllSubscribers()
    {
        foreach (var subscriber in subscribers)
        {
            subscriber.Update(latestNews);
        }
    }
}

// Step 5: Demo
class Programs
{
    static void Main(string[] args)
    {
        // Publisher
        NewsAgency newsAgency = new NewsAgency();

        // Subscribers
        Reader reader1 = new Reader("Alice");
        Reader reader2 = new Reader("Bob");
        Reader reader3 = new Reader("Charlie");

        // Subscribe
        newsAgency.Subscribe(reader1);
        newsAgency.Subscribe(reader2);
        newsAgency.Subscribe(reader3);

        // Publish news
        newsAgency.Publish("Breaking News: Pub-Sub Pattern in C#!");

        Console.WriteLine();

        // Unsubscribe one reader
        newsAgency.Unsubscribe(reader2);

        // Publish again
        newsAgency.Publish("Update: Bob has unsubscribed.");
    }
}
