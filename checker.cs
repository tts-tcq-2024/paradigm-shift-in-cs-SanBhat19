using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace paradigm_shift_csharp
{
    class Checker
    {
        static bool batteryIsOk(float temperature, float soc, float chargeRate)
        {
            bool tempOK = TemperatureIsOk(temperature);
            bool socOK = SOCIsOk(soc);
            bool chargeOK = ChargeIsOk(chargeRate);
            bool check = tempOK && socOK && chargeOK;
            return check;
        }
        static bool TemperatureIsOk(float temperature)
        {
            if (temperature < 0 || temperature > 45)
            {
                Measure(temperature, 45);
                PrintMessage("Temperature is out of range!");
                return false;
            }
            return true;
        }
        static bool SOCIsOk(float soc)
        {
            if (soc < 20 || soc > 80)
            {
                Measure(soc, 80);
                PrintMessage("State of Charge is out of range!");
                return false;
            }
            return true;
        }
        static bool ChargeIsOk(float charge)
        {
            if (charge > 0.8)
            {
                Measure(charge, 0.8);
                PrintMessage("Charge Rate is out of range!");
                return false;
            }
            return true;
        }
        static void Measure(float value, float min, float max)
        {
            if(value > max)
            {
                PrintMessage("Abnormal - Low");
            }
            else
            {
                PrintMessage("Abnormal - High");
            }
        }
        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
        static void ExpectTrue(bool expression)
        {
            if (!expression)
            {
                Console.WriteLine("Expected true, but got false");
                Environment.Exit(1);
            }
        }
        static void ExpectFalse(bool expression)
        {
            if (expression)
            {
                Console.WriteLine("Expected false, but got true");
                Environment.Exit(1);
            }
        }
        static int Main()
        {
            ExpectTrue(batteryIsOk(25, 70, 0.7f));
            ExpectFalse(batteryIsOk(50, 85, 0.0f));
            Console.WriteLine("All ok");
            return 0;
        }

    }
}

