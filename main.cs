using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {

		VaccineShot covid = new VaccineShot("Covid-19 shot", 3);
		VaccineShot flu = new VaccineShot("Flu shot", 2);

		covid.appointmentsFull += Shot_AppoinmentFull;
		flu.appointmentsFull += Shot_AppoinmentFull;

		covid.ScheduleAppointment("Jeff").PrintToConsole();
		covid.ScheduleAppointment("Jim").PrintToConsole();
		covid.ScheduleAppointment("Tom").PrintToConsole();
		covid.ScheduleAppointment("Bill").PrintToConsole();
		Console.WriteLine();

		flu.ScheduleAppointment("Tany").PrintToConsole();
		flu.ScheduleAppointment("Sue").PrintToConsole();
		flu.ScheduleAppointment("Chuck").PrintToConsole();
		flu.ScheduleAppointment("Jared").PrintToConsole();

		

    Console.ReadLine();
  }

	private static void Shot_AppoinmentFull(object sender, string e)
	{
		VaccineShot model = (VaccineShot)sender;
		Console.WriteLine();
		Console.WriteLine(e);
		Console.WriteLine();
	}
}

public static class ConsoleHelper
{
	public static void PrintToConsole(this string message)
	{
		Console.WriteLine(message);
	}
}

public class VaccineShot
{
	public event EventHandler<string> appointmentsFull;

	public List<string> appointmentScheduled = new List<string>();
	public List<string> onWaitigList = new List<string>();

	public string ShotName { get; private set; }
	public int MaxNumber { get; private set; }

	public VaccineShot(string shotName, int openSpots)
	{
		ShotName = shotName;
		MaxNumber = openSpots;
	}

	public string ScheduleAppointment(string personName)
	{
		string output = "";

		if (appointmentScheduled.Count < MaxNumber)
		{
			appointmentScheduled.Add(personName);
			output = $"{ personName }'s { ShotName } appointment has been scheduled";
		}
		else
		{
			appointmentsFull?.Invoke(this, $"{ ShotName } Appointments are Curently Full");
			onWaitigList.Add(personName);
			output = $"{ personName } has been added to the waiting list for the { ShotName }";
		}

		return output;
	}

}