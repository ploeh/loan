﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;

namespace Ploeh.Samples.Loan
{
    public interface IMortgageApplicationSpecification
    {
        bool IsSatisfiedBy(MortgageApplication application);
    }
}
