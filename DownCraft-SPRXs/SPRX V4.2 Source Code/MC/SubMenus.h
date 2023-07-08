#pragma once

namespace SubMenu
{
	void MainMenu()
	{
		submmenuMax = 15;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Main Menu");
		AddOption(L"Host Options");
		AddOption(L"Non Host Options");
		AddOption(L"Players Options");
		AddOption(L"Weather Options");
		AddOption(L"Vision Options");
		AddOption(L"Modules Options");
		AddOption(L"Name Changer");
		AddOption(L"Game Editor");
		AddOption(L"Mini-Game Options");
		AddOption(L"Teleport Options");
		AddOption(L"Players Options");
		AddOption(L"Settings Menu");
		AddOption(L"Credits Menu");
		AddOption(L"Config Options");
		AddOption(L"Developer Menu");
		AddInformation(submmenuMax, L"By Misakiii                                         V4.5");
	}

    #pragma region "Host Pages"

	void HostMenu()
	{
		submmenuMax = 20;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Host Menu");
		AddBoolOption(L"God Mode", !GodMode);
		AddBoolOption(L"Demi God Mode", !DemiGodMode);
		AddIntOption(L"Instant Damage", 63, InstantDamage);
		AddBoolOption(L"Critical Hit", !CriticalHit);
		AddBoolOption(L"Kill In Creative", !KillInCreative);
		AddBoolOption(L"No Damage Hit", !NoDamageHit);
		AddBoolOption(L"Knockback", !Knockback);
		AddBoolOption(L"Anti Knockback", !AntiKnockback);
		AddBoolOption(L"Reverse KB", !ReverseKnockback);
		AddBoolOption(L"Drop Far Items", !DropFarItems);
		AddBoolOption(L"Max XP Level", !MaxXPLevel);
		AddBoolOption(L"Water Jump", !WaterJump);
		AddBoolOption(L"Drift Boat", !DriftBoat);
		AddBoolOption(L"Stop Arrows", !StopArrows);
		AddBoolOption(L"Remove Arrows", !RemoveArrows);
		AddBoolOption(L"Potions Flying", !PotionsFlying);
		AddBoolOption(L"Potions Go Down", !PotionsNoGravity);
		AddBoolOption(L"Inf Pickup Items", !InfinitePickupItems);
		AddBoolOption(L"Max Pickup Items", !MaxPickupItems);
		AddOption(L"Next Page");

		if (CurrentOpt == 0) { AddInformation(submmenuMax, L"Turn everyone invincible"); }
		if (CurrentOpt == 1) { AddInformation(submmenuMax, L"Turn entity & players invincible"); }
		if (CurrentOpt == 2) { AddInformation(submmenuMax, L"Change attack damage delay"); }
		if (CurrentOpt == 4) { AddInformation(submmenuMax, L"Bypass kill entity & players"); }
		if (CurrentOpt == 5) { AddInformation(submmenuMax, L"Remove attack damage"); }
		if (CurrentOpt == 9) { AddInformation(submmenuMax, L"All items is dropped very far"); }
	}

	void HostMenu1()
	{
		submmenuMax = 20;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Host Menu");
		AddBoolOption(L"Infinite Blocks", !InfiniteBlocks);
		AddBoolOption(L"Burn In Water", !BurnInWater);
		AddBoolOption(L"Remove Fire", !RemoveFire);
		AddBoolOption(L"Creative Slot", !CreativeSlot);
		AddBoolOption(L"Survival Slot", !SurvivalSlot);
		AddBoolOption(L"Kill Spawn Entity", !KillSpawnEntity);
		AddBoolOption(L"No Block Gravity", !StopBlockGravity);
		AddBoolOption(L"No Hit Delay", !NoHitDelay);
		AddBoolOption(L"Get Max Items", !BypassMaxItems);
		AddBoolOption(L"Infinite Food", !InfiniteFood);
		AddBoolOption(L"Mobs Ignore Me", !MobIgnoreMe);
		AddBoolOption(L"Disable Portals", !DisablePortals);
		AddBoolOption(L"Kill On Respawn", !KillOnRespawn);
		AddBoolOption(L"Freeze Entity", !FreezeAllEntity);
		AddBoolOption(L"No Entity TP", !StopEndermanTP);
		AddBoolOption(L"No Pressure", !IgnoringPressure);
		AddBoolOption(L"All Enchant", !AllEnchant);
		AddBoolOption(L"Items On Head", !ItemsOnHead);
		AddBoolOption(L"Stop Boat", !StopBoat);
		AddOption(L"Next Page");
	}

	void HostMenu2()
	{
		submmenuMax = 20;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Host Menu");
		AddBoolOption(L"No Web", !NoWeb);
		AddBoolOption(L"Entity God Mode", !EntityGodMode);
		AddBoolOption(L"Regen Health", !RegenerateHealth);
		AddBoolOption(L"Lock GameMode", !LockGameMode);
		AddBoolOption(L"Lock Weather", !LockWeather);
		AddBoolOption(L"Fast Bow", !FastBow);
		AddBoolOption(L"Postion Arrows", !DirectionArrows);
		AddOption(L"God Mode For Me");
		AddBoolOption(L"Totem Health", !TotemGiveHealth);
		AddBoolOption(L"TNT Nuclear", !TntNuclear);
		AddBoolOption(L"TNT Particles", !TntBigParticles);
		AddBoolOption(L"TNT Flying", !TntFlying);
		AddBoolOption(L"TNT Explode", !TntInstantExplode);
		AddBoolOption(L"No Spawn Mobs", !DisableSpawnMobs);
		AddBoolOption(L"Tnt Go Ground", !TntGoInGround);
		AddBoolOption(L"Tnt Sound Off", !TntSoundOff);
		AddBoolOption(L"Big Creeper", !BigCreeper);
		AddBoolOption(L"Creeper Boom", !CreeperNuclear);
		AddBoolOption(L"Creeper Fire", !CreeperFire);
		AddOption(L"Next Page");
	}

	void HostMenu3()
	{
		submmenuMax = 3;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Host Menu");
		AddBoolOption(L"Disable Totem", !DisableTotem);
		AddBoolOption(L"Bug Dead Entity", !GlitchDeadEntity);
		AddBoolOption(L"Infos Players", !PlayersInfos);
	}

    #pragma endregion

    #pragma region "Non Host Pages"

	void NonHostMenu()
	{
		submmenuMax = 20;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Non Host Menu");
		AddIntOption(L"Super Speed", 38, SuperSpeed);
		AddBoolOption(L"Bunny Hop", !BunnyHoptoggle);
		AddBoolOption(L"Phase V1 BETA", !PhaseV1BETA);
		AddBoolOption(L"Block Static", !BlockStaticCrack);
		AddBoolOption(L"Multi Jump", !MultiJump);
		AddBoolOption(L"Jump For Build", !JumpForBuild);
		AddBoolOption(L"Jump In Sky", !JumpInSky);
		AddBoolOption(L"Super Jump", !SuperJump);
		AddBoolOption(L"Super Jump V2", !SuperJumpV2);
		AddBoolOption(L"Jump Forward", !JumpForward);
		AddBoolOption(L"Remove Jump", !RemoveJump);
		AddBoolOption(L"Jump Speed", !JumpSpeed);
		AddBoolOption(L"Fly Mode X", !FlyModeX);
		AddBoolOption(L"Swim Fly", !SwimFly);
		AddBoolOption(L"Movement Swim", !MovementSwim);
		AddBoolOption(L"Swim Glitch", !SwimGlitch);
		AddBoolOption(L"No Colission", !NoColission);
		AddBoolOption(L"Items IDs", !ItemsIds);
		AddBoolOption(L"Anti Kick", !AntiKick);
		AddOption(L"Next Page");
	}

	void NonHostMenu1()
	{
		submmenuMax = 20;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Non Host Menu");
		AddBoolOption(L"In Block", !InBlock);
		AddBoolOption(L"Position View", !PositionView);
		AddBoolOption(L"Funny Sound", !FunnySound);
		AddBoolOption(L"Float Up", !FloatUp);
		AddBoolOption(L"ESP Chests", !ESPChests);
		AddBoolOption(L"Camera Down", !CameraDown);
		AddBoolOption(L"Instant Mine", !InstantMine);
		AddBoolOption(L"Infinite Craft", !InfiniteCraft);
		AddBoolOption(L"Hud Mini Games", !HudMiniGame);
		AddBoolOption(L"Anti Teleport", !AntiTeleport);
		AddBoolOption(L"UFO Mode", !UFOMode);
		AddBoolOption(L"Anti AFK", !AntiAFK);
		AddBoolOption(L"Sensibility Fast", !SensibilityFast);
		AddBoolOption(L"Sensibility More", !SensibilityExtrem);
		AddBoolOption(L"Walk Alone", !WalkAlone);
		AddBoolOption(L"Name On Head", !NameOverHead);
		AddBoolOption(L"Name On Head V2", !NameOverHeadV2);
		AddBoolOption(L"Static Movement", !StaticMovement);
		AddBoolOption(L"Walk In Sky", !WalkInSky);
		AddOption(L"Next Page");
	}

	void NonHostMenu2()
	{
		submmenuMax = 20;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Non Host Menu");
		AddBoolOption(L"Gravity Moon", !GravityMoon);
		AddBoolOption(L"Look Forback", !Lookforback);
		AddBoolOption(L"Camera Down", !CameraDownR3);
		AddBoolOption(L"Better Time", !BetterTime);
		AddBoolOption(L"See Out Map", !SeeOutMap);
		AddBoolOption(L"Scaffold", !Scaffold);
		AddBoolOption(L"Day & Night", !DayAndNight);
		AddBoolOption(L"ESP Players", !ESPPlayers);
		AddBoolOption(L"Can Fly", !CanFly);
		AddBoolOption(L"Colission Entity", !NoColissionEntity);
		AddBoolOption(L"Always Crouch", !AlwaysOnCrouch);
		AddBoolOption(L"Get Players IDs", !GetPlayersIDs);
		AddBoolOption(L"Player On Elyta", !PlayersOnElytra);
		AddBoolOption(L"Water SlowDown", !WaterSlowDown);
		AddBoolOption(L"Jump In Lava", !JumpInLava);
		AddBoolOption(L"Crouch Mov", !CrouchMovement);
		AddBoolOption(L"Pos Place Block", !PosPlaceBlock);
		AddBoolOption(L"Destroy Game", !DestroyGame);
		AddBoolOption(L"Levitation", !Levitation);
		AddOption(L"Next Page");
	}

	void NonHostMenu3()
	{
		submmenuMax = 20;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Non Host Menu");
		AddBoolOption(L"Return XMB", !ReturnInXMB);
		AddBoolOption(L"Return XMB V2", !ReturnInXMBV2);
		AddBoolOption(L"Add Fake Clone", !AddFakeClone);
		AddBoolOption(L"Invisible Player", !InvisiblePlayers);
		AddBoolOption(L"Auto Ladder", !AutoLadder);
		AddBoolOption(L"Air To Water", !AirToWater);
		AddBoolOption(L"Multi Jump V2", !MultiJumpV2);
		AddBoolOption(L"Suicide Mode", !SuicideMode);
		AddBoolOption(L"Game Static", !GameSpeedStatic);
		AddBoolOption(L"Get 64 Items", !Get64Items);
		AddBoolOption(L"Auto Jump", !AutoJump);
		AddBoolOption(L"Auto View", !AutoChangeView);
		AddBoolOption(L"Auto Crouch", !AutoCrouch);
		AddBoolOption(L"Auto Mine", !AutoMine);
		AddBoolOption(L"Auto Hit", !AutoHit);
		AddBoolOption(L"Auto Build", !AutoBuild);
		AddBoolOption(L"ESP Waypoint", !ESPWaypoint);
		AddBoolOption(L"Bat Eggs Crash", !BatEggsCrash);
		AddBoolOption(L"Bat Eggs Freeze", !BatEggsFreeze);
		AddOption(L"Next Page");
	}

	void NonHostMenu4()
	{
		submmenuMax = 20;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Non Host Menu");
		AddBoolOption(L"Special Items", !GetSpecialItems);
		AddBoolOption(L"Reach Attack", !ReachAttack);
		AddBoolOption(L"Auto Sprint", !AutoSprint);
		AddBoolOption(L"Auto Sprint V2", !AutoSprintV2);
		AddBoolOption(L"Instant Hit", !InstantHit);
		AddBoolOption(L"Kill Aura", !KillAura);
		AddBoolOption(L"Fast Build", !FastBuild);
		AddBoolOption(L"Critical Mode", !CriticalMode);
		AddBoolOption(L"Critical ModeV2", !CriticalModeV2);
		AddBoolOption(L"No SlowDown", !NoSlowDown);
		AddBoolOption(L"No Hurt Cam", !NoHurtCam);
		AddBoolOption(L"Press X For Hit", !PressXForHit);
		AddBoolOption(L"Show Armor", !ShowArmor);
		AddBoolOption(L"Unfair Attack", !UnfairAttack);
		AddBoolOption(L"Hitbox BETA", !HitBoxBETA);
		AddBoolOption(L"Big Velocity", !BigVelocity);
		AddBoolOption(L"No Velocity", !NoVelocity);
		AddBoolOption(L"Anti Void", !AntiVoidtoggle);
		AddBoolOption(L"ESP Entity", !ESPEntity);
		AddOption(L"Next Page");
	}

	void NonHostMenu5()
	{
		submmenuMax = 5;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Non Host Menu");
		AddBoolOption(L"ESP Tracer", !ESPTracer);
		AddBoolOption(L"ESP COD", !ESPCOD);
	}

    #pragma endregion

    #pragma region "Players Options Pages"

	void PlayerOptionsMenu()
	{
		submmenuMax = 11;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Players Menu");
	        AddBoolOption(L"Plrs Fast Mine", !AllPlayersFastMine);
		AddBoolOption(L"Plrs Cant Mine", !AllPlayersCantMine);
		AddBoolOption(L"Plrs Cant Run", !AllPlayersCantRun);
		AddBoolOption(L"Plrs Speed", !AllPlayersSpeed);
		AddBoolOption(L"Plrs Super Run", !AllPlayersSuperRun);
		AddBoolOption(L"Plrs Zoom FOV", !AllPlayersZoomFOV);
		AddBoolOption(L"Plrs Cant Join", !PlayersCantJoin);
		AddBoolOption(L"All Change Hand", !AllChangeHand);
		AddBoolOption(L"Plrs Suffocate", !AllPlayersSuffocate);
		AddBoolOption(L"Plrs In Fire", !AllPlayersInFire);
		AddOption(L"Plrs Freeze PS3");
	}

    #pragma endregion

    #pragma region "Weather Options Pages"

	void WeatherOptionsMenu()
	{
		submmenuMax = 7;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Weather Menu");
		AddBoolOption(L"Dark Storm", !DarkStorm);
		AddBoolOption(L"Rainbow Storm", !RainbowStorm);
		AddBoolOption(L"Rain To Snow", !RainToSnow);
		AddBoolOption(L"Rain With Snow", !RainbowWithSnow);
		AddBoolOption(L"Flash Sky", !FlashSky);
		AddBoolOption(L"LightningBold V1", !LightningBoldV1);
		AddBoolOption(L"LightningBold V2", !LightningBoldV2);
	}

    #pragma endregion

    #pragma region "Vision Options Page"

	void VisionsOptionsMenu()
	{
		submmenuMax = 14;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Vision Menu");
		AddBoolOption(L"Xray Vision", !XrayVision);
		AddBoolOption(L"Night Vision", !NightVision);
		AddBoolOption(L"Apocalipse", !Apocalipse);
		AddBoolOption(L"Funny Screen", !FunnySound);
		AddBoolOption(L"Horror Vision", !HorrorView);
		AddBoolOption(L"Animation Run", !AnimationRun);
		AddBoolOption(L"Sky Rainbow", !SkyRainbow);
		AddBoolOption(L"WTF View", !WTFView);
		AddBoolOption(L"Size HUD", !SizeHUD);
		AddBoolOption(L"Broken Texture", !BrokenTexture);
		AddBoolOption(L"Shockwave", !ShockWave);
		AddBoolOption(L"Wall Hack", !WallHack);
		AddBoolOption(L"Wall Hack V2", !WallHackV2);
		AddOption(L"Next Page");
	}

	void VisionsOptionsMenu1()
	{
		submmenuMax = 14;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Vision Menu");
		AddBoolOption(L"Wall Hack V3", !WallhackV3);
		AddBoolOption(L"Plastic Texture", !PlasticTexture);
		AddBoolOption(L"Ghost Texture", !GhostPlastic);
		AddBoolOption(L"Blue Fog", !BlueFog);
		AddBoolOption(L"Best Sky", !BestSky);
		AddBoolOption(L"Shake Camera", !ShakeCamera);
		AddBoolOption(L"More Light", !MoreLight);
		AddBoolOption(L"Flat Items", !FlatItems);
		AddBoolOption(L"Vibrate Walk", !VibrateWalk);
		AddBoolOption(L"HUD Inv Down", !HUDInvDown);
		AddBoolOption(L"Small Graphic", !SmallGraphic);
		AddBoolOption(L"Particles Fly", !ParticlesFly);
		AddBoolOption(L"Paper Model", !PaperModel);
		AddOption(L"Next Page");
	}

	void VisionsOptionsMenu2()
	{
		submmenuMax = 14;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Vision Menu");
		AddIntOption(L"Big Model", 128, BigModel);
		AddBoolOption(L"Camera Left", !CameraLeft);
		AddBoolOption(L"Camera Right", !CameraRight);
		AddBoolOption(L"Big Particles", !BigParticles);
		AddBoolOption(L"HUD Loading", !HudLoading);
		AddBoolOption(L"Stars In Sky", !StarsInSky);
		AddBoolOption(L"Step Fast", !FootStepFast);
		AddBoolOption(L"Step Slow", !FootStepSlow);
		AddBoolOption(L"Skins Debug", !SkinsDebug);
		AddBoolOption(L"Shadow Skins", !ShadowSkins);
		AddBoolOption(L"Skins Red", !SkinsPlayersRed);
		AddBoolOption(L"Particles Fly", !ParticlesFly1);
		AddBoolOption(L"Line Block Move", !LineBlockMove);
		AddOption(L"Next Page");
	}

	void VisionsOptionsMenu3()
	{
		submmenuMax = 14;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Vision Menu");
		AddBoolOption(L"Disable Players", !DisablePlayers);
		AddBoolOption(L"Small Text", !SmallText);
		AddBoolOption(L"Pos Hud Text", !PosHudText);
		AddBoolOption(L"Arms Broken", !ArmsBroken);
		AddBoolOption(L"Black Fog", !BlackFog);
		AddBoolOption(L"Sky Nether", !SkyNether);
		AddBoolOption(L"Smoke Lobby", !SmokeLobby);
		AddBoolOption(L"Under World", !LookUnderWorld);
		AddBoolOption(L"Free Cam", !FreeCam);
		AddBoolOption(L"Remove Hand", !RemoveHand);
		AddBoolOption(L"Moving Particle", !TornadoParticles);
		AddBoolOption(L"Hit Damage Red", !HitDamageRed);
		AddBoolOption(L"Disable Fog", !DisableFog);
		AddOption(L"Next Page");
	}

	void VisionsOptionsMenu4()
	{
		submmenuMax = 14;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Vision Menu");
		AddBoolOption(L"FOV No Hand", !FovWithoutHand);
		AddBoolOption(L"Zoom No Hand", !ZoomWithoutHand);
		AddBoolOption(L"Iron Helmet", !IronHelmet);
		AddBoolOption(L"Entity To Baby", !EntityBaby);
		AddBoolOption(L"No Detailed Skins", !NoDetailedSkins);
		AddBoolOption(L"Aim 3Th Person", !AimOn3thPerson);
		AddBoolOption(L"Render Entity", !RenderEntity);
		AddBoolOption(L"360 Rotate Head", !RotationCam);
		AddBoolOption(L"Texture To Black", !TextureToBlack);
		AddBoolOption(L"Gamma To Max", !GammaToMax);
		AddBoolOption(L"Name & Shadow", !NameShadowBlack);
		AddBoolOption(L"Anim Character", !AnimationCharacter);
		AddBoolOption(L"Big Anim Character", !BigAnimCharacter);
		AddOption(L"Next Page");
	}

	void VisionsOptionsMenu5()
	{
		submmenuMax = 14;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Vision Menu");
		AddBoolOption(L"Rotation Body", !RotationBody);
		AddBoolOption(L"Entity Light", !EntityBodyLight);
		AddBoolOption(L"Nether Vision", !NetherVision);
		AddBoolOption(L"Hit Spam", !ParticlesHitSpam);
		AddBoolOption(L"Roblox Animation", !RobloxAnimation);
		AddBoolOption(L"Elytra Entity", !Elytra);
		AddBoolOption(L"Move Head", !MoveHeadNoBody);
		AddBoolOption(L"Stop Animation", !StopAnimation);
		AddBoolOption(L"Giant Gameplay", !GiantGameplay);
		AddBoolOption(L"Light White", !WorldLightWhite);
		AddBoolOption(L"Rainbow Light", !WorldRainbowLight);
		AddBoolOption(L"Shadow Skins", !ShadowSkins);
		AddBoolOption(L"Double Name", !DoubleName);
		AddOption(L"Next Page");
	}

	void VisionsOptionsMenu6()
	{
		submmenuMax = 5;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Vision Menu");
		AddBoolOption(L"Optimize Chunks", !OptimizeChunks);
		AddBoolOption(L"Stop Chunks", !StopChunksLoad);
		AddBoolOption(L"Real Jump Anim", !RealJumpAnim);
		AddIntOption(L"FOV Value", 128, ValueFOV);
		AddBoolOption(L"Rainbow Sky", !RainbowSky);
	}

    #pragma endregion

    #pragma region "Modules Options"

	void ModulesOptionsMenu()
	{
		submmenuMax = 7;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Modules Menu");
		AddBoolOption(L"Zoom Mode", !Zoom);
		AddBoolOption(L"TP Aura", !TPAura);
		AddBoolOption(L"Nuker", !Nuker);
		AddIntOption(L"Nuker Radius", 0, sizeNuker);
		AddBoolOption(L"Auto Toss", !AutoTossItems);
		AddBoolOption(L"Anti Void", !AntiVoidtoggle);
		AddBoolOption(L"Key Strokes", !keystrokes);

		if (CurrentOpt == 0) { AddInformation(submmenuMax, L"Press R3 for Zoom"); }
		if (CurrentOpt == 1) { AddInformation(submmenuMax, L"TP to target and attack him"); }
		if (CurrentOpt == 2) { AddInformation(submmenuMax, L"Break multiple blocks"); }
		if (CurrentOpt == 4) { AddInformation(submmenuMax, L"Auto Toss items on slot"); }
	}

    #pragma endregion

    #pragma region "Name Changer Options Page"

	void NameChangerOptionsMenu()
	{
		submmenuMax = 9;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Name Changer");
		AddOption(L"Enter a text");
		AddOption(L"DownCraft SPRX V4");
		AddOption(L"ABCDEFGHIJKLMNO...");
		AddOption(L"Your IP is...");
		AddOption(L"No Name");
		AddOption(L"Long Name");
		AddOption(L"*************");
		AddOption(L"Hentai");
		AddOption(L"сука блять");
	}

    #pragma endregion

    #pragma region "Game Editor Options Page"

	void GameEditorOptionsMenu()
	{
		submmenuMax = 6;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Game Editor");
		AddOption(L"Block Changer");
		AddOption(L"Eggs Changer");
		AddOption(L"Items Changer");
		AddOption(L"Enchant Changer");
		AddOption(L"Particles Changer");
		AddOption(L"Sounds Changer");
	}

	void EggChangerMenu()
	{
		submmenuMax = 2;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Eggs Changer");
		AddOption(L"Dragon Spawner");
		AddOption(L"Golem Spawner");
	}

	void BlockChangerMenu()
	{
		submmenuMax = 13;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Blocks Changer");
		AddOption(L"AIR  ");
		AddOption(L"COBBLESTONE");
		AddOption(L"GRASS  ");
		AddOption(L"WATER  ");
		AddOption(L"LAVA  ");
		AddOption(L"SAND  ");
		AddOption(L"FOSTED ICE");
		AddOption(L"~~TO ~~");
		AddOption(L"BARRIERE");
		AddOption(L"OBSIDIAN");
		AddOption(L"COMMAND BLOCK");
		AddOption(L"DIAMOND BLOCK");;
		AddOption(L"Next Page");
	}

	void BlockChangerMenu1()
	{
		submmenuMax = 16;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Blocks Changer");
		AddOption(L"LADDER");
		AddOption(L"END PORTAL");
		AddOption(L"NETHER PORTAL");
		AddOption(L"TNT  ");
		AddOption(L"MAGMA ");
		AddOption(L"CARPET");
		AddOption(L"DRAGON EGG");
		AddOption(L"CAKE  ");
		AddOption(L"SNOW LAYER");
		AddOption(L"CACTUS");
		AddOption(L"SIGN  ");
		AddOption(L"COB WEB");
		AddOption(L"LAVA ");
		AddOption(L"WATER");
		AddOption(L"LEVER ");
		AddOption(L"Next Page");
	}

	void BlockChangerMenu2()
	{
		submmenuMax = 8;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Blocks Changer");
		AddOption(L"BEDROCK");
		AddOption(L"CHORUS PLANT");
		AddOption(L"CHORUS FLOWER");
		AddOption(L"GRASS PATH");
		AddOption(L"ENCHANTEMENT");
		AddOption(L"SKULL  ");
		AddOption(L"Set Blocks");
		AddOption(L"Reset Blocks");
	}

    #pragma endregion

    #pragma region "Mini Games Options Menu"

	void MiniGameOptionsMenu()
	{
		submmenuMax = 12;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Mini-Games Menu");
		AddBoolOption(L"Can Craft", !CanCraft);
		AddBoolOption(L"Can Place Block", !CanPlaceBlocks);
		AddBoolOption(L"See Spectator", !CanSeeSpectator);
		AddBoolOption(L"Plrs Starved", !PlayersAreStarved);
		AddBoolOption(L"Allow Portals", !AllowPortals);
		AddBoolOption(L"Tnt Can Destroy", !TntCanDestroyBlocks);
		AddBoolOption(L"Max In Small Map", !MaxPlayersSmallMap);
		AddBoolOption(L"Crea Inv Lobby", !CreativeInventory);
		AddBoolOption(L"Destroy Block", !CanDestroyBlocks);
		AddBoolOption(L"Game Survival", !GameModeToSurvival);
		AddBoolOption(L"Inv Crea Tumble", !InventoryCreaTumbleActive);
		AddOption(L"Teleport Location");
	}

	void TPMiniGameOptionsMenu()
	{
		submmenuMax = 4;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Mini-Games Menu");
		AddOption(L"TP To Lobby");
		AddOption(L"TP To Cavern");
		AddOption(L"TP To Cove");
		AddOption(L"TP To Crucible");
	}

    #pragma endregion

    #pragma region "Teleport Menu Pages"

	void TeleportOptionsMenu()
	{
		submmenuMax = 8;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Teleport Menu");
		AddOption(L"Change: +X");
		AddOption(L"Change: +Y");
		AddOption(L"Change: +Z");
		AddOption(L"Change: -X");
		AddOption(L"Change: -Y");
		AddOption(L"Change: -Z");
		AddOption(L"Get Teleport");
		AddOption(L"Set Teleport");
	}

    #pragma endregion

    #pragma region "Settings Pages"

	void SettingsMenu()
	{
		submmenuMax = 8;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Settings Menu");
		AddOption(L"Theme Colors");
		AddOption(L"Edit Menu");
		AddOption(L"Debug Menu");
		AddOption(L"Custom Image");
		AddOption(L"Mics Settings");
		AddOption(L"Custom Crosshair");
		AddOption(L"Draw Head Logo");
		AddOption(L"Show Menu");
	}

	void EditMenu()
	{
		submmenuMax = 4;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Settings Menu");
		AddOption(L"Menu X +");
		AddOption(L"Menu X -");
		AddOption(L"Menu Y +");
		AddOption(L"Menu Y -");
	}

	void ThemeMenu()
	{
		submmenuMax = 11;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Settings Menu");
		AddOption(L"Default Theme");
		AddOption(L"White Theme");
		AddOption(L"Pink Theme");
		AddOption(L"Red Theme");
		AddOption(L"Orange Theme");
		AddOption(L"Cyan Theme");
		AddOption(L"Green Theme");
		AddOption(L"Lime Theme");
		AddOption(L"Yellow Theme");
		AddOption(L"Purple Theme");
		AddBoolOption(L"Rainbow Theme", !UI::Settings::Rainbow);
	}

	void DebugMenu()
	{
		submmenuMax = 4;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Debug Menu");
		AddOption(L"Debug Text");
		AddOption(L"Debug Hud");
		AddOption(L"Debug Hud Alpha");
		AddOption(L"Draw Line");
	}

	void DebugTextMenu()
	{
		submmenuMax = 6;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Debug Text Menu");
		AddBoolOption(L"Enable Debug Text", !DebugText);
		AddOption(L"Change Debug Text");
		AddOption(L"Text X +");
		AddOption(L"Text X -");
		AddOption(L"Text Y +");
		AddOption(L"Text Y -");
	}

	void DebugHudMenu()
	{
		submmenuMax = 9;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Debug HUD Menu");
		AddBoolOption(L"Enable Debug HUD", !DebugHud);
		AddOption(L"Hud X +");
		AddOption(L"Hud X -");
		AddOption(L"Hud Y +");
		AddOption(L"Hud Y -");
		AddOption(L"Hud W +");
		AddOption(L"Hud W -");
		AddOption(L"Hud H +");
		AddOption(L"Hud H -");
	}

	void DebugHudAlphaMenu()
	{
		submmenuMax = 9;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Debug HUD Alpha Menu");
		AddBoolOption(L"Enable Debug HUD Alpha", !DebugHudAlpha);
		AddOption(L"Hud X +");
		AddOption(L"Hud X -");
		AddOption(L"Hud Y +");
		AddOption(L"Hud Y -");
		AddOption(L"Hud W +");
		AddOption(L"Hud W -");
		AddOption(L"Hud H +");
		AddOption(L"Hud H -");
	}

	void DebugDrawLineMenu()
	{
		submmenuMax = 7;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Debug Draw Line Menu");
		AddBoolOption(L"Enable Draw Line", !DebugDrawLine);
		AddOption(L"Line X1 +");
		AddOption(L"Line X1 -");
		AddOption(L"Line X2 +");
		AddOption(L"Line X2 -");
		AddOption(L"Line Y1 +");
		AddOption(L"Line Y1 -");
		AddOption(L"Line Y2 +");
		AddOption(L"Line Y2 -");
		AddOption(L"Line Width +");
		AddOption(L"Line Width -");
	}

	void CustomImageMenu()
	{
		submmenuMax = 6;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Settings Menu");
		AddOption(L"Add Image");
		AddBoolOption(L"Add Banner", !UI::Settings::CustomImage);
		AddBoolOption(L"Add Banner Gif", !UI::Settings::CustomImageGif);
		AddOption(L"Add Opacity");
		AddOption(L"Remove Opacity");
		AddOption(L"Remove Image");
	}

	void MicsMenu()
	{
		submmenuMax = 10;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Settings Menu");
		AddBoolOption(L"Show Notif", !UI::Settings::ShowNotif);
		AddBoolOption(L"Show InfosBar", !UI::Settings::ShowInfosBar);
		AddBoolOption(L"New Style", !UI::Settings::Style);
		AddBoolOption(L"New Checkbox", !UI::Settings::Checkbox);
		AddBoolOption(L"Gradient Colors", !UI::Settings::GradientRGB);
		AddBoolOption(L"Show Scrollbar", !UI::Settings::Scrollbar);
		AddBoolOption(L"Add Opacity", !UI::Settings::BGOpacity);
		AddIntOption(L"Menu Lenght", 50, menulenght);
		AddIntOption(L"Change Opacity", 200, shadowBG);
		AddOption(L"Next Page");
	}

	void MicsMenu2()
	{
		submmenuMax = 6;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Settings Menu");
		AddOption(L"Exit Game");
		AddOption(L"Unload SPRX");
		AddOption(L"Restart Game");
		AddBoolOption(L"Checkbox V2", !UI::Settings::CheckboxV2);
		AddBoolOption(L"Show Logs", !UI::Settings::ShowLogs);
		AddBoolOption(L"BO2 Design Menu", !UI::Settings::BO2Design);
	}

	void CrosshairMenu()
	{
		submmenuMax = 2;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Custom Crosshair Menu");
		AddBoolOption(L"Enable Custom Crosshair", !custom_crosshair);
		AddIntOption(L"Custom Crosshair", 0, crosshair_value);
	}

	void DrawHeadLogoMenu()
	{
		submmenuMax = 1;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Draw Head Logo Menu");
		AddIntOption(L"Draw Head Logo", 1, DrawHeadPixelLogo);
	}

	void ShowMenu()
	{
		submmenuMax = 6;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Show Menu");
		AddBoolOption(L"Show Position", !UI::Settings::ShowPosition);
		AddBoolOption(L"Show Ping", !UI::Settings::ShowPING);
		AddBoolOption(L"Show Chunks", !UI::Settings::ShowChunks);
		AddBoolOption(L"Show Resolution", !UI::Settings::ShowResolution);
		AddBoolOption(L"Show CPU / RSX", !UI::Settings::ShowCPURSX);
		AddBoolOption(L"Show Gametime", !UI::Settings::ShowGametime);
	}

    #pragma endregion

    #pragma region "Credits Menu Pages"

	void CreditsMenu()
	{
		submmenuMax = 13;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Credits Menu");
		AddOption(L"Misakiii (Creator)");
		AddOption(L"NyTekCFW (Helper)");
		AddOption(L"PrismoMxdz (Helper)");
		AddOption(L"Magethsi (Helper)");
		AddOption(L"mizdx (Helper)");
		AddOption(L"TheRouletteBoi (helper)");
		AddOption(L"TheWaffleMan1337 (helper)");
		AddOption(L"Dublin Modz (helper)");
		AddOption(L"MayhemModding (helper)");
		AddOption(L"NELUxP MoDz (helper)");
		AddOption(L"d.s.j (helper)");
		AddOption(L"silver14818 (helper)");
		AddOption(L"gopro2027 (design idea)");

		if (CurrentOpt == 0) { AddInformation(submmenuMax, L"Discord: Misaki#9446");}
		if (CurrentOpt == 1) { AddInformation(submmenuMax, L"Discord: NyTekCFW#4315");}
		if (CurrentOpt == 4) { AddInformation(submmenuMax, L"Discord: mizdx#5066");}
		if (CurrentOpt == 7) { AddInformation(submmenuMax, L"Discord: VinDublin#5716");}
		if (CurrentOpt == 8) { AddInformation(submmenuMax, L"Discord: MayhemModding#3231");}
		if (CurrentOpt == 10) { AddInformation(submmenuMax, L"Discord: d.s.j.#0598");}
		if (CurrentOpt == 11) { AddInformation(submmenuMax, L"Discord: Guaros#9672"); }
	}

    #pragma endregion

    #pragma region "Config Menu Pages"

	void ConfigMenu()
	{
		submmenuMax = 2;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Config Menu");
		AddBoolOption(L"PvP Config", PvPConfig);
		AddBoolOption(L"Labymod Config", Labymode);
	}

    #pragma endregion

    #pragma region "Player Menu"

	void PlayerMenu()
	{
		submmenuMax = 8;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Player Menu");
		AddOption(L"[HOST] Misakiii");
		AddOption(L"NOT CONNECTED");
		AddOption(L"NOT CONNECTED");
		AddOption(L"NOT CONNECTED");
		AddOption(L"NOT CONNECTED");
		AddOption(L"NOT CONNECTED");
		AddOption(L"NOT CONNECTED");
		AddOption(L"NOT CONNECTED");

		if (CurrentOpt == 0) { AddInformation(submmenuMax, L"Still in developement :("); }
	}

    #pragma endregion

    #pragma region "Developer Menu"

	void DeveloperMenu()
	{
		submmenuMax = 3;
		AddHud(submmenuMax);
		AddTitle(L"DownCraft SPRX");
		AddDescription(L"Developer Menu");
		AddBoolOption(L"Disable Dev Mode", devmenu);
		AddOption(L"Restart Minecraft");
		AddOption(L"Uninject SPRX");
		AddInformation(submmenuMax, L"Dev menu still not finish yet :x");

		if (CurrentOpt == 1) { AddInformation(submmenuMax, L"Auto Restart Minecraft"); }
	}

    #pragma endregion
}