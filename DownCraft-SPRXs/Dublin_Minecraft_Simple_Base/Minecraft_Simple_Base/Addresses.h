#pragma once
#pragma region Includes
//#include "AddressCaller.h"
#include "PS3Pad.h"
//#include "CallSubMenus.h"
//#include "Colors.h"
#include "Huds.h"
//#include "SubMenus.h"
#include "var.h"
#include "Enums.h"
#pragma endregion

#pragma region Declare
unsigned long ConsoleUIController = 0x01558228;
unsigned long Slot = 0x013CCE70;
unsigned long ResultSlot = 0x013BBA00;
uint32_t ItemRare = 0x01551818;
uint32_t ItemEpic = 0x0155181C;
int MaxPickUp = 0x00310A40;
int slowFalling = 0x003ACD04;
int CrackbutNotBreak = 0x00B32F68;
int GoldenAppleRarityText = 0x002BE994;
int GoldenAppleFunctionsSwitched = 0x002BEA7C;




#pragma endregion

#pragma region Defines


#define TOC 0x014CDAB0
#define PlayerPosition 0x01639148
#define PlayerRotation 0x015772F8
#define PlayerRotationYaw 0x0130BBD0


#define MAKE_FUNCTION(address, return_type, func_name, args) \
	uint32_t func_name##opd[2] = { address, TOC }; \
	using func_name##_t = return_type(*)args; \
	func_name##_t func_name = (func_name##_t)func_name##opd;

#define DWORD_ADDRESS(address, address_name)


#pragma endregion

namespace BUFFERBUILDER{
	MAKE_FUNCTION(0x009C1928, void, Begin, (uint32_t pTesselator));
	MAKE_FUNCTION(0x009C2388, void, Pos_EndVertex, (uint32_t pTesselator, float f1, float f2, float f3, float f4, float f5));
	MAKE_FUNCTION(0x00A3EA38, void, renderShadowSingle, (unsigned int* state, float x, float y, float z, int BlockPos, float par1, float par2, float par3, float par4));
	MAKE_FUNCTION(0x009C1A3C, void, Color, (uint32_t pTesselator, int r, int g, int b, float a));
}

namespace DAMAGESOURCE {
	MAKE_FUNCTION(0x001B25B0, bool, CanHarmInCreative, ());
}

namespace ENTITY {
	MAKE_FUNCTION(0x004A94B8, void, Invulnerable, (uint32_t* player, uint32_t* damageSource, float Damage));
	MAKE_FUNCTION(0x00224714, void, GetEntityDataManager, (uint32_t Enchantment, float amount));
	MAKE_FUNCTION(0x004B0674, bool, CanTriggerWalking, ());
	MAKE_FUNCTION(0x00B03698, void, AutoJumpUpdate, (float x, float something));
}

namespace EntityPlayerSP {
	MAKE_FUNCTION(0x00AFE690, void, SetXPStats, (double currentXP, int maxXP, int level));
	DWORD_ADDRESS(0x420E8CCC, CurrentSkinPack);
	int server_SPacketSetExperience_getExperienceBar = 0x0018A954;
	int NetHandlePlayClient_handleSetExperience = 0x00A236A8;
}

namespace FONTRENDERER {
	MAKE_FUNCTION(0x00AA4794, void, DrawString, (uintptr_t font, const std::wstring& text, int x, int y, int color));
	MAKE_FUNCTION(0x00A7E2E8, void, DrawStringWithShadow, (uint32_t font, const wchar_t * text, uint32_t x, uint32_t y, uint32_t color, int r8, int r9));
	MAKE_FUNCTION(0x00A7DB38, int, getStringWidth, (uintptr_t font, const std::wstring& text));
	//int drawString_opd[2] = { 0x00AA4794, TOC };
	//void(*drawString)(uintptr_t font, const std::wstring& text, int x, int y, int color) = (void(*)(uintptr_t, const std::wstring&, int, int, int))&drawString_opd;
	//MAKE_FUNC(0xA7DB38, uint32_t, Item_Rare, uint32_t);
	//int(*getStringWidth)(uintptr_t font, const std::wstring& text) = (int(*)(uintptr_t, const std::wstring))&getStringWidth_opd;
}

namespace GLSTATEMANAGER {

	MAKE_FUNCTION(0x00A73F10, void, EnableBlend, ());
	MAKE_FUNCTION(0x00A73ED4, void, DisableBlend, ());
	MAKE_FUNCTION(0x00A73A30, void, DisableAlpha, ());
	MAKE_FUNCTION(0x00A73A9C, void, EnableAlpha, ());
	MAKE_FUNCTION(0x00A73AD8, void, AlphaFunc, (int func, float ref));
	MAKE_FUNCTION(0x00A73D7C, void, DisableColorMaterial, ());
	MAKE_FUNCTION(0x00A73B24, void, EnableLighting, ());
	MAKE_FUNCTION(0x00A73B5C, void, DisableLighting, ());
	MAKE_FUNCTION(0x00A73B94, void, EnableLight, (int light));
	MAKE_FUNCTION(0x00A73BDC, void, DisableLight, (int light));
	MAKE_FUNCTION(0x00A73C24, void, ColorMaterial, (uint32_t face, int mode));
	MAKE_FUNCTION(0x00A73DCC, void, DisableDepth, ());
	MAKE_FUNCTION(0x00A73E08, void, EnableDepth, ());
	MAKE_FUNCTION(0x00A73E44, void, DepthFunc, (int depthFunc));
	MAKE_FUNCTION(0x00A73E8C, void, DepthMask, (int flagIn));
	MAKE_FUNCTION(0x00A73F4C, void, BlendFunc, (int srcFactor, int dstFactor));
	MAKE_FUNCTION(0x00A73FC0, void, EnableFog, ());
	MAKE_FUNCTION(0x00A73FFC, void, DisableFog, ());
	MAKE_FUNCTION(0x00A74038, void, setFog, (int param));
	MAKE_FUNCTION(0x00A74080, void, SetFogDensity, (double param));
	MAKE_FUNCTION(0x00A740C4, void, SetFogStart, (double param));
	MAKE_FUNCTION(0x00A74108, void, SetFogEnd, (double param));
	MAKE_FUNCTION(0x00A7414C, void, GlFog, ());
	MAKE_FUNCTION(0x00A7415C, void, GlFogI, ());
	MAKE_FUNCTION(0x00A7416C, void, EnableCull, ());
	MAKE_FUNCTION(0x00A741A8, void, DisableCull, ());
	MAKE_FUNCTION(0x00A741E4, void, CullFace, (int mode));
	MAKE_FUNCTION(0x00A74234, void, EnablePolygonOffset, ());
	MAKE_FUNCTION(0x00A74270, void, DisablePolygonOffset, ());
	MAKE_FUNCTION(0x00A74324, void, doPolygonOffset, (double factor, double units));
	MAKE_FUNCTION(0x00A7436C, void, EnableColorLogic, ());
	MAKE_FUNCTION(0x00A743A8, void, DisableColorLogic, ());
	MAKE_FUNCTION(0x00A743E4, void, ColorLogic, (int texGen));
	MAKE_FUNCTION(0x00A74444, void, EnableTexGenCoord, (int texGen));
	MAKE_FUNCTION(0x00A7447C, void, DisableTexGenCoord, (int texGen));
	MAKE_FUNCTION(0x00A744B4, void, TexGen, (int texGen, int param));
	MAKE_FUNCTION(0x00A74578, void, SetActiveTexture, (int texture));
	MAKE_FUNCTION(0x00A74584, void, EnableTexture2D, ());
	MAKE_FUNCTION(0x00A745D4, void, DisableTexture2D, ());
	MAKE_FUNCTION(0x00A74624, void, GenerateTexture, ());
	MAKE_FUNCTION(0x00A7465C, void, DeleteTexture, (int texture));
	MAKE_FUNCTION(0x00A746E0, void, BendTexture, (int texture));
	MAKE_FUNCTION(0x00A74960, void, GlTexImage2D, (uint32_t target, uint32_t level, uint32_t internalFormat, uint32_t width, int height, int border, int type, int r8, int r9, int r10));
	MAKE_FUNCTION(0x00A749E4, void, EnableNormalize, ());
	MAKE_FUNCTION(0x00A74A1C, void, DisableNormalize, ());
	MAKE_FUNCTION(0x00A74A54, void, ShadeModel, (int mode));
	MAKE_FUNCTION(0x00A74A6C, void, EnableRescaleNormal, ());
	MAKE_FUNCTION(0x00A74AA4, void, DisableRescaleNormal, ());
	MAKE_FUNCTION(0x00A74B18, void, ColorMask, (char red, char green, char blue, char alpha));
	MAKE_FUNCTION(0x00A74B84, void, ClearDepth, (double depth));
	MAKE_FUNCTION(0x00A74B94, void, ClearColor, (double red, double green, double blue, double alpha));
	MAKE_FUNCTION(0x00A74D20, void, GetFloat, (int32_t pname, int32_t param));
	MAKE_FUNCTION(0x00A75024, void, Color1, (float colorRed, float colorGreen, float colorBlue, float colorAlpha));
	MAKE_FUNCTION(0x00A75074, void, Color2, (float colorRed, float colorGreen, float ColorBlue));
}

namespace GUI {
	MAKE_FUNCTION(0x00A7E688, void, DrawTextureModalRect, (int x, int y, int textureX, int width, int height)); //Draws a texture rectangle at the current z-value.
	MAKE_FUNCTION(0x009C4F84, void, GetFontRenderer, ());
}

namespace MULTIPLAYER {
	MAKE_FUNCTION(0x002F027C, void, setPlayerGameMode, (int modePtr, int modeTick));
	MAKE_FUNCTION(0x00BB9194, void, setServerPlayerGameMode, (int dwordAddr, int gameModePtr));
	MAKE_FUNCTION(0x00B33A08, void, MultiPlayerGameMode_tick, (int* multiPlayerGameMode));
	MAKE_FUNCTION(0x00218A30, void, GetMaxEnchantmentLevel, (uint32_t Enchantment, int pos));

}

namespace MCPROFILER {
	MAKE_FUNCTION(0x00A73838, void, endStartScreen, (uint32_t result));//End current section and start a new section
}


namespace PARTICLES {
	MAKE_FUNCTION(0x000B51490, void, addBlockHitEffects, (unsigned int* BlockPos, int EnumFacing_side));
	MAKE_FUNCTION(0x00B50AF8, void, renderParticle, (uint32_t EntityIn, float particleTicks));
	MAKE_FUNCTION(0x009BECA0, void, renderParticle1, (uint32_t pTesselator, unsigned int* EntityIn, float particleTicks, float rotationX, float rotationZ, float rotationYZ, float rotationXY, float rotationXZ)); //Renders the particle
	MAKE_FUNCTION(0x00B50ED0, void, SetPosition, (int* a1, int* a2, int* a3, int* a4));
}

namespace PARTICLESWEEPATTACK {
	/*Retrieve what effect layer (what texture) the particle should be rendered with. 0 for the particle sprite sheet,
	//1 for the main Texture atlas, and 3 for a custom texture.
	*/
	MAKE_FUNCTION(0x009BEFEC, int, GetFXLayer, ());
}



namespace PLAYER {
	DWORD_ADDRESS(0x0140DF40, ServerPlayer);
	DWORD_ADDRESS(0x014CF2E4, TheMC);
	DWORD_ADDRESS(0x016BD758, ClientProfile);
	MAKE_FUNCTION(0x00ACA1C8, void, getMinecraft, ());
	MAKE_FUNCTION(0x004A9500, int, isInvulnerable, ());//Fix Later
	MAKE_FUNCTION(0x003AA780, void, PlayerUpwardsJumpMotion, (float jumpHeight));
	MAKE_FUNCTION(0x002BEA3C, void, GoldenAppleOnEaten, (void* Item, int stack, int worldIn, uint32_t EntityPlayer));
	MAKE_FUNCTION(0x0045E26C, void, PotionEffect, (void* Potion, int potionIn, int durationIn, int amplifierIn));

}

namespace RENDER {
	/**
	* Renders a white box with the bounds of the AABB trasnlated by an offset.
	*/
	MAKE_FUNCTION(0x00A3ED78, void, RenderOffsetAABB, (int boundingBox, float x, float y, float z));
	MAKE_FUNCTION(0x00A3DF08, void, RenderEntityOnFire, (int Entity, float x, float y, float z, float particleTicks));
	MAKE_FUNCTION(0x00A5C0C8, void, RenderDebugBoundingBox, (int Entity, float x, float y, float z, float yaw, float particleTicks));
}

namespace RENDERHELPER {
	MAKE_FUNCTION(0x00ACE5F0, void, EnableGUIStandardItemLighting, ()); //sets OpenGL lighting for rendering blocks as items inside GUI screens (such as containers)

}



namespace TESSELLATOR {
	MAKE_FUNCTION(0x00BDCA9C, uint32_t, ReadInstance, (uint32_t pTessellator));
	MAKE_FUNCTION(0x009C170C, void, Draw, (uint32_t pTesselator));
	MAKE_FUNCTION(0x00BDCA84, uint32_t, getInstance, ());
	MAKE_FUNCTION(0x00BDCA9C, void, GetBuffer, ());
}

namespace Menu {

};

namespace UI {
	void UI_DrawMenuBackground();
	void AddInstructionText(const wchar_t * InstructionText);
	void AddMenuTitle(const wchar_t * MenuTitle);
	void AddTitle(const wchar_t * Headertitle);
	void AddOptionText(const wchar_t * OptionText);
	void AddBoolOption(const wchar_t * opt, void(*function)(), bool boolOption);
	void AddSubOption(const wchar_t * opt, SubMenus subMenu);
	void AddOption(const wchar_t * opt, void(*function)());
	template<typename arg_t>
	void AddOption(const wchar_t * opt, void(*function)(arg_t arg), arg_t arg);
	void Selector(const wchar_t * option, void(*function)());
};





