namespace PS3
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
		char* StrBytes = PS3::ReadBytes(address, strlength);

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