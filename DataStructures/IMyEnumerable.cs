﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface IMyEnumerable<T>
    {
        IEnumerator<T> GetEnumerator();
    }
}
