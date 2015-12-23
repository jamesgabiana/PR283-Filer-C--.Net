using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FilerTATM
{
    public class FileHandler : IFileHandler
    {
        Regex regex = new Regex(@"[^0-9\\[\]HDSVXCTYMK .|_\r\n]+");
        InvalidInputError invalidInput;

        private String ValidateMap(String map)
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

        public String LoadMap(String input) 
        {
            StringBuilder map = new StringBuilder();
            String checkChar;
            String txt;

            //try
            //{
                txt = input.Substring((input.Length) - 4, 4);
                if (txt != ".txt")
                {
                    invalidInput = new InvalidInputError("File Failed to load!, Please select a .txt file\nError: " + input);
                    //new ArgumentOutOfRangeException("File Failed to load!, Please select a .txt file");
                    throw invalidInput;
                }
                if (!File.Exists(@input))
                {
                    throw new FileNotFoundException();
                }
                checkChar = ValidateMap(@File.ReadAllText(input));
                if (checkChar != "")
                {
                    invalidInput = new InvalidInputError(checkChar);
                    throw invalidInput;
                }
                map.Append(@File.ReadAllText(input));
                Console.WriteLine("FILE LOADED");
            //}
            //catch (InvalidInputError)
            //{

            //    Console.WriteLine(invalidInput.Message);
            //    throw invalidInput; // For testing purposes, Please uncomment this
            //}
            //catch (FileNotFoundException ex)
            //{
            //    Console.WriteLine("File not found!, Please input the correct location");
            //    //throw ex; // For testing purposes, Please uncomment this
            //}
            //catch (ArgumentOutOfRangeException ex)
            //{
            //    Console.WriteLine(ex);
            //    //throw ex; // For testing purposes, Please uncomment this
            //}
            return map.ToString();
        
        }

        public void SaveMap(String path, String input)
        {
            String txt;
            String checkChar;
                txt = path.Substring((@path.Length) - 4, 4);
                if (txt != ".txt")
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (!File.Exists(@path))
                {
                    throw new FileNotFoundException();
                }
                checkChar = ValidateMap(input);
                if (checkChar != "")
                {
                    invalidInput = new InvalidInputError(checkChar);
                    throw invalidInput;
                }
                else
                {
                    File.WriteAllText(@path, input);
                    Console.WriteLine("FILE SAVED");
                }
                
            //catch (InvalidInputError)
            //{
            //    Console.WriteLine(invalidInput.Message);
            //    //throw invalidInput; // For testing purposes, Please uncomment this
            //} 
            //catch (ArgumentOutOfRangeException ex)
            //{
            //    Console.WriteLine("File Failed to save!, make sure its a .txt file");
            //    //throw ex; // For testing purposes, Please uncomment this
            //}
            //catch (FileNotFoundException ex)
            //{
            //    Console.WriteLine("File Failed to save!, Please input the correct location");
            //    //throw ex; // For testing purposes, Please uncomment this
            //}
        }
    }
}
