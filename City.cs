namespace Practice1
{
    class City: IMessageWritter
    {
        public List<Taxi> taxiLicenses;

        public City()
        {
            taxiLicenses = new List<Taxi>();
        }

        public void RegisterLicense(Taxi taxi)
        {
            if (taxiLicenses.Contains(taxi))
            {
                Console.WriteLine(WriteMessage($"Taxi with plate {taxi.GetPlate()}: was already registered"));
            }
            else
            {
                taxiLicenses.Add(taxi);
                Console.WriteLine(WriteMessage($"Taxi with plate {taxi.GetPlate()}: successfully registered license"));
            }


        }

        public void DeleteLicense(Taxi taxi)
        {
            if (taxiLicenses.Contains(taxi))
            {
                taxiLicenses.Remove(taxi);
                Console.WriteLine(WriteMessage($"Taxi with plate {taxi.GetPlate()}: successfully deleted license."));

            }
            else
            {
                Console.WriteLine(WriteMessage($"Taxi with plate {taxi.GetPlate()}: was not registered."));
            }
        }

        public override string ToString()
        {
            return $"City";
        }

        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }

    }
}
