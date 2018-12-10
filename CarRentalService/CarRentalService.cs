using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BL;
using Domain;

namespace CarRentalService
{
    public class CarRentalService : ICarRentalService
    {
        CarService carService = new CarService();
        BookingService bookingService = new BookingService();
        CustomerService customerService = new CustomerService();

        //CarService
        public void AddCar(Car car)
        {
            carService.Add(car); 
        }

        public void RemoveCar(String regNr)
        {
            carService.Remove(regNr);
        }

        public List<int> GetAllAvailableCarIds(DateTime fromDate, DateTime toDate)
        {
            List<int> ids = carService.GetAllAvailable(fromDate, toDate);
            return ids;
        }

        public List<Car> GetCarById(List<int> id)
        {
            List<Car> car = carService.GetById(id);
            return car;
        }

        public List<Car> GetAllCars()
        {
            List<Car> car = carService.GetAllCars();
            return car;
        }

        public List<Car> GetAvailableCars(DateTime startDate, DateTime endDate)
        {
            List<Car> cars = carService.GetAvailableCars(startDate, endDate);
            return cars;
        }

        public bool CompareDates(List<DateTime> dateBetween, DateTime booked)
        {
            bool dates = carService.CompareDates(dateBetween, booked);
            return dates;
        }

        public List<DateTime> GetDates(DateTime startDate, DateTime endDate)
        {
            List<DateTime> dates = carService.GetDates(startDate, endDate);
            return dates;
        }

        //BookingService
        public void CreateBooking(Booking booking)
        {
            bookingService.Create(booking);
        }

        public void RemoveBooking(Booking booking)
        {
            bookingService.Remove(booking);
        }


    }
}
