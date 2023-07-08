#pragma once
using namespace std;

//All Addresses from Minecraft 1.84
//Only what i need for the SPRX ofc

#pragma once
//Variables
bool MainMenu;


#pragma region "Offsets"

enum Offsets
{
	InWorld = 0x3000CF6B,
	NAMECHANGER = 0x3000ABE4,
	LockControl = 0x0155847C,

	HUD_Screen = 0x00AEF9F0,
	HUD_DrawText = 0x30FB2331,
	HUD_Color_Text = 0x31E72950,
	HUD_Controller = 0x31E7239C,
	HUD_Shader_Shadow = 0x31E7281C,
	HUD = 0x31E71F1C,
	HUD_Text_Position = 0x31E7290C,
	HUD_BG_Colors = 0x31E71F60,
	HUD_Shader_White = 0x31E7272C,
	HUD_Fix_Text = 0x00887E3B,

	ScrollBar_Shader = 0x31E74F0C,
	Scrollbar_Colors = 0x31E74F50,
	Scrollbar_Toggle = 0x31E74F20
};

#pragma endregion

//Detect if the localplayer is in a world or not yet

bool IsInWorld()
{
	return !(*(char*)InWorld != 0);
}


#pragma region "Functions for the Menu"

//Functions for draw (Dont touch this !!)
void DrawHud(float width, float height, float x, float y, float R, float G, float B, float A)
{
	PS3Lib::WriteSingleFloat(0x31E71F1C, width);
	PS3Lib::WriteSingleFloat(0x31E71F28, height);
	PS3Lib::WriteSingleFloat(0x31E71F2C, x);
	PS3Lib::WriteSingleFloat(0x31E71F30, y);
	PS3Lib::WriteSingleFloat(0x31E71F60, R);
	PS3Lib::WriteSingleFloat(0x31E71F64, G);
	PS3Lib::WriteSingleFloat(0x31E71F68, B);
	PS3Lib::WriteSingleFloat(0x31E71F6C, A);
}

void DrawText(float width, float height, float x, float y, float R, float G, float B, float A)
{
	PS3Lib::WriteSingleFloat(0x31E7290C, width);
	PS3Lib::WriteSingleFloat(0x31E72918, height);
	PS3Lib::WriteSingleFloat(0x31E7291C, x);
	PS3Lib::WriteSingleFloat(0x31E72920, y);
	PS3Lib::WriteSingleFloat(0x31E72950, R);
	PS3Lib::WriteSingleFloat(0x31E72954, G);
	PS3Lib::WriteSingleFloat(0x31E72958, B);
	PS3Lib::WriteSingleFloat(0x31E7295C, A);
}


#pragma endregion


#pragma region "Before Start SPRX"

void BEFORE_START_SPRX()
{
	sleep(30000); //<== WAIT 30 seconds for load Minecraft cuz of black screen

	strcpy((char*)0x320E8410, "Alone - DownCraft SPRX Demo V2.2");
	strcpy((char*)0x320E89E0, "Multiplayer - DownCraft SPRX Demo V2.2");
	//Show actualy game states = 0x017003D8

	char ENABLESPLITHUD[] = { 0x40 };
	write_process(HUD_Screen, &ENABLESPLITHUD, sizeof(ENABLESPLITHUD));

	char FIXTEXT[] = { 0x00 };
	write_process(HUD_Fix_Text, &FIXTEXT, sizeof(FIXTEXT));

	char SCROLLBARCOLOR[] = { 0x0F, 0x80, 0x00, 0x00, 0x0F, 0x80, 0x00, 0x00, 0x0F, 0x80, 0x00, 0x00, 0x3F, 0x80 };
	write_process(Scrollbar_Colors, &SCROLLBARCOLOR, sizeof(SCROLLBARCOLOR));

	char COLORS_BG[] = { 0x0F, 0x80, 0x00, 0x00, 0x0F, 0x80, 0x00, 0x00, 0x0F, 0x80, 0x00, 0x00, 0x3F, 0xC0, 0x00 };
	write_process(HUD_BG_Colors, &COLORS_BG, sizeof(COLORS_BG));

	char COLORS_TEXTS[] = { 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x4F, 0x80, 0x00, 0x00 };
	write_process(HUD_Color_Text, &COLORS_TEXTS, sizeof(COLORS_TEXTS));
}

#pragma endregion


void OpenMenu()
{
	DrawHud(4.00000000, -4.500000000, -384.000000, 128.000000, 1.26218e-29, 1.26218e-29, 1.26218e-29, 1.75000000);
	DrawText(1.00000000, 1.00000000, -194.000000, -224.000000, 4.29497e+09, 4.29497e+09, 4.29497e+09, 1.00000000);

	char ON[] = { 0x00 };
	write_process(LockControl, &ON, sizeof(ON));

	MainMenu = true;
}




