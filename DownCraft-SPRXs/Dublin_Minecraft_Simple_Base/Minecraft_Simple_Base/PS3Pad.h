#pragma once
#pragma region Includes
//#include <cellstatus.h>
#include <sys/prx.h>
#include <sys/syscall.h>
//#include <netinet/in.h>
//#include <sys/socket.h>
#include <sys/process.h>
//#include <netdb.h>

#pragma endregion
#pragma region Template
template<typename R, typename... Arguments> inline R Call(long long function, Arguments... args) {
	int toc_t[2] = { function, 0x014CDAB0 };
	R(*temp)(Arguments...) = (R(*)(Arguments...))&toc_t;
	return temp(args...);
}
#pragma endregion

//#pragma comment(lib, "net_stub")


//#define CDECL extern "C"


/*bool ButtonPressed(eButtons button)
{
return g_GameVariables->CInput_ButtonPressed(*g_GameVariables->pCInput, 0, button, 0);
}

bool ButtonDown(eButtons button)
{
return g_GameVariables->CInput_ButtonDown(*g_GameVariables->pCInput, 0, button);
}

bool IsButtonBinds(eButtons button1, eButtons button2)
{
return (ButtonPressed(button1) && ButtonDown(button2))
|| (ButtonDown(button1) && ButtonPressed(button2));
}*/

/*double GetLeftJoyStickX()
{
return g_GameVariables->CInput_GetJoyStick_LX(*g_GameVariables->pCInput, 0, 0);
}

double GetLeftJoyStickY()
{
return g_GameVariables->CInput_GetJoyStick_LY(*g_GameVariables->pCInput, 0, 0);
}

double GetRightJoyStickX()
{
return g_GameVariables->CInput_GetJoyStick_RX(*g_GameVariables->pCInput, 0, 0);
}

double GetRightJoyStickY()
{
return g_GameVariables->CInput_GetJoyStick_RY(*g_GameVariables->pCInput, 0, 0);
}

void PlayUISoundBack()
{
g_GameVariables->ConsoleUIController_PlayUISFX(g_GameVariables->ConsoleUIController, *g_GameVariables->pSoundEventBack);
}

void PlayUISoundSelect()
{
g_GameVariables->ConsoleUIController_PlayUISFX(g_GameVariables->ConsoleUIController, *g_GameVariables->pSoundEventPress);
}

void PlayUISoundScroll()
{
g_GameVariables->ConsoleUIController_PlayUISFX(g_GameVariables->ConsoleUIController, *g_GameVariables->pSoundEventScroll);
}*/



//int32_t sys_dbg_read_process_memory(uint64_t address, void* data, size_t size);
//int32_t sys_dbg_write_process_memory(uint64_t address, const void* data, size_t size);
//int32_t sys_dbg_write_process_memory_ps3mapi(uint64_t ea, const void* data, size_t size);
//int32_t sys_dbg_read_process_memory_ps3mapi(uint64_t ea, void* data, size_t size);
//void PatchInJump(uint32_t address, uint32_t destination);
//void HookFunctionStart(uint32_t functionStartAddress, uint32_t newFunction, uint32_t functionStub);
//void UnHookFunctionStart(uint32_t functionStartAddress, uint32_t functionStub);
//int32_t BranchLinkedHook(uint32_t branchFrom, uint32_t branchTo);
//int32_t BranchHook(uint32_t branchFrom, uint32_t branchTo);
//bool bCompare(const unsigned char* pData, const unsigned char* bMask, const char* szMask);
//unsigned long FindPattern(unsigned long dwAddress, unsigned long dwLen, unsigned char* bMask, char* szMask);
//char * removespace(const char * notify);
//char* SendRequest(char* URL, char* Path);
//void Notify(const char * notify);

