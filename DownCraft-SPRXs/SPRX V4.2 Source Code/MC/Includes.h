#pragma once

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

#include "PS3.h"
#include "Vector.h"
#include "dialog.h"
#include "Buttons.h"
#include "UI.h"
#include "struct.h"
#include "var.h"
#include "IDs.h"
#include "GameFunctions.h"
#include "Functions.h"
#include "Hooking.h"
#include "OSK.h"
#include "Modules.h"
#include "DrawHudsFunctions.h"
#include "HudsFunctions.h"
#include "Offsets.h"
#include "SubMenus.h"
#include "Options.h"
#include "LoopFunctions.h"
#include "menu.h"
#include "Startup.h"

#include <sys/types.h>
#include <sys/stat.h>
#include <sys/paths.h>
#include <sys/fs.h>
#include <sys/fs_external.h>
#include <pthread.h>
#include <cell/cell_fs.h>
#include <cell/fs/cell_fs_file_api.h>