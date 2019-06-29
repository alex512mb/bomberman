using UnityEngine;


namespace Bomberman
{
    public class TagSearcher : ObjectSearcher
    {
        public string searchingTag;
        public override GameObject FindObject()
        {
            return GameObject.FindGameObjectWithTag(searchingTag);
        }
    }
}
