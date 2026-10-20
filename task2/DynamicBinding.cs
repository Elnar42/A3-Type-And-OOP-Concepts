using System;

class Employee
{
    // Here we first define the method PrintRole as virtual, which means that it can be overridden in the derived classes.
    public virtual void PrintRole()
    {
        Console.WriteLine("Employee");
    }
}

class Manager : Employee
{
    // Here we override the PrintRole method in the Manager class.
    public override void PrintRole()
    {
        Console.WriteLine("Manager");
    }
}

class Developer : Employee
{
    // Here we override the PrintRole method in the Developer class.
    public override void PrintRole()
    {
        Console.WriteLine("Developer");
    }
}

class Program
{
    static void Main()
    {
        Employee person;

        // Here we create a new Manager object and assign it to the person variable.
        person = new Manager();

        // This prints "Manager" because the person object is of type Manager.
        person.PrintRole();

        // Here we create a new Developer object and assign it to the person variable.
        person = new Developer();

        // This prints "Developer" because the person object is of type Developer.
        person.PrintRole();
    }
}
