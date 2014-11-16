VSDiffMergeR
============
Tool to remove the read-only attribute from files before passing them to
vsdiffmerge.exe.

This is needed since vsdiffmerge.exe silently fails if a file is read-only.
TortoiseGit is one such tool which generates read-only files.
