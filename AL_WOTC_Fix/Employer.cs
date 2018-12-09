using System;

namespace AL_WOTC_Fix
{
	/// <summary>
	/// Class:	Employer
	/// Use:	Read and store employer information. (EIN, Address, Phone, etc.)
	/// </summary>
	public class Employer
	{
		// CONSULTANT EF
		public readonly string EF_NAME = "Efficient Forms, LLC";
		public readonly string EF_ADDRESS = "10499 West Bradford Rd, Suite 102";
		public readonly string EF_CITY = "Littleton";
		public readonly string EF_STATE = "CO";
		public readonly string EF_ZIP = "80127";
		public readonly string EF_PHONE = "3037858600";
		public readonly string EF_FAX = "3034849586";
		public readonly string EF_EMAIL = "wotc@efficientforms.com";
		public readonly string EF_SIGNER = "Dave Kenney";
		public readonly string EF_SIGNER_TITLE = "Dir WOTC Operations";

		// CONSULTANT NTC
		public readonly string NTC_NAME = "National Tax Credit";
		public readonly string NTC_ADDRESS = "1025 Rose Creek Dr PO Box 620-324";
		public readonly string NTC_CITY = "Woodstock";
		public readonly string NTC_STATE = "GA";
		public readonly string NTC_ZIP = "30189";
		public readonly string NTC_PHONE = "8664996356";
		public readonly string NTC_FAX = "4043934468";
		public readonly string NTC_EMAIL = "aankele@ntcusa.com";
		public readonly string NTC_SIGNER = "Stephen Johnstone";
		public readonly string NTC_SIGNER_TITLE = "WOTC Coordinator";

		// Input validation
		public readonly string VALID_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789//";


		// Variables
		private string fein;
		private string name;
		private string street1;
		private string street2;
		private string city;
		private string state;
		private string zipCode;
		private string phone;
		private Consultant thisConsultant;

		public string Fein { get => fein; set => fein = value; }
		public string Name { get => name; set => name = value; }
		public string Street1 { get => street1; set => street1 = value; }
		public string Street2 { get => street2; set => street2 = value; }
		public string City { get => city; set => city = value; }
		public string State { get => state; set => state = value; }
		public string ZipCode { get => zipCode; set => zipCode = value; }
		public string Phone { get => phone; set => phone = value; }
		internal Consultant ThisConsultant { get => thisConsultant; set => thisConsultant = value; }


		// TODO: create getters and setters (encapsulate, use field?)

		public Employer()
		{
			// TODO: create Employer public constructor	
		}


		// Validators
		public bool CheckAddress(string street1, string street2)
		{
			// TODO validating CheckAddress() characters

			// Default state is true, updated if either address 1 or 2 fails validation
			bool isReady = true;
			int index = 0;

			foreach (char a in Street1.ToCharArray())
			{
				if (!VALID_CHARACTERS.Contains(a.ToString()))
				{
					Console.WriteLine("Street 1: replaced character " + a.ToString() + " at index " + index + ".");
					Street1.Replace(a, ' ');
				}
				index++;
			}

			Console.WriteLine("Fail on Employer City validation.");
			isReady = false;

			return isReady;
		}

		// Will substitute default phone number is given phone is invalid
		public void CheckPhone(string phone)
		{
			// If phone is not present or invalid (less than 10 chars), substitute consultant phone number 
			if (this.Phone == null || this.Phone.Length < 10)
			{
				// Auto populate default phone num for NTC, EF
				if (ThisConsultant.Name == "NTC") {
					this.Phone = NTC_PHONE;
				} else {
					this.Phone = EF_PHONE;
				}
			}
		}

		// Will pad beginning of FEIN with zeros until it reaches 9 digits
		public void CheckFEIN(string fein)
		{
			fein = AddLeadingZeros(fein, 9);
		}

		// Will pad beginning of Zip with zeros until it reaches 5 digits
		public void CheckZip(string zipcode)
		{
			zipcode = AddLeadingZeros(zipcode, 5);
		}
	}
}
