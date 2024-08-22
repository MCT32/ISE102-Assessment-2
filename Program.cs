// Class for storing customer information

class Customer
{
    // Login information
    public string Username { get; set; }
    public string Password { get; set; }

    // Customer's current bank balance
    public float Balance { get; set; }

    // Constructor to initialize customer information
    public Customer(string username, string password, float balance)
    {
        this.Username = username;
        this.Password = password;
        this.Balance = balance;
    }
}

// Class for storing bank accounts and functions
class Bank
{
    // List of customer accounts
    private List<Customer> accounts;

    // Constructor to initialize bank accounts
    public Bank()
    {
        // Initialize list of customer accounts
        accounts = [
            // Starting account as mentioned in the assignment
            new Customer("Joe.Doe", "Password123", 1000),
            new Customer("Joestar", "Qwerty", 5)
        ];
    }

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

    // Function to check if the password is valid
    bool CheckPassword(string password)
    {
        // Check if the password is empty
        if (string.IsNullOrWhiteSpace(password)) {
            Console.WriteLine("Password cannot be empty.");
            return false;
        }

        // Check if the password is at least 8 characters long
        if (password.Length <= 8) {
            Console.WriteLine("Password must be at least 8 characters long.");
            return false;
        }

        // Check if the password contains any whitespace
        if (password.Any(char.IsWhiteSpace)) {
            Console.WriteLine("Password cannot contain whitespace.");
            return false;
        }

        // If all checks pass, return true
        return true;
    }

    // Function to check if the username is valid
    bool CheckUsername(string username)
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
        if (this.accounts.Any(account => account.Username == username)) {
            Console.WriteLine("Username is already taken.");
            return false;
        }

        // If all checks pass, return true
        return true;
    }

    // Function to login to the bank
    public void Login()
    {
        Console.WriteLine("Please Enter Username:"); // this gives the prompt to the user to enter their username.
        string username = Console.ReadLine(); //this reads the username that has been inputed by the user and stores it.
         Customer customer = accounts.FirstOrDefault(account => account.Username == username); //This simply checks if the username that has been inputted exists within the array.
         // if the username does not match this means it is null or not found which redirects to these 3 lines of codes which displays Invalid Username.
         if (customer == null){ 
            Console.WriteLine("Invalid Username");
            return; // exits the function
         }
         Console.Write("Enter your password "); // this allows the user to input a password.
         string password = getPassword(); //this calls the getPassword function to read the inputed function by the user.
          if (customer.Password != password){ //This just checks if the password provided by the user matches the password stored in the signup.
            Console.WriteLine("\nInvalid password"); // if the password fails to verify then this will display to the user that the password in invalid.
            return; //exists the function
          }
          Console.WriteLine("\nSuccesful Login, Signing in...."); // similarly if the password is verified and is indeed correct, this will be displayed to the user instead.

        this.LoggedInMenu(username);
    }

    // Function to signup to the bank
    public void Signup()
    {
        // For George to do
        // Creating the Username
        Console.WriteLine("Hi! Welcome to the bank. What shall your username to be?");
        string username = Console.ReadLine();

        if (CheckUsername(username)) {
            Console.WriteLine("Awesome! Now let's create your password.");
        }
        else
        {
            Console.WriteLine("Invalide username");
            return;
        }

        Console.WriteLine("So what do you want your password to be?");
        string password = getPassword();
        Console.WriteLine("\n");

        if (CheckPassword(password))
        {
            this.accounts.Add(new Customer(username, password, 0));
            Console.WriteLine("Awesome! Your account has been created.");
        }
        else
        {
            Console.WriteLine("Invalid password");
            return;
        }
    }

    // Main function to run the program
	public static void Main(string[] args)
	{
        // Welcome message
		Console.WriteLine("Welcome to the bank!");
        Console.WriteLine("");

        // Create a new bank object
		var bank = new Bank();

        // Main menu loop
        while (true)
        {
            // Menu options
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Signup");
            Console.WriteLine("3. Exit");
            Console.WriteLine("");
            Console.Write("Enter your choice: ");

            // Read user input
            var choice = Console.ReadLine();

            // Switch statement to handle user input
            switch (choice.Trim())
            {
                case "1":
                    bank.Login();
                    break;
                case "2":
                    bank.Signup();
                    break;
                case "3":
                    // Exit the program
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    // Invalid choice message
                    // Get user input again
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
	}

    // Menu for once user is logged in
    public void LoggedInMenu(String username) {
        // Main menu loop
        while (true)
        {
            // Welcome
            Console.WriteLine(String.Format("Hello, {0}!", username));

            // Menu options
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Log out");
            Console.WriteLine("");
            Console.Write("Enter your choice: ");

            // Read user input
            var choice = Console.ReadLine();

            // Switch statement to handle user input
            switch (choice.Trim())
            {
                case "1":
                    this.Deposit(username);
                    break;
                case "2":
                    this.Withdraw(username);
                    break;
                case "3":
                    // Log out
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    // Invalid choice message
                    // Get user input again
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

    // Deposit money into account
        public void Deposit(String username)
    {
        Customer customer = accounts.FirstOrDefault(account => account.Username == username);

        // Prompt to user to enter the amount
        Console.Write("Enter amount to deposit: ");
        string input = Console.ReadLine();

        // This part makes sure the amount which was entered is correct and does ot go over the balance amount. It also converts any input to a float value.
        if (float.TryParse(input, out float amount) && amount > 0)
        {
            customer.Balance += amount;
            Console.WriteLine($"Successfully deposited {amount:C}. New balance: {customer.Balance:C}");
        }
        else
        {
            Console.WriteLine("Invalid amount. Please enter a positive number.");
        }
    }

    // Withdraw from user accounts
    public void Withdraw(String username)
    {
        Customer customer = accounts.FirstOrDefault(account => account.Username == username);

        Console.Write("Enter amount to withdraw: ");
        string input = Console.ReadLine();

        if (float.TryParse(input, out float amount) && amount > 0)
        {
            if (amount <= customer.Balance)
            {
                customer.Balance -= amount;
                Console.WriteLine($"You have withdrew {amount:C}.balance after the withdraw: {customer.Balance:C}");
            }
            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }
    }
}