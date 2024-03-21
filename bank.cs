using System;

public class BankAccount
{
    // Properties
    public string AccountNumber { get; }
    public double Balance { get; private set; }
    public string Type { get; }

    // Constructors
    public BankAccount(string accountNumber, double initialBalance = 0, string type = "Checking")
    {
        AccountNumber = accountNumber; // This Initializes account number
        Balance = initialBalance; // This Initializes balance
        Type = type; // This Initializes account type
    }

    // Methods
    public void Deposit(double amount)
    {
        if (amount <= 0) // This checks if deposit amount is positive or not
        {
            Console.WriteLine("Deposit amount should be greater than zero."); // Displaying error
            return;
        }
        Balance += amount;
        Console.WriteLine($"{amount} deposited into {Type} account. New balance: {Balance}"); // Display deposit confirmation
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0) // Check if withdrawal amount is not positive
        {
            Console.WriteLine("Withdrawal amount should be greater than zero."); // Display error message
            return; // Exit method
        }
        if (Balance < amount) // Check if withdrawal amount exceeds balance
        {
            Console.WriteLine("Insufficient funds."); // Display error message
            return; // Exit method
        }
        Balance -= amount; // Subtract withdrawal amount from balance
        Console.WriteLine($"{amount} withdrawn from {Type} account. New balance: {Balance}"); // Display withdrawal confirmation
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Testing different constructors and methods
        BankAccount checkingAccount = new BankAccount("123456789"); // Create a checking account
        BankAccount savingAccount = new BankAccount("987654321", 1000, "Savings"); // Create a savings account with initial balance

        // Displaying account information
        Console.WriteLine($"Checking Account Number: {checkingAccount.AccountNumber}, Balance: {checkingAccount.Balance}, Type: {checkingAccount.Type}");
        Console.WriteLine($"Savings Account Number: {savingAccount.AccountNumber}, Balance: {savingAccount.Balance}, Type: {savingAccount.Type}");

        // Testing deposit and withdrawal methods for checking account
        checkingAccount.Deposit(10000);
        checkingAccount.Withdraw(5000);
        checkingAccount.Withdraw(5000); // Insufficient funds test

        // Testing deposit and withdrawal methods for savings account
        savingAccount.Deposit(200);
        savingAccount.Withdraw(1000); // Insufficient funds test

        Console.ReadLine(); // Keep the console open
    }
}
