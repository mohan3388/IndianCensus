using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaStateCensusAnalyzer
{
    public class CensusStateCode
    {
        public string SerialNumber;
        public string StateName;
        public string Tin;
        public string StateCode;

        public CensusStateCode(string serialnumber, string statename, string tin, string statecode)
        {
            this.SerialNumber = serialnumber;
            this.StateName = statename;
            this.Tin = tin;
            this.StateCode = statecode;
        }
    }
}
