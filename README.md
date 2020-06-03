# ChangeCurator

Responsible for managing all changelog relevant stuff

[![Nuget](https://img.shields.io/nuget/v/ChangeCurator.CLI)](https://www.nuget.org/packages/ChangeCurator.CLI/)

## What is this?

This tool is heavily inspired by [GitLab's workflow](https://docs.gitlab.com/ee/development/changelog.html) on how to manage a changelog file on a project with multiple contributors.
I often encountered merge conflicts on the main changelog file just because it was changed at the same place by 2 different contributors. This problem was, at least for me, very annoying and led to unnecessary delays.

This tool allows you to create one file per changelog entry and merge them into the main changelog file during the release process, so that conflicts are a thing of the past.

## Usage

Download the tool by executing

```
dotnet tool install --global ChangeCurator.CLI
```

Once installed, initialize the repository in which you want to use this tool

```
cc init -p <project-name> -d <directory-path> -u <issue-tracker-url>
```

After the initialization process you need to commit and push following directories/files
* .cc/
* changelogs/
* CHANGELOG.md

After that, everything is set up in order to use this tool collaboratively within your team.

Every team member can add a new changelog entry on their feature branch by executing

```
cc add -d <description> -i <issue-id>
```

This command generates a separate changelog entry file which needs to be commited.

Once all changes have been merged and you want to generate the final changelog execute

```
cc merge
```

This command merges all changelog entry file into the main changelog file. Update the version and release date and you are ready to go.