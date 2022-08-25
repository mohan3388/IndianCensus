using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaStateCensusAnalyzer
{
    public class CensusCustomException:Exception
    {
        public enum ExceptionType
        {
            File_Not_Found, Invalid_File_Type, Incorrect_Header, Invalid_Delimeter
        }
        ExceptionType exceptionType;
        public CensusCustomException(ExceptionType exceptionType, string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
