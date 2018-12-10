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
        WrapperName = "CustomerRequestObject",
        WrapperNamespace = "http://localhost:8080/Customer")]

    public class CustomerRequest
    {
        [MessageHeader(Namespace = "http://localhost:8080/Customer")]
        public string LicenseKey { get; set; }

        [MessageBodyMember(Namespace = "http://localhost:8080/Customer")]
        public int CustomerId { get; set; }
    }

    [MessageContract(IsWrapped = true,
       WrapperName = "CustomerInfoObject",
       WrapperNamespace = "http://localhost:8080/Customer")]

    public class CustomerInfo
    {
        public CustomerInfo() { }

        public CustomerInfo(Customer customer)
        {
            this.Id = customer.Id;
            this.Firstname = customer.Firstname;
            this.Lastname = customer.Lastname;
            this.Telephone = customer.Telephone;
            this.Email = customer.Email;
        }

        [MessageBodyMember(Order = 1, Namespace = "http://localhost:8080/Customer")]
        public int Id { get; set; }

        [MessageBodyMember(Order = 2, Namespace = "http://localhost:8080/Customer")]
        public string Firstname { get; set; }

        [MessageBodyMember(Order = 3, Namespace = "http://localhost:8080/Customer")]
        public string Lastname { get; set; }

        [MessageBodyMember(Order = 4, Namespace = "http://localhost:8080/Customer")]
        public string Telephone { get; set; }

        [MessageBodyMember(Order = 5, Namespace = "http://localhost:8080/Customer")]
        public string Email { get; set; }
    }
    [DataContract(Namespace = "http://localhost:8080/Customer")]
    public class Customer
    {
        [DataMember(Order = 1, Name = "ID")]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string Firstname { get; set; }

        [DataMember(Order = 3)]
        public string Lastname { get; set; }

        [DataMember(Order = 4)]
        public string Telephone { get; set; }

        [DataMember(Order = 5)]
        public string Email { get; set; }
    }
}
