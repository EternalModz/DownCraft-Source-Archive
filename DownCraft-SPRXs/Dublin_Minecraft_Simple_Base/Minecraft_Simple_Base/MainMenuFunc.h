#pragma once
#pragma region Includes
#include "var.h"
#include "Addresses.h"
//#include "Huds.h"
//#include "Colors.h"
#include "PS3.h"
//#include "SubMenus.h"
//#include "struct.h"
//#include "CallSubMenus.h"
#include "PS3Pad.h"
#include "Enums.h"
#pragma endregion

void gameRender_Stub(uint32_t r3, uint32_t r4) {
	__nop(); __nop(); __nop(); __nop(); __nop();
}

#pragma region Menu Declare
int CurrentMenu;
int CurrentOpt;
int MaxOptions;
int MinOptions;
Self self;
float menuXPos = 150;
float menuYPos = 20;
float menuWidth = 100;
float menuHeight = 8;

#pragma endregion

#pragma region Menu Functions

using Function = void(*)();
using KeyboardHandler = int(*)(uint64_t param, uint64_t status, uint64_t a3);





#pragma endregion



namespace mcBtnOfs
{
	enum MCbuttonsOffsets
	{
		_L2 = 0xF0,
		_R2 = 0xF1,
		R1 = 0xB3,
		R2 = 0xB1,
		R3 = 0xB2,
		L1 = 0xB3,
		L2 = 0xB1,
		L3 = 0xB2,
		DpadUp = 0xB2,
		DpadDown = 0xB2,
		DpadLeft = 0xB2,
		DpadRight = 0xB2,
		Cross = 0xB3,
		Square = 0xB3,
		Circle = 0xB3,
		Triangle = 0xB3,
		Select = 0xB3,
		Start = 0xB3
	};
}
namespace mcBtnBytes
{
	enum MCbuttonsBytes
	{
		_R2 = 0,
		_L2 = 0,
		R2L2 = 0xC0,
		R1 = 0x40,
		R2 = 0x40,
		R3 = 0x01,
		L1 = 0x80,
		L2 = 0x80,
		L3 = 0x02,
		DpadUp = 0x04,
		DpadDown = 0x08,
		DpadLeft = 0x10,
		DpadRight = 0x20,
		Cross = 0x01,
		Square = 0x04,
		Circle = 0x02,
		Triangle = 0x08,
		Select = 0x20,
		Start = 0x10
	};
}



bool buttonPressed(int ofs, int button)
{
	if (*(char*)(btnMonOfs + (mcBtnOfs::MCbuttonsOffsets(ofs))) == mcBtnBytes::MCbuttonsBytes(button))
		return true;
	else
		return false;
}





void DrawMenu() {
	//Menu::AddMenuTitle(L"Minecraft Menu Base"); //Menu Title
	// UI_DrawText(L"Stratospheric Returns Sprx", 150, 10, Red, 0, 1);
	//drawMenuBackground(150, 20, 100, 10 + (10 * MaxOption), Transparent, Transparent);//Menu Scroll
	drawTitleRectBorder(150, 20, 100, -90 + (10 * MinOptions + 90), Gray, Black);//Menu Background
	drawTitleRectBorder(menuXPos, menuYPos, menuWidth, menuHeight, White, Black);//Title Border
	//UI_DrawShaders(150, 10, 100, 120, White);
}



void SelectFunction(Function fn) {
	if (buttonPressed(mcBtnOfs::Cross, mcBtnBytes::Cross))
	{
		CurrentOpt;
		fn();
		const wchar_t * options;
		//Menu::Selector(options, fn);
	//	printf("Press 'X'");
		sleep(50);
	}
}

void RenderMenu() {
	if (self.isMenuOpen){
		//Menu::UI_DrawMenuBackground();
		if (buttonPressed(mcBtnOfs::DpadUp, mcBtnBytes::DpadUp))
		{
			CurrentOpt = CurrentOpt - 1;
			MinOptions = 1;
			sleep(50);
		}

		if (buttonPressed(mcBtnOfs::DpadDown, mcBtnBytes::DpadDown))
		{
			CurrentOpt = CurrentOpt + 1;
			sleep(50);
		}
		if (CurrentOpt > MaxOptions)
		{
			CurrentOpt = 1;
		}

		if (CurrentOpt > MaxOptions)
		{
			CurrentOpt = 0;
		}

		if (CurrentOpt < 0)
		{
			CurrentOpt = MaxOptions;
		}

		if (buttonPressed(mcBtnOfs::Cross, mcBtnBytes::Cross))
		{
			CurrentOpt;
			//func();
			Function fn;
			const wchar_t * options;
			SelectFunction(fn);
			//Menu::Selector(options, fn);
			//printf("Press 'X'");
			sleep(50);
		}

		if (buttonPressed(mcBtnOfs::Circle, mcBtnBytes::Circle))
		{
			CurrentOpt = 1;
		//	MainMenuFuncList::MainMenuFunc();
			//printf("Press 'Circle'");
			sleep(50);
		}

		if (buttonPressed(mcBtnOfs::Circle, mcBtnBytes::Circle) && CurrentMenu == Main_Menu)
			self.isMenuOpen = false;

		if (buttonPressed(mcBtnOfs::L1, mcBtnBytes::L1) && buttonPressed(mcBtnOfs::R1, mcBtnBytes::R1))
		{
			DrawMenu();
			CurrentOpt = 1;
		}

		MaxOptions = MinOptions;
	}
}