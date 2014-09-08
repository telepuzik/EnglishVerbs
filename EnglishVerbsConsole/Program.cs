using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishVerbsConsole
{
    class VerbsList { 
        public string FormOne {get; set;}
        public string FormTwo { get; set; }
        public string FormThree { get; set; }
        public string FormFour { get; set; }
        public string FormFive { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start reading file");
            var reader = new StreamReader(File.OpenRead(@"C:\lib\list_verbs.csv"));
            List<VerbsList> VerbsListValues = new List<VerbsList>();

            while (!reader.EndOfStream) {
                var line = reader.ReadLine();
                var values = line.Split(';');
                var verbsLine = new VerbsList
                {
                    FormOne = values[0],
                    FormTwo = values[1],
                    FormThree = values[2],
                    FormFour = values[3],
                    FormFive = values[4]
                };

                VerbsListValues.Add(verbsLine);
            }

            Console.WriteLine("finished reading file");

            var answer = "";

            while (answer != "n") {
                Console.Write("Get new word(y/n)? ");
                answer = Console.ReadLine();

                if ((answer == "y") || (answer == ""))
                {
                    GetWord(VerbsListValues);
                }
            }
            Console.WriteLine("exam finished");
            Console.ReadLine();
        }

        static void GetWord(List<VerbsList> VerbsListValues)
        {
            var randomIndex = new Random();

            var verbs = VerbsListValues[randomIndex.Next(0, 9)];

            Console.WriteLine("Verb: {0}", verbs.FormOne);

            Console.Write("Enter 2 form: ");
            var form = Console.ReadLine();

            if (form != verbs.FormTwo)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong! Correct verb - {0}", verbs.FormTwo);
                Console.ResetColor();
            }
            else {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct!");
                Console.ResetColor();
            }

            Console.Write("Enter 3 form: ");
            form = Console.ReadLine();

            if (form != verbs.FormThree)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong! Correct verb - {0}", verbs.FormThree);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct!");
                Console.ResetColor();
            }

            Console.Write("Enter 4 form: ");
            form = Console.ReadLine();

            if (form != verbs.FormFour)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong! Correct verb - {0}", verbs.FormFour);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct!");
                Console.ResetColor();
            }

            Console.Write("Enter 5 form: ");
            form = Console.ReadLine();

            if (form != verbs.FormFive)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong! Correct verb - {0}", verbs.FormFive);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct!");
                Console.ResetColor();
            }
        }
    }
}
