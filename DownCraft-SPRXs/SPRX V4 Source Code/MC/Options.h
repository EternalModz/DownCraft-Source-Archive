#pragma once

void Options()
{

    #pragma region "DEVELOPER MENU"

	if (DeveloperMenu)
	{
		if (CurrentOpt == 0)
		{
			if (devmenu)
			{
				devmenu = false;
			}
			else
			{
				devmenu = true;
			}
		}
	}

    #pragma endregion

    #pragma region "MICS SETTINGS MENU 2"

	if (MicsSettings2)
	{
		if (CurrentOpt == 0)
		{
			Offsets::EXIT_GAME();
		}

		if (CurrentOpt == 1)
		{
			*(int*)0x0155847C = 0x00000000;
			UnHookFunctionStart(gameRenderHook, *(uint32_t*)(gameRender_Stub));
		}

		if (CurrentOpt == 2)
		{
			RestartGame();
		}

		if (CurrentOpt == 3)
		{
			if (UI::Settings::ShowCPURSX)
			{
				UI::Settings::ShowCPURSX = false;
			}
			else
			{
				UI::Settings::ShowCPURSX = true;
			}
		}

		if (CurrentOpt == 4)
		{
			if (UI::Settings::CheckboxV2)
			{
				UI::Settings::CheckboxV2 = false;
			}
			else
			{
				UI::Settings::CheckboxV2 = true;
			}
		}
	}

#pragma endregion

    #pragma region "MICS SETTINGS MENU"

	if (MicsSettings)
	{
		if (CurrentOpt == 0)
		{
			if (UI::Settings::ShowPosition)
			{
				UI::Settings::ShowPosition = false;
			}
			else
			{
				UI::Settings::ShowPosition = true;
			}
		}

		if (CurrentOpt == 1)
		{
			if (UI::Settings::ShowPING)
			{
				UI::Settings::ShowPING = false;
			}
			else
			{
				UI::Settings::ShowPING = true;
			}
		}

		if (CurrentOpt == 2)
		{
			if (UI::Settings::ShowChunks)
			{
				UI::Settings::ShowChunks = false;
			}
			else
			{
				UI::Settings::ShowChunks = true;
			}
		}

		if (CurrentOpt == 3)
		{
			if (UI::Settings::ShowResolution)
			{
				UI::Settings::ShowResolution = false;
			}
			else
			{
				UI::Settings::ShowResolution = true;
			}
		}

		if (CurrentOpt == 4)
		{
			if (UI::Settings::ShowNotif)
			{
				UI::Settings::ShowNotif = false;
			}
			else
			{
				UI::Settings::ShowNotif = true;
			}
		}

		if (CurrentOpt == 5)
		{
			if (UI::Settings::ShowInfosBar)
			{
				UI::Settings::ShowInfosBar = false;
			}
			else
			{
				UI::Settings::ShowInfosBar = true;
			}
		}

		if (CurrentOpt == 6)
		{
			if (UI::Settings::Style)
			{
				UI::Settings::Style = false;
			}
			else
			{
				UI::Settings::Style = true;
			}
		}

		if (CurrentOpt == 7)
		{
			if (UI::Settings::Checkbox)
			{
				UI::Settings::Checkbox = false;
			}
			else
			{
				UI::Settings::Checkbox = true;
			}
		}

		if (CurrentOpt == 8)
		{
			if (UI::Settings::GradientRGB)
			{
				UI::Settings::GradientRGB = false;
			}
			else
			{
				UI::Settings::GradientRGB = true;
			}
		}

		if (CurrentOpt == 9)
		{
			if (UI::Settings::Scrollbar)
			{
				UI::Settings::Scrollbar = false;
			}
			else
			{
				UI::Settings::Scrollbar = true;
			}
		}

		if (CurrentOpt == 10)
		{
			if (UI::Settings::BGOpacity)
			{
				UI::Settings::BGOpacity = false;
			}
			else
			{
				UI::Settings::BGOpacity = true;
			}
		}

		if (CurrentOpt == 13)
		{
			MicsSettings = false;
			MicsSettings2 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "CUSTOM IMAGE MENU"

	if (CustomImageMenu)
	{
		if (CurrentOpt == 0)
		{
			Offsets::ADD_CUSTOM_IMAGE(true);
		}

		if (CurrentOpt == 1)
		{
			if (!UI::Settings::CustomImage)
			{
				UI::Settings::CustomImage = true;

				menulenght = 105;

				TitleTextX -= 48;
				textX -= 48;
				bgX -= 48;
				AddOptX -= 48;
				CheckBoxX -= 48;
				ScrollX -= 48;

				TitleTextY += 28;
				textY += 28;
				bgY += 28;
				AddOptY += 28;
				CheckBoxY += 28;
				ScrollY += 28;

				*(int*)0x31E7781C = 0x3F2B0000; //size
				*(int*)0x31E77828 = 0x3F400000; //size

				Offsets::ADD_CUSTOM_BANNER();
			}
			else
			{
				menulenght = 50;

				TitleTextX = SaveTitleSlide;
				textX = SaveTextSlide;
				bgX = SavebgSlide;
				AddOptX = SaveAddOptSlide;
				CheckBoxX = SaveCheckBoxSlide;
				ScrollX = SaveScrollSlide;

				TitleTextY -= 28;
				textY -= 28;
				bgY -= 28;
				AddOptY -= 28;
				CheckBoxY -= 28;
				ScrollY -= 28;

				*(int*)0x31E7782C = 0x49B00000; //pos
				*(int*)0x31E77830 = 0xC9760000; //pos
				UI::Settings::CustomImage = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!UI::Settings::CustomImageGif)
			{
				UI::Settings::CustomImageGif = true;

				menulenght = 105;

				TitleTextX -= 48;
				textX -= 48;
				bgX -= 48;
				AddOptX -= 48;
				CheckBoxX -= 48;
				ScrollX -= 48;

				TitleTextY += 28;
				textY += 28;
				bgY += 28;
				AddOptY += 28;
				CheckBoxY += 28;
				ScrollY += 28;

				*(int*)0x31E7781C = 0x3F2B0000; //size
				*(int*)0x31E77828 = 0x3F400000; //size

				Offsets::ADD_CUSTOM_BANNER_GIF();
			}
			else
			{
				menulenght = 50;

				TitleTextX = SaveTitleSlide;
				textX = SaveTextSlide;
				bgX = SavebgSlide;
				AddOptX = SaveAddOptSlide;
				CheckBoxX = SaveCheckBoxSlide;
				ScrollX = SaveScrollSlide;

				TitleTextY -= 28;
				textY -= 28;
				bgY -= 28;
				AddOptY -= 28;
				CheckBoxY -= 28;
				ScrollY -= 28;

				*(int*)0x31E7782C = 0x49B00000; //pos
				*(int*)0x31E77830 = 0xC9760000; //pos
				UI::Settings::CustomImageGif = false;
			}
		}

		if (CurrentOpt == 3)
		{
			Offsets::ADD_OPACITY_IMAGE();
		}

		if (CurrentOpt == 4)
		{
			Offsets::REMOVE_OPACITY_IMAGE();
		}

		if (CurrentOpt == 5)
		{
			*(int*)0x31E7782C = 0x49600000; //pos
			*(int*)0x31E77830 = 0xC98D0000; //pos
		}
	}

#pragma endregion

    #pragma region "EDIT MENU"

	if (EditMenu)
	{
		if (CurrentOpt == 0)
		{
			TitleTextX += 1;
			textX += 1;
			bgX += 1;
			AddOptX += 1;
			CheckBoxX += 1;
			ScrollX += 1;
			SaveTitleSlide = TitleTextX;
		}

		if (CurrentOpt == 1)
		{
			TitleTextX -= 1;
			textX -= 1;
			bgX -= 1;
			AddOptX -= 1;
			CheckBoxX -= 1;
			ScrollX -= 1;
			SaveTitleSlide = TitleTextX;
		}

		if (CurrentOpt == 2)
		{
			TitleTextY += 1;
			textY += 1;
			bgY += 1;
			AddOptY += 1;
			CheckBoxY += 1;
			ScrollY += 1;
			SaveTitleSlide = TitleTextX;
		}

		if (CurrentOpt == 3)
		{
			TitleTextY -= 1;
			textY -= 1;
			bgY -= 1;
			AddOptY -= 1;
			CheckBoxY -= 1;
			ScrollY -= 1;
			SaveTitleSlide = TitleTextX;
		}
	}

#pragma endregion

    #pragma region "THEME COLORS MENU"

	if (ThemeColors)
	{
		if (CurrentOpt == 0)
		{
			UI::Settings::ThemeColors = "DEFAULT";
		}

		if (CurrentOpt == 1)
		{
			UI::Settings::ThemeColors = "WHITE";
		}

		if (CurrentOpt == 2)
		{
			UI::Settings::ThemeColors = "PINK";
		}

		if (CurrentOpt == 3)
		{
			UI::Settings::ThemeColors = "RED";
		}

		if (CurrentOpt == 4)
		{
			UI::Settings::ThemeColors = "ORANGE";
		}

		if (CurrentOpt == 5)
		{
			UI::Settings::ThemeColors = "CYAN";
		}

		if (CurrentOpt == 6)
		{
			UI::Settings::ThemeColors = "GREEN";
		}

		if (CurrentOpt == 7)
		{
			UI::Settings::ThemeColors = "LIME";
		}

		if (CurrentOpt == 8)
		{
			UI::Settings::ThemeColors = "YELLOW";
		}

		if (CurrentOpt == 9)
		{
			UI::Settings::ThemeColors = "PURPLE";
		}

		if (CurrentOpt == 10)
		{
			if (!UI::Settings::Rainbow)
			{
				UI::Settings::Rainbow = true;
			}
			else
			{
				UI::Settings::Rainbow = false;
			}
		}
	}

#pragma endregion

    #pragma region "DEBUG MENU"

	if (DebugMenu)
	{
		if (CurrentOpt == 0)
		{
			DebugTextX += 1;
		}

		if (CurrentOpt == 1)
		{
			DebugTextX -= 1;
		}

		if (CurrentOpt == 2)
		{
			DebugTextY += 1;
		}

		if (CurrentOpt == 3)
		{
			DebugTextY -= 1;
		}

		if (CurrentOpt == 4)
		{
			DebugHudX += 1;
		}

		if (CurrentOpt == 5)
		{
			DebugHudX -= 1;
		}

		if (CurrentOpt == 6)
		{
			DebugHudY += 1;
		}

		if (CurrentOpt == 7)
		{
			DebugHudY -= 1;
		}

		if (CurrentOpt == 8)
		{
			DebugHudW += 1;
		}

		if (CurrentOpt == 9)
		{
			DebugHudW -= 1;
		}

		if (CurrentOpt == 10)
		{
			DebugHudH += 1;
		}

		if (CurrentOpt == 11)
		{
			DebugHudH -= 1;
		}
	}

#pragma endregion

    #pragma region "SETTINGS MENU"

	if (SettingsMenu)
	{
		if (CurrentOpt == 0)
		{
			SettingsMenu = false;
			ThemeColors = true;
			CurrentOpt = 0;
		}

		if (CurrentOpt == 1)
		{
			SettingsMenu = false;
			EditMenu = true;
			CurrentOpt = 0;
		}

		if (CurrentOpt == 2)
		{
			SettingsMenu = false;
			DebugMenu = true;
			CurrentOpt = 0;
		}

		if (CurrentOpt == 3)
		{
			SettingsMenu = false;
			CustomImageMenu = true;
			CurrentOpt = 0;
		}

		if (CurrentOpt == 4)
		{
			SettingsMenu = false;
			MicsSettings = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "TELEPORT MENU"

	if (TeleportMenu)
	{
		if (CurrentOpt == 0)
		{
			TeleportX += 1;
		}

		if (CurrentOpt == 1)
		{
			TeleportY += 1;
		}

		if (CurrentOpt == 2)
		{
			TeleportZ += 1;
		}

		if (CurrentOpt == 3)
		{
			TeleportX -= 1;
		}

		if (CurrentOpt == 4)
		{
			TeleportY -= 1;
		}

		if (CurrentOpt == 5)
		{
			TeleportZ -= 1;
		}

		if (CurrentOpt == 6)
		{
			TeleportX = (int)mc->theMinecraft->cMultiplayerLocalPlayer->posX - 1;
			TeleportY = (int)mc->theMinecraft->cMultiplayerLocalPlayer->posY + 1;
			TeleportZ = (int)mc->theMinecraft->cMultiplayerLocalPlayer->posZ + 0.5;
		}

		if (CurrentOpt == 7)
		{
			Modules::setLocation(TeleportX, TeleportY, TeleportZ);
		}
	}

#pragma endregion

    #pragma region "TELEPORT MINI GAMES MENU"

	if (TPMiniGame)
	{
		if (CurrentOpt == 0)
		{
			Offsets::TELEPORT_TO_LOBBY();
		}

		if (CurrentOpt == 1)
		{
			Offsets::TELEPORT_TO_CAVERN();
		}

		if (CurrentOpt == 2)
		{
			Offsets::TELEPORT_TO_COVE();
		}

		if (CurrentOpt == 3)
		{
			Offsets::TELEPORT_TO_CRUCIBLE();
		}
	}

#pragma endregion

    #pragma region "MINI GAME MENU"

	if (MiniGamePage)
	{
		if (CurrentOpt == 0)
		{
			if (!CanCraft)
			{
				Offsets::CAN_CRAFT(true);
				CanCraft = true;
			}
			else
			{
				Offsets::CAN_CRAFT(false);
				CanCraft = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!CanPlaceBlocks)
			{
				Offsets::CAN_PLACE_BLOCKS(true);
				CanPlaceBlocks = true;
			}
			else
			{
				Offsets::CAN_PLACE_BLOCKS(false);
				CanPlaceBlocks = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!CanSeeSpectator)
			{
				Offsets::CAN_SEE_SPECTATOR(true);
				CanSeeSpectator = true;
			}
			else
			{
				Offsets::CAN_SEE_SPECTATOR(false);
				CanSeeSpectator = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!PlayersAreStarved)
			{
				Offsets::PLAYERS_ARE_STARVED(true);
				PlayersAreStarved = true;
			}
			else
			{
				Offsets::PLAYERS_ARE_STARVED(false);
				PlayersAreStarved = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!AllowPortals)
			{
				Offsets::ALLOW_PORTALS(true);
				AllowPortals = true;
			}
			else
			{
				Offsets::ALLOW_PORTALS(false);
				AllowPortals = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!TntCanDestroyBlocks)
			{
				Offsets::TNT_CAN_DESTROY(true);
				TntCanDestroyBlocks = true;
			}
			else
			{
				Offsets::TNT_CAN_DESTROY(false);
				TntCanDestroyBlocks = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!MaxPlayersSmallMap)
			{
				Offsets::MAX_PLAYERS_IN_SMALL_MAPS(true);
				MaxPlayersSmallMap = true;
			}
			else
			{
				Offsets::MAX_PLAYERS_IN_SMALL_MAPS(false);
				MaxPlayersSmallMap = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!CreativeInventory)
			{
				Offsets::CREATIVE_INVENTORY(true);
				CreativeInventory = true;
			}
			else
			{
				Offsets::CREATIVE_INVENTORY(false);
				CreativeInventory = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!CanDestroyBlocks)
			{
				Offsets::CAN_DESTROY_BLOCKS(true);
				CanDestroyBlocks = true;
			}
			else
			{
				Offsets::CAN_DESTROY_BLOCKS(false);
				CanDestroyBlocks = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!GameModeToSurvival)
			{
				Offsets::GAMEMODE_TO_SURVIVAL(true);
				GameModeToSurvival = true;
			}
			else
			{
				Offsets::GAMEMODE_TO_SURVIVAL(false);
				GameModeToSurvival = false;
			}
		}

		if (CurrentOpt == 10)
		{
			if (!InventoryCreaTumble)
			{
				Offsets::INVENTORY_CREATIVE_TUMBLE(true);
				InventoryCreaTumble = true;
			}
			else
			{
				Offsets::INVENTORY_CREATIVE_TUMBLE(false);
				InventoryCreaTumble = false;
			}
		}

		if (CurrentOpt == 11)
		{
			MiniGamePage = false;
			TPMiniGame = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "BLOCK CHANGER MENU 2"

	if (BlockChangerMenu2)
	{
		if (CurrentOpt == 0)
		{
			changedblock = Blocks::BEDROCK;
		}

		if (CurrentOpt == 1)
		{
			changedblock = Blocks::CHORUS_PLANT;
		}

		if (CurrentOpt == 2)
		{
			changedblock = Blocks::CHORUS_FLOWER;
		}

		if (CurrentOpt == 3)
		{
			changedblock = Blocks::GRASS_PATH;
		}

		if (CurrentOpt == 4)
		{
			changedblock = Blocks::ENCHANTEMENT_TABLE;
		}

		if (CurrentOpt == 5)
		{
			changedblock = Blocks::SKULL;
		}

		if (CurrentOpt == 6)
		{
			Offsets::ChangeBlocks();
		}

		if (CurrentOpt == 7)
		{
			//RESET
		}
	}

#pragma endregion

    #pragma region "BLOCK CHANGER MENU 1"

	if (BlockChangerMenu1)
	{
		if (CurrentOpt == 0)
		{
			changedblock = Blocks::LADDER;
		}

		if (CurrentOpt == 1)
		{
			changedblock = Blocks::END_PORTAL_WITH_BEACON;
		}

		if (CurrentOpt == 2)
		{
			changedblock = Blocks::NETHER_PORTAL;
		}

		if (CurrentOpt == 3)
		{
			changedblock = Blocks::TNT;
		}

		if (CurrentOpt == 4)
		{
			changedblock = Blocks::MAGMA;
		}

		if (CurrentOpt == 5)
		{
			changedblock = Blocks::CARPET;
		}

		if (CurrentOpt == 6)
		{
			changedblock = Blocks::DRAGON_EGG;
		}

		if (CurrentOpt == 7)
		{
			changedblock = Blocks::CAKE;
		}

		if (CurrentOpt == 8)
		{
			changedblock = Blocks::SNOW_LAYER;
		}

		if (CurrentOpt == 9)
		{
			changedblock = Blocks::CACTUS;
		}

		if (CurrentOpt == 10)
		{
			changedblock = Blocks::WALL_SIGN;
		}

		if (CurrentOpt == 11)
		{
			changedblock = Blocks::COB_WEB;
		}

		if (CurrentOpt == 12)
		{
			changedblock = Blocks::LAVA;
		}

		if (CurrentOpt == 13)
		{
			changedblock = Blocks::WATER;
		}

		if (CurrentOpt == 14)
		{
			changedblock = Blocks::LEVER;
		}

		if (CurrentOpt == 15)
		{
			BlockChangerMenu1 = false;
			BlockChangerMenu2 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "BLOCK CHANGER MENU"

	if (BlockChangerMenu)
	{
		if (CurrentOpt == 0)
		{
			SelectedBlock = Blocks::AIR;
		}

		if (CurrentOpt == 1)
		{
			SelectedBlock = Blocks::COBBLESTONE;
		}

		if (CurrentOpt == 2)
		{
			SelectedBlock = Blocks::GRASS;
		}

		if (CurrentOpt == 3)
		{
			SelectedBlock = Blocks::WATER;
		}

		if (CurrentOpt == 4)
		{
			SelectedBlock = Blocks::LAVA;
		}

		if (CurrentOpt == 5)
		{
			SelectedBlock = Blocks::SAND;
		}

		if (CurrentOpt == 6)
		{
			SelectedBlock = Blocks::FROSTED_ICE;
		}

		if (CurrentOpt == 7)
		{

		}

		if (CurrentOpt == 8)
		{
			changedblock = Blocks::BARRIERE;
		}

		if (CurrentOpt == 9)
		{
			changedblock = Blocks::OBSIDIAN;
		}

		if (CurrentOpt == 10)
		{
			changedblock = Blocks::COMMAND_BLOCK;
		}

		if (CurrentOpt == 11)
		{
			changedblock = Blocks::DIAMOND;
		}

		if (CurrentOpt == 12)
		{
			BlockChangerMenu = false;
			BlockChangerMenu1 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "EGGS SPAWNER CHANGER MENU"

	if (EggChangerMenu)
	{
		if (CurrentOpt == 0)
		{
			if (!DragonEggSpawner)
			{
				Offsets::DRAGON_EGGS_SPAWNER(true);
				DragonEggSpawner = true;
			}
			else
			{
				Offsets::DRAGON_EGGS_SPAWNER(false);
				DragonEggSpawner = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!GolemEggSpawner)
			{
				Offsets::GOLEM_EGGS_SPAWNER(true);
				GolemEggSpawner = true;
			}
			else
			{
				Offsets::GOLEM_EGGS_SPAWNER(false);
				GolemEggSpawner = false;
			}
		}
	}

#pragma endregion

    #pragma region "GAME EDITOR MENU"

	if (GameEditorMenu)
	{
		if (CurrentOpt == 0)
		{
			GameEditorMenu = false;
			BlockChangerMenu = true;
			CurrentOpt = 0;
		}

		if (CurrentOpt == 1)
		{
			GameEditorMenu = false;
			EggChangerMenu = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "NAME CHANGER MENU"

	if (NameChanger)
	{
		if (CurrentOpt == 0)
		{
			PRESET_NAME = ReadFile("/dev_hdd0/tmp/DownCraft/preset_name.txt");
			Offsets::NAME_CHANGER(PRESET_NAME);
		}

		if (CurrentOpt == 1)
		{
			Offsets::NAME_CHANGER("DownCraft SPRX V4");
		}

		if (CurrentOpt == 2)
		{
			Offsets::NAME_CHANGER("A\nB\nC\nD\nE\nF\nG\nH\nI\nJ\nK\nL\nM\nN\nO\nP\nQ\nR\nS\nT\nU\nV\nW\nX\nY\nZ");
		}

		if (CurrentOpt == 3)
		{
			Offsets::NAME_CHANGER("Your IP is: 125.58.46.741");
		}

		if (CurrentOpt == 4)
		{
			Offsets::NAME_CHANGER("");
		}

		if (CurrentOpt == 5)
		{
			Offsets::NAME_CHANGER("Hello\nEveryone\nIm\nJust\nA\nUser\nOf\nThe\nNew\nSPRX\nDownCraft V4");
		}

		if (CurrentOpt == 6)
		{
			Offsets::NAME_CHANGER("****************");
		}

		if (CurrentOpt == 7)
		{
			Offsets::NAME_CHANGER("エロアニメ");
		}

		if (CurrentOpt == 8)
		{
			Offsets::NAME_CHANGER("сука блять");
		}
	}

#pragma endregion

    #pragma region "VISION MENU 6"

	if (VisionMenu6)
	{
		if (CurrentOpt == 0)
		{
			if (!OptimizeChunks)
			{
				Offsets::OPTIMIZE_CHUNKS(true);
				OptimizeChunks = true;
			}
			else
			{
				Offsets::OPTIMIZE_CHUNKS(false);
				OptimizeChunks = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!StopChunksLoad)
			{
				Offsets::STOP_CHUNKS_LOAD(true);
				StopChunksLoad = true;
			}
			else
			{
				Offsets::STOP_CHUNKS_LOAD(false);
				StopChunksLoad = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!RealJumpAnim)
			{
				Offsets::REAL_JUMP_ANIM(true);
				RealJumpAnim = true;
			}
			else
			{
				Offsets::REAL_JUMP_ANIM(false);
				RealJumpAnim = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!RainbowSky)
			{
				RainbowSky = true;
			}
			else
			{
				RainbowSky = false;
				*(int*)0x00410734 = 0x40C00000;
			}
		}
	}

#pragma endregion

    #pragma region "VISION MENU 5"

	if (VisionMenu5)
	{
		if (CurrentOpt == 0)
		{
			if (!RotationBody)
			{
				Offsets::ROTATION_BODY(true);
				RotationBody = true;
			}
			else
			{
				Offsets::ROTATION_BODY(false);
				RotationBody = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!EntityBodyLight)
			{
				Offsets::ENTITY_BODY_LIGHT(true);
				EntityBodyLight = true;
			}
			else
			{
				Offsets::ENTITY_BODY_LIGHT(false);
				EntityBodyLight = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!NetherVision)
			{
				Offsets::NETHER_VISION(true);
				NetherVision = true;
			}
			else
			{
				Offsets::NETHER_VISION(false);
				NetherVision = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!ParticlesHitSpam)
			{
				Offsets::PARTICLES_HIT_SPAM(true);
				ParticlesHitSpam = true;
			}
			else
			{
				Offsets::PARTICLES_HIT_SPAM(false);
				ParticlesHitSpam = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!RobloxAnimation)
			{
				Offsets::ROBLOX_ANIMATION(true);
				RobloxAnimation = true;
			}
			else
			{
				Offsets::ROBLOX_ANIMATION(false);
				RobloxAnimation = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!Elytra)
			{
				Offsets::ENTITY_ELYTRA(true);
				Elytra = true;
			}
			else
			{
				Offsets::ENTITY_ELYTRA(false);
				Elytra = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!MoveHeadNoBody)
			{
				Offsets::MOVE_HEAD_NO_BODY(true);
				MoveHeadNoBody = true;
			}
			else
			{
				Offsets::MOVE_HEAD_NO_BODY(false);
				MoveHeadNoBody = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!StopAnimation)
			{
				Offsets::STOP_ANIMATION(true);
				StopAnimation = true;
			}
			else
			{
				Offsets::STOP_ANIMATION(false);
				StopAnimation = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!GiantGameplay)
			{
				Offsets::GIANT_GAMEPLAY(true);
				GiantGameplay = true;
			}
			else
			{
				Offsets::GIANT_GAMEPLAY(false);
				GiantGameplay = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!WorldLightWhite)
			{
				Offsets::WORLD_LIGHT_WHITE(true);
				WorldLightWhite = true;
			}
			else
			{
				Offsets::WORLD_LIGHT_WHITE(false);
				WorldLightWhite = false;
			}
		}

		if (CurrentOpt == 10)
		{
			if (!WorldRainbowLight)
			{
				Offsets::WORLD_LIGHT_RAINBOW(true);
				WorldRainbowLight = true;
			}
			else
			{
				Offsets::WORLD_LIGHT_RAINBOW(false);
				WorldRainbowLight = false;
			}
		}

		if (CurrentOpt == 11)
		{
			if (!ShadowSkins)
			{
				Offsets::SHADOW_SKINS_V1(true);
				ShadowSkins = true;
			}
			else
			{
				Offsets::SHADOW_SKINS_V1(false);
				ShadowSkins = false;
			}
		}

		if (CurrentOpt == 12)
		{
			if (!DoubleName)
			{
				Offsets::DOUBLE_NAME(true);
				DoubleName = true;
			}
			else
			{
				Offsets::DOUBLE_NAME(false);
				DoubleName = false;
			}
		}

		if (CurrentOpt == 13)
		{
			VisionMenu5 = false;
			VisionMenu6 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "VISION MENU 4"

	if (VisionMenu4)
	{
		if (CurrentOpt == 0)
		{
			if (!FovWithoutHand)
			{
				Offsets::FOV_WITHOUT_HAND(true);
				FovWithoutHand = true;
			}
			else
			{
				Offsets::FOV_WITHOUT_HAND(false);
				FovWithoutHand = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!ZoomWithoutHand)
			{
				Offsets::FOV_WITHOUT_HAND(true);
				ZoomWithoutHand = true;
			}
			else
			{
				Offsets::FOV_WITHOUT_HAND(false);
				ZoomWithoutHand = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!IronHelmet)
			{
				Offsets::IRON_HELMET_ON_ALL(true);
				IronHelmet = true;
			}
			else
			{
				Offsets::IRON_HELMET_ON_ALL(false);
				IronHelmet = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!EntityBaby)
			{
				Offsets::ENTITY_TO_BABY(true);
				EntityBaby = true;
			}
			else
			{
				Offsets::ENTITY_TO_BABY(false);
				EntityBaby = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!NoDetailedSkins)
			{
				Offsets::REMOVE_DETAILED_SKINS(true);
				NoDetailedSkins = true;
			}
			else
			{
				Offsets::REMOVE_DETAILED_SKINS(false);
				NoDetailedSkins = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!AimOn3thPerson)
			{
				Offsets::AIM_ON_3TH_PERSON(true);
				AimOn3thPerson = true;
			}
			else
			{
				Offsets::AIM_ON_3TH_PERSON(false);
				AimOn3thPerson = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!RenderEntity)
			{
				Offsets::RENDER_ENTITY(true);
				RenderEntity = true;
			}
			else
			{
				Offsets::RENDER_ENTITY(false);
				RenderEntity = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!RotationCam)
			{
				Offsets::ROTATION_BODY(true);
				RotationCam = true;
			}
			else
			{
				Offsets::ROTATION_BODY(false);
				RotationCam = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!TextureToBlack)
			{
				Offsets::TEXTURE_TO_BLACK(true);
				TextureToBlack = true;
			}
			else
			{
				Offsets::TEXTURE_TO_BLACK(false);
				TextureToBlack = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!GammaToMax)
			{
				Offsets::GAMMA_TO_MAX(true);
				GammaToMax = true;
			}
			else
			{
				Offsets::GAMMA_TO_MAX(false);
				GammaToMax = false;
			}
		}

		if (CurrentOpt == 10)
		{
			if (!NameShadowBlack)
			{
				Offsets::NAME_AND_SHADOW_TO_BLACK(true);
				NameShadowBlack = true;
			}
			else
			{
				Offsets::NAME_AND_SHADOW_TO_BLACK(false);
				NameShadowBlack = false;
			}
		}

		if (CurrentOpt == 11)
		{
			if (!AnimationCharacter)
			{
				Offsets::ANIMATION_CHARACTER(true);
				AnimationCharacter = true;
			}
			else
			{
				Offsets::ANIMATION_CHARACTER(false);
				AnimationCharacter = false;
			}
		}

		if (CurrentOpt == 12)
		{
			if (!BigAnimCharacter)
			{
				Offsets::BIG_ANIM_CHARACTER(true);
				BigAnimCharacter = true;
			}
			else
			{
				Offsets::BIG_ANIM_CHARACTER(false);
				BigAnimCharacter = false;
			}
		}

		if (CurrentOpt == 13)
		{
			VisionMenu4 = false;
			VisionMenu5 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "VISION MENU 3"

	if (VisionMenu3)
	{
		if (CurrentOpt == 0)
		{
			if (!DisablePlayers)
			{
				Offsets::DISABLE_PLAYERS(true);
				DisablePlayers = true;
			}
			else
			{
				Offsets::DISABLE_PLAYERS(false);
				DisablePlayers = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!SmallText)
			{
				Offsets::SMALL_TEXT(true);
				SmallText = true;
			}
			else
			{
				Offsets::SMALL_TEXT(false);
				SmallText = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!PosHudText)
			{
				Offsets::POS_HUD_TEXT(true);
				PosHudText = true;
			}
			else
			{
				Offsets::POS_HUD_TEXT(false);
				PosHudText = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!ArmsBroken)
			{
				Offsets::ARMS_BROKEN(true);
				ArmsBroken = true;
			}
			else
			{
				Offsets::ARMS_BROKEN(false);
				ArmsBroken = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!BlackFog)
			{
				Offsets::BLOCK_FOG(true);
				BlackFog = true;
			}
			else
			{
				Offsets::BLOCK_FOG(false);
				BlackFog = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!SkyNether)
			{
				Offsets::SKY_NETHER(true);
				SkyNether = true;
			}
			else
			{
				Offsets::SKY_NETHER(false);
				SkyNether = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!SmokeLobby)
			{
				Offsets::SMOKE_LOBBY(true);
				SmokeLobby = true;
			}
			else
			{
				Offsets::SMOKE_LOBBY(false);
				SmokeLobby = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!LookUnderWorld)
			{
				Offsets::LOOK_UNDER_WORLD(true);
				LookUnderWorld = true;
			}
			else
			{
				Offsets::LOOK_UNDER_WORLD(false);
				LookUnderWorld = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!FreeCam)
			{
				Offsets::FREE_CAM(true);
				FreeCam = true;
			}
			else
			{
				Offsets::FREE_CAM(false);
				FreeCam = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!RemoveHand)
			{
				Offsets::REMOVE_HAND(true);
				RemoveHand = true;
			}
			else
			{
				Offsets::REMOVE_HAND(false);
				RemoveHand = false;
			}
		}

		if (CurrentOpt == 10)
		{
			if (!TornadoParticles)
			{
				Offsets::TORNADE_PARTICLES(true);
				TornadoParticles = true;
			}
			else
			{
				Offsets::TORNADE_PARTICLES(false);
				TornadoParticles = false;
			}
		}

		if (CurrentOpt == 11)
		{
			if (!HitDamageRed)
			{
				Offsets::HIT_DAMAGE_RED(true);
				HitDamageRed = true;
			}
			else
			{
				Offsets::HIT_DAMAGE_RED(false);
				HitDamageRed = false;
			}
		}

		if (CurrentOpt == 12)
		{
			if (!DisableFogOfs)
			{
				Offsets::DISABLE_FOG(true);
				DisableFogOfs = true;
			}
			else
			{
				Offsets::DISABLE_FOG(false);
				DisableFogOfs = false;
			}
		}

		if (CurrentOpt == 13)
		{
			VisionMenu3 = false;
			VisionMenu4 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "VISION MENU 2"

	if (VisionMenu2)
	{
		if (CurrentOpt == 0)
		{
			if (!BigModel)
			{
				Offsets::BIG_MODEL(true);
				BigModel = true;
			}
			else
			{
				Offsets::BIG_MODEL(false);
				BigModel = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!CameraLeft)
			{
				Offsets::CAMERA_LEFT(true);
				CameraLeft = true;
			}
			else
			{
				Offsets::CAMERA_LEFT(false);
				CameraLeft = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!CameraRight)
			{
				Offsets::CAMERA_RIGHT(true);
				CameraRight = true;
			}
			else
			{
				Offsets::CAMERA_RIGHT(false);
				CameraRight = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!BigParticles)
			{
				Offsets::BIG_PARTICLES(true);
				BigParticles = true;
			}
			else
			{
				Offsets::BIG_PARTICLES(false);
				BigParticles = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!HudLoading)
			{
				Offsets::HUD_LOADING(true);
				HudLoading = true;
			}
			else
			{
				Offsets::HUD_LOADING(false);
				HudLoading = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!StarsInSky)
			{
				Offsets::STARS_IN_SKY(true);
				StarsInSky = true;
			}
			else
			{
				Offsets::STARS_IN_SKY(false);
				StarsInSky = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!FootStepFast)
			{
				Offsets::FOOT_STEP_SLOW(true);
				FootStepFast = true;
			}
			else
			{
				Offsets::FOOT_STEP_SLOW(false);
				FootStepFast = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!FootStepSlow)
			{
				Offsets::FOOT_STEP_SLOW(true);
				FootStepSlow = true;
			}
			else
			{
				Offsets::FOOT_STEP_SLOW(false);
				FootStepSlow = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!SkinsDebug)
			{
				Offsets::SKINS_DEBUG(true);
				SkinsDebug = true;
			}
			else
			{
				Offsets::SKINS_DEBUG(false);
				SkinsDebug = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!ShadowSkins)
			{
				Offsets::SHADOW_SKINS(true);
				ShadowSkins = true;
			}
			else
			{
				Offsets::SHADOW_SKINS(false);
				ShadowSkins = false;
			}
		}

		if (CurrentOpt == 10)
		{
			if (!SkinsPlayersRed)
			{
				Offsets::SKINS_RED_PLAYERS(true);
				SkinsPlayersRed = true;
			}
			else
			{
				Offsets::SKINS_RED_PLAYERS(false);
				SkinsPlayersRed = false;
			}
		}

		if (CurrentOpt == 11)
		{
			if (!ParticlesFly1)
			{
				Offsets::PARTICLES_FLY_V1(true);
				ParticlesFly1 = true;
			}
			else
			{
				Offsets::PARTICLES_FLY_V1(false);
				ParticlesFly1 = false;
			}
		}

		if (CurrentOpt == 12)
		{
			if (!LineBlockMove)
			{
				Offsets::LINE_BLOCK_MOVE(true);
				LineBlockMove = true;
			}
			else
			{
				Offsets::LINE_BLOCK_MOVE(false);
				LineBlockMove = false;
			}
		}

		if (CurrentOpt == 13)
		{
			VisionMenu2 = false;
			VisionMenu3 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "VISION MENU 1"

	if (VisionMenu1)
	{
		if (CurrentOpt == 0)
		{
			if (!WallhackV3)
			{
				Offsets::WALLHACK_V3(true);
				WallhackV3 = true;
			}
			else
			{
				Offsets::WALLHACK_V3(false);
				WallhackV3 = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!PlasticTexture)
			{
				Offsets::PLASTIC_TEXTURE(true);
				PlasticTexture = true;
			}
			else
			{
				Offsets::PLASTIC_TEXTURE(false);
				PlasticTexture = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!GhostPlastic)
			{
				Offsets::GHOST_TEXTURE(true);
				GhostPlastic = true;
			}
			else
			{
				Offsets::GHOST_TEXTURE(false);
				GhostPlastic = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!BlueFog)
			{
				Offsets::BLUE_FOG(true);
				BlueFog = true;
			}
			else
			{
				Offsets::BLUE_FOG(false);
				BlueFog = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!BestSky)
			{
				Offsets::BEST_SKY(true);
				BestSky = true;
			}
			else
			{
				Offsets::BEST_SKY(false);
				BestSky = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!ShakeCamera)
			{
				Offsets::SHAKE_CAMERA(true);
				ShakeCamera = true;
			}
			else
			{
				Offsets::SHAKE_CAMERA(false);
				ShakeCamera = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!MoreLight)
			{
				Offsets::MORE_LIGHT(true);
				MoreLight = true;
			}
			else
			{
				Offsets::MORE_LIGHT(false);
				MoreLight = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!FlatItems)
			{
				Offsets::FLAT_ITEMS(true);
				FlatItems = true;
			}
			else
			{
				Offsets::FLAT_ITEMS(false);
				FlatItems = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!VibrateWalk)
			{
				Offsets::VIBRATE_WALK(true);
				VibrateWalk = true;
			}
			else
			{
				Offsets::VIBRATE_WALK(false);
				VibrateWalk = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!HUDInvDown)
			{
				Offsets::HUD_INV_DOWN(true);
				HUDInvDown = true;
			}
			else
			{
				Offsets::HUD_INV_DOWN(false);
				HUDInvDown = false;
			}
		}

		if (CurrentOpt == 10)
		{
			if (!SmallGraphic)
			{
				Offsets::SMALL_GRAPHIC(true);
				SmallGraphic = true;
			}
			else
			{
				Offsets::SMALL_GRAPHIC(false);
				SmallGraphic = false;
			}
		}

		if (CurrentOpt == 11)
		{
			if (!ParticlesFly)
			{
				Offsets::PARTICLES_FLY(true);
				ParticlesFly = true;
			}
			else
			{
				Offsets::PARTICLES_FLY(false);
				ParticlesFly = false;
			}
		}

		if (CurrentOpt == 12)
		{
			if (!PaperModel)
			{
				Offsets::PAPER_MODE(true);
				PaperModel = true;
			}
			else
			{
				Offsets::PAPER_MODE(false);
				PaperModel = false;
			}
		}

		if (CurrentOpt == 13)
		{
			VisionMenu1 = false;
			VisionMenu2 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "VISION MENU"

	if (VisionMenu)
	{
		if (CurrentOpt == 0)
		{
			if (!XrayVision)
			{
				Offsets::XRAY_VISON(true);
				XrayVision = true;
			}
			else
			{
				Offsets::XRAY_VISON(false);
				XrayVision = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!NightVision)
			{
				Offsets::NIGHT_VISON(true);
				NightVision = true;
			}
			else
			{
				Offsets::NIGHT_VISON(false);
				NightVision = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!Apocalipse)
			{
				Offsets::APOCALIPSE(true);
				Apocalipse = true;
			}
			else
			{
				Offsets::APOCALIPSE(false);
				Apocalipse = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!FunnySound)
			{
				Offsets::FUNNY_SCREEN(true);
				FunnySound = true;
			}
			else
			{
				Offsets::FUNNY_SCREEN(false);
				FunnySound = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!HorrorView)
			{
				Offsets::HORROR_VISION(true);
				HorrorView = true;
			}
			else
			{
				Offsets::HORROR_VISION(false);
				HorrorView = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!AnimationRun)
			{
				Offsets::ANIMATION_RUN(true);
				AnimationRun = true;
			}
			else
			{
				Offsets::ANIMATION_RUN(false);
				AnimationRun = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!SkyRainbow)
			{
				Offsets::SKY_RAINBOW(true);
				SkyRainbow = true;
			}
			else
			{
				Offsets::SKY_RAINBOW(false);
				SkyRainbow = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!WTFView)
			{
				Offsets::WTF_VIEW(true);
				WTFView = true;
			}
			else
			{
				Offsets::WTF_VIEW(false);
				WTFView = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!SizeHUD)
			{
				Offsets::SIZE_HUD(true);
				SizeHUD = true;
			}
			else
			{
				Offsets::SIZE_HUD(false);
				SizeHUD = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!BrokenTexture)
			{
				Offsets::BROKEN_TEXTURE(true);
				BrokenTexture = true;
			}
			else
			{
				Offsets::BROKEN_TEXTURE(false);
				BrokenTexture = false;
			}
		}

		if (CurrentOpt == 10)
		{
			if (!ShockWave)
			{
				Offsets::SHOCKWAVE(true);
				ShockWave = true;
			}
			else
			{
				Offsets::SHOCKWAVE(false);
				ShockWave = false;
			}
		}

		if (CurrentOpt == 11)
		{
			if (!WallHack)
			{
				Offsets::WALLHACK(true);
				WallHack = true;
			}
			else
			{
				Offsets::WALLHACK(false);
				WallHack = false;
			}
		}

		if (CurrentOpt == 12)
		{
			if (!WallHackV2)
			{
				Offsets::WALLHACK_V2(true);
				WallHackV2 = true;
			}
			else
			{
				Offsets::WALLHACK_V2(false);
				WallHackV2 = false;
			}
		}

		if (CurrentOpt == 13)
		{
			VisionMenu = false;
			VisionMenu1 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "WEATHER MENU"

	if (WeathesMenu)
	{
		if (CurrentOpt == 0)
		{
			if (!DarkStorm)
			{
				Offsets::WEATHER_DARK_STORM(true);
				DarkStorm = true;
			}
			else
			{
				Offsets::WEATHER_DARK_STORM(false);
				DarkStorm = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!RainbowStorm)
			{
				Offsets::WEATHER_RAINBOW_STORM(true);
				RainbowStorm = true;
			}
			else
			{
				Offsets::WEATHER_RAINBOW_STORM(false);
				RainbowStorm = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!RainToSnow)
			{
				Offsets::WEATHER_RAIN_TO_SNOW(true);
				RainToSnow = true;
			}
			else
			{
				Offsets::WEATHER_RAIN_TO_SNOW(false);
				RainToSnow = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!RainbowWithSnow)
			{
				Offsets::WEATHER_RAINBOW_WITH_STORM(true);
				RainbowWithSnow = true;
			}
			else
			{
				Offsets::WEATHER_RAINBOW_WITH_STORM(false);
				RainbowWithSnow = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!FlashSky)
			{
				Offsets::WEATHER_FLASH_SKY(true);
				FlashSky = true;
			}
			else
			{
				Offsets::WEATHER_FLASH_SKY(false);
				FlashSky = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!LightningBoldV1)
			{
				Offsets::WEATHER_LIGHTNINGBOLD_V1(true);
				LightningBoldV1 = true;
			}
			else
			{
				Offsets::WEATHER_LIGHTNINGBOLD_V1(false);
				LightningBoldV1 = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!LightningBoldV2)
			{
				Offsets::WEATHER_LIGHTNINGBOLD_V2(true);
				LightningBoldV2 = true;
			}
			else
			{
				Offsets::WEATHER_LIGHTNINGBOLD_V2(false);
				LightningBoldV2 = false;
			}
		}
	}

#pragma endregion

    #pragma region "PLAYERS OPTIONS MENU"

	if (PlayersOptions)
	{
		if (CurrentOpt == 0)
		{
			if (!AllPlayersFastMine)
			{
				Offsets::ALL_PLAYERS_FAST_MINE(true);
				AllPlayersFastMine = true;
			}
			else
			{
				Offsets::ALL_PLAYERS_FAST_MINE(false);
				AllPlayersFastMine = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!AllPlayersCantMine)
			{
				Offsets::ALL_PLAYERS_CANNOT_MINE(true);
				AllPlayersCantMine = true;
			}
			else
			{
				Offsets::ALL_PLAYERS_CANNOT_MINE(false);
				AllPlayersCantMine = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!AllPlayersCantRun)
			{
				Offsets::ALL_PLAYERS_CANT_RUN(true);
				AllPlayersCantRun = true;
			}
			else
			{
				Offsets::ALL_PLAYERS_CANT_RUN(false);
				AllPlayersCantRun = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!AllPlayersSpeed)
			{
				Offsets::ALL_PLAYERS_SUPER_SPEED(true);
				AllPlayersSpeed = true;
			}
			else
			{
				Offsets::ALL_PLAYERS_SUPER_SPEED(false);
				AllPlayersSpeed = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!AllPlayersSuperRun)
			{
				Offsets::ALL_PLAYERS_SUPER_RUN(true);
				AllPlayersSuperRun = true;
			}
			else
			{
				Offsets::ALL_PLAYERS_SUPER_RUN(false);
				AllPlayersSuperRun = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!AllPlayersZoomFOV)
			{
				AllPlayersZoomFOV = true;
			}
			else
			{
				char ON2[] = { 0x08 };
				sys_dbg_write_process_memory(0x004668B6, &ON2, sizeof(ON2));
				sys_dbg_read_process_memory_ps3mapi(0x004668B6, &ON2, sizeof(ON2));
				AllPlayersZoomFOV = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!PlayersCantJoin)
			{
				Offsets::ALL_PLAYERS_CANT_JOIN_THE_WORLD(true);
				PlayersCantJoin = true;
			}
			else
			{
				Offsets::ALL_PLAYERS_CANT_JOIN_THE_WORLD(false);
				PlayersCantJoin = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!AllChangeHand)
			{
				Offsets::ALL_PLAYERS_CHANGE_HAND(true);
				AllChangeHand = true;
			}
			else
			{
				Offsets::ALL_PLAYERS_CHANGE_HAND(false);
				AllChangeHand = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!AllPlayersSuffocate)
			{
				Offsets::ALL_PLAYERS_SUFFOCATE(true);
				AllPlayersSuffocate = true;
			}
			else
			{
				Offsets::ALL_PLAYERS_SUFFOCATE(false);
				AllPlayersSuffocate = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!AllPlayersInFire)
			{
				Offsets::ALL_PLAYERS_IN_FIRE(true);
				AllPlayersInFire = true;
			}
			else
			{
				Offsets::ALL_PLAYERS_IN_FIRE(false);
				AllPlayersInFire = false;
			}
		}

		if (CurrentOpt == 10)
		{
			Offsets::ALL_PLAYERS_FREEZE_PS3();
		}
	}

#pragma endregion

    #pragma region "NON HOST MENU 7"

	if (NonHostPage7)
	{
		if (CurrentOpt == 0)
		{
			if (!BlockStaticCrack)
			{
				Offsets::BLOCK_STATIC_CRACK(true);
				BlockStaticCrack = true;
			}
			else
			{
				Offsets::BLOCK_STATIC_CRACK(false);
				BlockStaticCrack = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!BigVelocity)
			{
				Offsets::BIG_VELOCITY(true);
				BigVelocity = true;
			}
			else
			{
				Offsets::BIG_VELOCITY(false);
				BigVelocity = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!NoVelocity)
			{
				Offsets::NO_VELOCITY(true);
				NoVelocity = true;
			}
			else
			{
				Offsets::NO_VELOCITY(false);
				NoVelocity = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!AntiVoidtoggle)
			{
				AntiVoidtoggle = true;
			}
			else
			{
				AntiVoidtoggle = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!BunnyHoptoggle)
			{
				BunnyHoptoggle = true;
			}
			else
			{
				BunnyHoptoggle = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!ESPEntity)
			{
				Offsets::ENTITY_ESP(true);
				ESPEntity = true;
			}
			else
			{
				Offsets::ENTITY_ESP(false);
				ESPEntity = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!ESPTracer)
			{
				Offsets::ESP_TRACER(true);
				ESPTracer = true;
			}
			else
			{
				Offsets::ESP_TRACER(false);
				ESPTracer = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!ESPCOD)
			{
				Offsets::ESP_COD(true);
				ESPCOD = true;
			}
			else
			{
				Offsets::ESP_COD(false);
				ESPCOD = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!ESPWaypoint)
			{
				Offsets::ESP_WAYPOINT(true);
				ESPWaypoint = true;
			}
			else
			{
				Offsets::ESP_WAYPOINT(false);
				ESPWaypoint = false;
			}
		}
	}

#pragma endregion

    #pragma region "NON HOST MENU 6"

	if (NonHostPage6)
	{
		if (CurrentOpt == 0)
		{
			if (!AutoSprint)
			{
				Offsets::AUTO_SPRINT(true);
				AutoSprint = true;
			}
			else
			{
				Offsets::AUTO_SPRINT(false);
				AutoSprint = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!AutoSprintV2)
			{
				Offsets::AUTO_SPRINT_V2(true);
				AutoSprintV2 = true;
			}
			else
			{
				Offsets::AUTO_SPRINT_V2(false);
				AutoSprintV2 = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!InstantHit)
			{
				Offsets::INSTANT_HIT(true);
				InstantHit = true;
			}
			else
			{
				Offsets::INSTANT_HIT(false);
				InstantHit = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!KillAura)
			{
				Offsets::KILL_AURA(true);
				KillAura = true;
			}
			else
			{
				Offsets::KILL_AURA(false);
				KillAura = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!FastBuild)
			{
				Offsets::FAST_BUILD(true);
				FastBuild = true;
			}
			else
			{
				Offsets::FAST_BUILD(false);
				FastBuild = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!CriticalMode)
			{
				Offsets::CRITICAL_MODE(true);
				CriticalMode = true;
			}
			else
			{
				Offsets::CRITICAL_MODE(false);
				CriticalMode = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!CriticalModeV2)
			{
				Offsets::CRITICAL_MODE_V1(true);
				CriticalModeV2 = true;
			}
			else
			{
				Offsets::CRITICAL_MODE_V1(false);
				CriticalModeV2 = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!NoSlowDown)
			{
				Offsets::NO_SLOW_DOWN(true);
				NoSlowDown = true;
			}
			else
			{
				Offsets::NO_SLOW_DOWN(false);
				NoSlowDown = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!NoHurtCam)
			{
				Offsets::REMOVE_HURT_CAM(true);
				NoHurtCam = true;
			}
			else
			{
				Offsets::REMOVE_HURT_CAM(false);
				NoHurtCam = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!PressXForHit)
			{
				Offsets::PRESS_X_FOR_HIT(true);
				PressXForHit = true;
			}
			else
			{
				Offsets::PRESS_X_FOR_HIT(false);
				PressXForHit = false;
			}
		}

		if (CurrentOpt == 10)
		{
			if (!ShowArmor)
			{
				Offsets::SHOW_ARMOR(true);
				ShowArmor = true;
			}
			else
			{
				Offsets::SHOW_ARMOR(false);
				ShowArmor = false;
			}
		}

		if (CurrentOpt == 11)
		{
			if (!UnfairAttack)
			{
				Offsets::UNFAIR_ATTACK(true);
				UnfairAttack = true;
			}
			else
			{
				Offsets::UNFAIR_ATTACK(false);
				UnfairAttack = false;
			}
		}

		if (CurrentOpt == 12)
		{
			if (!HitBoxBETA)
			{
				Offsets::HITBOX_BETA(true);
				HitBoxBETA = true;
			}
			else
			{
				Offsets::HITBOX_BETA(false);
				HitBoxBETA = false;
			}
		}

		if (CurrentOpt == 13)
		{
			NonHostPage6 = false;
			NonHostPage7 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "NON HOST MENU 5"

	if (NonHostPage5)
	{
		if (CurrentOpt == 0)
		{
			if (!GameSpeedStatic)
			{
				Offsets::GAME_SPEED_STATIC(true);
				GameSpeedStatic = true;
			}
			else
			{
				Offsets::GAME_SPEED_STATIC(false);
				GameSpeedStatic = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!Get64Items)
			{
				Offsets::GET_64_ITEMS(true);
				Get64Items = true;
			}
			else
			{
				Offsets::GET_64_ITEMS(false);
				Get64Items = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!AutoJump)
			{
				Offsets::AUTO_JUMP(true);
				AutoJump = true;
			}
			else
			{
				Offsets::AUTO_JUMP(false);
				AutoJump = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!AutoChangeView)
			{
				Offsets::AUTO_CHANGE_VIEW(true);
				AutoChangeView = true;
			}
			else
			{
				Offsets::AUTO_CHANGE_VIEW(false);
				AutoChangeView = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!AutoCrouch)
			{
				Offsets::AUTO_CROUCH(true);
				AutoCrouch = true;
			}
			else
			{
				Offsets::AUTO_CROUCH(false);
				AutoCrouch = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!AutoMine)
			{
				Offsets::AUTO_MINE(true);
				AutoMine = true;
			}
			else
			{
				Offsets::AUTO_MINE(false);
				AutoMine = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!AutoHit)
			{
				Offsets::AUTO_HIT(true);
				AutoHit = true;
			}
			else
			{
				Offsets::AUTO_HIT(false);
				AutoHit = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!AutoTossItems)
			{
				Offsets::AUTO_TOSS_ITEMS(true);
				AutoTossItems = true;
			}
			else
			{
				Offsets::AUTO_TOSS_ITEMS(false);
				AutoTossItems = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!AutoBuild)
			{
				Offsets::AUTO_BUILD(true);
				AutoBuild = true;
			}
			else
			{
				Offsets::AUTO_BUILD(false);
				AutoBuild = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!BatEggsCrash)
			{
				Offsets::BAT_EGGS_CRASH(true);
				BatEggsCrash = true;
			}
			else
			{
				Offsets::BAT_EGGS_CRASH(false);
				BatEggsCrash = false;
			}
		}

		if (CurrentOpt == 10)
		{
			if (!BatEggsFreeze)
			{
				Offsets::BAT_EGGS_FREEZE(true);
				BatEggsFreeze = true;
			}
			else
			{
				Offsets::BAT_EGGS_FREEZE(false);
				BatEggsFreeze = false;
			}
		}

		if (CurrentOpt == 11)
		{
			if (!GetSpecialItems)
			{
				Offsets::GET_SPECIAL_ITEMS(true);
				GetSpecialItems = true;
			}
			else
			{
				Offsets::GET_SPECIAL_ITEMS(false);
				GetSpecialItems = false;
			}
		}

		if (CurrentOpt == 12)
		{
			if (!ReachAttack)
			{
				Offsets::REACH_ATTACK(true);
				ReachAttack = true;
			}
			else
			{
				Offsets::REACH_ATTACK(false);
				ReachAttack = false;
			}
		}

		if (CurrentOpt == 13)
		{
			NonHostPage5 = false;
			NonHostPage6 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "NON HOST MENU 4"

	if (NonHostPage4)
	{
		if (CurrentOpt == 0)
		{
			if (!JumpInLava)
			{
				Offsets::JUMP_IN_LAVA(true);
				JumpInLava = true;
			}
			else
			{
				Offsets::JUMP_IN_LAVA(false);
				JumpInLava = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!CrouchMovement)
			{
				Offsets::CROUCH_MOVEMENT(true);
				CrouchMovement = true;
			}
			else
			{
				Offsets::CROUCH_MOVEMENT(false);
				CrouchMovement = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!PosPlaceBlock)
			{
				Offsets::POSITION_PLACE_BLOCK(true);
				PosPlaceBlock = true;
			}
			else
			{
				Offsets::POSITION_PLACE_BLOCK(false);
				PosPlaceBlock = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!DestroyGame)
			{
				Offsets::DESTROY_GAME(true);
				DestroyGame = true;
			}
			else
			{
				Offsets::DESTROY_GAME(false);
				DestroyGame = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!Levitation)
			{
				Offsets::LEVITATION(true);
				Levitation = true;
			}
			else
			{
				Offsets::LEVITATION(false);
				Levitation = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!ReturnInXMB)
			{
				Offsets::RETURN_IN_XMB(true);
				ReturnInXMB = true;
			}
			else
			{
				Offsets::RETURN_IN_XMB(false);
				ReturnInXMB = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!ReturnInXMBV2)
			{
				Offsets::RETURN_IN_XMB_V2(true);
				ReturnInXMBV2 = true;
			}
			else
			{
				Offsets::RETURN_IN_XMB_V2(false);
				ReturnInXMBV2 = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!AddFakeClone)
			{
				Offsets::ADD_FAKE_CLONE(true);
				AddFakeClone = true;
			}
			else
			{
				Offsets::ADD_FAKE_CLONE(false);
				AddFakeClone = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!InvisiblePlayers)
			{
				Offsets::INVISIBLE_PLAYERS(true);
				InvisiblePlayers = true;
			}
			else
			{
				Offsets::INVISIBLE_PLAYERS(false);
				InvisiblePlayers = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!AutoLadder)
			{
				Offsets::AUTO_LADDER(true);
				AutoLadder = true;
			}
			else
			{
				Offsets::AUTO_LADDER(false);
				AutoLadder = false;
			}
		}

		if (CurrentOpt == 10)
		{
			if (!AirToWater)
			{
				Offsets::AIR_TO_WATER(true);
				AirToWater = true;
			}
			else
			{
				Offsets::AIR_TO_WATER(false);
				AirToWater = false;
			}
		}

		if (CurrentOpt == 11)
		{
			if (!MultiJumpV2)
			{
				Offsets::MULTI_JUMP_V2(true);
				MultiJumpV2 = true;
			}
			else
			{
				Offsets::MULTI_JUMP_V2(false);
				MultiJumpV2 = false;
			}
		}

		if (CurrentOpt == 12)
		{
			if (!SuicideMode)
			{
				Offsets::SUICIDE_MODE(true);
				SuicideMode = true;
			}
			else
			{
				Offsets::SUICIDE_MODE(false);
				SuicideMode = false;
			}
		}

		if (CurrentOpt == 13)
		{
			NonHostPage4 = false;
			NonHostPage5 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "NON HOST MENU 3"

	if (NonHostPage3)
	{
		if (CurrentOpt == 0)
		{
			if (!Lookforback)
			{
				Offsets::LOOK_FORBACK(true);
				Lookforback = true;
			}
			else
			{
				Offsets::LOOK_FORBACK(false);
				Lookforback = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!CameraDownR3)
			{
				Offsets::CAMERA_DOWN(true);
				CameraDownR3 = true;
			}
			else
			{
				Offsets::CAMERA_DOWN(false);
				CameraDownR3 = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!BetterTime)
			{
				Offsets::BETTER_TIME(true);
				BetterTime = true;
			}
			else
			{
				Offsets::BETTER_TIME(false);
				BetterTime = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!SeeOutMap)
			{
				Offsets::SEE_OUT_MAP(true);
				SeeOutMap = true;
			}
			else
			{
				Offsets::SEE_OUT_MAP(false);
				SeeOutMap = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!Scaffold)
			{
				Offsets::SCAFFOLD(true);
				Scaffold = true;
			}
			else
			{
				Offsets::SCAFFOLD(false);
				Scaffold = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!DayAndNight)
			{
				Offsets::DAY_NIGHT(true);
				DayAndNight = true;
			}
			else
			{
				Offsets::DAY_NIGHT(false);
				DayAndNight = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!ESPPlayers)
			{
				Offsets::ESP_PLAYERS(true);
				ESPPlayers = true;
			}
			else
			{
				Offsets::ESP_PLAYERS(false);
				ESPPlayers = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!CanFly)
			{
				Offsets::CAN_FLY(true);
				CanFly = true;
			}
			else
			{
				Offsets::CAN_FLY(false);
				CanFly = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!NoColissionEntity)
			{
				Offsets::NO_COLISSION_ENTITY(true);
				NoColissionEntity = true;
			}
			else
			{
				Offsets::NO_COLISSION_ENTITY(false);
				NoColissionEntity = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!AlwaysOnCrouch)
			{
				Offsets::ALWAYS_CROUCH(true);
				AlwaysOnCrouch = true;
			}
			else
			{
				Offsets::ALWAYS_CROUCH(false);
				AlwaysOnCrouch = false;
			}
		}

		if (CurrentOpt == 10)
		{
			if (!GetPlayersIDs)
			{
				Offsets::GET_PLAYERS_IDS(true);
				GetPlayersIDs = true;
			}
			else
			{
				Offsets::GET_PLAYERS_IDS(false);
				GetPlayersIDs = false;
			}
		}

		if (CurrentOpt == 11)
		{
			if (!PlayersOnElytra)
			{
				Offsets::PLAYERS_ON_ELYTRA(true);
				PlayersOnElytra = true;
			}
			else
			{
				Offsets::PLAYERS_ON_ELYTRA(false);
				PlayersOnElytra = false;
			}
		}

		if (CurrentOpt == 12)
		{
			if (!WaterSlowDown)
			{
				Offsets::WATER_SLOWDOWN(true);
				WaterSlowDown = true;
			}
			else
			{
				Offsets::WATER_SLOWDOWN(false);
				WaterSlowDown = false;
			}
		}

		if (CurrentOpt == 13)
		{
			NonHostPage3 = false;
			NonHostPage4 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "NON HOST MENU 2"

	if (NonHostPage2)
	{
		if (CurrentOpt == 0)
		{
			if (!InfiniteCraft)
			{
				Offsets::INFINITE_CRAFT(true);
				InfiniteCraft = true;
			}
			else
			{
				Offsets::INFINITE_CRAFT(false);
				InfiniteCraft = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!HudMiniGame)
			{
				Offsets::HUD_MINI_GAME(true);
				HudMiniGame = true;
			}
			else
			{
				Offsets::HUD_MINI_GAME(false);
				HudMiniGame = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!AntiTeleport)
			{
				Offsets::ANTI_TELEPORT(true);
				AntiTeleport = true;
			}
			else
			{
				Offsets::ANTI_TELEPORT(false);
				AntiTeleport = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!UFOMode)
			{
				//Offsets::UFO_MODE(true);
				mc->theMinecraft->cMultiplayerLocalPlayer->noClip = true;
				Offsets::CAN_FLY(true);
				UFOMode = true;
			}
			else
			{
				//Offsets::UFO_MODE(false);
				mc->theMinecraft->cMultiplayerLocalPlayer->noClip = false;
				Offsets::CAN_FLY(false);
				UFOMode = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!AntiAFK)
			{
				Offsets::ANTI_AFK(true);
				AntiAFK = true;
			}
			else
			{
				Offsets::ANTI_AFK(false);
				AntiAFK = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!SensibilityFast)
			{
				Offsets::SENSIBILITY_FAST(true);
				SensibilityFast = true;
			}
			else
			{
				Offsets::SENSIBILITY_FAST(false);
				SensibilityFast = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!SensibilityExtrem)
			{
				Offsets::SENSIBILITY_EXTREM(true);
				SensibilityExtrem = true;
			}
			else
			{
				Offsets::SENSIBILITY_EXTREM(false);
				SensibilityExtrem = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!WalkAlone)
			{
				Offsets::WALK_ALONE(true);
				WalkAlone = true;
			}
			else
			{
				Offsets::WALK_ALONE(false);
				WalkAlone = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!NameOverHead)
			{
				Offsets::NAME_OVER_HEAD(true);
				NameOverHead = true;
			}
			else
			{
				Offsets::NAME_OVER_HEAD(false);
				NameOverHead = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!NameOverHeadV2)
			{
				Offsets::NAME_OVER_HEAD_V2(true);
				NameOverHeadV2 = true;
			}
			else
			{
				Offsets::NAME_OVER_HEAD_V2(false);
				NameOverHeadV2 = false;
			}
		}

		if (CurrentOpt == 10)
		{
			if (!StaticMovement)
			{
				Offsets::STATIC_MOVEMENT(true);
				StaticMovement = true;
			}
			else
			{
				Offsets::STATIC_MOVEMENT(false);
				StaticMovement = false;
			}
		}

		if (CurrentOpt == 11)
		{
			if (!WalkInSky)
			{
				Offsets::WALK_IN_SKY(true);
				WalkInSky = true;
			}
			else
			{
				Offsets::WALK_IN_SKY(false);
				WalkInSky = false;
			}
		}

		if (CurrentOpt == 12)
		{
			if (!GravityMoon)
			{
				Offsets::GRAVITY_MOON(true);
				GravityMoon = true;
			}
			else
			{
				Offsets::GRAVITY_MOON(false);
				GravityMoon = false;
			}
		}

		if (CurrentOpt == 13)
		{
			NonHostPage2 = false;
			NonHostPage3 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "NON HOST MENU 1"

	if (NonHostPage1)
	{
		if (CurrentOpt == 0)
		{
			if (!SwimFly)
			{
				Offsets::SWIM_FLY(true);
				SwimFly = true;
			}
			else
			{
				Offsets::SWIM_FLY(false);
				SwimFly = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!MovementSwim)
			{
				Offsets::MOVEMENT_SWIM(true);
				MovementSwim = true;
			}
			else
			{
				Offsets::MOVEMENT_SWIM(false);
				MovementSwim = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!SwimGlitch)
			{
				Offsets::SWIM_GLITCH(true);
				SwimGlitch = true;
			}
			else
			{
				Offsets::SWIM_GLITCH(false);
				SwimGlitch = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!NoColission)
			{
				Offsets::NO_COLISSION_BYPASS(true);
				NoColission = true;
			}
			else
			{
				Offsets::NO_COLISSION_BYPASS(false);
				NoColission = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!ItemsIds)
			{
				Offsets::ITEMS_IDS(true);
				ItemsIds = true;
			}
			else
			{
				Offsets::ITEMS_IDS(false);
				ItemsIds = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!AntiKick)
			{
				Offsets::ANTI_KICK(true);
				AntiKick = true;
			}
			else
			{
				Offsets::ANTI_KICK(false);
				AntiKick = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!InBlock)
			{
				Offsets::STUCK_IN_BLOCK(true);
				InBlock = true;
			}
			else
			{
				Offsets::STUCK_IN_BLOCK(false);
				InBlock = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!PositionView)
			{
				Offsets::CHANGE_POSITION_VIEW(true);
				PositionView = true;
			}
			else
			{
				Offsets::CHANGE_POSITION_VIEW(false);
				PositionView = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!FunnySound)
			{
				Offsets::FUNNY_SOUND(true);
				FunnySound = true;
			}
			else
			{
				Offsets::FUNNY_SOUND(false);
				FunnySound = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!FloatUp)
			{
				Offsets::FLOAT_UP(true);
				FloatUp = true;
			}
			else
			{
				Offsets::FLOAT_UP(false);
				FloatUp = false;
			}
		}

		if (CurrentOpt == 10)
		{
			if (!ESPChests)
			{
				Offsets::ESP_CHESTS(true);
				ESPChests = true;
			}
			else
			{
				Offsets::ESP_CHESTS(false);
				ESPChests = false;
			}
		}

		if (CurrentOpt == 11)
		{
			if (!CameraDown)
			{
				Offsets::CAMERA_DOWN(true);
				CameraDown = true;
			}
			else
			{
				Offsets::CAMERA_DOWN(false);
				CameraDown = false;
			}
		}

		if (CurrentOpt == 12)
		{
			if (!InstantMine)
			{
				Offsets::INSTANT_MINE(true);
				InstantMine = true;
			}
			else
			{
				Offsets::INSTANT_MINE(false);
				InstantMine = false;
			}
		}

		if (CurrentOpt == 13)
		{
			NonHostPage1 = false;
			NonHostPage2 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "NON HOST MENU"

	if (NonHostPage)
	{
		if (CurrentOpt == 0)
		{
			if (!SuperSpeed)
			{
				Offsets::SUPER_SPEED(true);
				SuperSpeed = true;
			}
			else
			{
				Offsets::SUPER_SPEED(false);
				SuperSpeed = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!SuperSpeedV2)
			{
				Offsets::SUPER_SPEED_V2(true);
				SuperSpeedV2 = true;
			}
			else
			{
				Offsets::SUPER_SPEED_V2(false);
				SuperSpeedV2 = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!SuperSpeedV3)
			{
				Offsets::SUPER_SPEED_V3(true);
				SuperSpeedV3 = true;
			}
			else
			{
				Offsets::SUPER_SPEED_V3(false);
				SuperSpeedV3 = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!SuperSpeedV4)
			{
				Offsets::SUPER_SPEED_V4(true);
				SuperSpeedV4 = true;
			}
			else
			{
				Offsets::SUPER_SPEED_V4(false);
				SuperSpeedV4 = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!MultiJump)
			{
				Offsets::MULTI_JUMP(true);
				MultiJump = true;
			}
			else
			{
				Offsets::MULTI_JUMP(false);
				MultiJump = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!JumpForBuild)
			{
				Offsets::JUMP_FOR_BUILD(true);
				JumpForBuild = true;
			}
			else
			{
				Offsets::JUMP_FOR_BUILD(false);
				JumpForBuild = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!JumpInSky)
			{
				Offsets::JUMP_IN_SKY(true);
				JumpInSky = true;
			}
			else
			{
				Offsets::JUMP_IN_SKY(false);
				JumpInSky = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!SuperJump)
			{
				Offsets::SUPER_JUMP(true);
				SuperJump = true;
			}
			else
			{
				Offsets::SUPER_JUMP(false);
				SuperJump = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!SuperJumpV2)
			{
				Offsets::SUPER_JUMP_V2(true);
				SuperJumpV2 = true;
			}
			else
			{
				Offsets::SUPER_JUMP_V2(false);
				SuperJumpV2 = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!JumpForward)
			{
				Offsets::JUMP_FORWARD(true);
				JumpForward = true;
			}
			else
			{
				Offsets::JUMP_FORWARD(false);
				JumpForward = false;
			}
		}

		if (CurrentOpt == 10)
		{
			if (!RemoveJump)
			{
				Offsets::REMOVE_JUMP(true);
				RemoveJump = true;
			}
			else
			{
				Offsets::REMOVE_JUMP(false);
				RemoveJump = false;
			}
		}

		if (CurrentOpt == 11)
		{
			if (!JumpSpeed)
			{
				Offsets::JUMP_SPEED(true);
				JumpSpeed = true;
			}
			else
			{
				Offsets::JUMP_SPEED(false);
				JumpSpeed = false;
			}
		}

		if (CurrentOpt == 12)
		{
			if (!FlyModeX)
			{
				Offsets::FLY_MODE_X(true);
				FlyModeX = true;
			}
			else
			{
				Offsets::FLY_MODE_X(false);
				FlyModeX = false;
			}
		}

		if (CurrentOpt == 13)
		{
			NonHostPage = false;
			NonHostPage1 = true;
			CurrentOpt = 0;
		}

	}

#pragma endregion

    #pragma region "HOST MENU 4"

	if (HostPage4)
	{
		if (CurrentOpt == 0)
		{
			if (!TntGoInGround)
			{
				Offsets::TNT_GO_IN_GROUND(true);
				TntGoInGround = true;
			}
			else
			{
				Offsets::TNT_GO_IN_GROUND(false);
				TntGoInGround = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!TntSoundOff)
			{
				Offsets::TNT_SOUND_OFF(true);
				TntSoundOff = true;
			}
			else
			{
				Offsets::TNT_SOUND_OFF(false);
				TntSoundOff = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!BigCreeper)
			{
				Offsets::BIG_CREEPER(true);
				BigCreeper = true;
			}
			else
			{
				Offsets::BIG_CREEPER(false);
				BigCreeper = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!CreeperNuclear)
			{
				Offsets::CREEPER_NUCLEAR(true);
				CreeperNuclear = true;
			}
			else
			{
				Offsets::CREEPER_NUCLEAR(false);
				CreeperNuclear = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!CreeperFire)
			{
				Offsets::CREEPER_FIRE(true);
				CreeperFire = true;
			}
			else
			{
				Offsets::CREEPER_FIRE(false);
				CreeperFire = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!DisableTotem)
			{
				Offsets::DISABLE_TOTEM(true);
				DisableTotem = true;
			}
			else
			{
				Offsets::DISABLE_TOTEM(false);
				DisableTotem = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!GlitchDeadEntity)
			{
				Offsets::GLITCHED_DEAD_ENTITY(true);
				GlitchDeadEntity = true;
			}
			else
			{
				Offsets::GLITCHED_DEAD_ENTITY(false);
				GlitchDeadEntity = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!PlayersInfos)
			{
				PlayersInfos = true;
			}
			else
			{
				PlayersInfos = false;
			}
		}
	}

#pragma endregion

    #pragma region "HOST MENU 3"

	if (HostPage3)
	{
		if (CurrentOpt == 0)
		{
			if (!EntityGodMode)
			{
				Offsets::ENTITY_GOD_MODE(true);
				EntityGodMode = true;
			}
			else
			{
				Offsets::ENTITY_GOD_MODE(false);
				EntityGodMode = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!RegenerateHealth)
			{
				Offsets::REGENERATE_HEART(true);
				RegenerateHealth = true;
			}
			else
			{
				Offsets::REGENERATE_HEART(false);
				RegenerateHealth = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!LockGameMode)
			{
				Offsets::LOCK_GAMEMODE(true);
				LockGameMode = true;
			}
			else
			{
				Offsets::LOCK_GAMEMODE(false);
				LockGameMode = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!LockWeather)
			{
				Offsets::LOCK_WEATHER(true);
				LockWeather = true;
			}
			else
			{
				Offsets::LOCK_WEATHER(false);
				LockWeather = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!FastBow)
			{
				Offsets::FAST_BOW(true);
				FastBow = true;
			}
			else
			{
				Offsets::FAST_BOW(false);
				FastBow = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!DirectionArrows)
			{
				Offsets::DIRECTION_ARROWS(true);
				DirectionArrows = true;
			}
			else
			{
				Offsets::DIRECTION_ARROWS(false);
				DirectionArrows = false;
			}
		}

		if (CurrentOpt == 6)
		{

		}

		if (CurrentOpt == 7)
		{
			if (!TotemGiveHealth)
			{
				Offsets::TOTEM_GIVE_HEALTH(true);
				TotemGiveHealth = true;
			}
			else
			{
				Offsets::TOTEM_GIVE_HEALTH(false);
				TotemGiveHealth = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!TntNuclear)
			{
				Offsets::TNT_NUCLEAR(true);
				TntNuclear = true;
			}
			else
			{
				Offsets::TNT_NUCLEAR(false);
				TntNuclear = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!TntBigParticles)
			{
				Offsets::TNT_BIG_PARTICLES(true);
				TntBigParticles = true;
			}
			else
			{
				Offsets::TNT_BIG_PARTICLES(false);
				TntBigParticles = false;
			}
		}

		if (CurrentOpt == 10)
		{
			if (!TntFlying)
			{
				Offsets::TNT_FLYING(true);
				TntFlying = true;
			}
			else
			{
				Offsets::TNT_FLYING(false);
				TntFlying = false;
			}
		}

		if (CurrentOpt == 11)
		{
			if (!TntInstantExplode)
			{
				Offsets::TNT_INSTANT_EXPLODE(true);
				TntInstantExplode = true;
			}
			else
			{
				Offsets::TNT_INSTANT_EXPLODE(false);
				TntInstantExplode = false;
			}
		}

		if (CurrentOpt == 12)
		{
			if (!DisableSpawnMobs)
			{
				Offsets::DISABLE_SPAWN_MOBS(true);
				DisableSpawnMobs = true;
			}
			else
			{
				Offsets::DISABLE_SPAWN_MOBS(false);
				DisableSpawnMobs = false;
			}
		}

		if (CurrentOpt == 13)
		{
			HostPage3 = false;
			HostPage4 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "HOST MENU 2"

	if (HostPage2)
	{
		if (CurrentOpt == 0)
		{
			if (!NoHitDelay)
			{
				Offsets::NO_DELAY_HIT(true);
				NoHitDelay = true;
			}
			else
			{
				Offsets::NO_DELAY_HIT(false);
				NoHitDelay = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!BypassMaxItems)
			{
				Offsets::BYPASS_MAX_ITEMS(true);
				BypassMaxItems = true;
			}
			else
			{
				Offsets::BYPASS_MAX_ITEMS(false);
				BypassMaxItems = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!InfiniteFood)
			{
				Offsets::INFINITE_FOOD(true);
				InfiniteFood = true;
			}
			else
			{
				Offsets::INFINITE_FOOD(false);
				InfiniteFood = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!MobIgnoreMe)
			{
				Offsets::MOBS_IGNORE_ME(true);
				MobIgnoreMe = true;
			}
			else
			{
				Offsets::MOBS_IGNORE_ME(false);
				MobIgnoreMe = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!DisablePortals)
			{
				Offsets::DISABLE_PORTALS(true);
				DisablePortals = true;
			}
			else
			{
				Offsets::DISABLE_PORTALS(false);
				DisablePortals = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!KillOnRespawn)
			{
				Offsets::KILL_ON_RESPAWN(true);
				KillOnRespawn = true;
			}
			else
			{
				Offsets::KILL_ON_RESPAWN(false);
				KillOnRespawn = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!FreezeAllEntity)
			{
				Offsets::FREEZE_ALL_ENTITY(true);
				FreezeAllEntity = true;
			}
			else
			{
				Offsets::FREEZE_ALL_ENTITY(false);
				FreezeAllEntity = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!StopEndermanTP)
			{
				Offsets::STOP_ENDERMAN_TP(true);
				StopEndermanTP = true;
			}
			else
			{
				Offsets::STOP_ENDERMAN_TP(false);
				StopEndermanTP = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!IgnoringPressure)
			{
				Offsets::IGNORING_PRESSURE(true);
				IgnoringPressure = true;
			}
			else
			{
				Offsets::IGNORING_PRESSURE(false);
				IgnoringPressure = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!AllEnchant)
			{
				Offsets::ALL_ENCHANT(true);
				AllEnchant = true;
			}
			else
			{
				Offsets::ALL_ENCHANT(false);
				AllEnchant = false;
			}
		}

		if (CurrentOpt == 10)
		{
			if (!ItemsOnHead)
			{
				Offsets::ITEMS_ON_HEAD(true);
				ItemsOnHead = true;
			}
			else
			{
				Offsets::ITEMS_ON_HEAD(false);
				ItemsOnHead = false;
			}
		}

		if (CurrentOpt == 11)
		{
			if (!StopBoat)
			{
				Offsets::STOP_BOAT(true);
				StopBoat = true;
			}
			else
			{
				Offsets::STOP_BOAT(false);
				StopBoat = false;
			}
		}

		if (CurrentOpt == 12)
		{
			if (!NoWeb)
			{
				Offsets::NO_WEB(true);
				NoWeb = true;
			}
			else
			{
				Offsets::NO_WEB(false);
				NoWeb = false;
			}
		}

		if (CurrentOpt == 13)
		{
			HostPage2 = false;
			HostPage3 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "HOST MENU 1"

	if (HostPage1)
	{
		if (CurrentOpt == 0)
		{
			if (!StopArrows)
			{
				Offsets::STOP_ARROWS(true);
				StopArrows = true;
			}
			else
			{
				Offsets::STOP_ARROWS(false);
				StopArrows = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!RemoveArrows)
			{
				Offsets::REMOVE_ARROWS(true);
				RemoveArrows = true;
			}
			else
			{
				Offsets::STOP_ARROWS(false);
				RemoveArrows = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!PotionsFlying)
			{
				Offsets::POTIONS_FLYING(true);
				PotionsFlying = true;
			}
			else
			{
				Offsets::POTIONS_FLYING(false);
				PotionsFlying = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!PotionsNoGravity)
			{
				Offsets::POTIONS_NO_GRAVITY(true);
				PotionsNoGravity = true;
			}
			else
			{
				Offsets::POTIONS_NO_GRAVITY(false);
				PotionsNoGravity = false;
			}
		}

		if (CurrentOpt == 4)
		{
			if (!InfinitePickupItems)
			{
				Offsets::INFINITE_PICKUP_ITEMS(true);
				InfinitePickupItems = true;
			}
			else
			{
				Offsets::INFINITE_PICKUP_ITEMS(false);
				InfinitePickupItems = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!MaxPickupItems)
			{
				Offsets::MAX_PICKUP_ITEMS(true);
				MaxPickupItems = true;
			}
			else
			{
				Offsets::MAX_PICKUP_ITEMS(false);
				MaxPickupItems = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!InfiniteBlocks)
			{
				Offsets::INFINITE_BLOCKS(true);
				InfiniteBlocks = true;
			}
			else
			{
				Offsets::INFINITE_BLOCKS(false);
				InfiniteBlocks = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!BurnInWater)
			{
				Offsets::BURN_IN_WATER(true);
				BurnInWater = true;
			}
			else
			{
				Offsets::BURN_IN_WATER(false);
				BurnInWater = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!RemoveFire)
			{
				Offsets::REMOVE_FIRE(true);
				RemoveFire = true;
			}
			else
			{
				Offsets::REMOVE_FIRE(false);
				RemoveFire = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!CreativeSlot)
			{
				Offsets::CREATIVE_SLOT(true);
				CreativeSlot = true;
			}
			else
			{
				Offsets::CREATIVE_SLOT(false);
				CreativeSlot = false;
			}
		}

		if (CurrentOpt == 10)
		{
			if (!SurvivalSlot)
			{
				Offsets::SURVIVAL_SLOT(true);
				SurvivalSlot = true;
			}
			else
			{
				Offsets::SURVIVAL_SLOT(false);
				SurvivalSlot = false;
			}
		}

		if (CurrentOpt == 11)
		{
			if (!KillSpawnEntity)
			{
				Offsets::KILL_SPAWN_ENTITY(true);
				KillSpawnEntity = true;
			}
			else
			{
				Offsets::KILL_SPAWN_ENTITY(false);
				KillSpawnEntity = false;
			}
		}

		if (CurrentOpt == 12)
		{
			if (!StopBlockGravity)
			{
				Offsets::STOP_BLOCKS_GRAVITY(true);
				StopBlockGravity = true;
			}
			else
			{
				Offsets::STOP_BLOCKS_GRAVITY(false);
				StopBlockGravity = false;
			}
		}

		if (CurrentOpt == 13)
		{
			HostPage1 = false;
			HostPage2 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "HOST MENU"

	if (HostPage)
	{
		if (CurrentOpt == 0)
		{
			if (!GodMode)
			{
				Offsets::GOD_MODE(true);
				GodMode = true;
			}
			else
			{
				Offsets::GOD_MODE(false);
				GodMode = false;
			}
		}

		if (CurrentOpt == 1)
		{
			if (!DemiGodMode)
			{
				Offsets::DEMI_GOD_MODE(true);
				DemiGodMode = true;
			}
			else
			{
				Offsets::DEMI_GOD_MODE(false);
				DemiGodMode = false;
			}
		}

		if (CurrentOpt == 2)
		{
			if (!InstantDamage)
			{
				Offsets::INSTANT_DAMAGE(true);
				InstantDamage = true;
			}
			else
			{
				Offsets::INSTANT_DAMAGE(false);
				InstantDamage = false;
			}
		}

		if (CurrentOpt == 3)
		{
			if (!CriticalHit)
			{
				Offsets::CRITICAL_HIT(true);
				CriticalHit = true;
			}
			else
			{
				Offsets::CRITICAL_HIT(false);
				CriticalHit = false;
			}
		}


		if (CurrentOpt == 4)
		{
			if (!KillInCreative)
			{
				Offsets::KILL_IN_CREATIVE(true);
				KillInCreative = true;
			}
			else
			{
				Offsets::KILL_IN_CREATIVE(false);
				KillInCreative = false;
			}
		}

		if (CurrentOpt == 5)
		{
			if (!NoDamageHit)
			{
				Offsets::NO_DAMAGE_HIT(true);
				NoDamageHit = true;
			}
			else
			{
				Offsets::NO_DAMAGE_HIT(false);
				NoDamageHit = false;
			}
		}

		if (CurrentOpt == 6)
		{
			if (!Knockback)
			{
				Offsets::KNOCKBACK(true);
				Knockback = true;
			}
			else
			{
				Offsets::KNOCKBACK(false);
				Knockback = false;
			}
		}

		if (CurrentOpt == 7)
		{
			if (!AntiKnockback)
			{
				Offsets::ANTI_KNOCKBACK(true);
				AntiKnockback = true;
			}
			else
			{
				Offsets::ANTI_KNOCKBACK(false);
				AntiKnockback = false;
			}
		}

		if (CurrentOpt == 8)
		{
			if (!ReverseKnockback)
			{
				Offsets::REVERSE_KNOCKBACK(true);
				ReverseKnockback = true;
			}
			else
			{
				Offsets::REVERSE_KNOCKBACK(false);
				ReverseKnockback = false;
			}
		}

		if (CurrentOpt == 9)
		{
			if (!DropFarItems)
			{
				Offsets::DROP_ITEMS_FAR(true);
				DropFarItems = true;
			}
			else
			{
				Offsets::DROP_ITEMS_FAR(false);
				DropFarItems = false;
			}
		}

		if (CurrentOpt == 10)
		{
			if (!MaxXPLevel)
			{
				Offsets::MAX_LEVEL_XP(true);
				MaxXPLevel = true;
			}
			else
			{
				Offsets::MAX_LEVEL_XP(false);
				MaxXPLevel = false;
			}
		}

		if (CurrentOpt == 11)
		{
			if (!WaterJump)
			{
				Offsets::WATER_JUMP(true);
				WaterJump = true;
			}
			else
			{
				Offsets::WATER_JUMP(false);
				WaterJump = false;
			}
		}

		if (CurrentOpt == 12)
		{
			if (!DriftBoat)
			{
				Offsets::DRIFT_BOAT(true);
				DriftBoat = true;
			}
			else
			{
				Offsets::DRIFT_BOAT(false);
				DriftBoat = false;
			}
		}

		if (CurrentOpt == 13)
		{
			HostPage = false;
			HostPage1 = true;
			CurrentOpt = 0;
		}
	}

#pragma endregion

    #pragma region "MAIN MENU"

	if (MainMenu)
	{
		if (CurrentOpt == 0)
		{
			MainMenu = false;
			HostPage = true;
			CurrentOpt = 0;
		}

		if (CurrentOpt == 1)
		{
			MainMenu = false;
			NonHostPage = true;
			CurrentOpt = 0;
		}

		if (CurrentOpt == 2)
		{
			MainMenu = false;
			PlayersOptions = true;
			CurrentOpt = 0;
		}

		if (CurrentOpt == 3)
		{
			MainMenu = false;
			WeathesMenu = true;
			CurrentOpt = 0;
		}

		if (CurrentOpt == 4)
		{
			MainMenu = false;
			VisionMenu = true;
			CurrentOpt = 0;
		}

		if (CurrentOpt == 5)
		{
			MainMenu = false;
			NameChanger = true;
			CurrentOpt = 0;
		}

		if (CurrentOpt == 6)
		{
			MainMenu = false;
			GameEditorMenu = true;
			CurrentOpt = 0;
		}

		if (CurrentOpt == 7)
		{
			MainMenu = false;
			MiniGamePage = true;
			CurrentOpt = 0;
		}

		if (CurrentOpt == 8)
		{
			MainMenu = false;
			TeleportMenu = true;
			CurrentOpt = 0;
		}

		if (CurrentOpt == 9)
		{
			MainMenu = false;
			SettingsMenu = true;
			CurrentOpt = 0;
		}

		if (CurrentOpt == 10)
		{
			MainMenu = false;
			CreditsMenu = true;
			CurrentOpt = 0;
		}

		if (devmenu)
		{
			if (CurrentOpt == 11)
			{
				MainMenu = false;
				DeveloperMenu = true;
				CurrentOpt = 0;
			}
		}
	}

#pragma endregion
}