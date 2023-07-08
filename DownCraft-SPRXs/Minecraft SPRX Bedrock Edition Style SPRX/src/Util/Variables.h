#pragma once

enum eMenus
{
	MainMenu, MainOptions
};

namespace MC_Color
{
	int DarkRed[3] = { 170, 0, 0 };
	int Red[3] = { 255, 85, 85 };
	int Gold[3] = { 255, 170, 0 };
	int Orange[3] = { 255, 143, 16 };
	int Yellow[3] = { 255, 255, 85 };
	int DarkGreen[3] = { 0, 170, 0 };
	int Green[3] = { 85, 255, 85 };
	int Aqua[3] = { 85, 255, 255 };
	int DarkAqua[3] = { 0, 170, 170 };
	int DarkBlue[3] = { 0, 0, 170 };
	int Blue[3] = { 85, 85, 255 };
	int LightPurple[3] = { 255, 85, 255 };
	int DarkPurple[3] = { 170, 0, 170 };
	int White[3] = { 255, 255, 255 };
	int Gray[3] = { 170, 170, 170 };
	int DarkGray[3] = { 85, 85, 85 };
	int Black[3] = { 0, 0, 0 };
	int BlackTheme[3] = { 32, 32, 32 };
	int DescColor[4] = { 10, 10, 10, 50 };
	int BoolColors[3] = { 65, 65, 65 };

	//BEDROCK
	int header_color1[3] = { 198, 198, 198 };
	int header_color2[3] = { 88, 86, 89 };
	int black_line[3] = { 6, 6, 6 };
	int bg_color[3] = { 49, 50, 51 };
	int ScrollColor[3] = { 85, 255, 85 };
	int bool_on[3] = { 127, 127, 127 };
	int bool_off[3] = { 64, 64, 64 };
};

//Initial Vars
char* checkTxt = "";
wchar_t charA2wcharA_[1000];
int lastMenus[20];
int lastMenuCount = 0;

//Scroller
bool gotTime[1000], keyPressed[100], freeFirst[100], resetWait[100], resetWait2[100], lockFirst[100];
int getTime[1000], firstWaitTime = 15, waitTime = 5, scrollTick = 0, timeMath[1000], scroll = 0;

//Menu settings
int CurrentMenu, CurrentOpt, MaxOption, MaxSubOptions, optionPress, returnPress, SpaceBetweenText = 15;
bool UsableMenu = true, Opened, Closed, FirstOpen;

bool ToggleTitle, TogglePosition;

//Rainbow color
int MenuColourTime = 0, RainbowTime = 0, RainbowRED1, RainbowGREEN1, RainbowBLUE1, RainbowRED2, RainbowGREEN2, RainbowBLUE2, RainbowColor[3];
int Rainbow[3] = { RainbowRED1, RainbowGREEN1, RainbowBLUE1 };