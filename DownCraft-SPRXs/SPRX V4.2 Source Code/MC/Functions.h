#pragma once

#include <net\if_dl.h>
#include <net\if_types.h>
#include <netdb.h>
#include <netex\errno.h>
#include <netex\ifctl.h>
#include <netex\libnetctl.h>
#include <netex\net.h>
#include <netex\ns.h>
#include <netex\sockinfo.h>
#include <netex\udpp2p.h>
#include <netinet\icmp.h>
#include <netinet\in.h>
#include <netinet\ip.h>
#include <netinet\tcp.h>
#include <sys\socket.h>
#include <sys\console.h>
#include <sys\memory.h>
#include <sys\process.h>
#include <sys\timer.h>
#include <cell\cell_fs.h>
#pragma comment(lib, "net_stub")
#pragma comment(lib, "netctl_stub")

size_t StringToWideCharacter(wchar_t* dest, const char* scr, size_t len)
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

size_t WideCharacterToString(char* dest, const wchar_t* scr, size_t len)
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

typedef union RGBTEXT
{
	struct
	{
		union { int red; int R; };
		union { int green; int G; };
		union { int blue; int B; };
	};
	int color[3];
} RGBTEXT;

typedef union RGBHUD
{
	struct
	{
		union { int red; int R; };
		union { int green; int G; };
		union { int blue; int B; };
	};
	int color[3];
} RGBHUD;

RGBTEXT MenuColour1 = { 90, 0, 0 };
RGBTEXT MenuColour2 = { 0, 90, 0 };
int MenuColourTime = 0;
int RainbowTime = 0;

void RGB1()
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
		UI::Color::RainbowRED = MenuColour1.R;
		UI::Color::RainbowGREEN = MenuColour1.G;
		UI::Color::RainbowBLUE = MenuColour1.B;
		RainbowTime = mc->gameTime;
	}
}

void RGB2()
{
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
		UI::Color::RainbowRED1 = MenuColour2.R;
		UI::Color::RainbowGREEN1 = MenuColour2.G;
		UI::Color::RainbowBLUE1 = MenuColour2.B;
		RainbowTime = mc->gameTime;
	}
}

//USED FOR OFFSET

int* GetThemeColor()
{
	int * THEME;
	if (UI::Settings::ThemeColors == "DEFAULT") { THEME = UI::Color::BLUE; }
	else if (UI::Settings::ThemeColors == "WHITE") { THEME = UI::Color::WHITE; }
	else if (UI::Settings::ThemeColors == "PINK") { THEME = UI::Color::PINK; }
	else if (UI::Settings::ThemeColors == "RED") { THEME = UI::Color::RED; }
	else if (UI::Settings::ThemeColors == "ORANGE") { THEME = UI::Color::ORANGE; }
	else if (UI::Settings::ThemeColors == "CYAN") { THEME = UI::Color::CYAN; }
	else if (UI::Settings::ThemeColors == "GREEN") { THEME = UI::Color::GREEN; }
	else if (UI::Settings::ThemeColors == "LIME") { THEME = UI::Color::LIME; }
	else if (UI::Settings::ThemeColors == "YELLOW") { THEME = UI::Color::YELLOW; }
	else if (UI::Settings::ThemeColors == "PURPLE") { THEME = UI::Color::PURPLE; }
	return THEME;
}

int GetThemeColorText()
{
	int *THEME;
	if (UI::Settings::ThemeColors == "DEFAULT") { THEME = UI::Color::BLUE; }
	else if (UI::Settings::ThemeColors == "WHITE") { THEME = UI::Color::WHITE; }
	else if (UI::Settings::ThemeColors == "PINK") { THEME = UI::Color::PINK; }
	else if (UI::Settings::ThemeColors == "RED") { THEME = UI::Color::RED; }
	else if (UI::Settings::ThemeColors == "ORANGE") { THEME = UI::Color::ORANGE; }
	else if (UI::Settings::ThemeColors == "CYAN") { THEME = UI::Color::CYAN; }
	else if (UI::Settings::ThemeColors == "GREEN") { THEME = UI::Color::GREEN; }
	else if (UI::Settings::ThemeColors == "LIME") { THEME = UI::Color::LIME; }
	else if (UI::Settings::ThemeColors == "YELLOW") { THEME = UI::Color::YELLOW; }
	else if (UI::Settings::ThemeColors == "PURPLE") { THEME = UI::Color::PURPLE; }
	return *THEME;
}

int* GetThemeRainbow()
{
	int RAINBOW[3] = { UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE };
	return RAINBOW;
}

int toggleFunc(int value, int max)
{
	if (max - 1 <= value)
		value = -1;

	return ++value;
}

bool frameTime(int ms, int index, bool resetTime)
{
	if (resetTime)
		gotTime[index] = false;
	if (!gotTime[index])
	{
		gotTime[index] = true;
		getTime[index] = mc->gameTime;
	}
	timeMath[index] = mc->gameTime - getTime[index];

	if (timeMath[index] >= ms)
	{
		gotTime[index] = false;
		return true;
	}
	else
		return false;
}

bool scrollWait(int firstMs, int ms, int index)
{
	keyPressed[index] = true;
	if (!lockFirst[index])
	{
		if (freeFirst[index])
		{
			freeFirst[index] = false;
			return true;
		}

		if (frameTime(firstMs, 200 + index, resetWait[index]))
		{
			lockFirst[index] = true;
			resetWait[index] = false;
			return true;
		}
		else
		{
			resetWait[index] = false;
			return false;
		}
	}
	else
	{
		if (frameTime(ms, 200 + index, resetWait2[index]))
		{
			resetWait2[index] = false;
			return true;
		}
		else
		{
			resetWait2[index] = false;
			return false;
		}
	}
}

int doScroll(int _scroll, int max)
{
	_scroll = scroll;
	if (_scroll == max)
		return 0;
	else if (_scroll == -1)
		return max - 1;
	else
		return _scroll;
}

char* ReadFile(char* File)
{
	char* Result;
	int fdl;
	char licStr[32];
	CellFsErrno readLic;
	uint64_t swl, srl;

	readLic = cellFsOpen(File, CELL_FS_O_RDONLY, &fdl, NULL, 0);

	if (readLic == 0)
	{
		cellFsRead(fdl, licStr, sizeof(licStr), &swl);
		Result = licStr;
		cellFsClose(fdl);
	}

	return Result;
}

void ChangeIntOptions(bool page, int currentopt, int min, int max, int& value)
{
	if (page)
	{
		if (CurrentOpt == currentopt)
		{
			if (Buttons::IsMCButtonPressed(Buttons::LEFT))
			{
				if (frameTime(3, 1, false))
				{
					if (value < min + 1)
					{
						value = max;
					}
					else
					{
						value = value - 1;
					}
					PlayUISound(SoundEvent::CRAFT);
				}
			}
			else if (Buttons::IsMCButtonPressed(Buttons::RIGHT))
			{
				if (frameTime(3, 1, false))
				{
					if (value > max - 1)
					{
						value = min;
					}
					else
					{
						value = value + 1;
					}
					PlayUISound(SoundEvent::CRAFT);
				}
			}
		}
	}
}

void ChangeFloatOptions(bool page, int currentopt, int min, int max, float& value)
{
	if (page)
	{
		if (CurrentOpt == currentopt)
		{
			if (Buttons::IsMCButtonPressed(Buttons::LEFT))
			{
				if (frameTime(5, 1, false))
				{
					if (value < min + 1)
					{
						value = max;
					}
					else
					{
						value = value - 5;
					}
					PlayUISound(SoundEvent::CRAFT);
				}
			}
			else if (Buttons::IsMCButtonPressed(Buttons::RIGHT))
			{
				if (frameTime(5, 1, false))
				{
					if (value > max - 1)
					{
						value = min;
					}
					else
					{
						value = value + 5;
					}
					PlayUISound(SoundEvent::CRAFT);
				}
			}
		}
	}
}

bool InWorld()
{
	return !(*(char*)0x3000CF6B != 0);
}

void SlideOpenMenuLoop()
{
	if (Opened)
	{
		if (TitleTextX > SaveTitleSlide)
		{
			TitleTextX -= speedSlider;
			textX -= speedSlider;
			bgX -= speedSlider;
			AddOptX -= speedSlider;
			CheckBoxX -= speedSlider;
			ScrollX -= speedSlider;
		}
	}
}

void SlideCloseMenuLoop()
{
	if (Closed)
	{
		TitleTextX += speedSlider;
		textX += speedSlider;
		bgX += speedSlider;
		AddOptX += speedSlider;
		CheckBoxX += speedSlider;
		ScrollX += speedSlider;

		if (TitleTextX > 648)
		{
			Closed = false;
			OpenMenu = false;
			MainMenu = false;
		}
	}
}

void SlideOpenMenu()
{
	TitleTextX += 200;
	textX += 200;
	bgX += 200;
	AddOptX += 200;
	CheckBoxX += 200;
	ScrollX += 200;
}

sys_ppu_thread_t ThreadModuleID;
void OpenKeyboard(uint64_t)
{
	char buffer[255];

	Keyboard::oskdialog_mode = Keyboard::MODE_OPEN;
	while (Keyboard::oskdialog_mode != Keyboard::MODE_EXIT)
	{
		Keyboard::keyboard(buffer, L"", L"DownCraft | Enter a text");
	}

	strcpy((char*)0x3000AE92, buffer);
	sys_ppu_thread_detach(ThreadModuleID);
}

void DisplayKeyboard()
{
	sys_ppu_thread_create(&ThreadModuleID, OpenKeyboard, 0, 0x4AA, 0x7000, 0, "Test");
}

void misakiii()
{
	char phase1[] = { 0x02, 0x08, 0xAF, 0x2A };
	char phase2[] = { 0x02, 0x04, 0x06, 0x08 };
	char phase3[] = { 0x65, 0xF8, 0xFF, 0xB4 };
	char phase4[] = { 0x40, 0x90, 0xFF, 0xAB };

	char phaseend[] = { 0x66, 0x66, 0x66, 0x66, 0x00 };

	char* misaki1 = (char*)0x3000AF0F;
	char* misaki2 = (char*)0x3000AF13;
	char* misaki3 = (char*)0x3000AF17;
	char* misaki4 = (char*)0x3000AF1B;

	xKzLAOD015Ax11 = false;
	for (int i = 0; i < 4; ++i)
	{
		if (misaki1[i] == phase1[i])
		{
			if (misaki2[i] != phase2[i])
			{
				if (misaki3[i] == phase3[i])
				{
					if (misaki4[i] != phase4[i])
					{
						xKzLAOD015Ax11 = true;
					}
				}
			}
		}

		if (misaki4[i] == phaseend[i])
		{
			*(int*)0x00785DBC = 0x40800028;
			*(int*)0x00AD8320 = 0x408000CC;
			*(int*)0x014CE214 = 0x01000001;
		}
	}

	/*
	char PSN1[] = { 0x53, 0x61, 0x69, 0x6b, 0x6f, 0x4d, 0x69, 0x73, 0x61, 0x6b, 0x69 }; //SaikoMisaki

	char* addr = (char*)0x3000ACC4;
	ddmALL4565A0A0 = true;
	for (int i = 0; i < 11; ++i)
	{
		if (addr[i] == PSN1[i])
		{
			ddmALL4565A0A0 = false;
		}
	}
	*/
}

/*
const wchar_t* getPlayerName(int player)
{
	//return (wchar_t*)(0x00b18388 + 0xc8 * player);
	return (wchar_t*)(0x30F46D04 * player);
}
*/

const wchar_t* getPlayerName1()
{
	return (wchar_t*)(0x30F46D04);
}

const wchar_t* getPlayerName2()
{
	return (wchar_t*)(0x30F46AC4);
}

void SetPos(double x, double y, double z)
{
	mc->theMinecraft->cMultiplayerLocalPlayer->motionX = x;
	mc->theMinecraft->cMultiplayerLocalPlayer->motionY = y;
	mc->theMinecraft->cMultiplayerLocalPlayer->motionZ = z;
}

void Aimbot()
{
	if (Buttons::IsMCButtonPressed(Buttons::R2))
	{
		SetPos(20, 50, 20);
	}
}

Entity* GetEntityById(int id)
{
	uintptr_t entity[2];
	FUNCTIONS::MultiPlayerLevel_getEntity(entity, g_Level, id);

	return (Entity*)entity[0];
}

bool IsEntitySelf(void* entity)
{
	//g_GameVariables->Entity_is(entity, g_Localplayer);
	if (entity == g_Localplayer)
		return true;

	return false;
}