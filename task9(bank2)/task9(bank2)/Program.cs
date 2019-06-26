using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace task9_bank2_
{
    class Program
    {
        private static List<Card> card = new List<Card>();
        private static List<Client> client = new List<Client>();

        
        static void Main(string[] args)
        {
            bool flag = true;

            card.Add(new Card(3, "MTB", "visa", "1345578909876541", 100));
            card.Add(new Card(1, "BNB", "mastercard", "1345500009870009", 1500));
            card.Add(new Card(1, "Belarus", "visa", "1000000000000009", 120));
            client.Add(new Client(1, "akosko", "anton", "kosko"));


            Console.WriteLine("Menu:\n1) Show all clients;\n2) Show client by Index;\n3) Add a new Client;\n4) Add a new Card;\n7) Exit.");
            while (flag)
            {
                switch (Console.ReadLine())
                {
                    case "allclients":
                        SeeAllClients();
                        break;
                    case "client":
                        ClientByIndex();
                        break;
                    case "addclient":
                        Console.WriteLine("Enter comma separated - Client Index, Client Login, Client Name, Client Surname:");
                        string line = Console.ReadLine();
                        if (line != null)
                        {
                            string[] temp = line.Split(',');                                 // rework from massive 
                            int indexvalue = Convert.ToInt32(temp[0]);                       // add validation - unique index, unique login
                            AddClient(indexvalue, temp[1], temp[2], temp[3]);
                        }
                            break;
                    case "addcard":
                        Console.WriteLine("Enter comma separated - Client Index, Bank Name, Card Type, Card Number, Card Balance:");
                        string line1 = Console.ReadLine();
                        if (line1 != null)
                        {
                            string[] temp = line1.Split(',');
                            int indexvalue1 = Convert.ToInt32(temp[0]);
                            double balance = Convert.ToDouble(temp[4]);
                            AddCard(indexvalue1, temp[1], temp[2], temp[3], balance);
                        }
                        break;
                    case "exit":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect command. Try again.\n");
                        break;
                }

            }                                       
                                    
            Console.ReadKey();
        }

        private static void AddClient(int clientindex, string clientlogin, string personname, string personsurname)
        {            
            client.Add(new Client(clientindex, clientlogin, personname, personsurname));
            Console.WriteLine("The Client was successfully added\n");
        }

        private static void ClientByIndex()
        {
            Console.WriteLine("Enter Client Index:");
            int index = Convert.ToInt32(Console.ReadLine());
            foreach (Client clients in client)
            {
                if (index == clients.ClientIndex)
                {
                    Console.WriteLine("User info:");
                    Console.WriteLine("Login - {0}\nName - {1}\nSurname - {2}\n", clients.ClientLogin, clients.PersonName, clients.PersonSurname);

                    foreach (Card cards in card)
                    {
                        if (clients.ClientIndex == cards.ClientCardIndex)
                        {
                            Console.WriteLine("Card Index: {0}\nBank: {1}\nCard Type: {2}\nCard Number: {3}\n", cards.ClientCardIndex, cards.BName, cards.CardType, cards.CardNumber);
                        }
                    }
                }                
            }
        }

        private static void SeeAllClients()
        {
            foreach (Client clients in client)
            {
                Console.WriteLine("User info:");
                Console.WriteLine("Login - {0}\nName - {1}\nSurname - {2}\n", clients.ClientLogin, clients.PersonName, clients.PersonSurname);
            }
        }

        private static void AddCard (int clientcardindex, string bname, string cardtype, string cardnumber, double cardbalance)
        {
            card.Add(new Card(clientcardindex, bname, cardtype, cardnumber, cardbalance));
            Console.WriteLine("The Card was successfully added\n");
        }

    }
}
