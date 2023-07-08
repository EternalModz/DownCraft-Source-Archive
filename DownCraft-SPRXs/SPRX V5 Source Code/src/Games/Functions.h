#pragma once

#pragma region "Function Colors"

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

int* GetThemeRainbow()
{
	int RAINBOW[3] = { RainbowRED1, RainbowGREEN1, RainbowBLUE1 };
	return RAINBOW;
}

int* GetThemeColor()
{
	int RGB[] = { MenuR, MenuG, MenuB };
	int* THEME[3];
	if (ThemeColors == "RAINBOW") { THEME[3] = GetThemeRainbow(); }
	else if (ThemeColors == "RGB") { THEME[3] = { RGB }; }
	return THEME[3];
}

#pragma endregion
#pragma region "Buttons"

namespace Buttons
{
	unsigned int
		X = 0x100,
		O = 0x200,
		SQUARE = 0x400,
		TRIANGLE = 0x800,
		UP = 0x40000,
		DOWN = 0x80000,
		LEFT = 0x100000,
		RIGHT = 0x200000,
		R1 = 0x4000,
		R2 = 0x0, //NEED FOUND
		R3 = 0x10000,
		L1 = 0x8000,
		L2 = 0x0, //NEED FOUND
		L3 = 0x20000,
		START = 0x2000,
		SELECT = 0x1000,
		JOYSTICK_L3_UP = 0x20000000,
		JOYSTICK_L3_DOWN = 0x10000000,
		JOYSTICK_L3_LEFT = 0x00800000,
		JOYSTICK_L3_RIGHT = 0x00400000;

	unsigned int getMCButtons()
	{
		return *(unsigned int*)(0x3000CF79);
	}

	bool IsMCButtonPressed(unsigned int Buttons)
	{
		return (getMCButtons() & Buttons) > 0;
	}
}

#pragma endregion
#pragma region "Menu Function"

void ToggleHUD()
{
	if (Opened)
		*(int*)0x0155847C = 0x01000000;
	else
		*(int*)0x0155847C = 0x00000000;
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

int lastMenus[20];
int lastMenuCount = 0;
void openSubmenu(int menu)
{
	lastMenus[lastMenuCount] = CurrentMenu;
	lastMenuCount++;
	CurrentOpt = 0;
	CurrentMenu = menu;
}

void closeSubmenu()
{
	lastMenuCount = 0;
	CurrentOpt = 0;
	Opened = false;
}

void goBack()
{
	if (lastMenuCount == 0)
	{
		closeSubmenu();
	}
	else
	{
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
#pragma region "Send Notification"

namespace logs
{
	Color BLACK_OPACITY{ 15, 15, 15, 200 };
	typedef int64_t _QWORD;
	signed char logs_count = -1;
	uint64_t get_time_now()
	{
		return sys_time_get_system_time() / 1000;
	}
	struct timer_fade
	{
		wchar_t* message;
		int color[3];
		_QWORD start_time;
		_QWORD end_time;
		int duration;
	};
	timer_fade logs[12];

	void SendMessageDebug(wchar_t* logsmsg = L"", int* color = MC_TextColor::White, int duration = 10000)//10sec
	{
		for (byte a = 11; a > 0; a--)
		{
			logs[a].message = logs[a - 1].message;
			logs[a].color[0] = logs[a - 1].color[0];
			logs[a].color[1] = logs[a - 1].color[1];
			logs[a].color[2] = logs[a - 1].color[2];
			logs[a].color[3] = 0xFF;
			logs[a].start_time = logs[a - 1].start_time;
			logs[a].end_time = logs[a - 1].end_time;
		}
		logs[0].message = logsmsg;
		logs[0].color[0] = color[0];
		logs[0].color[1] = color[1];
		logs[0].color[2] = color[2];
		logs[0].start_time = get_time_now();
		logs[0].end_time = logs[0].start_time + duration;
		if (logs_count < 11)
			logs_count++;

		//PlayUISound(SoundEvent::RANDOM_ORB);
	}

	void draw_logs()
	{
		if (logs[0].message != NULL)
		{
			//Color BLACK_OPACITY = { 25, 25, 25, 200 };
			//(15, 246 - (logs_count * 10), 160, 12 + (10 * logs_count), BLACK_OPACITY);

			if (logs_count > -1)
			{
				//DrawRectangle(0, 246 - (logs_count * 10), 190, 12 + (10 * logs_count), UI::Color::BLACK);
				Color BLACK_OPACITY{ 15, 15, 15, 210 };
				DrawRectangleAlpha(0, 257, 190, 246 - (10 * logs_count), BLACK_OPACITY);
			}

			for (byte a = 0; a < logs_count + 1; a++)
			{
				DrawText(logs[a].message, 5, 248 - ((a * 10)), color(logs[a].color));
				if (get_time_now() >= logs[a].end_time)
				{
					logs[a].message = L"";
					logs_count--;
				}
			}
		}
	}
}

#pragma endregion
#pragma region "Show Debug Player"

void ShowDebugPlayer()
{
	if (mc->theMinecraft->cMultiplayerLocalPlayer->isInWeb == true)
	{
		DrawTextWithRectangle(L"[In Web]", 0, 116, MC_Color::BLACK_THEME, MC_Color::WHITE, true);
	}
	if (mc->theMinecraft->cMultiplayerLocalPlayer->IsSprinting())
	{
		DrawTextWithRectangle(L"[Sprinting]", 0, 116, MC_Color::BLACK_THEME, MC_Color::WHITE, true);
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->IsSneaking())
	{
		DrawTextWithRectangle(L"[Sneaking]", 0, 116, MC_Color::BLACK_THEME, MC_Color::WHITE, true);
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->IsSpectator())
	{
		DrawTextWithRectangle(L"[Spectator]", 0, 116, MC_Color::BLACK_THEME, MC_Color::WHITE, true);
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->IsBurning())
	{
		DrawTextWithRectangle(L"[Burning]", 0, 116, MC_Color::BLACK_THEME, MC_Color::WHITE, true);
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->isInWater())
	{
		DrawTextWithRectangle(L"[In Water]", 0, 116, MC_Color::BLACK_THEME, MC_Color::WHITE, true);
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->fallDistance > 0)
	{
		DrawTextWithRectangle(L"[Falling]", 0, 116, MC_Color::BLACK_THEME, MC_Color::WHITE, true);
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->onGround == true)
	{
		DrawTextWithRectangle(L"[On Ground]", 0, 116, MC_Color::BLACK_THEME, MC_Color::WHITE, true);
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->isDead == true)
	{
		DrawTextWithRectangle(L"[Is Dead]", 0, 116, MC_Color::BLACK_THEME, MC_Color::WHITE, true);
	}
}

#pragma endregion
#pragma region "Show Keystrokes"

void ShowKeystrokes()
{
	bool KeyPressedUP, KeyPressedDOWN, KeyPressedLEFT, KeyPressedRIGHT, KeyPressedSPACE;
	char* keystrokes_text[] = { "W    ", "S    ", "Q    ", "D    " };

	if (Buttons::IsMCButtonPressed(Buttons::JOYSTICK_L3_UP))
		KeyPressedUP = true; else KeyPressedUP = false;

	if (Buttons::IsMCButtonPressed(Buttons::JOYSTICK_L3_DOWN))
		KeyPressedDOWN = true; else KeyPressedDOWN = false;

	if (Buttons::IsMCButtonPressed(Buttons::JOYSTICK_L3_LEFT))
		KeyPressedLEFT = true; else KeyPressedLEFT = false;

	if (Buttons::IsMCButtonPressed(Buttons::JOYSTICK_L3_RIGHT))
		KeyPressedRIGHT = true; else KeyPressedRIGHT = false;

	if (Buttons::IsMCButtonPressed(Buttons::X))
		KeyPressedSPACE = true; else KeyPressedSPACE = false;

	int* KeyUPColor = KeyPressedUP ? GetThemeRainbow() : GetThemeColor();
	int* KeyDOWNColor = KeyPressedDOWN ? GetThemeRainbow() : GetThemeColor();
	int* KeyLEFTColor = KeyPressedLEFT ? GetThemeRainbow() : GetThemeColor();
	int* KeyRIGHTColor = KeyPressedRIGHT ? GetThemeRainbow() : GetThemeColor();
	int* KeySPACEColor = KeyPressedSPACE ? GetThemeRainbow() : GetThemeColor();

	int* keystrokesHudColor2[] = { KeyUPColor, KeyDOWNColor, KeyLEFTColor, KeyRIGHTColor, KeySPACEColor, MC_Color::WHITE };

	for (byte a = 0; a < 6; a++)
		DrawRectangleBorder(keystrokesBase_x + keystrokesHudX[a], keystrokesBase_y + keystrokesHudY[a], HudW[a], HudH[a], keystrokesHudColor1[a], keystrokesHudColor2[a], 1);

	for (byte b = 0; b < 4; b++)
		DrawTextC(keystrokes_text[b], keystrokesBase_x + keystrokes_TextX[b], keystrokesBase_y + keystrokes_TextY[b], color(keystrokes_TextColor[b]));
}

#pragma endregion
#pragma region "Get Teleport XYZ"

void GetTeleportXYZ()
{
	DrawRectangleBorder(447 + MenuX, 52 + MenuY, 50, 33, MC_Color::BLACK, GetThemeColor(), 1);

	char option4[0x100];
	wchar_t woption4[0x100];
	_sys_memset(option4, 0, 0x100);
	_sys_memset(woption4, 0, 0x200);
	_sys_snprintf(option4, 0x100, "X: %i   ", (TeleportX));
	StringToWideCharacter(woption4, option4, _sys_strlen(option4));
	DrawTextC(option4, 450 + MenuX, 55 + MenuY, color(MC_TextColor::White));

	char option8[0x100];
	wchar_t woption8[0x100];
	_sys_memset(option8, 0, 0x100);
	_sys_memset(woption8, 0, 0x200);
	_sys_snprintf(option8, 0x100, "Y: %i   ", (TeleportY));
	StringToWideCharacter(woption8, option8, _sys_strlen(option8));
	DrawTextC(option8, 450 + MenuX, 65 + MenuY, color(MC_TextColor::White));

	char option16[0x100];
	wchar_t woption16[0x100];
	_sys_memset(option16, 0, 0x100);
	_sys_memset(woption16, 0, 0x200);
	_sys_snprintf(option16, 0x100, "Z: %i   ", (TeleportZ));
	StringToWideCharacter(woption16, option16, _sys_strlen(option16));
	DrawTextC(option16, 450 + MenuX, 75 + MenuY, color(MC_TextColor::White));
}

#pragma endregion
#pragma region "Banner Function"

void ToggleBanner()
{
	CustomBanner = !CustomBanner; 
	if (CustomBanner) 
	{ MenuX -= 62; MenuY += 8; menuLenght = 64; }
	else 
	{ MenuX += 62; MenuY -= 8; menuLenght = 0; }
}

void ShowBanner()
{
	if (CustomBanner)
	{
		if (Opened)
		{
			*(int*)0x31E7781C = 0x3F384000; *(int*)0x31E77828 = 0x3F300000;
			*(int*)0x31E7782C = 0x443A1000; *(int*)0x31E77830 = 0xC3A00000;
		}
		else
		{
			*(int*)0x31E7782C = 0x68410000; *(int*)0x31E77830 = 0xF8EE0000;
		}
	}
	else
	{
		*(int*)0x31E7782C = 0x68410000; *(int*)0x31E77830 = 0xF8EE0000;
	}
}

#pragma endregion