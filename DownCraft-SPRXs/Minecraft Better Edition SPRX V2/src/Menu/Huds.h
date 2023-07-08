#pragma once

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

	void debugMessage(wchar_t* logsmsg = L"", int* color = MC_Color::White, int duration = 10000)//10sec
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
			if (logs_count > -1)
			{
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

namespace Menu
{
	void AddHuds(int sub)
	{
		for (byte a = 0; a < sub + 1; a++)
		{
			DrawRectangle(MenuX + 508, MenuY + 61, 152, + (11 * sub), MC_Color::BlackTheme);
		}
	}

	void TitleSPRX(const wchar_t* title)
	{
		if (ToggleTitleSPRX)
			DrawTextWithRectangle(title, 10, 10, MC_Color::BlackTheme, MC_Color::White, true);
	}

	void Scrollbar()
	{
		DrawRectangle(MenuX + 508, MenuY + 61 + (SpaceBetweenText * CurrentOpt), 152, 11, GetThemeColor());
	}

	void AddTitle(const wchar_t* title)
	{
		Scrollbar();
		DrawRectangle(MenuX + 508, MenuY + 35, 152, 13, GetThemeColor());
		DrawTextWithShadow(title, MenuX + 550, MenuY + 38, color(MC_Color::White));
	}

	void Description(const wchar_t* description)
	{
		DrawRectangle(MenuX + 508, MenuY + 48, 152, 13, MC_Color::DescColor);
		DrawText(description, MenuX + 510, MenuY + 51 , color(MC_Color::White));
		int index[] = {CurrentOpt + 1, MaxSubOptions};

		if (MaxSubOptions > 9)
			DrawsnprintfText("%i/%i     ", index, MenuX + 636, MenuY + 51, false);
		else
			DrawsnprintfText("%i/%i     ", index, MenuX + 641, MenuY + 51, false);
		
		if (CurrentOpt > 9)
			DrawsnprintfText("%i/%i     ", index, MenuX + 628, MenuY + 51, false);
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
		int value = { IntOption };
		DrawText(option, MenuX + 513, MenuY + 63 + (SpaceBetweenText * MaxOption), color(MC_Color::White));

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

		if (value < -99)
			DrawSnprintf("< %i >    ", value, MenuX + 625, MenuY + 63 + (SpaceBetweenText * MaxOption));
		else
			DrawSnprintf("< %i >    ", value, MenuX + 630, MenuY + 63 + (SpaceBetweenText * MaxOption));

		MaxOption += 1;
	}

	void AddBoolOption(const wchar_t* option, bool toggle)
	{
		DrawText(option, MenuX + 513, MenuY + 63 + (SpaceBetweenText * MaxOption), color(MC_Color::White));

		if (toggle)
		{
			DrawRectangleBorder(MenuX + 622, MenuY + 63 + (SpaceBetweenText * MaxOption), 34, 7, MC_Color::BoolColors, MC_Color::BlackTheme, 1);
			DrawRectangle(MenuX + 622 + 17, MenuY + 63 + (SpaceBetweenText * MaxOption), 17, 7, MC_Color::BlackTheme);
			DrawTextC("OFF     ", MenuX + 622 + 18, MenuY + 63 + (SpaceBetweenText * MaxOption), color(MC_Color::BoolColors));
		}
		else
		{
			DrawRectangleBorder(MenuX + 622, MenuY + 63 + (SpaceBetweenText * MaxOption), 34, 7, MC_Color::BoolColors, MC_Color::BlackTheme, 1);
			DrawRectangle(MenuX + 622, MenuY + 63 + (SpaceBetweenText * MaxOption), 17, 7, MC_Color::BlackTheme);
			DrawTextC("ON     ", MenuX + 622 + 1, MenuY + 63 + (SpaceBetweenText * MaxOption), color(GetThemeColor()));
		}
		MaxOption += 1;
	}
}