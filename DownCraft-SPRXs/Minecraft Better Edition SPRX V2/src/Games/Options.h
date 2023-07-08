#pragma once

namespace Options
{
	char* getName()
	{
		if (*(int*)0x3000ABE4 == 0x00000000)
			return (char*) NyTekCFW::ReadString(0x3000ABA4);
		else
			return (char*)NyTekCFW::ReadString(0x3000AD34);
	}

	void setName(char* name)
	{
		NyTekCFW::WriteString(0x3000ABE4, name);
		NyTekCFW::WriteString(0x3000ABA4, name);
	}

	void getTeleport()
	{
		CoordX = (int)mc->theMinecraft->cMultiplayerLocalPlayer->posX;
		CoordY = (int)mc->theMinecraft->cMultiplayerLocalPlayer->posY;
		CoordZ = (int)mc->theMinecraft->cMultiplayerLocalPlayer->posZ;
	}

	void setTeleport(double X, double Y, double Z) 
	{ 
		mc->theMinecraft->cMultiplayerLocalPlayer->SetPosition(X + 0.5, Y + 1 + 0.5, Z + 0.5);
	}

	void ShowPSN()
	{
		if (TogglePSN)
		{
			char* name;
			name = getName();

			DrawTextWithRectangle(L"Welcome: ", 0, 36, MC_Color::BlackTheme, MC_Color::White, false);
			DrawTextCharWithRectangle(name, 40, 36, MC_Color::BlackTheme, MC_Color::White, false);
		}
	}

	void ShowGametime()
	{
		if (ToggleGametime)
		{
			int milliseconds, seconds, minutes, hours;
			milliseconds = mc->gameTime; seconds = (milliseconds / 60); minutes = seconds / 60; hours = minutes / 60;
			int gametime[3] = { int(hours % 24), int(minutes % 60), int(seconds % 60) };
			DrawsnprintfText("Gametime: %ih:%imin:%isec", gametime, 0, 46, true);
		}
	}

	void ShowPosition()
	{
		if (TogglePosition)
		{
			int position[3] = { mc->theMinecraft->cMultiplayerLocalPlayer->LocationX, mc->theMinecraft->cMultiplayerLocalPlayer->LocationY, mc->theMinecraft->cMultiplayerLocalPlayer->LocationZ };
			DrawsnprintfText("Position: (%i, %i, %i)", position, 0, 56, true);
		}
	}

	void ShowChunks()
	{
		if (ToggleChunks)
		{
			int getChunks[3] = { (int)mc->theMinecraft->cMultiplayerLocalPlayer->chunkCoordX + 1, (int)mc->theMinecraft->cMultiplayerLocalPlayer->chunkCoordY + 1, (int)mc->theMinecraft->cMultiplayerLocalPlayer->chunkCoordZ + 1 };
			DrawsnprintfText("Chunks: (%i, %i, %i)", getChunks, 0, 66, true);
		}
	}

	void ShowResolution()
	{
		if (ToggleResolution)
		{
			int getResolution[2] = { mc->theMinecraft->displayWidth, mc->theMinecraft->displayHeight };
			DrawsnprintfText("Resolution: (%ix%i)", getResolution, 0, 76, true);
		}
	}

	void ShowPing()
	{
		if (TogglePing)
		{
			int getPing[] = { mc->FPS };
			DrawsnprintfText("Ping: %i ms", getPing, 0, 86, true);
		}
	}

	void ShowCPURSX()
	{
		if (ToggleCPURSX)
		{

			if (frameTime(120, 1, false))
			{
				char systemperature[100];
				get_temperature(0, &cpu_t);
				get_temperature(1, &rsx_t);
				cpu_t = cpu_t >> 24;
				rsx_t = rsx_t >> 24;
			}

			int getCPURSX[2] = { cpu_t, rsx_t };
			DrawsnprintfText("CPU: %iC / RSX: %iC", getCPURSX, 0, 96, true);
		}
	}

	void ShowDebugPlayer()
	{
		if (ToggleDebugPlayer)
		{
			if (mc->theMinecraft->cMultiplayerLocalPlayer->isInWeb == true)
			{
				DrawTextWithRectangle(L"[In Web]", 0, 116, MC_Color::BlackTheme, MC_Color::White, true);
			}
			if (mc->theMinecraft->cMultiplayerLocalPlayer->IsSprinting())
			{
				DrawTextWithRectangle(L"[Sprinting]", 0, 116, MC_Color::BlackTheme, MC_Color::White, true);
			}
			else if (mc->theMinecraft->cMultiplayerLocalPlayer->IsSneaking())
			{
				DrawTextWithRectangle(L"[Sneaking]", 0, 116, MC_Color::BlackTheme, MC_Color::White, true);
			}
			else if (mc->theMinecraft->cMultiplayerLocalPlayer->IsSpectator())
			{
				DrawTextWithRectangle(L"[Spectator]", 0, 116, MC_Color::BlackTheme, MC_Color::White, true);
			}
			else if (mc->theMinecraft->cMultiplayerLocalPlayer->IsBurning())
			{
				DrawTextWithRectangle(L"[Burning]", 0, 116, MC_Color::BlackTheme, MC_Color::White, true);
			}
			else if (mc->theMinecraft->cMultiplayerLocalPlayer->isInWater())
			{
				DrawTextWithRectangle(L"[In Water]", 0, 116, MC_Color::BlackTheme, MC_Color::White, true);
			}
			else if (mc->theMinecraft->cMultiplayerLocalPlayer->fallDistance > 0)
			{
				DrawTextWithRectangle(L"[Falling]", 0, 116, MC_Color::BlackTheme, MC_Color::White, true);
			}
			else if (mc->theMinecraft->cMultiplayerLocalPlayer->onGround == true)
			{
				DrawTextWithRectangle(L"[On Ground]", 0, 116, MC_Color::BlackTheme, MC_Color::White, true);
			}
			else if (mc->theMinecraft->cMultiplayerLocalPlayer->isDead == true)
			{
				DrawTextWithRectangle(L"[Is Dead]", 0, 116, MC_Color::BlackTheme, MC_Color::White, true);
			}
		}
	}

	void ShowKeystrokes()
	{
		if (ToggleKeystrokes)
		{
			bool KeyPressedUP, KeyPressedDOWN, KeyPressedLEFT, KeyPressedRIGHT, KeyPressedSPACE;
			char* keystrokes_text[] = { "W    ", "S    ", "Q    ", "D    " };

			if (Buttons::IsMCButtonPressed(Buttons::JOYSTICK_L3_UP))
				KeyPressedUP = true; else KeyPressedUP = false;

			if (Buttons::IsMCButtonPressed(Buttons::JOYSTICK_L3_DOWN))
				KeyPressedDOWN = true; else KeyPressedDOWN = false;

			if (Buttons::IsMCButtonPressed(Buttons::JOYSTICK_L3_LEFT))
				KeyPressedLEFT = true; else KeyPressedLEFT = false;

			if (Buttons::IsMCButtonPressed(Buttons::JOYSTICK_L3_RIGHT))
				KeyPressedRIGHT = true; else KeyPressedRIGHT = false;

			if (Buttons::IsMCButtonPressed(Buttons::X))
				KeyPressedSPACE = true; else KeyPressedSPACE = false;

			int* KeyUPColor = KeyPressedUP ? GetThemeRainbow() : GetThemeColor();
			int* KeyDOWNColor = KeyPressedDOWN ? GetThemeRainbow() : GetThemeColor();
			int* KeyLEFTColor = KeyPressedLEFT ? GetThemeRainbow() : GetThemeColor();
			int* KeyRIGHTColor = KeyPressedRIGHT ? GetThemeRainbow() : GetThemeColor();
			int* KeySPACEColor = KeyPressedSPACE ? GetThemeRainbow() : GetThemeColor();

			int* keystrokesHudColor2[] = { KeyUPColor, KeyDOWNColor, KeyLEFTColor, KeyRIGHTColor, KeySPACEColor, MC_Color::White };

			for (byte a = 0; a < 6; a++)
				DrawRectangleBorder(keystrokesBase_x + keystrokesHudX[a], keystrokesBase_y + keystrokesHudY[a], HudW[a], HudH[a], keystrokesHudColor1[a], keystrokesHudColor2[a], 1);

			for (byte b = 0; b < 4; b++)
				DrawTextC(keystrokes_text[b], keystrokesBase_x + keystrokes_TextX[b], keystrokesBase_y + keystrokes_TextY[b], color(keystrokes_TextColor[b]));
		}
	}
}