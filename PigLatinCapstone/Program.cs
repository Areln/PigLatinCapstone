using System;
//Aaron Anderson
namespace PigLatinCapstone
{
    class Program
    {
        static string vowels = "aeiou";
        static string again = "y";
        static void Main(string[] args)
        {
            while (again != "n")
            {
                Console.WriteLine(ConvertToPigLatin(PromptUser()));
                RunAgain();
            }
        }
        static void RunAgain() 
        {
            Console.WriteLine("Translate another line? (y/n)");
            again = Console.ReadLine();
        }
        static string PromptUser() 
        {
            Console.Write("Enter a word or sentence: ");
            return Console.ReadLine().ToLower();
        }
        static bool ShouldSkip(string segment) 
        {
            //if the segment contains numbers or is blank, skip it
            foreach (char letter in segment)
            {
                if (char.IsNumber(letter))
                {
                    return true;
                }
            }
            if (segment == "")
            {
                return true;
            }
            return false;
        }
        static string ConvertToPigLatin(string input)
        {

            string returnString = "";
            foreach (string segment in input.Split())
            {
                if (ShouldSkip(segment)) 
                {
                    returnString = string.Concat(returnString, segment);
                    continue;
                }
                //checks if the work starts with a vowl, if it doesnt, moves on to consonants conversion
                if (vowels.Contains(segment[0]))
                {
                    string x = string.Concat(segment, "way ");
                    returnString = string.Concat(returnString, x);
                    continue;
                }
                else
                {
                    int counter = 0;
                    foreach (char letter in segment)
                    {
                        //loops through the segment, if the letter is not a vowel add to list of characters that will move to the back
                        if (!vowels.Contains(letter))
                        {
                            counter++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    string sub1 = segment.Substring(0, counter);
                    string sub2 = segment.Substring(counter);
                    returnString += string.Concat(sub2, sub1);
                    returnString = string.Concat(returnString, "ay ");
                }
            }
            return returnString;
        }
    }
}
