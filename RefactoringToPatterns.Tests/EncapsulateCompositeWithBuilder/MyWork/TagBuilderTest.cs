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
            var builder = new TagBuilder(rootName);
            builder.AddChild(childName);
            var actualXml = builder.ToXml();
            Assert.AreEqual(expectedXml, actualXml);
        }

        [Test]
        public void shouldBuildSiblingNodeWhenAddSiblingNodeGivenSiblingNodeName()
        {
            const string rootName = "Root";
            const string childName = "Child";
            const string childName2 = "Child2";
            var expectedXml = $"<{rootName}><{childName}></{childName}><{childName2}></{childName2}></{rootName}>";
           var builder = new TagBuilder(rootName); 
           builder.AddChild(childName);
           builder.AddSibling(childName2);
           var actualXml = builder.ToXml();
           Assert.AreEqual(expectedXml,actualXml);
        }
    }
}