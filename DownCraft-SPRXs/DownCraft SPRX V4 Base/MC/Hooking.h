#pragma once

void gameRender_Stub(uint32_t r3, uint32_t r4)
{
	__nop(); __nop(); __nop(); __nop(); __nop();
}

int asm_SetPresenceDetails_Hook(SceNpBasicPresenceDetails2* pres, uint32_t options)
{
	__nop(); __nop(); __nop(); __nop(); __nop();
}
int sceNpBasicSetPresenceDetails_Hook(SceNpBasicPresenceDetails2* pres, uint32_t options)
{
	strncpy(pres->status, "Using \uF477 DownCraft SPRX V4 \uF477", 30);

	return asm_SetPresenceDetails_Hook(pres, options);
}

int asm_actuallyHurtHook(Entity* entity, EntityDamageSource* entityDamageSource, float damage)
{
	__asm("li %r3, 0x332;");
}

void LivingEntity_actuallyHurtHook(Entity* entity, EntityDamageSource* entityDamageSource, float damage)
{
	damage = 99.f;
	asm_actuallyHurtHook(entity, entityDamageSource, damage);
}

int asm_destroyBlockHook(MultiPlayerGameMode* gamemode, BlockPos* blockPos) // ou (...) si tu veux opti apres  sa depend des fois sa marche des fois non
{
	__asm("li %r3, 0x332;");
}
int MultiPlayerGameMode_destroyBlockHook(MultiPlayerGameMode* gamemode, BlockPos* blockPos)
{
	int size = 5;
	for (int x = 0 - size / 2; x < size / 2; x++)
	{
		for (int y = 0 - size / 2; y < size / 2; y++)
		{
			for (int z = 0 - size / 2; z < size / 2; z++)
			{
				blockPos->x += y;
				blockPos->y += y;
				blockPos->z += z;
			}
		}
	}
	return asm_destroyBlockHook(gamemode, blockPos);
}