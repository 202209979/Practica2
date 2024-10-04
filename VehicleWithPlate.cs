namespace Practice1
{
    abstract class VehicleWithPlate : Vehicle, IMessageWritter
    {
        private string plate;

        public VehicleWithPlate(string plate, string typeOfVehicle): base(typeOfVehicle)
        {
            this.plate = plate;
        }

        public string GetPlate()
        {
            return plate;
        }

        //Override ToString() method with class information
        public override string ToString()
        {
            return $"{GetTypeOfVehicle()} with plate {GetPlate()}";
        }


        //Implment interface with Vechicle message structure
        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }

    }
}
