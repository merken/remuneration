﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Common
{
    public interface ICalculationContext
    {
        double AmountForCalculationArea { get; set; }
    }
}
