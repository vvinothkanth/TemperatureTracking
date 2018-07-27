//*************************
//  Auther : Vinothkanth V
//  Creation date :25 /7/ 2018
//  Last Modify    :26/ 7/ 2018
//
//  In this class is used to perform all process like add temperatur report
//   find Minimum and maximum and average value for given date.
//
//*************************

/// <summary>
/// The Temparature Namespace
/// </summary>
namespace Temperature
{
    using System;
    using System.Collections;
    using Temperature;

    /// <summary>
    /// The Tempearture Report Class
    /// </summary>
    public class TemperatureReport
    {
        /// <summary>
        /// The temperature Hashtable
        /// </summary>
        public static Hashtable temperatureTable = new Hashtable();

        /// <summary>
        ///  To set and get Temperature datas
        /// </summary>
        public static Hashtable TemperatureTable
        {

            get { return temperatureTable; }
        }

        /// <summary>
        /// By default it can be add some temperature data when this function calls
        /// </summary>
        /// <returns>key par values of temperature data</returns>
        public static Hashtable setSampleTemperatureTable()
        {
            try
            {
                TemperatureTable.Add("7/22/2018", "30.6,32.4,10.6,20.6");
                TemperatureTable.Add("7/23/2018", "30.6,32.4,10.6,20.6");
                TemperatureTable.Add("7/24/2018", "40.6,32.4,40.6,20.6");
                TemperatureTable.Add("7/25/2018", "30.6,32.4,30.6,20.6");
                TemperatureTable.Add("7/26/2018", "50.6,32.4,40.6,20.6");
                TemperatureTable.Add("7/27/2018", "60.6,32.4,50.6,20.6");
                TemperatureTable.Add("7/28/2018", "40.6,32.4,40.6,20.6");
            }
            catch (ArgumentOutOfRangeException arrayException)
            {
                Console.WriteLine(arrayException);
            }

            return temperatureTable;
        }

        /// <summary>
        /// To convert all user temperature  values as celcious
        /// </summary>
        /// <returns>return celcious value set</returns>
        public static string splitAndConvertToCelcious(string[] splitedTemperatureValue)
        {
            string listOfTemparatureValue = string.Empty;
            try
            {
                double convertToCelcious = 0.0;
                int inputFromUser = 0;
                // split and convert all values as celcious
                foreach (string temperature in splitedTemperatureValue)
                {
                    if (temperature.Contains("F") || temperature.Contains("f"))
                    {
                        double farenheat = Convert.ToDouble(temperature.Trim('F').Trim('f'));
                        convertToCelcious = TemperatureReport.convertToCelcious(farenheat);
                        if (listOfTemparatureValue == string.Empty || inputFromUser == splitedTemperatureValue.Length)
                        {
                            listOfTemparatureValue += convertToCelcious;
                        }
                        else
                        {
                            listOfTemparatureValue += "," + convertToCelcious;
                        }
                    }
                    else
                    {
                        double celcious = Convert.ToDouble(temperature.Trim('C').Trim('c'));
                        if (listOfTemparatureValue == string.Empty || inputFromUser == splitedTemperatureValue.Length)
                        {
                            listOfTemparatureValue += celcious;
                        }
                        else
                        {
                            listOfTemparatureValue += "," + celcious;
                        }
                    }
                    inputFromUser++;
                }

            }
            catch (FormatException temparatureIsNotInFormate)
            {
                Console.WriteLine(temparatureIsNotInFormate);
            }

            return listOfTemparatureValue;
        }

        /// <summary>
        /// To get and return date to user
        /// </summary>
        /// <returns></returns>
        public static string setDateForUserTemperatureEntry(string getDate)
        {
            string returnDate = string.Empty;
            try
            {
                string[] dat = getDate.Split('/');
                int month = Convert.ToInt16(dat[0]);
                int date = Convert.ToInt16(dat[1]);
                int year = Convert.ToInt16(dat[2]);
                if (month <= 0 || month > 12 || date <=0 || date >= 31 || year <=1900)
                {
                    Console.WriteLine("Date is Not In Correct Formate");
                    returnDate = "00/00/0000";
                }
                else
                {
                    returnDate = getDate;
                }
                
            }
            catch (FormatException dateIsNotInRightFormate)
            {
                Console.WriteLine(dateIsNotInRightFormate);
            }

            return returnDate;
        }

        /// <summary>
        /// To ask the quetion to user for enter value or retrive value 
        /// </summary>
        /// <returns>anserKey</returns>
        public static int getQuery()
        {
            int getQueryAnswer = 0;
            try
            {
                Console.WriteLine("if you ask Query Enter 1");
                Console.WriteLine("If you enter temperature enter 2");
                getQueryAnswer = Convert.ToInt16(Console.ReadLine());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return getQueryAnswer;
        }

        /// <summary>
        ///  Convert Farenheat to Celcious
        /// </summary>
        /// <param name="getfarenheat"> Farenheat value</param>
        /// <returns>celcious Value</returns>
        public static double convertToCelcious(double getfarenheat)
        {
            double convertToCelcious = 0.0;
            try
            {
                convertToCelcious = (getfarenheat - 32) * 5 / 9;
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception);
            }

            return convertToCelcious;
        }

        /// <summary>
        /// To store temerature details to Hashtable
        /// </summary>
        /// <param name="pareDate">date and temperature value of string array</param>
        /// <returns>true</returns>
        public static bool addTemperatureDataToHashTable(string[] pareDate)
        {
            bool storeStatus = false;

            try
            {
                // if the date is already exsist to add the temperature value
                if (TemperatureTable.ContainsKey(pareDate[0]))
                {
                    string x = TemperatureTable[pareDate[0]].ToString();
                    string ad = x + "," + pareDate[1];
                    TemperatureTable[pareDate[0]] = ad;
                    storeStatus = true;
                }
                else
                {
                    // if the date is not exist to create and add the temperature value
                    TemperatureTable.Add(pareDate[0], pareDate[1]);
                    storeStatus = true;
                }
                Console.WriteLine("{0} : {1}", pareDate[0], TemperatureTable[pareDate[0]]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }

            return storeStatus;
        }

        /// <summary>
        /// To fetch the Minimum ro Maximum temprature for given date
        /// </summary>
        /// <param name="date">Required Date</param>
        /// <param name="type">Maximum Temperature</param>
        /// <returns>Maximum Tempareture Value</returns>
        public static string getMaximumTemperature(string date)
        {
            string returnMaximumTemparature = string.Empty;
            try
            {
                if (TemperatureTable.ContainsKey(date))
                {
                    string[] splitDataAsComma = TemperatureTable[date].ToString().Split(',');
                    Console.WriteLine("Temperatures In date of {1} : {0} / degree C", TemperatureTable[date].ToString(), date);
                    Array.Sort(splitDataAsComma);
                    Array.Reverse(splitDataAsComma);
                    Console.Write("Maximum Tempearture is:");
                    return splitDataAsComma[0];
                }
                else
                {
                    Console.WriteLine("Date Not Fount");
                }
                Console.ReadKey();
                TemperatureProcessFlow.askQuery();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return returnMaximumTemparature;
        }

        /// <summary>
        /// To fetch the Minimum temprature for given date
        /// </summary>
        /// <param name="date">Required Date</param>
        /// <param name="type">Min</param>
        /// <returns>Min Value</returns>
        public static string getMinimumTemperature(string date)
        {
            string returnMinimumTemperature = string.Empty;
            try
            {
                if (TemperatureTable.ContainsKey(date))
                {
                    string[] splitDataAsComma = TemperatureTable[date].ToString().Split(',');
                    Console.WriteLine("Temperatures In date of {1} : {0} / degree C", TemperatureTable[date].ToString(), date);
                    Array.Sort(splitDataAsComma);
                    Console.Write("Minimum Tempearture is:");
                    return splitDataAsComma[0];
                }
                else
                {
                    Console.WriteLine("Date Not Fount");
                }
                Console.ReadKey();
                TemperatureProcessFlow.askQuery();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return returnMinimumTemperature;
        }

        /// <summary>
        /// To calculte the average temperature in between two date 
        /// </summary>
        /// <param name="startDate">starting date</param>
        /// <param name="endDate">Ending Date</param>
        /// <returns>Average Temperature</returns>
        public static double findAverageInBetweenTwoDate(string startDate, string endDate)
        {
            double averageTemperature = 0.0;
            int totalTemperatureValue = 0;
            try
            {
                string[] start = startDate.Split('/');
                string[] end = endDate.Split('/');

                var startingDate = new DateTime(Convert.ToInt16(start[2]), Convert.ToInt16(start[1]), Convert.ToInt16(start[0]));
                var endingDate = new DateTime(Convert.ToInt16(end[2]), Convert.ToInt16(end[1]), Convert.ToInt16(end[0]));

                var dateDifferenceBetweenTwoDate = (endingDate - startingDate).TotalDays;

                for (int i = 0; i <= dateDifferenceBetweenTwoDate; i++)
                {
                    var nextDate = startingDate.AddDays(i);
                    string s = Convert.ToString(nextDate).Split(' ')[0];
                    if (TemperatureTable.ContainsKey(s))
                    {
                        string[] temperatureDate = TemperatureTable[s].ToString().Split(',');
                        foreach (string dta in temperatureDate)
                        {
                            averageTemperature += Convert.ToDouble(dta);
                            totalTemperatureValue++;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.WriteLine("Total : {0} Temperatures Found records \n Sum Of temp : Count : {1} \n ", totalTemperatureValue, averageTemperature);
            }
            catch (ArgumentOutOfRangeException arrayException)
            {
                Console.WriteLine(arrayException);
            }

            return (averageTemperature / totalTemperatureValue);

        }

    }
}
