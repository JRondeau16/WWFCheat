// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace WWFCheat
{
	[Register ("WWFCheatViewController")]
	partial class WWFCheatViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnGenerate { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIScrollView scrollviewResults { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtfieldLetters { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView txtviewResults { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtviewTiles { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnGenerate != null) {
				btnGenerate.Dispose ();
				btnGenerate = null;
			}

			if (scrollviewResults != null) {
				scrollviewResults.Dispose ();
				scrollviewResults = null;
			}

			if (txtfieldLetters != null) {
				txtfieldLetters.Dispose ();
				txtfieldLetters = null;
			}

			if (txtviewResults != null) {
				txtviewResults.Dispose ();
				txtviewResults = null;
			}

			if (txtviewTiles != null) {
				txtviewTiles.Dispose ();
				txtviewTiles = null;
			}
		}
	}
}
