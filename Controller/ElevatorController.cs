using ElevatorSimulation.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Controller
{
    public class ElevatorController
    {
            public List<Elevator> Elevators { get; set; }
            public int NumberOfFloors { get; set; }

            public ElevatorController(int numberOfFloors, int numberOfElevators, int elevatorCapacity)
            {
                NumberOfFloors = numberOfFloors;
                Elevators = Enumerable.Range(0, numberOfElevators).Select(x => new Elevator(elevatorCapacity)).ToList();
            }

            public void CallElevator(int floor, Person person)
            {
                var availableElevators = Elevators.Where(elevator => !elevator.IsFull()).ToList();
                if (availableElevators.Count == 0)
                {
                    Console.WriteLine("All elevators are full");
                    return;
                }

                var nearestElevator = availableElevators.OrderBy(elevator => Math.Abs(elevator.CurrentFloor - floor)).First();
                nearestElevator.TargetFloor = floor;

                if (nearestElevator.Enter(person))
                {
                    Console.WriteLine($"Person with weight {person.Weight} entered the elevator");
                }
                else
                {
                    Console.WriteLine("The elevator is full");
                }
            }

            public void Update()
            {
                foreach (var elevator in Elevators)
                {
                    elevator.Move();
                    if (elevator.CurrentFloor == elevator.TargetFloor)
                    {
                        elevator.Exit();
                    }
                }
            }

            public void Status()
            {
                foreach (var elevator in Elevators)
                {
                    Console.WriteLine($"Elevator at floor {elevator.CurrentFloor}, moving: {elevator.IsMoving}, occupants: {elevator.Occupants.Count}");
                }
            }
        }

    }
