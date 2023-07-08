#pragma once

int toggleFunc(int value)
{
	if (value == 0)
	{
		return 1;
	}
	else if (value == 1)
	{
		return 0;
	}
	else
		return 0;
}

int toggleFunc(int value, int max)
{
	if (max - 1 <= value)
		value = -1;

	return ++value;
}

bool frameTime(int ms, int index, bool resetTime)
{
	if (resetTime)
		gotTime[index] = false;
	if (!gotTime[index])
	{
		gotTime[index] = true;
		getTime[index] = mc->gameTime;
	}
	timeMath[index] = mc->gameTime - getTime[index];

	if (timeMath[index] >= ms)
	{
		gotTime[index] = false;
		return true;
	}
	else
		return false;
}

bool scrollWait(int firstMs, int ms, int index)
{
	keyPressed[index] = true;
	if (!lockFirst[index])
	{
		if (freeFirst[index])
		{
			freeFirst[index] = false;
			return true;
		}

		if (frameTime(firstMs, 200 + index, resetWait[index]))
		{
			lockFirst[index] = true;
			resetWait[index] = false;
			return true;
		}
		else
		{
			resetWait[index] = false;
			return false;
		}
	}
	else
	{
		if (frameTime(ms, 200 + index, resetWait2[index]))
		{
			resetWait2[index] = false;
			return true;
		}
		else
		{
			resetWait2[index] = false;
			return false;
		}
	}
}

int doScroll(int _scroll, int max)
{
	_scroll = scroll;
	if (_scroll == max)
		return 0;
	else if (_scroll == -1)
		return max - 1;
	else
		return _scroll;
}

void gameRender_Stub(uint32_t r3, uint32_t r4)
{
	__nop(); __nop(); __nop(); __nop(); __nop();
}

void setLocation(float x, float y, float z)
{
	double xyz1[3] = { x, y, z };
	double xyz2[3] = { x + .6, y + 1.8, z + .6 };
	int theMc = *(int*)0x014CF2E4;
	int localUser = *(int*)(theMc + 0x44);
	int pos = *(int*)(localUser + 0x158);
	int count8 = 0;
	*(double*)(pos + (count8++ * 8)) = xyz1[0];
	*(double*)(pos + (count8++ * 8)) = xyz1[1];
	*(double*)(pos + (count8++ * 8)) = xyz1[2];
	*(double*)(pos + (count8++ * 8)) = xyz2[0];
	*(double*)(pos + (count8++ * 8)) = xyz2[1];
	*(double*)(pos + (count8++ * 8)) = xyz2[2];
}

void INITIALIZE_START()
{
	if (INITIALIZE_SPRX)
	{
		//search for custom image: 31 EB 25 F0 00 00 00 02
		PSN_NAME = PS3Lib::ReadString(0x3000AD34);
		INITIALIZE_SPRX = false;
	}
}