/*The Adapter pattern allows otherwise incompatible classes 
to work together by converting the interface of one class 
into an interface expected by the clients*/
using System;

interface ITarget1
{
    void Request();
}

class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Adaptee's specific request called.");
    }
}

class Adapter : ITarget1
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public void Request()
    {
        _adaptee.SpecificRequest();
    }
}
interface ITarget2
{
    void Request();
}

class Adaptee2
{
    public void SpecificRequest()
    {
        Console.WriteLine("Adaptee2 specific request called.");
    }
}

class Adapter2 : Adaptee2, ITarget2
{
    public void Request()
    {
        base.SpecificRequest();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("---------------------------------EXAMPLE 1---------------------------------");
        Adaptee adaptee = new Adaptee();
        ITarget1 target = new Adapter(adaptee);
        target.Request();

        System.Console.WriteLine("---------------------------------EXAMPLE 2---------------------------------");
        ITarget2 target2 = new Adapter2();
        target2.Request();
    }
}
