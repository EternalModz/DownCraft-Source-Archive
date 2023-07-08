#pragma region Includes
#include <sys/syscall.h>
#include <stdarg.h>
#include <sys/syscall.h>
#include <sys/timer.h>
#include "PS3Pad.h"
//#include <string.h>

#pragma endregion

#pragma region Extern
extern "C"
{
	#define printf _sys_printf
	#define malloc _sys_malloc
	#define memalign _sys_memalign
	#define free _sys_free
	#define wcslen _sys_wcslen
	#define wmemcpy _sys_wmemcpy
	//#define sprintf _sys_sprintf

	//int			   _sys_printf(const char* fmt, ...);

	//int            _sys_printf(const char* format, ...);
	//int            _sys_sprintf(char* s, const char* format, ...);
	//int            _sys_snprintf(char * s, size_t n, const char * format, ...);
	//int            _sys_vprintf(const char * format, va_list arg);
	//int            _sys_vsprintf(char * s, const char * format, va_list arg);

	size_t		_sys_wcslen(const wchar_t * wcs);
	void*        _sys_malloc(size_t n);
	void        _sys_free(void* ptr);
	void*        _sys_memchr(void * ptr, int value, size_t num);
	void*        _sys_memcpy(void * destination, const void * source, size_t num);
	int            _sys_memcmp(const void * ptr1, const void * ptr2, size_t num);
	void*        _sys_memset(void * ptr, int value, size_t num);
	void*        _sys_memmove(void * destination, const void * source, size_t num);
	wchar_t*	 _sys_wmemove(wchar_t* destination, const wchar_t* source, size_t num);
	wchar_t*	 _sys_wmemcpy(wchar_t* destination, const wchar_t* source, size_t num);

	char*        _sys_strcat(char * destination, const char * source);
	char*        _sys_strchr(char * str, int character);
	int            _sys_strcmp(const char * str1, const char * str2);
	char*        _sys_strcpy(char * destination, const char * source);
	size_t        _sys_strlen(const char * str);
	char*        _sys_strncat(char * destination, const char * source, size_t num);
	int            _sys_strncmp(const char * str1, const char * str2, size_t num);
	char*        _sys_strncpy(char * destination, const char * source, size_t num);
	char*        _sys_strrchr(char * str, int character);
	int            _sys_tolower(int c);
	int            _sys_toupper(int c);
	//int			 _sys_sprintf(char* buffer, const char* format, ...);
	void*		_sys_malloc(size_t size);
	void*		_sys_memalign(size_t boundary, size_t size);
	void		_sys_free(void* ptr);



};
#pragma endregion */

#pragma region Definitions

unsigned int buttonMonitoring = 0x3000CF79; //Button Monitoring for Minecraft 1.84

#pragma endregion




void sys_sleep(uint64_t milliseconds)
{
	sys_timer_usleep(milliseconds * 1000);
}
void sleep(usecond_t time) {
	sys_timer_usleep(time * 1000);
}

unsigned int getMCButtons()
{
	return *(unsigned int*)(buttonMonitoring);
}

bool isMCButtonPressed(unsigned int Buttons)
{
	return (getMCButtons() & Buttons) > 0;
}

int32_t write_process(uint64_t ea, const void* data, size_t size)
{
	system_call_6(8, 0x7777, 0x32, (uint64_t)sys_process_getpid(), (uint64_t)ea, (uint64_t)data, (uint64_t)size);
	return_to_user_prog(int);
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