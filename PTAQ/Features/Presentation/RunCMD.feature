Feature: RunCMD

@mytag
Scenario: CMD Example
Given following output directory: C:\TestFilesTarget
	When I copy files from C:\TestFilesSource into output directory
