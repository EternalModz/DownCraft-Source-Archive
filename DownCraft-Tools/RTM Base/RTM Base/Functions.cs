using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PS3Lib; //Using PS3 Librabry

namespace RTM_Base
{
    public class Functions
    {
        PS3API PS3 = new PS3API(); //For using PS3.

        #region "Toggle Options / Offsets"

        public void GOD_MODE(bool toggle) //<== Options God Mode
        {
            try
            {
                if (this.PS3.AttachProcess() && toggle)
                {
                    PS3.SetMemory(0x004B2021, new byte[] { 0x80 }); //Offset God Mode with values for enable it
                }
                else if (!toggle)
                {
                    PS3.SetMemory(0x004B2021, new byte[] { 0x20 }); //Offset God Mode with values for disable it
                }
            }
            catch (Exception)
            {
                MessageBox.Show("RTM Base, need to be connected or attached to the PS3 !", "RTM Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion












































        public bool Toggle { get; private set; }

    }
}
