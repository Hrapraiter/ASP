namespace Blazor.Components.Pages
{
    using Microsoft.AspNetCore.Html;
    using System.Numerics;
    public partial class Fibonatchi
    {
        int n;
        List<BigInteger> cashNumbers = new List<BigInteger>() { 0 , 1 , 1 };
        string output = "";

        int getIntLenght(double value) 
        {
            int count = 0;
            while(value > 0) 
            {
                value = Math.Floor(value / 10);
                count++;
            }
            return count-1;
        }
        void Calculate()
        {
            output = "";

            if(n > cashNumbers.Count)
                 for(int i = cashNumbers.Count-1; i < n; i++) 
                     cashNumbers.Add(cashNumbers[i - 1] + cashNumbers[i]);

            //int numbersCount = Math.Min(n, cashNumbers.Count);// страховка
            int spaceCount = getIntLenght(n);
            for(int i = 0; i < n; i++)
                output += $"{new string(' ' , spaceCount - getIntLenght(i+1))}{i+1}. {cashNumbers[i]}\n";
            
            
        }
    }
}
