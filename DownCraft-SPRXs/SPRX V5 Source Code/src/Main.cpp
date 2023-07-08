﻿/*
___  ____                            __ _     ___________________   __
|  \/  (_)                          / _| |   /  ___| ___ \ ___ \ \ / /
| .  . |_ _ __   ___  ___ _ __ __ _| |_| |_  \ `--.| |_/ / |_/ /\ V /
| |\/| | | '_ \ / _ \/ __| '__/ _` |  _| __|  `--. \  __/|    / /   \
| |  | | | | | |  __/ (__| | | (_| | | | |_  /\__/ / |   | |\ \/ /^\ \
\_|  |_/_|_| |_|\___|\___|_|  \__,_|_|  \__| \____/\_|   \_| \_\/   \/

                          Made by Misaki
*/

#include "Util/Includes.h"

SYS_MODULE_INFO(Minecraft, 0, 1, 1);
SYS_MODULE_START(Minecraft_Main);
SYS_MODULE_STOP(Minecraft_Stop);

extern "C" int Minecraft_Main(void)
{
	Dialog::msgdialog_mode = Dialog::MODE_RUNNING;
	Dialog::ProgressBar("DownCraft SPRX\nVersion: 5.0\n\nInstruction: for open the menu press  + \nThis menu has been created by Misaki\nFor any informations, join the discord server\n\ndiscord.gg/yv35ubUr4U", "DownCraft", 20);
	Dialog::End();

	InstallHooks();
	return SYS_PRX_RESIDENT;
}
extern "C" int Minecraft_Stop(void)
{
	UninstallHooks();
	return SYS_PRX_RESIDENT;
}