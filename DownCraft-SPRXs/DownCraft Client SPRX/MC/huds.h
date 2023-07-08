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

Color BLACK_OPACITY{ 5, 5, 5, 230 };

void drawShadowText(uint32_t font, uint32_t r4, uint32_t x, uint32_t y, uint32_t color, uint32_t r8, uint32_t r9) 
{
	Call<void>(shaderOfs, font, r4, x, y, color, r8, r9);
}

void ConsoleUIController_PlayUISFX(uintptr_t consoleUIController, uintptr_t soundEvent)
{
	Call<void>(PlayUISFX, consoleUIController, soundEvent);
}

void MultiPlayerLevel_getEntity(void* outEntity, void* multiPlayerLevel, int id)
{
	Call<void>(MultiPlayerGetEntity, outEntity, multiPlayerLevel, id);
}

int Minecraft_getLocalPlayerIdx(void* minecraft)
{
	Call<void>(GetLocalPlayerID, minecraft);
}

void MultiPlayerGameMode_destroyBlock(void* gamemode, void* blockPos)
{
	Call<void>(MPDestroyBlock, gamemode, blockPos);
}

int __printf(const char* format, ...)
{
	Call<void>(Ofsprintf, format);
}

void GuiComponent_fillGradient(void* guiComponent, uint32_t x, uint32_t y, uint32_t width, uint32_t height, uint32_t color1, uint32_t color2)
{
	Call<void>(GuiFillGardient, guiComponent, x, y, width, height, color1, color2);
}

void Gui_render(void* guiComponent, double unk)
{
	Call<void>(GuiRender, guiComponent, unk);
}

bool CInput_RequestKeyboard(uintptr_t cinput, const wchar_t* title, const wchar_t* initText, uint32_t _zero, size_t length, void* callback, uint64_t param, uint32_t unk)
{
	Call<void>(CinputRequestKeyboard, cinput, title, initText, _zero, length, callback, param, unk);
}

GuiComponent* g_GuiComponent;

void GuiComponent_fill(void* guiComponent, uint32_t x, uint32_t y, uint32_t width, uint32_t height, uint32_t color) {
	Call<void>(0xA7CE80, guiComponent, x, y, width, height, color);
}

bool GuiComponent_drawString(void* guiComponent, uint32_t font, uint32_t text, uint32_t x, uint32_t y, uint32_t color) {
	Call<void>(0xA7E5DC, guiComponent, font, text, x, y, color);
}

void NewDrawRect(float x, float y, float width, float height, Color color)
{
	GuiComponent_fill(g_GuiComponent, x, y, width, height, color.ToHex());
}

int __snprintf(char* s, size_t n, const char* format, ...)
{
	Call<void>(Ofssnprintf, s, n, format);
}

uintptr_t pCInput = (uintptr_t)0x16BD748;
uintptr_t ConsoleUIController = 0x1558228;
uintptr_t* pSoundEventBack = (uintptr_t*)0x14CA684;
uintptr_t* pSoundEventCraft = (uintptr_t*)0x14CA688;
uintptr_t* pSoundEventFocus = (uintptr_t*)0x14CA690;
uintptr_t* pSoundEventPress = (uintptr_t*)0x14CA694;
uintptr_t* pSoundEventScroll = (uintptr_t*)0x14CA698;


void DisplayKeyboard(const std::wstring& title, const std::wstring& defaultText, size_t maxInputLength, void* callback)
{
	CInput_RequestKeyboard(pCInput, title.c_str(), defaultText.c_str(), 0, maxInputLength, callback, 0, 0);
}

void PlayUISoundBack()
{
	ConsoleUIController_PlayUISFX(ConsoleUIController, *pSoundEventBack);
}

void PlayUISoundSelect()
{
	ConsoleUIController_PlayUISFX(ConsoleUIController, *pSoundEventPress);
}

void PlayUISoundScroll()
{
	ConsoleUIController_PlayUISFX(ConsoleUIController, *pSoundEventScroll);
}

void PlayUISoundFocus()
{
	ConsoleUIController_PlayUISFX(ConsoleUIController, *pSoundEventFocus);
}

void PlayUISoundCraft()
{
	ConsoleUIController_PlayUISFX(ConsoleUIController, *pSoundEventCraft);
}


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

font_t getString(const wchar_t * str) 
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

size_t StringToWideCharacter(wchar_t *dest, const char *scr, size_t len)
{
	int count = 0;
	if (len)
	{
		do
		{
			if ((*dest++ = (wchar_t)*scr++) == 0)
				break;
			count++;
		} while (--len);
	}
	return count;
}

size_t WideCharacterToString(char *dest, const wchar_t *scr, size_t len)
{
	int count = 0;
	if (len)
	{
		do
		{
			if ((*dest++ = (char)*scr++) == 0)
				break;
			count++;
		} while (--len);
	}
	return count;
}

void drawText(char* text, float x, float y, uint32_t Color)
{
	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(c2wc(text)), x, y, Color, 0, 1);
}

void UI_DrawText(const wchar_t * text, float x, float y, uint32_t Color)
{
	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(text), x, y, Color, 0, 1);
}

void DrawShadowText(const wchar_t* text, uint32_t x, uint32_t y, uint32_t color)
{
	GuiComponent_drawString(g_GuiComponent, mc->theMinecraft->fontRenderer, (uint32_t)&getString(text), x, y, color);
}


uint32_t Tesselator_GetInstance() 
{
	return Call<uint32_t>(addr1);
}

uint32_t ReadTesselatorInstance(uint32_t r3) 
{
	return Call<uint32_t>(addr2, r3);
}

void Tesselator_Begin(uint32_t pTesselator) 
{
	Call<void>(addr3, pTesselator);
}

void Tesselator_Color(uint32_t pTesselator, int r, int g, int b, float a) 
{
	Call<void>(addr4, pTesselator, r, g, b, a);
}

void Tesselator_End(uint32_t pTesselator) 
{
	Call<void>(addr5, pTesselator);
}

void BufferBuilder_endVertex(uint32_t pTesselator, float f1, float f2, float f3, float f4, float f5) 
{
	Call<void>(addr6, pTesselator, f1, f2, f3, f4, f5);
}

void Tesselator_EndVertex(uint32_t pTesselator, float X, float Y, float Z, int* Color) {
	Tesselator_Color(pTesselator, Color[0], Color[1], Color[2], 255);
	BufferBuilder_endVertex(pTesselator, X, Y, Z, 0, 0);
}

void drawRect(float x, float y, float w, float h, int* Color) {
	uint32_t pTesselator = ReadTesselatorInstance(Tesselator_GetInstance());
	Tesselator_Begin(pTesselator);
	Tesselator_EndVertex(pTesselator, x, h + y, 0, Color);
	Tesselator_EndVertex(pTesselator, w + x, h + y, 0, Color);
	Tesselator_EndVertex(pTesselator, w + x, y, 0, Color);
	Tesselator_EndVertex(pTesselator, x, y, 0, Color);
	Tesselator_End(pTesselator);
}

void drawRectBorder(float x, float y, float w, float h, int* Color, int* Color2) 
{
	drawRect(x - 1, y - 1, w + 2, h + 2, Color2);
	drawRect(x, y, w, h, Color);
}

void drawLine(const float * start, const float * end)
{
	float startl[3] = { start[0] - mc->theMinecraft->cLevelRenderer->location[0], start[1] - mc->theMinecraft->cLevelRenderer->location[1], start[2] - mc->theMinecraft->cLevelRenderer->location[2] };
	float endl[3] = { end[0] - mc->theMinecraft->cLevelRenderer->location[0], end[1] - mc->theMinecraft->cLevelRenderer->location[1], end[2] - mc->theMinecraft->cLevelRenderer->location[2] };
	//float startl[3] = { start[0] - mc->theMinecraft->cMultiplayerLocalPlayer->LocationX, start[1] - mc->theMinecraft->cMultiplayerLocalPlayer->LocationY, start[2] - mc->theMinecraft->cMultiplayerLocalPlayer->LocationZ };
	//float endl[3] = { end[0] - mc->theMinecraft->cMultiplayerLocalPlayer->LocationX, end[1] - mc->theMinecraft->cMultiplayerLocalPlayer->LocationY, end[2] - mc->theMinecraft->cMultiplayerLocalPlayer->LocationZ };

	uint32_t pTesselator = ReadTesselatorInstance(Tesselator_GetInstance());
	Tesselator_Begin(pTesselator);
	Tesselator_EndVertex(pTesselator, start[0], start[1], start[2], UI::Color::WHITE);
	Tesselator_EndVertex(pTesselator, end[0], end[1], end[2], UI::Color::WHITE);
	Tesselator_End(pTesselator);
}

void DrawToggleONOFF(float x, float y, int* Color1, int* Color2, bool checked)
{
	int color1[3] = { 65, 65, 65 };
	if (checked)
	{
		drawRectBorder(x, y, 34, 7, Color1, Color2);
		drawRect(x + 17, y, 17, 7, Color2);
		drawText("OFF     ", x + 18, y, color(color1));
	}
	else
	{
		drawRectBorder(x, y, 34, 7, Color1, Color2);
		drawRect(x, y, 17, 7, Color2);
		drawText("ON     ", x + 2, y, color(UI::Color::BLUE));
	}
}



//HUD
void AddInstruction()
{
	if (UI::Settings::ShowInfosBar)
	{
		if (*(int*)0x31E7781C == 0x3F800000) //Check if the game is for US
		{
			drawRect(17, 217, 160, 14, UI::Color::BLACK);
			UI_DrawText(L"Back: O   Scroll: UP / DOWN   Select: X", 21, 220, color(UI::Color::WHITE));
			if (!UI::Settings::ShowCustomImage)
				*(int*)0x31E77830 = 0x44000000;
		}
		else
		{
			//SetNotify(L"Add default Media | PS3 to US");
			UI::Settings::ShowInfosBar = false;
		}
	}
}

void Scrollbar()
{
	if (UI::Settings::NewScrollbar)
	{
		drawRect(AddOptX - 2, AddOptY + (CurrentOpt * 10), bgW + TextYSelector, 11, UI::Color::BLUE);
	}
}

void AddHud(int sub)
{
	if (sub == 1) { drawRect(bgX, bgY, bgW, bgH, UI::Color::BLACK); }
	else if (sub == 2) { drawRect(bgX, bgY, bgW, 21, UI::Color::BLACK); }
	else if (sub == 3) { drawRect(bgX, bgY, bgW, 31, UI::Color::BLACK); }
	else if (sub == 4) { drawRect(bgX, bgY, bgW, 41, UI::Color::BLACK); }
	else if (sub == 5) { drawRect(bgX, bgY, bgW, 51, UI::Color::BLACK); }
	else if (sub == 6) { drawRect(bgX, bgY, bgW, 61, UI::Color::BLACK); }
	else if (sub == 7) { drawRect(bgX, bgY, bgW, 71, UI::Color::BLACK); }
	else if (sub == 8) { drawRect(bgX, bgY, bgW, 81, UI::Color::BLACK); }
	else if (sub == 9) { drawRect(bgX, bgY, bgW, 91, UI::Color::BLACK); }
	else if (sub == 10) { drawRect(bgX, bgY, bgW, 101, UI::Color::BLACK); }
	else if (sub == 11) { drawRect(bgX, bgY, bgW, 111, UI::Color::BLACK); }
	else if (sub == 12) { drawRect(bgX, bgY, bgW, 121, UI::Color::BLACK); }
	else if (sub == 13) { drawRect(bgX, bgY, bgW, 131, UI::Color::BLACK); }
	else if (sub == 14) { drawRect(bgX, bgY, bgW, 141, UI::Color::BLACK); }
	else if (sub == 15) { drawRect(bgX, bgY, bgW, 151, UI::Color::BLACK); }
	else if (sub == 16) { drawRect(bgX, bgY, bgW, 161, UI::Color::BLACK); }
}

void AddTitle(const wchar_t* opt)
{
	if (UI::Settings::HeaderTitle)
	{
		drawRect(20, 19, 50, 11, UI::Color::BLUE);
	}
	Scrollbar();
	DrawShadowText(opt, AddOptX - 1, AddOptY - 11, color(UI::Color::WHITE));
}

void AddOption(const wchar_t * opt)
{
	UI_DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(UI::Color::BLUE) : color(UI::Color::WHITE));
	//UI_DrawText(L">     ", 65, 32 + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(UI::Color::BLUE) : color(UI::Color::WHITE));
	MaxOption += 1;
}

void AddHudSelector(int sub)
{
	if (sub == 1) { drawRect(70, bgYSelector, BgWSelector, bgH, UI::Color::BLACK); }
	else if (sub == 2) { drawRect(70, bgYSelector, BgWSelector, 21, UI::Color::BLACK); }
	else if (sub == 3) { drawRect(70, bgYSelector, BgWSelector, 31, UI::Color::BLACK); }
	else if (sub == 4) { drawRect(70, bgYSelector, BgWSelector, 41, UI::Color::BLACK); }
	else if (sub == 5) { drawRect(70, bgYSelector, BgWSelector, 51, UI::Color::BLACK); }
	else if (sub == 6) { drawRect(70, bgYSelector, BgWSelector, 61, UI::Color::BLACK); }
	else if (sub == 7) { drawRect(70, bgYSelector, BgWSelector, 71, UI::Color::BLACK); }
	else if (sub == 8) { drawRect(70, bgYSelector, BgWSelector, 81, UI::Color::BLACK); }
	else if (sub == 9) { drawRect(70, bgYSelector, BgWSelector, 91, UI::Color::BLACK); }
	else if (sub == 10) { drawRect(70, bgYSelector, BgWSelector, 101, UI::Color::BLACK); }
	else if (sub == 11) { drawRect(70, bgYSelector, BgWSelector, 111, UI::Color::BLACK); }
	else if (sub == 12) { drawRect(70, bgYSelector, BgWSelector, 121, UI::Color::BLACK); }
	else if (sub == 13) { drawRect(70, bgYSelector, BgWSelector, 131, UI::Color::BLACK); }
	else if (sub == 14) { drawRect(70, bgYSelector, BgWSelector, 141, UI::Color::BLACK); }
	else if (sub == 15) { drawRect(70, bgYSelector, BgWSelector, 151, UI::Color::BLACK); }
	else if (sub == 16) { drawRect(70, bgYSelector, BgWSelector, 161, UI::Color::BLACK); }
}

void AddBoolOption(const wchar_t * opt, bool checkbox)
{
	UI_DrawText(opt, 72, TextYSelector + (10 * MaxOptionsSelector), (MaxOptionsSelector == CurrentOptSelector) ? color(UI::Color::BLUE) : color(UI::Color::WHITE));

	if (UI::Settings::NewCheckbox)
	{
		drawRectBorder(CheckBoxSelector, TextYSelector + 2 + (10 * MaxOptionsSelector), 4, 4, (checkbox) ? UI::Color::BLACK : UI::Color::BLUE, UI::Color::WHITE);
	}
	else
	{
		if (UI::Settings::ToggleOnOff)
		{
			DrawToggleONOFF(CheckBoxSelector, TextYSelector + 2 + (10 * MaxOptionsSelector), UI::Color::BLUE, UI::Color::BLACK, checkbox);
		}
		else
		{
			UI_DrawText(checkbox ? L"" : L"+     ", CheckBoxSelector, TextYSelector + (10 * MaxOptionsSelector), (MaxOptionsSelector == CurrentOptSelector) ? color(UI::Color::BLUE) : color(UI::Color::WHITE));
		}
	}
	MaxOptionsSelector += 1;
}

void AddOptionFuncs(const wchar_t* opt)
{
	UI_DrawText(opt, 72, TextYSelector + (10 * MaxOptionsSelector), (MaxOptionsSelector == CurrentOptSelector) ? color(UI::Color::BLUE) : color(UI::Color::WHITE));
	MaxOptionsSelector += 1;
}

void AddCustomImages(bool toggle)
{
	if (toggle)
	{
		*(int*)0x31E7782C = 0xC1A00000; //pos title
		*(int*)0x31E77830 = 0xC3E30000; //pos title
		*(int*)0x31E787A0 = 0xC5D3C000; //pos image
		*(int*)0x30927421 = 0x00000000; //REMOVE TEXT INVENTORY
		*(int*)0x3092CD81 = 0x00000000; //REMOVE TEXT CREATIVE

		//Creative Shader = 0x31E7879C
		//Button R1 = 0x31E788CC
		//Dpad PickBlock = 0x31E78A4C
	}
	else
	{
		*(int*)0x31E77830 = 0x45E30000; //pos title
		*(int*)0x31E7879C = 0x447C0000; //pos image
		*(int*)0x31E787A0 = 0xC5D3C000; //pos image
		*(int*)0x31E787DC = 0X3FA00000; //opacity image
	}
}

void ResetHud()
{
	bgYSelector = 30;
	TextYSelector = 32;
	BgWSelector = 50;
	CheckBoxSelector = 112;
}

void AddShadow(bool toggle)
{
	if (toggle)
	{
		Color BLACK_OPACITY{ 15, 15, 15, shadowBG };
		NewDrawRect(-5, -5, 1000, 1000, BLACK_OPACITY);
	}
	else
	{

	}
}