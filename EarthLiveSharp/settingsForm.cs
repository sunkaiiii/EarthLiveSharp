using System;
using System.Windows.Forms;

namespace EarthLiveSharp
{
    public partial class settingsForm : Form
    {
        public settingsForm()
        {
            InitializeComponent();
            Config.Load();
        }

        private void save_config()
        {
            Config.satellite = satellite.Text;
            Config.interval = (int)(interval.Value);
            Config.zoom = (int)(image_zoom.Value);
            Config.autostart = autostart.Checked;
            Config.setwallpaper = setwallpaper.Checked;
            Config.saveTexture = Save_Texture.Checked;
            Config.saveMaxCount = (int)Save_Max_Count.Value;
            Config.saveDirectory = Directory_Display.Text;

            if (radioButton_CDN.Checked)
            {
                Config.source_selection = 1;
                Config.cloud_name = cloud_name.Text;
                Config.api_key = api_key.Text;
                Config.api_secret = api_secret.Text;
            }
            else
            {
                Config.source_selection = 0;
            }
            switch (image_size.SelectedIndex)
            {
                case 0: Config.size = 1; break;
                case 1: Config.size = 2; break;
                case 2: Config.size = 4; break;
                case 3: Config.size = 8; break;
                case 4: Config.size = 16; break;
                default: Config.size = 1; break;
            }
            Config.Save();
            Autostart.Set(Config.autostart);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            save_config();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/bitdust/EarthLiveSharp/issues/32");
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            Config.Load();
            version_number.Text = Config.version;
            cloud_name.Text = Config.cloud_name;
            autostart.Checked = Config.autostart;
            setwallpaper.Checked = Config.setwallpaper;
            interval.Value = Config.interval;
            image_zoom.Value = Config.zoom;
            api_key.Text = Config.api_key;
            api_secret.Text = Config.api_secret;
            Save_Texture.Checked = Config.saveTexture;
            Save_Max_Count.Value = Config.saveMaxCount;
            Directory_Display.Text = Config.saveDirectory;


            if (Config.source_selection == 1)
            {
                radioButton_CDN.Checked = true;
                panel2.Enabled = true;
            }
            else
            {
                radioButton_Orgin.Checked = true;
                panel2.Enabled = false;
            }

            if (Config.saveTexture)
            {
                panel3.Enabled = true;
            }
            else
            {
                panel3.Enabled = false;
            }

            switch (Config.satellite)
            {
                case "Himawari8": satellite.SelectedIndex = 0; image_size.Enabled = true; break;
                case "FengYun4": satellite.SelectedIndex = 1; image_size.Enabled = false; break;
                default: satellite.SelectedIndex = 0; image_size.Enabled = true; break;
            }

            switch (Config.size)
            {
                case 1: image_size.SelectedIndex = 0; break;
                case 2: image_size.SelectedIndex = 1; break;
                case 4: image_size.SelectedIndex = 2; break;
                case 8: image_size.SelectedIndex = 3; break;
                case 16: image_size.SelectedIndex = 4; break;
                default: image_size.SelectedIndex = 0; break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            save_config();
            this.Close();
        }

        private void radioButton_Orgin_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_CDN.Checked)
            {
                panel2.Enabled = true;
            }
            else
            {
                panel2.Enabled = false;
            }
        }

        private void satellite_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (satellite.Text)
            {
                case "Himawari8": image_size.Enabled = true; break;
                case "FengYun4": image_size.Enabled = false; break;
                default: image_size.Enabled = true; break;
            }
        }

        private void Selected_Directory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "selected Directory";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Directory_Display.Text = dialog.SelectedPath;
            }
        }

        private void Save_Texture_CheckedChanged(object sender, EventArgs e)
        {
            if (Save_Texture.Checked)
            {
                panel3.Enabled = true;
            }
            else
            {
                panel3.Enabled = false;
            }
        }
    }
}
