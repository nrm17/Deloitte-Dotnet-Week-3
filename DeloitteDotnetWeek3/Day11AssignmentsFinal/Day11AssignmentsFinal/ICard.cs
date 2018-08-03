using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Day11AssignmentsFinal
{
    [ServiceContract]
    public interface ICard
    {
        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        bool Authenticate(int cardno, string cvv);


        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        bool DateCheck(int cardno);


        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        decimal Trans(int cardno, decimal amt);



    }
}
