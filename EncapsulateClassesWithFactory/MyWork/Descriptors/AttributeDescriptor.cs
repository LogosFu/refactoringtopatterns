using System;

namespace EncapsulateClassesWithFactory.MyWork.Descriptors
{
    public class AttributeDescriptor
    {
        readonly string descriptorName;
        readonly Type mapperType;
        readonly Type forType;

        protected AttributeDescriptor(string descriptorName, Type mapperType, Type forType)
        {
            this.descriptorName = descriptorName;
            this.mapperType = mapperType;
            this.forType = forType;
        }

        public string DescriptorName => descriptorName;

        public static AttributeDescriptor ForInteger(string attr, Type type)
        {
            return new DefaultDescriptor(attr, type, typeof(int));
        }

        public static AttributeDescriptor ForDate(string attr, Type type)
        {
            return new DefaultDescriptor(attr, type, typeof(DateTime));
        }
    }
}