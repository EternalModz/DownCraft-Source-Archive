


#include "stdafx.h"

#include <cellstatus.h>
#include <sys/prx.h>
#include "MainMenuFunc.h"
#include "NewDeleteOverride.h"



SYS_MODULE_INFO( Minecraft_Simple_Base, 0, 1, 1);
SYS_MODULE_START( _Minecraft_Simple_Base_prx_entry );

SYS_LIB_DECLARE_WITH_STUB( LIBNAME, SYS_LIB_AUTO_EXPORT, STUBNAME );
SYS_LIB_EXPORT( _Minecraft_Simple_Base_export_function, LIBNAME );

// An exported function is needed to generate the project's PRX stub export library
/*void gameRender_Hook(uint32_t r3, uint32_t r4) {
	gameRender_Stub(r3, r4);

	//mc = (TheMinecraft*)(mcOfs);
	//menuMon();
	//PlayerInstructions();
	RenderMenu();
	//menu();
}*/
extern "C" int _Minecraft_Simple_Base_export_function(void)
{
	//HookFunctionStart(gameRenderHook, *(uint32_t*)(gameRender_Hook), *(uint32_t*)(gameRender_Stub));
    return CELL_OK;
}

extern "C" int _Minecraft_Simple_Base_prx_entry(void)
{
	//HookFunctionStart(gameRenderHook, *(uint32_t*)(gameRender_Hook), *(uint32_t*)(gameRender_Stub));
    return SYS_PRX_RESIDENT;
}
