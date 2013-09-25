using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace WWFCheat
{
	public partial class WWFCheatViewController : UIViewController
	{
		public WWFCheatViewController () : base ("WWFCheatViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//this will be called whenever whenever the generate button is pressed
			//It will trigger the testing of the user input
			this.btnGenerate.TouchUpInside += delegate {
				string user_input = this.txtfieldLetters.Text;
				int blank_tiles = 0;
				if(this.txtviewTiles.HasText == true){
					blank_tiles = Convert.ToInt32(this.txtviewTiles.Text);
				}
				Dictionary dictonary = new Dictionary (user_input, blank_tiles);
				dictonary.Test_Input();
				this.txtviewResults.Text = dictonary.Output_Words();
				dictonary.Reset();
				this.txtviewResults.EndEditing(true);
				this.txtfieldLetters.ResignFirstResponder();
				this.txtviewTiles.ResignFirstResponder();
			};

		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}