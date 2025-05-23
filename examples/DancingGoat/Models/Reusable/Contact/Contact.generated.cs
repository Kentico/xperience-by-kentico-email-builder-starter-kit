//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at https://docs.xperience.io/.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using CMS.ContentEngine;

namespace DancingGoat.Models
{
	/// <summary>
	/// Represents a content item of type <see cref="Contact"/>.
	/// </summary>
	[RegisterContentTypeMapping(CONTENT_TYPE_NAME)]
	public partial class Contact : IContentItemFieldsSource
	{
		/// <summary>
		/// Code name of the content type.
		/// </summary>
		public const string CONTENT_TYPE_NAME = "DancingGoat.Contact";


		/// <summary>
		/// Represents system properties for a content item.
		/// </summary>
		[SystemField]
		public ContentItemFields SystemFields { get; set; }


		/// <summary>
		/// ContactName.
		/// </summary>
		public string ContactName { get; set; }


		/// <summary>
		/// ContactStreet.
		/// </summary>
		public string ContactStreet { get; set; }


		/// <summary>
		/// ContactCity.
		/// </summary>
		public string ContactCity { get; set; }


		/// <summary>
		/// ContactCountry.
		/// </summary>
		public string ContactCountry { get; set; }


		/// <summary>
		/// ContactUSState.
		/// </summary>
		public string ContactUSState { get; set; }


		/// <summary>
		/// ContactZipCode.
		/// </summary>
		public string ContactZipCode { get; set; }


		/// <summary>
		/// ContactPhone.
		/// </summary>
		public string ContactPhone { get; set; }


		/// <summary>
		/// ContactEmail.
		/// </summary>
		public string ContactEmail { get; set; }
	}
}