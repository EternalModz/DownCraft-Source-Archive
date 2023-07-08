#pragma once

int DebugX = 80, DebugY = 80, DebugW = 160, DebugH = 160;
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

void BetterOptions()
{
	*(int*)0x0090FB6C = 0x40820008; //hotbar down
	*(int*)0x00AD5A5C = 0x6F800000; //entity more red when attacked
	//*(int*)0x0022C370 = 0x3FC99999; //no more collission entity
	//*(int*)0x00A9A6DC = 0x3EDF6666; //better day light
	//*(int*)0x004AA398 = 0xBFE00000; //better riding Height
	//*(int*)0x002230C4 = 0xBFE00000; //see all entity
}

void Render()
{
	RenderSubMenu();
}