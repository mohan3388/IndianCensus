using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaStateCensusAnalyzer
{
    public class StateCensusData
    {
        string state;
        string population;
        string area;
        string density;
        string serialNumber;
        string stateName;
        string tin;
        string stateCode;

        public StateCensusData(CensusStateCode censusStateCode)
        {
            this.stateName = censusStateCode.StateName;
            this.serialNumber = censusStateCode.SerialNumber;
            this.tin = censusStateCode.Tin;
            this.stateCode = censusStateCode.StateCode;
        }

        public StateCensusData(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = population;
            this.area = area;
            this.density = density;
        }
    }
}
