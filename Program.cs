using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L36_advancedPersonnelAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CommandAddDossier = 1;
            const int CommandDisplayAllDossier = 2;
            const int CommandDeleteDossier = 3;
            const int CommandExit = 4;

            List<string> persons = new List<string>();
            List<string> jobTitles = new List<string>();

            char delimiter = '-';

            int numberMenu;

            bool isOpen = true;

            while (isOpen)
            {
                Console.Clear();
                Console.WriteLine("Реестр компании \"Рога и копыта\"");
                Console.WriteLine($"{CommandAddDossier}) Добавить досье.\n{CommandDisplayAllDossier}) Вывести все досье." +
                                  $"\n{CommandDeleteDossier}) Удалить досье.\n{CommandExit}) Выход.\n");

                Console.Write("Выбирите номер меню: ");
                numberMenu = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (numberMenu)
                {
                    case CommandAddDossier:
                        AddDossier(persons, jobTitles);
                        continue;

                    case CommandDisplayAllDossier:
                        FormatOutput(persons, jobTitles, delimiter);
                        break;

                    case CommandDeleteDossier:
                        DeleteDossier(persons, jobTitles);
                        break;

                    case CommandExit:
                        isOpen = false;
                        continue;

                    default:
                        Console.WriteLine("Введена неизвестная команда.");
                        break;
                }

                Console.WriteLine("\nДля возврата в меню, нажмите любую клавишу.");
                Console.ReadKey();
            }
        }

        private static void DeleteDossier(List<string> persons, List<string> jobTitles)
        {
            int indexOfPerson;
            Console.Write("Введите номер досье, для его удаления: ");

            if (int.TryParse(Console.ReadLine(), out indexOfPerson))
            {
                indexOfPerson--;

                if (indexOfPerson < persons.Count && indexOfPerson > -1)
                {
                    persons.RemoveAt(indexOfPerson);
                    jobTitles.RemoveAt(indexOfPerson);
                }
                else
                {
                    Console.WriteLine($"Досье под номером {indexOfPerson}, нет в базе данных.");
                }
            }
        }

        private static void AddDossier(List<string> persons, List<string> jobTitles)
        {
            Console.Write("Введите полностью Фамилию Имя Отчество: ");
            persons.Add(Console.ReadLine());

            Console.Write("Введите наименование должности: ");
            jobTitles.Add(Console.ReadLine());
        }

        static void FormatOutput(List<string> persons, List<string> jobTitles, char delimiter)
        {
            string[] tempLines;

            Console.Clear();

            for (int i = 0; i < persons.Count; i++)
            {
                tempLines = persons[i].Split();
                Console.Write(i + 1);

                foreach (string line in tempLines)
                    Console.Write(delimiter + line);

                Console.WriteLine(delimiter + jobTitles[i]);
            }
        }
    }
}
