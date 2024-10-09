using System;
using System.Collections.Generic;
public class Car : IEquatable<Car>
{
    public string Name { get; set; }
    public string Engine { get; set; }
    public int MaxSpeed { get; set; }
    public Car(string name, string engine, int maxSpeed)
    {
        Name = name;
        Engine = engine;
        MaxSpeed = maxSpeed;
    }
    public override string ToString()
    {
        return Name;
    }
    public bool Equals(Car other)
    {
        if (other == null) return false;
        return Name == other.Name && Engine == other.Engine && MaxSpeed == other.MaxSpeed;
    }
    public override bool Equals(object obj)
    {
        if (obj is Car other)
        {
            return Equals(other);
        }
        return false;
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode() ^ Engine.GetHashCode() ^ MaxSpeed.GetHashCode();
    }
}
public class CarsCatalog
{
    private List<Car> cars;
    public CarsCatalog()
    {
        cars = new List<Car>();
    }
    public void AddCar(Car car)
    {
        cars.Add(car);
    }
    public string this[int index]
    {
        get
        {
            if (index >= 0 && index < cars.Count)
            {
                return $"{cars[index].Name} ({cars[index].Engine})";
            }
            throw new IndexOutOfRangeException("Индекс выходит за пределы коллекции.");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car("Toyota Camry", "V6", 220);
        Car car2 = new Car("Honda Civic", "Inline-4", 200);
        Car car3 = new Car("Ford Mustang", "V8", 250);
        CarsCatalog catalog = new CarsCatalog();
        catalog.AddCar(car1);
        catalog.AddCar(car2);
        catalog.AddCar(car3);
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(catalog[i]);
        }
        Console.WriteLine($"car1 == car2: {car1.Equals(car2)}");
        Console.WriteLine($"car1 == car1: {car1.Equals(car1)}");
    }
}
