#pragma once

GuiComponent* g_GuiComponent;

#pragma region "OpenGL Functions"

void EnableBlend()
{
	Call<void>(0x00A73F10);
}

void DisableBlend()
{
	Call<void>(0x00A73ED4);
}

void EnableAlpha()
{
	Call<void>(0x00A73A9C);
}

void DisableAlpha()
{
	Call<void>(0x00A73A30);
}

void AlphaFunc(int func, float ref)
{
	Call<void>(0x00A73AD8, func, ref);
}

void DisableColorMaterial()
{
	Call<void>(0x00A73D7C);
}

void EnableLighting()
{
	Call<void>(0x00A73B24);
}

void DisableLighting()
{
	Call<void>(0x00A73B5C);
}

void EnableLight(int light)
{
	Call<void>(0x00A73B94, light);
}

void DisableLight(int light)
{
	Call<void>(0x00A73BDC, light);
}

void ColorMaterial(uint32_t face, int mode)
{
	Call<void>(0x00A73C24, face, mode);
}

void EnableDepth()
{
	Call<void>(0x00A73E08);
}

void DisableDepth()
{
	Call<void>(0x00A73DCC);
}

void DepthFunc(int depthFunc)
{
	Call<void>(0x00A73E44, depthFunc);
}

void DepthMask(int flagIn)
{
	Call<void>(0x00A73E8C, flagIn);
}

void BlendFunc(int srcFactor, int dstFactor)
{
	Call<void>(0x00A73F4C, srcFactor, dstFactor);
}

void EnableFog()
{
	Call<void>(0x00A73FC0);
}

void DisableFog()
{
	Call<void>(0x00A73FFC);
}

void setFog(int param)
{
	Call<void>(0x00A74038, param);
}

void SetFogDensity(double param)
{
	Call<void>(0x00A74080, param);
}

void SetFogStart(double param)
{
	Call<void>(0x00A740C4, param);
}

void SetFogEnd(double param)
{
	Call<void>(0x00A74108, param);
}

void GlFog()
{
	Call<void>(0x00A7414C);
}

void GlFogI()
{
	Call<void>(0x00A7415C);
}

void EnableCull()
{
	Call<void>(0x00A7416C);
}

void DisableCull()
{
	Call<void>(0x00A741A8);
}

void CullFace(int mode)
{
	Call<void>(0x00A741E4, mode);
}

void EnablePolygonOffset()
{
	Call<void>(0x00A74234);
}

void DisablePolygonOffset()
{
	Call<void>(0x00A74270);
}

void doPolygonOffset(double factor, double units)
{
	Call<void>(0x00A74324, factor, units);
}

void EnableColorLogic()
{
	Call<void>(0x00A7436C);
}

void DisableColorLogic()
{
	Call<void>(0x00A743A8);
}

void ColorLogic(int texGen)
{
	Call<void>(0x00A743E4, texGen);
}

void EnableTexGenCoord(int texGen)
{
	Call<void>(0x00A74444, texGen);
}

void DisableTexGenCoord(int texGen)
{
	Call<void>(0x00A7447C, texGen);
}

void TexGen(int texGen, int param)
{
	Call<void>(0x00A744B4, texGen, param);
}

void SetActiveTexture(int texture)
{
	Call<void>(0x00A74578, texture);
}

void EnableTexture2D()
{
	Call<void>(0x00A74584);
}

void DisableTexture2D()
{
	Call<void>(0x00A745D4);
}

void GenerateTexture()
{
	Call<void>(0x00A74624);
}

void DeleteTexture(int texture)
{
	Call<void>(0x00A7465C, texture);
}

void BendTexture(int texture)
{
	Call<void>(0x00A746E0, texture);
}

void GlTexImage2D(uint32_t target, uint32_t level, uint32_t internalFormat, uint32_t width, int height, int border, int type, int r8, int r9, int r10)
{
	Call<void>(0x00A74960, target, level, internalFormat, width, height, border, type, r8, r9, r10);
}

void EnableNormalize()
{
	Call<void>(0x00A749E4);
}

void DisableNormalize()
{
	Call<void>(0x00A74A1C);
}

void ShadeModel(int mode)
{
	Call<void>(0x00A74A54);
}

void EnableRescaleNormal()
{
	Call<void>(0x00A74A6C);
}

void DisableRescaleNormal()
{
	Call<void>(0x00A74AA4);
}

void ColorMask(char red, char green, char blue, char alpha)
{
	Call<void>(0x00A74B18, red, green, blue, alpha);
}

void ClearDepth(double depth)
{
	Call<void>(0x00A74B84, depth);
}

void ClearColor(double red, double green, double blue, double alpha)
{
	Call<void>(0x00A74B94, red, green, blue, alpha);
}

void GetFloat(int32_t pname, int32_t param)
{
	Call<void>(0x00A74D20, pname, param);
}

void Color1(float colorRed, float colorGreen, float colorBlue, float colorAlpha)
{
	Call<void>(0x00A75024, colorRed, colorGreen, colorBlue, colorAlpha);
}

void Color2(float colorRed, float colorGreen, float ColorBlue)
{
	Call<void>(0x00A75074, colorRed, colorGreen, ColorBlue);
}

#pragma endregion

void CLStateColor(float r, float g, float b, float a) {
	Call<void>(0x00A75024, r, g, b, a);
}

bool CanHarmInCreative()
{
	Call<void>(0x001B25B0);
}

void getMinecraft()
{
	Call<void>(0x00ACA1C8);
}

void LocalPlayer() 
{
	getMinecraft();
}

void setItemStackToSlot() {
	Call<void>(0x004B0930);
}

void getHotbarSize() {
	Call<void>(0x0030E618);
}


void MultiPlayerGameMode_tick(void* multiPlayerGameMode) {
	Call<void>(0xB33A08, multiPlayerGameMode);
}

bool GuiComponent_drawString(void* guiComponent, uint32_t font, uint32_t text, uint32_t x, uint32_t y, uint32_t color) {
	Call<void>(0xA7E5DC, guiComponent, font, text, x, y, color);
}

uint32_t MultiPlayerGameMode_useItemOn(void* gameMode, void* player, void* level, void* blockPos, void* direction, void* pos, uint32_t interactionHand, bool unk1, bool* unk2) {
	Call<void>(0xAE4CD8, gameMode, player, level, blockPos, direction, pos, interactionHand, unk1, unk2);
}

void drawShadowText(uint32_t font, uint32_t r4, uint32_t x, uint32_t y, uint32_t color, uint32_t r8, uint32_t r9) {
	Call<void>(shaderOfs, font, r4, x, y, color, r8, r9);
}

void GuiComponent_fill(void* guiComponent, uint32_t x, uint32_t y, uint32_t width, uint32_t height, uint32_t color) {
	Call<void>(0xA7CE80, guiComponent, x, y, width, height, color);
}

void ConsoleUIController_PlayUISFX(uintptr_t consoleUIController, uintptr_t soundEvent) 
{
	Call<void>(PlayUISFX, consoleUIController, soundEvent);
}

int Minecraft_getLocalPlayerIdx(void* minecraft) {
	Call<void>(GetLocalPlayerID, minecraft);
}

void MultiPlayerLevel_getEntity(void* outEntity, void* multiPlayerLevel, int id) {
	Call<void>(MultiPlayerGetEntity, outEntity, multiPlayerLevel, id);
}

void MultiPlayerGameMode_destroyBlock(void* gamemode, void* blockPos) {
	Call<void>(MPDestroyBlock, gamemode, blockPos);
}

int __printf(const char* format, ...) {
	Call<void>(Ofsprintf, format);
}

void Gui_render(void* guiComponent, double unk) {
	Call<void>(GuiRender, guiComponent, unk);
}

int __snprintf(char* s, size_t n, const char* format, ...) {
	Call<void>(Ofssnprintf, s, n, format);
}

int CInput_GetValue(uintptr_t cinput, uint32_t unk, uint8_t button, uint32_t r6)
{
	Call<int>(0xC619E0, cinput, unk, button, r6);
}

bool CInput_ButtonPressed(uintptr_t cinput, uint32_t unk, uint8_t button, uint32_t r6)
{
	Call<bool>(0xC61D04, cinput, unk, button, r6);
}

bool CInput_ButtonReleased(uintptr_t cinput, uint32_t unk, uint8_t button, uint32_t r6)
{
	Call<bool>(0xC61EEC, cinput, unk, button, r6);
}

bool CInput_ButtonDown(uintptr_t cinput, uint32_t unk, uint8_t button)
{
	Call<bool>(0xC61F84, cinput, unk, button);
}

double CInput_GetJoyStick_LX(uintptr_t cinput, uint8_t button, bool r5)
{
	Call<double>(0xC62490, cinput, button, r5);
}

double CInput_GetJoyStick_LY(uintptr_t cinput, uint8_t button, bool r5)
{
	Call<double>(0xC62500, cinput, button, r5);
}

double CInput_GetJoyStick_RX(uintptr_t cinput, uint8_t button, bool r5)
{
	Call<double>(0xC62570, cinput, button, r5);
}

double CInput_GetJoyStick_RY(uintptr_t cinput, uint8_t button, bool r5)
{
	Call<double>(0xC625E0, cinput, button, r5);
}

float GameRenderer_GetFov(void* gameRenderer, float datFloat, int datBoolean)
{
	Call<void>(0xA96E90, gameRenderer, datFloat, datBoolean);
}

void GameRenderer_getFovAndAspect(void* gameRenderer, float* fov, float* aspectRatio, uint32_t r6, bool someFovBool)
{
	Call<void>(0xA98E30, gameRenderer, fov, aspectRatio, r6, someFovBool);
}

#pragma region "Tessellator Function"

uint32_t Tesselator_GetInstance() {
	return Call<uint32_t>(addr1);
}

uint32_t ReadTesselatorInstance(uint32_t r3) {
	return Call<uint32_t>(addr2, r3);
}

void Tesselator_Begin(uint32_t pTesselator) {
	Call<void>(addr3, pTesselator);
}

void Tesselator_Color(uint32_t pTesselator, int r, int g, int b, double a) {
	Call<void>(addr4, pTesselator, r, g, b, a);
}

void Tesselator_End(uint32_t pTesselator) {
	Call<void>(addr5, pTesselator);
}

void BufferBuilder_endVertex(uint32_t pTesselator, float f1, float f2, float f3, float f4, float f5) {
	Call<void>(addr6, pTesselator, f1, f2, f3, f4, f5);
}

void Tesselator_EndVertex(uint32_t pTesselator, float X, float Y, float Z, int* Color) {
	Tesselator_Color(pTesselator, Color[0], Color[1], Color[2], 255);
	BufferBuilder_endVertex(pTesselator, X, Y, Z, 0, 0);
}

#pragma endregion

uintptr_t pCInput = (uintptr_t)0x16BD748;
uintptr_t ConsoleUIController = 0x1558228;
uintptr_t* pSoundEventBack = (uintptr_t*)0x14CA684;
uintptr_t* pSoundEventCraft = (uintptr_t*)0x14CA688;
uintptr_t* pSoundEventFocus = (uintptr_t*)0x14CA690;
uintptr_t* pSoundEventPress = (uintptr_t*)0x14CA694;
uintptr_t* pSoundEventScroll = (uintptr_t*)0x14CA698;