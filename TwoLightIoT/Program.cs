using System;
using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;

namespace TwoLightIoT
{
    class Program
    {
        static void Main(string[] args)
        {
            var blinkingPinGreen = Pi.Gpio[P1.Gpio22];// Physical pin 15
            var blinkingPinRed = Pi.Gpio[P1.Gpio27];// Physical pin 13
            blinkingPinGreen.PinMode = GpioPinDriveMode.Output;
            blinkingPinRed.PinMode = GpioPinDriveMode.Output;

            for (byte i = 0; i < 40; i++)
            {
                if (i % 2 == 0)
                {
                    blinkingPinRed.Write(false);
                    Thread.Sleep(500);
                    blinkingPinGreen.Write(true);

                }
                else
                {
                    blinkingPinGreen.Write(false);
                    Thread.Sleep(500);
                    blinkingPinRed.Write(true);
                }
                Thread.Sleep(2500);
            }
            blinkingPinGreen.Write(false);
            blinkingPinRed.Write(false);
            Environment.Exit(0);
        }
    }
}
