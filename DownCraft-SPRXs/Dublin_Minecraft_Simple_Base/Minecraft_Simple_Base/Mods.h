#pragma once
#pragma region Includes
#include "PS3.h"

#pragma endregion
#pragma region Definitions
bool Unbreaking;
bool God_Mode;
bool InstantDamage;
bool SilkTouch;
bool Exhausted;
bool CanFly;
bool NightVision;
bool CreativeMine;
bool SlowFalling;
bool NoGravity;
bool Instant_Mine;
bool ShowTlkingPlayers;



#pragma endregion

void PLAYER_GOD_MODE() {
	if (!God_Mode)
	{
		God_Mode = true;
		char OpCode[] = { 0x80 };
		write_process(0x004B2021, &OpCode, sizeof(OpCode));

	}
	else
	{
		God_Mode = false;
		char OpCode[] = { 0x20 };
		write_process(0x004B2021, &OpCode, sizeof(OpCode));
	}
}

void PLAYER_CAN_FLY()
{
	if (!CanFly) {
		CanFly = true;
		char OpCode[] = { 0x40 };
		write_process(0x00B02378, &OpCode, sizeof(OpCode));

	}
	else {
		CanFly = false;
		char OpCode[] = { 0x41 };
		write_process(0x00B02378, &OpCode, sizeof(OpCode));

	}
}

void PLAYER_NIGHT_VISION()
{
	if (!NightVision)
	{
		NightVision = true;
		char OpCode[] = { 0x40 };
		write_process(0x00A9ACAC, &OpCode, sizeof(OpCode));
	}
	else
	{
		NightVision = false;
		char OpCode[] = { 0x41 };
		write_process(0x00A9ACAC, &OpCode, sizeof(OpCode));
	}
}
