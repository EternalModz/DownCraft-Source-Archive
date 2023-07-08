
#pragma region "Functions Caller"

#define MAKE_FUNCTION(address, return_type, func_name, args) \
	uint32_t func_name##opd[2] = { address, 0x014CDAB0 }; \
	using func_name##_t = return_type(*)args; \
	func_name##_t func_name = (func_name##_t)func_name##opd;

#define DWORD_ADDRESS(address, address_name)

#include "Minecraft/client/gui/GuiComponent.h"
#include "Minecraft/entity/player/ServerPlayer.h"

GuiComponent* g_GuiComponent;
MultiPlayerLevel* g_Level;
MultiplayerLocalPlayer* g_Localplayer;
ServerPlayer* g_ServerPlayer;

namespace FUNCTIONS 
{
	MAKE_FUNCTION(0xCB9910, int, __printf, (const char* format, ...));
	MAKE_FUNCTION(0xCB9A10, int, __snprintf, (char* s, size_t n, const char* format, ...));

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

	//FONT RENDER
	MAKE_FUNCTION(0xA7DB38, int, Font_width, (uintptr_t font, uint32_t text));
	MAKE_FUNCTION(0xA7E2E8, void, DrawText, (uint32_t font, uint32_t r4, uint32_t x, uint32_t y, uint32_t color, uint32_t r8, uint32_t r9));
	MAKE_FUNCTION(0xA7E5DC, void, DrawTextWithShadow, (void* guiComponent, uint32_t font, uint32_t text, uint32_t x, uint32_t y, uint32_t color));
	MAKE_FUNCTION(0xA7E520, void, DrawCenteredText, (void* guiComponent, uint32_t font, uint32_t text, uint32_t x, uint32_t y, uint32_t color));
	MAKE_FUNCTION(0xA7CE80, void, DrawRectangleAlpha, (void* guiComponent, uint32_t x, uint32_t y, uint32_t width, uint32_t height, uint32_t color));
	MAKE_FUNCTION(0xA7D278, void, GuiComponent_fillGradient, (void* guiComponent, uint32_t x, uint32_t y, uint32_t width, uint32_t height, uint32_t color1, uint32_t color2));
	MAKE_FUNCTION(0xA75024, void, GLStateColor, (float r, float g, float b, float a));
	MAKE_FUNCTION(0xC720B8, uintptr_t, Renderer_DrawVertices, (uintptr_t r3, uintptr_t r4, uintptr_t r5, uintptr_t r6, uintptr_t r7, uintptr_t r8, uintptr_t r9));
	MAKE_FUNCTION(0xC6B6E0, int, GetFramesSinceBoot, ());

	//TESSELATOR
	MAKE_FUNCTION(0xBDCA84, uint32_t, Tesselator_GetInstance, ());
	MAKE_FUNCTION(0xBDCA9C, uint32_t, ReadTesselatorInstance, (uint32_t r3));
	MAKE_FUNCTION(0x9C1928, void, Tesselator_Begin, (uint32_t pTesselator));
	MAKE_FUNCTION(0x9C1A3C, void, Tesselator_Color, (uint32_t pTesselator, int r, int g, int b, double a));
	MAKE_FUNCTION(0x9C170C, void, Tesselator_End, (uint32_t pTesselator));
	MAKE_FUNCTION(0x9C2388, void, BufferBuilder_endVertex, (uint32_t pTesselator, float f1, float f2, float f3, float f4, float f5));
	void Tesselator_EndVertex(uint32_t pTesselator, float X, float Y, float Z, int* Color) { FUNCTIONS::Tesselator_Color(pTesselator, Color[0], Color[1], Color[2], 255); FUNCTIONS::BufferBuilder_endVertex(pTesselator, X, Y, Z, 0, 0); }

	MAKE_FUNCTION(0x886798, void, ConsoleUIController_PlayUISFX, (uintptr_t consoleUIController, uintptr_t soundEvent));

	//BUTTONS
	MAKE_FUNCTION(0xC62490, double, CInput_GetJoyStick_LX, (uintptr_t cinput, uint8_t button, bool r5));
	MAKE_FUNCTION(0xC62500, double, CInput_GetJoyStick_LY, (uintptr_t cinput, uint8_t button, bool r5));
	MAKE_FUNCTION(0xC62570, double, CInput_GetJoyStick_RX, (uintptr_t cinput, uint8_t button, bool r5));
	MAKE_FUNCTION(0xC625E0, double, CInput_GetJoyStick_RY, (uintptr_t cinput, uint8_t button, bool r5));

	//PLAYER
	MAKE_FUNCTION(0xB0E8F4, void, MultiPlayerLevel_getEntity, (void* outEntity, void* multiPlayerLevel, int id));
	MAKE_FUNCTION(0x85FA24, uintptr_t, CGameNetworkManager_GetPlayerByIndex, ());

	MAKE_FUNCTION(0x3A7F48, void, LivingEntity_actuallyHurt, (void* entity, void* entityDamageSource, float damage));
	MAKE_FUNCTION(0x4A94B8, void, Player_actuallyHurt, (void* player, void* damageSource, float damage));
	MAKE_FUNCTION(0x39F018, uint32_t, LivingEntity_onChangedBlock, (void* entity, void* pos));
	MAKE_FUNCTION(0x2E2180, void, FrostWalkerEnchantment_onEntityMoved, (void* entity, void* multiPlayerLevel, void* blockPos, int enchantmentLevel));
}

#pragma endregion

uintptr_t pCInput = (uintptr_t)0x16BD748;
uintptr_t ConsoleUIController = 0x1558228;

#pragma region "Need for Funcs"

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


wchar_t* c2wc(char* txt)
{
	if (checkTxt != txt)
	{
		int len = strlen(txt);
		for (int i = 0; i < len; i++)
		{
			charA2wcharA_[i] = txt[i];
		}
		charA2wcharA_[len] = '\0';
		checkTxt = txt;

	}
	return charA2wcharA_;
}

font_t getString(const wchar_t* str)
{
	font_t font;
	font.text = str;
	font.dataType = 7;
	font.wcstrlen = wcslen(str);
	font.wcstrlen1 = wcslen(str) + 3;
	font.unknown1 = 2.0625f;
	font.unknown1 = 1.0f;
	font.unknown1 = 1.0078125f;
	return font;
}

#pragma endregion

#pragma region "Game Functions"

int Font_width(const wchar_t* text) {
	FUNCTIONS::Font_width(mc->theMinecraft->fontRenderer, (uint32_t)&getString(text));
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

void DrawCenteredText(const wchar_t* text, uint32_t x, uint32_t y, uint32_t color) {
	FUNCTIONS::DrawCenteredText(g_GuiComponent, mc->theMinecraft->fontRenderer, (uint32_t)&getString(text), x, y, color);
}

void DrawRectangle(float x, float y, float w, float h, int* Color) {
	uint32_t pTesselator = FUNCTIONS::ReadTesselatorInstance(FUNCTIONS::Tesselator_GetInstance());
	FUNCTIONS::Tesselator_Begin(pTesselator);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, h + y, 0, Color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, h + y, 0, Color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, y, 0, Color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, y, 0, Color);
	FUNCTIONS::Tesselator_End(pTesselator);
}

void DrawRectangleAlpha(uint32_t x, uint32_t y, uint32_t width, uint32_t height, Color color) {
	FUNCTIONS::DrawRectangleAlpha(g_GuiComponent, x, y, width, height, color.ToHex());
}

void DrawGradient(uint32_t x, uint32_t y, uint32_t width, uint32_t height, Color colorTop, Color colorBottom)
{
	FUNCTIONS::GuiComponent_fillGradient(g_GuiComponent, x, y, width, height, colorTop.ToHex(), colorBottom.ToHex());
}

void PlayUISound(uintptr_t* SoundEvent) {
	FUNCTIONS::ConsoleUIController_PlayUISFX(ConsoleUIController, *SoundEvent);
}

void drawRectBorder(float x, float y, float w, float h, int* Color1, int* Color2)
{
	DrawRectangle(x - 1, y - 1, w + 2, h + 2, Color2);
	DrawRectangle(x, y, w, h, Color1);
}

#pragma endregion