namespace Practice1
{
    class Scooter: VehicleWithoutPlate, IMessageWritter
    {
        private static string typeOfVehicle = "Scooter";
        public Scooter(): base(typeOfVehicle)
        {

        }
    }
}
