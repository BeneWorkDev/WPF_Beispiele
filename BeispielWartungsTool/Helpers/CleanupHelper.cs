
using BeispielWartungsTool.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace BeispielWartungsTool.Helpers
{
    public static class CleanupHelper
    {
        public static List<CleanablePath> GetCommonPaths()
        {
            string user = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            return new List<CleanablePath>
            {
                new CleanablePath { Name = "Windows Temp", Path = Path.GetTempPath() },
                new CleanablePath { Name = "User Temp", Path = Path.Combine(user, "AppData", "Local", "Temp") },
                new CleanablePath { Name = "Downloads", Path = Path.Combine(user, "Downloads") },
                new CleanablePath { Name = "Recycle Bin", Path = "recyclebin://" }, // handled separately
            };
        }

        public static List<string> CleanPath(string path)
        {
            List<string> deleted = new List<string>();

            if (path == "recyclebin://")
            {
                try
                {
                    Shell32.SHEmptyRecycleBin(IntPtr.Zero, null, Shell32.RecycleFlags.SHERB_NOCONFIRMATION);
                    deleted.Add("Recycle Bin geleert");
                }
                catch (Exception ex)
                {
                    deleted.Add($"Fehler beim Leeren des Papierkorbs: {ex.Message}");
                }
                return deleted;
            }

            if (!Directory.Exists(path)) 
                return deleted;

            try
            {
                var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    try
                    {
                        File.Delete(file);
                        deleted.Add($"Datei gelöscht: {file}");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        deleted.Add($"Zugriff verweigert (Datei): {file}");
                    }
                    catch (IOException ex)
                    {
                        deleted.Add($"IO-Fehler (Datei): {file} – {ex.Message}");
                    }
                }

                var dirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
                foreach (var dir in dirs.Reverse()) // Wichtig: erst tiefste Ordner löschen
                {
                    try
                    {
                        Directory.Delete(dir, true);
                        deleted.Add($"Ordner gelöscht: {dir}");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        deleted.Add($"Zugriff verweigert (Ordner): {dir}");
                    }
                    catch (IOException ex)
                    {
                        deleted.Add($"IO-Fehler (Ordner): {dir} – {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                deleted.Add($"Fehler in Pfad: {path} – {ex.Message}");
            }

            try
            {
                Shell32.SHEmptyRecycleBin(IntPtr.Zero, null, Shell32.RecycleFlags.SHERB_NOCONFIRMATION);

                // ⇨ Ansicht des Recycle Bins aktualisieren
                Shell32.SHChangeNotify(
                    Shell32.SHCNE_ASSOCCHANGED,
                    Shell32.SHCNF_IDLIST | Shell32.SHCNF_FLUSH,
                    IntPtr.Zero,
                    IntPtr.Zero
                );

                deleted.Add("Recycle Bin geleert und aktualisiert");
            }
            catch (Exception ex)
            {
                deleted.Add($"Fehler beim Leeren des Papierkorbs: {ex.Message}");
            }

            return deleted;
        }
    }

    // Add reference to Shell32.dll via COM
    internal class Shell32
    {
        [Flags]
        public enum RecycleFlags : int
        {
            SHERB_NOCONFIRMATION = 0x00000001,
            SHERB_NOPROGRESSUI = 0x00000002,
            SHERB_NOSOUND = 0x00000004
        }

        [System.Runtime.InteropServices.DllImport("Shell32.dll")]
        public static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);


        [DllImport("Shell32.dll")]
        public static extern void SHChangeNotify(
        int wEventId,
        int uFlags,
        IntPtr dwItem1,
        IntPtr dwItem2);

        // Konstanten:
        public const int SHCNE_ALLEVENTS = 0x7FFFFFFF;
        public const int SHCNE_UPDATEITEM = 0x00002000;
        public const int SHCNE_ASSOCCHANGED = 0x08000000;
        public const int SHCNF_IDLIST = 0x0000;
        public const int SHCNF_FLUSH = 0x1000;
        public const int SHCNF_FLUSHNOWAIT = 0x2000;
    }
}
