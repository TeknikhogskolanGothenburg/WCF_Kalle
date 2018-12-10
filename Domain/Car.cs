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
        WrapperName = "CarRequestObject",
        WrapperNamespace = "http://localhost:8080/Cars")]

    public class CarRequest
    {
        [MessageHeader(Namespace = "http://localhost:8080/Cars")]
        public string LicenseKey { get; set; }

        [MessageBodyMember(Namespace = "http://localhost:8080/Cars")]
        public int CarId { get; set; }
    }

    [MessageContract(IsWrapped = true,
       WrapperName = "CarInfoObject",
       WrapperNamespace = "http://localhost:8080/Cars")]

    public class CarInfo
    {
        public CarInfo() { }

        public CarInfo(Car car)
        {
            this.Id = car.Id;
            this.CarId = car.CarId;
            this.Brand = car.Brand;
            this.Model = car.Model;
            this.Year = car.Year;
            this.RegNr = car.RegNr;
        }

        [MessageBodyMember(Order = 1, Namespace = "http://localhost:8080/Cars")]
        public int Id { get; set; }

        [MessageBodyMember(Order = 2, Namespace = "http://localhost:8080/Cars")]
        public int CarId { get; set; }

        [MessageBodyMember(Order = 3, Namespace = "http://localhost:8080/Cars")]
        public string Brand { get; set; }

        [MessageBodyMember(Order = 4, Namespace = "http://localhost:8080/Cars")]
        public string Model { get; set; }

        [MessageBodyMember(Order = 5, Namespace = "http://localhost:8080/Cars")]
        public int Year { get; set; }

        [MessageBodyMember(Order = 6, Namespace = "http://localhost:8080/Cars")]
        public string RegNr { get; set; }
    }
}

[DataContract(Namespace = "http://localhost:8080/Cars")]
public class Car
{
    [DataMember(Order = 1, Name = "ID")]
    public int Id { get; set; }

    [DataMember(Order = 2)]
    public int CarId { get; set; }

    [DataMember(Order = 3)]
    public string Brand { get; set; }

    [DataMember(Order = 4)]
    public string Model { get; set; }

    [DataMember(Order = 5)]
    public int Year { get; set; }

    [DataMember(Order = 6)]
    public string RegNr { get; set; }
}
