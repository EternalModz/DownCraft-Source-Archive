#pragma once

#include "Minecraft/entity/Entity.h"
#include "Minecraft/entity/player/ServerPlayer.h"
#include "Minecraft/world/entity/DamageSource.h"
#include <string>
#include <vector>
#include "Minecraft/util/AABB.h"
#include "Minecraft/util/Vec2.h"
#include "Minecraft/util/Vec3.h"
#include "Modules.h"

#pragma region "ASM"

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

int asm_destroyBlockHook(MultiPlayerGameMode* gamemode, BlockPos* blockPos) // ou (...) si tu veux opti apres  sa depend des fois sa marche des fois non!
{
    __nop(); __nop(); __nop(); __nop(); __nop();
	//__asm("li %r3, 0x332;");
}

void asm_LivingEntity_HurtHook(Entity* entity, EntityDamageSource* entityDamageSource, float damage)
{
    __nop(); __nop(); __nop(); __nop(); __nop();
    //__asm("li %r3, 0x332;");
}

void asm_Player_HurtHook(ServerPlayer* player, DamageSource* damageSource, float damage)
{
    __nop(); __nop(); __nop(); __nop(); __nop();
}

uint32_t asm_LivingEntity_onChangedBlockHook(Entity* entity, BlockPos* pos)
{
	__nop(); __nop(); __nop(); __nop(); __nop();
}

#pragma endregion

int MultiPlayerGameMode_destroyBlockHook(MultiPlayerGameMode* gamemode, BlockPos* blockPos)
{
	if (Nuker)
	{
		if (sizeNuker > 0)
		{
			for (int x = -sizeNuker; x < sizeNuker; x++)
			{
				for (int y = -sizeNuker; y < sizeNuker; y++)
				{
					for (int z = -sizeNuker; z < sizeNuker; z++)
					{
						blockPos->x = (int)mc->theMinecraft->cMultiplayerLocalPlayer->posX + x;
						blockPos->y = (int)mc->theMinecraft->cMultiplayerLocalPlayer->posY + y;
						blockPos->z = (int)mc->theMinecraft->cMultiplayerLocalPlayer->posZ + z;

						asm_destroyBlockHook(gamemode, blockPos);
					}
				}
			}
		}
	}
}

void LivingEntity_HurtHook(Entity* entity, EntityDamageSource* entityDamageSource, float damage)
{
	//FUNCTIONS::Player_getAttachPos(entity, 10);
    asm_LivingEntity_HurtHook(entity, entityDamageSource, damage);
}

void Player_actuallyHurtHook(ServerPlayer* player, DamageSource* damageSource, float damage)
{
	if (player->isAlive())
		debug_entity_alive = true;
	else
		debug_entity_alive = false;

	Modules::TP_Aura(player);

    asm_Player_HurtHook(player, damageSource, damage);
}

uint32_t LivingEntity_onChangedBlockHook(Entity* entity, BlockPos* pos)
{
	FUNCTIONS::FrostWalkerEnchantment_onEntityMoved(&entity->m_this, entity->m_multiPlayerLevel2, pos, 255);
	return asm_LivingEntity_onChangedBlockHook(entity, pos);
}

void InstallHooks()
{
	HookFunctionStart(0x01084270, *(uint32_t*)(sceNpBasicSetPresenceDetails_Hook), *(uint32_t*)(asm_SetPresenceDetails_Hook));
	HookFunctionStart(0x3A7F48, *(uint32_t*)(LivingEntity_HurtHook), *(uint32_t*)(asm_LivingEntity_HurtHook));
	HookFunctionStart(0x4A94B8, *(uint32_t*)(Player_actuallyHurtHook), *(uint32_t*)(asm_Player_HurtHook));
	HookFunctionStart(0xB34A6C, *(uint32_t*)(MultiPlayerGameMode_destroyBlockHook), *(uint32_t*)(asm_destroyBlockHook));
	//HookFunctionStart(0xAE1A04, *(uint32_t*)(LivingEntity_onChangedBlockHook), *(uint32_t*)(asm_LivingEntity_onChangedBlockHook));
}

void UninstallHooks()
{
	UnHookFunctionStart(gameRenderHook, *(uint32_t*)(gameRender_Stub));
	UnHookFunctionStart(0x01084270, *(uint32_t*)(sceNpBasicSetPresenceDetails_Hook));
	UnHookFunctionStart(0x3A7F48, *(uint32_t*)(LivingEntity_HurtHook));
	UnHookFunctionStart(0x4A94B8, *(uint32_t*)(Player_actuallyHurtHook));
	UnHookFunctionStart(0xB34A6C, *(uint32_t*)(MultiPlayerGameMode_destroyBlockHook));
	//UnHookFunctionStart(0xAE1A04, *(uint32_t*)(LivingEntity_onChangedBlockHook));
}