// Function to get a password from the user while hiding the input
string getPassword() {
    // Buffer to store the entered password
    string EnteredVal = "";

    // Loop until password is entered
    do {
        // Read a single character from the user
        ConsoleKeyInfo key = Console.ReadKey(true);

        // If the user presses backspace, remove the last character from the password
        if (key.Key == ConsoleKey.Backspace) {
            // If the password is not empty, remove the last character from the password
            if (EnteredVal.Length > 0) {
                // Remove the last character from the buffer
                EnteredVal = EnteredVal.Substring(0, (EnteredVal.Length - 1));
                // Erase the last character from the screen
                Console.Write("\b \b");
            }
        // If the user presses enter, return the password
        } else if (key.Key == ConsoleKey.Enter) {
            // First check if the password is empty
            if (string.IsNullOrWhiteSpace(EnteredVal)) {
                Console.WriteLine("");
                Console.WriteLine("Empty value not allowed.");
                // Recursively call the function to retry
                return getPassword();
            } else {
                return EnteredVal;
            }
        // Otherwise, add the character to the password
        } else {
            EnteredVal += key.KeyChar;
            // Display the character as a star
            Console.Write("*");
        }
    } while (true);
}

CheckPassword(string password)
{
    // Check if the password is empty
    if (string.IsNullOrWhiteSpace(password)) {
        Console.WriteLine("Password cannot be empty.");
        return false;
    }

    // Check if the password is at least 8 characters long
    if (password.Length < 8) {
        Console.WriteLine("Password must be at least 8 characters long.");
        return false;
    }

    if (password.Any(char.IsWhiteSpace)) {
        Console.WriteLine("Password cannot contain whitespace.");
        return false;
    }

    return true;
}

CheckUsername(string username)
{
    // Check if the username is empty
    if (string.IsNullOrWhiteSpace(username)) {
        Console.WriteLine("Username cannot be empty.");
        return false;
    }

    // Check if the username contains any invalid characters
    if (!username.All(char.IsLetterOrDigit)) {
        Console.WriteLine("Username can only contain letters and digits.");
        return false;
    }

    // Check if the username is already taken
    if (accounts.Any(account => account.Item1 == username)) {
        Console.WriteLine("Username is already taken.");
        return false;
    }

    return true;
}

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
