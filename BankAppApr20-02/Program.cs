using System;

namespace BankAppApr20_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****Welcome to my bank!****");
            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Deposit money");
                Console.WriteLine("3. Withdraw money");
                Console.WriteLine("4. Print all accounts");
                Console.WriteLine("5. Print all transactions");

                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting the bank!");
                        return;
                    case "1":
                        Console.Write("Account Name: ");
                        var accountName = Console.ReadLine();
                        Console.Write("Email Address: ");
                        var emailAddress = Console.ReadLine();
                        Console.WriteLine("Account type: ");

                        var accountTypes = Enum.GetNames(typeof(TypeOfAccounts));
                        for(var i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}. {accountTypes[i]}");
                        }
                        var accountType = Enum.Parse<TypeOfAccounts>(Console.ReadLine());

                        Console.Write("Amount to deposit: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());

                        var account = Bank.CreateAccount(accountName, emailAddress, accountType, amount);
                        Console.WriteLine($"AN: {account.AccountNumber}, Name: {account.AccountName}, Email: {account.EmailAddress}, B: {account.Balance:C}, CD: {account.CreatedDate}, AT: {account.AccountType}");

                        break;

                    case "2":
                        PrintAllAccounts();
                        try
                        {
                            Console.Write("Account Number: ");
                            var acctNumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Amount to Deposit: ");
                            amount = Convert.ToDecimal(Console.ReadLine());

                            Bank.Deposit(acctNumber, amount);
                            Console.WriteLine("Deposit successfully completed!");
                        }
                        
                        catch (FormatException)
                        {
                            Console.WriteLine("Input is invalid. Please try again!");
                        }
                        catch(OverflowException)
                        {
                            Console.WriteLine("Input is invalid. Please try again!");
                        }
                        catch(ArgumentException ax)
                        {
                            Console.WriteLine($"Error - {ax.Message}");
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong! Please try again");
                        }
                        break;
                    case "3":
                        PrintAllAccounts();
                        try
                        {
                            Console.Write("Account Number: ");
                            var aNumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Amount to Withdraw: ");
                            amount = Convert.ToDecimal(Console.ReadLine());

                            Bank.Withdraw(aNumber, amount);
                            Console.WriteLine("Withdrawal successfully completed!");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Input is invalid. Please try again!");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Input is invalid. Please try again!");
                        }
                        catch (ArgumentException ax)
                        {
                            Console.WriteLine($"Error - {ax.Message}");
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong! Please try again");
                        }
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                    case "5":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());

                        var transactions = Bank.GetTransactionsByAccountNumber(accountNumber);
                        foreach (var transaction in transactions)
                        {
                            Console.WriteLine($"TD: {transaction.TransactionDate}, TA: {transaction.Amount:C}, TT: {transaction.TransactionType}, AN: {transaction.AccountNumber}");
                        }

                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        private static void PrintAllAccounts()
        {
            Console.Write("Email Address: ");
            var emailAddress = Console.ReadLine();
            var accounts = Bank.GetAccounts(emailAddress);
            foreach (var a in accounts)
            {
                Console.WriteLine($"AN: {a.AccountNumber}, Name: {a.AccountName}, Email: {a.EmailAddress}, B: {a.Balance:C}, CD: {a.CreatedDate}, AT: {a.AccountType}");
            }
        }
    }
}
