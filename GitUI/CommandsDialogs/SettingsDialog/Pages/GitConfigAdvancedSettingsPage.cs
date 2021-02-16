﻿using Microsoft;

namespace GitUI.CommandsDialogs.SettingsDialog.Pages
{
    public partial class GitConfigAdvancedSettingsPage : ConfigFileSettingsPage
    {
        public GitConfigAdvancedSettingsPage()
        {
            InitializeComponent();
            Text = "Advanced";
            InitializeComplete();
        }

        protected override void SettingsToPage()
        {
            Validates.NotNull(CurrentSettings);
            checkBoxPullRebase.Checked = CurrentSettings.GetValue("pull.rebase") == "true";
            checkBoxFetchPrune.Checked = CurrentSettings.GetValue("fetch.prune") == "true";
            checkBoxRebaseAutostash.Checked = CurrentSettings.GetValue("rebase.autoStash") == "true";
        }

        protected override void PageToSettings()
        {
            Validates.NotNull(CurrentSettings);
            CurrentSettings.SetValue("pull.rebase", checkBoxPullRebase.Checked ? "true" : "false");
            CurrentSettings.SetValue("fetch.prune", checkBoxFetchPrune.Checked ? "true" : "false");
            CurrentSettings.SetValue("rebase.autoStash", checkBoxRebaseAutostash.Checked ? "true" : "false");
        }
    }
}
