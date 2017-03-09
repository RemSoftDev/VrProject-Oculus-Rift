using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VrManager.Helpers
{
    class LicenseProvider
    {


        public string FullPathLicense { get; set; }

        private string _fingerPrint = string.Empty;
        private string _clientInfo;

        public string GetLicenseValue()
        {
            try
            {
                _fingerPrint = GetHash("CPU >> " + CpuId() + "\nBIOS >> " + BiosId() + "\nBASE >> " + BaseId() + "\nDISK >> " + DiskId() + "\nVIDEO >> " + VideoId());
                return _fingerPrint;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }
        public string GetInfoString()
        {
            try
            {
                return _fingerPrint = "CPU >> " + CpuId() + "\nBIOS >> " + BiosId() + "\nBASE >> " + BaseId() + "\nDISK >> " + DiskId() + "\nVIDEO >> " + VideoId();
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }
        public string GetLicenseValueByInfo(string info)
        {
            try
            {
                string @string = info;
                _fingerPrint = GetHash(@string);
                return _fingerPrint;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }
        private string GetHash(string s)
        {
            try
            {
                //Initialize a new MD5 Crypto Service Provider in order to generate a hash
                MD5 sec = new MD5CryptoServiceProvider();
                //Grab the bytes of the variable 's'
                byte[] bt = Encoding.ASCII.GetBytes(s);
                //Grab the Hexadecimal value of the MD5 hash
                return GetHexString(sec.ComputeHash(bt));
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }

        public void CreateLicense()
        {
            try
            {
                LicenseProvider licenseProvider = new LicenseProvider();
                string licese = licenseProvider.GetLicenseValueByInfo(_clientInfo);
                File.WriteAllText(FullPathLicense, licese);
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        public void CreateClientFileInfo(string path)
        {
            try
            {
                string ConfigInfo = GetInfoString();
                File.WriteAllText(path, ConfigInfo);
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        public void OpenFileClientInfo(string path)
        {
            try
            {
                _clientInfo = File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        public bool CheckLicense()
        {
            try
            {
                if (File.Exists(FullPathLicense) == false)
                {
                    return false;
                }

                using (StreamReader sr = new StreamReader(FullPathLicense))
                {
                    LicenseProvider licenseProvider = new LicenseProvider();
                    var licese = licenseProvider.GetLicenseValueByInfo(licenseProvider.GetLicenseValue());
                    string line = sr.ReadToEnd();
                    return licese.Equals(line);
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return false;
            }
        }

        private string GetHexString(IList<byte> bt)
        {
            try
            {
                string s = string.Empty;
                for (int i = 0; i < bt.Count; i++)
                {
                    byte b = bt[i];
                    int n = b;
                    int n1 = n & 15;
                    int n2 = (n >> 4) & 15;
                    if (n2 > 9)
                        s += ((char)(n2 - 10 + 'A')).ToString(CultureInfo.InvariantCulture);
                    else
                        s += n2.ToString(CultureInfo.InvariantCulture);
                    if (n1 > 9)
                        s += ((char)(n1 - 10 + 'A')).ToString(CultureInfo.InvariantCulture);
                    else
                        s += n1.ToString(CultureInfo.InvariantCulture);
                    if ((i + 1) != bt.Count && (i + 1) % 2 == 0) s += "-";
                }
                return s;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }

        //Return a hardware identifier
        private string Identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
        {
            try
            {
                string result = "";
                System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
                System.Management.ManagementObjectCollection moc = mc.GetInstances();
                foreach (System.Management.ManagementBaseObject mo in moc)
                {
                    if (mo[wmiMustBeTrue].ToString() != "True") continue;
                    //Only get the first one
                    if (result != "") continue;
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch (Exception ex)
                    {
                        App.SendException(ex);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }
        //Return a hardware identifier
        private string Identifier(string wmiClass, string wmiProperty)
        {
            try
            {
                string result = "";
                System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
                System.Management.ManagementObjectCollection moc = mc.GetInstances();
                foreach (System.Management.ManagementBaseObject mo in moc)
                {
                    //Only get the first one
                    if (result != "") continue;
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }

        private string CpuId()
        {
            try
            {
                //Uses first CPU identifier available in order of preference
                //Don't get all identifiers, as it is very time consuming
                string retVal = Identifier("Win32_Processor", "UniqueId");
                if (retVal != "") return retVal;
                retVal = Identifier("Win32_Processor", "ProcessorId");
                if (retVal != "") return retVal;
                retVal = Identifier("Win32_Processor", "Name");
                if (retVal == "") //If no Name, use Manufacturer
                {
                    retVal = Identifier("Win32_Processor", "Manufacturer");
                }
                //Add clock speed for extra security
                retVal += Identifier("Win32_Processor", "MaxClockSpeed");
                return retVal;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }
        //BIOS Identifier
        private string BiosId()
        {
            try
            {
                return Identifier("Win32_BIOS", "Manufacturer") + Identifier("Win32_BIOS", "SMBIOSBIOSVersion") + Identifier("Win32_BIOS", "IdentificationCode") + Identifier("Win32_BIOS", "SerialNumber") + Identifier("Win32_BIOS", "ReleaseDate") + Identifier("Win32_BIOS", "Version");
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }
        //Main physical hard drive ID
        private string DiskId()
        {
            try
            {
                return Identifier("Win32_DiskDrive", "Model") + Identifier("Win32_DiskDrive", "Manufacturer") + Identifier("Win32_DiskDrive", "Signature") + Identifier("Win32_DiskDrive", "TotalHeads");
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }
        //Motherboard ID
        private string BaseId()
        {
            try
            {
                return Identifier("Win32_BaseBoard", "Model") + Identifier("Win32_BaseBoard", "Manufacturer") + Identifier("Win32_BaseBoard", "Name") + Identifier("Win32_BaseBoard", "SerialNumber");
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }
        //Primary video controller ID
        private string VideoId()
        {
            try
            {
                return Identifier("Win32_VideoController", "DriverVersion") + Identifier("Win32_VideoController", "Name");
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }
        //First enabled network card ID
        private string MacId()
        {
            try
            {
                return Identifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }

    }
}
