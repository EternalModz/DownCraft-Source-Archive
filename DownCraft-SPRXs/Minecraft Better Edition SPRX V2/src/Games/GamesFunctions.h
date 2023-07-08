#pragma once

#define TOC 0x014CDAB0

#define DWORD_ADDRESSS(address, address_name) \
	uint32_t address_name##opd[2] = { address, TOC }; \
	using address_name##_t = void(*); \
	address_name##_t address_name = (address_name##_t)address_name##opd;


#define MAKE_FUNCTION(address, return_type, func_name, args) \
	uint32_t func_name##opd[2] = { address, TOC }; \
	using func_name##_t = return_type(*)args; \
	func_name##_t func_name = (func_name##_t)func_name##opd;

namespace FUNCTIONS
{
	MAKE_FUNCTION(0x00A74CB0, void, PushMatrix, ());
	MAKE_FUNCTION(0x00A74CE8, void, PopMatrix, ());
	MAKE_FUNCTION(0x00A73F10, void, EnableBlend, ());
	MAKE_FUNCTION(0x00A73ED4, void, DisableBlend, ());
	MAKE_FUNCTION(0x00A73A30, void, DisableAlpha, ());
	MAKE_FUNCTION(0x00A73A9C, void, EnableAlpha, ());
	MAKE_FUNCTION(0x00A73AD8, void, AlphaFunc, (int func, float ref));
	MAKE_FUNCTION(0x00A73D7C, void, DisableColorMaterial, ());
	MAKE_FUNCTION(0x00A73B24, void, EnableLighting, ());
	MAKE_FUNCTION(0x00A73B5C, void, DisableLighting, ());
	MAKE_FUNCTION(0x00A73B94, void, EnableLight, (int light));
	MAKE_FUNCTION(0x00A73BDC, void, DisableLight, (int light));
	MAKE_FUNCTION(0x00A73C24, void, ColorMaterial, (uint32_t face, int mode));
	MAKE_FUNCTION(0x00A73DCC, void, DisableDepth, ());
	MAKE_FUNCTION(0x00A73E08, void, EnableDepth, ());
	MAKE_FUNCTION(0x00A73E44, void, DepthFunc, (int depthFunc));
	MAKE_FUNCTION(0x00A73E8C, void, DepthMask, (int flagIn));
	MAKE_FUNCTION(0x00A73F4C, void, BlendFunc, (int srcFactor, int dstFactor));
	MAKE_FUNCTION(0x00A73FC0, void, EnableFog, ());
	MAKE_FUNCTION(0x00A73FFC, void, DisableFog, ());
	MAKE_FUNCTION(0x00A74038, void, setFog, (int param));
	MAKE_FUNCTION(0x00A74080, void, SetFogDensity, (double param));
	MAKE_FUNCTION(0x00A740C4, void, SetFogStart, (double param));
	MAKE_FUNCTION(0x00A74108, void, SetFogEnd, (double param));
	MAKE_FUNCTION(0x00A7414C, void, GlFog, ());
	MAKE_FUNCTION(0x00A7415C, void, GlFogI, ());
	MAKE_FUNCTION(0x00A7416C, void, EnableCull, ());
	MAKE_FUNCTION(0x00A741A8, void, DisableCull, ());
	MAKE_FUNCTION(0x00A741E4, void, CullFace, (int mode));
	MAKE_FUNCTION(0x00A74234, void, EnablePolygonOffset, ());
	MAKE_FUNCTION(0x00A74270, void, DisablePolygonOffset, ());
	MAKE_FUNCTION(0x00A74324, void, doPolygonOffset, (double factor, double units));
	MAKE_FUNCTION(0x00A7436C, void, EnableColorLogic, ());
	MAKE_FUNCTION(0x00A743A8, void, DisableColorLogic, ());
	MAKE_FUNCTION(0x00A743E4, void, ColorLogic, (int texGen));
	MAKE_FUNCTION(0x00A74444, void, EnableTexGenCoord, (int texGen));
	MAKE_FUNCTION(0x00A7447C, void, DisableTexGenCoord, (int texGen));
	MAKE_FUNCTION(0x00A744B4, void, TexGen, (int texGen, int param));
	MAKE_FUNCTION(0x00A74578, void, SetActiveTexture, (int texture));
	MAKE_FUNCTION(0x00A74584, void, EnableTexture2D, ());
	MAKE_FUNCTION(0x00A745D4, void, DisableTexture2D, ());
	MAKE_FUNCTION(0x00A74624, void, GenerateTexture, ());
	MAKE_FUNCTION(0x00A7465C, void, DeleteTexture, (int texture));
	MAKE_FUNCTION(0x00A746E0, void, BendTexture, (int texture));
	MAKE_FUNCTION(0x00A74960, void, GlTexImage2D, (uint32_t target, uint32_t level, uint32_t internalFormat, uint32_t width, int height, int border, int type, int r8, int r9, int r10));
	MAKE_FUNCTION(0x00A749E4, void, EnableNormalize, ());
	MAKE_FUNCTION(0x00A74A1C, void, DisableNormalize, ());
	MAKE_FUNCTION(0x00A74A54, void, ShadeModel, (int mode));
	MAKE_FUNCTION(0x00A74A6C, void, EnableRescaleNormal, ());
	MAKE_FUNCTION(0x00A74AA4, void, DisableRescaleNormal, ());
	MAKE_FUNCTION(0x00A74B18, void, ColorMask, (char red, char green, char blue, char alpha));
	MAKE_FUNCTION(0x00A74B84, void, ClearDepth, (double depth));
	MAKE_FUNCTION(0x00A74B94, void, ClearColor, (double red, double green, double blue, double alpha));
	MAKE_FUNCTION(0x00A74D20, void, GetFloat, (int32_t pname, int32_t param));
	MAKE_FUNCTION(0x00A75024, void, Color1, (float colorRed, float colorGreen, float colorBlue, float colorAlpha));
	MAKE_FUNCTION(0x00A75074, void, Color2, (float colorRed, float colorGreen, float ColorBlue));
	MAKE_FUNCTION(0xCB9910, int, __printf, (const char* format, ...));
	MAKE_FUNCTION(0xA7DB38, int, Font_width, (uintptr_t font, uint32_t text));
	MAKE_FUNCTION(0xA7E2E8, void, DrawText, (uint32_t font, uint32_t r4, uint32_t x, uint32_t y, uint32_t color, uint32_t r8, uint32_t r9));
	MAKE_FUNCTION(0xA7E5DC, void, DrawTextWithShadow, (void* guiComponent, uint32_t font, uint32_t text, uint32_t x, uint32_t y, uint32_t color));
	MAKE_FUNCTION(0xA7CE80, void, DrawRectangleAlpha, (void* guiComponent, uint32_t x, uint32_t y, uint32_t width, uint32_t height, uint32_t color));
	MAKE_FUNCTION(0xBDCA84, uint32_t, Tesselator_GetInstance, ());
	MAKE_FUNCTION(0xBDCA9C, uint32_t, ReadTesselatorInstance, (uint32_t r3));
	MAKE_FUNCTION(0x9C1928, void, Tesselator_Begin, (uint32_t pTesselator));
	MAKE_FUNCTION(0x9C1A3C, void, Tesselator_Color, (uint32_t pTesselator, int r, int g, int b, double a));
	MAKE_FUNCTION(0x9C170C, void, Tesselator_End, (uint32_t pTesselator));
	MAKE_FUNCTION(0x9C2388, void, BufferBuilder_endVertex, (uint32_t pTesselator, float f1, float f2, float f3, float f4, float f5))
	void Tesselator_EndVertex(uint32_t pTesselator, float X, float Y, float Z, int* Color) { Tesselator_Color(pTesselator, Color[0], Color[1], Color[2], 255); BufferBuilder_endVertex(pTesselator, X, Y, Z, 0, 0); }
	MAKE_FUNCTION(0x886798, void, ConsoleUIController_PlayUISFX, (uintptr_t consoleUIController, uintptr_t soundEvent));
	MAKE_FUNCTION(0xAE03B4, int, Minecraft_getLocalPlayerIdx, (void* minecraft));
};

#pragma region "Functions Caller"

void PlayUISound(uintptr_t* SoundEvent) {
	uintptr_t ConsoleUIController = 0x1558228;
	FUNCTIONS::ConsoleUIController_PlayUISFX(ConsoleUIController, *SoundEvent);
}

void mc_printf(const char* format, ...) {
	FUNCTIONS::__printf(format);
}

int Font_width(const wchar_t* text) {
	FUNCTIONS::Font_width(mc->theMinecraft->fontRenderer, (uint32_t)&getString(text));
}

int Font_width_char(char* text) {
	FUNCTIONS::Font_width(mc->theMinecraft->fontRenderer, (uint32_t)&getString(c2wc(text)));
}

void DrawText(const wchar_t* text, float x, float y, uint32_t color) {
	FUNCTIONS::DrawText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(text), x, y, color, 0, 1);
}

void DrawTextC(char* text, float x, float y, uint32_t color) {
	FUNCTIONS::DrawText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(c2wc(text)), x, y, color, 0, 1);
}

void DrawTextWithShadow(const wchar_t* text, uint32_t x, uint32_t y, uint32_t color) {
	FUNCTIONS::DrawTextWithShadow(g_GuiComponent, mc->theMinecraft->fontRenderer, (uint32_t)&getString(text), x, y, color);
}

void DrawRectangleAlpha(float x, float y, float width, float height, Color color) {
	FUNCTIONS::DrawRectangleAlpha(g_GuiComponent, x, y, width, height, color.ToHex());
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

void DrawGradientRectangle(float x, float y, float w, float h, int* color1, int* color2, bool LeftOrUp)
{
	if (LeftOrUp)
	{
		uint32_t pTesselator = FUNCTIONS::ReadTesselatorInstance(FUNCTIONS::Tesselator_GetInstance());
		FUNCTIONS::Tesselator_End(pTesselator);
		FUNCTIONS::Tesselator_EndVertex(pTesselator, x, h + y, 0, color2);
		FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, h + y, 0, color1);
		FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, y, 0, color1);
		FUNCTIONS::Tesselator_EndVertex(pTesselator, x, y, 0, color2);
		FUNCTIONS::Tesselator_End(pTesselator);
	}
	else
	{
		uint32_t pTesselator = FUNCTIONS::ReadTesselatorInstance(FUNCTIONS::Tesselator_GetInstance());
		FUNCTIONS::Tesselator_End(pTesselator);
		FUNCTIONS::Tesselator_EndVertex(pTesselator, x, h + y, 0, color1);
		FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, h + y, 0, color1);
		FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, y, 0, color2);
		FUNCTIONS::Tesselator_EndVertex(pTesselator, x, y, 0, color2);
		FUNCTIONS::Tesselator_End(pTesselator);
	}
}

void DrawGradientBorder(float x, float y, float w, float h, int* color1, int* color2, int* color3, int borderSize, bool LeftOrUp)
{
	DrawGradientRectangle(x - 1, y - 1, w + 2, h + 2, color1, color2, LeftOrUp);
	DrawRectangle(x, y, w, h, color3);
}

void DrawGradientRectangleV2(float x, float y, float w, float h, int* color1, int* color2, int* color3, int* color4)
{
	uint32_t pTesselator = FUNCTIONS::ReadTesselatorInstance(FUNCTIONS::Tesselator_GetInstance());
	FUNCTIONS::Tesselator_End(pTesselator);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, h + y, 0, color1);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, h + y, 0, color2);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, y, 0, color3);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, y, 0, color4);
	FUNCTIONS::Tesselator_End(pTesselator);	FUNCTIONS::Tesselator_End(pTesselator);
}

void drawLine(const Vector2& start, const Vector2& end, int* color)
{
	float modX = 1 + (start.y - end.y);
	float modY = start.x - end.x;

	float len = sqrtf(modX * modX + modY * modY);

	modX /= len;
	modY /= len;

	uint32_t pTesselator = FUNCTIONS::ReadTesselatorInstance(FUNCTIONS::Tesselator_GetInstance());
	FUNCTIONS::Tesselator_Begin(pTesselator);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, start.x + modX, start.y + modY, 0, color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, start.x - modX, start.y - modY, 0, color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, end.x - modX, end.y - modY, 0, color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, start.x + modX, start.y + modY, 0, color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, end.x + modX, end.y + modY, 0, color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, end.x - modX, end.y - modY, 0, color);
	FUNCTIONS::Tesselator_End(pTesselator);
}

void DrawTextWithRectangle(const wchar_t* text, float x, float y, int* bgColor, int* textColor, bool underline)
{
	if (underline)
	{
		int RAINBOW[3] = { RainbowRED1, RainbowGREEN1, RainbowBLUE1 };
		int width = Font_width(text);
		DrawRectangle(x, y, width + 4, 11, bgColor);
		DrawRectangle(x, y + 11, width + 4, 2, RAINBOW);
		DrawText(text, x + 2, y + 2, color(textColor));
	}
	else
	{
		int width = Font_width(text);
		DrawRectangle(x, y, width + 4, 11, bgColor);
		DrawText(text, x + 2, y + 2, color(textColor));
	}
}

void DrawTextCharWithRectangle(char* text, float x, float y, int* bgColor, int* textColor, bool underline)
{
	if (underline)
	{
		int RAINBOW[3] = { RainbowRED1, RainbowGREEN1, RainbowBLUE1 };
		int width = Font_width_char(text);
		DrawRectangle(x, y, width + 4, 11, bgColor);
		DrawRectangle(x, y + 11, width + 4, 2, RAINBOW);
		DrawTextC(text, x + 2, y + 2, color(textColor));
	}
	else
	{
		int width = Font_width_char(text);
		DrawRectangle(x, y, width + 4, 11, bgColor);
		DrawTextC(text, x + 2, y + 2, color(textColor));
	}
}

void DrawsnprintfText(const char* format, int* args, float x, float y, bool WithRect)
{
	if (WithRect)
	{
		char option[0x100];
		wchar_t woption[0x100];
		_sys_memset(option, 0, 0x100);
		_sys_memset(woption, 0, 0x200);
		_sys_snprintf(option, 0x100, format, args[0], args[1], args[2], args[3], args[4]);
		StringToWideCharacter(woption, option, strlen(option));
		DrawTextWithRectangle(woption, x, y, MC_Color::BlackTheme, MC_Color::White, false);
	}
	else
	{
		char option[0x100];
		wchar_t woption[0x100];
		_sys_memset(option, 0, 0x100);
		_sys_memset(woption, 0, 0x200);
		_sys_snprintf(option, 0x100, format, args[0], args[1], args[2], args[3], args[4]);
		StringToWideCharacter(woption, option, strlen(option));
		DrawText(woption, x, y, color(MC_Color::White));
	}
}

void DrawSnprintf(const char* text, int valeur, int X, int Y)
{
	char option4[0x100];
	wchar_t woption4[0x100];
	_sys_memset(option4, 0, 0x100);
	_sys_memset(woption4, 0, 0x200);
	_sys_snprintf(option4, 0x100, text, (valeur));
	StringToWideCharacter(woption4, option4, strlen(option4));
	DrawText(woption4, X, Y, color(MC_Color::White));
}

#pragma endregion