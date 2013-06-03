using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ploeh.Samples.Loan
{
    public interface ITimeProvider
    {
        DateTimeOffset GetCurrentTime();
    }
}
