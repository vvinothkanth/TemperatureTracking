# TemperatureTracking
Problem statement:

Create a console application which receives two input parameters from users that is date and temperature.

The user can enter temperature values both in F and degree celsius.

The application should save the given inputs and should return the below reports based on request.
1. max temperature for requested day.
2.Min temp for requested day
3. Average temperature for a given start data and end date.

The temperature outputs should always be in degree celsius.


It is Contain three class files such as :
 
 1.) TemparatureReport:
      In this class is used to perform all process like add temperatur report find Minimum and maximum and average value for given date.
      
 2.) TemparatureProcessFlow:
      This class to used to ask the questions to user and perform that operation like find average, min ,max  temperature of given date
  
 3.) TemparatureMain:
      This class to used to invoke the  TemparatureReport and TemparatureProcessFlow class
      
      >> Sample Process
      >>if you ask Query Enter 1
If you enter temperature enter 2
2
Enter a date (e.g. 10/22/1987 or 7/22/1996 - MM/DD/YYYY):
7/30/2018
Enter Temperature VAlues
 Temperature Formate : 100F or 35C  like 23c,100f,36c,123F :
23c,110f,-2c,102.2F
7/30/2018 : 23,43.3333333333333,-2,39
if you ask Query Enter 1
If you enter temperature enter 2
1
Available Date with Temarature Value
7/28/2018: 40.6,32.4,40.6,20.6
7/23/2018: 30.6,32.4,10.6,20.6
7/30/2018: 23,43.3333333333333,-2,39
7/22/2018: 30.6,32.4,10.6,20.6
7/27/2018: 60.6,32.4,50.6,20.6
7/24/2018: 40.6,32.4,40.6,20.6
7/26/2018: 50.6,32.4,40.6,20.6
7/25/2018: 30.6,32.4,30.6,20.6

If you like to find Min/Max temperature Press (1)
If you like to find Average temperature between two Date Press (2)  :
1
Enter Date  : Formate must be in (MM/DD/YYYY) eg. 12/30/2018
7/27/2018
Enter type Min / Max
max
Temperatures In date of 7/27/2018 : 60.6,32.4,50.6,20.6 / degree C
Maximum Tempearture is:60.6 Degree Celcious
if you ask Query Enter 1
If you enter temperature enter 2
1
Available Date with Temarature Value
7/28/2018: 40.6,32.4,40.6,20.6
7/23/2018: 30.6,32.4,10.6,20.6
7/30/2018: 23,43.3333333333333,-2,39
7/22/2018: 30.6,32.4,10.6,20.6
7/27/2018: 60.6,32.4,50.6,20.6
7/24/2018: 40.6,32.4,40.6,20.6
7/26/2018: 50.6,32.4,40.6,20.6
7/25/2018: 30.6,32.4,30.6,20.6

If you like to find Min/Max temperature Press (1)
If you like to find Average temperature between two Date Press (2)  :
2
starting Date : Formate Must Be in DD/MM/YYYY eg. (30/12/2018)
27/7/2018
Ending Date : Formate Must Be in DD/MM/YYYY eg. (30/12/2018)
30/7/2018
Total : 12 Temperatures Found records
 Sum Of temp : Count : 401.733333333333

Average Temparature between (27/7/2018 to 30/7/2018) :33.4777777777778 degree Celcious

      
