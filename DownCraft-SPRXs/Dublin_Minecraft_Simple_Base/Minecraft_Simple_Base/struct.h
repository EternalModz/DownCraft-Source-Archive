#pragma once

/*enum MCButtons {
	X = 0x100,
	O = 0x200,
	SQUARE = 0x400,
	TRIANGLE = 0x800,
	UP = 0x40000,
	DOWN = 0x80000,
	LEFT = 0x100000,
	RIGHT = 0x200000,
	R1 = 0x4000,
	R2 = 0x0, //No need
	R3 = 0x10000,
	L1 = 0x8000,
	L2 = 0x0, //No need
	L3 = 0x20000,
	START = 0x2000,
	SELECT = 0x1000
};*/

class Minecraft {
public:
	//DataFixerUpper * cDataFixerUpper;
	//MultiPlayerGameMode * cMultiPlayerGameMode;
	char __padding000[0x0008];
	int displayWidth;
	int displayHeight;
	int displayWidth1;
	int displayHeight1;
	//Timer * cTimer;
	char __padding001[0x0008];
	//MultiPlayerLevel * cMultiPlayerLevel;
	//LevelRenderer * cLevelRenderer;
	//MultiplayerLocalPlayer * cMultiplayerLocalPlayer;
	char __padding002[0x000C];
	//MultiplayerLocalPlayer * cMultiplayerLocalPlayer1;
	char __padding003[0x0018];
	//MultiPlayerGameMode * cMultiPlayerGameMode1;
	char __padding004[0x0010];
	uint32_t unknownptr[4];
	char __padding005[0x003C];
	//MultiplayerLocalPlayer * cMultiplayerLocalPlayer2;
	char __padding006[0x000C];
	uint32_t unknownptr1[2];
	char __padding007[0x0028];
	uint32_t fontRenderer;
};

class TheMinecraft {
public:
	Minecraft * theMinecraft;
	char __padding000[0x0020];
	uint32_t gameTime;
	char __padding001[0x0080];
	uint32_t ping;
};
struct eMenus {

};

/*struct Menu {
	int CurrentMenu;
	int CurrentOpt;
	int MaxOption;

};*/

struct Vars {

};

struct Self {
	//Menu menu;
	Vars vars;
	bool isMenuOpen;
};






