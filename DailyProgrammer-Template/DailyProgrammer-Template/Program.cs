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
        }
    }

    
    class Decoder
    {
        public string message = null;
        // empty constructor
        public Decoder() { }

        public Decoder(string file)
        {
            string line = null;
            using (StreamReader reader = new StreamReader("../../" + file))
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    for (int i = 0; i < line.Length; i++)
                    {
                        char getChar = line[i];
                        int asciiCoded = (int)getChar - 4;
                        message += Char.ConvertFromUtf32(asciiCoded);
                    }
                    message += "\n";
                }
            }
        }

        /// <summary>
        /// Decodes a message in a file, each char is -4 of each ascii char
        /// </summary>
        public void EncodeMessage(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char getChar = line[i];
                int asciiCoded = (int)getChar - 4;
                message += Char.ConvertFromUtf32(asciiCoded);
            }
            Console.WriteLine(message);
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

    /*    REDDIT DAILY PROGRAMMER SOLUTION TEMPLATE 
 * http://www.reddit.com/r/dailyprogrammer
 *     Your Name:  Patrick Yee
 *     Challenge Name: Easter Challenge
 *     Challenge #: 202
 *     Challenge URL: http://www.reddit.com/r/dailyprogrammer/comments/2wbvuu/20150218_challenge_202_intermediate_easter/
 *     Brief Descrtiption of Challenge:
 *      Find the day of Easter Day when given a year.  I thought that was too easy, so I did one for Thanksgiving and all
     *      of the other holidays.
 *      What was difficult about this challenge?  For Thanksgiving, if I had to count the week, if the first of month fell
     *      on a Friday or Saturday.  Figuring out when Easter Day was. Remember: I would work that day at my old job and 
     *      wouldn't know it.
 *     What was easier than expected about this challenge?  Cycling through the calendar to look for what I needed from it.
     *     I guess I could have used a lambda expression.
 *     
 *     BE SURE TO CREATE AT LEAST TWO TESTS FOR YOUR CODE IN THE TEST CLASS
 *     One test for a valid entry, one test for an invalid entry. 
 */

    // the holidays that I wanted to look at.
    enum holidays
    {
        New_Years, Valentines, Easter, St_Patrick, Independence, Halloween, Thanksgiving, Christmas
    }
    class Holiday
    {
        DateTime getDay;
        // this is a public variable so when the Print holiday is called this will be called
        public holidays Holidays;

        /// <summary>
        /// Defaults to the challenge
        /// </summary>
        public Holiday()
        {
            Holidays = holidays.Easter;
        }

        /// <summary>
        /// Get the Easter day according of the year
        /// </summary>
        /// <param name="year">input year</param>
        /// <returns>day of Easter day</returns>
        public int GetEasterDay(int year)
        {
            // checks for the first day of April
            int day = 1;
            getDay = new DateTime(year, 4, day);
            while (getDay.DayOfWeek != DayOfWeek.Sunday)
            {
                day++;
                getDay = new DateTime(year, 4, day);
            }
            return day;
        }

        public int GetThanksgivingDay(int year)
        {
            int day = 0;
            int thurdays = 0;
            while (thurdays != 4)
            {
                // need to change before the check b/c if it incrments after the check it would the wrong day.
                day++;
                getDay = new DateTime(year, 11, day);
                if (getDay.DayOfWeek == DayOfWeek.Thursday)
                {
                    thurdays++;
                }
            }
            return day;
        }

        /// <summary>
        /// Prints the day and day of the week of a range of years
        /// </summary>
        /// <param name="StartYear">Start year</param>
        /// <param name="EndYear">Ending Year</param>
        public void PrintYearsOfTheHoliday(int StartYear, int EndYear)
        {
            // the check for the Holidays variable
            int currentYear = StartYear;
            while (currentYear <= EndYear)
            {
                if (Holidays == holidays.Easter)
                {
                    Console.WriteLine("Easter Day of {0} is April {1}.", currentYear, GetEasterDay(currentYear));
                }
                if (Holidays == holidays.Christmas)
                {
                    getDay = new DateTime(currentYear, 12, 25);
                    Console.WriteLine("Christmas is {0} in {1}", getDay.DayOfWeek, currentYear);
                }
                if (Holidays == holidays.Halloween)
                {
                    getDay = new DateTime(currentYear, 10, 31);
                    Console.WriteLine("Halloween is {0} in {1}", getDay.DayOfWeek, currentYear);
                }
                if (Holidays == holidays.Independence)
                {
                    getDay = new DateTime(currentYear, 7, 4);
                    Console.WriteLine("Independence Day is {0} in {1}", getDay.DayOfWeek, currentYear);
                }
                if (Holidays == holidays.New_Years)
                {
                    getDay = new DateTime(currentYear, 1, 1);
                    Console.WriteLine("New Year's Day is a {0} in {1}", getDay.DayOfWeek, currentYear);
                }
                if (Holidays == holidays.St_Patrick)
                {
                    getDay = new DateTime(currentYear, 3, 17);
                    Console.WriteLine("St. Patrick's Day is a {0} in {1}", getDay.DayOfWeek, currentYear);
                }
                if (Holidays == holidays.Thanksgiving) { }
                if (Holidays == holidays.Valentines)
                {
                    getDay = new DateTime(currentYear, 2, 14);
                    Console.WriteLine("Valentine's Day is a {0} in {1}", getDay.DayOfWeek, currentYear);
                }
                currentYear++;

            }
        }
    }


#region " TEST CLASS "

    //We need to use a Data Annotation [ ] to declare that this class is a Test class
    [TestFixture]
    class Test
    {
        //Test classes are declared with a return type of void.  Test classes also need a data annotation to mark them as a Test function
        [Test]
        public void TestEncodeMessageForLength()
        {
            Decoder testCode = new Decoder();
            testCode.EncodeMessage("hi, name is Eric. How are you doing?");
            int result = testCode.GetNumberOfCharacters();
            //now we test for the result.
            Assert.IsTrue(result == 36, "Wrong Message");
        }

        // Test for the message change
        [Test]
        public void TestForChangeMessage()
        {
            Decoder testCode = new Decoder();
            testCode.EncodeMessage("My name is Patrick");
            string result = testCode.GetMessage();
            Assert.IsFalse(result == "My name is Patrick");
        }

        // test for a random year like 2025
    [Test]
        public void TestForThanksgiving()
        {
            Holiday testHoliday = new Holiday();
            int result = testHoliday.GetThanksgivingDay(2025);
            Assert.IsTrue(result == 27, "Wrong day for the Thanksgiving {0}", result);
        }
        
        // I defaulted to the challenge, so it would give Easter
        [Test]
    public void TestForEasterHappeningAtTheEndOfTheMonth()
    {
        Holiday testHoliday = new Holiday();
        int result = testHoliday.GetEasterDay(2015);
        Assert.IsFalse(result == 25, "Easter doesn't happen on the 25 of April");
    }
    }
#endregion
}
