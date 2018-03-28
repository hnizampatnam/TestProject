using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApps
{
    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new TestApps.Program();
            //int[] intArray = new int[] {0,0,1,1,3,5,6,7,7 };
            //int[] intArray = new int[] { 3, 3, 3, 3, 3, 3, 3, 3, 3 };
            //int[] intArray = new int[] { 0, 0, 1, 2, 3, 5, 6, 2, 7 };
            int totalNos = 9;
            int[] intArray = obj.ReadNumbers(totalNos);
            Console.WriteLine("Input array ");
            for (int i = 0; i < totalNos; i++)
            {
                Console.Write(intArray[i].ToString()+ ",");
            }
            Console.WriteLine();
            Console.Write("Max Time : ");
            obj.GetMaxTime(intArray);
        }
        private int[] ReadNumbers(int cnt)
        {
            int n;
            int[] intArray = new int[9];
            Console.WriteLine("enter number of conversations");
            for (int i = -1; i < cnt-1; )
            {
                if (int.TryParse(Console.ReadLine(), out n))
                {
                    if (n <= 9)
                    {
                        i++;
                        intArray[i] = n;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input , Enter only number which are <=9");
                }
            }
            
            return intArray;
        }
        private void GetMaxTime(int[] intArray)
        {
            /*
             HH:MM:SS
             1. Need to prepare two digit numbers with given set
             2. Need to pick max number from the above list which is <=12 it will be hours
             3. Remove the main array with the hours digits
             4. Need to prepare two digit array with this new array
             5. Need to pick max number from the above array which is <=59 it will be minutes
             6. Remove the new array with the minutes digits
             7. Need to prepare two digit array with this new array
             8. Need to pick max number from the above array which is <=59 it will be seconds             
             */
            int[] twoDigitArray =  GetTwodigitNumbers(intArray);
            int maxHour = GetMaxNumber(twoDigitArray, 12);

            intArray = RemoveInstances(intArray, maxHour);
            twoDigitArray = GetTwodigitNumbers(intArray);
            int maxminutes = GetMaxNumber(twoDigitArray, 59);

            intArray = RemoveInstances(intArray, maxminutes);
            twoDigitArray = GetTwodigitNumbers(intArray);
            int maxSeconds = GetMaxNumber(twoDigitArray, 59);

            Console.WriteLine(string.Format("{0}:{1}:{2}",maxHour,maxminutes,maxSeconds));
            Console.ReadLine();
        }

        /// <summary>
        /// In this function i have used lists which are not there in C++, and Remove function also
        /// I am not getting how to implement this in C++, rest all code can be easily write in C++ except this function
        /// </summary>
        /// <param name="intArray"></param>
        /// <param name="maxHour"></param>
        /// <returns></returns>
        private int[] RemoveInstances(int[] intArray, int maxHour)
        {
            List<int> lst = intArray.ToList();
            lst.Remove((int)maxHour / 10);
            lst.Remove((int)maxHour % 10);
            return lst.ToArray();
        }

        private void GetMaxTime()
        {
            
        }

        private int[] GetTwodigitNumbers(int[] inputArray)
        {
            int[] result = new int[ inputArray.Length*inputArray.Length];
            int cnt =-1;
            for (int i = 0; i < inputArray.Length; i++)
            {
                int a = inputArray[i];
                for (int j = 0; j < inputArray.Length; j++)
                {
                    int value = a * 10 + inputArray[j];
                    if (!result.Contains(value))
                    {
                        cnt++;
                        result[cnt] = value;
                    }
                }
                
            }
            int[] newArray = bubblesort(ref result, cnt);
            return newArray;
        }
        public int[] bubblesort(ref int[] arr, int n)
        {
            int temp;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            int[] newArray = new int[n+1];
            for (int i = 1; i <= n; i++)
            {
                newArray[i]= arr[i];
            }
            return newArray;
        }
        private int GetMaxNumber(int[] array,int limit)
        {
            int maxNo=0;
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i]>limit)
                {
                    maxNo = array[i-1];
                    break;
                }
            }//Added comment line to test changes
            return maxNo;
        }
    }
}
