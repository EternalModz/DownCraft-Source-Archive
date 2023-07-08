#pragma once
#include <cellstatus.h>
#include <sys/prx.h>
#include <sys/syscall.h>
#include <netinet/in.h>
#include <sys/socket.h>
#include <sys/process.h>
#include <netdb.h>


typedef struct SceNpBasicPresenceDetails2 {
	size_t struct_size;
	int state;
	char title[128];
	char status[192];
	char comment[64];
	uint8_t data[128];
	size_t size;
} SceNpBasicPresenceDetails2;

#pragma comment(lib, "net_stub")

#include "mc_classes.h"
#include "mc_funcs.h"

#define CDECL extern "C"
CDECL void* _sys_malloc(size_t size);
#define malloc _sys_malloc
CDECL void _sys_free(void* ptr);
#define free _sys_free
CDECL void* _sys_memalign(size_t boundary, size_t size);
#define memalign _sys_memalign
CDECL void* _sys_memchr(const void* s, int c, size_t n);
#define memchr _sys_memchr
CDECL int _sys_memcmp(const void* s1, const void* s2, size_t n);
#define memcmp _sys_memcmp
CDECL void* _sys_memcpy(void* dest, const void* src, size_t n);
#define memcpy _sys_memcpy
CDECL void* _sys_memset(void* m, int c, size_t n);
#define memset _sys_memset
CDECL void* _sys_memmove(void* str1, const void* str2, size_t n);
#define memmove _sys_memmove
CDECL int _sys_printf(const char* fmt, ...);
#define printf _sys_printf
CDECL int _sys_snprintf(char* buffer, size_t len, const char* fmt, ...);
#define snprintf _sys_snprintf
CDECL int _sys_sprintf(char* buffer, const char* fmt, ...);
#define sprintf _sys_sprintf
CDECL char* _sys_strcat(char* dest, const char* src);
#define strcat _sys_strcat
CDECL char* _sys_strchr(const char* s, int c);
#define strchr _sys_strchr
CDECL int _sys_strcmp(const char* s1, const char* s2);
#define strcmp _sys_strcmp
CDECL char* _sys_strcpy(char* dest, const char* src);
#define strcpy _sys_strcpy
CDECL size_t _sys_strlen(const char* str);
#define strlen _sys_strlen
CDECL int _sys_strncasecmp(const char* s1, const char* s2, size_t n);
#define strncasecmp _sys_strncasecmp
CDECL char* _sys_strncat(char* dest, const char* src, size_t n);
#define strncat _sys_strncat
CDECL int _sys_strncmp(const char* s1, const char* s2, size_t n);
#define strncmp _sys_strncmp
CDECL char* _sys_strncpy(char* dest, const char* src, size_t n);
#define strncpy _sys_strncpy
CDECL char* _sys_strrchr(const char* s, int c);
#define strrchr _sys_strrchr
CDECL int _sys_tolower(int c);
#define tolower _sys_tolower
CDECL int _sys_toupper(int c);
#define toupper _sys_toupper

#include "mc_funcs.h"

void drawRect(float x, float y, float w, float h, Color color);
void drawLine(const float * start, const float * end);

int32_t sys_dbg_read_process_memory(uint64_t address, void* data, size_t size);
int32_t sys_dbg_write_process_memory(uint64_t address, const void* data, size_t size);
int32_t sys_dbg_write_process_memory_ps3mapi(uint64_t ea, const void* data, size_t size);
int32_t sys_dbg_read_process_memory_ps3mapi(uint64_t ea, void* data, size_t size);
void PatchInJump(uint32_t address, uint32_t destination);
void HookFunctionStart(uint32_t functionStartAddress, uint32_t newFunction, uint32_t functionStub);
void UnHookFunctionStart(uint32_t functionStartAddress, uint32_t functionStub);
int32_t BranchLinkedHook(uint32_t branchFrom, uint32_t branchTo);
int32_t BranchHook(uint32_t branchFrom, uint32_t branchTo);
bool bCompare(const unsigned char* pData, const unsigned char* bMask, const char* szMask);
unsigned long FindPattern(unsigned long dwAddress, unsigned long dwLen, unsigned char* bMask, char* szMask);

char * removespace(const char * notify);
char* SendRequest(char* URL, char* Path);
void Notify(const char * notify);
