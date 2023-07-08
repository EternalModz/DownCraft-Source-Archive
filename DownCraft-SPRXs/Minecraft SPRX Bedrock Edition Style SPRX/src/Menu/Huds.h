#pragma once

namespace Menu
{
	void AddTitle(const wchar_t* title)
	{
		DrawText(title, 460, 13, color(MC_Color::DarkGray));
	}

	void AddHuds()
	{
		DrawRectangleBorder(430, 0, 160, 1000, MC_Color::bg_color, MC_Color::black_line, 1);
		DrawRectangle(430, 0, 160, 30, MC_Color::header_color1);
		DrawRectangle(430, 30, 160, 5, MC_Color::header_color2);
		DrawRectangle(430, 35, 160, 1, MC_Color::black_line);
	}

	void AddOption(const wchar_t* option)
	{
		DrawText(option, 438, 45 + (SpaceBetweenText * MaxOption), (MaxOption == CurrentOpt) ? color(MC_Color::ScrollColor) : color(MC_Color::White));
		MaxOption += 1;
	}

	void AddSubOption(const wchar_t* option)
	{
		DrawText(option, 438, 45 + (SpaceBetweenText * MaxOption), (MaxOption == CurrentOpt) ? color(MC_Color::ScrollColor) : color(MC_Color::White));
		DrawText(L">     ", 580, 45 + (SpaceBetweenText * MaxOption), (MaxOption == CurrentOpt) ? color(MC_Color::ScrollColor) : color(MC_Color::White));
		MaxOption += 1;
	}

	void AddBoolOption(const wchar_t* option, bool toggle)
	{
		DrawText(option, 465, 45 + (SpaceBetweenText * MaxOption), (MaxOption == CurrentOpt) ? color(MC_Color::ScrollColor) : color(MC_Color::White));

		if (toggle)
		{
			DrawRectangleBorder(440, 45 + (SpaceBetweenText * MaxOption), 20, 7, MC_Color::bool_on, MC_Color::black_line, 1);
			DrawRectangleBorder(458, 42 + (SpaceBetweenText * MaxOption), 5, 12, MC_Color::header_color1, MC_Color::black_line, 1);
		}
		else
		{
			DrawRectangleBorder(440, 45 + (SpaceBetweenText * MaxOption), 20, 7, MC_Color::bool_off, MC_Color::black_line, 1);
			DrawRectangleBorder(438, 42 + (SpaceBetweenText * MaxOption), 5, 12, MC_Color::header_color1, MC_Color::black_line, 1);
		}

		MaxOption += 1;
	}
}