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

        public TagBuilder(string rootName, string attrName, string attrValue)
        {
            _rootNode = new TagNode(rootName);
            _rootNode.AddAttribute(attrName, attrValue);
            _currentNode = _rootNode;
        }

        public TagBuilder(string rootName, string attrName, string attrValue, string value)
        {
            _rootNode = new TagNode(rootName);
            _rootNode.AddAttribute(attrName, attrValue);
            _rootNode.AddValue(value);
            _currentNode = _rootNode;
        }

        public string ToXml()
        {
            return _rootNode.ToString();
        }

        public TagBuilder AddChild(string childName)
        {
            var parentNode = _currentNode;
            AddTo(childName, parentNode);
            return this;
        }

        public TagBuilder AddSibling(string childName)
        {
            var parentNode = _currentNode.parentNode;
            AddTo(childName, parentNode);
            return this;
        }

        private void AddTo(string childName, TagNode parentNode)
        {
            _currentNode = new TagNode(childName);
            parentNode.Add(_currentNode);
        }

        public TagBuilder AddChildWithAttr(string childName, string attrName, string attrValue)
        {
            var parentNode = _currentNode;
            _currentNode = new TagNode(childName);
            _currentNode.AddAttribute(attrName, attrValue);
            parentNode.Add(_currentNode);
            return this;
        }
    }
}