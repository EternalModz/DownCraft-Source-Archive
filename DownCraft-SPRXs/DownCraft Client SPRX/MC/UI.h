#pragma once

namespace UI
{
	namespace Settings
	{
		int Style = 0;
		char* ThemeColors = "DEFAULT";
		int MenuSize = 0;
		int PosMenuX = 0;
		int PosMenuY = 0;
		char* DebugText = "Debug Text! 1";
		bool ShowNotif = true;
		bool ShowPosition = false;
		bool ShowPING = false;
		bool ShowInfosBar = true;
		bool ShowCustomImage = false;
		bool HeaderTitle = false;
		bool NewCheckbox = false;
		bool NewScrollbar = false;
		bool ToggleOnOff = false;
	}

	namespace Color
	{
		int WHITE[3] = { 255, 255, 255 };
		int BLACK[3] = { 15, 15, 15 };
		int PINK[3] = { 255, 137, 214 };
		int RED[4] = { 255, 16, 63, 20 };
		int ORANGE[3] = { 255, 143, 16 };
		int CYAN[3] = { 16, 233, 255 };
		int GREEN[3] = { 33, 192, 74 };
		int LIME[3] = { 0, 255, 15 };
		int BLUE[3] = { 0, 147, 255 };
		int PURPLE[3] = { 128, 0, 128 };
		int YELLOW[3] = { 255, 255, 0 };
		int TEST[4] = { 36, 36, 36, 30 };
	};
};