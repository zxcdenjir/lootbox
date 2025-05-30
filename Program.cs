class Program
{
    private static Random random = new();
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Data.Rarities.Add(new Rarity(0.60m, ConsoleColor.Gray, "Обычный"));
        Data.Rarities.Add(new Rarity(0.25m, ConsoleColor.Blue, "Редкий"));
        Data.Rarities.Add(new Rarity(0.10m, ConsoleColor.Magenta, "Эпический"));
        Data.Rarities.Add(new Rarity(0.05m, ConsoleColor.Yellow, "Легендарный"));

        Data.Categoties.Add(new Category("Оружие"));
        Data.Categoties.Add(new Category("Броня"));
        Data.Categoties.Add(new Category("Зелья"));
        Data.Categoties.Add(new Category("Аксессуары"));
        Data.Categoties.Add(new Category("Магические"));

        Data.Items.Add(new Item("Меч", "Острый клинок", 0, 0));             
        Data.Items.Add(new Item("Щит", "Защищает вас", 0, 1));             
        Data.Items.Add(new Item("Зелье здоровья", "Восстанавливает здоровье", 0, 2));
        Data.Items.Add(new Item("Лук", "Стреляет стрелами", 1, 0));          
        Data.Items.Add(new Item("Кинжал", "Быстрый и лёгкий", 0, 0));         
        Data.Items.Add(new Item("Тяжёлая броня", "Защищает от ударов", 1, 1));
        Data.Items.Add(new Item("Зелье маны", "Восполняет ману", 0, 2));       
        Data.Items.Add(new Item("Кольцо силы", "Увеличивает силу владельца", 2, 3));
        Data.Items.Add(new Item("Амулет мудрости", "Дарует мудрость", 2, 3));
        Data.Items.Add(new Item("Посох стихий", "Магический посох", 2, 4));
        Data.Items.Add(new Item("Мантия теней", "Невидимость в бою", 3, 4));
        Data.Items.Add(new Item("Булава", "Сокрушительная сила", 1, 0));
        Data.Items.Add(new Item("Щит драконьей чешуи", "Почти не пробиваемый", 2, 1));
        Data.Items.Add(new Item("Эликсир бессмертия", "Секрет древних", 3, 2));

        Data.LootBoxes.Add(new LootBox("Базовый ящик", "Содержит преимущественно обычные предметы", 3, 349));
        Data.LootBoxes.Add(new LootBox("Продвинутый ящик", "Содержит улучшенные предметы", 4, 799));
        Data.LootBoxes.Add(new LootBox("Легендарный ящик", "Содержит элитные предметы", 5, 1999));

        Data.LootBoxItems.Add(new LootBoxItem(0, 0));
        Data.LootBoxItems.Add(new LootBoxItem(1, 0));
        Data.LootBoxItems.Add(new LootBoxItem(2, 0));
        Data.LootBoxItems.Add(new LootBoxItem(3, 0));

        Data.LootBoxItems.Add(new LootBoxItem(0, 1));
        Data.LootBoxItems.Add(new LootBoxItem(4, 1));
        Data.LootBoxItems.Add(new LootBoxItem(5, 1));
        Data.LootBoxItems.Add(new LootBoxItem(7, 1));
        Data.LootBoxItems.Add(new LootBoxItem(8, 1));

        Data.LootBoxItems.Add(new LootBoxItem(3, 2));
        Data.LootBoxItems.Add(new LootBoxItem(6, 2));
        Data.LootBoxItems.Add(new LootBoxItem(9, 2));
        Data.LootBoxItems.Add(new LootBoxItem(10, 2));
        Data.LootBoxItems.Add(new LootBoxItem(11, 2));
        Data.LootBoxItems.Add(new LootBoxItem(12, 2));
        Data.LootBoxItems.Add(new LootBoxItem(13, 2));

        foreach (LootBox lootBox in Data.LootBoxes)
        {
            int count = 0;
            foreach (LootBoxItem lbi in Data.LootBoxItems)
            {
                if (lbi.LootBoxId == lootBox.Id)
                    count++;
            }
            lootBox.ItemCount = count;
        }


        while (true)
        {
            Console.WriteLine($"Текущий баланс: {Data.Money}₽\n");
            Console.WriteLine("1. Работа с лутбоксами");
            Console.WriteLine("2. Работа с редкостью");
            Console.WriteLine("3. Работа с категорией");
            Console.WriteLine("4. Работа с предметами");
            Console.WriteLine("5. Пополнить баланс");
            Console.WriteLine("6. Инвентарь");
            Console.WriteLine("7. Выход");

            switch (Input("Выберите действие: ", 1, 7))
            {
                case 1:
                    Console.Clear();
                    LootBoxActions();
                    break;

                case 2:
                    Console.Clear();

                    break;

                case 3:
                    Console.Clear();

                    break;

                case 4:
                    Console.Clear();

                    break;

                case 5:
                    Console.WriteLine();
                    decimal money = Input("Введите сумму для пополнения баланса: ", 0, decimal.MaxValue);
                    Data.Dodep(money);
                    PressToContinue();
                    break;

                case 6:
                    Console.Clear();
                    Console.WriteLine("Ваш инвентарь:");
                    if (Data.InventoryItems.Count == 0)
                    {
                        Console.WriteLine("Инвентарь пуст");
                    }
                    else
                    {
                        foreach (Item item in Data.InventoryItems)
                        {
                            Console.ForegroundColor = Data.Rarities[item.RarityId].Color;
                            Console.WriteLine(item);
                            Console.ResetColor();
                        }
                    }
                    PressToContinue();
                    break;

                case 7:
                    return;
            }
        }
    }

    static void LootBoxActions()
    {
        while (true)
        {
            PrintLootboxes();
            Console.WriteLine($"Текущий баланс: {Data.Money}₽\n");
            Console.WriteLine("1. Вывести информацию о лутбоксах");
            Console.WriteLine("2. Добавить предмет в лутбокс");
            Console.WriteLine("3. Создать лутбокс");
            Console.WriteLine("4. Открыть лутбокс");
            Console.WriteLine("5. Редактировать лутбокс");
            Console.WriteLine("6. В главное меню");

            switch (Input("Выберите действие: ", 1, 6))
            {
                case 1:
                    Console.Clear();
                    PrintLootboxes();
                    PressToContinue();
                    break;

                case 2:
                    Console.WriteLine();
                    PrintItems();
                    int itemId = Input("Введите ID предмета для добавления в лутбокс: ", 0, Data.Items.Count - 1);
                    int lootBoxId = Input("Введите ID лутбокса, в который вы хотите добавить предмет: ", 0, Data.LootBoxes.Count - 1);
                    LootBoxItem item = new(itemId, lootBoxId);

                    bool inLootbox = false;
                    foreach (LootBoxItem lbi in Data.LootBoxItems)
                    {
                        if (lbi.ItemId == itemId && lbi.LootBoxId == lootBoxId)
                        {
                            Console.WriteLine("Этот предмет уже добавлен в лутбокс!");
                            inLootbox = true;
                            break;
                        }
                    }
                    if (!inLootbox)
                    {
                        Data.LootBoxItems.Add(item);
                        Data.LootBoxes[lootBoxId].ItemCount++;
                        Console.WriteLine($"\nПредмет {Data.Items[itemId].Name} был добавлен в лутбокс {Data.LootBoxes[lootBoxId].Name}");
                    }
                    PressToContinue();
                    break;

                case 3:
                    Console.WriteLine();

                    Data.LootBoxes.Add(new LootBox(
                        Input("Введите название лутбокса: "),
                        Input("Введите описание лутбокса: "),
                        Input("Введите количество предметов в лутбоксе: ", 1, 100),
                        Input("Введите стоимость лутбокса: ", 0m, 1000000m)
                    ));

                    PressToContinue();
                    break;

                case 4:
                    Console.WriteLine();

                    int lootBoxToOpenId = Input("Введите ID лутбокса, который вы хотите открыть: ", 0, Data.LootBoxes.Count - 1);

                    if (Data.Money < Data.LootBoxes[lootBoxToOpenId].Cost)
                    {
                        Console.WriteLine("Недостаточно средств для открытия этого лутбокса!");
                        PressToContinue();
                        break;
                    }

                    Console.WriteLine();
                    Data.Withdraw(Data.LootBoxes[lootBoxToOpenId].Cost);
                    Console.WriteLine();

                    List<Item> items = ItemInLootbox(Data.LootBoxes[lootBoxToOpenId]);

                    int itemDropCount = random.Next(1, Data.LootBoxes[lootBoxToOpenId].ItemCount + 1);

                    for (int i = 0; i < itemDropCount; i++)
                    {
                        decimal totalChance = 0.0m;
                        for (int j = 0; j < items.Count; j++)
                        {
                            totalChance += Data.Rarities[items[j].RarityId].DropChance;
                        }

                        decimal roll = (decimal)random.NextDouble() * totalChance;
                        Item selectedItem = items[0];

                        for (int j = 0; j < items.Count; j++)
                        {
                            roll -= Data.Rarities[items[j].RarityId].DropChance;
                            if (roll <= 0)
                            {
                                selectedItem = items[j];
                                break;
                            }
                        }

                        Console.ForegroundColor = Data.Rarities[selectedItem.RarityId].Color;
                        Console.WriteLine("Вы получили: " + selectedItem.Name + " - " + selectedItem.Description);
                        Console.ResetColor();
                        Data.InventoryItems.Add(selectedItem);
                    }

                    PressToContinue();
                    break;


                case 6:
                    Console.Clear();
                    return;
            }
        }
        static void PrintLootboxes()
        {
            foreach (LootBox lootBox in Data.LootBoxes)
            {
                Console.WriteLine($"Лутбокс: {lootBox.Id}, Название: {lootBox.Name}, Колличество предметов: {lootBox.ItemCount}");
                Console.WriteLine($"Описание: {lootBox.Description}");
                Console.WriteLine("Предметы:");
                foreach (LootBoxItem lbi in Data.LootBoxItems)
                {
                    if (lbi.LootBoxId == lootBox.Id)
                    {
                        foreach (Item item in Data.Items)
                        {
                            if (item.Id == lbi.ItemId)
                            {
                                Console.WriteLine(item);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }

    static List<Item> ItemInLootbox(LootBox lootBox)
    {
        List<Item> items = [];
        foreach (LootBoxItem lbi in Data.LootBoxItems)
        {
            if (lbi.LootBoxId == lootBox.Id)
            {
                foreach (Item item in Data.Items)
                {
                    if (item.Id == lbi.ItemId)
                    {
                        items.Add(item);
                    }
                }
            }
        }
        return items;
    }

    static void PrintItems()
    {
        foreach (Item item in Data.Items)
        {
            Console.ForegroundColor = Data.Rarities[item.RarityId].Color;
            Console.WriteLine(item);
            Console.ResetColor();
        }
    }

    static T Input<T>(string text, T minValue, T maxValue) where T : struct, IComparable<T>
    {
        while (true)
        {
            Console.Write(text);
            string input = Console.ReadLine()!;

            T value;
            try
            {
                value = (T)Convert.ChangeType(input, typeof(T));
            }
            catch
            {
                Console.WriteLine("Неверный ввод данных!");
                continue;
            }

            if (value.CompareTo(minValue) < 0 || value.CompareTo(maxValue) > 0)
            {
                Console.WriteLine($"Некорректный ввод. Пожалуйста, введите число от {minValue} до {maxValue}");
                continue;
            }

            return value;
        }
    }
    static string Input(string text)
    {
        Console.Write(text);
        return Console.ReadLine()!;
    }

    static void PressToContinue()
    {
        Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
        Console.ReadKey();
        Console.Clear();
    }
}