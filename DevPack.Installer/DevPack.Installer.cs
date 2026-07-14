/*
***********************************************
*  Copyright (c), Skyline Communications NV.  *
***********************************************

Revision History:

DATE		VERSION		AUTHOR			COMMENTS

14. 07. 2026	1.0.0.1		DSA, Skyline	Initial version
****************************************************************************
*/

using System;

using DevPack.Installer;

using Skyline.AppInstaller;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.AppPackages;

/// <summary>
/// DataMiner Script Class.
/// </summary>
internal class Script
{
	/// <summary>
	/// The script entry point.
	/// </summary>
	/// <param name="engine">Provides access to the Automation engine.</param>
	/// <param name="context">Provides access to the installation context.</param>
	[AutomationEntryPoint(AutomationEntryPointType.Types.InstallAppPackage)]
	public void Install(IEngine engine, AppInstallContext context)
	{
		try
		{
			engine.Timeout = new TimeSpan(0, 10, 0);
			engine.GenerateInformation("Starting installation");
			var solutionInstaller = new SolutionInstaller(engine, context);
			solutionInstaller.InstallDefaultContent();
			solutionInstaller.InstallDom();
		}
		catch (Exception e)
		{
			engine.ExitFail($"Exception encountered during installation: {e}");
		}
	}
}
