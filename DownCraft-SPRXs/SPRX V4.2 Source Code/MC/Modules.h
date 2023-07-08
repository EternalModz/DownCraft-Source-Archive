#pragma once
/*
* Zoom Mode
* TP Aura
* Nuker
* Auto Toss
* Anti Void
* Set Location
* KeyStrokes
*/

namespace Modules
{
	void ModulesTextRender()
	{
		if (Zoom)
			DrawTextWithShadow(L"Zoom Mode", 584, 15, color(UI::Color::WHITE));
		if (TPAura)
			DrawTextWithShadow(L"TP Aura", 595, 25, color(UI::Color::WHITE));
		if (Nuker)
			DrawTextWithShadow(L"Nuker", 603, 35, color(UI::Color::WHITE));
		if (AutoTossItems)
			DrawTextWithShadow(L"Auto Toss", 586, 45, color(UI::Color::WHITE));
	}

	void setLocation(double x, double y, double z)
	{
		mc->theMinecraft->cMultiplayerLocalPlayer->SetPosition(x + 0.5, y + 1 + 0.5, z + 0.5);
	}

	void ZoomModule()
	{
		if (Zoom)
		{
			if (Buttons::IsMCButtonPressed(Buttons::R3))
			{
				*(int*)0x014C670C = 0x40500000;
			}
			else
			{
				*(int*)0x014C670C = 0x3F800000;
			}
		}
	}

	void TP_Aura(ServerPlayer* player)
	{
		if (TPAura)
		{
			TargetposX = player->posX;
			TargetposY = player->posY;
			TargetposZ = player->posZ;

			if (frameTime(0, 1, false))
			{
				*(int*)0x00AEC34C = 0x40820024;
				setLocation(TargetposX, TargetposY + 10, TargetposZ); //TARGET POS
				sleep(400);
				setLocation(TargetposX, TargetposY, TargetposZ); //TARGET POS
				sleep(400);
				setLocation(TargetposX, TargetposY, TargetposZ); //TARGET POS
				sleep(400);
				setLocation(TargetposX + 5, TargetposY + 10, TargetposZ); //TARGET POS
				sleep(400);
				setLocation(TargetposX, TargetposY + 10, TargetposZ + 5); //TARGET POS
				*(int*)0x00AEC34C = 0x41820024;
			}
		}
	}

	void AutoToss()
	{
		if (AutoTossItems)
		{
			if (Buttons::IsMCButtonPressed(Buttons::O))
			{
				*(int*)0x00AEF428 = 0x40820024;
			}
			else
			{
				*(int*)0x00AEF428 = 0x41820024;
			}
		}
	}

	void AntiVoid()
	{
		if (AntiVoidtoggle)
		{
			if (mc->theMinecraft->cMultiplayerLocalPlayer->onGround)
			{
				char HEX[] = { 0x00 };
				sys_dbg_write_process_memory(0x003A74F3, &HEX, sizeof(HEX));
				sys_dbg_write_process_memory_ps3mapi(0x003A74F3, &HEX, sizeof(HEX));
				AntiVoidX = (int)mc->theMinecraft->cMultiplayerLocalPlayer->posX;
				AntiVoidY = (int)mc->theMinecraft->cMultiplayerLocalPlayer->posY;
				AntiVoidZ = (int)mc->theMinecraft->cMultiplayerLocalPlayer->posZ;
			}

			if (mc->theMinecraft->cMultiplayerLocalPlayer->fallDistance >= 5)
			{
				if (mc->theMinecraft->cMultiplayerLocalPlayer->IsSneaking())
				{
					return;
				}
				else
				{
					setLocation(AntiVoidX, AntiVoidY, AntiVoidZ);
					char HEX[] = { 0x01 };
					sys_dbg_write_process_memory(0x003A74F3, &HEX, sizeof(HEX));
					sys_dbg_write_process_memory_ps3mapi(0x003A74F3, &HEX, sizeof(HEX));
				}
			}
		}
	}

	void KeyStrokes()
	{
		if (keystrokes)
		{
			int BoxPos[2] = { 25, 280 };
			int Rainbow[3] = { UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE };

			DrawText(L"          ", 69, 244, color(UI::Color::WHITE));

			if (Buttons::IsMCButtonPressed(Buttons::JOYSTICK_L3_UP))
			{
				drawRectBorder(BoxPos[0] + 16, BoxPos[1] - 18, 15, 15, UI::Color::BLACK1, Rainbow); //UP
				DrawText(L"W    ", BoxPos[0] + 21, BoxPos[1] - 14, color(UI::Color::WHITE));
			}
			else
			{
				drawRectBorder(BoxPos[0] + 16, BoxPos[1] - 18, 15, 15, UI::Color::BLACK, GetThemeColor()); //UP
				DrawText(L"W    ", BoxPos[0] + 21, BoxPos[1] - 14, color(UI::Color::WHITE));
			}

			if (Buttons::IsMCButtonPressed(Buttons::JOYSTICK_L3_DOWN))
			{
				drawRectBorder(BoxPos[0] + 16, BoxPos[1], 15, 15, UI::Color::BLACK1, Rainbow); //BACK
				DrawText(L"S    ", BoxPos[0] + 21, BoxPos[1] + 4, color(UI::Color::WHITE));
			}
			else
			{
				drawRectBorder(BoxPos[0] + 16, BoxPos[1], 15, 15, UI::Color::BLACK, GetThemeColor()); //BACK
				DrawText(L"S    ", BoxPos[0] + 21, BoxPos[1] + 4, color(UI::Color::WHITE));
			}

			if (Buttons::IsMCButtonPressed(Buttons::JOYSTICK_L3_LEFT))
			{
				drawRectBorder(BoxPos[0] - 2, BoxPos[1], 15, 15, UI::Color::BLACK1, Rainbow); //LEFT
				DrawText(L"Q    ", BoxPos[0] + 3, BoxPos[1] + 4, color(UI::Color::WHITE));
			}
			else
			{
				drawRectBorder(BoxPos[0] - 2, BoxPos[1], 15, 15, UI::Color::BLACK, GetThemeColor()); //LEFT
				DrawText(L"Q    ", BoxPos[0] + 3, BoxPos[1] + 4, color(UI::Color::WHITE));
			}


			if (Buttons::IsMCButtonPressed(Buttons::JOYSTICK_L3_RIGHT))
			{
				drawRectBorder(BoxPos[0] + 34, BoxPos[1], 15, 15, UI::Color::BLACK1, Rainbow); //RIGHT
				DrawText(L"D    ", BoxPos[0] + 39, BoxPos[1] + 4, color(UI::Color::WHITE));
			}
			else
			{
				drawRectBorder(BoxPos[0] + 34, BoxPos[1], 15, 15, UI::Color::BLACK, GetThemeColor()); //RIGHT
				DrawText(L"D    ", BoxPos[0] + 39, BoxPos[1] + 4, color(UI::Color::WHITE));
			}

			if (Buttons::IsMCButtonPressed(Buttons::X))
			{
				drawRectBorder(BoxPos[0] - 2, BoxPos[1] + 20, 51, 10, UI::Color::BLACK1, Rainbow); //SPACE
				DrawRectangle(BoxPos[0] + 7, BoxPos[1] + 25, 33, 2, UI::Color::WHITE);
			}
			else
			{
				drawRectBorder(BoxPos[0] - 2, BoxPos[1] + 20, 51, 10, UI::Color::BLACK, GetThemeColor()); //SPACE
				DrawRectangle(BoxPos[0] + 7, BoxPos[1] + 25, 33, 2, UI::Color::WHITE);
			}
		}
	}


	void RainbowRenderName()
	{
		if (RainbowNameRender)
		{
			RainbowNameRenderColor += 1;
			if (RainbowNameRenderColor > 254)
				RainbowNameRenderColor = 0;

			char COLOR[] = { NyTekCFW::IntToHex(RainbowNameRenderColor) };
			sys_dbg_write_process_memory(0x00AA5236, &COLOR, sizeof(COLOR));
			sys_dbg_write_process_memory_ps3mapi(0x00AA5236, &COLOR, sizeof(COLOR));
		}
	}

	void BunnyJump()
	{
		if (BunnyHoptoggle)
		{

		}
	}

	void NoFall()
	{
		if (mc->theMinecraft->cMultiplayerLocalPlayer->fallDistance > 2.f)
		{
			mc->theMinecraft->cMultiplayerLocalPlayer->onGround = true;
		}
	}

	void SpinCamera()
	{
		if (spincameratoggle)
		{
			int speed = 5;
			spincamera += speed;
			if (spincamera == 350)
				spincamera = 0;

			mc->theMinecraft->cMultiplayerLocalPlayer->rotationYaw = spincamera;
		}
	}

	void SkyboxRGB()
	{
		if (RainbowSky)
		{
			RainbowSkyRGB += RainbowSkyRGBSpeed;
			if (RainbowSkyRGB == 500)
			{
				RainbowSkyRGB = 0;
			}
			*(float*)(0x00410734) = NyTekCFW::IntToHex(RainbowSkyRGB);
		}
	}

	void Scaffold()
	{
		if (ScaffoldV1)
		{
			if (Buttons::IsMCButtonPressed(Buttons::X))
			{
				mc->theMinecraft->cMultiplayerLocalPlayer->rotationPitch = 150;
				mc->theMinecraft->cMultiplayerLocalPlayer->rotationPitch = 0;
				char HEX[] = { 0x41 };
				char MODZ[] = { 0x80 };
				char MOD[] = { 0x80 };
				char MO[] = { 0x43, 0xA0, 0x00, 0x00 };
				char MA[] = { 0x43, 0xA0, 0x00, 0x00 };
				sys_dbg_write_process_memory(0x00B01BAC, &HEX, sizeof(HEX));
				sys_dbg_write_process_memory_ps3mapi(0x00B01BAC, &HEX, sizeof(HEX));
				sys_dbg_write_process_memory(0x00A95FB9, &MODZ, sizeof(MODZ));
				sys_dbg_write_process_memory(0x00A95FC1, &MOD, sizeof(MOD));
				sys_dbg_write_process_memory(0x00B351D8, &MO, sizeof(MO));
				sys_dbg_write_process_memory(0x00B351DC, &MA, sizeof(MA));
				sys_dbg_write_process_memory_ps3mapi(0x00A95FB9, &MODZ, sizeof(MODZ));
				sys_dbg_write_process_memory_ps3mapi(0x00A95FC1, &MOD, sizeof(MOD));
				sys_dbg_write_process_memory_ps3mapi(0x00B351D8, &MO, sizeof(MO));
				sys_dbg_write_process_memory_ps3mapi(0x00B351DC, &MA, sizeof(MA));
			}
			else
			{
				char MODZ[] = { 0x18 };
				char MOD[] = { 0x08 };
				char MO[] = { 0x40, 0xA0, 0x00, 0x00 };
				char MA[] = { 0x40, 0x90, 0x00, 0x00 };
				char HEX[] = { 0x40 };
				sys_dbg_write_process_memory(0x00A95FB9, &MODZ, sizeof(MODZ));
				sys_dbg_write_process_memory(0x00A95FC1, &MOD, sizeof(MOD));
				sys_dbg_write_process_memory(0x00B351D8, &MO, sizeof(MO));
				sys_dbg_write_process_memory(0x00B351DC, &MA, sizeof(MA));
				sys_dbg_write_process_memory_ps3mapi(0x00A95FB9, &MODZ, sizeof(MODZ));
				sys_dbg_write_process_memory_ps3mapi(0x00A95FC1, &MOD, sizeof(MOD));
				sys_dbg_write_process_memory_ps3mapi(0x00B351D8, &MO, sizeof(MO));
				sys_dbg_write_process_memory_ps3mapi(0x00B351DC, &MA, sizeof(MA));
				sys_dbg_write_process_memory(0x00B01BAC, &HEX, sizeof(HEX));
				sys_dbg_write_process_memory_ps3mapi(0x00B01BAC, &HEX, sizeof(HEX));
			}
		}
	}
}