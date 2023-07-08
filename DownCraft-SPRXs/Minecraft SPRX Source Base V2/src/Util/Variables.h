#pragma once

enum eMenus
{
	MainMenu, MainOptions, TeleportMenu, SettingsMenu, ColorMenu, CreditsMenu
};

//Initial Vars
const wchar_t* titleSPRX = L"Minecraft SPRX";
int MenuR = 0, MenuG = 147, MenuB = 255, MenuGradient1R = 0, MenuGradient1G = 0, MenuGradient1B = 255, MenuGradient2R = 0, MenuGradient2G = 255, MenuGradient2B = 0;
int MenuX, MenuY;

//Others vars
char* checkTxt = "";
wchar_t charA2wcharA_[1000];
uint32_t cpu_t = 0;
uint32_t rsx_t = 0;


//Scroller
bool gotTime[1000], keyPressed[100], freeFirst[100], resetWait[100], resetWait2[100], lockFirst[100];
int getTime[1000], firstWaitTime = 15, waitTime = 5, scrollTick = 0, timeMath[1000], scroll = 0;

//Menu settings
int CurrentMenu, CurrentOpt, MaxOption, MaxSubOptions, optionPress, returnPress, SpaceBetweenText = 11;
bool BtnLeftPressed, BtnRightPressed;
bool Opened, Closed, FirstOpen, GradientMenu;
int MenuColorAlpha = 255, MenuColorAlphaTitle = 255, MenuColorAlphaDescription = 255;
int SavePosition, AnimationSpeed = 10;
int SaveMenuX, speedSlider = 10, menuLenght = 5, MenuBorderSize;
char* ThemeColors = "RGB";

//Teleport options
int CoordX, CoordY, CoordZ;

//Main Options
bool GodMode, SuperSpeed;

//Rainbow color
int MenuColourTime = 0, RainbowTime = 0, RainbowRED1, RainbowGREEN1, RainbowBLUE1, RainbowRED2, RainbowGREEN2, RainbowBLUE2, RainbowColor[3];
int Rainbow[3] = { RainbowRED1, RainbowGREEN1, RainbowBLUE1 };

int lastMenus[20];
int lastMenuCount = 0;