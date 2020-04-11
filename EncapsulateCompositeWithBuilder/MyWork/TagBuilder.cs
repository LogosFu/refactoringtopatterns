using System;

namespace EncapsulateCompositeWithBuilder.MyWork
{
    public class TagBuilder
    {
        private readonly TagNode _rootNode;
        private TagNode _currentNode;

        public TagBuilder(string rootName)
        {
            _rootNode = new TagNode(rootName);
            _currentNode = _rootNode;
        }

        public string ToXml()
        {
            return _rootNode.ToString();
        }

        public void AddChild(string childName)
        {
            var parentNode = _currentNode;
            AddTo(childName, parentNode);
        }

        public void AddSibling(string childName)
        {
            var parentNode = _currentNode.parentNode;
            AddTo(childName, parentNode);
        }

        private void AddTo(string childName, TagNode parentNode)
        {
            _currentNode = new TagNode(childName);
            parentNode.Add(_currentNode);
        }
    }
}