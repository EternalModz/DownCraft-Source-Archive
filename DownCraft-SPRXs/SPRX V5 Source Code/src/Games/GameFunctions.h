#pragma once

uintptr_t pCInput = (uintptr_t)0x16BD748;
uintptr_t ConsoleUIController = 0x1558228;

namespace FUNCTIONS
{
	CallFunction(0xA7E5DC, void, DrawTextShadow, (void* guiComponent, uint32_t font, uint32_t text, uint32_t x, uint32_t y, uint32_t color));
	CallFunction(0xA7E2E8, void, DrawText, (uint32_t font, uint32_t r4, uint32_t x, uint32_t y, uint32_t color, uint32_t r8, uint32_t r9));
	CallFunction(0xA7CE80, void, DrawRectangleAlpha, (void* guiComponent, uint32_t x, uint32_t y, uint32_t width, uint32_t height, uint32_t color));
	CallFunction(0x886798, void, ConsoleUIController_PlayUISFX, (uintptr_t consoleUIController, uintptr_t soundEvent));
	CallFunction(0xA7DB38, int, Font_width, (uintptr_t font, uint32_t text));

	CallFunction(0xBDCA84, uint32_t, Tesselator_GetInstance, ());
	CallFunction(0xBDCA9C, uint32_t, ReadTesselatorInstance, (uint32_t r3));
	CallFunction(0x9C1928, void, Tesselator_Begin, (uint32_t pTesselator));
	CallFunction(0x9C1A3C, void, Tesselator_Color, (uint32_t pTesselator, int r, int g, int b, int a));
	CallFunction(0x9C170C, void, Tesselator_End, (uint32_t pTesselator));
	CallFunction(0x9C2388, void, BufferBuilder_endVertex, (uint32_t pTesselator, float f1, float f2, float f3, float f4, float f5))	
	void Tesselator_EndVertex(uint32_t pTesselator, float X, float Y, float Z, int* Color) { Tesselator_Color(pTesselator, Color[0], Color[1], Color[2], Color[3]); BufferBuilder_endVertex(pTesselator, X, Y, Z, 0, 0); }
};

int GetTextWidth(const wchar_t* text) 
{
	FUNCTIONS::Font_width(mc->theMinecraft->fontRenderer, (uint32_t)&getString(text));
}

void PlaySound(uintptr_t* SoundEvent) 
{
	FUNCTIONS::ConsoleUIController_PlayUISFX(ConsoleUIController, *SoundEvent);
}

void DrawTextShadow(const wchar_t* text, uint32_t x, uint32_t y, uint32_t color) {
	FUNCTIONS::DrawTextShadow(g_GuiComponent, mc->theMinecraft->fontRenderer, (uint32_t)&getString(text), x, y, color);
}

void DrawText(const wchar_t* text, float x, float y, uint32_t color) {
	FUNCTIONS::DrawText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(text), x, y, color, 0, 1);
}

void DrawTextC(char* text, float x, float y, uint32_t color) {
	FUNCTIONS::DrawText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(c2wc(text)), x, y, color, 0, 1);
}

void DrawTextSnprintf(const char* text, int valeur, int X, int Y)
{
	char option4[0x100];
	wchar_t woption4[0x100];
	_sys_memset(option4, 0, 0x100);
	_sys_memset(woption4, 0, 0x200);
	_sys_snprintf(option4, 0x100, text, (valeur));
	StringToWideCharacter(woption4, option4, strlen(option4));
	DrawText(woption4, X, Y, color(MC_Color::WHITE));
}

void DrawTextSnprintfV2(const char* format, int* args, float x, float y)
{
	char option[0x100];
	wchar_t woption[0x100];
	_sys_memset(option, 0, 0x100);
	_sys_memset(woption, 0, 0x200);
	_sys_snprintf(option, 0x100, format, args[0], args[1], args[2], args[3], args[4]);
	StringToWideCharacter(woption, option, strlen(option));
	DrawText(woption, x, y, color(MC_Color::WHITE));
}

void DrawRectangle(float x, float y, float w, float h, int* color)
{
	uint32_t pTesselator = FUNCTIONS::ReadTesselatorInstance(FUNCTIONS::Tesselator_GetInstance());
	FUNCTIONS::Tesselator_End(pTesselator);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, h + y, 0, color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, h + y, 0, color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, y, 0, color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, y, 0, color);
	FUNCTIONS::Tesselator_End(pTesselator);
}

void DrawRectangleBorder(float x, float y, float w, float h, int* Color1, int* Color2, int borderSize)
{
	DrawRectangle(x - borderSize, y - borderSize, w + borderSize * 2, h + borderSize * 2, Color2);
	DrawRectangle(x, y, w, h, Color1);
}

void DrawRectangleAlpha(float x, float y, float width, float height, Color color) {
	FUNCTIONS::DrawRectangleAlpha(g_GuiComponent, x, y, width + 80, height + 80, color.ToHex());
}

void DrawTextWithRectangle(const wchar_t* text, float x, float y, int* bgColor, int* textColor, bool underline)
{
	if (underline)
	{
		int RAINBOW[3] = { RainbowRED1, RainbowGREEN1, RainbowBLUE1 };
		int width = GetTextWidth(text);
		DrawRectangle(x, y, width + 4, 11, bgColor);
		DrawRectangle(x, y + 11, width + 4, 2, RAINBOW);
		DrawText(text, x + 2, y + 2, color(textColor));
	}
	else
	{
		int width = GetTextWidth(text);
		DrawRectangle(x, y, width + 4, 11, bgColor);
		DrawText(text, x + 2, y + 2, color(textColor));
	}
}