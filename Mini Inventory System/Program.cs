using System.Linq;

List<Product> products = new List<Product>();

void menu()
{
    Console.WriteLine("1. Add product");
    Console.WriteLine("2. Read all products");
    Console.WriteLine("3. Update products");
    Console.WriteLine("4. Delete products");
    Console.WriteLine("0. Exit");
    Console.Write("Choose option: ");
}

bool isOn = true;

while(isOn)
{
    menu();
    int choice = int.Parse(Console.ReadLine());


    switch (choice)
    {
        case 1:
            Console.Clear();
            AddProduct();
            break;
        case 2:
            Console.Clear();
            ReadProducts();
            break;
        case 3:
            Console.Clear();
            UpdateProducts();
            break;
        case 4:
            Console.Clear();
            DeleteProducts();
            break;
        case 0:
            isOn = false;
            return;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

//// Product
void AddProduct()
{
    int id = products.Count == 0
    ? 0
    : products.Max(p => p.Id);

    Console.Clear();

    Console.Write("Insert Name: ");
    string Name = Console.ReadLine();

    Console.Write("Insert Description: ");
    string Description = Console.ReadLine();

    Console.Write("Insert Price: ");
    decimal Price = decimal.Parse(Console.ReadLine());

    Console.Write("Insert Quantity: ");
    int Quantity = int.Parse(Console.ReadLine());




    Product product = new Product
    {
        Id = 1 + id,
        Name = Name,
        Description = Description,
        Price = Price,
        Quantity = Quantity
    };

    products.Add(product);
    Console.Write("Product has been added! \n\n\n");
}

void ReadProducts()
{
    foreach(Product product in products)
    {
        Console.WriteLine("===========================");
        Console.WriteLine($"" +
            $"Id: {product.Id}, " +
            $"Name: {product.Name}, " +
            $"Description: {product.Description}, " +
            $"Price: {product.Price}, " +
            $"Quantity: {product.Quantity}, "
            );
        Console.WriteLine("");
    }
}

void UpdateProducts()
{

    Console.Write("Insert id: ");
    int id = int.Parse(Console.ReadLine());

    Product? product = products.FirstOrDefault(p => p.Id == id);

    if(product == null)
    {
        Console.WriteLine("Product not found");
        return;
    }

    Console.WriteLine("1. Change name");
    Console.WriteLine("2. Change description");
    Console.WriteLine("3. Change price");
    Console.WriteLine("4. Change quantity");
    Console.WriteLine("0. Exit");
    Console.Write("Choose option: ");
    int UpdateChoice = int.Parse(Console.ReadLine());

    switch(UpdateChoice)
    {
        case 1:
            Console.Clear();
            Console.Write("Insert new Name: ");
            string Name = Console.ReadLine();
            product.Name = Name;
            break;
        case 2:
            Console.Clear();
            Console.Write("Insert new Description: ");
            string Description = Console.ReadLine();
            product.Description = Description;
            break;
        case 3:
            Console.Clear();
            Console.Write("Insert new Price: ");
            decimal Price = decimal.Parse(Console.ReadLine());
            product.Price = Price;
            break;
        case 4:
            Console.Clear();
            Console.Write("Insert new Quantity: ");
            int Quantity = int.Parse(Console.ReadLine());
            product.Quantity = Quantity;
            break;
        case 0:
            return;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }

    Console.WriteLine("Product updated successfully.");
}

void DeleteProducts()
{
    if (products.Count == 0)
    {
        Console.WriteLine("No products available.");
        return;
    }

    Console.Write("Insert id: ");
    int id = int.Parse(Console.ReadLine());

    Product? product = products.FirstOrDefault(p => p.Id == id);

    if (product == null)
    {
        Console.WriteLine("Product not found");
        return;
    }

    products.Remove(product);
    Console.WriteLine("Product deleted successfully.");
}


//// Category
