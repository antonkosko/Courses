using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9_bank2_
{
    class Card: Bank
    {
        private string cardnumber;
        private string cardtype;
        private int clientcardindex;
        private int cardindex;
        private double cardbalance;
        public double visatax = 0.35;
        public double mctax = 0.2;


        public bool IsDigitalOnly (string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }

        public string CardNumber
        {
            get
            {
                return cardnumber;
            }
            set
            {
                if (value.Length == 16 && IsDigitalOnly(value) == true)
                {
                    cardnumber = value;
                }
                else
                {
                    Console.WriteLine("Incorrect card number format was entered.");
                }
            }
        }

        public string CardType
        {
            get
            {
                return cardtype;
            }
            set
            {
                if (value == "visa" || value == "mastercard")
                {
                    cardtype = value;
                }
                else
                {
                    Console.WriteLine("Incorrect card type was entered.");
                }
            }
        }

        public int ClientCardIndex
        {
            get
            {
                return clientcardindex;
            }
            set
            {
                clientcardindex = value;
            }
        }

        public int CardIndex
        {
            get
            {
                return cardindex;
            }
            set
            {
                cardindex = value;
            }
        }

        public double CardBalance
        {
            get
            {
                return cardbalance;
            }
            set
            {
                if (value > 0)
                {
                    cardbalance = value;
                }
                else
                {
                    Console.WriteLine("Initial balance can not be minus");
                }
            }
        }

        public Card (int clientcardindex,int cardindex, string bname, string cardtype, string cardnumber, double cardbalance): base(bname)
        {
            this.CardType = cardtype;
            this.CardNumber = cardnumber;
            this.ClientCardIndex = clientcardindex;
            this.CardIndex = cardindex;
            this.CardBalance = cardbalance;
        }

        public void Getbalance()
        {
            if (cardtype == "visa")
            {
                if ((cardbalance - visatax) > 0)
                {
                    Console.WriteLine("Current balance is - " + (cardbalance - visatax));
                    Console.WriteLine("Tax value - " + visatax);
                    this.CardBalance = cardbalance - visatax;
                }
                else 
                {
                    Console.WriteLine("Not enough money to perform this operation.");
                }
                
            }

            if (CardType == "mastercard")
            {
                if ((cardbalance - mctax) > 0)
                {
                    Console.WriteLine("Current balance is - " + (cardbalance - mctax));
                    Console.WriteLine("Tax value - " + mctax);
                    this.CardBalance = cardbalance - mctax;
                }
                else
                {
                    Console.WriteLine("Not enough money to perform operation.");
                }
            }
        }

        public void Addmoney()
        {
            Console.WriteLine("Enter the amount of money you want to put on the card: ");
            double amount = Convert.ToDouble(Console.ReadLine());
            if(amount > 0)
            {
                this.CardBalance = cardbalance + amount;
                Console.WriteLine("The Money was successfully added.");
            }
            else
            {
                Console.WriteLine("Amount value can not be negative.");
            }
        }
        
        public void Takemoney()
        {
            Console.WriteLine("Enter the amount of money you want to take from the card: ");
            double amount = Convert.ToDouble(Console.ReadLine());
            if (amount > 0)
            {
                if (cardbalance - visatax - amount > 0)
                {
                    if (cardtype == "visa")
                    {                        
                        Console.WriteLine("You get - " + amount);
                        Console.WriteLine("Current balance is - " + (cardbalance - visatax - amount));
                        Console.WriteLine("Tax value - " + visatax);
                        this.CardBalance = cardbalance - visatax - amount;                            
                    }

                    if (CardType == "mastercard")
                    {
                        Console.WriteLine("You get - " + amount);
                        Console.WriteLine("Current balance is - " + (cardbalance - mctax - amount));
                        Console.WriteLine("Tax value - " + mctax);
                        this.CardBalance = cardbalance - mctax - amount;                       
                    }
                }
                else
                {
                    Console.WriteLine("Not enough money on the card balance.");
                }
            }
            else
            {
                Console.WriteLine("Amount value can not be negative.");
            }            
        }
    }
}
