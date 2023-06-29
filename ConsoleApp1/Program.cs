// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Diagnostics;

Console.WriteLine("Hello, World!");
printRandomNumber printNumber = new printRandomNumber();
printNumber.print();

printRandomNumberV2 printNumberV2 = new printRandomNumberV2();
printNumberV2.printV2();

printStaticNumber.printStatic();
Console.Clear();


// public variables can be modify from enywhere
car myCar = new car();
Console.WriteLine($"my car default model is : {myCar.carModel}");
myCar.carModel = "second car model";
Console.WriteLine($"my updated model is : {myCar.carModel}");

// Property getter and setter
Console.WriteLine($"my car default price is : {myCar.price}");
myCar.price = 700000;
Console.WriteLine($"my updated price is : {myCar.price}");

//getter
Console.WriteLine($"my car launch year is : {myCar.launchYear}");
//setter
myCar.launchYear = 2022;
Console.WriteLine($"my car updated launch year is : {myCar.launchYear}");

dictionaryUse();


static void dictionaryUse()
{
    Random random = new Random();
    Dictionary<int, int> dictionayNumbers = new Dictionary<int, int>();

    Stopwatch timer = new Stopwatch();
    timer.Start();
    for (int i = 0; i < 1000; i++)
    {
        var vrNumber = random.Next(1, 101);
        if (dictionayNumbers.ContainsKey(vrNumber))
        {
            dictionayNumbers[vrNumber]++;
        }
        else
        {
            dictionayNumbers.Add(vrNumber, 1);
        }
    }
    timer.Stop();
    Console.WriteLine($"ms time - {timer.Elapsed.TotalMilliseconds}");
}

class printRandomNumber
{
    Random random = new Random();

    public void print()
    {
        Console.WriteLine(random.Next().ToString("N0"));
    }

    private void printPrivate()
    {
        Console.WriteLine("printPrivate" + random.Next().ToString("N0"));
    }

    protected void printProtected()
    {
        Console.WriteLine("protected random number" + random.Next().ToString());
    }

    public void callPrintPrivate()
    {
        this.printPrivate();
    }
}

class printRandomNumberV2: printRandomNumber
{
    public void printV2()
    {
        this.printProtected();
        this.callPrintPrivate();
    }
}

static class printStaticNumber
{
    static Random random = new Random();
    public static void printStatic()
    {
        for (int startNumber = 0; startNumber < 10; startNumber++)
        {
            Console.WriteLine("static random number" + random.Next().ToString());
        }
    }
}

class car
{
    public string carModel = "Default Car";
    public int price { get; set; }

    public int lYear;
    public int launchYear { 
        get
        {
            if (lYear < 2010)
            {
                return 2010;
            }
            return lYear;
        }
        set
        {
            if (lYear > 2020)
            {
                lYear = 2020;
            }
            lYear = value - 10;
        }
    }
}
