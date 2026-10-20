using System;

class Employee
{
    // Here we first define the method PrintRole as virtual, which means that it can be overridden in the derived classes.
    public virtual void PrintRole()
    {
        Console.WriteLine("Employee");
    }

    // PrintDepartment is not virtual, so a call is bound to Employee when the reference type is Employee.
    public void PrintDepartment()
    {
        Console.WriteLine("General department");
    }
}

class Manager : Employee
{
    // Here we override the PrintRole method in the Manager class.
    public override void PrintRole()
    {
        Console.WriteLine("Manager");
    }

    // new hides Employee.PrintDepartment. The call is bound from the reference type, not the object type.
    public new void PrintDepartment()
    {
        Console.WriteLine("Management department");
    }
}

class Developer : Employee
{
    // Here we override the PrintRole method in the Developer class.
    public override void PrintRole()
    {
        Console.WriteLine("Developer");
    }

    // new hides Employee.PrintDepartment. The call is bound from the reference type, not the object type.
    public new void PrintDepartment()
    {
        Console.WriteLine("Engineering department");
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

        // The object is a Manager, but person has type Employee, so this prints "General department".
        person = new Manager();
        person.PrintDepartment();

        // The reference type is Manager, so this prints "Management department".
        Manager manager = new Manager();
        manager.PrintDepartment();
    }
}
