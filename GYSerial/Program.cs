using System;
using System.Threading.Tasks;
using IToolS.Data;
using SerialHelper.Modbus;

namespace GYSerial
{
    class Program
    {
        static void Main(string[] args)
        {
            ModbusRTU modbusRTU = new ModbusRTU();
            try
            {
                modbusRTU.OpenCom("COM11",
             BaudRateEnum.BaudRate9600,
             System.IO.Ports.Parity.None,
             System.IO.Ports.StopBits.One, DataBitsEnum.DataBits8);
                Console.WriteLine("Sesscess");
                for (int i = 0; i < 100; i++)
                {
                    byte[] reuslt = modbusRTU.ReadKeepReg(17, 107, 3);
                    byte[] re = new byte[2];
                    re[0] = reuslt[1];
                    re[1] = reuslt[0];
                    Console.WriteLine(BitConverter.ToInt16(re, 0).ToString());
                    Task.Delay(1000).Wait();
                }
            }
            catch (Exception)
            {

                    throw;
            }
        }
    }
}
