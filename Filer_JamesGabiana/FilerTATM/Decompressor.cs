using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FilerTATM
{
    class Decompressor
    {
        public String StageTwoDecompression(String input)
        {
            String map = "";
            String newString;
            for (int i = 0; i < input.Length; i++)
            {
                newString = ConvertToString(input[i]);
                if (newString != "")
                {
                    map += newString;
                }
                else
                {
                    map += input[i];
                }
            }
            return map;
        }

        public String StageOneDecompression(String input)
        {
            String map = "";
            Boolean expanding = false; 
            String contents = "";
            String number = "";
            Int32 openingBrackets = 0;
            Int32 closingBrackets = 0;
            Int32 n = 0;
            Int32 previous;
            Int32 lastCharsLeft;
            for (int i = 0; i < input.Length; i++)
            {
                
                //Console.WriteLine(input[i] + " " + i);
                if (Char.IsDigit(input[i]) == true)
                {
                    if (expanding == false)
                    {
                        number += input[i];
                        if (Char.IsDigit(input[i+1]) == false && input[i+1] != '[')
                        {
                            n = Convert.ToInt32(number);
                            previous = (i+1) - number.Length;
                            lastCharsLeft = (input.Length - 1) - i;
                            if (previous > 0)
                            {
                                map += input.Substring(0, previous);
                            }
                            map += String.Concat(Enumerable.Repeat(input[i+1], n));
                            map = map.Remove(map.Length - 1, 1);
                            if (lastCharsLeft > 0)
                            {
                                map += input.Substring(i + 1, lastCharsLeft);
                            }
                            break;
                        }
                        
                    }
                    else
                    {
                        contents += input[i];
                    }
                }
                else
                {
                    if (number != "")
                    {
                        n = Convert.ToInt32(number);
                        number = "";
                    }
                    if (input[i] == '[')
                    {
                        expanding = true;
                        contents += input[i];
                        openingBrackets++;
                    }
                    else if (input[i] == ']')
                    {
                        contents += input[i];
                        closingBrackets++;
                    }
                    else
                    {
                        if (expanding == true)
                        {
                            contents += input[i];
                        }
                    }
                    if (openingBrackets == closingBrackets && expanding == true)
                    {
                        previous = ((i) - contents.Length);
                        lastCharsLeft = (input.Length - 1) - i;
                        if (previous >  0 )
                        {
                            map += input.Substring(0,previous);
                        }
                        contents = contents.Remove(contents.Length - 1, 1);
                        contents = contents.Remove(0, 1);
                        map += String.Concat(Enumerable.Repeat(contents, n));
                        if (lastCharsLeft > 0)
                        {
                            map += input.Substring(i+1, lastCharsLeft);
                        }
                        break;
                    }
                }
            }
            if (map != "")
            {
                return map;
            }
            else
            {
                return input;
            }
        }

        private String ConvertToString(Char input)
        {
            String output = "";
            switch (input)
            {
                case 'H':
                    output = ".___";
                    break;
                case 'D':
                    output = ".   ";
                    break;
                case 'S':
                    output = "    ";
                    break;
                case 'V':
                    output = "|   ";
                    break;
                case 'X':
                    output = "  X ";
                    break;
                case 'C':
                    output = "| X ";
                    break;
                case 'T':
                    output = "  T ";
                    break;
                case 'Y':
                    output = "| T ";
                    break;
                case 'M':
                    output = "  M ";
                    break;
                case 'K':
                    output = "| M ";
                    break;
                default:
                    output = "";
                    break;
            }

            return output;
        }
    }
}
