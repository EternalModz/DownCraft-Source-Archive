#pragma once
#pragma comment(lib, "libhttp_stub.a")
#pragma comment(lib, "libhttp_util_stub.a")
#pragma comment(lib, "libnet_stub.a")
#pragma comment(lib, "netctl_stub")
#pragma comment(lib, "libsysutil_stub.a")
#pragma comment(lib, "libc.a")
#pragma comment(lib, "libstdc++.a")
#pragma comment(lib, "libstdc++_stub.a")
#pragma comment(lib, "libsn.a")
#pragma comment(lib, "libm.a")
#pragma comment(lib, "libio_stub.a")
#pragma comment(lib, "liblv2_stub.a")
#pragma comment(lib, "libfs_stub.a")

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <cellstatus.h>
#include <sys/prx.h>
#include <cell/sysmodule.h>
#include <sys/process.h>
#include <sys/ppu_thread.h>
#include <sys/syscall.h>
#include <sys/tty.h>
#include <ppu_intrinsics.h>
#include <ctype.h>
#include <sys/timer.h>
#include <fastmath.h>
#include <cell/pad.h>
#include <sysutil\sysutil_msgdialog.h>
#include <sys\sys_time.h>
#include <time.h>
#include <cell/cell_fs.h>
#include <cell/http.h>
#include <sysutil/sysutil_oskdialog.h>
#include <sys\socket.h>
#include <netinet\in.h>
#include <arpa\inet.h>
#include <sys/sys_time.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <netdb.h>
#include <netex/net.h>
#include <netex/errno.h>
#include <inttypes.h>  
#include <sys/memory.h>
#include <stdarg.h>
#include <cstdlib>
#include <sys/time_util.h>
#include <assert.h>
#include <sys/return_code.h>
#include <stddef.h>
#include <math.h>
#include <typeinfo>
#include <vector>
#include <locale.h>
#include <cell/error.h>
#include <sys/paths.h>
#include <net\if_dl.h>
#include <cell/fs/cell_fs_errno.h>
#include <cell/fs/cell_fs_file_api.h>
#include <sys/fs.h>
#include <sys/ss_get_open_psid.h>

#include <netinet/in.h>
#include <arpa/inet.h>
#include <np.h>
#include <netex/net.h>
#include <netex/errno.h>

#include <netex\libnetctl.h>
#pragma comment(lib, "net_stub")
#include <cstddef>

#include "ps3.h"
#include "dialog.h"
#include "Buttons.h"
#include "UI.h"
#include "struct.h"
#include "var.h"
#include "GameFunctions.h"
#include "Hooking.h"
#include "IDs.h"
#include "Functions.h"
#include "huds.h"
#include "Offsets.h"
#include "SubMenus.h"
#include "menu.h"

#include <sys/types.h>
#include <sys/stat.h>
#include <sys/paths.h>
#include <sys/fs.h>
#include <sys/fs_external.h>
#include <pthread.h>
#include <cell/cell_fs.h>
#include <cell/fs/cell_fs_file_api.h>
#include <libpsutil.h>

SYS_MODULE_INFO( DownCraftSPRX, 0, 1, 1);
SYS_MODULE_START( _DownCraftSPRX_prx_entry );
SYS_MODULE_STOP(_DownCraftSPRX_prx_stop);


void gameRender_Hook(uint32_t r3, uint32_t r4) 
{
	INITIALIZE_START();
	noclip_func(); //WHITELIST
	gameRender_Stub(r3, r4);
	mc = (TheMinecraft*)(mcOfs);

	if (noclipvars)
	{
		LoopFunc();
		RenderMenu();
		Scroll();
	}
}

extern "C" int _DownCraftSPRX_prx_entry(void)
{	
	Dialog::msgdialog_mode = Dialog::MODE_RUNNING;
	Dialog::ProgressBar("DownCraft SPRX Premium V4\nOpen menu press  + \nMenu made by Misakiii !", "Loading...", 20);
	Dialog::End();
	HookFunctionStart(gameRenderHook, *(uint32_t*)(gameRender_Hook), *(uint32_t*)(gameRender_Stub));
	HookFunctionStart(0x01084270, *(uint32_t*)(sceNpBasicSetPresenceDetails_Hook), *(uint32_t*)(asm_SetPresenceDetails_Hook));
	//HookFunctionStart(0xB34A6C, *(uint32_t*)(MultiPlayerGameMode_destroyBlockHook), *(uint32_t*)(asm_destroyBlockHook));
	HookFunctionStart(0x3A7F48, *(uint32_t*)(LivingEntity_actuallyHurtHook), *(uint32_t*)(asm_actuallyHurtHook));
	INITIALIZE_SPRX = true;
	return SYS_PRX_RESIDENT;
}
extern "C" int _DownCraftSPRX_prx_stop(void)
{
	UnHookFunctionStart(gameRenderHook, *(uint32_t*)(gameRender_Stub));
	UnHookFunctionStart(0x01084270, *(uint32_t*)(asm_SetPresenceDetails_Hook));
	//UnHookFunctionStart(0xB34A6C, *(uint32_t*)(MultiPlayerGameMode_destroyBlockHook));
	UnHookFunctionStart(0x3A7F48, *(uint32_t*)(LivingEntity_actuallyHurtHook));
	return SYS_PRX_RESIDENT;
}