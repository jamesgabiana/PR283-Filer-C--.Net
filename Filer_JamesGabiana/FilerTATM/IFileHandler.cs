using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilerTATM
{
    interface IFileHandler
    {
        String LoadMap(String input);
        void SaveMap(String path, String input);
    }
}
