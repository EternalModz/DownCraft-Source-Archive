#pragma once

namespace UI
{
	namespace Settings
	{
		bool Style = false;
		bool Checkbox = false;
		bool CheckboxV2 = true;
		bool Rainbow = false;
		char* ThemeColors = "DEFAULT";
		int MenuSize = 0;
		int PosMenuX = 0;
		int PosMenuY = 0;
		char* DebugText = "Debug Text! 1";
		bool ShowNotif = true;
		bool ShowPosition = false;
		bool ShowPING = false;
		bool ShowChunks = false;
		bool ShowResolution = false;
		bool ShowInfosBar = false;
		bool GradientRGB = false;
		bool ShowCPURSX = false;
		bool Scrollbar = true;
		bool BGOpacity = false;
		bool CustomImage = false;
		bool CustomImageGif = false;
	}

	namespace Color
	{
		int WHITE[3] = { 255, 255, 255 };
		int BLACK[4] = { 25, 25, 25, 50 };
		int BLACK2[4] = { 10, 10, 10, 50 };
		int PINK[3] = { 255, 137, 214 };
		int RED[4] = { 255, 16, 63, 20 };
		int ORANGE[3] = { 255, 143, 16 };
		int CYAN[3] = { 16, 233, 255 };
		int GREEN[3] = { 33, 192, 74 };
		int LIME[3] = { 0, 255, 15 };
		int BLUE[3] = { 0, 147, 255 };
		int PURPLE[3] = { 128, 0, 128 };
		int YELLOW[3] = { 255, 255, 0 };
		int TEST[4] = { 36, 36, 36, 0.8 };
		int RAINBOW[3] = { 255, 0, 0 };
		int RainbowRED = 135;
		int RainbowGREEN = 65;
		int RainbowBLUE = 54;
		int RainbowRED1 = 255;
		int RainbowGREEN1 = 10;
		int RainbowBLUE1 = 130;
	};
};