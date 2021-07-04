using System;

namespace Interface_Segregation_Principle
{
    /*public interface IVehicle
    {
        void Fly();
        void Drive();
    }*/

    public interface ICar
    {
        void Drive();
    }

    public interface IAirpLane
    {
        void Fly();
    }

    public interface IMultiFunctionIVehicle : IAirpLane, ICar
    {

    }

    public class MultiFunctionalCar : IMultiFunctionIVehicle
    {
        private readonly ICar _car;
        private readonly IAirpLane _airpLane;
        public MultiFunctionalCar(ICar car, IAirpLane airpLane)
        {
            _car = car;
            _airpLane = airpLane;
        }

        public void Fly()
        {
            _airpLane.Fly();
        }

        public void Drive()
        {
            _car.Drive();
        }
    }
    public class Car : ICar
    {
        public void Drive()
        {

        }
    }
    public class AirPlane : IAirpLane
    {
        public void Fly()
        {

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car();
            car.Drive();

            var airpalne = new AirPlane();
            airpalne.Fly();

            var multi = new MultiFunctionalCar(car, airpalne);
            multi.Drive();
            multi.Fly();
        }
    }
}
