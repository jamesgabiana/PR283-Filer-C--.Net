using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilerTATM
{
    class Compressor
    {
        public String StageOneCompression(String input)
        {
            Int32 i = 0;
            String map = "";
            Char newChar;
            String tempWord = "";
            foreach (char c in input)
            {
                tempWord += c;
                if (tempWord.Length == 4)
                {
                    newChar = ConvertToChar(tempWord);
                    if (newChar != ' ')
                    {
                        map += newChar;
                        tempWord = "";
                    }
                    else
                    {
                        map += tempWord[0];
                        tempWord = tempWord.Remove(0, 1);
                    }
                    
                }
                else if (i == input.Length - 1)
                {
                    map += input[i];
                }
                i++;
            }
            return map;
        }

        public String StageTwoCompression(String input)
        {
            String temp1 = "";
            String temp2 = "";
            String stage2 = StageThreeCompression(input, "", 1, 0, "", true);
            Int32 count = 0;
            while (temp1 != stage2)
            {
                temp1 = temp2;
                if (stage2 == input)
                {
                    break;
                }
                else
                {
                    stage2 = StageThreeCompression(stage2, "", 1, count, "", true);
                }
                temp2 = stage2;
                count++;
            }
            return stage2;
        }

        // RECURSIVE method
        public String StageThreeCompression(String input, String charsLeft = "",  Int32 steps = 2,
                                            Int32 pos = 0, String map = "", Boolean stage1 = false)// RECURSIVE method
        {
            Int32 num = 1;
            Int32 count = 1;
            String temp;
            String current;

            if (pos < input.Length - (steps + 1))
            {
                temp = input.Substring(pos, steps); // starts here

                for (int i = steps + pos; i < input.Length; i += steps)
                {
                    if (pos > 0)
                    {
                        if (Char.IsDigit(input[pos - 1]) == true && Char.IsDigit(input[pos]) == false)
                        {
                            continue;// Stops 2DHDHD from becoming 22[DH]D
                        }
                    }
                    if (input.Length - i < steps)
                    {
                        charsLeft = input.Substring(i, input.Length - i);
                        break;
                    }
                    current = input.Substring(i, steps);
                    if (temp == current)
                    {
                        num++;
                    }
                    else
                    {
                        if (i < input.Length)
                        {
                            charsLeft = input.Substring(i, input.Length - i);
                        }
                        break;
                    }
                }

                if (num > 1)
                {
                    map += input.Substring(0, pos);
                    if (stage1 == true)
                    {
                        map += num.ToString() + temp;
                    }
                    else
                    {
                        map += num.ToString() + "[" + temp + "]";
                    }
                    
                    return map + charsLeft;
                }
                else
                {
                    if (count < input.Length && (pos + steps) < input.Length- steps)
                    {
                        return StageThreeCompression(input, charsLeft = "", steps, pos += 1, map, stage1);//check all similar chars
                    }
                    else
                    {
                        return StageThreeCompression(input, charsLeft = "", steps += 1, pos = 0, map, stage1);
                        //adds one character to temp and then search again. 2 chars becomes 3 and so on...
                        //RECURSION, keep trying to compress till its not compressible anymore.
                    }
                }
            }
            else
            {
                if (map != "")
                {
                    return map + charsLeft;
                }
                else
                {
                    return input;
                }
            }
        }

        private Char ConvertToChar(String input)
        {
            Char output = ' ';
            switch (input)
            {
                case ".___":
                    output = 'H';
                    break;
                case ".   ":
                    output = 'D';
                    break;
                case "    ":
                    output = 'S';
                    break;
                case "|   ":
                    output = 'V';
                    break;
                case "  X ":
                    output = 'X';
                    break;
                case "| X ":
                    output = 'C';
                    break;
                case "  T ":
                    output = 'T';
                    break;
                case "| T ":
                    output = 'Y';
                    break;
                case "  M ":
                    output = 'M';
                    break;
                case "| M ":
                    output = 'K';
                    break;
                default:
                    output = ' ';
                    break;
            }
            
            return output;
        }


    }
}
