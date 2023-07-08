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

void SlideOpenMenuAnimation()
{
	if (Opened && !Closed)
	{
		if (MenuX > -41)
		{
			MenuX -= speedSlider;
		}
	}
}

void SlideCloseMenuAnimation()
{
	if (Closed)
	{
		MenuX += speedSlider;

		if (MenuX > 200)
		{
			Opened = false;
			Closed = false;
		}
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
			MenuX = 200;
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
				returnPress = true;
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

void DrawRectangleAlpha(uint32_t x, uint32_t y, uint32_t width, uint32_t height, Color color) {
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
	DrawRectangle(x - borderSize, y - borderSize, w + borderSize * 2, h + borderSize * 2,Color2);
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

#pragma endregion