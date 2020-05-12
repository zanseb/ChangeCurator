using System;
using System.Collections.Generic;
using System.Text;
using ChangeCurator.SDK.Core;

namespace ChangeCurator.SDK.Models
{
    public class ChangeLogEntry
    {
        public string Description { get; set; }

        public string Author { get; set; }

        public string IssueId { get; set; }

        public EntryType Type { get; set; }

        public ChangeLogEntry()
        {

        }

        public ChangeLogEntry(string description, string author, string issueId, EntryType entryType)
        {
            Description = description;
            Author = author;
            IssueId = issueId;
            Type = entryType;
        }
    }
}
