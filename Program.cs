class Bank
{
    private Tuple<string, string>[] accounts;

    public Bank()
    {
        accounts = [
            new Tuple<string, string>("Joe.Doe", "Password123")
        ];
    }
 
    public void Login()
    {

    }

    public void Signup()
    {

    }
}

static class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Welcome to the bank!");
        Console.WriteLine("");

		var bank = new Bank();

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Signup");
            Console.WriteLine("3. Exit");
            Console.WriteLine("");
            Console.Write("Enter your choice: ");

            var choice = Console.ReadLine();

            switch (choice.Trim())
            {
                case "1":
                    bank.Login();
                    break;
                case "2":
                    bank.Signup();
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
	}
}
