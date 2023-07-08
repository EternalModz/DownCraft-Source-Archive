#pragma once

#define MAKE_FUNCTION(address, return_type, func_name, args) \
	uint32_t func_name##opd[2] = { address, 0x014CDAB0 }; \
	using func_name##_t = return_type(*)args; \
	func_name##_t func_name = (func_name##_t)func_name##opd;

#define DWORD_ADDRESS(address, address_name)

namespace FUNCTIONS
{
	MAKE_FUNCTION(0xBDCA84, uint32_t, Tesselator_GetInstance, ());
	MAKE_FUNCTION(0xBDCA9C, uint32_t, ReadTesselatorInstance, (uint32_t r3));
	MAKE_FUNCTION(0x9C1928, void, Tesselator_Begin, (uint32_t pTesselator));
	MAKE_FUNCTION(0x9C1A3C, void, Tesselator_Color, (uint32_t pTesselator, int r, int g, int b, double a));
	MAKE_FUNCTION(0x9C170C, void, Tesselator_End, (uint32_t pTesselator));
	MAKE_FUNCTION(0x9C2388, void, BufferBuilder_endVertex, (uint32_t pTesselator, float f1, float f2, float f3, float f4, float f5));
	void Tesselator_EndVertex(uint32_t pTesselator, float X, float Y, float Z, int* Color) { FUNCTIONS::Tesselator_Color(pTesselator, Color[0], Color[1], Color[2], 255); FUNCTIONS::BufferBuilder_endVertex(pTesselator, X, Y, Z, 0, 0); }

	MAKE_FUNCTION(0xCB9910, int, __printf, (const char* format, ...));
	MAKE_FUNCTION(0xA7DB38, int, Font_width, (uintptr_t font, uint32_t text));
	MAKE_FUNCTION(0xA7E2E8, void, DrawText, (uint32_t font, uint32_t r4, uint32_t x, uint32_t y, uint32_t color, uint32_t r8, uint32_t r9));
	MAKE_FUNCTION(0xA7E5DC, void, DrawTextWithShadow, (void* guiComponent, uint32_t font, uint32_t text, uint32_t x, uint32_t y, uint32_t color));
	MAKE_FUNCTION(0xA7CE80, void, DrawRectangleAlpha, (void* guiComponent, uint32_t x, uint32_t y, uint32_t width, uint32_t height, uint32_t color));

	MAKE_FUNCTION(0x886798, void, ConsoleUIController_PlayUISFX, (uintptr_t consoleUIController, uintptr_t soundEvent));
	MAKE_FUNCTION(0x2F93A0, void, GiveCommandExecute, (ServerCommandParser Server, std::string[]));
};