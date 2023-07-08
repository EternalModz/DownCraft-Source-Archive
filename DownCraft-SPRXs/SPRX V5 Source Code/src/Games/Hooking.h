#pragma once

void Render()
{
	RenderSubMenu();
	Controller();
	Startup();

	//Others funcs
	ToggleHUD();
	ShowBanner();
}

void LoopOptions()
{
	if (UsableMenu)
	{
		Render();
	}
}

void RenderScreen_Stub(uint32_t r3, uint32_t r4) {
	__nop(); __nop(); __nop(); __nop(); __nop();
}

void Gui_render_Stub(GuiComponent* gui, double unk) {
	__nop(); __nop(); __nop(); __nop(); __nop();
}

void RenderScreen_Hook(uint32_t r3, uint32_t r4) {
	RenderScreen_Stub(r3, r4);
	mc = (TheMinecraft*)(0x014CF2E4);
	DrawText(L"Working", -80, -80, color(MC_TextColor::White));
	DrawRectangle(-80, -80, 40, 40, MC_Color::WHITE);
	MaxOption = 0;
	LoopOptions();
}

void Gui_render_Hook(GuiComponent* gui, double unk) {
	g_GuiComponent = gui;
	Gui_render_Stub(gui, unk);
}

void InstallHooks()
{
	HookFunctionStart(0xA89068, *(uint32_t*)(RenderScreen_Hook), *(uint32_t*)(RenderScreen_Stub));
	HookFunctionStart(0xA891F0, *(uint32_t*)(Gui_render_Hook), *(uint32_t*)(Gui_render_Stub));
}

void UninstallHooks()
{
	UnHookFunctionStart(0xAA3360, *(uint32_t*)(RenderScreen_Hook));
	UnHookFunctionStart(0x4A94B8, *(uint32_t*)(Gui_render_Hook));
}