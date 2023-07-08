#pragma once
#pragma region Includes
//#include "struct.h"
#include "Huds.h"
//#include "MainMenuFunc.h"
#include "Addresses.h"
//#include "Colors.h"
#include "CallSubMenus.h"
//#include "Mods.h"
#include "Enums.h"
#pragma endregion

#pragma region Definitions
int CurrentMenu;
int CurrentOpt;
int MaxOptions;
int MinOptions;
Self self;

#pragma endregion

#pragma region Menu Functions
void AddMenuTitle(const wchar_t * menuTitle)
{
	// drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(c2wc(text)), x, y, Color, 0, 1);
	UI_DrawText(menuTitle, 150, 10, White, 0, true);
	//AddMenuMainTitle(menuTitle, 150, 10, White);
	//drawRect(bgX, 10, 100, 120, bgColor);//background
}
void AddInstructionText(const wchar_t * InstructionText)
{
	// drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(c2wc(text)), x, y, Color, 0, 1);
	UI_DrawText(InstructionText, 100, 214, White, 0, true);
	//AddMenuMainTitle(menuTitle, 150, 10, White);
	//drawRect(bgX, 10, 100, 120, bgColor);//background
}
void AddTitle(const wchar_t * headertitle) {
	UI_DrawText(headertitle, 150, 20, White, 0, true);
}


void AddOptionText(const wchar_t *optionText)
{

	//							 Y coord for Text. Under Submenu Title
	UI_DrawText(optionText, 150, 10 + (10 * MinOptions + 10), White, 0, true);
	// drawTitleRectBorder(150, 10 + (10 * MinOptions + 10), 100, 8, Red, Black);//Title Border
	MinOptions += 1; // Draw the shader and option un50rneath, Space between options
	//The last option + 1 space down, draw shader.
}




void AddOption(const wchar_t * opt, void(*function)()) {
	//          opt, 150f = x coord, 30 = y coord, maxoption == current option ? Green And White text
	UI_DrawText(opt, 150, 10 + (10 * MinOptions + 10), (MinOptions == CurrentOpt) ? Green : White, 0, true);
	// UI_DrawText(opt, 150, -70 + (10 * MaxOptions), (MaxOptions == CurrentOpt) ? Green : White, 0, true);
	MinOptions += 1; //Space between each Option and Background Shader of menu
}

template<typename arg_t>
void AddOption(const wchar_t * opt, void(*function)(arg_t arg), arg_t arg) {
	UI_DrawText(opt, 150, 10 + (10 * MinOptions + 10), (MaxOptions == CurrentOpt) ? Green : White, 0, true);
	MaxOptions += 1;
}
void AddSubOption(const wchar_t * opt, SubMenus subMenu){
	UI_DrawText(opt, 150, 10 + (10 * MinOptions + 10), (MinOptions == CurrentOpt) ? Green : White, 0, true);
	CurrentMenu = subMenu;
	MinOptions += 1;
}

void AddBoolOption(const wchar_t * opt, void(*function)(), bool boolOption) {
	//          opt, 150f = x coord, 30 = y coord, maxoption == current option ? Green And White text
	UI_DrawText(opt, 150, 10 + (10 * MinOptions + 10), (MinOptions == CurrentOpt) ? Green : White, 0, true);
	int* insideColor = boolOption ? Green : Red;
	int* outsideColor = Black;
	drawTitleRectBorder(245, 12 + (10 * MinOptions + 10), 4, 4, insideColor, outsideColor);
	MinOptions += 1; //Space between each Option and Background Shader of menu
}

void UI_DrawMenuBackground(){
	AddMenuTitle(L"Stratospheric Sprx"); //Menu Title
	// UI_DrawText(L"Stratospheric Returns Sprx", 150, 10, Red, 0, 1);
	//drawMenuBackground(150, 20, 100, 10 + (10 * MaxOption), Transparent, Transparent);//Menu Scroll
	drawTitleRectBorder(150, 20, 100, -90 + (10 * MinOptions + 90), Gray, Black);//Menu Background
	drawTitleRectBorder(150, 20, 100, 8, White, Black);//Title Border
	//UI_DrawShaders(150, 10, 100, 120, White);
}


#pragma endregion


void MainMenu() {
	MinOptions = 1; //The max Amount of options that can show in the menu // 0 it is counted too
	MaxOptions = 10;
	CurrentMenu = Main_Menu;
	UI_DrawRightText(L"Main Menu", 150, 20, Black);
	AddOption(L"Host Options", MainMenuFuncList::HostMenuFunc);
	AddOption(L"Self Options", MainMenuFuncList::SelfOptionsFunc);
	AddOption(L"Non-Host Options", MainMenuFuncList::NonHostOptionsFunc);
	AddOption(L"World Options", MainMenuFuncList::WorldOptionsFunc);
	AddOption(L"Lobby Options", MainMenuFuncList::LobbyOptionsFunc);
	AddOption(L"Texture Pack Creator", MainMenuFuncList::TexturePackOptionsFunc);
	AddOption(L"Model Changer", MainMenuFuncList::ModelChangerOptionsFunc);
	AddOption(L"Online Players", MainMenuFuncList::PlayersOptionsFunc);
	AddOption(L"Teleport Options", MainMenuFuncList::TeleportOptionsFunc);
	AddOption(L"Menu Settings", MainMenuFuncList::MenuSettingsFunc);
	AddOption(L"Menu Credits", MainMenuFuncList::MenuCreditsFunc);
}

void HostMenu() {
	CurrentMenu = Host_Options;
	UI_DrawRightText(L"Host Options", 150, 20, Black);
	AddBoolOption(L"BoolOption 1", HostMenuFuncList::GodModeFunc, !God_Mode);
	AddBoolOption(L"BoolOption 2", HostMenuFuncList::CanFlyFunc, !CanFly);
	AddBoolOption(L"BoolOption 3", HostMenuFuncList::NightVisionFunc, !NightVision);
}

void SelfOptions() {
	CurrentMenu = Self_Options;
	UI_DrawRightText(L"Self Options Options", 150, 20, Black);
	AddBoolOption(L"BoolOption 1", SelfOptionsFuncList::GodModeFunc, !God_Mode);
	AddBoolOption(L"BoolOption 2", SelfOptionsFuncList::CanFlyFunc, !CanFly);
	AddBoolOption(L"BoolOption 3", SelfOptionsFuncList::NightVisionFunc, !NightVision);
}

void NonHostOptions() {

}

void WorldOptions() {

}

void LobbyOptions() {

}

void TexturePackOptions() {

}

void ModelChangerOptions() {

}

void PlayersOptions() {

}

void TeleportOptions() {

}

void MenuSettings() {

}

void MenuCredits() {

}

