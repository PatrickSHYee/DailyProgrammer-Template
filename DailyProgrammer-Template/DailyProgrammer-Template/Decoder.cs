using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework; //test classes need to have the using statement

/*    REDDIT DAILY PROGRAMMER SOLUTION TEMPLATE 
 * http://www.reddit.com/r/dailyprogrammer
 *     Your Name:  Patrick Yee
 *     Challenge Name: Simple Decoder
 *     Challenge #: 156
 *     Challenge URL: http://www.reddit.com/r/dailyprogrammer/comments/21w3lb/412014_challenge_156_easy_simple_decoder/
 *     Brief Descrtiption of Challenge:
 *      We are given a messed up messaged that one of moderators where we have to decode the message.
 *      What was difficult about this challenge?  I couldn't cast the ascii integer to a type of a char.  I had to figure out
 *        how to convert the integer ascii char to the char.  I had to be more carefully about the wording of the problem.
 *     What was easier than expected about this challenge?  The code.
 *     
 *     BE SURE TO CREATE AT LEAST TWO TESTS FOR YOUR CODE IN THE TEST CLASS
 *     One test for a valid entry, one test for an invalid entry. 
 */

namespace DailyProgrammer_Template
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Decoder> normalMessage = new List<Decoder>();
            using (StreamReader reader = new StreamReader("../../message.txt")){
                while (!reader.EndOfStream)
                {
                    normalMessage.Add(new Decoder(reader.ReadLine()));
                }
            }

            normalMessage.ForEach(x => Console.WriteLine(x.message));
        }
    }

    class Decoder
    {
        public string message = null;
        // constructor
        public Decoder(string inputLine)
        {

            for (int i = 0; i < inputLine.Length; i++)
            {
                char getCharacter = inputLine[i];
                int asciiConvert = (int)getCharacter - 4;
                message += Char.ConvertFromUtf32(asciiConvert);
            }
        }

        public int GetNumberOfCharacters()
        {
            return message.Length;
        }

        public string GetMessage()
        {
            return message;
        }
    }


#region " TEST CLASS "

    //We need to use a Data Annotation [ ] to declare that this class is a Test class
    [TestFixture]
    class Test
    {
        //Test classes are declared with a return type of void.  Test classes also need a data annotation to mark them as a Test function
        [Test]
        public void MyValidTest()
        {
            Decoder testCode = new Decoder("hi, name is Eric. How are you doing?");
            //inside of the test, we can declare any variables that we'll need to test.  Typically, we will reference a function in your main program to test.
            int result = testCode.GetNumberOfCharacters();  // this function should return 15 if it is working correctly
            //now we test for the result.
            Assert.IsTrue(result == 36, "This is the message that displays if it does not pass");
            // The format is:
            // Assert.IsTrue(some boolean condition, "failure message");
        }

        [Test]
        public void MyInvalidTest()
        {
            Decoder testCode = new Decoder("My name is Patrick.");
            string result = testCode.GetMessage();
            Assert.IsFalse(result == "My name is Patrick");
        }
    }
#endregion
}
