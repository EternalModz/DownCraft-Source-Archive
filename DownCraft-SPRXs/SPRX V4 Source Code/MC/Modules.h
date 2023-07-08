#pragma once

namespace Modules
{
	void NukerTNT()
	{
		if (Buttons::IsMCButtonPressed(Buttons::R1))
		{
			*(int*)(Blocks::AIR) = *(int*)(Blocks::TNT);
			*(int*)0x0051E6A0 = 0x40810034;
		}
	}

	void BunnyJump()
	{
		if (BunnyHoptoggle)
		{
			if (mc->theMinecraft->cMultiplayerLocalPlayer->onGround)
			{
				char SPEED[] = { 0x01 };
				char SUPER_RUN[] = { 0xFF, 0xE0, 0x08, 0x90 };
				char JUMP_FORWARD[] = { 0x68 };
				char AUTO_JUMP[] = { 0x40 };
				sys_dbg_write_process_memory(0x00B01EEF, &SPEED, sizeof(SPEED));
				sys_dbg_write_process_memory_ps3mapi(0x00B01EEF, &SPEED, sizeof(SPEED));
				sys_dbg_write_process_memory(0x00018CE4, &SUPER_RUN, sizeof(SUPER_RUN));
				sys_dbg_write_process_memory_ps3mapi(0x00018CE4, &SUPER_RUN, sizeof(SUPER_RUN));
				sys_dbg_write_process_memory(0x003AA999, &JUMP_FORWARD, sizeof(JUMP_FORWARD));
				sys_dbg_write_process_memory_ps3mapi(0x003AA999, &JUMP_FORWARD, sizeof(JUMP_FORWARD));
				sys_dbg_write_process_memory(0x00B01BAC, &AUTO_JUMP, sizeof(AUTO_JUMP));
				sys_dbg_write_process_memory_ps3mapi(0x00B01BAC, &AUTO_JUMP, sizeof(AUTO_JUMP));

				//Offsets::AUTO_SPRINT_V2(false);
				//Offsets::ALL_PLAYERS_SUPER_RUN(false);
				//Offsets::JUMP_FORWARD(false);
				//Offsets::AUTO_JUMP(false);
			}
			else
			{
				char SPEED[] = { 0x00 };
				char SUPER_RUN[] = { 0xFF, 0xE0, 0x28, 0x90 };
				char JUMP_FORWARD[] = { 0x80 };
				char AUTO_JUMP[] = { 0x41 };
				sys_dbg_write_process_memory(0x00B01EEF, &SPEED, sizeof(SPEED));
				sys_dbg_write_process_memory_ps3mapi(0x00B01EEF, &SPEED, sizeof(SPEED));
				sys_dbg_write_process_memory(0x00018CE4, &SUPER_RUN, sizeof(SUPER_RUN));
				sys_dbg_write_process_memory_ps3mapi(0x00018CE4, &SUPER_RUN, sizeof(SUPER_RUN));
				sys_dbg_write_process_memory(0x003AA999, &JUMP_FORWARD, sizeof(JUMP_FORWARD));
				sys_dbg_write_process_memory_ps3mapi(0x003AA999, &JUMP_FORWARD, sizeof(JUMP_FORWARD));
				sys_dbg_write_process_memory(0x00B01BAC, &AUTO_JUMP, sizeof(AUTO_JUMP));
				sys_dbg_write_process_memory_ps3mapi(0x00B01BAC, &AUTO_JUMP, sizeof(AUTO_JUMP));
			}
		}
	}

	void setLocation(double x, double y, double z)
	{
		mc->theMinecraft->cMultiplayerLocalPlayer->SetPosition(x + 0.5, y + 1 + 0.5, z + 0.5);
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