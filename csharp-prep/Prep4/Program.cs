using System;

class Program
{
    static void Main(string[] args)
    {
         bool playing = true;
        bool success = true;
        string tempchoice = "";
        int tempint = 1;
        int sum = 0;
        float average = 0;
        int greatest = 0;
        int smallest = 1000000;
        List<int> enterList = new List<int>();

        while (playing)
        {
            enterList.Clear();
            System.Console.WriteLine("Enter a list of integers, enter 0 when finished.");
            
            while (tempint != 0)
            {
                System.Console.WriteLine("Enter Number: ");
                success = false;
                while (!success)
                {
                     try
                        {
                            tempint = int.Parse(Console.ReadLine());
                            success = true;
                        }
                    catch (System.FormatException)
                        {
                            Console.Write("Oops! Please enter only the number and in integer form. ");
                        }
                }
                if (tempint != 0)
                {
                    enterList.Add(tempint);
                }
                
            }

            for (int i = 0; i < enterList.Count; i++)
            {
                sum += enterList[i];
                if (enterList[i] >= greatest)
                {
                    greatest = enterList[i];
                }
                if (enterList[i] > 0 && enterList[i] <= smallest)
                {
                    smallest = enterList[i];
                }
                enterList.Sort();
            }
            average = sum / enterList.Count();

            System.Console.WriteLine($"The Sum of your list is: {sum}\nThe average of your list is {average:N3}\nThe Largest Number: {greatest}\nThe smallest positive number: {smallest}\n");
            System.Console.WriteLine("Here is your list sorted from least to greatest:");
            for (int i = 0; i < enterList.Count; i++)
            {
                System.Console.WriteLine(enterList[i]);
            }


            success = false;
            while (!success)
            {
                Console.WriteLine("Would you like to go again? (Y/n) ");
                tempchoice = Console.ReadLine();
                if ((tempchoice.ToLower() == "y") || (tempchoice.ToLower() == "n"))
                {
                    success = true;
                }
                else
                {
                    Console.WriteLine("Invalid Entry, Please try again. ");
                }
            }
            
            if (tempchoice.ToLower() == "n")
            {
                playing = false;
                Console.WriteLine("See you next time!");
            }

        }
    }
}