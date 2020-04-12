using System;
using EncapsulateCompositeWithBuilder.MyWork;
using NUnit.Framework;

namespace RefactoringToPatterns.EncapsulateCompositeWithBuilder.MyWork
{
    public class TagBuilderTest
    {
        [Test]
        public void shouldBuildOneNodeWhenNewBuilderGivenRootName()
        {
            const string flavors = "flavors";
            var expectedXml = $"<{flavors}></{flavors}>";
            var actualXml = new TagBuilder(flavors).ToXml();
            Assert.AreEqual(expectedXml, actualXml);
        }

        [Test]
        public void shouldBuildChildWhenAddChildGivenChildName()
        {
            const string rootName = "Root";
            const string childName = "Child";
            var expectedXml = $"<{rootName}><{childName}></{childName}></{rootName}>";
            var actualXml = new TagBuilder(rootName).AddChild(childName).ToXml();
            Assert.AreEqual(expectedXml, actualXml);
        }

        [Test]
        public void shouldBuildSiblingNodeWhenAddSiblingNodeGivenSiblingNodeName()
        {
            const string rootName = "Root";
            const string childName = "Child";
            const string childName2 = "Child2";
            var expectedXml = $"<{rootName}><{childName}></{childName}><{childName2}></{childName2}></{rootName}>";
            var actualXml = new TagBuilder(rootName).AddChild(childName).AddSibling(childName2).ToXml();
            Assert.AreEqual(expectedXml, actualXml);
        }

        [Test]
        public void shouldBuildChildWithAttrWhenAddChildWithAttrGivenNodeNameAddAttrNameAndValue()
        {
            const string rootName = "Root";
            const string childName = "Child";
            const string attrName = "attrName";
            const string attrValue = "attrValue";
            var expectedXml = $"<{rootName}><{childName} {attrName}='{attrValue}'></{childName}></{rootName}>";
            var actualXml = new TagBuilder(rootName).AddChildWithAttr(childName,attrName,attrValue).ToXml();
            Assert.AreEqual(expectedXml, actualXml); 
        }
        [Test]
        public void shouldBuildRootWithAttrWhenNewWithAttrGivenNodeNameAddAttrNameAndValue()
        {
            const string rootName = "Root";
            const string attrName = "attrName";
            const string attrValue = "attrValue";
            var expectedXml = $"<{rootName} {attrName}='{attrValue}'></{rootName}>";
            var actualXml = new TagBuilder(rootName,attrName,attrValue).ToXml();
            Assert.AreEqual(expectedXml, actualXml); 
        }
        [Test]
        public void shouldBuildRootWithAttrWhenNewWithAttrAndValueGivenNodeNameAddAttrNameAndValueAndValue()
        {
            const string rootName = "Root";
            const string attrName = "attrName";
            const string attrValue = "attrValue";
            const string value = "2.96";
            var expectedXml = $"<{rootName} {attrName}='{attrValue}'>{value}</{rootName}>";
            var actualXml = new TagBuilder(rootName,attrName,attrValue,value).ToXml();
            Assert.AreEqual(expectedXml, actualXml); 
        }
    }
}