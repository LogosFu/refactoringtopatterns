using System;
using NUnit.Framework;
using EncapsulateCompositeWithBuilder.MyWork;

namespace RefactoringToPatterns.EncapsulateCompositeWithBuilder.MyWork
{
    [TestFixture]
    public class TagNodeTests
    {
        private const string SamplePrice = "2.39";

        [Test]
        public void TestSimpleTagWithOneAttributeAndValue()
        {
            var expected =
                "<price currency=" +
                "'" +
                "USD" +
                "'>" +
                SamplePrice +
                "</price>";

           string acutal = new TagBuilder("price","currency","USD",SamplePrice).ToXml(); 
   
            Assert.AreEqual(expected, acutal);
        }

        [Test]
        public void TestCompositeTagoneChild()
        {
            var expected =
                "<product>" +
                "<price>" +
                "</price>" +
                "</product>";

            string actual = new TagBuilder("product").AddChild("price").ToXml();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestAddingChildrenAndGrandChildren()
        {
            var expected =
                "<orders>" +
                "<order>" +
                "<product>" +
                "</product>" +
                "</order>" +
                "</orders>";

            TagNode ordersTag = new TagNode("orders");
            TagNode orderTag = new TagNode("order");
            orderTag.Add(new TagNode("product"));
            ordersTag.Add(orderTag);
            string actual = new TagBuilder("orders").AddChild("order").AddChild("product").ToXml();

            Assert.AreEqual(expected, actual);
        }
    }
}