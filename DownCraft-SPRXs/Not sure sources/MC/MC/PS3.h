#pragma once

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

#define GetPointer(X) *(int*)(X)

typedef unsigned char byte;
typedef unsigned char BYTE;
typedef unsigned char* PBYTE;
typedef void VOID;
typedef void* PVOID;
typedef long long __int64;
typedef unsigned int uint;

//PS3:
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

//Console Commands
void sleep(usecond_t time) {
	sys_timer_usleep(time * 1000);
}
int console_write(const char * s) {
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

//Hook Functions
int Memcpy(void* destination, const void* source, size_t size)
{
	system_call_4(905, (uint64_t)sys_process_getpid(), (uint64_t)destination, size, (uint64_t)source);
	__dcbst(destination);
	__sync();
	__isync();
	return_to_user_prog(int);
}
void PatchInJump(int Address, int Destination){
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
	Destination = *(int *)Destination;
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
void hookFunctionStart(int Address, int saveStub, int Destination){ //Works on every game
	int BranchtoAddress = Address + (4 * 4);
	int StubData[8];
	StubData[0] = 0x3D600000 + ((BranchtoAddress >> 16) & 0xFFFF);
	if (BranchtoAddress & 0x8000) StubData[0] += 1;
	StubData[1] = 0x396B0000 + (BranchtoAddress & 0xFFFF);
	StubData[2] = 0x7D6903A6;
	std::memcpy(&StubData[3], (void*)Address, 4 * 4);
	StubData[7] = 0x4E800420;
	PatchInJump(Address, Destination);

}
void Menu_PaintAll_Stub(int a, int b){
	__asm("li %r3, 0x3");
}

//Create Thread
sys_ppu_thread_t id;
sys_ppu_thread_t create_thread(void(*entry)(uint64_t), int priority, size_t stacksize, const char* threadname)
{
	if (sys_ppu_thread_create(&id, entry, 0, priority, stacksize, 0, threadname) != CELL_OK)
	{
		console_write("Thread creation failed\n");
	}
	else
	{
		console_write("Thread created\n");
	}
	return id;
}
void setMemory(int address = 0, int client = 0, bool* toggle = NULL, int enable = 0, int disable = 0)
{
	*(int*)address = toggle[client] ? enable : disable;
}
//Sprintf
void reverse(char s[])
{
	int i, j;
	char c;
	for (i = 0, j = strlen(s) - 1; i<j; i++, j--)
	{
		c = s[i];
		s[i] = s[j];
		s[j] = c;
	}
}
void itoa(int n, char s[])
{
	int i, sign;
	if ((sign = n) < 0)  /* record sign */
		n = -n;          /* make n positive */
	i = 0;
	do  		/* generate digits in reverse order */
	{
		s[i++] = n % 10 + '0';	/* get next digit */
	} while ((n /= 10) > 0);	/* delete it */
	if (sign < 0)
		s[i++] = '-';
	s[i] = '\0';
	reverse(s);
}
int atoi(char* str)
{
	int val = 0;
	while (*str)
	{
		val = val * 10 + (*str++ - '0');
	}
	return val;
}
bool isdigit(char Num) {
	return (Num >= 0x30 && Num <= 0x39);
}
int VSprintf(char *ptr, const char *fmt, va_list ap)
{
	if (!ptr || !fmt)
		return -1;
	__int64 Int;
	int sLen;
	char* String;
	char* aPtr;
	byte bTemp;
	char Buf[0x500];
	while (*fmt)
	{
		char Temp = *fmt;
		int Length = -1;
		if (Temp == '%')
		{
			fmt++;
			if (*fmt == '0')
			{
				fmt++;
				Length = 0;
				char* aPtr = Buf;
				while (isdigit(Temp = *fmt))
				{
					*aPtr = Temp;
					aPtr++;
					fmt++;
					*aPtr = 0;
				}
				Length = atoi(Buf);
			}
			switch (*fmt)
			{
			case 's':
				String = va_arg(ap, char*);
				if (String)
				{
					while (*String)
					{
						*ptr = *String;
						String++;
						if (*String)
							ptr++;
					}
				}
				break;
			case 'p':
				Length = 8;
			case 'X':
			case 'x':
				bool Found;
				bool Caps;
				Int = va_arg(ap, __int64);
				if (Length == -1)
					Int = Int & 0xFFFFFFFF;
				Caps = *fmt != 'x';
				Found = false;
				for (int i = 0; i < 8; i++)   // for each bit :: 0 0   0 0   0 0   0 0
				{
					bTemp = (Int >> (28 - (i * 4))) & 0xF;
					if ((8 - i) <= Length)
						Found = true;
					if (Length == -1 && !Found && bTemp)
						Found = true;
					if (Found)
					{
						if (bTemp <= 9)// decimal
							*ptr = 0x30 + bTemp;
						else// hex
							*ptr = (Caps ? 0x40 : 0x60) + bTemp - 9;
						if (i != 7)
							*ptr++;
					}
				}
				break;
			case 'i':
			case 'd':
				memset(Buf, '0', 0xFF);
				Int = va_arg(ap, __int64);
				if (Length == -1)
					Int = Int & 0xFFFFFFFF;
				aPtr = ptr;
				itoa((int)Int, ptr);
				sLen = strlen(ptr);
				if (Length == -1)
					Length = sLen;
				memcpy(Buf + 0xFF - sLen, aPtr, sLen);
				memcpy(aPtr, Buf + 0xFF - Length, Length);
				ptr = aPtr + Length - 1;
				break;
			case 'f':
				break;
			}
		}
		else
			*ptr = Temp;
		ptr++;
		fmt++;
	}
	*ptr = 0;
	return 1;
}
int Sprintf(char *ptr, const char *fmt, /*args*/ ...)  // %s, %i, %d, %x, %X, %p
{
	if (!ptr || !fmt)
		return -1;
	va_list ap;
	va_start(ap, fmt);
	VSprintf(ptr, fmt, ap);
	va_end(ap);
	return 1;
}

char vaBuffer[0x2000];
char* va(const char* fmt, ...) {
	va_list ap;
	va_start(ap, fmt);

	VSprintf(vaBuffer, fmt, ap);

	va_end(ap);
	return vaBuffer;
}

//cString Compare
int cstrcmp(const char* s1, const char* s2)//Please note if its equal to zero the strings are equal
{
	while (*s1 && (*s1 == *s2))
		s1++, s2++;
	return *(const unsigned char*)s1 - *(const unsigned char*)s2;
}
bool Compare(const char* String1, const char* String2){
	return !strcmp(String1, String2);
}

//Sprint Commands
int cPrint(const char* string){
	char buf[100];
	Sprintf(buf, "%s\n", string);
	console_write(buf);
}
int clientIntPrint(int percentInt, const char* string){
	char buf[100];
	Sprintf(buf, "[%i] %s\n", percentInt, string);
	console_write(buf);
}
int32_t sys_dbg_write_process_memoryhen(uint64_t ea, const void* data, size_t size)
{
	system_call_6(8, 0x7777, 0x32, (uint64_t)sys_process_getpid(), (uint64_t)ea, (uint64_t)data, (uint64_t)size);
	return_to_user_prog(int);
}
void sys_dbg_write_process_memory(uint64_t address, const void *data, size_t size)
{
	sys_dbg_write_process_memoryhen(address, data, size);
}

void sys_dbg_write_string(uint32_t address, const char *value)
{
	sys_dbg_write_process_memory(address, value, strlen(value) + 1);
}

void HookFunction(uint32_t address, uint32_t function)
{
	uint32_t opcode[4];
	opcode[0] = 0x3D600000 + ((function >> 16) & 0xFFFF);
	opcode[1] = 0x616B0000 + (function & 0xFFFF);
	opcode[2] = 0x7D6903A6;
	opcode[3] = 0x4E800420;
	sys_dbg_write_process_memory(address, &opcode, 0x10);
}