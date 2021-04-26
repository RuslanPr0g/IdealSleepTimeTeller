using System;
using System.Collections.Generic;
using System.Linq;

namespace IdealSleepTimeTeller
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Time to wake up: *(hh:mm) format");
                Console.WriteLine("enter 0 to quit");

                try
                {
                    var enteredTime = Console.ReadLine();
                    if (enteredTime == "0")
                    {
                        return;
                    }
                    var desiredTimeToWakeUp = Convert.ToDateTime(enteredTime);
                    var timeToWakeUp = DateTime.Parse(DateTime.Now.Year + "/" + DateTime.Now.Month +
                        "/" + DateTime.Now.Day + " " +
                        desiredTimeToWakeUp.Hour + ":" + desiredTimeToWakeUp.Minute);
                    timeToWakeUp = timeToWakeUp.AddHours(24);
                    var theBestTimesToWakeUp = new List<DateTime>
                    {
                        timeToWakeUp
                    };
                    while (theBestTimesToWakeUp.Last().AddMinutes(-90) >= DateTime.Now)
                    {
                        theBestTimesToWakeUp.Add(theBestTimesToWakeUp.Last().AddMinutes(-90));
                    }
                    Console.WriteLine("The best times: *(hh:mm) format\n");
                    theBestTimesToWakeUp.Reverse();
                    theBestTimesToWakeUp.Remove(theBestTimesToWakeUp.Last());
                    foreach (var time in theBestTimesToWakeUp)
                    {
                        Console.WriteLine(time.Hour + ":" + time.Minute);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    Console.WriteLine("\n\nPress return to try again.");
                    Console.ReadKey();
                }
            }
        }
    }
}
