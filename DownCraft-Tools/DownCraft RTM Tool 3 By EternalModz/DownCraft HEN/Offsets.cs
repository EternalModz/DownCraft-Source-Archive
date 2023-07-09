/*
 * Offsets Minecraft 1.84 made by Misakiii
 * 
 * This file contains all options 
 * for use it just use name_of_options(true); or name_of_options(false);
 * 
 * Credits to NELUxP MoDz, Mayhem Modding, Dublin Modz, Misakiii
 * 
 * Nobody know Minecraft codes better that us, so don't think you can do it better
 * 
 * -Misakiii (I'm still the best <3)
 */

#region "Library"

using PS3Lib;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace DownCraft
{
    public class Offsets
    {
        #region "Variables"

        PS3API PS3 = new PS3API();
        Functions FUNCTIONS = new Functions();

        public string LastPlayersJoinedPSN = ""; //Get the last PSN name joined your world
        public string LastPlayersRegion = ""; //Get the region of the last players joined your world
        public string LastPlayersAvatar = ""; //Get avatar of the last players joined your world
        public string GetPingz = "-1"; //Get ping

        //Default Swap Items
        public uint Offset_Default_Items = 0x0000000; //used for get the swapper items
        public byte[] Items_Default_Items = { 0x00 }; //used for get the swapper items

        //Default Swap Blocks
        public uint Offset_Default_Blocks = 0x0000000; //used for get the swapper blocks
        public byte[] Blocks_Default_Blocks = { 0x00 }; //used for get the swapper blocks

        #endregion


        #region "Changing Effect"

        public static byte[] ModEffectsSPEED = { 0x32, 0x1B, 0x8C, 0xD0 };
        public static byte[] MobEffectsSLOWNESS = { 0x32, 0x1B, 0x8D, 0x10 };
        public static byte[] MobEffectsHASTE = { 0x32, 0x1B, 0x95, 0x40 };
        public static byte[] MobEffectsMINING_FATIGUE = { 0x32, 0x1B, 0x96, 0x90 };
        public static byte[] MobEffectsSTRENGTH = { 0x32, 0x1B, 0x97, 0xE0 };
        public static byte[] MobEffectsINSTANT_HEALTH = { 0x32, 0x1B, 0x99, 0x40 };
        public static byte[] MobEffectsINSTANT_DAMAGE = { 0x32, 0x1B, 0x9A, 0x40 };
        public static byte[] MobEffectsJUMP_BOOST = { 0x32, 0x1B, 0x9B, 0x40 };
        public static byte[] MobEffectsNAUSEA = { 0x32, 0x1B, 0x9C, 0x40 };
        public static byte[] MobEffectsREGENERATION = { 0x32, 0x1B, 0x9D, 0x80 };
        public static byte[] MobEffectsRESISTANCE = { 0x32, 0x1B, 0x9E, 0x80 };
        public static byte[] MobEffectsFIRE_RESISTANCE = { 0x32, 0x1B, 0x9F, 0x80 };
        public static byte[] MobEffectsWATER_BREATHING = { 0x32, 0x1B, 0xA0, 0x80 };
        public static byte[] MobEffectsINVISIBILITY = { 0x32, 0x1B, 0x9C, 0x80 };
        public static byte[] MobEffectsBLINDNESS = { 0x32, 0x1B, 0xA2, 0x90 };
        public static byte[] MobEffectsNIGHT_VISION = { 0x32, 0x1B, 0xA3, 0x90 };
        public static byte[] MobEffectsHUNGER = { 0x32, 0x1B, 0xA4, 0x90 };
        public static byte[] MobEffectsWEAKNESS = { 0x32, 0x1B, 0xA5, 0x90 };
        public static byte[] MobEffectsPOISON = { 0x32, 0x1B, 0x93, 0xE0 };
        public static byte[] MobEffectsWITHER = { 0x32, 0x1B, 0xA0, 0xC0 };
        public static byte[] MobEffectsHEALTH_BOOST = { 0x32, 0x1B, 0x93, 0x30 };
        public static byte[] MobEffectsABSORPTION = { 0x32, 0x1B, 0xAB, 0x30 };
        public static byte[] MobEffectsSATURATION = { 0x32, 0x1B, 0xAC, 0x30 };
        public static byte[] MobEffectsGLOWING = { 0x32, 0x1B, 0xAD, 0x30 };
        public static byte[] MobEffectsLEVITATION = { 0x32, 0x1B, 0xAE, 0x30 };
        public static byte[] MobEffectsLUCK = { 0x32, 0x1B, 0xAF, 0x30 };
        public static byte[] MobEffectsUNLUCK = { 0x32, 0x1B, 0xB0, 0x80 };
        public static byte[] MobEffectsCONDUIT_POWER = { 0x32, 0x1B, 0xB1, 0xD0 };
        public static byte[] MobEffectsSLOW_FALLING = { 0x32, 0x1B, 0xB3, 0x20 };

        #endregion


        #region "Timer Regeneration"

        //timer changer for totem regenerations MAX = 25:00
        public static byte[] MobEffectTimer1 = { 0x38, 0xA0, 0x03, 0x20 }; //default time for regeneration 0:36 
        public static byte[] MobEffectTimer2 = { 0x38, 0xA0, 0x08, 0x20 }; //default time for regeneration 1:43
        public static byte[] MobEffectTimer3 = { 0x38, 0xA0, 0x10, 0x20 }; //default time for regeneration 3:26 
        public static byte[] MobEffectTimer4 = { 0x38, 0xA0, 0x20, 0x20 }; //default time for regeneration 6:51
        public static byte[] MobEffectTimer5 = { 0x38, 0xA0, 0x30, 0x20 }; //default time for regeneration 10:16 
        public static byte[] MobEffectTimer6 = { 0x38, 0xA0, 0x40, 0x20 }; //default time for regeneration 13:40
        public static byte[] MobEffectTimer7 = { 0x38, 0xA0, 0x60, 0x20 }; //default time for regeneration 20:30
        public static byte[] MobEffectTimer8 = { 0x38, 0xA0, 0x70, 0x80 }; //default time for regeneration 24:00

        #endregion


        #region "Changing Items"

        public byte[] Items_air = { 0x32, 0x1C, 0x0A, 0x60 };
        public byte[] Items_flint_and_steel = { 0x32, 0x1E, 0xA4, 0x60 };
        public byte[] Items_string = { 0x32, 0x1E, 0xF5, 0x00 };
        public byte[] Items_bow = { 0x32, 0x1E, 0xA9, 0xD0 };
        public byte[] Items_arrow = { 0x32, 0x1E, 0xAD, 0xA0 };
        public byte[] Items_spectral_arrow = { 0x32, 0x20, 0x8D, 0xA0 };
        public byte[] Items_tipped_arrow = { 0x32, 0x20, 0x8F, 0xF0 };
        public byte[] Items_bucket_lava = { 0x32, 0x1F, 0x6B, 0x20 };
        public byte[] Items_diamond = { 0x32, 0x1E, 0xB2, 0x40 };
        public byte[] Items_diamond_shovel = { 0x32, 0x1E, 0xD8, 0x30 };
        public byte[] Items_diamond_pickaxe = { 0x32, 0x1E, 0xDB, 0x50 };
        public byte[] Items_diamond_axe = { 0x32, 0x1E, 0xDE, 0x70 };
        public byte[] Items_diamond_sword = { 0x32, 0x1E, 0xD5, 0x20 };
        public byte[] Items_diamond_hoe = { 0x32, 0x1F, 0x05, 0x20 };
        public byte[] Items_apple = { 0x32, 0x1E, 0xA7, 0x70 };
        public byte[] Items_coocked_porkchop = { 0x32, 0x1F, 0x5A, 0xD0 };
        public byte[] Items_golden_apple = { 0x32, 0x1F, 0x5F, 0x80 };
        public byte[] Items_snowball = { 0x32, 0x1F, 0x76, 0xB0 };
        public byte[] Items_furnace = { 0x32, 0x1F, 0x8F, 0xC0 };
        public byte[] Items_egg = { 0x32, 0x1F, 0x91, 0x50 };
        public byte[] Items_cooked_beef = { 0x32, 0x1F, 0xC3, 0x80 };
        public byte[] Items_blazer_rood = { 0x32, 0x1D, 0xAC, 0x40 };
        public byte[] Items_ender_perl = { 0x32, 0x1D, 0xA9, 0xF0 };
        public byte[] Items_spawn_egg = { 0x32, 0x20, 0x01, 0xC0 };
        public byte[] Items_experience_bottle = { 0x32, 0x20, 0x04, 0x10 };
        public byte[] Items_writen_booke = { 0x32, 0x20, 0x0B, 0xE0 };
        public byte[] Items_emerald = { 0x32, 0x20, 0x0E, 0x30 };
        public byte[] Items_enchanted_book = { 0x32, 0x20, 0x32, 0x80 };
        public byte[] Items_tnt_minecraft = { 0x32, 0x20, 0x3B, 0xC0 };
        public byte[] Items_armor_stand = { 0x32, 0x20, 0x52, 0x70 };
        public byte[] Items_commande_block_minecraft = { 0x32, 0x20, 0x64, 0x20 };
        public byte[] Items_banner = { 0x32, 0x20, 0x6C, 0x00 };
        public byte[] Items_end_crystal = { 0x32, 0x20, 0x6E, 0x50 };
        public byte[] Items_totem_of_undying = { 0x32, 0x20, 0xA4, 0xF0 };
        public byte[] Items_trident = { 0x32, 0x20, 0xB0, 0x30 };
        public byte[] Items_debug_four_items = { 0x32, 0x20, 0xCF, 0xB0 };

        #endregion


        #region "Changing Blocks"

        public byte[] Blocks_air = { 0x32, 0x18, 0x10, 0x20 };
        public byte[] Blocks_stone = { 0x32, 0x18, 0x11, 0xC0 };
        public byte[] Blocks_grass = { 0x32, 0x18, 0x13, 0x10 };
        public byte[] Blocks_water = { 0x32, 0x18, 0x1D, 0x70 };
        public byte[] Blocks_lava = { 0x32, 0x18, 0x20, 0xF0 };
        public byte[] Blocks_sand = { 0x32, 0x18, 0x22, 0xA0 };
        public byte[] Blocks_bed = { 0x32, 0x18, 0x37, 0x80 };

        #endregion


        #region "Bool Options Offset"

        //FIX ALL TEXT
        public string fixText(string fixStr)
        {
            int length = fixStr.Length;
            int startIndex = 1;
            int num3 = 0;
            while (true)
            {
                if (num3 >= length)
                {
                    fixStr = fixStr.Replace(".", "\0");
                    return (fixStr + "\0\0\0");
                }
                fixStr = fixStr.Insert(startIndex, ".");
                startIndex += 2;
                num3++;
            }
        }


        public void GOD_MODE(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x004B2021, new byte[] { 0x80 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x004B2021, new byte[] { 0x20 });
            }
        }

        public void INSTANT_DAMAGE(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x003A3FF0, new byte[] { 0x40, 0x80 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A3FF0, new byte[] { 0x3F, 0x00 }); ////SET to default
            }
        }

        public void KNOCKBACK(bool toggle) //<== Options Knockback
        {
            if (toggle)
            {
                PS3.SetMemory(0x003A4018, new byte[] { 0x40, 0x80 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A4018, new byte[] { 0x3E, 0xCC }); ////SET to default
            }
        }

        public void ANTI_KNOCKBACK(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x003A4018, new byte[] { 0x00, 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A4018, new byte[] { 0x3E, 0xCC }); ////SET to default
            }
        }


        public void INSTANT_KILL(bool toggle)
        {
            if (toggle)  //////Instant Kill
            {
                PS3.SetMemory(0x001AC411, new byte[] { 0xE0, 0x28, 0x90 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x001AC411, new byte[] { 0xE0, 0x08, 0x90 }); ////SET to default
            }
        }


        public void WATER_JUMP(bool toggle)
        {
            if (toggle)  //////Water Jump
            {
                PS3.SetMemory(0x003ABD68, new byte[] { 0x3F, 0xF9, 0x99, 0x99 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABD68, new byte[] { 0x3F, 0xE9, 0x99, 0x99 }); ////SET to default
            }
        }


        public void INFINITE_PICK_UP(bool toggle) //<== Options Pick Up Infinite
        {
            if (toggle)
            {
                PS3.SetMemory(0x00224B13, new byte[] { 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00224B13, new byte[] { 0x01 }); ////SET to default
            }
        }


        public void FAST_BOW(bool toggle)
        {
            if (toggle)  //////Bow Fast
            {
                PS3.SetMemory(0x000FB4C5, new byte[] { 0xE0, 0x18, 0x18 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x000FB4C5, new byte[] { 0xE0, 0x08, 0x18 }); ////SET to default
            }
        }


        public void ALL_PLAYERS_FAST_MINE(bool toggle)
        {
            if (toggle)  //////All Players Fast Mine
            {
                PS3.SetMemory(0x0010E0C4, new byte[] { 0xFF, 0xE0, 0x28, 0x90 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0010E0C4, new byte[] { 0xFF, 0xE0, 0x08, 0x90 }); ////SET to default
            }
        }

        public void ALL_PLAYERS_FAST_SPEED(bool toggle)
        {
            if (toggle)  //////All Players Speed
            {
                PS3.SetMemory(0x00018CE4, new byte[] { 0xFF, 0xE0, 0x00, 0x90 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00018CE4, new byte[] { 0xFF, 0xE0, 0x08, 0x90 }); ////SET to default
            }
        }


        public void AUTO_SAVE(bool toggle)
        {
            if (toggle)  ////Auto Save
            {
                PS3.SetMemory(0x00AEEE54, new byte[] { 0x40 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEEE54, new byte[] { 0x41 });
            }
        }


        public void SUPER_SPEED(bool toggle)
        {
            if (toggle)  //////Super Speed
            {
                PS3.SetMemory(0x003ABD49, new byte[] { 0xFF, 0xFF, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABD49, new byte[] { 0x26, 0xAD, 0x89 }); ////SET to default
            }
        }


        public void DISABLE_MOBS(bool toggle)
        {
            if (toggle)  ////Disable Mobs
            {
                PS3.SetMemory(0x004619E4, new byte[] { 0x40 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x004619E4, new byte[] { 0x41 });
            }
        }


        public void FIRE_CREEPER_EXPLODE(bool toggle)
        {
            if (toggle)  ////Fire Creeper Explode
            {
                PS3.SetMemory(0x001CC894, new byte[] { 0x39, 0x40, 0x00, 0x10 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x001CC894, new byte[] { 0x39, 0x40, 0x00, 0x00 });
            }
        }


        public void JUMP_SPEED(bool toggle)
        {
            if (toggle)  //////Jump Speed
            {
                PS3.SetMemory(0x003AA999, new byte[] { 0xA0 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003AA999, new byte[] { 0x68 }); ////SET to default
            }
        }


        public void MULTI_JUMP(bool toggle)
        {
            if (toggle)  //////Multi Jump
            {
                PS3.SetMemory(0x0022790B, new byte[] { 0x14 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0022790B, new byte[] { 0x18 }); ////SET to default
            }
        }

        public void SUPER_JUMP(bool toggle)
        {
            if (toggle)  //////Super Jump
            {
                PS3.SetMemory(0x003AA77C, new byte[] { 0x3F, 0x47, 0x7F, 0x42 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003AA77C, new byte[] { 0x3E, 0xD7, 0x0A, 0x3D }); ////SET to default
            }
        }


        public void AUTO_JUMP(bool toggle)
        {
            if (toggle)  //////Auto Jump
            {
                PS3.SetMemory(0x00B01BAC, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B01BAC, new byte[] { 0x40 }); ////SET to default
            }
        }


        public void REACH_ATTACK(bool toggle)
        {
            if (toggle)  //////Reach/Attack
            {
                PS3.SetMemory(0x00A95FB9, new byte[] { 0x80 }); ////reach creative ENTITY MOB
                PS3.SetMemory(0x00A95FC1, new byte[] { 0x80 }); ////reach survival ENTITY MOB
                PS3.SetMemory(0x00B351D8, new byte[] { 0x43, 0xA0, 0x00, 0x00 });////creative
                PS3.SetMemory(0x00B351DC, new byte[] { 0x43, 0xA0, 0x00, 0x00 });/////survival
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A95FB9, new byte[] { 0x18 }); ////reach creative ENTITY MOB
                PS3.SetMemory(0x00A95FC1, new byte[] { 0x08 }); ////reach survival ENTITY MOB
                PS3.SetMemory(0x00B351D8, new byte[] { 0x40, 0xA0, 0x00, 0x00 });/////creative
                PS3.SetMemory(0x00B351DC, new byte[] { 0x40, 0x90, 0x00, 0x00 });/////survival
            }
        }


        public void INSTANT_MINE(bool toggle)
        {
            if (toggle)  //////Instant mine
            {
                PS3.SetMemory(0x00AEB090, new byte[] { 0xBF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEB090, new byte[] { 0x3F }); ////SET to default
            }
        }


        public void INFINITE_CRAFT(bool toggle)
        {
            if (toggle)  //////Craft
            {
                PS3.SetMemory(0x0098871F, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0098871F, new byte[] { 0x00 }); ////SET to default
            }
        }


        public void ANTI_TELEPORT_BY_HOST(bool toggle)
        {
            if (toggle)  //////Anti Teleport By Host
            {
                PS3.SetMemory(0x003AFB60, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003AFB60, new byte[] { 0x3F, 0x7A, 0xE1, 0x48 }); ////SET to default
            }
        }


        public void UFO_MODE(bool toggle)
        {
            if (toggle)  //////UFO Mode
            {
                PS3.SetMemory(0x003ABDD0, new byte[] { 0x3F, 0x00, 0x7A, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABDD0, new byte[] { 0x3F, 0xEF, 0x5C, 0x29 }); ////SET to default
            }
        }


        public void JUMP_FORWARD(bool toggle)
        {
            if (toggle)  //////Jump forward X2
            {
                PS3.SetMemory(0x003AA999, new byte[] { 0x80 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003AA999, new byte[] { 0x68 }); ////SET to default
            }
        }


        public void CAM_DOWN(bool toggle)
        {
            if (toggle)  //////Cam Down
            {
                PS3.SetMemory(0x004B1CE0, new byte[] { 0xFC, 0x02, 0x10 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x004B1CE0, new byte[] { 0xFC, 0x01, 0x10 }); ////SET to default
            }
        }


        public void CAM_DOWN_R3(bool toggle)
        {
            if (toggle)  //////Cam Down R3
            {
                PS3.SetMemory(0x004B1D60, new byte[] { 0xFC, 0x00, 0xF8, 0x90 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x004B1D60, new byte[] { 0xFC, 0x20, 0xF8, 0x90 }); ////SET to default
            }
        }


        public void TOGGLE_SPRINT(bool toggle)
        {
            if (toggle)  //////Toggle Sprint
            {
                PS3.SetMemory(0x00B01DEC, new byte[] { 0x40, 0x82 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B01DEC, new byte[] { 0x41, 0x82 }); ////SET to default
            }
        }


        public void NAME_OVER_HEAD(bool toggle)
        {
            if (toggle)  //////Name Over Head
            {
                PS3.SetMemory(0x00AD8158, new byte[] { 0x4C }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD8158, new byte[] { 0x2C }); ////SET to default
            }
        }


        public void XRAY(bool toggle)
        {
            if (toggle)  //////XRay
            {
                PS3.SetMemory(0x00A99154, new byte[] { 0xFC, 0x80, 0x30, 0x90 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A99154, new byte[] { 0xFC, 0x60, 0x30, 0x90 }); ////SET to default
            }
        }

        public void HUD_MINI_GAME(bool toggle)
        {
            if (toggle)  //////Hud Mini Game
            {
                PS3.SetMemory(0x00AD8480, new byte[] { 0x41, 0x82 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD8480, new byte[] { 0x40, 0x82 }); ////SET to default
            }
        }

        public void SHOW_ARMOR(bool toggle)
        {
            if (toggle)  //////Show Armor
            {
                PS3.SetMemory(0x0090B5F0, new byte[] { 0x38, 0x80, 0x00, 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0090B5F0, new byte[] { 0x38, 0x80, 0x00, 0x00 }); ////SET to default
            }
        }


        public void AUTO_CHANGE_VIEW(bool toggle)
        {
            if (toggle)  ////Auto Change View
            {
                PS3.SetMemory(0x00AEF56C, new byte[] { 0x40 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEF56C, new byte[] { 0x41 });
            }
        }


        public void REMOVE_JUMP(bool toggle)
        {
            if (toggle)  ////Remove Jump
            {
                PS3.SetMemory(0x003ABDC9, new byte[] { 0xF4 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABDC9, new byte[] { 0xB4 });
            }
        }


        public void AUTO_CROUCH(bool toggle)
        {
            if (toggle)  ////Auto Snick
            {
                PS3.SetMemory(0x00AEF514, new byte[] { 0x40, 0x82, 0x00, 0x1C });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEF514, new byte[] { 0x41, 0x82, 0x00, 0x1C });
            }
        }


        public void DISABLE_SWIM(bool toggle)
        {
            if (toggle)  ////Disable Swim
            {
                PS3.SetMemory(0x0034B8F4, new byte[] { 0x41 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0034B8F4, new byte[] { 0x40 });
            }
        }


        public void AUTO_MINE(bool toggle)
        {
            if (toggle)  ////Auto Mine
            {
                PS3.SetMemory(0x00AEC42C, new byte[] { 0x40 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEC42C, new byte[] { 0x41 });
            }
        }


        public void AUTO_HIT(bool toggle)
        {
            if (toggle)  ////Auto Hit
            {
                PS3.SetMemory(0x00AEC34C, new byte[] { 0x40 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEC34C, new byte[] { 0x41 });
            }
        }


        public void ANIM_SWIM_FLY(bool toggle)
        {
            if (toggle)  ////Anim Swim Fly
            {
                PS3.SetMemory(0x00390410, new byte[] { 0x3B, 0x40, 0x00, 0x10 });
                PS3.SetMemory(0x003ABD44, new byte[] { 0x3D });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00390410, new byte[] { 0x3B, 0x40, 0x00, 0x00 });
                PS3.SetMemory(0x003ABD44, new byte[] { 0x3C });
            }
        }


        public void LEVITATION(bool toggle)
        {
            if (toggle)  ////Levitation
            {
                PS3.SetMemory(0x003ABDD0, new byte[] { 0xBF });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABDD0, new byte[] { 0x3F });
            }
        }


        public void REMOVE_ALL_TEXT(bool toggle)
        {
            if (toggle)  ////Remove All Text
            {
                PS3.SetMemory(0x007865EC, new byte[] { 0x40 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x007865EC, new byte[] { 0x41 });
            }
        }


        public void CHANGE_POSITION_VIEW(bool toggle)
        {
            if (toggle)  ////Change Postion View
            {
                PS3.SetMemory(0x00A99420, new byte[] { 0x40 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A99420, new byte[] { 0x41 });
            }
        }


        public void REMOVE_SWIM(bool toggle)
        {
            if (toggle)  ////Remove Swim
            {
                PS3.SetMemory(0x003ABD40, new byte[] { 0xBF });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABD40, new byte[] { 0x3F });
            }
        }


        public void CHANGE_MOVEMENT_SWIM(bool toggle)
        {
            if (toggle)  ////Change Movement Swim
            {
                PS3.SetMemory(0x003ABD44, new byte[] { 0xBC });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABD44, new byte[] { 0x3C });
            }
        }


        public void SEE_OUTSIDE_MAP(bool toggle)
        {
            if (toggle)  ////See outside map
            {
                PS3.SetMemory(0x00A97F34, new byte[] { 0xDF });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A97F34, new byte[] { 0x3F });
            }
        }


        public void LOOK_FORBACK(bool toggle)
        {
            if (toggle)  ////Look Forback
            {
                PS3.SetMemory(0x00A97F2C, new byte[] { 0x23 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A97F2C, new byte[] { 0x43 });
            }
        }


        public void INSTANT_HIT(bool toggle)
        {
            if (toggle)  //////Instant hit
            {
                PS3.SetMemory(0x00AEBED4, new byte[] { 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEBED4, new byte[] { 0x3E }); ////SET to default
            }
        }


        public void NO_COLISSION(bool toggle)
        {
            if (toggle)  //////No Collision
            {
                PS3.SetMemory(0x00011230, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00011230, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }); ////SET to default
            }
        }


        public void APOCALIPSE(bool toggle)
        {
            if (toggle)  //////Apocalipse
            {
                PS3.SetMemory(0x00AD5EC8, new byte[] { 0xBF, 0xFF }); ////MODIFED VALUE
                PS3.SetMemory(0x00410734, new byte[] { 0xCD, 0xC0, 0x00, 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD5EC8, new byte[] { 0xBF, 0x80 }); ////SET to default
                PS3.SetMemory(0x00410734, new byte[] { 0x40, 0xC0, 0x00, 0x00 }); ////MODIFED VALUE
            }
        }


        public void FUNNY_SCREEN(bool toggle)
        {
            if (toggle)  //////Funny Screen
            {
                PS3.SetMemory(0x00AD5EC8, new byte[] { 0x50, 0x80 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD5EC8, new byte[] { 0xBF, 0x80 }); ////SET to default
            }
        }


        public void CHANGE_PLAYERS_POSITION(bool toggle)
        {
            if (toggle)  //////Change Players Position
            {
                PS3.SetMemory(0x00AD5EC8, new byte[] { 0x3F, 0x80 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD5EC8, new byte[] { 0xBF, 0x80 }); ////SET to default
            }
        }


        public void HORROR_VIEW(bool toggle)
        {
            if (toggle)  //////horror view
            {
                PS3.SetMemory(0x00A9A6C8, new byte[] { 0x4F, 0x80, 0x00, 0x00 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A9A6C8, new byte[] { 0x3F, 0x80, 0x00, 0x00 });
            }
        }

        public void ANIMATION_RUNNING(bool toggle)
        {
            if (toggle)  //////Anime Run
            {
                PS3.SetMemory(0x003ACEF4, new byte[] { 0xBF, 0x80 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ACEF4, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }

        public async void RAINBOW_SKY(bool toggle)
        {
            if (toggle)
            {
                for (; ; )
                {
                    PS3.SetMemory(0x00410734, new byte[] { 0x40, 0xC0, 0x00, 0x00 }); ////Normal
                    PS3.SetMemory(0x00410734, new byte[] { 0xC8, 0xC0, 0x00, 0x00 }); ////Black
                    PS3.SetMemory(0x00410734, new byte[] { 0x50, 0xC0, 0x00, 0x00 }); ////MODIFED VALUE
                    PS3.SetMemory(0x00410734, new byte[] { 0xCE, 0xCC, 0xCC, 0xCD }); ////MODIFED VALUE
                    PS3.SetMemory(0x00410734, new byte[] { 0xFF, 0xFF, 0xCC, 0xCD }); ////MODIFED VALUE
                    PS3.SetMemory(0x00410734, new byte[] { 0x47, 0xFF, 0xCC, 0xCD }); ////MODIFED VALUE
                    PS3.SetMemory(0x00410734, new byte[] { 0x45, 0xC0, 0x00, 0x00 }); ////MODIFED VALUE
                    await Task.Delay(1000);
                }
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00410734, new byte[] { 0x40, 0xC0, 0x00, 0x00 }); //Sky Rainbow OFF
            }
        }


        public async void LSD_VIEW(bool toggle)
        {
            if (toggle)
            {
                for (; ; )
                {
                    PS3.SetMemory(0x00410734, new byte[] { 0x50, 0xC0, 0x00, 0x00 }); ////SET SKY COLOR
                    PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x80 }); //FOV
                    PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x70 });
                    PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x60 });
                    PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x50 });
                    PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x40 });
                    PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x30 });
                    PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x20 });
                    PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x10 });
                    PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x00 });
                    PS3.SetMemory(0x014C670C, new byte[] { 0xAF, 0x00 });
                    PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x10 });
                    PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x20 });
                    PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x30 });
                    PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x40 });
                    PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x50 });
                    PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x60 });
                    PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x70 });
                    PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x80 });
                    await Task.Delay(500);
                }
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00410734, new byte[] { 0x40, 0xC0, 0x00, 0x00 }); //SKY COLOR
                PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x80 }); //FOV
            }
        }


        public void SPLIT_SCREEN(bool toggle)
        {
            if (toggle)  ////Split Screen
            {
                PS3.SetMemory(0x00AEF9F0, new byte[] { 0x40 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEF9F0, new byte[] { 0x41 });
            }
        }


        public void FUNNY_SOUND(bool toggle)
        {
            if (toggle)  /////Funny Sound
            {
                PS3.SetMemory(0x00AEB090, new byte[] { 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEB090, new byte[] { 0x3F }); ////SET to default
            }
        }


        public void SIZE_HUD(bool toggle)
        {
            if (toggle)  //////Size HUD
            {
                PS3.SetMemory(0x0090FAC8, new byte[] { 0x41, 0x82 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0090FAC8, new byte[] { 0x40, 0x82 }); ////SET to default
            }
        }


        public void ITEMS_SIZE(string values)
        {
            uint offset = 0x00AF6B9C;
            uint offset1 = 0x00AF6B98;

            if (values == "0")
            {
                byte[] buffer = new byte[] { 0x41, 0x80 }; //RESET
                byte[] buffer1 = new byte[] { 0xBF, 0x80 }; //RESET
                PS3.SetMemory(offset, buffer);
                PS3.SetMemory(offset1, buffer1);
            }
            else if (values == "1")
            {
                byte[] buffer = new byte[] { 0xAF }; //Hide Items
                PS3.SetMemory(offset1, buffer);
            }
            else if (values == "2")
            {
                byte[] buffer = new byte[] { 0xBF, 0xFF }; //Big Items
                PS3.SetMemory(offset1, buffer);
            }
            else if (values == "3")
            {
                byte[] buffer = new byte[] { 0xEF }; //WTF Items
                PS3.SetMemory(offset1, buffer);
            }
            else if (values == "4")
            {
                byte[] buffer = new byte[] { 0x40, 0xFF }; //Little Items
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "5")
            {
                byte[] buffer = new byte[] { 0x41, 0xF0 }; //items X1
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "6")
            {
                byte[] buffer = new byte[] { 0x42, 0x80 }; //Items V2
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "7")
            {
                byte[] buffer = new byte[] { 0x43, 0x80 }; //Extrem Items
                PS3.SetMemory(offset, buffer);
            }
        }


        public void FOV_VALUE(string values) //FOV
        {
            uint offset = 0x014C670C;

            if (values == "0")
            {
                byte[] buffer = new byte[] { 0x3F, 0x80 }; //RESET
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "1")
            {
                byte[] buffer = new byte[] { 0x3F, 0x70 }; //X1
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "2")
            {
                byte[] buffer = new byte[] { 0x3F, 0x60 }; //X2
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "3")
            {
                byte[] buffer = new byte[] { 0x3F, 0x50 }; //X3
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "4")
            {
                byte[] buffer = new byte[] { 0x3F, 0x40 }; //X4
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "5")
            {
                byte[] buffer = new byte[] { 0x3F, 0x30 }; //X5
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "6")
            {
                byte[] buffer = new byte[] { 0x3F, 0x25 }; //X6
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "7")
            {
                byte[] buffer = new byte[] { 0x3F, 0x20 }; //X7
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "8")
            {
                byte[] buffer = new byte[] { 0x3F, 0x15 }; //X8 
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "9")
            {
                byte[] buffer = new byte[] { 0x3F, 0x10 }; //X9
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "10")
            {
                byte[] buffer = new byte[] { 0x1F, 0x80 }; //Updside Down
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "11")
            {
                byte[] buffer = new byte[] { 0x3F, 0xFF, 0xFF }; //ZOOM
                PS3.SetMemory(offset, buffer);
            }
        }


        public void SKY_COLORS(string values)
        {
            uint offset = 0x00410734;
            uint offset1 = 0x00410738;

            if (values == "0")
            {
                byte[] buffer = new byte[] { 0x40, 0xC0 }; //RESET
                byte[] buffer1 = new byte[] { 0x3F, 0x80 }; //RESET
                PS3.SetMemory(offset, buffer);
                PS3.SetMemory(offset1, buffer1);
            }
            else if (values == "1")
            {
                byte[] buffer = new byte[] { 0x40, 0x50 }; //GREEN SKY COLORS
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "2")
            {
                byte[] buffer = new byte[] { 0xBF, 0x80 }; //BLUE SKY COLORS
                PS3.SetMemory(offset1, buffer);
            }
            else if (values == "3")
            {
                byte[] buffer = new byte[] { 0x49, 0xC0 }; //Purple Sky Colors
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "4")
            {
                byte[] buffer = new byte[] { 0x42, 0xC0 }; //Pink Sky Colors
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "5")
            {
                byte[] buffer = new byte[] { 0x43, 0xC0 }; //Orange Sky Colors
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "6")
            {
                byte[] buffer = new byte[] { 0xF0, 0xC0 }; //Black Sky Colors
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "7")
            {
                byte[] buffer = new byte[] { 0x3F, 0xF0 }; //White Sky Colors
                PS3.SetMemory(offset1, buffer);
            }
        }


        public void HUD_COLORS(string values)
        {
            uint offset = 0x30DBAD64;

            if (values == "0")
            {
                byte[] buffer = new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 }; //RESET
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "1")
            {
                byte[] buffer = new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x4F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 }; //GREEN
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "2")
            {
                byte[] buffer = new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x1F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 }; //PURPLE
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "3")
            {
                byte[] buffer = new byte[] { 0x3F, 0xFF, 0x00, 0x00, 0x1F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 }; //RED
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "4")
            {
                byte[] buffer = new byte[] { 0X5F, 0x80, 0x00, 0x00, 0x5F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 }; //YELLOW
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "5")
            {
                byte[] buffer = new byte[] { 0X8F, 0x80, 0x00, 0x00, 0x8F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 }; //BLUE
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "6")
            {
                byte[] buffer = new byte[] { 0X00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }; //INVISIBLE
                PS3.SetMemory(offset, buffer);
            }
        }


        public void BURN_IN_WATER(bool toggle)
        {
            if (toggle)  //////Burn
            {
                PS3.SetMemory(0x00225EA8, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00225EA8, new byte[] { 0x40 }); ////SET to default
            }
        }


        public void MAX_PICKUP_ITEMS(bool toggle)
        {
            if (toggle)  //////Max Pick Up Items
            {
                PS3.SetMemory(0x00310AD4, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00310AD4, new byte[] { 0x40 }); ////SET to default
            }
        }


        public void TEXT_TO_ALIEN(bool toggle)
        {
            if (toggle)  //////Text to alien
            {
                PS3.SetMemory(0x007865D0, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x007865D0, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void KICK_TO_XMB_HUD(bool toggle)
        {
            if (toggle)  //////Kick to XMB press Select
            {
                PS3.SetMemory(0x00785DBC, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00785DBC, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void BROKEN_TEXTURES(bool toggle)
        {
            if (toggle)  //////Broke texture minecraft
            {
                PS3.SetMemory(0x00A98F4C, new byte[] { 0xAF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A98F4C, new byte[] { 0x40 }); ////SET to default
            }
        }


        public void SHOCKWAVE_EFFECT(bool toggle)
        {
            if (toggle)  //////ShockWave
            {
                PS3.SetMemory(0x00A98F40, new byte[] { 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A98F40, new byte[] { 0x00 }); ////SET to default
            }
        }


        public void NIGHT_VISION(bool toggle)
        {
            if (toggle)  //////Night Vision
            {
                PS3.SetMemory(0x00A9A6C8, new byte[] { 0x7F }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A9A6C8, new byte[] { 0x3F }); ////SET to default
            }
        }


        public void KILL_AURA(bool toggle)
        {
            if (toggle)  //////Kill aura
            {
                PS3.SetMemory(0x00233290, new byte[] { 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00233290, new byte[] { 0x00 }); ////SET to default
            }
        }


        public void FLY_MODE_X(bool toggle)
        {
            if (toggle)  //////Fly Mode X
            {
                PS3.SetMemory(0x00B023EC, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B023EC, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void WALL_HACK_V1(bool toggle)
        {
            if (toggle)  //////Wall Hack V1
            {
                PS3.SetMemory(0x30012913, new byte[] { 0x05 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x30012913, new byte[] { 0x07 }); ////SET to default
            }
        }


        public void GHOST_PLAYERS(bool toggle)
        {
            if (toggle)  //////Ghost Players
            {
                PS3.SetMemory(0x30012913, new byte[] { 0x02 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x30012913, new byte[] { 0x07 }); ////SET to default
            }
        }


        public void TEXTURE_PLASTIC(bool toggle)
        {
            if (toggle)  //////Texture Plastic
            {
                PS3.SetMemory(0x30012913, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x30012913, new byte[] { 0x07 }); ////SET to default
            }
        }


        public void SUICIDE(bool toggle)
        {
            if (toggle)  //////Suicide
            {
                PS3.SetMemory(0x003ABDD0, new byte[] { 0x3F, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABDD0, new byte[] { 0x3F, 0xEF }); ////SET to default
            }
        }


        public void GUN_ITEMS(bool toggle)
        {
            if (toggle)  //////Gun Items
            {
                PS3.SetMemory(0x014C6880, new byte[] { 0x3F, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x014C6880, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }


        public void REMOVE_PARTICLES(bool toggle)
        {
            if (toggle)  //////Remove Particles
            {
                PS3.SetMemory(0x014C6880, new byte[] { 0x3F, 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x014C6880, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }


        public void BIG_PARTICLES(bool toggle)
        {
            if (toggle)  //////Big Particles
            {
                PS3.SetMemory(0x014C6880, new byte[] { 0x3F, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x014C6880, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }


        public void FAST_BUILD(bool toggle)
        {
            if (toggle)  //////Fast Build
            {
                PS3.SetMemory(0x00AECE70, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AECE70, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void CAN_FLY(bool toggle)
        {
            if (toggle)  //////Can Fly
            {
                PS3.SetMemory(0x00B02378, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B02378, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void GAME_SPEED_STATIC(bool toggle)
        {
            if (toggle)  //////Game Speed Static
            {
                PS3.SetMemory(0x00AEFE64, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEFE64, new byte[] { 0x40 }); ////SET to default
            }
        }


        public void DARK_STORM(bool toggle)
        {
            if (toggle)  //////Dark Storm
            {
                PS3.SetMemory(0x00393E34, new byte[] { 0x3F, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00393E34, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }


        public void HUD_LOADING(bool toggle)
        {
            if (toggle)  //////HUD LOADING
            {
                PS3.SetMemory(0x014CE214, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x014CE214, new byte[] { 0x00 }); ////SET to default
            }
        }


        public void TIMECYCLE(string values)
        {
            uint offset = 0x001DA1D4;

            if (values == "0")
            {
                byte[] buffer = new byte[] { 0x40 }; //SET TO DEFAULT
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "1")
            {
                byte[] buffer = new byte[] { 0x43 }; //X1
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "2")
            {
                byte[] buffer = new byte[] { 0x44 }; //X2
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "3")
            {
                byte[] buffer = new byte[] { 0x45 }; //X3
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "4")
            {
                byte[] buffer = new byte[] { 0X46 }; //X4
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "5")
            {
                byte[] buffer = new byte[] { 0X47 }; //X5
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "6")
            {
                byte[] buffer = new byte[] { 0X48 }; //X6
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "7")
            {
                byte[] buffer = new byte[] { 0XFF }; //MAX
                PS3.SetMemory(offset, buffer);
            }
        }

        public void TIMECYCLE_V2(string toggle)
        {
            uint offset = 0x001DA1D4;
            if (toggle == "0")
            {
                byte[] buffer = new byte[] { 0x40 }; //SET TO DEFAULT
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "1")
            {
                byte[] buffer = new byte[] { 0x41 }; //Speed Time Cycle X1
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "2")
            {
                byte[] buffer = new byte[] { 0x42 }; //Speed Time Cycle X2
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "3")
            {
                byte[] buffer = new byte[] { 0x43 }; //Speed Time Cycle X3
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "4")
            {
                byte[] buffer = new byte[] { 0x44 }; //Speed Time Cycle X4
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "5")
            {
                byte[] buffer = new byte[] { 0x45 }; //Speed Time Cycle X5
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "6")
            {
                byte[] buffer = new byte[] { 0x46 }; //Speed Time Cycle X6
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "7")
            {
                byte[] buffer = new byte[] { 0x47 }; //Speed Time Cycle X7
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "8")
            {
                byte[] buffer = new byte[] { 0x48 }; //Speed Time Cycle X8
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "9")
            {
                byte[] buffer = new byte[] { 0x49 }; //Speed Time Cycle X9
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "10")
            {
                byte[] buffer = new byte[] { 0xFF }; //Speed Time Cycle X10
                PS3.SetMemory(offset, buffer);
            }
        }


        public void RAINBOW_STORM(bool toggle)
        {
            if (toggle)  //////Rainbow Storm
            {
                PS3.SetMemory(0x00393E34, new byte[] { 0x4F, 0x80 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00393E34, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }


        public void RAIN_TO_SNOW(bool toggle)
        {
            if (toggle)  //////Change rain to snow
            {
                PS3.SetMemory(0x01310954, new byte[] { 0x7E }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x01310954, new byte[] { 0x3E }); ////SET to default
            }
        }


        public void SKY_TO_RAINBOW_WITH_SNOW(bool toggle)
        {
            if (toggle)  //////Change Sky to Rainbow with snow
            {
                PS3.SetMemory(0x01310954, new byte[] { 0x7E }); ////MODIFED VALUE
                PS3.SetMemory(0x00393E34, new byte[] { 0x4F }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x01310954, new byte[] { 0x3E }); ////SET to default
                PS3.SetMemory(0x00393E34, new byte[] { 0x3F }); ////SET to default
            }
        }


        public void FLASH_STARS_IN_SKY(bool toggle)
        {
            if (toggle)  //////Flash Star In Sky
            {
                PS3.SetMemory(0x0038C658, new byte[] { 0x7F }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0038C658, new byte[] { 0x3F }); ////SET to default
            }
        }


        public void REMOVE_STARS_IN_SKY(bool toggle)
        {
            if (toggle)  //////Remove Star in Sky
            {
                PS3.SetMemory(0x0038C658, new byte[] { 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0038C658, new byte[] { 0x3F }); ////SET to default
            }
        }


        public void IDS_ITEMS(bool toggle)
        {
            if (toggle)  //////ID Items
            {
                PS3.SetMemory(0x003097C8, new byte[] { 0x40 }); ////MODIFED VALUE
                PS3.SetMemory(0x003097B8, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003097C8, new byte[] { 0x41 }); ////SET to default
                PS3.SetMemory(0x003097B8, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void BYPASS_MAX_ITEMS(bool toggle)
        {
            if (toggle)  //////Bypass Max Items
            {
                PS3.SetMemory(0x00310AFC, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00310AFC, new byte[] { 0x40 }); ////SET to default
            }
        }


        public void AUTO_TOSS_ITEMS(bool toggle)
        {
            if (toggle)  //////Auto Toss Items
            {
                PS3.SetMemory(0x00AEF428, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEF428, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void FREEZE_PARTICLES(bool toggle)
        {
            if (toggle)  //////Freeze Particles
            {
                PS3.SetMemory(0x00AEE7E8, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEE7E8, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void SEMI_BLACKSCREEN(bool toggle)
        {
            if (toggle)  //////Semi Blackscreen
            {
                PS3.SetMemory(0x00AF0354, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AF0354, new byte[] { 0x40 }); ////SET to default
            }
        }


        public void DISABLE_FLY_CREATIVE(bool toggle)
        {
            if (toggle)  //////Disable Fly Creative
            {
                PS3.SetMemory(0x00B02368, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B02368, new byte[] { 0x40 }); ////SET to default
            }
        }


        public void INSTANT_PLACE_SURVIVAL(bool toggle)
        {
            if (toggle)  //////Instant Place Survival
            {
                PS3.SetMemory(0x00AECF10, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AECF10, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void NO_DAMAGE_HIT(bool toggle)
        {
            if (toggle)  //////No Damage Hit
            {
                PS3.SetMemory(0x003A3FF0, new byte[] { 0xFF, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A3FF0, new byte[] { 0x3F, 0x00 }); ////SET to default
            }
        }


        public void BREAK_PARTICLES_FLY(bool toggle)
        {
            if (toggle)  //////Break Particles Fly
            {
                PS3.SetMemory(0x00B52100, new byte[] { 0x0F }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B52100, new byte[] { 0x3F }); ////SET to default
            }
        }


        public void STUCK_IN_BLOCKS(bool toggle)
        {
            if (toggle)  //////Locked In Block
            {
                PS3.SetMemory(0x00389B3C, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00389B3C, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void SMALL_RAIN(bool toggle)
        {
            if (toggle)  //////Small Rain
            {
                PS3.SetMemory(0x00393E34, new byte[] { 0x3E }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00393E34, new byte[] { 0x3F }); ////SET to default
            }
        }


        public void FLASH_SKY_WITH_PARTICLES(bool toggle)
        {
            if (toggle)  //////Flash Sky with Particles
            {
                PS3.SetMemory(0x00393E34, new byte[] { 0xFF, 0x80 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00393E34, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }


        public void NEW_SUPER_SPEED(bool toggle)
        {
            if (toggle)  //////[NEW] Super Speed
            {
                PS3.SetMemory(0x003AA999, new byte[] { 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003AA999, new byte[] { 0x68 }); ////SET to default
            }
        }


        public void TIME_SPEED(string values)
        {
            uint offset = 0x00C202C8;
            if (values == "0")
            {
                byte[] buffer = new byte[] { 0x3F, 0x50 }; //SET TO DEFAULT
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "1")
            {
                byte[] buffer = new byte[] { 0x3F, 0x60 }; //Speed Time X1
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "2")
            {
                byte[] buffer = new byte[] { 0x3F, 0x70 }; //Speed Time X2
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "3")
            {
                byte[] buffer = new byte[] { 0x3F, 0x80 }; //Speed Time X3
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "4")
            {
                byte[] buffer = new byte[] { 0x3F, 0x90 }; //Speed Time X4
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "5")
            {
                byte[] buffer = new byte[] { 0x3F, 0xF0 }; //Speed Time X5
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "6")
            {
                byte[] buffer = new byte[] { 0x3F, 0x40 }; //Speed Time -1
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "7")
            {
                byte[] buffer = new byte[] { 0x3F, 0x30 }; //Speed Time -2
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "8")
            {
                byte[] buffer = new byte[] { 0x3F, 0x20 }; //Speed Time -3
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "9")
            {
                byte[] buffer = new byte[] { 0x3F, 0x10 }; //Speed Time -4
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "10")
            {
                byte[] buffer = new byte[] { 0x3F, 0x00 }; //Speed Time -5
                PS3.SetMemory(offset, buffer);
            }
        }


        public void INDICATOR_DAMAGE_COLORS(string values)
        {
            uint offset = 0x00AD5A5C;
            if (values == "0")
            {
                byte[] buffer = new byte[] { 0x3F, 0x80 }; //SET TO DEFAULT
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "1")
            {
                byte[] buffer = new byte[] { 0x6F, 0xFF }; //Red Indicator Damage
                PS3.SetMemory(offset, buffer);
            }
            else if (values == "2")
            {
                byte[] buffer = new byte[] { 0xFF, 0xFF }; //Blue Indicator Damage
                PS3.SetMemory(offset, buffer);
            }
        }


        public void PLAYERS_PAPER_MODELS(bool toggle)
        {
            if (toggle)  //////Paper Models
            {
                PS3.SetMemory(0x00AD5ECC, new byte[] { 0x1F }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD5ECC, new byte[] { 0x3F }); ////SET to default
            }
        }


        public void PLAYERS_BIG_MODELS(bool toggle)
        {
            if (toggle)  //////Big Models
            {
                PS3.SetMemory(0x00AD5ECC, new byte[] { 0x3F, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD5ECC, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }


        public void INFINITE_BLOCK(bool toggle)
        {
            if (toggle)  //////Infinity place block
            {
                PS3.SetMemory(0x0010673F, new byte[] { 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0010673F, new byte[] { 0x01 }); ////SET to default
            }
        }


        public void BEST_SKY(bool toggle)
        {
            if (toggle)  //////Best Sky
            {
                PS3.SetMemory(0x00410738, new byte[] { 0x3F, 0x10 }); ////MODIFED VALUE
                PS3.SetMemory(0x0038C658, new byte[] { 0x7F }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00410738, new byte[] { 0x3F, 0x80 }); ////SET to default
                PS3.SetMemory(0x0038C658, new byte[] { 0x3F });  ////SET to default
            }
        }


        public async void FAKE_LAGS(bool toggle)
        {
            if (toggle)
            {
                for (; ; )
                {
                    PS3.SetMemory(0x00C202C8, new byte[] { 0x3F, 0x50 }); ////fake lag1
                    PS3.SetMemory(0x00C202C8, new byte[] { 0x3F, 0x51 }); ////fake lag2
                    await Task.Delay(500);
                }
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00C202C8, new byte[] { 0x3F, 0x50 }); //fake lag OFF
            }
        }


        public void DISABLE_RUN(bool toggle)
        {
            if (toggle)  //////Disable run
            {
                PS3.SetMemory(0x00B022F8, new byte[] { 0x4C }); ////SET to Modified
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B022F8, new byte[] { 0x2C }); ////SET to default
            }
        }


        public void PLAYERS_SKATE_MODE(bool toggle)
        {
            if (toggle)  //////Skate Mods
            {
                PS3.SetMemory(0x00A857D8, new byte[] { 0x50 }); ////SET to Modified
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A857D8, new byte[] { 0x40 }); ////SET to default
            }
        }


        public void ARMS_AND_LEGS_WEIRD(bool toggle)
        {
            if (toggle)  //////Arms And Legs Weird
            {
                PS3.SetMemory(0x00A857D8, new byte[] { 0x00 }); ////SET to Modified
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A857D8, new byte[] { 0x40 }); ////SET to default
            }
        }


        public void RAYMAN_MODE(bool toggle)
        {
            if (toggle)  //////Rayman Mods
            {
                PS3.SetMemory(0x00A857C8, new byte[] { 0x44 }); ////SET to Modified
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A857C8, new byte[] { 0xC0 }); ////SET to default
            }
        }


        public void ARMS_HIT_SPEED(bool toggle)
        {
            if (toggle)  //////Speed Arms Hit
            {
                PS3.SetMemory(0x00A857D0, new byte[] { 0xBF }); ////SET to Modified
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A857D0, new byte[] { 0x3F }); ////SET to default
            }
        }


        public void CREATIVE_SLOT(bool toggle)
        {
            if (toggle)  //////Creative Slot
            {
                PS3.SetMemory(0x002F0348, new byte[] { 0x38, 0x80, 0x00, 0x01 }); ////Survival to creative
                PS3.SetMemory(0x002F0398, new byte[] { 0x38, 0x80, 0x00, 0x00 }); ////HUD Survival to creative
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002F0348, new byte[] { 0x38, 0x80, 0x00, 0x00 }); ////Reset Survival to creative
                PS3.SetMemory(0x002F0398, new byte[] { 0x38, 0x80, 0x00, 0x01 }); ////Reset HUD Survival to creative
            }
        }


        public void SURVIVAL_SLOT(bool toggle)
        {
            if (toggle)  //////Survival Slot
            {
                PS3.SetMemory(0x002F0368, new byte[] { 0x38, 0x80, 0x00, 0x00 }); ////Creative to Survival
                PS3.SetMemory(0x002F0378, new byte[] { 0x38, 0x80, 0x00, 0x01 }); ////HUD Creative to Survival
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002F0368, new byte[] { 0x38, 0x80, 0x00, 0x01 }); ////Reset Creative to Survival
                PS3.SetMemory(0x002F0378, new byte[] { 0x38, 0x80, 0x00, 0x00 }); ////Reset HUD Creative to Survival
            }
        }


        public void SUPER_SPEED_V3(bool toggle)
        {
            if (toggle)  //////Super Speed X3 PREMIUM
            {
                PS3.SetMemory(0x003ABD48, new byte[] { 0x3F, 0x10, 0x23, 0x50 }); ////MODIFED VALUE
                PS3.SetMemory(0x003AA999, new byte[] { 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABD48, new byte[] { 0x3E, 0x26, 0xAD, 0x89 }); ////SET to default
                PS3.SetMemory(0x003AA999, new byte[] { 0x68 });  ////SET to default
            }
        }


        public void CRITICAL_HIT_V1(bool toggle)
        {
            if (toggle)  //////[NEW] Critical Mods PREMIUM !
            {
                PS3.SetMemory(0x003ABDD0, new byte[] { 0x3F, 0xAF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABDD0, new byte[] { 0x3F, 0xEF }); ////SET to default
            }
        }


        public void DRIFT_BOAT(bool toggle)
        {
            if (toggle)  //////Drift Boat
            {
                PS3.SetMemory(0x002278E4, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002278E4, new byte[] { 0x40 }); ////SET to default
            }
        }


        public void REMOVE_ANIMATION_RUN(bool toggle)
        {
            if (toggle)  //////Remove Anim Run Like PC
            {
                PS3.SetMemory(0x00227BDC, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00227BDC, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void GAME_GAMEMODE_LOCKED(bool toggle)
        {
            if (toggle)  //////Lock Change Game Mode
            {
                PS3.SetMemory(0x002F03D0, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002F03D0, new byte[] { 0x40 }); ////SET to default
            }
        }


        public void FLOAT_UP(bool toggle)
        {
            if (toggle)  //////Float UP
            {
                PS3.SetMemory(0x003ABDC8, new byte[] { 0x3F }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABDC8, new byte[] { 0xBF }); ////SET to default
            }
        }


        public void PRESS_X_FOR_HIT(bool toggle)
        {
            if (toggle)  //////Press X for Hit
            {
                PS3.SetMemory(0x00AEEB83, new byte[] { 0x0F }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEEB83, new byte[] { 0x01 }); ////SET to default
            }
        }


        public void ESP_CHESTS_V1(bool toggle)
        {
            if (toggle)  //////ESP Chest
            {
                PS3.SetMemory(0x00A98F4C, new byte[] { 0x50 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A98F4C, new byte[] { 0x40 }); ////SET to default
            }
        }


        public void SMALL_GRAPHIC(bool toggle)
        {
            if (toggle)  //////Small Graphic
            {
                PS3.SetMemory(0x00A98EF4, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A98EF4, new byte[] { 0x41 }); ////SET to default
            }
        }



        public void SUPER_SPEED_V4(bool toggle)
        {
            if (toggle)  //////NEW SUPER SPEED V4
            {
                PS3.SetMemory(0x003ABD48, new byte[] { 0x3F, 0xFF, 0x00, 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABD48, new byte[] { 0x3E, 0x26, 0xAD, 0x89 }); ////SET to default
            }
        }


        public void CAMERA_RIGHT_POSITION(bool toggle)
        {
            if (toggle)  //////CAMERA RIGHT
            {
                PS3.SetMemory(0x00A99050, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A99050, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void CAMERA_LEFT_POSITION(bool toggle)
        {
            if (toggle)  //////CAMERA LEFT
            {
                PS3.SetMemory(0x00A991AC, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A991AC, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void TNT_CANT_DESTROY_BLOCKS(bool toggle)
        {
            if (toggle)  //////TNT Cant Break Blocks
            {
                PS3.SetMemory(0x00245DEB, new byte[] { 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00245DEB, new byte[] { 0x01 }); ////SET to default
            }
        }


        public void BIG_GAMEPLAY(bool toggle)
        {
            if (toggle)  //////Giant GamePlay
            {
                PS3.SetMemory(0x00A98EBC, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A98EBC, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void KNOCKBACK_V1(bool toggle)
        {
            if (toggle)  //////Knockback
            {
                PS3.SetMemory(0x003ABF3C, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABF3C, new byte[] { 0x40 }); ////SET to default
            }
        }


        public void REMOVE_INVENTORY_HUD(bool toggle)
        {
            if (toggle)  //////Remove Inventory HUD
            {
                PS3.SetMemory(0x0090FCC0, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0090FCC0, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void REMOVE_POINTER_AIM(bool toggle)
        {
            if (toggle)  //////Remove Pointer Aim
            {
                PS3.SetMemory(0x0090FDFF, new byte[] { 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0090FDFF, new byte[] { 0x01 }); ////SET to default
            }
        }


        public void HUD_SHOW_PLAYERS_AROUND_YOU(bool toggle)
        {
            if (toggle)  //////HUD Show players Around you
            {
                PS3.SetMemory(0x00910298, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00910298, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void CREEPER_EXPLODE_MEDIUM(bool toggle)
        {
            if (toggle)  //////Creeper Explode Medium
            {
                PS3.SetMemory(0x001CC85C, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x001CC85C, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void CREEPER_CANT_DESTROY_BLOCKS(bool toggle)
        {
            if (toggle)  //////Creeper can't broken blocks
            {
                PS3.SetMemory(0x001CC827, new byte[] { 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x001CC827, new byte[] { 0x01 }); ////SET to default
            }
        }


        public void MAKE_CREEPER_BIG(bool toggle)
        {
            if (toggle)  //////Make Big Creeper
            {
                PS3.SetMemory(0x001CC81C, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x001CC81C, new byte[] { 0x40 }); ////SET to default
            }
        }



        public void NO_SLOW_DOWN(bool toggle)
        {
            if (toggle)  //////No Slow Down
            {
                PS3.SetMemory(0x003AFB60, new byte[] { 0x4F }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003AFB60, new byte[] { 0x3F }); ////SET to default
            }
        }

        public void HUD_INVENTORY_DOWN_ON_SCREEN(bool toggle)
        {
            if (toggle)  //////HUD Inventory Down On Screen
            {
                PS3.SetMemory(0x0090FB6C, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0090FB6C, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void FAST_BROKEN_BLOCKS_IN_CREATIVE(bool toggle)
        {
            if (toggle)  //////Fast Broken in Creative
            {
                PS3.SetMemory(0x00AEB11C, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEB11C, new byte[] { 0x40 }); ////SET to default
            }
        }


        public void CANT_GRAB_ITEMS(bool toggle)
        {
            if (toggle)  //////Cant Grab Items
            {
                PS3.SetMemory(0x00310B0C, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00310B0C, new byte[] { 0x40 }); ////SET to default
            }
        }

        public void REMOVE_SOME_FPS(bool toggle)
        {
            if (toggle)  //////Remove FPS
            {
                PS3.SetMemory(0x00AEFE18, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEFE18, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void DISABLE_CHANGING_WEATHER(bool toggle)
        {
            if (toggle)  //////Block Changing Weather
            {
                PS3.SetMemory(0x00393E84, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00393E84, new byte[] { 0x40 }); ////SET to default
            }
        }


        public void FUNNY_ARMS_LEGS(bool toggle)
        {
            if (toggle)  //////Fun Arms/legs
            {
                PS3.SetMemory(0x00A857D0, new byte[] { 0x3F, 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A857D0, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }

        public void BYPASS_CREATIVE_IN_TRUMBLE(bool toggle)
        {
            if (toggle)  /////BYPASS Creatif to Trumble
            {
                PS3.SetMemory(0x00AD8480, new byte[] { 0x41, 0x82 }); ////HUD MINI GAME
                PS3.SetMemory(0x0098871F, new byte[] { 0x01 }); ////Unlimited Craft
                PS3.SetMemory(0x002F0348, new byte[] { 0x38, 0x80, 0x00, 0x01 }); ////Survival to creative
                PS3.SetMemory(0x002F0398, new byte[] { 0x38, 0x80, 0x00, 0x00 }); ////HUD Survival to creative
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD8480, new byte[] { 0x40, 0x82 }); ////HUD MINI GAME
                PS3.SetMemory(0x0098871F, new byte[] { 0x00 }); ////Unlimited Craft
                PS3.SetMemory(0x002F0348, new byte[] { 0x38, 0x80, 0x00, 0x00 }); ////Survival to creative
                PS3.SetMemory(0x002F0398, new byte[] { 0x38, 0x80, 0x00, 0x01 }); ////HUD Survival to creative
            }
        }


        public void HIDE_ARMS(bool toggle)
        {
            if (toggle)  //////Hide Arms
            {
                PS3.SetMemory(0x00A996C8, new byte[] { 0x4D }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A996C8, new byte[] { 0x3D }); ////SET to default
            }
        }

        public void BETTER_TIME(bool toggle)
        {
            if (toggle)  //////Better Time
            {
                PS3.SetMemory(0x00A9A6DC, new byte[] { 0x0F }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A9A6DC, new byte[] { 0x3F }); ////SET to default
            }
        }

        public void STOP_BOW(bool toggle)
        {
            if (toggle)  //////Stop Bow
            {
                PS3.SetMemory(0x000FB4C5, new byte[] { 0xE0, 0x58 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x000FB4C5, new byte[] { 0xE0, 0x08 }); ////SET to default
            }
        }


        public void NO_COLISSION_BYPASS(bool toggle)
        {
            if (toggle)  //////No Colission Bypass
            {
                PS3.SetMemory(0x002271B0, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002271B0, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void NO_KNOCKBACK(bool toggle)
        {
            if (toggle)  //////New NO kb
            {
                PS3.SetMemory(0x00011ACC, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00011ACC, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void ROTATION_BODY(bool toggle)
        {
            if (toggle)  //////Rotation Body
            {
                PS3.SetMemory(0x014C6728, new byte[] { 0x0F }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x014C6728, new byte[] { 0x3F }); ////SET to default
            }
        }


        public void FOG_BLUE(bool toggle)
        {
            if (toggle)  //////Blue Fog
            {
                PS3.SetMemory(0x014C67D8, new byte[] { 0x0F }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x014C67D8, new byte[] { 0x3F }); ////SET to default
            }
        }

        public void DAYS_NIGHT(bool toggle)
        {
            if (toggle)  //////Days / Night
            {
                PS3.SetMemory(0x014C6880, new byte[] { 0x2F }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x014C6880, new byte[] { 0x3F }); ////SET to default
            }
        }


        public void HUD_NEW_COLORS(string toggle)
        {
            uint offset = 0x014CB898;
            uint offset1 = 0x014CB898;
            uint offset2 = 0x014CB89C;
            uint offset3 = 0x014CB8A0;
            uint offset4 = 0x014CB8A4;
            if (toggle == "0")
            {
                byte[] buffer = new byte[] { 0x00, 0x00 }; //SET TO DEFAULT NEED FIX
                byte[] buffer1 = new byte[] { 0x00, 0x00 }; //SET TO DEFAULT NEED FIX
                byte[] buffer2 = new byte[] { 0x00, 0x00 }; //SET TO DEFAULT NEED FIX
                byte[] buffer3 = new byte[] { 0x00, 0x00 }; //SET TO DEFAULT NEED FIX
                byte[] buffer4 = new byte[] { 0x3F, 0x80 }; //SET TO DEFAULT NEED FIX
                PS3.SetMemory(offset, buffer);
                PS3.SetMemory(offset1, buffer1);
                PS3.SetMemory(offset2, buffer2);
                PS3.SetMemory(offset3, buffer3);
                PS3.SetMemory(offset4, buffer4);
            }
            else if (toggle == "1")
            {
                byte[] buffer = new byte[] { 0x40 }; //All Hud Blue
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "2")
            {
                byte[] buffer = new byte[] { 0x42 }; //All Hud Red
                PS3.SetMemory(offset1, buffer);
            }
            else if (toggle == "3")
            {
                byte[] buffer = new byte[] { 0x40 }; //All Hud Green
                PS3.SetMemory(offset2, buffer);
            }
            else if (toggle == "4")
            {
                byte[] buffer = new byte[] { 0xF0 }; //All Hud Gold
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "5")
            {
                byte[] buffer = new byte[] { 0xF0 }; //All Hud Purple
                PS3.SetMemory(offset2, buffer);
            }
            else if (toggle == "6")
            {
                byte[] buffer = new byte[] { 0x40 }; //All Hud White
                PS3.SetMemory(offset3, buffer);
            }
            else if (toggle == "7")
            {
                byte[] buffer = new byte[] { 0xF0 }; //ALL HUD NOTHING
                PS3.SetMemory(offset3, buffer);
            }
            else if (toggle == "8")
            {
                byte[] buffer = new byte[] { 0x3F, 0x60 }; //aLL Hud Small
                PS3.SetMemory(offset4, buffer);
            }
            else if (toggle == "9")
            {
                byte[] buffer = new byte[] { 0x3F, 0x90 }; //All Hud Big
                PS3.SetMemory(offset4, buffer);
            }
        }


        public void CREEPER_SMALL_EXPLOSION(bool toggle)
        {
            if (toggle)  //////Small Explosion Creeper
            {
                PS3.SetMemory(0x001CC7E0, new byte[] { 0x3F, 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x001CC7E0, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }

        public void CREEPER_MEDIUM_EXPLOSION(bool toggle)
        {
            if (toggle)  //////Medium Explosion Creeper
            {
                PS3.SetMemory(0x001CC7E0, new byte[] { 0x3F, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x001CC7E0, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }

        public void CREEPER_EXTREM_EXPLOSION(bool toggle)
        {
            if (toggle)  //////Extrem Explosion Creeper
            {
                PS3.SetMemory(0x001CC7E0, new byte[] { 0x40, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x001CC7E0, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }


        public void CREEPER_NUCLEAR_EXPLOSION(bool toggle)
        {
            if (toggle)  //////Nuclear Explosion Creeper
            {
                PS3.SetMemory(0x001CC7E0, new byte[] { 0x42, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x001CC7E0, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }

        public void INSTANT_KILL_IN_FIRE(bool toggle)
        {
            if (toggle)  //////Instant Kill Fire
            {
                PS3.SetMemory(0x002258F8, new byte[] { 0x4F, 0x80 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002258F8, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }

        public void ALL_PLAYERS_SET_IN_FIRE(bool toggle)
        {
            if (toggle)  //////All Players Burn
            {
                PS3.SetMemory(0x00225FA0, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00225FA0, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void INSTANT_JUMP_IN_SKY(bool toggle)
        {
            if (toggle)  //////Jump Instant in Sky
            {
                PS3.SetMemory(0x00011ADC, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00011ADC, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void PLAYERS_BODY_LIGHT(bool toggle)
        {
            if (toggle)  //////Players body Light
            {
                PS3.SetMemory(0x00AD66C0, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD66C0, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void JUMP_FOR_BUILD(bool toggle)
        {
            if (toggle)  //////Jump for build
            {
                PS3.SetMemory(0x002271F4, new byte[] { 0xFC, 0x80 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002271F4, new byte[] { 0xFC, 0x20 }); ////SET to default
            }
        }

        public void ENTITY_FUNNY_VISION(string toggle)
        {
            uint offset = 0x00AD5EC8;
            if (toggle == "0")
            {
                byte[] buffer = new byte[] { 0xBF, 0x80 }; //DEFAULT
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "1")
            {
                byte[] buffer = new byte[] { 0xBF, 0x00 }; //SMALL
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "2")
            {
                byte[] buffer = new byte[] { 0xBF, 0xAA }; //MEDIUM
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "3")
            {
                byte[] buffer = new byte[] { 0xBF, 0xFF }; //BIG
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "4")
            {
                byte[] buffer = new byte[] { 0XC0, 0x50 }; //GIANT 
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "5")
            {
                byte[] buffer = new byte[] { 0XC0, 0x99 }; //GIANT V2
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "6")
            {
                byte[] buffer = new byte[] { 0XC0, 0xFF }; //GIANT V3
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "7")
            {
                byte[] buffer = new byte[] { 0XC1, 0x80 }; //WOOW
                PS3.SetMemory(offset, buffer);
            }
        }


        public void ENTITY_FUNNY_VISUAL(string toggle)
        {
            uint offset = 0x00AD5ECC;
            if (toggle == "0")
            {
                byte[] buffer = new byte[] { 0x3F, 0x80 }; //DEFAULT
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "1")
            {
                byte[] buffer = new byte[] { 0x2F, 0x80 }; //PAPER
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "2")
            {
                byte[] buffer = new byte[] { 0x3F, 0xFF }; //MEDIUM
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "3")
            {
                byte[] buffer = new byte[] { 0x40, 0x80 }; //BIG
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "4")
            {
                byte[] buffer = new byte[] { 0X40, 0xFF }; //LSD
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "5")
            {
                byte[] buffer = new byte[] { 0X41, 0xFF }; //WEIRD
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "6")
            {
                byte[] buffer = new byte[] { 0x43, 0x80 }; //woow
                PS3.SetMemory(offset, buffer);
            }
        }


        public void FPS_VALUES(string toggle)
        {
            uint offset = 0x00AF0443;
            if (toggle == "0")
            {
                byte[] buffer = new byte[] { 0x00 }; //DEFAULT
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "1")
            {
                byte[] buffer = new byte[] { 0x10 }; //X1
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "2")
            {
                byte[] buffer = new byte[] { 0x20 }; //x2
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "3")
            {
                byte[] buffer = new byte[] { 0x30 }; //X3
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "4")
            {
                byte[] buffer = new byte[] { 0x40 }; //X4
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "5")
            {
                byte[] buffer = new byte[] { 0x50 }; //X5
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "6")
            {
                byte[] buffer = new byte[] { 0x60 }; //X6
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "7")
            {
                byte[] buffer = new byte[] { 0x70 }; //X7
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "8")
            {
                byte[] buffer = new byte[] { 0x80 }; //X8
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "9")
            {
                byte[] buffer = new byte[] { 0x90 }; //X9
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "10")
            {
                byte[] buffer = new byte[] { 0xA0 }; //X10
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "11")
            {
                byte[] buffer = new byte[] { 0xB0 }; //X11
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "12")
            {
                byte[] buffer = new byte[] { 0xC0 }; //X12
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "13")
            {
                byte[] buffer = new byte[] { 0xD0 }; //X13
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "14")
            {
                byte[] buffer = new byte[] { 0xE0 }; //X14
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "15")
            {
                byte[] buffer = new byte[] { 0xF0 }; //X15
                PS3.SetMemory(offset, buffer);
            }
        }

        public void CREEPER_INSTANT_EXPLODE(bool toggle)
        {
            if (toggle)  //////Creeper instant explode
            {
                PS3.SetMemory(0x001CCC2C, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x001CCC2C, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void WOLF_TURN_HEAD(bool toggle)
        {
            if (toggle)  //////Wolf Turn Head
            {
                PS3.SetMemory(0x006C0610, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x006C0610, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void WOLF_REMOVE_WATER(bool toggle)
        {
            if (toggle)  //////Wolf Remove Water
            {
                PS3.SetMemory(0x006C0630, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x006C0630, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void TNT_CANT_EXPLODE_BLOCKS(bool toggle)
        {
            if (toggle)  //////TNT Can't explode blocks
            {
                PS3.SetMemory(0x00245DF0, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00245DF0, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void TNT_MAKE_MORE_PARTICLES(bool toggle)
        {
            if (toggle)  //////TNT Make more Particles
            {
                PS3.SetMemory(0x00245E58, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00245E58, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void CANT_GRAB_ITEMS_V2(bool toggle)
        {
            if (toggle)  //////CANT GRAB ITEMS V2 (CANT GO IN INVENTORY)
            {
                PS3.SetMemory(0x004A3FB8, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x004A3FB8, new byte[] { 0x40 }); ////SET to default
            }
        }


        public void TNT_FLY_IN_AIR_WHEN_ENABLED(bool toggle)
        {
            if (toggle)  //////TNT FLY IN AIR WHEN ACTIVATE
            {
                PS3.SetMemory(0x0051E558, new byte[] { 0x2F, 0xA4 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0051E558, new byte[] { 0x3F, 0xA4 }); ////SET to default
            }
        }

        public void TNT_INSTANT_EXPLODE(bool toggle)
        {
            if (toggle)  //////TNT INSTANT EXPLODE
            {
                PS3.SetMemory(0x0051E6A0, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0051E6A0, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void ALL_PLAYERS_FREEZE_PS3(bool toggle)
        {
            if (toggle)  //////Froze PS3 Players V2
            {
                PS3.SetMemory(0x00AEE434, new byte[] { 0x40 }); ////MODIFED VALUE
                PS3.SetMemory(0x00393E34, new byte[] { 0xCF, 0x80 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00393E34, new byte[] { 0x4F, 0x80 }); ////SET to default
                PS3.SetMemory(0x00393E34, new byte[] { 0x2F, 0x80 }); ////SET to default
                PS3.SetMemory(0x00393E34, new byte[] { 0x3F, 0x80 }); ////SET to default
                PS3.SetMemory(0x00AEE434, new byte[] { 0x41 }); ////MODIFED VALUE
            }
        }


        public void ANTI_KICK_PREMIUM(bool toggle) //NEED FIX
        {
            if (toggle)  //////Anti Kick Premium
            {
                PS3.SetMemory(0x00AEE434, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEE434, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void ANTI_AFK(bool toggle)
        {
            if (toggle)  //////Anti AFK
            {
                PS3.SetMemory(0x002267B0, new byte[] { 0x3F, 0x80 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002267B0, new byte[] { 0x00, 0x00 }); ////SET to default
            }
        }

        public void FOOT_STEP_FAST(bool toggle)
        {
            if (toggle)  //////Foot Step Fast
            {
                PS3.SetMemory(0x002267F0, new byte[] { 0x3F, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002267F0, new byte[] { 0x3F, 0x19 }); ////SET to default
            }
        }


        public void FOOT_STEP_SLOW(bool toggle)
        {
            if (toggle)  //////Foot Step Slow
            {
                PS3.SetMemory(0x002267F0, new byte[] { 0x2F, 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002267F0, new byte[] { 0x3F, 0x19 }); ////SET to default
            }
        }

        public void SENSIBILITY_FAST(bool toggle)
        {
            if (toggle)  //////Sensibility Fast
            {
                PS3.SetMemory(0x00ABA948, new byte[] { 0x42, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00ABA948, new byte[] { 0x42, 0x48 }); ////SET to default
            }
        }

        public void SENSIBILITY_MAX(bool toggle)
        {
            if (toggle)  //////Sensibility Max
            {
                PS3.SetMemory(0x00ABA948, new byte[] { 0x44, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00ABA948, new byte[] { 0x42, 0x48 }); ////SET to default
            }
        }


        public void SWIM_GLITCH(bool toggle)
        {
            if (toggle)  //////Swim Glitch
            {
                PS3.SetMemory(0x00B0229C, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B0229C, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void REMOVE_HURT_CAM(bool toggle)
        {
            if (toggle)  //////Hurt Cam
            {
                PS3.SetMemory(0x00A972B0, new byte[] { 0x00, 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A972B0, new byte[] { 0x40, 0x49 }); ////SET to default
            }
        }

        public void REMOVE_FALL_DAMAGE(bool toggle)
        {
            if (toggle)  //////No FALL Damage
            {
                PS3.SetMemory(0x003A409C, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A409C, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void MAX_XP_LEVEL(bool toggle)
        {
            if (toggle)  //////MAX XP LEVEL
            {
                PS3.SetMemory(0x004B0094, new byte[] { 0x7C, 0xA5, 0x10, 0x14 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x004B0094, new byte[] { 0x7C, 0xA5, 0x20, 0x14 }); ////SET to default
            }
        }

        public void SUPER_SPEED_V5(bool toggle)
        {
            if (toggle)  //////Premium Speed V5
            {
                PS3.SetMemory(0x003ABD48, new byte[] { 0x41, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABD48, new byte[] { 0x3E, 0x26 }); ////SET to default
            }
        }

        public void ALL_PLAYERS_FAST_MINE_V2(bool toggle)
        {
            if (toggle)  //////All Players Fast Mine V2
            {
                PS3.SetMemory(0x0010E0C4, new byte[] { 0xFF, 0xE0, 0x18, 0x90 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0010E0C4, new byte[] { 0xFF, 0xE0, 0x08, 0x90 }); ////SET to default
            }
        }


        public void WALL_HACK_V2(bool toggle)
        {
            if (toggle)  //////Wall Hack
            {
                PS3.SetMemory(0x00A98F50, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A98F50, new byte[] { 0x3D }); ////SET to default
            }
        }

        public void SUPER_SPEED_V6(bool toggle)
        {
            if (toggle)  //////Super Speed V6
            {
                PS3.SetMemory(0x003AA998, new byte[] { 0x3E }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003AA998, new byte[] { 0x3F }); ////SET to default
            }
        }

        public void PLAYERS_SLIDE(bool toggle)
        {
            if (toggle)  //////Player Slide
            {
                PS3.SetMemory(0x003AAA98, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003AAA98, new byte[] { 0x41 }); ////SET to default
            }
        }

        public async void MOVE_WITH_INVENTORY_OPENED(bool toggle)
        {
            if (toggle)  //////Walk with inventory open
            {
                for (; ; )
                {
                    PS3.SetMemory(0x3000CF68, new byte[] { 0x00 }); ////For inventory open anytime
                    await Task.Delay(1000);
                }
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x3000CF68, new byte[] { 0x00 }); ////SET to default
            }
        }


        public void ENTITY_INVISIBLE(bool toggle)
        {
            if (toggle)  //////Invisible players
            {
                PS3.SetMemory(0x00011ADC, new byte[] { 0x40 }); ////Jump instant sky
                PS3.SetMemory(0x003ABDD0, new byte[] { 0x3F, 0xFF }); ////Suicide
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00011ADC, new byte[] { 0x41 }); ////Jump instant sky
                PS3.SetMemory(0x003ABDD0, new byte[] { 0x3F, 0xEF }); ////Suicide
            }
        }

        public void CRITICAL_HIT_V2(bool toggle)
        {
            if (toggle)  //////Critical Mods V2
            {
                PS3.SetMemory(0x003AA77C, new byte[] { 0x3E, 0x27 }); ////Jump small enabled
                PS3.SetMemory(0x00233290, new byte[] { 0xFF }); ////kill aura enabled
                PS3.SetMemory(0x00AEBED4, new byte[] { 0xFF, 0xFF }); ////instant hit enabled
                PS3.SetMemory(0x00B01BAC, new byte[] { 0x41 }); ////Auto jump enabled
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003AA77C, new byte[] { 0x3E, 0xD7 }); ////Jump small disabled
                PS3.SetMemory(0x00233290, new byte[] { 0x00 }); ////kill aura disable
                PS3.SetMemory(0x00AEBED4, new byte[] { 0x3E, 0x80 }); ////instant hit disabled
                PS3.SetMemory(0x00B01BAC, new byte[] { 0x40 }); ////auto jump disabled
            }
        }


        public void REVERSE_KNOCKBACK(bool toggle)
        {
            if (toggle)  //////Reverse Knockback
            {
                PS3.SetMemory(0x003A4018, new byte[] { 0xBF, 0x80 }); ////Knocback enabled
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A4018, new byte[] { 0x3E, 0xCC }); ////Knockback disabled
            }
        }

        public void TNT_SMALL_PARTICLES(bool toggle)
        {
            if (toggle)  //////Small Particles TNT
            {
                PS3.SetMemory(0x00245C4C, new byte[] { 0x40 }); ////Knocback enabled
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00245C4C, new byte[] { 0x41 }); ////Knockback disabled
            }
        }

        public void DEBUG_SKINS_TEXTURE(bool toggle)
        {
            if (toggle)  //////Skins debug texture
            {
                PS3.SetMemory(0x30012AB3, new byte[] { 0x03 }); ////Knocback enabled
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x30012AB3, new byte[] { 0x04 }); ////Knockback disabled
            }
        }


        public void ALL_WORLD_LIGHT_WHITE(bool toggle)
        {
            if (toggle)  //////Map Light White
            {
                PS3.SetMemory(0x300136D3, new byte[] { 0x02 }); ////Knocback enabled
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x300136D3, new byte[] { 0x06 }); ////Knockback disabled
            }
        }

        public void RAINBOW_LIGHT(bool toggle)
        {
            if (toggle)  //////Rainbow Light
            {
                PS3.SetMemory(0x00A9A6C8, new byte[] { 0x3F, 0xFF }); ////Knocback enabled
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A9A6C8, new byte[] { 0x3F, 0x80 }); ////Knockback disabled
            }
        }

        public void TNT_GO_DOWN(bool toggle)
        {
            if (toggle)  //////Tnt go down
            {
                PS3.SetMemory(0x0051E558, new byte[] { 0x4F }); ////Knocback enabled
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0051E558, new byte[] { 0x3F }); ////Knockback disabled
            }
        }

        public void ESP_CHESTS_V2(bool toggle)
        {
            if (toggle)  //////ESP Chests V2
            {
                PS3.SetMemory(0x00A9C2B4, new byte[] { 0x3E, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A9C2B4, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }


        public void CLOUD_COLORS(string toggle)
        {
            uint offset = 0x0038B964;
            uint offset1 = 0x0038B968;
            uint offset2 = 0x00B230AC;
            uint offset3 = 0x00B230D0;
            uint offset4 = 0x00B230FC;

            if (toggle == "0")
            {
                byte[] buffer = new byte[] { 0x3E, 0xCC }; //DEFAULT
                byte[] buffer1 = new byte[] { 0x3F, 0x59 }; //DEFAULT
                byte[] buffer2 = new byte[] { 0xBF, 0x80 }; //DEFAULT
                byte[] buffer3 = new byte[] { 0x3F, 0x60 }; //DEFAULT
                byte[] buffer4 = new byte[] { 0x41, 0x80 }; //DEFAULT
                PS3.SetMemory(offset, buffer);
                PS3.SetMemory(offset1, buffer1);
                PS3.SetMemory(offset2, buffer2);
                PS3.SetMemory(offset3, buffer3);
                PS3.SetMemory(offset4, buffer4);
            }
            else if (toggle == "1")
            {
                byte[] buffer = new byte[] { 0xFF, 0xCC }; //Cloud Blue
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "2")
            {
                byte[] buffer = new byte[] { 0x3F, 0xCC }; //Cloud White
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "3")
            {
                byte[] buffer = new byte[] { 0x8E, 0xCC }; //Cloud Gray
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "4")
            {
                byte[] buffer = new byte[] { 0xFF }; //Cloud Yellow
                PS3.SetMemory(offset1, buffer);
            }
            else if (toggle == "5")
            {
                byte[] buffer = new byte[] { 0xBF, 0x70 }; //Speed Cloud
                PS3.SetMemory(offset2, buffer);
            }
            else if (toggle == "6")
            {
                byte[] buffer = new byte[] { 0x3F, 0x80 }; //Transparent Cloud
                PS3.SetMemory(offset3, buffer);
            }
            else if (toggle == "7")
            {
                byte[] buffer = new byte[] { 0x43 }; //Down Cloud
                PS3.SetMemory(offset4, buffer);
            }
            else if (toggle == "8")
            {
                byte[] buffer = new byte[] { 0x40 }; //Up Cloud
                PS3.SetMemory(offset, buffer);
            }
        }


        public void REMOVE_SHADOW_ENTITY(string toggle)
        {
            uint offset = 0x300040FF;
            if (toggle == "0")
            {
                byte[] buffer = new byte[] { 0x05 }; //DEFAULT
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "1")
            {
                byte[] buffer = new byte[] { 0x00 }; //Remove Shadow Players
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "2")
            {
                byte[] buffer = new byte[] { 0x02 }; //Black Shadow Players
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "3")
            {
                byte[] buffer = new byte[] { 0x01 }; //4 Blocks Shadow
                PS3.SetMemory(offset, buffer);
            }
        }


        public void EPS_CHEST_V3(bool toggle)
        {
            if (toggle)  //////ESP Chests V2
            {
                PS3.SetMemory(0x003A7654, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A7654, new byte[] { 0x40 }); ////SET to default
            }
        }

        public void SHADOW_SKINS_V2(bool toggle)
        {
            if (toggle)  //////Shadow Skins V2
            {
                PS3.SetMemory(0x003AD910, new byte[] { 0xFC, 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003AD910, new byte[] { 0xFC, 0x80 }); ////SET to default
            }
        }

        public void WALK_ALONE(bool toggle)
        {
            if (toggle)  //////Walk Alone
            {
                PS3.SetMemory(0x003ABE18, new byte[] { 0xFF, 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABE18, new byte[] { 0xFF, 0x20 }); ////SET to default
            }
        }

        public void SHADOW_SKINS_PLAYERS(bool toggle)
        {
            if (toggle)  //////Shadow Skins Players
            {
                PS3.SetMemory(0x003AD388, new byte[] { 0x2F }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003AD388, new byte[] { 0x3F }); ////SET to default
            }
        }

        public void ANTI_AFK_V2(bool toggle)
        {
            if (toggle)  //////Anti AFK V2
            {
                PS3.SetMemory(0x003ABDC8, new byte[] { 0x3F }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABDC8, new byte[] { 0xBF }); ////MODIFED VALUE
            }
        }


        public void ALL_PLAYERS_CANT_RUN(bool toggle)
        {
            if (toggle)  /////All Players Cant Run
            {
                PS3.SetMemory(0x00018CE4, new byte[] { 0xFF, 0xE0, 0x28, 0x90 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00018CE4, new byte[] { 0xFF, 0xE0, 0x08, 0x90 }); ////SET to default
            }
        }

        public void RETURN_TO_XMB(bool toggle)
        {
            if (toggle)  /////Return to XMB
            {
                PS3.SetMemory(0x00AD8320, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD8320, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void LIGHT_MAKE_MORE_POWER(bool toggle)
        {
            if (toggle)  /////Light make more light power !
            {
                PS3.SetMemory(0x00A9A6D8, new byte[] { 0x4F, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A9A6D8, new byte[] { 0x3F, 0xC0 }); ////SET to default
            }
        }

        public void TNT_EXPLODE_SOUND_OFF(bool toggle)
        {
            if (toggle)  /////TNT Explode Sound For All !
            {
                PS3.SetMemory(0x00245BE4, new byte[] { 0xFF, 0x60, 0x18, 0x90 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00245BE4, new byte[] { 0xFF, 0x60, 0x08, 0x90 }); ////SET to default
            }
        }

        public void NAME_OVER_HEAD_GO_UP_DOWN(bool toggle)
        {
            if (toggle)  /////Name over head go up and down
            {
                PS3.SetMemory(0x00AD8110, new byte[] { 0xFF, 0xC0, 0xE0, 0x90 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD8110, new byte[] { 0xFF, 0xC0, 0x10, 0x90 }); ////SET to default
            }
        }

        public void STATIC_MOVEMENT(bool toggle)
        {
            if (toggle)  /////Static Movement
            {
                PS3.SetMemory(0x00A98FA4, new byte[] { 0xFF, 0xA0, 0x18, 0x90 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A98FA4, new byte[] { 0xFF, 0xA0, 0x08, 0x90 }); ////SET to default
            }
        }


        public void LOBBY_MESSAGES(bool toggle)
        {
            if (toggle)  /////Lobby Messages
            {
                PS3.SetMemory(0x003ABE28, new byte[] { 0xFF, 0x60, 0x88, 0x90 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABE28, new byte[] { 0xFF, 0x60, 0x08, 0x90 }); ////SET to default
            }
        }

        public void SHAKE_CAMERA(bool toggle)
        {
            if (toggle)  /////Shake Camera
            {
                PS3.SetMemory(0x00A98FA4, new byte[] { 0xFF, 0x0A, 0x28, 0x90 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A98FA4, new byte[] { 0xFF, 0xA0, 0x08, 0x90 }); ////SET to default
            }
        }

        public void DEMI_GOD(bool toggle)
        {
            if (toggle)  /////Demi God
            {
                PS3.SetMemory(0x003A4064, new byte[] { 0xFF, 0x40, 0x88, 0x90 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A4064, new byte[] { 0xFF, 0x40, 0x08, 0x90 }); ////SET to default
            }
        }


        public void INSTANT_KILL_ALL(bool toggle)
        {
            if (toggle)  /////Instant Kill all
            {
                PS3.SetMemory(0x003A4064, new byte[] { 0xFF, 0x40, 0x28, 0x90 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A4064, new byte[] { 0xFF, 0x40, 0x08, 0x90 }); ////SET to default
            }
        }

        public void ENTITY_SKINS_RED(bool toggle)
        {
            if (toggle)  ////Skins Red Players
            {
                PS3.SetMemory(0x00AD5B60, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD5B60, new byte[] { 0x40 }); ////SET to default
            }
        }

        public void GLITCHED_DEAD_MOBS(bool toggle)
        {
            if (toggle)  ////Glitched Dead Mobs
            {
                PS3.SetMemory(0x00EA89E2, new byte[] { 0x18 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00EA89E2, new byte[] { 0x08 }); ////SET to default
            }
        }


        public void FIRE_INSTANT_REMOVED(bool toggle)
        {
            if (toggle)  ////Fire Removed If player go out fire
            {
                PS3.SetMemory(0x00225E80, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00225E80, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void WALK_IN_SKY(bool toggle)
        {
            if (toggle)  ////Walk in sky
            {
                PS3.SetMemory(0x00011B00, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00011B00, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void BYPASS_KILL_ALL(bool toggle)
        {
            if (toggle)  ////Bypass Kill All Creative
            {
                PS3.SetMemory(0x00226168, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00226168, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void SUPER_JUMP_V2(bool toggle)
        {
            if (toggle)  ////Super Jump V2
            {
                PS3.SetMemory(0x003AA77C, new byte[] { 0x3F }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003AA77C, new byte[] { 0x3E }); ////SET to default
            }
        }


        public void REMOVE_LEVEL_XP(bool toggle)
        {
            if (toggle)  ////Remove XP
            {
                PS3.SetMemory(0x004B00AC, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x004B00AC, new byte[] { 0x40 }); ////SET to default
            }
        }

        public void AUTO_REGENERATE_HEALTH(bool toggle)
        {
            if (toggle)  ////Auto Regenerate
            {
                PS3.SetMemory(0x002ADCE8, new byte[] { 0x68, 0x63, 0x00, 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002ADCE8, new byte[] { 0x68, 0x63, 0x00, 0x01 }); ////SET to default
            }
        }

        public void CANT_GRAB_ITEMS_V3(bool toggle)
        {
            if (toggle)  ////Can't Grab Items
            {
                PS3.SetMemory(0x003105F4, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003105F4, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void GRAVITY_MOON(bool toggle)
        {
            if (toggle)  //////Gravity Moon
            {
                PS3.SetMemory(0x003ABF88, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABF88, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void FLAT_BLOCKS(bool toggle)
        {
            if (toggle)  //////Flat Block
            {
                PS3.SetMemory(0x000924FF, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x000924FF, new byte[] { 0x00 }); ////SET to default
            }
        }

        public void BLOCKS_HAND_UP(bool toggle)
        {
            if (toggle)  //////Block Hand Up
            {
                PS3.SetMemory(0x00092507, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00092507, new byte[] { 0x00 }); ////SET to default
            }
        }

        public void SUPER_SPEED_V7(bool toggle)
        {
            if (toggle)  //////Super Speed V7
            {
                PS3.SetMemory(0x003ABD48, new byte[] { 0x3F, 0xFF, 0x00, 0x01 }); ////MODIFED VALUE
                PS3.SetMemory(0x003ABD48, new byte[] { 0x41, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABD48, new byte[] { 0x3E, 0x26, 0xAD, 0x89 }); ////SET to default
                PS3.SetMemory(0x003ABD48, new byte[] { 0x3E, 0x26 }); ////SET to default
            }
        }

        public void POTIONS_GRAVITY_FLY(bool toggle)
        {
            if (toggle)  //////Potions Gravity In Air
            {
                PS3.SetMemory(0x0065FB60, new byte[] { 0x2D }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0065FB60, new byte[] { 0x3D }); ////SET to default
            }
        }


        public void POTIONS_NO_GRAVITY(bool toggle)
        {
            if (toggle)  //////Potions do not fly in air 
            {
                PS3.SetMemory(0x0065FB60, new byte[] { 0x4D }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0065FB60, new byte[] { 0x3D }); ////SET to default
            }
        }

        public void GAMEPLAY_COLORS(string toggle)
        {
            uint offset = 0x3000AAF8;
            if (toggle == "0")
            {
                byte[] buffer = new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80 }; //DEFAULT
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "1")
            {
                byte[] buffer = new byte[] { 0x3F, 0xFF, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80 }; //RED
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "2")
            {
                byte[] buffer = new byte[] { 0x3F, 0x00, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80 }; //CYAN
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "3")
            {
                byte[] buffer = new byte[] { 0x4F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80 }; //RED BLUE
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "4")
            {
                byte[] buffer = new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x00, 0x00, 0x00, 0x3F, 0x80 }; //Purple
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "5")
            {
                byte[] buffer = new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x3F, 0xFF, 0x00, 0x00, 0x3F, 0x80 }; //Green
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "6")
            {
                byte[] buffer = new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x4F, 0x80, 0x00, 0x00, 0x3F, 0x80 }; //Purple Green
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "7")
            {
                byte[] buffer = new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x00 }; //Yellow
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "8")
            {
                byte[] buffer = new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0xFF }; //Blue
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "9")
            {
                byte[] buffer = new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x4F, 0x80 }; //Yellow Blue
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "10")
            {
                byte[] buffer = new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x4F, 0x80, 0x00, 0x00, 0x4F, 0x80 }; //Cyan Red
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "11")
            {
                byte[] buffer = new byte[] { 0x4F, 0x80, 0x00, 0x00, 0x4F, 0x80, 0x00, 0x00, 0x4F, 0x80 }; //Black and white
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "12")
            {
                byte[] buffer = new byte[] { 0x4F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x4F, 0x80 }; //Pink Red
                PS3.SetMemory(offset, buffer);
            }
        }

        public void TOGGLE_SPRINT_V2(bool toggle)
        {
            if (toggle)  //////Toogle Sprint V2
            {
                PS3.SetMemory(0x00B01EEF, new byte[] { 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B01EEF, new byte[] { 0x01 }); ////SET to default
            }
        }

        public void ARROWS_BLOCKS_ITEMS(bool toggle)
        {
            if (toggle)  //////Block Arrows Items
            {
                PS3.SetMemory(0x000FB55C, new byte[] { 0x80 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x000FB55C, new byte[] { 0x40 }); ////SET to default
            }
        }

        public void ARROWS_REMOVE(bool toggle)
        {
            if (toggle)  //////Remove Arrows
            {
                PS3.SetMemory(0x000FB644, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x000FB644, new byte[] { 0x40 }); ////SET to default
            }
        }

        public void ARROWS_CHANGE_DIRECTIONS(bool toggle)
        {
            if (toggle)  //////Direction Arrow
            {
                PS3.SetMemory(0x000FB55C, new byte[] { 0x45 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x000FB55C, new byte[] { 0x40 }); ////SET to default
            }
        }


        public void VIBRATE_WALK(bool toggle)
        {
            if (toggle)  //////Vibrate Walk
            {
                PS3.SetMemory(0x004A3D99, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x004A3D99, new byte[] { 0x20 }); ////SET to default
            }
        }

        public void PARTICLES_FLY_V2(bool toggle)
        {
            if (toggle)  //////Particles fly V2
            {
                PS3.SetMemory(0x00B52100, new byte[] { 0xBF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B52100, new byte[] { 0x3F }); ////SET to default
            }
        }

        public void CHANGE_POSITIONS_PLACE(bool toggle)
        {
            if (toggle)  //////Change position place
            {
                PS3.SetMemory(0x0022C85A, new byte[] { 0x28 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0022C85A, new byte[] { 0x08 }); ////SET to default
            }
        }

        public void DESTROY_GAME(bool toggle)
        {
            if (toggle)  //////Destroy Game !
            {
                PS3.SetMemory(0x00B21C96, new byte[] { 0x48 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B21C96, new byte[] { 0x08 }); ////SET to default
            }
        }

        public void LINES_BLOCKS_MOVE(bool toggle)
        {
            if (toggle)  /////Line blocks move !
            {
                PS3.SetMemory(0x00B259DE, new byte[] { 0x48 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B259DE, new byte[] { 0x08 }); ////SET to default
            }
        }

        public void DISABLE_PLAYERS(bool toggle)
        {
            if (toggle)  /////Disable Players
            {
                PS3.SetMemory(0x001D3BF2, new byte[] { 0x48 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x001D3BF2, new byte[] { 0x08 }); ////SET to default
            }
        }

        public void LOBBY_MESSAGES_SPAM(bool toggle)
        {
            if (toggle)  /////Lobby Messages Spams
            {
                PS3.SetMemory(0x003A4A36, new byte[] { 0x48 }); ////MODIFED VALUE
                PS3.SetMemory(0x003A7BB6, new byte[] { 0x48 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A4A36, new byte[] { 0x08 }); ////SET to default
                PS3.SetMemory(0x003A7BB6, new byte[] { 0x08 }); ////SET to default
            }
        }

        public void ALL_PLAYERS_FAST_SPEED_V2(bool toggle)
        {
            if (toggle)  /////All players have speed V2
            {
                PS3.SetMemory(0x004668B6, new byte[] { 0x58 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x004668B6, new byte[] { 0x08 }); ////SET to default
            }
        }

        public void PLAYERS_LISTS(bool toggle)
        {
            if (toggle)  /////Players Lists
            {
                PS3.SetMemory(0x007151AA, new byte[] { 0x48 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x007151AA, new byte[] { 0x08 }); ////SET to default
            }
        }

        public void SMALL_TEXT(bool toggle)
        {
            if (toggle)  ////Small Text
            {
                PS3.SetMemory(0x0079E326, new byte[] { 0x48 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0079E326, new byte[] { 0x08 }); ////SET to default
            }
        }

        public void POSITIONS_HUD(bool toggle)
        {
            if (toggle)  ////Position Hud text
            {
                PS3.SetMemory(0x0079E8DE, new byte[] { 0x58 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0079E8DE, new byte[] { 0x08 }); ////SET to default
            }
        }

        public void ARMS_BROKEN_V2(bool toggle)
        {
            if (toggle)  ////Arms Broken V2
            {
                PS3.SetMemory(0x00AD6172, new byte[] { 0x48 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD6172, new byte[] { 0x08 }); ////SET to default
            }
        }

        public void AUTO_KILL_MOBS_SPAWNED(bool toggle)
        {
            if (toggle)  ////Kill mobs spawned
            {
                PS3.SetMemory(0x005BF34E, new byte[] { 0x48 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x005BF34E, new byte[] { 0x08 }); ////SET to default
            }
        }

        public void WEATHER_SNOW(bool toggle)
        {
            if (toggle)  ////Make Snow !
            {
                PS3.SetMemory(0x00A9B23E, new byte[] { 0x48 }); ////MODIFED VALUE
                PS3.SetMemory(0x00A9B986, new byte[] { 0x58 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A9B23E, new byte[] { 0x08 }); ////SET to default
                PS3.SetMemory(0x00A9B986, new byte[] { 0x08 }); ////SET to default
            }
        }

        public void WEATHER_RAIN(bool toggle)
        {
            if (toggle)  ////Make Rain !
            {
                PS3.SetMemory(0x00A9B23E, new byte[] { 0x48 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A9B23E, new byte[] { 0x08 }); ////SET to default
            }
        }

        public void FOG_BLACK(bool toggle)
        {
            if (toggle)  ////Fog Black !
            {
                PS3.SetMemory(0x00AA1B76, new byte[] { 0x28 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AA1B76, new byte[] { 0x08 }); ////SET to default
            }
        }

        public void LIGHTING_BOLT(bool toggle)
        {
            if (toggle)  ////Lightning Bolt
            {
                PS3.SetMemory(0x0098871F, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0098871F, new byte[] { 0x00 }); ////SET to default
            }
        }

        public void LIGHTNING_BOLT_V2(bool toggle)
        {
            if (toggle)  ////Lightning Bolt V2
            {
                PS3.SetMemory(0x0098871F, new byte[] { 0x01 }); ////MODIFED VALUE
                PS3.SetMemory(0x00393E34, new byte[] { 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0098871F, new byte[] { 0x00 }); ////SET to default
                PS3.SetMemory(0x00393E34, new byte[] { 0x3F }); ////SET to default
            }
        }


        public void LINES_SELECTED_BLOCKS(string toggle)
        {
            uint offset = 0x00B25990;
            uint offset1 = 0x00B25994;
            uint offset2 = 0x00B25998;
            uint offset3 = 0x00B259A0;
            uint offset4 = 0x00B25A58;
            uint offset5 = 0x00B25A59;
            uint offset6 = 0x00B259A0;
            uint blue = 0x00B25A5E;

            if (toggle == "0")
            {
                byte[] buffer = new byte[] { 0x00, 0x00 }; //DEFAULT
                byte[] buffer1 = new byte[] { 0x3E, 0xCC }; //DEFAULT
                byte[] buffer2 = new byte[] { 0x40, 0x00 }; //DEFAULT
                byte[] buffer3 = new byte[] { 0x3F, 0x60 }; //DEFAULT
                byte[] buffer4 = new byte[] { 0xFC, 0x40 }; //DEFAULT
                byte[] buffer5 = new byte[] { 0x08 }; //DEFAULT BLUE BOX
                PS3.SetMemory(offset, buffer);
                PS3.SetMemory(offset1, buffer1);
                PS3.SetMemory(offset2, buffer2);
                PS3.SetMemory(offset3, buffer3);
                PS3.SetMemory(offset4, buffer4);
                PS3.SetMemory(blue, buffer5);
            }
            else if (toggle == "1")
            {
                byte[] buffer = new byte[] { 0x3F, 0xFF }; //White Line Box
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "2")
            {
                byte[] buffer = new byte[] { 0x4E }; //Black Line Box
                PS3.SetMemory(offset1, buffer);
            }
            else if (toggle == "3")
            {
                byte[] buffer = new byte[] { 0x7E }; //Green Line Box
                PS3.SetMemory(offset5, buffer);
            }
            else if (toggle == "4")
            {
                byte[] buffer = new byte[] { 0x48 }; //Blue Line Box
                PS3.SetMemory(blue, buffer);
            }
            else if (toggle == "5")
            {
                byte[] buffer = new byte[] { 0x41 }; //Big X1
                PS3.SetMemory(offset2, buffer);
            }
            else if (toggle == "6")
            {
                byte[] buffer = new byte[] { 0x42 }; //Big X2
                PS3.SetMemory(offset2, buffer);
            }
            else if (toggle == "7")
            {
                byte[] buffer = new byte[] { 0x60 }; //Big x3
                PS3.SetMemory(offset2, buffer);
            }
            else if (toggle == "8")
            {
                byte[] buffer = new byte[] { 0xA0 }; //Box X1
                PS3.SetMemory(offset6, buffer);
            }
            else if (toggle == "9")
            {
                byte[] buffer = new byte[] { 0xB0 }; //Box X2
                PS3.SetMemory(offset6, buffer);
            }
            else if (toggle == "10")
            {
                byte[] buffer = new byte[] { 0xD0 }; //Box X3
                PS3.SetMemory(offset6, buffer);
            }
            else if (toggle == "11")
            {
                byte[] buffer = new byte[] { 0xFF }; //Box X4
                PS3.SetMemory(offset6, buffer);
            }
        }

        public void SUPER_SPEED_LEGIT(bool toggle)
        {
            if (toggle)  //////Speed Legit
            {
                PS3.SetMemory(0x003ABD49, new byte[] { 0x86 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ABD49, new byte[] { 0x26 }); ////SET to default
            }
        }

        public void SCAFFOLD_BETA(bool toggle)
        {
            if (toggle)  //////Scaffold Place BETA !
            {
                PS3.SetMemory(0x0022C7FC, new byte[] { 0x50 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0022C7FC, new byte[] { 0x40 }); ////SET to default
            }
        }

        public void ALL_PLAYERS_CANT_RUN_V2(bool toggle)
        {
            if (toggle)  //////All can't run / walk
            {
                PS3.SetMemory(0x004668B6, new byte[] { 0x78 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x004668B6, new byte[] { 0x08 }); ////SET to default
            }
        }

        public void BLINK_SKY(bool toggle)
        {
            if (toggle)  //////blink sky
            {
                PS3.SetMemory(0x00393E34, new byte[] { 0xBF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00393E34, new byte[] { 0x3F }); ////SET to default
            }
        }

        public void STOP_FALL_GRAVITY(bool toggle)
        {
            if (toggle)  //////Stop Fall Gravity
            {
                PS3.SetMemory(0x00246A2C, new byte[] { 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00246A2C, new byte[] { 0x3F }); ////SET to default
            }
        }

        public void ALL_PLAYERS_SPAM_ZOOM(bool toggle)
        {
            if (toggle)  //////SPAM ZOOM
            {
                PS3.SetMemory(0x004668B6, new byte[] { 0x78 }); ////DEFAULT 
                PS3.SetMemory(0x004668B6, new byte[] { 0x78 }); ////DEFAULT
                PS3.SetMemory(0x004668B6, new byte[] { 0x08 }); ////MODIFIED
                PS3.SetMemory(0x004668B6, new byte[] { 0x08 }); ////MODIFIED
            }
            else if (!toggle)
            {

            }
        }

        public void ANTI_AFK_V3(bool toggle)
        {
            if (toggle)  //////Anti AFK V3
            {
                PS3.SetMemory(0x002267B0, new byte[] { 0x3F, 0xF0 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002267B0, new byte[] { 0x00, 0x00, 0x00, 0x00 }); ////SET to default
            }
        }

        public void ITEMS_IN_HAND_POSITIONS(string toggle)
        {
            uint offset = 0x00ACA524;
            if (toggle == "0")
            {
                byte[] buffer = new byte[] { 0xBF, 0x00 }; //DEFAULT
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "1")
            {
                byte[] buffer = new byte[] { 0xAF, 0x80 }; //X1 RIGHT
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "2")
            {
                byte[] buffer = new byte[] { 0xBF, 0x80 }; //X1 LEFT
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "3")
            {
                byte[] buffer = new byte[] { 0x3F, 0x00 }; //X2 RIGHT
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "4")
            {
                byte[] buffer = new byte[] { 0xBF, 0xFF }; //X2 LEFT
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "5")
            {
                byte[] buffer = new byte[] { 0x3F, 0xFF }; //X3 RIGHT
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "6")
            {
                byte[] buffer = new byte[] { 0x4F, 0xFF }; //REMOVE
                PS3.SetMemory(offset, buffer);
            }
        }

        public void SUN_MOON_SIZE(string toggle)
        {
            uint remove = 0x00B21F1C;
            uint size = 0x00B21F28;
            uint change = 0x00B21F5C;

            if (toggle == "0")
            {
                byte[] buffer = new byte[] { 0x3F, 0x80 }; //DEFAULT REMOVE SUN
                byte[] buffer1 = new byte[] { 0x42, 0xC8 }; //DEFAULT SIZE SUN
                byte[] buffer2 = new byte[] { 0x43, 0xB4 }; //DEFAULT CHANGE SUN / MOON
                PS3.SetMemory(remove, buffer);
                PS3.SetMemory(size, buffer1);
                PS3.SetMemory(change, buffer2);
            }
            else if (toggle == "1")
            {
                byte[] buffer = new byte[] { 0x2F, 0x80 }; //REMOVE SUN / MOON
                PS3.SetMemory(remove, buffer);
            }
            else if (toggle == "2")
            {
                byte[] buffer = new byte[] { 0x3F, 0xFF }; //4 SUN + Light Moon Better
                PS3.SetMemory(remove, buffer);
            }
            else if (toggle == "3")
            {
                byte[] buffer = new byte[] { 0x4F, 0xFF }; //Light Moon Max
                PS3.SetMemory(remove, buffer);
            }
            else if (toggle == "4")
            {
                byte[] buffer = new byte[] { 0x43, 0xC8 }; //Sun Size Little
                PS3.SetMemory(size, buffer);
            }
            else if (toggle == "5")
            {
                byte[] buffer = new byte[] { 0x41, 0xC8 }; //Sun Size Big X1
                PS3.SetMemory(size, buffer);
            }
            else if (toggle == "6")
            {
                byte[] buffer = new byte[] { 0x40, 0xC8 }; //Sun Size Big X2
                PS3.SetMemory(size, buffer);
            }
            else if (toggle == "7")
            {
                byte[] buffer = new byte[] { 0x40, 0x00 }; //Sun Size Big X3
                PS3.SetMemory(size, buffer);
            }
            else if (toggle == "8")
            {
                byte[] buffer = new byte[] { 0x43, 0x84 }; //Moon To Sun and Sun To Moon
                PS3.SetMemory(change, buffer);
            }
        }

        public void SKY_TO_NETHER(bool toggle)
        {
            if (toggle)  //////Sky Nether
            {
                PS3.SetMemory(0x00B22050, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B22050, new byte[] { 0x40 }); ////SET to default
            }
        }

        public void SMOKE_LOBBY(bool toggle)
        {
            if (toggle)  //////Smoke Lobby
            {
                PS3.SetMemory(0x00B24177, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B24177, new byte[] { 0x00 }); ////SET to default
            }
        }

        public void CAN_SEE_UNDER_WORLD(bool toggle)
        {
            if (toggle)  //////Look under map
            {
                PS3.SetMemory(0x00A98A91, new byte[] { 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A98A91, new byte[] { 0x40 }); ////SET to default
            }
        }

        public void FREE_CAM(bool toggle)
        {
            if (toggle)  //////Free Cam
            {
                PS3.SetMemory(0x00A98A95, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A98A95, new byte[] { 0x30 }); ////SET to default
            }
        }

        public void CORRUPT_WORLD(bool toggle)
        {
            if (toggle)  //////Corrupt Map
            {
                PS3.SetMemory(0x0098871F, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0098871F, new byte[] { 0x00 }); ////SET to default
            }
        }

        public void LIGHT_EYES_ENDERMAN(bool toggle)
        {
            if (toggle)  //////Light Eyes Enderman
            {
                PS3.SetMemory(0x00A68148, new byte[] { 0x4F, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A68148, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }

        public void REMOVE_HANDS(bool toggle)
        {
            if (toggle)  //////Remove Hand
            {
                PS3.SetMemory(0x00AF10A8, new byte[] { 0x38, 0x60, 0x00, 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AF10A8, new byte[] { 0x38, 0x60, 0x00, 0x00 }); ////SET to default
            }
        }


        public void HAND_POSITION(string toggle)
        {
            uint normal = 0x00AD14EC;
            uint normal1 = 0x00AD14F0;
            uint normal2 = 0x00AD14F4;
            uint normal3 = 0x00AD14F8;
            uint normal4 = 0x00AD0274;

            if (toggle == "0")
            {
                byte[] buffer = new byte[] { 0x3F, 0x0F }; //DEFAULT 
                byte[] buffer1 = new byte[] { 0xBF, 0x19 }; //DEFAULT 
                byte[] buffer2 = new byte[] { 0xBF, 0x05 }; //DEFAULT 
                byte[] buffer3 = new byte[] { 0xBF, 0x38 }; //DEFAULT 
                byte[] buffer4 = new byte[] { 0x3F, 0x23 }; //DEFAULT 
                PS3.SetMemory(normal, buffer);
                PS3.SetMemory(normal1, buffer1);
                PS3.SetMemory(normal2, buffer2);
                PS3.SetMemory(normal3, buffer3);
                PS3.SetMemory(normal4, buffer4);
            }
            if (toggle == "1")
            {
                byte[] buffer = new byte[] { 0x3F, 0x0F }; //Hand Right
                PS3.SetMemory(normal, buffer);
            }
            if (toggle == "2")
            {
                byte[] buffer = new byte[] { 0xBF, 0x0F }; //Hand Left
                byte[] buffer1 = new byte[] { 0xBF, 0x23 }; //Hand Left
                PS3.SetMemory(normal, buffer);
                PS3.SetMemory(normal4, buffer1);
            }
            if (toggle == "3")
            {
                byte[] buffer = new byte[] { 0x8F, 0x0F }; //Middle hand
                byte[] buffer1 = new byte[] { 0x8F, 0x23 }; //Middle Hand
                PS3.SetMemory(normal, buffer);
                PS3.SetMemory(normal4, buffer1);
            }
            if (toggle == "4")
            {
                byte[] buffer = new byte[] { 0x8F, 0x05 }; //Hand Up
                PS3.SetMemory(normal2, buffer);
            }
            if (toggle == "5")
            {
                byte[] buffer = new byte[] { 0xBF, 0x25 }; //Hand Down
                PS3.SetMemory(normal2, buffer);
            }
            if (toggle == "6")
            {
                byte[] buffer = new byte[] { 0xBF, 0x68 }; //Hand Long X1
                PS3.SetMemory(normal3, buffer);
            }
            if (toggle == "7")
            {
                byte[] buffer = new byte[] { 0xBF, 0x98 }; //Hand Long X2
                PS3.SetMemory(normal3, buffer);
            }
            if (toggle == "8")
            {
                byte[] buffer = new byte[] { 0xBF, 0xB8 }; //Hand Long X3
                PS3.SetMemory(normal3, buffer);
            }
            if (toggle == "9")
            {
                byte[] buffer = new byte[] { 0xBF, 0xFF }; //Hand Long MAX
                PS3.SetMemory(normal3, buffer);
            }
        }

        public void LABYMOD_SETTINGS(bool toggle)
        {
            if (toggle)  //////Labymod Settings
            {
                PS3.SetMemory(0x00AD14EC, new byte[] { 0xBF, 0x0F }); ////Left Hand
                PS3.SetMemory(0x00AD0274, new byte[] { 0xBF, 0x23 }); ////Left Hand
                PS3.SetMemory(0x00AD8158, new byte[] { 0x4C }); ////Name Over Head
                PS3.SetMemory(0x00B01DEC, new byte[] { 0x40, 0x82 }); ////AutoSprint
                PS3.SetMemory(0x003097C8, new byte[] { 0x40 }); ////ID Items
                PS3.SetMemory(0x003097B8, new byte[] { 0x40 }); ////ID Items
                PS3.SetMemory(0x0090B5F0, new byte[] { 0x38, 0x80, 0x00, 0x01 }); ////Show Armor
                PS3.SetMemory(0x00AD5A5C, new byte[] { 0x3F, 0xFF }); ////Damage Indicator
                PS3.SetMemory(0x00227BDC, new byte[] { 0x40 }); ////Remove Run Anim
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nLabymod ON");
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD14EC, new byte[] { 0x3F, 0x0F }); ////Left Hand
                PS3.SetMemory(0x00AD0274, new byte[] { 0x3F, 0x23 }); ////Left Hand
                PS3.SetMemory(0x00AD8158, new byte[] { 0x2C }); ////Name Over Head
                PS3.SetMemory(0x00B01DEC, new byte[] { 0x41, 0x82 }); ////AutoSprint
                PS3.SetMemory(0x003097C8, new byte[] { 0x41 }); ////ID Items
                PS3.SetMemory(0x003097B8, new byte[] { 0x41 }); ////ID Items
                PS3.SetMemory(0x0090B5F0, new byte[] { 0x38, 0x80, 0x00, 0x00 }); ////Show Armor
                PS3.SetMemory(0x00AD5A5C, new byte[] { 0x3F, 0x80 }); ////Damage Indicator
                PS3.SetMemory(0x00227BDC, new byte[] { 0x41 }); ////Remove Run Anim
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nLabymod OFF");
            }
        }


        public void PARTICLES_TORNADO(bool toggle)
        {
            if (toggle)  //////Tornado Particles
            {
                PS3.SetMemory(0x00B50B32, new byte[] { 0x58 }); //MODIFIED VALUES
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B50B32, new byte[] { 0x08 }); //DEFAULT VALUES
            }
        }

        public void FAST_MOVE_LEGS_ARMS(bool toggle)
        {
            if (toggle)  //////Fast Move Legs / Arms
            {
                PS3.SetMemory(0x00B5A62E, new byte[] { 0x98 }); //MODIFIED VALUES
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B5A62E, new byte[] { 0x08 }); //DEFAULT VALUES
            }
        }

        public void LEGS_IN_AIR(bool toggle)
        {
            if (toggle)  //////Legs in air
            {
                PS3.SetMemory(0x00B5A62E, new byte[] { 0xC8 }); //MODIFIED VALUES
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B5A62E, new byte[] { 0x08 }); //DEFAULT VALUES
            }
        }

        public void DAMAGE_HIT_RED_BLUE(bool toggle)
        {
            if (toggle)  //////Hit Damage RED / BLUE
            {
                PS3.SetMemory(0x00AD5B7A, new byte[] { 0xD0 }); //MODIFIED VALUES
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD5B7A, new byte[] { 0xC0 }); //DEFAULT VALUES
            }
        }

        public void NO_DELAY_HIT_DAMAGE(bool toggle)
        {
            if (toggle)  //////No delay hit damage
            {
                PS3.SetMemory(0x003A3FF0, new byte[] { 0x20 }); //MODIFIED VALUES
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A3FF0, new byte[] { 0x00 }); //DEFAULT VALUES
            }
        }

        public void DISABLE_FOG(bool toggle)
        {
            if (toggle)  //////Disable Fog
            {
                PS3.SetMemory(0x003A3FF0, new byte[] { 0xFF, 0x00 }); //MODIFIED VALUES
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A3FF0, new byte[] { 0x3F, 0x80 }); //DEFAULT VALUES
            }
        }

        public void ESP_ENTITY_RED(bool toggle)
        {
            if (toggle)  ////ESP Players / Mobs RED
            {
                PS3.SetMemory(0x00AD5B60, new byte[] { 0x41 }); ////MODIFED VALUE
                PS3.SetMemory(0x00AD5A5C, new byte[] { 0x6F, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD5B60, new byte[] { 0x40 }); ////SET to default
                PS3.SetMemory(0x00AD5A5C, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }

        public void ESP_ENTITY_BLUE(bool toggle)
        {
            if (toggle)  ////ESP Players / Mobs BLUE
            {
                PS3.SetMemory(0x00AD5B60, new byte[] { 0x41 }); ////MODIFED VALUE
                PS3.SetMemory(0x00AD5A5C, new byte[] { 0xFF, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD5B60, new byte[] { 0x40 }); ////SET to default
                PS3.SetMemory(0x00AD5A5C, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }

        public void FOV_WITHOUT_HAND(bool toggle)
        {
            if (toggle)  //////FOV Without Hand
            {
                PS3.SetMemory(0x00987502, new byte[] { 0x68 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00987502, new byte[] { 0x08 }); ////SET to default
            }
        }

        public void ZOOM_WITHOUT_HAND(bool toggle)
        {
            if (toggle)  //////ZOOM Without Hand
            {
                PS3.SetMemory(0x00987502, new byte[] { 0xF8 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00987502, new byte[] { 0x08 }); ////SET to default
            }
        }


        public void WEATHER_STATE(string toggle) //RAIN OPTIONS
        {
            uint normal = 0x00A9B140; //3F 80
            uint normal1 = 0x00A9B144; //3F 00
            uint normal2 = 0x00A9B150; //3E 80
            uint normal3 = 0x00A9B158; //3F A0

            if (toggle == "0")
            {
                byte[] buffer = new byte[] { 0x3F, 0x80 }; //DEFAULT 
                byte[] buffer1 = new byte[] { 0x3F, 0x00 }; //DEFAULT 
                byte[] buffer2 = new byte[] { 0xBF, 0x05 }; //DEFAULT 
                byte[] buffer3 = new byte[] { 0x3F, 0xA0 }; //DEFAULT 
                byte[] buffer4 = new byte[] { 0x3F, 0x23 }; //DEFAULT 
                PS3.SetMemory(normal, buffer);
                PS3.SetMemory(normal1, buffer1);
                PS3.SetMemory(normal2, buffer2);
                PS3.SetMemory(normal3, buffer3);
            }
            else if (toggle == "1")
            {
                byte[] buffer = new byte[] { 0x1F, 0x80 }; //Remove Rain / Snow
                PS3.SetMemory(normal, buffer);
            }
            else if (toggle == "2")
            {
                byte[] buffer = new byte[] { 0x4F, 0x80 }; //WTF Rain
                PS3.SetMemory(normal, buffer);
            }
            else if (toggle == "3")
            {
                byte[] buffer = new byte[] { 0x3F, 0xFF }; //Much Rain / Snow
                PS3.SetMemory(normal, buffer);
            }
            else if (toggle == "4")
            {
                byte[] buffer = new byte[] { 0x3F, 0xFF }; //Big Particles Rain / Snow
                PS3.SetMemory(normal1, buffer);
            }
            else if (toggle == "5")
            {
                byte[] buffer = new byte[] { 0xFF, 0x80 }; //Pink Rain / Snow
                PS3.SetMemory(normal2, buffer);
            }
            else if (toggle == "6")
            {
                byte[] buffer = new byte[] { 0x4E, 0x80 }; //long Rain / Snow
                PS3.SetMemory(normal2, buffer);
            }
            else if (toggle == "7")
            {
                byte[] buffer = new byte[] { 0x8E, 0x80 }; //Fast Rain / Snow
                PS3.SetMemory(normal2, buffer);
            }
            else if (toggle == "8")
            {
                byte[] buffer = new byte[] { 0x1F, 0xA0 }; //Freeze Rain / Snow
                PS3.SetMemory(normal3, buffer);
            }
            else if (toggle == "9")
            {
                byte[] buffer = new byte[] { 0xBF, 0x90 }; //Reverse Rain / Snow
                PS3.SetMemory(normal3, buffer);
            }
        }


        public void ALL_PLAYERS_TAKE_DAMAGE(bool toggle)
        {
            if (toggle)  //////All Players Take Damage
            {
                PS3.SetMemory(0x0039E2D4, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0039E2D4, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void INFINITE_FOOD(bool toggle)
        {
            if (toggle)  //////Infinite Food
            {
                PS3.SetMemory(0x0043E9F7, new byte[] { 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0043E9F7, new byte[] { 0x01 }); ////SET to default
            }
        }

        public void UNFAIR_ATTACK(bool toggle)
        {
            if (toggle)  //////Unfair Attack
            {
                PS3.SetMemory(0x00AEBED4, new byte[] { 0xBE }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEBED4, new byte[] { 0x3E }); ////SET to default
            }
        }


        public void AUTO_BUILD_IN_SURVIVAL(bool toggle)
        {
            if (toggle)  //////Auto Build Survival
            {
                PS3.SetMemory(0x00AECF10, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AECF10, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void REACH_VALUES(string toggle)
        {
            uint offset = 0x00A95FB9; //reach creative ENTITY MOB
            uint offset1 = 0x00A95FC1; //reach survival ENTITY MOB
            uint offset2 = 0x00B351D8; //creative
            uint offset3 = 0x00B351DC; //survival

            if (toggle == "0")
            {
                byte[] buffer = new byte[] { 0x18 }; //DEFAULT
                byte[] buffer1 = new byte[] { 0x08 }; //DEFAULT
                byte[] buffer2 = new byte[] { 0x40, 0xA0, 0x00, 0x00 }; //DEFAULT
                byte[] buffer3 = new byte[] { 0x40, 0x90, 0x00, 0x00 }; //DEFAULT
                PS3.SetMemory(offset, buffer);
                PS3.SetMemory(offset1, buffer1);
                PS3.SetMemory(offset2, buffer2);
                PS3.SetMemory(offset3, buffer3);
            }
            else if (toggle == "1")
            {
                byte[] buffer = new byte[] { 0x80 }; //Reach Small
                byte[] buffer1 = new byte[] { 0x80 };
                byte[] buffer2 = new byte[] { 0x41, 0xA0, 0x00, 0x00 };
                byte[] buffer3 = new byte[] { 0x41, 0xA0, 0x00, 0x00 };
                PS3.SetMemory(offset, buffer);
                PS3.SetMemory(offset1, buffer1);
                PS3.SetMemory(offset2, buffer2);
                PS3.SetMemory(offset3, buffer3);
            }
            else if (toggle == "2")
            {
                byte[] buffer = new byte[] { 0x80 }; //Reach Medium
                byte[] buffer1 = new byte[] { 0x80 };
                byte[] buffer2 = new byte[] { 0x42, 0xA0, 0x00, 0x00 };
                byte[] buffer3 = new byte[] { 0x42, 0xA0, 0x00, 0x00 };
                PS3.SetMemory(offset, buffer);
                PS3.SetMemory(offset1, buffer1);
                PS3.SetMemory(offset2, buffer2);
                PS3.SetMemory(offset3, buffer3);
            }
            else if (toggle == "3")
            {
                byte[] buffer = new byte[] { 0x80 }; //Reach Large
                byte[] buffer1 = new byte[] { 0x80 };
                byte[] buffer2 = new byte[] { 0x45, 0xA0, 0x00, 0x00 };
                byte[] buffer3 = new byte[] { 0x45, 0xA0, 0x00, 0x00 };
                PS3.SetMemory(offset, buffer);
                PS3.SetMemory(offset1, buffer1);
                PS3.SetMemory(offset2, buffer2);
                PS3.SetMemory(offset3, buffer3);
            }
        }


        public void ESP_PLAYERS(bool toggle)
        {
            if (toggle)  //////ESP Players
            {
                PS3.SetMemory(0x00A98F50, new byte[] { 0x3F, 0x00 }); ////MODIFED VALUE WALL HACK
                PS3.SetMemory(0x00AD5B60, new byte[] { 0x41 }); ////MODIFED VALUE ESP RED
                PS3.SetMemory(0x00AD5A5C, new byte[] { 0x6F, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A98F50, new byte[] { 0x3D, 0x8C }); ////MODIFED VALUE WALL HACK
                PS3.SetMemory(0x00AD5B60, new byte[] { 0x40 }); ////SET to default ESP RED
                PS3.SetMemory(0x00AD5A5C, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }


        public void HITBOX_BETA(bool toggle)
        {
            if (toggle)  //////HitBox BETA
            {
                PS3.SetMemory(0x0003AE03, new byte[] { 0x01 }); ////BETA HITBOX
                PS3.SetMemory(0x00233290, new byte[] { 0xFF }); ////KILL AURA
                PS3.SetMemory(0x00B25998, new byte[] { 0x41 }); ////LINE BIGGER
                PS3.SetMemory(0x00B25A59, new byte[] { 0x20 }); ////GREEN
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0003AE03, new byte[] { 0x00 }); ////SET to default
                PS3.SetMemory(0x00233290, new byte[] { 0x00 }); ////MODIFED VALUE
                PS3.SetMemory(0x00B25998, new byte[] { 0x40 }); ////LINE BIGGER
                PS3.SetMemory(0x00B25A59, new byte[] { 0x40 }); ////GREEN
            }
        }


        public void WEATHER_TO_RAIN_ANYTIME(bool toggle)
        {
            if (toggle)  //////Weather To Rain Anytime
            {
                PS3.SetMemory(0x00393F8F, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00393F8F, new byte[] { 0x00 }); ////SET to default
            }
        }

        public void WALL_HACK_V3(bool toggle)
        {
            if (toggle)  //////Wall Hack Best
            {
                PS3.SetMemory(0x00A98F50, new byte[] { 0x3F, 0x00 }); ////MODIFED VALUE WALL HACK
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A98F50, new byte[] { 0x3D, 0x8C }); ////MODIFED VALUE WALL HACK
            }
        }

        public void OLD_FLY_OPTIONS(bool toggle)
        {
            if (toggle)  //////Old Fly Option
            {
                PS3.SetMemory(0x00A98F50, new byte[] { 0x3F, 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A98F50, new byte[] { 0x3D, 0x8C }); ////MODIFED VALUE
            }
        }

        public void MOBS_IGNORE_ME(bool toggle)
        {
            if (toggle)  //////Mobs ignore me
            {
                PS3.SetMemory(0x00A98F50, new byte[] { 0x3F, 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A98F50, new byte[] { 0x3D, 0x8C }); ////MODIFED VALUE
            }
        }

        public void DISALBE_HUD_TEXT(bool toggle)
        {
            if (toggle)  //////Disable Text HUD
            {
                PS3.SetMemory(0x008FC4B4, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x008FC4B4, new byte[] { 0x41 }); ////MODIFED VALUE
            }
        }


        public void MINE_IN_ADVENTURE(bool toggle)
        {
            if (toggle)  //////GOD MODE ONLY FOR ME
            {
                PS3.SetMemory(0x002F0273, new byte[] { 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002F0273, new byte[] { 0x01 }); ////SET to default
            }
        }


        public void NAME_OVER_HEAD_DOUBLE(bool toggle)
        {
            if (toggle)  /////Double Name Over Head
            {
                PS3.SetMemory(0x00979BCF, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00979BCF, new byte[] { 0x00 }); ////SET to default
            }
        }

        public void BOAT_STOP_WORKING(bool toggle)
        {
            if (toggle)  /////Stop Boat
            {
                PS3.SetMemory(0x000E0F90, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x000E0F90, new byte[] { 0x40 }); ////SET to default
            }
        }

        public void HUD_HIDE_EVERYTHING(bool toggle)
        {
            if (toggle)  /////Hide HUD Everything
            {
                PS3.SetMemory(0x00884148, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00884148, new byte[] { 0x40 }); ////SET to default
            }
        }

        public void GAME_NO_ITEMS(bool toggle)
        {
            if (toggle)  /////Game No Items
            {
                PS3.SetMemory(0x002FE98B, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002FE98B, new byte[] { 0x00 }); ////SET to default
            }
        }

        public void IRON_HELMET_EVERYONE(bool toggle)
        {
            if (toggle)  /////Iron Helmet All
            {
                PS3.SetMemory(0x002FE983, new byte[] { 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002FE983, new byte[] { 0x01 }); ////SET to default
            }
        }

        public void TEXTURE_BLACK(bool toggle)
        {
            if (toggle)  /////Texture Black
            {
                PS3.SetMemory(0x00A73854, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A73854, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void GAMMA_TO_MAX(bool toggle)
        {
            if (toggle)  /////Max Gamma
            {
                PS3.SetMemory(0x00A9C2B4, new byte[] { 0x3F, 0xFF }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A9C2B4, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }

        public void NAME_AND_SHADOW_BLACK(bool toggle)
        {
            if (toggle)  /////Name + Shadow Black
            {
                PS3.SetMemory(0x00A73878, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A73878, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void TRIDENT_RIPTIDE_TO_MAX(bool toggle)
        {
            if (toggle)  /////Trident Riptide Max
            {
                PS3.SetMemory(0x00217DCF, new byte[] { 0x08 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00217DCF, new byte[] { 0x00 }); ////SET to default
            }
        }

        public void ALLOW_ALL_ITEMS_ON_HEAD(bool toggle)
        {
            if (toggle)  /////Allow all items on head
            {
                PS3.SetMemory(0x00428704, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00428704, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void NO_COLISSION_ENTITY(bool toggle)
        {
            if (toggle)  /////No Colission Entity
            {
                PS3.SetMemory(0x000108AC, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x000108AC, new byte[] { 0x40 }); ////SET to default
            }
        }

        public void ENABLE_ALL_ENCHANTEMENT(bool toggle)
        {
            if (toggle)  /////Enable All Enchant
            {
                PS3.SetMemory(0x00218A4F, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00218A4F, new byte[] { 0x00 }); ////SET to default
            }
        }

        public void ENCHANTEMENT_LEVEL(string toggle)
        {
            uint offset = 0x00218A4F;
            if (toggle == "0")
            {
                byte[] buffer = new byte[] { 0x00 }; //DEFAULT
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "1")
            {
                byte[] buffer = new byte[] { 0x01 }; //Level 1
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "2")
            {
                byte[] buffer = new byte[] { 0x02 }; //Level 2
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "3")
            {
                byte[] buffer = new byte[] { 0x03 }; //Level 3
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "4")
            {
                byte[] buffer = new byte[] { 0x04 }; //Level 4
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "5")
            {
                byte[] buffer = new byte[] { 0x05 }; //Level 5
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "6")
            {
                byte[] buffer = new byte[] { 0x10 }; //Level 6
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "7")
            {
                byte[] buffer = new byte[] { 0x20 }; //Level 7
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "8")
            {
                byte[] buffer = new byte[] { 0x30 }; //Level 8
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "9")
            {
                byte[] buffer = new byte[] { 0x40 }; //Level 9
                PS3.SetMemory(offset, buffer);
            }
            else if (toggle == "10")
            {
                byte[] buffer = new byte[] { 0xFF }; //Level 10
                PS3.SetMemory(offset, buffer);
            }
        }

        public void FROST_WALKER(bool toggle)
        {
            if (toggle)  /////Frost Walk
            {
                PS3.SetMemory(0x00218A4F, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00218A4F, new byte[] { 0x00 }); ////SET to default
            }
        }

        public void NO_WEB_HAX(bool toggle)
        {
            if (toggle)  /////No Web
            {
                PS3.SetMemory(0x00234F9F, new byte[] { 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00234F9F, new byte[] { 0x01 }); ////SET to default
            }
        }

        public void FLY_OR_RUN_ON_CROUCH(bool toggle)
        {
            if (toggle)  /////Fly or Run with Crouch
            {
                PS3.SetMemory(0x00B0142B, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B0142B, new byte[] { 0x00 }); ////SET to default
            }
        }

        public void AUTO_LADDER(bool toggle)
        {
            if (toggle)  ////Auto Ladder
            {
                PS3.SetMemory(0x003A74F3, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A74F3, new byte[] { 0x00 }); ////SET to default
            }
        }

        public void ANIMATION_CHARACTER(bool toggle)
        {
            if (toggle)  ////Anim Character
            {
                PS3.SetMemory(0x00A89AC8, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A89AC8, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void BIG_ANIMATION_CHARACTER(bool toggle)
        {
            if (toggle)  //// Big Anim Character
            {
                PS3.SetMemory(0x00A8919D, new byte[] { 0xF0 }); ////MODIFED VALUE
                PS3.SetMemory(0x00A891A1, new byte[] { 0xF0 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A8919D, new byte[] { 0x40 }); ////SET to default
                PS3.SetMemory(0x00A891A1, new byte[] { 0x40 }); ////SET to default
            }
        }

        public void NETHER_VISION(bool toggle)
        {
            if (toggle)  ////Nether Vision
            {
                PS3.SetMemory(0x00B018D0, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B018D0, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void ENTITY_GOD_MODE(bool toggle)
        {
            if (toggle)  ////Entity God Mode
            {
                PS3.SetMemory(0x003A3F6C, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A3F6C, new byte[] { 0x41 }); ////SET to default
            }
        }


        public void ENABLE_SPECIAL_BLOCK(bool toggle)
        {
            if (toggle)  //////Enable Get Special Blocks
            {
                PS3.SetMemory(0x00218A4F, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00218A4F, new byte[] { 0x00 }); ////SET to default
            }
        }


        public void FROSTED_ICE_TO_BARRIERE(bool toggle)
        {
            PS3.SetMemory(0x014C8C84, new byte[] { 0x32, 0x19, 0x93, 0xC0 }); ////Barriere
        }

        public void FROSTED_ICE_TO_EGGS_DRAGON(bool toggle)
        {
            PS3.SetMemory(0x014C8C84, new byte[] { 0x32, 0x19, 0x2E, 0x10 }); ////Eggs Dragon
        }

        public void FROSTED_ICE_TO_REAPETING_COMMAND_BLOCK(bool toggle)
        {
            PS3.SetMemory(0x014C8C84, new byte[] { 0x32, 0x19, 0xED, 0xB0 }); ////Reapeting Command Block
        }

        public void FROSTED_ICE_TO_GREEN_COMMAND_BLOCK(bool toggle)
        {
            PS3.SetMemory(0x014C8C84, new byte[] { 0x32, 0x19, 0xEF, 0x30 }); ////Green Command Block
        }

        public void FROSTED_ICE_TO_COMMAND_BLOCK(bool toggle)
        {
            PS3.SetMemory(0x014C8C84, new byte[] { 0x32, 0x19, 0x4F, 0x20 }); ////Command Block
        }

        public void FROSTED_ICE_TO_DEFAULT(bool toggle)
        {
            PS3.SetMemory(0x014C8C84, new byte[] { 0x32, 0x19, 0xF1, 0xE0 }); ////Frosted Ice
        }

        public void FROSTED_ICE_TO_MAGMA(bool toggle)
        {
            PS3.SetMemory(0x014C8C84, new byte[] { 0x32, 0x19, 0xF4, 0xC0 }); ////Magma
        }

        public void FROSTED_ICE_TO_ENDER_GATEWAY(bool toggle)
        {
            PS3.SetMemory(0x014C8C84, new byte[] { 0x32, 0x19, 0xEC, 0x00 }); ////Ender Gateway
        }

        public void FROSTED_ICE_TO_DAIMOND_ORE(bool toggle)
        {
            PS3.SetMemory(0x014C8C84, new byte[] { 0x32, 0x18, 0xB4, 0x60 }); ////Daimond ore
        }

        public void FROSTED_ICE_TO_SIGN(bool toggle)
        {
            PS3.SetMemory(0x014C8C84, new byte[] { 0x32, 0x18, 0xBE, 0x00 }); ////Sign
        }


        public void SPECTRAL_ARROWS_WITH_BOW(bool toggle)
        {
            if (toggle)  //////Arrows To Spectral Arrows
            {
                PS3.SetMemory(0x014C90D4, new byte[] { 0x32, 0x20, 0x8D, 0xA0 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x014C90D4, new byte[] { 0x32, 0x1E, 0xAD, 0xA0 }); ////SET to default
            }
        }

        public void CHANGE_AIR_TO_WATER(bool toggle)
        {
            if (toggle)  //////Air To Water
            {
                PS3.SetMemory(0x001D7FCC, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x001D7FCC, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void MULTI_JUMP_V2(bool toggle)
        {
            if (toggle)  /////Multi Jump V2
            {
                PS3.SetMemory(0x003B000A, new byte[] { 0x02 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003B000A, new byte[] { 0x01 }); ////SET to default
            }
        }

        public void ALL_PLAYERS_LEFT_HAND(bool toggle)
        {
            if (toggle)  /////All Players Hand To Left
            {
                PS3.SetMemory(0x0151F2F0, new byte[] { 0x30, 0x01, 0x87, 0xF0 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0151F2F0, new byte[] { 0x30, 0x01, 0x87, 0xF8 }); ////SET to default
            }
        }

        public void PARTICLES_DAMAGE_NO_STOP(bool toggle)
        {
            if (toggle)  /////Particles Hit No Stop
            {
                PS3.SetMemory(0x00B520F7, new byte[] { 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B520F7, new byte[] { 0x01 }); ////SET to default
            }
        }

        public void ROBLOX_ANIMATION(bool toggle)
        {
            if (toggle)  /////ROBLOX ANIM
            {
                PS3.SetMemory(0x002341D0, new byte[] { 0xC3 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002341D0, new byte[] { 0xC0 }); ////SET to default
            }
        }

        public void INFINITE_OXYGEN_IN_WATER(bool toggle)
        {
            if (toggle)  ////Infinite Oxygen In Water
            {
                PS3.SetMemory(0x0039DE28, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0039DE28, new byte[] { 0x40 }); ////SET to default
            }
        }

        public void ENTITY_TO_BABY(bool toggle)
        {
            if (toggle)  ////Players To Baby
            {
                PS3.SetMemory(0x0039F52F, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0039F52F, new byte[] { 0x00 }); ////SET to default
            }
        }


        public void ITEMS_WATER_TO_FOUR_4J_DEBUG(bool toggle)
        {
            PS3.SetMemory(0x014C91F0, new byte[] { 0x32, 0x20, 0xCF, 0xB0 }); ////Four 4J
        }

        public void ITEMS_WATER_TO_(bool toggle)
        {
            PS3.SetMemory(0x014C91F0, new byte[] { 0x32, 0x1F, 0x5F, 0x80 }); ////Golden Apple
        }

        public void ITEMS_WATER_TO_DIAMOND(bool toggle)
        {
            PS3.SetMemory(0x014C91F0, new byte[] { 0x32, 0x1E, 0xB2, 0x40 }); ////Diamond
        }

        public void ITEMS_WATER_TO_COMMAND_BLOCK(bool toggle)
        {
            PS3.SetMemory(0x014C91F0, new byte[] { 0x32, 0x20, 0x64, 0x20 }); ////Command Block Cart
        }

        public void ITEMS_WATER_TO_SPAWN_EGGS(bool toggle)
        {
            PS3.SetMemory(0x014C91F0, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Spawn Eggs
        }

        public void ITEMS_WATER_TO_DIAMOND_SWORD(bool toggle)
        {
            PS3.SetMemory(0x014C91F0, new byte[] { 0x32, 0x1E, 0xD5, 0x20 }); ////Diamond Sword
        }

        public void bunifuImageButton19_Click(bool toggle)
        {
            PS3.SetMemory(0x014C91F0, new byte[] { 0x32, 0x1E, 0xDB, 0x50 }); ////Diamond PickAxe
        }

        public void bunifuImageButton20_Click(bool toggle)
        {
            PS3.SetMemory(0x014C91F0, new byte[] { 0x32, 0x20, 0x8D, 0xA0 }); ////Spectral Arrows
        }

        public void GET_SPECTATOR_GAMEMODE(bool toggle)
        {
            if (toggle)  ////GET SPECTATOR GAMEMODE
            {
                PS3.SetMemory(0x014C9048, new byte[] { 0x32, 0x3A, 0x84, 0xC0 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x014C9048, new byte[] { 0x32, 0x39, 0x4B, 0xD0 }); ////SET to default
            }
        }

        public void BLOCKS_STATIC_CRACK(bool toggle)
        {
            if (toggle)  //////Block Static Crack
            {
                PS3.SetMemory(0x00AE3C3F, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AE3C3F, new byte[] { 0x00 }); ////SET to default
            }
        }

        public void KILL_DISAPPEAR_ENTITY(bool toggle)
        {
            if (toggle)  //////Kill Disappear Entity
            {
                PS3.SetMemory(0x0039F587, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0039F587, new byte[] { 0x14 }); ////SET to default
            }
        }

        public void KILL_DONT_DISAPPEAR_ENTITY(bool toggle)
        {
            if (toggle)  //////Kill Don't Disappear Entity
            {
                PS3.SetMemory(0x0039F587, new byte[] { 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0039F587, new byte[] { 0x14 }); ////SET to default
            }
        }

        public void CHANGE_SOURCE_KILL(string toggle)
        {
            if (toggle == "0")
            {
                PS3.SetMemory(0x015118BC, new byte[] { 0x30, 0x8B, 0xC4, 0xEC }); ////RESET FALL DMG 
                PS3.SetMemory(0x015118C4, new byte[] { 0x30, 0x8B, 0xC5, 0x24 }); ////RESET OUT OF WORLD
            }
            else if (toggle == "1")
            {
                PS3.SetMemory(0x015118BC, new byte[] { 0x30, 0x8B, 0xC5, 0x24 }); ////FALL DMG TO OUT OF WORLD
            }
            else if (toggle == "2")
            {
                PS3.SetMemory(0x015118C4, new byte[] { 0x30, 0x8B, 0xC4, 0xEC }); ////OUT OF WORLD TO FALL DMG
            }
            else if (toggle == "3")
            {
                PS3.SetMemory(0x015118BC, new byte[] { 0x30, 0x8B, 0xC5, 0x08 }); ////FALL DAMAGE TO KINNETIC ENERGY
            }
        }


        public void GET_IDS_PLAYERS_ON_HEAD(bool toggle)
        {
            if (toggle)  //////Get IDs players on head
            {
                PS3.SetMemory(0x004B5DF3, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x004B5DF3, new byte[] { 0x00 }); ////SET to default
            }
        }


        public void GET_64_ITEMS_BLOCKS(bool toggle)
        {
            if (toggle)  //////Get 64 blocks / items
            {
                PS3.SetMemory(0x004B5DF3, new byte[] { 0x01 }); ////MODIFED VALUE
                PS3.SetMemory(0x323BB9DF, new byte[] { 0x40 }); ////STONE
                PS3.SetMemory(0x323BBACF, new byte[] { 0x40 }); ////COBBLESTONE
                PS3.SetMemory(0x323BBBBF, new byte[] { 0x40 }); ////GRASS BLOCK
                PS3.SetMemory(0x323BBCAF, new byte[] { 0x40 }); ////DIRT
                PS3.SetMemory(0x323BBD9F, new byte[] { 0x40 }); ////GRASS PATH
                PS3.SetMemory(0x323BBEEF, new byte[] { 0x40 }); ////SAND
                PS3.SetMemory(0x323BC07F, new byte[] { 0x40 }); ////SANDSTONE
                PS3.SetMemory(0x323BC16F, new byte[] { 0x40 }); ////SMOOTH SANDSTONE
                PS3.SetMemory(0x323BC25F, new byte[] { 0x40 }); ////CHISELED SANDSTONE
                PS3.SetMemory(0x323BC34F, new byte[] { 0x40 }); ////RED SAND
                PS3.SetMemory(0x323BC43F, new byte[] { 0x40 }); ////RED SANDSTONE
                PS3.SetMemory(0x323BC52F, new byte[] { 0x40 }); ////SMOOTH RED SANDSTONE
                PS3.SetMemory(0x323BC61F, new byte[] { 0x40 }); ////CHISELED RED SANDSTONE
                PS3.SetMemory(0x323BC70F, new byte[] { 0x40 }); ////GRANITE
                PS3.SetMemory(0x323BC75F, new byte[] { 0x40 }); ////DRIED KELP BLOCK
                PS3.SetMemory(0x323BC84F, new byte[] { 0x40 }); ////POLISHED GRANITE
                PS3.SetMemory(0x323BC93F, new byte[] { 0x40 }); ////ANDESITE
                PS3.SetMemory(0x323BCA2F, new byte[] { 0x40 }); ////POLISHED ANDESITE
                PS3.SetMemory(0x323BCB1F, new byte[] { 0x40 }); ////DIORITE
                PS3.SetMemory(0x323BCC0F, new byte[] { 0x40 }); ////POLISHED DIORITE
                PS3.SetMemory(0x323BCCFF, new byte[] { 0x40 }); ////Block of Coal
                PS3.SetMemory(0x323BCE8F, new byte[] { 0x40 }); ////Block of gold
                PS3.SetMemory(0x323BCF7F, new byte[] { 0x40 }); ////Block of iron
                PS3.SetMemory(0x323BD06F, new byte[] { 0x40 }); ////Lapis Lazuli Block
                PS3.SetMemory(0x323BD15F, new byte[] { 0x40 }); ////Block of Diamond
                PS3.SetMemory(0x323BD24F, new byte[] { 0x40 }); ////Block of Emerald
                PS3.SetMemory(0x323BD33F, new byte[] { 0x40 }); ////Block of Quartz
                PS3.SetMemory(0x323BD42F, new byte[] { 0x40 }); ////Coal Ore
                PS3.SetMemory(0x323BD51F, new byte[] { 0x40 }); ////Lapis Lazuli Ore
                PS3.SetMemory(0x323BD6BF, new byte[] { 0x40 }); ////Diamond Ore
                PS3.SetMemory(0x323BD7AF, new byte[] { 0x40 }); ////Redstone Ore
                PS3.SetMemory(0x323BD89F, new byte[] { 0x40 }); ////Iron Ore
                PS3.SetMemory(0x323BD98F, new byte[] { 0x40 }); ////Gold Ore
                PS3.SetMemory(0x323BDA7F, new byte[] { 0x40 }); ////Emerald Ore
                PS3.SetMemory(0x323BDB6F, new byte[] { 0x40 }); ////Nether Quartz Ore
                PS3.SetMemory(0x323BDC5F, new byte[] { 0x40 }); ////Nether Wart Block
                PS3.SetMemory(0x323BDD4F, new byte[] { 0x40 }); ////Bedrock
                PS3.SetMemory(0x323BDE3F, new byte[] { 0x40 }); ////Oak Planks
                PS3.SetMemory(0x323BDF2F, new byte[] { 0x40 }); ////Sprice Planks
                PS3.SetMemory(0x323BE01F, new byte[] { 0x40 }); ////Birch Planks
                PS3.SetMemory(0x323BE10F, new byte[] { 0x40 }); ////Jungle Planks
                PS3.SetMemory(0x323BE1FF, new byte[] { 0x40 }); ////Acasia Planks
                PS3.SetMemory(0x323BE2EF, new byte[] { 0x40 }); ////Dark Oak Planks
                PS3.SetMemory(0x323BE3DF, new byte[] { 0x40 }); ////Dark Prismarine
                PS3.SetMemory(0x323BE4DF, new byte[] { 0x40 }); ////Oak Wood
                PS3.SetMemory(0x323BE5CF, new byte[] { 0x40 }); ////Spruce Wood
                PS3.SetMemory(0x323BE6BF, new byte[] { 0x40 }); ////Birch Wood
                PS3.SetMemory(0x323BE7AF, new byte[] { 0x40 }); ////Jungle Wood
                PS3.SetMemory(0x323BE89F, new byte[] { 0x40 }); ////Acacia Wood
                PS3.SetMemory(0x323BE98F, new byte[] { 0x40 }); ////Dark Oak Wood
                PS3.SetMemory(0x323BEA7F, new byte[] { 0x40 }); ////Srtipped Oak Log
                PS3.SetMemory(0x323BEB6F, new byte[] { 0x40 }); ////Stripped Spruce Log
                PS3.SetMemory(0x323BEC5F, new byte[] { 0x40 }); ////Stripped Birch Log
                PS3.SetMemory(0x323BED4F, new byte[] { 0x40 }); ////Stripped Jungle Log
                PS3.SetMemory(0x323BEE3F, new byte[] { 0x40 }); ////Stripped Acacia Log
                PS3.SetMemory(0x323BEF2F, new byte[] { 0x40 }); ////Stripped Dark Oak Log
                PS3.SetMemory(0x323BF01F, new byte[] { 0x40 }); ////Gravel
                PS3.SetMemory(0x323BF10F, new byte[] { 0x40 }); ////Bricks
                PS3.SetMemory(0x323BF1FF, new byte[] { 0x40 }); ////Moss Stone
                PS3.SetMemory(0x323BF2EF, new byte[] { 0x40 }); ////Obsidian
                PS3.SetMemory(0x323BF3DF, new byte[] { 0x40 }); ////Clay
                PS3.SetMemory(0x323BF4CF, new byte[] { 0x40 }); ////Ice
                PS3.SetMemory(0x323BF5BF, new byte[] { 0x40 }); ////Packed Ice
                PS3.SetMemory(0x323BF6AF, new byte[] { 0x40 }); ////Blue Ice
                PS3.SetMemory(0x323BF79F, new byte[] { 0x40 }); ////Snow
                PS3.SetMemory(0x323BF88F, new byte[] { 0x40 }); ////Red Nether Brick
                PS3.SetMemory(0x323BF8DF, new byte[] { 0x40 }); ////End Stone
                PS3.SetMemory(0x323BFA0F, new byte[] { 0x40 }); ////Netherrack
                PS3.SetMemory(0x323BFAFF, new byte[] { 0x40 }); ////Soul Sand
                PS3.SetMemory(0x323BFBEF, new byte[] { 0x40 }); ////Glow Stone
                PS3.SetMemory(0x323BFCDF, new byte[] { 0x40 }); ////Magma Block
                PS3.SetMemory(0x323BFDCF, new byte[] { 0x40 }); ////Sea Lantern
                PS3.SetMemory(0x323F1EEF, new byte[] { 0x40 }); ////Prismarine Block
                PS3.SetMemory(0x323F1F3F, new byte[] { 0x40 }); ////Slim Block
                PS3.SetMemory(0x323FBEEF, new byte[] { 0x40 }); ////Oak Fence
                PS3.SetMemory(0x323FBFDF, new byte[] { 0x40 }); ////Sprice Fence
                PS3.SetMemory(0x323FC0CF, new byte[] { 0x40 }); ////Birch Fence
                PS3.SetMemory(0x323FC1BF, new byte[] { 0x40 }); ////Jungle Fence
                PS3.SetMemory(0x323FC2AF, new byte[] { 0x40 }); ////Acacia Fence
                PS3.SetMemory(0x323FC39F, new byte[] { 0x40 }); ////Dark Oak Fence
                PS3.SetMemory(0x323FC48F, new byte[] { 0x40 }); ////Nether Brick Fence
                PS3.SetMemory(0x323FC57F, new byte[] { 0x40 }); ////Iron Bars
                PS3.SetMemory(0x323FC66F, new byte[] { 0x40 }); ////Stone Bricks
                PS3.SetMemory(0x323FC75F, new byte[] { 0x40 }); ////Mossy Stone Bricks
                PS3.SetMemory(0x323FC84F, new byte[] { 0x40 }); ////Cracked Stone Bricks
                PS3.SetMemory(0x323FC93F, new byte[] { 0x40 }); ////Chiseled Stone Bricks
                PS3.SetMemory(0x323FCA2F, new byte[] { 0x40 }); ////Silverfish Stone
                PS3.SetMemory(0x323FCB1F, new byte[] { 0x40 }); ////Silverfish Cobblestone
                PS3.SetMemory(0x323FCC0F, new byte[] { 0x40 }); ////Silverfish Stone Brick
                PS3.SetMemory(0x323FCCFF, new byte[] { 0x40 }); ////Silverfish Mossy Stone Brick
                PS3.SetMemory(0x323FCDEF, new byte[] { 0x40 }); ////Silverfish Cracked Stone Brick
                PS3.SetMemory(0x323FCEDF, new byte[] { 0x40 }); ////Silverfish Chiseled Stone Brick
                PS3.SetMemory(0x323FCFCF, new byte[] { 0x40 }); ////Mycelium
                PS3.SetMemory(0x323FD0BF, new byte[] { 0x40 }); ////Coarse Dirt
                PS3.SetMemory(0x323FD1AF, new byte[] { 0x40 }); ////Podzol
                PS3.SetMemory(0x323FD29F, new byte[] { 0x40 }); ////Nether Brick
                PS3.SetMemory(0x323FD47F, new byte[] { 0x40 }); ////End Stone
                PS3.SetMemory(0x323FD66F, new byte[] { 0x40 }); ////End Stone Brick
                PS3.SetMemory(0x323FD75F, new byte[] { 0x40 }); ////Chiseled Quartz Block
                PS3.SetMemory(0x323FD84F, new byte[] { 0x40 }); ////Pillar Quartz Block
                PS3.SetMemory(0x32412D8F, new byte[] { 0x40 }); ////Elyta
                PS3.SetMemory(0x32414C5F, new byte[] { 0x40 }); ////Black Bed
                PS3.SetMemory(0x32414D4F, new byte[] { 0x40 }); ////Blue Bed
                PS3.SetMemory(0x32414E3F, new byte[] { 0x40 }); ////Light Blue Bed
                PS3.SetMemory(0x32414F2F, new byte[] { 0x40 }); ////Cyan Bed
                PS3.SetMemory(0x3241501F, new byte[] { 0x40 }); ////Green Bed
                PS3.SetMemory(0x3241525F, new byte[] { 0x40 }); ////Pink Bed
                PS3.SetMemory(0x3241534F, new byte[] { 0x40 }); ////Magenta Bed
                PS3.SetMemory(0x3241543F, new byte[] { 0x40 }); ////Purple Bed
                PS3.SetMemory(0x3241552F, new byte[] { 0x40 }); ////Red Bed
                PS3.SetMemory(0x3241561F, new byte[] { 0x40 }); ////Brown Bed
                PS3.SetMemory(0x3241570F, new byte[] { 0x40 }); ////Orange Bed
                PS3.SetMemory(0x324157FF, new byte[] { 0x40 }); ////Yellow Bed
                PS3.SetMemory(0x324158EF, new byte[] { 0x40 }); ////White Bed
                PS3.SetMemory(0x324159DF, new byte[] { 0x40 }); ////Light Gray Bed
                PS3.SetMemory(0x32415ACF, new byte[] { 0x40 }); ////Gray Bed
                PS3.SetMemory(0x32415FDF, new byte[] { 0x40 }); ////Bucket
                PS3.SetMemory(0x324160CF, new byte[] { 0x40 }); ////Lava Bucket
                PS3.SetMemory(0x324161BF, new byte[] { 0x40 }); ////Water Bucket
                PS3.SetMemory(0x324162AF, new byte[] { 0x40 }); ////Milk Bucket
                PS3.SetMemory(0x3241639F, new byte[] { 0x40 }); ////Bucket Of Cod
                PS3.SetMemory(0x3241648F, new byte[] { 0x40 }); ////Bucket Of Salmon
                PS3.SetMemory(0x3241657F, new byte[] { 0x40 }); ////Bucket Of Puffefish
                PS3.SetMemory(0x3241666F, new byte[] { 0x40 }); ////Bucket Of Tropical Fish
                PS3.SetMemory(0x3241684F, new byte[] { 0x40 }); ////Snow Ball
                PS3.SetMemory(0x32416B1F, new byte[] { 0x40 }); ////Book And Quill
                PS3.SetMemory(0x32416C0F, new byte[] { 0x40 }); ////Ender Perl
                PS3.SetMemory(0x3241710F, new byte[] { 0x40 }); ////Eggs Creeper
                PS3.SetMemory(0x3241D95F, new byte[] { 0x40 }); ////Bow
                //stone sword = 0x3241FD3F
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x323BB9DF, new byte[] { 0x01 }); ////STONE
                PS3.SetMemory(0x323BBACF, new byte[] { 0x01 }); ////COBBLESTONE
                PS3.SetMemory(0x323BBBBF, new byte[] { 0x01 }); ////GRASS BLOCK
                PS3.SetMemory(0x323BBCAF, new byte[] { 0x01 }); ////DIRT
                PS3.SetMemory(0x323BBD9F, new byte[] { 0x01 }); ////GRASS PATH
                PS3.SetMemory(0x323BBEEF, new byte[] { 0x01 }); ////SAND
                PS3.SetMemory(0x323BC07F, new byte[] { 0x01 }); ////SANDSTONE
                PS3.SetMemory(0x323BC16F, new byte[] { 0x01 }); ////SMOOTH SANDSTONE
                PS3.SetMemory(0x323BC25F, new byte[] { 0x01 }); ////CHISELED SANDSTONE
                PS3.SetMemory(0x323BC34F, new byte[] { 0x01 }); ////RED SAND
                PS3.SetMemory(0x323BC43F, new byte[] { 0x01 }); ////RED SANDSTONE
                PS3.SetMemory(0x323BC52F, new byte[] { 0x01 }); ////SMOOTH RED SANDSTONE
                PS3.SetMemory(0x323BC61F, new byte[] { 0x01 }); ////CHISELED RED SANDSTONE
                PS3.SetMemory(0x323BC70F, new byte[] { 0x01 }); ////GRANITE
                PS3.SetMemory(0x323BC75F, new byte[] { 0x01 }); ////DRIED KELP BLOCK
                PS3.SetMemory(0x323BC84F, new byte[] { 0x01 }); ////POLISHED GRANITE
                PS3.SetMemory(0x323BC93F, new byte[] { 0x01 }); ////ANDESITE
                PS3.SetMemory(0x323BCA2F, new byte[] { 0x01 }); ////POLISHED ANDESITE
                PS3.SetMemory(0x323BCB1F, new byte[] { 0x01 }); ////DIORITE
                PS3.SetMemory(0x323BCC0F, new byte[] { 0x01 }); ////POLISHED DIORITE
                PS3.SetMemory(0x323BCCFF, new byte[] { 0x01 }); ////Block of Coal
                PS3.SetMemory(0x323BCE8F, new byte[] { 0x01 }); ////Block of gold
                PS3.SetMemory(0x323BCF7F, new byte[] { 0x01 }); ////Block of iron
                PS3.SetMemory(0x323BD06F, new byte[] { 0x01 }); ////Lapis Lazuli Block
                PS3.SetMemory(0x323BD15F, new byte[] { 0x01 }); ////Block of Diamond
                PS3.SetMemory(0x323BD24F, new byte[] { 0x01 }); ////Block of Emerald
                PS3.SetMemory(0x323BD33F, new byte[] { 0x01 }); ////Block of Quartz
                PS3.SetMemory(0x323BD42F, new byte[] { 0x01 }); ////Coal Ore
                PS3.SetMemory(0x323BD51F, new byte[] { 0x01 }); ////Lapis Lazuli Ore
                PS3.SetMemory(0x323BD6BF, new byte[] { 0x01 }); ////Diamond Ore
                PS3.SetMemory(0x323BD7AF, new byte[] { 0x01 }); ////Redstone Ore
                PS3.SetMemory(0x323BD89F, new byte[] { 0x01 }); ////Iron Ore
                PS3.SetMemory(0x323BD98F, new byte[] { 0x01 }); ////Gold Ore
                PS3.SetMemory(0x323BDA7F, new byte[] { 0x01 }); ////Emerald Ore
                PS3.SetMemory(0x323BDB6F, new byte[] { 0x01 }); ////Nether Quartz Ore
                PS3.SetMemory(0x323BDC5F, new byte[] { 0x01 }); ////Nether Wart Block
                PS3.SetMemory(0x323BDD4F, new byte[] { 0x01 }); ////Bedrock
                PS3.SetMemory(0x323BDE3F, new byte[] { 0x01 }); ////Oak Planks
                PS3.SetMemory(0x323BDF2F, new byte[] { 0x01 }); ////Sprice Planks
                PS3.SetMemory(0x323BE01F, new byte[] { 0x01 }); ////Birch Planks
                PS3.SetMemory(0x323BE10F, new byte[] { 0x01 }); ////Jungle Planks
                PS3.SetMemory(0x323BE1FF, new byte[] { 0x01 }); ////Acasia Planks
                PS3.SetMemory(0x323BE2EF, new byte[] { 0x01 }); ////Dark Oak Planks
                PS3.SetMemory(0x323BE3DF, new byte[] { 0x01 }); ////Dark Prismarine
                PS3.SetMemory(0x323BE4DF, new byte[] { 0x01 }); ////Oak Wood
                PS3.SetMemory(0x323BE5CF, new byte[] { 0x01 }); ////Spruce Wood
                PS3.SetMemory(0x323BE6BF, new byte[] { 0x01 }); ////Birch Wood
                PS3.SetMemory(0x323BE7AF, new byte[] { 0x01 }); ////Jungle Wood
                PS3.SetMemory(0x323BE89F, new byte[] { 0x01 }); ////Acacia Wood
                PS3.SetMemory(0x323BE98F, new byte[] { 0x01 }); ////Dark Oak Wood
                PS3.SetMemory(0x323BEA7F, new byte[] { 0x01 }); ////Srtipped Oak Log
                PS3.SetMemory(0x323BEB6F, new byte[] { 0x01 }); ////Stripped Spruce Log
                PS3.SetMemory(0x323BEC5F, new byte[] { 0x01 }); ////Stripped Birch Log
                PS3.SetMemory(0x323BED4F, new byte[] { 0x01 }); ////Stripped Jungle Log
                PS3.SetMemory(0x323BEE3F, new byte[] { 0x01 }); ////Stripped Acacia Log
                PS3.SetMemory(0x323BEF2F, new byte[] { 0x01 }); ////Stripped Dark Oak Log
                PS3.SetMemory(0x323BF01F, new byte[] { 0x01 }); ////Gravel
                PS3.SetMemory(0x323BF10F, new byte[] { 0x01 }); ////Bricks
                PS3.SetMemory(0x323BF1FF, new byte[] { 0x01 }); ////Moss Stone
                PS3.SetMemory(0x323BF2EF, new byte[] { 0x01 }); ////Obsidian
                PS3.SetMemory(0x323BF3DF, new byte[] { 0x01 }); ////Clay
                PS3.SetMemory(0x323BF4CF, new byte[] { 0x01 }); ////Ice
                PS3.SetMemory(0x323BF5BF, new byte[] { 0x01 }); ////Packed Ice
                PS3.SetMemory(0x323BF6AF, new byte[] { 0x01 }); ////Blue Ice
                PS3.SetMemory(0x323BF79F, new byte[] { 0x01 }); ////Snow
                PS3.SetMemory(0x323BF88F, new byte[] { 0x01 }); ////Red Nether Brick
                PS3.SetMemory(0x323BF8DF, new byte[] { 0x01 }); ////End Stone
                PS3.SetMemory(0x323BFA0F, new byte[] { 0x01 }); ////Netherrack
                PS3.SetMemory(0x323BFAFF, new byte[] { 0x01 }); ////Soul Sand
                PS3.SetMemory(0x323BFBEF, new byte[] { 0x01 }); ////Glow Stone
                PS3.SetMemory(0x323BFCDF, new byte[] { 0x01 }); ////Magma Block
                PS3.SetMemory(0x323BFDCF, new byte[] { 0x01 }); ////Sea Lantern
                PS3.SetMemory(0x323F1EEF, new byte[] { 0x01 }); ////Prismarine Block
                PS3.SetMemory(0x323F1F3F, new byte[] { 0x01 }); ////Slim Block
                PS3.SetMemory(0x323FBEEF, new byte[] { 0x01 }); ////Oak Fence
                PS3.SetMemory(0x323FBFDF, new byte[] { 0x01 }); ////Sprice Fence
                PS3.SetMemory(0x323FC0CF, new byte[] { 0x01 }); ////Birch Fence
                PS3.SetMemory(0x323FC1BF, new byte[] { 0x01 }); ////Jungle Fence
                PS3.SetMemory(0x323FC2AF, new byte[] { 0x01 }); ////Acacia Fence
                PS3.SetMemory(0x323FC39F, new byte[] { 0x01 }); ////Dark Oak Fence
                PS3.SetMemory(0x323FC48F, new byte[] { 0x01 }); ////Nether Brick Fence
                PS3.SetMemory(0x323FC57F, new byte[] { 0x01 }); ////Iron Bars
                PS3.SetMemory(0x323FC66F, new byte[] { 0x01 }); ////Stone Bricks
                PS3.SetMemory(0x323FC75F, new byte[] { 0x01 }); ////Mossy Stone Bricks
                PS3.SetMemory(0x323FC84F, new byte[] { 0x01 }); ////Cracked Stone Bricks
                PS3.SetMemory(0x323FC93F, new byte[] { 0x01 }); ////Chiseled Stone Bricks
                PS3.SetMemory(0x323FCA2F, new byte[] { 0x01 }); ////Silverfish Stone
                PS3.SetMemory(0x323FCB1F, new byte[] { 0x01 }); ////Silverfish Cobblestone
                PS3.SetMemory(0x323FCC0F, new byte[] { 0x01 }); ////Silverfish Stone Brick
                PS3.SetMemory(0x323FCCFF, new byte[] { 0x01 }); ////Silverfish Mossy Stone Brick
                PS3.SetMemory(0x323FCDEF, new byte[] { 0x01 }); ////Silverfish Cracked Stone Brick
                PS3.SetMemory(0x323FCEDF, new byte[] { 0x01 }); ////Silverfish Chiseled Stone Brick
                PS3.SetMemory(0x323FCFCF, new byte[] { 0x01 }); ////Mycelium
                PS3.SetMemory(0x323FD0BF, new byte[] { 0x01 }); ////Coarse Dirt
                PS3.SetMemory(0x323FD1AF, new byte[] { 0x01 }); ////Podzol
                PS3.SetMemory(0x323FD29F, new byte[] { 0x01 }); ////Nether Brick
                PS3.SetMemory(0x323FD47F, new byte[] { 0x01 }); ////End Stone
                PS3.SetMemory(0x323FD66F, new byte[] { 0x01 }); ////End Stone Brick
                PS3.SetMemory(0x323FD75F, new byte[] { 0x01 }); ////Chiseled Quartz Block
                PS3.SetMemory(0x323FD84F, new byte[] { 0x01 }); ////Pillar Quartz Block
                PS3.SetMemory(0x32412D8F, new byte[] { 0x01 }); ////Elyta
                PS3.SetMemory(0x32414C5F, new byte[] { 0x01 }); ////Black Bed
                PS3.SetMemory(0x32414D4F, new byte[] { 0x01 }); ////Blue Bed
                PS3.SetMemory(0x32414E3F, new byte[] { 0x01 }); ////Light Blue Bed
                PS3.SetMemory(0x32414F2F, new byte[] { 0x01 }); ////Cyan Bed
                PS3.SetMemory(0x3241501F, new byte[] { 0x01 }); ////Green Bed
                PS3.SetMemory(0x3241525F, new byte[] { 0x01 }); ////Pink Bed
                PS3.SetMemory(0x3241534F, new byte[] { 0x01 }); ////Magenta Bed
                PS3.SetMemory(0x3241543F, new byte[] { 0x01 }); ////Purple Bed
                PS3.SetMemory(0x3241552F, new byte[] { 0x01 }); ////Red Bed
                PS3.SetMemory(0x3241561F, new byte[] { 0x01 }); ////Brown Bed
                PS3.SetMemory(0x3241570F, new byte[] { 0x01 }); ////Orange Bed
                PS3.SetMemory(0x324157FF, new byte[] { 0x01 }); ////Yellow Bed
                PS3.SetMemory(0x324158EF, new byte[] { 0x01 }); ////White Bed
                PS3.SetMemory(0x324159DF, new byte[] { 0x01 }); ////Light Gray Bed
                PS3.SetMemory(0x32415ACF, new byte[] { 0x01 }); ////Gray Bed
                PS3.SetMemory(0x32415FDF, new byte[] { 0x01 }); ////Bucket
                PS3.SetMemory(0x324160CF, new byte[] { 0x01 }); ////Lava Bucket
                PS3.SetMemory(0x324161BF, new byte[] { 0x01 }); ////Water Bucket
                PS3.SetMemory(0x324162AF, new byte[] { 0x01 }); ////Milk Bucket
                PS3.SetMemory(0x3241639F, new byte[] { 0x01 }); ////Bucket Of Cod
                PS3.SetMemory(0x3241648F, new byte[] { 0x01 }); ////Bucket Of Salmon
                PS3.SetMemory(0x3241657F, new byte[] { 0x01 }); ////Bucket Of Puffefish
                PS3.SetMemory(0x3241666F, new byte[] { 0x01 }); ////Bucket Of Tropical Fish
                PS3.SetMemory(0x3241684F, new byte[] { 0x01 }); ////Snow Ball
                PS3.SetMemory(0x32416B1F, new byte[] { 0x01 }); ////Book And Quill
                PS3.SetMemory(0x32416C0F, new byte[] { 0x01 }); ////Ender Perl
                PS3.SetMemory(0x3241710F, new byte[] { 0x01 }); ////Eggs Creeper
                PS3.SetMemory(0x3241D95F, new byte[] { 0x01 }); ////Bow
            }
        }


        public void SWITCH_GAME_TO_OFFLINE(bool toggle)
        {
            if (toggle)  //////Swith Game To offline
            {
                PS3.SetMemory(0x324193B9, new byte[] { 0x08 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x324193B9, new byte[] { 0x00 }); ////SET to default
            }
        }

        public void FREEZE_THE_WORLD_WITH_EGG(bool toggle)
        {
            if (toggle)  //////Freeze the world with egg
            {
                PS3.SetMemory(0x324193B9, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x324193B9, new byte[] { 0x00 }); ////SET to default
            }
        }


        public void FISHING_ROD_CANT_BE_REMOVED(bool toggle)
        {
            if (toggle)  //////Fishing Rod Can't be removed
            {
                PS3.SetMemory(0x002C0D98, new byte[] { 0x3B, 0xA0, 0x00, 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002C0D98, new byte[] { 0x3B, 0xA0, 0x00, 0x00 }); ////SET to default
            }
        }

        public void FISHING_ROD_NO_GRAVITY(bool toggle)
        {
            if (toggle)  //////Fishing Rod No Gravity
            {
                PS3.SetMemory(0x002C2948, new byte[] { 0x0F }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002C2948, new byte[] { 0x3F }); ////SET to default
            }
        }

        public void REMOVE_ANIMATION_DETAILED_SKINS(bool toggle)
        {
            if (toggle)  //////Remove Animation Detailed Skins
            {
                PS3.SetMemory(0x004B2468, new byte[] { 0x38, 0x60, 0x00, 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x004B2468, new byte[] { 0x38, 0x60, 0x00, 0x01 }); ////SET to default
            }
        }

        public void CREEPER_CHARGED_DISABLED(bool toggle)
        {
            if (toggle)  //////Disabled Creeper Charged
            {
                PS3.SetMemory(0x001CDB98, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x001CDB98, new byte[] { 0xF8, 0x21, 0xFF, 0x71 }); ////SET to default
            }
        }

        public void LEAD_CANT_BE_REMOVED(bool toggle)
        {
            if (toggle)  //////Lead Can't be removed
            {
                PS3.SetMemory(0x0023B240, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0023B240, new byte[] { 0xF8, 0x21, 0xFF, 0x21 }); ////SET to default
            }
        }

        public void IGNIORING_PRESSURE_PLATE(bool toggle)
        {
            if (toggle)  //////Ignioring Pressure Plate
            {
                PS3.SetMemory(0x00237BC8, new byte[] { 0x38, 0x60, 0x00, 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00237BC8, new byte[] { 0x38, 0x60, 0x00, 0x00 }); ////SET to default
            }
        }

        public void DEAD_PLAYERS_REMAINS_STANDING(bool toggle)
        {
            if (toggle)  /////Dead players remains standing
            {
                PS3.SetMemory(0x0039F548, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0039F548, new byte[] { 0xF8, 0x21, 0xFE, 0xE1 }); ////SET to default
            }
        }

        public void DISABLE_KILLED_OUT_OF_WORLD(bool toggle)
        {
            if (toggle)  /////Disable Die Out Of The World
            {
                PS3.SetMemory(0x003A9350, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A9350, new byte[] { 0xF8, 0x21, 0xFF, 0x91 }); ////SET to default
            }
        }

        public void DISABLE_TOTEM_OF_UNDYING(bool toggle)
        {
            if (toggle)  /////Disable Totem Of Undying
            {
                PS3.SetMemory(0x003A52B8, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A52B8, new byte[] { 0xF8, 0x21, 0xFF, 0x41 }); ////SET to default
            }
        }

        public void ENABLE_AIM_ON_3TH_PRESON(bool toggle)
        {
            if (toggle)  /////Enable Aim On 3th Person
            {
                PS3.SetMemory(0x0090FA30, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0090FA30, new byte[] { 0xF8, 0x21, 0xF5, 0x41 }); ////SET to default
            }
        }

        public void TOTEM_FLOAT_HEALTH(bool toggle)
        {
            if (toggle)  /////Totem Float Health
            {
                PS3.SetMemory(0x003A52B0, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A52B0, new byte[] { 0x3F, 0x80, 0x00, 0x00 }); ////SET to default
            }
        }

        public void ENDERMAN_AND_CHORUS_FRUIT_CANT_BE_TELEPORTED(bool toggle)
        {
            if (toggle)  /////Enderman + chorus fruit can't be teleported
            {
                PS3.SetMemory(0x003B30A8, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003B30A8, new byte[] { 0xF8, 0x21, 0xFE, 0xB1 }); ////SET to default
            }
        }

        public void PLAYERS_ON_ELYTRA(bool toggle)
        {
            if (toggle)  /////Player on Elytra
            {
                PS3.SetMemory(0x003B3008, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003B3008, new byte[] { 0xF8, 0x21, 0xFF, 0x91 }); ////SET to default
            }
        }

        public void WATER_SLOW_DOWN(bool toggle)
        {
            if (toggle)  /////Water Slow Down
            {
                PS3.SetMemory(0x0003AA964, new byte[] { 0x3F, 0x7C, 0xCC, 0xCD }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0003AA964, new byte[] { 0x3F, 0x4C, 0xCC, 0xCD }); ////SET to default
            }
        }

        public void JUMP_IN_LAVA(bool toggle)
        {
            if (toggle)  /////Jump in lava
            {
                PS3.SetMemory(0x003AA940, new byte[] { 0x3F, 0xF4, 0x7A, 0xE1 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003AA940, new byte[] { 0x3F, 0xBA, 0xCC, 0xCD }); ////SET to default
            }
        }

        public void FREEZE_ALL_ENTITY(bool toggle)
        {
            if (toggle)  /////Freeze All Entity
            {
                PS3.SetMemory(0x003A9FE8, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A9FE8, new byte[] { 0xF8, 0x21, 0xFF, 0x81 }); ////SET to default
            }
        }

        public void AUTO_KILL_PLAYERS(bool toggle)
        {
            if (toggle)  ////Auto Kill Players After He Is Dead
            {
                PS3.SetMemory(0x003A8678, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A8678, new byte[] { 0xF8, 0x21, 0xFF, 0x81 }); ////SET to default
            }
        }

        public void DISABLE_PORTALS(bool toggle)
        {
            if (toggle)  ////Disable Portal
            {
                PS3.SetMemory(0x002379E4, new byte[] { 0x38, 0x60, 0x00, 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002379E4, new byte[] { 0x38, 0x60, 0x00, 0x01 }); ////SET to default
            }
        }

        public void ALL_PLAYERS_SUFFOCATE(bool toggle)
        {
            if (toggle)  ////All Players In Wall
            {
                PS3.SetMemory(0x0022FDC8, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0022FDC8, new byte[] { 0xF8, 0x21, 0xFF, 0x11 }); ////SET to default
            }
        }

        public void ENTITY_RENDER(bool toggle)
        {
            if (toggle)  ////Entity Render
            {
                PS3.SetMemory(0x0022CE40, new byte[] { 0x48, 0xFF, 0x00, 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0022CE40, new byte[] { 0x40, 0x48, 0x00, 0x00 }); ////SET to default
            }
        }

        public void DRAW_MODE(string toggle)
        {
            if (toggle == "0")  ////Draw Mode with Diamond Hoe
            {
                MessageBox.Show("Use a diamond hoe on the grass and you will see the block you have select. With that you can draw :p", "How to use ?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                PS3.SetMemory(0x014C8A28, new byte[] { 0x32, 0x18, 0xB9, 0xE0 }); ////SET to default
            }
            else if (toggle == "1")
            {
                MessageBox.Show("Use a diamond hoe on the grass and you will see the block you have select. With that you can draw :p", "How to use ?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                PS3.SetMemory(0x014C8A28, new byte[] { 0x32, 0x19, 0xAE, 0x10 }); ////Red Sandstone Slab
            }
        }

        public void NETHER_PORTAL_WITH_STONE(bool toggle)
        {
            if (toggle)  ////Nether Portal With Stone
            {
                PS3.SetMemory(0x014C89FC, new byte[] { 0x32, 0x18, 0x11, 0xC0 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x014C89FC, new byte[] { 0x32, 0x18, 0x5E, 0x70 }); ////SET to default
            }
        }

        public void DETECT_IF_PLAYERS_HAS_BEEN_ALREADY_DAMAGED(bool toggle)
        {
            if (toggle)  ////Look if player has been already damaged
            {
                PS3.SetMemory(0x003A4A3C, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A4A3C, new byte[] { 0x41 }); ////SET to default
            }
        }

        public void RUNNING_PARTICLES_SPECTRAL(bool toggle)
        {
            if (toggle)  ////Running Particles Spectral
            {
                PS3.SetMemory(0x01550AA0, new byte[] { 0x30, 0xAF, 0x25, 0xB8 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x01550AA0, new byte[] { 0x30, 0xAF, 0x23, 0x10 }); ////SET to default
            }
        }

        public void RUNNING_PARTICLES_WEIRD(bool toggle)
        {
            if (toggle)  ////Running Particles Weird
            {
                PS3.SetMemory(0x01550AA0, new byte[] { 0x30, 0xAF, 0x21, 0xA8 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x01550AA0, new byte[] { 0x30, 0xAF, 0x23, 0x10 }); ////SET to default
            }
        }

        public void AUTO_CROUCH_ON_MOVEMENT(bool toggle)
        {
            if (toggle)  ////Auto Crouch On Movement
            {
                PS3.SetMemory(0x00B0143F, new byte[] { 0x0F }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B0143F, new byte[] { 0x0E }); ////SET to default
            }
        }

        public void ROTATION_HEAD_360_DEGRES(bool toggle)
        {
            if (toggle)  ////360 Rotation Head
            {
                PS3.SetMemory(0x00224FD4, new byte[] { 0xC3 }); ////MODIFED VALUE
                PS3.SetMemory(0x00224FD8, new byte[] { 0x43 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00224FD4, new byte[] { 0xC2 }); ////MODIFED VALUE
                PS3.SetMemory(0x00224FD8, new byte[] { 0x42 }); ////MODIFED VALUE
            }
        }

        public void PLACE_BLOCKS_IN_BATTLE_WORLDS(bool toggle)
        {
            if (toggle)  ////Place Blocks In Battle World
            {
                PS3.SetMemory(0x007D75A3, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x007D75A3, new byte[] { 0x00 }); ////SET to default
            }
        }

        public void CREATIVE_INVENTORY_IN_LOBBY(bool toggle)
        {
            if (toggle)  ////Creative Inventory In Lobby
            {
                PS3.SetMemory(0x00AED18F, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AED18F, new byte[] { 0x00 }); ////SET to default
            }
        }

        public void PERMISSIONS_DESTROY_BLOCKS(bool toggle)
        {
            if (toggle)  ////Premission Destroy Blocks
            {
                PS3.SetMemory(0x007D75FF, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x007D75FF, new byte[] { 0x00 }); ////SET to default
            }
        }


        public void ITEMS_2TH_HAND(string toggle)
        {
            if (toggle == "0")
            {
                PS3.SetMemory(0x014C93F0, new byte[] { 0x32, 0x20, 0xA4, 0xF0 }); ////In 2th hand Default
            }
            else if (toggle == "1")
            {
                PS3.SetMemory(0x014C93F0, new byte[] { 0x32, 0x1F, 0x97, 0xC0 }); ////In 2th hand Fishing Rod
            }

            else if (toggle == "2")
            {
                PS3.SetMemory(0x014C93F0, new byte[] { 0x32, 0x1E, 0xA1, 0x40 }); ////In 2th hand Iron Axe
            }

            else if (toggle == "3")
            {
                PS3.SetMemory(0x014C93F0, new byte[] { 0x32, 0x1E, 0xD5, 0x20 }); ////In 2th hand Diamond Sword
            }
        }


        public void INVENTORY_SPECIAL_BLOCKS(bool toggle)
        {
            if (toggle)  ////Get items on inventory creative
            {
                PS3.SetMemory(0x3241B6B4, new byte[] { 0x32, 0x1B, 0xB4, 0x20 }); ////Water
                PS3.SetMemory(0x3241B7A4, new byte[] { 0x32, 0x1B, 0xB7, 0xF0 }); ////Lava
                PS3.SetMemory(0x3241B894, new byte[] { 0x32, 0x1D, 0x45, 0x90 }); ////Command Block
                PS3.SetMemory(0x3241B984, new byte[] { 0x32, 0x1D, 0x9B, 0x10 }); ////Repeating Command Block
                PS3.SetMemory(0x3241BA74, new byte[] { 0x32, 0x1D, 0x9D, 0xE0 }); ////Blue Command Block
                PS3.SetMemory(0x3241BB64, new byte[] { 0x32, 0x1D, 0x70, 0x00 }); ////Barrier
                PS3.SetMemory(0x3241BC54, new byte[] { 0x32, 0x20, 0x8D, 0xA0 }); ////Spectral Arrow
                PS3.SetMemory(0x3241BD44, new byte[] { 0x32, 0x1B, 0xE3, 0xA0 }); //// Glitched Sign
                PS3.SetMemory(0x3241BE34, new byte[] { 0x32, 0x1B, 0xE9, 0xF0 }); //// Redstone Comparator
                PS3.SetMemory(0x3241BF24, new byte[] { 0x32, 0x1B, 0xEC, 0xE0 }); //// Redstone repetor off
                PS3.SetMemory(0x3241C014, new byte[] { 0x32, 0x1B, 0xEF, 0xD0 }); ////Redstone Repetor on
                PS3.SetMemory(0x3241C104, new byte[] { 0x32, 0x1B, 0xF2, 0xC0 }); ////Pumkin Stem
                PS3.SetMemory(0x3241B3D4, new byte[] { 0x32, 0x1B, 0xF5, 0x10 }); ////Melon Stem
                PS3.SetMemory(0x3241B284, new byte[] { 0x32, 0x1B, 0xF7, 0x60 }); ////Brewing Stand
                PS3.SetMemory(0x3241B134, new byte[] { 0x32, 0x1B, 0xF9, 0xB0 }); ////Cauldron
                PS3.SetMemory(0x3241AFE4, new byte[] { 0x32, 0x1B, 0xFC, 0x00 }); ////Tripwire
                PS3.SetMemory(0x3241AE94, new byte[] { 0x32, 0x1B, 0xFE, 0x50 }); ////Flower Pot
                PS3.SetMemory(0x3241AD44, new byte[] { 0x32, 0x1C, 0x00, 0xA0 }); ////Skull
                PS3.SetMemory(0x3241ABF4, new byte[] { 0x32, 0x1C, 0x84, 0xF0 }); ////Farm Land
                PS3.SetMemory(0x3241AAA4, new byte[] { 0x32, 0x1C, 0x89, 0x90 }); ////Furnace enabled
                PS3.SetMemory(0x3241A954, new byte[] { 0x32, 0x1D, 0x2B, 0x90 }); ////Dragon Eggs
                PS3.SetMemory(0x3241A804, new byte[] { 0x32, 0x1D, 0xA7, 0xA0 }); ////Frosted Ice
                PS3.SetMemory(0x3241A6B4, new byte[] { 0x32, 0x1D, 0xC0, 0x70 }); ////End Rod Reversed
                PS3.SetMemory(0x3241A564, new byte[] { 0x32, 0x1E, 0x8D, 0x20 }); ////Wood 1
                PS3.SetMemory(0x3241A414, new byte[] { 0x32, 0x1E, 0x8F, 0x70 }); ////Wood 2
                PS3.SetMemory(0x3241A2C4, new byte[] { 0x32, 0x1E, 0x91, 0xC0 }); ////Wood 3
                PS3.SetMemory(0x3241A174, new byte[] { 0x32, 0x1E, 0x94, 0x10 }); ////Wood 4
                PS3.SetMemory(0x3241A024, new byte[] { 0x32, 0x1E, 0x96, 0x60 }); ////Wood 5
                PS3.SetMemory(0x32419ED4, new byte[] { 0x32, 0x1E, 0x98, 0xB0 }); ////Wood 6
                PS3.SetMemory(0x32419D84, new byte[] { 0x32, 0x20, 0x8F, 0xF0 }); ////Arrow Of Splashing
                PS3.SetMemory(0x324199F4, new byte[] { 0x32, 0x1B, 0xC1, 0x60 }); ////Redstone lamp eanbled
                PS3.SetMemory(0x324198A4, new byte[] { 0x32, 0x1B, 0xDA, 0x60 }); ////Bed glitched
                PS3.SetMemory(0x32419754, new byte[] { 0x32, 0x1B, 0xDC, 0xB0 }); ////Piston
                PS3.SetMemory(0x32419604, new byte[] { 0x32, 0x1B, 0xDF, 0x00 }); ///Redstone dust
                PS3.SetMemory(0x324194B4, new byte[] { 0x32, 0x1F, 0xB4, 0xC0 }); ///Map opened
                PS3.SetMemory(0x32419364, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Spawn
                PS3.SetMemory(0x32419214, new byte[] { 0x32, 0x20, 0x0B, 0xE0 }); ///Book written
                PS3.SetMemory(0x324190C4, new byte[] { 0x32, 0x20, 0x32, 0x80 }); ////Enchanted Book
                PS3.SetMemory(0x32418F74, new byte[] { 0x32, 0x20, 0x64, 0x20 }); ////Command Block Minecrart
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x3241B6B4, new byte[] { 0x32, 0x1E, 0x58, 0x70 }); ////Water
                PS3.SetMemory(0x3241B7A4, new byte[] { 0x32, 0x1E, 0x5B, 0x30 }); ////Lava
                PS3.SetMemory(0x3241B894, new byte[] { 0x32, 0x1E, 0x5D, 0xA0 }); ////Command Block
                PS3.SetMemory(0x3241B984, new byte[] { 0x32, 0x1E, 0x60, 0x10 }); ////Repeating Command Block
                PS3.SetMemory(0x3241BA74, new byte[] { 0x32, 0x1E, 0x62, 0x80 }); ////Blue Command Block
                PS3.SetMemory(0x3241BB64, new byte[] { 0x32, 0x1E, 0x64, 0xF0 }); ////Barrier
                PS3.SetMemory(0x3241BC54, new byte[] { 0x32, 0x1E, 0x67, 0x60 }); ////Spectral Arrow
                PS3.SetMemory(0x3241BD44, new byte[] { 0x32, 0x1E, 0x69, 0xD0 }); //// Glitched Sign
                PS3.SetMemory(0x3241BE34, new byte[] { 0x32, 0x1E, 0x6C, 0x40 }); //// Redstone Comparator
                PS3.SetMemory(0x3241BF24, new byte[] { 0x32, 0x1E, 0x6E, 0xB0 }); //// Redstone repetor off
                PS3.SetMemory(0x3241C014, new byte[] { 0x32, 0x21, 0x03, 0x60 }); ////Redstone Repetor on
                PS3.SetMemory(0x3241C104, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Pumkin Stem
                PS3.SetMemory(0x3241B3D4, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Melon Stem
                PS3.SetMemory(0x3241B284, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Brewing Stand
                PS3.SetMemory(0x3241B134, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Cauldron
                PS3.SetMemory(0x3241AFE4, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Tripwire
                PS3.SetMemory(0x3241AE94, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Flower Pot
                PS3.SetMemory(0x3241AD44, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Skull
                PS3.SetMemory(0x3241ABF4, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Farm Land
                PS3.SetMemory(0x3241AAA4, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Furnace enabled
                PS3.SetMemory(0x3241A954, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Dragon Eggs
                PS3.SetMemory(0x3241A804, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Frosted Ice
                PS3.SetMemory(0x3241A6B4, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////End Rod Reversed
                PS3.SetMemory(0x3241A564, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Wood 1
                PS3.SetMemory(0x3241A414, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Wood 2
                PS3.SetMemory(0x3241A2C4, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Wood 3
                PS3.SetMemory(0x3241A174, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Wood 4
                PS3.SetMemory(0x3241A024, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Wood 5
                PS3.SetMemory(0x32419ED4, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Wood 6
                PS3.SetMemory(0x32419D84, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Arrow Of Splashing
                PS3.SetMemory(0x324199F4, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Redstone lamp eanbled
                PS3.SetMemory(0x324198A4, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Bed glitched
                PS3.SetMemory(0x32419754, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Piston
                PS3.SetMemory(0x32419604, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ///Redstone dust
                PS3.SetMemory(0x324194B4, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ///Map opened
                PS3.SetMemory(0x32419364, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Spawn
                PS3.SetMemory(0x32419214, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ///Book written
                PS3.SetMemory(0x324190C4, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Enchanted Book
                PS3.SetMemory(0x32418F74, new byte[] { 0x32, 0x20, 0x01, 0xC0 }); ////Command Block Minecrart
            }
        }

        public void GET_CRAFTING_IN_BATTLE_WORLD(bool toggle)
        {
            if (toggle)  ////Get Craft In Battle Map
            {
                PS3.SetMemory(0x00AED18F, new byte[] { 0x01 }); ////Craft In Lobby
                PS3.SetMemory(0x0098871F, new byte[] { 0x01 }); ////Infinite Craft
                PS3.SetMemory(0x007D75A3, new byte[] { 0x01 }); ////Place Blocks
                PS3.SetMemory(0x007D767C, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////Premissions Use Blocks
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AED18F, new byte[] { 0x00 }); ////Craft In Lobby
                PS3.SetMemory(0x0098871F, new byte[] { 0x00 }); ////Infinite Craft
                PS3.SetMemory(0x007D75A3, new byte[] { 0x01 }); ////Place Blocks
                PS3.SetMemory(0x007D767C, new byte[] { 0xF8, 0x21, 0xFF, 0x81 }); ////Premissions Use Blocks
            }
        }


        public void ENABLE_TAKE_EVERYTHING_IN_CHESTS(bool toggle)
        {
            if (toggle)  ////Enable Take Eveything In Chest
            {
                PS3.SetMemory(0x007D79D0, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x007D79D0, new byte[] { 0xF8, 0x21, 0xFF, 0x81 }); ////SET to default
            }
        }


        public void GOD_MODE_V3(bool toggle)
        {
            if (toggle)  //////God Mode V3
            {
                MessageBox.Show("You will take damage for are in god mode, don't move and wait !", "How to use ?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                PS3.SetMemory(0x014C93F0, new byte[] { 0x32, 0x1C, 0x0A, 0x60 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x014C93F0, new byte[] { 0x32, 0x20, 0xA4, 0xF0 }); ////MODIFED VALUE
            }
        }

        public async void BATTLE_WORLD_TELEPORT_TO_LOBBY()
        {
            MessageBox.Show("You will be teleported to Lobby World\n\nYou can place block and all players can see it. You can too save some items on a chest / ender chest and when the round start teleport to Lobby for take this and teleport back to the map. Do what you want with this :p\n\nYou will freeze 5/10/15 secondes, it's normal just wait and don't move.");

            PS3.SetMemory(0x00B01BAC, new byte[] { 0x41 }); ////Auto Jump
            PS3.SetMemory(0x00011ADC, new byte[] { 0x40 }); ////Jump In Sky
            PS3.SetMemory(0x0022790B, new byte[] { 0x14 }); ////Multi Jump

            await Task.Delay(1000);

            string coord = "-343,57,-341";
            string[] split = Regex.Split(coord, ",");
            setLocation(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));

            await Task.Delay(5000);

            PS3.SetMemory(0x00B01BAC, new byte[] { 0x40 }); ////Auto Jump
            PS3.SetMemory(0x00011ADC, new byte[] { 0x41 }); ////Jump In Sky
        }


        public async void BATTLE_WORLDS_TELEPORT_TO_CAVERN()
        {
            MessageBox.Show("You will be teleported back to the Cavern map, don't move and wait.");

            PS3.SetMemory(0x00B01BAC, new byte[] { 0x41 }); ////Auto Jump
            PS3.SetMemory(0x00011ADC, new byte[] { 0x40 }); ////Jump In Sky
            PS3.SetMemory(0x0022790B, new byte[] { 0x14 }); ////Multi Jump

            await Task.Delay(1000);

            string coord = "-222,66,287";
            string[] split = Regex.Split(coord, ",");
            setLocation(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));

            PS3.SetMemory(0x00B01BAC, new byte[] { 0x40 }); ////Auto Jump
            PS3.SetMemory(0x00011ADC, new byte[] { 0x41 }); ////Jump In Sky
        }

        public async void BATTLE_WORLDS_TELEPORT_TO_COVE()
        {
            MessageBox.Show("You will be teleported back to the Cove map, don't move and wait.");

            PS3.SetMemory(0x00B01BAC, new byte[] { 0x41 }); ////Auto Jump
            PS3.SetMemory(0x00011ADC, new byte[] { 0x40 }); ////Jump In Sky
            PS3.SetMemory(0x0022790B, new byte[] { 0x14 }); ////Multi Jump

            await Task.Delay(1000);

            string coord = "219,65,-220";
            string[] split = Regex.Split(coord, ",");
            setLocation(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));

            PS3.SetMemory(0x00B01BAC, new byte[] { 0x40 }); ////Auto Jump
            PS3.SetMemory(0x00011ADC, new byte[] { 0x41 }); ////Jump In Sky
        }

        public async void BATTLE_WORLD_TELEPORT_TO_CRUCIBLE()
        {
            MessageBox.Show("You will be teleported back to the Crucible map, don't move and wait.");

            PS3.SetMemory(0x00B01BAC, new byte[] { 0x41 }); ////Auto Jump
            PS3.SetMemory(0x00011ADC, new byte[] { 0x40 }); ////Jump In Sky
            PS3.SetMemory(0x0022790B, new byte[] { 0x14 }); ////Multi Jump

            await Task.Delay(1000);

            string coord = "317,76,301";
            string[] split = Regex.Split(coord, ",");
            setLocation(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));

            PS3.SetMemory(0x00B01BAC, new byte[] { 0x40 }); ////Auto Jump
            PS3.SetMemory(0x00011ADC, new byte[] { 0x41 }); ////Jump In Sky
        }



        public void CAN_SEE_REAL_SKINS_IN_SPECTATOR(bool toggle)
        {
            if (toggle)  //////Show Real Skins Spectator
            {
                PS3.SetMemory(0x007D86A0, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x007D86A0, new byte[] { 0xF8, 0x21, 0xFF, 0x81 }); ////MODIFED VALUE
            }
        }


        public void DISABLE_RESPAWN(bool toggle)
        {
            if (toggle)  ///////Lock Respawn
            {
                PS3.SetMemory(0x00AF1EE0, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AF1EE0, new byte[] { 0xF8, 0x21, 0xFD, 0x21 }); ////MODIFED VALUE
            }
        }

        public void GENEREATE_BUBBLE_IN_WATER(bool toggle)
        {
            if (toggle)  ///////Generate Bubble In Water
            {
                PS3.SetMemory(0x004A0A60, new byte[] { 0x38, 0x60, 0x00, 0x01 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x004A0A60, new byte[] { 0x38, 0x60, 0x00, 0x00 }); ////MODIFED VALUE
            }
        }

        public void ELYTRA_ON_ALL_ENTITY(bool toggle)
        {
            if (toggle)  ///////Elytra on all players
            {
                PS3.SetMemory(0x014C93D8, new byte[] { 0x32, 0x1C, 0x0A, 0x60 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x014C93D8, new byte[] { 0x32, 0x20, 0x94, 0x50 }); ////MODIFED VALUE
            }
        }

        public void MOVE_HEAD_BUT_NOT_BODY(bool toggle)
        {
            if (toggle)  ///////Move Head But Not Body
            {
                PS3.SetMemory(0x003AF338, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003AF338, new byte[] { 0xF8, 0x21, 0xFF, 0x71 }); ////MODIFED VALUE
            }
        }

        public void STOP_ANIMATIONS(bool toggle)
        {
            if (toggle)  ///////Stop Animations
            {
                PS3.SetMemory(0x003ACF00, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003ACF00, new byte[] { 0xF8, 0x21, 0xFF, 0x71 }); ////MODIFED VALUE
            }
        }

        public void STOP_WALK_ANIMATIONS(bool toggle)
        {
            if (toggle)  ///////Stop Animations
            {
                PS3.SetMemory(0x007D8B0C, new byte[] { 0x4F, 0x80, 0x00, 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x007D8B0C, new byte[] { 0x00, 0x00, 0x00, 0x00 }); ////MODIFED VALUE
            }
        }

        public void ALLOW_PORTAL_IN_MINI_GAMES(bool toggle)
        {
            if (toggle)  ///////Allow portal teleport in mini-games
            {
                PS3.SetMemory(0x007DC3BC, new byte[] { 0x38, 0x60, 0x00, 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x007DC3BC, new byte[] { 0x38, 0x60, 0x00, 0x01 }); ////MODIFED VALUE
            }
        }

        public void CREATIVE_SLOT_V2(bool toggle)
        {
            if (toggle)  ///////Creative Slot V2
            {
                PS3.SetMemory(0x00AACEDC, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AACEDC, new byte[] { 0xF8, 0x21, 0xFF, 0x71 }); ////MODIFED VALUE
            }
        }

        public void STARVED_ALL_PLAYERS_IN_BATTLE_WORLD(bool toggle)
        {
            if (toggle)  ///////Disable Run + Starved All Players
            {
                PS3.SetMemory(0x007D7AA0, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x007D7AA0, new byte[] { 0xF8, 0x21, 0xFF, 0x71 }); ////MODIFED VALUE
            }
        }

        public void OPTIMIZE_CHUNKS_LOAD(bool toggle)
        {
            if (toggle)  ///////Optimize Chunks Load
            {
                PS3.SetMemory(0x00B21C60, new byte[] { 0x40, 0xD7, 0x00, 0x00 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B21C60, new byte[] { 0x40, 0x30, 0x00, 0x00 }); ////MODIFED VALUE
            }
        }

        public void STOP_CHUNKS_LOAD(bool toggle)
        {
            if (toggle)  ///////Stop Chunks Load
            {
                PS3.SetMemory(0x00B2437C, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B2437C, new byte[] { 0xF8, 0x21, 0xFF, 0x71 }); ////MODIFED VALUE
            }
        }

        public void DISABLE_3RD_PERSON_VIEW(bool toggle)
        {
            if (toggle)  ///////Disable 3rd person view
            {
                PS3.SetMemory(0x00AFB458, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AFB458, new byte[] { 0xF8, 0x21, 0xFF, 0x11 }); ////MODIFED VALUE
            }
        }

        public void NETHER_PORTAL_WITH_DIRT(bool toggle)
        {
            if (toggle)  ////Nether Portal With Dirt
            {
                PS3.SetMemory(0x014C89FC, new byte[] { 0x32, 0x18, 0x14, 0x70 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x014C89FC, new byte[] { 0x32, 0x18, 0x5E, 0x70 }); ////SET to default
            }
        }

        public void TNT_CAN_DESTROY_BLOCKS_IN_MINI_GAMES(bool toggle)
        {
            if (toggle)  ////TNT Can Destroy Blocks In Mini-Games
            {
                PS3.SetMemory(0x007D8FB8, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x007D8FB8, new byte[] { 0xF8, 0x21, 0xFF, 0x81 }); ////SET to default
            }
        }


        public void SURVIVAL_IN_LOBBY(bool toggle)
        {
            if (toggle)  ////Change GameMode To Survival In Lobby
            {
                PS3.SetMemory(0x007D88C0, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x007D88C0, new byte[] { 0xF8, 0x21, 0xFF, 0x81 }); ////SET to default
            }
        }

        public void VELOCITY_SMALL(bool toggle)
        {
            if (toggle)  ////No Knoback PVP non host
            {
                PS3.SetMemory(0x002335C8, new byte[] { 0xD3, 0x23, 0x01, 0x30 }); ////No Kb PVP
                PS3.SetMemory(0x002335CC, new byte[] { 0xD8, 0x43, 0x01, 0x38 }); ////No Kb PVP
                PS3.SetMemory(0x002335D0, new byte[] { 0xD3, 0x63, 0x01, 0x40 }); ////No Kb PVP
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002335C8, new byte[] { 0xD8, 0x23, 0x01, 0x30 }); ////No Kb PVP
                PS3.SetMemory(0x002335CC, new byte[] { 0xD8, 0x43, 0x01, 0x38 }); ////No Kb PVP
                PS3.SetMemory(0x002335D0, new byte[] { 0xD8, 0x63, 0x01, 0x40 }); ////No Kb PVP
            }
        }

        public void VELOCITY_BIG(bool toggle)
        {
            if (toggle)  ////Big Knoback PVP non host
            {
                PS3.SetMemory(0x002335C8, new byte[] { 0xD9, 0x23, 0x01, 0x30 }); ////No Kb PVP
                PS3.SetMemory(0x002335CC, new byte[] { 0xD8, 0x43, 0x01, 0x38 }); ////No Kb PVP
                PS3.SetMemory(0x002335D0, new byte[] { 0xD9, 0x63, 0x01, 0x40 }); ////No Kb PVP
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002335C8, new byte[] { 0xD8, 0x23, 0x01, 0x30 }); ////No Kb PVP
                PS3.SetMemory(0x002335CC, new byte[] { 0xD8, 0x43, 0x01, 0x38 }); ////No Kb PVP
                PS3.SetMemory(0x002335D0, new byte[] { 0xD8, 0x63, 0x01, 0x40 }); ////No Kb PVP
            }
        }

        public void TNT_EXPLODE_RADIUS_SMALL(bool toggle)
        {
            if (toggle)  ////TNT Explose Radius V1
            {
                PS3.SetMemory(0x0051E0D0, new byte[] { 0x42, 0x80, 0x00, 0x00 }); ////MODIFIED VALUES
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0051E0D0, new byte[] { 0x40, 0x80, 0x00, 0x00 }); ////DEFAULT VALUES
            }
        }


        public void STOP_SHOW_LOGS_NOTIFS(bool toggle)
        {
            if (toggle)  ////Stop Show Logs Chat
            {
                PS3.SetMemory(0x00912D08, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFIED VALUES
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00912D08, new byte[] { 0xF8, 0x21, 0xFE, 0x51 }); ////DEFAULT VALUES
            }
        }

        public void ADD_FAKE_CLONE_CONTROLLER(bool toggle)
        {
            if (toggle)  ////Add Fake Clone (controller)
            {
                PS3.SetMemory(0x00AEFA74, new byte[] { 0x40 }); ////MODIFIED VALUES
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEFA74, new byte[] { 0x41 }); ////DEFAULT VALUES
            }
        }

        public void REAL_JUMP_ANIMATION(bool toggle)
        {
            if (toggle)  ////Jump Animation Real
            {
                PS3.SetMemory(0x014C6728, new byte[] { 0xBF }); ////MODIFIED VALUES
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x014C6728, new byte[] { 0x3F }); ////DEFAULT VALUES
            }
        }

        public void LAST_PLAYERS_JOINED_THE_WORLD()
        {
            LastPlayersJoinedPSN = PS3.Extension.ReadString(0x30F46AC4); //////Name Of Players
            LastPlayersRegion = PS3.Extension.ReadString(0x30F46AD8); //////Country Of Players
            LastPlayersAvatar = PS3.Extension.ReadString(0x30F46B80); //////Picture of players    
        }

        public void SCREEN_DEAD(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x003A7654, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A7654, new byte[] { 0x40 }); ////SET to default
            }
        }

        public void TEXT_CHANGER_PLAYING_ALONE(string text)
        {
            PS3.SetMemory(0x320E8410, Encoding.ASCII.GetBytes(fixText(text)));
        }

        public void TEXT_CHANGER_PLAYING_MULTI(string text)
        {
            PS3.SetMemory(0x320E89E0, Encoding.ASCII.GetBytes(fixText(text)));
        }

        public void TEXT_CHANGER_PLAYER_JOIN(string text)
        {
            PS3.SetMemory(0x30FAA197, Encoding.ASCII.GetBytes(fixText(text)));
        }
        public void TEXT_CHANGER_PLAYER_LEAVE(string text)
        {
            PS3.SetMemory(0x30FAA1D7, Encoding.ASCII.GetBytes(fixText(text)));
        }

        public void NAME_CHANGER(string text)
        {
            string PSN = PS3.Extension.ReadString(0x3000AD34); //////NAME SLOT OF MINECRAFT
            PS3.SetMemory(11466913, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes(text + "");
            PS3.SetMemory(11466913, bytes);


            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nName Changed, rejoin the world for see your new name!");

            string externalip = new WebClient().DownloadString("http://ipinfo.io/ip");
            string country = new WebClient().DownloadString("http://ipinfo.io/country");


        }

        public void NAME_CHANGER_GLITCHED(string text)
        {
            string PSN = PS3.Extension.ReadString(0x3000AD34); //////NAME SLOT OF MINECRAFT
            PS3.SetMemory(0x3000ABE4, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes(text);
            byte[] buffer1 = new byte[] { 0x20, 0xC2, 0xA7, 0x33 };

            PS3.SetMemory(0x3000ABE4, bytes); ////NAME
            PS3.SetMemory(0x3000ABF7, buffer1); ////GLITCH


            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nName Changed To Glitched, rejoin the world for see your new name!");

            string externalip = new WebClient().DownloadString("http://ipinfo.io/ip");
            string country = new WebClient().DownloadString("http://ipinfo.io/country");


        }

        public void NAME_CHANGER_COLORED(string text)
        {
            string PSN = PS3.Extension.ReadString(0x3000AD34); //////NAME SLOT OF MINECRAFT
            PS3.SetMemory(0x3000ABE4, new byte[] { 0xC2, 0xA7, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes(text + "");
            PS3.SetMemory(0x3000ABE6, bytes);

            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nName Changed To Colored, rejoin the world for see your new name!");

            string externalip = new WebClient().DownloadString("http://ipinfo.io/ip");
            string country = new WebClient().DownloadString("http://ipinfo.io/country");


        }

        public void NAME_CHANGER_LINE(string text)
        {
            string PSN = PS3.Extension.ReadString(0x3000AD34); //////NAME SLOT OF MINECRAFT
            PS3.SetMemory(0x3000ABE4, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes(text + "");
            PS3.SetMemory(0x3000ABE4, bytes);


            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nName Changed To Lines, rejoin the world for see your new name!");

            string externalip = new WebClient().DownloadString("http://ipinfo.io/ip");
            string country = new WebClient().DownloadString("http://ipinfo.io/country");


        }

        public void SPAWN_DRAGON_EGGS(bool toggle)
        {
            if (toggle)
            {
                MessageBox.Show("Eggs of Elder Guardian has been changed to the Ender Dragon eggs, you can spawn it with a Monster Spawner", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Question);
                PS3.SetMemory(0x32418D18, new byte[] { 0x30, 0x99, 0xE7, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0C }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x32418D18, new byte[] { 0x30, 0x99, 0xD3, 0xE0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E }); ////DEFAULT VALUE
            }
        }

        public void SPAWN_WHITER_EGGS(bool toogle)
        {
            if (toogle)
            {
                MessageBox.Show("Eggs of Shulker has been changed to the Wither eggs, you can spawn it with a Monster Spawner", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Question);
                PS3.SetMemory(0x32418A79, new byte[] { 0x77, 0x00, 0x69, 0x00, 0x74, 0x00, 0x68, 0x00, 0x65, 0x00, 0x72, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x06 }); ////MODIFED VALUE
            }
            else if (!toogle)
            {
                PS3.SetMemory(0x32418A79, new byte[] { 0x73, 0x00, 0x68, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x6B, 0x00, 0x65, 0x00, 0x72, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07 }); ////DEFAULT VALUE
            }
        }

        public void SPAWN_BUNNY_KILLER_EGGS(bool toogle)
        {
            if (toogle)
            {
                MessageBox.Show("Eggs of Shulker has been changed to the Bunny Killer eggs, you can spawn it with a Monster Spawner", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Question);
                PS3.SetMemory(0x32418A79, new byte[] { 0x77, 0x00, 0x69, 0x00, 0x74, 0x00, 0x68, 0x00, 0x65, 0x00, 0x72, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x06 }); ////MODIFED VALUE
            }
            else if (!toogle)
            {
                PS3.SetMemory(0x32418A79, new byte[] { 0x73, 0x00, 0x68, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x6B, 0x00, 0x65, 0x00, 0x72, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07 }); ////DEFAULT VALUE
            }
        }

        public void SPAWN_GIANT_EGGS(bool toogle)
        {
            if (toogle)
            {
                MessageBox.Show("Eggs of Shulker has been changed to the Giant Zombie eggs, you can spawn it with a Monster Spawner", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Question);
                PS3.SetMemory(0x32418A79, new byte[] { 0x67, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x05 }); ////MODIFED VALUE
            }
            else if (!toogle)
            {
                PS3.SetMemory(0x32418A79, new byte[] { 0x73, 0x00, 0x68, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x6B, 0x00, 0x65, 0x00, 0x72, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07 }); ////DEFAULT VALUE
            }
        }

        public void SPAWN_IRON_GOLEM_EGGS(bool toogle)
        {
            if (toogle)
            {
                MessageBox.Show("Eggs of Elder Guardian has been changed to the Iron Golem eggs, you can spawn it with a Monster Spawner", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Question);
                PS3.SetMemory(0x32418D18, new byte[] { 0x30, 0x99, 0xF6, 0xA0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E }); ////MODIFED VALUE
            }
            else if (!toogle)
            {
                PS3.SetMemory(0x32418D18, new byte[] { 0x30, 0x99, 0xD3, 0xE0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E }); ////DEFAULT VALUE
            }
        }

        public void SPAWN_SNOWBALL_EGGS(bool toogle)
        {
            if (toogle)
            {
                MessageBox.Show("Eggs of Elder Guardian has been changed to Snowball, you can spawn it with a Monster Spawner (YOU CAN FREEZE)", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Question);
                PS3.SetMemory(0x32418D18, new byte[] { 0x30, 0x9D, 0xA4, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08 }); ////MODIFED VALUE
            }
            else if (!toogle)
            {
                PS3.SetMemory(0x32418D18, new byte[] { 0x30, 0x99, 0xD3, 0xE0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E }); ////DEFAULT VALUE
            }
        }

        public void SPAWN_ARMOR_STAND_EGGS(bool toogle)
        {
            if (toogle)
            {
                MessageBox.Show("Eggs of Elder Guardian has been changed to Armor Stand, you can spawn it with a Monster Spawner (YOU CAN FREEZE)", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Question);
                PS3.SetMemory(0x32418D18, new byte[] { 0x30, 0x99, 0xE3, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0B }); ////MODIFED VALUE
            }
            else if (!toogle)
            {
                PS3.SetMemory(0x32418D18, new byte[] { 0x30, 0x99, 0xD3, 0xE0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E }); ////DEFAULT VALUE
            }
        }


        public void MAX_PLAYERS_FOR_SMALL_MAPS(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x007D7984, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x007D7984, new byte[] { 0xF8, 0x21, 0xFF, 0x81 }); ////DEFAULT VALUE
            }
        }

        public void CHANGE_OVERWORLD_DIMENSION(string values)
        {
            if (values == "0")
            {
                PS3.SetMemory(0x0151DBEC, new byte[] { 0x30, 0xDC, 0x40, 0x50 }); ////RESET
            }
            else if (values == "1")
            {
                PS3.SetMemory(0x0151DBEC, new byte[] { 0x30, 0xDC, 0x41, 0xD0 }); ////MODIFED VALUE
            }
            else if (values == "2")
            {
                PS3.SetMemory(0x0151DBEC, new byte[] { 0x30, 0xDC, 0x41, 0x90 }); ////MODIFED VALUE
            }
        }

        public void CHANGE_NETHER_DIMENSION(string values)
        {
            if (values == "0")
            {
                PS3.SetMemory(0x0151DBF0, new byte[] { 0x30, 0xDC, 0x41, 0x90 }); ////RESET
            }
            else if (values == "1")
            {
                PS3.SetMemory(0x0151DBF0, new byte[] { 0x30, 0xDC, 0x40, 0x50 }); ////MODIFED VALUE
            }
            else if (values == "2")
            {
                PS3.SetMemory(0x0151DBF0, new byte[] { 0x30, 0xDC, 0x41, 0xD0 }); ////MODIFED VALUE
            }
        }

        public void CHANGE_THE_END_DIMENSION(string values)
        {
            if (values == "0")
            {
                PS3.SetMemory(0x0151DBEC, new byte[] { 0x30, 0xDC, 0x41, 0xD0 }); ////RESET
            }
            else if (values == "1")
            {
                PS3.SetMemory(0x0151DBEC, new byte[] { 0x30, 0xDC, 0x40, 0x50 }); ////MODIFED VALUE
            }
            else if (values == "2")
            {
                PS3.SetMemory(0x0151DBEC, new byte[] { 0x30, 0xDC, 0x41, 0x90 }); ////MODIFED VALUE
            }
        }

        //Need fix it
        public void GET_YOUR_PING(bool toogle)
        {
            if (toogle)
            {
                byte[] data = PS3.Extension.ReadBytes(0x014CF38F, 1);
                string VALUES = BitConverter.ToString(data); //get the hex
                GetPingz = VALUES;

            }
            else if (!toogle)
            {

            }
        }

        public void START_SPRX(bool toogle)
        {
            if (toogle)
            {
                //using 4 slot for start the SPRX

            }
            else if (!toogle)
            {

            }
        }

        public void STOP_SPRX(bool toogle)
        {
            if (toogle)
            {

            }
            else if (!toogle)
            {

            }
        }

        public void REMOVE_EFFECT_OPTION(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x003B35CC, new byte[] { 0x38, 0x60, 0x00, 0x00 }); ////MODIFIED
            }
            else
            {
                PS3.SetMemory(0x003B35CC, new byte[] { 0x38, 0x60, 0x00, 0x01 }); ////RESET
            }
        }

        #endregion


        #region "Teleport Functions"

        public string getLocation()
        {
            string xyz = " ";
            for (int i = 0; i < 3; i++)
            {
                xyz += Math.Round(PS3.Extension.ReadDouble(PS3.Extension.ReadUInt32(PS3.Extension.ReadUInt32(PS3.Extension.ReadUInt32(0x014CF2E4) + 0x44) + 0x84) + 0x08 * (uint)i)).ToString() + ",";
            }
            return xyz;
        }

        public void setLocation(int x, int y, int z)
        {
            double[] xyz1 = { x, y, z };
            double[] xyz2 = { x + .6, y + 1.8, z + .6 };
            List<byte> xyzBytes = new List<byte>();
            for (int i = 0; i < 3; i++)
            {
                byte[] rev1 = BitConverter.GetBytes(xyz1[i]);
                Array.Reverse(rev1);
                xyzBytes.AddRange(rev1);
            }
            for (int i = 0; i < 3; i++)
            {
                byte[] rev2 = BitConverter.GetBytes(xyz2[i]);
                Array.Reverse(rev2);
                xyzBytes.AddRange(rev2);
            }
            PS3.SetMemory(PS3.Extension.ReadUInt32(PS3.Extension.ReadUInt32(PS3.Extension.ReadUInt32(0x014CF2E4) + 0x44) + 0x158), xyzBytes.ToArray());
        }

        public double[] playerPos() //Functions for PlayerPosition more better
        {
            uint memRegion = 0U; //0
            uint clientOrg = 256U; //100

            uint num = memRegion + PS3.Extension.ReadUInt32(PS3.Extension.ReadUInt32(0x014CF2E4) + 0x44) + clientOrg;
            int num2 = (int)PS3.Extension.ReadDouble(num);
            int num3 = (int)PS3.Extension.ReadDouble(num + 0x10);
            return new double[]
            {
                (double)((num2 > 0) ? num2 : (num2 - 1)),
                Math.Round(PS3.Extension.ReadDouble(num + 0x08)) + 1.0,
                (double)((num3 > 0) ? num3 : (num3 - 1))
            };
        }

        public void setLocation(int x, int y, int z, bool fallDamage)
        {
            double[] array = new double[]
            {
                (double)x,
                (double)y,
                (double)z
            };
            double[] array2 = new double[]
            {
                (double)x + 0.6,
                (double)y + 1.8,
                (double)z + 0.6
            };
            List<byte> list = new List<byte>();
            for (int i = 0; i < 3; i++)
            {
                byte[] bytes = BitConverter.GetBytes(array[i]);
                Array.Reverse(bytes);
                list.AddRange(bytes);
            }
            for (int i = 0; i < 3; i++)
            {
                byte[] bytes2 = BitConverter.GetBytes(array2[i]);
                Array.Reverse(bytes2);
                list.AddRange(bytes2);
            }
            bool flag = false;
            if (!fallDamage)
            {
                PS3.SetMemory(0x00227908, new byte[] { 0x41, 0x82, 0x00, 0x18 }); ////MODIFED VALUE
                {
                    flag = true;
                    PS3.SetMemory(0x00227908, new byte[] { 0x41, 0x82, 0x00, 0x28 }); ////MODIFED VALUE
                }
            }
            PS3.SetMemory(PS3.Extension.ReadUInt32(PS3.Extension.ReadUInt32(PS3.Extension.ReadUInt32(0x014CF2E4) + 68U) + 344U), list.ToArray());
            if (flag && !fallDamage)
            {
                Task.Delay(500).Wait();
                PS3.SetMemory(0x00227908, new byte[] { 0x41, 0x82, 0x00, 0x18 }); ////MODIFED VALUE
            }
        }

        public async void GOD_MODE_FOR_MYSELF()
        {
            int num = (int)this.playerPos()[1];

            MessageBox.Show("You need are on a surface for it's work.", "How to use ?", MessageBoxButtons.OK, MessageBoxIcon.Question);
            MessageBox.Show("You will take damage for are in god mode, don't move and wait !", "How to use ?", MessageBoxButtons.OK, MessageBoxIcon.Question);

            for (int i = 0; i < 3; i++)
            {
                PS3.SetMemory(0x004B1D7C, new byte[] { 0x4F, 0xFF }); ////GOD MODE MYSELF ON

                setLocation((int)this.playerPos()[0], 500, (int)this.playerPos()[2], true);
                Task.Delay(100).Wait();
                setLocation((int)this.playerPos()[0], num, (int)this.playerPos()[2], true);
                Task.Delay(100).Wait();
                num = (int)this.playerPos()[1];
                Task.Delay(100).Wait();
            }
            await Task.Delay(10000);
            PS3.SetMemory(0x004B1D7C, new byte[] { 0x00, 0x00 }); ////GOD MODE MYSELF OFF
        }

        #endregion


        #region "SWAPPER"

        #region "Swapper Effect Regeneration"

        public void CHANGING_EFFECT_REGENERATION(string toggle)
        {
            if (toggle == "0")
            {
                PS3.SetMemory(0x014C9B48, ModEffectsSPEED); //SPEED
            }
            else if (toggle == "1")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsSLOWNESS); //SLOWNESS
            }
            else if (toggle == "2")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsHASTE); //HASTE
            }
            else if (toggle == "3")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsMINING_FATIGUE); //MINING FATIGUE
            }
            else if (toggle == "4")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsSTRENGTH); //STRENGTH
            }
            else if (toggle == "5")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsINSTANT_HEALTH); //INSTANT HEALTH
            }
            else if (toggle == "6")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsINSTANT_DAMAGE); //INSTANT DAMAGE
            }
            else if (toggle == "7")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsJUMP_BOOST); //JUMP BOOST
            }
            else if (toggle == "8")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsNAUSEA); //NAUSEA
            }
            else if (toggle == "9")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsREGENERATION); //REGENERATION
            }
            else if (toggle == "10")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsRESISTANCE); //RESISTANCE
            }
            else if (toggle == "11")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsFIRE_RESISTANCE); //FIRE RESISTANCE
            }
            else if (toggle == "12")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsWATER_BREATHING); //WATER BREATHING
            }
            else if (toggle == "13")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsINVISIBILITY); //INVISIBLITY
            }
            else if (toggle == "14")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsBLINDNESS); //BLINDNESS
            }
            else if (toggle == "15")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsNIGHT_VISION); //NIGHT VISION
            }
            else if (toggle == "16")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsHUNGER); //HUNGER
            }
            else if (toggle == "17")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsWEAKNESS); //WEAKNESS
            }
            else if (toggle == "18")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsPOISON); //POISON
            }
            else if (toggle == "19")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsWITHER); //WITHER
            }
            else if (toggle == "20")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsHEALTH_BOOST); //HEALTH_BOOST
            }
            else if (toggle == "21")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsABSORPTION); //ABSORPTION
            }
            else if (toggle == "22")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsSATURATION); //SATURATION
            }
            else if (toggle == "23")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsGLOWING); //GLOWING
            }
            else if (toggle == "24")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsLEVITATION); //LEVIATION
            }
            else if (toggle == "25")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsLUCK); //LUCK
            }
            else if (toggle == "26")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsUNLUCK); //UNLUCK
            }
            else if (toggle == "27")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsCONDUIT_POWER); //CONDUIT POWER
            }
            else if (toggle == "28")
            {
                PS3.SetMemory(0x014C9B48, MobEffectsSLOW_FALLING); //SLOW FALLING
            }
            else if (toggle == "29")
            {
                MessageBox.Show("Change the regeneration effect to a another effect\n\nIf you eat a apple or use the totem of undying you will get the regeneration effect, so if you change this effec to a another you will get the new effect.", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        #endregion

        #region "Swapper Effect Regeneration Time"

        public void CHANGING_EFFECT_REGENERATION_TIME(string toggle)
        {
            if (toggle == "0")
            {
                PS3.SetMemory(0x003A55EC, MobEffectTimer1);
            }
            else if (toggle == "1")
            {
                PS3.SetMemory(0x003A55EC, MobEffectTimer2);
            }
            else if (toggle == "2")
            {
                PS3.SetMemory(0x003A55EC, MobEffectTimer3);
            }
            else if (toggle == "3")
            {
                PS3.SetMemory(0x003A55EC, MobEffectTimer4);
            }
            else if (toggle == "4")
            {
                PS3.SetMemory(0x003A55EC, MobEffectTimer5);
            }
            else if (toggle == "5")
            {
                PS3.SetMemory(0x003A55EC, MobEffectTimer6);
            }
            else if (toggle == "6")
            {
                PS3.SetMemory(0x003A55EC, MobEffectTimer7);
            }
            else if (toggle == "7")
            {
                PS3.SetMemory(0x003A55EC, MobEffectTimer8);
            }
            else if (toggle == "8")
            {
                MessageBox.Show("Change duration of the regeneration effect\nWorking only if you using the totem of undying select the duration you want, use the totem and you will get the duration on the regeneration effect. If you change the effect of regeneration to a another it's working too.", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        #endregion

        #region "Swapper Items"

        public void CHANGING_ITEMS_SWAPPER_OFFSET(string toggle)
        {
            if (toggle == "0")
            {
                Offset_Default_Items = 0x014C90CC; //APPLE
            }
            else if (toggle == "1")
            {
                Offset_Default_Items = 0x014C9124; //STICK
            }
            else if (toggle == "2")
            {
                Offset_Default_Items = 0x014C9140; //STRING
            }
            else if (toggle == "3")
            {
                Offset_Default_Items = 0x014C91D0; //SIGN
            }
            else if (toggle == "4")
            {
                Offset_Default_Items = 0x014C91F0; //BUCKET WATER
            }
            else if (toggle == "5")
            {
                Offset_Default_Items = 0x014C9340; //MAP
            }
            else if (toggle == "6")
            {
                Offset_Default_Items = 0x014C93F0; //TOTEM OF UNDYING
            }
            else if (toggle == "7")
            {
                Offset_Default_Items = 0x014C9298; //BEEF
            }
        }

        public void CHANGING_ITEMS_SWAPPER_VALUES(string toggle)
        {
            if (toggle == "0")
            {
                Items_Default_Items = Items_air; //AIR
            }
            else if (toggle == "1")
            {
                Items_Default_Items = Items_flint_and_steel; //FLINT AND STEEL
            }
            else if (toggle == "2")
            {
                Items_Default_Items = Items_string; //STRING
            }
            else if (toggle == "3")
            {
                Items_Default_Items = Items_bow; //BOW
            }
            else if (toggle == "4")
            {
                Items_Default_Items = Items_arrow; //ARROW
            }
            else if (toggle == "5")
            {
                Items_Default_Items = Items_spectral_arrow; //SPECTRAL ARROW
            }
            else if (toggle == "6")
            {
                Items_Default_Items = Items_tipped_arrow; //TIPPED ARROW
            }
            else if (toggle == "7")
            {
                Items_Default_Items = Items_diamond_shovel; //DIAMOND SHOVEL
            }
            else if (toggle == "8")
            {
                Items_Default_Items = Items_diamond_pickaxe; //DIAMOND PICKAXE
            }
            else if (toggle == "9")
            {
                Items_Default_Items = Items_diamond_axe; //DIAMOND AXE
            }
            else if (toggle == "10")
            {
                Items_Default_Items = Items_diamond_sword; //DIAMOND SWORD
            }
            else if (toggle == "11")
            {
                Items_Default_Items = Items_diamond_hoe; //DIAMOND HOE
            }
            else if (toggle == "12")
            {
                Items_Default_Items = Items_diamond; //DIAMOND
            }
            else if (toggle == "13")
            {
                Items_Default_Items = Items_coocked_porkchop; //Coocked Porkshop
            }
            else if (toggle == "14")
            {
                Items_Default_Items = Items_golden_apple; //Golden Apple
            }
            else if (toggle == "15")
            {
                Items_Default_Items = Items_air; //Air
            }
            else if (toggle == "16")
            {
                Items_Default_Items = Items_armor_stand; //Armor Stand
            }
            else if (toggle == "17")
            {
                Items_Default_Items = Items_banner; //Banner
            }
            else if (toggle == "18")
            {
                Items_Default_Items = Items_blazer_rood; //Blazer Rood
            }
            else if (toggle == "19")
            {
                Items_Default_Items = Items_bucket_lava; //Bucket Lava
            }
            else if (toggle == "20")
            {
                Items_Default_Items = Items_commande_block_minecraft; //Command Block
            }
            else if (toggle == "21")
            {
                Items_Default_Items = Items_cooked_beef; //Coocked Beef
            }
            else if (toggle == "22")
            {
                Items_Default_Items = Items_debug_four_items; //debug four items
            }
            else if (toggle == "23")
            {
                Items_Default_Items = Items_egg; //egg
            }
            else if (toggle == "24")
            {
                Items_Default_Items = Items_emerald; //Emerald
            }
            else if (toggle == "25")
            {
                Items_Default_Items = Items_enchanted_book; //Enchanted Book
            }
            else if (toggle == "26")
            {
                Items_Default_Items = Items_ender_perl; //Ender Perl
            }
            else if (toggle == "27")
            {
                Items_Default_Items = Items_end_crystal; //Ender Crytal
            }
            else if (toggle == "28")
            {
                Items_Default_Items = Items_experience_bottle; //Experience Bottle
            }
            else if (toggle == "29")
            {
                Items_Default_Items = Items_snowball; //Snowball
            }
            else if (toggle == "30")
            {
                Items_Default_Items = Items_spawn_egg; //Spawn egg
            }
            else if (toggle == "31")
            {
                Items_Default_Items = Items_tnt_minecraft; //tnt Minecraft
            }
            else if (toggle == "32")
            {
                Items_Default_Items = Items_totem_of_undying; //Totem Of undying
            }
            else if (toggle == "33")
            {
                Items_Default_Items = Items_trident; //trident
            }
            else if (toggle == "34")
            {
                Items_Default_Items = Items_writen_booke; //Writen Book
            }
        }

        #endregion

        #region "Swapper Blocks"

        public void CHANGING_BLOCKS_SWAPPER_OFFSET(string toggle)
        {
            if (toggle == "0")
            {
                Offset_Default_Blocks = 0x014C893C; //DIRT
            }
            else if (toggle == "1")
            {
                Offset_Default_Blocks = 0x014C8940; //COBBLESTONE
            }
            else if (toggle == "2")
            {
                Offset_Default_Blocks = 0x014C8950; //Flowing Water //0014C8954 WATER
            }
            else if (toggle == "3")
            {
                Offset_Default_Blocks = 0x014C8C84; //FROSTED ICE
            }
            else if (toggle == "4")
            {
                Offset_Default_Blocks = 0x014C894C; //BEDROCK
            }
            else if (toggle == "5")
            {
                Offset_Default_Blocks = 0x014C8930; //AIR
            }
            else if (toggle == "6")
            {
                Offset_Default_Blocks = 0x014C8A04; //FIRE
            }
            else if (toggle == "7")
            {
                Offset_Default_Blocks = 0x014C8A08; //MOB SPAWNNER
            }
        }

        public void CHANGING_BLOCKS_SWAPPER_VALUES(string toggle)
        {
            if (toggle == "0")
            {
                Blocks_Default_Blocks = Items_air; //AIR
            }
        }

        #endregion

        #endregion

    }
}

//Jumping entity = 0x003ABE20