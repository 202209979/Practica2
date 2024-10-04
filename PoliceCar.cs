namespace Practice1
{
    class PoliceCar : VehicleWithPlate
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car";
        private bool isPatrolling;
        private bool isChasing;
        private bool withRadar;
        private SpeedRadar? speedRadar;
        private PoliceStation station;

        public PoliceCar(string plate, bool withRadar, PoliceStation station) : base(plate, typeOfVehicle)
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

        public void UseRadar(VehicleWithPlate vehicle)
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
                        isChasing = true;
                        Console.WriteLine(WriteMessage($"chasing infractor car with plate {vehicle.GetPlate()}."));
                        ReportInfractor(vehicle.GetPlate());
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

        public void ReportInfractor(string infractorPlate)
        {
            Console.WriteLine(WriteMessage($"Reporting infractor with plate {infractorPlate} to police station."));
            station.ActivateAlert(infractorPlate);
        }

        //Override ToString() method with class information
        public override string ToString()
        {
            if (!withRadar)
            {
                return $"{GetTypeOfVehicle()} with plate {GetPlate()}";
            }

            return $"{GetTypeOfVehicle()} with plate {GetPlate()} and radar";

        }

    }
}