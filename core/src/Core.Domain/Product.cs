namespace Core.Domain;

public class Product
{
    // TODO: вернуть категории если будет время
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Cost { get; private set; }
    public decimal? Discount { get; private set; }
    public string? Description { get; private set; }
    public Guid Category { get; private set; }
    public Media[] Thumbnails { get; private set; }

    public decimal DiscountedCost { get => GetDiscountedCost(); }

    public Product(Guid id, string name, decimal cost)
    {
        Id = id;
        Name = name;
        Cost = cost;
        Thumbnails = [];

        Validate();
    }

    private Product(
        Guid id,
        string name,
        decimal cost,
        decimal? discount,
        string? description,
        Guid category,
        Media[] thumbnails
    )
    {
        Id = id;
        Name = name;
        Cost = cost;
        Discount = discount;
        Description = description;
        Category = category;
        Thumbnails = thumbnails ?? [];

        Validate();
    }

    public void Validate()
    {
        if (Id == Guid.Empty)
        {
            throw new InvalidPropertyException<Guid>("Id", Id);
        }

        if (Name == "")
        {
            throw new InvalidPropertyException<string>("Name", Name);
        }

        if (Cost < 0)
        {
            throw new InvalidPropertyException<decimal>("Cost", Cost);
        }

        if (Discount != null && (Discount < 0 || Discount > 1))
        {
            throw new InvalidPropertyException<decimal?>("Discount", Discount);
        }
    }

    public void Update(
        string name,
        decimal cost,
        decimal? discount,
        string? description,
        Guid category,
        Media[] thumbnails
    )
    {
        SetName(name);
        SetCost(cost);

        if (discount.HasValue)
            SetDiscount(discount.Value);
        else
            RemoveDiscount();

        if (string.IsNullOrEmpty(description))
            RemoveDescription();
        else
            SetDescription(description);

        // SetCategory(category);
        SetThumbnails(thumbnails);
    }

    public void SetName(string name)
    {
        if (name == "")
        {
            throw new InvalidPropertyException<string>("Name", name);
        }

        Name = name;
    }

    public void SetCost(decimal cost)
    {
        if (cost < 0)
        {
            throw new InvalidPropertyException<decimal>("Cost", cost);
        }

        Cost = cost;
    }

    public void SetDiscount(decimal discount)
    {
        if (discount < 0 || discount > 1)
        {
            throw new InvalidPropertyException<decimal>("Discount", discount);
        }

        Discount = discount;
    }

    public void RemoveDiscount()
    {
        Discount = null;
    }

    public void SetDescription(string description)
    {
        if (description == "")
        {
            throw new InvalidPropertyException<string>("Description", description);
        }

        Description = description;
    }

    public void RemoveDescription()
    {
        Description = null;
    }

    // public void SetCategory(Guid category)
    // {
    //     if (category == Guid.Empty)
    //     {
    //         throw new InvalidPropertyException<Guid>("Category", category);
    //     }

    //     Category = category;
    // }

    public void SetThumbnails(Media[] thumbnails)
    {
        Thumbnails = thumbnails;
    }

    private decimal GetDiscountedCost()
    {
        return Cost * (1 - Discount ?? 0);
    }
}
