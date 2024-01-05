/*The Proxy provides a surrogate or place holder to 
provide access to an object. A check or bank draft is 
a proxy for funds in an account. A check can be used in 
place of cash for making purchases and ultimately controls
access to cash in the issuer's account.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment_7
{
    interface IImage
    {
        void Display();
    }

    // RealImage class (the actual object)
    class RealImage : IImage
    {
        private string fileName;

        public RealImage(string fileName)
        {
            this.fileName = fileName;
            LoadFromDisk();
        }

        public void Display()
        {
            Console.WriteLine("Displaying " + fileName);
        }

        private void LoadFromDisk()
        {
            Console.WriteLine("Loading " + fileName + " from disk");
        }
    }

    // ProxyImage class (proxy for RealImage)
    class ProxyImage : IImage
    {
        private RealImage realImage;
        private string fileName;

        public ProxyImage(string fileName)
        {
            this.fileName = fileName;
        }

        public void Display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(fileName);
            }
            realImage.Display();
        }
    }

    interface IBankAccount
    {
        void WithdrawMoney(int amount);
    }

    // RealBankAccount class (the actual object)
    class RealBankAccount : IBankAccount
    {
        private int balance = 1000;

        public void WithdrawMoney(int amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn {amount} units. Remaining balance: {balance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }
    }

    // ProxyBankAccount class (proxy for RealBankAccount)
    class ProxyBankAccount : IBankAccount
    {
        private RealBankAccount realBankAccount;
        private bool isAdmin; // Assume true for admin access

        public ProxyBankAccount(bool isAdmin)
        {
            this.isAdmin = isAdmin;
        }

        public void WithdrawMoney(int amount)
        {
            if (realBankAccount == null)
            {
                realBankAccount = new RealBankAccount();
            }

            if (isAdmin)
            {
                realBankAccount.WithdrawMoney(amount);
            }
            else
            {
                Console.WriteLine("Access denied. You are not authorized to perform this operation.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------EXAMPLE 1---------------------------------");
            //Using ProxyImage to display an image
            IImage image = new ProxyImage("largeImage.jpg");

            // Image will be loaded only when Display is called
            image.Display();

            // The second time, the image will be loaded from memory
            image.Display();

            Console.WriteLine("---------------------------------EXAMPLE 2---------------------------------");
            IBankAccount bankAccount = new ProxyBankAccount(isAdmin: false);

            // Withdrawal attempt
            bankAccount.WithdrawMoney(500); // Access denied

            // Admin access
            IBankAccount adminBankAccount = new ProxyBankAccount(isAdmin: true);
            adminBankAccount.WithdrawMoney(500); // Withdrawn 500 units. Remaining balance: 500

        }
    }

}

