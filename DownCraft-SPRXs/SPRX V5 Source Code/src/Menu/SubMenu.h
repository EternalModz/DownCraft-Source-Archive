#pragma once

void RenderSubMenu()
{
	if (Opened)
	{
		switch (CurrentMenu)
		{
		case(MainMenu):
			MaxSubOptions = 12;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Main Menu");
			Menu->AddSubOption(L"Host Menu");
			Menu->AddSubOption(L"Non-Host Menu");
			Menu->AddSubOption(L"Players Menu");
			Menu->AddSubOption(L"Weather Menu");
			Menu->AddSubOption(L"Visions Menu");
			Menu->AddSubOption(L"Modules Menu");
			Menu->AddSubOption(L"Name Changer");
			Menu->AddSubOption(L"Game Editor");
			Menu->AddSubOption(L"Mini-Game Menu");
			Menu->AddSubOption(L"Teleport Menu");
			Menu->AddSubOption(L"Settings Menu");
			Menu->AddSubOption(L"Credits Menu");
			switch (getOption()) {
			case(0): openSubmenu(HostMenu); break;
			case(1): openSubmenu(NonHostMenu); break;
			case(2): openSubmenu(PlayerMenu); break;
			case(3): openSubmenu(WeatherMenu); break;
			case(4): openSubmenu(VisionsMenu); break;
			case(5): openSubmenu(ModulesMenu); break;
			case(6): openSubmenu(NameMenu); break;
			case(7): openSubmenu(GameEditor); break;
			case(8): openSubmenu(MiniGameMenu); break;
			case(9): openSubmenu(TeleportMenu); break;
			case(10): openSubmenu(SettingsMenu); break;
			case(11): openSubmenu(CreditsMenu); break;
			}
			break;

        #pragma region "Host Page"

		case(HostMenu):
			MaxSubOptions = 23;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Host Menu");
			Menu->AddBoolOption(L"God Mode", GodMode);
			Menu->AddBoolOption(L"Demi God Mode", DemiGodMode);
			Menu->AddIntOption(L"Instant Damage", 2, -500, 500, InstantDamage);
			Menu->AddBoolOption(L"Critical Hit", CriticalHit);
			Menu->AddBoolOption(L"Kill In Creative", KillInCreative);
			Menu->AddBoolOption(L"No Damage Hit", NoDamageHit);
			Menu->AddBoolOption(L"Knockback", Knockback);
			Menu->AddBoolOption(L"Anti Knockback", AntiKnockback);
			Menu->AddBoolOption(L"Reverse KB", ReverseKB);
			Menu->AddBoolOption(L"Drop Far Items", DropFarItems);
			Menu->AddBoolOption(L"Max XP Level", MaxXPLevel);
			Menu->AddBoolOption(L"Water Jump", WaterJump);
			Menu->AddBoolOption(L"Drift Boat", DriftBoat);
			Menu->AddBoolOption(L"Stop Arrows", StopArrows);
			Menu->AddBoolOption(L"Remove Arrows", RemoveArrows);
			Menu->AddBoolOption(L"Potion Flying", PotionsFlying);
			Menu->AddBoolOption(L"Potion Go Down", PotionsNoGravity);
			Menu->AddBoolOption(L"Inf Pickup Items", InfinitePickupItems);
			Menu->AddBoolOption(L"Max Pickup Items", MaxPickupItems);
			Menu->AddBoolOption(L"Infinite Blocks", InfiniteBlocks);
			Menu->AddBoolOption(L"Burn In Water", BurnInWater);
			Menu->AddBoolOption(L"Remove Fire", RemoveFire);
			Menu->AddSubOption(L"Next Page");
			switch (getOption()) {
			case(0): GodMode =! GodMode; Offsets->GOD_MODE(GodMode); break;
			case(1): DemiGodMode =! DemiGodMode; Offsets->DEMI_GOD_MODE(DemiGodMode); break;
			case(2): Offsets->INSTANT_DAMAGE(InstantDamage); break;
			case(3): CriticalHit =! CriticalHit; Offsets->CRITICAL_HIT(CriticalHit); break;
			case(4): KillInCreative =! KillInCreative; Offsets->KILL_IN_CREATIVE(KillInCreative); break;
			case(5): NoDamageHit =! NoDamageHit; Offsets->NO_DAMAGE_HIT(NoDamageHit); break;
			case(6): Knockback =! Knockback; Offsets->KNOCKBACK(Knockback); break;
			case(7): AntiKnockback =! AntiKnockback; Offsets->ANTI_KNOCKBACK(AntiKnockback); break;
			case(8): ReverseKB =! ReverseKB; Offsets->REVERSE_KNOCKBACK(ReverseKB); break;
			case(9): DropFarItems =! DropFarItems; Offsets->DROP_ITEMS_FAR(DropFarItems); break;
			case(10): MaxXPLevel =! MaxXPLevel; Offsets->MAX_LEVEL_XP(MaxXPLevel); break;
			case(11): WaterJump =! WaterJump; Offsets->WATER_JUMP(WaterJump); break;
			case(12): DriftBoat =! DriftBoat; Offsets->DRIFT_BOAT(DriftBoat); break;
			case(13): StopArrows =! StopArrows; Offsets->STOP_ARROWS(StopArrows); break;
			case(14): RemoveArrows =! RemoveArrows; Offsets->REMOVE_ARROWS(RemoveArrows); break;
			case(15): PotionsFlying =! PotionsFlying; Offsets->POTIONS_FLYING(PotionsFlying); break;
			case(16): PotionsNoGravity =! PotionsNoGravity; Offsets->POTIONS_NO_GRAVITY(PotionsNoGravity); break;
			case(17): InfinitePickupItems =! InfinitePickupItems; Offsets->INFINITE_PICKUP_ITEMS(InfinitePickupItems); break;
			case(18): MaxPickupItems =! MaxPickupItems; Offsets->MAX_PICKUP_ITEMS(MaxPickupItems); break;
			case(19): InfiniteBlocks =! InfiniteBlocks; Offsets->INFINITE_BLOCKS(InfiniteBlocks); break;
			case(20): BurnInWater =! BurnInWater; Offsets->BURN_IN_WATER(BurnInWater); break;
			case(21): RemoveFire =! RemoveFire; Offsets->REMOVE_FIRE(RemoveFire); break;
			case(22): openSubmenu(HostMenu2); break;
			}
			break;

		case(HostMenu2):
			MaxSubOptions = 23;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Host Menu");
			Menu->AddBoolOption(L"Creative Slot", CreativeSlot);
			Menu->AddBoolOption(L"Survival Slot", SurvivalSlot);
			Menu->AddBoolOption(L"Kill Spawn Entity", KillSpawnEntity);
			Menu->AddBoolOption(L"No Block Gravity", StopBlockGravity);
			Menu->AddBoolOption(L"No Hit Delay", NoHitDelay);
			Menu->AddBoolOption(L"Get Max Items", BypassMaxItems);
			Menu->AddBoolOption(L"Infinite Food", InfiniteFood);
			Menu->AddBoolOption(L"Mobs Ignore Me", MobIgnoreMe);
			Menu->AddBoolOption(L"Disable Portals", DisablePortals);
			Menu->AddBoolOption(L"Kill On Respawn", KillOnRespawn);
			Menu->AddBoolOption(L"Freeze Entity", FreezeAllEntity);
			Menu->AddBoolOption(L"No Enderman TP", StopEndermanTP);
			Menu->AddBoolOption(L"No Pressure", IgnoringPressure);
			Menu->AddBoolOption(L"All Enchant", AllEnchant);
			Menu->AddBoolOption(L"Items On Head", ItemsOnHead);
			Menu->AddBoolOption(L"Stop Boat", StopBoat);
			Menu->AddBoolOption(L"No Web", NoWeb);
			Menu->AddBoolOption(L"Entity God Mode", EntityGodMode);
			Menu->AddBoolOption(L"Regen Health", RegenerateHealth);
			Menu->AddBoolOption(L"Lock GameMode", LockGameMode);
			Menu->AddBoolOption(L"Lock Weather", LockWeather);
			Menu->AddBoolOption(L"Fast Bow", FastBow);
			Menu->AddSubOption(L"Next Page");
			switch (getOption()) {
			case(0): CreativeSlot =! CreativeSlot; Offsets->CREATIVE_SLOT(CreativeSlot); break;
			case(1): SurvivalSlot =! SurvivalSlot; Offsets->SURVIVAL_SLOT(SurvivalSlot); break;
			case(2): KillSpawnEntity =! KillSpawnEntity; Offsets->KILL_SPAWN_ENTITY(KillSpawnEntity); break;
			case(3): StopBlockGravity =! StopBlockGravity; Offsets->STOP_BLOCKS_GRAVITY(StopBlockGravity); break;
			case(4): NoHitDelay =! NoHitDelay; Offsets->NO_DELAY_HIT(NoHitDelay); break;
			case(5): BypassMaxItems =! BypassMaxItems; Offsets->BYPASS_MAX_ITEMS(BypassMaxItems); break;
			case(6): InfiniteFood =! InfiniteFood; Offsets->INFINITE_FOOD(InfiniteFood); break;
			case(7): MobIgnoreMe =! MobIgnoreMe; Offsets->MOBS_IGNORE_ME(MobIgnoreMe); break;
			case(8): DisablePortals =! DisablePortals; Offsets->DISABLE_PORTALS(DisablePortals); break;
			case(9): KillOnRespawn =! KillOnRespawn; Offsets->KILL_ON_RESPAWN(KillOnRespawn); break;
			case(10): FreezeAllEntity =! FreezeAllEntity; Offsets->FREEZE_ALL_ENTITY(FreezeAllEntity); break;
			case(11): StopEndermanTP =! StopEndermanTP; Offsets->STOP_ENDERMAN_TP(StopEndermanTP); break;
			case(12): IgnoringPressure =! IgnoringPressure; Offsets->IGNORING_PRESSURE(IgnoringPressure); break;
			case(13): AllEnchant =! AllEnchant; Offsets->ALL_ENCHANT(AllEnchant); break;
			case(14): ItemsOnHead =! ItemsOnHead; Offsets->ITEMS_ON_HEAD(ItemsOnHead); break;
			case(15): StopBoat =! StopBoat; Offsets->STOP_BOAT(StopBoat); break;
			case(16): NoWeb =! NoWeb; Offsets->NO_WEB(NoWeb); break;
			case(17): EntityGodMode =! EntityGodMode; Offsets->ENTITY_GOD_MODE(EntityGodMode); break;
			case(18): RegenerateHealth =! RegenerateHealth; Offsets->REGENERATE_HEART(RegenerateHealth); break;
			case(19): LockGameMode =! LockGameMode; Offsets->LOCK_GAMEMODE(LockGameMode); break;
			case(20): LockWeather =! LockWeather; Offsets->LOCK_WEATHER(LockWeather); break;
			case(21): FastBow =! FastBow; Offsets->FAST_BOW(FastBow); break;
			case(22): openSubmenu(HostMenu3); break;
			}
			break;

		case(HostMenu3):
			MaxSubOptions = 16;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Host Menu");
			Menu->AddBoolOption(L"Direction Arrows", DirectionArrows);
			Menu->AddOption(L"God Mode (ONLY ME)");
			Menu->AddBoolOption(L"Give Totem Health", TotemGiveHealth);
			Menu->AddBoolOption(L"TNT Nuclear", TntNuclear);
			Menu->AddBoolOption(L"TNT Particles", TntBigParticles);
			Menu->AddBoolOption(L"TNT Flying", TntFlying);
			Menu->AddBoolOption(L"TNT Explode", TntInstantExplode);
			Menu->AddBoolOption(L"No Spawn Mobs", DisableSpawnMobs);
			Menu->AddBoolOption(L"TNT Go Ground", TntGoInGround);
			Menu->AddBoolOption(L"TNT Sound Off", TntSoundOff);
			Menu->AddBoolOption(L"Big Creeper", BigCreeper);
			Menu->AddBoolOption(L"Creeper Nuclear", CreeperNuclear);
			Menu->AddBoolOption(L"Creeper Fire", CreeperFire);
			Menu->AddBoolOption(L"Disable Totem", DisableTotem);
			Menu->AddBoolOption(L"Glitch Dead Entit", GlitchDeadEntity);
			Menu->AddBoolOption(L"Infos Players", PlayersInfos);
			switch (getOption()) {
			case(0): DirectionArrows =! DirectionArrows; Offsets->DIRECTION_ARROWS(DirectionArrows); break;
			case(1): Offsets->GOD_MODE_FOR_ME(true); break;
			case(2): TotemGiveHealth =! TotemGiveHealth; Offsets->TOTEM_GIVE_HEALTH(TotemGiveHealth); break;
			case(3): TntNuclear =! TntNuclear; Offsets->TNT_NUCLEAR(TntNuclear); break;
			case(4): TntBigParticles =! TntBigParticles; Offsets->TNT_BIG_PARTICLES(TntBigParticles); break;
			case(5): TntFlying =! TntFlying; Offsets->TNT_FLYING(TntFlying); break;
			case(6): TntInstantExplode =! TntInstantExplode; Offsets->TNT_INSTANT_EXPLODE(TntInstantExplode); break;
			case(7): DisableSpawnMobs =! DisableSpawnMobs; Offsets->DISABLE_SPAWN_MOBS(DisableSpawnMobs); break;
			case(8): TntGoInGround =! TntGoInGround; Offsets->TNT_GO_IN_GROUND(TntGoInGround); break;
			case(9): TntSoundOff =! TntSoundOff; Offsets->TNT_SOUND_OFF(TntSoundOff); break;
			case(10): BigCreeper =! BigCreeper; Offsets->BIG_CREEPER(BigCreeper); break;
			case(11): CreeperNuclear =! CreeperNuclear; Offsets->CREEPER_NUCLEAR(CreeperNuclear); break;
			case(12): CreeperFire =! CreeperFire; Offsets->CREEPER_FIRE(CreeperFire); break;
			case(13): DisableTotem =! DisableTotem; Offsets->DISABLE_TOTEM(DisableTotem); break;
			case(14): GlitchDeadEntity =! GlitchDeadEntity; Offsets->GLITCHED_DEAD_ENTITY(GlitchDeadEntity); break;
			///case(15): PlayersInfos =! PlayersInfos; Offsets->player(PlayersInfos); break;
			}
			break;

            #pragma endregion
        #pragma region "Non-Host Page"

		case(NonHostMenu):
			MaxSubOptions = 23;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Non-Host Menu");
			Menu->AddIntOption(L"Super Speed", 38, -500, 500, SuperSpeed);
			Menu->AddBoolOption(L"Bunny Hop", BunnyHop);
			Menu->AddBoolOption(L"Phase Mode", PhaseMode);
			Menu->AddBoolOption(L"Static Block", BlockStaticCrack);
			Menu->AddBoolOption(L"Infinite Jump", InfiniteJump);
			Menu->AddBoolOption(L"Jump Build", JumpForBuild);
			Menu->AddBoolOption(L"Jump In Sky", JumpInSky);
			Menu->AddIntOption(L"Super Jump", 38, -500, 500, SuperJump);
			Menu->AddBoolOption(L"Jump Forward", JumpForward);
			Menu->AddBoolOption(L"Remove Jump", RemoveJump);
			Menu->AddBoolOption(L"Jump Speed", JumpSpeed);
			Menu->AddBoolOption(L"Fly Mode X", FlyModeX);
			Menu->AddBoolOption(L"Swim Fly", SwimFly);
			Menu->AddBoolOption(L"Movement Swim", MovementSwim);
			Menu->AddBoolOption(L"Swim Glitch", SwimGlitch);
			Menu->AddBoolOption(L"No Colission", NoColission);
			Menu->AddBoolOption(L"Items IDs", ItemsIds);
			Menu->AddBoolOption(L"Anti Kick", AntiKick);
			Menu->AddBoolOption(L"Stuck In Block", InBlock);
			Menu->AddBoolOption(L"Position View", PositionView);
			Menu->AddBoolOption(L"Crack Sound", FunnySound);
			Menu->AddBoolOption(L"Float UP", FloatUp);
			Menu->AddBoolOption(L"ESP Chests", ESPChests);
			Menu->AddOption(L"Next Page");
			switch (getOption()) {
			case(0): Offsets->SUPER_SPEED(SuperSpeed); break;
			case(1): BunnyHop =! BunnyHop; Offsets->AUTO_JUMP(BunnyHop); break;
			case(2): PhaseMode =! PhaseMode; Offsets->PHASE_MODE(PhaseMode); break;
			case(3): BlockStaticCrack =! BlockStaticCrack; Offsets->BLOCK_STATIC_CRACK(BlockStaticCrack); break;
			case(4): InfiniteJump =! InfiniteJump; Offsets->MULTI_JUMP(InfiniteJump); break;
			case(5): JumpForBuild =! JumpForBuild; Offsets->JUMP_FOR_BUILD(JumpForBuild); break;
			case(6): JumpInSky =! JumpInSky; Offsets->JUMP_IN_SKY(JumpInSky); break;
			case(7): Offsets->SUPER_JUMP(SuperJump); break;
			case(8): JumpForward =! JumpForward; Offsets->JUMP_FORWARD(JumpForward); break;
			case(9): RemoveJump =! RemoveJump; Offsets->REMOVE_JUMP(RemoveJump); break;
			case(10): JumpSpeed =! JumpSpeed; Offsets->JUMP_SPEED(JumpSpeed); break;
			case(11): FlyModeX =! FlyModeX; Offsets->FLY_MODE_X(FlyModeX); break;
			case(12): SwimFly = !SwimFly; Offsets->SWIM_FLY(SwimFly); break;
			case(13): MovementSwim =! MovementSwim; Offsets->MOVEMENT_SWIM(MovementSwim); break;
			case(14): SwimGlitch =! SwimGlitch; Offsets->SWIM_GLITCH(SwimGlitch); break;
			case(15): NoColission =! NoColission; Offsets->NO_COLISSION(NoColission); break;
			case(16): ItemsIds =! ItemsIds; Offsets->ITEMS_IDS(ItemsIds); break;
			case(17): AntiKick =! AntiKick; Offsets->ANTI_KICK(AntiKick); break;
			case(18): InBlock =! InBlock; Offsets->STUCK_IN_BLOCK(InBlock); break;
			case(19): FunnySound =! FunnySound; Offsets->FUNNY_SOUND(FunnySound); break;
			case(20): FloatUp =! FloatUp; Offsets->FLOAT_UP(FloatUp); break;
			case(21): ESPChests =! ESPChests; Offsets->ESP_CHESTS(ESPChests); break;
			case(22): openSubmenu(NonHostMenu2); break;
			}
			break;

		case(NonHostMenu2):
			MaxSubOptions = 23;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Non-Host Menu");
			Menu->AddBoolOption(L"Camera Down", CameraDown);
			Menu->AddBoolOption(L"Instant Mine", InstantMine);
			Menu->AddBoolOption(L"Infinite Craft", InfiniteCraft);
			Menu->AddBoolOption(L"Hud Mini Games", HudMiniGame);
			Menu->AddBoolOption(L"Anti Teleport", HudMiniGame);
			Menu->AddBoolOption(L"UFO Mode", UFOMode);
			Menu->AddBoolOption(L"Anti AFK", AntiAFK);
			Menu->AddBoolOption(L"Sensibility Fast", SensibilityFast);
			Menu->AddBoolOption(L"Sensibility Extrem", SensibilityExtrem);
			Menu->AddBoolOption(L"Walk Alone", WalkAlone);
			Menu->AddBoolOption(L"Name On Head", NameOverHead);
			Menu->AddBoolOption(L"Name On Head V2", NameOverHeadV2);
			Menu->AddBoolOption(L"Static Movement", StaticMovement);
			Menu->AddBoolOption(L"Walk In Sky", WalkInSky);
			Menu->AddBoolOption(L"Gravity Moon", GravityMoon);
			Menu->AddBoolOption(L"Look Forback", Lookforback);
			Menu->AddBoolOption(L"Camera Down R3", CameraDownR3);
			Menu->AddBoolOption(L"Better Time", BetterTime);
			Menu->AddBoolOption(L"See Out Map", SeeOutMap);
			Menu->AddBoolOption(L"Scaffold", Scaffold);
			Menu->AddBoolOption(L"Day & Night", DayAndNight);
			Menu->AddBoolOption(L"ESP Players", ESPPlayers);
			Menu->AddOption(L"Next Page");
			switch (getOption()) {
			case(0): CameraDown =! CameraDown; Offsets->CAMERA_DOWN(CameraDown); break;
			case(1): InstantMine =! InstantMine; Offsets->INSTANT_MINE(InstantMine); break;
			case(2): InfiniteCraft =! InfiniteCraft; Offsets->INFINITE_CRAFT(InfiniteCraft); break;
			case(3): HudMiniGame =! HudMiniGame; Offsets->HUD_MINI_GAME(HudMiniGame); break;
			case(4): AntiTeleport =! AntiTeleport; Offsets->ANTI_TELEPORT(AntiTeleport); break;
			case(5): UFOMode =! UFOMode; Offsets->UFO_MODE(UFOMode); break;
			case(6): AntiAFK =! AntiAFK; Offsets->ANTI_AFK(AntiAFK); break;
			case(7): SensibilityFast =! SensibilityFast; Offsets->SENSIBILITY_FAST(SensibilityFast); break;
			case(8): SensibilityExtrem =! SensibilityExtrem; Offsets->SENSIBILITY_EXTREM(SensibilityExtrem); break;
			case(9): WalkAlone =! WalkAlone; Offsets->WALK_ALONE(WalkAlone); break;
			case(10): NameOverHead =! NameOverHead; Offsets->NAME_OVER_HEAD(NameOverHead); break;
			case(11): NameOverHeadV2 =! NameOverHeadV2; Offsets->NAME_OVER_HEAD_V2(NameOverHeadV2); break;
			case(12): StaticMovement =! StaticMovement; Offsets->STATIC_MOVEMENT(StaticMovement); break;
			case(13): WalkInSky =! WalkInSky; Offsets->WALK_IN_SKY(WalkInSky); break;
			case(14): GravityMoon =! GravityMoon; Offsets->GRAVITY_MOON(GravityMoon); break;
			case(15): Lookforback =! Lookforback; Offsets->LOOK_FORBACK(Lookforback); break;
			case(16): CameraDownR3 =! CameraDownR3; Offsets->CAMERA_DOWN_R3(CameraDownR3); break;
			case(17): BetterTime =! BetterTime; Offsets->BETTER_TIME(BetterTime); break;
			case(18): SeeOutMap =! SeeOutMap; Offsets->SEE_OUT_MAP(SeeOutMap); break;
			case(19): Scaffold =! Scaffold; Offsets->SCAFFOLD(Scaffold); break;
			case(20): DayAndNight =! DayAndNight; Offsets->DAY_NIGHT(DayAndNight); break;
			case(21): ESPPlayers =! ESPPlayers; Offsets->ESP_PLAYERS(ESPPlayers); break;
			case(22): openSubmenu(NonHostMenu3); break;
			}
			break;

		case(NonHostMenu3):
			MaxSubOptions = 23;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Non-Host Menu");
			Menu->AddBoolOption(L"Can Fly", CanFly);
			Menu->AddBoolOption(L"Colission Entity", NoColissionEntity);
			Menu->AddBoolOption(L"Always Crouch", AlwaysOnCrouch);
			Menu->AddBoolOption(L"Get Players IDs", GetPlayersID);
			Menu->AddBoolOption(L"Player On Elyta", PlayersOnElytra);
			Menu->AddBoolOption(L"Water SlowDown", WaterSlowDown);
			Menu->AddBoolOption(L"Jump In Lava", JumpInLava);
			Menu->AddBoolOption(L"Crouch Mov", CrouchMovement);
			Menu->AddBoolOption(L"Pos Place Block", PosPlaceBlock);
			Menu->AddBoolOption(L"Destroy Game", DestroyGame);
			Menu->AddBoolOption(L"Levitation", Levitation);
			Menu->AddBoolOption(L"Return XMB", ReturnInXMB);
			Menu->AddBoolOption(L"Return XMB V2", ReturnInXMBV2);
			Menu->AddBoolOption(L"Add Fake Clone", AddFakeClone);
			Menu->AddBoolOption(L"Invisible Player", InvisiblePlayer);
			Menu->AddBoolOption(L"Auto Ladder", AutoLadder);
			Menu->AddBoolOption(L"Air To Water", AirToWater);
			Menu->AddBoolOption(L"Multi Jump V2", MultiJumpV2);
			Menu->AddBoolOption(L"Suicide Mode", SuicideMode);
			Menu->AddBoolOption(L"Game Static", GameSpeedStatic);
			Menu->AddBoolOption(L"Get 64 Items", Get64Items);
			Menu->AddBoolOption(L"Auto Jump", AutoJump);
			Menu->AddOption(L"Next Page");
			switch (getOption()) {
			case(0): CanFly =! CanFly; Offsets->CAN_FLY(CanFly); break;
			case(1): NoColissionEntity =! NoColissionEntity; Offsets->NO_COLISSION_ENTITY(NoColissionEntity); break;
			case(2): AlwaysOnCrouch =! AlwaysOnCrouch; Offsets->ALWAYS_CROUCH(AlwaysOnCrouch); break;
			case(3): GetPlayersID =! GetPlayersID; Offsets->GET_PLAYERS_IDS(GetPlayersID); break;
			case(4): PlayersOnElytra =! PlayersOnElytra; Offsets->PLAYERS_ON_ELYTRA(PlayersOnElytra); break;
			case(5): WaterSlowDown =! WaterSlowDown; Offsets->WATER_SLOWDOWN(WaterSlowDown); break;
			case(6): JumpInLava =! JumpInLava; Offsets->JUMP_IN_LAVA(JumpInLava); break;
			case(7): CrouchMovement =! CrouchMovement; Offsets->CROUCH_MOVEMENT(CrouchMovement); break;
			case(8): PosPlaceBlock =! PosPlaceBlock; Offsets->POSITION_PLACE_BLOCK(PosPlaceBlock); break;
			case(9): DestroyGame =! DestroyGame; Offsets->DESTROY_GAME(DestroyGame); break;
			case(10): Levitation =! Levitation; Offsets->LEVITATION(Levitation); break;
			case(11): ReturnInXMB =! ReturnInXMB; Offsets->RETURN_IN_XMB(ReturnInXMB); break;
			case(12): ReturnInXMBV2 =! ReturnInXMBV2; Offsets->RETURN_IN_XMB_V2(ReturnInXMBV2); break;
			case(13): AddFakeClone =! AddFakeClone; Offsets->ADD_FAKE_CLONE(AddFakeClone); break;
			case(14): InvisiblePlayer =! InvisiblePlayer; Offsets->INVISIBLE_PLAYERS(InvisiblePlayer); break;
			case(15): AutoLadder =! AutoLadder; Offsets->AUTO_LADDER(AutoLadder); break;
			case(16): AirToWater =! AirToWater; Offsets->AIR_TO_WATER(AirToWater); break;
			case(17): MultiJumpV2 =! MultiJumpV2; Offsets->MULTI_JUMP_V2(MultiJumpV2); break;
			case(18): SuicideMode =! SuicideMode; Offsets->SUICIDE_MODE(SuicideMode); break;
			case(19): GameSpeedStatic =! GameSpeedStatic; Offsets->GAME_SPEED_STATIC(GameSpeedStatic); break;
			case(20): Get64Items = !Get64Items; Offsets->GET_SPECIAL_ITEMS(Get64Items); break;
			case(21): AutoJump =! AutoJump; Offsets->AUTO_JUMP(AutoJump); break;
			case(22): openSubmenu(NonHostMenu4); break;
			}
			break;

		case(NonHostMenu4):
			MaxSubOptions = 23;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Non-Host Menu");
			Menu->AddBoolOption(L"Auto View", AutoChangeView);
			Menu->AddBoolOption(L"Auto Crouch", AutoCrouch);
			Menu->AddBoolOption(L"Auto Mine", AutoMine);
			Menu->AddBoolOption(L"Auto Hit", AutoHit);
			Menu->AddBoolOption(L"Auto Build", AutoBuild);
			Menu->AddBoolOption(L"ESP Waypoint", ESPWaypoint);
			Menu->AddBoolOption(L"Bat Eggs Crash", BatEggsCrash);
			Menu->AddBoolOption(L"Bat Eggs Freeze", BatEggsFreeze);
			Menu->AddBoolOption(L"Special Items", GetSpecialItems);
			Menu->AddBoolOption(L"Reach Attack", ReachAttack);
			Menu->AddBoolOption(L"Auto Sprint", AutoSprint);
			Menu->AddBoolOption(L"Auto Sprint V2", AutoSprintV2);
			Menu->AddBoolOption(L"Instant Hit", InstantHit);
			Menu->AddBoolOption(L"Kill Aura", KillAura);
			Menu->AddBoolOption(L"Fast Build", FastBuild);
			Menu->AddBoolOption(L"Critical Mode", CriticalMode);
			Menu->AddBoolOption(L"Critical Mode V2", CriticalModeV2);
			Menu->AddBoolOption(L"No SlowDown", NoSlowDown);
			Menu->AddBoolOption(L"No Hurt Cam", NoHurtCam);
			Menu->AddBoolOption(L"Press X For Hit", PressXForHit);
			Menu->AddBoolOption(L"Show Armor", ShowArmor);
			Menu->AddBoolOption(L"Unfair Attack", UnfairAttack);
			Menu->AddOption(L"Next Page");
			switch (getOption()) {
			case(0): AutoChangeView =! AutoChangeView; Offsets->AUTO_CHANGE_VIEW(AutoChangeView); break;
			case(1): AutoCrouch =! AutoCrouch; Offsets->AUTO_CROUCH(AutoCrouch); break;
			case(2): AutoMine =! AutoMine; Offsets->AUTO_MINE(AutoMine); break;
			case(3): AutoHit =! AutoHit; Offsets->AUTO_HIT(AutoHit); break;
			case(4): AutoBuild =! AutoBuild; Offsets->AUTO_BUILD(AutoBuild); break;
			case(5): ESPWaypoint =! ESPWaypoint; Offsets->ESP_WAYPOINT(ESPWaypoint); break;
			case(6): BatEggsCrash =! BatEggsCrash; Offsets->BAT_EGGS_CRASH(BatEggsCrash); break;
			case(7): BatEggsFreeze =! BatEggsFreeze; Offsets->BAT_EGGS_FREEZE(BatEggsFreeze); break;
			case(8): GetSpecialItems =! GetSpecialItems; Offsets->GET_SPECIAL_ITEMS(GetSpecialItems); break;
			case(9): ReachAttack =! ReachAttack; Offsets->REACH_ATTACK(ReachAttack); break;
			case(10): AutoSprint =! AutoSprint; Offsets->AUTO_SPRINT(AutoSprint); break;
			case(11): AutoSprintV2 =! AutoSprintV2; Offsets->AUTO_SPRINT_V2(AutoSprintV2); break;
			case(12): InstantHit =! InstantHit; Offsets->INSTANT_HIT(InstantHit); break;
			case(13): KillAura =! KillAura; Offsets->KILL_AURA(KillAura); break;
			case(14): FastBuild =! FastBuild; Offsets->FAST_BUILD(FastBuild); break;
			case(15): CriticalMode =! CriticalMode; Offsets->CRITICAL_MODE(CriticalMode); break;
			case(16): CriticalModeV2 =! CriticalModeV2; Offsets->CRITICAL_MODE_V1(CriticalModeV2); break;
			case(17): NoSlowDown =! NoSlowDown; Offsets->NO_SLOW_DOWN(NoSlowDown); break;
			case(18): NoHurtCam =! NoHurtCam; Offsets->REMOVE_HURT_CAM(NoHurtCam); break;
			case(19): PressXForHit =! PressXForHit; Offsets->PRESS_X_FOR_HIT(PressXForHit); break;
			case(20): ShowArmor =! ShowArmor; Offsets->SHOW_ARMOR(ShowArmor); break;
			case(21): UnfairAttack =! UnfairAttack; Offsets->UNFAIR_ATTACK(UnfairAttack); break;
			case(22): openSubmenu(NonHostMenu5); break;
			}
			break;

		case(NonHostMenu5):
			MaxSubOptions = 6;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Non-Host Menu");
			Menu->AddBoolOption(L"Hitbox BETA", HitBoxBETA);
			Menu->AddBoolOption(L"Big Velocity", BigVelocity);
			Menu->AddBoolOption(L"No Velocity", NoVelocity);
			Menu->AddBoolOption(L"ESP Entity", ESPEntity);
			Menu->AddBoolOption(L"ESP Tracer", ESPTracer);
			Menu->AddBoolOption(L"ESP COD", ESPCOD);
			switch (getOption()) {
			case(0): HitBoxBETA =! HitBoxBETA; Offsets->HITBOX_BETA(HitBoxBETA); break;
			case(1): BigVelocity =! BigVelocity; Offsets->BIG_VELOCITY(BigVelocity); break;
			case(2): NoVelocity =! NoVelocity; Offsets->NO_VELOCITY(NoVelocity); break;
			case(3): ESPEntity =! ESPEntity; Offsets->ENTITY_ESP(ESPEntity); break;
			case(4): ESPTracer =! ESPTracer; Offsets->ESP_TRACER(ESPTracer); break;
			case(5): ESPCOD =! ESPCOD; Offsets->ESP_COD(ESPCOD); break;
			}
			break;

        #pragma endregion
        #pragma region "Players Options"

		case(PlayerMenu):
			MaxSubOptions = 11;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Players Menu");
			Menu->AddBoolOption(L"Plrs Fast Mine", AllPlayersFastMine);
			Menu->AddBoolOption(L"Plrs Cant Mine", AllPlayersCantMine);
			Menu->AddBoolOption(L"Plrs Cant Run", AllPlayersCantRun);
			Menu->AddBoolOption(L"Plrs Speed", AllPlayersSpeed);
			Menu->AddBoolOption(L"Plrs Super Run", AllPlayersSuperRun);
			Menu->AddBoolOption(L"Plrs Zoom FOV", AllPlayersZoomFOV);
			Menu->AddBoolOption(L"Plrs Cant Join", PlayersCantJoin);
			Menu->AddBoolOption(L"All Change Hand", AllChangeHand);
			Menu->AddBoolOption(L"Plrs Suffocate", AllPlayersSuffocate);
			Menu->AddBoolOption(L"Plrs In Fire", AllPlayersInFire);
			Menu->AddOption(L"Plrs Freeze PS3");
			switch (getOption()) {
			case(0): AllPlayersFastMine =! AllPlayersFastMine; Offsets->ALL_PLAYERS_FAST_MINE(AllPlayersFastMine); break;
			case(1): AllPlayersCantMine =! AllPlayersCantMine; Offsets->ALL_PLAYERS_CANNOT_MINE(AllPlayersCantMine); break;
			case(2): AllPlayersCantRun =! AllPlayersCantRun; Offsets->ALL_PLAYERS_CANT_RUN(AllPlayersCantRun); break;
			case(3): AllPlayersSpeed =! AllPlayersSpeed; Offsets->ALL_PLAYERS_SUPER_SPEED(AllPlayersSpeed); break;
			case(4): AllPlayersSuperRun =! AllPlayersSuperRun; Offsets->ALL_PLAYERS_SUPER_RUN(AllPlayersSuperRun); break;
			//case(5): AllPlayersZoomFOV =! AllPlayersZoomFOV; Offsets->ALL_PLAYERS_CANT_RUN(AllPlayersZoomFOV); break;
			case(6): PlayersCantJoin =! PlayersCantJoin; Offsets->ALL_PLAYERS_CANT_JOIN_THE_WORLD(PlayersCantJoin); break;
			case(7): AllChangeHand =! AllChangeHand; Offsets->ALL_PLAYERS_CHANGE_HAND(AllChangeHand); break;
			case(8): AllPlayersSuffocate =! AllPlayersSuffocate; Offsets->ALL_PLAYERS_SUFFOCATE(AllPlayersSuffocate); break;
			case(9): AllPlayersInFire =! AllPlayersInFire; Offsets->ALL_PLAYERS_IN_FIRE(AllPlayersInFire); break;
			case(10): Offsets->ALL_PLAYERS_FREEZE_PS3(); break;
			}
			break;

        #pragma endregion
        #pragma region "Weather Options"

		case(WeatherMenu):
			MaxSubOptions = 7;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Weather Menu");
			Menu->AddBoolOption(L"Dark Storm", DarkStorm);
			Menu->AddBoolOption(L"Rainbow Storm", RainbowStorm);
			Menu->AddBoolOption(L"Rain To Snow", RainToSnow);
			Menu->AddBoolOption(L"Rain With Snow", RainbowWithSnow);
			Menu->AddBoolOption(L"Flash Sky", FlashSky);
			Menu->AddBoolOption(L"LightningBold V1", LightningBoldV1);
			Menu->AddBoolOption(L"LightningBold V2", LightningBoldV2);
			switch (getOption()) {
			case(0): DarkStorm =! DarkStorm; Offsets->WEATHER_DARK_STORM(DarkStorm); break;
			case(1): RainbowStorm =! RainbowStorm; Offsets->WEATHER_RAINBOW_STORM(RainbowStorm); break;
			case(2): RainToSnow =! RainToSnow; Offsets->WEATHER_RAIN_TO_SNOW(RainToSnow); break;
			case(3): RainbowWithSnow =! RainbowWithSnow; Offsets->WEATHER_RAINBOW_WITH_STORM(RainbowWithSnow); break;
			case(4): FlashSky =! FlashSky; Offsets->WEATHER_FLASH_SKY(FlashSky); break;
			case(5): LightningBoldV1 =! LightningBoldV1; Offsets->WEATHER_LIGHTNINGBOLD_V1(LightningBoldV1); break;
			case(6): LightningBoldV2 =! LightningBoldV2; Offsets->WEATHER_LIGHTNINGBOLD_V2(LightningBoldV2); break;
			}
			break;

#pragma endregion
        #pragma region "Vision Options"

		case(VisionsMenu):
			MaxSubOptions = 23;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Visions Menu");
			Menu->AddBoolOption(L"Xray Vision", XrayVision);
			Menu->AddBoolOption(L"Night Vision", NightVision);
			Menu->AddBoolOption(L"Apocalipse", Apocalipse);
			Menu->AddBoolOption(L"Funny Screen", FunnySound);
			Menu->AddBoolOption(L"Horror Vision", HorrorView);
			Menu->AddBoolOption(L"Animation Run", AnimationRun);
			Menu->AddBoolOption(L"Sky Rainbow", SkyRainbow);
			Menu->AddBoolOption(L"WTF View", WTFView);
			Menu->AddBoolOption(L"Size HUD", SizeHUD);
			Menu->AddBoolOption(L"Broken Texture", BrokenTexture);
			Menu->AddBoolOption(L"Shockwave", ShockWave);
			Menu->AddBoolOption(L"Wall Hack", WallHack);
			Menu->AddBoolOption(L"Wall Hack V2", WallHackV2);
			Menu->AddBoolOption(L"Wall Hack V3", WallhackV3);
			Menu->AddBoolOption(L"Plastic Texture", PlasticTexture);
			Menu->AddBoolOption(L"Ghost Texture", GhostPlastic);
			Menu->AddBoolOption(L"Blue Fog", BlueFog);
			Menu->AddBoolOption(L"Best Sky", BestSky);
			Menu->AddBoolOption(L"Shake Camera", ShakeCamera);
			Menu->AddBoolOption(L"More Light", MoreLight);
			Menu->AddBoolOption(L"Flat Items", FlatItems);
			Menu->AddBoolOption(L"Vibrate Walk", VibrateWalk);
			Menu->AddOption(L"Next Page");
			switch (getOption()) {
			case(0): XrayVision =! XrayVision; Offsets->XRAY_VISON(XrayVision); break;
			case(1): NightVision =! NightVision; Offsets->NIGHT_VISON(NightVision); break;
			case(2): Apocalipse =! Apocalipse; Offsets->APOCALIPSE(Apocalipse); break;
			case(3): FunnySound =! FunnySound; Offsets->FUNNY_SOUND(FunnySound); break;
			case(4): HorrorView =! HorrorView; Offsets->HORROR_VISION(HorrorView); break;
			case(5): AnimationRun =! AnimationRun; Offsets->ANIMATION_RUN(AnimationRun); break;
			//case(6): SkyRainbow =! SkyRainbow; Offsets->WORLD_LIGHT_RAINBOW(SkyRainbow); break;
			//case(7): WTFView =! WTFView; Offsets->ANIMATION_RUN(WTFView); break;
			case(8): SizeHUD =! SizeHUD; Offsets->SIZE_HUD(SizeHUD); break;
			case(9): BrokenTexture =! BrokenTexture; Offsets->BROKEN_TEXTURE(BrokenTexture); break;
			case(10): ShockWave =! ShockWave; Offsets->SHOCKWAVE(ShockWave); break;
			case(11): WallHack =! WallHack; Offsets->WALLHACK(WallHack); break;
			case(12): WallHackV2 =! WallHackV2; Offsets->WALLHACK_V2(WallHackV2); break;
			case(13): WallhackV3 =! WallhackV3; Offsets->WALLHACK_V3(WallhackV3); break;
			case(14): PlasticTexture =! PlasticTexture; Offsets->PLASTIC_TEXTURE(PlasticTexture); break;
			case(15): GhostPlastic =! GhostPlastic; Offsets->GHOST_TEXTURE(GhostPlastic); break;
			case(16): BlueFog =! BlueFog; Offsets->BLUE_FOG(BlueFog); break;
			case(17): BestSky =! BestSky; Offsets->BEST_SKY(BestSky); break;
			case(18): ShakeCamera =! ShakeCamera; Offsets->SHAKE_CAMERA(ShakeCamera); break;
			case(19): MoreLight =! MoreLight; Offsets->MORE_LIGHT(MoreLight); break;
			case(20): FlatItems =! FlatItems; Offsets->FLAT_ITEMS(FlatItems); break;
			case(21): VibrateWalk =! VibrateWalk; Offsets->VIBRATE_WALK(VibrateWalk); break;
			case(22): openSubmenu(VisionsMenu2); break;
			}
			break;

		case(VisionsMenu2):
			MaxSubOptions = 23;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Visions Menu");
			Menu->AddBoolOption(L"HUD Inv Down", HUDInvDown);
			Menu->AddBoolOption(L"Small Graphic", SmallGraphic);
			Menu->AddBoolOption(L"Particles Fly", ParticlesFly);
			Menu->AddBoolOption(L"Paper Model", PaperModel);
			Menu->AddIntOption(L"Big Model", 4, -255, 255, BigModel);
			Menu->AddBoolOption(L"Camera Left", CameraLeft);
			Menu->AddBoolOption(L"Camera Right", CameraRight);
			Menu->AddBoolOption(L"Big Particles", BigParticles);
			Menu->AddBoolOption(L"HUD Loading", HudLoading);
			Menu->AddBoolOption(L"Stars In Sky", StarsInSky);
			Menu->AddBoolOption(L"Step Fast", FootStepFast);
			Menu->AddBoolOption(L"Step Slow", FootStepSlow);
			Menu->AddBoolOption(L"Skins Debug", SkinsDebug);
			Menu->AddBoolOption(L"Shadow Skins", ShadowSkins);
			Menu->AddBoolOption(L"Skins Red", SkinsPlayersRed);
			Menu->AddBoolOption(L"Particles Fly", ParticlesFly1);
			Menu->AddBoolOption(L"Line Block Move", LineBlockMove);
			Menu->AddBoolOption(L"Disable Players", DisablePlayers);
			Menu->AddBoolOption(L"Small Text", SmallText);
			Menu->AddBoolOption(L"Pos Hud Text", PosHudText);
			Menu->AddBoolOption(L"Arms Broken", ArmsBroken);
			Menu->AddBoolOption(L"Black Fog", BlackFog);
			Menu->AddOption(L"Next Page");
			switch (getOption()) {
			case(0): HUDInvDown =! HUDInvDown; Offsets->HUD_INV_DOWN(HUDInvDown); break;
			case(1): SmallGraphic =! SmallGraphic; Offsets->SMALL_GRAPHIC(SmallGraphic); break;
			case(2): ParticlesFly =! ParticlesFly; Offsets->PARTICLES_FLY(ParticlesFly); break;
			case(3): PaperModel =! PaperModel; Offsets->PAPER_MODE(PaperModel); break;
			case(4): Offsets->BIG_MODEL(BigModel); break;
			case(5): CameraLeft =! CameraLeft; Offsets->CAMERA_LEFT(CameraLeft); break;
			case(6): CameraRight =! CameraRight; Offsets->CAMERA_RIGHT(CameraRight); break;
			case(7): BigParticles =! BigParticles; Offsets->BIG_PARTICLES(BigParticles); break;
			case(8): HudLoading =! HudLoading; Offsets->HUD_LOADING(HudLoading); break;
			case(9): StarsInSky =! StarsInSky; Offsets->STARS_IN_SKY(StarsInSky); break;
			case(10): FootStepFast =! FootStepFast; Offsets->FOOT_STEP_SLOW(FootStepFast); break;
			case(11): FootStepSlow =! FootStepSlow; Offsets->FOOT_STEP_SLOW(FootStepSlow); break;
			case(12): SkinsDebug =! SkinsDebug; Offsets->SKINS_DEBUG(SkinsDebug); break;
			case(13): ShadowSkins =! ShadowSkins; Offsets->SHADOW_SKINS(ShadowSkins); break;
			case(14): SkinsPlayersRed =! SkinsPlayersRed; Offsets->SKINS_RED_PLAYERS(SkinsPlayersRed); break;
			case(15): ParticlesFly1 =! ParticlesFly1; Offsets->PARTICLES_FLY_V1(ParticlesFly1); break;
			case(16): LineBlockMove =! LineBlockMove; Offsets->LINE_BLOCK_MOVE(LineBlockMove); break;
			case(17): DisablePlayers =! DisablePlayers; Offsets->DISABLE_PLAYERS(DisablePlayers); break;
			case(18): SmallText =! SmallText; Offsets->SMALL_TEXT(SmallText); break;
			case(19): PosHudText =! PosHudText; Offsets->POS_HUD_TEXT(PosHudText); break;
			case(20): ArmsBroken =! ArmsBroken; Offsets->ARMS_BROKEN(ArmsBroken); break;
			case(21): BlackFog =! BlackFog; Offsets->BLOCK_FOG(BlackFog); break;
			case(22): openSubmenu(VisionsMenu3); break;
			}
			break;

		case(VisionsMenu3):
			MaxSubOptions = 23;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Visions Menu");
			Menu->AddBoolOption(L"Sky Nether", SkyNether);
			Menu->AddBoolOption(L"Smoke Lobby", SmokeLobby);
			Menu->AddBoolOption(L"Under World", LookUnderWorld);
			Menu->AddBoolOption(L"Free Cam", FreeCam);
			Menu->AddBoolOption(L"Remove Hand", RemoveHand);
			Menu->AddBoolOption(L"Moving Particle", TornadoParticles);
			Menu->AddBoolOption(L"Hit Damage Red", HitDamageRed);
			Menu->AddBoolOption(L"Disable Fog", DisableFog);
			Menu->AddBoolOption(L"FOV No Hand", FovWithoutHand);
			Menu->AddBoolOption(L"Zoom No Hand", ZoomWithoutHand);
			Menu->AddBoolOption(L"Iron Helmet", IronHelmet);
			Menu->AddBoolOption(L"Entity To Baby", EntityBaby);
			Menu->AddBoolOption(L"No Detailed Skins", NoDetailedSkins);
			Menu->AddBoolOption(L"Aim 3Th Person", AimOn3thPerson);
			Menu->AddBoolOption(L"Render Entity", RenderEntity);
			Menu->AddBoolOption(L"360 Rotate Head", RotationCam);
			Menu->AddBoolOption(L"Texture To Black", TextureToBlack);
			Menu->AddBoolOption(L"Gamma To Max", GammaToMax);
			Menu->AddBoolOption(L"Name & Shadow", NameShadowBlack);
			Menu->AddBoolOption(L"Anim Character", AnimationCharacter);
			Menu->AddBoolOption(L"Big Anim Character", BigAnimCharacter);
			Menu->AddBoolOption(L"Rotation Body", RotationBody);
			Menu->AddOption(L"Next Page");
			switch (getOption()) {
			case(0): SkyNether =! SkyNether; Offsets->SKY_NETHER(SkyNether); break;
			case(1): SmokeLobby =! SmokeLobby; Offsets->SMOKE_LOBBY(SmokeLobby); break;
			case(2): LookUnderWorld =! LookUnderWorld; Offsets->LOOK_UNDER_WORLD(LookUnderWorld); break;
			case(3): FreeCam =! FreeCam; Offsets->FREE_CAM(FreeCam); break;
			case(4): RemoveHand =! RemoveHand; Offsets->REMOVE_HAND(RemoveHand); break;
			case(5): TornadoParticles =! TornadoParticles; Offsets->TORNADE_PARTICLES(TornadoParticles); break;
			case(6): HitDamageRed =! HitDamageRed; Offsets->HIT_DAMAGE_RED(HitDamageRed); break;
			case(7): DisableFog =! DisableFog; Offsets->DISABLE_FOG(DisableFog); break;
			case(8): FovWithoutHand =! FovWithoutHand; Offsets->FOV_WITHOUT_HAND(FovWithoutHand); break;
			//case(9): ZoomWithoutHand =! ZoomWithoutHand; Offsets->zoom(ZoomWithoutHand); break;
			case(10): IronHelmet =! IronHelmet; Offsets->IRON_HELMET_ON_ALL(IronHelmet); break;
			case(11): EntityBaby =! EntityBaby; Offsets->ENTITY_TO_BABY(EntityBaby); break;
			case(12): NoDetailedSkins =! NoDetailedSkins; Offsets->REMOVE_DETAILED_SKINS(NoDetailedSkins); break;
			case(13): AimOn3thPerson = !AimOn3thPerson; Offsets->AIM_ON_3TH_PERSON(AimOn3thPerson); break;
			case(14): RenderEntity = !RenderEntity; Offsets->RENDER_ENTITY(RenderEntity); break;
			case(15): RotationCam = !RotationCam; Offsets->ROTATION_HEAD(RotationCam); break;
			case(16): TextureToBlack = !TextureToBlack; Offsets->TEXTURE_TO_BLACK(TextureToBlack); break;
			case(17): GammaToMax =! GammaToMax; Offsets->GAMMA_TO_MAX(GammaToMax); break;
			case(18): NameShadowBlack =! NameShadowBlack; Offsets->NAME_AND_SHADOW_TO_BLACK(NameShadowBlack); break;
			case(19): AnimationCharacter =! AnimationCharacter; Offsets->ANIMATION_CHARACTER(AnimationCharacter); break;
			case(20): BigAnimCharacter =! BigAnimCharacter; Offsets->BIG_ANIM_CHARACTER(BigAnimCharacter); break;
			case(21): RotationBody =! RotationBody; Offsets->ROTATION_BODY(RotationBody); break;
			case(22): openSubmenu(VisionsMenu4); break;
			}
			break;

		case(VisionsMenu4):
			MaxSubOptions = 17;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Visions Menu");
			Menu->AddBoolOption(L"Entity Light", EntityBodyLight);
			Menu->AddBoolOption(L"Nether Vision", NetherVision);
			Menu->AddBoolOption(L"Hit Spam", ParticlesHitSpam);
			Menu->AddBoolOption(L"Roblox Animation", RobloxAnimation);
			Menu->AddBoolOption(L"Elytra Entity", Elytra);
			Menu->AddBoolOption(L"Move Head", MoveHeadNoBody);
			Menu->AddBoolOption(L"Stop Animation", StopAnimation);
			Menu->AddBoolOption(L"Giant Gameplay", GiantGameplay);
			Menu->AddBoolOption(L"Light White", WorldLightWhite);
			Menu->AddBoolOption(L"Rainbow Light", WorldRainbowLight);
			Menu->AddBoolOption(L"Shadow Skins", ShadowSkins);
			Menu->AddBoolOption(L"Double Name", DoubleName);
			Menu->AddBoolOption(L"Optimize Chunks", OptimizeChunks);
			Menu->AddBoolOption(L"Stop Chunks", StopChunksLoad);
			Menu->AddBoolOption(L"Real Jump Anim", RealJumpAnim);
			Menu->AddIntOption(L"FOV Value", 15, -255, 255, ValueFOV);
			Menu->AddBoolOption(L"Rainbow Sky", RainbowSky);
			switch (getOption()) {
			case(0): EntityBodyLight =! EntityBodyLight; Offsets->ENTITY_BODY_LIGHT(EntityBodyLight); break;
			case(1): NetherVision =! NetherVision; Offsets->NETHER_VISION(NetherVision); break;
			case(2): ParticlesHitSpam =! ParticlesHitSpam; Offsets->PARTICLES_HIT_SPAM(ParticlesHitSpam); break;
			case(3): RobloxAnimation =! RobloxAnimation; Offsets->ROBLOX_ANIMATION(RobloxAnimation); break;
			case(4): Elytra = !Elytra; Offsets->ENTITY_ELYTRA(Elytra); break;
			case(5): MoveHeadNoBody =! MoveHeadNoBody; Offsets->MOVE_HEAD_NO_BODY(MoveHeadNoBody); break;
			case(6): StopAnimation =! StopAnimation; Offsets->STOP_ANIMATION(StopAnimation); break;
			case(7): GiantGameplay =! GiantGameplay; Offsets->GIANT_GAMEPLAY(GiantGameplay); break;
			case(8): WorldLightWhite =! WorldLightWhite; Offsets->WORLD_LIGHT_WHITE(WorldLightWhite); break;
			case(10): WorldRainbowLight =! WorldRainbowLight; Offsets->WORLD_LIGHT_RAINBOW(WorldRainbowLight); break;
			case(11): ShadowSkins =! ShadowSkins; Offsets->SHADOW_SKINS(ShadowSkins); break;
			case(12): DoubleName =! DoubleName; Offsets->DOUBLE_NAME(DoubleName); break;
			case(13): OptimizeChunks =! OptimizeChunks; Offsets->OPTIMIZE_CHUNKS(OptimizeChunks); break;
			case(14): StopChunksLoad =! StopChunksLoad; Offsets->STOP_CHUNKS_LOAD(StopChunksLoad); break;
			case(15): RealJumpAnim =! RealJumpAnim; Offsets->REAL_JUMP_ANIM(RealJumpAnim); break;
			case(16): Offsets->REAL_JUMP_ANIM(ValueFOV); break;
			case(17): RainbowSky =! RainbowSky; Offsets->WORLD_LIGHT_RAINBOW(RainbowSky); break;
			}
			break;

            #pragma endregion
        #pragma region "Modules Options"

		case(ModulesMenu):
			MaxSubOptions = 7;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Modules Menu");
			Menu->AddBoolOption(L"Zoom Mode", Zoom);
			Menu->AddBoolOption(L"TP Aura", TPAura);
			Menu->AddBoolOption(L"Nuker", Nuker);
			Menu->AddIntOption(L"Nuker Radius", 3, -255, 255, sizeNuker);
			Menu->AddBoolOption(L"Auto Toss", AutoTossItems);
			Menu->AddBoolOption(L"Anti Void", AntiVoidtoggle);
			Menu->AddBoolOption(L"Key Strokes", keystrokes);
			switch (getOption()) {
			case(0): XrayVision = !XrayVision; Offsets->XRAY_VISON(XrayVision); break;
			}
			break;

#pragma endregion
        #pragma region "Name Changer"

		case(NameMenu):
			MaxSubOptions = 9;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Name Changer");
			Menu->AddOption(L"Enter a text");
			Menu->AddOption(L"DownCraft SPRX");
			Menu->AddOption(L"ABCDEFGHIJKLMNO...");
			Menu->AddOption(L"Your IP is...");
			Menu->AddOption(L"No Name");
			Menu->AddOption(L"Long Name");
			Menu->AddOption(L"*************");
			Menu->AddOption(L"Hentai");
			Menu->AddOption(L"сука блять");
			switch (getOption()) {
			case(0): Offsets->setName("ok"); break;
			case(1): Offsets->setName("DownCraft SPRX"); break;
			}
			break;

         #pragma endregion
        #pragma region "Game Editor"

		case(GameEditor):
			MaxSubOptions = 6;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Game Editor");
			Menu->AddSubOption(L"Block Changer");
			Menu->AddSubOption(L"Eggs Changer");
			Menu->AddSubOption(L"Items Changer");
			Menu->AddSubOption(L"Enchant Changer");
			Menu->AddSubOption(L"Particles Changer");
			Menu->AddSubOption(L"Sounds Changer");
			switch (getOption()) {
			case(0): break;
			}
			break;

        #pragma endregion
        #pragma region "Mini-Game Options"

		case(MiniGameMenu):
			MaxSubOptions = 12;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Mini-Games Menu");
			Menu->AddBoolOption(L"Can Craft", !CanCraft);
			Menu->AddBoolOption(L"Can Place Block", !CanPlaceBlocks);
			Menu->AddBoolOption(L"See Spectator", !CanSeeSpectator);
			Menu->AddBoolOption(L"Plrs Starved", !PlayersAreStarved);
			Menu->AddBoolOption(L"Allow Portals", !AllowPortals);
			Menu->AddBoolOption(L"Tnt Can Destroy", !TntCanDestroyBlocks);
			Menu->AddBoolOption(L"Max In Small Map", !MaxPlayersSmallMap);
			Menu->AddBoolOption(L"Crea Inv Lobby", !CreativeInventory);
			Menu->AddBoolOption(L"Destroy Block", !CanDestroyBlocks);
			Menu->AddBoolOption(L"Game Survival", !GameModeToSurvival);
			Menu->AddBoolOption(L"Inv Crea Tumble", !InventoryCreaTumbleActive);
			Menu->AddSubOption(L"Teleport Location");
			switch (getOption()) {
			case(0): break;
			}
			break;

		case(MiniGameTPLocation):
			MaxSubOptions = 4;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Teleport Location");
			Menu->AddOption(L"TP To Lobby");
			Menu->AddOption(L"TP To Cavern");
			Menu->AddOption(L"TP To Cove");
			Menu->AddOption(L"TP To Crucible");
			switch (getOption()) {
			case(0): break;
			}
			break;

        #pragma endregion
        #pragma region "Teleport Options"

		case(TeleportMenu):
			MaxSubOptions = 5;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Teleport Menu");
			Menu->AddIntOption(L"Teleport Y", 0, -999, 999, TeleportX);
			Menu->AddIntOption(L"Teleport X", 1, -999, 999, TeleportY);
			Menu->AddIntOption(L"Teleport Y", 2, -999, 999, TeleportZ);
			Menu->AddOption(L"Get Teleport");
			Menu->AddOption(L"Set Teleport");
			GetTeleportXYZ();
			switch (getOption()) {
			case(3): Offsets->getLocation(); break;
			case(4): Offsets->setLocation(TeleportX, TeleportY, TeleportZ); break;
			}
			break;

        #pragma endregion
        #pragma region "Settings Options"

		case(SettingsMenu):
			MaxSubOptions = 3;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Settings Menu");
			Menu->AddSubOption(L"Theme Colors");
			Menu->AddSubOption(L"Menu Editing");
			Menu->AddSubOption(L"Banner Menu");
			switch (getOption()) {
			case(0): openSubmenu(ThemeMenu); break;
			case(1): openSubmenu(MenuEditing); break;
			case(2): openSubmenu(BannerMenu); break;
			}
			break;

		case(ThemeMenu):
			MaxSubOptions = 3;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Settings Menu");
			Menu->AddIntOption(L"Red  ", 0, 0, 255, MenuR);
			Menu->AddIntOption(L"Green", 1, 0, 255, MenuG);
			Menu->AddIntOption(L"Blue ", 2, 0, 255, MenuB);
			switch (getOption()) {
			case(0): break;
			}
			break;

		case(MenuEditing):
			MaxSubOptions = 5;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Menu Editing");
			Menu->AddIntOption(L"Menu X", 0, -999, 999, MenuX);
			Menu->AddIntOption(L"Menu Y", 1, -999, 999, MenuY);
			Menu->AddBoolOption(L"Add Description", DescInfo);
			Menu->AddBoolOption(L"Border Menu", BorderMenu);
			Menu->AddIntOption(L"Menu Lenght", 7, -255, 500, menuLenght);
			switch (getOption()) {
			case(2): DescInfo =! DescInfo; break;
			case(3): BorderMenu =! BorderMenu; break;
			}
			break;

		case(BannerMenu):
			MaxSubOptions = 1;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Banner Menu");
			Menu->AddBoolOption(L"Custom Banner", CustomBanner);
			switch (getOption()) {
			case(0): ToggleBanner(); break;
			}
			break;

        #pragma endregion
        #pragma region "Credits Options"

		case(CreditsMenu):
			MaxSubOptions = 13;
			Menu->AddHuds(MaxSubOptions);
			Menu->AddTitle(titleSPRX);
			Menu->Description(L"Credits Menu");
			Menu->AddOption(L"Misakiii (Creator)");
			Menu->AddOption(L"NyTekCFW (Helper)");
			Menu->AddOption(L"PrismoMxdz (Helper)");
			Menu->AddOption(L"Magethsi (Helper)");
			Menu->AddOption(L"mizdx (Helper)");
			Menu->AddOption(L"TheRouletteBoi (helper)");
			Menu->AddOption(L"TheWaffleMan1337 (helper)");
			Menu->AddOption(L"Dublin Modz (helper)");
			Menu->AddOption(L"MayhemModding (helper)");
			Menu->AddOption(L"NELUxP MoDz (helper)");
			Menu->AddOption(L"d.s.j (helper)");
			Menu->AddOption(L"silver14818 (helper)");
			Menu->AddOption(L"gopro2027 (design idea)");
			switch (getOption()) {
			case(0): break;
			}
			break;

        #pragma endregion
		}
	}
}