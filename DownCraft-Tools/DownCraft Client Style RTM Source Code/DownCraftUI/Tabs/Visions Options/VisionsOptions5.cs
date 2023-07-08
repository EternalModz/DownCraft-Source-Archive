using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DownCraftUI.Classes;

namespace DownCraftUI.Tabs.Visions_Options
{
    public partial class VisionsOptions5 : Form
    {
        public static Point newpoint = new Point();
        public static int x;
        public static int y;
        Offsets OFFSETS = new Offsets();
        Functions FUNCS = new Functions();

        #region "System Move Title Panel"
        private void xMouseDown(object sender, MouseEventArgs e)
        {
            x = Control.MousePosition.X - base.Location.X;
            y = Control.MousePosition.Y - base.Location.Y;
        }
        private void xMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                newpoint = Control.MousePosition;
                newpoint.X -= x;
                newpoint.Y -= y;
                base.Location = newpoint;
            }
        }
        #endregion

        public VisionsOptions5()
        {
            InitializeComponent();
        }

        private void VisionsOptions5_Load(object sender, EventArgs e)
        {
            this.guna2GradientPanel1.MouseDown += this.xMouseDown;
            this.guna2GradientPanel1.MouseMove += this.xMouseMove;
            this.guna2GradientPanel1.MouseDown += this.xMouseDown;
            this.guna2GradientPanel1.MouseMove += this.xMouseMove;
            this.label1.MouseDown += this.xMouseDown;
            this.label1.MouseMove += this.xMouseMove;
            this.label1.MouseDown += this.xMouseDown;
            this.label1.MouseMove += this.xMouseMove;

            #region "Variables ON / OFF"

            if (Variables.SkyColorsValue == 0)
            {
                guna2ComboBox1.SelectedIndex = 0;
            }
            else if (Variables.SkyColorsValue == 1)
            {
                guna2ComboBox1.SelectedIndex = 1;
            }
            else if (Variables.SkyColorsValue == 2)
            {
                guna2ComboBox1.SelectedIndex = 2;
            }
            else if (Variables.SkyColorsValue == 3)
            {
                guna2ComboBox1.SelectedIndex = 3;
            }
            else if (Variables.SkyColorsValue == 4)
            {
                guna2ComboBox1.SelectedIndex = 4;
            }
            else if (Variables.SkyColorsValue == 5)
            {
                guna2ComboBox1.SelectedIndex = 5;
            }
            else if (Variables.SkyColorsValue == 6)
            {
                guna2ComboBox1.SelectedIndex = 6;
            }
            else if (Variables.SkyColorsValue == 7)
            {
                guna2ComboBox1.SelectedIndex = 7;
            }

            if (Variables.TimeCycleValue == 0)
            {
                guna2ComboBox2.SelectedIndex = 0;
            }
            else if (Variables.TimeCycleValue == 1)
            {
                guna2ComboBox2.SelectedIndex = 1;
            }
            else if (Variables.TimeCycleValue == 2)
            {
                guna2ComboBox2.SelectedIndex = 2;
            }
            else if (Variables.TimeCycleValue == 3)
            {
                guna2ComboBox2.SelectedIndex = 3;
            }
            else if (Variables.TimeCycleValue == 4)
            {
                guna2ComboBox2.SelectedIndex = 4;
            }
            else if (Variables.TimeCycleValue == 5)
            {
                guna2ComboBox2.SelectedIndex = 5;
            }
            else if (Variables.TimeCycleValue == 6)
            {
                guna2ComboBox2.SelectedIndex = 6;
            }
            else if (Variables.TimeCycleValue == 7)
            {
                guna2ComboBox2.SelectedIndex = 7;
            }
            else if (Variables.TimeCycleValue == 8)
            {
                guna2ComboBox2.SelectedIndex = 8;
            }
            else if (Variables.TimeCycleValue == 9)
            {
                guna2ComboBox2.SelectedIndex = 9;
            }
            else if (Variables.TimeCycleValue == 10)
            {
                guna2ComboBox2.SelectedIndex = 10;
            }

            if (Variables.ShadowEntityValue == 0)
            {
                guna2ComboBox3.SelectedIndex = 0;
            }
            else if (Variables.ShadowEntityValue == 1)
            {
                guna2ComboBox3.SelectedIndex = 1;
            }
            else if (Variables.ShadowEntityValue == 2)
            {
                guna2ComboBox3.SelectedIndex = 2;
            }
            else if (Variables.ShadowEntityValue == 3)
            {
                guna2ComboBox3.SelectedIndex = 3;
            }

            if (Variables.GameplayColorsValue == 0)
            {
                guna2ComboBox4.SelectedIndex = 0;
            }
            else if (Variables.GameplayColorsValue == 1)
            {
                guna2ComboBox4.SelectedIndex = 1;
            }
            else if (Variables.GameplayColorsValue == 2)
            {
                guna2ComboBox4.SelectedIndex = 2;
            }
            else if (Variables.GameplayColorsValue == 3)
            {
                guna2ComboBox4.SelectedIndex = 3;
            }
            else if (Variables.GameplayColorsValue == 4)
            {
                guna2ComboBox4.SelectedIndex = 4;
            }
            else if (Variables.GameplayColorsValue == 5)
            {
                guna2ComboBox4.SelectedIndex = 5;
            }
            else if (Variables.GameplayColorsValue == 6)
            {
                guna2ComboBox4.SelectedIndex = 6;
            }
            else if (Variables.GameplayColorsValue == 7)
            {
                guna2ComboBox4.SelectedIndex = 7;
            }
            else if (Variables.GameplayColorsValue == 8)
            {
                guna2ComboBox4.SelectedIndex = 8;
            }
            else if (Variables.GameplayColorsValue == 9)
            {
                guna2ComboBox4.SelectedIndex = 9;
            }
            else if (Variables.GameplayColorsValue == 10)
            {
                guna2ComboBox4.SelectedIndex = 10;
            }
            else if (Variables.GameplayColorsValue == 11)
            {
                guna2ComboBox4.SelectedIndex = 11;
            }
            else if (Variables.GameplayColorsValue == 12)
            {
                guna2ComboBox4.SelectedIndex = 12;
            }

            if (Variables.ItemsSizeValue == 0)
            {
                guna2ComboBox5.SelectedIndex = 0;
            }
            else if (Variables.ItemsSizeValue == 1)
            {
                guna2ComboBox5.SelectedIndex = 1;
            }
            else if (Variables.ItemsSizeValue == 2)
            {
                guna2ComboBox5.SelectedIndex = 2;
            }
            else if (Variables.ItemsSizeValue == 3)
            {
                guna2ComboBox5.SelectedIndex = 3;
            }
            else if (Variables.ItemsSizeValue == 4)
            {
                guna2ComboBox5.SelectedIndex = 4;
            }
            else if (Variables.ItemsSizeValue == 5)
            {
                guna2ComboBox5.SelectedIndex = 5;
            }
            else if (Variables.ItemsSizeValue == 6)
            {
                guna2ComboBox5.SelectedIndex = 6;
            }
            else if (Variables.ItemsSizeValue == 7)
            {
                guna2ComboBox5.SelectedIndex = 7;
            }

            if (Variables.HUDColorsValue == 0)
            {
                guna2ComboBox6.SelectedIndex = 0;
            }
            else if (Variables.HUDColorsValue == 1)
            {
                guna2ComboBox6.SelectedIndex = 1;
            }
            else if (Variables.HUDColorsValue == 2)
            {
                guna2ComboBox6.SelectedIndex = 2;
            }
            else if (Variables.HUDColorsValue == 3)
            {
                guna2ComboBox6.SelectedIndex = 3;
            }
            else if (Variables.HUDColorsValue == 4)
            {
                guna2ComboBox6.SelectedIndex = 4;
            }
            else if (Variables.HUDColorsValue == 5)
            {
                guna2ComboBox6.SelectedIndex = 5;
            }
            else if (Variables.HUDColorsValue == 6)
            {
                guna2ComboBox6.SelectedIndex = 6;
            }

            if (Variables.HandPositionValue == 0)
            {
                guna2ComboBox7.SelectedIndex = 0;
            }
            else if (Variables.HandPositionValue == 1)
            {
                guna2ComboBox7.SelectedIndex = 1;
            }
            else if (Variables.HandPositionValue == 2)
            {
                guna2ComboBox7.SelectedIndex = 2;
            }
            else if (Variables.HandPositionValue == 3)
            {
                guna2ComboBox7.SelectedIndex = 3;
            }
            else if (Variables.HandPositionValue == 4)
            {
                guna2ComboBox7.SelectedIndex = 4;
            }
            else if (Variables.HandPositionValue == 5)
            {
                guna2ComboBox7.SelectedIndex = 5;
            }
            else if (Variables.HandPositionValue == 6)
            {
                guna2ComboBox7.SelectedIndex = 6;
            }
            else if (Variables.HandPositionValue == 7)
            {
                guna2ComboBox7.SelectedIndex = 7;
            }

            if (Variables.FOVValue == 0)
            {
                guna2ComboBox8.SelectedIndex = 0;
            }
            else if (Variables.FOVValue == 1)
            {
                guna2ComboBox8.SelectedIndex = 1;
            }
            else if (Variables.FOVValue == 2)
            {
                guna2ComboBox8.SelectedIndex = 2;
            }
            else if (Variables.FOVValue == 3)
            {
                guna2ComboBox8.SelectedIndex = 3;
            }
            else if (Variables.FOVValue == 4)
            {
                guna2ComboBox8.SelectedIndex = 4;
            }
            else if (Variables.FOVValue == 5)
            {
                guna2ComboBox8.SelectedIndex = 5;
            }
            else if (Variables.FOVValue == 6)
            {
                guna2ComboBox8.SelectedIndex = 6;
            }
            else if (Variables.FOVValue == 7)
            {
                guna2ComboBox8.SelectedIndex = 7;
            }
            else if (Variables.FOVValue == 8)
            {
                guna2ComboBox8.SelectedIndex = 8;
            }
            else if (Variables.FOVValue == 9)
            {
                guna2ComboBox8.SelectedIndex = 9;
            }
            else if (Variables.FOVValue == 10)
            {
                guna2ComboBox8.SelectedIndex = 10;
            }
            else if (Variables.FOVValue == 11)
            {
                guna2ComboBox8.SelectedIndex = 11;
            }

            if (Variables.HudNewColorsValue == 0)
            {
                guna2ComboBox9.SelectedIndex = 0;
            }
            else if (Variables.HudNewColorsValue == 1)
            {
                guna2ComboBox9.SelectedIndex = 1;
            }
            else if (Variables.HudNewColorsValue == 2)
            {
                guna2ComboBox9.SelectedIndex = 2;
            }
            else if (Variables.HudNewColorsValue == 3)
            {
                guna2ComboBox9.SelectedIndex = 3;
            }
            else if (Variables.HudNewColorsValue == 4)
            {
                guna2ComboBox9.SelectedIndex = 4;
            }
            else if (Variables.HudNewColorsValue == 5)
            {
                guna2ComboBox9.SelectedIndex = 5;
            }
            else if (Variables.HudNewColorsValue == 6)
            {
                guna2ComboBox9.SelectedIndex = 6;
            }
            else if (Variables.HudNewColorsValue == 7)
            {
                guna2ComboBox9.SelectedIndex = 7;
            }
            else if (Variables.HudNewColorsValue == 8)
            {
                guna2ComboBox9.SelectedIndex = 8;
            }
            else if (Variables.HudNewColorsValue == 9)
            {
                guna2ComboBox9.SelectedIndex = 9;
            }

            if (Variables.WeatherStateValue == 0)
            {
                guna2ComboBox10.SelectedIndex = 0;
            }
            else if (Variables.WeatherStateValue == 1)
            {
                guna2ComboBox10.SelectedIndex = 1;
            }
            else if (Variables.WeatherStateValue == 2)
            {
                guna2ComboBox10.SelectedIndex = 2;
            }
            else if (Variables.WeatherStateValue == 3)
            {
                guna2ComboBox10.SelectedIndex = 3;
            }
            else if (Variables.WeatherStateValue == 4)
            {
                guna2ComboBox10.SelectedIndex = 4;
            }
            else if (Variables.WeatherStateValue == 5)
            {
                guna2ComboBox10.SelectedIndex = 5;
            }
            else if (Variables.WeatherStateValue == 6)
            {
                guna2ComboBox10.SelectedIndex = 6;
            }
            else if (Variables.WeatherStateValue == 7)
            {
                guna2ComboBox10.SelectedIndex = 7;
            }
            else if (Variables.WeatherStateValue == 8)
            {
                guna2ComboBox10.SelectedIndex = 8;
            }
            else if (Variables.WeatherStateValue == 9)
            {
                guna2ComboBox10.SelectedIndex = 9;
            }

            if (Variables.IndicatorDamageColorsValue == 0)
            {
                guna2ComboBox11.SelectedIndex = 0;
            }
            else if (Variables.IndicatorDamageColorsValue == 1)
            {
                guna2ComboBox11.SelectedIndex = 1;
            }
            else if (Variables.IndicatorDamageColorsValue == 2)
            {
                guna2ComboBox11.SelectedIndex = 2;
            }
            else if (Variables.IndicatorDamageColorsValue == 3)
            {
                guna2ComboBox11.SelectedIndex = 3;
            }

            if (Variables.EntityFunnyVisionValue == 0)
            {
                guna2ComboBox12.SelectedIndex = 0;
            }
            else if (Variables.EntityFunnyVisionValue == 1)
            {
                guna2ComboBox12.SelectedIndex = 1;
            }
            else if (Variables.EntityFunnyVisionValue == 2)
            {
                guna2ComboBox12.SelectedIndex = 2;
            }
            else if (Variables.EntityFunnyVisionValue == 3)
            {
                guna2ComboBox12.SelectedIndex = 3;
            }
            else if (Variables.EntityFunnyVisionValue == 4)
            {
                guna2ComboBox12.SelectedIndex = 4;
            }
            else if (Variables.EntityFunnyVisionValue == 5)
            {
                guna2ComboBox12.SelectedIndex = 5;
            }
            else if (Variables.EntityFunnyVisionValue == 6)
            {
                guna2ComboBox12.SelectedIndex = 6;
            }
            else if (Variables.EntityFunnyVisionValue == 7)
            {
                guna2ComboBox12.SelectedIndex = 7;
            }

            if (Variables.EntityFunnyVisualValue == 0)
            {
                guna2ComboBox13.SelectedIndex = 0;
            }
            else if (Variables.EntityFunnyVisualValue == 1)
            {
                guna2ComboBox13.SelectedIndex = 1;
            }
            else if (Variables.EntityFunnyVisualValue == 2)
            {
                guna2ComboBox13.SelectedIndex = 2;
            }
            else if (Variables.EntityFunnyVisualValue == 3)
            {
                guna2ComboBox13.SelectedIndex = 3;
            }
            else if (Variables.EntityFunnyVisualValue == 4)
            {
                guna2ComboBox13.SelectedIndex = 4;
            }
            else if (Variables.EntityFunnyVisualValue == 5)
            {
                guna2ComboBox13.SelectedIndex = 5;
            }
            else if (Variables.EntityFunnyVisualValue == 6)
            {
                guna2ComboBox13.SelectedIndex = 6;
            }

            if (Variables.FPSValue == 0)
            {
                guna2ComboBox14.SelectedIndex = 0;
            }
            else if (Variables.FPSValue == 1)
            {
                guna2ComboBox14.SelectedIndex = 1;
            }
            else if (Variables.FPSValue == 2)
            {
                guna2ComboBox14.SelectedIndex = 2;
            }
            else if (Variables.FPSValue == 3)
            {
                guna2ComboBox14.SelectedIndex = 3;
            }
            else if (Variables.FPSValue == 4)
            {
                guna2ComboBox14.SelectedIndex = 4;
            }
            else if (Variables.FPSValue == 5)
            {
                guna2ComboBox14.SelectedIndex = 5;
            }
            else if (Variables.FPSValue == 6)
            {
                guna2ComboBox14.SelectedIndex = 6;
            }
            else if (Variables.FPSValue == 7)
            {
                guna2ComboBox14.SelectedIndex = 7;
            }
            else if (Variables.FPSValue == 8)
            {
                guna2ComboBox14.SelectedIndex = 8;
            }
            else if (Variables.FPSValue == 9)
            {
                guna2ComboBox14.SelectedIndex = 9;
            }
            else if (Variables.FPSValue == 10)
            {
                guna2ComboBox14.SelectedIndex = 10;
            }
            else if (Variables.FPSValue == 11)
            {
                guna2ComboBox14.SelectedIndex = 11;
            }
            else if (Variables.FPSValue == 12)
            {
                guna2ComboBox14.SelectedIndex = 12;
            }
            else if (Variables.FPSValue == 13)
            {
                guna2ComboBox14.SelectedIndex = 13;
            }
            else if (Variables.FPSValue == 14)
            {
                guna2ComboBox14.SelectedIndex = 14;
            }
            else if (Variables.FPSValue == 15)
            {
                guna2ComboBox14.SelectedIndex = 15;
            }

            if (Variables.CloudColorsValue == 0)
            {
                guna2ComboBox15.SelectedIndex = 0;
            }
            else if (Variables.CloudColorsValue == 1)
            {
                guna2ComboBox15.SelectedIndex = 1;
            }
            else if (Variables.CloudColorsValue == 2)
            {
                guna2ComboBox15.SelectedIndex = 2;
            }
            else if (Variables.CloudColorsValue == 3)
            {
                guna2ComboBox15.SelectedIndex = 3;
            }
            else if (Variables.CloudColorsValue == 4)
            {
                guna2ComboBox15.SelectedIndex = 4;
            }
            else if (Variables.CloudColorsValue == 5)
            {
                guna2ComboBox15.SelectedIndex = 5;
            }
            else if (Variables.CloudColorsValue == 6)
            {
                guna2ComboBox15.SelectedIndex = 6;
            }
            else if (Variables.CloudColorsValue == 7)
            {
                guna2ComboBox15.SelectedIndex = 7;
            }
            else if (Variables.CloudColorsValue == 8)
            {
                guna2ComboBox15.SelectedIndex = 8;
            }

            if (Variables.TimeSpeedValue == 0)
            {
                guna2ComboBox16.SelectedIndex = 0;
            }
            else if (Variables.TimeSpeedValue == 1)
            {
                guna2ComboBox16.SelectedIndex = 1;
            }
            else if (Variables.TimeSpeedValue == 2)
            {
                guna2ComboBox16.SelectedIndex = 2;
            }
            else if (Variables.TimeSpeedValue == 3)
            {
                guna2ComboBox16.SelectedIndex = 3;
            }
            else if (Variables.TimeSpeedValue == 4)
            {
                guna2ComboBox16.SelectedIndex = 4;
            }
            else if (Variables.TimeSpeedValue == 5)
            {
                guna2ComboBox16.SelectedIndex = 5;
            }
            else if (Variables.TimeSpeedValue == 6)
            {
                guna2ComboBox16.SelectedIndex = 6;
            }
            else if (Variables.TimeSpeedValue == 7)
            {
                guna2ComboBox16.SelectedIndex = 7;
            }
            else if (Variables.TimeSpeedValue == 8)
            {
                guna2ComboBox16.SelectedIndex = 8;
            }
            else if (Variables.TimeSpeedValue == 9)
            {
                guna2ComboBox16.SelectedIndex = 9;
            }
            else if (Variables.TimeSpeedValue == 10)
            {
                guna2ComboBox16.SelectedIndex = 10;
            }

            #endregion
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex == 0)
            {
                OFFSETS.SKY_COLORS("0");
                Variables.SkyColorsValue = 0;
            }
            else if (guna2ComboBox1.SelectedIndex == 1)
            {
                OFFSETS.SKY_COLORS("1");
                Variables.SkyColorsValue = 1;
            }
            else if (guna2ComboBox1.SelectedIndex == 2)
            {
                OFFSETS.SKY_COLORS("2");
                Variables.SkyColorsValue = 2;
            }
            else if (guna2ComboBox1.SelectedIndex == 3)
            {
                OFFSETS.SKY_COLORS("3");
                Variables.SkyColorsValue = 3;
            }
            else if (guna2ComboBox1.SelectedIndex == 4)
            {
                OFFSETS.SKY_COLORS("4");
                Variables.SkyColorsValue = 4;
            }
            else if (guna2ComboBox1.SelectedIndex == 5)
            {
                OFFSETS.SKY_COLORS("5");
                Variables.SkyColorsValue = 5;
            }
            else if (guna2ComboBox1.SelectedIndex == 6)
            {
                OFFSETS.SKY_COLORS("6");
                Variables.SkyColorsValue = 6;
            }
            else if (guna2ComboBox1.SelectedIndex == 7)
            {
                OFFSETS.SKY_COLORS("7");
                Variables.SkyColorsValue = 7;
            }
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox2.SelectedIndex == 0)
            {
                OFFSETS.TIMECYCLE_V2("0");
                Variables.TimeCycleValue = 0;
            }
            else if (guna2ComboBox2.SelectedIndex == 1)
            {
                OFFSETS.TIMECYCLE_V2("1");
                Variables.TimeCycleValue = 1;
            }
            else if (guna2ComboBox2.SelectedIndex == 2)
            {
                OFFSETS.TIMECYCLE_V2("2");
                Variables.TimeCycleValue = 2;
            }
            else if (guna2ComboBox2.SelectedIndex == 3)
            {
                OFFSETS.TIMECYCLE_V2("3");
                Variables.TimeCycleValue = 3;
            }
            else if (guna2ComboBox2.SelectedIndex == 4)
            {
                OFFSETS.TIMECYCLE_V2("4");
                Variables.TimeCycleValue = 4;
            }
            else if (guna2ComboBox2.SelectedIndex == 5)
            {
                OFFSETS.TIMECYCLE_V2("5");
                Variables.TimeCycleValue = 5;
            }
            else if (guna2ComboBox2.SelectedIndex == 6)
            {
                OFFSETS.TIMECYCLE_V2("6");
                Variables.TimeCycleValue = 6;
            }
            else if (guna2ComboBox2.SelectedIndex == 7)
            {
                OFFSETS.TIMECYCLE_V2("7");
                Variables.TimeCycleValue = 7;
            }
            else if (guna2ComboBox2.SelectedIndex == 8)
            {
                OFFSETS.TIMECYCLE_V2("8");
                Variables.TimeCycleValue = 8;
            }
            else if (guna2ComboBox2.SelectedIndex == 9)
            {
                OFFSETS.TIMECYCLE_V2("9");
                Variables.TimeCycleValue = 9;
            }
            else if (guna2ComboBox2.SelectedIndex == 10)
            {
                OFFSETS.TIMECYCLE_V2("10");
                Variables.TimeCycleValue = 10;
            }
        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox3.SelectedIndex == 0)
            {
                OFFSETS.REMOVE_SHADOW_ENTITY("0");
                Variables.ShadowEntityValue = 0;
            }
            else if (guna2ComboBox3.SelectedIndex == 1)
            {
                OFFSETS.REMOVE_SHADOW_ENTITY("1");
                Variables.ShadowEntityValue = 1;
            }
            else if (guna2ComboBox3.SelectedIndex == 2)
            {
                OFFSETS.REMOVE_SHADOW_ENTITY("2");
                Variables.ShadowEntityValue = 2;
            }
            else if (guna2ComboBox3.SelectedIndex == 3)
            {
                OFFSETS.REMOVE_SHADOW_ENTITY("3");
                Variables.ShadowEntityValue = 3;
            }
        }

        private void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox4.SelectedIndex == 0)
            {
                OFFSETS.GAMEPLAY_COLORS("0");
                Variables.GameplayColorsValue = 0;
            }
            else if (guna2ComboBox4.SelectedIndex == 1)
            {
                OFFSETS.GAMEPLAY_COLORS("1");
                Variables.GameplayColorsValue = 1;
            }
            else if (guna2ComboBox4.SelectedIndex == 2)
            {
                OFFSETS.GAMEPLAY_COLORS("2");
                Variables.GameplayColorsValue = 2;
            }
            else if (guna2ComboBox4.SelectedIndex == 3)
            {
                OFFSETS.GAMEPLAY_COLORS("3");
                Variables.GameplayColorsValue = 3;
            }
            else if (guna2ComboBox4.SelectedIndex == 4)
            {
                OFFSETS.GAMEPLAY_COLORS("4");
                Variables.GameplayColorsValue = 4;
            }
            else if (guna2ComboBox4.SelectedIndex == 5)
            {
                OFFSETS.GAMEPLAY_COLORS("5");
                Variables.GameplayColorsValue = 5;
            }
            else if (guna2ComboBox4.SelectedIndex == 6)
            {
                OFFSETS.GAMEPLAY_COLORS("6");
                Variables.GameplayColorsValue = 6;
            }
            else if (guna2ComboBox4.SelectedIndex == 7)
            {
                OFFSETS.GAMEPLAY_COLORS("7");
                Variables.GameplayColorsValue = 7;
            }
            else if (guna2ComboBox4.SelectedIndex == 8)
            {
                OFFSETS.GAMEPLAY_COLORS("8");
                Variables.GameplayColorsValue = 8;
            }
            else if (guna2ComboBox4.SelectedIndex == 9)
            {
                OFFSETS.GAMEPLAY_COLORS("9");
                Variables.GameplayColorsValue = 9;
            }
            else if (guna2ComboBox4.SelectedIndex == 10)
            {
                OFFSETS.GAMEPLAY_COLORS("10");
                Variables.GameplayColorsValue = 10;
            }
            else if (guna2ComboBox4.SelectedIndex == 11)
            {
                OFFSETS.GAMEPLAY_COLORS("11");
                Variables.GameplayColorsValue = 11;
            }
            else if (guna2ComboBox4.SelectedIndex == 12)
            {
                OFFSETS.GAMEPLAY_COLORS("12");
                Variables.GameplayColorsValue = 12;
            }
        }

        private void guna2ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox5.SelectedIndex == 0)
            {
                OFFSETS.ITEMS_SIZE("0");
                Variables.ItemsSizeValue = 0;
            }
            else if (guna2ComboBox5.SelectedIndex == 1)
            {
                OFFSETS.ITEMS_SIZE("1");
                Variables.ItemsSizeValue = 1;
            }
            else if (guna2ComboBox5.SelectedIndex == 2)
            {
                OFFSETS.ITEMS_SIZE("2");
                Variables.ItemsSizeValue = 2;
            }
            else if (guna2ComboBox5.SelectedIndex == 3)
            {
                OFFSETS.ITEMS_SIZE("3");
                Variables.ItemsSizeValue = 3;
            }
            else if (guna2ComboBox5.SelectedIndex == 4)
            {
                OFFSETS.ITEMS_SIZE("4");
                Variables.ItemsSizeValue = 4;
            }
            else if (guna2ComboBox5.SelectedIndex == 5)
            {
                OFFSETS.ITEMS_SIZE("5");
                Variables.ItemsSizeValue = 5;
            }
            else if (guna2ComboBox5.SelectedIndex == 6)
            {
                OFFSETS.ITEMS_SIZE("6");
                Variables.ItemsSizeValue = 6;
            }
            else if (guna2ComboBox5.SelectedIndex == 7)
            {
                OFFSETS.ITEMS_SIZE("7");
                Variables.ItemsSizeValue = 7;
            }
        }

        private void guna2ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox6.SelectedIndex == 0)
            {
                OFFSETS.HUD_COLORS("0");
                Variables.HUDColorsValue = 0;
            }
            else if (guna2ComboBox6.SelectedIndex == 1)
            {
                OFFSETS.HUD_COLORS("1");
                Variables.HUDColorsValue = 1;
            }
            else if (guna2ComboBox6.SelectedIndex == 2)
            {
                OFFSETS.HUD_COLORS("2");
                Variables.HUDColorsValue = 2;
            }
            else if (guna2ComboBox6.SelectedIndex == 3)
            {
                OFFSETS.HUD_COLORS("3");
                Variables.HUDColorsValue = 3;
            }
            else if (guna2ComboBox6.SelectedIndex == 4)
            {
                OFFSETS.HUD_COLORS("4");
                Variables.HUDColorsValue = 4;
            }
            else if (guna2ComboBox6.SelectedIndex == 5)
            {
                OFFSETS.HUD_COLORS("5");
                Variables.HUDColorsValue = 5;
            }
            else if (guna2ComboBox6.SelectedIndex == 6)
            {
                OFFSETS.HUD_COLORS("6");
                Variables.HUDColorsValue = 6;
            }
        }

        private void guna2ComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox7.SelectedIndex == 0)
            {
                OFFSETS.HAND_POSITION("0");
                Variables.HandPositionValue = 0;
            }
            else if (guna2ComboBox7.SelectedIndex == 1)
            {
                OFFSETS.HAND_POSITION("1");
                Variables.HandPositionValue = 1;
            }
            else if (guna2ComboBox7.SelectedIndex == 2)
            {
                OFFSETS.HAND_POSITION("2");
                Variables.HandPositionValue = 2;
            }
            else if (guna2ComboBox7.SelectedIndex == 3)
            {
                OFFSETS.HAND_POSITION("3");
                Variables.HandPositionValue = 3;
            }
            else if (guna2ComboBox7.SelectedIndex == 4)
            {
                OFFSETS.HAND_POSITION("4");
                Variables.HandPositionValue = 4;
            }
            else if (guna2ComboBox7.SelectedIndex == 5)
            {
                OFFSETS.HAND_POSITION("5");
                Variables.HandPositionValue = 5;
            }
            else if (guna2ComboBox7.SelectedIndex == 6)
            {
                OFFSETS.HAND_POSITION("6");
                Variables.HandPositionValue = 6;
            }
        }

        private void guna2ComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox8.SelectedIndex == 0)
            {
                OFFSETS.FOV_VALUE("0");
                Variables.FOVValue = 0;
            }
            else if (guna2ComboBox8.SelectedIndex == 1)
            {
                OFFSETS.FOV_VALUE("1");
                Variables.FOVValue = 1;
            }
            else if (guna2ComboBox8.SelectedIndex == 2)
            {
                OFFSETS.FOV_VALUE("2");
                Variables.FOVValue = 2;
            }
            else if (guna2ComboBox8.SelectedIndex == 3)
            {
                OFFSETS.FOV_VALUE("3");
                Variables.FOVValue = 3;
            }
            else if (guna2ComboBox8.SelectedIndex == 4)
            {
                OFFSETS.FOV_VALUE("4");
                Variables.FOVValue = 4;
            }
            else if (guna2ComboBox8.SelectedIndex == 5)
            {
                OFFSETS.FOV_VALUE("5");
                Variables.FOVValue = 5;
            }
            else if (guna2ComboBox8.SelectedIndex == 6)
            {
                OFFSETS.FOV_VALUE("6");
                Variables.FOVValue = 6;
            }
            else if (guna2ComboBox8.SelectedIndex == 7)
            {
                OFFSETS.FOV_VALUE("7");
                Variables.FOVValue = 7;
            }
            else if (guna2ComboBox8.SelectedIndex == 8)
            {
                OFFSETS.FOV_VALUE("8");
                Variables.FOVValue = 8;
            }
            else if (guna2ComboBox8.SelectedIndex == 9)
            {
                OFFSETS.FOV_VALUE("9");
                Variables.FOVValue = 9;
            }
            else if (guna2ComboBox8.SelectedIndex == 10)
            {
                OFFSETS.FOV_VALUE("10");
                Variables.FOVValue = 10;
            }
            else if (guna2ComboBox8.SelectedIndex == 11)
            {
                OFFSETS.FOV_VALUE("11");
                Variables.FOVValue = 11;
            }
        }

        private void guna2ComboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox9.SelectedIndex == 0)
            {
                OFFSETS.HUD_NEW_COLORS("0");
                Variables.HudNewColorsValue = 0;
            }
            else if (guna2ComboBox9.SelectedIndex == 1)
            {
                OFFSETS.HUD_NEW_COLORS("1");
                Variables.HudNewColorsValue = 1;
            }
            else if (guna2ComboBox9.SelectedIndex == 2)
            {
                OFFSETS.HUD_NEW_COLORS("2");
                Variables.HudNewColorsValue = 2;
            }
            else if (guna2ComboBox9.SelectedIndex == 3)
            {
                OFFSETS.HUD_NEW_COLORS("3");
                Variables.HudNewColorsValue = 3;
            }
            else if (guna2ComboBox9.SelectedIndex == 4)
            {
                OFFSETS.HUD_NEW_COLORS("4");
                Variables.HudNewColorsValue = 4;
            }
            else if (guna2ComboBox9.SelectedIndex == 5)
            {
                OFFSETS.HUD_NEW_COLORS("5");
                Variables.HudNewColorsValue = 5;
            }
            else if (guna2ComboBox9.SelectedIndex == 6)
            {
                OFFSETS.HUD_NEW_COLORS("6");
                Variables.HudNewColorsValue = 6;
            }
            else if (guna2ComboBox9.SelectedIndex == 7)
            {
                OFFSETS.HUD_NEW_COLORS("7");
                Variables.HudNewColorsValue = 7;
            }
            else if (guna2ComboBox9.SelectedIndex == 8)
            {
                OFFSETS.HUD_NEW_COLORS("8");
                Variables.HudNewColorsValue = 8;
            }
            else if (guna2ComboBox9.SelectedIndex == 9)
            {
                OFFSETS.HUD_NEW_COLORS("9");
                Variables.HudNewColorsValue = 9;
            }
        }

        private void guna2ComboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox10.SelectedIndex == 0)
            {
                OFFSETS.WEATHER_STATE("0");
                Variables.WeatherStateValue = 0;
            }
            else if (guna2ComboBox10.SelectedIndex == 1)
            {
                OFFSETS.WEATHER_STATE("1");
                Variables.WeatherStateValue = 1;
            }
            else if (guna2ComboBox10.SelectedIndex == 2)
            {
                OFFSETS.WEATHER_STATE("2");
                Variables.WeatherStateValue = 2;
            }
            else if (guna2ComboBox10.SelectedIndex == 3)
            {
                OFFSETS.WEATHER_STATE("3");
                Variables.WeatherStateValue = 3;
            }
            else if (guna2ComboBox10.SelectedIndex == 4)
            {
                OFFSETS.WEATHER_STATE("4");
                Variables.WeatherStateValue = 4;
            }
            else if (guna2ComboBox10.SelectedIndex == 5)
            {
                OFFSETS.WEATHER_STATE("5");
                Variables.WeatherStateValue = 5;
            }
            else if (guna2ComboBox10.SelectedIndex == 6)
            {
                OFFSETS.WEATHER_STATE("6");
                Variables.WeatherStateValue = 6;
            }
            else if (guna2ComboBox10.SelectedIndex == 7)
            {
                OFFSETS.WEATHER_STATE("7");
                Variables.WeatherStateValue = 7;
            }
            else if (guna2ComboBox10.SelectedIndex == 8)
            {
                OFFSETS.WEATHER_STATE("8");
                Variables.WeatherStateValue = 8;
            }
            else if (guna2ComboBox10.SelectedIndex == 9)
            {
                OFFSETS.WEATHER_STATE("9");
                Variables.WeatherStateValue = 9;
            }
        }

        private void guna2ComboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox11.SelectedIndex == 0)
            {
                OFFSETS.INDICATOR_DAMAGE_COLORS("0");
                Variables.IndicatorDamageColorsValue = 0;
            }
            else if (guna2ComboBox11.SelectedIndex == 1)
            {
                OFFSETS.INDICATOR_DAMAGE_COLORS("1");
                Variables.IndicatorDamageColorsValue = 1;
            }
            else if (guna2ComboBox11.SelectedIndex == 2)
            {
                OFFSETS.INDICATOR_DAMAGE_COLORS("2");
                Variables.IndicatorDamageColorsValue = 2;
            }
        }

        private void guna2ComboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox12.SelectedIndex == 0)
            {
                OFFSETS.ENTITY_FUNNY_VISION("0");
                Variables.EntityFunnyVisionValue = 0;
            }
            else if (guna2ComboBox12.SelectedIndex == 1)
            {
                OFFSETS.ENTITY_FUNNY_VISION("1");
                Variables.EntityFunnyVisionValue = 1;
            }
            else if (guna2ComboBox12.SelectedIndex == 2)
            {
                OFFSETS.ENTITY_FUNNY_VISION("2");
                Variables.EntityFunnyVisionValue = 2;
            }
            else if (guna2ComboBox12.SelectedIndex == 3)
            {
                OFFSETS.ENTITY_FUNNY_VISION("3");
                Variables.EntityFunnyVisionValue = 3;
            }
            else if (guna2ComboBox12.SelectedIndex == 4)
            {
                OFFSETS.ENTITY_FUNNY_VISION("4");
                Variables.EntityFunnyVisionValue = 4;
            }
            else if (guna2ComboBox12.SelectedIndex == 5)
            {
                OFFSETS.ENTITY_FUNNY_VISION("5");
                Variables.EntityFunnyVisionValue = 5;
            }
            else if (guna2ComboBox12.SelectedIndex == 6)
            {
                OFFSETS.ENTITY_FUNNY_VISION("6");
                Variables.EntityFunnyVisionValue = 6;
            }
            else if (guna2ComboBox12.SelectedIndex == 7)
            {
                OFFSETS.ENTITY_FUNNY_VISION("7");
                Variables.EntityFunnyVisionValue = 7;
            }
        }

        private void guna2ComboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox13.SelectedIndex == 0)
            {
                OFFSETS.ENTITY_FUNNY_VISUAL("0");
                Variables.EntityFunnyVisualValue = 0;
            }
            else if (guna2ComboBox13.SelectedIndex == 1)
            {
                OFFSETS.ENTITY_FUNNY_VISUAL("1");
                Variables.EntityFunnyVisualValue = 1;
            }
            else if (guna2ComboBox13.SelectedIndex == 2)
            {
                OFFSETS.ENTITY_FUNNY_VISUAL("2");
                Variables.EntityFunnyVisualValue = 2;
            }
            else if (guna2ComboBox13.SelectedIndex == 3)
            {
                OFFSETS.ENTITY_FUNNY_VISUAL("3");
                Variables.EntityFunnyVisualValue = 3;
            }
            else if (guna2ComboBox13.SelectedIndex == 4)
            {
                OFFSETS.ENTITY_FUNNY_VISUAL("4");
                Variables.EntityFunnyVisualValue = 4;
            }
            else if (guna2ComboBox13.SelectedIndex == 5)
            {
                OFFSETS.ENTITY_FUNNY_VISUAL("5");
                Variables.EntityFunnyVisualValue = 5;
            }
            else if (guna2ComboBox13.SelectedIndex == 6)
            {
                OFFSETS.ENTITY_FUNNY_VISUAL("6");
                Variables.EntityFunnyVisualValue = 6;
            }
        }

        private void guna2ComboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox14.SelectedIndex == 0)
            {
                OFFSETS.FPS_VALUES("0");
                Variables.FPSValue = 0;
            }
            else if (guna2ComboBox14.SelectedIndex == 1)
            {
                OFFSETS.FPS_VALUES("1");
                Variables.FPSValue = 1;
            }
            else if (guna2ComboBox14.SelectedIndex == 2)
            {
                OFFSETS.FPS_VALUES("2");
                Variables.FPSValue = 2;
            }
            else if (guna2ComboBox14.SelectedIndex == 3)
            {
                OFFSETS.FPS_VALUES("3");
                Variables.FPSValue = 3;
            }
            else if (guna2ComboBox14.SelectedIndex == 4)
            {
                OFFSETS.FPS_VALUES("4");
                Variables.FPSValue = 4;
            }
            else if (guna2ComboBox14.SelectedIndex == 5)
            {
                OFFSETS.FPS_VALUES("5");
                Variables.FPSValue = 5;
            }
            else if (guna2ComboBox14.SelectedIndex == 6)
            {
                OFFSETS.FPS_VALUES("6");
                Variables.FPSValue = 6;
            }
            else if (guna2ComboBox14.SelectedIndex == 7)
            {
                OFFSETS.FPS_VALUES("7");
                Variables.FPSValue = 7;
            }
            else if (guna2ComboBox14.SelectedIndex == 8)
            {
                OFFSETS.FPS_VALUES("8");
                Variables.FPSValue = 8;
            }
            else if (guna2ComboBox14.SelectedIndex == 9)
            {
                OFFSETS.FPS_VALUES("9");
                Variables.FPSValue = 9;
            }
            else if (guna2ComboBox14.SelectedIndex == 10)
            {
                OFFSETS.FPS_VALUES("10");
                Variables.FPSValue = 10;
            }
            else if (guna2ComboBox14.SelectedIndex == 11)
            {
                OFFSETS.FPS_VALUES("11");
                Variables.FPSValue = 11;
            }
            else if (guna2ComboBox14.SelectedIndex == 12)
            {
                OFFSETS.FPS_VALUES("12");
                Variables.FPSValue = 12;
            }
            else if (guna2ComboBox14.SelectedIndex == 13)
            {
                OFFSETS.FPS_VALUES("13");
                Variables.FPSValue = 13;
            }
            else if (guna2ComboBox14.SelectedIndex == 14)
            {
                OFFSETS.FPS_VALUES("14");
                Variables.FPSValue = 14;
            }
            else if (guna2ComboBox14.SelectedIndex == 15)
            {
                OFFSETS.FPS_VALUES("15");
                Variables.FPSValue = 15;
            }
        }

        private void guna2ComboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox15.SelectedIndex == 0)
            {
                OFFSETS.CLOUD_COLORS("0");
                Variables.CloudColorsValue = 0;
            }
            else if (guna2ComboBox15.SelectedIndex == 1)
            {
                OFFSETS.CLOUD_COLORS("1");
                Variables.CloudColorsValue = 1;
            }
            else if (guna2ComboBox15.SelectedIndex == 2)
            {
                OFFSETS.CLOUD_COLORS("2");
                Variables.CloudColorsValue = 2;
            }
            else if (guna2ComboBox15.SelectedIndex == 3)
            {
                OFFSETS.CLOUD_COLORS("3");
                Variables.CloudColorsValue = 3;
            }
            else if (guna2ComboBox15.SelectedIndex == 4)
            {
                OFFSETS.CLOUD_COLORS("4");
                Variables.CloudColorsValue = 4;
            }
            else if (guna2ComboBox15.SelectedIndex == 5)
            {
                OFFSETS.CLOUD_COLORS("5");
                Variables.CloudColorsValue = 5;
            }
            else if (guna2ComboBox15.SelectedIndex == 6)
            {
                OFFSETS.CLOUD_COLORS("6");
                Variables.CloudColorsValue = 6;
            }
            else if (guna2ComboBox15.SelectedIndex == 7)
            {
                OFFSETS.CLOUD_COLORS("7");
                Variables.CloudColorsValue = 7;
            }
            else if (guna2ComboBox15.SelectedIndex == 8)
            {
                OFFSETS.CLOUD_COLORS("8");
                Variables.CloudColorsValue = 8;
            }
        }

        private void guna2ComboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox16.SelectedIndex == 0)
            {
                OFFSETS.TIME_SPEED("0");
                Variables.TimeSpeedValue = 0;
            }
            else if (guna2ComboBox16.SelectedIndex == 1)
            {
                OFFSETS.TIME_SPEED("1");
                Variables.TimeSpeedValue = 1;
            }
            else if (guna2ComboBox16.SelectedIndex == 2)
            {
                OFFSETS.TIME_SPEED("2");
                Variables.TimeSpeedValue = 2;
            }
            else if (guna2ComboBox16.SelectedIndex == 3)
            {
                OFFSETS.TIME_SPEED("3");
                Variables.TimeSpeedValue = 3;
            }
            else if (guna2ComboBox16.SelectedIndex == 4)
            {
                OFFSETS.TIME_SPEED("4");
                Variables.TimeSpeedValue = 4;
            }
            else if (guna2ComboBox16.SelectedIndex == 5)
            {
                OFFSETS.TIME_SPEED("5");
                Variables.TimeSpeedValue = 5;
            }
            else if (guna2ComboBox16.SelectedIndex == 6)
            {
                OFFSETS.TIME_SPEED("6");
                Variables.TimeSpeedValue = 6;
            }
            else if (guna2ComboBox16.SelectedIndex == 7)
            {
                OFFSETS.TIME_SPEED("7");
                Variables.TimeSpeedValue = 7;
            }
            else if (guna2ComboBox16.SelectedIndex == 8)
            {
                OFFSETS.TIME_SPEED("8");
                Variables.TimeSpeedValue = 8;
            }
            else if (guna2ComboBox16.SelectedIndex == 9)
            {
                OFFSETS.TIME_SPEED("9");
                Variables.TimeSpeedValue = 9;
            }
            else if (guna2ComboBox16.SelectedIndex == 10)
            {
                OFFSETS.TIME_SPEED("10");
                Variables.TimeSpeedValue = 10;
            }
        }
    }
}
