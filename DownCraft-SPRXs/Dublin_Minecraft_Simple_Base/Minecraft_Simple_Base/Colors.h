#pragma once

#define Color_s(a,r,g,b) (((((a)&0xff)<<24)|(((r)&0xff)<<16)|(((g)&0xff)<<8)|((b)&0xff)))

struct Color
{
	Color(std::uint8_t r = 255, std::uint8_t g = 255, std::uint8_t b = 255, std::uint8_t a = 255)
	: r(r), g(g), b(b), a(a)
	{

	}

	Color(std::uint32_t hexValue)
	{
		a = (hexValue & 0xFF000000) >> 24;
		r = (hexValue & 0xFF0000) >> 16;
		g = (hexValue & 0xFF00) >> 8;
		b = hexValue & 0xFF;
	}

	std::uint32_t ToHex()
	{
		return (a << 24) | (r << 16) | (g << 8) | b;
	}


	std::uint8_t a;
	std::uint8_t r;
	std::uint8_t g;
	std::uint8_t b;
};

int Red[] = { 255, 0, 0, 255 };
int White[4] = { 255, 255, 255, 255 };
int Green[4] = { 30, 130, 76, 100 };
int Brown[4] = { 165, 42, 42, 255 };
int Black[4] = { 0, 0, 0, 255 };
int Transparent[4] = { 255, 0, 0, 0.8 };
int Gray[4] = { 15, 0, 0, 0.8 };