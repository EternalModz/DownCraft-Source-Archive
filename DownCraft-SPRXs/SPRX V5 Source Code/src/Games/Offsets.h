#pragma once

#pragma region "Offsets"

class Address {
public:
	void GOD_MODE(bool toggle) { if (toggle) { *(int*)0x4B2020 = 0xFC80F890; } else { *(int*)0x4B2020 = 0xFC20F890; } }
	void DEMI_GOD_MODE(bool toggle) { if (toggle) { *(int*)0x3A4064 = 0xFF408890; } else { *(int*)0x3A4064 = 0xFF400890; } }
	void CRITICAL_HIT(bool toggle) { if (toggle) { *(int*)0x1AC410 = 0xFFE02890; } else { *(int*)0x1AC410 = 0xFFE00890; } }
	void INSTANT_KILL_ALL(bool toggle) { if (toggle) { *(int*)0x3A4064 = 0xFF402890; } else { *(int*)0x3A4064 = 0xFF400890; } }
	void KILL_IN_CREATIVE(bool toggle) { if (toggle) { *(int*)0x226168 = 0x4086001C; } else { *(int*)0x226168 = 0x4186001C; } }
	void KILL_IN_FIRE(bool toggle) { if (toggle) { *(int*)0x226168 = 0x4086001C; } else { *(int*)0x226168 = 0x4186001C; } }
	void NO_DAMAGE_HIT(bool toggle) { if (toggle) { *(int*)0x3A3FF0 = 0xFF000000; } else { *(int*)0x3A3FF0 = 0x3F000000; } }
	void KNOCKBACK(bool toggle) { if (toggle) { *(int*)0x003A4018 = 0x40CCCCCD; } else { *(int*)0x003A4018 = 0x3ECCCCCD; } }
	void ANTI_KNOCKBACK(bool toggle) { if (toggle) { *(int*)0x3A4018 = 0x00CCCCCD; } else { *(int*)0x3A4018 = 0x3ECCCCCD; } }
	void REVERSE_KNOCKBACK(bool toggle) { if (toggle) { *(int*)0x3A4018 = 0xBFCCCCCD; } else { *(int*)0x3A4018 = 0x3ECCCCCD; } }
	void DROP_ITEMS_FAR(bool toggle) { if (toggle) { *(int*)0x14C6880 = 0x3FFF0000; } else { *(int*)0x14C6880 = 0x3F800000; } }
	void MAX_LEVEL_XP(bool toggle) { if (toggle) { *(int*)0x4B0094 = 0x7CA51014; } else { *(int*)0x4B0094 = 0x7CA52014; } }
	void WATER_JUMP(bool toggle) { if (toggle) { *(int*)0x3ABD68 = 0x3FFF9999; } else { *(int*)0x3ABD68 = 0x3FE99999; } }
	void DRIFT_BOAT(bool toggle) { if (toggle) { *(int*)0x2278E4 = 0x41820018; } else { *(int*)0x2278E4 = 0x40820018; } }
	void STOP_ARROWS(bool toggle) { if (toggle) { *(int*)0xFB55C = 0x80400000; } else { *(int*)0xFB55C = 0x40400000; } }
	void REMOVE_ARROWS(bool toggle) { if (toggle) { *(int*)0xFB644 = 0x41820020; } else { *(int*)0xFB644 = 0x40820020; } }
	void POTIONS_FLYING(bool toggle) { if (toggle) { *(int*)0x0065FB60 = 0x2D4CCCCD; } else { *(int*)0x0065FB60 = 0x3D4CCCCD; } }
	void POTIONS_NO_GRAVITY(bool toggle) { if (toggle) { *(int*)0x0065FB60 = 0x4D4CCCCD; } else { *(int*)0x0065FB60 = 0x3D4CCCCD; } }
	void INFINITE_PICKUP_ITEMS(bool toggle) { if (toggle) { *(int*)0x224B10 = 0x38800000; } else { *(int*)0x224B10 = 0x38800001; } }
	void MAX_PICKUP_ITEMS(bool toggle) { if (toggle) { *(int*)0x310AD4 = 0x41810034; } else { *(int*)0x310AD4 = 0x40810034; } }
	void INFINITE_BLOCKS(bool toggle) { if (toggle) { *(int*)0x10673C = 0x38800000; } else { *(int*)0x10673C = 0x38800001; } }
	void BURN_IN_WATER(bool toggle) { if (toggle) { *(int*)0x225EA8 = 0x418100A4; } else { *(int*)0x225EA8 = 0x408100A4; } }
	void REMOVE_FIRE(bool toggle) { if (toggle) { *(int*)0x225E80 = 0x40820020; } else { *(int*)0x225E80 = 0x41820020; } }
	void CREATIVE_SLOT(bool toggle) { if (toggle) { *(int*)0x2F0348 = 0x38800001; *(int*)0x2F0398 = 0x38800000; } else { *(int*)0x2F0348 = 0x38800000; *(int*)0x2F0398 = 0x38800001; } }
	void SURVIVAL_SLOT(bool toggle) { if (toggle) { *(int*)0x2F0378 = 0x38800001; *(int*)0x2F0368 = 0x38800000; } else { *(int*)0x2F0378 = 0x38800000; *(int*)0x2F0368 = 0x38800001; } }
	void KILL_SPAWN_ENTITY(bool toggle) { if (toggle) { *(int*)0x5BF34C = 0xFFE04890; } else { *(int*)0x5BF34C = 0xFFE00890; } }
	void STOP_BLOCKS_GRAVITY(bool toggle) { if (toggle) { *(int*)0x246A2C = 0xFF800000; } else { *(int*)0x246A2C = 0x3F800000; } }
	void NO_DELAY_HIT(bool toggle) { if (toggle) { *(int*)0x3A3FF0 = 0x3FFF0000; } else { *(int*)0x3A3FF0 = 0x3F000000; } }
	void BYPASS_MAX_ITEMS(bool toggle) { if (toggle) { *(int*)0x310AFC = 0x41820008; } else { *(int*)0x310AFC = 0x40820008; } }
	void INFINITE_FOOD(bool toggle) { if (toggle) { *(int*)0x310AFC = 0x40820008; } else { *(int*)0x310AFC = 0x40820008; } }
	void MOBS_IGNORE_ME(bool toggle) { if (toggle) { *(int*)0xA98F50 = 0x3F00CCCD; } else { *(int*)0xA98F50 = 0x3D4CCCCD; } }
	void DISABLE_PORTALS(bool toggle) { if (toggle) { *(int*)0x2379E4 = 0x38600000; } else { *(int*)0x2379E4 = 0x38600001; } }
	void KILL_ON_RESPAWN(bool toggle) { if (toggle) { *(int*)0x3A8678 = 0x4E800020; } else { *(int*)0x3A8678 = 0xF821FF91; } }
	void FREEZE_ALL_ENTITY(bool toggle) { if (toggle) { *(int*)0x3A9FE8 = 0x4E800020; } else { *(int*)0x3A9FE8 = 0xF821FF81; } }
	void STOP_ENDERMAN_TP(bool toggle) { if (toggle) { *(int*)0x3B30A8 = 0x4E800020; } else { *(int*)0x3B30A8 = 0xF821FEB1; } }
	void IGNORING_PRESSURE(bool toggle) { if (toggle) { *(int*)0x237BC8 = 0x38600001; } else { *(int*)0x237BC8 = 0x38600000; } }
	void ALL_ENCHANT(bool toggle) { if (toggle) { *(int*)0x218A4C = 0x3BE00010; } else { *(int*)0x218A4C = 0x3BE00000; } }
	void ITEMS_ON_HEAD(bool toggle) { if (toggle) { *(int*)0x428704 = 0x4082001C; } else { *(int*)0x428704 = 0x4182001C; } }
	void STOP_BOAT(bool toggle) { if (toggle) { *(int*)0xE0F90 = 0x41800034; } else { *(int*)0xE0F90 = 0x40800034; } }
	void NO_WEB(bool toggle) { if (toggle) { *(int*)0x234F9C = 0x38800000; } else { *(int*)0x234F9C = 0x38800001; } }
	void ENTITY_GOD_MODE(bool toggle) { if (toggle) { *(int*)0x003A3F6C = 0x4082004C; } else { *(int*)0x003A3F6C = 0x4182004C; } }
	void INFINITE_OXYGEN(bool toggle) { if (toggle) { *(int*)0x0039DE28 = 0x4182002C; } else { *(int*)0x0039DE28 = 0x4082002C; } }
	void REGENERATE_HEART(bool toggle) { if (toggle) { *(int*)0x002ADCE8 = 0x68630000; } else { *(int*)0x002ADCE8 = 0x68630001; } }
	void LOCK_GAMEMODE(bool toggle) { if (toggle) { *(int*)0x002F03D0 = 0x4182000C; } else { *(int*)0x002F03D0 = 0x4082000C; } }
	void LOCK_WEATHER(bool toggle) { if (toggle) { *(int*)0x00393E84 = 0x4182048C; } else { *(int*)0x00393E84 = 0x4082048C; } }
	void FAST_BOW(bool toggle) { if (toggle) { *(int*)0x000FB4C4 = 0xFFE01818; } else { *(int*)0x000FB4C4 = 0xFFE00818; } }
	void DIRECTION_ARROWS(bool toggle) { if (toggle) { *(int*)0x000FB55C = 0x45400000; } else { *(int*)0x000FB55C = 0x40400000; } }


	bool inWorld() { return !(*(char*)0x3000CF6B != 0); }







































	void INSTANT_DAMAGE(int value)
	{
		char HEX[] = { NyTekCFW::IntToHex(value) };
		sys_dbg_write_process_memory(0x003A3FF0, &HEX, sizeof(HEX));
		sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &HEX, sizeof(HEX));
	}

	void GOD_MODE_FOR_ME(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x00 };
			sys_dbg_write_process_memory(0x002F0273, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x002F0273, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x01 };
			sys_dbg_write_process_memory(0x002F0273, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x002F0273, &HEX, sizeof(HEX));
		}
	}

	void TOTEM_GIVE_HEALTH(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x4E, 0x80, 0x00, 0x20 };
			sys_dbg_write_process_memory(0x003A52B0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003A52B0, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3F, 0x80, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x003A52B0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003A52B0, &HEX, sizeof(HEX));
		}
	}

	void TNT_NUCLEAR(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x42, 0x80, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x0051E0D0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0051E0D0, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x40, 0x80, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x0051E0D0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0051E0D0, &HEX, sizeof(HEX));
		}
	}

	void TNT_BIG_PARTICLES(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00245E58, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00245E58, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00245E58, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00245E58, &HEX, sizeof(HEX));
		}
	}

	void TNT_FLYING(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x2F, 0xA4 };
			sys_dbg_write_process_memory(0x0051E558, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0051E558, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3F, 0xA4 };
			sys_dbg_write_process_memory(0x0051E558, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0051E558, &HEX, sizeof(HEX));
		}
	}

	void TNT_INSTANT_EXPLODE(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x0051E6A0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0051E6A0, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x0051E6A0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0051E6A0, &HEX, sizeof(HEX));
		}
	}

	void TNT_GO_IN_GROUND(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x4F };
			sys_dbg_write_process_memory(0x0051E558, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0051E558, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3F };
			sys_dbg_write_process_memory(0x0051E558, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0051E558, &HEX, sizeof(HEX));
		}
	}

	void TNT_SOUND_OFF(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xFF, 0x60, 0x18, 0x90 };
			sys_dbg_write_process_memory(0x00245BE4, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00245BE4, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0xFF, 0x60, 0x08, 0x90 };
			sys_dbg_write_process_memory(0x00245BE4, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00245BE4, &HEX, sizeof(HEX));
		}
	}

	void BIG_CREEPER(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x001CC81C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x001CC81C, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x001CC81C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x001CC81C, &HEX, sizeof(HEX));
		}
	}

	void CREEPER_NUCLEAR(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x3F, 0xFF };
			sys_dbg_write_process_memory(0x001CC7E0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x001CC7E0, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3F, 0x80 };
			sys_dbg_write_process_memory(0x001CC7E0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x001CC7E0, &HEX, sizeof(HEX));
		}
	}

	void CREEPER_FIRE(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x39, 0x40, 0x00, 0x10 };
			sys_dbg_write_process_memory(0x001CC894, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x001CC894, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x39, 0x40, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x001CC894, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x001CC894, &HEX, sizeof(HEX));
		}
	}

	void DISABLE_TOTEM(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x4E, 0x80, 0x00, 0x20 };
			sys_dbg_write_process_memory(0x003A52B8, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003A52B8, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0xF8, 0x21, 0xFF, 0x41 };
			sys_dbg_write_process_memory(0x003A52B8, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003A52B8, &HEX, sizeof(HEX));
		}
	}

	void GLITCHED_DEAD_ENTITY(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x18 };
			sys_dbg_write_process_memory(0x00EA89E2, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00EA89E2, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x08 };
			sys_dbg_write_process_memory(0x00EA89E2, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00EA89E2, &HEX, sizeof(HEX));
		}
	}

	void DISABLE_SPAWN_MOBS(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x004619E4, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x004619E4, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x004619E4, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x004619E4, &HEX, sizeof(HEX));
		}
	}

	void SUPER_SPEED(int value)
	{
		char HEX[] = { NyTekCFW::IntToHex(value) };
		sys_dbg_write_process_memory(0x003ABD49, &HEX, sizeof(HEX));
		sys_dbg_write_process_memory_ps3mapi(0x003ABD49, &HEX, sizeof(HEX));
	}

	void MULTI_JUMP(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x14 };
			sys_dbg_write_process_memory(0x0022790B, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0022790B, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x18 };
			sys_dbg_write_process_memory(0x0022790B, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0022790B, &HEX, sizeof(HEX));
		}
	}

	void JUMP_FOR_BUILD(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xFC, 0x80 };
			sys_dbg_write_process_memory(0x002271F4, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x002271F4, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0xFC, 0x20 };
			sys_dbg_write_process_memory(0x002271F4, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x002271F4, &HEX, sizeof(HEX));
		}
	}

	void JUMP_IN_SKY(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00011ADC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00011ADC, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00011ADC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00011ADC, &HEX, sizeof(HEX));
		}
	}

	void SUPER_JUMP(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x3F, 0x47, 0x7F, 0x42 };
			sys_dbg_write_process_memory(0x003AA77C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003AA77C, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3E, 0xD7, 0x0A, 0x3D };
			sys_dbg_write_process_memory(0x003AA77C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003AA77C, &HEX, sizeof(HEX));
		}
	}

	void SUPER_JUMP_V2(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x3F };
			sys_dbg_write_process_memory(0x003AA77C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003AA77C, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3E };
			sys_dbg_write_process_memory(0x003AA77C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003AA77C, &HEX, sizeof(HEX));
		}
	}

	void JUMP_FORWARD(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x80 };
			sys_dbg_write_process_memory(0x003AA999, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003AA999, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x68 };
			sys_dbg_write_process_memory(0x003AA999, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003AA999, &HEX, sizeof(HEX));
		}
	}

	void REMOVE_JUMP(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xF4 };
			sys_dbg_write_process_memory(0x003ABDC9, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABDC9, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0xB4 };
			sys_dbg_write_process_memory(0x003ABDC9, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABDC9, &HEX, sizeof(HEX));
		}
	}

	void JUMP_SPEED(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xA0 };
			sys_dbg_write_process_memory(0x003AA999, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003AA999, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x68 };
			sys_dbg_write_process_memory(0x003AA999, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003AA999, &HEX, sizeof(HEX));
		}
	}

	void SWIM_FLY(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x3B, 0x40, 0x00, 0x10 };
			sys_dbg_write_process_memory(0x00390410, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00390410, &HEX, sizeof(HEX));

			char HEX1[] = { 0x3D };
			sys_dbg_write_process_memory(0x003ABD44, &HEX1, sizeof(HEX1));
			sys_dbg_write_process_memory_ps3mapi(0x003ABD44, &HEX1, sizeof(HEX1));
		}
		else
		{
			char HEX[] = { 0x3B, 0x40, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x00390410, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00390410, &HEX, sizeof(HEX));

			char HEX1[] = { 0x3C };
			sys_dbg_write_process_memory(0x003ABD44, &HEX1, sizeof(HEX1));
			sys_dbg_write_process_memory_ps3mapi(0x003ABD44, &HEX1, sizeof(HEX1));
		}
	}

	void MOVEMENT_SWIM(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xBC };
			sys_dbg_write_process_memory(0x003ABD44, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABD44, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3C };
			sys_dbg_write_process_memory(0x003ABD44, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABD44, &HEX, sizeof(HEX));
		}
	}

	void SWIM_GLITCH(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00B0229C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B0229C, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00B0229C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B0229C, &HEX, sizeof(HEX));
		}
	}

	void NO_COLISSION(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
			sys_dbg_write_process_memory(0x00011230, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00011230, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x00011230, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00011230, &HEX, sizeof(HEX));
		}
	}

	void NO_COLISSION_BYPASS(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x002271B0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x002271B0, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x002271B0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x002271B0, &HEX, sizeof(HEX));
		}
	}

	void FLY_MODE_X(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00B023EC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B023EC, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00B023EC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B023EC, &HEX, sizeof(HEX));
		}
	}

	void ITEMS_IDS(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x003097C8, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003097C8, &HEX, sizeof(HEX));

			char HEX1[] = { 0x40 };
			sys_dbg_write_process_memory(0x003097B8, &HEX1, sizeof(HEX1));
			sys_dbg_write_process_memory_ps3mapi(0x003097B8, &HEX1, sizeof(HEX1));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x003097C8, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003097C8, &HEX, sizeof(HEX));

			char HEX1[] = { 0x41 };
			sys_dbg_write_process_memory(0x003097B8, &HEX1, sizeof(HEX1));
			sys_dbg_write_process_memory_ps3mapi(0x003097B8, &HEX1, sizeof(HEX1));
		}
	}

	void ANTI_KICK(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00AEE434, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEE434, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00AEE434, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEE434, &HEX, sizeof(HEX));
		}
	}

	void STUCK_IN_BLOCK(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00389B3C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00389B3C, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00389B3C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00389B3C, &HEX, sizeof(HEX));
		}
	}

	void CHANGE_POSITION_VIEW(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00A99420, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00A99420, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00A99420, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00A99420, &HEX, sizeof(HEX));
		}
	}

	void FUNNY_SOUND(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xFF };
			sys_dbg_write_process_memory(0x00AEB090, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEB090, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3F };
			sys_dbg_write_process_memory(0x00AEB090, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEB090, &HEX, sizeof(HEX));
		}
	}

	void FLOAT_UP(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x3F };
			sys_dbg_write_process_memory(0x003ABDC8, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABDC8, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0xBF };
			sys_dbg_write_process_memory(0x003ABDC8, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABDC8, &HEX, sizeof(HEX));
		}
	}

	void ESP_CHESTS(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x3E, 0xFF };
			sys_dbg_write_process_memory(0x00A9C2B4, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00A9C2B4, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3F, 0x80 };
			sys_dbg_write_process_memory(0x00A9C2B4, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00A9C2B4, &HEX, sizeof(HEX));
		}
	}

	void CAMERA_DOWN(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xFC, 0x02, 0x10 };
			sys_dbg_write_process_memory(0x004B1CE0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x004B1CE0, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0xFC, 0x01, 0x10 };
			sys_dbg_write_process_memory(0x004B1CE0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x004B1CE0, &HEX, sizeof(HEX));
		}
	}

	void INSTANT_MINE(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xBF };
			sys_dbg_write_process_memory(0x00AEB090, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEB090, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3F };
			sys_dbg_write_process_memory(0x00AEB090, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEB090, &HEX, sizeof(HEX));
		}
	}

	void INFINITE_CRAFT(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x01 };
			sys_dbg_write_process_memory(0x0098871F, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0098871F, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x00 };
			sys_dbg_write_process_memory(0x0098871F, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0098871F, &HEX, sizeof(HEX));
		}
	}

	void HUD_MINI_GAME(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00AD8480, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AD8480, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00AD8480, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AD8480, &HEX, sizeof(HEX));
		}
	}

	void ANTI_TELEPORT(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xFF, 0xFF, 0xFF, 0xFF };
			sys_dbg_write_process_memory(0x003AFB60, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003AFB60, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3F, 0x7A, 0xE1, 0x48 };
			sys_dbg_write_process_memory(0x003AFB60, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003AFB60, &HEX, sizeof(HEX));
		}
	}

	void UFO_MODE(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x3F, 0x00, 0x7A, 0xFF };
			sys_dbg_write_process_memory(0x003ABDD0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABDD0, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3F, 0xEF, 0x5C, 0x29 };
			sys_dbg_write_process_memory(0x003ABDD0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABDD0, &HEX, sizeof(HEX));
		}
	}

	void ANTI_AFK(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x3F, 0x80 };
			sys_dbg_write_process_memory(0x002267B0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x002267B0, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x00, 0x00 };
			sys_dbg_write_process_memory(0x002267B0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x002267B0, &HEX, sizeof(HEX));
		}
	}

	void SENSIBILITY_FAST(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x42, 0xFF };
			sys_dbg_write_process_memory(0x00ABA948, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00ABA948, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x42, 0x48 };
			sys_dbg_write_process_memory(0x00ABA948, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00ABA948, &HEX, sizeof(HEX));
		}
	}

	void SENSIBILITY_EXTREM(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x45, 0xFF };
			sys_dbg_write_process_memory(0x00ABA948, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00ABA948, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x42, 0x48 };
			sys_dbg_write_process_memory(0x00ABA948, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00ABA948, &HEX, sizeof(HEX));
		}
	}

	void WALK_ALONE(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xFF, 0x40 };
			sys_dbg_write_process_memory(0x003ABE18, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABE18, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0xFF, 0x20 };
			sys_dbg_write_process_memory(0x003ABE18, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABE18, &HEX, sizeof(HEX));
		}
	}

	void NAME_OVER_HEAD(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x4C };
			sys_dbg_write_process_memory(0x00AD8158, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AD8158, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x2C };
			sys_dbg_write_process_memory(0x00AD8158, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AD8158, &HEX, sizeof(HEX));
		}
	}

	void NAME_OVER_HEAD_V2(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xFF, 0xC0, 0xE0, 0x90 };
			sys_dbg_write_process_memory(0x00AD8110, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AD8110, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0xFF, 0xC0, 0x10, 0x90 };
			sys_dbg_write_process_memory(0x00AD8110, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AD8110, &HEX, sizeof(HEX));
		}
	}

	void STATIC_MOVEMENT(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xFF, 0xA0, 0x18, 0x90 };
			sys_dbg_write_process_memory(0x00A98FA4, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00A98FA4, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0xFF, 0xA0, 0x08, 0x90 };
			sys_dbg_write_process_memory(0x00A98FA4, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00A98FA4, &HEX, sizeof(HEX));
		}
	}

	void WALK_IN_SKY(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00011B00, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00011B00, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00011B00, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00011B00, &HEX, sizeof(HEX));
		}
	}

	void GRAVITY_MOON(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x003ABF88, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABF88, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x003ABF88, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABF88, &HEX, sizeof(HEX));
		}
	}

	void LOOK_FORBACK(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x23 };
			sys_dbg_write_process_memory(0x00A97F2C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00A97F2C, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x43 };
			sys_dbg_write_process_memory(0x00A97F2C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00A97F2C, &HEX, sizeof(HEX));
		}
	}

	void CAMERA_DOWN_R3(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xFC, 0x00, 0xF8, 0x90 };
			sys_dbg_write_process_memory(0x004B1D60, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x004B1D60, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0xFC, 0x20, 0xF8, 0x90 };
			sys_dbg_write_process_memory(0x004B1D60, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x004B1D60, &HEX, sizeof(HEX));
		}
	}

	void BETTER_TIME(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x0F };
			sys_dbg_write_process_memory(0x00A9A6DC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00A9A6DC, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3F };
			sys_dbg_write_process_memory(0x00A9A6DC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00A9A6DC, &HEX, sizeof(HEX));
		}
	}

	void SEE_OUT_MAP(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xDF };
			sys_dbg_write_process_memory(0x00A97F34, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00A97F34, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3F };
			sys_dbg_write_process_memory(0x00A97F34, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00A97F34, &HEX, sizeof(HEX));
		}
	}

	void SCAFFOLD(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x86 };
			sys_dbg_write_process_memory(0x003ABD49, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABD49, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x26 };
			sys_dbg_write_process_memory(0x003ABD49, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABD49, &HEX, sizeof(HEX));
		}
	}

	void DAY_NIGHT(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x2F };
			sys_dbg_write_process_memory(0x014C6880, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x014C6880, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3F };
			sys_dbg_write_process_memory(0x014C6880, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x014C6880, &HEX, sizeof(HEX));;
		}
	}

	void ESP_PLAYERS(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00AD5B60, &HEX, sizeof(HEX));

			char HEX1[] = { 0x6F, 0xFF };
			sys_dbg_write_process_memory(0x00AD5A5C, &HEX1, sizeof(HEX1));

			sys_dbg_write_process_memory_ps3mapi(0x00AD5B60, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AD5A5C, &HEX1, sizeof(HEX1));
		}
		else
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00AD5B60, &HEX, sizeof(HEX));

			char HEX1[] = { 0x3F, 0x80 };
			sys_dbg_write_process_memory(0x00AD5A5C, &HEX1, sizeof(HEX1));

			sys_dbg_write_process_memory_ps3mapi(0x00AD5B60, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AD5A5C, &HEX1, sizeof(HEX1));
		}
	}

	void CAN_FLY(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00B02378, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B02378, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00B02378, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B02378, &HEX, sizeof(HEX));
		}
	}

	void NO_COLISSION_ENTITY(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x000108AC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x000108AC, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x000108AC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x000108AC, &HEX, sizeof(HEX));
		}
	}

	void ALWAYS_CROUCH(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x01 };
			sys_dbg_write_process_memory(0x00B0142B, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B0142B, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x00 };
			sys_dbg_write_process_memory(0x00B0142B, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B0142B, &HEX, sizeof(HEX));
		}
	}

	void GET_PLAYERS_IDS(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x01 };
			sys_dbg_write_process_memory(0x004B5DF3, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x004B5DF3, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x00 };
			sys_dbg_write_process_memory(0x004B5DF3, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x004B5DF3, &HEX, sizeof(HEX));
		}
	}

	void PLAYERS_ON_ELYTRA(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x4E, 0x80, 0x00, 0x20 };
			sys_dbg_write_process_memory(0x003B3008, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003B3008, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0xF8, 0x21, 0xFF, 0x91 };
			sys_dbg_write_process_memory(0x003B3008, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003B3008, &HEX, sizeof(HEX));
		}
	}

	void WATER_SLOWDOWN(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x3F, 0x7C, 0xCC, 0xCD };
			sys_dbg_write_process_memory(0x0003AA964, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0003AA964, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3F, 0x4C, 0xCC, 0xCD };
			sys_dbg_write_process_memory(0x0003AA964, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0003AA964, &HEX, sizeof(HEX));
		}
	}

	void JUMP_IN_LAVA(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x3F, 0xF4, 0x7A, 0xE1 };
			sys_dbg_write_process_memory(0x003AA940, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003AA940, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3F, 0xBA, 0xCC, 0xCD };
			sys_dbg_write_process_memory(0x003AA940, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003AA940, &HEX, sizeof(HEX));
		}
	}

	void CROUCH_MOVEMENT(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x0F };
			sys_dbg_write_process_memory(0x00B0143F, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B0143F, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x0E };
			sys_dbg_write_process_memory(0x00B0143F, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B0143F, &HEX, sizeof(HEX));
		}
	}

	void POSITION_PLACE_BLOCK(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x28 };
			sys_dbg_write_process_memory(0x0022C85A, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0022C85A, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x08 };
			sys_dbg_write_process_memory(0x0022C85A, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x0022C85A, &HEX, sizeof(HEX));
		}
	}

	void DESTROY_GAME(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x48 };
			sys_dbg_write_process_memory(0x00B21C96, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B21C96, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x08 };
			sys_dbg_write_process_memory(0x00B21C96, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B21C96, &HEX, sizeof(HEX));
		}
	}

	void LEVITATION(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xBF };
			sys_dbg_write_process_memory(0x003ABDD0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABDD0, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3F };
			sys_dbg_write_process_memory(0x003ABDD0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABDD0, &HEX, sizeof(HEX));
		}
	}

	void RETURN_IN_XMB(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00AD8320, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AD8320, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00AD8320, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AD8320, &HEX, sizeof(HEX));
		}
	}

	void RETURN_IN_XMB_V2(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00785DBC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00785DBC, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00785DBC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00785DBC, &HEX, sizeof(HEX));
		}
	}

	void ADD_FAKE_CLONE(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00AEFA74, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEFA74, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00AEFA74, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEFA74, &HEX, sizeof(HEX));
		}
	}

	void INVISIBLE_PLAYERS(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00011ADC, &HEX, sizeof(HEX));

			char HEX1[] = { 0x3F, 0xFF };
			sys_dbg_write_process_memory(0x003ABDD0, &HEX1, sizeof(HEX1));

			sys_dbg_write_process_memory_ps3mapi(0x00011ADC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABDD0, &HEX1, sizeof(HEX1));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00011ADC, &HEX, sizeof(HEX));

			char HEX1[] = { 0x3F, 0xEF };
			sys_dbg_write_process_memory(0x003ABDD0, &HEX1, sizeof(HEX1));

			sys_dbg_write_process_memory_ps3mapi(0x00011ADC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABDD0, &HEX1, sizeof(HEX1));
		}
	}

	void AUTO_LADDER(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x01 };
			sys_dbg_write_process_memory(0x003A74F3, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003A74F3, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x00 };
			sys_dbg_write_process_memory(0x003A74F3, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003A74F3, &HEX, sizeof(HEX));
		}
	}

	void AIR_TO_WATER(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x001D7FCC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x001D7FCC, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x001D7FCC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x001D7FCC, &HEX, sizeof(HEX));
		}
	}

	void MULTI_JUMP_V2(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x02 };
			sys_dbg_write_process_memory(0x003B000A, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003B000A, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x01 };
			sys_dbg_write_process_memory(0x003B000A, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003B000A, &HEX, sizeof(HEX));
		}
	}

	void SUICIDE_MODE(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x3F, 0xFF };
			sys_dbg_write_process_memory(0x003ABDD0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABDD0, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x3F, 0xEF };
			sys_dbg_write_process_memory(0x003ABDD0, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x003ABDD0, &HEX, sizeof(HEX));
		}
	}

	void GAME_SPEED_STATIC(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00AEFE64, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEFE64, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00AEFE64, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEFE64, &HEX, sizeof(HEX));
		}
	}

	void AUTO_JUMP(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00B01BAC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B01BAC, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00B01BAC, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00B01BAC, &HEX, sizeof(HEX));
		}
	}

	void AUTO_CHANGE_VIEW(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00AEF56C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEF56C, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00AEF56C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEF56C, &HEX, sizeof(HEX));
		}
	}

	void AUTO_CROUCH(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00AEF514, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEF514, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00AEF514, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEF514, &HEX, sizeof(HEX));
		}
	}

	void AUTO_MINE(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x40 };
			sys_dbg_write_process_memory(0x00AEC42C, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00AEC42C, &MOD, sizeof(MOD));
		}
		else
		{
			char MOD[] = { 0x41 };
			sys_dbg_write_process_memory(0x00AEC42C, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00AEC42C, &MOD, sizeof(MOD));
		}
	}

	void AUTO_HIT(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00AEC34C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEC34C, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00AEC34C, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEC34C, &HEX, sizeof(HEX));
		}
	}

	void AUTO_TOSS_ITEMS(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00AEF428, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEF428, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00AEF428, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AEF428, &HEX, sizeof(HEX));
		}
	}

	void AUTO_BUILD(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x40 };
			sys_dbg_write_process_memory(0x00AECF10, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AECF10, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x41 };
			sys_dbg_write_process_memory(0x00AECF10, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x00AECF10, &HEX, sizeof(HEX));
		}
	}

	void BAT_EGGS_CRASH(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x08 };
			sys_dbg_write_process_memory(0x324193B9, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x324193B9, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x00 };
			sys_dbg_write_process_memory(0x324193B9, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x324193B9, &HEX, sizeof(HEX));
		}
	}

	void BAT_EGGS_FREEZE(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x01 };
			sys_dbg_write_process_memory(0x324193B9, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x324193B9, &HEX, sizeof(HEX));
		}
		else
		{
			char HEX[] = { 0x00 };
			sys_dbg_write_process_memory(0x324193B9, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x324193B9, &HEX, sizeof(HEX));
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
		}
	}

	void AUTO_SPRINT(bool toggle)
	{
		if (toggle)
		{
			char SPEED[] = { 0x40 };
			sys_dbg_write_process_memory(0x00B01DEC, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00B01DEC, &SPEED, sizeof(SPEED));
		}
		else
		{
			char SPEED[] = { 0x41 };
			sys_dbg_write_process_memory(0x00B01DEC, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00B01DEC, &SPEED, sizeof(SPEED));
		}
	}

	void AUTO_SPRINT_V2(bool toggle)
	{
		if (toggle)
		{
			char SPEED[] = { 0x00 };
			sys_dbg_write_process_memory(0x00B01EEF, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00B01EEF, &SPEED, sizeof(SPEED));
		}
		else
		{
			char SPEED[] = { 0x01 };
			sys_dbg_write_process_memory(0x00B01EEF, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00B01EEF, &SPEED, sizeof(SPEED));
		}
	}

	void INSTANT_HIT(bool toggle)
	{
		if (toggle)
		{
			char SPEED[] = { 0xFF };
			sys_dbg_write_process_memory(0x00AEBED4, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00AEBED4, &SPEED, sizeof(SPEED));
		}
		else
		{
			char SPEED[] = { 0x3E };
			sys_dbg_write_process_memory(0x00AEBED4, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00AEBED4, &SPEED, sizeof(SPEED));
		}
	}

	void KILL_AURA(bool toggle)
	{
		if (toggle)
		{
			char SPEED[] = { 0xFF };
			sys_dbg_write_process_memory(0x00233290, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00233290, &SPEED, sizeof(SPEED));
		}
		else
		{
			char SPEED[] = { 0x00 };
			sys_dbg_write_process_memory(0x00233290, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00233290, &SPEED, sizeof(SPEED));
		}
	}

	void FAST_BUILD(bool toggle)
	{
		if (toggle)
		{
			char SPEED[] = { 0x40 };
			sys_dbg_write_process_memory(0x00AECE70, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00AECE70, &SPEED, sizeof(SPEED));
		}
		else
		{
			char SPEED[] = { 0x41 };
			sys_dbg_write_process_memory(0x00AECE70, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00AECE70, &SPEED, sizeof(SPEED));
		}
	}

	void CRITICAL_MODE(bool toggle)
	{
		if (toggle)
		{
			char SPEED[] = { 0x3F, 0xAF };
			sys_dbg_write_process_memory(0x003ABDD0, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x003ABDD0, &SPEED, sizeof(SPEED));
		}
		else
		{
			char SPEED[] = { 0x3F, 0xEF };
			sys_dbg_write_process_memory(0x003ABDD0, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x003ABDD0, &SPEED, sizeof(SPEED));
		}
	}

	void CRITICAL_MODE_V1(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x3E, 0x27 };
			char MOD2[] = { 0xFF };
			char MOD3[] = { 0xFF, 0xFF };
			char MOD4[] = { 0x41 };

			sys_dbg_write_process_memory(0x003AA77C, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory(0x00233290, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory(0x00AEBED4, &MOD3, sizeof(MOD3));
			sys_dbg_write_process_memory(0x00B01BAC, &MOD4, sizeof(MOD4));
			sys_dbg_write_process_memory_ps3mapi(0x003AA77C, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00233290, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x00AEBED4, &MOD3, sizeof(MOD3));
			sys_dbg_write_process_memory_ps3mapi(0x00B01BAC, &MOD4, sizeof(MOD4));
		}
		else
		{
			char MOD[] = { 0x3E, 0xD7 };
			char MOD2[] = { 0x00 };
			char MOD3[] = { 0x3E, 0x80 };
			char MOD4[] = { 0x40 };

			sys_dbg_write_process_memory(0x003AA77C, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory(0x00233290, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory(0x00AEBED4, &MOD3, sizeof(MOD3));
			sys_dbg_write_process_memory(0x00B01BAC, &MOD4, sizeof(MOD4));
			sys_dbg_write_process_memory_ps3mapi(0x003AA77C, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00233290, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x00AEBED4, &MOD3, sizeof(MOD3));
			sys_dbg_write_process_memory_ps3mapi(0x00B01BAC, &MOD4, sizeof(MOD4));
		}
	}

	void NO_SLOW_DOWN(bool toggle)
	{
		if (toggle)
		{
			char SPEED[] = { 0x4F };
			sys_dbg_write_process_memory(0x003AFB60, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x003AFB60, &SPEED, sizeof(SPEED));
		}
		else
		{
			char SPEED[] = { 0x3F };
			sys_dbg_write_process_memory(0x003AFB60, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x003AFB60, &SPEED, sizeof(SPEED));
		}
	}

	void REMOVE_HURT_CAM(bool toggle)
	{
		if (toggle)
		{
			char SPEED[] = { 0x00, 0x00 };
			sys_dbg_write_process_memory(0x00A972B0, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00A972B0, &SPEED, sizeof(SPEED));
		}
		else
		{
			char SPEED[] = { 0x40, 0x49 };
			sys_dbg_write_process_memory(0x00A972B0, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00A972B0, &SPEED, sizeof(SPEED));
		}
	}

	void PRESS_X_FOR_HIT(bool toggle)
	{
		if (toggle)
		{
			char SPEED[] = { 0x0F };
			sys_dbg_write_process_memory(0x00AEEB83, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00AEEB83, &SPEED, sizeof(SPEED));
		}
		else
		{
			char SPEED[] = { 0x01 };
			sys_dbg_write_process_memory(0x00AEEB83, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00AEEB83, &SPEED, sizeof(SPEED));
		}
	}

	void SHOW_ARMOR(bool toggle)
	{
		if (toggle)
		{
			char SPEED[] = { 0x38, 0x80, 0x00, 0x01 };
			sys_dbg_write_process_memory(0x0090B5F0, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x0090B5F0, &SPEED, sizeof(SPEED));
		}
		else
		{
			char SPEED[] = { 0x38, 0x80, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x0090B5F0, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x0090B5F0, &SPEED, sizeof(SPEED));
		}
	}

	void UNFAIR_ATTACK(bool toggle)
	{
		if (toggle)
		{
			char SPEED[] = { 0xBE };
			sys_dbg_write_process_memory(0x00AEBED4, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00AEBED4, &SPEED, sizeof(SPEED));
		}
		else
		{
			char SPEED[] = { 0x3E };
			sys_dbg_write_process_memory(0x00AEBED4, &SPEED, sizeof(SPEED));
			sys_dbg_write_process_memory_ps3mapi(0x00AEBED4, &SPEED, sizeof(SPEED));
		}
	}

	void HITBOX_BETA(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x01 };
			char MOD1[] = { 0xFF };

			sys_dbg_write_process_memory(0x0003AE03, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory(0x00233290, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0003AE03, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00233290, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD[] = { 0x00 };
			char MOD1[] = { 0x00 };

			sys_dbg_write_process_memory(0x0003AE03, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory(0x00233290, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0003AE03, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00233290, &MOD1, sizeof(MOD1));
		}
	}

	void BLOCK_STATIC_CRACK(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x01 };
			sys_dbg_write_process_memory(0x00AE3C3F, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00AE3C3F, &MOD, sizeof(MOD));
		}
		else
		{
			char MOD[] = { 0x00 };
			sys_dbg_write_process_memory(0x00AE3C3F, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00AE3C3F, &MOD, sizeof(MOD));
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
		}
	}

	void BIG_VELOCITY(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0xD3, 0x23, 0x01, 0x30 };
			char MOD1[] = { 0xD8, 0x43, 0x01, 0x38 };
			char MOD2[] = { 0xD9, 0x63, 0x01, 0x40 };

			sys_dbg_write_process_memory(0x002335C8, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory(0x002335CC, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory(0x002335D0, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x002335C8, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x002335CC, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x002335D0, &MOD2, sizeof(MOD2));
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
		}
	}

	void DRAGON_EGGS_SPAWNER(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x30, 0x99, 0xE7, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0C };
			sys_dbg_write_process_memory(0x32418D18, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x32418D18, &MOD, sizeof(MOD));
		}
		else
		{
			char MOD[] = { 0x30, 0x99, 0xD3, 0xE0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E };
			sys_dbg_write_process_memory(0x32418D18, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x32418D18, &MOD, sizeof(MOD));
		}
	}

	void GOLEM_EGGS_SPAWNER(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x30, 0x99, 0xF6, 0xA0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E };
			sys_dbg_write_process_memory(0x32418D18, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x32418D18, &MOD, sizeof(MOD));
		}
		else
		{
			char MOD[] = { 0x30, 0x99, 0xD3, 0xE0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E };
			sys_dbg_write_process_memory(0x32418D18, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x32418D18, &MOD, sizeof(MOD));
		}
	}

	void WITHER_EGGS_SPAWNER(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x77, 0x00, 0x69, 0x00, 0x74, 0x00, 0x68, 0x00, 0x65, 0x00, 0x72, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x06 };
			sys_dbg_write_process_memory(0x32418A79, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x32418A79, &MOD, sizeof(MOD));
		}
		else
		{
			char MOD[] = { 0x73, 0x00, 0x68, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x6B, 0x00, 0x65, 0x00, 0x72, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07 };
			sys_dbg_write_process_memory(0x32418A79, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x32418A79, &MOD, sizeof(MOD));
		}
	}

	void ALL_PLAYERS_FAST_MINE(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0xFF, 0xE0, 0x28, 0x90 };
			sys_dbg_write_process_memory(0x0010E0C4, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x0010E0C4, &MOD, sizeof(MOD));
		}
		else
		{
			char MOD[] = { 0xFF, 0xE0, 0x08, 0x90 };
			sys_dbg_write_process_memory(0x0010E0C4, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x0010E0C4, &MOD, sizeof(MOD));
		}
	}

	void ALL_PLAYERS_CANNOT_MINE(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0xFF, 0xE0, 0x18, 0x90 };
			sys_dbg_write_process_memory(0x0010E0C4, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x0010E0C4, &MOD, sizeof(MOD));
		}
		else
		{
			char MOD[] = { 0xFF, 0xE0, 0x08, 0x90 };
			sys_dbg_write_process_memory(0x0010E0C4, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x0010E0C4, &MOD, sizeof(MOD));
		}
	}

	void ALL_PLAYERS_CANT_RUN(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0xFF, 0xE0, 0x00, 0x90 };
			sys_dbg_write_process_memory(0x00018CE4, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00018CE4, &MOD, sizeof(MOD));
		}
		else
		{
			char MOD[] = { 0xFF, 0xE0, 0x08, 0x90 };
			sys_dbg_write_process_memory(0x00018CE4, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00018CE4, &MOD, sizeof(MOD));
		}
	}

	void ALL_PLAYERS_SUPER_SPEED(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0xFF, 0xE0, 0x28, 0x90 };
			sys_dbg_write_process_memory(0x00018CE4, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00018CE4, &MOD, sizeof(MOD));
		}
		else
		{
			char MOD[] = { 0xFF, 0xE0, 0x08, 0x90 };
			sys_dbg_write_process_memory(0x00018CE4, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00018CE4, &MOD, sizeof(MOD));
		}
	}

	void ALL_PLAYERS_SUPER_RUN(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x58 };
			sys_dbg_write_process_memory(0x004668B6, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x004668B6, &MOD, sizeof(MOD));
		}
		else
		{
			char MOD[] = { 0x08 };
			sys_dbg_write_process_memory(0x004668B6, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x004668B6, &MOD, sizeof(MOD));
		}
	}

	void ALL_PLAYERS_CANT_JOIN_THE_WORLD(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x01 };
			sys_dbg_write_process_memory(0x0098871F, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x0098871F, &MOD, sizeof(MOD));
		}
		else
		{
			char MOD[] = { 0x00 };
			sys_dbg_write_process_memory(0x0098871F, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x0098871F, &MOD, sizeof(MOD));
		}
	}

	void ALL_PLAYERS_CHANGE_HAND(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x30, 0x01, 0x87, 0xF0 };
			sys_dbg_write_process_memory(0x0151F2F0, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x0151F2F0, &MOD, sizeof(MOD));
		}
		else
		{
			char MOD[] = { 0x30, 0x01, 0x87, 0xF8 };
			sys_dbg_write_process_memory(0x0151F2F0, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x0151F2F0, &MOD, sizeof(MOD));
		}
	}

	void ALL_PLAYERS_SUFFOCATE(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x4E, 0x80, 0x00, 0x20 };
			sys_dbg_write_process_memory(0x0022FDC8, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD, sizeof(MOD));
		}
		else
		{
			char MOD[] = { 0xF8, 0x21, 0xFF, 0x11 };
			sys_dbg_write_process_memory(0x0022FDC8, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD, sizeof(MOD));
		}
	}

	void ALL_PLAYERS_IN_FIRE(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x40 };
			sys_dbg_write_process_memory(0x00225FA0, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00225FA0, &MOD, sizeof(MOD));
		}
		else
		{
			char MOD[] = { 0x41 };
			sys_dbg_write_process_memory(0x00225FA0, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00225FA0, &MOD, sizeof(MOD));
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
	}

	void WEATHER_DARK_STORM(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x3F, 0xFF };
			sys_dbg_write_process_memory(0x00393E34, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00393E34, &MOD, sizeof(MOD));
		}
		else
		{
			char MOD[] = { 0x3F, 0x80 };
			sys_dbg_write_process_memory(0x00393E34, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00393E34, &MOD, sizeof(MOD));
		}
	}

	void WEATHER_RAINBOW_STORM(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x4F, 0x80 };
			sys_dbg_write_process_memory(0x00393E34, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00393E34, &MOD, sizeof(MOD));
		}
		else
		{
			char MOD[] = { 0x3F, 0x80 };
			sys_dbg_write_process_memory(0x00393E34, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00393E34, &MOD, sizeof(MOD));
		}
	}

	void WEATHER_RAIN_TO_SNOW(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x7E };
			sys_dbg_write_process_memory(0x01310954, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x01310954, &MOD, sizeof(MOD));
		}
		else
		{
			char MOD[] = { 0x3E };
			sys_dbg_write_process_memory(0x01310954, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x01310954, &MOD, sizeof(MOD));
		}
	}

	void WEATHER_RAINBOW_WITH_STORM(bool toggle)
	{
		if (toggle)
		{
			char MOD[] = { 0x7E };
			char MOD1[] = { 0x4F };

			sys_dbg_write_process_memory(0x01310954, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory(0x00393E34, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x01310954, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00393E34, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD[] = { 0x3E };
			char MOD1[] = { 0x3F };

			sys_dbg_write_process_memory(0x01310954, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory(0x00393E34, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x01310954, &MOD, sizeof(MOD));
			sys_dbg_write_process_memory_ps3mapi(0x00393E34, &MOD1, sizeof(MOD1));
		}
	}

	void WEATHER_FLASH_SKY(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xFF };
			sys_dbg_write_process_memory(0x00393E34, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00393E34, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3F };
			sys_dbg_write_process_memory(0x00393E34, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00393E34, &MOD1, sizeof(MOD1));
		}
	}

	void WEATHER_LIGHTNINGBOLD_V1(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x01 };
			sys_dbg_write_process_memory(0x0098871F, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0098871F, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x00 };
			sys_dbg_write_process_memory(0x0098871F, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0098871F, &MOD1, sizeof(MOD1));
		}
	}

	void WEATHER_LIGHTNINGBOLD_V2(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x01 };
			char MOD2[] = { 0xFF };

			sys_dbg_write_process_memory(0x0098871F, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory(0x00393E34, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x0098871F, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00393E34, &MOD2, sizeof(MOD2));
		}
		else
		{
			char MOD1[] = { 0x00 };
			char MOD2[] = { 0x3F };

			sys_dbg_write_process_memory(0x0098871F, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory(0x00393E34, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x0098871F, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00393E34, &MOD2, sizeof(MOD2));
		}
	}

	void EFFECT_WEAKNESS()
	{
		char MOD1[] = { 0x32, 0x1C, 0x0A, 0x60 };
		char MOD2[] = { 0x4E, 0x80, 0x00, 0x20 };
		char MOD3[] = { 0x40, 0x80 };
		char MOD7[] = { 0x32, 0x1B, 0xA5, 0x90 }; //EFFECT
		char MOD4[] = { 0x32, 0x20, 0xA4, 0xF0 };
		char MOD5[] = { 0xF8, 0x21, 0xFF, 0x11 };
		char MOD6[] = { 0x3F, 0x00 };
		char MOD8[] = { 0x32, 0x1B, 0x9D, 0x80 }; //EFFECT

		sys_dbg_write_process_memory(0x014C93F0, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory(0x0022FDC8, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory(0x003A3FF0, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory(0x014C9B48, &MOD7, sizeof(MOD7));
		sys_dbg_write_process_memory_ps3mapi(0x014C93F0, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory_ps3mapi(0x014C9B48, &MOD7, sizeof(MOD7));
		sleep(2000);
		sys_dbg_write_process_memory(0x014C93F0, &MOD4, sizeof(MOD4));
		sys_dbg_write_process_memory(0x0022FDC8, &MOD5, sizeof(MOD5));
		sys_dbg_write_process_memory(0x003A3FF0, &MOD6, sizeof(MOD6));
		sys_dbg_write_process_memory(0x014C9B48, &MOD7, sizeof(MOD7));
		sys_dbg_write_process_memory_ps3mapi(0x014C93F0, &MOD4, sizeof(MOD4));
		sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD5, sizeof(MOD5));
		sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &MOD6, sizeof(MOD6));
		sys_dbg_write_process_memory_ps3mapi(0x014C9B48, &MOD7, sizeof(MOD7));
	}

	void EFFECT_SPEED()
	{
		char MOD1[] = { 0x32, 0x1C, 0x0A, 0x60 };
		char MOD2[] = { 0x4E, 0x80, 0x00, 0x20 };
		char MOD3[] = { 0x40, 0x80 };
		char MOD7[] = { 0x32, 0x1B, 0x8C, 0xD0 }; //EFFECT
		char MOD4[] = { 0x32, 0x20, 0xA4, 0xF0 };
		char MOD5[] = { 0xF8, 0x21, 0xFF, 0x11 };
		char MOD6[] = { 0x3F, 0x00 };
		char MOD8[] = { 0x32, 0x1B, 0x9D, 0x80 }; //EFFECT

		sys_dbg_write_process_memory(0x014C93F0, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory(0x0022FDC8, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory(0x003A3FF0, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory(0x014C9B48, &MOD7, sizeof(MOD7));
		sys_dbg_write_process_memory_ps3mapi(0x014C93F0, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory_ps3mapi(0x014C9B48, &MOD7, sizeof(MOD7));

		sleep(2000);

		sys_dbg_write_process_memory(0x014C93F0, &MOD4, sizeof(MOD4));
		sys_dbg_write_process_memory(0x0022FDC8, &MOD5, sizeof(MOD5));
		sys_dbg_write_process_memory(0x003A3FF0, &MOD6, sizeof(MOD6));
		sys_dbg_write_process_memory(0x014C9B48, &MOD7, sizeof(MOD7));
		sys_dbg_write_process_memory_ps3mapi(0x014C93F0, &MOD4, sizeof(MOD4));
		sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD5, sizeof(MOD5));
		sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &MOD6, sizeof(MOD6));
		sys_dbg_write_process_memory_ps3mapi(0x014C9B48, &MOD7, sizeof(MOD7));
	}

	void EFFECT_SLOWNESS()
	{
		char MOD1[] = { 0x32, 0x1C, 0x0A, 0x60 };
		char MOD2[] = { 0x4E, 0x80, 0x00, 0x20 };
		char MOD3[] = { 0x40, 0x80 };
		char MOD7[] = { 0x32, 0x1B, 0x8D, 0x10 }; //EFFECT
		char MOD4[] = { 0x32, 0x20, 0xA4, 0xF0 };
		char MOD5[] = { 0xF8, 0x21, 0xFF, 0x11 };
		char MOD6[] = { 0x3F, 0x00 };
		char MOD8[] = { 0x32, 0x1B, 0x9D, 0x80 }; //EFFECT


		sys_dbg_write_process_memory(0x014C93F0, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory(0x0022FDC8, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory(0x003A3FF0, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory(0x014C9B48, &MOD7, sizeof(MOD7));
		sys_dbg_write_process_memory_ps3mapi(0x014C93F0, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory_ps3mapi(0x014C9B48, &MOD7, sizeof(MOD7));

		sleep(2000);

		sys_dbg_write_process_memory(0x014C93F0, &MOD4, sizeof(MOD4));
		sys_dbg_write_process_memory(0x0022FDC8, &MOD5, sizeof(MOD5));
		sys_dbg_write_process_memory(0x003A3FF0, &MOD6, sizeof(MOD6));
		sys_dbg_write_process_memory(0x014C9B48, &MOD7, sizeof(MOD7));
		sys_dbg_write_process_memory_ps3mapi(0x014C93F0, &MOD4, sizeof(MOD4));
		sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD5, sizeof(MOD5));
		sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &MOD6, sizeof(MOD6));
		sys_dbg_write_process_memory_ps3mapi(0x014C9B48, &MOD7, sizeof(MOD7));
	}

	void EFFECT_HASTE()
	{
		char MOD1[] = { 0x32, 0x1C, 0x0A, 0x60 };
		char MOD2[] = { 0x4E, 0x80, 0x00, 0x20 };
		char MOD3[] = { 0x40, 0x80 };
		char MOD7[] = { 0x32, 0x1B, 0x95, 0x40 }; //EFFECT
		char MOD4[] = { 0x32, 0x20, 0xA4, 0xF0 };
		char MOD5[] = { 0xF8, 0x21, 0xFF, 0x11 };
		char MOD6[] = { 0x3F, 0x00 };
		char MOD8[] = { 0x32, 0x1B, 0x9D, 0x80 }; //EFFECT


		sys_dbg_write_process_memory(0x014C93F0, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory(0x0022FDC8, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory(0x003A3FF0, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory(0x014C9B48, &MOD7, sizeof(MOD7));
		sys_dbg_write_process_memory_ps3mapi(0x014C93F0, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory_ps3mapi(0x014C9B48, &MOD7, sizeof(MOD7));

		sleep(2000);

		sys_dbg_write_process_memory(0x014C93F0, &MOD4, sizeof(MOD4));
		sys_dbg_write_process_memory(0x0022FDC8, &MOD5, sizeof(MOD5));
		sys_dbg_write_process_memory(0x003A3FF0, &MOD6, sizeof(MOD6));
		sys_dbg_write_process_memory(0x014C9B48, &MOD7, sizeof(MOD7));
		sys_dbg_write_process_memory_ps3mapi(0x014C93F0, &MOD4, sizeof(MOD4));
		sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD5, sizeof(MOD5));
		sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &MOD6, sizeof(MOD6));
		sys_dbg_write_process_memory_ps3mapi(0x014C9B48, &MOD7, sizeof(MOD7));
	}

	void EFFECT_MINE_FATIGUE()
	{
		char MOD1[] = { 0x32, 0x1C, 0x0A, 0x60 };
		char MOD2[] = { 0x4E, 0x80, 0x00, 0x20 };
		char MOD3[] = { 0x40, 0x80 };
		char MOD7[] = { 0x32, 0x1B, 0x96, 0x90 }; //EFFECT
		char MOD4[] = { 0x32, 0x20, 0xA4, 0xF0 };
		char MOD5[] = { 0xF8, 0x21, 0xFF, 0x11 };
		char MOD6[] = { 0x3F, 0x00 };
		char MOD8[] = { 0x32, 0x1B, 0x9D, 0x80 }; //EFFECT


		sys_dbg_write_process_memory(0x014C93F0, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory(0x0022FDC8, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory(0x003A3FF0, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory(0x014C9B48, &MOD7, sizeof(MOD7));
		sys_dbg_write_process_memory_ps3mapi(0x014C93F0, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory_ps3mapi(0x014C9B48, &MOD7, sizeof(MOD7));

		sleep(2000);

		sys_dbg_write_process_memory(0x014C93F0, &MOD4, sizeof(MOD4));
		sys_dbg_write_process_memory(0x0022FDC8, &MOD5, sizeof(MOD5));
		sys_dbg_write_process_memory(0x003A3FF0, &MOD6, sizeof(MOD6));
		sys_dbg_write_process_memory(0x014C9B48, &MOD7, sizeof(MOD7));
		sys_dbg_write_process_memory_ps3mapi(0x014C93F0, &MOD4, sizeof(MOD4));
		sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD5, sizeof(MOD5));
		sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &MOD6, sizeof(MOD6));
		sys_dbg_write_process_memory_ps3mapi(0x014C9B48, &MOD7, sizeof(MOD7));
	}

	void EFFECT_STRENGTH()
	{
		char MOD1[] = { 0x32, 0x1C, 0x0A, 0x60 };
		char MOD2[] = { 0x4E, 0x80, 0x00, 0x20 };
		char MOD3[] = { 0x40, 0x80 };
		char MOD7[] = { 0x32, 0x1B, 0x97, 0xE0 }; //EFFECT
		char MOD4[] = { 0x32, 0x20, 0xA4, 0xF0 };
		char MOD5[] = { 0xF8, 0x21, 0xFF, 0x11 };
		char MOD6[] = { 0x3F, 0x00 };
		char MOD8[] = { 0x32, 0x1B, 0x9D, 0x80 }; //EFFECT

		sys_dbg_write_process_memory(0x014C93F0, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory(0x0022FDC8, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory(0x003A3FF0, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory(0x014C9B48, &MOD7, sizeof(MOD7));
		sys_dbg_write_process_memory_ps3mapi(0x014C93F0, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory_ps3mapi(0x014C9B48, &MOD7, sizeof(MOD7));

		sleep(2000);

		sys_dbg_write_process_memory(0x014C93F0, &MOD4, sizeof(MOD4));
		sys_dbg_write_process_memory(0x0022FDC8, &MOD5, sizeof(MOD5));
		sys_dbg_write_process_memory(0x003A3FF0, &MOD6, sizeof(MOD6));
		sys_dbg_write_process_memory(0x014C9B48, &MOD7, sizeof(MOD7));
		sys_dbg_write_process_memory_ps3mapi(0x014C93F0, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory_ps3mapi(0x014C9B48, &MOD7, sizeof(MOD7));
	}

	void EFFECT_INSTANT_HEALTH()
	{
		char MOD1[] = { 0x32, 0x1C, 0x0A, 0x60 };
		char MOD2[] = { 0x4E, 0x80, 0x00, 0x20 };
		char MOD3[] = { 0x40, 0x80 };
		char MOD7[] = { 0x32, 0x1B, 0x99, 0x40 }; //EFFECT
		char MOD4[] = { 0x32, 0x20, 0xA4, 0xF0 };
		char MOD5[] = { 0xF8, 0x21, 0xFF, 0x11 };
		char MOD6[] = { 0x3F, 0x00 };
		char MOD8[] = { 0x32, 0x1B, 0x9D, 0x80 }; //EFFECT


		sys_dbg_write_process_memory(0x014C93F0, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory(0x0022FDC8, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory(0x003A3FF0, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory(0x014C9B48, &MOD7, sizeof(MOD7));
		sys_dbg_write_process_memory_ps3mapi(0x014C93F0, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory_ps3mapi(0x014C9B48, &MOD7, sizeof(MOD7));

		sleep(2000);

		sys_dbg_write_process_memory(0x014C93F0, &MOD4, sizeof(MOD4));
		sys_dbg_write_process_memory(0x0022FDC8, &MOD5, sizeof(MOD5));
		sys_dbg_write_process_memory(0x003A3FF0, &MOD6, sizeof(MOD6));
		sys_dbg_write_process_memory(0x014C9B48, &MOD7, sizeof(MOD7));
		sys_dbg_write_process_memory_ps3mapi(0x014C93F0, &MOD4, sizeof(MOD4));
		sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD5, sizeof(MOD5));
		sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &MOD6, sizeof(MOD6));
		sys_dbg_write_process_memory_ps3mapi(0x014C9B48, &MOD7, sizeof(MOD7));
	}

	void EFFECT_INSTANT_DAMAGE()
	{
		char MOD1[] = { 0x32, 0x1C, 0x0A, 0x60 };
		char MOD2[] = { 0x4E, 0x80, 0x00, 0x20 };
		char MOD3[] = { 0x40, 0x80 };
		char MOD7[] = { 0x32, 0x1B, 0x9A, 0x40 }; //EFFECT
		char MOD4[] = { 0x32, 0x20, 0xA4, 0xF0 };
		char MOD5[] = { 0xF8, 0x21, 0xFF, 0x11 };
		char MOD6[] = { 0x3F, 0x00 };
		char MOD8[] = { 0x32, 0x1B, 0x9D, 0x80 }; //EFFECT

		sys_dbg_write_process_memory(0x014C93F0, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory(0x0022FDC8, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory(0x003A3FF0, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory(0x014C9B48, &MOD7, sizeof(MOD7));
		sys_dbg_write_process_memory_ps3mapi(0x014C93F0, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory_ps3mapi(0x014C9B48, &MOD7, sizeof(MOD7));

		sleep(2000);

		sys_dbg_write_process_memory(0x014C93F0, &MOD4, sizeof(MOD4));
		sys_dbg_write_process_memory(0x0022FDC8, &MOD5, sizeof(MOD5));
		sys_dbg_write_process_memory(0x003A3FF0, &MOD6, sizeof(MOD6));
		sys_dbg_write_process_memory(0x014C9B48, &MOD7, sizeof(MOD7));
		sys_dbg_write_process_memory_ps3mapi(0x014C93F0, &MOD4, sizeof(MOD4));
		sys_dbg_write_process_memory_ps3mapi(0x0022FDC8, &MOD5, sizeof(MOD5));
		sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &MOD6, sizeof(MOD6));
		sys_dbg_write_process_memory_ps3mapi(0x014C9B48, &MOD7, sizeof(MOD7));
	}

	//base title image = 0x31E7865C
	//base logo image = 0x31E7878C

	void ADD_CUSTOM_IMAGE(bool toggle)
	{
		if (toggle)
		{
			*(int*)0x31E7782C = 0x44700000; //pos
			*(int*)0x31E77830 = 0x40000000; //pos
		}
		else
		{

		}
	}

	void XRAY_VISON(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xFC, 0x80, 0x30, 0x90 };
			sys_dbg_write_process_memory(0x00A99154, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A99154, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0xFC, 0x60, 0x30, 0x90 };
			sys_dbg_write_process_memory(0x00A99154, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A99154, &MOD1, sizeof(MOD1));
		}
	}

	void NIGHT_VISON(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x7F };
			sys_dbg_write_process_memory(0x00A9A6C8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A9A6C8, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3F };
			sys_dbg_write_process_memory(0x00A9A6C8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A9A6C8, &MOD1, sizeof(MOD1));
		}
	}

	void APOCALIPSE(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xBF, 0xFF };
			char MOD2[] = { 0xCD, 0xC0, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x00AD5EC8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory(0x00410734, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x00AD5EC8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00410734, &MOD2, sizeof(MOD2));
		}
		else
		{
			char MOD1[] = { 0xBF, 0x80 };
			char MOD2[] = { 0x40, 0xC0, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x00AD5EC8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory(0x00410734, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x00AD5EC8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00410734, &MOD2, sizeof(MOD2));
		}
	}

	void FUNNY_SCREEN(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x50, 0x80 };
			sys_dbg_write_process_memory(0x00AD5EC8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AD5EC8, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0xBF, 0x80 };
			sys_dbg_write_process_memory(0x00AD5EC8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AD5EC8, &MOD1, sizeof(MOD1));
		}
	}

	void HORROR_VISION(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x4F, 0x80, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x00A9A6C8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A9A6C8, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3F, 0x80, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x00A9A6C8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A9A6C8, &MOD1, sizeof(MOD1));
		}
	}

	void ANIMATION_RUN(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xBF, 0x80 };
			sys_dbg_write_process_memory(0x003ACEF4, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x003ACEF4, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3F, 0x80 };
			sys_dbg_write_process_memory(0x003ACEF4, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x003ACEF4, &MOD1, sizeof(MOD1));
		}
	}

	void SIZE_HUD(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x41, 0x82 };
			sys_dbg_write_process_memory(0x0090FAC8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0090FAC8, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x40, 0x82 };
			sys_dbg_write_process_memory(0x0090FAC8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0090FAC8, &MOD1, sizeof(MOD1));
		}
	}

	void BROKEN_TEXTURE(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xAF };
			sys_dbg_write_process_memory(0x00A98F4C, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98F4C, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x40 };
			sys_dbg_write_process_memory(0x00A98F4C, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98F4C, &MOD1, sizeof(MOD1));
		}
	}

	void SHOCKWAVE(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xFF };
			sys_dbg_write_process_memory(0x00A98F40, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98F40, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x00 };
			sys_dbg_write_process_memory(0x00A98F40, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98F40, &MOD1, sizeof(MOD1));
		}
	}

	void WALLHACK(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x05 };
			sys_dbg_write_process_memory(0x30012913, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x30012913, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x07 };
			sys_dbg_write_process_memory(0x30012913, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x30012913, &MOD1, sizeof(MOD1));
		}
	}

	void WALLHACK_V2(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x40 };
			sys_dbg_write_process_memory(0x00A98F50, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98F50, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3D };
			sys_dbg_write_process_memory(0x00A98F50, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98F50, &MOD1, sizeof(MOD1));
		}
	}

	void WALLHACK_V3(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x3F, 0x00 };
			sys_dbg_write_process_memory(0x00A98F50, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98F50, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3D, 0x8C };
			sys_dbg_write_process_memory(0x00A98F50, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98F50, &MOD1, sizeof(MOD1));
		}
	}

	void PLASTIC_TEXTURE(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x01 };
			sys_dbg_write_process_memory(0x30012913, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x30012913, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x07 };
			sys_dbg_write_process_memory(0x30012913, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x30012913, &MOD1, sizeof(MOD1));
		}
	}

	void GHOST_TEXTURE(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x02 };
			sys_dbg_write_process_memory(0x30012913, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x30012913, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x07 };
			sys_dbg_write_process_memory(0x30012913, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x30012913, &MOD1, sizeof(MOD1));
		}
	}

	void BLUE_FOG(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x0F };
			sys_dbg_write_process_memory(0x014C67D8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x014C67D8, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3F };
			sys_dbg_write_process_memory(0x014C67D8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x014C67D8, &MOD1, sizeof(MOD1));
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
		}
		else
		{
			char MOD1[] = { 0x3F, 0x80 };
			char MOD2[] = { 0x3F };
			sys_dbg_write_process_memory(0x00410738, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory(0x0038C658, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x00410738, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0038C658, &MOD2, sizeof(MOD2));
		}
	}

	void SHAKE_CAMERA(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xFF, 0x0A, 0x28, 0x90 };
			sys_dbg_write_process_memory(0x00A98FA4, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98FA4, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0xFF, 0xA0, 0x08, 0x90 };
			sys_dbg_write_process_memory(0x00A98FA4, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98FA4, &MOD1, sizeof(MOD1));
		}
	}

	void MORE_LIGHT(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x4F, 0xFF };
			sys_dbg_write_process_memory(0x00A9A6D8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A9A6D8, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3F, 0xC0 };
			sys_dbg_write_process_memory(0x00A9A6D8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A9A6D8, &MOD1, sizeof(MOD1));
		}
	}

	void FLAT_ITEMS(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x01 };
			sys_dbg_write_process_memory(0x000924FF, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x000924FF, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x00 };
			sys_dbg_write_process_memory(0x000924FF, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x000924FF, &MOD1, sizeof(MOD1));
		}
	}

	void VIBRATE_WALK(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x40 };
			sys_dbg_write_process_memory(0x004A3D99, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x004A3D99, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x20 };
			sys_dbg_write_process_memory(0x004A3D99, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x004A3D99, &MOD1, sizeof(MOD1));
		}
	}

	void HUD_INV_DOWN(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x40 };
			sys_dbg_write_process_memory(0x0090FB6C, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0090FB6C, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x20 };
			sys_dbg_write_process_memory(0x0090FB6C, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0090FB6C, &MOD1, sizeof(MOD1));
		}
	}

	void SMALL_GRAPHIC(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x40 };
			sys_dbg_write_process_memory(0x00A98EF4, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98EF4, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x20 };
			sys_dbg_write_process_memory(0x00A98EF4, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98EF4, &MOD1, sizeof(MOD1));
		}
	}

	void PARTICLES_FLY(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x0F };
			sys_dbg_write_process_memory(0x00B52100, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B52100, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3F };
			sys_dbg_write_process_memory(0x00B52100, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B52100, &MOD1, sizeof(MOD1));
		}
	}

	void PAPER_MODE(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x1F };
			sys_dbg_write_process_memory(0x00AD5ECC, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AD5ECC, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3F };
			sys_dbg_write_process_memory(0x00AD5ECC, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AD5ECC, &MOD1, sizeof(MOD1));
		}
	}

	void BIG_MODEL(int value)
	{
		char HEX[] = { NyTekCFW::IntToHex(value) };
		sys_dbg_write_process_memory(0x00AD5ECD, &HEX, sizeof(HEX));
		sys_dbg_write_process_memory_ps3mapi(0x00AD5ECD, &HEX, sizeof(HEX));
	}

	void CHANGE_FOV(int value)
	{
		char HEX[] = { NyTekCFW::IntToHex(value) };
		sys_dbg_write_process_memory(0x00AD5ECD, &HEX, sizeof(HEX));
		sys_dbg_write_process_memory_ps3mapi(0x00AD5ECD, &HEX, sizeof(HEX));
	}

	void CAMERA_LEFT(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x40 };
			sys_dbg_write_process_memory(0x00A991AC, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A991AC, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x41 };
			sys_dbg_write_process_memory(0x00A991AC, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A991AC, &MOD1, sizeof(MOD1));
		}
	}

	void CAMERA_RIGHT(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x40 };
			sys_dbg_write_process_memory(0x00A99050, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A99050, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x41 };
			sys_dbg_write_process_memory(0x00A99050, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A99050, &MOD1, sizeof(MOD1));
		}
	}

	void BIG_PARTICLES(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x3F, 0xFF };
			sys_dbg_write_process_memory(0x014C6880, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x014C6880, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3F, 0x80 };
			sys_dbg_write_process_memory(0x014C6880, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x014C6880, &MOD1, sizeof(MOD1));
		}
	}

	void HUD_LOADING(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x01 };
			sys_dbg_write_process_memory(0x014CE214, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x014CE214, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x00 };
			sys_dbg_write_process_memory(0x014CE214, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x014CE214, &MOD1, sizeof(MOD1));
		}
	}

	void STARS_IN_SKY(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x7F };
			sys_dbg_write_process_memory(0x0038C658, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0038C658, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3F };
			sys_dbg_write_process_memory(0x0038C658, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0038C658, &MOD1, sizeof(MOD1));
		}
	}

	void FOOT_STEP_SLOW(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x2F, 0x19 };
			sys_dbg_write_process_memory(0x002267F0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x002267F0, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3F, 0x19 };
			sys_dbg_write_process_memory(0x002267F0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x002267F0, &MOD1, sizeof(MOD1));
		}
	}

	void SKINS_DEBUG(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x03 };
			sys_dbg_write_process_memory(0x30012AB3, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x30012AB3, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x04 };
			sys_dbg_write_process_memory(0x30012AB3, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x30012AB3, &MOD1, sizeof(MOD1));
		}
	}

	void SHADOW_SKINS(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xFC, 0x40 };
			sys_dbg_write_process_memory(0x003AD910, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x003AD910, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0xFC, 0x80 };
			sys_dbg_write_process_memory(0x003AD910, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x003AD910, &MOD1, sizeof(MOD1));
		}
	}

	void SKINS_RED_PLAYERS(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x41 };
			sys_dbg_write_process_memory(0x00AD5B60, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AD5B60, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x40 };
			sys_dbg_write_process_memory(0x00AD5B60, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AD5B60, &MOD1, sizeof(MOD1));
		}
	}

	void PARTICLES_FLY_V1(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xBF };
			sys_dbg_write_process_memory(0x00B52100, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B52100, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3F };
			sys_dbg_write_process_memory(0x00B52100, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B52100, &MOD1, sizeof(MOD1));
		}
	}

	void LINE_BLOCK_MOVE(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x48 };
			sys_dbg_write_process_memory(0x00B259DE, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B259DE, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x08 };
			sys_dbg_write_process_memory(0x00B259DE, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B259DE, &MOD1, sizeof(MOD1));
		}
	}

	void DISABLE_PLAYERS(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x48 };
			sys_dbg_write_process_memory(0x001D3BF2, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x001D3BF2, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x08 };
			sys_dbg_write_process_memory(0x001D3BF2, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x001D3BF2, &MOD1, sizeof(MOD1));
		}
	}

	void SMALL_TEXT(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x48 };
			sys_dbg_write_process_memory(0x0079E326, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0079E326, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x08 };
			sys_dbg_write_process_memory(0x0079E326, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0079E326, &MOD1, sizeof(MOD1));
		}
	}

	void POS_HUD_TEXT(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x58 };
			sys_dbg_write_process_memory(0x0079E8DE, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0079E8DE, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x08 };
			sys_dbg_write_process_memory(0x0079E8DE, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0079E8DE, &MOD1, sizeof(MOD1));
		}
	}

	void ARMS_BROKEN(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x48 };
			sys_dbg_write_process_memory(0x00AD6172, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AD6172, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x08 };
			sys_dbg_write_process_memory(0x00AD6172, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AD6172, &MOD1, sizeof(MOD1));
		}
	}

	void BLOCK_FOG(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x28 };
			sys_dbg_write_process_memory(0x00AA1B76, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AA1B76, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x08 };
			sys_dbg_write_process_memory(0x00AA1B76, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AA1B76, &MOD1, sizeof(MOD1));
		}
	}

	void SKY_NETHER(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x41 };
			sys_dbg_write_process_memory(0x00B22050, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B22050, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x40 };
			sys_dbg_write_process_memory(0x00B22050, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B22050, &MOD1, sizeof(MOD1));
		}
	}

	void SMOKE_LOBBY(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x01 };
			sys_dbg_write_process_memory(0x00B24177, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B24177, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x00 };
			sys_dbg_write_process_memory(0x00B24177, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B24177, &MOD1, sizeof(MOD1));
		}
	}

	void LOOK_UNDER_WORLD(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x20 };
			sys_dbg_write_process_memory(0x00A98A91, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98A91, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x40 };
			sys_dbg_write_process_memory(0x00A98A91, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98A91, &MOD1, sizeof(MOD1));
		}
	}

	void FREE_CAM(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x40 };
			sys_dbg_write_process_memory(0x00A98A95, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98A95, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x30 };
			sys_dbg_write_process_memory(0x00A98A95, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98A95, &MOD1, sizeof(MOD1));
		}
	}

	void REMOVE_HAND(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x38, 0x60, 0x00, 0x01 };
			sys_dbg_write_process_memory(0x00AF10A8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AF10A8, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x38, 0x60, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x00AF10A8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AF10A8, &MOD1, sizeof(MOD1));
		}
	}

	void TORNADE_PARTICLES(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x58 };
			sys_dbg_write_process_memory(0x00B50B32, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B50B32, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x08 };
			sys_dbg_write_process_memory(0x00B50B32, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B50B32, &MOD1, sizeof(MOD1));
		}
	}

	void HIT_DAMAGE_RED(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xD0 };
			sys_dbg_write_process_memory(0x00AD5B7A, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AD5B7A, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0xC0 };
			sys_dbg_write_process_memory(0x00AD5B7A, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AD5B7A, &MOD1, sizeof(MOD1));
		}
	}

	void DISABLE_FOG(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xFF, 0x00 };
			sys_dbg_write_process_memory(0x003A3FF0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3F, 0x80 };
			sys_dbg_write_process_memory(0x003A3FF0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x003A3FF0, &MOD1, sizeof(MOD1));
		}
	}

	void FOV_WITHOUT_HAND(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x68 };
			sys_dbg_write_process_memory(0x00987502, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00987502, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x08 };
			sys_dbg_write_process_memory(0x00987502, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00987502, &MOD1, sizeof(MOD1));
		}
	}

	void IRON_HELMET_ON_ALL(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x00 };
			sys_dbg_write_process_memory(0x002FE983, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x002FE983, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x08 };
			sys_dbg_write_process_memory(0x002FE983, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x002FE983, &MOD1, sizeof(MOD1));
		}
	}

	void ENTITY_TO_BABY(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x01 };
			sys_dbg_write_process_memory(0x0039F52F, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0039F52F, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x00 };
			sys_dbg_write_process_memory(0x0039F52F, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0039F52F, &MOD1, sizeof(MOD1));
		}
	}

	void REMOVE_DETAILED_SKINS(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x38, 0x60, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x004B2468, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x004B2468, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x38, 0x60, 0x00, 0x01 };
			sys_dbg_write_process_memory(0x004B2468, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x004B2468, &MOD1, sizeof(MOD1));
		}
	}

	void AIM_ON_3TH_PERSON(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x4E, 0x80, 0x00, 0x20 };
			sys_dbg_write_process_memory(0x0090FA30, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0090FA30, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0xF8, 0x21, 0xF5, 0x41 };
			sys_dbg_write_process_memory(0x0090FA30, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0090FA30, &MOD1, sizeof(MOD1));
		}
	}

	void RENDER_ENTITY(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x48, 0xFF, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x0022CE40, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0022CE40, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x40, 0x48, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x0022CE40, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0022CE40, &MOD1, sizeof(MOD1));
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
		}
		else
		{
			char MOD1[] = { 0xC2 };
			char MOD2[] = { 0x42 };
			sys_dbg_write_process_memory(0x00224FD4, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory(0x00224FD8, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x00224FD4, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00224FD8, &MOD2, sizeof(MOD2));
		}
	}

	void TEXTURE_TO_BLACK(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x40 };
			sys_dbg_write_process_memory(0x00A73854, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A73854, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x41 };
			sys_dbg_write_process_memory(0x00A73854, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A73854, &MOD1, sizeof(MOD1));
		}
	}

	void GAMMA_TO_MAX(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x3F, 0xFF };
			sys_dbg_write_process_memory(0x00A9C2B4, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A9C2B4, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3F, 0x80 };
			sys_dbg_write_process_memory(0x00A9C2B4, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A9C2B4, &MOD1, sizeof(MOD1));
		}
	}

	void NAME_AND_SHADOW_TO_BLACK(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x40 };
			sys_dbg_write_process_memory(0x00A73878, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A73878, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x41 };
			sys_dbg_write_process_memory(0x00A73878, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A73878, &MOD1, sizeof(MOD1));
		}
	}

	void ANIMATION_CHARACTER(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x40 };
			sys_dbg_write_process_memory(0x00A89AC8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A89AC8, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x41 };
			sys_dbg_write_process_memory(0x00A89AC8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A89AC8, &MOD1, sizeof(MOD1));
		}
	}

	void BIG_ANIM_CHARACTER(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xF0 };
			char MOD2[] = { 0xF0 };
			sys_dbg_write_process_memory(0x00A8919D, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory(0x00A891A1, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x00A8919D, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A891A1, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x40 };
			char MOD2[] = { 0x40 };
			sys_dbg_write_process_memory(0x00A8919D, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory(0x00A891A1, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x00A8919D, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A891A1, &MOD1, sizeof(MOD1));
		}
	}

	void ROTATION_BODY(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x4E, 0x80, 0x00, 0x20 };
			sys_dbg_write_process_memory(0x003AF338, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x003AF338, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0xF8, 0x21, 0xFF, 0x71 };
			sys_dbg_write_process_memory(0x003AF338, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x003AF338, &MOD1, sizeof(MOD1));
		}
	}

	void ENTITY_BODY_LIGHT(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x40 };
			sys_dbg_write_process_memory(0x00AD66C0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AD66C0, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x41 };
			sys_dbg_write_process_memory(0x00AD66C0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AD66C0, &MOD1, sizeof(MOD1));
		}
	}

	void NETHER_VISION(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x40 };
			sys_dbg_write_process_memory(0x00B018D0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B018D0, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x41 };
			sys_dbg_write_process_memory(0x00B018D0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B018D0, &MOD1, sizeof(MOD1));
		}
	}

	void PARTICLES_HIT_SPAM(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x00 };
			sys_dbg_write_process_memory(0x00B520F7, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B520F7, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x01 };
			sys_dbg_write_process_memory(0x00B520F7, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B520F7, &MOD1, sizeof(MOD1));
		}
	}

	void ROBLOX_ANIMATION(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xC3 };
			sys_dbg_write_process_memory(0x002341D0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x002341D0, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0xC0 };
			sys_dbg_write_process_memory(0x002341D0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x002341D0, &MOD1, sizeof(MOD1));
		}
	}

	void ENTITY_ELYTRA(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x4E, 0x80, 0x00, 0x20 };
			sys_dbg_write_process_memory(0x003B3008, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x003B3008, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0xF8, 0x21, 0xFF, 0x91 };
			sys_dbg_write_process_memory(0x003B3008, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x003B3008, &MOD1, sizeof(MOD1));
		}
	}

	void MOVE_HEAD_NO_BODY(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x4E, 0x80, 0x00, 0x20 };
			sys_dbg_write_process_memory(0x003AF338, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x003AF338, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0xF8, 0x21, 0xFF, 0x71 };
			sys_dbg_write_process_memory(0x003AF338, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x003AF338, &MOD1, sizeof(MOD1));
		}
	}

	void STOP_ANIMATION(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x4E, 0x80, 0x00, 0x20 };
			sys_dbg_write_process_memory(0x003ACF00, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x003ACF00, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0xF8, 0x21, 0xFF, 0x71 };
			sys_dbg_write_process_memory(0x003ACF00, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x003ACF00, &MOD1, sizeof(MOD1));
		}
	}

	void GIANT_GAMEPLAY(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x40 };
			sys_dbg_write_process_memory(0x00A98EBC, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98EBC, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x41 };
			sys_dbg_write_process_memory(0x00A98EBC, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A98EBC, &MOD1, sizeof(MOD1));
		}
	}

	void WORLD_LIGHT_WHITE(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x02 };
			sys_dbg_write_process_memory(0x300136D3, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x300136D3, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x06 };
			sys_dbg_write_process_memory(0x300136D3, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x300136D3, &MOD1, sizeof(MOD1));
		}
	}

	void WORLD_LIGHT_RAINBOW(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x3F, 0xFF };
			sys_dbg_write_process_memory(0x00A9A6C8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A9A6C8, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3F, 0x80 };
			sys_dbg_write_process_memory(0x00A9A6C8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00A9A6C8, &MOD1, sizeof(MOD1));
		}
	}

	void SHADOW_SKINS_V1(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x2F };
			sys_dbg_write_process_memory(0x003AD388, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x003AD388, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3F };
			sys_dbg_write_process_memory(0x003AD388, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x003AD388, &MOD1, sizeof(MOD1));
		}
	}

	void DOUBLE_NAME(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x01 };
			sys_dbg_write_process_memory(0x00979BCF, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00979BCF, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x00 };
			sys_dbg_write_process_memory(0x00979BCF, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00979BCF, &MOD1, sizeof(MOD1));
		}
	}

	void OPTIMIZE_CHUNKS(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x40, 0xD7, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x00B21C60, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B21C60, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x40, 0x30, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x00B21C60, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B21C60, &MOD1, sizeof(MOD1));
		}
	}

	void STOP_CHUNKS_LOAD(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x4E, 0x80, 0x00, 0x20 };
			sys_dbg_write_process_memory(0x00B2437C, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B2437C, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0xF8, 0x21, 0xFF, 0x71 };
			sys_dbg_write_process_memory(0x00B2437C, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00B2437C, &MOD1, sizeof(MOD1));
		}
	}

	void REAL_JUMP_ANIM(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xBF };
			sys_dbg_write_process_memory(0x014C6728, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x014C6728, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3F };
			sys_dbg_write_process_memory(0x014C6728, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x014C6728, &MOD1, sizeof(MOD1));
		}
	}

	void REAL_JUMP_ANIMATION(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xBF };
			sys_dbg_write_process_memory(0x014C6728, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x014C6728, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x3F };
			sys_dbg_write_process_memory(0x014C6728, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x014C6728, &MOD1, sizeof(MOD1));
		}
	}

	void CAN_CRAFT(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x01 };
			char MOD4[] = { 0x4E, 0x80, 0x00, 0x20 };
			char MOD3[] = { 0x01 };
			char MOD2[] = { 0x01 };

			sys_dbg_write_process_memory(0x00AED18F, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory(0x0098871F, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory(0x007D75A3, &MOD3, sizeof(MOD3));
			sys_dbg_write_process_memory(0x007D767C, &MOD4, sizeof(MOD4));
			sys_dbg_write_process_memory_ps3mapi(0x00AED18F, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0098871F, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x007D75A3, &MOD3, sizeof(MOD3));
			sys_dbg_write_process_memory_ps3mapi(0x007D767C, &MOD4, sizeof(MOD4));
		}
		else
		{
			char MOD1[] = { 0x00 };
			char MOD2[] = { 0x00 };
			char MOD3[] = { 0x00 };
			char MOD4[] = { 0xF8, 0x21, 0xFF, 0x81 };

			sys_dbg_write_process_memory(0x00AED18F, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory(0x0098871F, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory(0x007D75A3, &MOD3, sizeof(MOD3));
			sys_dbg_write_process_memory(0x007D767C, &MOD4, sizeof(MOD4));
			sys_dbg_write_process_memory_ps3mapi(0x00AED18F, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x0098871F, &MOD2, sizeof(MOD2));
			sys_dbg_write_process_memory_ps3mapi(0x007D75A3, &MOD3, sizeof(MOD3));
			sys_dbg_write_process_memory_ps3mapi(0x007D767C, &MOD4, sizeof(MOD4));
		}
	}

	void CAN_PLACE_BLOCKS(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x01 };
			sys_dbg_write_process_memory(0x007D75A3, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x007D75A3, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x00 };
			sys_dbg_write_process_memory(0x007D75A3, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x007D75A3, &MOD1, sizeof(MOD1));
		}
	}

	void CAN_SEE_SPECTATOR(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x4E, 0x80, 0x00, 0x20 };
			sys_dbg_write_process_memory(0x007D86A0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x007D86A0, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0xF8, 0x21, 0xFF, 0x81 };
			sys_dbg_write_process_memory(0x007D86A0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x007D86A0, &MOD1, sizeof(MOD1));
		}
	}

	void PLAYERS_ARE_STARVED(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x4E, 0x80, 0x00, 0x20 };
			sys_dbg_write_process_memory(0x007D7AA0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x007D7AA0, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0xF8, 0x21, 0xFF, 0x71 };
			sys_dbg_write_process_memory(0x007D7AA0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x007D7AA0, &MOD1, sizeof(MOD1));
		}
	}

	void ALLOW_PORTALS(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x38, 0x60, 0x00, 0x00 };
			sys_dbg_write_process_memory(0x007DC3BC, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x007DC3BC, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x38, 0x60, 0x00, 0x01 };
			sys_dbg_write_process_memory(0x007DC3BC, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x007DC3BC, &MOD1, sizeof(MOD1));
		}
	}

	void TNT_CAN_DESTROY(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x4E, 0x80, 0x00, 0x20 };
			sys_dbg_write_process_memory(0x007D8FB8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x007D8FB8, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0xF8, 0x21, 0xFF, 0x81 };
			sys_dbg_write_process_memory(0x007D8FB8, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x007D8FB8, &MOD1, sizeof(MOD1));
		}
	}

	void MAX_PLAYERS_IN_SMALL_MAPS(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x4E, 0x80, 0x00, 0x20 };
			sys_dbg_write_process_memory(0x007D7984, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x007D7984, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0xF8, 0x21, 0xFF, 0x81 };
			sys_dbg_write_process_memory(0x007D7984, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x007D7984, &MOD1, sizeof(MOD1));
		}
	}

	void CREATIVE_INVENTORY(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x01 };
			sys_dbg_write_process_memory(0x00AED18F, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AED18F, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x00 };
			sys_dbg_write_process_memory(0x00AED18F, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AED18F, &MOD1, sizeof(MOD1));
		}
	}

	void CAN_DESTROY_BLOCKS(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x01 };
			sys_dbg_write_process_memory(0x007D75FF, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x007D75FF, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x00 };
			sys_dbg_write_process_memory(0x007D75FF, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x007D75FF, &MOD1, sizeof(MOD1));
		}
	}

	void GAMEMODE_TO_SURVIVAL(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x4E, 0x80, 0x00, 0x20 };
			sys_dbg_write_process_memory(0x007D88C0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x007D88C0, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0xF8, 0x21, 0xFF, 0x81 };
			sys_dbg_write_process_memory(0x007D88C0, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x007D88C0, &MOD1, sizeof(MOD1));
		}
	}

	void TELEPORT_TO_LOBBY()
	{
		JUMP_IN_SKY(true);
		AUTO_JUMP(true);
		sleep(1000);
		//Modules::setLocation(-343, 57, -341);
		JUMP_IN_SKY(false);
		AUTO_JUMP(false);
		MULTI_JUMP(true);
	}

	void TELEPORT_TO_CAVERN()
	{
		JUMP_IN_SKY(true);
		AUTO_JUMP(true);
		sleep(1000);
		//Modules::setLocation(-222, 66, 287);
		JUMP_IN_SKY(false);
		AUTO_JUMP(false);
		MULTI_JUMP(true);
	}

	void TELEPORT_TO_COVE()
	{
		JUMP_IN_SKY(true);
		AUTO_JUMP(true);
		sleep(1000);
		//Modules::setLocation(219, 65, -220);
		JUMP_IN_SKY(false);
		AUTO_JUMP(false);
		MULTI_JUMP(true);
	}

	void TELEPORT_TO_CRUCIBLE()
	{
		JUMP_IN_SKY(true);
		AUTO_JUMP(true);
		sleep(1000);
		//Modules::setLocation(317, 76, 301);
		JUMP_IN_SKY(false);
		AUTO_JUMP(false);
		MULTI_JUMP(true);
	}

	void ENTITY_ESP(bool toggle)
	{
		if (toggle)
		{
			//remove name = 0x00AA4FE4
			//size up to down = 0x00AA4A14 - 0x00AA48B0
			//like if player is on sneak = 0x00AA4A18
			//rotate behing or front = 0x00AA4934 - 0x00AA492C - 0x00AA4924
			//vertical rotation = 0x00AA4930 - 0x00AA4928
			//remove name = 0x00AA48F4
			//0x00AA4908
			//tracer ? 0x00AA4934
			//bigger = 0x00AA4974
			//0x00AA49F0 left to right
			//another ESP = 0x00AA4A10
			//color lines = R = 0x00AA4C90, G = 0x00AA4C98 B = 0x00AA4CA0
			//remove a bit the name = 0x00AA5251
			//bg name tag colors = 0x00AA47C0
			//render all entity = 0x00012058
			char RECT[] = { 0xFC, 0x00, 0x08, 0x90 };
			char SIZE[] = { 0xBE, 0x90, 0x00, 0x00 };
			char PLAT[] = { 0x38, 0x80, 0x00, 0x00 };
			char SIZE2[] = { 0xBE, 0x3C, 0xCC, 0xCD };
			char COLORBOX[] = { 0x3F, 0x40, 0x00, 0x00 };
			char FIXUP[] = { 0xFF, 0x80, 0x30, 0x18 };
			char FIXROTATION[] = { 0xBC, 0x8E, 0xFA, 0x35 };
			char REMOVESHADOW[] = { 0x3E, 0x3C, 0xCC, 0xCD };
			sys_dbg_write_process_memory(0x00AA497C, &RECT, sizeof(RECT));
			sys_dbg_write_process_memory_ps3mapi(0x00AA497C, &RECT, sizeof(RECT));
			sys_dbg_write_process_memory(0x00AA47C0, &SIZE, sizeof(SIZE));
			sys_dbg_write_process_memory_ps3mapi(0x00AA47C0, &SIZE, sizeof(SIZE));
			sys_dbg_write_process_memory(0x00AA4908, &PLAT, sizeof(PLAT));
			sys_dbg_write_process_memory_ps3mapi(0x00AA4908, &PLAT, sizeof(PLAT));
			sys_dbg_write_process_memory(0x00AA47C8, &SIZE2, sizeof(SIZE2));
			sys_dbg_write_process_memory_ps3mapi(0x00AA47C8, &SIZE2, sizeof(SIZE2));
			sys_dbg_write_process_memory(0x00AA47D0, &COLORBOX, sizeof(COLORBOX));
			sys_dbg_write_process_memory_ps3mapi(0x00AA47D0, &COLORBOX, sizeof(COLORBOX));
			sys_dbg_write_process_memory(0x00AA4A14, &FIXUP, sizeof(FIXUP));
			sys_dbg_write_process_memory_ps3mapi(0x00AA4A14, &FIXUP, sizeof(FIXUP));
			sys_dbg_write_process_memory(0x00AA47BC, &FIXROTATION, sizeof(FIXROTATION));
			sys_dbg_write_process_memory_ps3mapi(0x00AA47BC, &FIXROTATION, sizeof(FIXROTATION));
			sys_dbg_write_process_memory(0x00AA47C8, &REMOVESHADOW, sizeof(REMOVESHADOW));
			sys_dbg_write_process_memory_ps3mapi(0x00AA47C8, &REMOVESHADOW, sizeof(REMOVESHADOW));
			NAME_OVER_HEAD(true);
			GET_PLAYERS_IDS(true);
		}
		else
		{
			char RECT[] = { 0xFC, 0x40, 0x08, 0x90 };
			char SIZE[] = { 0x3F, 0x80, 0x00, 0x00 };
			char PLAT[] = { 0x38, 0x80, 0x00, 0x01 };
			char SIZE2[] = { 0xBC, 0xCC, 0xCC, 0xCD };
			char COLORBOX[] = { 0x3E, 0x80, 0x00, 0x00 };
			char FIXUP[] = { 0xFF, 0x80, 0xE0, 0x18 };
			char FIXROTATION[] = { 0x3C, 0x8E, 0xFA, 0x35 };
			char REMOVESHADOW[] = { 0xBC, 0xCC, 0xCC, 0xCD };
			sys_dbg_write_process_memory(0x00AA497C, &RECT, sizeof(RECT));
			sys_dbg_write_process_memory_ps3mapi(0x00AA497C, &RECT, sizeof(RECT));
			sys_dbg_write_process_memory(0x00AA47C0, &SIZE, sizeof(SIZE));
			sys_dbg_write_process_memory_ps3mapi(0x00AA47C0, &SIZE, sizeof(SIZE));
			sys_dbg_write_process_memory(0x00AA4908, &PLAT, sizeof(PLAT));
			sys_dbg_write_process_memory_ps3mapi(0x00AA4908, &PLAT, sizeof(PLAT));
			sys_dbg_write_process_memory(0x00AA47C8, &SIZE2, sizeof(SIZE2));
			sys_dbg_write_process_memory_ps3mapi(0x00AA47C8, &SIZE2, sizeof(SIZE2));
			sys_dbg_write_process_memory(0x00AA47D0, &COLORBOX, sizeof(COLORBOX));
			sys_dbg_write_process_memory_ps3mapi(0x00AA47D0, &COLORBOX, sizeof(COLORBOX));
			sys_dbg_write_process_memory(0x00AA4A14, &FIXUP, sizeof(FIXUP));
			sys_dbg_write_process_memory_ps3mapi(0x00AA4A14, &FIXUP, sizeof(FIXUP));
			sys_dbg_write_process_memory(0x00AA47BC, &FIXROTATION, sizeof(FIXROTATION));
			sys_dbg_write_process_memory_ps3mapi(0x00AA47BC, &FIXROTATION, sizeof(FIXROTATION));
			sys_dbg_write_process_memory(0x00AA47C8, &REMOVESHADOW, sizeof(REMOVESHADOW));
			sys_dbg_write_process_memory_ps3mapi(0x00AA47C8, &REMOVESHADOW, sizeof(REMOVESHADOW));
			NAME_OVER_HEAD(false);
			GET_PLAYERS_IDS(false);
		}
	}

	void ESP_TRACER(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0x7C, 0x65, 0x38, 0x14 };
			sys_dbg_write_process_memory(0x00AA4934, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AA4934, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x7C, 0x65, 0x18, 0x14 };
			sys_dbg_write_process_memory(0x00AA4934, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AA4934, &MOD1, sizeof(MOD1));
		}
	}

	void ESP_COD(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xFF, 0x80, 0x1E, 0x9C };
			sys_dbg_write_process_memory(0x00AA4A10, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AA4A10, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x7C, 0x65, 0x08, 0x14 };
			sys_dbg_write_process_memory(0x00AA4A10, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AA4A10, &MOD1, sizeof(MOD1));
		}
	}

	void ESP_WAYPOINT(bool toggle)
	{
		if (toggle)
		{
			char MOD1[] = { 0xFF, 0x80, 0xBE, 0x9C };
			sys_dbg_write_process_memory(0x00AA4A10, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AA4A10, &MOD1, sizeof(MOD1));
		}
		else
		{
			char MOD1[] = { 0x7C, 0x65, 0x08, 0x14 };
			sys_dbg_write_process_memory(0x00AA4A10, &MOD1, sizeof(MOD1));
			sys_dbg_write_process_memory_ps3mapi(0x00AA4A10, &MOD1, sizeof(MOD1));
		}
	}

	void ADD_OPACITY_IMAGE()
	{
		char MOD1[] = { 0x3F, 0x0C, 0xCC, 0xCC };
		sys_dbg_write_process_memory(0x31E7786C, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory_ps3mapi(0x31E7786C, &MOD1, sizeof(MOD1));
	}

	void REMOVE_OPACITY_IMAGE()
	{
		char MOD1[] = { 0x3F, 0x7C, 0xCC, 0xCC };
		sys_dbg_write_process_memory(0x31E7786C, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory_ps3mapi(0x31E7786C, &MOD1, sizeof(MOD1));
	}

	void EXIT_GAME()
	{
		char MOD1[] = { 0x40, 0x80, 0x00, 0x28 };
		char MOD2[] = { 0x40, 0x80, 0x00, 0xCC };
		char MOD3[] = { 0x01, 0x00, 0x00, 0x01 };
		sys_dbg_write_process_memory(0x00785DBC, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory(0x00AD8320, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory(0x014CE214, &MOD3, sizeof(MOD3));
		sys_dbg_write_process_memory_ps3mapi(0x00785DBC, &MOD1, sizeof(MOD1));
		sys_dbg_write_process_memory_ps3mapi(0x00AD8320, &MOD2, sizeof(MOD2));
		sys_dbg_write_process_memory_ps3mapi(0x014CE214, &MOD3, sizeof(MOD3));
	}

	/*
	void ALL_PLAYERS_ZOOM_FOV()
	{
		if (AllPlayersZoomFOV)
		{
			char ON1[] = { 0x78 };
			char ON2[] = { 0x08 };

			sys_dbg_write_process_memory(0x004668B6, &ON2, sizeof(ON2));
			sys_dbg_write_process_memory_ps3mapi(0x004668B6, &ON2, sizeof(ON2));

			if (frameTime(10, 1, false))
			{
				sys_dbg_write_process_memory(0x004668B6, &ON1, sizeof(ON1));
				sys_dbg_write_process_memory_ps3mapi(0x004668B6, &ON1, sizeof(ON1));
			}
		}
	}
	*/

	void GET_SPECIAL_ITEMS(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0x32, 0x1B, 0xB4, 0x20 };
			char HEX1[] = { 0x32, 0x1B, 0xB7, 0xF0 };
			char HEX2[] = { 0x32, 0x1D, 0x45, 0x90 };
			char HEX3[] = { 0x32, 0x1D, 0x9B, 0x10 };
			char HEX4[] = { 0x32, 0x1D, 0x9D, 0xE0 };
			char HEX5[] = { 0x32, 0x1D, 0x70, 0x00 };
			char HEX6[] = { 0x32, 0x20, 0x8D, 0xA0 };
			char HEX7[] = { 0x32, 0x1B, 0xE3, 0xA0 };
			char HEX8[] = { 0x32, 0x1B, 0xE9, 0xF0 };
			char HEX9[] = { 0x32, 0x1B, 0xEC, 0xE0 };
			char HEX10[] = { 0x32, 0x1B, 0xEF, 0xD0 };
			char HEX11[] = { 0x32, 0x1B, 0xF2, 0xC0 };
			char HEX12[] = { 0x32, 0x1B, 0xF5, 0x10 };
			char HEX13[] = { 0x32, 0x1B, 0xF7, 0x60 };
			char HEX14[] = { 0x32, 0x1B, 0xF9, 0xB0 };
			char HEX15[] = { 0x32, 0x1B, 0xFC, 0x00 };
			char HEX16[] = { 0x32, 0x1B, 0xFE, 0x50 };
			char HEX17[] = { 0x32, 0x1C, 0x00, 0xA0 };
			char HEX18[] = { 0x32, 0x1C, 0x84, 0xF0 };
			char HEX19[] = { 0x32, 0x1C, 0x89, 0x90 };
			char HEX20[] = { 0x32, 0x1D, 0x2B, 0x90 };
			char HEX21[] = { 0x32, 0x1D, 0xA7, 0xA0 };
			char HEX22[] = { 0x32, 0x1D, 0xC0, 0x70 };
			char HEX23[] = { 0x32, 0x1E, 0x8D, 0x20 };
			char HEX24[] = { 0x32, 0x1E, 0x8F, 0x70 };
			char HEX25[] = { 0x32, 0x1E, 0x91, 0xC0 };
			char HEX26[] = { 0x32, 0x1E, 0x94, 0x10 };
			char HEX27[] = { 0x32, 0x1E, 0x96, 0x60 };
			char HEX28[] = { 0x32, 0x1E, 0x98, 0xB0 };
			char HEX29[] = { 0x32, 0x20, 0x8F, 0xF0 };
			char HEX30[] = { 0x32, 0x1B, 0xC1, 0x60 };
			char HEX31[] = { 0x32, 0x1B, 0xDA, 0x60 };
			char HEX32[] = { 0x32, 0x1B, 0xDC, 0xB0 };
			char HEX33[] = { 0x32, 0x1B, 0xDF, 0x00 };
			char HEX34[] = { 0x32, 0x1F, 0xB4, 0xC0 };
			char HEX35[] = { 0x32, 0x20, 0x01, 0xC0 };
			char HEX36[] = { 0x32, 0x20, 0x0B, 0xE0 };
			char HEX37[] = { 0x32, 0x20, 0x32, 0x80 };
			char HEX38[] = { 0x32, 0x20, 0x64, 0x20 };

			sys_dbg_write_process_memory(0x3241B6B4, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory(0x3241B7A4, &HEX1, sizeof(HEX1));
			sys_dbg_write_process_memory(0x3241B894, &HEX2, sizeof(HEX2));
			sys_dbg_write_process_memory(0x3241B984, &HEX3, sizeof(HEX3));
			sys_dbg_write_process_memory(0x3241BA74, &HEX4, sizeof(HEX4));
			sys_dbg_write_process_memory(0x3241BB64, &HEX5, sizeof(HEX5));
			sys_dbg_write_process_memory(0x3241BC54, &HEX6, sizeof(HEX6));
			sys_dbg_write_process_memory(0x3241BD44, &HEX7, sizeof(HEX7));
			sys_dbg_write_process_memory(0x3241BE34, &HEX8, sizeof(HEX8));
			sys_dbg_write_process_memory(0x3241BF24, &HEX9, sizeof(HEX9));
			sys_dbg_write_process_memory(0x3241C014, &HEX10, sizeof(HEX10));
			sys_dbg_write_process_memory(0x3241C104, &HEX11, sizeof(HEX11));
			sys_dbg_write_process_memory(0x3241B3D4, &HEX12, sizeof(HEX12));
			sys_dbg_write_process_memory(0x3241B284, &HEX13, sizeof(HEX13));
			sys_dbg_write_process_memory(0x3241B134, &HEX14, sizeof(HEX14));
			sys_dbg_write_process_memory(0x3241AFE4, &HEX15, sizeof(HEX15));
			sys_dbg_write_process_memory(0x3241AE94, &HEX16, sizeof(HEX16));
			sys_dbg_write_process_memory(0x3241AD44, &HEX17, sizeof(HEX17));
			sys_dbg_write_process_memory(0x3241ABF4, &HEX18, sizeof(HEX18));
			sys_dbg_write_process_memory(0x3241AAA4, &HEX19, sizeof(HEX19));
			sys_dbg_write_process_memory(0x3241A954, &HEX20, sizeof(HEX20));
			sys_dbg_write_process_memory(0x3241A804, &HEX21, sizeof(HEX21));
			sys_dbg_write_process_memory(0x3241A6B4, &HEX22, sizeof(HEX22));
			sys_dbg_write_process_memory(0x3241A564, &HEX23, sizeof(HEX23));
			sys_dbg_write_process_memory(0x3241A414, &HEX24, sizeof(HEX24));
			sys_dbg_write_process_memory(0x3241A2C4, &HEX25, sizeof(HEX25));
			sys_dbg_write_process_memory(0x3241A174, &HEX26, sizeof(HEX26));
			sys_dbg_write_process_memory(0x3241A024, &HEX27, sizeof(HEX27));
			sys_dbg_write_process_memory(0x32419ED4, &HEX28, sizeof(HEX28));
			sys_dbg_write_process_memory(0x32419D84, &HEX29, sizeof(HEX29));
			sys_dbg_write_process_memory(0x324199F4, &HEX30, sizeof(HEX30));
			sys_dbg_write_process_memory(0x324198A4, &HEX31, sizeof(HEX31));
			sys_dbg_write_process_memory(0x32419754, &HEX32, sizeof(HEX32));
			sys_dbg_write_process_memory(0x32419604, &HEX33, sizeof(HEX33));
			sys_dbg_write_process_memory(0x324194B4, &HEX34, sizeof(HEX34));
			sys_dbg_write_process_memory(0x32419364, &HEX35, sizeof(HEX35));
			sys_dbg_write_process_memory(0x32419214, &HEX36, sizeof(HEX36));
			sys_dbg_write_process_memory(0x324190C4, &HEX37, sizeof(HEX37));
			sys_dbg_write_process_memory(0x32418F74, &HEX38, sizeof(HEX38));

			sys_dbg_write_process_memory_ps3mapi(0x3241B6B4, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x3241B7A4, &HEX1, sizeof(HEX1));
			sys_dbg_write_process_memory_ps3mapi(0x3241B894, &HEX2, sizeof(HEX2));
			sys_dbg_write_process_memory_ps3mapi(0x3241B984, &HEX3, sizeof(HEX3));
			sys_dbg_write_process_memory_ps3mapi(0x3241BA74, &HEX4, sizeof(HEX4));
			sys_dbg_write_process_memory_ps3mapi(0x3241BB64, &HEX5, sizeof(HEX5));
			sys_dbg_write_process_memory_ps3mapi(0x3241BC54, &HEX6, sizeof(HEX6));
			sys_dbg_write_process_memory_ps3mapi(0x3241BD44, &HEX7, sizeof(HEX7));
			sys_dbg_write_process_memory_ps3mapi(0x3241BE34, &HEX8, sizeof(HEX8));
			sys_dbg_write_process_memory_ps3mapi(0x3241BF24, &HEX9, sizeof(HEX9));
			sys_dbg_write_process_memory_ps3mapi(0x3241C014, &HEX10, sizeof(HEX10));
			sys_dbg_write_process_memory_ps3mapi(0x3241C104, &HEX11, sizeof(HEX11));
			sys_dbg_write_process_memory_ps3mapi(0x3241B3D4, &HEX12, sizeof(HEX12));
			sys_dbg_write_process_memory_ps3mapi(0x3241B284, &HEX13, sizeof(HEX13));
			sys_dbg_write_process_memory_ps3mapi(0x3241B134, &HEX14, sizeof(HEX14));
			sys_dbg_write_process_memory_ps3mapi(0x3241AFE4, &HEX15, sizeof(HEX15));
			sys_dbg_write_process_memory_ps3mapi(0x3241AE94, &HEX16, sizeof(HEX16));
			sys_dbg_write_process_memory_ps3mapi(0x3241AD44, &HEX17, sizeof(HEX17));
			sys_dbg_write_process_memory_ps3mapi(0x3241ABF4, &HEX18, sizeof(HEX18));
			sys_dbg_write_process_memory_ps3mapi(0x3241AAA4, &HEX19, sizeof(HEX19));
			sys_dbg_write_process_memory_ps3mapi(0x3241A954, &HEX20, sizeof(HEX20));
			sys_dbg_write_process_memory_ps3mapi(0x3241A804, &HEX21, sizeof(HEX21));
			sys_dbg_write_process_memory_ps3mapi(0x3241A6B4, &HEX22, sizeof(HEX22));
			sys_dbg_write_process_memory_ps3mapi(0x3241A564, &HEX23, sizeof(HEX23));
			sys_dbg_write_process_memory_ps3mapi(0x3241A414, &HEX24, sizeof(HEX24));
			sys_dbg_write_process_memory_ps3mapi(0x3241A2C4, &HEX25, sizeof(HEX25));
			sys_dbg_write_process_memory_ps3mapi(0x3241A174, &HEX26, sizeof(HEX26));
			sys_dbg_write_process_memory_ps3mapi(0x3241A024, &HEX27, sizeof(HEX27));
			sys_dbg_write_process_memory_ps3mapi(0x32419ED4, &HEX28, sizeof(HEX28));
			sys_dbg_write_process_memory_ps3mapi(0x32419D84, &HEX29, sizeof(HEX29));
			sys_dbg_write_process_memory_ps3mapi(0x324199F4, &HEX30, sizeof(HEX30));
			sys_dbg_write_process_memory_ps3mapi(0x324198A4, &HEX31, sizeof(HEX31));
			sys_dbg_write_process_memory_ps3mapi(0x32419754, &HEX32, sizeof(HEX32));
			sys_dbg_write_process_memory_ps3mapi(0x32419604, &HEX33, sizeof(HEX33));
			sys_dbg_write_process_memory_ps3mapi(0x324194B4, &HEX34, sizeof(HEX34));
			sys_dbg_write_process_memory_ps3mapi(0x32419364, &HEX35, sizeof(HEX35));
			sys_dbg_write_process_memory_ps3mapi(0x32419214, &HEX36, sizeof(HEX36));
			sys_dbg_write_process_memory_ps3mapi(0x324190C4, &HEX37, sizeof(HEX37));
			sys_dbg_write_process_memory_ps3mapi(0x32418F74, &HEX38, sizeof(HEX38));
		}
		else
		{

		}
	}


	void PHASE_MODE(bool toggle)
	{
		if (toggle)
		{
			char HEX[] = { 0xC5 };
			char HEX1[] = { 0x00, 0x00, 0x00, 0x00 };
			char HEX2[] = { 0x44 };
			char HEX3[] = { 0x7F };
			sys_dbg_write_process_memory(0x00AFB448, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory(0x013029BC, &HEX1, sizeof(HEX1));
			sys_dbg_write_process_memory(0x0022FDC4, &HEX2, sizeof(HEX2));
			sys_dbg_write_process_memory(0x00B01778, &HEX3, sizeof(HEX3));
			sys_dbg_write_process_memory_ps3mapi(0x00AFB448, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x013029BC, &HEX1, sizeof(HEX1));
			sys_dbg_write_process_memory_ps3mapi(0x0022FDC4, &HEX2, sizeof(HEX2));
			sys_dbg_write_process_memory_ps3mapi(0x00B01778, &HEX3, sizeof(HEX3));
		}
		else
		{
			char HEX[] = { 0x3F };
			char HEX1[] = { 0x3F, 0xE6, 0x66, 0x66 };
			char HEX2[] = { 0x3F };
			char HEX3[] = { 0x3F };
			sys_dbg_write_process_memory(0x00AFB448, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory(0x013029BC, &HEX1, sizeof(HEX1));
			sys_dbg_write_process_memory(0x0022FDC4, &HEX2, sizeof(HEX2));
			sys_dbg_write_process_memory(0x00B01778, &HEX3, sizeof(HEX3));
			sys_dbg_write_process_memory_ps3mapi(0x00AFB448, &HEX, sizeof(HEX));
			sys_dbg_write_process_memory_ps3mapi(0x013029BC, &HEX1, sizeof(HEX1));
			sys_dbg_write_process_memory_ps3mapi(0x0022FDC4, &HEX2, sizeof(HEX2));
			sys_dbg_write_process_memory_ps3mapi(0x00B01778, &HEX3, sizeof(HEX3));
		}
	}

	// SOME FUNCTIONS //

	char* getName()
	{
		if (*(int*)0x3000ABE4 == 0x00000000)
			return (char*)NyTekCFW::ReadString(0x3000ABA4);
		else
			return (char*)NyTekCFW::ReadString(0x3000AD34);
	}

	char* setName(char* name)
	{
		char HEX[] = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
		sys_dbg_write_process_memory(0x3000ABE4, &HEX, sizeof(HEX));
		sys_dbg_write_process_memory_ps3mapi(0x3000ABE4, &HEX, sizeof(HEX));
		//strcpy((char*)0x3000ABF8, REGION);
		strcpy((char*)0x3000ABE4, name);
	}

	void setLocation(double x, double y, double z)
	{
		mc->theMinecraft->cMultiplayerLocalPlayer->SetPosition(x + 0.5, y + 1 + 0.5, z + 0.5);
	}

	void getLocation()
	{
		TeleportX = (int)mc->theMinecraft->cMultiplayerLocalPlayer->posX;
		TeleportY = (int)mc->theMinecraft->cMultiplayerLocalPlayer->posY;
		TeleportZ = (int)mc->theMinecraft->cMultiplayerLocalPlayer->posZ;
	}
};
#pragma endregion

Address* Offsets;