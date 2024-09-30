using Resources.Enums;
using MainApp.Menu;

namespace MainApp.CustomerMenu;

internal class ProductMenu
{
    private readonly ProductService _productService = new ProductService();

    public ProductMenu()
    {
        _productService.LoadProducts(); // Ladda produkter från fil vid start
    }

    // Meny för att skapa ny produkt
    public void CreateMenu()
    {
        Product product = new Product(0, "", 0); // Skapa en ny produkt med defaultvärden

        Console.Clear();
        Console.WriteLine("Create New Product");

        // Hämta produktens namn från användaren
        Console.Write("Enter Product Name: ");
        product.Name = Console.ReadLine() ?? "";

        // Hämta produktens pris från användaren och validera att det är ett decimalvärde
        Console.Write("Enter Product Price: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            product.Price = price;
        }
        else
        {
            Console.WriteLine("Invalid price format. Please enter a valid decimal number.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            return;
        }

        // Lägg till produkten i listan och visa resultatet
        var result = _productService.AddToList(product);

        switch (result)
        {
            case ResultStatus.Success:
                Console.WriteLine("\nProduct was created successfully.");
                break;

            case ResultStatus.Exists:
                Console.WriteLine("\nProduct with the same name already exists.");
                break;

            case ResultStatus.Failed:
                Console.WriteLine("\nSomething went wrong while creating the product.");
                break;

            case ResultStatus.SuccessWithErrors:
                Console.WriteLine("\nProduct was created successfully. But product list was not saved.");
                break;
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    // Meny för att visa alla produkter
    public void ViewAllMenu()
    {
        var productList = _productService.GetAllProducts();

        Console.Clear();
        Console.WriteLine("View All Products\n");

        if (productList.Any())
        {
            foreach (Product product in productList)
            {
                Console.WriteLine($"ID: {product.ID}, Name: {product.Name}, Price: {product.Price:C}");
                Console.WriteLine("------------------------------");
            }
        }
        else
        {
            Console.WriteLine("No products in list\n");
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    // Meny för att visa en enskild produkt baserat på ID
    public void ViewSingleMenu()
    {
        Console.Clear();
        Console.WriteLine("View Single Product\n");

        Console.Write("Enter Product ID: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var product = _productService.GetProduct(id);

            if (product != null)
            {
                Console.Clear();
                Console.WriteLine($"View Details for Product ID: {product.ID}\n");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price:C}\n");
            }
            else
            {
                Console.WriteLine($"No product found with ID: {id}\n");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format. Please enter a valid number.");
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    // Meny för att ta bort en produkt baserat på ID
    public void DeleteMenu()
    {
        Console.Clear();
        Console.WriteLine("Delete Product\n");

        Console.Write("Enter Product ID: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var result = _productService.DeleteProduct(id);

            switch (result)
            {
                case ResultStatus.Success:
                    Console.WriteLine("Product was deleted successfully.");
                    break;

                case ResultStatus.NotFound:
                    Console.WriteLine("Product was not found.");
                    break;

                case ResultStatus.Failed:
                    Console.WriteLine("\nSomething went wrong while deleting the product.");
                    break;

                case ResultStatus.SuccessWithErrors:
                    Console.WriteLine("\nProduct was deleted successfully. But product list was not saved.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format. Please enter a valid number.");
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
}
