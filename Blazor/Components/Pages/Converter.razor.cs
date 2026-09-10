using System.ComponentModel;
using System.Reflection;

namespace Blazor.Components.Pages
{
    public static class ConverterLib
    {
        private static Assembly asm = Assembly.LoadFrom(@"x64/Debug/ConverterCSharp.dll");
        
        public readonly static Type wrapperType = asm.GetType("ConverterCSharp.Converter");
        
        private static object instance = Activator.CreateInstance(wrapperType);
        private static MethodInfo dec2bin = wrapperType.GetMethod("Dec2Bin");
        private static MethodInfo dec2hex = wrapperType.GetMethod("Dec2Hex");
        private static MethodInfo bin2dec = wrapperType.GetMethod("Bin2Dec");
        private static MethodInfo hex2dec = wrapperType.GetMethod("Hex2Dec");
        private static MethodInfo bin2hex = wrapperType.GetMethod("Bin2Hex");
        private static MethodInfo hex2bin = wrapperType.GetMethod("Hex2Bin");

        public static string Dec2Bin(Int64 number)  { return (string)dec2bin.Invoke(instance, new object[] { number }); }
        public static string Dec2Hex(Int64 number)  { return (string)dec2hex.Invoke(instance, new object[] { number }); }
        public static Int64 Bin2Dec(string bin)     { return (Int64)bin2dec.Invoke(instance, new object[] { bin });     }
        public static Int64 Hex2Dec(string hex)     { return (Int64)hex2dec.Invoke(instance, new object[] { hex });     }
        public static string Bin2Hex(string bin)    { return (string)bin2hex.Invoke(instance, new object[] { bin });    }
        public static string Hex2Bin(string hex)    { return (string)hex2bin.Invoke(instance, new object[] { hex });    }
    }
    public partial class Converter
    {

        string D2B_result = "";
        string D2H_result = "";
        Int64 B2D_result = 0;
        Int64 H2D_result = 0;
        string B2H_result = "";
        string H2B_result = "";

        Int64  D2B_input = 0;
        Int64  D2H_input = 0;
        string B2D_input = "";
        string H2D_input = "";
        string B2H_input = "";
        string H2B_input = "";

        void D2B_Calc() => D2B_result = ConverterLib.Dec2Bin(D2B_input);
        void D2H_Calc() => D2H_result = ConverterLib.Dec2Hex(D2H_input);
        void B2D_Calc() => B2D_result = ConverterLib.Bin2Dec(B2D_input);
        void H2D_Calc() => H2D_result = ConverterLib.Hex2Dec(H2D_input);
        void B2H_Calc() => B2H_result = ConverterLib.Bin2Hex(B2H_input);
        void H2B_Calc() => H2B_result = ConverterLib.Hex2Bin(H2B_input);
    }
}
