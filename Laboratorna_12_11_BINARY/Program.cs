using System;

public class Car
{
    public string Number { get; set; }
}

public class CarTreeNode
{
    public Car Car { get; set; }
    public CarTreeNode Left { get; set; }
    public CarTreeNode Right { get; set; }
}

public class Garage
{
    private CarTreeNode root;

    public void AddCar(string number)
    {
        root = AddCarRecursive(root, new Car { Number = number });
        Console.WriteLine($"Автомобіль з номером {number} доданий на стоянку.");
    }

    private CarTreeNode AddCarRecursive(CarTreeNode node, Car car)
    {
        if (node == null)
        {
            return new CarTreeNode { Car = car };
        }

        if (car.Number.CompareTo(node.Car.Number) < 0)
        {
            node.Left = AddCarRecursive(node.Left, car);
        }
        else if (car.Number.CompareTo(node.Car.Number) > 0)
        {
            node.Right = AddCarRecursive(node.Right, car);
        }

        return node;
    }

    public void RemoveCar(string number)
    {
        root = RemoveCarRecursive(root, number);
    }

    private CarTreeNode RemoveCarRecursive(CarTreeNode node, string number)
    {
        if (node == null)
        {
            return null;
        }

        if (number.CompareTo(node.Car.Number) < 0)
        {
            node.Left = RemoveCarRecursive(node.Left, number);
        }
        else if (number.CompareTo(node.Car.Number) > 0)
        {
            node.Right = RemoveCarRecursive(node.Right, number);
        }
        else
        {
            if (node.Left == null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }

            node.Car = FindMin(node.Right).Car;
            node.Right = RemoveCarRecursive(node.Right, node.Car.Number);
        }

        return node;
    }

    private CarTreeNode FindMin(CarTreeNode node)
    {
        while (node.Left != null)
        {
            node = node.Left;
        }
        return node;
    }

    public void DisplayCars()
    {
        Console.WriteLine("Автомобілі на стоянці:");
        DisplayCarsRecursive(root);
    }

    private void DisplayCarsRecursive(CarTreeNode node)
    {
        if (node != null)
        {
            DisplayCarsRecursive(node.Left);
            Console.WriteLine($"Номер: {node.Car.Number}");
            DisplayCarsRecursive(node.Right);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Garage garage = new Garage();

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Додати автомобіль");
            Console.WriteLine("2. Видалити автомобіль");
            Console.WriteLine("3. Показати автомобілі на стоянці");
            Console.WriteLine("4. Вийти");

            Console.Write("Оберіть опцію: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введіть номер автомобіля: ");
                    string numberToAdd = Console.ReadLine();
                    garage.AddCar(numberToAdd);
                    break;
                case "2":
                    Console.Write("Введіть номер автомобіля для видалення: ");
                    string numberToRemove = Console.ReadLine();
                    garage.RemoveCar(numberToRemove);
                    break;
                case "3":
                    garage.DisplayCars();
                    break;
                case "4":
                    Console.WriteLine("Програма завершена.");
                    return;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
}
