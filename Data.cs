static class Data
{
    public static decimal Money { get; private set; } = 10000m;

    public static List<Rarity> Rarities = [];
    public static List<Category> Categoties = [];
    public static List<Item> Items = [];
    public static List<LootBox> LootBoxes = [];
    public static List<LootBoxItem> LootBoxItems = [];

    public static List<Item> InventoryItems = [];

    public static void Dodep(decimal money)
    {
        Money += money;
        Console.WriteLine($"Баланс успешно пополнен на сумму {money}₽");
    }

    public static void Withdraw(decimal money)
    {
        if (Money < money)
        {
            Console.WriteLine("Недостаточно средств на балансе.");
            return;
        }
        Money -= money;
        Console.WriteLine($"Сумма {money}₽ успешно снята с баланса.");
    }
}