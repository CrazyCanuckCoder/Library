#region

using System;
using System.Configuration;
using System.Linq;

#endregion

namespace Library.WinForms
{
    public class AppSettingsManager
    {
        /// <summary>
        /// Gets the values of the AppSettings section in the application's
        /// configuration file.
        /// </summary>
        /// 
        private static AppSettingsSection AppSettings
        {
            get
            {
                Configuration config = null;
                AppSettingsSection section = null;

                try
                {
                    config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                }
                catch (Exception)
                {
                    config = null;
                }

                if (config != null)
                {
                    section = config.AppSettings;
                }

                return section;
            }
        }

        /// <summary>
        /// Retrieves the value for the specified setting name from the application
        /// configuration file.
        /// </summary>
        /// 
        /// <param name="SettingName">
        /// The name of the setting, must exactly match a value in the application's
        /// configuration file.
        /// </param>
        /// 
        /// <returns>
        /// A string containing the value found for the specified setting or a blank
        /// string if the setting could not be found.
        /// </returns>
        /// 
        private static string GetAppSetting(string SettingName)
        {
            string settingValue = "";

            if (AppSettings != null && AppSettings.Settings.Count > 0)
            {
                if (AppSettings.Settings.AllKeys.Contains(SettingName))
                {
                    settingValue = AppSettings.Settings[SettingName].Value;
                }
            }

            return settingValue;
        }

        /// <summary>
        /// Obtains the value associated with the specified setting name and 
        /// converts it to the appropriate type.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the value to be converted to.  Must be a built in .NET
        /// primitive type like int, bool or string.
        /// </typeparam>
        /// 
        /// <param name="AppSettingName">
        /// The name of the setting in the configuration file.
        /// </param>
        /// 
        /// <returns>
        /// A T value according to the value found in the configuration file.  If
        /// the setting name was not found in the configuration file, the default
        /// value for T is returned.  (0 for ints, blanks for strings, etc)
        /// </returns>
        /// 
        public static T GetAppSettingValue<T>(string AppSettingName) where T : IConvertible
        {
            T newValue = default(T);
            string settingValue = GetAppSetting(AppSettingName);

            if (settingValue != "")
            {
                try
                {
                    newValue = (T) Convert.ChangeType(settingValue, typeof (T));
                }
                catch
                {
                    newValue = default(T);
                }
            }

            return newValue;
        }

        /// <summary>
        /// Writes a new value to the configuration file for a specified
        /// key in the AppSetting section.
        /// </summary>
        /// 
        /// <param name="SettingName">
        /// The name of the setting which must exactly match a key in the
        /// AppSetting section of the configuration file.
        /// </param>
        /// 
        /// <param name="NewValue">
        /// The value to write to the specified setting.
        /// </param>
        /// 
        public static void SetAppSettingValue(string SettingName, string NewValue)
        {
            Configuration config = null;

            try
            {
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
            catch
            {
                config = null;
            }

            if (config != null)
            {
                AppSettingsSection section = config.AppSettings;

                //  Change the value then encrypt the section before writing it
                //    back to the configuration file.

                if (section.Settings.AllKeys.Contains(SettingName))
                {
                    section.Settings[SettingName].Value = NewValue;
                }
                config.Save(ConfigurationSaveMode.Full);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
    }
}