using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChangeCurator.SDK.Models;

namespace ChangeCurator.SDK.Core
{
    internal class ChangeLogBuilder
    {
        private readonly ProjectSettings settings;
        private StringBuilder content;
        private IEnumerable<ChangeLogEntry> entries;

        public ChangeLogBuilder(ProjectSettings settings)
        {
            content = new StringBuilder();
            this.settings = settings;
        }

        internal ChangeLogBuilder WithContent(string sourceContent)
        {
            if (content.Length != 0)
            {
                throw new InvalidOperationException();
            }

            content.Append(sourceContent);

            return this;
        }

        internal ChangeLogBuilder WithEntries(IEnumerable<ChangeLogEntry> entries)
        {
            this.entries = entries;

            return this;
        }

        internal string Build()
        {
            string unreleasedSection = GenerateUnreleasedSection();

            content.Insert(0, unreleasedSection);

            return content.ToString();
        }

        private string GenerateUnreleasedSection()
        {
            IOrderedEnumerable<ChangeLogEntry> orderedEntries = entries.ToList().OrderBy((k) => k.Type);
            StringBuilder unreleasedSection = new StringBuilder();

            unreleasedSection.AppendLine("## [Unreleased] - YYYY-MM-DD");

            var currentCategory = EntryType.Added;
            var categoryHeaderGenerated = false;
            foreach (var entry in orderedEntries)
            {
                if (currentCategory != entry.Type)
                {
                    unreleasedSection.AppendLine();
                    currentCategory = entry.Type;
                    categoryHeaderGenerated = false;
                }

                if (!categoryHeaderGenerated)
                {
                    switch (entry.Type)
                    {
                        case EntryType.Added:
                            unreleasedSection.AppendLine("### Added");
                            break;
                        case EntryType.Changed:
                            unreleasedSection.AppendLine("### Changed");
                            break;
                        case EntryType.Deprecated:
                            unreleasedSection.AppendLine("### Deprecated");
                            break;
                        case EntryType.Removed:
                            unreleasedSection.AppendLine("### Removed");
                            break;
                        case EntryType.Fixed:
                            unreleasedSection.AppendLine("### Fixed");
                            break;
                        case EntryType.Security:
                            unreleasedSection.AppendLine("### Security");
                            break;
                        default:
                            unreleasedSection.AppendLine("### Unknown");
                            break;
                    }

                    categoryHeaderGenerated = true;
                }

                var issueUrl = $"{settings.IssueUrl.TrimEnd('/')}/{entry.IssueId}";
                unreleasedSection.AppendLine($"- {entry.Description} [{entry.IssueId}]({issueUrl})");
            }

            unreleasedSection.AppendLine();

            return unreleasedSection.ToString();
        }
    }
}
