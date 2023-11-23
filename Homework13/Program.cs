using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework13
{
    class Program
    {
        static Queue<Client> queue = new Queue<Client>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("1. Встать в очередь");
                Console.WriteLine("2. Обслужить следующего клиента");
                Console.WriteLine("3. Выйти из программы");

                int choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                        EnqueueClient();
                        break;
                    case 2:
                        ServeNextClient();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
                        break;
                }
            }
        }

        static int GetUserChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
            }
            return choice;
        }

        static void EnqueueClient()
        {
            Console.WriteLine("Введите ИИН клиента:");
            string id = Console.ReadLine();

            Console.WriteLine("Выберите тип обслуживания:");
            Console.WriteLine("1. Кредитование");
            Console.WriteLine("2. Открытие вклада");
            Console.WriteLine("3. Консультация");

            int serviceType = GetUserChoice();

            ServiceType type = ServiceType.Credit;

            switch (serviceType)
            {
                case 1:
                    type = ServiceType.Credit;
                    break;
                case 2:
                    type = ServiceType.Deposit;
                    break;
                case 3:
                    type = ServiceType.Consultation;
                    break;
                default:
                    break;
            }

            Client client = new Client(id, type);
            queue.Enqueue(client);

            Console.WriteLine($"Клиент {id} добавлен в очередь для {type}.");
            DisplayQueueStatus();
        }

        static void ServeNextClient()
        {
            if (queue.Count > 0)
            {
                Client client = queue.Dequeue();
                Console.WriteLine($"Обслужен клиент {client.Id} ({client.ServiceType}).");
                DisplayQueueStatus();
            }
            else
            {
                Console.WriteLine("Очередь пуста. Нет клиентов для обслуживания.");
            }
        }

        static void DisplayQueueStatus()
        {
            Console.WriteLine("Текущее состояние очереди:");
            foreach (var client in queue)
            {
                Console.WriteLine($"- Клиент {client.Id} ({client.ServiceType})");
            }
        }
    }

    enum ServiceType
    {
        Credit,
        Deposit,
        Consultation
    }

    class Client
    {
        public string Id { get; }
        public ServiceType ServiceType { get; }

        public Client(string id, ServiceType serviceType)
        {
            Id = id;
            ServiceType = serviceType;
        }
    }

}
