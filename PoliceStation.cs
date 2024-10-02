namespace Practice1
{
    class PoliceStation
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
            foreach (PoliceCar pc in policeCars)
            {
                if (car.GetPlate() == pc.GetPlate())
                {
                    Console.WriteLine($"Car with plate {car.GetPlate()} already registered.");
                    break;
                }
            }
            policeCars.Add(car);
        }

        public void ActivateAlert(string plate)
        {
            detectedInfractor = true;
            foreach (PoliceCar car in policeCars)
            {
                if (car.IsPatrolling() && !car.IsChasing)
                {
                    car.IsChasing = true;
                    Console.WriteLine($"Police Car with plate {car.GetPlate()} chasing infractor car with plate {plate}.");
                }
            }
        }
    }
}

