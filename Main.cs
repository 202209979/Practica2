namespace Practice1
{
    internal class Program
    {

        static void Main()
        {
            City city = new City();
            Console.WriteLine(city.WriteMessage("Created"));

            PoliceStation station = new PoliceStation();
            Console.WriteLine(station.WriteMessage("Created"));

            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");
            PoliceCar policeCar1 = new PoliceCar("0001 CNP",true,station);
            PoliceCar policeCar2 = new PoliceCar("0002 CNP",false,station);

            Console.WriteLine(taxi1.WriteMessage("Created"));
            Console.WriteLine(taxi2.WriteMessage("Created"));
            Console.WriteLine(policeCar1.WriteMessage("Created"));
            Console.WriteLine(policeCar2.WriteMessage("Created"));

            city.RegisterLicense(taxi1);
            city.RegisterLicense(taxi2);
            city.RegisterLicense(taxi1);

            station.RegisterPoliceCar(policeCar1,station);
            station.RegisterPoliceCar(policeCar2 ,station);
            station.RegisterPoliceCar (policeCar1,station);

            taxi1.StartRide();
            taxi1.StartRide();
            policeCar2.StartPatrolling();
            policeCar2.UseRadar(taxi1);
            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1);
            taxi1.StopRide();
            taxi1.StopRide();
            city.DeleteLicense(taxi1);
            policeCar1.EndPatrolling();

            policeCar1.PrintRadarHistory();
            policeCar2.PrintRadarHistory();

            Scooter scooter = new Scooter();
            Console.WriteLine(scooter.WriteMessage("Created"));

        }
    }
}
    

