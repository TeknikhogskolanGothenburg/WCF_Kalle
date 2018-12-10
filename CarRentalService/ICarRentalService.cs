using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarRentalService
{
    [ServiceContract]
    public interface ICarRentalService
    {
        //CarContracts
        [OperationContract]
        void AddCar(Car car);

        [OperationContract]
        void RemoveCar(String regNr);

        [OperationContract]
        List<int> GetAllAvailableCarIds(DateTime fromDate, DateTime toDate);

        [OperationContract]
        List<Car> GetCarById(List<int> id);

        [OperationContract]
        List<Car> GetAllCars();

        [OperationContract]
        List<Car> GetAvailableCars(DateTime startDate, DateTime endDate);

        [OperationContract]
        bool CompareDates(List<DateTime> dateBetween, DateTime booked);

        [OperationContract]
        List<DateTime> GetDates(DateTime startDate, DateTime endDate);

        //BookingContracts
        [OperationContract]
        void CreateBooking(Booking booking);

        [OperationContract]
        void RemoveBooking(Booking booking);

        [OperationContract]
        Booking GetBooking(int Id);

        [OperationContract]
        void IsReturned(int bookingId);

        [OperationContract]
        void IsRented(int bookingId);

        [OperationContract]
        List<Booking> GetAllBookings();

        //CustomerContracts
        [OperationContract]
        void AddCustomer(Customer customer);

        [OperationContract]
        void RemoveCustomer(Customer customer);

        [OperationContract]
        Customer GetCustomer(int Id);

        [OperationContract]
        void UpdateCustomer(Customer customer);
    }
}
