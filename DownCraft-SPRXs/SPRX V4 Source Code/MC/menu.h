
//X = < >
//Y = /\ \/

#pragma region "Get Functions"

void VersionText()
{
	if (devmenu)
	{
		DrawShadowText(L"DEV Edition", 98, 13, color(UI::Color::WHITE));
	}
	else
	{
		DrawShadowText(L"Public Edition", 98, 13, color(UI::Color::WHITE));
	}
}

void DEBUG_FUNCTIONS_MESSAGES()
{
	if (UI::Settings::ShowPosition)
	{
		DEBUG_FUNCTIONS_MESSAGE = 34;

		if (UI::Settings::ShowPING)
		{
			DEBUG_FUNCTIONS_MESSAGE = 44;

			if (UI::Settings::ShowChunks)
			{
				DEBUG_FUNCTIONS_MESSAGE = 54;

				if (UI::Settings::ShowResolution)
				{
					DEBUG_FUNCTIONS_MESSAGE = 64;

					if (UI::Settings::ShowCPURSX)
					{
						DEBUG_FUNCTIONS_MESSAGE = 74;
					}
				}
			}
		}
	}

	if (mc->theMinecraft->cMultiplayerLocalPlayer->isInWeb == true)
	{
		DrawShadowText(L"[In Web]", 20, DEBUG_FUNCTIONS_MESSAGE, color(UI::Color::WHITE));
	}
	if (mc->theMinecraft->cMultiplayerLocalPlayer->IsSprinting())
	{
		DrawShadowText(L"[Sprinting]", 20, DEBUG_FUNCTIONS_MESSAGE, color(UI::Color::WHITE));
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->IsSneaking())
	{
		DrawShadowText(L"[Sneaking]", 20, DEBUG_FUNCTIONS_MESSAGE, color(UI::Color::WHITE));
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->IsSpectator())
	{
		DrawShadowText(L"[Spectator]", 20, DEBUG_FUNCTIONS_MESSAGE, color(UI::Color::WHITE));
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->IsBurning())
	{
		DrawShadowText(L"[Burning]", 20, DEBUG_FUNCTIONS_MESSAGE, color(UI::Color::WHITE));
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->isInWater())
	{
		DrawShadowText(L"[In Water]", 20, DEBUG_FUNCTIONS_MESSAGE, color(UI::Color::WHITE));
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->fallDistance > 0)
	{
		DrawShadowText(L"[Falling]", 20, DEBUG_FUNCTIONS_MESSAGE, color(UI::Color::WHITE));
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->onGround == true)
	{
		DrawShadowText(L"[On Ground]", 20, DEBUG_FUNCTIONS_MESSAGE, color(UI::Color::WHITE));
	}
	else if (mc->theMinecraft->cMultiplayerLocalPlayer->isDead == true)
	{
		DrawShadowText(L"[Is Dead]", 20, DEBUG_FUNCTIONS_MESSAGE, color(UI::Color::WHITE));
	}
}

void Welcome_Message()
{
	if (UI::Settings::ShowPosition)
	{

	}
	else
	{
		if (UI::Settings::ShowPING)
		{
			UI_DrawText(L"Welcome: ", 20, 23, color(UI::Color::WHITE));
			drawText(PSN_NAME, 60, 23, color(UI::Color::ORANGE));
		}
		else
		{
			UI_DrawText(L"Welcome: ", 20, 24, color(UI::Color::WHITE));
			drawText(PSN_NAME, 60, 24, color(UI::Color::ORANGE));
		}
	}
}

void get_temperature(uint32_t a, uint32_t* b)
{
	system_call_2(383, (uint64_t)(uint32_t)a, (uint64_t)(uint32_t)b);
}

void get_temp()
{
	if (UI::Settings::ShowCPURSX)
	{
		if (frameTime(120, 1, false))
		{
			char systemperature[100];
			get_temperature(0, &cpu_t);//0 cpu
			get_temperature(1, &rsx_t);//1 rsx
			cpu_t = cpu_t >> 24;
			rsx_t = rsx_t >> 24;
		}

		char option[0x100];
		wchar_t woption[0x100];
		_sys_memset(option, 0, 0x100);
		_sys_memset(woption, 0, 0x200);
		_sys_snprintf(option, 0x100, "CPU :  %iC / RSX :  %iC", cpu_t, rsx_t);
		StringToWideCharacter(woption, option, strlen(option));
		drawRect(15, 61, 100, 13, UI::Color::BLACK);
		drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(woption), 20, 64, 0xFFFFFFFF, 0, 1);
	}
}


void GetPosition()
{
	if (UI::Settings::ShowPosition)
	{
		char option[0x100];
		wchar_t woption[0x100];
		_sys_memset(option, 0, 0x100);
		_sys_memset(woption, 0, 0x200);
		_sys_snprintf(option, 0x100, "Position: (%i, %i, %i)", (int)mc->theMinecraft->cMultiplayerLocalPlayer->posX - 1, (int)mc->theMinecraft->cMultiplayerLocalPlayer->posY + 1, (int)mc->theMinecraft->cMultiplayerLocalPlayer->posZ);
		StringToWideCharacter(woption, option, strlen(option));
		drawRect(15, 20, 115, 13, UI::Color::BLACK);
		drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(woption), 20, 23, 0xFFFFFFFF, 0, 1);
	}
}

void GetDebugXY()
{
	char option4[0x100];
	wchar_t woption4[0x100];
	_sys_memset(option4, 0, 0x100);
	_sys_memset(woption4, 0, 0x200);
	_sys_snprintf(option4, 0x100, "Text X: %i", (DebugTextX));
	StringToWideCharacter(woption4, option4, _sys_strlen(option4));
	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(woption4), 130, 55, 0xFFFFFFFF, 0, 1);

	char option8[0x100];
	wchar_t woption8[0x100];
	_sys_memset(option8, 0, 0x100);
	_sys_memset(woption8, 0, 0x200);
	_sys_snprintf(option8, 0x100, "Text Y: %i", (DebugTextY));
	StringToWideCharacter(woption8, option8, _sys_strlen(option8));
	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(woption8), 130, 65, 0xFFFFFFFF, 0, 1);

	char option16[0x100];
	wchar_t woption16[0x100];
	_sys_memset(option16, 0, 0x100);
	_sys_memset(woption16, 0, 0x200);
	_sys_snprintf(option16, 0x100, "Hud X: %i", (DebugHudX));
	StringToWideCharacter(woption16, option16, _sys_strlen(option16));
	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(woption16), 130, 75, 0xFFFFFFFF, 0, 1);

	char option26[0x100];
	wchar_t woption26[0x100];
	_sys_memset(option26, 0, 0x100);
	_sys_memset(woption26, 0, 0x200);
	_sys_snprintf(option26, 0x100, "Hud Y: %i", (DebugHudY));
	StringToWideCharacter(woption26, option26, _sys_strlen(option26));
	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(woption26), 130, 85, 0xFFFFFFFF, 0, 1);

	char option36[0x100];
	wchar_t woption36[0x100];
	_sys_memset(option36, 0, 0x100);
	_sys_memset(woption36, 0, 0x200);
	_sys_snprintf(option36, 0x100, "Hud W: %i", (DebugHudW));
	StringToWideCharacter(woption36, option36, _sys_strlen(option36));
	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(woption36), 130, 95, 0xFFFFFFFF, 0, 1);

	char option46[0x100];
	wchar_t woption46[0x100];
	_sys_memset(option46, 0, 0x100);
	_sys_memset(woption46, 0, 0x200);
	_sys_snprintf(option46, 0x100, "Hud H: %i", (DebugHudH));
	StringToWideCharacter(woption46, option46, _sys_strlen(option46));
	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(woption46), 130, 105, 0xFFFFFFFF, 0, 1);
}

void GetPingz()
{
	if (frameTime(30, 1, false))
	{
		_sys_memset(PING, 0, 0x100);
		_sys_memset(wPING, 0, 0x200);
		_sys_snprintf(PING, 0x100, "Ping: %i", (mc->FPS));
		StringToWideCharacter(wPING, PING, _sys_strlen(PING));
	}
}

void GetPing()
{
	if (UI::Settings::ShowPING)
	{
		GetPingz();
		drawRect(15, 30, 47, 13, UI::Color::BLACK);
		drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(wPING), 20, 33, 0xFFFFFFFF, 0, 1);
	}
}

void GetChunks()
{
	if (UI::Settings::ShowChunks)
	{
		char option[0x100];
		wchar_t woption[0x100];
		_sys_memset(option, 0, 0x100);
		_sys_memset(woption, 0, 0x200);
		_sys_snprintf(option, 0x100, "Chunk: (%i, %i, %i)", (int)mc->theMinecraft->cMultiplayerLocalPlayer->chunkCoordX + 1, (int)mc->theMinecraft->cMultiplayerLocalPlayer->chunkCoordY + 1, (int)mc->theMinecraft->cMultiplayerLocalPlayer->chunkCoordZ + 1);
		StringToWideCharacter(woption, option, strlen(option));
		drawRect(15, 41, 90, 13, UI::Color::BLACK);
		drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(woption), 20, 44, 0xFFFFFFFF, 0, 1);
	}
}

void GetResolution()
{
	if (UI::Settings::ShowResolution)
	{
		char option[0x100];
		wchar_t woption[0x100];
		_sys_memset(option, 0, 0x100);
		_sys_memset(woption, 0, 0x200);
		_sys_snprintf(option, 0x100, "Resolution: %ix%i", mc->theMinecraft->displayWidth, mc->theMinecraft->displayHeight);
		StringToWideCharacter(woption, option, strlen(option));
		drawRect(15, 51, 105, 13, UI::Color::BLACK);
		drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(woption), 20, 54, 0xFFFFFFFF, 0, 1);
	}
}

void GetTeleportXYZ()
{
	char option4[0x100];
	wchar_t woption4[0x100];
	_sys_memset(option4, 0, 0x100);
	_sys_memset(woption4, 0, 0x200);
	_sys_snprintf(option4, 0x100, "TP X: %i", (TeleportX));
	StringToWideCharacter(woption4, option4, _sys_strlen(option4));
	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(woption4), 130, 55, 0xFFFFFFFF, 0, 1);

	char option8[0x100];
	wchar_t woption8[0x100];
	_sys_memset(option8, 0, 0x100);
	_sys_memset(woption8, 0, 0x200);
	_sys_snprintf(option8, 0x100, "TP Y: %i", (TeleportY));
	StringToWideCharacter(woption8, option8, _sys_strlen(option8));
	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(woption8), 130, 65, 0xFFFFFFFF, 0, 1);

	char option16[0x100];
	wchar_t woption16[0x100];
	_sys_memset(option16, 0, 0x100);
	_sys_memset(woption16, 0, 0x200);
	_sys_snprintf(option16, 0x100, "TP Z: %i", (TeleportZ));
	StringToWideCharacter(woption16, option16, _sys_strlen(option16));
	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(woption16), 130, 75, 0xFFFFFFFF, 0, 1);
}

void GetInfosLastPlayer()
{
	if (PlayersInfos)
	{

		if (*(int*)0x30F46AD8 == 0xFFFFFFFF)
		{
			PLR_NAME = "N/A    ";
			PLR_REGION = "N/A    ";
		}
		else
		{
			if (*(int*)0x30F46AC4 == 0xFFFFFFFF)
			{
				PLR_NAME = "N/A    ";
				PLR_REGION = "N/A    ";
			}
			else
			{
				PLR_NAME = PS3Lib::ReadString(0x30F46AC4);
				PLR_REGION = PS3Lib::ReadString(0x30F46AD8);
			}
		}

		drawRect(15, 70, 90, 24, UI::Color::BLACK);
		drawText(PLR_NAME, 20, 74, color(UI::Color::WHITE));
		drawText(PLR_REGION, 20, 84, color(UI::Color::WHITE));
	}
}


#pragma endregion

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

	 if (HostPage4)
	 {
		 HostPage4 = false;
		 HostPage3 = true;
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

	 if (NonHostPage6)
	 {
		 NonHostPage6 = false;
		 NonHostPage5 = true;
	 }

	 if (NonHostPage7)
	 {
		 NonHostPage7 = false;
		 NonHostPage6 = true;
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

	 if (CreditsMenu)
	 {
		 CreditsMenu = false;
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
			 Opened = true;
			 OpenMenu = true;
			 MainMenu = true;
			 SlideOpenMenu();
		 }
	 }

	 if (OpenMenu)
	 {
		 if (Buttons::IsMCButtonPressed(Buttons::UP))
		 {
			 if (scrollWait(firstWaitTime, waitTime, wI))
			 {
				 CurrentOpt = CurrentOpt - 1;
				 PlayUISoundScroll();
				 return;
			 }
		 }

		 if (Buttons::IsMCButtonPressed(Buttons::DOWN))
		 {
			 if (scrollWait(firstWaitTime, waitTime, wI))
			 {
				 CurrentOpt = CurrentOpt + 1;
				 PlayUISoundScroll();
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
				 PlayUISoundSelect();
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
				 PlayUISoundBack();
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


 void LoopFunc()
 {
	 SlideOpenMenuLoop();
	 SlideCloseMenuLoop();
	 drawText("     ", 0, 0, color(255, 255, 255));//dont move
	 MaxOption = 0;
	 GetNotify();
	 RGB1();
	 RGB2();
	 Modules::AntiVoid();
	 Modules::BunnyJump();
	 Modules::SkyboxRGB();
	 Modules::Scaffold();
	 Offsets::ADD_CUSTOM_BANNER();
	 Offsets::ANIMATED_BANNER_GIF();
	 Offsets::ALL_PLAYERS_ZOOM_FOV();
 }

 void RenderMenu()
 {
	 if (!OpenMenu)
	 {
		 Welcome_Message();
		 GetPosition();
		 GetPing();
		 GetChunks();
		 GetResolution();
		 GetInfosLastPlayer();
		 get_temp();
		 TitleMenu();
		 DEBUG_FUNCTIONS_MESSAGES();
		 VersionText();
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

		 if (HostPage4)
		 {
			 SubMenu::HostMenu4();
		 }

		 if (NonHostPage)
		 {
			 SubMenu::NonHostMenu();
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

		 if (NonHostPage6)
		 {
			 SubMenu::NonHostMenu6();
		 }

		 if (NonHostPage7)
		 {
			 SubMenu::NonHostMenu7();
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
			 ChangeFloatOptions(VisionMenu6, 3, 0, 100, fovvalue);
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
			 drawRect(128, 53, 51, 30, UI::Color::BLACK);
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
			 SubMenu::DebugMenu();
			 drawRect(DebugHudX, DebugHudY, DebugHudW, DebugHudH, UI::Color::BLACK);
			 drawText("Debug Text", DebugTextX, DebugTextY, color(UI::Color::WHITE));
			 GetDebugXY();
		 }

		 if (CustomImageMenu)
		 {
			 drawRect(127, 108, 218, 32, UI::Color::BLACK);
			 drawText("Before using this read this!", 129, 110, color(UI::Color::WHITE));
			 drawText("You need add a custom image in the MediaPS3.arc", 129, 120, color(UI::Color::WHITE));
			 drawText("Set your PS3 language to English (United State)", 129, 130, color(UI::Color::WHITE));
			 SubMenu::CustomImageMenu();
		 }

		 if (MicsSettings)
		 {
			 SubMenu::MicsMenu();
			 ChangeIntOptions(MicsSettings, 11, -5, 255, menulenght);
			 ChangeIntOptions(MicsSettings, 12, 0, 255, shadowBG);
		 }

		 if (MicsSettings2)
		 {
			 SubMenu::MicsMenu2();
			 ChangeIntOptions(MicsSettings2, 4, 0, 500, RainbowSkyRGBSpeed);
		 }

		 if (CreditsMenu)
		 {
			 SubMenu::CreditsMenu();
		 }

		 if (DeveloperMenu)
		 {
			 if (devmenu)
			 {
				 SubMenu::DeveloperMenu();
			 }
		 }
	 }
 }