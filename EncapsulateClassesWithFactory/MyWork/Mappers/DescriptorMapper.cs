using System;
using System.Collections.Generic;
using EncapsulateClassesWithFactory.MyWork.Descriptors;
using EncapsulateClassesWithFactory.MyWork.Domain;

namespace EncapsulateClassesWithFactory.MyWork.Mappers
{
    public class DescriptorMapper
    {
        protected List<AttributeDescriptor> CreateAttributeDescriptors()
        {
            var result = new List<AttributeDescriptor>();

            result.Add(AttributeDescriptor.ForInteger("remoteId", GetClass()));
            result.Add(AttributeDescriptor.ForDate("createDate", GetClass()));
            result.Add(AttributeDescriptor.ForDate("lastChangedDate", GetClass()));
            result.Add(new ReferenceDescriptor("createdBy", GetClass(), typeof(User)));
            result.Add(new ReferenceDescriptor("lastChangedBy", GetClass(), typeof(User)));
            result.Add(AttributeDescriptor.ForInteger("optimisticLockVersion", GetClass()));
            return result;
        }

        private Type GetClass()
        {
            return typeof(DescriptorMapper);
        }
    }
}