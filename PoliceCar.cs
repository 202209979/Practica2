namespace Practice1
{
    class PoliceCar : Vehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car";
        private bool isPatrolling;
        private bool isChasing;
        private bool withRadar;
        private SpeedRadar? speedRadar;
        private PoliceStation station;

        public PoliceCar(string plate, bool withRadar, PoliceStation station) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            isChasing = false;
            this.station = station;
            if (withRadar)
            {
                speedRadar = new SpeedRadar();
            }
            else
            {
                speedRadar = null;
            }
        }

        public void UseRadar(Vehicle vehicle)
        {
            if (speedRadar != null)
            {
                if (isPatrolling)
                {
                    speedRadar.TriggerRadar(vehicle);
                    string meassurement = speedRadar.GetLastReading();
                    Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                    if (vehicle.GetSpeed() > speedRadar.GetLegalSpeed())
                    {
                        station.ActivateAlert(vehicle.GetPlate());
                        isChasing = true;
                        Console.WriteLine($"Police Car with plate {GetPlate()} chasing infractor car with plate {vehicle.GetPlate()}.");
                    }

                }
                else
                {
                    Console.WriteLine(WriteMessage($"has no active radar."));
                }
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no radar available."));
            }
        }

        public bool IsChasing
        {
            get => isChasing;
            set => isChasing = value;
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            if (speedRadar != null)
            {
                Console.WriteLine(WriteMessage("Report radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }
            }
            else
            {
                Console.WriteLine(WriteMessage("has no radar available."));
            }
        }

    }
}