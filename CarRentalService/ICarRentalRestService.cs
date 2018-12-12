using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Domain;

namespace CarRentalService
{
    [ServiceContract]
    public interface ICarRentalRestService
    {
        [OperationContract(Name = "AddCar")]
        [WebInvoke(Method = "POST", 
            UriTemplate = "Car", 
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        void AddCar(Car car);

        [OperationContract(Name = "RemoveCar")]
        [WebInvoke(Method = "DELETE",
            UriTemplate = "Car/{id}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void RemoveCar(string RegNr);
    }
}