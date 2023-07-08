#pragma once

int DebugX = 0, DebugY = 0, DebugW = 0, DebugH = 0;
void DebugHud()
{
	if (Buttons::IsMCButtonPressed(Buttons::LEFT)) { NyTekCFW::sleep(80); DebugX += 1; }
	if (Buttons::IsMCButtonPressed(Buttons::RIGHT)) { NyTekCFW::sleep(80); DebugX -= 1; }
	if (Buttons::IsMCButtonPressed(Buttons::UP)) { NyTekCFW::sleep(80); DebugY += 1; }
	if (Buttons::IsMCButtonPressed(Buttons::DOWN)) { NyTekCFW::sleep(80); DebugY -= 1; }
	if (Buttons::IsMCButtonPressed(Buttons::O)) { NyTekCFW::sleep(80); DebugW += 1; }
	if (Buttons::IsMCButtonPressed(Buttons::SQUARE)) { NyTekCFW::sleep(80); DebugW -= 1; }
	if (Buttons::IsMCButtonPressed(Buttons::TRIANGLE)) { NyTekCFW::sleep(80); DebugH += 1; }
	if (Buttons::IsMCButtonPressed(Buttons::X)) { NyTekCFW::sleep(80); DebugH -= 1; }

	if (Buttons::IsMCButtonPressed(Buttons::L1)) { printf("Coord: %i %i %i %i \n", DebugX, DebugY, DebugW, DebugH); }
}

void DrawKeyboard()
{
	if (ShowKeyboard)
	{
		char letter1[] = { "A    Z    E   R    T    Y    U    I    O    P    ^" };
		char letter2[] = { "Q    S    D   F    G    H    J    K   L    M    _" };
		char letter3[] = { "W    X    C   V    B    N     ,     ;     :      !     ?" };
		char letter4[] = { "1    2    3   4    5    6    7    8   9    0    @" };

		int width = Font_width_char("Name Changer");
		DrawRectangleBorder(186, 71, width + 6, 13, MC_Color::BlackTheme, GetThemeColor(), 1);
		DrawTextC("Name Changer", 190, 73, color(MC_Color::White));

		DrawRectangleBorder(186, 84, 143, 13, MC_Color::BlackTheme, GetThemeColor(), 1);

		DrawTextC(NAME_CHANGER_TEXT, 190, 87, color(MC_Color::White));

		DrawRectangleBorder(186, 97, 143, 52, MC_Color::BlackTheme, GetThemeColor(), 1);
		DrawRectangle(186 + (13 * CurrentSelectX), 97 + (13 * CurrentSelectY), 13, 13, GetThemeColor());
		DrawTextC(letter1, 190, 100, color(MC_Color::White));
		DrawTextC(letter2, 190, 113, color(MC_Color::White));
		DrawTextC(letter3, 190, 126, color(MC_Color::White));
		DrawTextC(letter4, 190, 139, color(MC_Color::White));

		DrawRectangle(MenuX + 508, MenuY + 61 + (SpaceBetweenText * CurrentOpt), 152, 11, GetThemeColor());
	}
}

void Render()
{
	//DebugHud();
	RenderSubMenu();
	Controller();
}