using System;

namespace Singletonpattern
{}
public sealed class Singleton
{
    private static Singleton instance = null;
    private static readonly object padlock = new object();

    // Private constructor
    private Singleton()
    {
        Console.WriteLine("Instance Created");
    }

    // Public method to get the instance
    public static Singleton GetInstance()
    {
        // Double-checked locking for thread safety
        if (instance == null)
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
            }
        }
        return instance;
    }

    // Sample method to test singleton behavior
    public void PrintDetails(string message)
    {
        Console.WriteLine($"Message: {message}");
    }
}


