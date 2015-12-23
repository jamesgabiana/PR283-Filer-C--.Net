using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilerTATM;

namespace UnitTestFiler
{
    [TestClass]
    public class HappyDays
    {
        FileHandler fileHandler = new FileHandler();
        MapHandler mapHandler = new MapHandler();
        FileView view = new FileView();

        //********COMPRESSION TEST**********
        [TestMethod]
        public void TestStage1Compression()
        {
            String expected = "HDSVXCTYMK";
            String result;

            //do
            result = mapHandler.CompressMap(".___.       |     X | X   T | T   M | M ");
            // assert
            Assert.AreEqual(expected, result, "TestAllCharsCompression Failed");
        }

        [TestMethod]
        public void TestLongDStage2()
        {
            String expected = "5D";
            String result;

            //do
            result = mapHandler.CompressMap(".   .   .   .   .   ");
            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLongHStage2()
        {
            String expected = "5H";
            String result;

            //do
            result = mapHandler.CompressMap(".___.___.___.___.___");
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestLongSStage2()
        {
            String expected = "5S";
            String result;

            //do
            result = mapHandler.CompressMap("                    ");
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestLongVStage2()
        {
            String expected = "5V";
            String result;

            //do
            result = mapHandler.CompressMap("|   |   |   |   |   ");
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMultipleLongCharStage2()
        {
            String expected = "3S3V3H";
            String result;

            //do
            result = mapHandler.CompressMap("            |   |   |   .___.___.___");
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestStage3Compression1()
        {
            String expected = "2[3S3V3H]";
            String result;

            //do
            result = mapHandler.CompressMap("            |   |   |   .___.___.___            |   |   |   .___.___.___");
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestStage3Compression2()
        {
            String expected = "2[SV]3[HV]2[SH]";
            String result;

            //do
            result = mapHandler.CompressMap("    |       |   .___|   .___|   .___|       .___    .___");
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestStage3_SUPER_Compression()
        {
            String expected = "2[H4[SV]]";
            String result;

            //do
            result = mapHandler.CompressMap(".___    |       |       |       |   .___    |       |       |       |   ");
            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestStage3_ULTRA_Compression()
        {
            String expected = "2[H2[SV]]5SHV";
            String result;

            //do
            result = mapHandler.CompressMap(".___    |       |   .___    |       |                       .___|   ");
            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SampleMapCompression1()
        {
            String expected = "3SD.\n" +
                              "3SC|\n" +
                              "3HDH.\n" +
                              "VY3S|\n" +
                              "3DHD.\n" +
                              "2[VS]K|\n" +
                              "DH3D.\n" +
                              "V2SVS|\n" +
                              "D2H2D.\n" +
                              "V2S2V|\n" +
                              "3DHD.\n" +
                              "V4S|\n" +
                              "5H.";
            String result, map;
            map = "            .   .\n" +
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
            //do
            result = mapHandler.CompressMap(map);
            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SampleMapCompression2()
        {
            String expected = "4S2V \n" +
                              "4HDH.\n" +
                              "K4SV|\n" +
                              "H5D.\n" +
                              "2[VS]2V|\n" +
                              "DH2DHD.\n" +
                              "4VTS|\n" +
                              "2D2[HD].\n" +
                              "2V2SVS|\n" +
                              "2DH3D.\n" +
                              "3V3S|\n" +
                              "6D.\n" +
                              "V5S|\n" +
                              "6H.";
            String result, map;
            map = "                |   |    \n" +
                  ".___.___.___.___.   .___.\n" +
                  "| M                 |   |\n" +
                  ".___.   .   .   .   .   .\n" +
                  "|       |       |   |   |\n" +
                  ".   .___.   .   .___.   .\n" +
                  "|   |   |   |     T     |\n" +
                  ".   .   .___.   .___.   .\n" +
                  "|   |           |       |\n" +
                  ".   .   .___.   .   .   .\n" +
                  "|   |   |               |\n" +
                  ".   .   .   .   .   .   .\n" +
                  "|                       |\n" +
                  ".___.___.___.___.___.___.";
            //do
            result = mapHandler.CompressMap(map);
            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SampleMapCompression3()
        {
            String expected = "S2D3S \n" +
                              "SCV3S \n" +
                              "HD4H.\n" +
                              "V4SV|\n" +
                              "DH2DHD.\n" +
                              "2[V2S]|\n" +
                              "4DHD.\n" +
                              "V2SVSV|\n" +
                              "6D.\n" +
                              "2V2S2V|\n" +
                              "H3DHD.\n" +
                              "K3STV|\n" +
                              "2DH3D.\n" +
                              "V5S|\n" +
                              "6H.";
            String result, map;
            map = "    .   .                \n" +
                  "    | X |                \n" +
                  ".___.   .___.___.___.___.\n" +
                  "|                   |   |\n" +
                  ".   .___.   .   .___.   .\n" +
                  "|           |           |\n" +
                  ".   .   .   .   .___.   .\n" +
                  "|           |       |   |\n" +
                  ".   .   .   .   .   .   .\n" +
                  "|   |           |   |   |\n" +
                  ".___.   .   .   .___.   .\n" +
                  "| M               T |   |\n" +
                  ".   .   .___.   .   .   .\n" +
                  "|                       |\n" +
                  ".___.___.___.___.___.___.";
            //do
            result = mapHandler.CompressMap(map);
            // assert
            Assert.AreEqual(expected, result);
        }


        //********DECOMPRESSION TEST**********
        [TestMethod]
        public void TestStage2Deompression()
        {
            //String expected = "HDSVXCTYMK";
            String expected = ".___.       |     X | X   T | T   M | M ";
            String result;

            //do
            result = mapHandler.DecompressMap("HDSVXCTYMK");
            // assert
            Assert.AreEqual(expected, result, "TestAllCharsCompression Failed");
        }

        [TestMethod]
        public void TestLongDStage1Decompression()
        {
            String expected = ".   .   .   .   .   ";
            String result;

            //do
            result = mapHandler.DecompressMap("5D");
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestLongHStage1Decompression()
        {
            String expected = ".___.___.___.___.___";
            String result;

            //do
            result = mapHandler.DecompressMap("5H");
            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLongSStage1Decompression()
        {
            String expected = "                    ";
            String result;

            //do
            result = mapHandler.DecompressMap("5S");
            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLongVStage1Decompression()
        {
            String expected = "|   |   |   |   |   ";
            String result;

            //do
            result = mapHandler.DecompressMap("5V");
            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMultipleLongCharDecomp()
        {
            String expected = "            |   |   |   .___.___.___";
            String result;

            //do
            result = mapHandler.DecompressMap("3S3V3H");
            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestBracketsDecompression1()
        {
            String expected = "            |   |   |   .___.___.___            |   |   |   .___.___.___";
            String result;

            //do
            result = mapHandler.DecompressMap("2[3S3V3H]");
            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestBracketsDecompression2()
        {
            String expected = "    |       |   .___|   .___|   .___|       .___    .___";
            String result;

            //do
            result = mapHandler.DecompressMap("2[SV]3[HV]2[SH]");
            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestBracketsDecompression3()
        {
            String expected = ".___    |       |       |       |   .___    |       |       |       |   ";
            String result;

            //do
            result = mapHandler.DecompressMap("2[H4[SV]]");
            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_SUPER_Decompression()
        {
            String expected = ".___    |       .___    .___    |       .___    .___    |       .___    .___    |       .___    .___.___    |       .___    .___    |       .___    .___    |       .___    .___    |       .___    .___";
            String result;

            //do
            result = mapHandler.DecompressMap("2[H4[SV2[SH]]]");
            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_GODLIKE_Decompression()
        {
            String expected = ".___    |       .___    .___    |       .___    .___    |       .___    .___    |       .___    .___.___    |       .___    .___    |       .___    .___    |       .___    .___    |       .___    .___.___    |       .___    .___    |       .___    .___    |       .___    .___    |       .___    .___.___    |       .___    .___    |       .___    .___    |       .___    .___    |       .___    .___";
            String result;

            //do
            result = mapHandler.DecompressMap("2[2[H4[SV2[SH]]]]");
            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SampleMap_Decompression1()
        {
            String expected = "            .   .\n" +
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
            String result;
            String map = "3SD.\n" +
                        "3SC|\n" +
                        "3HDH.\n" +
                        "VY3S|\n" +
                        "3DHD.\n" +
                        "2[VS]K|\n" +
                        "DH3D.\n" +
                        "V2SVS|\n" +
                        "D2H2D.\n" +
                        "V2S2V|\n" +
                        "3DHD.\n" +
                        "V4S|\n" +
                        "5H.";

            //do
            result = mapHandler.DecompressMap(map);
            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SampleMap_Decompression2()
        {
            String expected = "                |   |    \n" +
                              ".___.___.___.___.   .___.\n" +
                              "| M                 |   |\n" +
                              ".___.   .   .   .   .   .\n" +
                              "|       |       |   |   |\n" +
                              ".   .___.   .   .___.   .\n" +
                              "|   |   |   |     T     |\n" +
                              ".   .   .___.   .___.   .\n" +
                              "|   |           |       |\n" +
                              ".   .   .___.   .   .   .\n" +
                              "|   |   |               |\n" +
                              ".   .   .   .   .   .   .\n" +
                              "|                       |\n" +
                              ".___.___.___.___.___.___.";
            String result;
            String map = "4S2V \n" +
                        "4HDH.\n" +
                        "K4SV|\n" +
                        "H5D.\n" +
                        "2[VS]2V|\n" +
                        "DH2DHD.\n" +
                        "4VTS|\n" +
                        "2D2[HD].\n" +
                        "2V2SVS|\n" +
                        "2DH3D.\n" +
                        "3V3S|\n" +
                        "6D.\n" +
                        "V5S|\n" +
                        "6H.";

            //do
            result = mapHandler.DecompressMap(map);
            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SampleMap_Decompression3()
        {
            String expected = "    .   .                \n" +
                              "    | X |                \n" +
                              ".___.   .___.___.___.___.\n" +
                              "|                   |   |\n" +
                              ".   .___.   .   .___.   .\n" +
                              "|           |           |\n" +
                              ".   .   .   .   .___.   .\n" +
                              "|           |       |   |\n" +
                              ".   .   .   .   .   .   .\n" +
                              "|   |           |   |   |\n" +
                              ".___.   .   .   .___.   .\n" +
                              "| M               T |   |\n" +
                              ".   .   .___.   .   .   .\n" +
                              "|                       |\n" +
                              ".___.___.___.___.___.___.";
            String result;
            String map = "S2D3S \n" +
                        "SCV3S \n" +
                        "HD4H.\n" +
                        "V4SV|\n" +
                        "DH2DHD.\n" +
                        "2[V2S]|\n" +
                        "4DHD.\n" +
                        "V2SVSV|\n" +
                        "6D.\n" +
                        "2V2S2V|\n" +
                        "H3DHD.\n" +
                        "K3STV|\n" +
                        "2DH3D.\n" +
                        "V5S|\n" +
                        "6H.";

            //do
            result = mapHandler.DecompressMap(map);
            // assert
            Assert.AreEqual(expected, result);
        }


        //********LOAD FILE TEST**********
        [TestMethod]
        public void Test_Load()
        {
            String expected = "            .   .\n" +
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

            String result;

            //do
            result = fileHandler.LoadMap("H:\\C#\\FilerDocuments\\WriteLines7.txt");
            // assert
            Assert.AreEqual(expected, result);
        }


        //********SAVE FILE TEST**********
        [TestMethod]
        public void Test_Save()
        {
            String expected = "            .   .\n" +
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
            String result;

            //do
            fileHandler.SaveMap("H:\\C#\\FilerDocuments\\WriteLines6.txt", expected);
            result = fileHandler.LoadMap("H:\\C#\\FilerDocuments\\WriteLines6.txt");
            // assert
            Assert.AreEqual(expected, result);
        }
    }
}

