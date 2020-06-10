using System;

class Program
{
    static void Main(string[] args)
    {

        Guest g1 = new Guest(0, 0);
        g1.Create();
        LoggedUser l1 = new LoggedUser(11, 0991111111);
        l1.Create();
        Operator m1 = new Operator(901, 0992111111);
        m1.Create();
        CentralOperator a1 = new CentralOperator(1001, 0993111111);
        a1.Create();

        SuperUser su1 = new SuperUser(1, 1);
        su1.Create();

        Facade facade1 = new Facade(new Add_Sit(), new Calling());
        facade1.Operation1();
        facade1.Operation2();

        Calling cmntr1 = new Calling();
        Add_Sit artcl = new Add_Sit();
        su1.SetCommand(new ArticleOnCommand(artcl));
        su1.DoSomething();
        su1.UndoSomething();
        su1.SetCommand(new CommentaryOnCommand(cmntr1));
        su1.DoSomething();
        su1.UndoSomething();

        ManagerIntermediator intermediator = new ManagerIntermediator();
        SystemUser customer = new CustomerSystemUser(intermediator);
        SystemUser moder = new IntermoderatingSystemUser(intermediator);

        intermediator.Customer = customer;
        intermediator.Operator = moder;
        customer.Send("I want to add a situation to the map");
        moder.Send("We checked it, everything is in order, it is already on the map");
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
    abstract public Map Create();
}
class VisitingUser : Client
{
    public VisitingUser(int id, int ph) : base(id, ph)
    {
    }
    public override Map Create()
    {
        return new Calling();
    }
}
class ModeratingUser : Client
{
    public ModeratingUser(int id, int ph) : base(id, ph)
    {
    }
    public override Map Create()
    {
        return new Add_Sit();
    }
}
class Guest : VisitingUser
{
    public Guest(int id, int ph) : base(id, ph)
    {
    }
    public override Map Create()
    {
        Console.WriteLine($"Guest {Phone} calling...");
        return new Calling();
    }
}

class LoggedUser : VisitingUser
{
    public LoggedUser(int id, int ph) : base(id, ph)
    {
    }
    public override Map Create()
    {
        Console.WriteLine($"Logged user {Phone} calling...");
        return new Calling();
    }
}
class Operator : ModeratingUser
{
    public Operator(int id, int ph) : base(id, ph)
    {
    }
    public override Map Create()
    {
        Console.WriteLine($"Operator {Phone} adding situation");
        return new Add_Sit();
    }
}
class CentralOperator : ModeratingUser
{
    public CentralOperator(int id, int ph) : base(id, ph)
    {
    }
    public override Map Create()
    {
        Console.WriteLine($"Administrator {Phone} adding situation");
        return new Add_Sit();
    }
}
abstract public class Map
{
}
public class Add_Sit : Map
{
    public Add_Sit()
    {
        Console.WriteLine("Situation is created!");
    }
    public void SomeAction()
    {
        Console.WriteLine("Situation is changing");
    }
    public void WriteArticle()
    {
        Console.WriteLine("Situation is saved");
    }
    public void DeleteArticle()

    {
        Console.WriteLine("Situation is deleted");
    }
}
public class Calling : Map
{
    public Calling()
    {
        Console.WriteLine("Calling is created");
    }
    public void SomeAction()
    {
        Console.WriteLine("The call continues");
    }
    public void WriteCommentary()
    {
        Console.WriteLine("Calling is saved");
    }
    public void DeleteCommentary()
    {
        Console.WriteLine("Calling is deleted");
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
interface ICommand
{
    void Execute();
    void Undo();
}
class CommentaryOnCommand : ICommand
{
    Calling cm;
    public CommentaryOnCommand(Calling cmSet)
    {
        cm = cmSet;

    }
    public void Execute()
    {
        cm.WriteCommentary();
    }
    public void Undo()
    {
        cm.DeleteCommentary();
    }
}
class ArticleOnCommand : ICommand
{
    Add_Sit artcl;
    public ArticleOnCommand(Add_Sit artclSet)
    {
        artcl = artclSet;
    }
    public void Execute()
    {
        artcl.WriteArticle();
    }
    public void Undo()
    {
        artcl.DeleteArticle();
    }
}

class SuperUser : CentralOperator
{
    private static SuperUser instance;
    public SuperUser(int id, int ph) : base(id, ph)
    {
    }
    public static SuperUser getInstance(int id1, int ph1)
    {
        if (instance == null)
            instance = new SuperUser(id1, ph1);
        return instance;
    }
    public override Map Create()
    {
        Console.WriteLine($"Super user {Phone} checked the situation");
        return new Add_Sit();
    }
    ICommand command;
    public void SetCommand(ICommand com)
    {
        command = com;
    }
    public void DoSomething()
    {
        command.Execute();
    }

    public void UndoSomething()
    {
        command.Undo();
    }
}

abstract class intermediator
{
    public abstract void Send(string msg, SystemUser colleague);
}
abstract class SystemUser
{
    protected intermediator intermediator;
    public SystemUser(intermediator intermediator)
    {
        this.intermediator = intermediator;
    }
    public virtual void Send(string message)
    {
        intermediator.Send(message, this);
    }
    public abstract void Notify(string message);
}
//Customer
class CustomerSystemUser : SystemUser
{
    public CustomerSystemUser(intermediator intermediator)
    : base(intermediator)
    { }
    public override void Notify(string message)
    {
        Console.WriteLine("Message to customers: " + message);
    }
}
class IntermoderatingSystemUser : SystemUser
{
    public IntermoderatingSystemUser(intermediator intermediator)
    : base(intermediator)
    { }
    public override void Notify(string message)
    {
        Console.WriteLine("Message to operator: " + message);
    }
}
class ManagerIntermediator : intermediator
{
    public SystemUser Customer { get; set; }
    public SystemUser Operator { get; set; }
    public override void Send(string msg, SystemUser sysuser)
    {

        if (Customer == sysuser)
            Operator.Notify(msg);
        else if (Operator == sysuser)
            Customer.Notify(msg);
    }
}

