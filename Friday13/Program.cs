using System;

namespace Friday13
{
	class Program
	{
		public static void Main(string[] args)
		{
			// Welcome message
			Console.WriteLine("\n\r## Friday 13th ## " +
			                  "\n\r-- Search for all Friday 13th's between two dates --");
			
			// Prompt for start and end dates
			DateTime start = GetDateInput("Start");
			DateTime end = GetDateInput("End");
			
			// Convert to "months" only (e.g. 1st of relevant months)
			DateTime startMonth = GetStartMonth(start);
			DateTime endMonth = GetEndMonth(end);
			
			// Separator.
			Console.WriteLine("\n\r-- Searching -- \n\r");
			
			// To count the number of Friday 13th matches.
			int count = 1;
			
			// Loop through each month, 
			// checking the 13th of each, 
			// output if it's a friday.
			while(startMonth <= endMonth)
			{
				var thirteenth = new DateTime(startMonth.Year, startMonth.Month, 13);
				if(thirteenth.DayOfWeek == DayOfWeek.Friday)
				{
					// Format with tab for nicer output.
					// e.g.
					// 1.	Friday 13 October 20
					// 12.	Friday 13 April 2001
					// 130.	Friday 13 July 2001
					Console.WriteLine(string.Format("{0}.	{1}", count, thirteenth.ToString("dddd dd MMMM yyyy")));
					count++;
				}
				startMonth = startMonth.AddMonths(1);
			}
			
			// Separator.
			Console.WriteLine("\n\r-- Finished --\n\r");	
			
			// Leave when they're ready
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		static DateTime GetStartMonth(DateTime date)
		{
			// If greater than the 13th, move to next month.
			if(date.Day > 13)
				date = date.AddMonths(1);
			// Recast as the first of the month.
			return new DateTime(date.Year, date.Month, 1);
		}
		
		static DateTime GetEndMonth(DateTime date)
		{
			// If less than the 13th, move to the last month.
			if(date.Day < 13)
				date = date.AddMonths(-1);
			// Recast as the first of the month.
			return new DateTime(date.Year, date.Month, 1);
		}

		static DateTime GetDateInput(string fieldName)
		{
			// Use a nullable date so that we can tell if we got a valid input date.
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