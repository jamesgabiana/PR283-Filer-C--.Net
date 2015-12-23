using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FilerTATM
{
    class Validator
    {
        Regex regex = new Regex(@"[^0-9\\[\]HDSVXCTYMK .|_\r\n]+");
        public String ValidateMap(String map)
        {
            Int32 countM = 0, countT = 0, countX = 0, openBracket = 0, closingbracket = 0;
            Boolean isFirstOpenBracket = false;

            for (int i = 0; i < map.Length; i++)
            {
                if (regex.IsMatch(Convert.ToString(map[i])))
                {
                    return "Invalid File Format, " + "\"" + Convert.ToString(map[i]) + "\"" + " is invalid character";
                }
                if (map[i] == 'M' || map[i] == 'K')
                {
                    countM++;
                }
                if (map[i] == 'T' || map[i] == 'Y')
                {
                    countT++;
                }
                if (map[i] == 'X' || map[i] == 'C')
                {
                    countX++;
                }
                if (map[i] == '[')
                {
                    isFirstOpenBracket = true;
                    openBracket++;
                }
                if (map[i] == ']' && isFirstOpenBracket == false)
                {
                    return "Invalid File Format, closing bracket \']\' found before open bracket, missing \'[\'";
                }
                else if (map[i] == ']')
                {
                    closingbracket++;
                }
            }
            if (openBracket != closingbracket)
            {
                return "Invalid File Format, Number of closing and opening brackets are not equal\n" +
                        "Number of opening brackets is " + openBracket + ", Number of closing brackets is " + closingbracket;
            }
            if (countT > 1)
            {
                return "There must be only one Theseus, there are " + countT + " Theseus on the map";
            }
            else if (countT == 0)
            {
                return "Theseus is not found on the map, Please edit the map";
            }
            if (countM > 1)
            {
                return "There must be only one Minotaur, there are " + countM + " Minotaur on the map";
            }
            else if (countM == 0)
            {
                return "Minotaur is not found on the map, Please edit the map";
            }
            if (countX == 0)
            {
                return "Exit is not found on the map, please put an exit on the map";
            }

            return "";
        }

    }
}
