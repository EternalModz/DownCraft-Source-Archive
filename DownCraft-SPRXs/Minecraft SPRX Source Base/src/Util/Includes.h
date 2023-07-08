#pragma once

//INCLUDES PS3
#include <cellstatus.h>
#include <sys/prx.h>
#include <sys/ppu_thread.h>
#include <sys/timer.h>
#include <cell/pad.h>

//INCLUDES MINECRAFT
#include "Minecraft/gamemode/GameMode.h"
#include "Minecraft/client/Minecraft.h"
#include "Minecraft/entity/player/ServerPlayer.h"
#include "Minecraft/world/entity/DamageSource.h"
#include "Minecraft/util/Direction.h"
#include "Minecraft/world/level/block/BlockPos.h"
#include "Minecraft/client/gui/GuiComponent.h"

//INCLUDES MEMORY / UTIL
#include "Util/NewDeleteOverride.hpp"
#include "Util/TimeHelpers.hpp"
#include "Util/SystemCalls.hpp"

MultiPlayerLevel* g_Level;
MultiplayerLocalPlayer* g_Localplayer;
Minecraft* g_Minecraft;
MultiPlayerGameMode* g_Gamemode;
GuiComponent* g_GuiComponent;
Level* g_Level2;

//INCLUDES SOURCE
#include "Games/Buttons.h"
#include "Util/Variables.h"
#include "Games/PS3.h"
#include "Games/Vector.h"
#include "Games/Struct.h"
#include "Games/IDs.h"
#include "Games/GamesFunctions.h"
#include "Games/Functions.h"
#include "Menu/Huds.h"
#include "Games/Options.h"
#include "Menu/SubMenu.h"
#include "Menu/Menu.h"
#include "Games/Hooking.h"