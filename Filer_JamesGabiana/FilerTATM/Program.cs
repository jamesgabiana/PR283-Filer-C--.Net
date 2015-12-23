using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilerTATM
{
    class Program
    {
        static void Main(string[] args)
        {
            new FileController(new MapHandler(), new FileView(), new FileHandler()).Save();
            new FileController(new MapHandler(), new FileView(), new FileHandler()).Load();
            //new FileController(new MapHandler(), new FileView(), new FileHandler()).testDecomp();

        }
    }
}
