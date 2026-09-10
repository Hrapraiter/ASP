#pragma once
#include <string>

namespace convert
{
	std::string Dec2Bin(int64_t number);
	std::string Dec2Hex(int64_t number);
	int64_t Bin2Dec(std::string binary);
	int64_t Hex2Dec(std::string hex);
	std::string Bin2Hex(std::string binary);
	std::string Hex2Bin(std::string hex);
}
//
//inline std::string Bin2Hex_inline(const std::string& binary);
//inline std::string Hex2Bin_inline(const std::string& hex);
