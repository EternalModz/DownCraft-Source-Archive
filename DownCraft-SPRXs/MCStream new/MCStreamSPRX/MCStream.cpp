#include "MCStream.h"

SYS_MODULE_INFO( MCStreamSPRX, 0, 1, 1);
SYS_MODULE_START( _MCStreamSPRX_prx_entry );
SYS_MODULE_STOP( _MCStreamSPRX_prx_exit );



bool sub_140A78C(uint32_t localPlayerPtr) {
	mc = (TheMinecraft*)(0x014CF2E4);

	printf("sub_140A78C got called\n", localPlayerPtr);
	return true;
}

bool RenderSmallPlayer(uint32_t localPlayerPtr) {
	mc = (TheMinecraft*)(0x014CF2E4);
	
	if (mc->theMinecraft->cMultiplayerLocalPlayer->isInWater()) {
		printf("i am in the water haha\n");
	}

	//printf("sub_140A778 got called\n");
	return false;
}

bool sub_140A5B4(uint32_t localPlayerPtr) {
	mc = (TheMinecraft*)(0x014CF2E4);
	
	printf("sub_140A5B4 got called\n");
	return false;
}

MultiPlayerLevel * getEntityWorld(MultiplayerLocalPlayer * localPlayerPtr) {
	mc = (TheMinecraft*)(0x014CF2E4);
	
	printf("localPlayerPtr: 0x%X - worldPtr:0x%X\n", localPlayerPtr, *(uint32_t*)(localPlayerPtr + 0xF8));
	return localPlayerPtr->pWorld;
}

bool isInWater(uint32_t localPlayerPtr) {
	//printf("localPlayerPtr: 0x%X\n", localPlayerPtr);
	mc = (TheMinecraft*)(0x014CF2E4);
	
	return *(char*)(localPlayerPtr + 0x1EC);
}


void EPMPFrostWalk(MultiplayerLocalPlayer * r3, uint32_t r4) {
	mc = (TheMinecraft*)(0x014CF2E4);
	if (!r3->IsSpectator()) {
		ELBFrostWalk((uint32_t)r3, r4);
		printf("frostwalker getting called\n");
	}
}

void onEntityUpdate_Hook(uint32_t r3) {//function that is called to update entities
	onEntityUpdate(r3);
	mc = (TheMinecraft*)(0x014CF2E4);

	//theMinecraft->cMultiplayerLocalPlayer->motionY = 0.0f;
	//printf("%x %x\n", theMinecraft->cMultiplayerLocalPlayer->pWorld, theMinecraft->cMultiplayerLocalPlayer->pWorld1);
	
	if (mc->theMinecraft) {
		if (mc->theMinecraft->cMultiplayerLocalPlayer) {
			//theMinecraft->cMultiplayerLocalPlayer->onGround = 1;
			//theMinecraft->cMultiplayerLocalPlayer->isCollidedHorizontally = 0;
			//theMinecraft->cMultiplayerLocalPlayer->isCollidedVertically = 1;
			//theMinecraft->cMultiplayerLocalPlayer->isCollided = 1;
			//printf("0x%X\n", theMinecraft->cMultiplayerLocalPlayer);
			//theMinecraft->cMultiplayerLocalPlayer->sliding = 1;
			//printf("%X\n", theMinecraft->cMultiplayerLocalPlayer->AttributeMap);
			//printf("%i %i %i\n", theMinecraft->cMultiplayerLocalPlayer->chunkCoordX, theMinecraft->cMultiplayerLocalPlayer->chunkCoordY, theMinecraft->cMultiplayerLocalPlayer->chunkCoordZ);
			//printf("0x%X\n", sizeof(MultiplayerLocalPlayer));
		}

		if (mc->theMinecraft->cMultiPlayerLevel) {
			//printf("0x%X\n", theMinecraft->cMultiPlayerLevel);
		}

	}
	//printf("hooked\n");
}

void sub_C6DA60_Stub(uint32_t r3, uint32_t r4, float * r5, uint32_t r6, uint32_t r7, uint32_t r8, uint32_t r9) {
	__nop(); __nop(); __nop(); __nop(); __nop();
}

void sub_C6DA60_Hook(uint32_t r3, uint32_t r4, float * r5, uint32_t r6, uint32_t r7, uint32_t r8, uint32_t r9) {
	mc = (TheMinecraft*)(0x014CF2E4);
	//printf("0x%X 0x%X 0x%X %i %i %i %i\n", r3, r4, r5, r6, r7, r8, r9);
	//r5[0] = 0.0f;
	//r5[1] = 0.0f;
	//r5[2] = -0.1f;
	//r5[3] = 0.0f;
	//r5[4] = 0.1f;
	//r5[5] = 1.0f;
	//r5[6] = 0.0f;
	//r5[7] = 0.1f; //does starwars text
	//r5[8] = 1.0f; //moved shaders left
	//r5[9] = 1.0f; //moved shaders down

	///r5[0] = 1.0f;
	///r5[1] = 0.5f;
	///r5[2] = 1.0f;
	///r5[3] = 1.0f;
	///r5[4] = 1.0f;
	///r5[5] = 1.0f;
	///r5[6] = 1.0f;
	///r5[7] = 1.0f; //does starwars text
	///r5[8] = 1.0f; //moved shaders left
	///r5[9] = 1.0f; //moved shaders down
	//r6 = 20;
	//r7 = 20;
	//r8 = 20;
	//r9 = 20;

	sub_C6DA60_Stub(r3, r4, r5, r6, r7, r8, r9);
}


void RenderScreen_Stub(uint32_t r3, uint32_t r4) {
	__nop(); __nop(); __nop(); __nop(); __nop();
}
void RenderScreen_Hook(uint32_t r3, uint32_t r4) {
	mc = (TheMinecraft*)(0x014CF2E4);
	viewMatrix = (ViewMatrix*)(0x01578E70);
	RenderScreen_Stub(r3, r4);
	viscount = 0;

	

	char option[0x100];
	wchar_t woption[0x100];
	memset(option, 0, 0x100);
	memset(woption, 0, 0x200);
	snprintf(option, 0x100, "Self Pos: (%i, %i, %i)", (int)mc->theMinecraft->cMultiplayerLocalPlayer->posX, (int)mc->theMinecraft->cMultiplayerLocalPlayer->posY + 1, (int)mc->theMinecraft->cMultiplayerLocalPlayer->posZ);
	StringToWideCharacter(woption, option, strlen(option));
	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(woption), 20, 60 + (viscount * 10), 0xFFFFFFFF, 0, 1);
	viscount += 1;

	char option1[0x100];
	wchar_t woption1[0x100];
	memset(option1, 0, 0x100);
	memset(woption1, 0, 0x200);
	snprintf(option1, 0x100, "Current Chunk: (%i, %i, %i)", (int)mc->theMinecraft->cMultiplayerLocalPlayer->chunkCoordX + 1, (int)mc->theMinecraft->cMultiplayerLocalPlayer->chunkCoordY + 1, (int)mc->theMinecraft->cMultiplayerLocalPlayer->chunkCoordZ + 1);
	StringToWideCharacter(woption1, option1, strlen(option1));
	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(woption1), 20, 60 + (viscount * 10), 0xFFFFFFFF, 0, 1);
	viscount += 1;
	
	char option2[0x100];
	wchar_t woption2[0x100];
	memset(option2, 0, 0x100);
	memset(woption2, 0, 0x200);
	snprintf(option2, 0x100, "Resolution: %ix%i", mc->theMinecraft->displayWidth, mc->theMinecraft->displayHeight);
	StringToWideCharacter(woption2, option2, strlen(option2));
	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(woption2), 20, 60 + (viscount * 10), 0xFFFFFFFF, 0, 1);
	viscount += 1;

	char option3[0x100];
	wchar_t woption3[0x100];
	memset(option3, 0, 0x100);
	memset(woption3, 0, 0x200);
	snprintf(option3, 0x100, "Gametime: %i", mc->gameTime);
	StringToWideCharacter(woption3, option3, strlen(option3));
	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(woption3), 20, 60 + (viscount * 10), 0xFFFFFFFF, 0, 1);
	viscount += 1;

	

	char option4[0x100];
	wchar_t woption4[0x100];
	memset(option4, 0, 0x100);
	memset(woption4, 0, 0x200);
	snprintf(option4, 0x100, "FPS: %i", (mc->fps));
	StringToWideCharacter(woption4, option4, strlen(option4));
	drawShadowText(mc->theMinecraft->fontRenderer, (uint32_t)&getString(woption4), 20, 60 + (viscount * 10), 0xFFFFFFFF, 0, 1);
	viscount += 1;
	//printf("0x%X\n", sizeof(TheMinecraft));
	drawRect(25, 25, 50, 50, Color(0, 0, 0, 4));

	printf("0x%X\n", mc->theMinecraft->cLevelRenderer);

	float start[3] = { mc->theMinecraft->cMultiplayerLocalPlayer->LocationX, mc->theMinecraft->cMultiplayerLocalPlayer->LocationY, mc->theMinecraft->cMultiplayerLocalPlayer->LocationZ };
	float null_vec[3] = { 0, 0, 0 };
	drawLine(start, null_vec);

	//Tesselator_Color(pTesselator, 0);
	//Tesselator_Vertex(pTesselator, 0, 0, 0);
	//Tesselator_Vertex(pTesselator, 1000, 1000, 1000);
}

void drawRect(float x, float y, float w, float h, Color color) {
	uint32_t pTesselator = ReadTesselatorInstance(Tesselator_GetInstance());
	Tesselator_Begin(pTesselator);
	Tesselator_EndVertex(pTesselator, x, h + y, 0, color);
	Tesselator_EndVertex(pTesselator, w + x, h + y, 0, color);
	Tesselator_EndVertex(pTesselator, w + x, y, 0, color);
	Tesselator_EndVertex(pTesselator, x, y, 0, color);
	Tesselator_End(pTesselator);
}

void drawLine(const float * start, const float * end) {
	//float startl[3] = { start[0] - mc->theMinecraft->cLevelRenderer->location[0], start[1] - mc->theMinecraft->cLevelRenderer->location[1], start[2] - mc->theMinecraft->cLevelRenderer->location[2] };
	//float endl[3] = { end[0] - mc->theMinecraft->cLevelRenderer->location[0], end[1] - mc->theMinecraft->cLevelRenderer->location[1], end[2] - mc->theMinecraft->cLevelRenderer->location[2] };
	//float startl[3] = { start[0] - mc->theMinecraft->cMultiplayerLocalPlayer->LocationX, start[1] - mc->theMinecraft->cMultiplayerLocalPlayer->LocationY, start[2] - mc->theMinecraft->cMultiplayerLocalPlayer->LocationZ };
	//float endl[3] = { end[0] - mc->theMinecraft->cMultiplayerLocalPlayer->LocationX, end[1] - mc->theMinecraft->cMultiplayerLocalPlayer->LocationY, end[2] - mc->theMinecraft->cMultiplayerLocalPlayer->LocationZ };

	uint32_t pTesselator = ReadTesselatorInstance(Tesselator_GetInstance());
	Tesselator_Begin(pTesselator, 4);
	Tesselator_EndVertex(pTesselator, start[0], start[1], start[2], Color(255, 255, 255, 255));
	Tesselator_EndVertex(pTesselator, end[0], end[1], end[2], Color(255, 255, 255, 255));
	Tesselator_End(pTesselator);
}

int sceNpBasicSetPresenceDetails2_Stub(SceNpBasicPresenceDetails2 *pres, uint32_t options) {
	__nop(); __nop(); __nop(); __nop(); __nop();
}
int sceNpBasicSetPresenceDetails2_Hook(SceNpBasicPresenceDetails2 *pres, uint32_t options) {
	//printf("%i %s %s %s %s %i\n", pres->struct_size, pres->state, pres->title, pres->status, pres->comment, pres->data, pres->size);
	//strcpy(pres->status, "testing status");
	//strcpy(pres->comment, "testing comment");
	//strcpy(pres->title, "testing title");

	return sceNpBasicSetPresenceDetails2_Stub(pres, options);
}
//01084270


extern "C" int _MCStreamSPRX_prx_entry(void) {
	mc = (TheMinecraft*)(0x014CF2E4);
	//EntityPlaySound((uint32_t)theMinecraft->cMultiplayerLocalPlayer, *(uint32_t*)(0x014CA090), 1.0f, 2.0f);
	//printf("MultiplayerLocalPlayer: 0x%X 0x%X 0x%X\n", theMinecraft->cMultiplayerLocalPlayer, theMinecraft->cMultiplayerLocalPlayer->cWorld, theMinecraft->cMultiplayerLocalPlayer2->getEntityWorld());

	//uint32_t vtabledumper = 0x0140A1C0;
	//while (*(uint32_t*)(vtabledumper)) {
	//
	//	printf("virtual void func_%X(); //index %i\n", *(uint32_t*)(vtabledumper), (vtabledumper - 0x0140A1C0) / 4);
	//
	//	vtabledumper += 4;
	//}

	*(uint32_t*)(0x0140A78C) = (uint32_t)(sub_140A78C);
	*(uint32_t*)(0x0140A778) = (uint32_t)(RenderSmallPlayer);
	*(uint32_t*)(0x0140A5B4) = (uint32_t)(sub_140A5B4);

	*(uint32_t*)(0x0140A37C) = (uint32_t)(getEntityWorld); //getEntityWorld vtable hook

	*(uint32_t*)(0x0140A430) = (uint32_t)(isInWater); //isInWater vtable hook
	*(uint32_t*)(0x0140A774) = (uint32_t)(EPMPFrostWalk); //frostwalk vtable hook

	*(uint32_t*)(0x0140A3B8) = (uint32_t)(onEntityUpdate_Hook);

	HookFunctionStart(0x00A89068, *(uint32_t*)(RenderScreen_Hook), *(uint32_t*)(RenderScreen_Stub));
	HookFunctionStart(0x00C6DA60, *(uint32_t*)(sub_C6DA60_Hook), *(uint32_t*)(sub_C6DA60_Stub));
	HookFunctionStart(0x01084270, *(uint32_t*)(sceNpBasicSetPresenceDetails2_Hook), *(uint32_t*)(sceNpBasicSetPresenceDetails2_Stub));

	return SYS_PRX_RESIDENT;
}

extern "C" int _MCStreamSPRX_prx_exit(void) {
	*(uint32_t*)(0x0140A78C) = (uint32_t)(0x014A69C0);
	*(uint32_t*)(0x0140A778) = (uint32_t)(0x014A1C20);
	*(uint32_t*)(0x0140A5B4) = (uint32_t)(0x0149BB50);

	*(uint32_t*)(0x0140A37C) = (uint32_t)(0x0149BD20);
	*(uint32_t*)(0x0140A430) = (uint32_t)(0x0149B860);
	*(uint32_t*)(0x0140A774) = (uint32_t)(0x014A6760); //frostwalk vtable hook

	*(uint32_t*)(0x0140A3B8) = (uint32_t)(0x014A1C10);

	UnHookFunctionStart(0x00A89068, *(uint32_t*)(RenderScreen_Stub));
	UnHookFunctionStart(0x00C6DA60, *(uint32_t*)(sub_C6DA60_Stub));
	UnHookFunctionStart(0x01084270, *(uint32_t*)(sceNpBasicSetPresenceDetails2_Stub));

	return SYS_PRX_RESIDENT;
}


int32_t sys_dbg_read_process_memory(uint64_t address, void* data, size_t size)
{
	system_call_4(904, (uint64_t)sys_process_getpid(), address, size, (uint64_t)data);
	return_to_user_prog(int32_t);
}
int32_t sys_dbg_write_process_memory(uint64_t address, const void* data, size_t size)
{
	system_call_4(905, (uint64_t)sys_process_getpid(), address, size, (uint64_t)data);
	return_to_user_prog(int32_t);
}
int32_t sys_dbg_write_process_memory_ps3mapi(uint64_t ea, const void* data, size_t size)
{
	system_call_6(8, 0x7777, 0x32, (uint64_t)sys_process_getpid(), (uint64_t)ea, (uint64_t)data, (uint64_t)size);
	return_to_user_prog(int32_t);
}
int32_t sys_dbg_read_process_memory_ps3mapi(uint64_t ea, void* data, size_t size)
{
	system_call_6(8, 0x7777, 0x31, (uint64_t)sys_process_getpid(), (uint64_t)ea, (uint64_t)data, (uint64_t)size);
	return_to_user_prog(int32_t);
}
void PatchInJump(uint32_t address, uint32_t destination) {
	int FuncBytes[4];
	FuncBytes[0] = 0x3D600000 + ((destination >> 16) & 0xFFFF);
	if (destination & 0x8000) FuncBytes[0] += 1;
	FuncBytes[1] = 0x396B0000 + (destination & 0xFFFF);
	FuncBytes[2] = 0x7D6903A6;
	FuncBytes[3] = 0x4E800420;
	for (int i = 0; i < 4; i++) {
		*(int*)(address + (i * 4)) = FuncBytes[i];
	}
}
void HookFunctionStart(uint32_t functionStartAddress, uint32_t newFunction, uint32_t functionStub) {
	uint32_t normalFunctionStub[8], hookFunctionStub[4];
	sys_dbg_read_process_memory_ps3mapi(functionStartAddress, normalFunctionStub, 0x10);
	sys_dbg_read_process_memory(functionStartAddress, normalFunctionStub, 0x10);
	normalFunctionStub[4] = 0x3D600000 + ((functionStartAddress + 0x10 >> 16) & 0xFFFF);
	normalFunctionStub[5] = 0x616B0000 + (functionStartAddress + 0x10 & 0xFFFF);
	normalFunctionStub[6] = 0x7D6903A6;
	normalFunctionStub[7] = 0x4E800420;
	sys_dbg_write_process_memory_ps3mapi(functionStub, normalFunctionStub, 0x20);
	sys_dbg_write_process_memory(functionStub, normalFunctionStub, 0x20);
	hookFunctionStub[0] = 0x3D600000 + ((newFunction >> 16) & 0xFFFF);
	hookFunctionStub[1] = 0x616B0000 + (newFunction & 0xFFFF);
	hookFunctionStub[2] = 0x7D6903A6;
	hookFunctionStub[3] = 0x4E800420;
	sys_dbg_write_process_memory_ps3mapi(functionStartAddress, hookFunctionStub, 0x10);
	sys_dbg_write_process_memory(functionStartAddress, hookFunctionStub, 0x10);
}
void UnHookFunctionStart(uint32_t functionStartAddress, uint32_t functionStub) {
	uint32_t normalFunctionStub[4];
	sys_dbg_read_process_memory(functionStub, normalFunctionStub, 0x10);
	sys_dbg_write_process_memory(functionStartAddress, normalFunctionStub, 0x10);

	sys_dbg_read_process_memory_ps3mapi(functionStub, normalFunctionStub, 0x10);
	sys_dbg_write_process_memory_ps3mapi(functionStartAddress, normalFunctionStub, 0x10);
}
int32_t BranchLinkedHook(uint32_t branchFrom, uint32_t branchTo)
{
	uint32_t branch;
	if (branchTo > branchFrom)
		branch = 0x48000001 + (branchTo - branchFrom);
	else
		branch = 0x4C000001 - (branchFrom - branchTo);
	return sys_dbg_write_process_memory_ps3mapi(branchFrom, &branch, 4);
}
int32_t BranchHook(uint32_t branchFrom, uint32_t branchTo)
{
	uint32_t branch;
	if (branchTo > branchFrom)
		branch = 0x48000000 + (branchTo - branchFrom);
	else
		branch = 0x4C000000 - (branchFrom - branchTo);
	return sys_dbg_write_process_memory_ps3mapi(branchFrom, &branch, 4);
}
bool bCompare(const unsigned char* pData, const unsigned char* bMask, const char* szMask)
{
	for (; *szMask; ++szMask, ++pData, ++bMask)
	if (*szMask == 'x' && *pData != *bMask)
		return false;

	return (*szMask) == 0;
}
unsigned long FindPattern(unsigned long dwAddress, unsigned long dwLen, unsigned char* bMask, char* szMask)
{
	for (unsigned long i = 0; i < dwLen; i++)
	if (bCompare((unsigned char*)(dwAddress + i), bMask, szMask))
		return (unsigned long)(dwAddress + i);

	return 0;
}


char * removespace(const char * notify) {
	char buffer[0x500];
	strcat(buffer, notify);
	for (int i = 0; i < 0x500; i++) {
		if (buffer[i] == ' ') {
			buffer[i] = '+';
		}
	}
	return buffer;
}
char* SendRequest(char* URL, char* Path) {
	struct sockaddr_in SocketAddress;
	char bufferReturn[500];
	char RequestBuffer[1000];
	memset(RequestBuffer, 0x00, 1000);
	SocketAddress.sin_addr.s_addr = *((unsigned long*)gethostbyname(URL)->h_addr);
	SocketAddress.sin_family = AF_INET;
	SocketAddress.sin_port = htons(80);
	int Socket = socket(AF_INET, SOCK_STREAM, 0);
	if (connect(Socket, (struct sockaddr *)&SocketAddress, sizeof(SocketAddress)) != 0) {
		return "";
	}
	strcat(RequestBuffer, "GET /");
	strcat(RequestBuffer, Path);
	strcat(RequestBuffer, "\r\nConnection: close\r\n\r\n");

	send(Socket, RequestBuffer, strlen(RequestBuffer), 0);
	while (recv(Socket, bufferReturn, 500, 0) > 0){
		return bufferReturn;
	}
	socketclose(Socket);
}
void Notify(const char * notify) {
	char buffer[0x200];
	snprintf(buffer, 0x200, "notify.ps3mapi?msg=%s", notify);
	printf("%s\n", buffer);
	SendRequest("127.0.0.1", buffer);
}
