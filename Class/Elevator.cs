using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Class
{
    public class Elevator
    {
        public int CurrentFloor { get; set; }
            public int TargetFloor { get; set; }
            public List<Person> Occupants { get; set; } = new List<Person>();
            public bool IsMoving => CurrentFloor != TargetFloor;
            public string Direction => CurrentFloor < TargetFloor ? "Up" : "Down";
            public int Capacity { get; set; }

            public Elevator(int capacity)
            {
                Capacity = capacity;
            }

            public void Move()
            {
                if (IsMoving)
                {
                    if (CurrentFloor < TargetFloor)
                    {
                        CurrentFloor++;
                    }
                    else
                    {
                        CurrentFloor--;
                    }
                }
            }

            public bool IsFull()
            {
                return Occupants.Count >= Capacity;
            }

            public bool Enter(Person person)
            {
                if (!IsFull())
                {
                    Occupants.Add(person);
                    return true;
                }
                return false;
            }

            public void Exit()
            {
                if (Occupants.Count > 0)
                {
                    Occupants.RemoveAt(0);
                }
            }
        }
    }
