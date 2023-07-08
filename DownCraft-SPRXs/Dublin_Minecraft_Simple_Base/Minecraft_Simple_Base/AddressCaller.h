#pragma once
#pragma region Includes
#include "Huds.h"
//#include "struct.h"
#include "Colors.h"
#include "Addresses.h"
#pragma endregion

void drawTexureModalRect(float x, float y, int minU, int minV, int maxU, int maxV){
	uint32_t pTesselator = TESSELLATOR::ReadInstance(TESSELLATOR::getInstance());
	TESSELLATOR::GetBuffer();
	BUFFERBUILDER::Begin(pTesselator);
	BUFFERBUILDER::Pos_EndVertex(pTesselator, x + 0, y + maxV, minU + 0, minV + maxV, 0);
	BUFFERBUILDER::Pos_EndVertex(pTesselator, x * 2 + maxU, y + maxV, minU + maxU, minV + maxV, 0);
	BUFFERBUILDER::Pos_EndVertex(pTesselator, x + maxU, y + 0, minU + maxU, minV + 0, 0);
	BUFFERBUILDER::Pos_EndVertex(pTesselator, x + 0, y + 0, minU + 0, minV + 0, 0);
	TESSELLATOR::Draw(pTesselator);
}
void LocalPlayer() {
	PLAYER::getMinecraft();
	//UI_DrawRightText(L"You Are Local Player theMinecraft", 180, 40, Black);
}

class BlockPos {
public:
	int X_BITS;
	int Y_BITS;
	int Z_BITS;
	BlockPos(int x, int y, int z);
	BlockPos(double x, double y, double z);
};
int CProfile = 0x016BD758;
char* PlayerName = (char*)0x300ABA4;
const char PlayerRegion = *(char*)0x0155A378;

void DrawNameText(const wchar_t * text, float x, float y, int * color, float tint, float visiblity) {
	FONTRENDERER::DrawStringWithShadow(mc->theMinecraft->fontRenderer, text, x, y, Color_s(color[3], color[0], color[1], color[2]), tint, 1);
}
/*void PlayerGameName() {

	const wchar_t* Name = (wchar_t*)(ReadString(0x300ABA4));
	UI_DrawRightText(Name, 192, 20, Black);
}*/

void getHotbarSize(){
	Call<void>(0x0030E618);
}
/*
if the player is holding an Armor Item int their main hand, it can go into the slot.
*/
void setItemStackToSlot() {
	Call<void>(0x004B0930);
}

void setLocation(float x, float y, float z, bool noFallDamage)
{
	double xyz1[3] = { x, y, z };
	double xyz2[3] = { x + .6, y + 1.8, z + .6 };
	//int Player = theMinecraft + 0x44; //01638F3C
	int theMc = *(int*)0x014CF2E4;
	int localUser = *(int*)(theMc + 0x44);
	int pos = *(int*)(localUser + 0x158);
	int multiJump = 0x00227908;
	if (noFallDamage)
		*(int*)multiJump = 0x41820028;
	int count8 = 0;
	*(double*)(pos + (count8++ * 8)) = xyz1[0];
	*(double*)(pos + (count8++ * 8)) = xyz1[1];
	*(double*)(pos + (count8++ * 8)) = xyz1[2];
	*(double*)(pos + (count8++ * 8)) = xyz2[0];
	*(double*)(pos + (count8++ * 8)) = xyz2[1];
	*(double*)(pos + (count8++ * 8)) = xyz2[2];
}