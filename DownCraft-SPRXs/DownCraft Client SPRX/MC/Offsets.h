#pragma once

namespace Offsets
{
	void AUTO_SPRINT(bool toggle)
	{
		if (toggle)
		{
			char SPEED[] = { 0x40 };
			sys_dbg_write_process_memory(0x00B01DEC, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00B01DEC, &SPEED, sizeof(SPEED));
			//SetNotify(L"Auto Sprint: ON");
		}
		else
		{
			char SPEED[] = { 0x41 };
			sys_dbg_write_process_memory(0x00B01DEC, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00B01DEC, &SPEED, sizeof(SPEED));
			//SetNotify(L"Auto Sprint: OFF");
		}
	}

	void SUPER_SPEED(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xFF, 0xFF, 0xFF };
			sys_dbg_write_process_memory(0x003ABD49, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABD49, &HEX, sizeof(HEX));
			//SetNotify(L"Super Speed: ON");
		}
		else
		{
			char HEX[] = { 0x26, 0xAD, 0x89 };
			sys_dbg_write_process_memory(0x003ABD49, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABD49, &HEX, sizeof(HEX));
			//SetNotify(L"Super Speed: OFF");
		}
	}

	void SWIM_GLITCH(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00B0229C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B0229C, &HEX, sizeof(HEX));
			//SetNotify(L"Swim Glitch: ON");
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00B0229C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B0229C, &HEX, sizeof(HEX));
			//SetNotify(L"Swim Glitch: OFF");
		}
	}

	void SENSIBILITY_FAST(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x42, 0xFF };
			sys_dbg_write_process_memory(0x00ABA948, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00ABA948, &HEX, sizeof(HEX));
			//SetNotify(L"Sensibility Fast: ON");
		}
		else
		{
			char HEX[] = { 0x42, 0x48 };
			sys_dbg_write_process_memory(0x00ABA948, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00ABA948, &HEX, sizeof(HEX));
			//SetNotify(L"Sensibility Fast: OFF");
		}
	}

	void AUTO_WALK(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xFF, 0x40 };
			sys_dbg_write_process_memory(0x003ABE18, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABE18, &HEX, sizeof(HEX));
			//SetNotify(L"Sensibility Extrem: ON");
		}
		else
		{
			char HEX[] = { 0xFF, 0x20 };
			sys_dbg_write_process_memory(0x003ABE18, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABE18, &HEX, sizeof(HEX));
			//SetNotify(L"Sensibility Extrem: ON");
		}
	}

	void AUTO_CROUCH(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x01 };
			sys_dbg_write_process_memory(0x00B0142B, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B0142B, &HEX, sizeof(HEX));
			//SetNotify(L"Always Crouch: ON");
		}
		else
		{
			char HEX[] = { 0x00 };
			sys_dbg_write_process_memory(0x00B0142B, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B0142B, &HEX, sizeof(HEX));
			//SetNotify(L"Always Crouch: OFF");
		}
	}

	void CROUCH_MOVEMENT(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x0F };
			sys_dbg_write_process_memory(0x00B0143F, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B0143F, &HEX, sizeof(HEX));
			//SetNotify(L"Crouch Movement: ON");
		}
		else
		{
			char HEX[] = { 0x0E };
			sys_dbg_write_process_memory(0x00B0143F, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B0143F, &HEX, sizeof(HEX));
			//SetNotify(L"Crouch Movement: OFF");
		}
	}

	void WATER_SLOWDOWN(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x3F, 0x7C, 0xCC, 0xCD };
			sys_dbg_write_process_memory(0x0003AA964, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0003AA964, &HEX, sizeof(HEX));
			//SetNotify(L"Water Slowdown: ON");
		}
		else
		{
			char HEX[] = { 0x3F, 0x4C, 0xCC, 0xCD };
			sys_dbg_write_process_memory(0x0003AA964, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0003AA964, &HEX, sizeof(HEX));
			//sSetNotify(L"Water Slowdown: OFF");
		}
	}

	void AUTO_JUMP(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00B01BAC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B01BAC, &HEX, sizeof(HEX));
			//SetNotify(L"Auto Jump: ON");
		}
		else
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00B01BAC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B01BAC, &HEX, sizeof(HEX));
			//SetNotify(L"Auto Jump: OFF");
		}
	}

	void ALWAYS_SPRINT(bool toggle)
	{
		if (toggle)
		{
			char SPEED[] = { 0x00 };
			sys_dbg_write_process_memory(0x00B01EEF, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00B01EEF, &SPEED, sizeof(SPEED));
			//SetNotify(L"Auto Sprint V2: ON");
		}
		else
		{
			char SPEED[] = { 0x01 };
			sys_dbg_write_process_memory(0x00B01EEF, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00B01EEF, &SPEED, sizeof(SPEED));
			//SetNotify(L"Auto Sprint V2: OFF");
		}
	}

	void NO_SLOW_DOWN(bool toggle)
	{
		if (toggle)
		{
			char SPEED[] = { 0x4F };
			sys_dbg_write_process_memory(0x003AFB60, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x003AFB60, &SPEED, sizeof(SPEED));
			//SetNotify(L"No Slow Down: ON");
		}
		else
		{
			char SPEED[] = { 0x3F };
			sys_dbg_write_process_memory(0x003AFB60, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x003AFB60, &SPEED, sizeof(SPEED));
			//SetNotify(L"No Slow Down: OFF");
		}
	}

	void NO_FOOT_STEP(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x2F, 0x19 };
			sys_dbg_write_process_memory(0x002267F0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x002267F0, &MOD1, sizeof(MOD1));
			//SetNotify(L"Foot Step Slow: ON");
		}
		else
		{
			char MOD1[] = { 0x3F, 0x19 };
			sys_dbg_write_process_memory(0x002267F0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x002267F0, &MOD1, sizeof(MOD1));
			//SetNotify(L"Foot Step Slow: OFF");
		}
	}

	void REAL_JUMP_ANIMATION(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xBF };
			sys_dbg_write_process_memory(0x014C6728, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x014C6728, &MOD1, sizeof(MOD1));
			//SetNotify(L"Real Jump Anim: ON");
		}
		else
		{
			char MOD1[] = { 0x3F };
			sys_dbg_write_process_memory(0x014C6728, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x014C6728, &MOD1, sizeof(MOD1));
			//SetNotify(L"Real Jump Anim: OFF");
		}
	}

	void MULTI_JUMP(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x14 };
			sys_dbg_write_process_memory(0x0022790B, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0022790B, &HEX, sizeof(HEX));
			//SetNotify(L"Multi Jump: ON");
		}
		else
		{
			char HEX[] = { 0x18 };
			sys_dbg_write_process_memory(0x0022790B, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0022790B, &HEX, sizeof(HEX));
			//SetNotify(L"Multi Jump: OFF");
		}
	}

	void NO_COLISSION(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x002271B0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x002271B0, &HEX, sizeof(HEX));
			//SetNotify(L"No Colission Bypass: ON");
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x002271B0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x002271B0, &HEX, sizeof(HEX));
			//SetNotify(L"No Colission Bypass: ON");
		}
	}

	void DRIFT_BOAT(bool toggle)
	{
		if (toggle)
		{
			*(int*)0x2278E4 = 0x41820018;
			//SetNotify(L"Drift Boat: ON");
		}
		else
		{
			*(int*)0x2278E4 = 0x40820018;
			//SetNotify(L"Drift Boat: OFF");
		}
	}

	void DISABLE_PORTALS(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x00 };
			sys_dbg_write_process_memory(0x002379E7, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x002379E7, &HEX, sizeof(HEX));
			//SetNotify(L"Disable portals: ON");
		}
		else
		{
			char HEX[] = { 0x01 };
			sys_dbg_write_process_memory(0x002379E7, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x002379E7, &HEX, sizeof(HEX));
			//SetNotify(L"Disable portals: OFF");
		}
	}

	void ENTITY_GOD_MODE(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x003A3F6C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003A3F6C, &HEX, sizeof(HEX));
			//SetNotify(L"Entity God Mode: ON");
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x003A3F6C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003A3F6C, &HEX, sizeof(HEX));
			//SetNotify(L"Entity God Mode: OFF");
		}
	}

	void CAN_SEE_SPECTATOR(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x4E, 0x80, 0x00, 0x20 };
			sys_dbg_write_process_memory(0x007D86A0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x007D86A0, &MOD1, sizeof(MOD1));
			//SetNotify(L"Can See Spectator: ON");
		}
		else
		{
			char MOD1[] = { 0xF8, 0x21, 0xFF, 0x81 };
			sys_dbg_write_process_memory(0x007D86A0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x007D86A0, &MOD1, sizeof(MOD1));
			//SetNotify(L"Can See Spectator: OFF");
		}
	}

	void INSTANT_DAMAGE(bool toggle)
	{
		if (toggle)
		{
			*(int*)0x003A3FF0 = 0x40800000;
			//SetNotify(L"Instant Damage: ON");
		}
		else
		{
			*(int*)0x003A3FF0 = 0x3F000000;
			//SetNotify(L"Instant Damage: OFF");
		}
	}

	void KNOCKBACK(bool toggle)
	{
		if (toggle)
		{
			*(int*)0x003A4018 = 0x40CCCCCD;
		    //SetNotify(L"Knockback: ON");
		}
		else
		{
			*(int*)0x003A4018 = 0x3ECCCCCD;
			//SetNotify(L"Knockback: OFF");
		}
	}

	void MOBS_IGNORE_ME(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x3F, 0x00 };
			sys_dbg_write_process_memory(0x00A98F50, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00A98F50, &HEX, sizeof(HEX));
			//SetNotify(L"Mobs Ignore Me: ON");
		}
		else
		{
			char HEX[] = { 0x3D, 0x8C };
			sys_dbg_write_process_memory(0x00A98F50, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00A98F50, &HEX, sizeof(HEX));
			//SetNotify(L"Mobs Ignore Me: OFF");
		}
	}

	void FREEZE_ALL_ENTITY(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x4E, 0x80, 0x00, 0x20 };
			sys_dbg_write_process_memory(0x003A9FE8, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003A9FE8, &HEX, sizeof(HEX));
			//SetNotify(L"Freeze All Entity: ON");
		}
		else
		{
			char HEX[] = { 0xF8, 0x21, 0xFF, 0x81 };
			sys_dbg_write_process_memory(0x003A9FE8, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003A9FE8, &HEX, sizeof(HEX));
			//SetNotify(L"Freeze All Entity: OFF");
		}
	}

	void GOD_MODE_FOR_ME(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x00 };
			sys_dbg_write_process_memory(0x002F0273, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x002F0273, &HEX, sizeof(HEX));
			//SetNotify(L"God Mode For Me: ON");
		}
		else
		{
			char HEX[] = { 0x01 };
			sys_dbg_write_process_memory(0x002F0273, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x002F0273, &HEX, sizeof(HEX));
			//SetNotify(L"Gode Mode For Me: OFF");
		}
	}

	void CAN_FLY(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00B02378, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B02378, &HEX, sizeof(HEX));
			//SetNotify(L"Can Fly: ON");
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00B02378, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B02378, &HEX, sizeof(HEX));
			//SetNotify(L"Can Fly: OFF");
		}
	}

	void AIR_TO_WATER(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x001D7FCC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x001D7FCC, &HEX, sizeof(HEX));
			//SetNotify(L"Air To Water: ON");
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x001D7FCC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x001D7FCC, &HEX, sizeof(HEX));
			//SetNotify(L"Air To Water: OFF");
		}
	}

	void NO_VELOCITY(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0xD3, 0x23, 0x01, 0x30 };
			char MOD1[] = { 0xD8, 0x43, 0x01, 0x38 };
			char MOD2[] = { 0xD3, 0x63, 0x01, 0x40 };

			sys_dbg_write_process_memory(0x002335C8, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory(0x002335CC, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory(0x002335D0, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x002335C8, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x002335CC, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x002335D0, &MOD2, sizeof(MOD2));
			//SetNotify(L"No Velocity: ON");
		}
		else
		{
			char MOD[] = { 0xD8, 0x23, 0x01, 0x30 };
			char MOD1[] = { 0xD8, 0x43, 0x01, 0x38 };
			char MOD2[] = { 0xD8, 0x63, 0x01, 0x40 };

			sys_dbg_write_process_memory(0x002335C8, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory(0x002335CC, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory(0x002335D0, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x002335C8, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x002335CC, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x002335D0, &MOD2, sizeof(MOD2));
			//SetNotify(L"No Velocity: OFF");
		}
	}

	void DRAGON_EGGS_SPAWNER(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x30, 0x99, 0xE7, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0C };
			sys_dbg_write_process_memory(0x32418D18, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x32418D18, &MOD, sizeof(MOD));
			//SetNotify(L"Dragon Eggs Spawn: ON");
		}
		else
		{
			char MOD[] = { 0x30, 0x99, 0xD3, 0xE0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E };
			sys_dbg_write_process_memory(0x32418D18, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x32418D18, &MOD, sizeof(MOD));
			//SetNotify(L"Dragon Eggs Spawn: OFF");
		}
	}

	void ROTATION_HEAD(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xC3 };
			char MOD2[] = { 0x43 };
			sys_dbg_write_process_memory(0x00224FD4, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory(0x00224FD8, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x00224FD4, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00224FD8, &MOD2, sizeof(MOD2));
			//SetNotify(L"Rotation Head: ON");
		}
		else
		{
			char MOD1[] = { 0xC2 };
			char MOD2[] = { 0x42 };
			sys_dbg_write_process_memory(0x00224FD4, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory(0x00224FD8, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x00224FD4, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00224FD8, &MOD2, sizeof(MOD2));
			//SetNotify(L"Rotation Head: OFF");
		}
	}

	void INSTANT_HIT(bool toggle)
	{
		if (toggle)
		{
			char SPEED[] = { 0xFF };
			sys_dbg_write_process_memory(0x00AEBED4, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00AEBED4, &SPEED, sizeof(SPEED));
			//SetNotify(L"Instant Hit: ON");
		}
		else
		{
			char SPEED[] = { 0x3E };
			sys_dbg_write_process_memory(0x00AEBED4, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00AEBED4, &SPEED, sizeof(SPEED));
			//SetNotify(L"Instant Hit: OFF");
		}
	}

	void AUTO_HIT(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00AEC34C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEC34C, &HEX, sizeof(HEX));
			//SetNotify(L"Auto Hit: ON");
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00AEC34C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEC34C, &HEX, sizeof(HEX));
			//SetNotify(L"Auto Hit: OFF");
		}
	}

	void ALL_PLAYERS_FREEZE_PS3()
	{
		char MODz[] = { 0x40 };
		char MODzz[] = { 0xCF, 0x80 };
		char MOD[] = { 0x4F, 0x80 };
		char MOD1[] = { 0x2F, 0x80 };
		char MOD2[] = { 0x3F, 0x80 };
		char MOD3[] = { 0x41 };

		sys_dbg_write_process_memory(0x00AEE434, &MODz, sizeof(MODz));
		sys_dbg_write_process_memory(0x00393E34, &MODzz, sizeof(MODzz));
		sys_dbg_write_process_memory_ps3mapi(0x00AEE434, &MODz, sizeof(MODz));
		sys_dbg_write_process_memory_ps3mapi(0x00393E34, &MODzz, sizeof(MODzz));

		sleep(200);

		sys_dbg_write_process_memory(0x00393E34, &MOD, sizeof(MOD));
		sys_dbg_write_process_memory(0x00393E34, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory(0x00393E34, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory_ps3mapi(0x00393E34, &MOD, sizeof(MOD));
		sys_dbg_write_process_memory_ps3mapi(0x00393E34, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory_ps3mapi(0x00393E34, &MOD2, sizeof(MOD2));
		sleep(2000);
		sys_dbg_write_process_memory(0x00AEE434, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory_ps3mapi(0x00AEE434, &MOD3, sizeof(MOD3));
		sleep(200);

		//SetNotify(L"Freeze PS3 Send !");
	}

	void ALL_PLAYERS_FAST_MINE(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0xFF, 0xE0, 0x28, 0x90 };
			sys_dbg_write_process_memory(0x0010E0C4, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x0010E0C4, &MOD, sizeof(MOD));
			//SetNotify(L"All Players Fast Mine: ON");
		}
		else
		{
			char MOD[] = { 0xFF, 0xE0, 0x08, 0x90 };
			sys_dbg_write_process_memory(0x0010E0C4, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x0010E0C4, &MOD, sizeof(MOD));
			//SetNotify(L"All Players Fast Mine: OFF");
		}
	}

	void ALL_PLAYERS_SUPER_SPEED(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0xFF, 0xE0, 0x28, 0x90 };
			sys_dbg_write_process_memory(0x00018CE4, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00018CE4, &MOD, sizeof(MOD));
			//SetNotify(L"All Players Super Speed: ON");
		}
		else
		{
			char MOD[] = { 0xFF, 0xE0, 0x08, 0x90 };
			sys_dbg_write_process_memory(0x00018CE4, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00018CE4, &MOD, sizeof(MOD));
			//SetNotify(L"All Players Super Speed: OFF");
		}
	}

	void ALL_PLAYERS_SUFFOCATE(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x4E, 0x80, 0x00, 0x20 };
			sys_dbg_write_process_memory(0x0022FDC8, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD, sizeof(MOD));
			//SetNotify(L"All Players Suffocate: ON");
		}
		else
		{
			char MOD[] = { 0xF8, 0x21, 0xFF, 0x11 };
			sys_dbg_write_process_memory(0x0022FDC8, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD, sizeof(MOD));
			//SetNotify(L"All Players Suffocate: OFF");
		}
	}

	void ALL_PLAYERS_IN_FIRE(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x40 };
			sys_dbg_write_process_memory(0x00225FA0, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00225FA0, &MOD, sizeof(MOD));
			//SetNotify(L"All Players In Fire: ON");
		}
		else
		{
			char MOD[] = { 0x41 };
			sys_dbg_write_process_memory(0x00225FA0, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00225FA0, &MOD, sizeof(MOD));
			//SetNotify(L"All Players In Fire: OFF");
		}
	}

	void DISABLE_PLAYERS(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x48 };
			sys_dbg_write_process_memory(0x001D3BF2, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x001D3BF2, &MOD1, sizeof(MOD1));
			//SetNotify(L"Disable Players: ON");
		}
		else
		{
			char MOD1[] = { 0x08 };
			sys_dbg_write_process_memory(0x001D3BF2, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x001D3BF2, &MOD1, sizeof(MOD1));
			//SetNotify(L"Disable Players: OFF");
		}
	}

	void BETTER_TIME(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x0F };
			sys_dbg_write_process_memory(0x00A9A6DC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00A9A6DC, &HEX, sizeof(HEX));
			//SetNotify(L"Better Time: ON");
		}
		else
		{
			char HEX[] = { 0x3F };
			sys_dbg_write_process_memory(0x00A9A6DC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00A9A6DC, &HEX, sizeof(HEX));
			//SetNotify(L"Better Time: OFF");
		}
	}

	void XRAY_VISON(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xFC, 0x80, 0x30, 0x90 };
			sys_dbg_write_process_memory(0x00A99154, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A99154, &MOD1, sizeof(MOD1));
			//SetNotify(L"Xray Vision: ON");
		}
		else
		{
			char MOD1[] = { 0xFC, 0x60, 0x30, 0x90 };
			sys_dbg_write_process_memory(0x00A99154, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A99154, &MOD1, sizeof(MOD1));
			//SetNotify(L"Xray Vision: OFF");
		}
	}

	void OPTIMIZE_CHUNKS(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x40, 0xD7, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x00B21C60, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B21C60, &MOD1, sizeof(MOD1));
			//SetNotify(L"Optimize Chunks: ON");
		}
		else
		{
			char MOD1[] = { 0x40, 0x30, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x00B21C60, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B21C60, &MOD1, sizeof(MOD1));
			//SetNotify(L"Optimize Chunks: OFF");
		}
	}

	void FOV_WITHOUT_HAND(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x68 };
			sys_dbg_write_process_memory(0x00987502, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00987502, &MOD1, sizeof(MOD1));
			//SetNotify(L"FOV Without Hand: ON");
		}
		else
		{
			char MOD1[] = { 0x08 };
			sys_dbg_write_process_memory(0x00987502, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00987502, &MOD1, sizeof(MOD1));
			//SetNotify(L"FOV Without Hand: OFF");
		}
	}

	void FREE_CAM(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x40 };
			sys_dbg_write_process_memory(0x00A98A95, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98A95, &MOD1, sizeof(MOD1));
			//SetNotify(L"Free Cam: ON");
		}
		else
		{
			char MOD1[] = { 0x30 };
			sys_dbg_write_process_memory(0x00A98A95, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98A95, &MOD1, sizeof(MOD1));
			//SetNotify(L"Free Cam: OFF");
		}
	}

	void BEST_SKY(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x3F, 0x10 };
			char MOD2[] = { 0x7F };
			sys_dbg_write_process_memory(0x00410738, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory(0x0038C658, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x00410738, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0038C658, &MOD2, sizeof(MOD2));
			//SetNotify(L"Blue Fog: ON");
		}
		else
		{
			char MOD1[] = { 0x3F, 0x80 };
			char MOD2[] = { 0x3F };
			sys_dbg_write_process_memory(0x00410738, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory(0x0038C658, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x00410738, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0038C658, &MOD2, sizeof(MOD2));
			//SetNotify(L"Blue Fog: OFF");
		}
	}

	void WALLHACK(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x3F, 0x00 };
			sys_dbg_write_process_memory(0x00A98F50, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98F50, &MOD1, sizeof(MOD1));
			//SetNotify(L"Wallhack V3: ON");
		}
		else
		{
			char MOD1[] = { 0x3D, 0x8C };
			sys_dbg_write_process_memory(0x00A98F50, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98F50, &MOD1, sizeof(MOD1));
			//SetNotify(L"Wallhack V3: OFF");
		}
	}

	void RENDER_ENTITY(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x48, 0xFF, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x0022CE40, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0022CE40, &MOD1, sizeof(MOD1));
			//SetNotify(L"Render Entity: ON");
		}
		else
		{
			char MOD1[] = { 0x40, 0x48, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x0022CE40, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0022CE40, &MOD1, sizeof(MOD1));
			//SetNotify(L"Render Entity: OFF");
		}
	}

	void REACH_ATTACK(bool toggle)
	{
		if (toggle)
		{
			char MODZ[] = { 0x80 };
			char MOD[] = { 0x80 };
			char MO[] = { 0x43, 0xA0, 0x00, 0x00 };
			char MA[] = { 0x43, 0xA0, 0x00, 0x00 };

			sys_dbg_write_process_memory(0x00A95FB9, &MODZ, sizeof(MODZ));
			sys_dbg_write_process_memory(0x00A95FC1, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory(0x00B351D8, &MO, sizeof(MO));
			sys_dbg_write_process_memory(0x00B351DC, &MA, sizeof(MA));
			sys_dbg_write_process_memory_ps3mapi(0x00A95FB9, &MODZ, sizeof(MODZ));
			sys_dbg_write_process_memory_ps3mapi(0x00A95FC1, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00B351D8, &MO, sizeof(MO));
			sys_dbg_write_process_memory_ps3mapi(0x00B351DC, &MA, sizeof(MA));
			//SetNotify(L"Reach Attack: ON");
		}
		else
		{
			char MODZ[] = { 0x18 };
			char MOD[] = { 0x08 };
			char MO[] = { 0x40, 0xA0, 0x00, 0x00 };
			char MA[] = { 0x40, 0x90, 0x00, 0x00 };

			sys_dbg_write_process_memory(0x00A95FB9, &MODZ, sizeof(MODZ));
			sys_dbg_write_process_memory(0x00A95FC1, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory(0x00B351D8, &MO, sizeof(MO));
			sys_dbg_write_process_memory(0x00B351DC, &MA, sizeof(MA));
			sys_dbg_write_process_memory_ps3mapi(0x00A95FB9, &MODZ, sizeof(MODZ));
			sys_dbg_write_process_memory_ps3mapi(0x00A95FC1, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00B351D8, &MO, sizeof(MO));
			sys_dbg_write_process_memory_ps3mapi(0x00B351DC, &MA, sizeof(MA));
			//SetNotify(L"Reach Attack: OFF");
		}
	}

	void KILL_AURA(bool toggle)
	{
		if (toggle)
		{
			char SPEED[] = { 0xFF };
			sys_dbg_write_process_memory(0x00233290, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00233290, &SPEED, sizeof(SPEED));
			//SetNotify(L"Kill Aura: ON");
		}
		else
		{
			char SPEED[] = { 0x00 };
			sys_dbg_write_process_memory(0x00233290, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00233290, &SPEED, sizeof(SPEED));
			//SetNotify(L"Kill Aura: OFF");
		}
	}

}


//rotate character = 0x00A891A8 / 0x00A891AC / 0x00A891BC