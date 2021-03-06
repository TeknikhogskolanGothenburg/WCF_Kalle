﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
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

        public CarInfo GetCarId(CarRequest request)
        {
            if(request.LicenseKey != "RentMyCar231")
            {
                throw new WebFaultException<string>(
                    "Incorrect license key",
                    HttpStatusCode.Forbidden);
            }
            else
            {
                try
                {
                    var carData = new CarService();
                    var car = carData.GetById(request.CarId);
                    return new CarInfo(car);
                }
                catch
                {
                    throw new FaultException("That id is not valid, please provide a new one");
                }
            }
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

        public Booking GetBooking(int id)
        {
            try
            {
                Booking bookingId = bookingService.Get(id);
                return bookingId;
            }
            catch
            {
                throw new FaultException("That is not a valid id, please provide a new one");
            }
        }

        public void IsReturned(int bookingId)
        {
            bookingService.IsReturned(bookingId);
        }

        public void IsRented(int bookingId)
        {
            bookingService.IsRented(bookingId);
        }

        public List<Booking> GetAllBookings()
        {
            List<Booking> AllBookings = bookingService.GetAllBookings();
            return AllBookings;
        }

        //CustomerService
        public void AddCustomer(Customer customer)
        {
            customerService.Add(customer);
        }

        public void RemoveCustomer(Customer customer)
        {
            customerService.Remove(customer);
        }

        public Customer GetCustomer(int id)
        {
            Customer customerId = customerService.Get(id);
            return customerId;
        }

        public void UpdateCustomer(Customer customer)
        {
            customerService.Update(customer);
        }
    }
}
