using System;

namespace Bomberman.LevelConstructing
{
    public class TagsObserver
    {
        public event Action onCountChanged
        {
            add
            {
                callBack = value;
                TagCollector.OnRemovedTag += OnRemovedRegistredTag;
            }
            remove
            {
                TagCollector.OnRemovedTag -= OnRemovedRegistredTag;
                callBack = null;
            }
        }

        private Action callBack;
        private string targetTag;

        public TagsObserver(string targetTag)
        {
            this.targetTag = targetTag;
        }

        private void OnRemovedRegistredTag(string tag)
        {
            if (string.Equals(tag, targetTag) && TagCollector.GetCountTagedObjects(tag) == 0)
            {
                callBack?.Invoke();
            }
        }

    }
}
