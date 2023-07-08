#include <cellstatus.h>
#include <np.h>
#include "Offsets.h"
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
	INITIALIZE_START();

	for (;;)
	{
		if (InWorld())
		{
            #pragma region "WHITELIST PLAYERS"

			WHITELIST();

            #pragma endregion
			
			if (WhitelistCheck == true)
			{
				if (Buttons::IsMCButtonPressed(Buttons::L1) && Buttons::IsMCButtonPressed(Buttons::UP))
				{
					OpenMenu(true);
					SLIDE_ANIM();
				}

                #pragma region "LOOP AND FUNCS"

				BEDROCK_UI();

				if (InventoryCreaTumble)
				{
					if (Buttons::IsMCButtonPressed(Buttons::L1) && Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						if (!InventoryCreaTumbleBind)
						{
							*(int*)0x00AD8480 = 0x41820024;
							*(int*)0x0098871C = 0x38600001;
							*(int*)0x002F0348 = 0x38800001;
							*(int*)0x002F0398 = 0x38800000;
							OPTION_TOGGLE(true);
							InventoryCreaTumbleBind = true;
						}
						else
						{
							*(int*)0x00AD8480 = 0x40820024;
							*(int*)0x0098871C = 0x38600000;
							*(int*)0x002F0348 = 0x38800000;
							*(int*)0x002F0398 = 0x38800001;
							OPTION_TOGGLE(false);
							InventoryCreaTumbleBind = false;
						}
					}
				}

                #pragma endregion

                #pragma region "MENU PAGE FUNCS"

				if (MainMenu)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						OpenMenu(false);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollMainMenu == 0 ? ScrollMainMenu = 7 : ScrollMainMenu--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollMainMenu == 7 ? ScrollMainMenu = 0 : ScrollMainMenu++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectOpenMenu();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 127.5, ScrollDefault + (ScrollMainMenu * 24) + ScrollAnimationOffset);
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
						HostMenu(false);
						sleep(100);
						OpenMenu(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollHostMenu == 0 ? ScrollHostMenu = 18 : ScrollHostMenu--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollHostMenu == 18 ? ScrollHostMenu = 0 : ScrollHostMenu++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectHostMenu();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 132.438, ScrollDefault + (ScrollHostMenu * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (HostPage1)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						HostMenu1(false);
						sleep(100);
						HostMenu(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollHostMenu1 == 0 ? ScrollHostMenu1 = 18 : ScrollHostMenu1--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollHostMenu1 == 18 ? ScrollHostMenu1 = 0 : ScrollHostMenu1++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectHostMenu1();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 122.5, ScrollDefault + (ScrollHostMenu1 * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (HostPage2)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						HostMenu2(false);
						sleep(100);
						HostMenu1(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollHostMenu2 == 0 ? ScrollHostMenu2 = 18 : ScrollHostMenu2--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollHostMenu2 == 18 ? ScrollHostMenu2 = 0 : ScrollHostMenu2++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectHostMenu2();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 128.438, ScrollDefault + (ScrollHostMenu2 * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (HostPage3)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						HostMenu3(false);
						sleep(100);
						HostMenu2(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollHostMenu3 == 0 ? ScrollHostMenu3 = 18 : ScrollHostMenu3--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollHostMenu3 == 18 ? ScrollHostMenu3 = 0 : ScrollHostMenu3++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectHostMenu3();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 128.438, ScrollDefault + (ScrollHostMenu3 * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (NonHostPage)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						NonHostMenu(false);
						sleep(100);
						OpenMenu(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollNonHostMenu == 0 ? ScrollNonHostMenu = 18 : ScrollNonHostMenu--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollNonHostMenu == 18 ? ScrollNonHostMenu = 0 : ScrollNonHostMenu++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectNonHost();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 130.438, ScrollDefault + (ScrollNonHostMenu * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (NonHostPage1)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						NonHostMenu1(false);
						sleep(100);
						NonHostMenu(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollNonHostMenu1 == 0 ? ScrollNonHostMenu1 = 18 : ScrollNonHostMenu1--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollNonHostMenu1 == 18 ? ScrollNonHostMenu1 = 0 : ScrollNonHostMenu1++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectNonHost1();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 133.438, ScrollDefault + (ScrollNonHostMenu1 * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (NonHostPage2)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						NonHostMenu2(false);
						sleep(100);
						NonHostMenu1(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollNonHostMenu2 == 0 ? ScrollNonHostMenu2 = 18 : ScrollNonHostMenu2--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollNonHostMenu2 == 18 ? ScrollNonHostMenu2 = 0 : ScrollNonHostMenu2++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectNonHost2();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 133.438, ScrollDefault + (ScrollNonHostMenu2 * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (NonHostPage3)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						NonHostMenu3(false);
						sleep(100);
						NonHostMenu2(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollNonHostMenu3 == 0 ? ScrollNonHostMenu3 = 18 : ScrollNonHostMenu3--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollNonHostMenu3 == 18 ? ScrollNonHostMenu3 = 0 : ScrollNonHostMenu3++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectNonHost3();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 133.438, ScrollDefault + (ScrollNonHostMenu3 * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (NonHostPage4)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						NonHostMenu4(false);
						sleep(100);
						NonHostMenu3(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollNonHostMenu4 == 0 ? ScrollNonHostMenu4 = 18 : ScrollNonHostMenu4--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollNonHostMenu4 == 18 ? ScrollNonHostMenu4 = 0 : ScrollNonHostMenu4++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectNonHost4();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 133.438, ScrollDefault + (ScrollNonHostMenu4 * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (NonHostPage5)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						NonHostMenu5(false);
						sleep(100);
						NonHostMenu4(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollNonHostMenu5 == 0 ? ScrollNonHostMenu5 = 18 : ScrollNonHostMenu5--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollNonHostMenu5 == 18 ? ScrollNonHostMenu5 = 0 : ScrollNonHostMenu5++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectNonHost5();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 133.438, ScrollDefault + (ScrollNonHostMenu5 * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (LobbyPage)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						LobbyMenu(false);
						sleep(100);
						OpenMenu(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollLobbyMenu == 0 ? ScrollLobbyMenu = 18 : ScrollLobbyMenu--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollLobbyMenu == 18 ? ScrollLobbyMenu = 0 : ScrollLobbyMenu++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectLobby();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 117.719, ScrollDefault + (ScrollLobbyMenu * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (LobbyPage1)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						LobbyMenu1(false);
						sleep(100);
						LobbyMenu(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollLobbyMenu1 == 0 ? ScrollLobbyMenu1 = 18 : ScrollLobbyMenu1--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollLobbyMenu1 == 18 ? ScrollLobbyMenu1 = 0 : ScrollLobbyMenu1++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectLobby1();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 123.375, ScrollDefault + (ScrollLobbyMenu1 * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (DrawPage)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						DrawMenu(false);
						sleep(100);
						LobbyMenu1(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollDrawMenu == 0 ? ScrollDrawMenu = 18 : ScrollDrawMenu--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollDrawMenu == 18 ? ScrollDrawMenu = 0 : ScrollDrawMenu++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectDraw();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 133.438, ScrollDefault + (ScrollDrawMenu * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (ItemsOn2HandPage)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						ItemsOn2Hand(false);
						sleep(100);
						LobbyMenu1(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollItemsOn2Hand == 0 ? ScrollItemsOn2Hand = 18 : ScrollItemsOn2Hand--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollItemsOn2Hand == 18 ? ScrollItemsOn2Hand = 0 : ScrollItemsOn2Hand++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectItemsOn2Hand();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 133.438, ScrollDefault + (ScrollItemsOn2Hand * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (DimensionChangerPage)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						DimensionChanger(false);
						sleep(100);
						LobbyMenu1(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollDimensionChanger == 0 ? ScrollDimensionChanger = 18 : ScrollDimensionChanger--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollDimensionChanger == 18 ? ScrollDimensionChanger = 0 : ScrollDimensionChanger++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectDimensionChanger();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 124.469, ScrollDefault + (ScrollDimensionChanger * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (BlockSwapperPage)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						BlockSwapper(false);
						sleep(100);
						LobbyMenu1(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollBlockSwapper == 0 ? ScrollBlockSwapper = 18 : ScrollBlockSwapper--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollBlockSwapper == 18 ? ScrollBlockSwapper = 0 : ScrollBlockSwapper++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectBlockSwapper();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 122.498, ScrollDefault + (ScrollBlockSwapper * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (ItemsSwapperPage)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						ItemsSwapper(false);
						sleep(100);
						LobbyMenu1(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollItemsSwapper == 0 ? ScrollItemsSwapper = 18 : ScrollItemsSwapper--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollItemsSwapper == 18 ? ScrollItemsSwapper = 0 : ScrollItemsSwapper++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectItemsSwapper();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 113.498, ScrollDefault + (ScrollItemsSwapper * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (AddEffectPage)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						AddEffect(false);
						sleep(100);
						LobbyMenu1(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollAddEffect == 0 ? ScrollAddEffect = 18 : ScrollAddEffect--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollAddEffect == 18 ? ScrollAddEffect = 0 : ScrollAddEffect++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectAddEffect();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 113.498, ScrollDefault + (ScrollAddEffect * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (AddEffectPage1)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						AddEffect1(false);
						sleep(100);
						AddEffect(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollAddEffect1 == 0 ? ScrollAddEffect1 = 18 : ScrollAddEffect1--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollAddEffect1 == 18 ? ScrollAddEffect1 = 0 : ScrollAddEffect1++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectAddEffect1();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 123.498, ScrollDefault + (ScrollAddEffect1 * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (VisionsPage)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						VisionMenu(false);
						sleep(100);
						OpenMenu(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollVisions == 0 ? ScrollVisions = 18 : ScrollVisions--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollVisions == 18 ? ScrollVisions = 0 : ScrollVisions++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectVision();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 133.5, ScrollDefault + (ScrollVisions * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (VisionPage1)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						VisionMenu1(false);
						sleep(100);
						VisionMenu(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollVisions1 == 0 ? ScrollVisions1 = 18 : ScrollVisions1--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollVisions1 == 18 ? ScrollVisions1 = 0 : ScrollVisions1++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectVision1();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 133.5, ScrollDefault + (ScrollVisions1 * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (VisionPage2)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						VisionMenu2(false);
						sleep(100);
						VisionMenu1(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollVision2 == 0 ? ScrollVision2 = 18 : ScrollVision2--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollVision2 == 18 ? ScrollVision2 = 0 : ScrollVision2++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectVision2();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 133.5, ScrollDefault + (ScrollVision2 * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (VisionPage3)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						VisionMenu3(false);
						sleep(100);
						VisionMenu2(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollVision3 == 0 ? ScrollVision3 = 18 : ScrollVision3--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollVision3 == 18 ? ScrollVision3 = 0 : ScrollVision3++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectVision3();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 121.498, ScrollDefault + (ScrollVision3 * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (VisionPage4)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						VisionMenu4(false);
						sleep(100);
						VisionMenu3(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollVision4 == 0 ? ScrollVision4 = 18 : ScrollVision4--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollVision4 == 18 ? ScrollVision4 = 0 : ScrollVision4++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectVision4();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 132.5, ScrollDefault + (ScrollVision4 * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (NameChangerPage)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						NameChangerMenu(false);
						sleep(100);
						OpenMenu(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollNameChanger == 0 ? ScrollNameChanger = 18 : ScrollNameChanger--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -24;
						ScrollNameChanger == 18 ? ScrollNameChanger = 0 : ScrollNameChanger++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectNameChanger();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 132.5, ScrollDefault + (ScrollNameChanger * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (MiniGamesPage)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						MiniGamesMenu(false);
						sleep(100);
						OpenMenu(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollMiniGame == 0 ? ScrollMiniGame = 14 : ScrollMiniGame--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -14;
						ScrollMiniGame == 14 ? ScrollMiniGame = 0 : ScrollMiniGame++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectMiniGame();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 114.5, ScrollDefault + (ScrollMiniGame * 24) + ScrollAnimationOffset);
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
						SettingsMenu(false);
						sleep(100);
						OpenMenu(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollSettings == 0 ? ScrollSettings = 18 : ScrollSettings--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -10;
						ScrollSettings == 18 ? ScrollSettings = 0 : ScrollSettings++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectSettings();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 131.5, ScrollDefault + (ScrollSettings * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (HudColorsPage)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						HudColorPage(false);
						sleep(100);
						VisionMenu4(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollHudColors == 0 ? ScrollHudColors = 10 : ScrollHudColors--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -10;
						ScrollHudColors == 10 ? ScrollHudColors = 0 : ScrollHudColors++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectHudColors();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 131.5, ScrollDefault + (ScrollHudColors * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

				if (FOVPage)
				{
					if (Buttons::IsMCButtonPressed(Buttons::O))
					{
						FOVMenu(false);
						sleep(100);
						VisionMenu4(true);
						sleep(100);
					}

					if (Buttons::IsMCButtonPressed(Buttons::UP))
					{
						ScrollFOV == 0 ? ScrollFOV = 10 : ScrollFOV--;
						ScrollAnimationOffset = 24;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::DOWN))
					{
						ScrollAnimationOffset = -10;
						ScrollFOV == 10 ? ScrollFOV = 0 : ScrollFOV++;
						sleep(150);
					}

					if (Buttons::IsMCButtonPressed(Buttons::X))
					{
						SelectFOV();
						sleep(150);
					}

					if (ScrollAnimationOffset != 0)
					{
						DrawScrollbar(0.558594, 0.40625, 131.5, ScrollDefault + (ScrollFOV * 24) + ScrollAnimationOffset);
						if (ScrollAnimationOffset > 0)
							ScrollAnimationOffset -= ScrollSpeed;
						else
							ScrollAnimationOffset += ScrollSpeed;

						if (ScrollAnimationOffset < 0.1 && ScrollAnimationOffset > -0.1)
							ScrollAnimationOffset = 0;
					}
				}

                #pragma endregion

			}
			else
			{
				Dialog::msgdialog_mode = Dialog::MODE_STRING_OK;
				Dialog::Show("Sorry\nYou are not whitelised\nContact Misakiii");
				sys_ppu_thread_exit(0);
			}
		}	
		else
		{
            #pragma region "IN MENU"

			if (Buttons::IsMCButtonPressed(Buttons::START) && Buttons::IsMCButtonPressed(Buttons::SELECT))
			{
				NAME_CHANGER();
			}

			RGB_HUD(); //load rainbow hud in menu

            #pragma endregion
		}
	}
}


#pragma region "Load Thread Menu"

extern "C" int _MC_prx_entry(void)
{
	Dialog::msgdialog_mode = Dialog::MODE_RUNNING;
	Dialog::ProgressBar("DownCraft SPRX Premium V3\nOpen menu press  + \nMenu made by Misakiii", "Loading...", 20);
	Dialog::End();
	sys_ppu_thread_t ThreadModuleID;
	sys_ppu_thread_create(&ThreadModuleID, Menu, 0, 0x4AA, 0x7000, 0, "Test");
	return SYS_PRX_RESIDENT;
}

#pragma endregion