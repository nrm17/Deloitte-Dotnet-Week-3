using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace LoginService
{
    [ServiceContract]
    public interface ILogin
    {
        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        bool Authenticate(int id, string password);
    }
}
