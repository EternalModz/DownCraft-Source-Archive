//SubMenu
bool OpenMenu = false;
bool MainMenu = false;
bool HostPage = false;
bool CreditsMenu = false;

//Host Options
bool GodMode = false;

//UTILITY
int mcOfs = 0x014CF2E4;
int gameRenderHook = 0x00AA3360;
int ctrlLockOfs = 0x0155847c;
int shaderOfs = 0x00A7E2E8;
int PlayUISFX = 0x886798;
int MultiPlayerGetEntity = 0xB0E8F4;
int GetLocalPlayerID = 0xAE03B4;
int MPDestroyBlock = 0xB34A6C;
int wcLenOfs = 0x00CB32D8;
int theMcOfs = 0x014cf2e4;
int Ofsprintf = 0xCB9910;
int Ofssnprintf = 0xCB9A10;
int GuiFillGardient = 0xA7D278;
int GuiRender = 0xA891F0;
int FontWidth = 0x00A7DB38;
int CinputRequestKeyboard = 0xC62B80;
int addr1 = 0x00BDCA84;
int addr2 = 0x00BDCA9C;
int addr3 = 0x009C1928;
int addr4 = 0x009C1A3C;
int addr5 = 0x009C170C;
int addr6 = 0x009C2388;
int ofs1 = 0x30000000;
int ofs2 = 0x35000000;
int ofs3 = 0x01500000;
int ofs4 = 0x01100000;

namespace clientStruct
{
	int verify = 0x04;
	int getView = 0xE0;
	int setView = 0x148;
	int origin = 0x100;
	int active1 = 0x1E8;
	int active2 = 0x3AC;
	int targetP = 0x4E8;
	int alive1 = 0x197;
	int alive2 = 0x138;
	int invul = 0x6F0;
	int name = 0x764;
	int id = 0x774;
};

bool clientUpdated = false;
int firstWaitTime = 15;
int waitTime = 5;
int scrollTick = 0;
bool keyPressed[100];
bool freeFirst[100];
bool resetWait[100];
bool resetWait2[100];
bool lockFirst[100];
int getTime[1000];
int timeMath[1000];
bool gotTime[1000];

//Functions
char PING[0x100];
wchar_t wPING[0x100];
bool SendNotif = false;
wchar_t* NotifMsg;
bool INITIALIZE_SPRX;

int submmenuMax;

int shadowBG = 200;

//Menu pos and select
int menulenght = -5;
int TitleTextX = 46;
int TitleTextY = 38;
int DebugTextX = 0;
int DebugTextY = 0;
int DebugHudX = 0;
int DebugHudY = 0;
int DebugHudW = 0;
int DebugHudH = 0;
int CurrentMenu;
int CurrentOpt;
int MaxOption;
int subMax = 0;
int textX = 40;
int textY = 40;
int AddOptX = 40;
int AddOptY = 50;
int textI = 9;
int bgX = 35;
int bgY = 48;
int bgW = 95;
int bgH = 11;
int CheckBoxX = 119;
int CheckBoxY = 50;
int ScrollX = 35;
int ScrollY = 48;
int scroll = 0;

char* PSN_NAME;
char* PRESET_NAME;
char * REGION;

//Utility
char* checkTxt = "";
wchar_t charA2wcharA_[1000];
int userAddr = 0;
TheMinecraft * mc;
Vector2 _getView;
Vector3 _getOrigin;
Vector3 userOrigin;
void select();

char* PLR_NAME;
char* PLR_REGION;

int TeleportX;
int TeleportY;
int TeleportZ;
bool pressedbhop;

bool spincameratoggle = false;
float spincamera;
int menusize;
float fovvalue;

uint32_t cpu_t = 0;
uint32_t rsx_t = 0;

int RainbowSkyRGB;
int RainbowSkyRGBSpeed = 10;
