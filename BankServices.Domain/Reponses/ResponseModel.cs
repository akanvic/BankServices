using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServices.Domain.Reponses
{
    public class ResponseModel
    {
        public int State { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}
