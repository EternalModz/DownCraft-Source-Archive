#pragma once

namespace Options
{
	void GOD_MODE() { if (GodMode) *(int*)0x4B2020 = 0xFC80F890; else *(int*)0x4B2020 = 0xFC20F890; }
	void SUPER_SPEED() { if (SuperSpeed) *(int*)0x003ABD49 = 0x99999940; else *(int*)0x003ABD49 = 0x26AD8940; }

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
}