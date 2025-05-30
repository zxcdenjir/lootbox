class Category
{
    public int Id;
    public string Name;

    public Category(string name)
    {
        Id = Data.Categoties.Count;
        Name = name;
    }
}