using ProtectorDX.Interfaces;
using ProtectorDX.Models;
using System;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProtectorDX.Helpers
{
    public class ProtectorDX : IProtectorDX
    {
        
        public Tuple<bool, Exception> ProtectConnectionStrings(Parameters parameters)
        {
            try
            {
                if (parameters.HostNames.IndexOf(Environment.MachineName) > -1)
                {
                    var config = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap
                    {
                        ExeConfigFilename = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory,
                        (parameters.ProtectType == Enums.ProtectTypes.WEB_CONFIG) ? "web.config" : ((parameters.ProtectType == Enums.ProtectTypes.APP_CONFIG) ? "app.config" : "app.settings"))
                    }, ConfigurationUserLevel.None);

                    ConfigurationSection section = config.GetSection("connectionStrings");

                    if (!section.SectionInformation.IsProtected)
                    {
                        section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
                        config.Save();
                    }

                    return Tuple.Create(true, default(Exception));
                }
                else
                {
                    return Tuple.Create(true, default(Exception));
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create(false, ex);
            }
        }

        public Tuple<bool, Exception> UnProtectConnectionStrings(Parameters parameters)
        {
            try
            {
                if (parameters.HostNames.IndexOf(Environment.MachineName) > -1)
                {
                    var config = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap
                    {
                        ExeConfigFilename = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory,
                        (parameters.ProtectType == Enums.ProtectTypes.WEB_CONFIG) ? "web.config" : ((parameters.ProtectType == Enums.ProtectTypes.APP_CONFIG) ? "app.config" : "app.settings"))
                    }, ConfigurationUserLevel.None);

                    ConfigurationSection section = config.GetSection("connectionStrings");

                    if (section.SectionInformation.IsProtected)
                    {
                        section.SectionInformation.UnprotectSection();
                        config.Save();
                    }

                    return Tuple.Create(true, default(Exception));
                }
                else
                {
                    return Tuple.Create(true, default(Exception));
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create(false, ex);
            }
        }
    }
}
