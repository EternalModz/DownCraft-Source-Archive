#pragma once
#include "struct.h"


int mcOfs = 0x014CF2E4;
int btnMonOfs = 0x3000cec8;
int gameRenderHook = 0x00AA3360;
int ctrlLockOfs = 0x0155847c;
int shaderOfs = 0x00A7E2E8;

int theMcOfs = 0x014cf2e4;
int addr1 = 0x00BDCA84;
int addr2 = 0x00BDCA9C;
int BufferBuilder_Begin = 0x009C1928;
int BufferBuilder_Color = 0x009C1A3C;
int Tessalator_Draw = 0x009C170C;
int addr6 = 0x009C2388;
int ofs1 = 0x30000000;
int ofs2 = 0x35000000;
int ofs3 = 0x01500000;
int ofs4 = 0x01100000;

namespace clientStruct
{
	int verify = 0x04;
	int getView = 0xE0;
	int setView = 0x148;
	int origin = 0x100;
	int active1 = 0x1E8;
	int active2 = 0x3AC;
	int targetP = 0x4E8;
	int alive1 = 0x197;
	int alive2 = 0x138;
	int invul = 0x6F0;
	int name = 0x764;
	int id = 0x774;
};


bool clientUpdated = false;
int firstWaitTime = 15;
int waitTime = 5;
int scrollTick = 0;
bool keyPressed[100];
bool freeFirst[100];
bool resetWait[100];
bool resetWait2[100];
bool lockFirst[100];
int getTime[1000];
int timeMath[1000];
bool gotTime[1000];
int subMax = 0;
int scroll = 0;
bool isOpen = false;
char* checkTxt = "";
wchar_t charA2wcharA_[1000];
int userAddr = 0;
TheMinecraft * mc;
//Vector2 _getView;
//Vector3 _getOrigin;
//Vector3 userOrigin;
void select();