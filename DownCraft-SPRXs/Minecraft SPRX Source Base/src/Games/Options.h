#pragma once

namespace Offsets
{
	void GOD_MODE(bool toggle) { if (toggle) { *(int*)0x4B2020 = 0xFC80F890; } else { *(int*)0x4B2020 = 0xFC20F890; } }
}

namespace Options
{
	void ShowPosition()
	{
		if (TogglePosition)
		{
			int BLACK[3] = { 32, 32, 32 };

			char option[0x100];
			wchar_t woption[0x100];
			_sys_memset(option, 0, 0x100);
			_sys_memset(woption, 0, 0x200);
			_sys_snprintf(option, 0x100, "Position: %i, %i, %i", (int)mc->theMinecraft->cMultiplayerLocalPlayer->posX - 1, (int)mc->theMinecraft->cMultiplayerLocalPlayer->posY + 1, (int)mc->theMinecraft->cMultiplayerLocalPlayer->posZ);
			StringToWideCharacter(woption, option, strlen(option));

			int Width = Font_width(woption);
			DrawRectangle(0, 45, Width, 11, BLACK);
			DrawText(woption, 0, 47, color(MC_Color::White));
		}
	}

	void ShowGametime()
	{
		if (ToggleGametime)
		{
			int BLACK[3] = { 32, 32, 32 };
			int milliseconds, seconds, minutes, hours;

			int pos[2] = { 0, 36 };
			milliseconds = mc->gameTime;
			seconds = (milliseconds / 60);
			minutes = seconds / 60;
			hours = minutes / 60;

			char option4[0x100];
			wchar_t woption4[0x100];
			_sys_memset(option4, 0, 0x100);
			_sys_memset(woption4, 0, 0x200);
			_sys_snprintf(option4, 0x100, "Gametime: %ih:%imin:%isec", int(hours % 24), int(minutes % 60), int(seconds % 60));
			StringToWideCharacter(woption4, option4, strlen(option4));

			int width = Font_width(woption4);
			DrawRectangle(0, 34, width, 11, BLACK);
			DrawText(woption4, pos[0], pos[1], color(MC_Color::White));
		}
	}

	void ShowKeystrokes()
	{
		if (ToggleKeystrokes)
		{
			
		}
	}
}