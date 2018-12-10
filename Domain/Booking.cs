using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [MessageContract(IsWrapped = true,
        WrapperName = "BookingRequestObject",
        WrapperNamespace = "http://localhost:8080/Booking")]

    public class BookingRequest
    {
        [MessageHeader(Namespace = "http://localhost:8080/Booking")]
        public string LicenseKey { get; set; }

        [MessageBodyMember(Namespace = "http://localhost:8080/Booking")]
        public int BookingId { get; set; }
    }

    [MessageContract(IsWrapped = true,
       WrapperName = "BookingInfoObject",
       WrapperNamespace = "http://localhost:8080/Booking")]

    public class BookingInfo
    {
        public BookingInfo() { }

        public BookingInfo(Booking booking)
        {
            this.Id = booking.Id;
            this.CarId = booking.CarId;
            this.CustomerId = booking.CustomerId;
            this.FromDate = booking.FromDate;
            this.ToDate = booking.ToDate;
            this.IsReturned = booking.IsReturned;
        }
        
        [MessageBodyMember(Order = 1, Namespace = "http://localhost:8080/Booking")]
        public int Id { get; set; }

        [MessageBodyMember(Order = 2, Namespace = "http://localhost:8080/Booking")]
        public int CarId { get; set; }

        [MessageBodyMember(Order = 3, Namespace = "http://localhost:8080/Booking")]
        public int CustomerId { get; set; }

        [MessageBodyMember(Order = 4, Namespace = "http://localhost:8080/Booking")]
        public DateTime FromDate { get; set; }

        [MessageBodyMember(Order = 5, Namespace = "http://localhost:8080/Booking")]
        public DateTime ToDate { get; set; }

        [MessageBodyMember(Order = 6, Namespace = "http://localhost:8080/Booking")]
        public bool IsReturned { get; set; }
    }
}

[DataContract(Namespace = "http://localhost:8080/Booking")]
public class Booking
{
    [DataMember(Order = 1, Name = "ID")]
    public int Id { get; set; }

    [DataMember(Order = 2)]
    public int CarId { get; set; }

    [DataMember(Order = 3)]
    public int CustomerId { get; set; }

    [DataMember(Order = 4)]
    public DateTime FromDate { get; set; }

    [DataMember(Order = 5)]
    public DateTime ToDate { get; set; }

    [DataMember(Order = 6)]
    public bool IsReturned { get; set; }
}
