const string IS_VALID = "is";
const string IS_NOT_VALID = "is not";

CheckDate("", "dmy");
// The input can not be null or empty

CheckDate(null, "dmy");
// The input can not be null or empty

CheckDate("01/01/2001", "qwe");
// qwe is nos a valid format date, only (dmy, mdy, ymd) are allowed

CheckDate("01/01/2001", "dmy", '!');
// ! is nos a valid separator, only ('',  '.' ,  '/' , '-',  '_',  ',') are allowed

//CheckDate("qwertyuiop", "dmy");
// The input: qwertyuiop is not a Valid Date

CheckDate("10/10/10", "dmy");
// The input: 10/10/10 is not a valid date

CheckDate("01,01,20001", "dmy");
// The input 01,01,20001 is not a valid date

CheckDate("112001", "dmy", '\0');
// The input 112001 is not a valid date

CheckDate("1012001", "dmy", '\0');
// The input 1012001 is not a valid date

CheckDate("0112001", "mdy", '\0');
// The input 0112001 is not a valid date

//CheckDate("01012001", "dmy", '\0');
// The input 01012001 is not a valid date

CheckDate("08/10/1974", "dmy");
// The input: 08/10/1974 is a Valid Date

CheckDate("07-27-1996", "mdy", '-');
// The input: 27-07-1996 is a Valid Date

CheckDate("1976.04.10", "ymd", '.');
// The input: 1976.04.10 is a Valid Date

CheckDate("4.10.1976", "mdy", '.');
// The input: 4.10.1976 is a Valid Date

CheckDate("30,02,1976", "dmy", ',');
// The input: 30,02,1976 is not a Valid Date

CheckDate("31/01/1986", "mdy", '/');
// The input: 31/01/1986 is not a Valid Date

CheckDate("1/1/1/1986", "mdy", '/');
// The input: 31/01/1986 is not a Valid Date

void CheckDate(string? input, string dateFormat, char dateSeparator = '/')
{
   if (string.IsNullOrEmpty(input))
   {
      Console.WriteLine("The input can not b null or empty");
      return;
   }

   if (!IsValidDateFormat(dateFormat))
   {
      Console.WriteLine("{0} is not a valid format date, only (dmy, mdy, ymd) are allowed", dateFormat);
      return;
   }

   if (!IsValidDateSeparator(dateSeparator))
   {
      Console.WriteLine("{0} is nos a valid separator, only ('',  '.' ,  '/' , '-',  '_',  ',') are allowed", dateSeparator);
      return;
   }

   Console.WriteLine("The input: {0} {1} a valid date", input, GetValidDateResult(input, dateFormat, dateSeparator));
}

bool IsValidDateFormat(string dateFormat)
{
   //if (dateFormat != "dmy" && dateFormat != "mdy" && dateFormat != "ymd")
   //{
   //   return false;
   //}
   //return true;

   return (dateFormat != "dmy" && dateFormat != "mdy" && dateFormat != "ymd");
}

bool IsValidDateSeparator(char dateSeparator)
{
   //if (dateSeparator != '\0' && dateSeparator != '.' && dateSeparator != '/' && dateSeparator != '-' && dateSeparator != '_' && dateSeparator != ',')
   //{
   //   return false;
   //}
   //return true;

   return (dateSeparator != '\0' && dateSeparator != '.' && dateSeparator != '/' && dateSeparator != '-' && dateSeparator != '_' && dateSeparator != ',');
}

String[] SeparateDate(string input, char dateSeparator)
{
   //string[] dateSeparated = input.Split(dateSeparator);
   //return dateSeparated;

   return input.Split(dateSeparator);
}

String GetValidDateResult(string input, string dateFormat, char dateSeparator)
{
   if (!IsValidDate(input, dateFormat, dateSeparator))
   {
      return IS_NOT_VALID;
   }
   return IS_VALID;
}

bool IsValidDate(string input, string dateFormat, char dateSeparator)
{
   if (dateSeparator == '\0' && (!IsDateANumber(input) || input.Length != 8))
   {
      return false;
   }

   if (input.Length < 8 || input.Length > 10)
   {
      return false;
   }

   if (GetYear(input, dateFormat, dateSeparator) < 1900 || GetYear(input, dateFormat, dateSeparator) > 9999)
   {
      return false;
   }

   if (GetMonth(input, dateFormat, dateSeparator) < 1 || GetMonth(input, dateFormat, dateSeparator) > 12)
   {
      return false;
   }

   if (!IsAValidDay(input, dateFormat, dateSeparator))
   {
      return false;
   }

   return true;
}

bool IsDateANumber(string input)
{
   bool possibleConvertToInt = int.TryParse(input, out int number);
   return possibleConvertToInt;
}

int GetYear(string input, string dateFormat, char dateSeparator)
{
   string[] dateSeparated = SeparateDate(input, dateSeparator);
   int year = 0;

   if (dateFormat == "dmy" || dateFormat == "mdy")
   {
      year = int.Parse(dateSeparated[2]);
   }
   else
   {
      year = int.Parse(dateSeparated[0]);
   }

   return year;
}

bool IsALeapYear(int year)
{
   if (year % 4 != 0)
   {
      return false;
   }
   return true;
}

int GetMonth(string input, string dateFormat, char dateSeparator)
{
   string[] dateSeparated = SeparateDate(input, dateSeparator);
   int month = 0;

   if (dateFormat == "dmy" || dateFormat == "ymd")
   {
      month = int.Parse(dateSeparated[1]);
   }
   else
   {
      month = int.Parse(dateSeparated[0]);
   }

   return month;
}

bool IsAValidDay(string input, string dateFormat, char dateSeparator)
{
   int year = GetYear(input, dateFormat, dateSeparator);
   int month = GetMonth(input, dateFormat, dateSeparator);
   int day = GetDay(input, dateFormat, dateSeparator);

   if ((month == 4 || month == 6 || month == 9 || month == 11) && day > 30)
   {
      return false;
   }

   if (month == 2 && ((!IsALeapYear(year) && day > 28) || (IsALeapYear(year) && day > 29)))
   {
      return false;
   }

   if (day > 31)
   {
      return false;
   }

   return true;
}

int GetDay(string input, string dateFormat, char dateSeparator)
{
   string[] dateSeparated = SeparateDate(input, dateSeparator);
   int day = 0;

   if (dateFormat == "dmy")
   {
      day = int.Parse(dateSeparated[0]);
   }

   if (dateFormat == "mdy")
   {
      day = int.Parse(dateSeparated[1]);
   }

   if (dateFormat == "ymd")
   {
      day = int.Parse(dateSeparated[2]);
   }

   return day;
}