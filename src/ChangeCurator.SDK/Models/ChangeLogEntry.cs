using System;
using System.Collections.Generic;
using System.Text;
using ChangeCurator.SDK.Core;

namespace ChangeCurator.SDK.Models
{
    public class ChangeLogEntry
    {
        public string Description { get; }

        public string Author { get; }

        public string IssueId { get; }

        public EntryType Type { get; }

        public ChangeLogEntry(string description, string author, string issueId, EntryType entryType)
        {
            Description = description;
            Author = author;
            IssueId = issueId;
            Type = entryType;
        }
    }
}
