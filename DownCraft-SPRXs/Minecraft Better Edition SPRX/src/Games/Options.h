#pragma once

namespace Offsets
{
	void GOD_MODE(bool toggle) { if (toggle) { *(int*)0x4B2020 = 0xFC80F890; } else { *(int*)0x4B2020 = 0xFC20F890; } }
	void CLOSE_MINECRAFT() { *(int*)0xAD8320 = 0x408000CC; *(int*)0x00785DBC = 0x40800028; }
	void RESTART_MINECRAFT() { /*CODE HERE*/ }
	void TELEPORT(double X, double Y, double Z) { mc->theMinecraft->cMultiplayerLocalPlayer->SetPosition(X, Y, Z); }
}

namespace Options
{
	void ShowPosition()
	{
		if (TogglePosition)
		{
			int position[3] = { mc->theMinecraft->cMultiplayerLocalPlayer->LocationX, mc->theMinecraft->cMultiplayerLocalPlayer->LocationY, mc->theMinecraft->cMultiplayerLocalPlayer->LocationZ };
			DrawsnprintfText("Position: %i, %i, %i", position, 0, 47, true);
		}
	}

	void ShowGametime()
	{
		if (ToggleGametime)
		{
			int milliseconds, seconds, minutes, hours;
			milliseconds = mc->gameTime; seconds = (milliseconds / 60); minutes = seconds / 60; hours = minutes / 60;
			int gametime[3] = { int(hours % 24), int(minutes % 60), int(seconds % 60) };
			DrawsnprintfText("Gametime: %ih:%imin:%isec", gametime, 0, 36, true);
		}
	}

	void ShowPing()
	{
		if (TogglePing)
		{
			int getPing[] = { mc->FPS };
			DrawsnprintfText("Ping: %i ms", getPing, 0, 57, true);
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

			int* KeyUPColor = KeyPressedUP ? Rainbow : MC_Color::Blue;
			int* KeyDOWNColor = KeyPressedDOWN ? Rainbow : MC_Color::Blue;
			int* KeyLEFTColor = KeyPressedLEFT ? Rainbow : MC_Color::Blue;
			int* KeyRIGHTColor = KeyPressedRIGHT ? Rainbow : MC_Color::Blue;
			int* KeySPACEColor = KeyPressedSPACE ? Rainbow : MC_Color::Blue;

			int* keystrokesHudColor2[] = { KeyUPColor, KeyDOWNColor, KeyLEFTColor, KeyRIGHTColor, KeySPACEColor, MC_Color::White };

			for (byte a = 0; a < 6; a++)
				DrawRectangleBorder(keystrokesBase_x + keystrokesHudX[a], keystrokesBase_y + keystrokesHudY[a], HudW[a], HudH[a], keystrokesHudColor1[a], keystrokesHudColor2[a], 1);

			for (byte b = 0; b < 4; b++)
				DrawTextC(keystrokes_text[b], keystrokesBase_x + keystrokes_TextX[b], keystrokesBase_y + keystrokes_TextY[b], color(keystrokes_TextColor[b]));
		}
	}

	void ShowCPS()
	{
		int click;
		if (ToggleCPS)
		{
			if (Buttons::IsMCButtonPressed(Buttons::R2))
				click += 1;

			int getClick[] = { click };
			DrawsnprintfText("CPS: %i", getClick, 0, 68, true);
		}
	}
}