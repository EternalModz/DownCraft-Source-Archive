#pragma once

void Memory(int address, int value)
{
	*(int*)address = value;
}

void GOD_MODE(bool toggle)
{
	if (toggle)
	{
		Memory(0x4B2020, 0xFC80F890);
	}
	else
	{
		Memory(0x4B2020, 0xFC20F890);
	}
}

void INSTANT_DAMAGE(bool toggle)
{
	if (toggle)
	{
		Memory(0x03A3FF0, 0x3F000000);
	}
	else
	{
		Memory(0x03A3FF0, 0x40800000);
	}
}

void KNOCKBACK(bool toggle)
{
	if (toggle)
	{
		Memory(0x03A4018, 0x4080CCCD);
	}
	else
	{
		Memory(0x03A4018, 0x3ECCCCCD);
	}
}

void ANTI_KNOCKBACK(bool toggle)
{
	if (toggle)
	{
		Memory(0x03A4018, 0x0000CCCD);
	}
	else
	{
		Memory(0x03A4018, 0x3ECCCCCD);
	}
}

void INSTANT_KILL(bool toggle)
{
	if (toggle)
	{
		Memory(0x01AC410, 0xFFE02890);
	}
	else
	{
		Memory(0x01AC410, 0xFFE00890);
	}
}

void WATER_JUMP(bool toggle)
{
	if (toggle)
	{
		Memory(0x03ABD68, 0x3FF99999);
	}
	else
	{
		Memory(0x03ABD68, 0x3FE99999);
	}
}

void INFINITE_PICK_UP(bool toggle)
{
	if (toggle)
	{
		Memory(0x0224B10, 0x38800000);
	}
	else
	{
		Memory(0x0224B10, 0x38800001);
	}
}

void FAST_BOW(bool toggle)
{
	if (toggle)
	{
		Memory(0x0FB4C4, 0xFFE01818);
	}
	else
	{
		Memory(0x0FB4C4, 0xFFE00818);
	}
}

void ALL_PLAYERS_FAST_MINE(bool toggle)
{
	if (toggle)
	{
		Memory(0x010E0C4, 0xFFE00890);
	}
	else
	{
		Memory(0x010E0C4, 0xFFE00890);
	}
}