# ChangeCurator

Responsible for managing all changelog relevant stuff

## What is this?

This tool is heavily inspired by [GitLab's workflow](https://docs.gitlab.com/ee/development/changelog.html) on how to manage a changelog file on a project with multiple contributors.
I often encountered merge conflicts on the main changelog file just because it was changed at the same place by 2 different contributors. This problem was, at least for me, very annoying and led to unnecessary delays.

This tool allows you to create one file per changelog entry and merge them into the main changelog file during the release process, so that conflicts are a thing of the past.
