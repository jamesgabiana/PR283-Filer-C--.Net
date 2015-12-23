using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;


namespace FilerTATM
{
    class FileController
    {
        IMapHandler maphandler;
        IFileView fileView;
        IFileHandler fileHandler;
        Compressor compress = new Compressor();
        Decompressor decompress = new Decompressor();

        public FileController(IMapHandler newMapHandler, IFileView newFileView, IFileHandler newFileHandler)
        {
            maphandler = newMapHandler;
            fileView = newFileView;
            fileHandler = newFileHandler;
        }

        public void Save()
        {
            String map = "            .   .\n" +
                         "            | X |\n" +
                         ".___.___.___.   .___.\n" +
                         "|   | T             |\n" +
                         ".   .   .   .___.   .\n" +
                         "|       |       | M |\n" +
                         ".   .___.   .   .   .\n" +
                         "|           |       |\n" +
                         ".   .___.___.   .   .\n" +
                         "|           |   |   |\n" +
                         ".   .   .   .___.   .\n" +
                         "|                   |\n" +
                         ".___.___.___.___.___.";
            try
            {
                fileView.Show("Below is the orinal map to be saved.", true);
                fileView.Show(map, true);
                map = maphandler.CompressMap(map);
                fileView.Show("Below shows the Compressed map that was saved.", true);
                fileView.Show(map, true);
                fileHandler.SaveMap("H:\\C#\\FilerDocuments\\ControllerSave.txt", map);
            }
            catch (InvalidInputError ex)
            {
                Console.WriteLine(ex.Message);
                //throw invalidInput; // For testing purposes, Please uncomment this
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not Saved!, Please input the correct location");
                //throw ex; // For testing purposes, Please uncomment this
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
                //throw ex; // For testing purposes, Please uncomment this
            }

            //fileView.Stop();
        }

        public void Load()
        {
            try
            {
                String map = fileHandler.LoadMap("H:\\C#\\FilerDocuments\\ControllerSave.txt");
                map = maphandler.DecompressMap(map);
                fileView.Show("Below shows the Decompressed map loaded from file.", true);
                fileView.Show(map, true);
                fileView.Stop();
            }
            catch (InvalidInputError ex)
            {
                Console.WriteLine(ex.Message);
                //throw invalidInput; // For testing purposes, Please uncomment this
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found!, Please input the correct location");
                //throw ex; // For testing purposes, Please uncomment this
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
                //throw ex; // For testing purposes, Please uncomment this
            }

            fileView.Stop();

        }

        public void test()
        {
            String map = ".___    |       |   .___    |       |                       .___|   ";
            fileView.Show("The Original String", true);
            fileView.Show("", true);
            fileView.Show(map, true);
            fileView.Show("", true);
            map = maphandler.CompressMap(map);
            fileView.Show("Stage 3 Compression", true);
            fileView.Show(map, true);
            fileView.Show("", true);
            fileView.Stop();
        }

        public void testDecomp()
        {
            String map = fileHandler.LoadMap("H:\\C#\\FilerDocuments\\InvalidCharacters.txt");
            fileView.Show(map, true);
            fileView.Show("Please try Again", true);
            Console.ReadKey();
            //fileView.Stop();
        }
    }
}
