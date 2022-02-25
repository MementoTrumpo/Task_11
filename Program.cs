using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_11
{
    class Program
    {
        /// <summary>
        /// Словарь всех латинских заглавных букв для перевода в другие системы счисления
        /// </summary>
        public static Dictionary<int, char> Letters = new Dictionary<int, char>
        {
            {10, 'A'}, {11, 'B'}, {12, 'C'}, {13, 'D'}, {14, 'E'}, {15, 'F'}, {16, 'G'}, {17, 'H'}, {18, 'I'}, {19, 'J'}, {20, 'K'}, {21, 'L'}, {22, 'M'}, {23, 'N'},
            {24, 'O'}, {25, 'P'}, {26, 'Q'}, {27, 'R'}, {28, 'S'}, {29, 'T'}, {30, 'U'}, {31, 'V'}, {32, 'W'}, {33, 'X'}, {34, 'Y'}, {35, 'Z'}

        };

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputInformation = input.Split(new char[] { ' ' });

            int inputNumberSystem = Convert.ToInt32(inputInformation[0]);
            string numberInputNumberSystem = inputInformation[1];
            int outputNumberSystem = Convert.ToInt32(inputInformation[2]);

            Console.WriteLine($"{inputNumberSystem} - {numberInputNumberSystem} - {outputNumberSystem}");

            //Console.WriteLine(ToDecimalNumberSystem(numberInputNumberSystem,inputNumberSystem));
            //Console.WriteLine(FromDecimalToAnotherlNumberSystem(numberInputNumberSystem, outputNumberSystem));
            Console.WriteLine(TranslationFromOneNumberSystemToAnother(numberInputNumberSystem, inputNumberSystem, outputNumberSystem));


            Console.ReadKey();
        }

        /// <summary>
        /// Переводит из любой СС в 10-ую СС (СС - Система счисления)
        /// </summary>
        /// <param name="number"> Исходное число</param>
        /// <param name="inputNumberSystem"> Система, в которой записано исходное число</param>
        /// <returns>Возвращает строку из числа, переведенного в 10-ую систему счисления</returns>
        public static int ConversionFromAnyNumberSystemToDecimal( string number, int inputNumberSystem)
        {
            int finalNumber = 0;
            int i, j;
            for (i = 0, j = number.Length - 1; (i < number.Length) && (j >= 0); i++, j--)//
            {
                if (char.IsDigit(number[i]))//Проверяем что символом является цифра
                {
                    finalNumber += (Convert.ToInt32(number[i]) - 48) * Convert.ToInt32(Math.Pow(inputNumberSystem, j));
                }
                else
                {
                    foreach(var key in Letters)//Иначе ищем в словаре ключ и значение соответствующего символа
                    {
                        if(number[i] == key.Value)
                        {
                            finalNumber += key.Key * Convert.ToInt32(Math.Pow(inputNumberSystem, j));
                        }
                    }
                }
            }

            return finalNumber;
            
        }

        /// <summary>
        /// Переводит из 10-ой СС в любую другую СС (СС - Система счисления)
        /// </summary>
        /// <param name="number"> Исходное число</param>
        /// <param name="outputNumberSystem">Система счисления в которую необходимо перевести</param>
        /// <returns>Возвращает строку переведенного числа в конкретную СС</returns>
        public static string FromDecimalToAnotherlNumberSystem(string number, int outputNumberSystem)
        {
            int decimalNumber = Convert.ToInt32(number);//Приводим к значению int
            int num = 0;
            string finalNumber = "";

            while (decimalNumber > 0)
            {
                num = decimalNumber % outputNumberSystem;//Берем остаток от деления чтобы записать его в итоговую переменную
                if (num >= 10)
                {
                   foreach(var key in Letters)//Проверяем есть ли остаток больше 9 и находим его в словаре
                    {
                        if(num == key.Key)
                        {
                            finalNumber += key.Value;
                        }
                    }
                    
                }

                else
                {
                    finalNumber += num.ToString();
                }
                decimalNumber /= outputNumberSystem;
            }

            char[] reversString = finalNumber.ToArray();//Разворачиваем строку
            Array.Reverse(reversString);
            var output = new string(reversString);
            return output;            
        }

        /// <summary>
        /// Переводит из одной в другую систему счисления
        /// </summary>
        /// <param name="number"></param>
        public static string TranslationFromOneNumberSystemToAnother(string number, int inputNumberSystem, int outputNumberSystem)
        {
            string outputNumber = "";
            if (inputNumberSystem != 10 && outputNumberSystem != 10)
            {
                int num = ConversionFromAnyNumberSystemToDecimal(number, inputNumberSystem);
                outputNumber = FromDecimalToAnotherlNumberSystem(num.ToString(), outputNumberSystem);
                return outputNumber;
            }
            else if(outputNumberSystem == 10)
            {
                outputNumber = ConversionFromAnyNumberSystemToDecimal(number, inputNumberSystem).ToString();
                return outputNumber;
            }
            else
            {
                outputNumber = FromDecimalToAnotherlNumberSystem(number, outputNumberSystem);
                return outputNumber;
            }
        }
      
    }
}
