using System;
public struct Vector
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public Vector(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }
    public static double operator *(Vector v1, Vector v2)
    {
        return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
    }
    public static Vector operator *(Vector v, double scalar)
    {
        return new Vector(v.X * scalar, v.Y * scalar, v.Z * scalar);
    }
    public static Vector operator *(double scalar, Vector v)
    {
        return v * scalar;
    }
    public static bool operator ==(Vector v1, Vector v2)
    {
        return v1.Length() == v2.Length();
    }
    public static bool operator !=(Vector v1, Vector v2)
    {
        return v1.Length() != v2.Length();
    }
    public static bool operator >(Vector v1, Vector v2)
    {
        return v1.Length() > v2.Length();
    }
    public static bool operator <(Vector v1, Vector v2)
    {
        return v1.Length() < v2.Length();
    }
    public static bool operator >=(Vector v1, Vector v2)
    {
        return v1.Length() >= v2.Length();
    }
    public static bool operator <=(Vector v1, Vector v2)
    {
        return v1.Length() <= v2.Length();
    }
    public double Length()
    {
        return Math.Sqrt(X * X + Y * Y + Z * Z);
    }
    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }
    public override bool Equals(object obj)
    {
        if (obj is Vector other)
        {
            return this == other;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Vector v1 = new Vector(1, 2, 3);
        Vector v2 = new Vector(4, 5, 6);
        Vector sum = v1 + v2;
        Console.WriteLine($"Сумма векторов: {sum}");
        double dotProduct = v1 * v2;
        Console.WriteLine($"Скалярное произведение: {dotProduct}");
        Vector scaledVector = v1 * 2;
        Console.WriteLine($"Умножение вектора на число: {scaledVector}");
        Console.WriteLine($"v1 == v2: {v1 == v2}");
        Console.WriteLine($"v1 != v2: {v1 != v2}");
        Console.WriteLine($"v1 > v2: {v1 > v2}");
        Console.WriteLine($"v1 < v2: {v1 < v2}");
        Console.WriteLine($"v1 >= v2: {v1 >= v2}");
        Console.WriteLine($"v1 <= v2: {v1 <= v2}");
    }
}
