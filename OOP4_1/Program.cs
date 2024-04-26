using System;
//ЗАВДАННЯ 1
// Інтерфейс, який ми будемо реалізовувати в класі Animal
interface IAnimal
{
    void MakeSound(); // Метод для видачі звуку тварини
}

namespace OOP3333
{
    class Program
    {
        static void Main(string[] args)
        {
            // Створення масиву об'єктів тварин
            Animal[] animals = new Animal[]
            {
                new Wolf(30.5, 5, 20.0, "Сірий вовк", "Ліси"),
                new Bear(200.0, 10, 50.0, "Коричневий", "Всеїдний"),
                new Giraffe(800.0, 7, 100.0, 180, true),
                new Panda(150.0, 6, 80.0, "Бамбукові ліси", true)
            };

            // Виведення початкового масиву на екран
            Console.WriteLine("Початковий масив:");
            DisplayAnimals(animals);
            //ЗАВДАННЯ 3
            // Клонування першої половини масиву тварин та заміна другою половиною
            for (int i = 0; i < animals.Length / 2; i++)
            {
                animals[i + animals.Length / 2] = (Animal)animals[i].Clone();
            }

            // Виведення масиву після клонування на екран
            Console.WriteLine("\nМасив після клонування:");
            DisplayAnimals(animals);
            //ЗАВДАННЯ 4
            // Сортування масиву
            Array.Sort(animals);

            // Виведення масиву після сортування на екран
            Console.WriteLine("\nМасив після сортування:");
            DisplayAnimals(animals);

            Console.ReadLine(); // Пауза консолі перед виходом
        }

        static void DisplayAnimals(Animal[] animals)
        {
            // Виведення інформації про всіх тварин у масиві
            foreach (var animal in animals)
            {
                animal.DisplayInfo();
            }
        }
    }

    // Базовий клас Animal
    abstract class Animal : IComparable, ICloneable, IAnimal
    {
        public double Weight { get; }
        public int Age { get; }
        public double DailyMaintenanceCost { get; }

        public Animal(double weight, int age, double dailyMaintenanceCost)
        {
            Weight = weight;
            Age = age;
            DailyMaintenanceCost = dailyMaintenanceCost;
        }

        public abstract void DisplayInfo();

        // Індексатор для доступу до полів за назвою
        public object this[string propertyName]
        {
            get
            {
                var prop = GetType().GetProperty(propertyName);
                if (prop != null)
                {
                    var value = prop.GetValue(this, null);
                    if (value != null)
                    {
                        return value;
                    }
                }
                throw new ArgumentException($"Властивість '{propertyName}' не знайдена або має значення null");
            }
        }
        //2 ЗАВДАННЯ
        // Реалізація інтерфейсу IComparable
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Animal otherAnimal = obj as Animal;
            if (otherAnimal != null)
                return this.Weight.CompareTo(otherAnimal.Weight);
            else
                throw new ArgumentException("Об'єкт не є Animal");
        }

        // Реалізація інтерфейсу ICloneable
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        // Реалізація інтерфейсу IAnimal
        public virtual void MakeSound()
        {
            // Реалізація в залежності від типу тварини
        }
    }

    // Похідний клас Wolf
    class Wolf : Animal
    {
        public string Breed { get; }
        public string NaturalHabitat { get; }

        public Wolf(double weight, int age, double dailyMaintenanceCost, string breed, string naturalHabitat)
            : base(weight, age, dailyMaintenanceCost)
        {
            Breed = breed;
            NaturalHabitat = naturalHabitat;
        }

        // Перевизначений метод виводу інформації про вовка
        public override void DisplayInfo()
        {
            Console.WriteLine($"Вовк:\nВага: {this["Weight"]}\nВік: {Age}\nЩоденна вартість утримання: {DailyMaintenanceCost}\nПорода: {Breed}\nПриродне середовище: {NaturalHabitat}");
        }

        // Перевизначення методу MakeSound для вовка
        public override void MakeSound()
        {
            Console.WriteLine("Вовк видає вививив...");
        }
    }

    // Похідний клас Bear
    class Bear : Animal
    {
        public string FurColor { get; }
        public string Diet { get; }

        public Bear(double weight, int age, double dailyMaintenanceCost, string furColor, string diet)
            : base(weight, age, dailyMaintenanceCost)
        {
            FurColor = furColor;
            Diet = diet;
        }

        // Перевизначений метод виводу інформації про ведмедя
        public override void DisplayInfo()
        {
            Console.WriteLine($"Ведмідь:\nВага: {Weight}\nВік: {Age}\nЩоденна вартість утримання: {DailyMaintenanceCost}\nКолір шерсті: {FurColor}\nХарчування: {Diet}");
        }

        // Перевизначення методу MakeSound для ведмедя
        public override void MakeSound()
        {
            Console.WriteLine("Ведмідь видає громіздкий рев...");
        }
    }

    // Похідний клас Giraffe
    class Giraffe : Animal
    {
        public int NeckLength { get; }
        public bool SpottedPattern { get; }

        public Giraffe(double weight, int age, double dailyMaintenanceCost, int neckLength, bool spottedPattern)
            : base(weight, age, dailyMaintenanceCost)
        {
            NeckLength = neckLength;
            SpottedPattern = spottedPattern;
        }

        // Перевизначений метод виводу інформації про жирафу
        public override void DisplayInfo()
        {
            Console.WriteLine($"Жираф:\nВага: {Weight}\nВік: {Age}\nЩоденна вартість утримання: {DailyMaintenanceCost}\nДовжина шиї: {NeckLength}\nСпотований малюнок: {(SpottedPattern ? "Так" : "Ні")}");
        }

        // Перевизначення методу MakeSound для жирафи
        public override void MakeSound()
        {
            Console.WriteLine("Жираф видає характерний звук...");
        }
    }

    // Похідний клас Panda
    class Panda : Animal
    {
        public string Habitat { get; }
        public bool Endangered { get; }

        public Panda(double weight, int age, double dailyMaintenanceCost, string habitat, bool endangered)
            : base(weight, age, dailyMaintenanceCost)
        {
            Habitat = habitat;
            Endangered = endangered;
        }

        // Перевизначений метод виводу інформації про панду
        public override void DisplayInfo()
        {
            Console.WriteLine($"Панда:\nВага: {Weight}\nВік: {Age}\nЩоденна вартість утримання: {DailyMaintenanceCost}\nСередовище існування: {Habitat}\nЗагроза вимирання: {(Endangered ? "Так" : "Ні")}");
        }

        // Перевизначення методу MakeSound для панди
        public override void MakeSound()
        {
            Console.WriteLine("Панда видає хрумкий звук...");
        }
    }
}
