/*
 Author   : Mrudhula Murali
 Date     : 09/21/2019
 Comments : This console application helps to solve the basic algorithms
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammingIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b = 22;
            printselfDivNums(a, b);

            int n2 = 5;
            printSeries(n2);

            int n3 = 5;
            printTriangle(n3);

            int[] J = new int[] { 1, 3 };
            int[] S = new int[] { 1, 3, 3, 2, 2, 2, 2, 2 };
            int r4 = numJewelsInStones(J, S);
            Console.WriteLine(r4);

            int[] arr1 = new int[] { 1, 2, 5, 6, 7, 8, 9 };
            int[] arr2 = new int[] { 1, 2, 3, 4, 5 };
            int[] r5 = getLargestCommonSubArray(arr1, arr2);
            if (r5.Length == 0)
                Console.WriteLine("There are no common subarray ");
            foreach (int value in r5)
                Console.Write(value + " ");

            solvePuzzle();

            Console.ReadLine();
        }

        //This method prints all the self-dividing numbers between startNum and endNum.
        public static void printselfDivNums(int startNum, int endNum)
        {
            try
            {
                Console.WriteLine("The self dividing numbers between " + startNum + " and " + endNum + " : ");

                //Here we loop through the numbers between start range and end range.
                for (int i = startNum; i <= endNum; i++)
                {
                    //Call this method to check whether the number is self dividing
                    if (isSelfDividing(i))
                        //print the number if the number is self dividing
                        Console.Write(i + " ");

                }//end of for loop
                Console.ReadLine();

            }//end of try 
            catch
            {
                Console.WriteLine("Exception occured while computing printselfDivNums");
            }

        }

        //This method checks whether a number is self dividing.
        public static bool isSelfDividing(int selfDivNum)
        {
            try
            {
                //Here the isSelfDivide variable is used to track whether the number is divisible by its digits,
                //by default it is set to false.
                bool isSelfDivide = false;
                //To get the last digit of a number , we take modulus of 10.
                int endDigit = selfDivNum % 10;
                //save the original selfDivNum variable value to divNumCopy
                int divNumCopy = selfDivNum;

                //Loop to check whether we have more digits to be processed.
                while (endDigit != 0)
                {
                    //check whether the number is fully divisible by the digit
                    if (selfDivNum % endDigit == 0)
                    {
                        //If divisible set the isSelfDivide varaible to true.
                        isSelfDivide = true;
                    }
                    else
                    {
                        //set the variable to false and break from loop if the number is not divisible.
                        isSelfDivide = false;
                        break;
                    }
                    //divide the number by 10 to get the number excluding the last digit of the number.
                    divNumCopy = divNumCopy / 10;
                    //get the last digit of the new number from above step.
                    endDigit = divNumCopy % 10;
                }

                //return whether the number is self dividing.
                return isSelfDivide;


            }//end of try loop
            catch
            {
                Console.WriteLine("Exception occured while computing isSelfDividing");
                return false;
            }//end of catch loop
        }

        /*This method prints the following series till n terms:
         1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5, 6, 6 …. n terms*/
        public static void printSeries(int n)
        {
            try
            {
                Console.WriteLine("The number of terms of the series for  " + n + " : ");

                // this for lopp checks the total number of patterns being printed.
                for (int i = 1; n != 0; i++)
                {
                    //initialise a temp variable to use it as a counter for the number.
                    int temp = i;
                    // the while will print the number until the number is printed n times ie 2 will print 2 2.
                    while (temp != 0 && n != 0)
                    {
                        Console.Write(i + " ");
                        temp--;
                        n--;
                    }
                }//end of for loop
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSeries()");
            }
        }

        //This method prints an inverted triangle using *
        public static void printTriangle(int n)
        {
            try
            {
                for (int i = n; i > 0; i--)
                {
                    // this for loop will print the spaces in the starting of the inverted triangle to 
                    //maintain its inverted shape
                    for (int k = i; k <= n; k++)
                    {
                        Console.Write("  ");
                    }
                    //this for loop will print the * in the shape of the inverted triangle 
                    for (int j = 0; j < ((2 * i) - 1); j++)
                    {
                        Console.Write(" *");
                    }
                    //this will print a enter after each row of * 
                    Console.WriteLine("\n");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }

        /*You're given an array J representing the types of stones that are 
         jewels, and S representing the stones you have.Each element in S is a type of
         stone you have.You want to know how many of the stones you have are also jewels.*/
        public static int numJewelsInStones(int[] J, int[] S)
        {
            try
            {
                //initialise the jewel count to 0.
                int jewelCount = 0;
                //take each element in Jewel array
                foreach (int jewel in J)
                {
                    //take each element in stones array
                    foreach (int stone in S)
                    {
                        //check if there is a jewel in stone array and increment the jewel count if there is a match.
                        if (jewel == stone)
                            jewelCount++;
                    }
                }
                return jewelCount;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing numJewelsInStones()");
            }

            return 0;
        }

        /*This method finds the largest common contiguous subarray from two 
         sorted arrays. The given arrays are sorted in ascending order. If there are multiple 
         arrays with the same length, then return the last array having the maximum length.*/
        public static int[] getLargestCommonSubArray(int[] a, int[] b)
        {
            try
            {
                ArrayList myList = new ArrayList();
                ArrayList myListCopy = new ArrayList();
                //take this for loop to loop through all the elements in the first array
                for (int i = 0; i < a.Length; i++)
                {
                    bool matchFlag = false;
                    int firstLoop = i;
                    myList = new ArrayList();
                    //take this for loop to loop through each element in b array and checking a match with each element of first array.
                    for (int j = 0; j < b.Length && firstLoop < a.Length; j++)
                    {
                        //check if the element in a is matching with the element in second array.
                        if (a[firstLoop] == b[j])
                        {
                            //Add the matching subarray to the ArrayList.
                            myList.Add(a[firstLoop]);
                            matchFlag = true;
                            firstLoop++;
                        }
                        else if (matchFlag)
                        {
                            if (myList != null)
                            {
                                //store the first common subarray to the myListCopy array and free the myList 
                                //array list for further processing
                                if (myListCopy.Count == 0)
                                {
                                    myListCopy = myList;
                                }
                                else
                                {
                                    // if there is a new subarray with greater length copy it to the original output arraylist.
                                    if (myListCopy.Count <= myList.Count)
                                    {
                                        myListCopy = myList;
                                    }
                                }

                            }
                            break;
                        }
                    }//end of inner for loop
                    //store the value in outside for loop to store the value for the last element.
                    if (myListCopy.Count <= myList.Count)
                    {
                        myListCopy = myList;
                    }
                }//end of outer for loop
                int[] c = new int[myListCopy.Count];
                int listCount = 0;
                //convert the arraylist to array to return the array to the calling function.
                foreach (int value in myListCopy)
                {
                    c[listCount] = value;
                    listCount++;
                }
                return c;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getLargestCommonSubArray()");
                return null;
            }
        }

        /*The method should ask the user for the two input strings (e.g. uber, cool) and the 
          output string (e.g. uncle) and identify a set of number assignments that solve the 
          puzzle and print out the numbers.*/
        public static void solvePuzzle()
        {
            try
            {
                string string1 = GetInput("Input your first string : ");
                string string2 = GetInput("Input your second string : ");
                string outputString = GetInput("Input your output string : ");
                char[] char1 = IdentifyUniqueCharacters(string1);
                char[] char2 = IdentifyUniqueCharacters(string2);
                char[] char3 = IdentifyUniqueCharacters(outputString);
                char[] char4 = char1.Concat(char2).Distinct().ToArray();
                char[] char5= char4.Concat(char3).Distinct().ToArray();
                TestAssignedValues(char1, char2, char3, char5);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing solvePuzzle()");
            }
        }

        //method to collect inputs
        public static string GetInput(string message)
        {
            try
            {
                Console.WriteLine(message);
                string inputVaraiable = Console.ReadLine();
                return inputVaraiable;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing solvePuzzle()");
                return null;
            }
        }

        //method to identify unique characters in the given string.
        public static char[] IdentifyUniqueCharacters(string stringValue)
        {
            try
            {
                char[] character = new char[stringValue.Length];
                character = stringValue.ToArray();

                return character;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing solvePuzzle()");
                return null;
            }
        }

        //method to test the currently assigned values to solve the puzzle.
        public static bool TestAssignedValues(char[] char1, char[] char2, char[] char3, char[] charArray)
        {
            try
            {
                Dictionary<char, int> characterMap = new Dictionary<char, int>();
                int i = 0, val1 = 0, val2 = 0, val3 = 0;
                for(int a=0; a<=9;a++)
                {
                    for (int b = 0; b <= 9; b++)
                    {
                        if (a == b) continue;
                        for (int c = 0; c <= 9; c++)
                        {
                            if ((a == c) || (b == c)) continue;
                            for (int d = 0; d <= 9; d++)
                            {
                                if ((a == d) || (b == d) || ( c ==d )) continue;
                                for (int e = 0; e <= 9; e++)
                                {
                                    if ((a == e) || (b == e) || (c == e) || (d == e)) continue;
                                    for (int f = 0; f <= 9; f++)
                                    {
                                        if ((a == f) || (b == f) || (c == f) || (d == f) || (e == f)) continue;
                                        for (int g = 0; g <= 9; g++)
                                        {
                                            if ((a == g) || (b == g) || (c == g) || (d == g) || (e == g) || (f == g)) continue;
                                            for (int h = 0; h <= 9; h++)
                                            {
                                                if ((a == h) || (b == h) || (c == h) || (d == h) || (e == h) || (f == h) || (g ==h)) continue;

                                                characterMap.Add(charArray[0], a);
                                                characterMap.Add(charArray[1], b);
                                                characterMap.Add(charArray[2], c);
                                                characterMap.Add(charArray[3], d);
                                                characterMap.Add(charArray[4], e);
                                                characterMap.Add(charArray[5], f);
                                                characterMap.Add(charArray[6], g);
                                                characterMap.Add(charArray[7], h);
                                                for (int j = char1.Length-1,x=0; j >= 0 ; j--,x++)
                                                {
                                                    val1 = val1 + characterMap[char1[j]] * (int)Math.Pow(10, x);
                                                    val2 = val2 + characterMap[char2[j]] * (int)Math.Pow(10 ,x);
                                                }
                                                for (int j = char3.Length-1, x = 0; j >= 0; j--,x++)
                                                {
                                                    val3 = val3+characterMap[char3[j]] * (int)Math.Pow(10 , x);
                                                }
                                                if (val1 + val2 == val3)
                                                {
                                                    foreach (KeyValuePair<char, int> character in characterMap)
                                                    {
                                                        Console.WriteLine("Key: {0}, Value: {1}",
                                                            character.Key, character.Value);
                                                    }
                                                }
                                                   
                                                characterMap.Clear();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
               
                return false;


                //return character;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception occured while computing solvePuzzle()");
                return false;
            }
        }




    }



}

