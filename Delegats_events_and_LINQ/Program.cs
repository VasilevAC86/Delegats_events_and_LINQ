using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Delegats_events_and_LINQ
{
    internal class Program
    {
        // Делегаты, события, анонимные методы, люмбды и LINQ

        // Делегат - ссылка на метод, имеют параметры и возвращают значения
        // Делегат - это шаблон для методов внутри его (шаблон, указывающий как работает event-событие)
        // Может быть объявлен только внутри класса
        // Делегаты - это основа для событий, лямбд
        // Событие - это механизм, позволяющий объекту уведомлять другие объекты о каких-либо действиях
        // Событие - это массив ссылок на методы

        public static void HandleMes(string msg) { Console.WriteLine(msg); }
        public delegate void MyDelegate(string msg); // Создание делегата
        /*public event MyDelegate onMsg; // Создание события (event)
        
        public static void ShowMsg(string msg) { Console.WriteLine(msg); }*/
        static void Main()
        {
            /*   MyDelegate del = new MyDelegate(Program.ShowMsg);            
               del("Hello from Delegate");*/
            /*N n = new N();
            n.TakeMsg("fafdsa");*/
            //n.onMsg += HandleMes("ddd");

            // Анонимные методы -это делегаты без названия, исп. для создания делегатов "на месте"
            /*MyDelegate del = delegate (string msg) { Console.WriteLine(msg); };
            del("Hello from Delegate");*/ // Анонимный метод

            // Лямбды - то же самое, что в С++
            /*MyDelegate del = msg => { Console.WriteLine(msg); }; // Скобки убираем, если у нас один аргумент
            del("Hello from Delegate");*/

            // LINQ - специальный язык запросов в С# Есть много методов использования: для баз данных,
            // для работы с коллекциями, для работы с объектами (например, выбор студентов-отличников из общего списка)
            // работает с массивами, под капотом те же циклы, только синтаксис гораздо проще
            /*List<Person> list = new List<Person>();
            var result = from x in list // Query syntax, как в foreache
                         select x.Name; // Вытаскиваем все имена в новый список result, select - оператов возврата
            var result2 = from x in list
                          where x.Age > 18 // операто where, как условие
                          select x; // Новый cписок в result2 из Person, которым больше 18
            var result3 = from x in list
                          group x by x.Name; // Сортировка по алфавитному порядку списка list
            // LINQ с лямбдами
            var result4 = list.Where(x => x.Age > 18).ToList(); // В result4 будут все Person, кто старше 18
            var result5 = list.Select(x => x.Age * 2).ToList()*/; // В result5 будут все Person, с возратом, умноженным на 2
                                                                  // OrderBy - метод для сортировки по возрастанию
                                                                  // OrderByDescending - метод для сортировки по убыванию
                                                                  // GroupBy - метод для группировки/сортировки по определённому ключу
                                                                  // Distinct - удаляет повторения, удаляет дублирующиеся элементы из последовательности данных
                                                                  // Reverse - Разворачивает порядок элементов в последовательности
                                                                  // First / FirstOrDefault: возвращает первый элемент из последовательности. First выброст исключение, если
                                                                  // последовательность пуста, а FirstOrDefault вернёт значение по умолчанию
            /*List<Student> students = new List<Student>() // Массив студентов
            {
                new Student { Name = "Alice", Grades = new List<int> { 5, 3, 4 } },
                new Student { Name = "Bob", Grades = new List<int> { 3, 3, 2 } },
                new Student { Name = "Alice", Grades = new List<int> { 4, 3, 4 } },
            };
            var sortedList = students.OrderByDescending(student => student.Grades.Average());
            Console.WriteLine("Отсортированный список:");
            foreach (var student in sortedList)
                Console.WriteLine($"{student.Name}:{student.Grades.Average()}");*/

            List<Order> orders = new List<Order>
            {
                new Order {Num = 1, Customer = "Вася", Products = new List<OrderProduct>
                {
                    new OrderProduct {ProductName = "Хлеб", Price = 30},
                    new OrderProduct {ProductName = "Пиво", Price = 70},
                    new OrderProduct {ProductName = "Рыба", Price = 130}
                }
                },
                new Order {Num = 2, Customer = "Петя", Products = new List<OrderProduct>
                {
                    new OrderProduct {ProductName = "Яблоки", Price = 90},
                    new OrderProduct {ProductName = "Консерва", Price = 270},
                    new OrderProduct {ProductName = "Рыба", Price = 200}
                }
                }
            };
            Console.Write("Общая сумма по всем заказам = ");
            var orderTotalSum = orders.Select(o => new {TotalSum = o.Products.Sum(p => p.Price)});
            int sum = 0;
            foreach (var el in orderTotalSum)
                sum += el.TotalSum;
            Console.WriteLine(sum);
            Console.Write("\nОбщая сумма по заказу " + orders[0].Num + " = ");
            var order_1 = orders[0].Products.Select(el => new {Sum_1 = el.Price});
            int sum_1 = 0;
            foreach (var el in order_1)
                sum_1 += el.Sum_1;
            Console.WriteLine(sum_1);
            Console.Write("\nОбщая сумма по заказу " + orders[1].Num + " = ");
            var order_2 = orders[1].Products.Select(el => new { Sum_2 = el.Price });
            int sum_2 = 0;
            foreach (var el in order_2)
                sum_2 += el.Sum_2;
            Console.WriteLine(sum_2);
            Console.WriteLine("\nСписок повторяющихся товаров:");
            var result_1 = orders.SelectMany(o => o.Products)
                .GroupBy(p => p.ProductName) // Группируем продукты
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();
            foreach (var el in result_1)
                Console.WriteLine(el);
            // Клиент, который потратил наибольшую сумму
                            
            Console.WriteLine($"\nКлиент, потративший наибольшую сумму = ");
        }
       
            public class N
            {
                public delegate void MyDelegate(string msg); // Создание делегата
                public event MyDelegate onMsg; // Создание события (event)            
                public void TakeMsg(string msg)
                {
                    onMsg.Invoke(msg); // Метод вызывает делегат onMsg
                }
            }
        }
    }
