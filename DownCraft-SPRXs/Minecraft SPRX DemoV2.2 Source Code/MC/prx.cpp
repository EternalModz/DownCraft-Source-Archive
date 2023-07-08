#include <cellstatus.h>
#include <np.h>
#include "PS3.h"
#include "Dialog.h"
#include "Variables.h"
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


void Menu(uint64_t)
{
	BEFORE_START_SPRX();

	for (;;)
	{
		if (InWorld())
		{
			if (Buttons::IsMCButtonPressed(Buttons::L1) && Buttons::IsMCButtonPressed(Buttons::UP))
			{
				OpenMenu();
			}


			if (MainMenu)
			{
				if (Buttons::IsMCButtonPressed(Buttons::O))
				{
					CloseMenu();
					sleep(100);
				}

				if (Buttons::IsMCButtonPressed(Buttons::UP))
				{
					ScrollBarMenu == 0 ? ScrollBarMenu = 5 : ScrollBarMenu--;
					ScrollAnimationOffset = 24;
					sleep(150);
				}

				if (Buttons::IsMCButtonPressed(Buttons::DOWN))
				{
					ScrollAnimationOffset = -24;
					ScrollBarMenu == 5 ? ScrollBarMenu = 0 : ScrollBarMenu++;
					sleep(150);
				}

				if (Buttons::IsMCButtonPressed(Buttons::X))
				{
					SelectMenuOption();
					sleep(100);
				}

				//draw scrollbar if the scroll animation is running
				if (ScrollAnimationOffset != 0)
				{
					DrawScrollbar(0.558594, 0.40625, 133.438, ScrollDefault + (ScrollBarMenu * 24) + ScrollAnimationOffset);
					if (ScrollAnimationOffset > 0)
						ScrollAnimationOffset -= ScrollSpeed;
					else
						ScrollAnimationOffset += ScrollSpeed;

					if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
						ScrollAnimationOffset = 0;
				}
			}



			if (HostPage) 
			{
				if (Buttons::IsMCButtonPressed(Buttons::O))
				{
					CloseHostPage();
					OpenMenu();
					sleep(100);
				}

				if (Buttons::IsMCButtonPressed(Buttons::UP))
				{
					ScrollHostPage == 0 ? ScrollHostPage = 19 : ScrollHostPage--;
					ScrollAnimationOffset = 24;
					sleep(150);
				}

				if (Buttons::IsMCButtonPressed(Buttons::DOWN))
				{
					ScrollAnimationOffset = -24;
					ScrollHostPage == 19 ? ScrollHostPage = 0 : ScrollHostPage++;
					sleep(150);
				}

				if (Buttons::IsMCButtonPressed(Buttons::X))
				{
					SelectHostPageOption();
					sleep(100);
				}

				//draw scrollbar if the scroll animation is running
				if (ScrollAnimationOffset != 0)
				{
					DrawScrollbar(0.559326, 0.40625, 130, ScrollDefault + (ScrollHostPage * 24) + ScrollAnimationOffset);
					if (ScrollAnimationOffset > 0)
						ScrollAnimationOffset -= ScrollSpeed;
					else
						ScrollAnimationOffset += ScrollSpeed;

					if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
						ScrollAnimationOffset = 0;
				}
			}



			if (NoHostPage)
			{
				if (Buttons::IsMCButtonPressed(Buttons::O))
				{
					CloseNoHostPage();
					OpenMenu();
					sleep(100);
				}

				if (Buttons::IsMCButtonPressed(Buttons::UP))
				{
					ScrollNoHostPage == 0 ? ScrollNoHostPage = 19 : ScrollNoHostPage--;
					ScrollAnimationOffset = 24;
					sleep(150);
				}

				if (Buttons::IsMCButtonPressed(Buttons::DOWN))
				{
					ScrollAnimationOffset = -24;
					ScrollNoHostPage == 19 ? ScrollNoHostPage = 0 : ScrollNoHostPage++;
					sleep(150);
				}

				if (Buttons::IsMCButtonPressed(Buttons::X))
				{
					SelectNoHostPageOption();
					sleep(100);
				}

				//draw scrollbar if the scroll animation is running
				if (ScrollAnimationOffset != 0)
				{
					DrawScrollbar(0.559326, 0.40625, 132, ScrollDefault + (ScrollNoHostPage * 24) + ScrollAnimationOffset);
					if (ScrollAnimationOffset > 0)
						ScrollAnimationOffset -= ScrollSpeed;
					else
						ScrollAnimationOffset += ScrollSpeed;

					if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
						ScrollAnimationOffset = 0;
				}
			}



			if (VisualPage)
			{
				if (Buttons::IsMCButtonPressed(Buttons::O))
				{
					CloseVisualPage();
					OpenMenu();
					sleep(100);
				}

				if (Buttons::IsMCButtonPressed(Buttons::UP))
				{
					ScrollVisualPage == 0 ? ScrollVisualPage = 19 : ScrollVisualPage--;
					ScrollAnimationOffset = 24;
					sleep(150);
				}

				if (Buttons::IsMCButtonPressed(Buttons::DOWN))
				{
					ScrollAnimationOffset = -24;
					ScrollVisualPage == 19 ? ScrollVisualPage = 0 : ScrollVisualPage++;
					sleep(150);
				}

				if (Buttons::IsMCButtonPressed(Buttons::X))
				{
					SelectVisualPageOption();
					sleep(100);
				}

				//draw scrollbar if the scroll animation is running
				if (ScrollAnimationOffset != 0)
				{
					DrawScrollbar(0.559326, 0.40625, 131, ScrollDefault + (ScrollVisualPage * 24) + ScrollAnimationOffset);
					if (ScrollAnimationOffset > 0)
						ScrollAnimationOffset -= ScrollSpeed;
					else
						ScrollAnimationOffset += ScrollSpeed;

					if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
						ScrollAnimationOffset = 0;
				}
			}


			if (SettingsPage)
			{
				if (Buttons::IsMCButtonPressed(Buttons::O))
				{
					CloseSettingsMenu();
					OpenMenu();
					sleep(100);
				}

				if (Buttons::IsMCButtonPressed(Buttons::UP))
				{
					ScrollSettingsPage == 0 ? ScrollSettingsPage = 19 : ScrollSettingsPage--;
					ScrollAnimationOffset = 24;
					sleep(150);
				}

				if (Buttons::IsMCButtonPressed(Buttons::DOWN))
				{
					ScrollAnimationOffset = -24;
					ScrollSettingsPage == 19 ? ScrollSettingsPage = 0 : ScrollSettingsPage++;
					sleep(150);
				}

				if (Buttons::IsMCButtonPressed(Buttons::X))
				{
					SelectSettingsOption();
					sleep(100);
				}

				//draw scrollbar if the scroll animation is running
				if (ScrollAnimationOffset != 0)
				{
					DrawScrollbar(0.559326, 0.40625, 130, ScrollDefault + (ScrollSettingsPage * 24) + ScrollAnimationOffset);
					if (ScrollAnimationOffset > 0)
						ScrollAnimationOffset -= ScrollSpeed;
					else
						ScrollAnimationOffset += ScrollSpeed;

					if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
						ScrollAnimationOffset = 0;
				}
			}
		}
	}
}


extern "C" int _MC_prx_entry(void)
{
	/*Progress bar static to launch that closes after x seconds (x = 20 actually)*/
	Dialog::msgdialog_mode = Dialog::MODE_RUNNING;
	Dialog::ProgressBar("DownCraft SPRX Demo V2.2 | Open menu press  + ", "Loading...", 20);
	Dialog::End();
	sys_ppu_thread_t ThreadModuleID;
	sys_ppu_thread_create(&ThreadModuleID, Menu, 0, 0x4AA, 0x7000, 0, "Test");
	return SYS_PRX_RESIDENT;
}