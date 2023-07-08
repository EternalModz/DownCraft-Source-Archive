#pragma once

void RenderSubMenu()
{
	if (Opened)
	{
		switch (CurrentMenu)
		{
		case(MainMenu):
			MaxSubOptions = 5;
			Menu::AddHuds();
			Menu::AddTitle(L"DownCraft Utility Menu");
			Menu::AddSubOption(L"Main Menu");
			Menu::AddSubOption(L"Mics Menu");
			Menu::AddSubOption(L"Credits Menu");
			Menu::AddBoolOption(L"Toggle Title", ToggleTitle);
			Menu::AddBoolOption(L"Toggle Position", TogglePosition);
			switch (getOption()) {
			case(0): ToggleTitle = !ToggleTitle; break;
			case(1): TogglePosition = !TogglePosition; break;
			}
			break;
		}
	}
}