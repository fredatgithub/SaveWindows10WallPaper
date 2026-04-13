using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ImageduplicatefinderLib
{
  public class ImageDuplicateFinder
  {
    // Extensions supportées par défaut
    private static readonly HashSet<string> DefaultExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".jpg", ".jpeg", ".png", ".bmp", ".gif"
        };

    /// <summary>
    /// Parcourt récursivement le dossier, calcule le hash MD5 de chaque image supportée,
    /// et retourne les groupes de fichiers identiques (>= 2).
    /// </summary>
    public async Task<List<List<string>>> FindDuplicatesAsync(string directory, IEnumerable<string> extensions = null)
    {
      if (string.IsNullOrWhiteSpace(directory) || !Directory.Exists(directory))
      {
        throw new DirectoryNotFoundException($"Le répertoire '{directory}' n'existe pas.");
      }

      var exts = extensions != null
          ? new HashSet<string>(extensions, StringComparer.OrdinalIgnoreCase)
          : DefaultExtensions;

      return await Task.Run(() =>
      {
        // Récupère tous les fichiers avec extensions valides
        var files = Directory
            .EnumerateFiles(directory, "*.*", SearchOption.AllDirectories)
            .Where(f => exts.Contains(Path.GetExtension(f)))
            .ToList();

        var hashToFiles = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        using (var md5 = MD5.Create())
        {
          foreach (var file in files)
          {
            try
            {
              using (var stream = File.OpenRead(file))
              {
                var hashBytes = md5.ComputeHash(stream);
                var hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", "")
                    .ToLowerInvariant();

                if (!hashToFiles.TryGetValue(hash, out var list))
                {
                  list = new List<string>();
                  hashToFiles[hash] = list;
                }

                list.Add(file);
              }
            }
            catch
            {
              // ignore inaccessible files
            }
          }
        }

        // On ne garde que les groupes de doublons (2 fichiers ou plus)
        return hashToFiles.Values
            .Where(g => g.Count > 1)
            .Select(g => g.ToList())
            .ToList();
      });
    }
  }
}