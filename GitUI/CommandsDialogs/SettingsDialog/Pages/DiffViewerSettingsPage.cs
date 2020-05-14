﻿using GitCommands;
using ResourceManager;

namespace GitUI.CommandsDialogs.SettingsDialog.Pages
{
    public partial class DiffViewerSettingsPage : SettingsPageWithHeader
    {
        private readonly TranslationString _showDiffForAllParents = new TranslationString(
            @"Show all differences between the selected commits, not limiting to only one difference.

- For a single selected commit, show the difference with its parent commit.
- For a single selected merge commit, show the difference with all parents.
- For two selected commits with a common ancestor (BASE):
   - Show the difference between the commits.
   - The difference of unique files from BASE to each of the selected commits.
   - The difference of common files (identical changes) from BASE to the commits.
- For multiple selected commits (up to four), show the difference for all the first selected with the last selected commit.
- For more than four selected commits, show the difference from the first to the last selected commit.");

        public DiffViewerSettingsPage()
        {
            InitializeComponent();
            Text = "Diff Viewer";
            InitializeComplete();
            chkShowDiffForAllParents.ToolTipText = _showDiffForAllParents.Text;
            chkContScrollToNextFileOnlyWithAlt.Text = Strings.ContScrollToNextFileOnlyWithAlt;
        }

        protected override void SettingsToPage()
        {
            chkRememberIgnoreWhiteSpacePreference.Checked = AppSettings.RememberIgnoreWhiteSpacePreference;
            chkOmitUninterestingDiff.Checked = AppSettings.OmitUninterestingDiff;
            chkRememberShowEntireFilePreference.Checked = AppSettings.RememberShowEntireFilePreference;
            chkRememberShowNonPrintingCharsPreference.Checked = AppSettings.RememberShowNonPrintingCharsPreference;
            chkRememberNumberOfContextLines.Checked = AppSettings.RememberNumberOfContextLines;
            chkRememberShowSyntaxHighlightingInDiff.Checked = AppSettings.RememberShowSyntaxHighlightingInDiff;
            chkOpenSubmoduleDiffInSeparateWindow.Checked = AppSettings.OpenSubmoduleDiffInSeparateWindow;
            chkContScrollToNextFileOnlyWithAlt.Checked = AppSettings.AutomaticContinuousScroll;
            chkShowDiffForAllParents.Checked = AppSettings.ShowDiffForAllParents;
            VerticalRulerPosition.Value = AppSettings.DiffVerticalRulerPosition;
        }

        protected override void PageToSettings()
        {
            AppSettings.RememberIgnoreWhiteSpacePreference = chkRememberIgnoreWhiteSpacePreference.Checked;
            AppSettings.OmitUninterestingDiff = chkOmitUninterestingDiff.Checked;
            AppSettings.RememberShowEntireFilePreference = chkRememberShowEntireFilePreference.Checked;
            AppSettings.RememberShowNonPrintingCharsPreference = chkRememberShowNonPrintingCharsPreference.Checked;
            AppSettings.RememberNumberOfContextLines = chkRememberNumberOfContextLines.Checked;
            AppSettings.RememberShowSyntaxHighlightingInDiff = chkRememberShowSyntaxHighlightingInDiff.Checked;
            AppSettings.OpenSubmoduleDiffInSeparateWindow = chkOpenSubmoduleDiffInSeparateWindow.Checked;
            AppSettings.AutomaticContinuousScroll = chkContScrollToNextFileOnlyWithAlt.Checked;
            AppSettings.ShowDiffForAllParents = chkShowDiffForAllParents.Checked;
            AppSettings.DiffVerticalRulerPosition = (int)VerticalRulerPosition.Value;
        }

        public static SettingsPageReference GetPageReference()
        {
            return new SettingsPageReferenceByType(typeof(DiffViewerSettingsPage));
        }
    }
}
