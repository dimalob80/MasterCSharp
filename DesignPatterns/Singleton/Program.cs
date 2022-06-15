using Singleton;
using static System.Console;


var instance1 = SingletonClass.GetInstance();
//instance1.Value = 1;

var instance2 = SingletonClass.GetInstance();
//instance2.Value = 2;

var thread1 = new Thread(()=>
{
    var v1 = SingletonClass.GetInstance();
    Thread.Sleep(1000);
    WriteLine($"Value in thread 1: {v1.Value}");
});

var thread2 = new Thread(() =>
{
    var v2 = SingletonClass.GetInstance();
    WriteLine($"Value in thread 2: {v2.Value}");
    v2.Value = 100;
});

thread1.Start();
thread2.Start();


WriteLine($"Outside the threads. HashCodes: {instance1.GetHashCode()} | {instance2.GetHashCode()}");
WriteLine($"Outside the threads. Values: {instance1.Value} | {instance2.Value}");

ReadKey();

