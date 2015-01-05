VSDiffMergeR
============
Tool to remove the read-only attribute from files before passing them to
vsdiffmerge.exe.

This is needed since vsdiffmerge.exe silently fails if a file is read-only.
TortoiseGit is one such tool which generates read-only files.

Usage
============
1. Install TortoiseGit.
2. Right-click an Explorer window, click TortoiseGit\Settings.
3. Select the Diff Viewer node.
4. Click the External radio button, then set the path to:
   "<path>\VSDiffMergeR.exe" /t %base %mine
