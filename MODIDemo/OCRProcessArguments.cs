using System;

namespace DocumentProcessing
{
	/// <summary>
	/// Representation for the MODI OCR arguments
	/// </summary>
	public class MODIOCRArguments
	{
		private MODI.MiLANGUAGES _language = MODI.MiLANGUAGES.miLANG_SYSDEFAULT;
		public MODI.MiLANGUAGES Language 
		{
			get {return _language;}
			set {_language = value;}
		}
		private bool _withAutoRotation = true;
		public bool WithAutoRotation
		{
			get {return _withAutoRotation;}
			set {_withAutoRotation = value;}
		}
		private bool _WithStraightenImage = true;
		public bool WithStraightenImage
		{
			get {return _WithStraightenImage;}
			set {_WithStraightenImage = value;}
		}
	}

}
