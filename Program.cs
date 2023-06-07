using System;
using System.Collections.Generic;
using System.Linq;
using ElevatorSimulation.Class;
using ElevatorSimulation.Controller;

class Program
{
    static void Main(string[] args)
    {
        var elevatorController = new ElevatorController(10, 2, 10);

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Call elevator");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Status");
            Console.WriteLine("4. Exit");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Enter floor number and person weight (separated by a space):");
                    var inputs = Console.ReadLine().Split(' ');
                    int floor = int.Parse(inputs[0]);
                    int weight = int.Parse(inputs[1]);
                    var person = new Person(weight);
                    elevatorController.CallElevator(floor, person);
                    break;
                case "2":
                    elevatorController.Update();
                    break;
                case "3":
                    elevatorController.Status();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }

        Console.WriteLine("Program ended");
    }
}
