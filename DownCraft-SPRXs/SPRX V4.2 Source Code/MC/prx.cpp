
#include "Includes.h"

SYS_MODULE_INFO( DownCraftSPRX, 0, 1, 1);
SYS_MODULE_START( _DownCraftSPRX_prx_entry );
SYS_MODULE_STOP(_DownCraftSPRX_prx_stop);

void callThreadFromEBOOT(uint64_t)
{
	__asm("lis 3, 0x14C;");//oris r2, r2, 0x14C
	__asm("lwz 3, 0(3);");
	__asm("cmpwi 3, 0x3618;");//ori r2, r2, 0x361B
	__asm("beq end;");
	__asm("end:;");
}

void gameRender_Hook(uint32_t r3, uint32_t r4) 
{
	INITIALIZE_START();
	//misakiii();
	gameRender_Stub(r3, r4);
	mc = (TheMinecraft*)(mcOfs);

	if (xKzLAOD015Ax11)
	{
		if (InitializeSPRX)
			*(int*)0x0155847C = 0x00000000; //Usable HUD
		Inject();
	}
}

extern "C" int _DownCraftSPRX_prx_entry(void)
{	
	Dialog::msgdialog_mode = Dialog::MODE_RUNNING;
	Dialog::ProgressBar("DownCraft SPRX V4.5\nOpen menu press  + \nMenu made by Misakiii !", "Loading...", 20);
	Dialog::End();

	HookFunctionStart(gameRenderHook, *(uint32_t*)(gameRender_Hook), *(uint32_t*)(gameRender_Stub));
	InstallHooks();

	INITIALIZE_SPRX = true;
	return SYS_PRX_RESIDENT;
}
extern "C" int _DownCraftSPRX_prx_stop(void)
{
	UninstallHooks();
	return SYS_PRX_RESIDENT;
}