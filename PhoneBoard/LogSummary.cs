using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBoard
{
    public class LogSummary
    {
        public static void Summarize(string logFilePath, int interval = 30)
        {
            List<(DateTime callStartTime, TimeSpan callDuration)> calls = new List<(DateTime callStartTime, TimeSpan callDuration)>();

            // must be in same day
            using (StreamReader sr = new StreamReader(logFilePath))
            {
                while (!sr.EndOfStream)
                {
                    DateTime callStartTime = new DateTime();
                    TimeSpan callDuration = new TimeSpan();

                    if (ParseLine(sr.ReadLine(), ref callStartTime, ref callDuration))
                    {
                        calls.Add((callStartTime, callDuration));
                    }
                }
            }

            if (calls.Count <= 0)
            {
                return;
            }

            DateTime telethonStartTime;
            DateTime telethonEndTime;
            DateTime firstCallTime = (from d in calls select d.callStartTime).Min();
            DateTime lastCallTime = (from d in calls select d.callStartTime).Max();

            // Start time set to previous interval, end time set to next interval
            if (firstCallTime.Minute < interval)
                telethonStartTime = new DateTime(firstCallTime.Year, firstCallTime.Month, firstCallTime.Day, firstCallTime.Hour, 0, 0);
            else
                telethonStartTime = new DateTime(firstCallTime.Year, firstCallTime.Month, firstCallTime.Day, firstCallTime.Hour, interval, 0);

            if (lastCallTime.Minute >= interval)
                telethonEndTime = new DateTime(lastCallTime.Year, lastCallTime.Month, lastCallTime.Day, lastCallTime.Hour + 1, 0, 0);
            else
                telethonEndTime = new DateTime(lastCallTime.Year, lastCallTime.Month, lastCallTime.Day, lastCallTime.Hour, interval, 0);


            using (StreamWriter summaryLog = new StreamWriter(("./logs/summaryLog_" + DateTime.Now.ToString("yyyy-MM-dd-hh.mm.ss") + ".txt"), true))
            {
                summaryLog.WriteLine("{0, -19} | {1, -11} | {2, -16} | {3, -16}", "Times", "Calls / Min", "Avg.Call Length", "Calls");

                DateTime telethonNextPeriod = telethonStartTime;
                TimeSpan halfHourCallLength = new TimeSpan();
                int halfHourCalls = 0;
                int totalIntervals = (int)((telethonEndTime - telethonStartTime).TotalMinutes / interval); // Number of intervals in telethon

                for (int i = 0; i < totalIntervals; i++)
                {
                    foreach (var c in calls)
                    {
                        if (c.callStartTime >= telethonNextPeriod && c.callStartTime < telethonNextPeriod.Add(TimeSpan.FromMinutes(interval)))
                        {
                            halfHourCalls++;
                            halfHourCallLength = halfHourCallLength.Add(c.callDuration);
                        }
                    }
                    summaryLog.WriteLine("{0:hh\\:mm tt} - {1, -7:hh\\:mm tt} | {2, -11:000.000} | {3, -16:00.00} | {4:000000}", telethonNextPeriod, telethonNextPeriod.Add(TimeSpan.FromMinutes(interval)), Convert.ToDouble(halfHourCalls) / interval, (halfHourCallLength.TotalMinutes / halfHourCalls), halfHourCalls);
                    telethonNextPeriod = telethonNextPeriod.Add(TimeSpan.FromMinutes(interval));
                    halfHourCalls = 0;
                    halfHourCallLength = TimeSpan.Zero;
                }

                int totalCalls = calls.Count();
                TimeSpan totalCallLength = calls.Sum(c => c.callDuration);

                summaryLog.WriteLine("\n{0, -19} | {1, -11:000.000} | {2, -16:00.00} | {3:000000}", "Totals", totalCalls / (lastCallTime - firstCallTime).TotalMinutes, (totalCallLength.TotalMinutes / totalCalls), totalCalls);
            }

            Console.WriteLine("Successfully summarized log.");
        }

        private static bool ParseLine(string line, ref DateTime callStartTime, ref TimeSpan callDuration)
        {
            // log line must start with a number (number represents a phone)
            if (line.Length == 0 || line[0] < '0' || line[0] > '9')
                return false;

            string[] columns = line.Split('|');
            callStartTime = DateTime.Parse(columns[1]);
            callDuration = TimeSpan.Parse(columns[3]);
            return true;
        }
    }
}

