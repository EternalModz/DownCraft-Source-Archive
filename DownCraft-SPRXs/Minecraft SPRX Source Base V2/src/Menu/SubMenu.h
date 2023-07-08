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
			Menu::AddTitle(titleSPRX);
			Menu::AddSubOption(L"Main Options");
			Menu::AddSubOption(L"Teleport Options");
			Menu::AddSubOption(L"Settings Menu");
			Menu::AddSubOption(L"Credits Menu");
			switch (getOption()) {
			case(0): openSubmenu(eMenus::MainOptions); break;
			case(1): openSubmenu(eMenus::TeleportMenu); break;
			case(2): openSubmenu(eMenus::SettingsMenu); break;
			case(3): openSubmenu(eMenus::CreditsMenu); break;
			}
			break;

		case(MainOptions):
			MaxSubOptions = 4;
			Menu::AddHuds(MaxSubOptions);
			Menu::AddTitle(L"Main Options");
			Menu::AddBoolOption(L"God Mode", GodMode);
			Menu::AddBoolOption(L"Super Speed", SuperSpeed);
			Menu::AddOption(L"Sub Option 3");
			Menu::AddOption(L"Sub Option 4");
			switch (getOption()) {
			case(0): GodMode = !GodMode; break;
			case(1): SuperSpeed = !SuperSpeed; break;
			}
			break;

		case(TeleportMenu):
			MaxSubOptions = 5;
			Menu::AddHuds(MaxSubOptions);
			Menu::AddTitle(L"Teleport Menu");
			Menu::AddIntOption(L"CoordX", 0, -430, 450, CoordX);
			Menu::AddIntOption(L"CoordY", 1, -999, 510, CoordY);
			Menu::AddIntOption(L"CoordZ", 2, -430, 450, CoordZ);
			Menu::AddOption(L"Save Current Coord");
			Menu::AddOption(L"Set Teleport");
			switch (getOption()) {
			case(3): Options::getTeleport(); break;
			case(4): Options::setTeleport(CoordX, CoordY, CoordZ); break;
			}
			break;

		case(SettingsMenu):
			MaxSubOptions = 6;
			Menu::AddHuds(MaxSubOptions);
			Menu::AddTitle(L"Settings Menu");
			Menu::AddSubOption(L"Color Menu");
			Menu::AddIntOption(L"Menu Lenght", 1, 0, 455, menuLenght);
			Menu::AddIntOption(L"Menu Border", 2, 0, 5, MenuBorderSize);
			Menu::AddIntOption(L"Menu X", 3, 0, 500, MenuX);
			Menu::AddIntOption(L"Menu Y", 4, 0, 500, MenuY);
			Menu::AddBoolOption(L"Menu Gradient", GradientMenu);
			switch (getOption()) {
			case(0): openSubmenu(eMenus::ColorMenu); break;
			case(5): GradientMenu = !GradientMenu; break;
			}
			break;

		case(ColorMenu):
			MaxSubOptions = 9;
			Menu::AddHuds(MaxSubOptions);
			Menu::AddTitle(L"Color Menu");
			Menu::AddIntOption(L"Menu Color R", 0, 0, 255, MenuR);
			Menu::AddIntOption(L"Menu Color G", 1, 0, 255, MenuG);
			Menu::AddIntOption(L"Menu Color B", 2, 0, 255, MenuB);
			Menu::AddIntOption(L"Gradient1 Color R", 3, 0, 255, MenuGradient1R);
			Menu::AddIntOption(L"Gradient1 Color G", 4, 0, 255, MenuGradient1G);
			Menu::AddIntOption(L"Gradient1 Color B", 5, 0, 255, MenuGradient1B);
			Menu::AddIntOption(L"Gradient2 Color R", 6, 0, 255, MenuGradient2R);
			Menu::AddIntOption(L"Gradient2 Color G", 7, 0, 255, MenuGradient2G);
			Menu::AddIntOption(L"Gradient2 Color B", 8, 0, 255, MenuGradient2B);
			break;

		case(CreditsMenu):
			MaxSubOptions = 1;
			Menu::AddHuds(MaxSubOptions);
			Menu::AddTitle(L"Credits Menu");
			Menu::AddOption(L"Misaki (creator)");
			break;
		}
	}
}