using IndiaStateCensusAnalyzer;

namespace IndianCensusTest
{
    public class CensusTest
    {
        CensusAnalyzer censusAnalyzer;
        string path = @"F:\Dotnet2\IndianCenses\IndianCensus\IndiaStateCensusAnalyzer\IndiaStateCensusAnalyzer\CsvFiles\";
        string file = @"F:\Dotnet2\IndianCenses\IndianCensus\IndiaStateCensusAnalyzer\IndiaStateCensusAnalyzer\CsvFiles\IndiaStateCensusData.csv";
        string InvalidFile = @"F:\Dotnet2\IndianCenses\IndianCensus\IndiaStateCensusAnalyzer\IndiaStateCensusAnalyzer\CsvFiles\IndiaStateCode.txt";
        string InvalidDelimiter = @"F:\Dotnet2\IndianCenses\IndianCensus\IndiaStateCensusAnalyzer\IndiaStateCensusAnalyzer\CsvFiles\DelimiterIndiaStateCensusData.csv";
        string InvalidHeader = @"F:\Dotnet2\IndianCenses\IndianCensus\IndiaStateCensusAnalyzer\IndiaStateCensusAnalyzer\CsvFiles\WrongIndiaStateCensusData.csv";

        [SetUp]
        public void Setup()
        {
            censusAnalyzer = new CensusAnalyzer();
        }

        // TC 1.1: Given the States Census CSV file, Check to ensure the Number of Record matches
        [Test]
        public void GivenCSVFile_CheckifNumberofRecordsMatch()
        {
            censusAnalyzer.keyValuePairs = censusAnalyzer.CensusData(path + file, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, censusAnalyzer.keyValuePairs.Count);
        }

        // TC 1.2: Given the State Census CSV File if incorrect Returns a custom Exception
        [Test]
        public void GivenIncorrectFileName_ReturnCustomException()
        {
            CensusCustomException Exception = Assert.Throws<CensusCustomException>(() => censusAnalyzer.CensusData(path + file + "c", "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusCustomException.ExceptionType.File_Not_Found, Exception);
        }

        // TC 1.3: Given the State Census CSV File when correct but type incorrect Returns a custom Exception
        [Test]
        public void GivenIncorrectType_ReturnsCustomException()
        {
            CensusCustomException Exception = Assert.Throws<CensusCustomException>(() => censusAnalyzer.CensusData(path + InvalidFile, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusCustomException.ExceptionType.Invalid_File_Type, Exception);
        }

        // TC 1.4: Given the State Census CSV File when correct but delimiter incorrect Returns a custom Exception
        [Test]
        public void GivenIncorrectDelimiter_ReturnsCustomException()
        {
            CensusCustomException Exception = Assert.Throws<CensusCustomException>(() => censusAnalyzer.CensusData(path + InvalidDelimiter, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusCustomException.ExceptionType.Invalid_Delimeter, Exception);
        }

        // TC 1.5: Given the State Census CSV File when correct but csv header incorrect Returns a custom Exception
        [Test]
        public void GivenIncorrectHeader_ReturnsCustomException()
        {
            CensusCustomException Exception = Assert.Throws<CensusCustomException>(() => censusAnalyzer.CensusData(path + InvalidHeader, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusCustomException.ExceptionType.Incorrect_Header, Exception);
        }

        // TC 2.1: Given the States Code CSV file, Check to ensure the Number of Record matches
        [Test]
        public void GivenStateCodeCSVFile_TestIfRecordMatched()
        {
            censusAnalyzer.keyValuePairs = censusAnalyzer.CensusData(path + StateCodeExtension, "SrNo,State Name,TIN,StateCode");
            Assert.AreEqual(37, censusAnalyzer.keyValuePairs.Count);
        }

        // TC 2.2: Given the State Census CSV File if incorrect Returns a custom Exception
        [Test]
        public void GivenStateCodeIncorrectFileName_ReturnsCustomException()
        {
            CensusCustomException Exception = Assert.Throws<CensusCustomException>(() => censusAnalyzer.CensusData(path + InvalidHeader + "hellow", "SrNo, State Name, TIN, StateCode"));
            Assert.AreEqual(CensusCustomException.ExceptionType.File_Not_Found, Exception);
        }

        // TC 2.3: Given the State Code CSV File when correct but type incorrect Returns a custom Exception
        [Test]
        public void GivenStateCodeIncorrectType_ReturnsCustomException()
        {
            CensusCustomException Exception = Assert.Throws<CensusCustomException>(() => censusAnalyzer.CensusData(path + StateCodeExtension, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusCustomException.ExceptionType.Invalid_File_Type, Exception);
        }

        // TC 2.4: Given the State Code CSV File when correct but delimiter incorrect Returns a custom Exception
        [Test]
        public void GivenStateCodeIncorrectDelimiter_ReturnsCustomException()
        {
            CensusCustomException Exception = Assert.Throws<CensusCustomException>(() => censusAnalyzer.CensusData(path + StateCodeDelimiter, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusCustomException.ExceptionType.Invalid_Delimeter, Exception);
        }

        // TC 2.5: Given the State Code CSV File when correct but csv header incorrect Returns a custom Exception
        [Test]
        public void GivenStateCodeIncorrectHeader_ReturnsCustomException()
        {
            CensusCustomException Exception = Assert.Throws<CensusCustomException>(() => censusAnalyzer.CensusData(path + StateCodeInvalidHeader, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusCustomException.ExceptionType.Incorrect_Header, Exception);
        }
    }
}