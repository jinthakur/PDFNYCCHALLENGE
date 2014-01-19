using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using DocumentProcessing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;

namespace DocumentProcessing
{
	/// <summary>
	///  Representation of the MODI Search arguments
	/// </summary>
	public class MODISearchArguments
	{
		[Description("The word or phrase to search for.")]
		public string Pattern
		{
			get {return _pattern;}
			set { _pattern = value;}
		}
		private string _pattern = "";

		[Description("The zero-based page number to search.")]
		public int PageNum
		{
			get {return _PageNum;}
			set { _PageNum = value;}
		}
		private int _PageNum = 0;

		[Description("The zero-based index of the word at which to begin the search.")]
		public int WordIndex
		{
			get {return _WordIndex;}
			set { _WordIndex = value;}
		}
		private int _WordIndex = 0;
			
		[Description("A Boolean value that specifies whether to start on or after the specified WordIndex.")]
		public bool StartAfterIndex
		{
			get {return _StartAfterIndex;}
			set { _StartAfterIndex = value;}
		}
		private bool _StartAfterIndex = true;
	
		[Description("A Boolean value that specifies whether to search forward or backward.")]
		public bool Backward
		{
			get {return _Backward;}
			set { _Backward = value;}
		}
		private bool _Backward = false;
		
		[Description("Optional Boolean. Default is True.")]
		public bool MatchMinus
		{
			get {return _MatchMinus;}
			set { _MatchMinus = value;}
		}
		private bool _MatchMinus = true;

		[Description("Optional Boolean. Default is true.")]
		public bool MatchFullHalfWidthForm
		{
			get {return _MatchFullHalfWidthForm;}
			set { _MatchFullHalfWidthForm = value;}
		}
		private bool _MatchFullHalfWidthForm = true;

		[Description("Optional Boolean. Default is true.")]
		public bool MatchHiraganaKatakana
		{
			get {return _MatchHiraganaKatakana;}
			set { _MatchHiraganaKatakana = value;}
		}
		private bool _MatchHiraganaKatakana = true;

		[Description("Optional Boolean. Specifies whether to ignore spaces in the recognized text when searching for the specified word or phrase. Default is true.")]
		public bool IgnoreSpace
		{
			get {return _IgnoreSpace;}
			set { _IgnoreSpace = value;}
		}
		private bool _IgnoreSpace = true;
	}

}
