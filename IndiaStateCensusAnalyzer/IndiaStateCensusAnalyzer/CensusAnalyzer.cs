using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaStateCensusAnalyzer
{
    public class CensusAnalyzer
    {
        public Dictionary<string, StateCensusData> keyValuePairs;
        public Dictionary<string, StateCensusData> CensusData(string CSVfilepath, string header)
        {
            keyValuePairs = new Dictionary<string, StateCensusData>();

            if (!File.Exists(CSVfilepath))
            {
                throw new CensusCustomException(CensusCustomException.ExceptionType.File_Not_Found, "File does not exist");
            }

            if (Path.GetExtension(CSVfilepath) != ".csv")
            {
                throw new CensusCustomException(CensusCustomException.ExceptionType.Invalid_File_Type, "Invalid Extension");
            }

            string[] Data = File.ReadAllLines(CSVfilepath);
            if (Data[0] != header)
            {
                throw new CensusCustomException(CensusCustomException.ExceptionType.Incorrect_Header, "Incorrect Header");
            }

            foreach (string row in Data)
            {
                if (!row.Contains(","))
                {
                    throw new CensusCustomException(CensusCustomException.ExceptionType.Invalid_Delimeter, "delimeter not found");
                }

                string[] column = row.Split(',');

                if (CSVfilepath.Contains("StateCode"))
                    keyValuePairs.Add(column[0], new StateCensusData(new CensusStateCode(column[0], column[1], column[2], column[3])));
                else
                    keyValuePairs.Add(column[0], new StateCensusData(column[0], column[1], column[2], column[3]));
            }
            return keyValuePairs;
        }
    }
}
