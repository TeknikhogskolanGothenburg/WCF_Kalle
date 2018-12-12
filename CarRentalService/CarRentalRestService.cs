using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using BL;

namespace CarRentalService
{
    public class CarRentalRestService : ICarRentalRestService
    {
        CarService carService = new CarService();

        public void AddCar(Car car)
        {
            carService.Add(car);
        }

        public void RemoveCar(String regNr)
        {
            carService.Remove(regNr);
        }
    }
}
