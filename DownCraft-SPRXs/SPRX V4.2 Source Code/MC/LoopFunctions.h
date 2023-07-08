#pragma once

void ModuleLoop()
{

	Modules::ModulesTextRender();
	Modules::ZoomModule();
	Modules::AutoToss();
	Modules::AntiVoid();
	Modules::KeyStrokes();

	Modules::BunnyJump();
	Modules::SkyboxRGB();
	Modules::Scaffold();
	Modules::NoFall();
	Modules::RainbowRenderName();
}

void ChangeValueLoop()
{
	Offsets::BIG_MODEL(BigModel);
	Offsets::CHANGE_FOV(ValueFOV);
	Offsets::INSTANT_DAMAGE(InstantDamage);
	Offsets::SUPER_SPEED(SuperSpeed);
	Offsets::ADD_CUSTOM_BANNER();
	Offsets::ANIMATED_BANNER_GIF();
	Offsets::ALL_PLAYERS_ZOOM_FOV();
}

void LoopFunc()
{
	Welcome_Message();
	ModuleLoop();
	GetPosition();
	GetPing();
	GetChunks();
	GetResolution();
	GetInfosLastPlayer();
	get_temp();
	GetGameTime();
	TitleMenu();
	DEBUG_FUNCTIONS_MESSAGES();
	//VersionText();
	InventoryCreativeTumble();

	ChangeValueLoop();

	SlideOpenMenuLoop();
	SlideCloseMenuLoop();
	DrawTextC("     ", 0, 0, color(255, 255, 255));//dont move
	MaxOption = 0;
	RGB1();
	RGB2();
	Custom_Crosshair(crosshair_value);
	GetNotify();
	logs::draw_logs();

	DRAW_HEAD_PIXEL_LOGO();

	if (DebugText)
	{
		DrawTextC(initialDebugTxt, DebugTextX, DebugTextY, color(UI::Color::WHITE));
		snprintf("Text X: %i", DebugTextX, 50, 80);
		snprintf("Text Y: %i", DebugTextY, 50, 90);
	}

	if (DebugHud)
	{
		DrawRectangle(DebugHudX, DebugHudY, DebugHudW, DebugHudH, UI::Color::BLACK);
		snprintf("Hud X: %i", DebugHudX, 50, 80);
		snprintf("Hud Y: %i", DebugHudY, 50, 90);
		snprintf("Hud W: %i", DebugHudW, 50, 100);
		snprintf("Hud H: %i", DebugHudH, 50, 110);
	}

	if (DebugHudAlpha)
	{
		Color BLACK_OPACITY{ 15, 15, 15, 200 };
		DrawRectangleAlpha(DebugHudAlphaX, DebugHudAlphaY, DebugHudAlphaW, DebugHudAlphaH, BLACK_OPACITY);
		snprintf("Hud Alpha X: %i", DebugHudAlphaX, 50, 80);
		snprintf("Hud Alpha Y: %i", DebugHudAlphaY, 50, 90);
		snprintf("Hud Alpha W: %i", DebugHudAlphaW, 50, 100);
		snprintf("Hud Alpha H: %i", DebugHudAlphaH, 50, 110);
	}

	if (DebugDrawLine)
	{
		drawLineTest(Vector2(DebugDrawLineX1, DebugDrawLineX2), Vector2(DebugDrawLineY1, DebugDrawLineY2), UI::Color::PURPLE, DebugDrawLineWidth);
		snprintf("Draw Line X1: %i", DebugDrawLineX1, 50, 80);
		snprintf("Draw Line X2: %i", DebugDrawLineX2, 50, 90);
		snprintf("Draw Line Y1: %i", DebugDrawLineY1, 50, 100);
		snprintf("Draw Line Y2: %i", DebugDrawLineY2, 50, 110);
		snprintf("Draw Line Width: %i", DebugDrawLineWidth, 50, 120);
	}
}