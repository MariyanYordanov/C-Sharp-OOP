﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public interface IAddRemoveCollection : IAddCollection
    {
        string Remove(string input);
    }
}
