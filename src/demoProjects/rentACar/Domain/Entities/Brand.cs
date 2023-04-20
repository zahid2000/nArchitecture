namespace Domain.Entities;

public class Brand:Entity
{
    public Brand()
    {
    }
    public Brand(int id, string name) : base(id)
    {
        Name = name;
    }
    public string? Name { get; set; }
    public virtual ICollection<Model> Models { get; set; }

}
