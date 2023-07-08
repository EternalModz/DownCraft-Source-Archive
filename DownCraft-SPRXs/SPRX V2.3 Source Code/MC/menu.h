
//X = < >
//Y = /\ \/

#pragma region "Get Functions"

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

#pragma endregion

 void BackSubMenu()
 {
	 if (MainMenu)
	 {
		 OpenMenu = false;
		 MainMenu = false;
	 }

	 if (HostPage)
	 {
		 HostPage = false;
		 MainMenu = true;
	 }

	 if (CreditsMenu)
	 {
		 CreditsMenu = false;
		 MainMenu = true;
	 }
 }

 void Functions()
 {
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
	 }

     #pragma endregion
 }

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
			 OpenMenu = true;
			 MainMenu = true;
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
				 Functions();
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
	 drawText("     ", 0, 0, color(255, 255, 255));//dont move
	 MaxOption = 0;
	 GetNotify();
	 RGB1();
	 RGB2();
	 Modules::SpinCamera();
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
		 get_temp();
		 TitleMenu();
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
	 }
 }