using System.Collections.Generic;

namespace ImageduplicatefinderUI
{
  public class DuplicateGroup
  {
    public string GroupName { get; set; }
    public int FileCount { get; set; }
    public List<ImageInfo> Images { get; set; } = new List<ImageInfo>();
  }
}