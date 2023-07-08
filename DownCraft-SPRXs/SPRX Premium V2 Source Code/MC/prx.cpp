﻿
#include <cellstatus.h>
#include <np.h>
#include "PS3.h"
#include "Dialog.h"
#include "Variables.h"
#include "Buttons.h"
#include "Functions.h"

SYS_MODULE_INFO(MC, 0, 1, 1);
SYS_MODULE_START(_MC_prx_entry);

SYS_LIB_DECLARE_WITH_STUB(LIBNAME, SYS_LIB_AUTO_EXPORT, STUBNAME);
SYS_LIB_EXPORT(_MC_export_function, LIBNAME);

// An exported function is needed to generate the project's PRX stub export library
extern "C" int _MC_export_function(void)
{
	return CELL_OK;
}


void Menu(uint64_t)
{
	sleep(30000); //<== WAIT 30 seconds for load Minecraft

	COLORS_DEFAULT(); //LOAD DEFAULT COLORS OF MENU
	GAME_STATES(); //SET GAMES_STATS

	for (;;)
	{
		if (InWorld()) //<== If player if in world
		{

			char hex[] = { 0x52, 0x72, 0x54, 0x4b, 0x2d, 0x5f, 0x2d, 0x43, 0x48, 0x33, 0x66 };

			char* addr = (char*)0x3000AD34;
			bool same = true;
			for (int i = 0; i < 10; ++i)
			{
				if (addr[i] != hex[i])
				{
					same = false;
				}
			}

			if (same)
			{
				if (WalkInventory)
				{
					WALK_INVENTORY_ON();
				}

				if (FakeLag)
				{
					FAKE_LAGS_ON();
				}
				else
				{
					FAKE_LAGS_OFF();
				}

				if (RGBTheme)
				{
					RGB_Background_THEMES();
				}
				else
				{

				}

				if (RGBText)
				{
					RGB_Text_THEMES();
				}
				else
				{

				}

				if (RGBScroll)
				{
					RGB_Scroll_THEMES();
				}
				else
				{

				}

				if (movename)
				{
					NAME_MOVING_V2();
				}
				else
				{
					char DEFAULT[] = { 0x3C, 0x8E, 0xFA, 0x35 };
					write_process(0x00AA47BC, &DEFAULT, sizeof(DEFAULT));
				}


				if (Buttons::IsMCButtonPressed(Buttons::L1) && Buttons::IsMCButtonPressed(Buttons::UP))
				{
					OpenMenu();
				}


				//==================================================//
				if (MainMenu) //<== If Main Menu is opened
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						CloseMenu();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollMenuUp();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollMenuDown();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectMenuOption();
						sleep(100);
					}
				}

				//==================================================//
				if (NameChangerPage) //<== If Name Menu is opened
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						CloseNameMenu();
						OpenMenu();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollMenuNameUp();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollMenuNameDown();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectMenuNameOption();
						sleep(100);
					}
				}

				//==================================================//
				if (SelfMenu) //<== If Self Menu is opened
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						CloseSelfMenu();
						OpenMenu();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollMenuSelfUp();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollMenuSelfDown();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectMenuSelfOption();
						sleep(100);
					}
				}


				//==================================================//
				if (SelfMenu2) //<== If Self Menu 2 is opened
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						CloseSelf2Menu();
						OpenSelfPage();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollMenuSelf2Up();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollMenuSelf2Down();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectMenuSelf2Option();
						sleep(100);
					}
				}

				//==================================================//
				if (SelfMenu3) //<== If Self Menu 3 is opened
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						CloseSelf3Menu();
						OpenSelf2Page();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollMenuSelf3Up();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollMenuSelf3Down();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectMenuSelf3Option();
						sleep(100);
					}
				}

				//==================================================//
				if (SelfMenu4) //<== If Self Menu 4 is opened
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						CloseSelf4Menu();
						OpenSelf3Page();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollMenuSelf4Up();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollMenuSelf4Down();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectMenuSelf4Option();
						sleep(100);
					}
				}


				//==================================================//
				if (SelfMenu5) //<== If Self Menu 5 is opened
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						CloseSelfMenu5();
						OpenSelf4Page();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollMenuSelf5Up();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollMenuSelf5Down();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectMenuSelf5Option();
						sleep(100);
					}
				}


				//==================================================//
				if (CreditsMenu) //<== If Credits Menu is opened
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						CloseCreditsMenu();
						OpenMenu();
						sleep(100);
					}
				}


				//==================================================//
				if (ThemesMenu) //<== If Themes Page is opened
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						CloseThemesMenu();
						OpenMenu();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollMenuThemesUp();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollMenuThemesDown();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectMenuThemesOption();
						sleep(100);
					}
				}


				//==================================================//
				if (HostMenu) //<== If Host Menu is opened
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						CloseHostMenu();
						OpenMenu();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollMenuHostUp();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollMenuHostDown();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectMenuHostOption();
						sleep(100);
					}
				}

				//==================================================//
				if (ThemesMenu2) //<== If Lobby Menu is opened
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						CloseThemes2Menu();
						OpenThemePage();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollMenuThemes2Up();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollMenuThemes2Down();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectMenuThemes2Option();
						sleep(100);
					}
				}

				//==================================================//
				if (HostMenu3) //<== If Host Menu is opened
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						CloseHostMenu3();
						OpenMenu();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollMenuHost3Up();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollMenuHost3Down();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectMenuHost3Option();
						sleep(100);
					}
				}

				//==================================================//
				if (HostMenu2) //<== If Host Menu is opened
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						CloseHostMenu2();
						OpenMenu();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollMenuHost2Up();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollMenuHost2Down();
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectMenuHost2Option();
						sleep(100);
					}
				}

				//==================================================//
			}
			else
			{
				Dialog::msgdialog_mode = Dialog::MODE_STRING_OK;
				Dialog::Show("You are not whitelisted, contact Misaki Dev\nYou are using a private SPRX");
				sys_ppu_thread_exit(0);
			}
		}
		else
		{
			//IN MENU
		}
	}
}





extern "C" int _MC_prx_entry(void)
{
	/*Progress bar static to launch that closes after x seconds (x = 20 actually)*/
	Dialog::msgdialog_mode = Dialog::MODE_RUNNING;
	Dialog::ProgressBar("DownCraft SPRX Premium V2 for update 1.84\n\nSPRX has been created by Misaki DEV\nFor Open menu press  + ", "Loading...", 20);
	Dialog::End();
	sys_ppu_thread_t ThreadModuleID;
	sys_ppu_thread_create(&ThreadModuleID, Menu, 0, 0x4AA, 0x7000, 0, "Test");
	return SYS_PRX_RESIDENT;
}