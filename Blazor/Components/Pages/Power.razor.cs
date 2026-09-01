using System.Data.SqlTypes;
using System.Numerics;

namespace Blazor.Components.Pages
{
    public partial class Power
    {
        int number = 0;
        int pow = 0;
        //BigInteger positiveResult = 0;
        Double negativeResult = 0;
        string output = "";
        void Calculate()
        {
            output = "";
            if (pow < 0)
            {
                negativeResult = number;
                for (int i = 0; i >= pow; i--)
                    negativeResult /= number;

                output = negativeResult.ToString("F99").TrimEnd('0').TrimEnd('.');
            }
            else output = BigInteger.Pow(number, pow).ToString();
        }
    }
}
