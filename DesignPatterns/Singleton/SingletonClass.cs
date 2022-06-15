using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton;

internal class SingletonClass
{
    // Static members are 'eagerly initialized', that is, 
    // immediately when class is loaded for the first time.
    // .NET guarantees thread safety for static initialization

    private static SingletonClass _instance = new SingletonClass(new Random().Next(1, 10));

    private int _value;
    public int Value { get { return _value; } set { Console.WriteLine($"Setting value to {value}"); _value = value; } }

    private SingletonClass(int value)
    {
        Value = value;
        Console.WriteLine($"Creating instance with value: {Value}");
    }

    public static SingletonClass GetInstance()
    {
        Console.WriteLine($"Checking instance value: {_instance?.Value}");
        //return _instance = _instance ?? new SingletonClass(new Random().Next(1, 10));
        return _instance!;
    }
}
