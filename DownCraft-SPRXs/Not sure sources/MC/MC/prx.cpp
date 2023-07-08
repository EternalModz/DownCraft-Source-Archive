/*
This SPRX Mod Menu for Minecraft PS3 Update 1.84 was created by Misaki, all credits go to him.
If you using this SPRX for edit / remake your own SPRX, please don't remove my credit !

DownCraft | 2018 - 2021
*/

#include <cellstatus.h>
#include <sys/prx.h>

#include "Dialog.h"
#include "PS3.h"
#include "Buttons.h"
#include "Functions.h"


SYS_MODULE_INFO( MC, 0, 1, 1);
SYS_MODULE_START( _MC_prx_entry );

SYS_LIB_DECLARE_WITH_STUB( LIBNAME, SYS_LIB_AUTO_EXPORT, STUBNAME );
SYS_LIB_EXPORT( _MC_export_function, LIBNAME );

// An exported function is needed to generate the project's PRX stub export library
extern "C" int _MC_export_function(void)
{
    return CELL_OK;
}

//Thread Menu

void Menu(uint64_t)
{
	BEFORE_START_SPRX();

	for (;;)
	{
		//if buttons L1 + UP is pressed at the same time
		if (Buttons::IsMCButtonPressed(Buttons::L1) && Buttons::IsMCButtonPressed(Buttons::UP)) 
		{
			//Open the menu functions
			OpenMenu();
		}

		if (MainMenu)
		{
			if (Buttons::IsMCButtonPressed(Buttons::O))
			{

				sleep(100);
			}

			if (Buttons::IsMCButtonPressed(Buttons::UP))
			{

				sleep(100);
			}

			if (Buttons::IsMCButtonPressed(Buttons::DOWN))
			{

				sleep(100);
			}

			if (Buttons::IsMCButtonPressed(Buttons::X))
			{

				sleep(100);
			}
		}
	}
}



extern "C" int _MC_prx_entry(void)
{
	/*Progress bar static to launch that closes after x seconds (x = 20 actually)*/
	Dialog::msgdialog_mode = Dialog::MODE_RUNNING;
	Dialog::ProgressBar("DownCraft SPRX", "Loading...", 20);
	Dialog::End();
	sys_ppu_thread_t ThreadModuleID;
	sys_ppu_thread_create(&ThreadModuleID, Menu, 0, 0x4AA, 0x7000, 0, "Test");
	return SYS_PRX_RESIDENT;
}
