using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingMS.Forms.Class
{
    class SearchforUSBCom
    {
        public bool SearchforCom( string sCom)
        {
            string sComValue;
            string sTmpara;
            RegistryKey myReg;
            myReg = Registry.LocalMachine.OpenSubKey(@"HARDWARE\\DEVICEMAP\\SERIALCOMM");

            string[] sComName;
            sComName = myReg.GetValueNames(); // strings array composed of the key name holded by the subkey "SERIALCOMM"
            int i;
            for (i = 0; i <= sComName.Length - 1; i++)
            {
                sComValue = myReg.GetValue(sComName[i]).ToString(); // obtain the key value of the corresponding key name
                if (sComValue == "")
                    continue;

                sCom = "";
                int j;
                if (sComName[i] == @"\Device\USBSER000")
                {
                    for (j = 0; j <= 10; j++)
                    {
                        sTmpara = "";
                        RegistryKey myReg2;
                        myReg2 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Enum\\USB\\VID_1B55&PID_B400\\" + j.ToString() + @"\\Device Parameters");

                        if (myReg2 != null)
                        {
                            sTmpara = myReg2.GetValue("PortName").ToString();

                            if (sComValue == sTmpara)
                            {
                                sCom = sTmpara;
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

    }
}
