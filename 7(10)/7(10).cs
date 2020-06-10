using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7Csh
{
    class Program
    {
        static void Main(string[] args)
        {
            Enter Guest = new VisitorEnter("Viktor");
            Creator enter1 = Guest.Create();
            Enter Visitor = new ClientEnter("Oleg");
            Creator enter2 = Visitor.Create();
            Console.WriteLine();
            Console.WriteLine("What is your name");
            string name = Console.ReadLine();
            Enter guest2 = new VisitorEnter(name);
            Creator enter3 = Guest.Create();
            Console.WriteLine();
            Console.WriteLine("Do you have an account? (1 - yes; any another key - no)");
            if (Console.ReadLine() == "1")
            {
                Console.Write(name);
                Creator enter4 = Visitor.Create();
            }
            Console.ReadLine();
        }
    }
    abstract class Enter
    {
        public string Name { get; set; }
        public Enter(string n)
        {
            Name = n;
            Console.Write(Name);
        }
        abstract public Creator Create();
    }
    class VisitorEnter : Enter
    {
        public VisitorEnter(string n) : base(n)
        { }
        public override Creator Create()
        {
            return new VisitorCreator();
        }
    }
    class ClientEnter : Enter
    {
        public ClientEnter(string n) : base(n)
        { }
        public override Creator Create()
        {
            return new ClientCreator();
        }
    }
    abstract class Creator
    { }

    class VisitorCreator : Creator
    {
        public VisitorCreator()
        {
            Console.WriteLine(" has entered on server as a guest");
        }
    }
    class ClientCreator : Creator
    {
        public ClientCreator()
        {
            Console.WriteLine(" has entered on server as a client");
        }
    }
}
