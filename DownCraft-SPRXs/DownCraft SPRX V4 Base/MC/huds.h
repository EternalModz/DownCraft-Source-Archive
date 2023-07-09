#define Color_s(a,r,g,b) (((((a)&0xff)<<24)|(((r)&0xff)<<16)|(((g)&0xff)<<8)|((b)&0xff)))

//DRAW TEXT

void drawText(char* text, float x, float y, uint32_t Color)
{
	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(c2wc(text)), x, y, Color, 0, 1);
}

void UI_DrawText(const wchar_t* text, float x, float y, uint32_t Color)
{
	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(text), x, y, Color, 0, 1);
}

void DrawShadowText(const wchar_t* text, uint32_t x, uint32_t y, uint32_t color)
{
	GuiComponent_drawString(g_GuiComponent, mc->theMinecraft->fontRenderer, (uint32_t)&getString(text), x, y, color);
}

void NewDrawRect(float x, float y, float width, float height, Color color)
{
	GuiComponent_fill(g_GuiComponent, x, y, width, height, color.ToHex());
}


//DRAW HUDS

void drawLine(const float* start, const float* end)
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

void drawRect(float x, float y, float w, float h, int* Color)
{
	uint32_t pTesselator = ReadTesselatorInstance(Tesselator_GetInstance());
	Tesselator_Begin(pTesselator);
	Tesselator_EndVertex(pTesselator, x, h + y, 0, Color);
	Tesselator_EndVertex(pTesselator, w + x, h + y, 0, Color);
	Tesselator_EndVertex(pTesselator, w + x, y, 0, Color);
	Tesselator_EndVertex(pTesselator, x, y, 0, Color);
	Tesselator_End(pTesselator);
}

void drawRectBorder(float x, float y, float w, float h, int* Color1, int* Color2)
{
	drawRect(x - 1, y - 1, w + 2, h + 2, Color2);
	drawRect(x, y, w, h, Color1);
}

void drawRectRGB(float x, float y, float w, float h, int R, int G, int B)
{
	int colored[3] = { R, G, B };
	uint32_t pTesselator = ReadTesselatorInstance(Tesselator_GetInstance());
	Tesselator_Begin(pTesselator);
	Tesselator_EndVertex(pTesselator, x, h + y, 0, colored);
	Tesselator_EndVertex(pTesselator, w + x, h + y, 0, colored);
	Tesselator_EndVertex(pTesselator, w + x, y, 0, colored);
	Tesselator_EndVertex(pTesselator, x, y, 0, colored);
	Tesselator_End(pTesselator);
}

void drawGradientLeftRight(float x, float y, float w, float h, int* Color, int* Color2)
{
	uint32_t pTesselator = ReadTesselatorInstance(Tesselator_GetInstance());
	Tesselator_Begin(pTesselator);
	Tesselator_EndVertex(pTesselator, x, h + y, 0, Color2); //left down
	Tesselator_EndVertex(pTesselator, w + x, h + y, 0, Color); //right down
	Tesselator_EndVertex(pTesselator, w + x, y, 0, Color); //right up
	Tesselator_EndVertex(pTesselator, x, y, 0, Color2); //left up
	Tesselator_End(pTesselator);
}

void drawGradientUpDown(float x, float y, float w, float h, int* Color, int* Color2)
{
	uint32_t pTesselator = ReadTesselatorInstance(Tesselator_GetInstance());
	Tesselator_Begin(pTesselator);
	Tesselator_EndVertex(pTesselator, x, h + y, 0, Color2); //left down
	Tesselator_EndVertex(pTesselator, w + x, h + y, 0, Color2); //right down
	Tesselator_EndVertex(pTesselator, w + x, y, 0, Color); //right up
	Tesselator_EndVertex(pTesselator, x, y, 0, Color); //left up
	Tesselator_End(pTesselator);
}

void drawGradient(float x, float y, float w, float h, int* Color, int* Color2)
{
	uint32_t pTesselator = ReadTesselatorInstance(Tesselator_GetInstance());
	Tesselator_Begin(pTesselator);
	Tesselator_EndVertex(pTesselator, x, h + y, 0, Color2);
	Tesselator_EndVertex(pTesselator, w + x, h + y, 0, Color);
	Tesselator_EndVertex(pTesselator, w + x, y, 0, Color2);
	Tesselator_EndVertex(pTesselator, x, y, 0, Color);
	Tesselator_End(pTesselator);
}

void drawGradientLeftRightRGB(float x, float y, float w, float h, int R, int G, int B, int R1, int G1, int B1)
{
	int colored1[3] = { R, G, B };
	int colored2[3] = { R1, G1, B1 };
	uint32_t pTesselator = ReadTesselatorInstance(Tesselator_GetInstance());
	Tesselator_Begin(pTesselator);
	Tesselator_EndVertex(pTesselator, x, h + y, 0, colored2); //left down
	Tesselator_EndVertex(pTesselator, w + x, h + y, 0, colored1); //right down
	Tesselator_EndVertex(pTesselator, w + x, y, 0, colored1); //right up
	Tesselator_EndVertex(pTesselator, x, y, 0, colored2); //left up
	Tesselator_End(pTesselator);
}

void drawGradientUpDownRGB(float x, float y, float w, float h, int R, int G, int B, int R1, int G1, int B1)
{
	int colored1[3] = { R, G, B };
	int colored2[3] = { R1, G1, B1 };
	uint32_t pTesselator = ReadTesselatorInstance(Tesselator_GetInstance());
	Tesselator_Begin(pTesselator);
	Tesselator_EndVertex(pTesselator, x, h + y, 0, colored1); //left down
	Tesselator_EndVertex(pTesselator, w + x, h + y, 0, colored1); //right down
	Tesselator_EndVertex(pTesselator, w + x, y, 0, colored2); //right up
	Tesselator_EndVertex(pTesselator, x, y, 0, colored2); //left up
	Tesselator_End(pTesselator);
}

void drawGradientRGB(float x, float y, float w, float h, int R, int G, int B, int R1, int G1, int B1)
{
	int colored1[3] = { R, G, B };
	int colored2[3] = { R1, G1, B1 };
	uint32_t pTesselator = ReadTesselatorInstance(Tesselator_GetInstance());
	Tesselator_Begin(pTesselator);
	Tesselator_EndVertex(pTesselator, x, h + y, 0, colored1);
	Tesselator_EndVertex(pTesselator, w + x, h + y, 0, colored2);
	Tesselator_EndVertex(pTesselator, w + x, y, 0, colored1);
	Tesselator_EndVertex(pTesselator, x, y, 0, colored2);
	Tesselator_End(pTesselator);
}

void drawRectBorderRGB(float x, float y, float w, float h, int* Color1, int R, int G, int B)
{
	drawRectRGB(x - 1, y - 1, w + 2, h + 2, R, G, B);
	drawRect(x, y, w, h, Color1);
}

void drawRectBorderRGBV2(float x, float y, float w, float h, int R, int G, int B, int* Color1)
{
	drawRect(x - 1, y - 1, w + 2, h + 2, Color1);
	drawRectRGB(x, y, w, h, R, G, B);
}

void drawRectBorderRGBV3(float x, float y, float w, float h, int* Color1, int R, int G, int B, int R1 , int G1, int B1)
{
	drawGradientLeftRightRGB(x - 1, y - 1, w + 2, h + 2, R, G, B, R1, G1, B1);
	drawRect(x, y, w, h, Color1);
}

void DrawHorizontalLine(int startX, int endX, int y, int* color)
{
	if (endX < startX)
	{
		int i = startX;
		startX = endX;
		endX = i;
	}
	//		x pos, Y Pos,  W Pos, H Pos, Color
	drawRect(startX + 1, y, endX + 1, 1, color);
}

void DrawVerticalLine(int x, int startY, int endY, int* color)
{
	int width = 1;
	if (x < startY)
	{
		int i = startY;
		startY = endY;
		endY = i;
	}//		x pos, Y Pos,  W Pos, H Pos, Color
	drawRect(x, startY + 1, 1, endY, color);
}

void drawRectWithText(char* text, float x, float y, int* Color)
{
	float w;
	float h = 13;
	int count = strlen(text);

	if (count == 5) { w = 33; }
	else if (count == 6) { w = 36; }
	else if (count == 7) { w = 38; }
	else if (count == 8) { w = 39; }
	else if (count == 9) { w = 42; }
	else if (count == 10) { w = 44; }
	else if (count == 11) { w = 46; }
	else if (count == 12) { w = 48; }
	else if (count == 13) { w = 50; }
	else if (count == 14) { w = 52; }
	else if (count == 15) { w = 54; }
	else if (count == 16) { w = 56; }
	else if (count == 17) { w = 58; }
	else if (count == 18) { w = 60; }
	else if (count == 19) { w = 62; }
	else if (count == 20) { w = 64; }
	else if (count == 21) { w = 66; }
	else if (count == 22) { w = 68; }
	else if (count == 23) { w = 70; }
	else if (count == 24) { w = 72; }
	else if (count == 25) { w = 74; }
	else if (count == 26) { w = 76; }
	else if (count == 27) { w = 78; }
	else if (count == 28) { w = 80; }
	else if (count == 29) { w = 82; }
	else if (count == 30) { w = 84; }

	uint32_t pTesselator = ReadTesselatorInstance(Tesselator_GetInstance());
	Tesselator_Begin(pTesselator);
	Tesselator_EndVertex(pTesselator, x, h + y, 0, Color);
	Tesselator_EndVertex(pTesselator, w + x, h + y, 0, Color);
	Tesselator_EndVertex(pTesselator, w + x, y, 0, Color);
	Tesselator_EndVertex(pTesselator, x, y, 0, Color);
	Tesselator_End(pTesselator);

	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(c2wc(text)), x + 5, y + 3, color(UI::Color::WHITE), 0, 1);
}

void DrawToggleONOFF(float x, float y, int *Color1, int *Color2, bool checked)
{
	if (UI::Settings::Rainbow)
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
			drawText("ON     ", x + 2, y, color(UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE));
		}
	}
	else
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
}








void SetNotify(wchar_t* notifmsg)
{
	if (UI::Settings::ShowNotif)
	{
		NotifMsg = notifmsg;
		SendNotif = false;
		SendNotif = true;
	}
}

void GetNotify()
{
	if (UI::Settings::ShowNotif)
	{
		if (SendNotif)
		{
			if (UI::Settings::Rainbow)
			{
				if (UI::Settings::GradientRGB)
				{
					drawRectBorderRGBV3(284, 21, 143, 15, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1);
					UI_DrawText(NotifMsg, 289, 25, color(UI::Color::WHITE));
				}
				else
				{
					drawRectBorderRGB(284, 21, 143, 15, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE);
					UI_DrawText(NotifMsg, 289, 25, color(UI::Color::WHITE));
				}
			}
			else
			{
				drawRectBorder(284, 21, 143, 15, UI::Color::BLACK, GetThemeColor());
				UI_DrawText(NotifMsg, 289, 25, color(UI::Color::WHITE));
			}

			if (frameTime(200, 1, false))
			{
				SendNotif = false;
			}
		}
	}
}





//MENU HUDS

void TitleMenu()
{
	drawRect(15, 10, 80, 13, UI::Color::BLACK);
	DrawShadowText(L"DownCraft SPRX", 20, 13, color(UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE));
}

void AddInstruction()
{
	if (UI::Settings::ShowInfosBar)
	{
		if (UI::Settings::Style)
		{
			if (UI::Settings::Rainbow)
			{
				if (UI::Settings::GradientRGB)
				{
					drawRectBorderRGBV3(17, 217, 160, 14, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1);
				}
				else
				{
					drawRectBorderRGB(17, 217, 160, 14, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE);
				}
				UI_DrawText(L"Back: O   Scroll: UP / DOWN   Select: X", 21, 220, color(UI::Color::WHITE));
			}
			else
			{
				drawRectBorder(17, 217, 160, 14, UI::Color::BLACK, GetThemeColor());
				UI_DrawText(L"Back: O   Scroll: UP / DOWN   Select: X", 21, 220, color(UI::Color::WHITE));
			}
		}
		else
		{
			drawRect(17, 217, 160, 14, UI::Color::BLACK);
			UI_DrawText(L"Back: O   Scroll: UP / DOWN   Select: X", 21, 220, color(UI::Color::WHITE));
		}

		if (!UI::Settings::ShowCustomImage)
			*(int*)0x31E77830 = 0x44000000;
	}
}

void AddOpacityBG()
{
	if (UI::Settings::BGOpacity)
	{
		Color BLACK_OPACITY{ 15, 15, 15, shadowBG };
		if (submmenuMax == 1) { NewDrawRect(bgX, bgY, bgW + 35 + menulenght, bgH + 48, BLACK_OPACITY); }
		else if (submmenuMax == 2) { NewDrawRect(bgX, bgY, bgW + 35 + menulenght, bgH + 58, BLACK_OPACITY); }
		else if (submmenuMax == 3) { NewDrawRect(bgX, bgY, bgW + 35 + menulenght, bgH + 68, BLACK_OPACITY); }
		else if (submmenuMax == 4) { NewDrawRect(bgX, bgY, bgW + 35 + menulenght, bgH + 78, BLACK_OPACITY); }
		else if (submmenuMax == 5) { NewDrawRect(bgX, bgY, bgW + 35 + menulenght, bgH + 88, BLACK_OPACITY); }
		else if (submmenuMax == 6) { NewDrawRect(bgX, bgY, bgW + 35 + menulenght, bgH + 98, BLACK_OPACITY); }
		else if (submmenuMax == 7) { NewDrawRect(bgX, bgY, bgW + 35 + menulenght, bgH + 108, BLACK_OPACITY); }
		else if (submmenuMax == 8) { NewDrawRect(bgX, bgY, bgW + 35 + menulenght, bgH + 118, BLACK_OPACITY); }
		else if (submmenuMax == 9) { NewDrawRect(bgX, bgY, bgW + 35 + menulenght, bgH + 121, BLACK_OPACITY); }
		else if (submmenuMax == 10) { NewDrawRect(bgX, bgY, bgW + 35 + menulenght, bgH + 138, BLACK_OPACITY); }
		else if (submmenuMax == 11) { NewDrawRect(bgX, bgY, bgW + 35 + menulenght, bgH + 148, BLACK_OPACITY); }
		else if (submmenuMax == 12) { NewDrawRect(bgX, bgY, bgW + 35 + menulenght, bgH + 158, BLACK_OPACITY); }
		else if (submmenuMax == 13) { NewDrawRect(bgX, bgY, bgW + 35 + menulenght, bgH + 168, BLACK_OPACITY); }
		else if (submmenuMax == 14) { NewDrawRect(bgX, bgY, bgW + 35 + menulenght, bgH + 178, BLACK_OPACITY); }
		else if (submmenuMax == 15) { NewDrawRect(bgX, bgY, bgW + 35 + menulenght, bgH + 188, BLACK_OPACITY); }
		else if (submmenuMax == 16) { NewDrawRect(bgX, bgY, bgW + 35 + menulenght, bgH + 198, BLACK_OPACITY); }
	}
}

void Scrollbar()
{
	if (UI::Settings::Scrollbar)
	{ 
		drawRect(ScrollX, ScrollY + (CurrentOpt * 10), bgW + menulenght, 11, GetThemeColor());
		if (UI::Settings::Rainbow)
		{
			drawRectRGB(ScrollX, ScrollY + (CurrentOpt * 10), bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE);
			if (UI::Settings::GradientRGB)
			{
				drawGradientLeftRightRGB(ScrollX, ScrollY + (CurrentOpt * 10), bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1);
			}
		}
	}
}

void AddTitle(const wchar_t* title)
{
	if (UI::Settings::Rainbow)
	{
		if (UI::Settings::GradientRGB)
		{
			drawGradientLeftRightRGB(textX - 5, textY - 5, bgW + menulenght, textI + 4, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1);
		}
		else
		{
			drawRectRGB(textX - 5, textY - 5, bgW + menulenght, textI + 4, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE);
		}
	}
	else
	{
		drawRect(textX - 5, textY - 5, bgW + menulenght, textI + 4, GetThemeColor());
	}

	Scrollbar();
	AddOpacityBG();

	DrawShadowText(title, TitleTextX + 4 + menulenght, TitleTextY, color(UI::Color::WHITE));
}

void AddHud(int sub)
{
	if (UI::Settings::Style)
	{
		if (UI::Settings::Rainbow)
		{
			if (UI::Settings::GradientRGB)
			{
				if (sub == 1) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, bgH - 2, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 2) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 21, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 3) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 31, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 4) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 41, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 5) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 51, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 6) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 61, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 7) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 71, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 8) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 81, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 9) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 91, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 10) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 101, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 11) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 111, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 12) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 121, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 13) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 131, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 14) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 141, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 15) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 151, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 16) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 161, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
			}
			else
			{
				if (sub == 1) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, bgH - 2, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 2) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 21, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 3) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 31, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 4) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 41, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 5) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 51, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 6) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 61, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 7) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 71, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 8) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 81, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 9) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 91, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 10) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 101, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 11) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 111, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 12) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 121, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 13) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 131, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 14) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 141, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 15) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 151, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 16) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 161, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
			}
		}
		else
		{
			if (sub == 1) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, bgH - 2, UI::Color::BLACK, GetThemeColor()); }
			else if (sub == 2) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 21, UI::Color::BLACK, GetThemeColor()); }
			else if (sub == 3) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 31, UI::Color::BLACK, GetThemeColor()); }
			else if (sub == 4) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 41, UI::Color::BLACK, GetThemeColor()); }
			else if (sub == 5) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 51, UI::Color::BLACK, GetThemeColor()); }
			else if (sub == 6) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 61, UI::Color::BLACK, GetThemeColor()); }
			else if (sub == 7) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 71, UI::Color::BLACK, GetThemeColor()); }
			else if (sub == 8) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 81, UI::Color::BLACK, GetThemeColor()); }
			else if (sub == 9) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 91, UI::Color::BLACK, GetThemeColor()); }
			else if (sub == 10) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 101, UI::Color::BLACK, GetThemeColor()); }
			else if (sub == 11) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 111, UI::Color::BLACK, GetThemeColor()); }
			else if (sub == 12) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 121, UI::Color::BLACK, GetThemeColor()); }
			else if (sub == 13) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 131, UI::Color::BLACK, GetThemeColor()); }
			else if (sub == 14) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 141, UI::Color::BLACK, GetThemeColor()); }
			else if (sub == 15) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 151, UI::Color::BLACK, GetThemeColor()); }
			else if (sub == 16) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 161, UI::Color::BLACK, GetThemeColor()); }
		}
	}
	else
	{
		if (UI::Settings::BGOpacity)
		{

		}
		else
		{
			if (sub == 1) { drawRect(bgX, bgY, bgW + menulenght, bgH, UI::Color::BLACK); }
			else if (sub == 2) { drawRect(bgX, bgY, bgW + menulenght, 21, UI::Color::BLACK); }
			else if (sub == 3) { drawRect(bgX, bgY, bgW + menulenght, 31, UI::Color::BLACK); }
			else if (sub == 4) { drawRect(bgX, bgY, bgW + menulenght, 41, UI::Color::BLACK); }
			else if (sub == 5) { drawRect(bgX, bgY, bgW + menulenght, 51, UI::Color::BLACK); }
			else if (sub == 6) { drawRect(bgX, bgY, bgW + menulenght, 61, UI::Color::BLACK); }
			else if (sub == 7) { drawRect(bgX, bgY, bgW + menulenght, 71, UI::Color::BLACK); }
			else if (sub == 8) { drawRect(bgX, bgY, bgW + menulenght, 81, UI::Color::BLACK); }
			else if (sub == 9) { drawRect(bgX, bgY, bgW + menulenght, 91, UI::Color::BLACK); }
			else if (sub == 10) { drawRect(bgX, bgY, bgW + menulenght, 101, UI::Color::BLACK); }
			else if (sub == 11) { drawRect(bgX, bgY, bgW + menulenght, 111, UI::Color::BLACK); }
			else if (sub == 12) { drawRect(bgX, bgY, bgW + menulenght, 121, UI::Color::BLACK); }
			else if (sub == 13) { drawRect(bgX, bgY, bgW + menulenght, 131, UI::Color::BLACK); }
			else if (sub == 14) { drawRect(bgX, bgY, bgW + menulenght, 141, UI::Color::BLACK); }
			else if (sub == 15) { drawRect(bgX, bgY, bgW + menulenght, 151, UI::Color::BLACK); }
			else if (sub == 16) { drawRect(bgX, bgY, bgW + menulenght, 161, UI::Color::BLACK); }
		}
	}
}

void AddOption(const wchar_t* opt)
{
	//bgH * subMax;
	//drawRect(textX - 5, textY - 5 + (scroll * 13), bgW, textI + 2, UI::Color::RED);
	if (UI::Settings::Rainbow)
	{
		if (menulenght > 25)
		{
			if (UI::Settings::Scrollbar)
			{
				UI_DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
				UI_DrawText(L">    ", AddOptX + 80 + menulenght, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
			}
			else
			{
				UI_DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE) : color(UI::Color::WHITE));
				UI_DrawText(L">    ", AddOptX + 80 + menulenght, AddOptY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE) : color(UI::Color::WHITE));
			}
		}
		else
		{
			if (UI::Settings::Scrollbar)
			{
				UI_DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
			}
			else
			{
				UI_DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE) : color(UI::Color::WHITE));
			}
		}
	}
	else
	{
		if (menulenght > 25)
		{
			if (UI::Settings::Scrollbar)
			{
				UI_DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
				UI_DrawText(L">    ", AddOptX + 80 + menulenght, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
			}
			else
			{
				UI_DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(GetThemeColor()) : color(UI::Color::WHITE));
				UI_DrawText(L">    ", AddOptX + 80 + menulenght, AddOptY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(GetThemeColor()) : color(UI::Color::WHITE));
			}
		}
		else
		{
			if (UI::Settings::Scrollbar)
			{
				UI_DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
			}
			else
			{
				UI_DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(GetThemeColor()) : color(UI::Color::WHITE));
			}
		}
	}
	MaxOption += 1;
}

void AddBoolOption(const wchar_t* opt, bool boolOption)
{
	//drawRectBorder(115, 52 + (10 * MaxOption), 4, 4, (boolOption) ? UI::Color::BLACK : THEME, UI::Color::WHITE);
	if (UI::Settings::Rainbow)
	{
		if (UI::Settings::Scrollbar)
		{
			UI_DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
		}
		else
		{
			UI_DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE) : color(UI::Color::WHITE));
		}
		if (UI::Settings::Checkbox)
		{
			if (menulenght > 25)
			{
				int color1[3] = { 65, 65, 65 };
				int color2[3] = { 40, 40, 40 };
				DrawToggleONOFF(CheckBoxX - 30 + menulenght, CheckBoxY + (10 * MaxOption), color1, UI::Color::BLACK, boolOption);
			}
			else
			{
				drawRectBorderRGBV2(CheckBoxX + menulenght, CheckBoxY + 2 + (10 * MaxOption), 4, 4, (boolOption) ? 15, 15, 15 : UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::WHITE);
			}
		}
		else
		{
			if (UI::Settings::Scrollbar)
			{
				UI_DrawText(boolOption ? L"" : L"+     ", CheckBoxX + menulenght, CheckBoxY + (10 * MaxOption), color(UI::Color::WHITE));
			}
			else
			{
				UI_DrawText(boolOption ? L"" : L"+     ", CheckBoxX + menulenght, CheckBoxY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE) : color(UI::Color::WHITE));
			}
		}
	}
	else
	{
		if (UI::Settings::Scrollbar)
		{
			UI_DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
		}
		else
		{
			UI_DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(GetThemeColor()) : color(UI::Color::WHITE));
		}
		if (UI::Settings::Checkbox)
		{
			if (menulenght > 25)
			{
				int color1[3] = { 65, 65, 65 };
				int color2[3] = { 40, 40, 40 };
				DrawToggleONOFF(CheckBoxX  - 30 + menulenght, CheckBoxY + (10 * MaxOption), color1, UI::Color::BLACK, boolOption);
			}
			else
			{
				drawRectBorder(CheckBoxX + menulenght, CheckBoxY + 2 + (10 * MaxOption), 4, 4, (boolOption) ? UI::Color::BLACK : GetThemeColor(), UI::Color::WHITE);
			}
		}
		else
		{
			if (UI::Settings::Scrollbar)
			{
				UI_DrawText(boolOption ? L"" : L"+     ", CheckBoxX + menulenght, CheckBoxY + (10 * MaxOption), color(UI::Color::WHITE));
			}
			else
			{
				UI_DrawText(boolOption ? L"" : L"+     ", CheckBoxX + menulenght, CheckBoxY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(GetThemeColor()) : color(UI::Color::WHITE));
			}
		}
	}
	MaxOption += 1;
}

void AddIntOption(const wchar_t* opt, int IntOptions)
{
	UI_DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
	char option46[0x100];
	wchar_t woption46[0x100];
	_sys_memset(option46, 0, 0x100);
	_sys_memset(woption46, 0, 0x200);
	_sys_snprintf(option46, 0x100, "%i     ", (int)IntOptions);
	StringToWideCharacter(woption46, option46, _sys_strlen(option46));

	/*
	if (menulenght > 80)
	{
		UI_DrawText(woption46, CheckBoxX - 55 + menulenght, CheckBoxY + (10 * MaxOption), color(UI::Color::WHITE));
		drawRectBorder(CheckBoxX - 35 + menulenght, CheckBoxY + 2 + (10 * MaxOption), 40, 3, UI::Color::BLACK, GetThemeColor());
		if (IntOptions > 1)
		{
			float value = IntOptions - 0.8;
			drawRect(CheckBoxX - 35 + menulenght, CheckBoxY + 2.5 + (10 * MaxOption), value, 2.3, UI::Color::WHITE);
		}
	}
	else
	{
		UI_DrawText(woption46, CheckBoxX - 3 + menulenght, CheckBoxY + (10 * MaxOption), color(UI::Color::WHITE));
	}
	*/
	UI_DrawText(woption46, CheckBoxX - 5 + menulenght, CheckBoxY + (10 * MaxOption), color(UI::Color::WHITE));
	MaxOption += 1;
}

void AddFloatOption(const wchar_t* opt, float FloatOptions)
{
	UI_DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
	char option46[0x100];
	wchar_t woption46[0x100];
	_sys_memset(option46, 0, 0x100);
	_sys_memset(woption46, 0, 0x200);
	_sys_snprintf(option46, 0x100, "%i    ", (int)FloatOptions);
	StringToWideCharacter(woption46, option46, _sys_strlen(option46));
	UI_DrawText(woption46, CheckBoxX - 3 + menulenght, CheckBoxY + (10 * MaxOption), color(UI::Color::WHITE));
	MaxOption += 1;
}