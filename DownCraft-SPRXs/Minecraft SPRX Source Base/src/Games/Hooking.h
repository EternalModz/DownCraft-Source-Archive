#pragma once

void LoopOptions()
{
	Options::ShowPosition();
	Options::ShowGametime();
	Options::ShowKeystrokes();
	DoRainbowColor();
	SlideOpenMenuAnimation();
	SlideCloseMenuAnimation();
	Render();
}

void RenderScreen_Stub(uint32_t r3, uint32_t r4) {
	__nop(); __nop(); __nop(); __nop(); __nop();
}

void RenderScreen_Hook(uint32_t r3, uint32_t r4) {
	RenderScreen_Stub(r3, r4);
	mc = (TheMinecraft*)(0x014CF2E4);
	MaxOption = 0;
	DrawText(L"Working", -80, -80, color(MC_Color::White));
	LoopOptions();
}

void InstallHooks()
{
	HookFunctionStart(0x00A89068, *(uint32_t*)(RenderScreen_Hook), *(uint32_t*)(RenderScreen_Stub));
}

void UninstallHooks()
{
	UnHookFunctionStart(0x00AA3360, *(uint32_t*)(RenderScreen_Hook));
}