#pragma once
#include <string>
#include <msclr/marshal_cppstd.h>
#include "../../Converter_lib/Converter_lib.h"
#pragma comment(lib ,  "../../Blazor/x64/Debug/Converter_lib.lib")
using namespace System;

namespace ConverterCSharp {
using namespace msclr::interop;
	
	public ref class Converter
	{
		public:
		static String^ Dec2Bin(Int64 number)
		{
			return marshal_as<String^>(convert::Dec2Bin(number));
		}
		static String^ Dec2Hex(Int64 number)
		{
			return marshal_as<String^>(convert::Dec2Hex(number));
		}
		static Int64 Bin2Dec(String^ bin)
		{
			return convert::Bin2Dec(marshal_as<std::string>(bin));
		}
		static Int64 Hex2Dec(String^ hex)
		{
			return convert::Hex2Dec(marshal_as<std::string>(hex));
		}
		static String^ Bin2Hex(String^ bin)
		{
			return marshal_as<String^>(convert::Bin2Hex(marshal_as<std::string>(bin)));
		}
		static String^ Hex2Bin(String^ hex)
		{
			return marshal_as<String^>(convert::Hex2Bin(marshal_as<std::string>(hex)));
		}

	};
	
}
