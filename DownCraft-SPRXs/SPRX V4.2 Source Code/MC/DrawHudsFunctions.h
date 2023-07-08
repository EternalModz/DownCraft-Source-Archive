#pragma once

#pragma region "Draw Functions"

void drawLineLocation(const float* start, const float* end)
{
	int color[3] = { 50, 50, 50 };
	float startl[3] = { start[0] - mc->theMinecraft->cLevelRenderer->location[0], start[1] - mc->theMinecraft->cLevelRenderer->location[1], start[2] - mc->theMinecraft->cLevelRenderer->location[2] };
	float endl[3] = { end[0] - mc->theMinecraft->cLevelRenderer->location[0], end[1] - mc->theMinecraft->cLevelRenderer->location[1], end[2] - mc->theMinecraft->cLevelRenderer->location[2] };
	//float startl[3] = { start[0] - mc->theMinecraft->cMultiplayerLocalPlayer->LocationX, start[1] - mc->theMinecraft->cMultiplayerLocalPlayer->LocationY, start[2] - mc->theMinecraft->cMultiplayerLocalPlayer->LocationZ };
	//float endl[3] = { end[0] - mc->theMinecraft->cMultiplayerLocalPlayer->LocationX, end[1] - mc->theMinecraft->cMultiplayerLocalPlayer->LocationY, end[2] - mc->theMinecraft->cMultiplayerLocalPlayer->LocationZ };

	uint32_t pTesselator = FUNCTIONS::ReadTesselatorInstance(FUNCTIONS::Tesselator_GetInstance());
	FUNCTIONS::Tesselator_Begin(pTesselator);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, start[0], start[1], start[2], color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, end[0], end[1], end[2], color);
	FUNCTIONS::Tesselator_End(pTesselator);
}

void drawLine(const int& start, const int& end, int* color)
{
	float modX = 1 + (start);
	float modY = start;

	float len = sqrtf(modX * modX + modY * modY);

	modX /= len;
	modY /= len;

	uint32_t pTesselator = FUNCTIONS::ReadTesselatorInstance(FUNCTIONS::Tesselator_GetInstance());
	FUNCTIONS::Tesselator_Begin(pTesselator);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, start + modX, start + modY, 0, color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, start - modX, start - modY, 0, color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, end - modX, end - modY, 0, color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, start + modX, start + modY, 0, color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, end + modX, end + modY, 0, color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, end - modX, end - modY, 0, color);
	FUNCTIONS::Tesselator_End(pTesselator);
}

void drawLineWidth(const float& start, const float& end, float lineWidth)
{
	int color[3] = { 50, 50, 50 };
	float modX = 0 - (start - end);
	float modY = start - end;

	float len = sqrtf(modX * modX + modY * modY);

	modX /= len;
	modY /= len;
	modX *= lineWidth;
	modY *= lineWidth;

	uint32_t pTesselator = FUNCTIONS::ReadTesselatorInstance(FUNCTIONS::Tesselator_GetInstance());
	FUNCTIONS::Tesselator_Begin(pTesselator);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, start + modX, start + modY, 0, color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, start - modX, start - modY, 0, color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, end - modX, end - modY, 0, color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, start + modX, start + modY, 0, color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, end + modX, end + modY, 0, color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, end - modX, end - modY, 0, color);
	FUNCTIONS::Tesselator_End(pTesselator);
}

void drawRectRGB(float x, float y, float w, float h, int R, int G, int B)
{
	int colored[3] = { R, G, B };
	uint32_t pTesselator = FUNCTIONS::ReadTesselatorInstance(FUNCTIONS::Tesselator_GetInstance());
	FUNCTIONS::Tesselator_Begin(pTesselator);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, h + y, 0, colored);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, h + y, 0, colored);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, y, 0, colored);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, y, 0, colored);
	FUNCTIONS::Tesselator_End(pTesselator);
}

void drawGradientLeftRight(float x, float y, float w, float h, int* Color, int* Color2)
{
	uint32_t pTesselator = FUNCTIONS::ReadTesselatorInstance(FUNCTIONS::Tesselator_GetInstance());
	FUNCTIONS::Tesselator_Begin(pTesselator);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, h + y, 0, Color2); //left down
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, h + y, 0, Color); //right down
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, y, 0, Color); //right up
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, y, 0, Color2); //left up
	FUNCTIONS::Tesselator_End(pTesselator);
}

void drawGradientUpDown(float x, float y, float w, float h, int* Color, int* Color2)
{
	uint32_t pTesselator = FUNCTIONS::ReadTesselatorInstance(FUNCTIONS::Tesselator_GetInstance());
	FUNCTIONS::Tesselator_Begin(pTesselator);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, h + y, 0, Color2); //left down
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, h + y, 0, Color2); //right down
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, y, 0, Color); //right up
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, y, 0, Color); //left up
	FUNCTIONS::Tesselator_End(pTesselator);
}

void drawGradientAllColors(float x, float y, float w, float h, int* Color, int* Color2, int* Color3, int* Color4)
{
	uint32_t pTesselator = FUNCTIONS::ReadTesselatorInstance(FUNCTIONS::Tesselator_GetInstance());
	FUNCTIONS::Tesselator_Begin(pTesselator);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, h + y, 0, Color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, h + y, 0, Color2);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, y, 0, Color3);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, y, 0, Color4);
	FUNCTIONS::Tesselator_End(pTesselator);
}

void drawGradient(float x, float y, float w, float h, int* Color, int* Color2)
{
	uint32_t pTesselator = FUNCTIONS::ReadTesselatorInstance(FUNCTIONS::Tesselator_GetInstance());
	FUNCTIONS::Tesselator_Begin(pTesselator);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, h + y, 0, Color2);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, h + y, 0, Color);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, y, 0, Color2);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, y, 0, Color);
	FUNCTIONS::Tesselator_End(pTesselator);
}

void drawGradientLeftRightRGB(float x, float y, float w, float h, int R, int G, int B, int R1, int G1, int B1)
{
	int colored1[3] = { R, G, B };
	int colored2[3] = { R1, G1, B1 };
	uint32_t pTesselator = FUNCTIONS::ReadTesselatorInstance(FUNCTIONS::Tesselator_GetInstance());
	FUNCTIONS::Tesselator_Begin(pTesselator);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, h + y, 0, colored2); //left down
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, h + y, 0, colored1); //right down
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, y, 0, colored1); //right up
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, y, 0, colored2); //left up
	FUNCTIONS::Tesselator_End(pTesselator);
}

void drawGradientUpDownRGB(float x, float y, float w, float h, int R, int G, int B, int R1, int G1, int B1)
{
	int colored1[3] = { R, G, B };
	int colored2[3] = { R1, G1, B1 };
	uint32_t pTesselator = FUNCTIONS::ReadTesselatorInstance(FUNCTIONS::Tesselator_GetInstance());
	FUNCTIONS::Tesselator_Begin(pTesselator);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, h + y, 0, colored1); //left down
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, h + y, 0, colored1); //right down
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, y, 0, colored2); //right up
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, y, 0, colored2); //left up
	FUNCTIONS::Tesselator_End(pTesselator);
}

void drawGradientRGB(float x, float y, float w, float h, int R, int G, int B, int R1, int G1, int B1)
{
	int colored1[3] = { R, G, B };
	int colored2[3] = { R1, G1, B1 };
	uint32_t pTesselator = FUNCTIONS::ReadTesselatorInstance(FUNCTIONS::Tesselator_GetInstance());
	FUNCTIONS::Tesselator_Begin(pTesselator);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, h + y, 0, colored1);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, h + y, 0, colored2);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, w + x, y, 0, colored1);
	FUNCTIONS::Tesselator_EndVertex(pTesselator, x, y, 0, colored2);
	FUNCTIONS::Tesselator_End(pTesselator);
}

void drawRectBorderRGB(float x, float y, float w, float h, int* Color1, int R, int G, int B)
{
	drawRectRGB(x - 1, y - 1, w + 2, h + 2, R, G, B);
	DrawRectangle(x, y, w, h, Color1);
}

void drawRectBorderRGBV2(float x, float y, float w, float h, int R, int G, int B, int* Color1)
{
	DrawRectangle(x - 1, y - 1, w + 2, h + 2, Color1);
	drawRectRGB(x, y, w, h, R, G, B);
}

void drawRectBorderRGBV3(float x, float y, float w, float h, int* Color1, int R, int G, int B, int R1, int G1, int B1)
{
	drawGradientLeftRightRGB(x - 1, y - 1, w + 2, h + 2, R, G, B, R1, G1, B1);
	DrawRectangle(x, y, w, h, Color1);
}

void DrawHorizontalLine(int startX, int endX, int y, int* color)
{
	if (endX < startX)
	{
		int i = startX;
		startX = endX;
		endX = i;
	}
	DrawRectangle(startX + 1, y, endX + 1, 1, color);
}

void DrawVerticalLine(int x, int startY, int endY, int* color)
{
	int width = 1;
	if (x < startY)
	{
		int i = startY;
		startY = endY;
		endY = i;
	}
	DrawRectangle(x, startY + 1, 1, endY, color);
}

void snprintf(const char* text, int valeur, int X, int Y)
{
	char option4[0x100];
	wchar_t woption4[0x100];
	_sys_memset(option4, 0, 0x100);
	_sys_memset(woption4, 0, 0x200);
	_sys_snprintf(option4, 0x100, text, (valeur));
	StringToWideCharacter(woption4, option4, _sys_strlen(option4));
	DrawText(woption4, X, Y, color(UI::Color::WHITE));
}

void drawLineTest(const Vector2& start, const Vector2& end, int* color, float lineWidth)
{
	float modX = 0 - (start.y - end.y);
	float modY = start.x - end.x;

	float len = sqrtf(modX * modX + modY * modY);

	modX /= len;
	modY /= len;
	modX *= lineWidth;
	modY *= lineWidth;

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

void DrawTextWithRect(const wchar_t* text, float x, float y, uint32_t color)
{
	int width = Font_width(text);
	DrawRectangle(x - 3, y - 1, width + 5, 10, UI::Color::BLACK);
	DrawText(text, x, y, color);
}

#pragma endregion
