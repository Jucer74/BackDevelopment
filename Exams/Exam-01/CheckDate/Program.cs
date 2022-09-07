//CheckDate("", "dmy");
// The input can not be null or empty 

//CheckDate(null, "dmy");
// The input can not be null or empty 

//CheckDate("01/01/2001", "qwe");
// qwe is nos a valid format date, only (dmy, mdy, ymd) are allowed

//CheckDate("01/01/2001", "dmy", '!');
// ! is nos a valid separator, only ('',  '.' ,  '/' , '-',  '_',  ',') are allowed

//CheckDate("qwertyuiop", "dmy");
// The input: qwertyuiop is not a Valid Date

//CheckDate("10/10/10", "dmy");
// The input: 10/10/10 is not a valid date

//CheckDate("01,01,20001", "dmy");
// The input 01,01,20001 is not a valid date

//CheckDate("112001", "dmy", '\0');
// The input 112001 is not a valid date

//CheckDate("1012001", "dmy", '\0');
// The input 1012001 is not a valid date

//CheckDate("0112001", "mdy", '\0');
// The input 0112001 is not a valid date

//CheckDate("01012001", "dmy", '\0');
// The input 01012001 is not a valid date

//CheckDate("08/10/1974", "dmy");
// The input: 08/10/1974 is a Valid Date

//CheckDate("07-27-1996", "mdy", '-');
// The input: 27-07-1996 is a Valid Date

//CheckDate("1976.04.10", "mdy", '.');
// The input: 1976.04.10 is a Valid Date

//CheckDate("4.10.1976", "mdy", '.');
// The input: 4.10.1976 is a Valid Date

//CheckDate("30,02,1976", "dmy", ',');
// The input: 30,02,1976 is not a Valid Date

//CheckDate("31/01/1986", "mdy", '/');
// The input: 31/01/1986 is not a Valid Date



//void CheckDate(string? inout, string dateFormat, char dateSeparator='/')
//{
//throw new NotImplementedException();
//}

using System;
using System.Linq;

namespace ValidateDate
{
    class Program
    {
        static void Main(string[] args)
        {
         

        }
        
        void CheckDate(string? input, string dateFormat, char dateSeparator = '/')
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("The input can not be null or empty ");
                return;
            }

            if (!IsValidDateFormat(dateFormat))
            {
                Console.Writeline("qwe is NOT a valid format date, only (dmy, mdy, ymd) are allowed");
                return;
            }


        }

       
       }
    }
}


