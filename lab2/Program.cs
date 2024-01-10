 /* Вариант 7. Музыкальный каталог
  
 При запуске программы пользователю предлагается справочная информация по использованию.
 Далее предлагается ввести команду, позволяющую выполнить одно из действий:
 - осуществить поиск музыкальной композиции в каталоге по определенному критерию
 - вывести информацию обо всех существующих в каталоге композициях
 - добавить информацию о композиции в каталог
 - удалить существующую в каталоге запись
 - выйти из программы
 Критериями поиска могут служить: 
 - имя (название) автора/исполнителя или название композиции.
 В качестве результата поиска в консоль должен выводиться список композиций в виде
 «исполнитель – название». Удаление или добавление записи осуществляется после
 ввода всей информации о композиции */

namespace lab2
{
    using System;
    using System.Collections.Generic;

    /* создание класса музыкального каталога с методами, отвечающими соответствующим командам */
    class MusicCatalog
    {
        static List<MusicComposition> catalog = new List<MusicComposition>();
        
        static void Main()
        {
            Console.WriteLine("Добро пожаловать в Музыкальный каталог!");
            Console.WriteLine("Используйте команды: search, list, add, delete, exit");

            /* ввод и проверка введенной команды */
            while (true)
            {
                Console.Write("Введите команду: ");
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "search":
                        SearchComposition();
                        break;
                    case "list":
                        ListAllCompositions();
                        break;
                    case "add":
                        AddComposition();
                        break;
                    case "delete":
                        DeleteComposition();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неверная команда. Пожалуйста, введите корректную команду.");
                        break;
                }
            }
        }

        /* метод для команды поиска, выводящий композции по одному из двух критериев */
        static void SearchComposition()
        {
            Console.Write("Введите критерий поиска (имя исполнителя/название композиции): ");
            string searchCriteria = Console.ReadLine().ToLower();

            var searchResults = catalog.FindAll(comp =>
                comp.Artist.ToLower().Contains(searchCriteria) ||
                comp.Title.ToLower().Contains(searchCriteria)
            );

            Console.WriteLine("Результаты поиска:");
            foreach (var result in searchResults)
            {
                Console.WriteLine($"{result.Artist} - {result.Title}");
            }
        }

        /* метод, выводящий в консоль все композиции каталога, если они есть */
        static void ListAllCompositions()
        {
            if (catalog.Count > 0)
            {
                Console.WriteLine("Все композиции в каталоге:");
                foreach (var composition in catalog)
                {
                    Console.WriteLine($"{composition.Artist} - {composition.Title}");
                }
            }
            else
            {
                Console.WriteLine("Пока что в каталоге пусто :(... Но это всегда можно исправить, добавив композиции с помощью команды add!");
            }
        }

        /* метод для добавления новой композиции в каталог */
        static void AddComposition()
        {
            Console.Write("Введите имя исполнителя: ");
            string artist = Console.ReadLine();

            Console.Write("Введите название композиции: ");
            string title = Console.ReadLine();

            catalog.Add(new MusicComposition(artist, title));
            Console.WriteLine("Композиция добавлена в каталог.");
        }

        /* метод для удаления композиций из каталога, удаляет композицию по артисту и названию */
        static void DeleteComposition()
        {
            Console.Write("Введите имя исполнителя: ");
            string artist = Console.ReadLine().ToLower();

            Console.Write("Введите название композиции: ");
            string title = Console.ReadLine().ToLower();

            var compositionToDelete = catalog.Find(comp =>
                comp.Artist.ToLower() == artist && comp.Title.ToLower() == title
            );

            if (compositionToDelete != null)
            {
                catalog.Remove(compositionToDelete);
                Console.WriteLine("Композиция удалена из каталога.");
            }
            else
            {
                Console.WriteLine("Композиция не найдена в каталоге.");
            }
        }
    }

    /* класс музыкальной композиции, хранящий в себе имя исполнителя и название композиции */
    class MusicComposition
    {
        public string Artist { get; set; }
        public string Title { get; set; }

        public MusicComposition(string artist, string title)
        {
            Artist = artist;
            Title = title;
        }
    }
}