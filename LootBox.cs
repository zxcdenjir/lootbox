class LootBox
{
    public int Id;
    public string Name;
    public string Description;
    public int ItemCount;
    public decimal Cost;

    public LootBox(string name, string description, int itemCount, decimal cost)
    {
        Id = Data.LootBoxes.Count;
        Name = name;
        Description = description;
        ItemCount = itemCount;
        Cost = cost;
    }
}