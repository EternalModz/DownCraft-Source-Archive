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

bool InWorld()
{
	return !(*(char*)0x3000CF6B != 0);
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

	if (ShowKeyboard)
	{
		if (Buttons::IsMCButtonPressed(Buttons::UP))
		{
			if (scrollWait(firstWaitTime, waitTime, wI))
			{
				CurrentSelectY = CurrentSelectY - 1;
				return;
			}
		}

		if (Buttons::IsMCButtonPressed(Buttons::DOWN))
		{
			if (scrollWait(firstWaitTime, waitTime, wI))
			{
				CurrentSelectY = CurrentSelectY + 1;
				return;
			}
		}

		if (Buttons::IsMCButtonPressed(Buttons::LEFT))
		{
			if (scrollWait(firstWaitTime, waitTime, wI))
			{
				CurrentSelectX = CurrentSelectX - 1;
				return;
			}
		}

		if (Buttons::IsMCButtonPressed(Buttons::RIGHT))
		{
			if (scrollWait(firstWaitTime, waitTime, wI))
			{
				CurrentSelectX = CurrentSelectX + 1;
				return;
			}
		}

		if (Buttons::IsMCButtonPressed(Buttons::X))
		{
			if (scrollWait(firstWaitTime, waitTime, wI))
			{
				if (CurrentSelectX == 0 && CurrentSelectY == 0)
					NAME_CHANGER_TEXT = "A     ";
				else if (CurrentSelectX == 0 && CurrentSelectY == 1)
					NAME_CHANGER_TEXT = "Q     ";
				else if (CurrentSelectX == 0 && CurrentSelectY == 2)
					NAME_CHANGER_TEXT = "W     ";
				else if (CurrentSelectX == 0 && CurrentSelectY == 3)
					NAME_CHANGER_TEXT = "1     ";
				return;
			}
		}

		if (Buttons::IsMCButtonPressed(Buttons::O))
		{
			if (scrollWait(firstWaitTime, waitTime, wI))
			{
				ShowKeyboard = false;
				Opened = true;
				return;
			}
		}

		int fix1 = 11;
		fix1 -= 1;

		if (CurrentSelectX > fix1)
			CurrentSelectX = 0;

		if (CurrentSelectX < 0)
			CurrentSelectX = fix1;

		int fix2 = 4;
		fix2 -= 1;

		if (CurrentSelectY > fix2)
			CurrentSelectY = 0;

		if (CurrentSelectY < 0)
			CurrentSelectY = fix2;
	}
}

void CheckSPRX()
{
	char CHECK_EBOOT[] = { 0x4D, 0x69, 0x73, 0x61, 0x6B, 0x69, 0x69, 0x69 }; //custom EBOOT check
	char* CHECK_EBOOT_ADDRESS = (char*)0x14E8790; //custom location EBOOT check
	//bool BLES = (*(int*)0x31E7782C = 0x424C4553);

	for (int i = 0; i < 8; ++i)
	{
		if (CHECK_EBOOT_ADDRESS[i] == CHECK_EBOOT[i])
		{
			UsableMenu = true;
			/*
			if (BLES)
			{
				UsableMenu = true;
			}
			*/
		}
	}
}

#pragma endregion