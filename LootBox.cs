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

    public void PrintLootBox()
    {
        Console.Write($"Лутбокс: ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"{Id}");
        Console.ResetColor();
        Console.Write($", Название: {Name}, Колличество предметов: {ItemCount}, Цена: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{Cost}₽");
        Console.ResetColor();
        Console.WriteLine($"Описание: {Description}");
        Console.WriteLine("Предметы:");
        foreach (LootBoxItem lbi in Data.LootBoxItems)
        {
            if (lbi.LootBoxId == Id)
            {
                foreach (Item item in Data.Items)
                {
                    if (item.Id == lbi.ItemId)
                    {
                        Console.ForegroundColor = Data.Rarities[item.RarityId].Color;
                        Console.WriteLine(item);
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}