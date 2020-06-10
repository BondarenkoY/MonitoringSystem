using System;
class Program
{
    static void Main(string[] args)
    {
        Guest g1 = new Guest(0, 0);
        g1.Create();
        LoggedUser l1 = new LoggedUser(5, 0991111111);
        l1.Create();
        Operator m1 = new Operator(901, 0992111111);
        m1.Create();
        CentalOperator a1 = new CentalOperator(1001, 0993111111);
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

        Console.ReadLine();
    }
}
abstract class Person
{
    public int Id { get; set; }
    public int Phone { get; set; }
    public Person(int id, int ph)
    {
        Id = id;
        Phone = ph;
    }
    abstract public Map Create();
}
class VisitingUser : Person
{
    public VisitingUser(int id, int ph) : base(id, ph)
    {
    }
    public override Map Create()
    {
        return new Calling();
    }
}
class ModeratingUser : Person
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
        Console.WriteLine($"Operator {Phone} adding situation...");
        return new Add_Sit();
    }
}
class CentalOperator : ModeratingUser
{
    public CentalOperator(int id, int ph) : base(id, ph)
    {
    }
    public override Map Create()
    {
        Console.WriteLine($"Administrator {Phone} adding situation...");
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
        Console.WriteLine("Situation is changing...");
    }
    public void WriteArticle()
    {
        Console.WriteLine("Situation is saved! ");
    }
    public void DeleteArticle()
    {
        Console.WriteLine("Situation is deleted ");

    }
}
public class Calling : Map
{
    public Calling()
    {
        Console.WriteLine("Calling is created!");
    }
    public void SomeAction()
    {
        Console.WriteLine("The call continues...");
    }
    public void WriteCommentary()
    {
        Console.WriteLine("Calling is written ");
    }
    public void DeleteCommentary()
    {
        Console.WriteLine("Calling is deleted ");
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

class SuperUser : CentalOperator
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
        Console.WriteLine($"Super user {Phone} wrote something...");
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
