#pragma once

#include "DrawHudsFunctions.h"

#pragma region "Huds Function"

#define Color_s(a,r,g,b) (((((a)&0xff)<<24)|(((r)&0xff)<<16)|(((g)&0xff)<<8)|((b)&0xff)))

void DrawToggleONOFF(float x, float y, int* Color1, int* Color2, bool checked)
{
	if (UI::Settings::Rainbow)
	{
		int color1[3] = { 65, 65, 65 };
		if (checked)
		{
			drawRectBorder(x, y, 34, 7, Color1, Color2);
			DrawRectangle(x + 17, y, 17, 7, Color2);
			DrawTextC("OFF     ", x + 18, y, color(color1));
		}
		else
		{
			drawRectBorder(x, y, 34, 7, Color1, Color2);
			DrawRectangle(x, y, 17, 7, Color2);
			DrawTextC("ON     ", x + 2, y, color(UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE));
		}
	}
	else
	{
		int color1[3] = { 65, 65, 65 };
		if (checked)
		{
			drawRectBorder(x, y, 34, 7, Color1, Color2);
			DrawRectangle(x + 17, y, 17, 7, Color2);
			DrawTextC("OFF     ", x + 18, y, color(color1));
		}
		else
		{
			drawRectBorder(x, y, 34, 7, Color1, Color2);
			DrawRectangle(x, y, 17, 7, Color2);
			DrawTextC("ON     ", x + 2, y, color(UI::Color::BLUE));
		}
	}
}

void DrawToggleONOFFV2(float x, float y, int* Color1, int* Color2, bool checked)
{
	int ON[3] = { 37, 151, 68 };
	int OFF[3] = { 189, 26, 43 };
	if (checked)
	{
		DrawTextC("OFF     ", x + 2, y, color(OFF));
	}
	else
	{
		DrawTextC("ON     ", x + 2, y, color(ON));
	}
}


void SetNotify(wchar_t* notifmsg)
{
	if (UI::Settings::ShowNotif)
	{
		NotifMsg = notifmsg;
		SendNotif = false;
		SendNotif = true;
	}
}

void GetNotify()
{
	if (UI::Settings::ShowNotif)
	{
		if (SendNotif)
		{
			if (UI::Settings::Rainbow)
			{
				if (UI::Settings::GradientRGB)
				{
					int width = Font_width(NotifMsg);
					drawRectBorderRGBV3(284, 21, width + 5, 15, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1);
					DrawText(NotifMsg, 18, 64, color(UI::MCTextColors::White));
				}
				else
				{
					int width = Font_width(NotifMsg);
					drawRectBorderRGB(284, 21, width, 15, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE);
					DrawText(NotifMsg, 289, 25, color(UI::Color::WHITE));
				}
			}
			else
			{
				int width = Font_width(NotifMsg);
				drawRectBorder(284, 21, width, 15, UI::Color::BLACK, GetThemeColor());
				DrawText(NotifMsg, 289, 25, color(UI::Color::WHITE));
			}

			if (frameTime(200, 1, false))
			{
				SendNotif = false;
			}
		}
	}
}

//thanks to NyTekCFW
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

	void SendMessageDebug(wchar_t* logsmsg = L"", int* color = UI::MCTextColors::White, int duration = 10000)//10sec
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

		PlayUISound(SoundEvent::RANDOM_ORB);
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


//For modules
void ArrayList()
{
	char* modules_name[20];
	ArrayListIndex = 0;

	if (ArrayListIndex == 1)
	{

	}
}

//MENU HUDS

void TitleMenu()
{
	DrawRectangle(15, 10, 80, 13, UI::Color::BLACK);
	DrawTextWithShadow(L"DownCraft SPRX", 20, 13, color(UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE));
}

void AddInstruction()
{
	if (UI::Settings::ShowInfosBar)
	{
		DrawRectangle(450, 328, 160, 14, UI::Color::BLACK);
		DrawText(L"Back: O   Scroll: UP / DOWN   Select: X", 455, 331, color(UI::Color::WHITE));

		if (!UI::Settings::CustomImage)
			*(int*)0x31E77830 = 0x44000000;
	}
}

void AddOpacityBG()
{
	if (UI::Settings::BGOpacity)
	{
		Color BLACK_OPACITY{ 15, 15, 15, shadowBG };
		if (submmenuMax == 1) { DrawRectangleAlpha(603, 74, 408 + menulenght, 84, BLACK_OPACITY); }
		else if (submmenuMax == 2) { DrawRectangleAlpha(603, 74, 408 + menulenght, 94, BLACK_OPACITY); }
		else if (submmenuMax == 3) { DrawRectangleAlpha(603, 74, 408 + menulenght, 104, BLACK_OPACITY); }
		else if (submmenuMax == 4) { DrawRectangleAlpha(603, 74, 408 + menulenght, 114, BLACK_OPACITY); }
		else if (submmenuMax == 5) { DrawRectangleAlpha(603, 74, 408 + menulenght, 124, BLACK_OPACITY); }
		else if (submmenuMax == 6) { DrawRectangleAlpha(603, 74, 408 + menulenght, 134, BLACK_OPACITY); }
		else if (submmenuMax == 7) { DrawRectangleAlpha(603, 74, 408 + menulenght, 144, BLACK_OPACITY); }
		else if (submmenuMax == 8) { DrawRectangleAlpha(603, 74, 408 + menulenght, 154, BLACK_OPACITY); }
		else if (submmenuMax == 9) { DrawRectangleAlpha(603, 74, 408 + menulenght, 164, BLACK_OPACITY); }
		else if (submmenuMax == 10) { DrawRectangleAlpha(603, 74, 408 + menulenght, 174, BLACK_OPACITY); }
		else if (submmenuMax == 11) { DrawRectangleAlpha(603, 74, 408 + menulenght, 184, BLACK_OPACITY); }
		else if (submmenuMax == 12) { DrawRectangleAlpha(603, 74, 408 + menulenght, 194, BLACK_OPACITY); }
		else if (submmenuMax == 13) { DrawRectangleAlpha(603, 74, 408 + menulenght, 204, BLACK_OPACITY); }
		else if (submmenuMax == 14) { DrawRectangleAlpha(603, 74, 408 + menulenght, 214, BLACK_OPACITY); }
		else if (submmenuMax == 15) { DrawRectangleAlpha(603, 74, 408 + menulenght, 224, BLACK_OPACITY); }
		else if (submmenuMax == 16) { DrawRectangleAlpha(603, 74, 408 + menulenght, 234, BLACK_OPACITY); }
		else if (submmenuMax == 17) { DrawRectangleAlpha(603, 74, 408 + menulenght, 244, BLACK_OPACITY); }
		else if (submmenuMax == 18) { DrawRectangleAlpha(603, 74, 408 + menulenght, 254, BLACK_OPACITY); }
		else if (submmenuMax == 19) { DrawRectangleAlpha(603, 74, 408 + menulenght, 264, BLACK_OPACITY); }
		else if (submmenuMax == 20) { DrawRectangleAlpha(603, 74, 408 + menulenght, 274, BLACK_OPACITY); }
	}
}

void Scrollbar()
{
	if (UI::Settings::Scrollbar)
	{
		DrawRectangle(ScrollX, ScrollY + 10 + (CurrentOpt * 10), bgW + menulenght, 11, GetThemeColor());

		if (UI::Settings::Rainbow)
		{
			drawRectRGB(ScrollX, ScrollY + 10 + (CurrentOpt * 10), bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE);
			if (UI::Settings::GradientRGB)
			{
				drawGradientLeftRightRGB(ScrollX, ScrollY + 10 + (CurrentOpt * 10), bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1);
			}
		}
	}
}

void AddTitle(const wchar_t* title)
{
	Scrollbar();

	if (UI::Settings::Rainbow)
	{
		if (UI::Settings::GradientRGB)
		{
			drawGradientLeftRightRGB(textX - 10, textY - 13, bgW + menulenght, textI + 4, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1);
		}
		else
		{
			drawRectRGB(textX - 10, textY - 13, bgW + menulenght, textI + 4, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE);
		}
	}
	else
	{
		DrawRectangle(textX - 10, textY - 13, bgW + menulenght, textI + 4, GetThemeColor());
	}

	AddOpacityBG();

	DrawTextWithShadow(title, TitleTextX + menulenght, TitleTextY, color(UI::Color::WHITE));
}

void CountIndexPage()
{
	if (CurrentOpt == 0) { CurrentIndex = 1; }
	else if (CurrentOpt == 1) { CurrentIndex = 2; }
	else if (CurrentOpt == 2) { CurrentIndex = 3; }
	else if (CurrentOpt == 3) { CurrentIndex = 4; }
	else if (CurrentOpt == 4) { CurrentIndex = 5; }
	else if (CurrentOpt == 5) { CurrentIndex = 6; }
	else if (CurrentOpt == 6) { CurrentIndex = 7; }
	else if (CurrentOpt == 7) { CurrentIndex = 8; }
	else if (CurrentOpt == 8) { CurrentIndex = 9; }
	else if (CurrentOpt == 9) { CurrentIndex = 10; }
	else if (CurrentOpt == 10) { CurrentIndex = 11; }
	else if (CurrentOpt == 11) { CurrentIndex = 12; }
	else if (CurrentOpt == 12) { CurrentIndex = 13; }
	else if (CurrentOpt == 13) { CurrentIndex = 14; }
	else if (CurrentOpt == 14) { CurrentIndex = 15; }
	else if (CurrentOpt == 15) { CurrentIndex = 16; }
	else if (CurrentOpt == 16) { CurrentIndex = 17; }
	else if (CurrentOpt == 17) { CurrentIndex = 18; }
	else if (CurrentOpt == 18) { CurrentIndex = 19; }
	else if (CurrentOpt == 19) { CurrentIndex = 20; }
	else if (CurrentOpt == 20) { CurrentIndex = 21; }
}

void AddDescription(const wchar_t* desc)
{
	if (!UI::Settings::BO2Design)
	{
		CountIndexPage();
		DrawRectangle(ScrollX, ScrollY, bgW + menulenght, 11, UI::Color::BLACK2);
		DrawTextWithShadow(desc, AddOptX - 3, AddOptY - 10, color(UI::Color::WHITE));

		char option4[0x100];
		wchar_t woption4[0x100];
		_sys_memset(option4, 0, 0x100);
		_sys_memset(woption4, 0, 0x200);
		_sys_snprintf(option4, 0x100, "%i/%i     ", (CurrentIndex), (submmenuMax));
		StringToWideCharacter(woption4, option4, _sys_strlen(option4));

		if (CurrentIndex > 9)
		{
			DrawText(woption4, TitleTextX + 76 + menulenght, TitleTextY + 12, color(UI::Color::WHITE)); //574
		}
		else
		{
			DrawText(woption4, TitleTextX + 81 + menulenght, TitleTextY + 12, color(UI::Color::WHITE)); //579 title = 448
		}
	}
}

void AddInformation(int sub, const wchar_t* desc)
{
	if (!UI::Settings::BO2Design)
	{
		if (UI::Settings::Rainbow)
		{
			if (UI::Settings::GradientRGB)
			{
				if (sub == 1) { drawGradientLeftRightRGB(bgX, bgY + 10, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 2) { drawGradientLeftRightRGB(bgX, bgY + 20, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 3) { drawGradientLeftRightRGB(bgX, bgY + 30, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 4) { drawGradientLeftRightRGB(bgX, bgY + 40, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 5) { drawGradientLeftRightRGB(bgX, bgY + 50, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 6) { drawGradientLeftRightRGB(bgX, bgY + 60, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 7) { drawGradientLeftRightRGB(bgX, bgY + 70, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 8) { drawGradientLeftRightRGB(bgX, bgY + 80, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 9) { drawGradientLeftRightRGB(bgX, bgY + 90, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 10) { drawGradientLeftRightRGB(bgX, bgY + 100, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 11) { drawGradientLeftRightRGB(bgX, bgY + 110, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 12) { drawGradientLeftRightRGB(bgX, bgY + 120, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 13) { drawGradientLeftRightRGB(bgX, bgY + 130, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 14) { drawGradientLeftRightRGB(bgX, bgY + 140, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 15) { drawGradientLeftRightRGB(bgX, bgY + 150, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 16) { drawGradientLeftRightRGB(bgX, bgY + 160, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 17) { drawGradientLeftRightRGB(bgX, bgY + 170, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 18) { drawGradientLeftRightRGB(bgX, bgY + 180, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 19) { drawGradientLeftRightRGB(bgX, bgY + 190, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				else if (sub == 20) { drawGradientLeftRightRGB(bgX, bgY + 200, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
			}
			else
			{
				if (sub == 1) { drawRectRGB(bgX, bgY + 10, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 2) { drawRectRGB(bgX, bgY + 20, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 3) { drawRectRGB(bgX, bgY + 30, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 4) { drawRectRGB(bgX, bgY + 40, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 5) { drawRectRGB(bgX, bgY + 50, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 6) { drawRectRGB(bgX, bgY + 60, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 7) { drawRectRGB(bgX, bgY + 70, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 8) { drawRectRGB(bgX, bgY + 80, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 9) { drawRectRGB(bgX, bgY + 90, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 10) { drawRectRGB(bgX, bgY + 100, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 11) { drawRectRGB(bgX, bgY + 110, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 12) { drawRectRGB(bgX, bgY + 120, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 13) { drawRectRGB(bgX, bgY + 130, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 14) { drawRectRGB(bgX, bgY + 140, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 15) { drawRectRGB(bgX, bgY + 150, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 16) { drawRectRGB(bgX, bgY + 160, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 17) { drawRectRGB(bgX, bgY + 170, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 18) { drawRectRGB(bgX, bgY + 180, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 19) { drawRectRGB(bgX, bgY + 190, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				else if (sub == 20) { drawRectRGB(bgX, bgY + 200, bgW + menulenght, 11, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
			}
		}
		else
		{
			if (sub == 1) { DrawRectangle(bgX, bgY + 10, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 2) { DrawRectangle(bgX, bgY + 20, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 3) { DrawRectangle(bgX, bgY + 30, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 4) { DrawRectangle(bgX, bgY + 40, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 5) { DrawRectangle(bgX, bgY + 50, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 6) { DrawRectangle(bgX, bgY + 60, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 7) { DrawRectangle(bgX, bgY + 70, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 8) { DrawRectangle(bgX, bgY + 80, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 9) { DrawRectangle(bgX, bgY + 90, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 10) { DrawRectangle(bgX, bgY + 100, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 11) { DrawRectangle(bgX, bgY + 110, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 12) { DrawRectangle(bgX, bgY + 120, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 13) { DrawRectangle(bgX, bgY + 130, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 14) { DrawRectangle(bgX, bgY + 140, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 15) { DrawRectangle(bgX, bgY + 150, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 16) { DrawRectangle(bgX, bgY + 160, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 17) { DrawRectangle(bgX, bgY + 170, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 18) { DrawRectangle(bgX, bgY + 180, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 19) { DrawRectangle(bgX, bgY + 190, bgW + menulenght, 11, GetThemeColor()); }
			else if (sub == 20) { DrawRectangle(bgX, bgY + 200, bgW + menulenght, 11, GetThemeColor()); }
		}

		//TEXT

		if (sub == 1) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 10, color(UI::Color::WHITE)); }
		else if (sub == 2) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 20, color(UI::Color::WHITE)); }
		else if (sub == 3) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 30, color(UI::Color::WHITE)); }
		else if (sub == 4) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 40, color(UI::Color::WHITE)); }
		else if (sub == 5) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 50, color(UI::Color::WHITE)); }
		else if (sub == 6) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 60, color(UI::Color::WHITE)); }
		else if (sub == 7) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 70, color(UI::Color::WHITE)); }
		else if (sub == 8) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 80, color(UI::Color::WHITE)); }
		else if (sub == 9) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 90, color(UI::Color::WHITE)); }
		else if (sub == 10) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 100, color(UI::Color::WHITE)); }
		else if (sub == 11) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 110, color(UI::Color::WHITE)); }
		else if (sub == 12) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 120, color(UI::Color::WHITE)); }
		else if (sub == 13) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 130, color(UI::Color::WHITE)); }
		else if (sub == 14) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 140, color(UI::Color::WHITE)); }
		else if (sub == 15) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 150, color(UI::Color::WHITE)); }
		else if (sub == 16) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 160, color(UI::Color::WHITE)); }
		else if (sub == 17) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 170, color(UI::Color::WHITE)); }
		else if (sub == 18) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 180, color(UI::Color::WHITE)); }
		else if (sub == 19) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 190, color(UI::Color::WHITE)); }
		else if (sub == 20) { DrawTextWithShadow(desc, AddOptX - 3, AddOptY + 200, color(UI::Color::WHITE)); }
	}
}

void AddHud(int sub)
{
	if (!UI::Settings::BO2Design)
	{
		if (UI::Settings::Style)
		{
			if (UI::Settings::Rainbow)
			{
				if (UI::Settings::GradientRGB)
				{
					if (sub == 1) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, bgH - 2, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 2) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 21, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 3) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 31, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 4) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 41, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 5) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 51, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 6) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 61, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 7) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 71, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 8) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 81, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 9) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 91, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 10) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 101, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 11) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 111, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 12) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 121, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 13) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 131, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 14) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 141, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 15) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 151, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 16) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 161, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 17) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 171, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 18) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 181, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 19) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 191, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
					else if (sub == 20) { drawRectBorderRGBV3(bgX + 1, bgY, bgW - 2 + menulenght, 201, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::RainbowRED1, UI::Color::RainbowGREEN1, UI::Color::RainbowBLUE1); }
				}
				else
				{
					if (sub == 1) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, bgH - 2, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 2) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 21, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 3) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 31, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 4) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 41, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 5) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 51, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 6) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 61, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 7) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 71, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 8) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 81, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 9) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 91, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 10) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 101, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 11) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 111, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 12) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 121, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 13) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 131, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 14) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 141, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 15) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 151, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 16) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 161, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 17) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 171, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 18) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 181, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 19) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 191, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
					else if (sub == 20) { drawRectBorderRGB(bgX + 1, bgY, bgW - 2 + menulenght, 201, UI::Color::BLACK, UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE); }
				}
			}
			else
			{
				if (sub == 1) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, bgH - 2, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 2) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 21, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 3) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 31, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 4) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 41, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 5) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 51, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 6) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 61, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 7) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 71, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 8) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 81, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 9) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 91, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 10) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 101, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 11) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 111, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 12) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 121, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 13) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 131, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 14) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 141, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 15) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 151, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 16) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 161, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 17) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 171, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 18) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 181, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 19) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 191, UI::Color::BLACK, GetThemeColor()); }
				else if (sub == 20) { drawRectBorder(bgX + 1, bgY, bgW - 2 + menulenght, 201, UI::Color::BLACK, GetThemeColor()); }
			}
		}
		else
		{
			if (UI::Settings::BGOpacity)
			{

			}
			else
			{
				if (sub == 1) { DrawRectangle(bgX, bgY, bgW + menulenght, bgH, UI::Color::BLACK); }
				else if (sub == 2) { DrawRectangle(bgX, bgY, bgW + menulenght, 21, UI::Color::BLACK); }
				else if (sub == 3) { DrawRectangle(bgX, bgY, bgW + menulenght, 31, UI::Color::BLACK); }
				else if (sub == 4) { DrawRectangle(bgX, bgY, bgW + menulenght, 41, UI::Color::BLACK); }
				else if (sub == 5) { DrawRectangle(bgX, bgY, bgW + menulenght, 51, UI::Color::BLACK); }
				else if (sub == 6) { DrawRectangle(bgX, bgY, bgW + menulenght, 61, UI::Color::BLACK); }
				else if (sub == 7) { DrawRectangle(bgX, bgY, bgW + menulenght, 71, UI::Color::BLACK); }
				else if (sub == 8) { DrawRectangle(bgX, bgY, bgW + menulenght, 81, UI::Color::BLACK); }
				else if (sub == 9) { DrawRectangle(bgX, bgY, bgW + menulenght, 91, UI::Color::BLACK); }
				else if (sub == 10) { DrawRectangle(bgX, bgY, bgW + menulenght, 101, UI::Color::BLACK); }
				else if (sub == 11) { DrawRectangle(bgX, bgY, bgW + menulenght, 111, UI::Color::BLACK); }
				else if (sub == 12) { DrawRectangle(bgX, bgY, bgW + menulenght, 121, UI::Color::BLACK); }
				else if (sub == 13) { DrawRectangle(bgX, bgY, bgW + menulenght, 131, UI::Color::BLACK); }
				else if (sub == 14) { DrawRectangle(bgX, bgY, bgW + menulenght, 141, UI::Color::BLACK); }
				else if (sub == 15) { DrawRectangle(bgX, bgY, bgW + menulenght, 151, UI::Color::BLACK); }
				else if (sub == 16) { DrawRectangle(bgX, bgY, bgW + menulenght, 161, UI::Color::BLACK); }
				else if (sub == 17) { DrawRectangle(bgX, bgY, bgW + menulenght, 171, UI::Color::BLACK); }
				else if (sub == 18) { DrawRectangle(bgX, bgY, bgW + menulenght, 181, UI::Color::BLACK); }
				else if (sub == 19) { DrawRectangle(bgX, bgY, bgW + menulenght, 191, UI::Color::BLACK); }
				else if (sub == 20) { DrawRectangle(bgX, bgY, bgW + menulenght, 201, UI::Color::BLACK); }
			}
		}
	}
	else
	{
		drawRectBorder(bgX + 1, bgY - 200, bgW - 2 + menulenght, bgH + 800, UI::Color::BLACK, GetThemeColor());
	}
}

void AddOption(const wchar_t* opt)
{
	//bgH * subMax;
	//DrawRectangle(textX - 5, textY - 5 + (scroll * 13), bgW, textI + 2, UI::Color::RED);
	if (UI::Settings::Rainbow)
	{
		if (menulenght > 25)
		{
			if (UI::Settings::Scrollbar)
			{
				DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
				DrawText(L">    ", AddOptX + 80 + menulenght, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
			}
			else
			{
				DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE) : color(UI::Color::WHITE));
				DrawText(L">    ", AddOptX + 80 + menulenght, AddOptY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE) : color(UI::Color::WHITE));
			}
		}
		else
		{
			if (UI::Settings::Scrollbar)
			{
				DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
			}
			else
			{
				DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE) : color(UI::Color::WHITE));
			}
		}
	}
	else
	{
		if (menulenght > 25)
		{
			if (UI::Settings::Scrollbar)
			{
				DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
				DrawText(L">    ", AddOptX + 80 + menulenght, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
			}
			else
			{
				DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(GetThemeColor()) : color(UI::Color::WHITE));
				DrawText(L">    ", AddOptX + 80 + menulenght, AddOptY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(GetThemeColor()) : color(UI::Color::WHITE));
			}
		}
		else
		{
			if (UI::Settings::Scrollbar)
			{
				DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
			}
			else
			{
				DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(GetThemeColor()) : color(UI::Color::WHITE));
			}
		}
	}
	MaxOption += 1;
}


void AddBoolOption(const wchar_t* opt, bool boolOption)
{
	int color1[3] = { 65, 65, 65 };
	int color2[3] = { 40, 40, 40 };
	//drawRectBorder(115, 52 + (10 * MaxOption), 4, 4, (boolOption) ? UI::Color::BLACK : THEME, UI::Color::WHITE);
	if (UI::Settings::Rainbow)
	{
		if (UI::Settings::Scrollbar)
		{
			DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
		}
		else
		{
			DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE) : color(UI::Color::WHITE));
		}
		if (UI::Settings::Checkbox)
		{
			if (menulenght > 25)
			{
				DrawToggleONOFF(CheckBoxX - 50 + menulenght, CheckBoxY + (10 * MaxOption), color1, UI::Color::BLACK, boolOption);
			}
			else
			{
				drawRectBorderRGBV2(CheckBoxX + menulenght, CheckBoxY + 2 + (10 * MaxOption), 4, 4, (boolOption) ? 15, 15, 15 : UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::WHITE);
			}
		}
		else
		{
			if (UI::Settings::Scrollbar)
			{
				if (UI::Settings::CheckboxV2)
				{

				}
				else
				{
					int* insideColor = boolOption ? UI::Color::RED : UI::Color::GREEN;
					int* outsideColor = UI::Color::BLACK2;
					drawRectBorder(CheckBoxX + menulenght - 21, CheckBoxY + 1 + (10 * MaxOption), 5, 5, insideColor, outsideColor);
					//DrawText(boolOption ? L"" : L"+     ", CheckBoxX + menulenght - 21, CheckBoxY + (10 * MaxOption), color(UI::Color::WHITE));
				}
			}
			else
			{
				if (UI::Settings::CheckboxV2)
				{

				}
				else
				{
					int* insideColor = boolOption ? UI::Color::RED : UI::Color::GREEN;
					int* outsideColor = UI::Color::BLACK;
					drawRectBorder(CheckBoxX + menulenght - 21, CheckBoxY + 1 + (10 * MaxOption), 5, 5, insideColor, outsideColor);
					//DrawText(boolOption ? L"" : L"+     ", CheckBoxX + menulenght - 21, CheckBoxY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE) : color(UI::Color::WHITE));
				}
			}
		}
		if (UI::Settings::CheckboxV2 && !UI::Settings::Checkbox)
		{
			DrawToggleONOFFV2(CheckBoxX - 30 + menulenght, CheckBoxY + (10 * MaxOption), color1, UI::Color::BLACK, boolOption);
		}
	}
	else
	{
		if (UI::Settings::Scrollbar)
		{
			DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
		}
		else
		{
			DrawText(opt, (MaxOption == CurrentOpt) ? AddOptX + 5 : AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
			DrawRectangle(AddOptX, (MaxOption == CurrentOpt) ? AddOptY - 2 + (10 * MaxOption) : AddOptY - 2, 1, 10, (MaxOption == CurrentOpt) ? GetThemeColor() : UI::Color::BLACK);
			DrawRectangle(AddOptX, AddOptY + 8 + (10 * MaxOption), bgW + menulenght - 6, 1, (MaxOption == CurrentOpt) ? GetThemeColor() : UI::Color::BLACK);
		}
		if (UI::Settings::Checkbox)
		{
			if (menulenght > 25)
			{
				int color1[3] = { 65, 65, 65 };
				int color2[3] = { 40, 40, 40 };
				DrawToggleONOFF(CheckBoxX - 50 + menulenght, CheckBoxY + (10 * MaxOption), color1, UI::Color::BLACK, boolOption);
			}
			else
			{
				drawRectBorder(CheckBoxX + menulenght, CheckBoxY + 2 + (10 * MaxOption), 4, 4, (boolOption) ? UI::Color::BLACK : GetThemeColor(), UI::Color::WHITE);
			}
		}
		else
		{
			if (UI::Settings::Scrollbar)
			{
				if (UI::Settings::CheckboxV2)
				{

				}
				else
				{


					int* insideColor = boolOption ? UI::Color::RED : UI::Color::GREEN;
					int* outsideColor = UI::Color::BLACK;
					drawRectBorder(CheckBoxX + menulenght - 21, CheckBoxY + 1 + (10 * MaxOption), 5, 5, insideColor, outsideColor);
					//DrawText(boolOption ? L"" : L"+     ", CheckBoxX + menulenght - 21, CheckBoxY + (10 * MaxOption), color(UI::Color::WHITE));
				}
			}
			else
			{
				if (UI::Settings::CheckboxV2)
				{

				}
				else
				{
					int* insideColor = boolOption ? UI::Color::RED : UI::Color::GREEN;
					int* outsideColor = UI::Color::BLACK;
					drawRectBorder(CheckBoxX + menulenght - 21, CheckBoxY + 1 + (10 * MaxOption), 5, 5, insideColor, outsideColor);
					//DrawText(boolOption ? L"" : L"+     ", CheckBoxX + menulenght - 21, CheckBoxY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(GetThemeColor()) : color(UI::Color::WHITE));
				}
			}
		}
		if (UI::Settings::CheckboxV2 && !UI::Settings::Checkbox)
		{
			DrawToggleONOFFV2(CheckBoxX - 30 + menulenght, CheckBoxY + (10 * MaxOption), color1, UI::Color::BLACK, boolOption);
		}
	}
	MaxOption += 1;
}

void AddBoolOptionV2(const wchar_t* opt, void(*function)(), bool boolOption)
{
	int color1[3] = { 65, 65, 65 };
	int color2[3] = { 40, 40, 40 };
	//drawRectBorder(115, 52 + (10 * MaxOption), 4, 4, (boolOption) ? UI::Color::BLACK : THEME, UI::Color::WHITE);
	if (UI::Settings::Rainbow)
	{
		if (UI::Settings::Scrollbar)
		{
			DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
		}
		else
		{
			DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE) : color(UI::Color::WHITE));
		}
		if (UI::Settings::Checkbox)
		{
			if (menulenght > 25)
			{
				DrawToggleONOFF(CheckBoxX - 50 + menulenght, CheckBoxY + (10 * MaxOption), color1, UI::Color::BLACK, boolOption);
			}
			else
			{
				drawRectBorderRGBV2(CheckBoxX + menulenght, CheckBoxY + 2 + (10 * MaxOption), 4, 4, (boolOption) ? 15, 15, 15 : UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE, UI::Color::WHITE);
			}
		}
		else
		{
			if (UI::Settings::Scrollbar)
			{
				if (UI::Settings::CheckboxV2)
				{

				}
				else
				{
					int* insideColor = boolOption ? UI::Color::RED : UI::Color::GREEN;
					int* outsideColor = UI::Color::BLACK2;
					drawRectBorder(CheckBoxX + menulenght - 21, CheckBoxY + 1 + (10 * MaxOption), 5, 5, insideColor, outsideColor);
					//DrawText(boolOption ? L"" : L"+     ", CheckBoxX + menulenght - 21, CheckBoxY + (10 * MaxOption), color(UI::Color::WHITE));
				}
			}
			else
			{
				if (UI::Settings::CheckboxV2)
				{

				}
				else
				{
					int* insideColor = boolOption ? UI::Color::RED : UI::Color::GREEN;
					int* outsideColor = UI::Color::BLACK;
					drawRectBorder(CheckBoxX + menulenght - 21, CheckBoxY + 1 + (10 * MaxOption), 5, 5, insideColor, outsideColor);
					//DrawText(boolOption ? L"" : L"+     ", CheckBoxX + menulenght - 21, CheckBoxY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE) : color(UI::Color::WHITE));
				}
			}
		}
		if (UI::Settings::CheckboxV2 && !UI::Settings::Checkbox)
		{
			DrawToggleONOFFV2(CheckBoxX - 30 + menulenght, CheckBoxY + (10 * MaxOption), color1, UI::Color::BLACK, boolOption);
		}
	}
	else
	{
		if (UI::Settings::Scrollbar)
		{
			DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
		}
		else
		{
			DrawText(opt, (MaxOption == CurrentOpt) ? AddOptX + 5 : AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
			DrawRectangle(AddOptX, (MaxOption == CurrentOpt) ? AddOptY - 2 + (10 * MaxOption) : AddOptY - 2, 1, 10, (MaxOption == CurrentOpt) ? GetThemeColor() : UI::Color::BLACK);
			DrawRectangle(AddOptX, AddOptY + 8 + (10 * MaxOption), bgW + menulenght - 6, 1, (MaxOption == CurrentOpt) ? GetThemeColor() : UI::Color::BLACK);
		}
		if (UI::Settings::Checkbox)
		{
			if (menulenght > 25)
			{
				int color1[3] = { 65, 65, 65 };
				int color2[3] = { 40, 40, 40 };
				DrawToggleONOFF(CheckBoxX - 50 + menulenght, CheckBoxY + (10 * MaxOption), color1, UI::Color::BLACK, boolOption);
			}
			else
			{
				drawRectBorder(CheckBoxX + menulenght, CheckBoxY + 2 + (10 * MaxOption), 4, 4, (boolOption) ? UI::Color::BLACK : GetThemeColor(), UI::Color::WHITE);
			}
		}
		else
		{
			if (UI::Settings::Scrollbar)
			{
				if (UI::Settings::CheckboxV2)
				{

				}
				else
				{


					int* insideColor = boolOption ? UI::Color::RED : UI::Color::GREEN;
					int* outsideColor = UI::Color::BLACK;
					drawRectBorder(CheckBoxX + menulenght - 21, CheckBoxY + 1 + (10 * MaxOption), 5, 5, insideColor, outsideColor);
					//DrawText(boolOption ? L"" : L"+     ", CheckBoxX + menulenght - 21, CheckBoxY + (10 * MaxOption), color(UI::Color::WHITE));
				}
			}
			else
			{
				if (UI::Settings::CheckboxV2)
				{

				}
				else
				{
					int* insideColor = boolOption ? UI::Color::RED : UI::Color::GREEN;
					int* outsideColor = UI::Color::BLACK;
					drawRectBorder(CheckBoxX + menulenght - 21, CheckBoxY + 1 + (10 * MaxOption), 5, 5, insideColor, outsideColor);
					//DrawText(boolOption ? L"" : L"+     ", CheckBoxX + menulenght - 21, CheckBoxY + (10 * MaxOption), (MaxOption == CurrentOpt) ? color(GetThemeColor()) : color(UI::Color::WHITE));
				}
			}
		}
		if (UI::Settings::CheckboxV2 && !UI::Settings::Checkbox)
		{
			DrawToggleONOFFV2(CheckBoxX - 30 + menulenght, CheckBoxY + (10 * MaxOption), color1, UI::Color::BLACK, boolOption);
		}
	}
	MaxOption += 1;
}

void AddIntOption(const wchar_t* opt, int def, int IntOptions)
{
	if (UI::Settings::Scrollbar)
	{
		DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
	}
	else
	{
		DrawText(opt, (MaxOption == CurrentOpt) ? AddOptX + 5 : AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
	}

	if (IntOptions > 99)
	{
		if (!UI::Settings::Scrollbar)
		{
			DrawRectangle(AddOptX, (MaxOption == CurrentOpt) ? AddOptY - 2 + (10 * MaxOption) : AddOptY - 2, 1, 10, (MaxOption == CurrentOpt) ? GetThemeColor() : UI::Color::BLACK);
			DrawRectangle(AddOptX, AddOptY + 8 + (10 * MaxOption), bgW + menulenght - 6, 1, (MaxOption == CurrentOpt) ? GetThemeColor() : UI::Color::BLACK);
		}

		if (IntOptions == def)
		{
			DrawText(L"< Default >    ", CheckBoxX - 56 + menulenght, CheckBoxY + (10 * MaxOption), color(UI::Color::WHITE));
		}
		else
		{
			snprintf("< %i >    ", (int)IntOptions, CheckBoxX - 40 + menulenght, CheckBoxY + (10 * MaxOption));
		}
	}
	else
	{
		if (!UI::Settings::Scrollbar)
		{
			DrawRectangle(AddOptX, (MaxOption == CurrentOpt) ? AddOptY - 2 + (10 * MaxOption) : AddOptY - 2, 1, 10, (MaxOption == CurrentOpt) ? GetThemeColor() : UI::Color::BLACK);
			DrawRectangle(AddOptX, AddOptY + 8 + (10 * MaxOption), bgW + menulenght - 6, 1, (MaxOption == CurrentOpt) ? GetThemeColor() : UI::Color::BLACK);
		}
		if (IntOptions == def)
		{
			DrawText(L"< Default >    ", CheckBoxX - 56 + menulenght, CheckBoxY + (10 * MaxOption), color(UI::Color::WHITE));
		}
		else
		{
			snprintf("< %i >    ", (int)IntOptions, CheckBoxX - 35 + menulenght, CheckBoxY + (10 * MaxOption));
		}
	}
	MaxOption += 1;
}

void AddFloatOption(const wchar_t* opt, float FloatOptions)
{
	if (UI::Settings::Scrollbar)
	{
		DrawText(opt, AddOptX, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
	}
	else
	{
		DrawText(opt, AddOptX + 5, AddOptY + (10 * MaxOption), color(UI::Color::WHITE));
	}
	char option46[0x100];
	wchar_t woption46[0x100];
	_sys_memset(option46, 0, 0x100);
	_sys_memset(woption46, 0, 0x200);
	_sys_snprintf(option46, 0x100, "< %i >   ", (int)FloatOptions);
	StringToWideCharacter(woption46, option46, _sys_strlen(option46));
	DrawText(woption46, CheckBoxX - 3 + menulenght, CheckBoxY + (10 * MaxOption), color(UI::Color::WHITE));
	MaxOption += 1;
}

void InventoryCreativeTumble()
{
	int wI = 0;
	keyPressed[wI] = false;

	if (InventoryCreaTumbleActive)
	{
		if (InventoryCreaTumble)
			DrawText(L"Press DPAD LEFT for Disable", 27, 335, color(UI::Color::WHITE));
		else
			DrawText(L"Press DPAD LEFT for Enable", 27, 335, color(UI::Color::WHITE));

		if (Buttons::IsMCButtonPressed(Buttons::LEFT))
		{
			if (scrollWait(firstWaitTime, waitTime, wI))
			{
				if (!InventoryCreaTumble)
				{
					*(int*)0x00AD8480 = 0x41820024;
					*(int*)0x0098871C = 0x38600001;
					*(int*)0x002F0348 = 0x38800001;
					*(int*)0x002F0398 = 0x38800000;
					InventoryCreaTumble = true;
				}
				else
				{
					*(int*)0x00AD8480 = 0x40820024;
					*(int*)0x0098871C = 0x38600000;
					*(int*)0x002F0348 = 0x38800000;
					*(int*)0x002F0398 = 0x38800001;
					InventoryCreaTumble = false;
				}
			}
		}
	}
}

void VersionText()
{
	if (devmenu)
	{
		DrawTextWithShadow(L"DEV Edition", 98, 13, color(UI::Color::WHITE));
	}
	else
	{
		DrawTextWithShadow(L"Public Edition", 98, 13, color(UI::Color::WHITE));
	}
}

void DEBUG_FUNCTIONS_MESSAGES()
{
	if (UI::Settings::ShowPosition)
	{
		DEBUG_FUNCTIONS_MESSAGE = 35;
		if (UI::Settings::ShowPING)
		{
			DEBUG_FUNCTIONS_MESSAGE = 45;
			if (UI::Settings::ShowChunks)
			{
				DEBUG_FUNCTIONS_MESSAGE = 55;
				if (UI::Settings::ShowResolution)
				{
					DEBUG_FUNCTIONS_MESSAGE = 65;
					if (UI::Settings::ShowCPURSX)
					{
						DEBUG_FUNCTIONS_MESSAGE = 75;
						if (UI::Settings::ShowGametime)
						{
							DEBUG_FUNCTIONS_MESSAGE = 85;
						}
					}
				}
			}
		}
	}

	if (mc->theMinecraft->cMultiplayerLocalPlayer->isInWeb == true)
	{
		DrawTextWithShadow(L"[In Web]", 20, DEBUG_FUNCTIONS_MESSAGE, color(UI::Color::WHITE));
	}
	if (mc->theMinecraft->cMultiplayerLocalPlayer->IsSprinting())
	{
		DrawTextWithShadow(L"[Sprinting]", 20, DEBUG_FUNCTIONS_MESSAGE, color(UI::Color::WHITE));
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->IsSneaking())
	{
		DrawTextWithShadow(L"[Sneaking]", 20, DEBUG_FUNCTIONS_MESSAGE, color(UI::Color::WHITE));
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->IsSpectator())
	{
		DrawTextWithShadow(L"[Spectator]", 20, DEBUG_FUNCTIONS_MESSAGE, color(UI::Color::WHITE));
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->IsBurning())
	{
		DrawTextWithShadow(L"[Burning]", 20, DEBUG_FUNCTIONS_MESSAGE, color(UI::Color::WHITE));
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->isInWater())
	{
		DrawTextWithShadow(L"[In Water]", 20, DEBUG_FUNCTIONS_MESSAGE, color(UI::Color::WHITE));
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->fallDistance > 0)
	{
		DrawTextWithShadow(L"[Falling]", 20, DEBUG_FUNCTIONS_MESSAGE, color(UI::Color::WHITE));
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->onGround == true)
	{
		DrawTextWithShadow(L"[On Ground]", 20, DEBUG_FUNCTIONS_MESSAGE, color(UI::Color::WHITE));
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->isDead == true)
	{
		DrawTextWithShadow(L"[Is Dead]", 20, DEBUG_FUNCTIONS_MESSAGE, color(UI::Color::WHITE));
	}
}

void Welcome_Message()
{
	DrawText(L"Welcome: ", 20, 25, color(UI::Color::WHITE));
	if (!UI::Settings::ShowPosition)
		DrawTextC(PSN_NAME, 60, 25, color(UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE));
}

#pragma endregion

#pragma region "Get function"

void get_temperature(uint32_t a, uint32_t* b)
{
	system_call_2(383, (uint64_t)(uint32_t)a, (uint64_t)(uint32_t)b);
}

void get_temp()
{
	if (UI::Settings::ShowCPURSX)
	{
		if (frameTime(120, 1, false))
		{
			char systemperature[100];
			get_temperature(0, &cpu_t);//0 cpu
			get_temperature(1, &rsx_t);//1 rsx
			cpu_t = cpu_t >> 24;
			rsx_t = rsx_t >> 24;
		}

		char option[0x100];
		wchar_t woption[0x100];
		_sys_memset(option, 0, 0x100);
		_sys_memset(woption, 0, 0x200);
		_sys_snprintf(option, 0x100, "CPU :  %iC / RSX :  %iC", cpu_t, rsx_t);
		StringToWideCharacter(woption, option, strlen(option));

		int width = Font_width(woption);
		DrawRectangle(15, 63, width + 5, 10, UI::Color::BLACK);
		DrawText(woption, 18, 64, color(UI::MCTextColors::White));
	}
}

void GetPosition()
{
	if (UI::Settings::ShowPosition)
	{
		char option[0x100];
		wchar_t woption[0x100];
		_sys_memset(option, 0, 0x100);
		_sys_memset(woption, 0, 0x200);
		_sys_snprintf(option, 0x100, "Position: %i, %i, %i", (int)mc->theMinecraft->cMultiplayerLocalPlayer->posX - 1, (int)mc->theMinecraft->cMultiplayerLocalPlayer->posY + 1, (int)mc->theMinecraft->cMultiplayerLocalPlayer->posZ);
		StringToWideCharacter(woption, option, strlen(option));

		int width = Font_width(woption);
		DrawRectangle(15, 23, width + 5, 10, UI::Color::BLACK);
		DrawText(woption, 18, 24, color(UI::MCTextColors::White));
	}
}

void GetDebugXY()
{
	snprintf("Text X: %i", DebugTextX, 130, 55);
	snprintf("Text Y: %i", DebugTextY, 130, 65);
	snprintf("Hud X: %i", DebugHudX, 130, 75);
	snprintf("Hud Y: %i", DebugHudY, 130, 85);
	snprintf("Hud W: %i", DebugHudW, 130, 95);
	snprintf("Hud H: %i", DebugHudH, 130, 105);
	snprintf("Line Start X: %i", DebugLineStartX, 130, 115);
	snprintf("Line Start Y: %i", DebugLineStartY, 130, 125);
	snprintf("Line End X: %i", DebugLineEndX, 130, 135);
	snprintf("Line End Y: %i", DebugLineEndY, 130, 145);
}

void GetPingz()
{
	if (frameTime(30, 1, false))
	{
		_sys_memset(PING, 0, 0x100);
		_sys_memset(wPING, 0, 0x200);
		_sys_snprintf(PING, 0x100, "Ping: %i", (mc->FPS));
		StringToWideCharacter(wPING, PING, _sys_strlen(PING));
	}
}

void GetPing()
{
	if (UI::Settings::ShowPING)
	{
		GetPingz();
		int width = Font_width(wPING);
		DrawRectangle(15, 33, width + 5, 10, UI::Color::BLACK);
		DrawText(wPING, 18, 34, color(UI::MCTextColors::White));
	}
}

void GetChunks()
{
	if (UI::Settings::ShowChunks)
	{
		char option[0x100];
		wchar_t woption[0x100];
		_sys_memset(option, 0, 0x100);
		_sys_memset(woption, 0, 0x200);
		_sys_snprintf(option, 0x100, "Chunk: (%i, %i, %i)", (int)mc->theMinecraft->cMultiplayerLocalPlayer->chunkCoordX + 1, (int)mc->theMinecraft->cMultiplayerLocalPlayer->chunkCoordY + 1, (int)mc->theMinecraft->cMultiplayerLocalPlayer->chunkCoordZ + 1);
		StringToWideCharacter(woption, option, strlen(option));

		int width = Font_width(woption);
		DrawRectangle(15, 43, width + 5, 10, UI::Color::BLACK);
		DrawText(woption, 18, 44, color(UI::MCTextColors::White));
	}
}

void GetResolution()
{
	if (UI::Settings::ShowResolution)
	{
		char option[0x100];
		wchar_t woption[0x100];
		_sys_memset(option, 0, 0x100);
		_sys_memset(woption, 0, 0x200);
		_sys_snprintf(option, 0x100, "Resolution: %ix%i", mc->theMinecraft->displayWidth, mc->theMinecraft->displayHeight);
		StringToWideCharacter(woption, option, strlen(option));

		int width = Font_width(woption);
		DrawRectangle(15, 53, width + 5, 10, UI::Color::BLACK);
		DrawText(woption, 18, 54, color(UI::MCTextColors::White));
	}
}

void GetTeleportXYZ()
{
	snprintf("TP X: %i", TeleportX, 130, 55);
	snprintf("TP Y: %i", TeleportY, 130, 65);
	snprintf("TP Z: %i", TeleportZ, 130, 75);
}

#include "HudsFunctions.h"

int milliseconds;
int seconds;
int minutes;
int hours;
void GetGameTime()
{
	if (UI::Settings::ShowGametime)
	{
		int pos[2] = { 18, 74 };
		milliseconds = mc->gameTime;
		seconds = (milliseconds / 60);
		minutes = seconds / 60;
		hours = minutes / 60;

		char option4[0x100];
		wchar_t woption4[0x100];
		_sys_memset(option4, 0, 0x100);
		_sys_memset(woption4, 0, 0x200);
		_sys_snprintf(option4, 0x100, "Gametime: %ih:%imin:%isec", int(hours % 24), int(minutes % 60), int(seconds % 60));
		StringToWideCharacter(woption4, option4, _sys_strlen(option4));

		int width = Font_width(woption4);
		DrawRectangle(15, 73, width + 5, 10, UI::Color::BLACK);
		DrawText(woption4, pos[0], pos[1], color(UI::Color::WHITE));
	}
}


#pragma endregion

#pragma region "Get last player infos"

void GetInfosLastPlayer()
{
	if (PlayersInfos)
	{

		if (*(int*)0x30F46AD8 == 0xFFFFFFFF)
		{
			PLR_NAME = "N/A    ";
			PLR_REGION = "N/A    ";
		}
		else
		{
			if (*(int*)0x30F46AC4 == 0xFFFFFFFF)
			{
				PLR_NAME = "N/A    ";
				PLR_REGION = "N/A    ";
			}
			else
			{
				PLR_NAME = PS3Lib::ReadString(0x30F46AC4);
				PLR_REGION = PS3Lib::ReadString(0x30F46AD8);
			}
		}

		strcpy((char*)0x3000AF0A, PLR_NAME); //unique ID

		if (PLR_NAME == "cry_naegga")
		{
			DrawText(L"Misaki is here !", 37, 314, color(UI::Color::WHITE));
		}

		DrawRectangle(15, 70, 90, 24, UI::Color::BLACK);
		DrawTextC(PLR_NAME, 20, 74, color(UI::Color::WHITE));
		DrawTextC(PLR_REGION, 20, 84, color(UI::Color::WHITE));
	}
}

#pragma endregion

#pragma region "Custom Crosshair"

void Custom_Crosshair(int value)
{
	if (custom_crosshair)
	{
		if (value == 0)
		{
			//drawLine(Vector2(322, 181), Vector2(312, 194), GetThemeColor());
			//drawLine(Vector2(322, 181), Vector2(333, 194), GetThemeColor());
			*(int*)0x0155847C = 0x01000000;
		}
		else if (value == 1)
		{
			DrawRectangle(316, 176, 8, 8, GetThemeColor());
		}
		else if (value == 2)
		{
			DrawRectangle(317, 177, 6, 1, UI::Color::WHITE);
			DrawRectangle(317, 182, 6, 1, UI::Color::WHITE);
			DrawRectangle(317, 177, 1, 6, UI::Color::WHITE);
			DrawRectangle(322, 177, 1, 6, UI::Color::WHITE);
		}
	}
}

#pragma endregion

#pragma region "DRAWING HEAD PIXEL"

int AlexColorHair[3] = { 250, 140, 17 };
int AlexColorSkins[3] = { 248, 197, 170 };
int AlexColorEyesWhite[3] = { 255, 255, 255 };
int AlexColorEyes[3] = { 11, 139, 16 };
int AlexColorMouth[3] = { 252, 172, 197 };
int AlexHeadpos[2] = { 98, 5 };
int AlexHeadsize[2] = { 2, 2 };
int AlexHeadspace[7] = { 5, 10, 15, 20, 25, 30, 35 };

float AlexBlinkEyes = 0;
float AlexBlinkEyesTimer = 0;

void DrawAlexHead()
{
	if (AlexHeadsize[1] == 2)
	{
		AlexHeadspace[0] = 2; AlexHeadspace[1] = 4; AlexHeadspace[2] = 6; AlexHeadspace[3] = 8; AlexHeadspace[4] = 10; AlexHeadspace[5] = 12; AlexHeadspace[6] = 14;
	}
	else if (AlexHeadsize[1] == 3)
	{
		AlexHeadspace[0] = 3; AlexHeadspace[1] = 6; AlexHeadspace[2] = 9; AlexHeadspace[3] = 12; AlexHeadspace[4] = 15; AlexHeadspace[5] = 18; AlexHeadspace[6] = 21;
	}
	else if (AlexHeadsize[1] == 5)
	{
		AlexHeadspace[0] = 5; AlexHeadspace[1] = 10; AlexHeadspace[2] = 15; AlexHeadspace[3] = 20; AlexHeadspace[4] = 25; AlexHeadspace[5] = 30; AlexHeadspace[6] = 35;
	}
	else if (AlexHeadsize[1] == 10)
	{
		AlexHeadspace[0] = 10; AlexHeadspace[1] = 20; AlexHeadspace[2] = 30; AlexHeadspace[3] = 40; AlexHeadspace[4] = 50; AlexHeadspace[5] = 60; AlexHeadspace[6] = 70;
	}

	DrawRectangle(AlexHeadpos[0], AlexHeadpos[1], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[0], AlexHeadpos[1], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[1], AlexHeadpos[1], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[2], AlexHeadpos[1], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[3], AlexHeadpos[1], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[4], AlexHeadpos[1], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[5], AlexHeadpos[1], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[6], AlexHeadpos[1], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);

	DrawRectangle(AlexHeadpos[0], AlexHeadpos[1] + AlexHeadspace[0], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[0], AlexHeadpos[1] + AlexHeadspace[0], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[1], AlexHeadpos[1] + AlexHeadspace[0], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[2], AlexHeadpos[1] + AlexHeadspace[0], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[3], AlexHeadpos[1] + AlexHeadspace[0], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[4], AlexHeadpos[1] + AlexHeadspace[0], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[5], AlexHeadpos[1] + AlexHeadspace[0], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[6], AlexHeadpos[1] + AlexHeadspace[0], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);

	DrawRectangle(AlexHeadpos[0], AlexHeadpos[1] + AlexHeadspace[1], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[0], AlexHeadpos[1] + AlexHeadspace[1], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[1], AlexHeadpos[1] + AlexHeadspace[1], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[2], AlexHeadpos[1] + AlexHeadspace[1], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[3], AlexHeadpos[1] + AlexHeadspace[1], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[4], AlexHeadpos[1] + AlexHeadspace[1], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[5], AlexHeadpos[1] + AlexHeadspace[1], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[6], AlexHeadpos[1] + AlexHeadspace[1], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);

	DrawRectangle(AlexHeadpos[0], AlexHeadpos[1] + AlexHeadspace[2], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[0], AlexHeadpos[1] + AlexHeadspace[2], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[1], AlexHeadpos[1] + AlexHeadspace[2], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[2], AlexHeadpos[1] + AlexHeadspace[2], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[3], AlexHeadpos[1] + AlexHeadspace[2], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[4], AlexHeadpos[1] + AlexHeadspace[2], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[5], AlexHeadpos[1] + AlexHeadspace[2], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[6], AlexHeadpos[1] + AlexHeadspace[2], AlexHeadsize[0], AlexHeadsize[1], AlexColorHair);

	if (AlexBlinkEyes > -1)
		AlexBlinkEyes += 5;

	if (AlexBlinkEyes > 1500)
	{
		DrawRectangle(AlexHeadpos[0], AlexHeadpos[1] + AlexHeadspace[3], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
		DrawRectangle(AlexHeadpos[0] + AlexHeadspace[0], AlexHeadpos[1] + AlexHeadspace[3], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
		DrawRectangle(AlexHeadpos[0] + AlexHeadspace[1], AlexHeadpos[1] + AlexHeadspace[3], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
		DrawRectangle(AlexHeadpos[0] + AlexHeadspace[2], AlexHeadpos[1] + AlexHeadspace[3], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
		DrawRectangle(AlexHeadpos[0] + AlexHeadspace[3], AlexHeadpos[1] + AlexHeadspace[3], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
		DrawRectangle(AlexHeadpos[0] + AlexHeadspace[4], AlexHeadpos[1] + AlexHeadspace[3], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
		DrawRectangle(AlexHeadpos[0] + AlexHeadspace[5], AlexHeadpos[1] + AlexHeadspace[3], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
		DrawRectangle(AlexHeadpos[0] + AlexHeadspace[6], AlexHeadpos[1] + AlexHeadspace[3], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);

		if (AlexBlinkEyesTimer > -1)
			AlexBlinkEyesTimer += 1;

		if (AlexBlinkEyesTimer > 30)
		{
			AlexBlinkEyesTimer = 0;
			AlexBlinkEyes = 0;
		}
	}
	else
	{
		DrawRectangle(AlexHeadpos[0], AlexHeadpos[1] + AlexHeadspace[3], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
		DrawRectangle(AlexHeadpos[0] + AlexHeadspace[0], AlexHeadpos[1] + AlexHeadspace[3], AlexHeadsize[0], AlexHeadsize[1], AlexColorEyesWhite);
		DrawRectangle(AlexHeadpos[0] + AlexHeadspace[1], AlexHeadpos[1] + AlexHeadspace[3], AlexHeadsize[0], AlexHeadsize[1], AlexColorEyes);
		DrawRectangle(AlexHeadpos[0] + AlexHeadspace[2], AlexHeadpos[1] + AlexHeadspace[3], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
		DrawRectangle(AlexHeadpos[0] + AlexHeadspace[3], AlexHeadpos[1] + AlexHeadspace[3], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
		DrawRectangle(AlexHeadpos[0] + AlexHeadspace[4], AlexHeadpos[1] + AlexHeadspace[3], AlexHeadsize[0], AlexHeadsize[1], AlexColorEyes);
		DrawRectangle(AlexHeadpos[0] + AlexHeadspace[5], AlexHeadpos[1] + AlexHeadspace[3], AlexHeadsize[0], AlexHeadsize[1], AlexColorEyesWhite);
		DrawRectangle(AlexHeadpos[0] + AlexHeadspace[6], AlexHeadpos[1] + AlexHeadspace[3], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	}


	DrawRectangle(AlexHeadpos[0], AlexHeadpos[1] + AlexHeadspace[4], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[0], AlexHeadpos[1] + AlexHeadspace[4], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[1], AlexHeadpos[1] + AlexHeadspace[4], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[2], AlexHeadpos[1] + AlexHeadspace[4], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[3], AlexHeadpos[1] + AlexHeadspace[4], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[4], AlexHeadpos[1] + AlexHeadspace[4], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[5], AlexHeadpos[1] + AlexHeadspace[4], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[6], AlexHeadpos[1] + AlexHeadspace[4], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);

	DrawRectangle(AlexHeadpos[0], AlexHeadpos[1] + AlexHeadspace[5], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[0], AlexHeadpos[1] + AlexHeadspace[5], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[1], AlexHeadpos[1] + AlexHeadspace[5], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[2], AlexHeadpos[1] + AlexHeadspace[5], AlexHeadsize[0], AlexHeadsize[1], AlexColorMouth);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[3], AlexHeadpos[1] + AlexHeadspace[5], AlexHeadsize[0], AlexHeadsize[1], AlexColorMouth);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[4], AlexHeadpos[1] + AlexHeadspace[5], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[5], AlexHeadpos[1] + AlexHeadspace[5], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[6], AlexHeadpos[1] + AlexHeadspace[5], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);

	DrawRectangle(AlexHeadpos[0], AlexHeadpos[1] + AlexHeadspace[6], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[0], AlexHeadpos[1] + AlexHeadspace[6], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[1], AlexHeadpos[1] + AlexHeadspace[6], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[2], AlexHeadpos[1] + AlexHeadspace[6], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[3], AlexHeadpos[1] + AlexHeadspace[6], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[4], AlexHeadpos[1] + AlexHeadspace[6], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[5], AlexHeadpos[1] + AlexHeadspace[6], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
	DrawRectangle(AlexHeadpos[0] + AlexHeadspace[6], AlexHeadpos[1] + AlexHeadspace[6], AlexHeadsize[0], AlexHeadsize[1], AlexColorSkins);
}

int SteveColorHair[3] = { 45, 32, 15 };
int SteveColorSkins[3] = { 187, 137, 114 };
int SteveColorEyesWhite[3] = { 255, 255, 255 };
int SteveColorEyes[3] = { 24, 45, 108 };
int SteveColorNose[3] = { 83, 51, 13 };
int SteveColorMouth[3] = { 59, 38, 11 };
int SteveHeadpos[2] = { 98, 5 };
int SteveHeadsize[2] = { 2, 2 };
int SteveHeadspace[7] = { 5, 10, 15, 20, 25, 30, 35 };

float SteveBlinkEyes = 0;
float SteveBlinkEyesTimer = 0;

void DrawSteveHead()
{
	if (SteveHeadsize[1] == 2)
	{
		SteveHeadspace[0] = 2; SteveHeadspace[1] = 4; SteveHeadspace[2] = 6; SteveHeadspace[3] = 8; SteveHeadspace[4] = 10; SteveHeadspace[5] = 12; SteveHeadspace[6] = 14;
	}
	else if (SteveHeadsize[1] == 3)
	{
		SteveHeadspace[0] = 3; SteveHeadspace[1] = 6; SteveHeadspace[2] = 9; SteveHeadspace[3] = 12; SteveHeadspace[4] = 15; SteveHeadspace[5] = 18; SteveHeadspace[6] = 21;
	}
	else if (SteveHeadsize[1] == 5)
	{
		SteveHeadspace[0] = 5; SteveHeadspace[1] = 10; SteveHeadspace[2] = 15; SteveHeadspace[3] = 20; SteveHeadspace[4] = 25; SteveHeadspace[5] = 30; SteveHeadspace[6] = 35;
	}
	else if (SteveHeadsize[1] == 10)
	{
		SteveHeadspace[0] = 10; SteveHeadspace[1] = 20; SteveHeadspace[2] = 30; SteveHeadspace[3] = 40; SteveHeadspace[4] = 50; SteveHeadspace[5] = 60; SteveHeadspace[6] = 70;
	}

	DrawRectangle(SteveHeadpos[0], SteveHeadpos[1], SteveHeadsize[0], SteveHeadsize[1], SteveColorHair);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[0], SteveHeadpos[1], SteveHeadsize[0], SteveHeadsize[1], SteveColorHair);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[1], SteveHeadpos[1], SteveHeadsize[0], SteveHeadsize[1], SteveColorHair);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[2], SteveHeadpos[1], SteveHeadsize[0], SteveHeadsize[1], SteveColorHair);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[3], SteveHeadpos[1], SteveHeadsize[0], SteveHeadsize[1], SteveColorHair);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[4], SteveHeadpos[1], SteveHeadsize[0], SteveHeadsize[1], SteveColorHair);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[5], SteveHeadpos[1], SteveHeadsize[0], SteveHeadsize[1], SteveColorHair);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[6], SteveHeadpos[1], SteveHeadsize[0], SteveHeadsize[1], SteveColorHair);

	DrawRectangle(SteveHeadpos[0], SteveHeadpos[1] + SteveHeadspace[0], SteveHeadsize[0], SteveHeadsize[1], SteveColorHair);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[0], SteveHeadpos[1] + SteveHeadspace[0], SteveHeadsize[0], SteveHeadsize[1], SteveColorHair);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[1], SteveHeadpos[1] + SteveHeadspace[0], SteveHeadsize[0], SteveHeadsize[1], SteveColorHair);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[2], SteveHeadpos[1] + SteveHeadspace[0], SteveHeadsize[0], SteveHeadsize[1], SteveColorHair);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[3], SteveHeadpos[1] + SteveHeadspace[0], SteveHeadsize[0], SteveHeadsize[1], SteveColorHair);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[4], SteveHeadpos[1] + SteveHeadspace[0], SteveHeadsize[0], SteveHeadsize[1], SteveColorHair);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[5], SteveHeadpos[1] + SteveHeadspace[0], SteveHeadsize[0], SteveHeadsize[1], SteveColorHair);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[6], SteveHeadpos[1] + SteveHeadspace[0], SteveHeadsize[0], SteveHeadsize[1], SteveColorHair);

	DrawRectangle(SteveHeadpos[0], SteveHeadpos[1] + SteveHeadspace[1], SteveHeadsize[0], SteveHeadsize[1], SteveColorHair);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[0], SteveHeadpos[1] + SteveHeadspace[1], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[1], SteveHeadpos[1] + SteveHeadspace[1], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[2], SteveHeadpos[1] + SteveHeadspace[1], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[3], SteveHeadpos[1] + SteveHeadspace[1], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[4], SteveHeadpos[1] + SteveHeadspace[1], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[5], SteveHeadpos[1] + SteveHeadspace[1], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[6], SteveHeadpos[1] + SteveHeadspace[1], SteveHeadsize[0], SteveHeadsize[1], SteveColorHair);

	DrawRectangle(SteveHeadpos[0], SteveHeadpos[1] + SteveHeadspace[2], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[0], SteveHeadpos[1] + SteveHeadspace[2], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[1], SteveHeadpos[1] + SteveHeadspace[2], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[2], SteveHeadpos[1] + SteveHeadspace[2], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[3], SteveHeadpos[1] + SteveHeadspace[2], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[4], SteveHeadpos[1] + SteveHeadspace[2], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[5], SteveHeadpos[1] + SteveHeadspace[2], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[6], SteveHeadpos[1] + SteveHeadspace[2], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);

	if (SteveBlinkEyes > -1)
		SteveBlinkEyes += 5;

	if (SteveBlinkEyes > 1500)
	{
		DrawRectangle(SteveHeadpos[0], SteveHeadpos[1] + SteveHeadspace[3], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
		DrawRectangle(SteveHeadpos[0] + SteveHeadspace[0], SteveHeadpos[1] + SteveHeadspace[3], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
		DrawRectangle(SteveHeadpos[0] + SteveHeadspace[1], SteveHeadpos[1] + SteveHeadspace[3], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
		DrawRectangle(SteveHeadpos[0] + SteveHeadspace[2], SteveHeadpos[1] + SteveHeadspace[3], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
		DrawRectangle(SteveHeadpos[0] + SteveHeadspace[3], SteveHeadpos[1] + SteveHeadspace[3], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
		DrawRectangle(SteveHeadpos[0] + SteveHeadspace[4], SteveHeadpos[1] + SteveHeadspace[3], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
		DrawRectangle(SteveHeadpos[0] + SteveHeadspace[5], SteveHeadpos[1] + SteveHeadspace[3], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
		DrawRectangle(SteveHeadpos[0] + SteveHeadspace[6], SteveHeadpos[1] + SteveHeadspace[3], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);

		if (SteveBlinkEyesTimer > -1)
			SteveBlinkEyesTimer += 1;

		if (SteveBlinkEyesTimer > 30)
		{
			SteveBlinkEyesTimer = 0;
			SteveBlinkEyes = 0;
		}
	}
	else
	{
		DrawRectangle(SteveHeadpos[0], SteveHeadpos[1] + SteveHeadspace[3], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
		DrawRectangle(SteveHeadpos[0] + SteveHeadspace[0], SteveHeadpos[1] + SteveHeadspace[3], SteveHeadsize[0], SteveHeadsize[1], SteveColorEyesWhite);
		DrawRectangle(SteveHeadpos[0] + SteveHeadspace[1], SteveHeadpos[1] + SteveHeadspace[3], SteveHeadsize[0], SteveHeadsize[1], SteveColorEyes);
		DrawRectangle(SteveHeadpos[0] + SteveHeadspace[2], SteveHeadpos[1] + SteveHeadspace[3], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
		DrawRectangle(SteveHeadpos[0] + SteveHeadspace[3], SteveHeadpos[1] + SteveHeadspace[3], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
		DrawRectangle(SteveHeadpos[0] + SteveHeadspace[4], SteveHeadpos[1] + SteveHeadspace[3], SteveHeadsize[0], SteveHeadsize[1], SteveColorEyes);
		DrawRectangle(SteveHeadpos[0] + SteveHeadspace[5], SteveHeadpos[1] + SteveHeadspace[3], SteveHeadsize[0], SteveHeadsize[1], SteveColorEyesWhite);
		DrawRectangle(SteveHeadpos[0] + SteveHeadspace[6], SteveHeadpos[1] + SteveHeadspace[3], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	}


	DrawRectangle(SteveHeadpos[0], SteveHeadpos[1] + SteveHeadspace[4], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[0], SteveHeadpos[1] + SteveHeadspace[4], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[1], SteveHeadpos[1] + SteveHeadspace[4], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[2], SteveHeadpos[1] + SteveHeadspace[4], SteveHeadsize[0], SteveHeadsize[1], SteveColorNose);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[3], SteveHeadpos[1] + SteveHeadspace[4], SteveHeadsize[0], SteveHeadsize[1], SteveColorNose);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[4], SteveHeadpos[1] + SteveHeadspace[4], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[5], SteveHeadpos[1] + SteveHeadspace[4], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[6], SteveHeadpos[1] + SteveHeadspace[4], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);

	DrawRectangle(SteveHeadpos[0], SteveHeadpos[1] + SteveHeadspace[5], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[0], SteveHeadpos[1] + SteveHeadspace[5], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[1], SteveHeadpos[1] + SteveHeadspace[5], SteveHeadsize[0], SteveHeadsize[1], SteveColorMouth);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[2], SteveHeadpos[1] + SteveHeadspace[5], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[3], SteveHeadpos[1] + SteveHeadspace[5], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[4], SteveHeadpos[1] + SteveHeadspace[5], SteveHeadsize[0], SteveHeadsize[1], SteveColorMouth);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[5], SteveHeadpos[1] + SteveHeadspace[5], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[6], SteveHeadpos[1] + SteveHeadspace[5], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);

	DrawRectangle(SteveHeadpos[0], SteveHeadpos[1] + SteveHeadspace[6], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[0], SteveHeadpos[1] + SteveHeadspace[6], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[1], SteveHeadpos[1] + SteveHeadspace[6], SteveHeadsize[0], SteveHeadsize[1], SteveColorMouth);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[2], SteveHeadpos[1] + SteveHeadspace[6], SteveHeadsize[0], SteveHeadsize[1], SteveColorMouth);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[3], SteveHeadpos[1] + SteveHeadspace[6], SteveHeadsize[0], SteveHeadsize[1], SteveColorMouth);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[4], SteveHeadpos[1] + SteveHeadspace[6], SteveHeadsize[0], SteveHeadsize[1], SteveColorMouth);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[5], SteveHeadpos[1] + SteveHeadspace[6], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
	DrawRectangle(SteveHeadpos[0] + SteveHeadspace[6], SteveHeadpos[1] + SteveHeadspace[6], SteveHeadsize[0], SteveHeadsize[1], SteveColorSkins);
}

int EndermanColorSkins1[3] = { 1, 1, 1 };
int EndermanColorSkins2[3] = { 22, 22, 22 };
int EndermanColorEyes1[3] = { 224, 121, 252 };
int EndermanColorEyes2[3] = { 205, 0, 249 };
int EndermanHeadpos[2] = { 98, 5 };
int EndermanHeadsize[2] = { 2, 2 };
int EndermanHeadspace[7] = { 5, 10, 15, 20, 25, 30, 35 };

float EndermanBlinkEyes = 0;
float EndermanBlinkEyesTimer = 0;

void DrawEndermanHead()
{
	if (EndermanHeadsize[1] == 2)
	{
		EndermanHeadspace[0] = 2; EndermanHeadspace[1] = 4; EndermanHeadspace[2] = 6; EndermanHeadspace[3] = 8; EndermanHeadspace[4] = 10; EndermanHeadspace[5] = 12; EndermanHeadspace[6] = 14;
	}
	else if (EndermanHeadsize[1] == 3)
	{
		EndermanHeadspace[0] = 3; EndermanHeadspace[1] = 6; EndermanHeadspace[2] = 9; EndermanHeadspace[3] = 12; EndermanHeadspace[4] = 15; EndermanHeadspace[5] = 18; EndermanHeadspace[6] = 21;
	}
	else if (EndermanHeadsize[1] == 5)
	{
		EndermanHeadspace[0] = 5; EndermanHeadspace[1] = 10; EndermanHeadspace[2] = 15; EndermanHeadspace[3] = 20; EndermanHeadspace[4] = 25; EndermanHeadspace[5] = 30; EndermanHeadspace[6] = 35;
	}
	else if (EndermanHeadsize[1] == 10)
	{
		EndermanHeadspace[0] = 10; EndermanHeadspace[1] = 20; EndermanHeadspace[2] = 30; EndermanHeadspace[3] = 40; EndermanHeadspace[4] = 50; EndermanHeadspace[5] = 60; EndermanHeadspace[6] = 70;
	}

	DrawRectangle(EndermanHeadpos[0], EndermanHeadpos[1], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[0], EndermanHeadpos[1], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[1], EndermanHeadpos[1], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[2], EndermanHeadpos[1], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[3], EndermanHeadpos[1], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[4], EndermanHeadpos[1], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[5], EndermanHeadpos[1], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[6], EndermanHeadpos[1], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);

	DrawRectangle(EndermanHeadpos[0], EndermanHeadpos[1] + EndermanHeadspace[0], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[0], EndermanHeadpos[1] + EndermanHeadspace[0], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[1], EndermanHeadpos[1] + EndermanHeadspace[0], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[2], EndermanHeadpos[1] + EndermanHeadspace[0], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[3], EndermanHeadpos[1] + EndermanHeadspace[0], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[4], EndermanHeadpos[1] + EndermanHeadspace[0], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[5], EndermanHeadpos[1] + EndermanHeadspace[0], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[6], EndermanHeadpos[1] + EndermanHeadspace[0], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);

	DrawRectangle(EndermanHeadpos[0], EndermanHeadpos[1] + EndermanHeadspace[1], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[0], EndermanHeadpos[1] + EndermanHeadspace[1], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[1], EndermanHeadpos[1] + EndermanHeadspace[1], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[2], EndermanHeadpos[1] + EndermanHeadspace[1], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[3], EndermanHeadpos[1] + EndermanHeadspace[1], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[4], EndermanHeadpos[1] + EndermanHeadspace[1], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[5], EndermanHeadpos[1] + EndermanHeadspace[1], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[6], EndermanHeadpos[1] + EndermanHeadspace[1], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);

	if (EndermanBlinkEyes > -1)
		EndermanBlinkEyes += 5;

	if (EndermanBlinkEyes > 1500)
	{
		DrawRectangle(EndermanHeadpos[0], EndermanHeadpos[1] + EndermanHeadspace[2], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
		DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[0], EndermanHeadpos[1] + EndermanHeadspace[2], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
		DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[1], EndermanHeadpos[1] + EndermanHeadspace[2], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
		DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[2], EndermanHeadpos[1] + EndermanHeadspace[2], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
		DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[3], EndermanHeadpos[1] + EndermanHeadspace[2], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
		DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[4], EndermanHeadpos[1] + EndermanHeadspace[2], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
		DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[5], EndermanHeadpos[1] + EndermanHeadspace[2], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
		DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[6], EndermanHeadpos[1] + EndermanHeadspace[2], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);

		if (EndermanBlinkEyesTimer > -1)
			EndermanBlinkEyesTimer += 1;

		if (EndermanBlinkEyesTimer > 30)
		{
			EndermanBlinkEyesTimer = 0;
			EndermanBlinkEyes = 0;
		}
	}
	else
	{
		DrawRectangle(EndermanHeadpos[0], EndermanHeadpos[1] + EndermanHeadspace[2], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorEyes1);
		DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[0], EndermanHeadpos[1] + EndermanHeadspace[2], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorEyes2);
		DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[1], EndermanHeadpos[1] + EndermanHeadspace[2], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorEyes1);
		DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[2], EndermanHeadpos[1] + EndermanHeadspace[2], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
		DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[3], EndermanHeadpos[1] + EndermanHeadspace[2], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
		DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[4], EndermanHeadpos[1] + EndermanHeadspace[2], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorEyes1);
		DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[5], EndermanHeadpos[1] + EndermanHeadspace[2], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorEyes2);
		DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[6], EndermanHeadpos[1] + EndermanHeadspace[2], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorEyes1);
	}

	
	DrawRectangle(EndermanHeadpos[0], EndermanHeadpos[1] + EndermanHeadspace[3], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[0], EndermanHeadpos[1] + EndermanHeadspace[3], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[1], EndermanHeadpos[1] + EndermanHeadspace[3], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[2], EndermanHeadpos[1] + EndermanHeadspace[3], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[3], EndermanHeadpos[1] + EndermanHeadspace[3], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[4], EndermanHeadpos[1] + EndermanHeadspace[3], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[5], EndermanHeadpos[1] + EndermanHeadspace[3], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[6], EndermanHeadpos[1] + EndermanHeadspace[3], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);


	DrawRectangle(EndermanHeadpos[0], EndermanHeadpos[1] + EndermanHeadspace[4], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[0], EndermanHeadpos[1] + EndermanHeadspace[4], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[1], EndermanHeadpos[1] + EndermanHeadspace[4], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[2], EndermanHeadpos[1] + EndermanHeadspace[4], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[3], EndermanHeadpos[1] + EndermanHeadspace[4], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[4], EndermanHeadpos[1] + EndermanHeadspace[4], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[5], EndermanHeadpos[1] + EndermanHeadspace[4], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[6], EndermanHeadpos[1] + EndermanHeadspace[4], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);

	DrawRectangle(EndermanHeadpos[0], EndermanHeadpos[1] + EndermanHeadspace[5], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[0], EndermanHeadpos[1] + EndermanHeadspace[5], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[1], EndermanHeadpos[1] + EndermanHeadspace[5], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[2], EndermanHeadpos[1] + EndermanHeadspace[5], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[3], EndermanHeadpos[1] + EndermanHeadspace[5], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[4], EndermanHeadpos[1] + EndermanHeadspace[5], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[5], EndermanHeadpos[1] + EndermanHeadspace[5], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[6], EndermanHeadpos[1] + EndermanHeadspace[5], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);

	DrawRectangle(EndermanHeadpos[0], EndermanHeadpos[1] + EndermanHeadspace[6], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[0], EndermanHeadpos[1] + EndermanHeadspace[6], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[1], EndermanHeadpos[1] + EndermanHeadspace[6], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[2], EndermanHeadpos[1] + EndermanHeadspace[6], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[3], EndermanHeadpos[1] + EndermanHeadspace[6], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[4], EndermanHeadpos[1] + EndermanHeadspace[6], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[5], EndermanHeadpos[1] + EndermanHeadspace[6], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins1);
	DrawRectangle(EndermanHeadpos[0] + EndermanHeadspace[6], EndermanHeadpos[1] + EndermanHeadspace[6], EndermanHeadsize[0], EndermanHeadsize[1], EndermanColorSkins2);
}

void DRAW_HEAD_PIXEL_LOGO()
{
	if (DrawHeadPixelLogo == 0)
	{

	}
	else if (DrawHeadPixelLogo == 1)
	{
		DrawSteveHead();
	}
	else if (DrawHeadPixelLogo == 2)
	{
		DrawAlexHead();
	}
	else if (DrawHeadPixelLogo == 3)
	{
		DrawEndermanHead();
	}
}

#pragma endregion