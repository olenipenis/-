using System;

namespace AbiturientApp
{
    class Abiturient(string fullName, string schoolClass)
    {
        private string fullName = fullName;
        private string schoolClass = schoolClass;
        private double averageGPA;

        public Abiturient(string fullName, string schoolClass, double averageScore) : this(fullName, schoolClass)
        {
            AverageScore = averageScore; 
        }

        public string FullName
        {
            get => fullName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length >= 2)
                    fullName = value;
                else
                    Console.WriteLine("[Ошибка]: Длина ФИО должна быть не менее 2 символов.");
            }
        }

        public string SchoolClass
        {
            get => schoolClass;
            set => schoolClass = value;
        }

        public double AverageScore
        {
            get => averageGPA;
            set
            {
                if (value >= 0)
                    averageGPA = value;
                else
                    Console.WriteLine("[Ошибка]: Средний балл не может быть отрицательным.");
            }
        }

        public bool IsEleventhGrade => schoolClass.StartsWith("11");

        public void DisplayInfo()
        {
            Console.WriteLine($"Абитуриент: {FullName,-15} | Класс: {SchoolClass,-4} | Средний балл: {AverageScore:F1}");
        }

        public bool IsScoreHigherThan(double threshold)
        {
            return averageGPA > threshold;
        }
    }

    class Program
    {
        static void Main()
        {
            Abiturient testStudent = new Abiturient("Иван", "11А", 4.5);

            Console.WriteLine("Исходные данные:");
            testStudent.DisplayInfo();

            Console.WriteLine("\nПробуем установить ФИО = 'А' и балл = -5.0...");
            testStudent.FullName = "А";        
            testStudent.AverageScore = -5.0;   

            Console.WriteLine("Данные после попытки некорректного изменения (должны остаться прежними):");
            testStudent.DisplayInfo();

            Abiturient[] applicants =
            [
                new Abiturient("Петров А.В.", "11Б", 4.8),
                new Abiturient("Сидоров С.С.", "10А", 3.5),
                new Abiturient("Кузнецова М.Д.", "11А", 4.2),
                new Abiturient("Павлов И.К.", "9В", 5.0),
                new Abiturient("Лебедева О.Н.", "11Б", 3.9)
            ];

            Console.Write("Введите минимальный средний балл для поиска: ");
            if (double.TryParse(Console.ReadLine(), out double userThreshold))
            {
                
                Console.WriteLine($"\nАбитуриенты с баллом выше {userThreshold}:");
                bool foundByScore = false;
                foreach (var app in applicants)
                {
                    if (app.IsScoreHigherThan(userThreshold))
                    {
                        app.DisplayInfo();
                        foundByScore = true;
                    }
                }
                if (!foundByScore) Console.WriteLine("Совпадений не найдено.");
            }

            Console.WriteLine("\nАбитуриенты, закончившие 11 класс:");
            bool foundByGrade = false;
            foreach (var app in applicants)
            {
                if (app.IsEleventhGrade)
                {
                    app.DisplayInfo();
                    foundByGrade = true;
                }
            }
            if (!foundByGrade) Console.WriteLine("Абитуриенты 11-х классов не найдены.");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
