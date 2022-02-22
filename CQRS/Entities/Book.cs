namespace MediatR.API.Entities;

public class Book
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Category { get; private set; }

    private Book()
    {
    }

    public Book(string name, string category)
    {
        Name = name;
        Category = category;
    }

    public Book(int id, string name, string category)
    {
        Id = id;
        Name = name;
        Category = category;
    }

    public void ChangeId(int id)
    {
        if (id is 0) throw new ArgumentException("An id cannot have 0 as value");
        Id = id;
    }

    public void ChangeName(string name)
    {
        ThrowIfStringEmpty(name);
        Name = name;
    }

    public void ChangeCategory(string category)
    {
        ThrowIfStringEmpty(category);
        Category = category;
    }

    private void ThrowIfStringEmpty(string parameter)
    {
        if (string.IsNullOrWhiteSpace(parameter)) throw new ArgumentException("Value cannot be an empty string");
    }
}