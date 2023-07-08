#pragma once
#pragma region Includes
#include "Mods.h"
#include "SubMenus.h"
#pragma endregion

namespace MainMenuFuncList {
	void MainMenuFunc() { MainMenu(); }
	void HostMenuFunc() { HostMenu(); }
	void SelfOptionsFunc() { SelfOptions(); }
	void NonHostOptionsFunc() { NonHostOptions(); }
	void WorldOptionsFunc() { WorldOptions(); }
	void LobbyOptionsFunc() { LobbyOptions(); }
	void TexturePackOptionsFunc() { TexturePackOptions(); }
	void ModelChangerOptionsFunc() { ModelChangerOptions(); }
	void PlayersOptionsFunc() { PlayersOptions(); }
	void TeleportOptionsFunc() { TeleportOptions(); }
	void MenuSettingsFunc() { MenuSettings(); }
	void MenuCreditsFunc() { MenuCredits(); }
}

namespace HostMenuFuncList {
	void GodModeFunc() { PLAYER_GOD_MODE(); }
	void CanFlyFunc() { PLAYER_CAN_FLY(); }
	void NightVisionFunc() { PLAYER_NIGHT_VISION(); }
}

namespace SelfOptionsFuncList {
	void GodModeFunc() { PLAYER_GOD_MODE(); }
	void CanFlyFunc() { PLAYER_CAN_FLY(); }
	void NightVisionFunc() { PLAYER_NIGHT_VISION(); }
}

