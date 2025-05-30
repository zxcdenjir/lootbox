class Rarity
{
    public int Id;
    public decimal DropChance;
    public ConsoleColor Color;
    public string Name;

    public Rarity(decimal dropChance, ConsoleColor color, string name)
    {
        Id = Data.Rarities.Count;
        DropChance = dropChance;
        Color = color;
        Name = name;
    }
}