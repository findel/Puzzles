using System;

namespace Friday13
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("\n\r## Friday 13th ## \n\r-- Search for all Friday 13th's between two dates --");
			
			DateTime start = GetDateInput("Start");
			DateTime end = GetDateInput("End");
			
			DateTime startMonth = GetStartMonth(start);
			DateTime endMonth = GetEndMonth(end);
			
			Console.WriteLine("-- Searching -- \n\r");
			
			int count = 1;
			while(startMonth <= endMonth)
			{
				var thirteenth = startMonth.AddDays(12);
				if(thirteenth.DayOfWeek == DayOfWeek.Friday)
				{
					Console.WriteLine(string.Format("{0}.	{1}", count, thirteenth.ToString("dddd dd MMMM yyyy")));
					count++;
				}
				startMonth = startMonth.AddMonths(1);
			}
			
			Console.WriteLine("\n\r-- Finished --");	
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		static DateTime GetStartMonth(DateTime date)
		{
			if(date.Day > 13)
				date = date.AddMonths(1);
			return new 	DateTime(date.Year, date.Month, 1);
		}
		
		static DateTime GetEndMonth(DateTime date)
		{
			if(date.Day < 13)
				date = date.AddMonths(-1);
			return new DateTime(date.Year, date.Month, 1);
		}

		static DateTime GetDateInput(string fieldName)
		{
			DateTime? returnDate = null;
			while(returnDate == null)
			{
				Console.WriteLine(string.Format("\n\rQ: Please enter a valid {0} date", fieldName));
				var inputDate = Console.ReadLine();
				DateTime validDate;
				if (DateTime.TryParse(inputDate, out validDate))
					returnDate = validDate;
				else
					Console.WriteLine("Date not valid");
			}
			return returnDate.Value;
		}
	}
}