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

template<typename R, typename... Arguments> inline R Call(long long function, Arguments... args) {
	int toc_t[2] = { function, 0x014CDAB0 };
	R(*temp)(Arguments...) = (R(*)(Arguments...))&toc_t;
	return temp(args...);
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
void WriteBytes(int address, char* input, int length) {
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

void reverse(char s[]) {
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

int write_process(uint64_t ea, const void* data, size_t size)
{
	system_call_6(8, 0x7777, 0x32, (uint64_t)sys_process_getpid(), (uint64_t)ea, (uint64_t)data, (uint64_t)size);
	return_to_user_prog(int);
}

//Console Commands
void sleep(usecond_t time)
{
	sys_timer_usleep(time * 1000);
}

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