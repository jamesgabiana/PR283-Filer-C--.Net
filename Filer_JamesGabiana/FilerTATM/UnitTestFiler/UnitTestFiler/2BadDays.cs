using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilerTATM;
namespace UnitTestFiler
{
    [TestClass]
    public class BadDays
    {
        FileHandler fileHandler = new FileHandler();
        //InvalidInputError invalidinput;
        

        //PLEASE UNCOMMENT THE THROW EXEPTION ON THE FILEHANDLER for this to work

        //********BAD DAY LOAD FILE TEST**********
        /*
        [TestMethod]
        public void Test_Load_Multiple_Theseus_Err()//Please uncomment the 'throw invalidInput' in LoadMap method in FileHandler class for this to work
        {
            String expected = "There must be only one Theseus, there are 3 Theseus on the map";
            try
            {
                //do
                fileHandler.LoadMap("H:\\C#\\FilerDocuments\\WriteLinesMultipleTheseus.txt");//Please uncomment the 'throw invalidInput' in LoadMap method in FileHandler class for this to work
                Assert.Fail("An exception should have been thrown");
            }
            catch (InvalidInputError ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);
            }
        }
        
        [TestMethod]
        public void Test_Load_No_Theseus_Err()//Please uncomment the 'throw invalidInput' in LoadMap method in FileHandler class for this to work
        {
            String expected = "Theseus is not found on the map, Please edit the map";
            try
            {
                //do
                fileHandler.LoadMap("H:\\C#\\FilerDocuments\\NoTheseus.txt");//Please uncomment the 'throw invalidInput' in LoadMap method in FileHandler class for this to work
                Assert.Fail("An exception should have been thrown");
            }
            catch (InvalidInputError ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void Test_Load_Multiple_Minotaur_Err()//Please uncomment the 'throw invalidInput' in LoadMap method in FileHandler class for this to work
        {
            String expected = "There must be only one Minotaur, there are 3 Minotaur on the map";
            try
            {
                //do
                fileHandler.LoadMap("H:\\C#\\FilerDocuments\\WriteLinesMultipleMinotaur.txt");//Please uncomment the 'throw invalidInput' in LoadMap method in FileHandler class for this to work
                Assert.Fail("An exception should have been thrown");
            }
            catch (InvalidInputError ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void Test_Load_No_Minotaur_Err()//Please uncomment the throw exception in FileHandler class for this to work
        {
            String expected = "Minotaur is not found on the map, Please edit the map";
            try
            {
                //do
                fileHandler.LoadMap("H:\\C#\\FilerDocuments\\NoMinotaur.txt");//Please uncomment the throw exception in FileHandler class for this to work
                Assert.Fail("An exception should have been thrown");

            }
            catch (InvalidInputError ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void Test_Load_No_Exit_Err()//Please uncomment the throw exception in FileHandler class for this to work
        {
            String expected = "Exit is not found on the map, please put an exit on the map";
            try
            {
                //do
                fileHandler.LoadMap("H:\\C#\\FilerDocuments\\WriteLinesNoExit.txt");//Please uncomment the throw exception in FileHandler class for this to work
                Assert.Fail("An exception should have been thrown");

            }
            catch (InvalidInputError ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void Test_Load_InvalidFile_Format_Err()//Please uncomment the throw exception in FileHandler class for this to work
        {
            String expected = "Invalid File Format, closing bracket \']\' found before open bracket, missing \'[\'";
            try
            {
                //do
                fileHandler.LoadMap("H:\\C#\\FilerDocuments\\InvalidBrackets.txt");//Please uncomment the throw exception in FileHandler class for this to work
                Assert.Fail("An exception should have been thrown");

            }
            catch (InvalidInputError ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void Test_Load_InvalidFile_Format_Err2()//Please uncomment the throw exception in FileHandler class for this to work
        {
            String expected = "Invalid File Format, Number of closing and opening brackets are not equal\n" +
                        "Number of opening brackets is 2, Number of closing brackets is 1";
            try
            {
                //do
                fileHandler.LoadMap("H:\\C#\\FilerDocuments\\InvalidBrackets2.txt");//Please uncomment the throw exception in FileHandler class for this to work
                Assert.Fail("An exception should have been thrown");

            }
            catch (InvalidInputError ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void Test_Load_Invalid_Chars_Err()//Please uncomment the throw exception in FileHandler class for this to work
        {
            String expected = "Invalid File Format, " + "\"A\"" + " is invalid character";
            try
            {
                //do
                fileHandler.LoadMap("H:\\C#\\FilerDocuments\\InvalidCharacters.txt");//Please uncomment the throw exception in FileHandler class for this to work
                Assert.Fail("An exception should have been thrown");

            }
            catch (InvalidInputError ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);

            }
        }

        [TestMethod]
        public void Test_Load_InvalidFileLocation_Err()//Please uncomment the throw exception in FileHandler class for this to work
        {
            String expected = "File Failed to load!, Please select a .txt file\nError: H:\\C#\\FilerDocuments\\InvalidCharacters.xt";
            try
            {
                //do
                fileHandler.LoadMap("H:\\C#\\FilerDocuments\\InvalidCharacters.xt");//Please uncomment the throw exception in FileHandler class for this to work
                Assert.Fail("An exception should have been thrown");

            }
            catch (InvalidInputError ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);

            }
        }


        //********BAD DAY SAVE FILE TEST**********

        [TestMethod]
        public void Test_Save_Multiple_Theseus_Err()//Please uncomment the 'throw invalidInput' in LoadMap method in FileHandler class for this to work
        {
            String expected = "There must be only one Theseus, there are 3 Theseus on the map";
            String input = "TTT";
            try
            {
                //do
                fileHandler.SaveMap("H:\\C#\\FilerDocuments\\SaveTest.txt", input);//Please uncomment the 'throw invalidInput' in LoadMap method in FileHandler class for this to work
                Assert.Fail("An exception should have been thrown");
            }
            catch (InvalidInputError ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);
            }
        }
        
        [TestMethod]
        public void Test_Save_No_Theseus_Err()//Please uncomment the 'throw invalidInput' in LoadMap method in FileHandler class for this to work
        {
            String expected = "Theseus is not found on the map, Please edit the map";
            String input = "XM";
            try
            {
                //do
                fileHandler.SaveMap("H:\\C#\\FilerDocuments\\SaveTest.txt", input);//Please uncomment the 'throw invalidInput' in LoadMap method in FileHandler class for this to work
                Assert.Fail("An exception should have been thrown");
            }
            catch (InvalidInputError ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void Test_Save_Multiple_Minotaur_Err()//Please uncomment the 'throw invalidInput' in LoadMap method in FileHandler class for this to work
        {
            String expected = "There must be only one Minotaur, there are 3 Minotaur on the map";
            String input = "TXMMM";
            try
            {
                //do
                fileHandler.SaveMap("H:\\C#\\FilerDocuments\\SaveTest.txt", input);//Please uncomment the 'throw invalidInput' in LoadMap method in FileHandler class for this to work
                Assert.Fail("An exception should have been thrown");
            }
            catch (InvalidInputError ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void Test_Save_No_Minotaur_Err()//Please uncomment the throw exception in FileHandler class for this to work
        {
            String expected = "Minotaur is not found on the map, Please edit the map";
            String input = "TX";
            try
            {
                //do
                fileHandler.SaveMap("H:\\C#\\FilerDocuments\\SaveTest.txt", input);//Please uncomment the throw exception in FileHandler class for this to work
                Assert.Fail("An exception should have been thrown");

            }
            catch (InvalidInputError ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void Test_Save_No_Exit_Err()//Please uncomment the throw exception in FileHandler class for this to work
        {
            String expected = "Exit is not found on the map, please put an exit on the map";
            String input = "TM";
            try
            {
                //do
                fileHandler.SaveMap("H:\\C#\\FilerDocuments\\SaveTest.txt", input);//Please uncomment the throw exception in FileHandler class for this to work
                Assert.Fail("An exception should have been thrown");

            }
            catch (InvalidInputError ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void Test_Save_InvalidFile_Format_Err()//Please uncomment the throw exception in FileHandler class for this to work
        {
            String expected = "Invalid File Format, closing bracket \']\' found before open bracket, missing \'[\'";
            String input = "TMX][";
            try
            {
                //do
                fileHandler.SaveMap("H:\\C#\\FilerDocuments\\SaveTest.txt", input);//Please uncomment the throw exception in FileHandler class for this to work
                Assert.Fail("An exception should have been thrown");

            }
            catch (InvalidInputError ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void Test_Save_InvalidFile_Format_Err2()//Please uncomment the throw exception in FileHandler class for this to work
        {
            String expected = "Invalid File Format, Number of closing and opening brackets are not equal\n" +
                        "Number of opening brackets is 2, Number of closing brackets is 1";
            String input = "TMX[[]";
            try
            {
                //do
                fileHandler.SaveMap("H:\\C#\\FilerDocuments\\SaveTest.txt", input);//Please uncomment the throw exception in FileHandler class for this to work
                Assert.Fail("An exception should have been thrown");

            }
            catch (InvalidInputError ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void Test_Save_Invalid_Chars_Err()//Please uncomment the throw exception in FileHandler class for this to work
        {
            String expected = "Invalid File Format, " + "\"A\"" + " is invalid character";
            String input = "TMXA";
            try
            {
                //do
                fileHandler.SaveMap("H:\\C#\\FilerDocuments\\SaveTest.txt", input);//Please uncomment the throw exception in FileHandler class for this to work
                Assert.Fail("An exception should have been thrown");

            }
            catch (InvalidInputError ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);

            }
        }*/

        [TestMethod]
        [ExpectedException(typeof(InvalidInputError))]
        public void Test_Load_Multiple_Theseus_Err()//Please uncomment the 'throw invalidInput' in LoadMap method in FileHandler class for this to work
        {

            String actual = fileHandler.LoadMap("H:\\C#\\FilerDocuments\\WriteLinesMultipleTheseus.txt");
        }
        
    }
}
