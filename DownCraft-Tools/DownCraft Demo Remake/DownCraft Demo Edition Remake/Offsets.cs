using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PS3Lib;

namespace DownCraft_Demo_Edition_Remake
{
    public class Offsets
    {
        PS3API PS3 = new PS3API();
        Functions FUNCTIONS = new Functions();

        public string USERNAME;

        #region "Connect & Attach"
        public void CONNECT_TO_CONSOLE()
        {
            if (MessageBox.Show("Press 'YES' for CCAPI or press 'NO' for TMAPI", "DownCraft Demo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PS3.ChangeAPI(SelectAPI.ControlConsole);
            }
            else
            {
                PS3.ChangeAPI(SelectAPI.TargetManager);
            }

            try
            {
                if (PS3.ConnectTarget())
                {
                    MessageBox.Show("Connected to PS3 !", "DownCraft Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        if (PS3.AttachProcess())
                        {
                            MessageBox.Show("Attached to PS3 !", "DownCraft Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            USERNAME = PS3.Extension.ReadString(0x3000AD34); //////NAME SLOT OF MINECRAFT

                            Main form = (Main)Application.OpenForms["Main"];
                            form.siticoneLabel2.Text = USERNAME;
                            form.timer1.Start();

                            string[] AVATAR = { "https://pbs.twimg.com/media/Cw6mWuqWIAAQx_5.jpg", "https://imgcloud.pw/images/2019/06/19/yvumaobmgfeb376003c61ff3ba9d.jpg", "https://i.imgur.com/7PdJUhd.jpg", "https://i.imgur.com/kRzV4hu.png" };
                            string RandomAvatar = AVATAR[new Random().Next(0, AVATAR.Length)];

                            string[] Emojis = { "🍁", "🌲", "☄️", "⚡️", "❄️", "🔥", "🌪", "🌸", "🌹", "🍣", "🧃", "🌌", "💊", "💉", "🩸", "🔪", "🧸", "🎀", "❤️", "🔰", "🩹" };
                            string RandomEmojis = Emojis[new Random().Next(0, Emojis.Length)];

                            FUNCTIONS.SEND_WEBHOOK("https://discord.com/api/webhooks/718493810014814259/78JAlBdQrJ7CA0G19p99bQ8xte6zh-YYSkVuvHzCgGx1hV5AFfga5KrRnpAH4i0_qMy0", "DownCraft Demo Logs", RandomAvatar, "```" + RandomEmojis + " User: " + USERNAME + " is now connected to DownCraft Demo Edition. " + RandomEmojis + "```");

                            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Connected to DownCraft Demo !");
                        }
                        else
                        {
                            MessageBox.Show("DownCraft Not Attached To PS3 !", "DownCraft Demo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Unknow Error, Not Attached To PS3 !", "DownCraft Demo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Not Connected to PS3 !", "DownCraft Demo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unknow Error Not Connected to PS3 !", "DownCraft Demo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region "Disconnect To Console"
        public void DISCONNECT_TO_CONSOLE()
        {
            PS3.DisconnectTarget();
        }

        #endregion

        #region "Select API"

        public void SELECT_CCAPI()
        {
            PS3.ChangeAPI(SelectAPI.ControlConsole);
        }

        public void SELECT_TMAPI()
        {
            PS3.ChangeAPI(SelectAPI.TargetManager);
        }

        #endregion

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
                PS3.SetMemory(0x003A3FF0, new byte[] { 0x40, 0x80 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A3FF0, new byte[] { 0x3F, 0x00 });
            }
        }

        public void KNOCKBACK(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x003A4018, new byte[] { 0x40, 0x80 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A4018, new byte[] { 0x3E, 0xCC });
            }
        }
        public void ANTI_KNOCKBACK(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x003A4018, new byte[] { 0x00, 0x00 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003A4018, new byte[] { 0x3E, 0xCC });
            }
        }

        public void INFINITE_PICK_UP(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00224B13, new byte[] { 0x00 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00224B13, new byte[] { 0x01 });
            }
        }

        public void INFINITE_BLOCK(bool toggle)
        {
            if (toggle) 
            {
                PS3.SetMemory(0x0010673F, new byte[] { 0x00 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0010673F, new byte[] { 0x01 });
            }
        }

        public void ALL_PLAYERS_SET_IN_FIRE(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00225FA0, new byte[] { 0x40 }); 
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00225FA0, new byte[] { 0x41 });
            }
        }

        public void MAX_XP_LEVEL(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x004B0094, new byte[] { 0x7C, 0xA5, 0x10, 0x14 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x004B0094, new byte[] { 0x7C, 0xA5, 0x20, 0x14 });
            }
        }

        public void STOP_FALL_GRAVITY(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00246A2C, new byte[] { 0xFF }); 
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00246A2C, new byte[] { 0x3F });
            }
        }
        public void CREEPER_EXTREM_EXPLOSION(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x001CC7E0, new byte[] { 0x40, 0xFF });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x001CC7E0, new byte[] { 0x3F, 0x80 });
            }
        }

        public void ALL_PLAYERS_SUFFOCATE(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x0022FDC8, new byte[] { 0x4E, 0x80, 0x00, 0x20 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0022FDC8, new byte[] { 0xF8, 0x21, 0xFF, 0x11 });
            }
        }

        public void NEW_SUPER_SPEED(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x003AA999, new byte[] { 0x00 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003AA999, new byte[] { 0x68 });
            }
        }

        public void NIGHT_VISION(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00A9A6C8, new byte[] { 0x7F });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A9A6C8, new byte[] { 0x3F });
            }
        }

        public void CAN_FLY(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00B02378, new byte[] { 0x40 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B02378, new byte[] { 0x41 });
            }
        }

        public void TOGGLE_SPRINT(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00B01DEC, new byte[] { 0x40, 0x82 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B01DEC, new byte[] { 0x41, 0x82 });
            }
        }

        public void NO_COLISSION_BYPASS(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x002271B0, new byte[] { 0x40 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002271B0, new byte[] { 0x41 });
            }
        }

        public void WALL_HACK_V2(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00A98F50, new byte[] { 0x40 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A98F50, new byte[] { 0x3D });
            }
        }

        public void NO_SLOW_DOWN(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x003AFB60, new byte[] { 0x4F });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003AFB60, new byte[] { 0x3F });
            }
        }

        public void MULTI_JUMP(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x0022790B, new byte[] { 0x14 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0022790B, new byte[] { 0x18 });
            }
        }

        public void ESP_ENTITY_RED(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00AD5B60, new byte[] { 0x41 });
                PS3.SetMemory(0x00AD5A5C, new byte[] { 0x6F, 0xFF }); 
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD5B60, new byte[] { 0x40 });
                PS3.SetMemory(0x00AD5A5C, new byte[] { 0x3F, 0x80 });
            }
        }

        public void INSTANT_HIT(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00AEBED4, new byte[] { 0xFF });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AEBED4, new byte[] { 0x3E });
            }
        }

        public void INFINITE_CRAFT(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x0098871F, new byte[] { 0x01 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x0098871F, new byte[] { 0x00 });
            }
        }

        public void AUTO_JUMP(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00B01BAC, new byte[] { 0x41 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B01BAC, new byte[] { 0x40 });
            }
        }

        public void XRAY(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00A99154, new byte[] { 0xFC, 0x80, 0x30, 0x90 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A99154, new byte[] { 0xFC, 0x60, 0x30, 0x90 });
            }
        }

        public void BETTER_TIME(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00A9A6DC, new byte[] { 0x0F });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00A9A6DC, new byte[] { 0x3F });
            }
        }

        public void FOV_WITHOUT_HAND(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00987502, new byte[] { 0x68 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00987502, new byte[] { 0x08 });
            }
        }

        public void BEST_SKY(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00410738, new byte[] { 0x3F, 0x10 });
                PS3.SetMemory(0x0038C658, new byte[] { 0x7F });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00410738, new byte[] { 0x3F, 0x80 });
                PS3.SetMemory(0x0038C658, new byte[] { 0x3F });
            }
        }

        public void SMOKE_LOBBY(bool toggle)
        {
            if (toggle) 
            {
                PS3.SetMemory(0x00B24177, new byte[] { 0x01 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B24177, new byte[] { 0x00 });
            }
        }

        public void NAME_OVER_HEAD(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00AD8158, new byte[] { 0x4C });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AD8158, new byte[] { 0x2C });
            }
        }

        public void IDS_ITEMS(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x003097C8, new byte[] { 0x40 });
                PS3.SetMemory(0x003097B8, new byte[] { 0x40 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x003097C8, new byte[] { 0x41 });
                PS3.SetMemory(0x003097B8, new byte[] { 0x41 });
            }
        }

        public void TEXTURE_PLASTIC(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x30012913, new byte[] { 0x01 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x30012913, new byte[] { 0x07 });
            }
        }

        public void KILL_AURA(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00233290, new byte[] { 0xFF });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00233290, new byte[] { 0x00 });
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

        public void ROBLOX_ANIMATION(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x002341D0, new byte[] { 0xC3 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002341D0, new byte[] { 0xC0 });
            }
        }
        public void OPTIMIZE_CHUNKS_LOAD(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00B21C60, new byte[] { 0x40, 0xD7, 0x00, 0x00 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00B21C60, new byte[] { 0x40, 0x30, 0x00, 0x00 });
            }
        }

        public void CREATIVE_INVENTORY_IN_LOBBY(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00AED18F, new byte[] { 0x01 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00AED18F, new byte[] { 0x00 });
            }
        }

        public void FROST_WALKER(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00218A4F, new byte[] { 0x20 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00218A4F, new byte[] { 0x00 });
            }
        }

        public void GET_SPECTATOR_GAMEMODE(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x014C9048, new byte[] { 0x32, 0x3A, 0x84, 0xC0 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x014C9048, new byte[] { 0x32, 0x39, 0x4B, 0xD0 });
            }
        }

        public void DRIFT_BOAT(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x002278E4, new byte[] { 0x41 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x002278E4, new byte[] { 0x40 });
            }
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

        public void REAL_JUMP_ANIMATION(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x014C6728, new byte[] { 0xBF });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x014C6728, new byte[] { 0x3F });
            }
        }

        public void ALL_PLAYERS_FAST_SPEED(bool toggle)
        {
            if (toggle)
            {
                PS3.SetMemory(0x00018CE4, new byte[] { 0xFF, 0xE0, 0x00, 0x90 });
            }
            else if (!toggle)
            {
                PS3.SetMemory(0x00018CE4, new byte[] { 0xFF, 0xE0, 0x08, 0x90 });
            }
        }
    }
}
