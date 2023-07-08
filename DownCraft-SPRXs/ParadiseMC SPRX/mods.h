#define VALID_ADDR(x) ((unsigned int)(x) > 0x10000)

namespace Addresses { //1.69
	unsigned int buttonMonitoring = 0x3000CF78;//find using netcheat
	unsigned int globalVariableStruct = 0x13FCF3C;//too small for sig, but used everywhere. Look for the function it's used in, found by looking at ServerPlayer and then godmode then lr then this used at top of func (inside another function, 3 instructions)
};

namespace buttons {
unsigned int
    //buttons_address_mc = 0x3000dcb8,//1.54
	//buttons_address_mc = 0x3000CF78,//1.69
	//buttons_address_mc = Addresses::buttonMonitoring,
x = 0x1,
o = 0x2,
square = 0x4,
triangle = 0x8,
up = 0x400,
down = 0x800,
left = 0x1000,
right = 0x2000,
r1 = 0x40,
r2 = 0x400000,
r3 = 0x100,
l1 = 0x80,
l2 = 0x800000,
l3 = 0x200,
start = 0x10,
select = 0x20
;
 
           unsigned int getMCButtons()
           {
               return *(unsigned int*)(Addresses::buttonMonitoring);
           }
 
           bool IsMCButtonPressed(unsigned int button)
           {
               return (getMCButtons() & button) > 0;
           }
} //1.69






#define PAD(x,s) char unk##x[s]
struct DataFixerUpper;
struct MultiPlayerGameMode;
struct MultiPlayerLevel;
struct LevelRenderer;
struct MultiplayerLocalPlayer;
struct DataItem_ImplIiE;
struct NetworkDataStruct;

struct Vector3Special {//size 0x18
    float x;
    int unk1;
    float y;
    int unk2;
    float z;
    int unk3;
};

struct Vector2 {
    float x,y;
};

struct NetworkDataStruct {
    MultiplayerLocalPlayer *multiplayerLocalPlayer;//0x0
    DataItem_ImplIiE *dataItem_ImplIiE1;//0x0
};

#pragma pack(1)
struct MultiplayerLocalPlayer {//*(int*)(*(int*)0x13FCF3C+0x34)+0x0  for quick reference in prodg
	void* getThisAddress() {
        return (void*)this;
    };
    PAD(0,0x80);//0x0
    Vector2 viewAngles;//0x80 //x has no clamp (-inf to +inf), y goes 90 to -90 (-90 being looking up, 90 being looking down (yes this is correct), 0 being forward)   THIS IS MODIFYABLE AND WILL STICKAROONIE
    PAD(1,0x8);//0x88
    Vector3Special *coords;//0x90  These are desynced from server so best not to modify them
    PAD(2,0x120-0x94);//0x94
    NetworkDataStruct *netData;//0x120
	PAD(3,0x5D8-0x124);//0x124
	unsigned char flyData[4];//0x5D8
	//unsigned int flyData;//0x5D8
	PAD(4,0xC);//0x5DC
	unsigned int XP;//0x5E8
	PAD(5,0x6DC-0x5EC);//0x5EC
	unsigned int invisibility;//0x6DC   - set to 0001F990 on, 0001F810 off
	//0x5D8 is fly
	void setFly(bool enabled) {
		//*(char*)((unsigned int)getThisAddress()+0x5DA) = enabled;
		flyData[2] = enabled;
		flyData[1] = enabled;
	}
	bool getFly() {
		return flyData[2];
	}
	void setInvisibility(bool enabled) {
		if (enabled) {
			invisibility = 0x0001F990; //Update Address 1/69
		} else {
			invisibility = 0x0001F810; //1.69
		}
	}
};
#pragma pack(4)

struct GlobalVariablesStruct {
    DataFixerUpper *dataFixerUpper;//0x0
    MultiPlayerGameMode *multiPlayerGameMode;//0x4
    PAD(0,4);//0x8
    PAD(1,4);//0xC
    unsigned int fov;//0x10
    unsigned int width;//0x14
    unsigned int fov2;//0x18   don't use this one
    unsigned int width2;//0x1C don't use this onen
    PAD(2,4);//0x20
    PAD(3,4);//0x24
    PAD(4,4);//0x28
    MultiPlayerLevel *multiPlayerLevel;//0x2C
    LevelRenderer *levelRenderer;//0x30
    MultiplayerLocalPlayer *multiplayerLocalPlayer;//0x34   muy useful
    PAD(5,4);//0x38
    PAD(6,4);//0x3C
    unsigned int unkWeirdNumber;//0x40
    MultiplayerLocalPlayer *multiplayerLocalPlayer1;//0x44
};


//struct at *(int*)(      *(int*)(      *(int*)(*(int*)0x13FCF3C+0x34)      + 0x120)     + 4)  which is 13DataItem_ImplIiE
struct DataItem_ImplIiE {
    PAD(0,4);//0x0
    PAD(1,4);//0x4
    PAD(2,4);//0x8
    unsigned int movementTypeBitset;//0xC
};

#define globalVariablesStruct ((GlobalVariablesStruct *)*(int*)Addresses::globalVariableStruct)
void toggleFlyMode() {
	if (VALID_ADDR(globalVariablesStruct->multiplayerLocalPlayer)) {
		globalVariablesStruct->multiplayerLocalPlayer->setFly(!globalVariablesStruct->multiplayerLocalPlayer->getFly());
	}
	//0x00A40F14 re-sets it back to 0! nop it!
	//0x00A41440 too!
	//*(unsigned int*)0x00A40F14 = 0x60000000;
	//*(unsigned int*)0x00A41440 = 0x60000000;
}

void toggleMovementBit(int bit, bool enabled) {
	unsigned int og = globalVariablesStruct->multiplayerLocalPlayer->netData->dataItem_ImplIiE1->movementTypeBitset;
	if (enabled) {
		og |= (1<<bit);
	} else {
		og &= !(1<<bit);
	};
	globalVariablesStruct->multiplayerLocalPlayer->netData->dataItem_ImplIiE1->movementTypeBitset = og;
}

void toggleInvisibility(bool *enabled) {
	if (VALID_ADDR(globalVariablesStruct->multiplayerLocalPlayer)) {
		*enabled = !*enabled;
		printf("Setting invisibility: %i\n",*enabled);
		globalVariablesStruct->multiplayerLocalPlayer->setInvisibility(*enabled);
	}
}
/*
REMEMBER THIS:
1 byte - *(char*)0x0000000;
2 bytes - *(short*)0x00000000;
3 bytes - *(float*)0x00000000;
4 bytes - *(int*)0x00000000;
8 bytes - *(double*)0x00000000;
*/

/*  seg001 : 0000000000010374                 stdu      r1, -0x90(r1)
	seg001 : 0000000000010378                 mflr      r0
	seg001 : 000000000001037C                 std       r0, 0xA0(r1)
	seg001 : 0000000000010380                 std       r31, 0x88(r1)
	seg001 : 0000000000010384                 lis       r3, dword_13DBB38@ha
	seg001 : 0000000000010388                 lis       r31, dword_13F9A00@ha
	seg001 : 000000000001038C                 lwz       r3, dword_13DBB38@l(r3)
	seg001 : 0000000000010390                 lwz       r31, dword_13F9A00@l(r31)
	seg001 : 0000000000010394                 std       r30, 0x80(r1)
	seg001 : 0000000000010398                 std       r29, 0x78(r1)
	seg001 : 000000000001039C                 cmpwi     r3, 0
	seg001 : 00000000000103A0                 bne       loc_103E8
	seg001 : 00000000000103A4                 li        r3, 1
	seg001 : 00000000000103A8                 li        r29, 0
	seg001 : 00000000000103AC                 bl        sub_C2436C
	seg001 : 00000000000103B0                 mr        r30, r3
	seg001 : 00000000000103B4                 cmpwi     r30, 0
	seg001 : 00000000000103B8                 beq       loc_103C8
	seg001 : 00000000000103BC                 mr        r3, r30
	seg001 : 00000000000103C0                 bl        sub_891DF4
	seg001 : 00000000000103C4                 mr        r29, r30
	seg001 : 00000000000103C8
	seg001 : 00000000000103C8 loc_103C8 : # CODE XREF : seg001:00000000000103B8j
	seg001 : 00000000000103C8                 lis       r3, dword_13DBB38@ha
	seg001 : 00000000000103CC                 stw       r29, dword_13DBB38@l(r3)
    seg001 : 00000000000103D0                 b         
*/
/*
seg001:0000000000010374 # =============== S U B R O U T I N E =======================================
seg001:0000000000010374
seg001:0000000000010374
seg001:0000000000010374 sub_10374:                              # CODE XREF: seg001:00000000007BF940p
seg001:0000000000010374                                         # seg001:loc_9583F8p
seg001:0000000000010374
seg001:0000000000010374 .set var_18, -0x18
seg001:0000000000010374 .set var_10, -0x10
seg001:0000000000010374 .set var_8, -8
seg001:0000000000010374 .set arg_10,  0x10
seg001:0000000000010374
seg001:0000000000010374                 stdu      r1, -0x90(r1)
seg001:0000000000010378                 mflr      r0
seg001:000000000001037C                 std       r0, 0x90+arg_10(r1)
seg001:0000000000010380                 std       r31, 0x90+var_8(r1)
seg001:0000000000010380 # ---------------------------------------------------------------------------
seg001:0000000000010384               lis       r3, dword_13DBB38@ha
seg001:0000000000010388               lis       r31, dword_13F9A00@ha
seg001:0000000000010394 # ---------------------------------------------------------------------------
seg001:0000000000010394                 std       r30, 0x90+var_10(r1)
seg001:0000000000010398                 std       r29, 0x90+var_18(r1)
seg001:000000000001039C                 cmpwi     r3, 0    //Jump codes
seg001:00000000000103A0                 bne       loc_103E8
seg001:00000000000103A4                 li        r3, 1        //10 00 00 00
seg001:00000000000103A8                 li        r29, 0       //00 00 00 00
seg001:00000000000103AC                 bl        sub_C2436C
seg001:00000000000103B0                 mr        r30, r3
seg001:00000000000103B4                 cmpwi     r30, 0         
seg001:00000000000103B8                 beq       loc_103C8
seg001:00000000000103BC                 mr        r3, r30
seg001:00000000000103C0                 bl        sub_891DF4
seg001:00000000000103C4                 mr        r29, r30
seg001:00000000000103C8
seg001:00000000000103C8 loc_103C8:                              # CODE XREF: sub_10374+44j
seg001:00000000000103C8                 lis       r3, dword_13DBB38@ha
seg001:00000000000103CC                 stw       r29, dword_13DBB38@l(r3)
seg001:00000000000103D0                 b         loc_103E8
seg001:00000000000103D4 # ---------------------------------------------------------------------------
seg001:00000000000103D4                 mr        r31, r3
seg001:00000000000103D8                 mr        r3, r30
seg001:00000000000103DC                 bl        sub_C1EBB8
seg001:00000000000103E0                 mr        r3, r31
seg001:00000000000103E4                 bl        sub_C1C090
seg001:00000000000103E8
seg001:00000000000103E8 loc_103E8:                              # CODE XREF: sub_10374+2Cj
seg001:00000000000103E8                                         # sub_10374+5Cj
seg001:00000000000103E8                 lis       r4, unk_14663EC@h
seg001:00000000000103EC                 slwi      r3, r31, 2         // 02 00 00 00
seg001:00000000000103F0                 addic     r4, r4, unk_14663EC@l
seg001:00000000000103F4                 li        r31, 0
seg001:00000000000103F8                 lwzx      r4, r4, r3
seg001:00000000000103FC                 cmpwi     r4, 0
seg001:0000000000010400                 beq       loc_1040C
seg001:0000000000010404                 addic     r4, r13, -0x6FFC
seg001:0000000000010408                 lwzx      r31, r4, r3
seg001:000000000001040C
seg001:000000000001040C loc_1040C:                              # CODE XREF: sub_10374+8Cj
seg001:000000000001040C                 lis       r3, dword_13D59C0@h
seg001:0000000000010410                 lwz       r3, dword_13D59C0@l(r3)
seg001:0000000000010414                 cmpw      r31, r3
seg001:0000000000010418                 beq       loc_10434
seg001:000000000001041C                 cmpwi     r31, 0
seg001:0000000000010420                 beq       loc_10434
seg001:0000000000010424                 lwz       r3, 0(r31)
seg001:0000000000010428                 bl        sub_C1EB94
seg001:000000000001042C                 mr        r3, r31
seg001:0000000000010430                 bl        sub_C1EBB8
seg001:0000000000010434
seg001:0000000000010434 loc_10434:                              # CODE XREF: sub_10374+A4j
seg001:0000000000010434                                         # sub_10374+ACj
seg001:0000000000010434                 ld        r0, 0x90+arg_10(r1)
seg001:0000000000010438                 mtlr      r0
seg001:000000000001043C                 ld        r29, 0x90+var_18(r1)
seg001:0000000000010440                 ld        r30, 0x90+var_10(r1)
seg001:0000000000010444                 ld        r31, 0x90+var_8(r1)
seg001:0000000000010448                 addi      r1, r1, 0x90
seg001:000000000001044C                 blr
seg001:000000000001044C # End of function sub_10374
*/

/*
int hook8(int r3, int r4, int r5, int r6, int r7) {//callFunctionByIdR4IsANumber
//printf("r3: 0x%X\n",r3);

opd_s sub_233424_t = {0x233424,TOC};
int (*sub_233424)(int r3, int r4, int r5, int r6, int r7) = (int(*)(int,int,int,int,int))&sub_233424_t;
//printf("fix function\n");
char data[] = {0xF8, 0x21, 0xFF, 0x51, 0x7C, 0x08, 0x02, 0xA6, 0xF8, 0x01, 0x00, 0xC0, 0xFB, 0xE1, 0x00, 0xA8};
write_process((void*)0x233424,data,4*4);
//printf("do code\n");

//finding the branch function at 0x518284:
/*int r4 = *(int*)(r3+0x8);
int r6 = *(int*)(r4);
r4 = *(int*)(r6+0x8);
r4 = *(int*)(r4);*/
//yay now we got the branch address... simplifies is:
//int branchAddress = *(int*)(*(int*)(*(int*)(*(int*)(r3 + 0x8)) + 0x8));
//int argForIt = *(int*)(r3 + 0x8);
//opd_s branch_t = {branchAddress,TOC};
//int (*branch)(int r3) = (int(*)(int))&branch;
//int id = branch(argForIt);
/*
//reverse of branchAddress
lwz       r3, 8(r3)
lwz       r4, 0(r3)
lwz       r4, 8(r4)
lwz       r4, 0(r4)
r3 = *(int*)(r3+0x8);
r4 = *(int*)(r3);
r4 = *(int*)(r4+0x8);
r4 = *(int*)(r4);
which is:
address = *(int*)(*(int*)(*(int*)(*(int*)(r3+0x8))+0x8));
*/
/*int secondBranchAddress = *(int*)(*(int*)(*(int*)(*(int*)(argForIt + 0x8)) + 0x8));
printf("r3: 0x%X, branchAddress: 0x%X, argForIt: 0x%X, secondBranchAddress: 0x%X\n", r3, branchAddress, argForIt, secondBranchAddress);


functionInfo info;
info.functionId = 8;
info.unkfunctionArg1 = *(int*)(0x00D02E3E50 + 0);   //the stack for the value read at 0x233460 which is r3 for the other function. Best I could do.
info.unkfunctionArg1 = *(int*)(0x00D02E3E50 + 4);

printf("SetHealth address: 0x%X\n", getFunctionById(info));

//sub_ED258C(buf,functionsArray)


/*
r3: 0x32CE46A0
branchAddress: 0x257358, argForIt: 0x326A7D20


//printf("SetHealth address: 0x%X\n",getFunctionById(8));
//printf("Ran some code! lol\n");

*/