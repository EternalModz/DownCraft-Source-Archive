#pragma once

void LoopOptions()
{
	CheckSPRX();

	if (UsableMenu)
	{
		Menu::TitleSPRX(titleSPRX);
		DrawKeyboard();
		Options::ShowPSN();
		Options::ShowGametime();
		Options::ShowPosition();
		Options::ShowChunks();
		Options::ShowResolution();
		Options::ShowPing();
		Options::ShowCPURSX();
		Options::ShowDebugPlayer();
		Options::ShowKeystrokes();
		DoRainbowColor();
		Render();
		logs::draw_logs();
	}
}

void RenderScreen_Stub(uint32_t r3, uint32_t r4) {
	__nop(); __nop(); __nop(); __nop(); __nop();
}

void asm_LivingEntity_HurtHook(Entity* entity, EntityDamageSource* entityDamageSource, float damage) {
	__nop(); __nop(); __nop(); __nop(); __nop();
}
void asm_Player_HurtHook(ServerPlayer* player, DamageSource* damageSource, float damage) {
	__nop(); __nop(); __nop(); __nop(); __nop();
}

void Gui_render_Stub(GuiComponent* gui, double unk) {
	__nop(); __nop(); __nop(); __nop(); __nop();
}

void RenderScreen_Hook(uint32_t r3, uint32_t r4) {
	RenderScreen_Stub(r3, r4);
	mc = (TheMinecraft*)(0x014CF2E4);
	MaxOption = 0;
	DrawText(L"Working", -80, -80, color(MC_Color::White));
	LoopOptions();
}

void LivingEntity_HurtHook(Entity* entity, EntityDamageSource* entityDamageSource, float damage)
{
	asm_LivingEntity_HurtHook(entity, entityDamageSource, damage);
}

void Player_actuallyHurtHook(ServerPlayer* player, DamageSource* damageSource, float damage)
{
	asm_Player_HurtHook(player, damageSource, damage);
}

void Gui_render_Hook(GuiComponent* gui, double unk) {
	g_GuiComponent = gui;
	Gui_render_Stub(gui, unk);
}

void InstallHooks()
{
	HookFunctionStart(0xA89068, *(uint32_t*)(RenderScreen_Hook), *(uint32_t*)(RenderScreen_Stub));
	HookFunctionStart(0x3A7F48, *(uint32_t*)(LivingEntity_HurtHook), *(uint32_t*)(asm_LivingEntity_HurtHook));
	HookFunctionStart(0x4A94B8, *(uint32_t*)(Player_actuallyHurtHook), *(uint32_t*)(asm_Player_HurtHook));
	HookFunctionStart(0xA891F0, *(uint32_t*)(Gui_render_Hook), *(uint32_t*)(Gui_render_Stub));
}

void UninstallHooks()
{
	UnHookFunctionStart(0xAA3360, *(uint32_t*)(RenderScreen_Hook));
	UnHookFunctionStart(0x3A7F48, *(uint32_t*)(LivingEntity_HurtHook));
	UnHookFunctionStart(0x4A94B8, *(uint32_t*)(Player_actuallyHurtHook));
	UnHookFunctionStart(0x4A94B8, *(uint32_t*)(Gui_render_Hook));
}