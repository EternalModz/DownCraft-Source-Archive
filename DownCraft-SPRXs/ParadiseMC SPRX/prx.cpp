#include "stdafx.h"

#include <cellstatus.h>
#include <sys/prx.h>
#include "types.h"
#include "nativeCaller.h"

#include <sys/types.h>
#include <sys/socket.h> 
#include <netdb.h> 
#include <sys/types.h> 
#include <netinet/in.h>
#include <cell/cell_fs.h>
#include <sys/stat.h>
#include <cellstatus.h>
#include <sys/prx.h>
#include <sys/ppu_thread.h>
#include <string.h>
#include <sys/memory.h>
#include <sys/timer.h>
#include <sys/process.h>
#include <ppu_intrinsics.h>
#include <stdarg.h>
#include <stdio.h>
#include <sysutil\sysutil_msgdialog.h>
#include <sysutil\sysutil_oskdialog.h>
#include <sysutil\sysutil_oskdialog_ext.h>
#include <cstdlib>
#include <math.h>
#include <sys/types.h>
#include <sys/socket.h> 
#include <netdb.h> 
#include <sys/types.h> 
#include <netinet/in.h>
#include <cell/cell_fs.h>
#include <sys/stat.h>
#include "lib.h";
#include "Dialog.h"
#include "mods.h"
#include "PS3Lib.h"
#include "Structures.h"


SYS_MODULE_INFO(ParadiseMC, 0, 1, 1);
SYS_MODULE_START(_ParadiseMC_prx_entry);

SYS_LIB_DECLARE_WITH_STUB(LIBNAME, SYS_LIB_AUTO_EXPORT, STUBNAME);
SYS_LIB_EXPORT(_ParadiseMC_export_function, LIBNAME);

/*uint32_t Thingy = 0x18426DC;

uint32_t Table = *(uint32_t*)Thingy + 0x14;

uint32_t FunctionEntry = *(uint32_t*)(Table + (FunctionID << 2));

uint32_t FunctionEntry2 = *(uint32_t*)FunctionEntry;

uint32_t FunctionEntry3 = *(uint32_t*)FunctionEntry2;

uint32_t FunctionStruct = FunctionEntry3 - 8;*/

void debugData(unsigned char *data, int size, int formatSize = 4, int lineSize = 16) {
	for (int i = 0; i < size; i++) {
		printf("%02X",data[i]);
		if ((i+1)%formatSize==0)
			printf(" ");
		if ((i+1)%lineSize==0)
			printf("\n");
	}
}
int txtSP = 0x3117242C;
int txtBGSP = 0x3117197C;
int txt2SP = 0x311704AC;
int txt2BGSP = 0x3116F9FC;
int ctrlLock = 0x1463614;
int canUseOfs = 0x3000cf68;
struct somestringfunctiondata {
	int unk1;
	char string[16];
	int stringSize;
	int unk2;//0xF
	char extra[20];
};
opd_s somestringfunction_t = {0xDB9A98,TOC};
void (*somestringfunction)(somestringfunctiondata *destination,char *string) = (void(*)(somestringfunctiondata*,char*))&somestringfunction_t;

struct functionInfo {
	int functionId;
	unsigned int unkfunctionArg1;
	unsigned int unkfunctionArg2;
};

unsigned int getFunctionById(functionInfo info) {
	//functionInfo info;
	//info.functionId = id;
	//info.unkfunctionArg1 = 0x10020000;
	//info.unkfunctionArg2 = 0x1062C230;
	printf("creating function to call\n");
	opd_s sub_ED383C_t = {0xED383C,TOC};
	unsigned int (*sub_ED383C)(unsigned int functionsStorer,functionInfo functionID) = (unsigned int(*)(unsigned int,functionInfo))&sub_ED383C_t;
	unsigned int ret = sub_ED383C(0x18426DC,info);
	printf("Return value: 0x%X\n",ret);
	return *(int*)*(int*)ret;
}

int hook8(int r3, int r4, int r5, int r6, int r7) {//callFunctionByIdR4IsANumber
	//printf("r3: 0x%X\n",r3);

	opd_s sub_233424_t = {0x233424,TOC};
	int (*sub_233424)(int r3, int r4, int r5, int r6, int r7) = (int(*)(int,int,int,int,int))&sub_233424_t;
	//printf("fix function\n");
	char data[] = {0xF8, 0x21, 0xFF, 0x51, 0x7C, 0x08, 0x02, 0xA6, 0xF8, 0x01, 0x00, 0xC0, 0xFB, 0xE1, 0x00, 0xA8};
	write_process((void*)0x233424,data,4*4);
	//printf("do code\n");
#pragma region code




	//finding the branch function at 0x518284:
	/*int r4 = *(int*)(r3+0x8);
	int r6 = *(int*)(r4);
	r4 = *(int*)(r6+0x8);
	r4 = *(int*)(r4);*/
	//yay now we got the branch address... simplifies is:
	int branchAddress = *(int*)(*(int*)(*(int*)(*(int*)(r3+0x8))+0x8));
	int argForIt = *(int*)(r3+0x8);
	//opd_s branch_t = {branchAddress,TOC};
	//int (*branch)(int r3) = (int(*)(int))&branch;
	//int id = branch(argForIt);
	/*
	//reverse of branchAddress
	lwz       r3, 8(r3)
	lwz       r4, 0(r3)
	lwz       r4, 8(r4)
	lwz       r4, 0(r4)
	r3 = *(int*)(r3+0x8);
	r4 = *(int*)(r3);
	r4 = *(int*)(r4+0x8);
	r4 = *(int*)(r4);
	which is:
	address = *(int*)(*(int*)(*(int*)(*(int*)(r3+0x8))+0x8));
	*/
	int secondBranchAddress = *(int*)(*(int*)(*(int*)(*(int*)(argForIt+0x8))+0x8));
	printf("r3: 0x%X, branchAddress: 0x%X, argForIt: 0x%X, secondBranchAddress: 0x%X\n",r3,branchAddress,argForIt,secondBranchAddress);
	
	
	functionInfo info;
	info.functionId = 8;
	info.unkfunctionArg1 = *(int*)(0x00D02E3E50+0);   //the stack for the value read at 0x233460 which is r3 for the other function. Best I could do.
	info.unkfunctionArg1 = *(int*)(0x00D02E3E50+4);

	printf("SetHealth address: 0x%X\n",getFunctionById(info));
	
	//sub_ED258C(buf,functionsArray)


	/*
	r3: 0x32CE46A0
	branchAddress: 0x257358, argForIt: 0x326A7D20
	*/

	//printf("SetHealth address: 0x%X\n",getFunctionById(8));
	//printf("Ran some code! lol\n");




#pragma endregion
	//printf("call function and get value\n");
	int value = sub_233424(r3,r4,r5,r6,r7);
	//printf("re-patch\n");
	PatchInJump(0x233424,(int)hook8,false);
	//printf("return value\n");
	return value;
}

int pos = 0x440C0000;
bool useInBattle;
int hudDelay;
bool menuRunning;
bool isOpen;
int scrollPos;
int curSub;
int maxSub;
int menuOpts[6] = { -1280, -1510, -1664, -1892, -2084, -2358 };
int *linePos;
int menuIndexArray[1000];
char* mainTxt[4];
int *temp_subOpts;
int *subOptss;
char* temp_mainTxt[4] = { "Host Menu", "Non-host Menu", "Game Editor", "Selector Color" };
int subOpts = 0;
int menuId = 0;
int txtOfs = 0;
int txtBgOfs = 0;
int memRegion = 0;
bool invisibility = false;
int waitTimer = 0;
int forceUse = 1;
char* HexArray = "3F8000003F8000003F8000003F800000";
//vector3 mainPos  = { -16104, -16320, -16527, -16749 };
static int mainPos[4];

int sub1_1OptPos[17];
int sub1_2OptPos[6];

int sub2_1OptPos[29];
int sub2_2OptPos[18];

opd_s LiveStats_MoveToPlayerStatPath_t = { 0x5432A4, TOC };
int (*lsc)(int r3, int r4, int r5, int r6, int r7, int r8, int r9) = (int(*)(int, int, int, int, int, int, int))&LiveStats_MoveToPlayerStatPath_t;

char livestatsdetourdata[4*4];

int livestatsdetour(int r3, int r4, int r5, int r6, int r7, int r8, int r9) {
	//memcpy((void*)0x5432A4,livestatsdetourdata,4*4);
	//int returnValue = lsc(r3,r4,r5,r6,r7,r8,r9);

	//code
	printf("r3: 0x%X, r4: 0x%X, r5: 0x%X, r6: 0x%X, r7: 0x%X, r8: 0x%X, r9: 0x%X\n",r3,r4,r5,r6,r7,r8,r9);

	//PatchInJump(0x5432A4,(int)livestatsdetour,false);
	//return returnValue;
}

template <typename T>
T(*call(unsigned int address, unsigned int toc = TOC))(...) {
	opd_s opd = { address,toc };
	T(*func)(...) = (T(*)(...))&opd;
	return func;
}

/*template<typename Q, typename P1, typename P2, typename P3, typename P4, typename P5, typename P6, typename P7, typename P8>
Q invoke(unsigned int NativeHash, P1 p0, P2 p1, P3 p2, P4 p3, P5 p4, P6 p5, P7 p6, P8 p7)
{
	ResetArgs();
	PushArg(p0);
	PushArg(p1);
	PushArg(p2);
	PushArg(p3);
	PushArg(p4);
	PushArg(p5);
	PushArg(p6);
	PushArg(p7);
	CallHash(NativeHash, NativeArg);
	return GetReturn<T>();
}*/

/*template<typename T, typename P1, typename P2, typename P3, typename P4, typename P5, typename P6, typename P7, typename P8, typename P9>
T invoke(unsigned int NativeHash, P1 p0, P2 p1, P3 p2, P4 p3, P5 p4, P6 p5, P7 p6, P8 p7, P9 p8)
{
	ResetArgs();
	PushArg(p0);
	PushArg(p1);
	PushArg(p2);
	PushArg(p3);
	PushArg(p4);
	PushArg(p5);
	PushArg(p6);
	PushArg(p7);
	PushArg(p8);
	CallHash(NativeHash, NativeArg);
	return GetReturn<T>();
}*/

void DRAW_RECT(int ofs, int width, int stretchV, int stretchH, int height, int xPos, int yPos)
{//callFunctionByIdR4IsANumber
//printf("r3: 0x%X\n",r3);
	opd_s sub_311914CC_t = { txtSP,TOC };
	int(*sub_233424)(int ofs, int width, int stretchV, int stretchH, int height, int xPos, int yPos) = (int(*)(int, int, int, int, int, int, int))&sub_311914CC_t;
	//printf("fix function\n");
	//30 00 00 00 30 00 00 00 30 00 00 00 4F 00 00 00
	char data[] = { 0x3F, 0xA0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0xA0, 0x00, 0x00, 0x53, 0x00, 0x00, 0x00, 0xC3, 0xF5, 0x00, 0x00 };
	write_process((void*)txtSP, data, 4*6);
}

int DRAW_RECT1(int r1, int r2, int r3, int r4, int r5)
{//callFunctionByIdR4IsANumber
 //printf("r3: 0x%X\n",r3);
	opd_s sub_31190A1C_t = { txtBGSP,TOC };
	int(*sub_233424)(int r1, int r2, int r3, int r4, int r5) = (int(*)(int, int, int, int, int))&sub_31190A1C_t;
	//printf("fix function\n");
	//30 00 00 00 30 00 00 00 30 00 00 00 4F 00 00 00
	//3F 80 00 00 3F 80 00 00 3F 80 00 00 3F 80 00 00
	char data[] = { 0x3F, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x43, 0xCC, 0x00, 0x00, 0xC3, 0xC3, 0x00, 0x00};
	write_process((void*)txtBGSP, data, 4 * 6);
}

int DRAW_RECT2(unsigned int ofs, float xPos)
{//callFunctionByIdR4IsANumber
 //printf("r3: 0x%X\n",r3);
	functionInfo info;
	opd_s sub_31190A1CA_t = { txtBGSP,TOC };
	unsigned int(*sub_31190A1CA)(unsigned int functionsStorer, functionInfo functionID) = (unsigned int(*)(unsigned int, functionInfo))&sub_31190A1CA_t;
	unsigned int ret = sub_31190A1CA(txtBGSP, info);
	//printf("fix function\n");
	//30 00 00 00 30 00 00 00 30 00 00 00 4F 00 00 00
	//3F 80 00 00 3F 80 00 00 3F 80 00 00 3F 80 00 00
	return *(int*)*(int*)ret;
}

unsigned int DRAW_RECT3(functionInfo info) {
	//functionInfo info;
	//info.functionId = id;
	//info.unkfunctionArg1 = 0x10020000;
	//info.unkfunctionArg2 = 0x1062C230;
	printf("creating function to call\n");
	opd_s sub_31190A1CA_t = { txtBGSP,TOC};
	unsigned int (*sub_31190A1CA)(unsigned int functionsStorer,functionInfo functionID) = (unsigned int(*)(unsigned int,functionInfo))&sub_31190A1CA_t;
	unsigned int ret = sub_31190A1CA(txtBGSP,info);
	printf("Return value: 0x%X\n",ret);
	return *(int*)*(int*)ret;
}

void DRAW_RECT4(int ofs, int width, int stretchV, int stretchH, int height, int xPos, int yPos)
{//callFunctionByIdR4IsANumber
 //printf("r3: 0x%X\n",r3);
	opd_s sub_3118F54C_t = { txt2SP,TOC };
	int(*sub_3118F54C)(int ofs, int width, int stretchV, int stretchH, int height, int xPos, int yPos) = (int(*)(int, int, int, int, int, int, int))&sub_3118F54C_t;
	//printf("fix function\n");
	//30 00 00 00 30 00 00 00 30 00 00 00 4F 00 00 00
	char data[] = { 0x3F, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x30, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
	write_process((void*)txt2SP, data, 4 * 6);
}

void DRAW_RECT5(int ofs, int width, int stretchV, int stretchH, int height, int xPos, int yPos)
{//callFunctionByIdR4IsANumber
 //printf("r3: 0x%X\n",r3);
	opd_s sub_3118EA9C_t = { txt2BGSP,TOC };
	int(*sub_3118EA9C)(int ofs, int width, int stretchV, int stretchH, int height, int xPos, int yPos) = (int(*)(int, int, int, int, int, int, int))&sub_3118EA9C_t;
	//printf("fix function\n");
	//30 00 00 00 30 00 00 00 30 00 00 00 4F 00 00 00
	char data[] = { 0x45, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x30, 0x00, 0x00, 0xC4, 0x00, 0x00, 0x00, 0xC4, 0x00, 0x00, 0x00};
	write_process((void*)txt2BGSP, data, 4 * 6);
}

void DRAW_RECT6(int ofs, int width, int stretchV, int stretchH, int height, int xPos, int yPos)
{//callFunctionByIdR4IsANumber
 //printf("r3: 0x%X\n",r3);
	opd_s sub_31190A1C_t = { txtBGSP,TOC };
	int(*sub_31190A1C)(int ofs, int width, int stretchV, int stretchH, int height, int xPos, int yPos) = (int(*)(int, int, int, int, int, int, int))&sub_31190A1C_t;
	//printf("fix function\n");
	//30 00 00 00 30 00 00 00 30 00 00 00 4F 00 00 00
	char data[] = { 0x3E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x43, 0x60, 0x00, 0x00, 0xC3, 0xF3, 0x00, 0x00 };
	write_process((void*)txtBGSP, data, 4 * 6);
}

void WriteFloat(int offset, float input)
{

}

int doScroll(int scroll, int max)
{
	scroll = scrollPos;
	if (scroll == max + 1)
	{
		return 1;
	}
	else if (scroll == 0)
	{
		return max;
	}
	else
	{
		return scroll;
	}
}

void setHud(unsigned int ofs, float xPos)
{
	*(int*)txtSP = (ofs + 0x10, xPos);
}


bool canUse()
{
	if (*(char*)canUseOfs == 0x00)
	{
		return true;
	}
	else
	{
		return false;
	}
}

void scrollOpt(int pos)
{
	txtOfs = txtSP;
	scrollPos = doScroll(pos, maxSub);
	for (int i = 0; i < forceUse; i++)
	{
		setHud(memRegion + txtOfs, linePos[scrollPos - 1] + -1689);
	}
}

void showHud()
{
	for (int i = 0; i < forceUse; i++)
	{
		char data[] = { 0x3F, 0xA0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0xE0, 0x00, 0x00, 0xC6, 0x8E, 0xB0, 0x00, 0xC3, 0xC9, 0x00, 0x00 };
		write_process((void*)txtSP, data, 4 * 6);

		char data1[] = { 0x3F, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x30, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
		write_process((void*)txt2SP, data1, 4 * 6);

		char dataa[] = { 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x41, 0xF0, 0x00, 0x00 };
		write_process((void*)0x311719C0, dataa, 4 * 6);

		char data2[] = { 0x45, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x30, 0x00, 0x00, 0xC4, 0x00, 0x00, 0x00, 0xC3, 0xD0, 0x00, 0x00 };
		write_process((void*)txt2BGSP, data2, 4 * 6);

		char data3[] = { 0x3F, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x43, 0xCC, 0x00, 0x00, 0xC3, 0xC3, 0x00, 0x00 };
		write_process((void*)txtBGSP, data3, 4 * 6);
	}
}

void addSpace(int num)
{
	char* space = " ";
	for (int i = 0; i < num; i++)
	{
		space;
	}
}

int doScroll(int scroll, int max)
{
	scroll = scrollPos;
	if (scroll == max + 1)
	{
		return 1;
	}
	else if (scroll == 0)
	{
		return max;
	}
	else
	{
		return scroll;
	}
}

void setMenuTxt(int num)
{
		menuId = 0x302bf5e8;

	if (num == 1)
	{
		for (int i = 0; i < forceUse; i++)
		{
			PS3::WriteInt32(0x302BF5E8, 0x310A1337 - 1);
		}
		int space, txt, addNum;
		PS3::WriteString(space," ");
		PS3::WriteString(txt, "Crafting");
		PS3::ReadStringzz(addNum, 1);
		if (useInBattle)
		{
			char* txt = "Inventory";
			char* addNum = addSpace(120);
		}
		std::wstring txtLine = txt + addNum + std::wstring::Join(space, subOpts);
		Task::Delay(hudDelay).Wait();
		for (int i = 0; i < forceUse; i++)
		{
			PS3->SetMemory(memRegion + 0x310a1337, Encoding::ASCII->GetBytes(fixText(txtLine)));
		}
	}
	else if (num == 0)
	{
		for (int i = 0; i < forceUse; i++)
		{
			PS3->getExtension()->WriteUInt32(memRegion + menuId, memRegion + menuId + 0x28);
		}
	}
}

void openMenu()
{
	*(char*)ctrlLock = 0x01;
	waitTimer = 40;
	showHud();
	scrollOpt(scrollPos);
	isOpen = true;
}

void hideHud()
{
	txtOfs = txtSP;
	for (int i = 0; i < forceUse; i++)
	{
		DRAW_RECT(memRegion + txtOfs, 0x3F800000, 0x00000000, 0x00000000, 0x3F800000, 0x00000000, 0x00000000);
	}
	for (int i = 0; i < forceUse; i++)
	{
		memRegion + txt2BGSP, 0x3F800000, 0x00000000, 0x00000000, 0x3F800000, 0x00000000, 0x00000000;
		memRegion + txtBGSP, 0x3F800000, 0x00000000, 0x00000000, 0x3F800000, 0x00000000, 0x00000000;
	}
	for (int i = 0; i < forceUse; i++)
	{
		memRegion + txtBgOfs + 0x44, 0x3F800000, 0x3F800000, 0x3F800000, 0x3F800000;
		memRegion + txtBGSP + 0x44, 0x3F800000, 0x3F800000, 0x3F800000, 0x3F800000;
	}
}

int funcTog[1000];
void selectOpt()
{
	int plusOpt = 1;
	if (scrollPos == plusOpt++)
	{
		if (funcTog[scrollPos] == 0)
		{
			funcTog[scrollPos] = 1;
			*(char*)0x001E9C87 == 0x00;
		}
		else if (funcTog[scrollPos] == 1)
		{
			funcTog[scrollPos] = 0;
			*(char*)0x001E9C87 == 0x01;
		}
	}
	else if (scrollPos == plusOpt++)
	{
		if (funcTog[scrollPos] == 0)
		{
			funcTog[scrollPos] = 1;
			*(char*)0x004244A9 == 0x80;
		}
		else if (funcTog[scrollPos] == 1)
		{
			funcTog[scrollPos] = 0;
			*(char*)0x004244A9 == 0x20;
		}
	}
	else if (scrollPos == plusOpt++)
	{
		if (funcTog[scrollPos] == 0)
		{
			funcTog[scrollPos] = 1;
			*(char*)0x0031EB81 == 0x80;
		}
		else if (funcTog[scrollPos] == 1)
		{
			funcTog[scrollPos] = 0;
			*(char*)0x0031EB81 == 0x20;
		}
	}
	waitTimer = 40;
}

void MenuOptions()
{
	for (int element = 0; element < sizeof(temp_subOpts) / sizeof(temp_subOpts[0]); element++)
		subOptss[element] = temp_subOpts[element];
	for (int element = 0; element < sizeof(temp_mainTxt) / sizeof(temp_mainTxt[0]); element++)
		mainTxt[element] = temp_mainTxt[element];
}

void closeMenu()
{
	*(char*)ctrlLock = 0x00;
	isOpen = false;
	hideHud();
}


void closeSub()
{
	if (curSub == 0)
	{
		closeMenu();
	}
	else
	{
		linePos = menuOpts;
		maxSub = 15;
		scrollPos = curSub;
		curSub = 0;
		scrollOpt(scrollPos);
	}
}

void stopMenu()
{
	menuRunning = false;
	scrollPos = 1;
	curSub = 0;
	maxSub = sizeof(mainPos) / sizeof(mainPos[0]);
	linePos = mainPos;
}

void hookedFunc() {
	if (waitTimer > 0) {
		waitTimer--;
		return;
	}

	if (buttons::IsMCButtonPressed(buttons::r1) && buttons::IsMCButtonPressed(buttons::right)) //if (button1.Text == "Stop")
	{
		openMenu();
	}

	if (buttons::IsMCButtonPressed(buttons::up) && buttons::IsMCButtonPressed(buttons::x)) {
		toggleFlyMode();
		waitTimer = 40;
	}
	if (buttons::IsMCButtonPressed(buttons::down) && buttons::IsMCButtonPressed(buttons::x)) {
		toggleInvisibility(&invisibility);//not working online idk why yet
		waitTimer = 40;
	}
	if (isOpen)
	{
		if (!canUse())
		{
			closeMenu();
		}
		if (buttons::IsMCButtonPressed(buttons::left))
		{
			scrollOpt(scrollPos--);
		}
		else if ((buttons::IsMCButtonPressed(buttons::right)))
		{
			scrollOpt(scrollPos++);
		}
		else if ((buttons::IsMCButtonPressed(buttons::square)))
		{
			selectOpt();
		}
		else if ((buttons::IsMCButtonPressed(buttons::o)))
		{
			closeSub();
		}
	}
}

int hook(unsigned int ServerPlayer, unsigned int r4) {
	hookedFunc();
	return call<int>(0x323A74)(ServerPlayer,r4);
}

void startHook() {
	//*(unsigned int*)(0x13D05F8+0x0) = *(unsigned int*)((int)hook+0x0);
	//*(unsigned int*)(0x13D05F8+0x4) = *(unsigned int*)((int)hook+0x4);
	write_process((void*)0x13D05F8,(void*)hook,8);
}

// An exported function is needed to generate the project's PRX stub export library
extern "C" int _ParadiseMC_export_function(void)
{
	//printf("Called Export\n");
	return CELL_OK;
}

sys_ppu_thread_t ThreadModuleID;
void startHook();
void hookedFunc();
void thread(uint64_t nothing) {
	//PatchInJump(0x233424,(int)hook,false);//makes the stuff do
	//printf("\n\nHi there from a plugin\n\n\n");
	//somestringfunctiondata data;;
	//printf("calling the function\n");
	//somestringfunction(&data,"SetHealth");
	//printf("done calling the function\n");
	//debugData((char*)&data,0x100);
	sleep(10000);
	//startHook();
	for (;;) {
		hookedFunc();
		sleep(10);
	}
	sys_ppu_thread_exit(nothing);
}

extern "C" int _ParadiseMC_prx_entry(void)
{


	printf("Ran\n");
	//debugData((unsigned char*)0x22D744,0x114);
	//*(int*)0x22D7D4 = 0x60000000;
	//*(int*)0x22D744 = 0x4e800020;
	//printf("*(int*)0x22D744 = 0x%X\n",*(int*)0x22D744);
	//printf("\n\nYolo m8\n\n\n");
	//printf("0x344810 value at: 0x%X\n\n",*(unsigned int*)0x344810);
	//memcpy(livestatsdetourdata,(void*)0x5432A4,4*4);
	//PatchInJump(0x5432A4,(int)livestatsdetour,false);
	sys_ppu_thread_create(&ThreadModuleID, thread, 0, 0x6AA, 0x3000, 0, "Test001");//this doesn't execute
	Dialog::msgdialog_mode = Dialog::MODE_STRING_OK;
	Dialog::Show("WELCOME TO MINECRAFTSPRX BETA!!!\n\n MADE BY: Dublin Modz \n OPEN MENU: R1 + Dpad Right!\n I Hope You Enjoy!!!! :)\n PLEASE NOTE: This is a beta version. The menu is still in progress. Thanks to GoPro, David1336, TheRoulletteboi, NELUxP, and the biggest thanks to ModdingMayhem. The menu could not have been made without eveyone support. There will be alot added in the future.");
	//for(;;){}
	//sys_ppu_thread_exit(SYS_PRX_RESIDENT);
    return SYS_PRX_RESIDENT;
}
