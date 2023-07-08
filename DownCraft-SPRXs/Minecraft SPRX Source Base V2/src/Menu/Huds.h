#pragma once

namespace Menu
{
	void AddHuds(int sub)
	{
		int Gradient1[3] = { MenuGradient1R, MenuGradient1G, MenuGradient1B };
		int Gradient2[3] = { MenuGradient2R, MenuGradient2G, MenuGradient2B };

		for (byte a = 0; a < sub + 1; a++)
		{
			if (GradientMenu)
				DrawGradientBorder(60 + MenuX, 40 + MenuY, 110 + menuLenght, 15 + (11 * sub), Gradient1, Gradient2, MC_Color::BlackTheme, MenuBorderSize, true);
			else
				DrawRectangleBorder(60 + MenuX, 40 + MenuY, 110 + menuLenght, 15 + (11 * sub), MC_Color::BlackTheme, GetThemeColor(), MenuBorderSize);
		}
	}

	void Scrollbar()
	{
		int Gradient1[3] = { MenuGradient1R, MenuGradient1G, MenuGradient1B };
		int Gradient2[3] = { MenuGradient2R, MenuGradient2G, MenuGradient2B };

		if (GradientMenu)
			DrawGradientRectangle(60 + MenuX, 55 + MenuY + (SpaceBetweenText * CurrentOpt), 110 + menuLenght, 11, Gradient1, Gradient2, true);
		else
			DrawRectangle(60 + MenuX, 55 + MenuY + (SpaceBetweenText * CurrentOpt), 110 + menuLenght, 11, GetThemeColor());
	}

	void AddTitle(const wchar_t* title)
	{
		Scrollbar();

		int Gradient1[3] = { MenuGradient1R, MenuGradient1G, MenuGradient1B };
		int Gradient2[3] = { MenuGradient2R, MenuGradient2G, MenuGradient2B };

		if (GradientMenu)
			DrawGradientRectangle(60 + MenuX, 40 + MenuY, 110 + menuLenght, 15, Gradient1, Gradient2, true);
		else
			DrawRectangle(60 + MenuX, 40 + MenuY, 110 + menuLenght, 15, GetThemeColor());

		DrawTextWithShadow(title, 63 + MenuX, 44 + MenuY, color(MC_Color::White));
	}

	void AddSubOption(const wchar_t* option)
	{
		DrawText(option, 63 + MenuX, 57 + MenuY + (SpaceBetweenText * MaxOption), color(MC_Color::White));
		DrawText(L">     ", 163 + MenuX + menuLenght, 57 + MenuY + (SpaceBetweenText * MaxOption), color(MC_Color::White));
		MaxOption += 1;
	}

	void AddOption(const wchar_t* option)
	{
		DrawText(option, 63 + MenuX, 57 + MenuY + (SpaceBetweenText * MaxOption), color(MC_Color::White));
		MaxOption += 1;
	}

	void AddBoolOption(const wchar_t* option, bool toggle)
	{
		DrawText(option, 63 + MenuX, 57 + MenuY + (SpaceBetweenText * MaxOption), color(MC_Color::White));

		if (toggle)
			DrawTextC("ON     ", 158 + MenuX + menuLenght, 57 + MenuY + (SpaceBetweenText * MaxOption), color(MC_Color::Green));
		else
			DrawTextC("OFF     ", 154 + MenuX + menuLenght, 57 + MenuY + (SpaceBetweenText * MaxOption), color(MC_Color::Red));
		MaxOption += 1;
	}

	void AddIntOption(const wchar_t* option, int currentopt, int min, int max, int& IntOption)
	{
		int value = { IntOption };
		DrawText(option, 63 + MenuX, 57 + MenuY + (SpaceBetweenText * MaxOption), color(MC_Color::White));

		if (CurrentOpt == currentopt)
		{
			if (Buttons::IsMCButtonPressed(Buttons::LEFT))
			{
				if (frameTime(2, 1, false))
				{
					if (IntOption < min + 1)
						IntOption = max;
					else
						IntOption = IntOption - 1;
				}
			}
			if (Buttons::IsMCButtonPressed(Buttons::RIGHT))
			{
				if (frameTime(2, 1, false))
				{
					if (IntOption > max - 1)
						IntOption = min;
					else
						IntOption = IntOption + 1;
				}
			}
		}

		if (value > 99)
			DrawSnprintf("< %i >    ", value, 140 + MenuX + menuLenght, 57 + MenuY + (SpaceBetweenText * MaxOption));
		else
			DrawSnprintf("< %i >    ", value, 145 + MenuX + menuLenght, 57 + MenuY + (SpaceBetweenText * MaxOption));
		MaxOption += 1;
	}
}