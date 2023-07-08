#pragma once

void RenderSubMenu()
{
	if (Opened)
	{
		switch (CurrentMenu)
		{
		case(MainMenu):
			MaxSubOptions = 4;
			Menu::AddHuds(MaxSubOptions);
			Menu::AddTitle(L"DownCraft SPRX");
			Menu::Description(L"Main Menu");
			Menu::AddSubOption(L"Better Options");
			Menu::AddSubOption(L"Mics Menu");
			Menu::AddSubOption(L"Settings Menu");
			Menu::AddSubOption(L"Credits Menu");
			switch (getOption()) {
			case(0): openSubmenu(eMenus::BetterMenu); break;
			case(1): openSubmenu(eMenus::MicsMenu); break;
			case(2): openSubmenu(eMenus::SettingsMenu); break;
			case(3): openSubmenu(eMenus::CreditsMenu); break;
			}
			break;

		case(BetterMenu):
			MaxSubOptions = 5;
			Menu::AddHuds(MaxSubOptions);
			Menu::AddTitle(L"DownCraft SPRX");
			Menu::Description(L"Better Options");
			Menu::AddBoolOption(L"Show Position", !TogglePosition);
			Menu::AddBoolOption(L"Show Gametime", !ToggleGametime);
			Menu::AddBoolOption(L"Show Ping", !TogglePing);
			Menu::AddBoolOption(L"Show Keystrokes", !ToggleKeystrokes);
			Menu::AddBoolOption(L"Show CPS", !ToggleCPS);
			switch (getOption()) {
			case(0): TogglePosition = !TogglePosition; break;
			case(1): ToggleGametime = !ToggleGametime; break;
			case(2): TogglePing = !TogglePing; break;
			case(3): ToggleKeystrokes = !ToggleKeystrokes; break;
			case(4): ToggleCPS = !ToggleCPS; break;
			}
			break;

		case(MicsMenu):
			MaxSubOptions = 3;
			Menu::AddHuds(MaxSubOptions);
			Menu::AddTitle(L"DownCraft SPRX");
			Menu::Description(L"Mics Menu");
			Menu::AddBoolOption(L"Show Title", !ToggleTitleSPRX);
			Menu::AddOption(L"Close Minecraft");
			Menu::AddIntOption(L"Valeur test", 2, 0, 100, MenuY);
			switch (getOption()) {
			case(0): ToggleTitleSPRX = !ToggleTitleSPRX; break;
			case(1): Offsets::CLOSE_MINECRAFT(); break;
			}
			break;

		case(SettingsMenu):
			MaxSubOptions = 2;
			Menu::AddHuds(MaxSubOptions);
			Menu::AddTitle(L"DownCraft SPRX");
			Menu::Description(L"Settings Menu");
			Menu::AddIntOption(L"MenuX", 0, -50, 250, MenuX);
			Menu::AddIntOption(L"MenuY", 1, -50, 250, MenuY);
			break;

		case(CreditsMenu):
			MaxSubOptions = 2;
			Menu::AddHuds(2);
			Menu::AddTitle(L"DownCraft SPRX");
			Menu::Description(L"Credits Menu");
			Menu::AddOption(L"Submenu 1");
			Menu::AddOption(L"Submenu 1");
			break;
		}
	}
}