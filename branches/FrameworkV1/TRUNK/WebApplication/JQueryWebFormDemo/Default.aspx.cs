namespace JQueryWebFormDemo {
    using System;
    using System.Configuration;
    using System.Web;
    using System.Web.Configuration;

    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            
        }

        protected override void OnInit(EventArgs e)
        {
            btnSaveConfig.Click += new EventHandler(btnSaveConfig_Click);
            base.OnInit(e);
        }

        void btnSaveConfig_Click(object sender, EventArgs e)
        {
            //ConfigurationFileMap configurationFile = new ConfigurationFileMap();
            WebConfigurationFileMap fileMap = new WebConfigurationFileMap();


            lblLastName.Text = AppDomain.CurrentDomain.BaseDirectory +"-----" +Environment.CurrentDirectory;
           
            VirtualDirectoryMapping vDirMap = new VirtualDirectoryMapping(AppDomain.CurrentDomain.BaseDirectory,true,"web.config");
            fileMap.VirtualDirectories.Add("/",vDirMap);

            foreach (string key in fileMap.VirtualDirectories.AllKeys)
            {
                
                Response.Write(fileMap.VirtualDirectories[key].VirtualDirectory);
                Response.Write(fileMap.VirtualDirectories[key].PhysicalDirectory);
            }
            //string filename = AppDomain.CurrentDomain.BaseDirectory + "Web.config";
            //fileName.TrimStart(new char[] { '~', '/' });
            Configuration config = WebConfigurationManager.OpenMappedWebConfiguration(fileMap,"/");

            //Configuration config = WebConfigurationManager.OpenMappedWebConfiguration(
            //    webConigurationFile, HttpContext.Current.Request.ApplicationPath);
            config.AppSettings.Settings["test"].Value = "test3";

            config.Save();

        }
    }
}

