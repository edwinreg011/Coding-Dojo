namespace HungryNinja.Models
{
    public class Drink : IConsumable
    {
    public string Name {get;set;}
    public int Calories {get;set;}
    public bool IsSpicy {get;set;}
    public bool IsSweet {get;set;}

    public string GetInfo()
    {
        return $"{Name}, Calories: {Calories}, Sweet: {IsSweet}.";
    }

    public Drink(string name, int cal, bool spice)
    {
        Name = name;
        Calories = cal;
        IsSpicy = spice;
        IsSweet = true;
    }

    
    
    }
}