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

	if (Buttons::IsMCButtonPressed(Buttons::L1)) { printf("Coords: %i %i %i %i \n", DebugX, DebugY, DebugW, DebugH); }
}

void Render()
{
	//DebugHud();
	RenderSubMenu();
	Controller();
}