#pragma once
#include <stdint.h>

// X 0x20 0x14 0x00
// O 0x26 0x35 0x37 0x01 0x15
// /\ 0x03
// [] 0x02
// R1 0x24 0x0A
// L1 0x23 0x0B
// L2 0x21 0x08
// R2 0x22 0x09
// D-UP 0x2C 0x04
// D-RIGHT 0x2B 0x06
// D-DOWN 0x2D 0x05
// D-LEFT 0x2A 0x07
// SELECT 0x17 0x13
// START 0x16 0x12
// R3 0x27 0x0D
// L3 0x29 0x0C

enum SubMenus {
	Main_Menu,
	Host_Options,
	Self_Options,
	NonHost_Options,
	World_Options,
	Lobby_Options,
	TexturePack_Options,
	ModelChanger_Options,
	Player_Options,
	Teleport_Options,
	MenuSettings_Options,
	MenuCredits_Options

};



enum eEntityStatusFlags
{
	FLAG_IS_ON_FIRE = 0,
	FLAG_SNEAKING = 1,
	FLAG_INVULNERABLE = 2,
	FLAG_SPRINTING = 3,
	FLAG_USING_ITEM = 4,
	FLAG_INVISIBLE = 5,
	FLAG_IDLE = 6,
	FLAG_WEAKENED = 7,
	FLAG_GLOWING = 8,
	FLAG_FALLING = 9,                // FLAG_GET_ARROW_COUNT
	FLAG_SWIMMER = 10,               // FLAG_IS_DANGEROUS
	FLAG_SWIMMING = 11,              // FLAG_IS_CUSTOM_NAME_VISIBLE
	FLAG_DAMAGE_NEARBY_MOBS = 12,	   // FLAG_IS_BABY
	FLAG_IS_VILLAGER = 13,
	FLAG_IS_CONVERTING = 14,
	FLAG_RESTING = 16,
	FLAG_IS_CARRYING_DATA = 17,      // FLAG_IS_POWERED  // FLAG_JUST_JUMPED
	FLAG_HAS_CUSTOM_DISPLAY = 22,
};

enum eGameHostOption
{
	GAMEHOST_IS_ALLOWED_TO_FLY = 0x10,
	GAMEHOST_CAUSE_FOOD_EXHAUSTION = 0x11,
	GAMEHOST_HAS_INVULNERABLE_PRIVILEGE = 0x12,
};
