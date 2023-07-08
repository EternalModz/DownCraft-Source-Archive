#pragma once

namespace Menu
{
	void AddHuds(int sub)
	{
		if (sub == 1) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 11, MC_Color::BlackTheme); }
		else if (sub == 2) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 22, MC_Color::BlackTheme); }
		else if (sub == 3) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 33, MC_Color::BlackTheme); }
		else if (sub == 4) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 44, MC_Color::BlackTheme); }
		else if (sub == 5) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 55, MC_Color::BlackTheme); }
		else if (sub == 6) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 66, MC_Color::BlackTheme); }
		else if (sub == 7) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 77, MC_Color::BlackTheme); }
		else if (sub == 8) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 88, MC_Color::BlackTheme); }
		else if (sub == 9) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 99, MC_Color::BlackTheme); }
		else if (sub == 10) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 110, MC_Color::BlackTheme); }
		else if (sub == 11) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 121, MC_Color::BlackTheme); }
		else if (sub == 12) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 132, MC_Color::BlackTheme); }
		else if (sub == 13) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 143, MC_Color::BlackTheme); }
		else if (sub == 14) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 154, MC_Color::BlackTheme); }
		else if (sub == 15) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 165, MC_Color::BlackTheme); }
		else if (sub == 16) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 176, MC_Color::BlackTheme); }
		else if (sub == 17) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 187, MC_Color::BlackTheme); }
		else if (sub == 18) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 198, MC_Color::BlackTheme); }
		else if (sub == 19) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 209, MC_Color::BlackTheme); }
		else if (sub == 20) { DrawRectangle(MenuX + 508, MenuY + 61, 152, 220, MC_Color::BlackTheme); }
	}

	void TitleSPRX(const wchar_t* title)
	{
		if (ToggleTitleSPRX)
			DrawTextWithRectangle(title, 10, 10, MC_Color::BlackTheme, true);
	}

	void Scrollbar()
	{
		DrawRectangle(MenuX + 508, MenuY + 61 + (SpaceBetweenText * CurrentOpt), 152, 11, MC_Color::ColorTheme);
	}

	void AddTitle(const wchar_t* title)
	{
		Scrollbar();
		DrawRectangle(MenuX + 508, MenuY + 35, 152, 13, MC_Color::ColorTheme);
		DrawTextWithShadow(title, MenuX + 550, MenuY + 37, color(MC_Color::White));
	}

	void Description(const wchar_t* description)
	{
		DrawRectangle(MenuX + 508, MenuY + 48, 152, 13, MC_Color::DescColor);
		DrawText(description, MenuX + 510, MenuY + 51 , color(MC_Color::White));
		int index[] = {CurrentOpt + 1, MaxSubOptions};
		DrawsnprintfText("%i/%i     ", index, MenuX + 641, MenuY + 51, false);
	}

	void AddSubOption(const wchar_t* option)
	{
		DrawText(option, MenuX + 513, MenuY + 63 + (SpaceBetweenText * MaxOption), color(MC_Color::White));
		DrawText(L">     ", MenuX + 650, MenuY + 63 + (SpaceBetweenText * MaxOption), color(MC_Color::White));
		MaxOption += 1;
	}

	void AddOption(const wchar_t* option)
	{
		DrawText(option, MenuX + 513, MenuY + 63 + (SpaceBetweenText * MaxOption), color(MC_Color::White));
		MaxOption += 1;
	}

	void AddIntOption(const wchar_t* option, int currentopt, int min, int max, int& IntOption)
	{
		DrawText(option, MenuX + 513, MenuY + 63 + (SpaceBetweenText * MaxOption), color(MC_Color::White));

		if (CurrentOpt == currentopt)
		{
			if (Buttons::IsMCButtonPressed(Buttons::LEFT))
			{
				if (frameTime(3, 1, false))
				{
					if (IntOption < min + 1)
						IntOption = max;
					else
						IntOption = IntOption - 1;
				}
			}
			if (Buttons::IsMCButtonPressed(Buttons::RIGHT))
			{
				if (frameTime(3, 1, false))
				{
					if (IntOption > max - 1)
						IntOption = min;
					else
						IntOption = IntOption + 1;
				}
			}
		}

		int value = { IntOption };
		DrawSnprintf("< %i >    ", value, MenuX + 630, MenuY + 63 + (SpaceBetweenText * MaxOption));
		MaxOption += 1;
	}

	void AddBoolOption(const wchar_t* option, bool toggle)
	{
		DrawText(option, MenuX + 513, MenuY + 63 + (SpaceBetweenText * MaxOption), color(MC_Color::White));

		int color1[3] = { 65, 65, 65 };
		if (toggle)
		{
			DrawRectangleBorder(MenuX + 622, MenuY + 63 + (SpaceBetweenText * MaxOption), 34, 7, color1, MC_Color::BlackTheme, 1);
			DrawRectangle(MenuX + 622 + 17, MenuY + 63 + (SpaceBetweenText * MaxOption), 17, 7, MC_Color::BlackTheme);
			DrawTextC("OFF     ", MenuX + 622 + 18, MenuY + 63 + (SpaceBetweenText * MaxOption), color(color1));
		}
		else
		{
			DrawRectangleBorder(MenuX + 622, MenuY + 63 + (SpaceBetweenText * MaxOption), 34, 7, color1, MC_Color::BlackTheme, 1);
			DrawRectangle(MenuX + 622, MenuY + 63 + (SpaceBetweenText * MaxOption), 17, 7, MC_Color::BlackTheme);
			DrawTextC("ON     ", MenuX + 622 + 1, MenuY + 63 + (SpaceBetweenText * MaxOption), color(MC_Color::ColorTheme));
		}
		MaxOption += 1;
	}
}