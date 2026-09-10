#include <iostream>
#include <string>
#include "../Converter_lib/Converter_lib.h"
#pragma comment(lib , "../Blazor/x64/Debug/Converter_lib.lib")
//#include "../Converter_lib/Converter_lib.h"
//#pragma comment(lib ,  "../Blazor/x64/Debug/Converter_lib.lib")

int main()
{
    int64_t test_value = 255;
    std::cout <<"Dec2Hex : " << convert::Dec2Hex(test_value) << '\n';
    std::cout <<"Dec2Bin : " << convert::Dec2Bin(test_value) << '\n';
    std::cout <<"Bin2Dec : " << convert::Bin2Dec(convert::Dec2Bin(test_value)) << '\n';
    std::cout <<"Hex2Dec : " << convert::Hex2Dec(convert::Dec2Hex(test_value)) << '\n';
    std::cout <<"Bin2Hex : " << convert::Bin2Hex(convert::Dec2Bin(test_value)) << '\n';
    std::cout <<"Hex2Bin : " << convert::Hex2Bin(convert::Dec2Hex(test_value)) << "\n\n";

    system("pause");
    return 0;
}

/*
std::string Dec2Bin(const int64_t& number)
{
    std::string output = "";
    uint64_t tmp = static_cast<uint64_t>(number);
    while (tmp > 0)
    {
        output.insert(output.begin(), ((tmp & 1) > 0 ? '1' : '0'));
        tmp >>= 1;
    }
    if (output.length() < 64) output = std::string(64 - output.length(), '0') + output;
    return "0b" + output;
}
std::string Dec2Hex(const int64_t& number)
{
    static char(*Dec2Hex_Elem)(const uint8_t&) = [](const uint8_t& number)
        {
            if (number < 10)return char('0' + number);
            switch (number)
            {
            case 10: return 'A';
            case 11: return 'B';
            case 12: return 'C';
            case 13: return 'D';
            case 14: return 'E';
            case 15: return 'F';
            }
            return char(0);
        };
    std::string output = "";
    uint64_t num = static_cast<uint64_t>(number);
    while(num > 0)
    {
        output.insert(output.begin(), Dec2Hex_Elem(num % 16));
        num /= 16;
    }
    if (output.length() < 16) output = std::string(16 - output.length() , '0') + output;

    return "0x" + output;
}
int64_t Bin2Dec(const std::string& binary)
{
    if (binary.empty()) return 0;
    std::string binary_copy = binary;
    int index = 0;
    if ((index = binary_copy.find("0b")) != std::string::npos)
        binary_copy.erase(index , 2);

    uint64_t tmp = 0;

    for(int i = binary_copy.length()-1;i >= 0;i--)
        if (binary_copy[i] == '1')
            tmp |= (1ULL << (binary_copy.length() - i - 1));

    return static_cast<int64_t>(tmp);
}
int64_t Hex2Dec(const std::string& hex)
{
    static uint64_t(*Hex2Dec_Elem)(char) = [](char elem)
        {
            elem = toupper(elem);
            if (elem >= '0' && elem <= '9')return uint64_t(elem - '0');
            switch (elem)
            {
            case 'A': return 10ULL;
            case 'B': return 11ULL;
            case 'C': return 12ULL;
            case 'E': return 14ULL;
            case 'F': return 15ULL;
            }
            return 0ULL;
        };
    if (hex.empty())return 0;

    std::string hex_copy = hex;

    int index = 0;
    if ((index = hex_copy.find("0x")) != std::string::npos)
        hex_copy.erase(index, 2);

    uint64_t tmp = 0;
    int cash_len = hex_copy.length();
    for (int i = cash_len-1; i >= 0; i--)
    {
        if (hex_copy[i] == '0')continue;
        uint64_t elem = Hex2Dec_Elem(hex_copy[i]);
        tmp |= (elem << ((cash_len - i - 1) * 4));
    }
    return static_cast<int64_t>(tmp);
}

std::string Bin2Hex(const std::string& binary)
{
    static char(*Bin2Hex_Elem)(const std::string&) = [](const std::string& elem)
        {
            if (elem == "0000")return '0';
            if (elem == "0001")return '1';
            if (elem == "0010")return '2';
            if (elem == "0011")return '3';
            if (elem == "0100")return '4';
            if (elem == "0101")return '5';
            if (elem == "0110")return '6';
            if (elem == "0111")return '7';
            if (elem == "1000")return '8';
            if (elem == "1001")return '9';
            if (elem == "1010")return 'A';
            if (elem == "1011")return 'B';
            if (elem == "1100")return 'C';
            if (elem == "1101")return 'D';
            if (elem == "1110")return 'E';
            if (elem == "1111")return 'F';

            return char(0);
        };
    if (binary.empty()) return "";
    std::string binary_copy = binary;
    int index = 0;
    if ((index = binary_copy.find("0b")) != std::string::npos)
        binary_copy.erase(index, 2);

    std::string output = "";
    int remaind = binary_copy.length() % 4;
    if (remaind != 0)binary_copy = std::string(remaind, '0') + binary_copy;

    for (int i = 0;i <= binary_copy.length()-1;i+=4)
        output += Bin2Hex_Elem(binary_copy.substr(i, 4));

    if (output.length() < 16) output = std::string(16 - output.length(), '0') + output;

    return "0x" + output;
}
inline std::string Bin2Hex_inline(const std::string& binary)
{
    return Dec2Hex(Bin2Dec(binary));
}

std::string Hex2Bin(const std::string& hex)
{
    static std::string(*Hex2Bin_Elem)(char) = [](char elem)
        {
            elem = toupper(elem);
            switch (elem)
            {
            case '0': return std::string("0000");
            case '1': return std::string("0001");
            case '2': return std::string("0010");
            case '3': return std::string("0011");
            case '4': return std::string("0100");
            case '5': return std::string("0101");
            case '6': return std::string("0110");
            case '7': return std::string("0111");
            case '8': return std::string("1000");
            case '9': return std::string("1001");
            case 'A': return std::string("1010");
            case 'B': return std::string("1011");
            case 'C': return std::string("1100");
            case 'D': return std::string("1101");
            case 'E': return std::string("1110");
            case 'F': return std::string("1111");
            }
            return std::string("");
        };
    if (hex.empty())return "";

    std::string hex_copy = hex;

    int index = 0;
    if ((index = hex_copy.find("0x")) != std::string::npos)
        hex_copy.erase(index, 2);

    std::string output = "";
    for (int i = 0; i < hex_copy.length(); i++)
        output += Hex2Bin_Elem(hex_copy[i]);

    if (output.length() < 64) output = std::string(64 - output.length(), '0') + output;
    return "0b" + output;
    return Dec2Bin(Hex2Dec(hex));
}
inline std::string Hex2Bin_inline(const std::string& hex)
{
    return Dec2Bin(Hex2Dec(hex));
}
*/