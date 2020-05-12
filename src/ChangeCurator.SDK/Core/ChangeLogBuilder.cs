using System;
using System.Collections.Generic;
using System.Text;
using ChangeCurator.SDK.Models;

namespace ChangeCurator.SDK.Core
{
    internal class ChangeLogBuilder
    {
        internal ChangeLogBuilder WithContent(string sourceContent)
        {
            return this;
        }

        internal ChangeLogBuilder WithEntries(IEnumerable<ChangeLogEntry> entries)
        {
            return this;
        }

        internal string Build()
        {
            throw new NotImplementedException();
        }
    }
}
