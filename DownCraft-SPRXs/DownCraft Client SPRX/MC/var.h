//SubMenu
bool Enabled = false;
bool OpenMenu = false;
bool OpenSelector = false;
bool MainMenu = false;
bool CombatMenu = false;
bool MovementMenu = false;
bool ExploitMenu = false;
bool WorldMenu = false;
bool PlayersMenu = false;
bool RenderMenuz = false;
bool SettingsMenu = false;
bool CreditMenu = false;


//Combat
bool InstantHit = false;
bool AutoHit = false;
bool ReachAttack = false;
bool KillAura = false;


//Movement
bool AutoSprint = false;
bool SuperSpeed = false;
bool SwimGlitch = false;
bool SensiMax = false;
bool AutoWalk = false;
bool AutoCrouch = false;
bool CrouchMov = false;
bool WaterSlowdown = false;
bool AutoJump = false;
bool AlwaysSprint = false;
bool NoSlowDown = false;
bool NoFootStep = false;
bool RealJump = false;
bool RotationHead = false;


//Exploit
bool MultiJump = false;
bool NoColission = false;
bool DriftBoat = false;
bool SpectatorMode = false;
bool GodModeForMe = false;
bool CanFly = false;
bool NoVeloCity = false;
bool DragonEggs = false;


//World
bool DisablePortals = false;
bool EntityGodMode = false;
bool InstantDamage = false;
bool Knockback = false;
bool MobsIgnoreMe = false;
bool FreezeEntity = false;
bool AirToWater = false;

//Players
bool FreezeConsole = false;
bool PlayersFastMine = false;
bool PlayerSuperSpeed = false;
bool SuffocatePlayers = false;
bool PlayersInFire = false;
bool DisablePlayers = false;


//Render
bool BetterTime = false;
bool XrayVision = false;
bool OptimizeChunk = false;
bool FOVWithoutHand = false;
bool FreeCam = false;
bool BestSky = false;
bool WallHack = false;
bool RenderEntity = false;

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

//Menu pos and select
int TitleTextX = 44;
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
int AddOptX = 22;
int AddOptY = 32;
int textI = 9;
int bgX = 20;
int bgY = 30;
int bgW = 50;
int bgH = 11;
int scroll = 0;

int CurrentOptSelector;
int MaxOptionsSelector;
int bgXSelector = 20;
int bgYSelector = 30;
int TextXSelector = 25;
int TextYSelector = 32;
int BgWSelector = 50;
int CheckBoxSelector = 112;

int shadowBG = 200;

char* PSN_NAME;

//Not yet
int nukerSize = 80;
bool nuker = true;

//Utility
char* checkTxt = "";
wchar_t charA2wcharA_[1000];
int userAddr = 0;
TheMinecraft * mc;
Vector2 _getView;
Vector3 _getOrigin;
Vector3 userOrigin;
void select();