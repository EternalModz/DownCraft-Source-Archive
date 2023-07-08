#pragma once

namespace SubMenu
{
	void MainMenu()
	{
		AddHud(8);
		AddTitle(L"DownCraft");
		AddOption(L"Combat ");
		AddOption(L"Movement");
		AddOption(L"Exploit");
		AddOption(L"Worlds");
		AddOption(L"Players");
		AddOption(L"Render");
		AddOption(L"Settings");
		AddOption(L"Credits");
	}

	void CombatMenu()
	{
		AddHudSelector(2);
		AddBoolOption(L"Instant Hit", !InstantHit);
		AddBoolOption(L"Auto Hit", !AutoHit);
		AddBoolOption(L"Reach Attack", !ReachAttack);
		AddBoolOption(L"Kill Aura", !KillAura);
	}

	void MovementMenu()
	{
		AddHudSelector(13);
		AddBoolOption(L"Auto Sprint", !AutoSprint);
		AddBoolOption(L"Super Speed", !SuperSpeed);
		AddBoolOption(L"Swim Glitch", !SwimGlitch);
		AddBoolOption(L"Sensi. Max", !SensiMax);
		AddBoolOption(L"Auto Walk", !AutoWalk);
		AddBoolOption(L"Auto Crouch", !AutoCrouch);
		AddBoolOption(L"Crouch Mov", !CrouchMov);
		AddBoolOption(L"Water Slowdown", !WaterSlowdown);
		AddBoolOption(L"Auto Jump", !AutoJump);
		AddBoolOption(L"Always Sprint", !AlwaysSprint);
		AddBoolOption(L"No Slow Down", !NoSlowDown);
		AddBoolOption(L"Real Jump", !RealJump);
		AddBoolOption(L"Rotation Head", !RotationHead);
	}

	void ExploitMenu()
	{
		AddHudSelector(8);
		AddBoolOption(L"Multi Jump", !MultiJump);
		AddBoolOption(L"No Colission", !NoColission);
		AddBoolOption(L"Drift Boat", !DriftBoat);
		AddBoolOption(L"Specator Mode", !SpectatorMode);
		AddBoolOption(L"God Mode For Me", !GodModeForMe);
		AddBoolOption(L"Can Fly", !CanFly);
		AddBoolOption(L"No Velocity", !NoVeloCity);
		AddBoolOption(L"Dragon Eggs", !DragonEggs);
	}

	void WorldMenu()
	{
		AddHudSelector(7);
		AddBoolOption(L"Disable Portals", !DisablePortals);
		AddBoolOption(L"Entity God Mode", !EntityGodMode);
		AddBoolOption(L"Instant Damage", !InstantDamage);
		AddBoolOption(L"Knockback", !Knockback);
		AddBoolOption(L"Mobs Ignore Me", !MobsIgnoreMe);
		AddBoolOption(L"Freeze Entity", !FreezeEntity);
		AddBoolOption(L"Air To Water", !AirToWater);
	}

	void PlayersMenu()
	{
		AddHudSelector(6);
		AddOptionFuncs(L"Freeze Console");
		AddBoolOption(L"Player Fast Mine", !PlayersFastMine);
		AddBoolOption(L"Player Super Speed", !PlayerSuperSpeed);
		AddBoolOption(L"Suffocate Player", !SuffocatePlayers);
		AddBoolOption(L"Player In Fire", !PlayersInFire);
		AddBoolOption(L"Disable Player", !DisablePlayers);
	}

	void RenderMenu()
	{
		AddHudSelector(8);
		AddBoolOption(L"Better Time", !BetterTime);
		AddBoolOption(L"Xray Vision", !XrayVision);
		AddBoolOption(L"Optimize Chunks", !OptimizeChunk);
		AddBoolOption(L"FOV Without Hand", !FOVWithoutHand);
		AddBoolOption(L"Free Cam", !FreeCam);
		AddBoolOption(L"Best Sky", !BestSky);
		AddBoolOption(L"Wallhack", !WallHack);
		AddBoolOption(L"Render Entity", !RenderEntity);
	}

	void SettingsMenu()
	{
		AddHudSelector(3);
		AddBoolOption(L"Title Header", !UI::Settings::HeaderTitle);
		AddBoolOption(L"New Checkbox", !UI::Settings::NewCheckbox);
		AddBoolOption(L"Toggle Checkbox", !UI::Settings::ToggleOnOff);
	}

	void CreditsMenu()
	{
		AddHudSelector(2);
		AddOptionFuncs(L"Misakiii (SPRX)");
		AddOptionFuncs(L"Azey (Backup)");
	}
}
