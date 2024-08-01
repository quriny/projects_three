using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_07_23Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComputerClub computerClub = new ComputerClub(8);
            computerClub.Work();

        }
    }
    class ComputerClub
    {
        private int money = 0;
        private List<Computer> computers = new List<Computer>();
        private Queue<Client> clients = new Queue<Client>();
        public ComputerClub(int computersCount)
        {
            Random random = new Random();
            for (int i = 0; i < computersCount; i++)
            {
                computers.Add(new Computer(random.Next(5, 15)));
            }
            CreateNewClients(25, random);
        }
        public void CreateNewClients(int count, Random random)
        {
            for (int i = 0; i < count; i++)
            {
                clients.Enqueue(new Client(random.Next(100, 251), random));
            }
        }
        public void Work()
        {
            while (clients.Count > 0)
            {
                Client newClient = clients.Dequeue();
                Console.WriteLine($"Баланс компьютерного клуба {money} рублей. Ждем нового клиента.");
                Console.WriteLine($"У вас новый клиент, и он хочет купить {newClient.DesiredMinutes} минут.");
                ShowAllComputersState();
                Console.Write("\nВы предлагаете ему компьютер под номером: ");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int computerNumber))
                {
                    computerNumber--;
                    if (computerNumber >= 0 && computerNumber < computers.Count)
                    {
                        if (computers[computerNumber].IsTaken)
                        {
                            Console.WriteLine("Вы пытаетесь посадить клиента за компьютер, который уже занят. Клиент разозлился и ушел.");
                        }
                        else
                        {
                            if (newClient.CheckSolvency(computers[computerNumber]))
                            {
                                Console.WriteLine("Клиент оплатил компьютер и сел за номер " + computerNumber + 1);
                                money += newClient.Pay();
                                computers[computerNumber].BecomeTaken(newClient);
                            }
                            else
                            {
                                Console.WriteLine("У клиента не хватило денег и он ушел.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Вы сами не знаете за какой компьютер посадить клиента. Он разозлился и ушел.");
                    }
                }
                else
                {
                    CreateNewClients(1, new Random());
                    Console.WriteLine("Неверный ввод! Повторите снова.");
                }
                Console.WriteLine("Чтобы перейти к следующему клиенту, нажмите любую клавишу.");
                Console.ReadKey();
                Console.Clear();
                SpendOneMinute();
            }

        }
        private void ShowAllComputersState()
        {
            Console.WriteLine("Список всех компьютеров: ");
            for (int i = 0; i < computers.Count; i++)
            {
                Console.Write(i + 1 + " - ");
                computers[i].ShowState();
            }
        }
        private void SpendOneMinute()
        {
            foreach (var computer in computers)
            {
                computer.SpendOneMinute();
            }
        }

    }
    class Computer
    {
        private Client client;
        private int minutesRemaining;
        public bool IsTaken
        {
            get
            {
                return minutesRemaining > 0;
            }
        }
        public int PricePerMinute { get; private set; }
        public Computer(int pricePerMinutes)
        {
            PricePerMinute = pricePerMinutes;
        }
        public void BecomeTaken(Client client)
        {
            this.client = client;
            minutesRemaining = client.DesiredMinutes;
        }
        public void BecomeEmpty()
        {
            client = null;
        }
        public void SpendOneMinute()
        {
            minutesRemaining--;
        }
        public void ShowState()
        {
            if (IsTaken)
            {
                Console.WriteLine($"Компьютер занят, осталось минут: {minutesRemaining}");
            }
            else
            {
                Console.WriteLine($"Компьютер свободен, цена за минуту: {PricePerMinute}");
            }
        }
    }
    class Client
    {
        private int money;
        private int moneyToPay;
        public int DesiredMinutes { get; private set; }

        public Client(int money, Random random)
        {
            this.money = money;
            DesiredMinutes = random.Next(10, 30);
        }
        public bool CheckSolvency(Computer computer)
        {
            moneyToPay = DesiredMinutes * computer.PricePerMinute;
            if (money >= moneyToPay)
            {
                return true;
            }
            else
            {
                moneyToPay = 0;
                return false;
            }
        }
        public int Pay()
        {
            money -= moneyToPay;
            return moneyToPay;
        }
    }
}
