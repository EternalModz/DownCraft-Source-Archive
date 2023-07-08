#pragma once


class DamageSource
{
	//uintptr_t IN_FIRE;
	//DamageSource* IN_FIRE = (DamageSource*)0x01511894;
public:
	DamageSource* IN_FIRE = (DamageSource*)0x01511894;
	DamageSource* LIGHTNING_BOLT = (DamageSource*)0x01511898;
	DamageSource* ON_FIRE = (DamageSource*)0x0151189C;
	DamageSource* LAVA = (DamageSource*)0x015118A0;
	DamageSource* HOT_FLOOR = (DamageSource*)0x015118A4;
	DamageSource* IN_WALL = (DamageSource*)0x015118A8;
	DamageSource* CRAMMING = (DamageSource*)0x015118AC;
	DamageSource* DROWN = (DamageSource*)0x015118B0;
	DamageSource* STARVE = (DamageSource*)0x015118B4;
	DamageSource* CACTUS = (DamageSource*)0x015118B8;
	DamageSource* FALL = (DamageSource*)0x015118BC;
	DamageSource* FLY_INTO_WALL = (DamageSource*)0x015118C0;
	DamageSource* OUT_OF_WORLD = (DamageSource*)0x015118C4;
	DamageSource* GENERIC = (DamageSource*)0x015118C8;
	DamageSource* MAGIC = (DamageSource*)0x015118CC;
	DamageSource* WITHER = (DamageSource*)0x015118D0;
	DamageSource* ANVIL = (DamageSource*)0x015118D4;
	DamageSource* FALLING_BLOCK = (DamageSource*)0x015118D8;
	DamageSource* DRAGON_BREATH = (DamageSource*)0x015118DC;
	DamageSource* FIREWORKS = (DamageSource*)0x015118E0;

public:
	void* m_vmt;
};