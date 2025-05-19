using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WartungsTool_v._2.Services
{
    public static class CleanupHelper
    {
        public static List<string> CleanPath(string path)
        {
            List<string> deleted = new List<string>();

            if (path == "recyclebin://")
            {
                try
                {
                    Shell32.SHEmptyRecycleBin(IntPtr.Zero, null, Shell32.RecycleFlags.SHERB_NOCONFIRMATION);
                    Shell32.SHChangeNotify(Shell32.SHCNE_ASSOCCHANGED, Shell32.SHCNF_IDLIST | Shell32.SHCNF_FLUSH, IntPtr.Zero, IntPtr.Zero);
                    deleted.Add("Recycle Bin geleert und aktualisiert");
                }
                catch (Exception ex)
                {
                    deleted.Add($"Fehler beim Leeren des Papierkorbs: {ex.Message}");
                }
                return deleted;
            }

            if (!Directory.Exists(path)) return deleted;

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

                var dirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories).Reverse();
                foreach (var dir in dirs)
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

            return deleted;
        }
    }
}
