using System;

namespace Pesel_validator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter PESEL");
            PeselValidator peselValidator = new PeselValidator();
            string pesel = Console.ReadLine();
            Console.WriteLine(peselValidator.ValidatePesel(pesel));


        }

        class PeselValidator
        {
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

            public bool ValidatePesel(string pesel)
            {
                bool valid = false;
                try
                {
                    if (pesel.Length == 11)
                    {
                        valid = CountSum(pesel).Equals(pesel[10].ToString());
                    }
                }
                catch (Exception)
                {
                    valid = false;
                }
                return valid;

            }

            public string CountSum(string pesel)
            {
                int sum = 0;
                for (int i = 0; i < weights.Length; i++)
                {
                    sum += weights[i] * int.Parse(pesel[i].ToString());
                }

                int modulo = sum % 10;
                return modulo == 0 ? modulo.ToString() : (10 - modulo).ToString();
            }
        }
    }
}   
