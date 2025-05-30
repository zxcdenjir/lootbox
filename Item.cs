class Item
{
    public int Id;
    public string Name;
    public string Description;
    public int RarityId;
    public int CategoryId;

    public Item(string name, string description, int rarityId, int categoryId)
    {
        Id = Data.Items.Count;
        Name = name;
        Description = description;
        RarityId = rarityId;
        CategoryId = categoryId;
    }
    public override string ToString()
    {
        return $"ID: {Id}, Название: {Name}, Редкость: {Data.Rarities[RarityId].Name}, Категория: {Data.Categoties[CategoryId].Name}";
    }
}