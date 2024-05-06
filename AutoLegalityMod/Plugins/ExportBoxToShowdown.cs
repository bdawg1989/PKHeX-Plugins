using System;
using System.Windows.Forms;
using AutoModPlugins.Properties;
using PKHeX.Core;
using PKHeX.Core.AutoMod;

namespace AutoModPlugins
{
    public class ExportBoxToShowdown : AutoModPlugin
    {
        public override string Name => "Export Box to ALM Showdown Template";
        public static string Name2 => "Export Active to ALM Showdown Template";
        public override int Priority => 1;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name) { Image = Resources.exportboxtoshowdown };
            ctrl.Click += (_, _) => Export(SaveFileEditor);
            ctrl.Name = "Menu_ExportBoxtoShowdown";
            modmenu.DropDownItems.Add(ctrl);
            var ctrl2 = new ToolStripMenuItem(Name2) { Image = Resources.exportboxtoshowdown };
            ctrl2.Click += (_, _) => Export2();
            ctrl2.Name = "Menu_ExportActivetoShowdown";
            modmenu.DropDownItems.Add(ctrl2);
        }

        private static void Export(ISaveFileProvider provider)
        {
            try
            {
                var str = provider.GetRegenSetsFromBoxCurrent();
                if (string.IsNullOrWhiteSpace(str))
                {
                    return;
                }

                Clipboard.SetText(str);
                WinFormsUtil.Alert("Exported the active box in RegenTemplate format to clipboard.");
            }
            catch (Exception e)
            {
                WinFormsUtil.Error("Unable to export text to clipboard.", e.Message);
            }
        }
        public void Export2()
        {
            try
            {
                var str = PKMEditor.PreparePKM().GetRegenText();
                if (string.IsNullOrWhiteSpace(str))
                {
                    return;
                }

                Clipboard.SetText(str);
                WinFormsUtil.Alert("Exported the active box in RegenTemplate format to clipboard.");
            }
            catch (Exception e)
            {
                WinFormsUtil.Error("Unable to export text to clipboard.", e.Message);
            }
        }
    }
}
