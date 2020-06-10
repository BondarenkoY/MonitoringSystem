using System;

class Program
{
    static void Main(string[] args)
    {
        Guest g1 = new Guest(10, 0);
        g1.Create();
        LoggedUser l1 = new LoggedUser(11, 0992111111);
        l1.Create();
        Operator m1 = new Operator(901, 0993111111);
        m1.Create();
        CentralOperator a1 = new CentralOperator(1001, 0994111111);
        a1.Create();
        Facade facade1 = new Facade(new Add_Sit(), new Calling());
        facade1.Operation1();
        facade1.Operation2();
        Console.ReadLine();
    }
}
abstract class Client
{
    public int Id { get; set; }
    public int Phone { get; set; }
    public Client(int id, int ph)
    {
        Id = id;
        Phone = ph;
    }
    abstract public Call Create();
}
class VisitingUser : Client
{

    public VisitingUser(int id, int ph) : base(id, ph)
    {
    }
    public override Call Create()
    {
        return new Calling();
    }
}
class OperatorUser : Client
{
    public OperatorUser(int id, int ph) : base(id, ph)
    {
    }
    public override Call Create()
    {
        return new Add_Sit();
    }
}
class Guest : VisitingUser
{
    public Guest(int id, int ph) : base(id, ph)
    {
    }
    public override Call Create()
    {
        Console.WriteLine($"Guest +38{Phone} called...");
        return new Calling();
    }
}
class LoggedUser : VisitingUser
{
    public LoggedUser(int id, int ph) : base(id, ph)
    {
    }
    public override Call Create()
    {
        Console.WriteLine($"Logged user +38{Phone} called...");
        return new Calling();
    }
}
class Operator : OperatorUser
{
    public Operator(int id, int ph) : base(id, ph)
    {
    }
    public override Call Create()
    {
        Console.WriteLine($"Operator +38{Phone} called...");
        return new Add_Sit();
    }
}

class CentralOperator : OperatorUser
{
    public CentralOperator(int id, int ph) : base(id, ph)
    {
    }
    public override Call Create()
    {
        Console.WriteLine($"CentralOperator +38{Phone} called...");
        return new Add_Sit();
    }
}
abstract public class Call
{
}
public class Add_Sit : Call
{
    public Add_Sit()
    {
        Console.WriteLine("Situation created!");
    }
    public void SomeAction()
    {
        Console.WriteLine("Situation created added on Map");
    }
}
public class Calling : Call
{
    public Calling()
    {
        Console.WriteLine("Situation created!");
    }
    public void SomeAction()
    {
        Console.WriteLine("Situation created added on Map");
    }
}
public class Facade
{
    Add_Sit a1;
    Calling c1;
    public Facade(Add_Sit a, Calling c)
    {
        a1 = a;
        c1 = c;
    }
    public void Operation1()
    {
        a1.SomeAction();
        c1.SomeAction();
    }
    public void Operation2()
    {
        c1.SomeAction();
    }

}
