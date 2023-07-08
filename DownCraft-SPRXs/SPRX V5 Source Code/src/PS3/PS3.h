#pragma once

extern "C"
{
	int            _sys_printf(const char* format, ...);
	int            _sys_sprintf(char* s, const char* format, ...);

	void* _sys_malloc(size_t n);
	void        _sys_free(void* ptr);
	void* _sys_memchr(void* ptr, int value, size_t num);
	void* _sys_memcpy(void* destination, const void* source, size_t num);
	int            _sys_memcmp(const void* ptr1, const void* ptr2, size_t num);
	void* _sys_memset(void* ptr, int value, size_t num);
	void* _sys_memmove(void* destination, const void* source, size_t num);

	char* _sys_strcat(char* destination, const char* source);
	char* _sys_strchr(char* str, int character);
	int            _sys_strcmp(const char* str1, const char* str2);
	char* _sys_strcpy(char* destination, const char* source);
	size_t        _sys_strlen(const char* str);
	char* _sys_strncat(char* destination, const char* source, size_t num);
	int            _sys_strncmp(const char* str1, const char* str2, size_t num);
	char* _sys_strncpy(char* destination, const char* source, size_t num);
	char* _sys_strrchr(char* str, int character);
	int            _sys_tolower(int c);
	int            _sys_toupper(int c);
}

#include <cellstatus.h>
#include <sys/prx.h>
#include <stdio.h>
#include <stdlib.h>
#include <stdarg.h>
#include <stddef.h>
#include <string.h>
#include <sys/prx.h>
#include <sys/syscall.h>
#include <sys/ppu_thread.h>
#include <sys/sys_time.h>
#include <sys/time_util.h>
#include <sys/process.h>
#include <sys/memory.h>
#include <sys/timer.h>
#include <sys/types.h>
#include <math.h>
#include <fastmath.h>
#include <cellstatus.h>
#include <sys/timer.h>
#include <cell/sysmodule.h>
#include <sys/random_number.h>
#include <ppu_intrinsics.h>
#include <spu_printf.h>
#include <ctype.h>
#include <netinet/in.h>
#include <sys/socket.h>
#include <sys/process.h>
#include <netdb.h>
#include <wchar.h>
#include <sysutil/sysutil_oskdialog.h>
#include <sysutil\sysutil_msgdialog.h>

#define GetPointer(X) *(int*)(X)

typedef unsigned char byte;
typedef unsigned char BYTE;
typedef unsigned char* PBYTE;
typedef void VOID;
typedef void* PVOID;
typedef long long __int64;
typedef unsigned int uint;

#define TOC 0x014CDAB0 //Minecraft 1.84 Update

#pragma region "PS3Lib"
namespace PS3Lib
{
	float ReadSingleFloat(int Address)
	{
		return *(float*)Address;
	}
	float floatArray[100];
	float* ReadFloat(int address, int length)
	{
		for (int i = 0; i < length; i++)
		{
			floatArray[i] = *(float*)(address + (i * 0x04));
		}
		return floatArray;
	}

	char byteArrayz[100];
	char* ReadBytes(int address, int length)
	{
		for (int i = 0; i < length; i++)
		{
			byteArrayz[i] = *(char*)(address + (i));
		}
		return byteArrayz;
	}

	void WriteFloat(int address, float* input, int length)
	{
		for (int i = 0; i < length; i++)
		{
			*(float*)(address + (i * 4)) = input[i];
		}
	}

	void WriteSingleFloat(int Address, float Input)
	{
		*(float*)Address = Input;
	}

	void WriteBytes(int address, char* input, int length)
	{
		for (int i = 0; i < length; i++)
		{
			*(char*)(address + (i)) = input[i];
		}
	}
	void WriteByte(int Address, unsigned char Input)
	{
		*(unsigned char*)Address = Input;
	}
	float intArray[100];
	float* ReadInt(int address, int length)
	{
		for (int i = 0; i < length; i++)
		{
			intArray[i] = *(int*)(address + (i * 0x04));
		}
		return intArray;
	}

	void WriteInt(int address, int* input, int length)
	{
		for (int i = 0; i < length; i++)
		{
			*(int*)(intArray + (i * 0x04)) = input[i];
		}
	}
	void WriteInt32(int Address, int Input)
	{
		*(int*)Address = Input;
	}

	void WriteString(int address, char* string)
	{
		int FreeMem = 0x1D00000;
		int strlength = std::strlen(string);
		*(char**)FreeMem = string;
		char* StrBytes = ReadBytes(*(int*)FreeMem, strlength);
		WriteBytes(address, StrBytes, strlength);
	}

	struct readstr
	{
		char returnRead[100];
	}ReturnRead[1000];
	int strcount;

	char* ReadStringz(int address)
	{
		strcount++;
		memset(&ReturnRead[strcount].returnRead[0], 0, sizeof(ReturnRead[strcount].returnRead));
		int strlength = 100;
		char* StrBytes = ReadBytes(address, strlength);
		for (int i = 0; i < strlength; i++)
		{
			if (StrBytes[i] != 0x00)
				ReturnRead[strcount].returnRead[i] = StrBytes[i];
			else
				break;
		}
		return ReturnRead[strcount].returnRead;
	}
	char byteArray[100];
	char* ReadBytesC(int address, int length)
	{
		for (int i = 0; i < length; i++)
		{
			byteArray[i] = *(char*)(address + (i));
		}
		return byteArray;
	}
	char returnRead[100];
	char* ReadStringC(int address)
	{
		memset(&returnRead[0], 0, sizeof(returnRead));
		int strlength = 100;
		char* StrBytes = ReadBytesC(address, strlength);
		for (int i = 0; i < strlength; i++)
		{
			if (StrBytes[i] != 0x00)
				returnRead[i] = StrBytes[i];
			else
				break;
		}
		return returnRead;
	}
	int ReadInt32(int Address)
	{
		return *(int*)Address;
	}
	char* ReadString(int Address)
	{
		return (char*)Address;
	}
	char returnReadd[100];
	char* ReadStringzz(int address, bool IncludeSpaces) {
		int strlength = 100;
		char* StrBytes = PS3Lib::ReadBytes(address, strlength);

		char StopBytes = 0x00;
		if (!IncludeSpaces)
			StopBytes = 0x20;

		for (int i = 0; i < strlength; i++)
			returnReadd[i] = 0;
		for (int i = 0; i < strlength; i++) {
			if (StrBytes[i] != StopBytes)
				returnReadd[i] = StrBytes[i];
		}
		return returnReadd;
	}
};

#pragma endregion
#pragma region "NyTekCFW Lib"

namespace NyTekCFW
{
	typedef unsigned char byte;
	typedef char* String;
	typedef void* DWORD;
	typedef void* PVOID;
	char byteArrayz[0x10];

	void sleep(usecond_t time)
	{
		sys_timer_usleep(time * 1000);
	}

	char* ReadBytes(int address, int length)
	{
		for (int i = 0; i < length; i++)
		{
			byteArrayz[i] = *(char*)(address + (i));
		}
		return byteArrayz;
	}

	char* ReadString(int Address)
	{
		return (char*)Address;
	}

	void WriteBytes(int address, char* input, int length)
	{
		for (int i = 0; i < length; i++)
		{
			*(char*)(address + (i)) = input[i];
		}
	}

	void WriteString(int off, char* tct)
	{
		int strlength = std::strlen(tct);
		*(char**)off = tct;
		WriteBytes(off, ReadBytes(*(int*)off, strlength), strlength);
		*(byte*)(off + strlength) = 0;
	}

	void Zone(int Offset, float Zoned[])
	{
		*(float*)Offset = Zoned[0];
		*(float*)(Offset + 4) = Zoned[1];
		*(float*)(Offset + 8) = Zoned[2];
	}

	int FloatToHex(float value)
	{
		float f = value;
		int i = *(reinterpret_cast<int*>(&f));
		return i;
	}

	int IntToHex(int value)
	{
		int i = value;
		int result = *(reinterpret_cast<int*>(&i));
		return result;
	}
}

#pragma endregion
#pragma region "Function Call and Memory Read / Write"

template<typename R, typename... Arguments> inline R Call(long long function, Arguments... args)
{
	int toc_t[2] = { function, TOC };
	R(*temp)(Arguments...) = (R(*)(Arguments...)) & toc_t;
	return temp(args...);
}

#define CallFunction(address, return_type, func_name, args) \
	uint32_t func_name##opd[2] = { address, TOC }; \
	using func_name##_t = return_type(*)args; \
	func_name##_t func_name = (func_name##_t)func_name##opd;

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

void WriteMemoryByte(int address, char hex)
{
	*(char*)address = hex;
}

void WriteMemoryBytes2(int address, char hex)
{
	*(short*)address = hex;
}

void WriteMemoryBytes3(int address, char hex)
{
	*(float*)address = hex;
}

void WriteMemoryBytes4(int address, char hex)
{
	*(int*)address = hex;
}

void WriteMemoryBytes8(int address, char hex)
{
	*(double*)address = hex;
}

int console_write(const char* s)
{
	int len = strlen(s);
	system_call_4(SYS_TTY_WRITE, 0, (uint64_t)s, len, (uint64_t)&len);
	return 0;
}

int write_process(uint64_t ea, const void* data, size_t size)
{
	system_call_6(8, 0x7777, 0x32, (uint64_t)sys_process_getpid(), (uint64_t)ea, (uint64_t)data, (uint64_t)size);
	return_to_user_prog(int);
}

int read_process(uint64_t ea, const void* data, size_t size)
{
	system_call_6(8, 0x7777, 0x31, (uint64_t)sys_process_getpid(), (uint64_t)ea, (uint64_t)data, (uint64_t)size);
	return_to_user_prog(int);
}

#pragma endregion
#pragma region "Path and Hook"

int Memcpy(void* destination, const void* source, size_t size)
{
	system_call_4(905, (uint64_t)sys_process_getpid(), (uint64_t)destination, size, (uint64_t)source);
	__dcbst(destination);
	__sync();
	__isync();
	return_to_user_prog(int);
}

void PatchInJump(int Address, int Destination) {
	int FuncBytes[4];
	Destination = *(int*)Destination;
	FuncBytes[0] = 0x3D600000 + ((Destination >> 16) & 0xFFFF);
	if (Destination & 0x8000) FuncBytes[0] += 1;
	FuncBytes[1] = 0x396B0000 + (Destination & 0xFFFF);
	FuncBytes[2] = 0x7D6903A6;
	FuncBytes[3] = 0x4E800420;
	for (int i = 0; i < 4; i++) {
		*(int*)(Address + (i * 4)) = FuncBytes[i];

	}
}

void patcher(int Address, int Destination, bool Linked)
{
	int FuncBytes[4];
	Destination = *(int*)Destination;
	FuncBytes[0] = 0x3D600000 + ((Destination >> 16) & 0xFFFF);
	if (Destination & 0x8000)
		FuncBytes[0] += 1;
	FuncBytes[1] = 0x396B0000 + (Destination & 0xFFFF); // addi    %r11, %r11, dest&0xFFFF
	FuncBytes[2] = 0x7D6903A6; // mtctr    %r11
	FuncBytes[3] = 0x4E800420; // bctr
	if (Linked)
		FuncBytes[3] += 1; // bctrl
	Memcpy((void*)Address, FuncBytes, 4 * 4);
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

#pragma endregion
#pragma region "Functions"

void GetMemoryInfo()
{
	static sys_memory_info stat; size_t* FreeMemory, * UsedMemory; int HeapFree;
	sys_memory_get_user_memory_size(&stat);
	*FreeMemory = stat.available_user_memory;
	*FreeMemory += HeapFree;
	*UsedMemory = stat.total_user_memory - *FreeMemory;
	const size_t RETAIL_SIZE = 213 * 1024 * 1024;
	if (stat.total_user_memory > RETAIL_SIZE)
	{
		*FreeMemory -= stat.total_user_memory - RETAIL_SIZE;
	}
	else
	{
		*FreeMemory = 0;
		*UsedMemory = 0;
	}
	return;
}

void sleep(usecond_t time)
{
	sys_timer_usleep(time * 1000);
}

void get_temperature(uint32_t a, uint32_t* b)
{
	system_call_2(383, (uint64_t)(uint32_t)a, (uint64_t)(uint32_t)b);
}

#pragma endregion
#pragma region "Send Request"

namespace HTTP
{
	char* removespace(const char* notify)
	{
		char buffer[0x500];
		_sys_strcat(buffer, notify);
		for (int i = 0; i < 0x500; i++)
		{
			if (buffer[i] == ' ')
			{
				buffer[i] = '+';
			}
		}
		return buffer;
	}

	char* LocalRequest(char* Path)
	{
		struct sockaddr_in SocketAddress;
		char bufferReturn[500];
		char RequestBuffer[1000];
		memset(RequestBuffer, 0x00, 1000);
		SocketAddress.sin_addr.s_addr = 0x7F000001; //127.0.0.1 (localhost)
		SocketAddress.sin_family = AF_INET;
		SocketAddress.sin_port = htons(80); //http port (80)
		int Socket = socket(AF_INET, SOCK_STREAM, 0);
		if (connect(Socket, (struct sockaddr*)&SocketAddress, sizeof(SocketAddress)) != 0)
		{
			return "";
		}
		_sys_strcat(RequestBuffer, "GET /");
		_sys_strcat(RequestBuffer, Path);
		_sys_strcat(RequestBuffer, "\r\nConnection: close\r\n\r\n");

		send(Socket, RequestBuffer, _sys_strlen(RequestBuffer), 0);
		while (recv(Socket, bufferReturn, 500, 0) > 0)
		{
			return bufferReturn;
		}
		socketclose(Socket);
	}

	void SendLocalRequest(const char* cmd)
	{
		char buffer[0x200];
		_sys_snprintf(buffer, 0x200, cmd, "");
		_sys_printf("%s\n", buffer);
		LocalRequest(buffer);
	}

	///////////////////////////////////////////////

	char* URLRequest(char* URL, char* Path)
	{
		struct sockaddr_in SocketAddress;
		char bufferReturn[500];
		char RequestBuffer[1000];
		memset(RequestBuffer, 0x00, 1000);
		SocketAddress.sin_addr.s_addr = *((unsigned long*)gethostbyname(URL)->h_addr);
		SocketAddress.sin_family = AF_INET;
		SocketAddress.sin_port = htons(80);
		int Socket = socket(AF_INET, SOCK_STREAM, 0);
		if (connect(Socket, (struct sockaddr*)&SocketAddress, sizeof(SocketAddress)) != 0)
		{
			return "";
		}
		_sys_strcat(RequestBuffer, "GET /");
		_sys_strcat(RequestBuffer, Path);
		_sys_strcat(RequestBuffer, "\r\nConnection: close\r\n\r\n");

		send(Socket, RequestBuffer, _sys_strlen(RequestBuffer), 0);
		while (recv(Socket, bufferReturn, 500, 0) > 0)
		{
			return bufferReturn;
		}
		socketclose(Socket);
	}

	void SendURLRequest(char* URL, const char* cmd)
	{
		char buffer[0x200];
		_sys_snprintf(buffer, 0x200, cmd, "");
		_sys_printf("%s\n", buffer);
		URLRequest(URL, buffer);
	}
}

#pragma endregion