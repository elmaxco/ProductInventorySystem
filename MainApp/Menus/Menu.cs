using MainApp.CustomerMenu;

namespace MainApp.Menu;


public class Menu
{
    private readonly CustomerMenu _customerMenu = new CustomerMenu();
    private readonly ProductMenu _productMenu = new ProductMenu();

    public void MainMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Main Menu");
            Console.WriteLine("1.".PadRight(5) + "Customer Management");
            Console.WriteLine("2.".PadRight(5) + "Product Management");
            Console.WriteLine("3.".PadRight(5) + "Exit");
            Console.Write("\nEnter your choice: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CustomerManagementMenu();
                    break;

                case "2":
                    ProductManagementMenu();
                    break;

                case "3":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("\nIncorrect choice, please try again by pressing any key.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void CustomerManagementMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("Customer Management Menu");
            Console.WriteLine("1.".PadRight(5) + "Create Customer");
            Console.WriteLine("2.".PadRight(5) + "View All Customers");
            Console.WriteLine("3.".PadRight(5) + "View Single Customer");
            Console.WriteLine("4.".PadRight(5) + "Delete Customer");
            Console.WriteLine("5.".PadRight(5) + "Back to Main Menu");
            Console.Write("\nEnter your choice: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    _customerMenu.CreateMenu();
                    break;

                case "2":
                    _customerMenu.ViewAllMenu();
                    break;

                case "3":
                    _customerMenu.ViewSingleMenu();
                    break;

                case "4":
                    _customerMenu.DeleteMenu();
                    break;

                case "5":
                    back = true;
                    break;

                default:
                    Console.WriteLine("\nIncorrect choice, please try again by pressing any key.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void ProductManagementMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("Product Management Menu");
            Console.WriteLine("1.".PadRight(5) + "Create Product");
            Console.WriteLine("2.".PadRight(5) + "View All Products");
            Console.WriteLine("3.".PadRight(5) + "View Single Product");
            Console.WriteLine("4.".PadRight(5) + "Delete Product");
            Console.WriteLine("5.".PadRight(5) + "Back to Main Menu");
            Console.Write("\nEnter your choice: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    _productMenu.CreateMenu();
                    break;

                case "2":
                    _productMenu.ViewAllMenu();
                    break;

                case "3":
                    _productMenu.ViewSingleMenu();
                    break;

                case "4":
                    _productMenu.DeleteMenu();
                    break;

                case "5":
                    back = true;
                    break;

                default:
                    Console.WriteLine("\nIncorrect choice, please try again by pressing any key.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
