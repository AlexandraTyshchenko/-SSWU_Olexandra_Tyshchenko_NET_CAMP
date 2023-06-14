using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class CardIdentifier
    {
       private bool IsAmericanExpress(string cardNumber)
        {
            if (cardNumber.Length == 15 && (cardNumber.StartsWith("34") || cardNumber.StartsWith("37")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IsMasterCard(string cardNumber)
        {
            if (cardNumber.Length == 16 && cardNumber.StartsWith("51") || cardNumber.StartsWith("52") ||
                cardNumber.StartsWith("53") || cardNumber.StartsWith("54") || cardNumber.StartsWith("55"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       private bool IsVisa(string cardNumber)
        {
            if ((cardNumber.Length == 13 || cardNumber.Length == 16) && cardNumber.StartsWith("4"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ICard Create(string number)
        {
            if (Validate(number))
            {
                if (IsVisa(number))
                {
                    return new Visa(number);
                }
                if (IsAmericanExpress(number))
                {
                    return new AmericanExpress(number);
                }
                if (IsMasterCard(number))
                {
                    return new MasterCard(number);
                }
                throw new Exception("Card is not identified");
            }
            throw new Exception("Card is not validated");
        }

        private bool Validate(string number)
        {
            int[] digits = number.Replace(" ", "").Select(c => int.Parse(c.ToString())).ToArray();
            int sum = 0;
            bool isSecondDigit = false;

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int digit = digits[i];

                if (isSecondDigit)
                {
                    digit *= 2;
                    digit = digit % 10 + digit / 10;
                }

                sum += digit;
                isSecondDigit = !isSecondDigit;
            }

            return sum % 10 == 0;
        }
    }
}
