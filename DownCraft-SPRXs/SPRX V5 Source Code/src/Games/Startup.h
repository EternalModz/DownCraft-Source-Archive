#pragma once

void LoadSPRX()
{
	InitializeSPRX = false;
	UsableMenu = true;
	logs::SendMessageDebug(L"Welcome to DownCraft SPRX", MC_TextColor::Red);
	logs::SendMessageDebug(L"Version V5", MC_TextColor::Aqua);
	logs::SendMessageDebug(L"Press L1 + DPAD UP for open the menu", MC_TextColor::LightPurple);
}

void Startup()
{
	if (InitializeSPRX)
	{
		*(int*)0x30927421 = 0x00000000; //TEXT INVENTORY
		*(int*)0x3092CD81 = 0x00000000; //TEXT CREATIVE
		*(int*)0x31E7786C = 0x3F80CCCC; //OPACITY FOR BANNER

		LoadSPRX();
	}
}