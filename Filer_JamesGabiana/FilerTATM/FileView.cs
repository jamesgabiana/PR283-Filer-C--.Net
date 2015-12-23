using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilerTATM
{
    public class FileView : IFileView
    {

        public void Start()
        {
            Console.Clear();
        }

        public void Stop()
        {
            Console.WriteLine("Press any key to finish...");
            Console.ReadKey();
        }

        public Int32 GetNumber(String input)
        {
            Console.WriteLine(input);

            var userInput = Console.ReadLine();
            try
            {
                return Int32.Parse(userInput);

            }
            catch
            {
                return GetNumber(input);
            }
        }

        public void Show<T>(T message, Boolean isNewLine)
        {
            if (isNewLine == true)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.Write(message + " ");
            }

        }

        public String GetString(String input)
        {
            Console.WriteLine(input);
            return Console.ReadLine();
        }
    }
}
