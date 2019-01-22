using System;


namespace WP1
{
    public class Item
    {
        public string itemType;
        public string color;
        public char size;
        public int qty;
        public double price;

        public void displayItem()
        {
            double totalprice = price * qty;

            Console.WriteLine($"{itemType}");
            Console.WriteLine($"Color: {color}");
            Console.WriteLine($"Size: {size}");
            Console.WriteLine($"Quantity: {qty}");
            Console.WriteLine($"Price: ${price}");
            Console.WriteLine($"Total Price: ${totalprice}");
        }

    }

    public class Shoes : Item
    {   
        public void displayShoes()
        {
            itemType = "Shoes";
            color = "Black";
            size = 'M';
            price = 75.00;
            displayItem();
            Console.WriteLine("-----------------------");

        }
    }

    public class Pants : Item
    {
        public void displayPants()
        {
            itemType = "Pants";
            color = "Navy Blue";
            size = 'M';
            price = 50.00;
            displayItem();
            Console.WriteLine("-----------------------");

        }
    }

    public class Shirts : Item
    {
        public void displayShirts()
        {
            itemType = "Shirts";
            color = "Gray";
            size = 'M';
            price = 25.00;
            displayItem();
            Console.WriteLine("-----------------------");

        }
    }
    //You should split your classes into multiple .cs files.
    //This helps with Readability and Maintability.
    
}
