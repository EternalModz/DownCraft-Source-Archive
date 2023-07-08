
//X = < >
//Y = /\ \/

#pragma region "Back Sub Menu"

 void BackSubMenu()
 {
	 if (MainMenu)
	 {
		 Opened = false;
		 Closed = true;
	 }

	 if (HostPage)
	 {
		 HostPage = false;
		 MainMenu = true;
	 }

	 if (HostPage1)
	 {
		 HostPage1 = false;
		 HostPage = true;
	 }

	 if (HostPage2)
	 {
		 HostPage2 = false;
		 HostPage1 = true;
	 }

	 if (HostPage3)
	 {
		 HostPage3 = false;
		 HostPage2 = true;
	 }

	 if (NonHostPage)
	 {
		 NonHostPage = false;
		 MainMenu = true;
	 }

	 if (NonHostPage1)
	 {
		 NonHostPage1 = false;
		 NonHostPage = true;
	 }

	 if (NonHostPage2)
	 {
		 NonHostPage2 = false;
		 NonHostPage1 = true;
	 }

	 if (NonHostPage3)
	 {
		 NonHostPage3 = false;
		 NonHostPage2 = true;
	 }

	 if (NonHostPage4)
	 {
		 NonHostPage4 = false;
		 NonHostPage3 = true;
	 }

	 if (NonHostPage5)
	 {
		 NonHostPage5 = false;
		 NonHostPage4 = true;
	 }

	 if (PlayersOptions)
	 {
		 PlayersOptions = false;
		 MainMenu = true;
	 }

	 if (WeathesMenu)
	 {
		 WeathesMenu = false;
		 MainMenu = true;
	 }

	 if (VisionMenu)
	 {
		 VisionMenu = false;
		 MainMenu = true;
	 }

	 if (VisionMenu1)
	 {
		 VisionMenu1 = false;
		 VisionMenu = true;
	 }

	 if (VisionMenu2)
	 {
		 VisionMenu2 = false;
		 VisionMenu1 = true;
	 }

	 if (VisionMenu3)
	 {
		 VisionMenu3 = false;
		 VisionMenu2 = true;
	 }

	 if (VisionMenu4)
	 {
		 VisionMenu4 = false;
		 VisionMenu3 = true;
	 }

	 if (VisionMenu5)
	 {
		 VisionMenu5 = false;
		 VisionMenu4 = true;
	 }

	 if (VisionMenu6)
	 {
		 VisionMenu6 = false;
		 VisionMenu5 = true;
	 }

	 if (ModulesMenu)
	 {
		 ModulesMenu = false;
		 MainMenu = true;
	 }

	 if (NameChanger)
	 {
		 NameChanger = false;
		 MainMenu = true;
	 }

	 if (GameEditorMenu)
	 {
		 GameEditorMenu = false;
		 MainMenu = true;
	 }

	 if (EggChangerMenu)
	 {
		 EggChangerMenu = false;
		 GameEditorMenu = true;
	 }

	 if (BlockChangerMenu)
	 {
		 BlockChangerMenu = false;
		 GameEditorMenu = true;
	 }

	 if (BlockChangerMenu1)
	 {
		 BlockChangerMenu1 = false;
		 BlockChangerMenu = true;
	 }

	 if (BlockChangerMenu2)
	 {
		 BlockChangerMenu2 = false;
		 BlockChangerMenu1 = true;
	 }

	 if (MiniGamePage)
	 {
		 MiniGamePage = false;
		 MainMenu = true;
	 }

	 if (TPMiniGame)
	 {
		 TPMiniGame = false;
		 MiniGamePage = true;
	 }

	 if (TeleportMenu)
	 {
		 TeleportMenu = false;
		 MainMenu = true;
	 }

	 if (SettingsMenu)
	 {
		 SettingsMenu = false;
		 MainMenu = true;
	 }

	 if (EditMenu)
	 {
		 EditMenu = false;
		 SettingsMenu = true;
	 }

	 if (ThemeColors)
	 {
		 ThemeColors = false;
		 SettingsMenu = true;
	 }

	 if (DebugMenu)
	 {
		 DebugMenu = false;
		 SettingsMenu = true;
	 }

	 if (DebugTextMenu)
	 {
		 DebugTextMenu = false;
		 DebugMenu = true;
	 }

	 if (DebugHudMenu)
	 {
		 DebugHudMenu = false;
		 DebugMenu = true;
	 }

	 if (DebugHudAlphaMenu)
	 {
		 DebugHudAlphaMenu = false;
		 DebugMenu = true;
	 }

	 if (DebugDrawlineMenu)
	 {
		 DebugDrawlineMenu = false;
		 DebugMenu = true;
	 }

	 if (CustomImageMenu)
	 {
		 CustomImageMenu = false;
		 SettingsMenu = true;
	 }

	 if (MicsSettings)
	 {
		 MicsSettings = false;
		 SettingsMenu = true;
	 }

	 if (MicsSettings2)
	 {
		 MicsSettings2 = false;
		 MicsSettings = true;
	 }

	 if (CrosshairMenu)
	 {
		 CrosshairMenu = false;
		 SettingsMenu = true;
	 }

	 if (ShowMenu)
	 {
		 ShowMenu = false;
		 SettingsMenu = true;
	 }

	 if (PlayerOptionsMenu)
	 {
		 PlayerOptionsMenu = false;
		 MainMenu = true;
	 }

	 if (DrawHeadLogoMenu)
	 {
		 DrawHeadLogoMenu = false;
		 SettingsMenu = true;
	 }

	 if (CreditsMenu)
	 {
		 CreditsMenu = false;
		 MainMenu = true;
	 }

	 if (ConfigMenu)
	 {
		 ConfigMenu = false;
		 MainMenu = true;
	 }

	 if (DeveloperMenu)
	 {
		 DeveloperMenu = false;
		 MainMenu = true;
	 }
 }

#pragma endregion

#pragma region "Scroll"

 void Scroll()
 {
	 int wI = 0;
	 keyPressed[wI] = false;

	 if (UsableMenu)
	 {
		 if (Buttons::IsMCButtonPressed(Buttons::L1) && Buttons::IsMCButtonPressed(Buttons::R3))
		 {
			 if (scrollWait(firstWaitTime, waitTime, wI))
			 {
				 if (OpenMenu)
				 {
					 OpenMenu = false;
				 }
				 else
				 {
					 OpenMenu = true;
				 }
				 return;
			 }
		 }

		 if (!OpenMenu)
		 {
			 if (Buttons::IsMCButtonPressed(Buttons::L1) && Buttons::IsMCButtonPressed(Buttons::UP))
			 {
				 if (UsableMenu)
				 {
					 Opened = true;
					 OpenMenu = true;
					 MainMenu = true;
					 SlideOpenMenu();
				 }
			 }
		 }
	 }

	 if (OpenMenu)
	 {
		 if (Buttons::IsMCButtonPressed(Buttons::UP))
		 {
			 if (scrollWait(firstWaitTime, waitTime, wI))
			 {
				 CurrentOpt = CurrentOpt - 1;
				 PlayUISound(SoundEvent::SCROLL);
				 return;
			 }
		 }

		 if (Buttons::IsMCButtonPressed(Buttons::DOWN))
		 {
			 if (scrollWait(firstWaitTime, waitTime, wI))
			 {
				 CurrentOpt = CurrentOpt + 1;
				 PlayUISound(SoundEvent::SCROLL);
				 return;
			 }
		 }

		 int fix = MaxOption;
		 fix -= 1;

		 if (CurrentOpt > fix)
		 {
			 CurrentOpt = 0;
		 }

		 if (CurrentOpt < 0)
		 {
			 CurrentOpt = fix;
		 }

		 if (Buttons::IsMCButtonPressed(Buttons::X))
		 {
			 if (scrollWait(firstWaitTime, waitTime, wI))
			 {
				 Options();
				 PlayUISound(SoundEvent::PRESS);
				 return;
			 }
		 }

		 if (Buttons::IsMCButtonPressed(Buttons::O))
		 {
			 if (scrollWait(firstWaitTime, waitTime, wI))
			 {
				 BackSubMenu();
				 CurrentOpt = 0;
				 CurrentIndex = 0;
				 PlayUISound(SoundEvent::BACK);
				 return;
			 }
		 }

		 if (!keyPressed[wI])
		 {
			 lockFirst[wI] = false;
			 freeFirst[wI] = true;
			 resetWait[wI] = true;
			 resetWait2[wI] = true;
		 }
	 }
 }

#pragma endregion

#pragma region "Render Menu"

 void RenderMenu()
 {
	 if (!OpenMenu)
	 {
		 *(int*)0x0155847C = 0x00000000;
	 }
	 else
	 {
		 AddInstruction();
		 *(int*)0x0155847C = 0x01000000;

		 if (MainMenu)
		 {
			 SubMenu::MainMenu();
		 }

		 if (HostPage)
		 {
			 SubMenu::HostMenu();
			 ChangeIntOptions(HostPage, 2, 0, 255, InstantDamage);
		 }

		 if (HostPage1)
		 {
			 SubMenu::HostMenu1();
		 }

		 if (HostPage2)
		 {
			 SubMenu::HostMenu2();
		 }

		 if (HostPage3)
		 {
			 SubMenu::HostMenu3();
		 }

		 if (NonHostPage)
		 {
			 SubMenu::NonHostMenu();
			 ChangeIntOptions(NonHostPage, 0, 0, 255, SuperSpeed);
		 }

		 if (NonHostPage1)
		 {
			 SubMenu::NonHostMenu1();
		 }

		 if (NonHostPage2)
		 {
			 SubMenu::NonHostMenu2();
		 }

		 if (NonHostPage3)
		 {
			 SubMenu::NonHostMenu3();
		 }

		 if (NonHostPage4)
		 {
			 SubMenu::NonHostMenu4();
		 }

		 if (NonHostPage5)
		 {
			 SubMenu::NonHostMenu5();
		 }

		 if (PlayersOptions)
		 {
			 SubMenu::PlayerOptionsMenu();
		 }

		 if (WeathesMenu)
		 {
			 SubMenu::WeatherOptionsMenu();
		 }

		 if (VisionMenu)
		 {
			 SubMenu::VisionsOptionsMenu();
		 }

		 if (VisionMenu1)
		 {
			 SubMenu::VisionsOptionsMenu1();
		 }

		 if (VisionMenu2)
		 {
			 SubMenu::VisionsOptionsMenu2();
			 ChangeIntOptions(VisionMenu2, 0, 58, 255, BigModel);
		 }

		 if (VisionMenu3)
		 {
			 SubMenu::VisionsOptionsMenu3();
		 }

		 if (VisionMenu4)
		 {
			 SubMenu::VisionsOptionsMenu4();
		 }

		 if (VisionMenu5)
		 {
			 SubMenu::VisionsOptionsMenu5();
		 }

		 if (VisionMenu6)
		 {
			 SubMenu::VisionsOptionsMenu6();
			 ChangeIntOptions(VisionMenu6, 3, 0, 255, ValueFOV);
		 }

		 if (ModulesMenu)
		 {
			 SubMenu::ModulesOptionsMenu();
			 ChangeIntOptions(ModulesMenu, 3, 0, 15, sizeNuker);
		 }

		 if (NameChanger)
		 {
			 SubMenu::NameChangerOptionsMenu();
		 }

		 if (GameEditorMenu)
		 {
			 SubMenu::GameEditorOptionsMenu();
		 }

		 if (EggChangerMenu)
		 {
			 SubMenu::EggChangerMenu();
		 }

		 if (BlockChangerMenu)
		 {
			 SubMenu::BlockChangerMenu();
		 }

		 if (BlockChangerMenu1)
		 {
			 SubMenu::BlockChangerMenu1();
		 }

		 if (BlockChangerMenu2)
		 {
			 SubMenu::BlockChangerMenu2();
		 }

		 if (MiniGamePage)
		 {
			 SubMenu::MiniGameOptionsMenu();
		 }

		 if (TPMiniGame)
		 {
			 SubMenu::TPMiniGameOptionsMenu();
		 }

		 if (TeleportMenu)
		 {
			 DrawRectangle(128, 53, 51, 30, UI::Color::BLACK);
			 GetTeleportXYZ();
			 SubMenu::TeleportOptionsMenu();
		 }

		 if (SettingsMenu)
		 {
			 SubMenu::SettingsMenu();
		 }

		 if (EditMenu)
		 {
			 SubMenu::EditMenu();
		 }

		 if (ThemeColors)
		 {
			 SubMenu::ThemeMenu();
		 }

		 if (DebugMenu)
		 {
			 Color BLACK_OPACITY{ 15, 15, 15, 200 };
			 SubMenu::DebugMenu();
			 //DrawRectangleAlpha(DebugHudX, DebugHudY, DebugHudW, DebugHudH, BLACK_OPACITY);
		 }

		 if (DebugTextMenu)
		 {
			 SubMenu::DebugTextMenu();
		 }

		 if (DebugHudMenu)
		 {
			 SubMenu::DebugHudMenu();
		 }

		 if (DebugHudAlphaMenu)
		 {
			 SubMenu::DebugHudAlphaMenu();
		 }

		 if (DebugDrawlineMenu)
		 {
			 SubMenu::DebugDrawLineMenu();
		 }

		 if (CustomImageMenu)
		 {
			 DrawTextWithRect(L"Before using this read this!", 80, 40, color(UI::Color::WHITE));
			 DrawTextWithRect(L"You need add a custom image in the MediaPS3.arc", 80, 50, color(UI::Color::WHITE));
			 DrawTextWithRect(L"Set your PS3 language to English (United State)", 80, 60, color(UI::Color::WHITE));
			 SubMenu::CustomImageMenu();
		 }

		 if (MicsSettings)
		 {
			 SubMenu::MicsMenu();
			 ChangeIntOptions(MicsSettings, 7, -5, 255, menulenght);
			 ChangeIntOptions(MicsSettings, 8, 0, 255, shadowBG);
		 }

		 if (MicsSettings2)
		 {
			 SubMenu::MicsMenu2();
		 }

		 if (ShowMenu)
		 {
			 SubMenu::ShowMenu();
		 }

		 if (CrosshairMenu)
		 {
			 SubMenu::CrosshairMenu();
			 ChangeIntOptions(CrosshairMenu, 1, 0, 5, crosshair_value);
		 }

		 if (DrawHeadLogoMenu)
		 {
			 SubMenu::DrawHeadLogoMenu();
			 ChangeIntOptions(DrawHeadLogoMenu, 0, 0, 3, DrawHeadPixelLogo);
		 }

		 if (PlayerOptionsMenu)
		 {
			 SubMenu::PlayerMenu();
		 }

		 if (CreditsMenu)
		 {
			 SubMenu::CreditsMenu();
		 }

		 if (ConfigMenu)
		 {
			 SubMenu::ConfigMenu();
		 }

		 if (DeveloperMenu)
		 {
			 SubMenu::DeveloperMenu();
		 }
	 }
 }

#pragma endregion