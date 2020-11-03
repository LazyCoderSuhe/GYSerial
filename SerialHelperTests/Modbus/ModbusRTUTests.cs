using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerialHelper.Modbus;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerialHelper.Modbus.Tests
{
    [TestClass()]
    public class ModbusRTUTests
    {
        [TestMethod()]
        public void ReadKeepRegTest()
        {
            Modbus.ModbusRTU modbusRTU = new ModbusRTU();
            modbusRTU.OpenCom("COM11",
                BaudRateEnum.BaudRate9600,
                System.IO.Ports.Parity.None,
                System.IO.Ports.StopBits.None, DataBitsEnum.DataBits8);
            byte[] reuslt = modbusRTU.ReadKeepReg(17, 107, 3);
            byte[] re = new byte[2];
            re[0] = reuslt[1];
            re[1] = reuslt[0];
            string s = BitConverter.ToInt16(re, 0).ToString();
        }
    }
}