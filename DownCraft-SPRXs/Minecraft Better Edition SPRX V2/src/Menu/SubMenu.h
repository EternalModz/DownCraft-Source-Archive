#pragma once

void RenderSubMenu()
{
	if (Opened)
	{
		switch (CurrentMenu)
		{
		case(MainMenu):
			MaxSubOptions = 6;
			Menu::AddHuds(MaxSubOptions);
			Menu::AddTitle(titleSPRX);
			Menu::Description(L"Main Menu");
			Menu::AddSubOption(L"Main Options");
			Menu::AddSubOption(L"Mics Menu");
			Menu::AddSubOption(L"Teleport Menu");
			Menu::AddSubOption(L"Name Menu");
			Menu::AddSubOption(L"Settings Menu");
			Menu::AddSubOption(L"Credits Menu");
			switch (getOption()) {
			case(0): openSubmenu(eMenus::MainOptions); break;
			case(1): openSubmenu(eMenus::MicsMenu); break;
			case(2): openSubmenu(eMenus::TeleportMenu); break;
			case(3): openSubmenu(eMenus::NameMenu); break;
			case(4): openSubmenu(eMenus::SettingsMenu); break;
			case(5): openSubmenu(eMenus::CreditsMenu); break;
			}
			break;

		case(MainOptions):
			MaxSubOptions = 10;
			Menu::AddHuds(MaxSubOptions);
			Menu::AddTitle(titleSPRX);
			Menu::Description(L"Main Options");
			Menu::AddBoolOption(L"Show Title", !ToggleTitleSPRX);
			Menu::AddBoolOption(L"Show PSN", !TogglePSN);
			Menu::AddBoolOption(L"Show Gametime", !ToggleGametime);
			Menu::AddBoolOption(L"Show Position", !TogglePosition);
			Menu::AddBoolOption(L"Show Chunks", !ToggleChunks);
			Menu::AddBoolOption(L"Show Resolution", !ToggleResolution);
			Menu::AddBoolOption(L"Show Ping", !TogglePing);
			Menu::AddBoolOption(L"Show CPU/RSX", !ToggleCPURSX);
			Menu::AddBoolOption(L"Show Debug Player", !ToggleDebugPlayer);
			Menu::AddBoolOption(L"Show Keystrokes", !ToggleKeystrokes);
			switch (getOption()) {
			case(0): ToggleTitleSPRX = !ToggleTitleSPRX; break;
			case(1): TogglePSN = !TogglePSN; break;
			case(2): ToggleGametime = !ToggleGametime; break;
			case(3): TogglePosition = !TogglePosition; break;
			case(4): ToggleChunks = !ToggleChunks; break;
			case(5): ToggleResolution = !ToggleResolution; break;
			case(6): TogglePing = !TogglePing; break;
			case(7): ToggleCPURSX = !ToggleCPURSX; break;
			case(8): ToggleDebugPlayer = !ToggleDebugPlayer; break;
			case(9): ToggleKeystrokes = !ToggleKeystrokes; break;
			}
			break;

		case(MicsMenu):
			MaxSubOptions = 1;
			Menu::AddHuds(MaxSubOptions);
			Menu::AddTitle(titleSPRX);
			Menu::Description(L"Mics Menu");
			Menu::AddOption(L"No Clip");
			switch (getOption()) {
			case(0): mc->theMinecraft->cMultiplayerLocalPlayer->noClip = true; break;
			}
			break;

		case(TeleportMenu):
			MaxSubOptions = 5;
			Menu::AddHuds(MaxSubOptions);
			Menu::AddTitle(titleSPRX);
			Menu::Description(L"Teleport Options");
			Menu::AddIntOption(L"CoordX", 0, -430, 450, CoordX);
			Menu::AddIntOption(L"CoordY", 1, -999, 510, CoordY);
			Menu::AddIntOption(L"CoordZ", 2, -430, 450, CoordZ);
			Menu::AddOption(L"Save Current Coordinates");
			Menu::AddOption(L"Set Teleport");
			switch (getOption()) {
			case(3): Options::getTeleport(); logs::debugMessage(L"Coordinates has been saved.", MC_Color::Blue); break;
			case(4): Options::setTeleport(CoordX, CoordY, CoordZ); logs::debugMessage(L"The player has been teleported.", MC_Color::Green); break;
			}
			break;

		case(NameMenu):
			MaxSubOptions = 1;
			Menu::AddHuds(MaxSubOptions);
			Menu::AddTitle(titleSPRX);
			Menu::Description(L"Name Menu");
			Menu::AddOption(L"Enter a text");
			switch (getOption()) {
			case(0): ShowKeyboard = true; Opened = false; break;
			}
			break;

		case(SettingsMenu):
			MaxSubOptions = 2;
			Menu::AddHuds(MaxSubOptions);
			Menu::AddTitle(titleSPRX);
			Menu::Description(L"Settings Menu");
			Menu::AddSubOption(L"Colors Menu");
			Menu::AddSubOption(L"Editable Value");
			switch (getOption()) {
			case(0): openSubmenu(eMenus::ColorsMenu); break;
			case(1): openSubmenu(eMenus::EditableValMenu); break;
			}
			break;

		case(ColorsMenu):
			MaxSubOptions = 3;
			Menu::AddHuds(MaxSubOptions);
			Menu::AddTitle(titleSPRX);
			Menu::Description(L"Colors Menu");
			Menu::AddIntOption(L"Red  ", 0, 0, 255, MenuR);
			Menu::AddIntOption(L"Green", 1, 0, 255, MenuG);
			Menu::AddIntOption(L"Blue ", 2, 0, 255, MenuB);
			break;

		case(EditableValMenu):
			MaxSubOptions = 4;
			Menu::AddHuds(MaxSubOptions);
			Menu::AddTitle(titleSPRX);
			Menu::Description(L"Settings Menu");
			Menu::AddIntOption(L"MenuX", 0, -550, 600, MenuX);
			Menu::AddIntOption(L"MenuY", 1, -500, 600, MenuY);
			Menu::AddIntOption(L"KeystrokesX", 2, -50, 600, keystrokesBase_x);
			Menu::AddIntOption(L"KeystrokesY", 3, -300, 70, keystrokesBase_y);
			break;

		case(CreditsMenu):
			MaxSubOptions = 1;
			Menu::AddHuds(2);
			Menu::AddTitle(titleSPRX);
			Menu::Description(L"Credits Menu");
			Menu::AddOption(L"Misaki (Creator)");
			Menu::AddOption(L"YT: Misakiii");
			break;
		}
	}
}