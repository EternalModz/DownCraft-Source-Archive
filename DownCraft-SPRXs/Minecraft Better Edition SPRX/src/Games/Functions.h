#pragma once

#pragma region "Menu Functions"

typedef union RGB
{
	struct
	{
		union { int red; int R; };
		union { int green; int G; };
		union { int blue; int B; };
	};
	int color[3];
} RGB;

RGB MenuColour1 = { 90, 0, 0 };
RGB MenuColour2 = { 0, 0, 180 };

void DoRainbowColor()
{
	if (RainbowTime < mc->gameTime)
	{
		if (MenuColourTime == 0)
		{
			MenuColour1.B++;
			if (MenuColour1.B == 255)
				MenuColourTime = 1;
		}
		else if (MenuColourTime == 1)
		{
			MenuColour1.R--;
			if (MenuColour1.R == 0)
				MenuColourTime = 2;
		}
		else if (MenuColourTime == 2)
		{
			MenuColour1.G++;
			if (MenuColour1.G == 255)
				MenuColourTime = 3;
		}
		else if (MenuColourTime == 3)
		{
			MenuColour1.B--;
			if (MenuColour1.B == 0)
				MenuColourTime = 4;
		}
		else if (MenuColourTime == 4)
		{
			MenuColour1.R++;
			if (MenuColour1.R == 255)
				MenuColourTime = 5;
		}
		else if (MenuColourTime == 5)
		{
			MenuColour1.G--;
			if (MenuColour1.G == 0)
				MenuColourTime = 0;
		}

		if (RainbowTime < mc->gameTime)
		{
			if (MenuColourTime == 0)
			{
				MenuColour2.B++;
				if (MenuColour2.B == 255)
					MenuColourTime = 1;
			}
			else if (MenuColourTime == 1)
			{
				MenuColour2.R--;
				if (MenuColour2.R == 0)
					MenuColourTime = 2;
			}
			else if (MenuColourTime == 2)
			{
				MenuColour2.G++;
				if (MenuColour2.G == 255)
					MenuColourTime = 3;
			}
			else if (MenuColourTime == 3)
			{
				MenuColour2.B--;
				if (MenuColour2.B == 0)
					MenuColourTime = 4;
			}
			else if (MenuColourTime == 4)
			{
				MenuColour2.R++;
				if (MenuColour2.R == 255)
					MenuColourTime = 5;
			}
			else if (MenuColourTime == 5)
			{
				MenuColour2.G--;
				if (MenuColour2.G == 0)
					MenuColourTime = 0;
			}

			RainbowRED1 = MenuColour1.R;
			RainbowGREEN1 = MenuColour1.G;
			RainbowBLUE1 = MenuColour1.B;

			RainbowRED2 = MenuColour2.R;
			RainbowGREEN2 = MenuColour2.G;
			RainbowBLUE2 = MenuColour2.B;

			RainbowTime = mc->gameTime;
		}
	}
}

int getOption()
{
	if (optionPress)
	{
		optionPress = false;
		return CurrentOpt;
	}
	else return -1;
}

void openSubmenu(int menu)
{
	lastMenus[lastMenuCount] = CurrentMenu;
	lastMenuCount++;
	CurrentOpt = 0;
	CurrentMenu = menu;
}

void closeMenu() {
	lastMenuCount = 0;
	CurrentOpt = 0;
	Opened = false;
}

void goBack() {
	if (lastMenuCount == 0) {
		closeMenu();
	}
	else {
		lastMenuCount--;
		CurrentMenu = lastMenus[lastMenuCount];
		CurrentOpt = 0;
	}
}

void Controller()
{
	int wI = 0;
	keyPressed[wI] = false;

	if (Buttons::IsMCButtonPressed(Buttons::L1) && Buttons::IsMCButtonPressed(Buttons::UP))
	{
		if (!Opened)
		{
			Opened = true;
			CurrentMenu = MainMenu;
			lastMenuCount = 0;
			CurrentOpt = 0;
		}
	}

	if (Opened)
	{
		if (Buttons::IsMCButtonPressed(Buttons::UP))
		{
			if (scrollWait(firstWaitTime, waitTime, wI))
			{
				CurrentOpt = CurrentOpt - 1;
				return;
			}
		}

		if (Buttons::IsMCButtonPressed(Buttons::DOWN))
		{
			if (scrollWait(firstWaitTime, waitTime, wI))
			{
				CurrentOpt = CurrentOpt + 1;
				return;
			}
		}

		int fix = MaxSubOptions;
		fix -= 1;

		if (CurrentOpt > fix)
			CurrentOpt = 0;

		if (CurrentOpt < 0)
			CurrentOpt = fix;

		if (Buttons::IsMCButtonPressed(Buttons::X))
		{
			if (scrollWait(firstWaitTime, waitTime, wI))
			{
				optionPress = true;
				return;
			}
		}

		if (Buttons::IsMCButtonPressed(Buttons::O))
		{
			if (scrollWait(firstWaitTime, waitTime, wI))
			{
				goBack();
				return;
			}
		}

		if (!keyPressed[wI])
		{
			lockFirst[wI] = false;
			freeFirst[wI] = true;
			resetWait[wI] = true;
			resetWait2[wI] = true;
		}
	}
}

#pragma endregion

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

void DrawTextWithRectangle(const wchar_t* text, float x, float y, int* color1, bool underline)
{
	if (underline)
	{
		int RAINBOW[3] = { RainbowRED1, RainbowGREEN1, RainbowBLUE1 };
		int width = Font_width(text);
		DrawRectangle(x, y, width + 4, 11, color1);
		DrawRectangle(x, y + 11, width + 4, 2, RAINBOW);
		DrawText(text, x + 2, y + 2, color(MC_Color::White));
	}
	else
	{
		int width = Font_width(text);
		DrawRectangle(x, y, width + 4, 11, color1);
		DrawText(text, x + 2, y + 2, color(MC_Color::White));
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
		DrawTextWithRectangle(woption, x, y, MC_Color::BlackTheme, false);
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