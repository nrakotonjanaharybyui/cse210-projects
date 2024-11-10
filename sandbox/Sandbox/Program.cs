using System;
using System.Runtime.InteropServices.Marshalling;

class Program
{
    static void Main(string[] args)
    {
        Hourly empl1 = new Hourly("James", 30, 45);
        Salary empl2 = new Salary("Andrew", 125000);
        Volunteer empl3 = new Volunteer("Dax");
        Console.WriteLine(empl1.CalculatePay());
        Console.WriteLine(empl2.CalculatePay());
        Console.WriteLine(empl3.CalculatePay());
    }
}

public class Employee
{
    private string _name;
    protected float _pay;

    public Employee(string name)
    {
        _name = name;
        _pay = 0;
    }

    public float CalculatePay()
    {
        return _pay;
    }
}

public class Salary : Employee
{
    private float _salary;

    public Salary(string name, float salary) : base(name)
    {
        _salary = salary;
        _pay = _salary;
    }
}

public class Hourly : Employee
{
    private float _rate;
    private int _totalHour;

    public Hourly(string name, float rate, int totalHour): base(name)
    {
        _rate = rate;
        _totalHour = totalHour;
        _pay = _rate * _totalHour;
    }
}

public class Volunteer : Employee
{
    public Volunteer(string name):base(name)
    {
        _pay = 0;
    }
}