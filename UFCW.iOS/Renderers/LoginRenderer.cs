using Xamarin.Forms;
using UXDivers.Artina.Shared;

namespace UXDivers.Artina.Grial
{
	public sealed class LoginRenderer: ArtinaPageRenderer
	{
		protected override string GetTallImage(){
			return "login_background-568h.jpg";
		}

		protected override string GetStandardImage(){
			return "login_background.jpg";
		}
	}
}