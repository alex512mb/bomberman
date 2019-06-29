using System.Collections.Generic;

namespace Bomberman
{
    /// <summary>
    /// Collect tag componets for easy and fast access to it
    /// </summary>
    public static class TagCollector
    {
        private static Dictionary<string, List<Tag>> tags = new Dictionary<string, List<Tag>>();
        public static event System.Action<string> OnRemovedTag;

        public static int GetCountTagedObjects(string tag)
        {
            if (tags.ContainsKey(tag))
            {
                return tags[tag].Count;
            }
            else
            {
                return 0;
            }
        }

        public static void RegistryTag(string tag, Tag tagComponent)
        {
            if (tags.ContainsKey(tag))
            {
                tags[tag].Add(tagComponent);
            }
            else
            {
                tags.Add(tag, new List<Tag>());
                tags[tag].Add(tagComponent);
            }
        }
        public static void UnregistryTag(string tag, Tag tagComponent)
        {
            tags[tag].Remove(tagComponent);
            if (tags[tag].Count == 0)
            {
                tags.Remove(tag);
            }

            if (OnRemovedTag != null)
            {
                OnRemovedTag(tag);
            }
        }
    }
}
