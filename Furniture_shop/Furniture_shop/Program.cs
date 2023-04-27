using System;
namespace Furniture_shop
{
    using System;

    class Furniture
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public string Colour { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Furniture() { }

        public virtual void Accept()
        {
            Console.WriteLine("Enter furniture details:");
            Console.Write("Height: ");
            Height = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            Width = double.Parse(Console.ReadLine());
            Console.Write("Colour: ");
            Colour = Console.ReadLine();
            Console.Write("Quantity: ");
            Quantity = int.Parse(Console.ReadLine());
            Console.Write("Price: ");
            Price = double.Parse(Console.ReadLine());
        }

        public virtual void Display()
        {
            Console.WriteLine($"Type of furniture: {this.GetType().Name}");
            Console.WriteLine($"Height: {Height}");
            Console.WriteLine($"Width: {Width}");
            Console.WriteLine($"Colour: {Colour}");
            Console.WriteLine($"Quantity: {Quantity}");
            Console.WriteLine($"Price: {Price}");
        }
    }

    class Bookshelf : Furniture
    {
        public int NumShelves { get; set; }

        public override void Accept()
        {
            base.Accept();
            Console.Write("Number of shelves: ");
            NumShelves = int.Parse(Console.ReadLine());
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Number of shelves: {NumShelves}");
        }
    }

    class DiningTable : Furniture
    {
        public int NumLegs { get; set; }

        public override void Accept()
        {
            base.Accept();
            Console.Write("Number of legs: ");
            NumLegs = int.Parse(Console.ReadLine());
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Number of legs: {NumLegs}");
        }
    }

    class Program
    {
        static int AddToStock(Furniture[] stock)
        {
            Console.WriteLine("Adding furniture to stock:");
            int numItems = 0;
            while (numItems < stock.Length)
            {
                Console.Write($"Enter item {numItems + 1} (B for Bookshelf, D for Dining Table): ");
                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "B":
                        stock[numItems] = new Bookshelf();
                        break;
                    case "D":
                        stock[numItems] = new DiningTable();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        continue;
                }
                stock[numItems].Accept();
                numItems++;
            }
            Console.WriteLine("Stock added successfully.");
            return numItems;
        }

        static double TotalStockValue(Furniture[] stock)
        {
            double totalValue = 0;
            foreach (Furniture item in stock)
            {
                totalValue += item.Quantity * item.Price;
            }
            return totalValue;
        }

        static void ShowStockDetails(Furniture[] stock)
        {
            Console.WriteLine("Showing stock details:");
            foreach (Furniture item in stock)
            {
                item.Display();
            }
        }

        static void Main(string[] args)
        {
            Furniture[] stock = new Furniture[5];
            int numItems = AddToStock(stock);
            ShowStockDetails(stock);
            double totalValue = TotalStockValue(stock);
            Console.WriteLine($"Total stock value: INR{totalValue}");
        }
    }
}