using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public interface IMyList : IAddRemoveCollection
    {
        int Used { get;}
    }
}
