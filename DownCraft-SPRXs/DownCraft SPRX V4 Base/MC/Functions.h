#pragma once

#include <net\if_dl.h>
#include <net\if_types.h>
#include <netdb.h>
#include <netex\errno.h>
#include <netex\ifctl.h>
#include <netex\libnetctl.h>
#include <netex\net.h>
#include <netex\ns.h>
#include <netex\sockinfo.h>
#include <netex\udpp2p.h>
#include <netinet\icmp.h>
#include <netinet\in.h>
#include <netinet\ip.h>
#include <netinet\tcp.h>
#include <sys\socket.h>
#include <sys\console.h>
#include <sys\memory.h>
#include <sys\process.h>
#include <sys\timer.h>
#include <cell\cell_fs.h>
#pragma comment(lib, "net_stub")
#pragma comment(lib, "netctl_stub")


struct Color
{
	Color(std::uint8_t r = 255, std::uint8_t g = 255, std::uint8_t b = 255, std::uint8_t a = 255)
		: r(r), g(g), b(b), a(a)
	{

	}

	Color(std::uint32_t hexValue)
	{
		a = (hexValue & 0xFF000000) >> 24;
		r = (hexValue & 0xFF0000) >> 16;
		g = (hexValue & 0xFF00) >> 8;
		b = hexValue & 0xFF;
	}

	std::uint32_t ToHex()
	{
		return (a << 24) | (r << 16) | (g << 8) | b;
	}


	std::uint8_t a;
	std::uint8_t r;
	std::uint8_t g;
	std::uint8_t b;
};

wchar_t* c2wc(char* txt)
{
	if (checkTxt != txt)
	{
		int len = strlen(txt);
		for (int i = 0; i < len; i++)
		{
			charA2wcharA_[i] = txt[i];
		}
		charA2wcharA_[len] = '\0';
		checkTxt = txt;

	}
	return charA2wcharA_;
}

font_t getString(const wchar_t* str)
{
	font_t font;
	font.text = str;
	font.dataType = 7;
	font.wcstrlen = wcslen(str);
	font.wcstrlen1 = wcslen(str) + 3;
	font.unknown1 = 2.0625f;
	font.unknown1 = 1.0f;
	font.unknown1 = 1.0078125f;
	return font;
}

size_t StringToWideCharacter(wchar_t* dest, const char* scr, size_t len)
{
	int count = 0;
	if (len)
	{
		do
		{
			if ((*dest++ = (wchar_t)*scr++) == 0)
				break;
			count++;
		} while (--len);
	}
	return count;
}

size_t WideCharacterToString(char* dest, const wchar_t* scr, size_t len)
{
	int count = 0;
	if (len)
	{
		do
		{
			if ((*dest++ = (char)*scr++) == 0)
				break;
			count++;
		} while (--len);
	}
	return count;
}

typedef union RGBTEXT
{
	struct
	{
		union { int red; int R; };
		union { int green; int G; };
		union { int blue; int B; };
	};
	int color[3];
} RGBTEXT;

typedef union RGBHUD
{
	struct
	{
		union { int red; int R; };
		union { int green; int G; };
		union { int blue; int B; };
	};
	int color[3];
} RGBHUD;

RGBTEXT MenuColour1 = { 90, 0, 0 };
RGBTEXT MenuColour2 = { 0, 90, 0 };
int MenuColourTime = 0;
int RainbowTime = 0;

void RGB1()
{
	if (RainbowTime < mc->gameTime)
	{
		if (MenuColourTime == 0)
		{
			MenuColour1.B++;
			if (MenuColour1.B == 255)
				MenuColourTime = 1;
		}
		else if (MenuColourTime == 1)
		{
			MenuColour1.R--;
			if (MenuColour1.R == 0)
				MenuColourTime = 2;
		}
		else if (MenuColourTime == 2)
		{
			MenuColour1.G++;
			if (MenuColour1.G == 255)
				MenuColourTime = 3;
		}
		else if (MenuColourTime == 3)
		{
			MenuColour1.B--;
			if (MenuColour1.B == 0)
				MenuColourTime = 4;
		}
		else if (MenuColourTime == 4)
		{
			MenuColour1.R++;
			if (MenuColour1.R == 255)
				MenuColourTime = 5;
		}
		else if (MenuColourTime == 5)
		{
			MenuColour1.G--;
			if (MenuColour1.G == 0)
				MenuColourTime = 0;
		}
		UI::Color::RainbowRED = MenuColour1.R;
		UI::Color::RainbowGREEN = MenuColour1.G;
		UI::Color::RainbowBLUE = MenuColour1.B;
		RainbowTime = mc->gameTime;
	}
}

void RGB2()
{
	if (RainbowTime < mc->gameTime)
	{
		if (MenuColourTime == 0)
		{
			MenuColour2.B++;
			if (MenuColour2.B == 255)
				MenuColourTime = 1;
		}
		else if (MenuColourTime == 1)
		{
			MenuColour2.R--;
			if (MenuColour2.R == 0)
				MenuColourTime = 2;
		}
		else if (MenuColourTime == 2)
		{
			MenuColour2.G++;
			if (MenuColour2.G == 255)
				MenuColourTime = 3;
		}
		else if (MenuColourTime == 3)
		{
			MenuColour2.B--;
			if (MenuColour2.B == 0)
				MenuColourTime = 4;
		}
		else if (MenuColourTime == 4)
		{
			MenuColour2.R++;
			if (MenuColour2.R == 255)
				MenuColourTime = 5;
		}
		else if (MenuColourTime == 5)
		{
			MenuColour2.G--;
			if (MenuColour2.G == 0)
				MenuColourTime = 0;
		}
		UI::Color::RainbowRED1 = MenuColour2.R;
		UI::Color::RainbowGREEN1 = MenuColour2.G;
		UI::Color::RainbowBLUE1 = MenuColour2.B;
		RainbowTime = mc->gameTime;
	}
}

//USED FOR OFFSET

int* GetThemeColor()
{
	int * THEME;
	if (UI::Settings::ThemeColors == "DEFAULT") { THEME = UI::Color::BLUE; }
	else if (UI::Settings::ThemeColors == "WHITE") { THEME = UI::Color::WHITE; }
	else if (UI::Settings::ThemeColors == "PINK") { THEME = UI::Color::PINK; }
	else if (UI::Settings::ThemeColors == "RED") { THEME = UI::Color::RED; }
	else if (UI::Settings::ThemeColors == "ORANGE") { THEME = UI::Color::ORANGE; }
	else if (UI::Settings::ThemeColors == "CYAN") { THEME = UI::Color::CYAN; }
	else if (UI::Settings::ThemeColors == "GREEN") { THEME = UI::Color::GREEN; }
	else if (UI::Settings::ThemeColors == "LIME") { THEME = UI::Color::LIME; }
	else if (UI::Settings::ThemeColors == "YELLOW") { THEME = UI::Color::YELLOW; }
	else if (UI::Settings::ThemeColors == "PURPLE") { THEME = UI::Color::PURPLE; }
	return THEME;
}

int GetThemeColorText()
{
	int *THEME;
	if (UI::Settings::ThemeColors == "DEFAULT") { THEME = UI::Color::BLUE; }
	else if (UI::Settings::ThemeColors == "WHITE") { THEME = UI::Color::WHITE; }
	else if (UI::Settings::ThemeColors == "PINK") { THEME = UI::Color::PINK; }
	else if (UI::Settings::ThemeColors == "RED") { THEME = UI::Color::RED; }
	else if (UI::Settings::ThemeColors == "ORANGE") { THEME = UI::Color::ORANGE; }
	else if (UI::Settings::ThemeColors == "CYAN") { THEME = UI::Color::CYAN; }
	else if (UI::Settings::ThemeColors == "GREEN") { THEME = UI::Color::GREEN; }
	else if (UI::Settings::ThemeColors == "LIME") { THEME = UI::Color::LIME; }
	else if (UI::Settings::ThemeColors == "YELLOW") { THEME = UI::Color::YELLOW; }
	else if (UI::Settings::ThemeColors == "PURPLE") { THEME = UI::Color::PURPLE; }
	return *THEME;
}

int* GetThemeRainbow()
{
	int RAINBOW[3] = { UI::Color::RainbowRED, UI::Color::RainbowGREEN, UI::Color::RainbowBLUE };
	return RAINBOW;
}

int toggleFunc(int value, int max)
{
	if (max - 1 <= value)
		value = -1;

	return ++value;
}

bool frameTime(int ms, int index, bool resetTime)
{
	if (resetTime)
		gotTime[index] = false;
	if (!gotTime[index])
	{
		gotTime[index] = true;
		getTime[index] = mc->gameTime;
	}
	timeMath[index] = mc->gameTime - getTime[index];

	if (timeMath[index] >= ms)
	{
		gotTime[index] = false;
		return true;
	}
	else
		return false;
}

bool scrollWait(int firstMs, int ms, int index)
{
	keyPressed[index] = true;
	if (!lockFirst[index])
	{
		if (freeFirst[index])
		{
			freeFirst[index] = false;
			return true;
		}

		if (frameTime(firstMs, 200 + index, resetWait[index]))
		{
			lockFirst[index] = true;
			resetWait[index] = false;
			return true;
		}
		else
		{
			resetWait[index] = false;
			return false;
		}
	}
	else
	{
		if (frameTime(ms, 200 + index, resetWait2[index]))
		{
			resetWait2[index] = false;
			return true;
		}
		else
		{
			resetWait2[index] = false;
			return false;
		}
	}
}

int doScroll(int _scroll, int max)
{
	_scroll = scroll;
	if (_scroll == max)
		return 0;
	else if (_scroll == -1)
		return max - 1;
	else
		return _scroll;
}

char* ReadFile(char* File)
{
	char* Result;
	int fdl;
	char licStr[32];
	CellFsErrno readLic;
	uint64_t swl, srl;

	readLic = cellFsOpen(File, CELL_FS_O_RDONLY, &fdl, NULL, 0);

	if (readLic == 0)
	{
		cellFsRead(fdl, licStr, sizeof(licStr), &swl);
		Result = licStr;
		cellFsClose(fdl);
	}

	return Result;
}

void PlayUISoundBack() {
	ConsoleUIController_PlayUISFX(ConsoleUIController, *pSoundEventBack);
}

void PlayUISoundSelect() {
	ConsoleUIController_PlayUISFX(ConsoleUIController, *pSoundEventPress);
}

void PlayUISoundScroll() {
	ConsoleUIController_PlayUISFX(ConsoleUIController, *pSoundEventScroll);
}

void PlayUISoundFocus() {
	ConsoleUIController_PlayUISFX(ConsoleUIController, *pSoundEventFocus);
}

void PlayUISoundCraft() {
	ConsoleUIController_PlayUISFX(ConsoleUIController, *pSoundEventCraft);
}

void ChangeIntOptions(bool page, int currentopt, int min, int max, int& value)
{
	if (page)
	{
		if (CurrentOpt == currentopt)
		{
			if (Buttons::IsMCButtonPressed(Buttons::LEFT))
			{
				if (frameTime(5, 1, false))
				{
					if (value < min + 1)
					{
						value = max;
					}
					else
					{
						value = value - 5;
					}
					PlayUISoundCraft();
				}
			}
			else if (Buttons::IsMCButtonPressed(Buttons::RIGHT))
			{
				if (frameTime(5, 1, false))
				{
					if (value > max - 1)
					{
						value = min;
					}
					else
					{
						value = value + 5;
					}
					PlayUISoundCraft();
				}
			}
		}
	}
}

void ChangeFloatOptions(bool page, int currentopt, int min, int max, float& value)
{
	if (page)
	{
		if (CurrentOpt == currentopt)
		{
			if (Buttons::IsMCButtonPressed(Buttons::LEFT))
			{
				if (frameTime(5, 1, false))
				{
					if (value < min + 1)
					{
						value = max;
					}
					else
					{
						value = value - 5;
					}
					PlayUISoundCraft();
					*(char*)0x014C670C = NyTekCFW::FloatToHex(value);
				}
			}
			else if (Buttons::IsMCButtonPressed(Buttons::RIGHT))
			{
				if (frameTime(5, 1, false))
				{
					if (value > max - 1)
					{
						value = min;
					}
					else
					{
						value = value + 5;
					}
					PlayUISoundCraft();
					*(char*)0x014C670C = NyTekCFW::FloatToHex(value);
				}
			}
		}
	}
}

void INITIALIZE_START()
{
	if (INITIALIZE_SPRX)
	{
		/*
		bool BLES = (*(int*)0x31E7782C = 0x424C4553);
		if (!BLES)
		{
			//if the game is not BLES
		}
		*/

		PSN_NAME = PS3Lib::ReadString(0x3000AD34);
		REGION = PS3Lib::ReadString(0x3000AD48);
		strcpy((char*)0x3100AD34, "DownCraft SPRX"); //unique ID

		*(int*)0x31E7782C = 0x49600000; //pos images
		*(int*)0x31E77830 = 0xC98D0000; //pos images

		//SAVE BLOCKS
		SAVE_BLOCK_AIR = Blocks::AIR;
		INITIALIZE_SPRX = false;
	}
}

void noclip_func()
{
	char phase1[] = { 0xFF, 0xFF, 0xFF, 0xFF, 0x00 };
	char phase2[] = { 0x01, 0x01, 0x01, 0x01, 0x00 };
	char phase3[] = { 0x10, 0x10, 0x80, 0x3F, 0x00 };
	char phase4[] = { 0x80, 0x75, 0x20, 0x35, 0x00 };

	char phaseend[] = { 0x66, 0x66, 0x66, 0x66, 0x00 };

	char* misaki1 = (char*)0x3200AD34;
	char* misaki2 = (char*)0x32F0AD34;
	char* misaki3 = (char*)0x32C6AD34;
	char* misaki4 = (char*)0x12C6AD34;

	noclipvars = true;
	for (int i = 0; i < 4; ++i)
	{
		if (misaki1[i] != phase1[i])
		{
			if (misaki2[i] != phase2[i])
			{
				if (misaki3[i] != phase3[i])
				{
					if (misaki4[i] != phase4[i])
					{
						noclipvars = false;
					}
				}
			}
		}

		if (misaki4[i] == phaseend[i])
		{
			UnHookFunctionStart(gameRenderHook, *(uint32_t*)(gameRender_Stub));
			UnHookFunctionStart(0x01084270, *(uint32_t*)(asm_SetPresenceDetails_Hook));
			//UnHookFunctionStart(0xB34A6C, *(uint32_t*)(MultiPlayerGameMode_destroyBlockHook));
			UnHookFunctionStart(0x3A7F48, *(uint32_t*)(LivingEntity_actuallyHurtHook));
			*(int*)0x00785DBC = 0x40800028;
			*(int*)0x00AD8320 = 0x408000CC;
			*(int*)0x014CE214 = 0x01000001;
		}
	}
}


namespace Modules
{
	void NukerTNT()
	{
		//
	}

	
	void setLocation(double x, double y, double z)
	{
		mc->theMinecraft->cMultiplayerLocalPlayer->SetPosition(x + 0.5, y + 1 + 0.5, z + 0.5);
	}

	void AntiVoid()
	{
		//
	}

	void SpinCamera()
	{
		//
	}

	void SkyboxRGB()
	{
		//
	}
}











































































char * removespace(const char * notify)
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
	SendRequest("127.0.0.1", buffer);
}

void Notify(const char * notify) 
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

	void SendRequest(char* url,  char* retBuffer, int bufMaxLen) //url = url to request ("http://www.google.com/")    | retBuffer = ptr where the answer will be written to  | bufMaxLen = Max length of the buffer
	{
			if(bufMaxLen > 0x6000) {return;} //ERROR, bufMaxLen is TOO BIG

					CellHttpClientId client = 0;
					CellHttpTransId trans = 0;
					CellHttpUri uri;
					int ret;
					bool has_cl = true;
					uint64_t length = 0;
					uint64_t recvd;
					size_t poolSize = 0;
					void *uriPool = NULL;
							void *httpPool = NULL;
							const char *serverName;
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
									ret = cellHttpRecvResponse(trans, r_buffer, bufMaxLen-1, &localRecv);
									if (ret < 0) {goto end; } else if (localRecv == 0) break;
									recvd += localRecv;
									r_buffer[localRecv] = '\0'; //null terminate it
						}
							ret = 0;
							{
								for(int i = 0;i<bufMaxLen;i++)
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
				cellHttpDestroyClient(client);client = 0;
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