using Foundation;
using UIKit;
using Flex;

namespace FlexSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register("AppDelegate")]
	public class AppDelegate : UIResponder, IUIApplicationDelegate
	{
		[Export("applicationDidFinishLaunching:")]
		public void FinishedLaunching(UIApplication application)
		{
#if DEBUG
			FLEXManager sharedManager = new FLEXManager();
			sharedManager.NetworkDebuggingEnabled = true;

#endif
		}


	}
}
