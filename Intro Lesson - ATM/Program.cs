﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mime;

namespace IntroToCSharp
{
    class Program
    {
        static int balance = 100;

        static void Main()
        {
            string pinCode = "1234";    

            Console.WriteLine("ATM");
            Console.WriteLine("Enter your PIN Code");
            string userInput = GetUserInput();
            string result = userInput == pinCode ? "correct" : "error";

            while (userInput != "0")
            {
                if (result == "correct")
                {
                    DisplayMenu();

                    userInput = GetUserInput();
                    switch (userInput)
                    {
                        case "1":
                            DisplayCurrentBalance();
                            DisplayMenu();
                            userInput = GetUserInput();
                            break;
                        case "2":
                            Withdraw();
                            DisplayMenu();
                            userInput = GetUserInput();
                            break;
                        case "3":
                            Deposit();
                            DisplayMenu();
                            userInput = GetUserInput();
                            break;
                        case "4":
                            UpdateBalance(Operation.Withdraw);
                            break;
                        case "5":
                            UpdateBalance(Operation.Deposit);
                            break;
                        case "6":
                            UpdateBalance(50);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect PIN.");
                    Console.WriteLine("Please try again or press 0 to exit");

                    Console.WriteLine("Enter your PIN Code");
                    userInput = GetUserInput(); ;
                }
            }
        }

        private static void DisplayMenu() //method doesn't return anything and parameterless
        {
            Console.WriteLine("MENU");
            Console.WriteLine("Enter 1 to view balance");
            Console.WriteLine("Enter 2 to withdraw cash");
            Console.WriteLine("Enter 3 to deposit");
        }

        private static string GetUserInput() //method returns a string
        {
            Console.Write("User input > ");
            return Console.ReadLine();
        }

        private static void DisplayCurrentBalance()
        {
            Console.WriteLine("Your current available balance is " + balance);
        }

        private static void Withdraw() //single responsibility
        {
            Console.WriteLine("Enter amount to withdraw. ");
            int withdrawAmount = Convert.ToInt16(GetUserInput());
            
            if(UpdateBalance(Operation.Withdraw, withdrawAmount))
            {
              Console.WriteLine("Successfully withdrawn a cash.");
            }
            else
            {
                Console.WriteLine("Encountered error.");
            }

            DisplayCurrentBalance();
        }

        private static void Deposit()
        {
            Console.WriteLine("Enter amount to deposit");
            int depositAmount = Convert.ToInt16(GetUserInput());
            UpdateBalance(Operation.Deposit, depositAmount);

            Console.WriteLine("Successfully added cash.");
            DisplayCurrentBalance();
        }

        private static bool UpdateBalance(Operation operation, int amount) //to update the balance
        {
            var result = false;
            switch (operation)
            {
                case Operation.Withdraw:
                    if (balance >= amount)
                    {
                        balance = balance - amount;
                        result = true;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance");
                        result = false;
                    }
                    break;
                case Operation.Deposit:
                    balance = balance + amount;
                    result = true;
                    break;
                default:
                    break;
            }

            return result;
        }

        private static bool UpdateBalance(Operation operation)
        {
            var result = false;
            switch (operation)
            {
                case Operation.Withdraw:
                    if (balance >= 1)
                    {
                        balance = balance - 1;
                        result = true;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance");
                        result = false;
                    }
                    break;
                case Operation.Deposit:
                    balance = balance + 500;
                    result = true;
                    break;
                default:
                    break;
            }

            return result;
        }

        private static bool UpdateBalance(int amount)
        {
            var result = false;

            if (balance >= amount)
            {
                balance = balance - amount;
                result = true;    
            }

            return result;
        }
    }

    enum Operation
    {
        Withdraw,
        Deposit
    }
}