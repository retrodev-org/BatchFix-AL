using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_WOTC_Fix
{
	public class Consultant
	{
		// CONSULTANT EF
		public const string EF_NAME				= "Efficient Forms, LLC";
		public const string EF_ADDRESS			= "10499 West Bradford Rd, Suite 102";
		public const string EF_CITY				= "Littleton";
		public const string EF_STATE			= "CO";
		public const string EF_ZIP				= "80127";
		public const string EF_PHONE			= "3037858600";
		public const string EF_FAX				= "3034849586";
		public const string EF_EMAIL			= "wotc@efficientforms.com";
		public const string EF_SIGNER			= "Dave Kenney";
		public const string EF_SIGNER_TITLE		= "Dir WOTC Operations";

		// CONSULTANT NTC
		public const string NTC_NAME			= "National Tax Credit";
		public const string NTC_ADDRESS			= "1025 Rose Creek Dr PO Box 620-324";
		public const string NTC_CITY			= "Woodstock";
		public const string NTC_STATE			= "GA";
		public const string NTC_ZIP				= "30189";
		public const string NTC_PHONE			= "8664996356";
		public const string NTC_FAX				= "4043934468";
		public const string NTC_EMAIL			= "aankele@ntcusa.com";
		public const string NTC_SIGNER			= "Stephen Johnstone";
		public const string NTC_SIGNER_TITLE	= "WOTC Coordinator";
		
		private string name;
		private string address;
		private string city;
		private string state;
		private string zipCode;
		private string phone;
		private string fax;
		private string email;
		private string signerName;
		private string signerTitle;

		Consultant(string consultantName)
		{

			if (consultantName == "EF")
			{
				// Assign values based on public constant strings for each company
				Name = EF_NAME;
				Address = EF_ADDRESS;
				City = EF_CITY;
				State = EF_STATE;
				ZipCode = EF_ZIP;
				Phone = EF_PHONE;
				Fax = EF_FAX;
				Email = EF_EMAIL;
				SignerName = EF_SIGNER;
				SignerTitle = EF_SIGNER_TITLE;
				
			} else if (consultantName == "NTC")
			{
				// Assign values based on public constant strings for each company
				Name = NTC_NAME;
				Address = NTC_ADDRESS;
				City = NTC_CITY;
				State = NTC_STATE;
				ZipCode = NTC_ZIP;
				Phone = NTC_PHONE;
				Fax = NTC_FAX;
				Email = NTC_EMAIL;
				SignerName = NTC_SIGNER;
				SignerTitle = NTC_SIGNER_TITLE;
			}
			else
			{
				// todo error message for invalid consultant
				Console.WriteLine("Invalid consultant company name. Must be EF or NTC.");
			}
		}

		public string Name { get => name; set => name = value; }
		public string Address { get => address; set => address = value; }
		public string City { get => city; set => city = value; }
		public string State { get => state; set => state = value; }
		public string ZipCode { get => zipCode; set => zipCode = value; }
		public string Phone { get => phone; set => phone = value; }
		public string Fax { get => fax; set => fax = value; }
		public string Email { get => email; set => email = value; }
		public string SignerName { get => signerName; set => signerName = value; }
		public string SignerTitle { get => signerTitle; set => signerTitle = value; }
	}
}
