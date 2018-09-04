using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
https://www.codingame.com/ide/puzzle/defibrillators
The input data you require for your program is provided in text format.
This data is comprised of lines, each of which represents a defibrillator. Each defibrillator is represented by the following fields:
A number identifying the defibrillator;Name;Address;Contact Phone number;Longitude (degrees);Latitude (degrees)
These fields are separated by a semicolon (;).

Beware: the decimal numbers use the comma (,) as decimal separator. Remember to turn the comma (,) into dot (.) if necessary in order to use the data in your program.
 
DISTANCE
The distance d between two points A and B will be calculated using the following formula:
x = (longB - longA) * cos((latA + latB) / 2)
y = (latB - latA)
d = Sqrt(x*x + y*y) * 6371
​
Note: In this formula, the latitudes and longitudes are expressed in radians. 6371 corresponds to the radius of the earth in km.
The program will display the name of the defibrillator located the closest to the user’s position. This position is given as input to the program. 

Input:
    3,879483
    43,608177
    3
    1;Maison de la Prevention Sante;6 rue Maguelone 340000 Montpellier;;3,87952263361082;43,6071285339217
    2;Hotel de Ville;1 place Georges Freche 34267 Montpellier;;3,89652239197876;43,5987299452849
    3;Zoo de Lunaret;50 avenue Agropolis 34090 Mtp;;3,87388031141133;43,6395872778854

Output:
    Maison de la Prevention Sante
*/
namespace Puzzle004Defibrilators
{
    class Program
    {
        static void Main(string[] args)
        {
            string LON = Console.ReadLine().Replace(',', '.');
            string LAT = Console.ReadLine().Replace(',', '.');
            double userLon = 0.0, userLat = 0.0;
            double defbLon = 0.0, defbLat = 0.0;
            double minDistance = double.MaxValue;
            const double radianRate = Math.PI / 180.0; //one degree in radians

            if (Double.TryParse(LON, out userLon) && Double.TryParse(LAT, out userLat))
            {
                string ret = string.Empty;
                int N = int.Parse(Console.ReadLine());

                for (int i = 0; i < N; i++)
                {
                    string input = Console.ReadLine();

                    string[] DEFIB = input.Split(';');
                    if (Double.TryParse(DEFIB[4].Replace(',', '.'), out defbLon) &&
                        Double.TryParse(DEFIB[5].Replace(',', '.'), out defbLat))
                    {
                        double dlat = (defbLon * radianRate - userLon * radianRate) * Math.Cos((defbLat * radianRate + userLat * radianRate) / 2);
                        double dlon = (defbLat * radianRate - userLat * radianRate);
                        double distance = Math.Sqrt(dlat * dlat + dlon * dlon) * 6371;
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            ret = DEFIB[1];
                        }
                    }
                }

                Console.WriteLine(ret);
            }
        }
    }
}
