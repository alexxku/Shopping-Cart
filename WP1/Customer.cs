using System;


namespace WP1
{
    public class Customer
    {
        public string name;
        public int age;
        public double wallet = 0;

        public void displayCustomer()
        {
            Console.WriteLine($"-----------------\nCustomer: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Wallet: ${wallet}");
        }

        public void inputCustomer()
        {
            Console.Write("Enter Customer's Name: ");
            name = Console.ReadLine();

            A:
            try
            {
                Console.Write("Enter your age: ");
                age = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception error)
            {
                Console.WriteLine($"\n{error.Message.ToString()}\n");
                goto A;
            }
            B:
            try
            {
                Console.Write("Enter wallet: ");
                wallet = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception error)
            {
                Console.WriteLine($"\n{error.Message.ToString()}\n");
                goto B;
            }
            Console.WriteLine("\n");
            displayCustomer();
        }

        public void refillbalance()
        {
            restart:
            try
            {
                double x = Convert.ToDouble(Console.ReadLine());
                wallet = wallet + x;
            }
            catch (Exception error)
            {
                Console.WriteLine($"\n{error.Message.ToString()}\n");
                goto restart;
            }
            Console.WriteLine();
        }
    }
}
