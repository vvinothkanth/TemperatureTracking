//*************************
//  Auther : Vinothkanth V
//  Creation date :25 /7/ 2018
//  Last Modify    :26/ 7/ 2018
//
//  This class to used to invoke the  TemparatureReport and TemparatureProcessFlow class
//  
//
//*************************

/// <summary>
/// The Temperature Namespace
/// </summary>
namespace Temperature
{
    using System;
    using System.Linq;
    using System.Text;
    using Temperature;
    using System.Collections.Generic;
    using System.Collections;

    /// <summary>
    /// The Tempearture Main Class
    /// </summary>
    class TemperatureMain
    {
        static void Main(string[] args)
        {
            try
            {
                // if you want pre defind temperature data to uncomment the below line
                TemperatureReport.setSampleTemperatureTable();
                TemperatureProcessFlow.askQuery();
            }
            catch (Exception cannotAccessTheClass)
            {
                Console.WriteLine(cannotAccessTheClass);
            }
           
        }
    }
}
