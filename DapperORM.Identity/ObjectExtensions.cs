﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Identity
{
    internal static class ObjectExtensions
    {
        internal static void ThrowIfNull<T>(this T @object, string paramName)
        {
            if (@object == null)
            {
                throw new ArgumentNullException(paramName, $"Parameter {paramName} cannot be null.");
            }
        }
    }
}
