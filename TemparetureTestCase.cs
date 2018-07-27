//*************************
//  Auther : Vinothkanth V
//  Creation date :25 /7/ 2018
//  Last Modify    :26/ 7/ 2018
//
//*************************

/// <summary>
/// The Temperature Namespace
/// </summary>
/// 
namespace Temperature
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Temperature;

    /// <summary>
    /// The TemparetureTestCase class
    /// </summary>
    [TestClass]
    public class TemparetureTestCase
    {
        /// <summary>
        ///  To check the give date is valid are not
        /// </summary>
        [TestMethod]
        public void checkTheGivenDateHasBeenReturn()
        {
            string checkDateOne = TemperatureReport.setDateForUserTemperatureEntry("7/23/2018");
            string checkDateTwo = TemperatureReport.setDateForUserTemperatureEntry("7/24/2018");

            string invalidDate = TemperatureReport.setDateForUserTemperatureEntry("24/07/2018");
            string invalidDate_I = TemperatureReport.setDateForUserTemperatureEntry("32/65/1400");

            Assert.AreEqual("7/23/2018", checkDateOne);   
            Assert.AreEqual("7/24/2018", checkDateTwo);

            Assert.AreEqual("00/00/0000", invalidDate);
            Assert.AreEqual("00/00/0000", invalidDate_I);

            Assert.AreNotEqual("24/07/2018", checkDateOne);
            Assert.AreNotEqual("23/07/2018", checkDateTwo);


        }

        /// <summary>
        /// To check the given farenheat value is properly convert or not
        /// </summary>
        [TestMethod]
        public void CheckCelciousConversion()
        {
            double celcious_I = TemperatureReport.convertToCelcious(120.2);
            double celcious_II = TemperatureReport.convertToCelcious(100.0);

            Assert.AreEqual(49, celcious_I);
            Assert.AreNotEqual(53, celcious_I);
            Assert.AreNotEqual(33.45, celcious_II);
        }

        /// <summary>
        ///  To check the given tempareture is list is properly convert to celcious or not 
        /// </summary>
        [TestMethod]
        public void stringConvertion()
        {
            new TemperatureReport();
            TemperatureReport.setSampleTemperatureTable();
            int valueCount = TemperatureReport.TemperatureTable.Count;

            Assert.AreEqual(7, valueCount);
            string pareOfTemparetureValue = TemperatureReport.splitAndConvertToCelcious(new string[]{"120.2F","20C"});
            string pareOfTemparetureValue_I = TemperatureReport.splitAndConvertToCelcious(new string[]{ "22c","1200C","120.2f" });
            Assert.AreEqual("22,1200,49", pareOfTemparetureValue_I);
            Assert.AreNotEqual("22C,1200F,49", pareOfTemparetureValue_I);
            Assert.AreEqual("49,20",pareOfTemparetureValue);
            Assert.AreNotEqual("49F,20c", pareOfTemparetureValue);
        }

        /// <summary>
        ///  Check to default Hashtable is properly inserted or not using the count of hashtabel
        /// </summary>
        [TestMethod]
        public void checkHastTable()
        {
            TemperatureReport tr = new TemperatureReport();
            TemperatureReport.setSampleTemperatureTable();
            Assert.AreEqual(7, TemperatureReport.TemperatureTable.Count);
            Assert.AreNotEqual(8, TemperatureReport.TemperatureTable.Count);
        }

        /// <summary>
        /// Check the fuction is properly  return the Maximum Tempareture of the given date
        /// </summary>
        [TestMethod]
        public void checkMaxValue()
        {
            try
            {
                TemperatureReport tp = new TemperatureReport();
                TemperatureReport.setSampleTemperatureTable();
                string max = TemperatureReport.getMaximumTemperature("7/23/2018");
                Assert.AreEqual("32.4", max);
                Assert.AreNotEqual("34.4C", max);
                Assert.AreNotEqual("346", max);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "File Not Found Exception");
                return;
            }
        }

        /// <summary>
        /// Check the fuction is properly  return the Minimum Tempareture of the given date
        /// </summary>
        [TestMethod]
        public void checkMinValue()
        {
            try
            {
                TemperatureReport tp =  new TemperatureReport();
                TemperatureReport.setSampleTemperatureTable();
                string mix = TemperatureReport.getMinimumTemperature("7/23/2018");
                Assert.AreEqual("10.6", mix);
                Assert.AreNotEqual("10.6C", mix);
                Assert.AreNotEqual("106", mix);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "File Not Found Exception");
                return;
            }

        }

        /// <summary>
        /// Check the fuction is properly  return the Average Tempareture of in between two date
        /// </summary>
        [TestMethod]
        public void checkAverage()
        {
            try
            {
                TemperatureReport tp = new TemperatureReport();
                TemperatureReport.setSampleTemperatureTable();
                double average = TemperatureReport.findAverageInBetweenTwoDate("23/7/2018","25/7/2018");
                Assert.AreEqual(28.55, average);
                Assert.AreNotEqual("28.55", average);
                Assert.AreNotEqual(28, average);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "File Not Found Exception");
                return;
            }

        }


        /// <summary>
        /// Check the temperature date is properly insert or not
        /// </summary>
        [TestMethod]
        public void addData()
        {
            try
            {
                bool check = TemperatureReport.addTemperatureDataToHashTable(new string[]{"7/7/2018","23c,100f"});
                bool check1 = TemperatureReport.addTemperatureDataToHashTable(new string[] { "7/7/2018"});
                Assert.IsTrue(check);
                Assert.IsFalse(check1);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "File Not Found Exception");
                return;
            }

        }

    }
}
