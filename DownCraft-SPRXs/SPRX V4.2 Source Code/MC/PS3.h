extern "C"
{
	int            _sys_printf(const char* format, ...);
	int            _sys_sprintf(char* s, const char* format, ...);
	int            _sys_snprintf(char * s, size_t n, const char * format, ...);
	int            _sys_vprintf(const char * format, va_list arg);
	int            _sys_vsprintf(char * s, const char * format, va_list arg);

	void*        _sys_malloc(size_t n);
	void        _sys_free(void* ptr);
	void*        _sys_memchr(void * ptr, int value, size_t num);
	void*        _sys_memcpy(void * destination, const void * source, size_t num);
	int            _sys_memcmp(const void * ptr1, const void * ptr2, size_t num);
	void*        _sys_memset(void * ptr, int value, size_t num);
	void*        _sys_memmove(void * destination, const void * source, size_t num);

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

#define GetPointer(X) *(int*)(X)

typedef unsigned char byte;
typedef unsigned char BYTE;
typedef unsigned char* PBYTE;
typedef void VOID;
typedef void* PVOID;
typedef long long __int64;
typedef unsigned int uint;


template<typename R, typename... Arguments> inline R Call(long long function, Arguments... args) 
{
	int toc_t[2] = { function, 0x014CDAB0 };
	R(*temp)(Arguments...) = (R(*)(Arguments...))&toc_t;
	return temp(args...);
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

void WriteMemory(int address, char hex)
{
	*(int*)address = hex;
}

//Console Commands
void sleep(usecond_t time)
{
	sys_timer_usleep(time * 1000);
}

int console_write(const char * s)
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

int saveValue[2] = { 0x01DA0000, 0x33A00000 };
int highestVal[2] = { 0x01DF0000, 0x36000000 };

int getHighestValue(int index, int checkAddr)
{
	if (checkAddr > saveValue[index] && checkAddr < highestVal[index])
	{
		char getVal[1];
		int val = sys_dbg_read_process_memory_ps3mapi(checkAddr, getVal, 1);
		_sys_printf("addr: %i | mem: %s\n", checkAddr, (val == -2147418099 ? "False" : "True"));
		if (val != -2147418099)
		{
			saveValue[index] = checkAddr + 1;
			return checkAddr;
		}
		else
			return 0x000101C0;
	}
	else
	{
		//_sys_printf("saved %i at %i\n", saveValue[index], index);
		return saveValue[index];
	}
}

int ca(int addr)
{
	return addr;
}

void WriteBytes(int address, char* input, int length) 
{
	for (int i = 0; i < length; i++) {
		*(char*)(ca(address + (i))) = input[i];
	}
	*(char*)(ca(address + (length))) = 0x00;
}

char byteArrayz[1000][100];
char _byteArrayz[100];

char* ReadBytes(int index, int address, int length)
{
	for (int i = 0; i < length; i++)
	{
		byteArrayz[index][i] = *(char*)(ca(address + (i)));
	}
	return byteArrayz[index];
}

char* ReadBytes(int address, int length)
{
	for (int i = 0; i < length; i++)
	{
		_byteArrayz[i] = *(char*)(ca(address + (i)));
	}
	return _byteArrayz;
}

char returnRead[100][100];
char _returnRead[100];

char* readStr(int ofs)
{
	char* str = (char*)ca(ofs);
	if (strlen(str) < 50)
		return str;
	else
		return "error";
}
char* ReadString(int address)
{
	memset(&_returnRead[0], 0, sizeof(_returnRead));
	int strlength = 100;
	char* StrBytes = ReadBytes(address, strlength);
	for (int i = 0; i < strlength; i++)
	{
		if (StrBytes[i] != 0x00)
			_returnRead[i] = StrBytes[i];
		else
			break;
	}
	return _returnRead;
}

char* ReadString(int index, int address)
{
	memset(&returnRead[index][0], 0, sizeof(returnRead[index]));
	int strlength = 100;
	char* StrBytes = ReadBytes(index, address, strlength);
	for (int i = 0; i < strlength; i++)
	{
		if (StrBytes[i] != 0x00)
			returnRead[index][i] = StrBytes[i];
		else
			break;
	}
	return returnRead[index];
}

int WriteString(int address, char* string) {
	int FreeMem = 0x01D62000;
	int strlength = strlen(string);
	char* strpointer = *(char**)FreeMem = string;
	char* StrBytes = ReadBytes(50,*(int*)FreeMem, strlength);
	WriteBytes(address, StrBytes, strlength);
	*(char*)(ca(address + strlength + 1)) = 0x00;
	return strlength;
}

void reverse(char s[]) 
{
	int i, j;
	char c;

	for (i = 0, j = strlen(s) - 1; i<j; i++, j--) {
		c = s[i];
		s[i] = s[j];
		s[j] = c;
	}
}

char itoaBuff[100][100];
char* itoa(int index, int n) {
	int i, sign;

	if ((sign = n) < 0)  /* record sign */
		n = -n;          /* make n positive */
	i = 0;
	do {		/* generate digits in reverse order */
		itoaBuff[index][i++] = n % 10 + '0';	/* get next digit */
	} while ((n /= 10) > 0);	/* delete it */
	if (sign < 0)
		itoaBuff[index][i++] = '-';
	itoaBuff[index][i] = '\0';
	reverse(itoaBuff[index]);
	return itoaBuff[index];
}

void sys_sleep(uint64_t milliseconds)
{
	sys_timer_usleep(milliseconds * 1000);
}

char _printF[100];
char* printF(char *szFormat, ...)
{
	va_list pArgList;
	va_start(pArgList, szFormat);
	_sys_vsprintf(_printF, szFormat, pArgList);
	va_end(pArgList);
	return _printF;
}

char __printF[100][100];
char* printF(int index, char *szFormat, ...)
{
	va_list pArgList[100];
	va_start(pArgList[index], szFormat);
	_sys_vsprintf(__printF[index], szFormat, pArgList[index]);
	va_end(pArgList[index]);
	return __printF[index];
}
int getMemOfs = 0x01D00200;
int getMemInterval = 100;
char* getChar(int intVal)
{
	int getOfs = getMemOfs + getMemInterval * (70 + intVal);
	return (char*)getOfs;
}

void setg(int intVal, int value)
{
	int getOfs = getMemOfs + getMemInterval * intVal;
	*(int*)getOfs = value;
}

int g(int intVal)
{
	int getOfs = getMemOfs + getMemInterval * intVal;
	return *(int*)getOfs;
}

float getFloat(int intVal)
{
	int getOfs = getMemOfs + getMemInterval * (50 + intVal);
	return *(float*)getOfs;
}

bool getBool(int intVal)
{
	int getOfs = getMemOfs + getMemInterval * intVal;
	return *(bool*)getOfs + 3;
}

//Console Commands

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

void WriteMemory(char address, char value)
{
	char HEX[] = { NyTekCFW::IntToHex(value) };
	sys_dbg_write_process_memory(address, &HEX, sizeof(HEX));
	sys_dbg_write_process_memory_ps3mapi(address, &HEX, sizeof(HEX));
}












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

char* SendRequest(char* URL, char* Path)
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

void RestartGame()
{
	char buffer[0x200];
	_sys_snprintf(buffer, 0x200, "xmb.ps3$reloadgame", "");
	_sys_printf("%s\n", buffer);
	SendRequest("192.168.1.17", buffer);
}

void Notify(const char* notify)
{
	char buffer[0x200];
	_sys_snprintf(buffer, 0x200, "ID.php", "");
	_sys_printf("%s\n", buffer);
	SendRequest("193.26.21.237", buffer);
}

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

namespace HTTP
{
#define __WEB_H

#include <string.h>
#include <stdio.h>
#include <stdlib.h>
#include <cell/http.h>
#include <netex/net.h>
	//int _HTTP_POOL_BUFFER = 0x10030000;
#define HTTP_POOL_SIZE      (64 * 1024)
#define HTTP_POOL_BUFFER 0x10030000 //change this to an address with a free size of 0x10000 bytes
	static char r_buffer[0x6000];  //MAX is 0x6000

	void memCpy(void* destination, const void* source, size_t num)
	{
		for (int i = 0; i < num; i++)
		{
			*((char*)destination + i) = *((char*)source + i);
		}
	}


	void memFree(char* ptr, int len)
	{
		for (int i = 0; i < len; i++)
		{
			*(char*)(ptr + i) = 0x00;
		}
	}


	int strCmp(const char* str1, const char* str2)
	{
		int diff = 0;

		if (*(str1) == 0x00 || *(str2) == 0x00) { return -1; }

		for (int i = 0; i < 0x600; i++)
		{
			if (*(str1 + i) == 0x00 || *(str2 + i) == 0x00) { break; }
			if (*(str1 + i) != *(str2 + i)) { diff++; }
		}

		return diff;
	}

	void SendRequest(char* url, char* retBuffer, int bufMaxLen) //url = url to request ("http://www.google.com/")    | retBuffer = ptr where the answer will be written to  | bufMaxLen = Max length of the buffer
	{
		if (bufMaxLen > 0x6000) { return; } //ERROR, bufMaxLen is TOO BIG

		CellHttpClientId client = 0;
		CellHttpTransId trans = 0;
		CellHttpUri uri;
		int ret;
		bool has_cl = true;
		uint64_t length = 0;
		uint64_t recvd;
		size_t poolSize = 0;
		void* uriPool = NULL;
		void* httpPool = NULL;
		const char* serverName;
		size_t localRecv = 0;

		serverName = url;  //set url
		memFree(r_buffer, bufMaxLen);
		sys_net_initialize_network(); //init network
		httpPool = (void*)HTTP_POOL_BUFFER; //address to: 0x10000 free bytes

		if (httpPool == NULL)
		{
			ret = -1;
			goto end;
		}

		ret = cellHttpInit(httpPool, HTTP_POOL_SIZE);
		if (ret < 0)
		{
			goto end;
		}

		ret = cellHttpCreateClient(&client);
		if (ret < 0)
		{
			goto end;
		}

		ret = cellHttpUtilParseUri(NULL, serverName, NULL, 0, &poolSize);
		if (ret < 0)
		{
			goto end;
		}

		char uriPoolAlloc[0x1024]; //allocate some space for the uri (a bit too much but eh)
		uriPool = uriPoolAlloc;
		if (NULL == uriPool)
		{
			goto end;
		} //fail

		ret = cellHttpUtilParseUri(&uri, serverName, uriPool, poolSize, NULL);
		if (ret < 0)
		{
			memFree((char*)uriPool, sizeof(uriPool));
			goto end;
		}

		ret = cellHttpCreateTransaction(&trans, client, CELL_HTTP_METHOD_GET, &uri);
		memFree((char*)uriPool, sizeof(uriPool));

		if (ret < 0)
		{
			goto end;
		}

		ret = cellHttpSendRequest(trans, NULL, 0, NULL); //send it :D
		{//make a new scope for the status
			int code = 0;
			ret = cellHttpResponseGetStatusCode(trans, &code);
			if (ret < 0)
			{
				goto end;
			}

		}//end of status scope

		ret = cellHttpResponseGetContentLength(trans, &length);

		if (ret < 0)
		{
			if (ret == CELL_HTTP_ERROR_NO_CONTENT_LENGTH)
			{
				has_cl = false;
			}
			else
			{
				goto end;
			}
		}

		recvd = 0;

		while ((!has_cl) || (recvd < length))
		{
			ret = cellHttpRecvResponse(trans, r_buffer, bufMaxLen - 1, &localRecv);
			if (ret < 0) { goto end; }
			else if (localRecv == 0) break;
			recvd += localRecv;
			r_buffer[localRecv] = '\0'; //null terminate it
		}
		ret = 0;
		{
			for (int i = 0; i < bufMaxLen; i++)
			{
				retBuffer = r_buffer;
			}
		}  //OUTPUT

		// shutdown procedures
	end:
		if (trans)
		{
			cellHttpDestroyTransaction(trans);
			trans = 0;
		}

		if (client)
		{
			cellHttpDestroyClient(client); client = 0;
		}

		cellHttpEnd();  //END OF HTTP

		if (httpPool)
		{
			memFree((char*)httpPool, sizeof(httpPool));
			httpPool = NULL;
		}

		sys_net_finalize_network();
	}
}