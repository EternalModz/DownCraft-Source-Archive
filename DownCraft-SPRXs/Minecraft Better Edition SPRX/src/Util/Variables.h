#pragma once

enum eMenus
{
	MainMenu, BetterMenu, MicsMenu, SettingsMenu, CreditsMenu
};

namespace MC_Color
{
	int DarkRed[3] = { 170, 0, 0 };
	int Red[3] = { 255, 85, 85 };
	int Gold[3] = { 255, 170, 0 };
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
	int ColorTheme[3] = { 0, 147, 255 };
	int DescColor[4] = { 10, 10, 10, 50 };
};

char* checkTxt = "";
wchar_t charA2wcharA_[1000];

int MenuX = -41, MenuY = 6;

//Send Message Info
int SendMessageInfoPosX = 467, SendMessageInfoPosY = 43;
int SendMessageInfoRectColor[] = { 22, 8, 21 }, SendMessageInfoBorderColor[] = { 34, 8, 72 };

//Scroller
bool gotTime[1000], keyPressed[100], freeFirst[100], resetWait[100], resetWait2[100], lockFirst[100];
int getTime[1000], firstWaitTime = 15, waitTime = 5, scrollTick = 0, timeMath[1000], scroll = 0;

//menu
int CurrentMenu, CurrentOpt, MaxOption, MaxSubOptions, optionPress, returnPress, SpaceBetweenText = 11;
bool BtnLeftPressed, BtnRightPressed;
bool Opened, Closed;
int MenuColorAlpha = 255, MenuColorAlphaTitle = 255, MenuColorAlphaDescription = 255;
int SavePosition, AnimationSpeed = 10;
int SaveMenuX, speedSlider = 10;
bool ToggleTitleSPRX = true, TogglePosition, ToggleGametime, TogglePing, ToggleKeystrokes, ToggleCPS;

//Rainbow color
int MenuColourTime = 0, RainbowTime = 0, RainbowRED1, RainbowGREEN1, RainbowBLUE1, RainbowRED2, RainbowGREEN2, RainbowBLUE2,  RainbowColor[3];
int Rainbow[3] = { RainbowRED1, RainbowGREEN1, RainbowBLUE1 };

//Keystrokes
float keystrokesBase_x = 0, keystrokesBase_y = 0;
int keystrokes_TextX[] = { 60,60,42,78 }, keystrokes_TextY[] = { 254,272,272,272 };
int* keystrokes_TextColor[] = { MC_Color::White, MC_Color::White, MC_Color::White, MC_Color::White };
int keystrokesHudX[] = { 55,55,37,73,37,40 }, keystrokesHudY[] = { 250,268,268,268,288,294 }, HudW[] = { 15,15,15,15,51,45 }, HudH[] = { 15,15,15,15,10,0 };
int* keystrokesHudColor1[] = { MC_Color::BlackTheme, MC_Color::BlackTheme, MC_Color::BlackTheme, MC_Color::BlackTheme, MC_Color::BlackTheme, MC_Color::White };

int lastMenus[20];
int lastMenuCount = 0;