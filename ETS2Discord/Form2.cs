﻿using System;
using System.Windows.Forms;

namespace ETS2Discord
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            // 設定を読み込む
            api_url.Text = Settings.Telemetry_url;
            free_details_combo.SelectedIndex = int.Parse(Settings.free_details);
            free_state_combo.SelectedIndex = int.Parse(Settings.free_state);
            job_details_combo.SelectedIndex = int.Parse(Settings.job_details);
            job_state_combo.SelectedIndex = int.Parse(Settings.job_state);
            if (Settings.X_button_move == "minimum")
            {
                min_radioButton.Checked = true;
            } else
            {
                exit_radioButton.Checked = true;
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            DialogResult ini_result = MessageBox.Show("設定を上書き保存します。\n一部の設定は次回起動時に適用されます。", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (ini_result == DialogResult.OK)
            {
                // 設定を上書き保存
                var ini = new IniFile(System.IO.Directory.GetCurrentDirectory() + @"\ets2discord.ini");
                ini.WriteString("ets2discord", "api_url", api_url.Text);
                ini.WriteString("ets2discord", "free_details", free_details_combo.SelectedIndex.ToString());
                ini.WriteString("ets2discord", "free_state", free_state_combo.SelectedIndex.ToString());
                ini.WriteString("ets2discord", "job_details", job_details_combo.SelectedIndex.ToString());
                ini.WriteString("ets2discord", "job_state", job_state_combo.SelectedIndex.ToString());
                if (min_radioButton.Checked)
                {
                    ini.WriteString("ets2discord", "x_button_move", "minimum");
                } else
                {
                    ini.WriteString("ets2discord", "x_button_move", "exit");
                }

                // DiscordRPCの表示設定はすぐに反映させる
                Settings.free_details = free_details_combo.SelectedIndex.ToString();
                Settings.free_state = free_state_combo.SelectedIndex.ToString();
                Settings.job_details = job_details_combo.SelectedIndex.ToString();
                Settings.job_state = job_state_combo.SelectedIndex.ToString();

                this.Close();
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
