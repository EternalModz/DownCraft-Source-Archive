#pragma once

namespace SubMenu
{
	void MainMenu()
	{
		submmenuMax = 8;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddOption(L"Host Options");
		AddOption(L"Non Host Options");
		AddOption(L"Vision Options");
		AddOption(L"Name Changer");
		AddOption(L"Mini-Game Options");
		AddOption(L"Teleport Options");
		AddOption(L"Settings Menu");
		AddOption(L"Credits Menu");
	}

	void HostMenu()
	{
		submmenuMax = 1;
		AddHud(submmenuMax);
		AddTitle(L"Host Options");
		AddBoolOption(L"God Mode", !GodMode);
		AddOption(L"Next Page");
	}
}