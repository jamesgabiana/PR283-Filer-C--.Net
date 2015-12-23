using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilerTATM
{
    interface IFileView
    {
        void Start();
        void Stop();
        Int32 GetNumber(String input);
        void Show<T>(T message, Boolean isNewLine);
        String GetString(String input);
    }
}
