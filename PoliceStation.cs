namespace Practice1
{
    class PoliceStation : IMessageWritter
    {
        public List<PoliceCar> policeCars;
        private bool detectedInfractor;
        public PoliceStation()
        {
            policeCars = new List<PoliceCar>();
            detectedInfractor = false;
        }


        public void RegisterPoliceCar(PoliceCar car, PoliceStation station)
        {
            if (policeCars.Contains(car))
            {
                    Console.WriteLine(WriteMessage($"Police Car with plate {car.GetPlate()}: was already registered."));
            }
            else
            {
                policeCars.Add(car);
                Console.WriteLine(WriteMessage($"Police Car with plate {car.GetPlate()}: successfully registered."));
            }
        }

        public void ActivateAlert(string plate)
        {
            Console.WriteLine(WriteMessage($"Alert received for infractor with plate {plate}."));
            detectedInfractor = true;
            foreach (PoliceCar car in policeCars)
            {
                if (car.IsPatrolling() && !car.IsChasing)
                {
                    car.IsChasing = true;
                    Console.WriteLine($"Police Car with plate {car.GetPlate()}: chasing infractor car with plate {plate}.");
                }
            }
        }

        public override string ToString()
        {
            return $"Police Station";
        }

        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }
    }
}

