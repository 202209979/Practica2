namespace Practice1
{
    abstract class VehicleWithoutPlate: Vehicle, IMessageWritter
    {
        public VehicleWithoutPlate(string typeOfVehicle): base (typeOfVehicle)
        {
        }

        //Override ToString() method with class information
        public override string ToString()
        {
            return $"{GetTypeOfVehicle()} without plate";
        }


        //Implment interface with Vechicle message structure
        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }
    }
}
