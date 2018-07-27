//*************************
//  Auther : Vinothkanth V
//  Creation date :25 /7/ 2018
//  Last Modify    :26/ 7/ 2018
//
//  This class to used to ask the questions to user and perform that operation 
//  like find average, min ,max  temperature of given date
//
//*************************

/// <summary>
/// Temperature Namespace
/// </summary>
namespace Temperature
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Temperature;
    using System.Collections;

    /// <summary>
    /// The temperature flow class
    /// </summary>
    public class TemperatureProcessFlow
    {
        /// <summary>
        /// Initial state of the program it can be ask the question to user
        /// </summary>
        /// <returns>queryIndex</returns>
        public static int askQuery()
        {
            int query = 0;
            try
            {
                query = TemperatureReport.getQuery();
                if (query == 1 || query == 2)
                {

                    if (query == 2)
                    {
                        addTemperatureData();
                    }
                    else if (query == 1)
                    {
                        Console.WriteLine("Available Date with Temarature Value");
                        ICollection key = TemperatureReport.TemperatureTable.Keys;
                        foreach (string k in key)
                        {
                            Console.WriteLine(k + ": " + TemperatureReport.TemperatureTable[k]);
                        }

                        Console.WriteLine("\nIf you like to find Min temperature Press (1) ");
                        Console.WriteLine("\nIf you like to find Min temperature Press (2) ");
                        Console.WriteLine("\nIf you like to find Average temperature between two Date Press (3)");

                        int avgOrMinMax = Convert.ToInt32(Console.ReadLine());
                        if (avgOrMinMax == 1)
                        {
                            getMinMaxTempareture("Min");
                        }
                        else if (avgOrMinMax == 2)
                        {
                            getMinMaxTempareture("Max");
                        }
                        else if (avgOrMinMax == 3)
                        {
                            getAverageTemperature();
                        }
                        else
                        {
                            Console.WriteLine("Wrong Input");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong Input");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong Input");
                }

                Console.ReadKey();
                askQuery();
            }
            catch (Exception queryException)
            {
                Console.WriteLine(queryException);
            }

            return query;
        }

        /// <summary>
        /// return the date and temperature value to store in hashtable
        /// </summary>
        /// <returns>temperature values</returns>
        public static string[] getQueryForInsertDateWithTemperature()
        {
            string[] dateAndTemp = new string[2];
            try
            {
                // get multiple temperature values from user.
                Console.WriteLine("Enter a date (e.g. 10/22/1987 or 7/22/1996 - MM/DD/YYYY): ");
                string getDate = Convert.ToString(Console.ReadLine());
                string TempeartureDate = TemperatureReport.setDateForUserTemperatureEntry(getDate);
                string[] splitTemperatureValue = new string[] { };
                string celciousData = string.Empty;
                if (TempeartureDate == "00/00/0000")
                {
                    askQuery();
                }
                else
                {
                    Console.WriteLine("Enter Temperature Values (Please Enter More Then One value) \nTemperature Formate : 100F or 35C  like 23c,100f,36c,123F :");
                    string temperatureValues = Convert.ToString(Console.ReadLine());
                    splitTemperatureValue = temperatureValues.Split(',');
                    celciousData = TemperatureReport.splitAndConvertToCelcious(splitTemperatureValue);
                }
                dateAndTemp[0] = TempeartureDate;
                dateAndTemp[1] = celciousData;
            }
            catch (ArgumentOutOfRangeException arrayException)
            {
                Console.WriteLine(arrayException);
            }

            return dateAndTemp;
        }

        /// <summary>
        /// To store temparature details into hashtable
        /// </summary>
        /// <returns>return the operation true or not</returns>
        public static bool addTemperatureData()
        {
            bool status = false;
            try
            {
                string[] dateAndTemperature = getQueryForInsertDateWithTemperature();
                if (dateAndTemperature[0] != "00/00/0000")
                {
                    if (TemperatureReport.addTemperatureDataToHashTable(dateAndTemperature) == true)
                    {
                        askQuery();
                        status = true;
                    }
                    else
                    {
                        addTemperatureData();
                        status = false;
                    }
                }
                else
                {
                    getQueryForInsertDateWithTemperature();
                }
            }
            catch (Exception dataNotStored)
            {
                Console.WriteLine(dataNotStored);
            }

            return status;

        }

        /// <summary>
        /// Get date from the user and perform the operaiton of find min and max temparature
        /// </summary>
        /// <returns>return the operation true or not</returns>
        public static bool getMinMaxTempareture(string type)
        {
            bool status = false;

            try
            {

                Console.WriteLine("Enter Date  : Formate must be in (MM/DD/YYYY) eg. 12/30/2018");
                string date = Convert.ToString(Console.ReadLine());
                if (type == "Max")
                {
                    Console.WriteLine("{0} Degree Celcious", TemperatureReport.getMaximumTemperature(date));
                }
                else
                {
                    Console.WriteLine("{0} Degree Celcious", TemperatureReport.getMinimumTemperature(date));
                }
                Console.ReadKey();
                askQuery();
                status = true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return status;
        }

        /// <summary>
        /// Get two dates from the user and perform the operaiton of average temperature in between 
        /// two given dates
        /// </summary>
        /// <returns>return the operation true or not</returns>
        public static bool getAverageTemperature()
        {
            bool state = false;

            try
            {
                Console.WriteLine("starting Date : Formate Must Be in DD/MM/YYYY eg. (30/12/2018)");
                string start = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Ending Date : Formate Must Be in DD/MM/YYYY eg. (30/12/2018)");
                string end = Convert.ToString(Console.ReadLine());

                double averageTempearture = TemperatureReport.findAverageInBetweenTwoDate(start, end);
                Console.WriteLine("Average Temparature between ({0} to {1}) :{2} degree Celcious", start, end, averageTempearture);
                Console.ReadKey();

                askQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return state;
        }
    }
}
