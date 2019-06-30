using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace task9_bank2_
{
    class Program
    {
        private static List<Card> card = new List<Card>();
        private static List<Client> client = new List<Client>();
        
        static void Main(string[] args)
        {
            bool flag = true;

            //card.Add(new Card(2, 1, "MTB", "visa", "1345578909876541", 100));
            //card.Add(new Card(1, 2, "BNB", "mastercard", "1345500009870009", 1500));
            //card.Add(new Card(1, 3, "Belarus", "visa", "1000000000000009", 1));
            //client.Add(new Client(1, "akosko", "anton", "kosko"));
            //client.Add(new Client(2, "akosko2", "anton2", "kosko2"));

            string path_bank = @"C:\Users\ПК Мастер\Desktop\bank.txt";
            using (StreamReader sr = new StreamReader(path_bank, System.Text.Encoding.Default))  // using позволяет создавать объект в блоке кода
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] temp = line.Split(',');
                    int indexvalue = Convert.ToInt32(temp[0]);
                    AddClient(indexvalue, temp[1], temp[2], temp[3]);
                }
            }

            string path_cards = @"C:\Users\ПК Мастер\Desktop\cards.txt";
            using (StreamReader sr = new StreamReader(path_cards, System.Text.Encoding.Default))  
            {
                string line1;
                while ((line1 = sr.ReadLine()) != null)
                {
                    string[] temp = line1.Split(',');
                    int indexclient1 = Convert.ToInt32(temp[0]);
                    int indexcard1 = Convert.ToInt32(temp[1]);
                    double balance = Convert.ToDouble(temp[5]);
                    AddCard(indexclient1, indexcard1, temp[2], temp[3], temp[4], balance);
                }
            }
            
            Console.WriteLine("Menu:\n1) Show all clients;\n2) Show client by Index;\n3) Add a new Client;\n4) Add a new Card;\n5) Delete card;\n6) Delete client;\n7) Show card balance;\n8) Add Money to the Card;\n9) Take money from the card;\n0) Exit.");
            while (flag)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        SeeAllClients();
                        break;
                    case "2":
                        ClientByIndex();
                        break;
                    case "3":
                        Console.WriteLine("Enter comma separated - Client Index, Client Login, Client Name, Client Surname:");
                        string line = Console.ReadLine();
                        if (line != null)
                        {
                            string[] temp = line.Split(',');                                 // rework from massive 
                            int indexvalue = Convert.ToInt32(temp[0]);                       // add validation - unique index, unique login
                            AddClient(indexvalue, temp[1], temp[2], temp[3]);
                            Console.WriteLine("The Client was successfully added\n");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Enter comma separated - Client Index, Bank Name, Card Type, Card Number, Card Balance:");
                        string line1 = Console.ReadLine();
                        if (line1 != null)
                        {
                            string[] temp = line1.Split(',');
                            int indexclient1 = Convert.ToInt32(temp[0]);
                            int indexcard1 = Convert.ToInt32(temp[1]);
                            double balance = Convert.ToDouble(temp[5]);
                            AddCard(indexclient1, indexcard1, temp[2], temp[3], temp[4], balance);
                            Console.WriteLine("The Card was successfully added\n");
                        }
                        break;
                    case "5":
                        DeleteCard();
                        break;
                    case "6":
                        DeleteClient();
                        break;
                    case "7":
                        CardBalance();
                        break;
                    case "8":
                        AddMoney();
                        break;
                    case "9":
                        TakeMoney();
                        break;
                    case "0":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect command. Try again.\n");
                        break;
                }

            }

            using (StreamWriter sw = new StreamWriter(path_bank, false, System.Text.Encoding.Default))
            {
                foreach (Client clients in client)
                {
                    sw.WriteLine(clients);
                }
            }

            using (StreamWriter sw = new StreamWriter(path_cards, false, System.Text.Encoding.Default))
            {
                foreach (Card cards in card)
                {
                    sw.WriteLine(cards.CardIndex, cards.BName, cards.CardType, cards.CardNumber);
                }
            }

            Console.ReadKey();
        }

        private static void AddClient(int clientindex, string clientlogin, string personname, string personsurname)
        {            
            client.Add(new Client(clientindex, clientlogin, personname, personsurname));
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
                    Console.WriteLine("Client Index - {0}\nLogin - {1}\nName - {2}\nSurname - {3}\n", clients.ClientIndex, clients.ClientLogin, clients.PersonName, clients.PersonSurname);

                    foreach (Card cards in card)
                    {
                        if (clients.ClientIndex == cards.ClientCardIndex)
                        {
                            Console.WriteLine("Card Index: {0}\nBank: {1}\nCard Type: {2}\nCard Number: {3}\n", cards.CardIndex, cards.BName, cards.CardType, cards.CardNumber);
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
                Console.WriteLine("Client Index - {0}\nLogin - {1}\nName - {2}\nSurname - {3}\n", clients.ClientIndex, clients.ClientLogin, clients.PersonName, clients.PersonSurname);
            }
        }

        private static void AddCard (int clientcardindex,int cardindex, string bname, string cardtype, string cardnumber, double cardbalance)
        {
            card.Add(new Card(clientcardindex, cardindex, bname, cardtype, cardnumber, cardbalance));
        }

        private static void DeleteCard()
        {
            int id1, id2 = 0;
            Console.WriteLine("Enter card id which you want to delete: ");
            id1 = Convert.ToInt32(Console.ReadLine());

            foreach (Card cards in card.ToArray())
            {
                if (cards.CardIndex == id1)
                {
                    card.Remove(cards);
                    id2 = id1;
                    Console.WriteLine("Card successfully deleted.");
                    break;
                }
            }

            if (id2 == 0)
            {
                Console.WriteLine("\nThere is no such Card.\n");
            }
        }

        private static void DeleteClient() 
        {
            int index1 = 0;
            Console.WriteLine("Enter client id which you want to delete: ");
            int index = Convert.ToInt32(Console.ReadLine());
            foreach (Client clients in client)
            {
                if (index == clients.ClientIndex)
                {
                    client.Remove(clients);
                    foreach (Card cards in card.ToArray())
                    {
                        if (index == cards.ClientCardIndex)
                        {
                            card.Remove(cards);
                        }
                    }
                    index1 = index;
                    Console.WriteLine("Client successfully deleted.");
                    break;
                }
            }

            if (index1 == 0)
            {
                Console.WriteLine("\nThere is no such Client.\n");
            }
        }

        private static void CardBalance()
        {
            int id1, id2 = 0;
            Console.WriteLine("Enter card id: ");
            id1 = Convert.ToInt32(Console.ReadLine());

            foreach (Card cards in card.ToArray())
            {
                if (cards.CardIndex == id1)
                {
                    cards.Getbalance();
                    id2 = id1;
                    break;
                }
            }

            if (id2 == 0)
            {
                Console.WriteLine("\nThere is no such Card.\n");
            }
        }

        private static void AddMoney()
        {
            int id1, id2 = 0;
            Console.WriteLine("Enter card id: ");
            id1 = Convert.ToInt32(Console.ReadLine());

            foreach (Card cards in card.ToArray())
            {
                if (cards.CardIndex == id1)
                {
                    cards.Addmoney();
                    id2 = id1;
                    break;
                }
            }

            if (id2 == 0)
            {
                Console.WriteLine("\nThere is no such Card.\n");
            }
        }

        private static void TakeMoney()
        {
            int id1, id2 = 0;
            Console.WriteLine("Enter card id: ");
            id1 = Convert.ToInt32(Console.ReadLine());

            foreach (Card cards in card.ToArray())
            {
                if (cards.CardIndex == id1)
                {
                    cards.Takemoney();
                    id2 = id1;
                    break;
                }
            }

            if (id2 == 0)
            {
                Console.WriteLine("\nThere is no such Card.\n");
            }
        }
    }
}
