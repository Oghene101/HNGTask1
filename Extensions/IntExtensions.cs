namespace Task1.Extensions;

public static class IntExtensions
{
    public static bool IsPrime(this int number)
    {
        if (number < 2)
            return false;

        if (number == 2)
            return true;

        if (number % 2 == 0)
            return false; //2 is the only even prime number

        for (int i = 3; i <= Math.Sqrt(number); i += 2)
        {
            if (number % i == 0)
                return false; //short circuit if a divisor is found
        }

        return true;
    }

    public static bool IsPerfect(this int number)
    {
        if (!number.IsEven() || number < 6)
            return false;

        int sumOfDivisors = 1;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i != 0) continue;
            sumOfDivisors += i;
            if (i != number / i)
                sumOfDivisors += number / i; //Add the result of the perfect division
        }

        return sumOfDivisors == number;
    }

    public static bool IsEven(this int number)
    {
        if (number <= 0)
            return false;
        return number % 2 == 0;
    }

    public static bool IsArmstrongNumber(this int number)
    {
        if (number < 0)
            return false;

        int originalNumber = number;
        int numberOfDigits = (int)Math.Floor(Math.Log10(number)) + 1; // Count the number of digits
        int sum = 0;

        while (number > 0)
        {
            int digit = number % 10; // Extract the last digit
            sum += (int)Math.Pow(digit, numberOfDigits); // Raise the digit to the power of the number of digits
            number /= 10; // Remove the last digit
        }

        return sum == originalNumber;
    }

    public static int SumOfDigits(this int number)
    {
        return Math.Abs(number)
            .ToString() 
            .ToCharArray()
            .Sum(c => int.Parse(c.ToString()));
    }
}