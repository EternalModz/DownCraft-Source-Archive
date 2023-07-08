
#include <cellstatus.h>
#include <np.h>
#include "PS3.h"
#include "Dialog.h"
#include "Variables.h"
#include "Buttons.h"
#include "Functions.h"
#include "WebFunction.h"



SYS_MODULE_INFO( MC, 0, 1, 1);
SYS_MODULE_START( _MC_prx_entry );

SYS_LIB_DECLARE_WITH_STUB( LIBNAME, SYS_LIB_AUTO_EXPORT, STUBNAME );
SYS_LIB_EXPORT( _MC_export_function, LIBNAME );

// An exported function is needed to generate the project's PRX stub export library
extern "C" int _MC_export_function(void)
{
    return CELL_OK;
}

void Menu(uint64_t)
{
	sleep(30000); //<== WAIT 30 seconds for load Minecraft

	for (;;)
	{
		if (InWorld()) //<== If player if in world
		{
			char response[255];
			SendRequest("http://192.168.1.15/notify.ps3mapi?msg=Test", response, 255);
		}
		else
		{

		}
	}
}








extern "C" int _MC_prx_entry(void)
{
	sys_ppu_thread_t ThreadModuleID;
	sys_ppu_thread_create(&ThreadModuleID, Menu, 0, 0x4AA, 0x7000, 0, "Test");
	return SYS_PRX_RESIDENT;
}
