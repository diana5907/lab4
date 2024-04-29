using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();

        try
        {
            // Вводимо дані з клавіатури для кожного студента
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Введіть дані для студента №{i + 1}:");
                Console.Write("Прізвище: ");
                string lastName = Console.ReadLine();
                int[] marks = new int[5];
                string[] subjects = { "Web-дизайн", "Теорія. алгоритмві.", "Виш мат.", "Схемотехніка.", "Бази даних" };
                for (int j = 0; j < 5; j++)
                {
                    do
                    {
                        Console.Write($"Оцінка за предмет {subjects[j]}: ");
                        int mark = int.Parse(Console.ReadLine());
                        if (mark < 60 || mark > 100)
                        {
                            Console.WriteLine("Помилка: Оцінка повинна бути від 60 до 100.");
                        }
                        else
                        {
                            marks[j] = mark;
                        }
                    } while (marks[j] < 60 || marks[j] > 100); // Повторюємо ввід, якщо оцінка не відповідає вимогам
                }
                students.Add(new Student(lastName, marks));
            }

            // Верхній рядок таблиці
            Console.WriteLine("{0,-15} {1,10} {2,10} {3,10} {4,10} {5,10} {6,15}", "Прізвище", "Web-дизайн", "Теорія. алгоритмві.", "Виш мат.", "Схемотехніка.", "Бази даних", "Середній бал");
            Console.WriteLine(new string('-', 90));

            // Виводимо дані у таблицю
            foreach (var student in students)
            {
                Console.Write("{0,-15}", student.LastName);
                double totalMark = 0;
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("{0,10}", student.Marks[i]);
                    totalMark += student.Marks[i];
                }
                double averageMark = totalMark / 5;
                Console.WriteLine("{0,15:F2}", averageMark);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: Неправильний формат введених даних.");
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
        Console.ReadKey(); // Чекаємо, поки користувач натисне на будь-яку клавішу
    }
}

class Student
{
    public string LastName { get; set; }
    public int[] Marks { get; set; }

    public Student(string lastName, int[] marks)
    {
        if (marks.Length != 5)
        {
            throw new ArgumentException("Кількість оцінок повинна бути 5.");
        }

        foreach (var mark in marks)
        {
            if (mark < 60 || mark > 100)
            {
                throw new ArgumentException("Оцінки повинні бути від 60 до 100.");
            }
        }

        LastName = lastName;
        Marks = marks;
    }
}
