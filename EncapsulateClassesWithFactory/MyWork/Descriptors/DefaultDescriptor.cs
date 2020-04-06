using System;

namespace EncapsulateClassesWithFactory.MyWork.Descriptors
{
    public class DefaultDescriptor : AttributeDescriptor
    {
        protected internal DefaultDescriptor(string descriptorName, Type mapperType, Type forType)
            : base(descriptorName, mapperType, forType)
        {
        }
    }
}