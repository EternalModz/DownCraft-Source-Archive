#pragma once

namespace Options
{
	void Bedrock_UI(bool toggle)
	{
		if (toggle)
		{
			*(int*)0x31E7878C = 0x3F900000; *(int*)0x31E78798 = 0x3F900000; *(int*)0x31E7879C = 0x42790000; *(int*)0x31E787A0 = 0x44138000; //Creative Btn
			*(int*)0x31E7865C = 0x3F900000; *(int*)0x31E78668 = 0x3F900000; *(int*)0x31E7866C = 0x42790000; *(int*)0x31E78670 = 0x44208000; //Inventory Btn
			*(int*)0x31E788BC = 0x3F900000; *(int*)0x31E788C8 = 0x3F900000; *(int*)0x31E788CC = 0x448B0000; *(int*)0x31E788D0 = 0x44228000; //Mine Btn
			*(int*)0x0090FB6C = 0x40820008; //Inventory down
		}
		else
		{
			*(int*)0x31E7878C = 0x3F900000; *(int*)0x31E78798 = 0x3F900000; *(int*)0x31E7879C = 0x52790000; *(int*)0x31E787A0 = 0x44138000; //Creative Btn
			*(int*)0x31E7865C = 0x3F900000; *(int*)0x31E78668 = 0x3F900000; *(int*)0x31E7866C = 0x52790000; *(int*)0x31E78670 = 0x44208000; //Inventory Btn
			*(int*)0x31E788BC = 0x3F900000; *(int*)0x31E788C8 = 0x3F900000; *(int*)0x31E788CC = 0x548B0000; *(int*)0x31E788D0 = 0x44228000; //Mine Btn
			*(int*)0x0090FB6C = 0x40820008; //Inventory down
		}
	}

	char* getName()
	{
		if (*(int*)0x3000ABE4 == 0x00000000)
			return (char*) NyTekCFW::ReadString(0x3000ABA4);
		else
			return (char*)NyTekCFW::ReadString(0x3000AD34);
	}

	void ShowTitle()
	{
		if (ToggleTitle)
		{
			DrawTextWithRectangle(L"DownCraft SPRX", 20, 13, MC_Color::BlackTheme, MC_Color::White, true, true);
		}
	}

	void ShowPosition()
	{
		if (TogglePosition)
		{
			int position[3] = { mc->theMinecraft->cMultiplayerLocalPlayer->LocationX, mc->theMinecraft->cMultiplayerLocalPlayer->LocationY, mc->theMinecraft->cMultiplayerLocalPlayer->LocationZ };
			DrawsnprintfText("Position : (%i, %i, %i)", position, 0, 56, true, true);
		}
	}
}