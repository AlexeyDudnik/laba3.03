using System;
public class Currency
{
    public double Value { get; set; }

    public Currency(double value)
    {
        Value = value;
    }
}
public class CurrencyUSD : Currency
{
    public CurrencyUSD(double value) : base(value) { }
    public static implicit operator CurrencyEUR(CurrencyUSD usd)
    {
        return new CurrencyEUR(usd.Value * ExchangeRates.USDtoEUR);
    }
    public static implicit operator CurrencyRUB(CurrencyUSD usd)
    {
        return new CurrencyRUB(usd.Value * ExchangeRates.USDtoRUB);
    }
}
public class CurrencyEUR : Currency
{
    public CurrencyEUR(double value) : base(value) { }
    public static implicit operator CurrencyUSD(CurrencyEUR eur)
    {
        return new CurrencyUSD(eur.Value * ExchangeRates.EURtoUSD);
    }
    public static implicit operator CurrencyRUB(CurrencyEUR eur)
    {
        return new CurrencyRUB(eur.Value * ExchangeRates.EURtoRUB);
    }
}
public class CurrencyRUB : Currency
{
    public CurrencyRUB(double value) : base(value) { }
    public static implicit operator CurrencyUSD(CurrencyRUB rub)
    {
        return new CurrencyUSD(rub.Value * ExchangeRates.RUBtoUSD);
    }
    public static implicit operator CurrencyEUR(CurrencyRUB rub)
    {
        return new CurrencyEUR(rub.Value * ExchangeRates.RUBtoEUR);
    }
}
public static class ExchangeRates
{
    public static double USDtoEUR { get; set; }
    public static double USDtoRUB { get; set; }
    public static double EURtoUSD { get; set; }
    public static double EURtoRUB { get; set; }
    public static double RUBtoUSD { get; set; }
    public static double RUBtoEUR { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите обменные курсы:");
        Console.Write("USD to EUR: ");
        ExchangeRates.USDtoEUR = double.Parse(Console.ReadLine());
        Console.Write("USD to RUB: ");
        ExchangeRates.USDtoRUB = double.Parse(Console.ReadLine());
        Console.Write("EUR to USD: ");
        ExchangeRates.EURtoUSD = double.Parse(Console.ReadLine());
        Console.Write("EUR to RUB: ");
        ExchangeRates.EURtoRUB = double.Parse(Console.ReadLine());
        Console.Write("RUB to USD: ");
        ExchangeRates.RUBtoUSD = double.Parse(Console.ReadLine());
        Console.Write("RUB to EUR: ");
        ExchangeRates.RUBtoEUR = double.Parse(Console.ReadLine());
        CurrencyUSD usd = new CurrencyUSD(100);
        CurrencyEUR eur = new CurrencyEUR(100);
        CurrencyRUB rub = new CurrencyRUB(100);
        CurrencyEUR convertedToEUR = usd;
        CurrencyRUB convertedToRUB = eur;
        CurrencyUSD convertedToUSD = rub;
        Console.WriteLine($"100 USD = {convertedToEUR.Value} EUR");
        Console.WriteLine($"100 EUR = {convertedToRUB.Value} RUB");
        Console.WriteLine($"100 RUB = {convertedToUSD.Value} USD");
    }
}
