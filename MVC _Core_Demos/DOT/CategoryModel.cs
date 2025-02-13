using Data.Entities;

public class CategoryModel
{

    public int Id { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }

    public ICollection<Product> Products { get; set; }

}
