#pragma once
#pragma region Includes
#include "PS3Pad.h"

//#include "Addresses.h"
#include "Colors.h"
//#include "xString.h"
#include <xstring.h>
#pragma endregion





//C++ is a line by line based code engine, so placement matters. Basically you have places that reference other headers either before or AFTER a certain function gets called
//Try adding #pragma once to the top of all your .h files and see if that fixes it. Otherwise, I would make a single Header that handles all of your includes
//ok I can try that but I was trying the 2nd option before and it did not work
//These issues are stupidly hard to track down. You'll just have to go header by header to get it sorted. There's next to nothing I can do :X You know this code better than me. 
//Watch this

void drawTitleText(uint32_t font, const wchar_t * text, uint32_t x, uint32_t y, uint32_t color) {
	Call<void>(shaderOfs, font, text, x, y, color);
}

void UI_DrawMenuTitle(const wchar_t * text, float x, float y, int * color) {
	FONTRENDERER::DrawStringWithShadow(mc->theMinecraft->fontRenderer, text, x, y, Color_s(color[3], color[0], color[1], color[2]), 0, 1);
}



void UI_DrawText(const wchar_t * text, float x, float y, int * color, float tint, float visiblity) {
	FONTRENDERER::DrawStringWithShadow(mc->theMinecraft->fontRenderer, text, x, y, Color_s(color[3], color[0], color[1], color[2]), tint, 1);
}
void UI_DrawOptionText(const wchar_t * text, float x, float y, int * color) {
	UI_DrawText(text, 150, 10, color, 0, true);
}
void AddMenuMainTitle(const wchar_t * text, float x, float y, int * color)
{
	drawTitleText(mc->theMinecraft->fontRenderer, text, x, y, Color_s(color[3], color[0], color[1], color[2]));
}
void UI_DrawRightText(const wchar_t * text, float x, float y, int * color) {
	int width = FONTRENDERER::getStringWidth(mc->theMinecraft->fontRenderer, text);
	FONTRENDERER::DrawStringWithShadow(mc->theMinecraft->fontRenderer, text, x - width, y, Color_s(color[3], color[0], color[1], color[2]), 0, 1);
}

void Tesselator_EndVertex(uint32_t pTesselator, float X, float Y, float Z, int* Color) {
	BUFFERBUILDER::Color(pTesselator, Color[0], Color[1], Color[2], 255);
	BUFFERBUILDER::Pos_EndVertex(pTesselator, X, Y, Z, 0, 0);
}

void BufferBuilder_Position(uint32_t pTesselator, float X, float Y, float Z){
	BUFFERBUILDER::Pos_EndVertex(pTesselator, X, Y, Z, 0, 0);
}

void drawText(const wchar_t * text, float x, float y, uint32_t Color)
{
	FONTRENDERER::DrawStringWithShadow(mc->theMinecraft->fontRenderer, text, x, y, Color, 0, 1);
}

void drawStringwithShadow(const wchar_t * text, float x, float y, uint32_t Color)
{
	FONTRENDERER::DrawStringWithShadow(mc->theMinecraft->fontRenderer, text, x, y, Color, 1, 1);
}
/*
Tesselator is a Tessellation
Vertex Processing stage in the OpenGL rendering pipeline where patches the vertex data are subdivided into smaller Primiatives.
This process has 2 shaders drawn and a fixed shader stage.

*/


void PreloadShader(){
	GLSTATEMANAGER::DisableBlend();
	GLSTATEMANAGER::DisableAlpha();
	GLSTATEMANAGER::DisableFog();
	GLSTATEMANAGER::DisableLighting();
	GLSTATEMANAGER::DisableColorMaterial();
	GLSTATEMANAGER::EnableTexture2D();
}

void LoadShader(float x, float y, float w, float h) {
	PreloadShader();
	uint32_t pTesselator = TESSELLATOR::ReadInstance(TESSELLATOR::getInstance());
	TESSELLATOR::Draw(pTesselator);
	BufferBuilder_Position(pTesselator, x, y * 2, 0);
	BufferBuilder_Position(pTesselator, x * 2, y * 2, 0);
	BufferBuilder_Position(pTesselator, x * 2, y, 100);
	BufferBuilder_Position(pTesselator, x, y, 100);
	TESSELLATOR::Draw(pTesselator);
	GLSTATEMANAGER::EnableFog();
}

void GUIDrawRect(float x, float y, float w, float h, int* Color)
{
	uint32_t pTesselator = TESSELLATOR::ReadInstance(TESSELLATOR::getInstance());
	TESSELLATOR::Draw(pTesselator);
	GLSTATEMANAGER::EnableBlend();
	GLSTATEMANAGER::DisableTexture2D();
	BUFFERBUILDER::Color(pTesselator, Color[0], Color[1], Color[2], 255);
	BufferBuilder_Position(pTesselator, x, y * 2, 0);
	BufferBuilder_Position(pTesselator, x * 2, y * 2, 0);
	BufferBuilder_Position(pTesselator, x * 2, y, 100);
	BufferBuilder_Position(pTesselator, x, y, 100);
	TESSELLATOR::Draw(pTesselator);
	GLSTATEMANAGER::EnableTexture2D();
	GLSTATEMANAGER::DisableBlend();
}

void drawRect(float x, float y, float w, float h, int* Color) {
	uint32_t pTesselator = TESSELLATOR::ReadInstance(TESSELLATOR::getInstance());
	TESSELLATOR::Draw(pTesselator);
	Tesselator_EndVertex(pTesselator, x, h + y, 0, Color);
	Tesselator_EndVertex(pTesselator, w + x, h + y, 0, Color);
	Tesselator_EndVertex(pTesselator, w + x, y, 0, Color);
	Tesselator_EndVertex(pTesselator, x, y, 0, Color);
	TESSELLATOR::Draw(pTesselator);
}

void drawGradientRect(float x, float y, float w, float h, int* Color, int* Color2)
{
	uint32_t pTesselator = TESSELLATOR::ReadInstance(TESSELLATOR::getInstance());
	TESSELLATOR::Draw(pTesselator);
	Tesselator_EndVertex(pTesselator, x, h + y, 0, Color);
	Tesselator_EndVertex(pTesselator, w + x, h + y, 0, Color);
	Tesselator_EndVertex(pTesselator, w + x, y, 0, Color);
	Tesselator_EndVertex(pTesselator, x, y, 0, Color);
	TESSELLATOR::Draw(pTesselator);
	GLSTATEMANAGER::DisableBlend();
	GLSTATEMANAGER::EnableAlpha();
	GLSTATEMANAGER::EnableTexture2D();
}

void DrawHorizontalLine(int startX, int endX, int y, int *color)
{
	if (endX < startX)
	{
		int i = startX;
		startX = endX;
		endX = i;
	}
	//		x pos, Y Pos,  W Pos, H Pos, Color
	drawRect(startX + 1, y, endX + 1, 1, color);
}


void DrawVerticalLine(int x, int startY, int endY, int *color)
{
	int width = 1;
	if (x < startY)
	{
		int i = startY;
		startY = endY;
		endY = i;
	}//		x pos, Y Pos,  W Pos, H Pos, Color
	drawRect(x, startY + 1, 1, endY, color);
}

void drawRectangleBox(int x, int y, int right, int bottom, int* Color){
	if (x < right)
	{
		int i = x;
		x = right;
		right = i;
	}

	if (y < bottom)
	{
		int j = y;
		y = bottom;
		bottom = j;
	}
	uint32_t pTesselator = TESSELLATOR::ReadInstance(TESSELLATOR::getInstance());
	TESSELLATOR::Draw(pTesselator);
	GLSTATEMANAGER::EnableBlend();
	GLSTATEMANAGER::DisableTexture2D();
	BUFFERBUILDER::Color(pTesselator, Color[0], Color[1], Color[2], 255);
	BufferBuilder_Position(pTesselator, x, y * 2, 0);
	BufferBuilder_Position(pTesselator, x * 2, y * 2, 0);
	BufferBuilder_Position(pTesselator, x * 2, y, 100);
	BufferBuilder_Position(pTesselator, x, y, 100);
	TESSELLATOR::Draw(pTesselator);
	GLSTATEMANAGER::EnableTexture2D();
	GLSTATEMANAGER::DisableBlend();
}

void drawMenuBackground(float x, float y, float w, float h, int* Color, int* Color2)
{
	drawRect(x - 1, y - 1, w + 2, h + 2, Color2);
	drawRect(x, y, w, h, Color);
}
void drawRectBorder(float x, float y, float w, float h, int* Color, int* Color2) {
	drawRect(x - 1, y - 1, w + 2, h + 2, Color2);
	drawRect(x, y, w, h, Color);
}
void drawTitleRectBorder(float x, float y, float w, float h, int* Color, int* Color2) {
	drawRect(x - 1, y - 1, w + 2, h + 2, Color2);
	drawRect(x, y, w, h, Color);
}

void UI_DrawShaders(float x, float y, float w, float h, int* Color){
	uint32_t pTesselator = TESSELLATOR::ReadInstance(TESSELLATOR::getInstance());
	TESSELLATOR::Draw(pTesselator);
	Tesselator_EndVertex(pTesselator, x, h + y, 0, Color);
	Tesselator_EndVertex(pTesselator, w + x, h + y, 0, Color);
	Tesselator_EndVertex(pTesselator, w + x, y, 0, Color);
	Tesselator_EndVertex(pTesselator, x, y, 0, Color);
	TESSELLATOR::Draw(pTesselator);
}

void MEGuiTextField_drawSelectionBox(...){
	uint32_t pTesselator = TESSELLATOR::ReadInstance(TESSELLATOR::getInstance());
	TESSELLATOR::Draw(pTesselator);
	GLSTATEMANAGER::DisableColorLogic();
	GLSTATEMANAGER::EnableTexture2D();
}

int EnchantmentProtectionFunc = 0x00522140;

void Enchantment(int rarityIn, int typeIn, int slots){
	int rarity = rarityIn;
	int type = typeIn;
	int slot = slots;

}

/*void EnchantmentProtections(int EnchantmentRarity, int EnchantmentProtectionType, int EntityEquipmentSlot)
{
	Call<void>(EnchantmentProtectionFunc, EnchantmentRarity, EnchantmentProtectionType, EntityEquipmentSlot);
	if (EnchantmentProtection::FALL)
	{
		//EnchantmentProtectionType = EnchantmentType::ARMOR_FEET;
	}
}*/

int getMaxLevel()
{
	return 4;
}

/*namespace DamageSource{
	unsigned long damage = 0x0136F240;
	void isFire() { Call<void>(isFireFunc); }
	//void isFall() { Call<void>(EnchantmentProtection::FALL); }
	void isExplosion() { Call<void>(isExplosionFunc); }
	void isProjectile() { Call<void>(isProjectileFunc); }
}*/



/*int calcModifierDamage(int level, int DamageSource){
	if (CanHarmInCreative())
	{
		return 0;
	}
	else if (EnchantmentProtection::ALL)
	{
		return level;
	}
	else if (EnchantmentProtection::FIRE && DamageSource::isFire)
	{
		return level * 2;
	}
	else if (EnchantmentProtection::FALL && DamageSource::isFall)
	{
		return level * 3;
	}
	else if (EnchantmentProtection::EXPLOSION && DamageSource::isExplosion)
	{
		return level * 2;
	}
	else
	{
		return (EnchantmentProtection::PROJECTILE && DamageSource::isProjectile ? level * 2 : 0);
	}
}*/

bool autoJumpEnabled = true;
int autoJumpTime;
int EntityPlayerautoJumpupdate = 0x00B03698;
bool isAutoJumpEnabled(){
	return autoJumpEnabled;
}

int Item_Shield = 0x0151ED84;
int ShieldItem = 0x30DBF9B0;
int Item_Minecraft_Air = 0x014C90B8;
bool itemstack_isEmpty(int Item)
{
	int ItemPointer = 0x331BC260;
	int r4;

	ItemPointer = 0;
	if ((int)ItemPointer != Item_Shield)
	{
		r4 = *(int*)(Item + 16);
		if (r4)
		{
			if ((*(int*)0x331BC260) = Item_Minecraft_Air && *(int*)(Item + 8) > 0)
				ItemPointer = 0;
		}
	}
	return ItemPointer;
}

struct GameType{
	enum type{
		NOT_SET = 0x014C903C,
		SURVIVAL = 0x014C9040,
		CREATIVE = 0x014C9044,
		ADVENTURE = 0x014C9048,
		SPECTATOR = 0x014C904C,
		LOBBY = 0x014C9050,
	};

};
unsigned int CreativeModePointer = 0x3238FC40;
unsigned int SurvivalPointer = 0x32393EF0;
unsigned int AdventurePointer = 0x32394BD0;
uintptr_t CREATIVE = 0x014C9044;
uintptr_t SURVIVAL = 0x014C9040;
uintptr_t LOBBY = 0x014C9050;
void CreativeMode(int* CREATIVE);

#define GamemodePointer (void * addr)

/*void SetPlayerGame(unsigned int gamemode) {
	uintptr_t CreativeBytes[] = { 0x32, 0x38, 0xFC, 0x40 };
	char* CreativeSomething = getChar(0x014C9044);
	int r3;
	r3 = 0x0;
	if (gamemode == CREATIVE)
	{
		r3 = 0x1;
		//char bytes[] = { 0x36, 0x80, 0x00, 0x01 }; //li r3, 1
		write_process(0x002F0348, &r3, sizeof(r3));
		return;
	}

}*/

int SetServerPlayerGameMode(int32_t r3, int r4){
	int r5;
	uint32_t r28;

}
// = (wchar_t*)(0x03238FC40) + 0x0C;

//Simple Way
void GameType_isCreative()
{
	//Simple Way
	char bytes[] = { 0x36, 0x80, 0x00, 0x01, 0x4E, 0x80, 0x00, 0x20 }; //li r3, 1
	//write_process(0x002F0348, &bytes, sizeof(bytes));
}

void GameSetting_isCreative(){

	uint32_t r3 = *(uint32_t*)(r3);
	r3 = 0x1;
	//write_process(0x002F0348, &r3, sizeof(r3));
}

//Next Level Way
int SetGamemode(uintptr_t gamemode){
	uintptr_t pCreative = *(uintptr_t*)(CREATIVE);
	pCreative = 0x1;
	if (pCreative == gamemode)
	{
		*(uintptr_t*)(LOBBY) = gamemode;
		pCreative = 0x0;
	}
	return pCreative;
}

char GameType_CREATIVE[] = { 0x014C9044 };
char GameType_LOBBY[] = { 0x014C9050 };
//IDA Way
int PlayerSetGameMode(uintptr_t gamemode)
{
	uint32_t r4 = 0x0;
	uintptr_t pCreative = *(uintptr_t*)(CREATIVE);
	uintptr_t pLobby = *(uintptr_t*)(LOBBY);

	r4 = 0x0;
	if (pCreative == gamemode || pLobby == gamemode)
	{
		char bytes[] = { 0x36, 0x80, 0x00, 0x01 }; //li r3, 1
		//write_process(0x002F0348, &bytes, sizeof(bytes));
	}

	return r4;
}



