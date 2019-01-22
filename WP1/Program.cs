using System;

namespace WP1
{
    class Program
    {
        //Global objects and variables
        int STQTY, PQTY, SHQTY;
        double totalprice;
        Pants Pants = new Pants();
        Shoes Shoes = new Shoes();
        Shirts Shirts = new Shirts();
        Customer Customer = new Customer();

        static void Main(string[] args)

        {
            int a, b, c;
            string x;
            //CallMethod object
            Program CallMethod = new Program();
            //Calling methods
            CallMethod.Customer.inputCustomer();
            CallMethod.defaultdisplayInventory();
            while (true)
            {
                CallMethod.purchases();

                Console.WriteLine("Would you like to end this program? If so, enter Y. If not, press any key repeat.\n");
                x = Console.ReadLine();

                if (x == "Y" || x == "y")
                {
                    break;
                }
                Console.WriteLine("Do you want to refill your wallet ? If so, enter Y. If not, press any key to continue\n");
                x = Console.ReadLine();
                if (x == "Y" || x == "y")
                {
                    Console.Write("\nAmount: ");
                    CallMethod.Customer.refillbalance();
                }

                Console.WriteLine("Do you want to restock your inventory ? If so, enter Y. If not, press any key to continue\n");
                x = Console.ReadLine();
                if (x == "Y" || x == "y")
                {
                    A:
                    try
                    {
                        Console.Write("\nShirt: ");
                        a = Convert.ToInt32(Console.ReadLine());
                        CallMethod.Shirts.qty = CallMethod.Shirts.qty + a;
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine($"\n{error.Message.ToString()}\n");
                        goto A;
                    }
                    B:
                    try
                    {
                        Console.Write("\nPants: ");
                        b = Convert.ToInt32(Console.ReadLine());
                        CallMethod.Pants.qty = CallMethod.Pants.qty + b;
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine($"\n{error.Message.ToString()}\n");
                        goto B;
                    }
                    C:
                    try
                    {
                        Console.Write("\nShoes: ");
                        c = Convert.ToInt32(Console.ReadLine());
                        CallMethod.Shoes.qty = CallMethod.Shoes.qty + c;
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine($"\n{error.Message.ToString()}\n");
                        goto C;
                    }
                
                }
                CallMethod.Customer.displayCustomer();

                CallMethod.defaultdisplayInventory(CallMethod.Shirts.qty, CallMethod.Pants.qty, CallMethod.Shoes.qty);
            }

            Console.WriteLine("Thank you for using this program. Good Bye!\n");
            Console.ReadLine();

        }



        public void defaultdisplayInventory(int x = 10, int y = 10, int z = 10)
        {

            Shirts.qty = x;
            Pants.qty = y;
            Shoes.qty = z;

            Console.WriteLine("----------------\n\nInventory\n----------");
            Shirts.displayShirts();
            Pants.displayPants();
            Shoes.displayShoes();

        }



        public void UpdatedDisplayInventory(int ST, int P, int SH)
        {

            Shirts.qty = ST;
            Pants.qty = P;
            Shoes.qty = SH;

            Console.WriteLine("Updated Inventory\n----------");
            Shirts.displayShirts();
            Pants.displayPants();
            Shoes.displayShoes();

        }



        public void receipt(int RST, int RP, int RSH)
        {
            Shirts.qty = RST;
            Pants.qty = RP;
            Shoes.qty = RSH;

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++\nReceipt");

            Customer.wallet = Customer.wallet - totalprice;
            Customer.displayCustomer();
            Console.WriteLine($"Total Cost: ${totalprice}\n--------------------");
            Shirts.displayShirts();
            Pants.displayPants();
            Shoes.displayShoes();
            Console.WriteLine("\n------------------------");
        }



        public void purchases()
        {
           
            int STInvQty;
            int SHInvQty;
            int PInvQty;
            bool balance;

        
            Console.WriteLine("\nEnter the amount of items to purchase\n---------------------------");
            do
            {
                STInvQty = shirtPurchases();
                PInvQty = pantsPurchases();
                SHInvQty = shoesPurchases();
                totalprice = (STQTY * Shirts.price) + (PQTY * Pants.price) + (SHQTY * Shoes.price);

                balance = BalanceCondition(totalprice, (STQTY * Shirts.price), (PQTY * Pants.price), (SHQTY * Shoes.price));
            }
            while (balance == true);
            Console.WriteLine("\n");

            receipt(STQTY, PQTY, SHQTY);

            UpdatedDisplayInventory(STInvQty, PInvQty, SHInvQty);

        }



        public int shirtPurchases()
        {
            int InvQTY;
            restart:
            try
            {
                Console.Write("Shirt Qty: ");
                STQTY = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception error)
            {
                Console.WriteLine($"\n{error.Message.ToString()}\n");
                goto restart;
            }

            while (STQTY > Shirts.qty)
            {
                Console.WriteLine("\nNot Enough Stock.");
                try
                {
                    Console.Write("\nShirt Qty: ");
                    STQTY = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception error)
                {
                    Console.WriteLine($"\n{error.Message.ToString()}\n");
                    goto restart;
                }
            }

            return InvQTY = Shirts.qty - STQTY;
        }



        public int shoesPurchases()
        {
            int InvQTY;
            restart:
            try
            { 
            Console.Write("Shoes Qty: ");
            SHQTY = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception error)
            {
                Console.WriteLine($"\n{error.Message.ToString()}\n");
                goto restart;
            }
            while (SHQTY > Shoes.qty)
            {
                Console.WriteLine("\nNot Enough Stock.");
                try
                {
                    Console.Write("\nShoes Qty: ");
                    SHQTY = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception error)
                {
                    Console.WriteLine($"\n{error.Message.ToString()}\n");
                    goto restart;
                }
            }

            return InvQTY = Shoes.qty - SHQTY;
        }



        public int pantsPurchases()
        {
            int InvQTY;
            restart:
            try
            {
                Console.Write("Pants Qty: ");
                PQTY = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception error)
            {
                Console.WriteLine($"\n{error.Message.ToString()}\n");
                goto restart;
            }

            while (PQTY > Pants.qty)
            {
                Console.WriteLine("\nNot Enough Stock.");
                try
                {
                    Console.Write("\nPants Qty: ");
                    PQTY = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception error)
                {
                    Console.WriteLine($"\n{error.Message.ToString()}\n");
                    goto restart;
                }
            }
            return InvQTY = Pants.qty - PQTY;
        }



        public bool BalanceCondition(double W, double STP, double PP, double SHP)
        {
            if (Customer.wallet < (Shirts.price * STQTY))
            {
                Console.WriteLine("\nNot Enough Balance.\n");
                return true;
            }
            else if (Customer.wallet < (Pants.price * PQTY))
            {
                Console.WriteLine("\nNot Enough Balance.\n");
                return true;
            }
            else if (Customer.wallet < (Shoes.price * SHQTY))
            {
                Console.WriteLine("\nNot Enough Balance.\n");
                return true;
            }
            else if (Customer.wallet < totalprice)
            {
                Console.WriteLine("\nNot Enough Balance.\n");
                return true;
            }
            return false;
        }
    }
}
