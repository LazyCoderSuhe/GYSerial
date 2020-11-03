using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace SerialHelper.Modbus
{
    public class ModbusRTU
    {
        private SerialPort serialPort = new SerialPort();

        /// <summary>
        /// 串口配置
        /// </summary>
        /// <param name="PortName">串口名称</param>
        /// <param name="BaudRate">波特率</param>
        /// <param name="parity">校验</param>
        /// <param name="stopBits">停止位</param>
        /// <param name="dataBits">数据位</param>
        /// <param name="Timeout">超时</param>
        public void OpenCom(string PortName, int BaudRate, Parity parity, StopBits stopBits, DataBitsEnum dataBits,
            int Timeout = 1000)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            serialPort.PortName = PortName;
            serialPort.BaudRate = BaudRate;
            serialPort.Parity = parity;
            serialPort.DataBits = (int)dataBits;
            serialPort.StopBits = stopBits;
            serialPort.ReadTimeout = Timeout;
            serialPort.WriteTimeout = Timeout;
            //serialPort.ReceivedBytesThreshold = 1;
            //serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.Open();
        }

        /*
         * 报文：
         * Tx:642-11 03 00 6B 00 03 76 87
           Rx:643-11 03 06 00 00 00 00 00 00 EC B5
         第一步：拼接报文
         第二步：发送报文
         第三个：接受后解析报文
         */

        /// <summary>
        /// 读取保留 寄存器 3H
        /// </summary>
        public byte[] ReadKeepReg(int DevAddr, int Addrees, int Length)
        {
            byte[] sengCommand = new byte[8];
            sengCommand[0] = (byte)DevAddr;
            sengCommand[1] = 0x03;
            sengCommand[2] = (byte)(Addrees / 256);
            sengCommand[3] = (byte)(Addrees % 256);
            sengCommand[4] = (byte)(Length / 256);
            sengCommand[5] = (byte)(Length % 256);
            byte[] crc = ModBusCRCHelper.ToModbus(sengCommand, 6);
            sengCommand[6] = crc[0];
            sengCommand[7] = crc[1];
            byte[] response = new byte[5 + Length * 2];
            try
            {
                SendAndRecive(sengCommand, ref response);
            }
            catch (Exception)
            {
                return null;
            }
            return ClipByteArray(response, 3, Length * 2);
        }

        public void SendAndRecive(byte[] sengCommand, ref byte[] response)
        {

            serialPort.Write(sengCommand, 0, sengCommand.Length);
            for (int i = 0; i < response.Length; i++)
            {
                response[i] = (byte)serialPort.ReadByte();
            }
        }


        /// <summary>
        /// 关闭端口
        /// </summary>
        public void CloseCom()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
        private byte[] ClipByteArray(byte[] arr, int start, int length)
        {
            byte[] result = new byte[length];
            if (arr != null && arr.Length >= length)
                for (int i = 0; i < length; i++)
                    result[i] = arr[i + start];
            return result;
        }


        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
