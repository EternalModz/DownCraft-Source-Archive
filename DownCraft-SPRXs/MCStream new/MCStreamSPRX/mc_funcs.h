#pragma once
#include "MCStream.h"
extern int viscount;
template<typename R, typename... Arguments> inline R Call(long long function, Arguments... args);

struct font_t;
struct Color;

bool isSpectator(uint32_t r3);
void ELBFrostWalk(uint32_t r3, uint32_t r4);

void onEntityUpdate(uint32_t r3);

void EntityPlaySound(uint32_t ent, uint32_t sound, float volume, float pitch);

int wcslen(const wchar_t * wchar);

void drawShadowText(uint32_t font, uint32_t r4, uint32_t x, uint32_t y, uint32_t color, uint32_t r8, uint32_t r9);

font_t getString(const wchar_t * str);

extern int vswprintf_t[2];
extern int(*vswprintf)(wchar_t* buf, int len, const wchar_t*source, ...);

void CLStateColor(float r, float g, float b, float a);

size_t StringToWideCharacter(wchar_t *dest, const char *scr, size_t len);
size_t WideCharacterToString(char *dest, const wchar_t *scr, size_t len);

void sub_8829A4(uint32_t r3, uint32_t r4, uint32_t r5);

uint32_t Tesselator_GetInstance();
uint32_t ReadTesselatorInstance(uint32_t r3);
void Tesselator_Begin(uint32_t pTesselator, int iVertex);
void Tesselator_Begin(uint32_t pTesselator);
void Tesselator_Color(uint32_t pTesselator, uint32_t iColor);
void Tesselator_Color(uint32_t pTesselator, int r, int g, int b, int a);
void Tesselator_Vertex(uint32_t pTesselator, float v1, float v2, float v3);
void Tesselator_End(uint32_t pTesselator);
void Tesselator_End1(uint32_t pTesselator);

void Tesselator_EndVertex(uint32_t pTesselator, float X, float Y, float Z, Color color);

void Tesselator_glNormal3f(uint32_t pTesselator, float v1, float v2, float v3);

void BufferBuilder_endVertex(uint32_t pTesselator, float f1, float f2, float f3, float f4, float f5);



