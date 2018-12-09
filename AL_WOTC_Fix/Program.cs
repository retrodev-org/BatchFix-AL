/*
 * Created by SharpDevelop.
 * User: wholland
 * Date: 10/26/2018
 * Time: 3:45 PM
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AL_WOTC_Fix
{
	internal class Program
	{
		// TODO globalize logic
		public static void Main(string[] args)
		{
			const string YES = "Y";
			const string NO = "N";
			const string CONSULT_ID_EFFICIENT = "efficient   ";
			const string CONSULT_ID_NTC = "National Tax";

			DateTime dateConvictionDate = DateTime.MinValue;
			DateTime dateReleaseDate = DateTime.MinValue;

			int counter = 0;
			string[] lines = { null };
			var results = new List<string>();

			// Rural Renewal Community checklist
			string[] zipCodesRRC = { null };

			// Empowerment Zone checklist
			string[] empowermentZoneList = { "Tucson", "Tuscon", "Fresno", "Frenso", "Frsno", "LA", "Los Angeles", "LosAngeles",
				"Santa Ana", "Santaana", "Santa Anna", "Chicago", "Chicgo", "East Chicago", "E Chicago", "E. Chicago", "Gary",
				"East St. Louis", "East St Louis", "East Saint Louis", "E St Louis", "E. St. Louis", "Hammond", "Boston",
				"Baltimore", "Detroit", "Detriot", "Minneapolis", "St. Louis", "Camden", "New York", "Syracuse", "Jacksonville", "Jax",
				"Yonkers", "Cincinnati", "Cinci", "Cleveland", "Columbus", "Ironton", "Oklahoma City", "Philadelphia",
				"Columbia", "Sumter", "Knoxville", "Knox", "El Paso", "ElPaso", "San Antonio", "Clifton Forge", "Covington",
				"Norfolk", "Norflk", "Norton", "Portsmouth", "Staunton", "Huntington", "New Haven", "NewHaven" };

			string[] stateList = { "AK","AL","AR","AZ","CA","CO","CT","DC","DE","FL","GA","GU",
				"HI","IA","ID","IL","IN","KS","KY","LA","MA","MD","ME","MI","MN","MO","MS","MT",
				"NC","ND","NE","NH","NJ","NM","NV","NY","OH","OK","OR","PA","PR","RI","SC","SD",
				"TN","TX","UT","VA","VI","VT","WA","WI","WV","WY" };

			string filePathRead = null;
			string filePathWrite = null;
			string tempString = null;
			string thisState = "AL";

			StringBuilder stringb = new StringBuilder(); // build output lines

			var list = new List<string>();

			Console.Title = "Alabama Batch Fixer";

			Console.Write("Please enter the filename: ");
			tempString = Console.ReadLine();

			// Check filename for invalid length, whether it exists, and whether it has a 3 or 4 letter extension
			while (tempString.Length < 4 || !File.Exists(tempString) || (!(tempString.Substring(tempString.Length - 3, 1) == ".") && !(tempString.Substring(tempString.Length - 4, 1) == "."))
				&& tempString != "exit")
			{
				Console.WriteLine("Invalid file name. It must contain at least 1 character plus the file extension. (example: name.txt)");
				Console.WriteLine("Type 'exit' to exit the application.");
				Console.Write("Please enter the filename: ");
				tempString = Console.ReadLine();
			}

			filePathRead = tempString;
			filePathWrite = filePathRead.Remove(filePathRead.LastIndexOf(".")) + "_fix.txt";
			tempString = null;

			try
			{
				var fileStreamRead = new FileStream(filePathRead, FileMode.Open, FileAccess.Read);

				// Read file into array of lines
				using (var streamReader = new StreamReader(fileStreamRead))
				{
					Console.Write("Reading from " + filePathRead + "\n\n");

					try
					{
						string line;
						while ((line = streamReader.ReadLine()) != null)
						{
							list.Add(line);
							counter++;
						}
					}
					catch (Exception e)
					{
						Console.WriteLine("Encountered error reading line " + (counter + 1) + ". Error: " + e.ToString());
					}

					try
					{
						tempString = "streamReader";
						streamReader.Close();
						tempString = "fileStream";
						fileStreamRead.Close();
						tempString = null;
					}
					catch (Exception e)
					{
						Console.Write("Error closing " + tempString + ". " + e);
						tempString = null;
					}

				}
			}
			catch
			{
				Console.WriteLine("File read error. Unable to find or open file:" + filePathRead);
			}

			try
			{
				try
				{
					lines = list.ToArray();
				}
				catch (Exception e)
				{
					Console.WriteLine("Encountered error converting lines to array. Error: " + e.ToString());
				}

				// Parse Data - Alabama

				for (int i = 0; i < list.Count; i++)
				{
					if (thisState == "AL")
					{
						// Assign variables from string
						string consultantID = list[i].Substring(0, 12);
						string fein = list[i].Substring(12, 9);                     // FEIN 9 digits, preserve leading zero
						string ssn = list[i].Substring(21, 9);                      // SSN 9 digits, preserve leading zero
						string employeeFirstName = list[i].Substring(30, 10);
						string employeeMiddleName = list[i].Substring(40, 1);
						string employeeLastName = list[i].Substring(41, 19);
						string employeeStreet1 = list[i].Substring(60, 30);
						string employeeCity = list[i].Substring(90, 20);
						string employeeState = list[i].Substring(110, 2);
						string employeeZip = list[i].Substring(112, 5);
						string employeePhone = list[i].Substring(117, 10);
						string employeeDOB = list[i].Substring(127, 8);             // format mmddccyy
						string katrinaEmployee = list[i].Substring(135, 1);
						string katrinaCounty = list[i].Substring(136, 20);
						string katrinaStreet = list[i].Substring(156, 30);
						string katrinaCity = list[i].Substring(186, 20);
						string katrinaState = list[i].Substring(206, 2);
						string katrinaZip = list[i].Substring(208, 5);
						string deprecated01 = list[i].Substring(213, 1);
						string deprecated02 = list[i].Substring(214, 1);
						string deprecated03 = list[i].Substring(215, 1);
						string deprecated04 = list[i].Substring(216, 1);
						string pinPassword = list[i].Substring(217, 20);
						string signatureOnFile = list[i].Substring(237, 1);
						string dateSignatureEmployee = list[i].Substring(238, 8);   // format mmddccyy
						string targetGroup = list[i].Substring(246, 1);             // 4 or 6
						string dateGaveInfo = list[i].Substring(247, 8);            // format mmddccyy
						string dateOffered = list[i].Substring(255, 8);             // format mmddccyy
						string dateHired = list[i].Substring(263, 8);               // format mmddccyy
						string dateStarted = list[i].Substring(271, 8);             // format mmddccyy
						string jobCounty = list[i].Substring(279, 20);              // Hurricane Katrina relief
						string jobState = list[i].Substring(299, 2);                // Hurricane Katrina relief
						string newEmployee = list[i].Substring(301, 1);             // Hurricane Katrina relief
						string dateSignatureEmployer01 = list[i].Substring(302, 8); // format mmddccyy
						string wage = list[i].Substring(310, 4);                    // preserve leading/trailing zero
						string onetCode = list[i].Substring(314, 2);                // 2 numeric digits
						string rehire = list[i].Substring(316, 1);
						string veteran = list[i].Substring(317, 1);
						string vetDisabled = list[i].Substring(318, 1);
						string vetRecentDischarge = list[i].Substring(319, 1);
						string vetUnemployment = list[i].Substring(320, 1);
						string snap01 = list[i].Substring(321, 1);
						string snap02 = list[i].Substring(322, 1);
						string vocRehab = list[i].Substring(323, 1);
						string ticketToWork = list[i].Substring(324, 1);
						string veteranAffairs = list[i].Substring(325, 1);
						string tanf01 = list[i].Substring(326, 1);
						string tanf02 = list[i].Substring(327, 1);
						string tanf03 = list[i].Substring(328, 1);
						string tanf04 = list[i].Substring(329, 1);
						string primaryRecipientName = list[i].Substring(330, 30);
						string primaryRecipientCity = list[i].Substring(360, 20);
						string primaryRecipientState = list[i].Substring(380, 2);
						string felon = list[i].Substring(382, 1);
						string dateConviction = list[i].Substring(383, 8);
						string dateRelease = list[i].Substring(391, 8);
						string empowermentZone = list[i].Substring(399, 1);
						string ruralRenewalYN = list[i].Substring(400, 1);
						string ruralRenewalCounty = list[i].Substring(401, 20);
						string ssi = list[i].Substring(421, 1);
						string documentSources01 = list[i].Substring(422, 80);
						string documentSources02 = list[i].Substring(502, 80);
						string documentSources03 = list[i].Substring(582, 80);
						string documentSources04 = list[i].Substring(662, 80);
						string consultantYN = list[i].Substring(742, 1);				// C for Consultant or E for Employer
						string dateSignatureEmployer02 = list[i].Substring(743, 8);		// format mmddccyy
						string outOfStateBenefitsCity = list[i].Substring(751, 20);
						string outOfStateBenefitsState = list[i].Substring(771, 2);
						string representativeName = list[i].Substring(773, 12);
						string deprecated05 = list[i].Substring(785, 1);                // ARRA Vet, deprecated 2012
						string deprecated06 = list[i].Substring(786, 1);                // ARRA Youth, deprecated 2012
						string deprecated07 = list[i].Substring(787, 1);                // Vow to Hire Heroes, deprecated 2012
						string version8850 = list[i].Substring(788, 2);                 // 16 = 2016
						string version9061 = list[i].Substring(790, 2);                 // 16 = 2016, 17 = 2017
						string form9062 = list[i].Substring(792, 1);                    // not used as of Oct 2018, assume N
						string question2 = list[i].Substring(793, 1);                   // form 8850 questions 1-6
						string question3 = list[i].Substring(794, 1);
						string question4 = list[i].Substring(795, 1);
						string question5 = list[i].Substring(796, 1);
						string question6 = list[i].Substring(797, 1);
						string convictionType = list[i].Substring(798, 1);              // F = Federal, S = State
						string convictionState = list[i].Substring(799, 2);
						string vetUnemployed6Months = list[i].Substring(801, 1);
						string vetUnemployed4Weeks = list[i].Substring(802, 1);
						string categoryF = list[i].Substring(803, 1);                   // form 9061 question 19
						string dateMailed = list[i].Substring(804, 8);                  // Mail date (only if ok with state for catchup, otherwise blank)
						string longTermUnemploymentYN = list[i].Substring(812, 1);
						string deprecated08 = list[i].Substring(813, 1);
						string question7 = list[i].Substring(814, 1);                   // form 8850 question 7 LTU
						string signatureOnFileForm9175 = list[i].Substring(815, 1);     // not used yet
						string unemployed27ConsecutiveWeeks = list[i].Substring(816, 1);// not used yet
						string unemploymentCompensation = list[i].Substring(817, 1);    // not used yet
						string unemploymentBeginDate = list[i].Substring(818, 8);       // not used yet
						string unemploymentEndDate = list[i].Substring(826, 8);         // not used yet
						string declarationDate = list[i].Substring(834, 8);             // not used yet
						string longTermUnemploymentState = list[i].Substring(842, 2);   // ties to previous long term unemployment fields
						string deprecated09 = list[i].Substring(844, 56);               // not used yet
						string employerNameNew = list[i].Substring(900, 50);            // only for establishing a new employer
						string employerAddressNew = list[i].Substring(950, 30);         // only for establishing a new employer
						string employerAddress2New = list[i].Substring(980, 30);        // only for establishing a new employer
						string employerCityNew = list[i].Substring(1010, 20);           // only for establishing a new employer
						string employerStateNew = list[i].Substring(1030, 2);           // only for establishing a new employer
						string employerZipNew = list[i].Substring(1032, 5);             // only for establishing a new employer
						string employerPhoneNew = list[i].Substring(1037, 10);          // only for establishing a new employer
						string employerPhoneExtNew = list[i].Substring(1047, 4);        // only for establishing a new employer

						// Confirmation Message
						Console.WriteLine("\nRead record " + (i + 1) + ": success.");


						// Begin Logical Processing

						// Check Consultant ID
						if (consultantID == CONSULT_ID_EFFICIENT)
						{
							// use if employer phone is blank, for states that require employer address
							// AL does not request/accept employer address and phone number
						}
						else if (consultantID == CONSULT_ID_NTC)
						{
							// use if employer phone is blank, for states that require employer address
							// AL does not request/accept employer address and phone number
						}
						else
						{
							Console.Write("Record " + (i + 1) + ": Error reading consultant ID. Consultant ID must be 'efficient   ' or 'National Tax'.");
						}

						// Check FEIN
						while (fein.Trim().Length < 9)
						{
							fein = "0" + fein.Trim();
							Console.WriteLine("Record " + (i + 1) + ": Fix FEIN.");
						}


						// Check SSN
						while (ssn.Trim().Length < 9)
						{
							ssn = "0" + ssn.Trim();
							Console.WriteLine("Record " + (i + 1) + ": Fix SSN.");
						}

						// Parse and check gave info/hire/offer/start dates
						try
						{

							if (int.Parse(dateGaveInfo) > int.Parse(dateHired)
								|| int.Parse(dateHired) > int.Parse(dateOffered)
								|| int.Parse(dateOffered) > int.Parse(dateStarted))
							{
								dateGaveInfo = dateStarted;
								dateOffered = dateStarted;
								dateHired = dateStarted;

								Console.WriteLine("Record " + (i + 1) + ": Fix dates for start/hire/offer/gave info.");
							}
						}
						catch (Exception e)
						{
							Console.Write("Record " + (i + 1) + ": Error converting dates to integers in fields Gave Info, Gave Offer, Hired, or Start date. \n" + e.ToString());
						}

						// Check Names
						while (employeeFirstName.Length < 10)
							employeeFirstName = employeeFirstName + " ";
						while (employeeLastName.Length < 19)
							employeeLastName = employeeLastName + " ";
						if (employeeFirstName.Length > 10)
							employeeFirstName = " " + employeeFirstName.Substring(0, 10);
						if (employeeLastName.Length > 19)
							employeeLastName = " " + employeeLastName.Substring(0, 19);
						if (employeeMiddleName.Length > 1)
							employeeMiddleName = " " + employeeMiddleName.Trim().Substring(0, 1);

						// Check employee street address
						while (employeeStreet1.Length < 30)
							employeeStreet1 = employeeStreet1 + " ";
						if (employeeStreet1.Length > 30)
							employeeStreet1 = " " + employeeStreet1.Substring(0, 30);

						// check employee city
						while (employeeCity.Length < 20)
							employeeCity = employeeCity + " ";
						if (employeeCity.Length > 20)
							employeeCity = " " + employeeCity.Substring(0, 20);

						// Check employee state
						tempString = null;
						for (int j = 0; j < stateList.Length; j++)
						{
							if (string.Compare(employeeState, stateList[j], new System.Globalization.CultureInfo("en-US"), System.Globalization.CompareOptions.IgnoreCase) == 0)
								tempString = YES;
						}
						if (tempString != YES)
						{
							Console.WriteLine("Record " + (i + 1) + ": Invalid state abbreviation " + employeeState + " in employee address. Please review. Unable to recover. ");
						}

						// check employee zip code
						while (employeeZip.Length < 5)
							employeeZip = "0" + employeeZip;

						// Check phone
						try
						{
							if (int.Parse(employeePhone) < 999999999)  // if phone number has less than 10 digits
								employeePhone = new string(' ',10);
						}
						catch
						{
							if (employeePhone != new string(' ', 10)) // if phone number is not blank but is also not a valid number
							{
								Console.WriteLine("Record " + (i + 1) + ": Invalid employee phone number '" + employeePhone + "'. Recovered from error. Invalid phone number removed.");
								employeePhone = new string(' ', 10); // sets to blank phone number
							}
						}

						// Set pinPassword to blank, just in case
						pinPassword = new string(' ', 20);

						// set Signature on File to yes
						signatureOnFile = YES;

						// check ONET code
						if (onetCode == "  ")  // if ONET job code is blank, assume 35 Food Prep & Serving
							onetCode = "35";

						// check rehire
						if (rehire == YES)
							rehire = NO;  // AL does not ask for last employment date

						// check SNAP
						if (snap01 == YES || snap02 == YES)
						{
							if (snap01 != YES || snap02 != YES)
							{
								snap01 = YES;
								snap02 = YES;
								Console.WriteLine("Record " + (i + 1) + ": Fix SNAP.");
							}

							// if primary recipient is anything but blank
							if (primaryRecipientName != new string(' ', 30))
							{
								if (primaryRecipientCity == new string(' ', 20))
									primaryRecipientCity = employeeCity;
								if (primaryRecipientState == "  ")
									primaryRecipientState = employeeState;

								Console.WriteLine("Record " + (i + 1) + ": Fix primary benefit recipient city and state.");
							}

							while (primaryRecipientName.Length < 30 && primaryRecipientName != "                              ")
							{
								primaryRecipientName = primaryRecipientName + " ";
								Console.WriteLine("Record " + (i + 1) + ": Fix primary benefit recipient name length.");
							}
						}

						// check vocational rehab
						if (vocRehab == YES)
						{
							ticketToWork = NO;
							veteranAffairs = NO;
							Console.WriteLine("Record " + (i + 1) + ": Fix vocational rehab.");
						}

						// check TANF
						if (tanf01 == YES || tanf02 == YES || tanf03 == YES || tanf04 == YES)
						{
							tanf01 = YES;
							tanf02 = YES;
							tanf03 = YES;
							tanf04 = YES;
							Console.WriteLine("Record " + (i + 1) + ": Fix TANF.");

							// if primary recipient is anything but blank
							if (primaryRecipientName != "                              ")
							{
								if (primaryRecipientCity == new String(' ',20))
									primaryRecipientCity = employeeCity;
								if (primaryRecipientState == new String(' ', 2))
									primaryRecipientState = employeeState;
							}
						}

						// check felon if neither date is populated, felon = no. Otherwise compare dates.
						if (dateConviction != new String(' ', 8) && dateRelease != new String(' ', 8))
						{
							if (felon != YES)
							{
								felon = NO;
							}
							else
							{
								felon = NO;
								Console.WriteLine("Record " + (i + 1) + ": Felon is marked yes but both dates are blank. Marked felon as no. Please review.");
							}
						}
						else
						{
							// Convert date strings to DateTime
							DateTime.TryParse(dateConviction, out dateConvictionDate);
							DateTime.TryParse(dateRelease, out dateReleaseDate);

							try
							{
								if (dateConvictionDate > DateTime.MinValue || dateReleaseDate > DateTime.MinValue)
								{
									// if both dates are populated but release is earlier than conviction
									if (dateConvictionDate > dateReleaseDate && dateReleaseDate > DateTime.MinValue && dateConvictionDate > DateTime.MinValue)
									{
										DateTime tempDate = dateReleaseDate;
										dateReleaseDate = dateConvictionDate.AddDays(1);
										dateConvictionDate = tempDate;
										Console.WriteLine("Record " + (i + 1) + ": Swapped conviction/release dates.");
									}
									if (dateConviction == new String(' ', 8) && dateReleaseDate > DateTime.MinValue)
									{
										// if conviction date is blank but release date is populated, conviction = release - 1 day
										dateConvictionDate = dateReleaseDate.AddDays(-1); // Removes one day
										Console.WriteLine("Record " + (i + 1) + ": Added conviction date, release minus 1 day.");
									}
									else if ( == new String(' ', 8) && dateConvictionDate > DateTime.MinValue)
									{
										// if release date is blank but conviction date is populated, release = conviction + 1 day
										dateReleaseDate = dateConvictionDate.AddDays(1);
										Console.WriteLine("Record " + (i + 1) + ": Added release date, conviction plus one day.");
									}

									// if either date is populated, mark felon yes
									felon = YES;

									// if either date is populated and conviction type is not F for federal, make it S for State
									if (convictionType !="F" && convictionType != "S")
									{
										convictionType = "S";
										Console.WriteLine("Record " + (i + 1) + ": Fixed conviction status.");
									}
								}   // end if either date is populated
							}
							catch (Exception e)
							{
								Console.WriteLine("Record " + (i + 1) + ": conviction or release date parse error. May contain an invalid date. " + e);
							}
							
							if (convictionType != "F" && convictionType != "S")
								convictionType = "S";
							
							if (convictionState == new String(' ', 2))
								convictionState = employeeState;
						}  // end check felon

						// Not used yet:
						signatureOnFileForm9175 = YES;
						
						
						// check Empowerment Zone
						if (empowermentZone != YES)
						{
							if (empowermentZoneList.Contains(employeeCity.Trim()))
							{
								empowermentZone = YES;
								Console.WriteLine("Record " + (i + 1) + ": Added empowerment zone.");
							}
						}

						// check Rural Renewal Community
						if (ruralRenewalYN != YES)
						{
							// TODO check list of zip codes
						}

						// nothing to check for SSI

						// check vet 4, vet 6
						if (vetUnemployed6Months == YES || vetUnemployed4Weeks == YES)
							if (veteran != YES)
								veteran = YES;

						// check veteran status
						if (veteran != YES && veteran != NO) // if blank, set to N
							veteran = NO;

						if (veteran == NO)
						{
							// If not veteran, set all vet target groups to N
							vetDisabled = NO;
							vetRecentDischarge = NO;
							vetUnemployment = NO;
							vetUnemployed4Weeks = NO;
							vetUnemployed6Months = NO;
						}

						if (veteran == YES)        // check if vet unemployed 4 weeks or 6+ months
						{
							if (vetUnemployment == NO || vetUnemployment == new string(' ',2))
							{
								vetUnemployed4Weeks = YES;
								Console.WriteLine("Record " + (i + 1) + ": Added veteran unemployed 4 weeks to 6 months.");
							}
							else
							{
								if (vetUnemployed6Months != YES || question3 == YES)
								{
									vetUnemployed6Months = YES;
									Console.WriteLine("Record " + (i + 1) + ": Added veteran unemployed 6 months plus.");
								}
							}
						}


						// check LTU
						if (question7 == YES || longTermUnemploymentYN == YES)
						{
							question7 = YES;
							if (longTermUnemploymentYN != YES)
							{
								longTermUnemploymentYN = YES;
								Console.WriteLine("Record " + (i + 1) + ": Added long term unemployment.");
							}
							
							unemployed27ConsecutiveWeeks = YES;	// Not used yet
							unemploymentCompensation = YES;		// Not used yet
							// unemploymentBeginDate			// Not used yet
							// unemploymentEndDate				// Not used yet
							// declarationDate					// Not used yet

							// assign LTU state if it is not pre-filled
							if (longTermUnemploymentState == new String(' ',2) || longTermUnemploymentState.Trim().Length < 2)
							{
								longTermUnemploymentState = employeeState;
								Console.WriteLine("Record " + (i + 1) + ": Added LTU state.");
							}
							
						if (question7 == YES)
						{
							
						}
						}

						// check all signature dates
						if (dateSignatureEmployee.Trim().Length < 8 || dateSignatureEmployee == new String(' ',8))
						{
							dateSignatureEmployee = dateHired;
							Console.WriteLine("Record " + (i + 1) + ": Added employee signature date.");
						}

						if (dateSignatureEmployer01.Trim().Length < 8 || dateSignatureEmployer01 == new String(' ',8) ||
							dateSignatureEmployer02.Trim().Length < 8 || dateSignatureEmployer02 == new String(' ',8))
						{
							dateSignatureEmployer01 = dateHired;
							dateSignatureEmployer02 = dateHired;
							Console.WriteLine("Record " + (i + 1) + ": Added employer signature date.");
						}
						else
						{
							try
							{
								// if employer/consultant sign date is somehow earlier than employee sign date
								if (int.Parse(dateSignatureEmployee) > int.Parse(dateSignatureEmployer01) ||
									int.Parse(dateSignatureEmployee) > int.Parse(dateSignatureEmployer02))
								{
									dateSignatureEmployer01 = dateSignatureEmployee;
									dateSignatureEmployer02 = dateSignatureEmployee;
									Console.WriteLine("Record " + (i + 1) + ": Fixed employer signature date to match employee signature date.");
								}
							}
							catch (Exception e)
							{
								Console.Write("Record " + (i + 1) + ": Error reviewing employee and employer signature dates. \n" + e);
							}
						}

						// check all target groups, set 8850 Q2-7 to YES as needed
						if (snap01 == YES || tanf01 == YES || felon == YES || empowermentZone == YES
							|| ruralRenewalYN == YES || vetUnemployed4Weeks == YES)
						{
							question2 = YES;
							Console.WriteLine("Record " + (i + 1) + ": Marked question 2 to Y.");
						}

						if (vetUnemployed6Months == YES)
						{
							question3 = YES;
							Console.WriteLine("Record " + (i + 1) + ": Marked question 3 to Y.");
						}
						else
							question3 = NO;

						if (vetRecentDischarge == YES && vetDisabled == YES)
						{
							question4 = YES;
							Console.WriteLine("Record " + (i + 1) + ": Marked question 4 to Y.");
						}
						else
							question4 = NO;

						if (vetUnemployed6Months == YES)
						{
							question5 = YES;
							Console.WriteLine("Record " + (i + 1) + ": Marked question 5 to Y.");
						}
						else
							question5 = NO;

						if (tanf01 == YES)
						{
							question6 = YES;
							Console.WriteLine("Record " + (i + 1) + ": Marked question 6 to Y.");
						}
						else
							question6 = NO;

						if (longTermUnemploymentYN == YES)
							question7 = YES;
						else
							question7 = NO;

						// Check out of state benefits city & state
						// Note: These have been populating "incorrectly" unless specs were updated
						if (outOfStateBenefitsCity != employeeCity.Substring(0,2))
							outOfStateBenefitsCity = employeeCity.Substring(0,2);
						if (outOfStateBenefitsState == new String(' ',2))
							outOfStateBenefitsState = employeeState;
					
						// Check consultant name
						if (consultantYN != "C")
							consultantYN = "C";
						if (consultantID == CONSULT_ID_EFFICIENT)
						{
							if (representativeName != "Dave Kenney ")
							{
								representativeName = "Dave Kenney ";
								Console.WriteLine("Record " + (i + 1) + ": Fixed representative name.");
							}
						}
						else if (consultantID == CONSULT_ID_NTC)
						{
							if (representativeName != "SJOHNSTONE  ")
							{
								representativeName = "SJOHNSTONE  ";
								Console.WriteLine("Record " + (i + 1) + ": Fixed representative name.");
							}
						}							
						else
						{
							Console.WriteLine("Invalid consultant ID: " + consultantID);
							Console.WriteLine("Valid consultant IDs are \"" + CONSULT_ID_EFFICIENT +"\" or \"" + CONSULT_ID_NTC + "\"");
						}

						// check for no target groups
						if (veteran == NO &&
							vetDisabled == NO &&
							vetRecentDischarge == NO &&
							vetUnemployment == NO &&
							snap01 == NO &&
							snap02 == NO &&
							vocRehab == NO &&
							ticketToWork == NO &&
							veteranAffairs == NO &&
							tanf01 == NO &&
							tanf02 == NO &&
							tanf03 == NO &&
							tanf04 == NO &&
							felon == NO &&
							empowermentZone == NO &&
							ruralRenewalYN == NO &&
							ssi == NO &&
							vetUnemployed6Months == NO &&
							vetUnemployed4Weeks == NO &&
							longTermUnemploymentYN == NO)
						{
							Console.WriteLine("No target groups selected for record " + (i + 1));
						}

						// Check employer information for registering new business
						if (employerCityNew != new string(' ',20)
							&& employerPhoneNew == new string(' ', 10))
							if (consultantID == CONSULT_ID_EFFICIENT)
								employerPhoneNew = "8008597479";
							else
								employerPhoneNew = "8664996356";
							
						// Clear stringbuilder for new line of input
						stringb.Clear();

						// Build the record
						stringb.Append(consultantID);
						stringb.Append(fein);
						stringb.Append(ssn);
						stringb.Append(employeeFirstName);
						stringb.Append(employeeMiddleName);
						stringb.Append(employeeLastName);
						stringb.Append(employeeStreet1);
						stringb.Append(employeeCity);
						stringb.Append(employeeState);
						stringb.Append(employeeZip);
						stringb.Append(employeePhone);
						stringb.Append(employeeDOB);
						stringb.Append(katrinaEmployee);
						stringb.Append(katrinaCounty);
						stringb.Append(katrinaStreet);
						stringb.Append(katrinaCity);
						stringb.Append(katrinaState);
						stringb.Append(katrinaZip);
						stringb.Append(deprecated01);
						stringb.Append(deprecated02);
						stringb.Append(deprecated03);
						stringb.Append(deprecated04);
						stringb.Append(pinPassword);
						stringb.Append(signatureOnFile);
						stringb.Append(dateSignatureEmployee);
						stringb.Append(targetGroup);
						stringb.Append(dateGaveInfo);
						stringb.Append(dateOffered);
						stringb.Append(dateHired);
						stringb.Append(dateStarted);
						stringb.Append(jobCounty);
						stringb.Append(jobState);
						stringb.Append(newEmployee);
						stringb.Append(dateSignatureEmployer01);
						stringb.Append(wage);
						stringb.Append(onetCode);
						stringb.Append(rehire);
						stringb.Append(veteran);
						stringb.Append(vetDisabled);
						stringb.Append(vetRecentDischarge);
						stringb.Append(vetUnemployment);
						stringb.Append(snap01);
						stringb.Append(snap02);
						stringb.Append(vocRehab);
						stringb.Append(ticketToWork);
						stringb.Append(veteranAffairs);
						stringb.Append(tanf01);
						stringb.Append(tanf02);
						stringb.Append(tanf03);
						stringb.Append(tanf04);
						stringb.Append(primaryRecipientName);
						stringb.Append(primaryRecipientCity);
						stringb.Append(primaryRecipientState);
						stringb.Append(felon);
						stringb.Append(dateConviction);
						stringb.Append(dateRelease);
						stringb.Append(empowermentZone);
						stringb.Append(ruralRenewalYN);
						stringb.Append(ruralRenewalCounty);
						stringb.Append(ssi);
						stringb.Append(documentSources01);
						stringb.Append(documentSources02);
						stringb.Append(documentSources03);
						stringb.Append(documentSources04);
						stringb.Append(consultantYN);
						stringb.Append(dateSignatureEmployer02);
						stringb.Append(outOfStateBenefitsCity);
						stringb.Append(outOfStateBenefitsState);
						stringb.Append(representativeName);
						stringb.Append(deprecated05);
						stringb.Append(deprecated06);
						stringb.Append(deprecated07);
						stringb.Append(version8850);
						stringb.Append(version9061);
						stringb.Append(form9062);
						stringb.Append(question2);
						stringb.Append(question3);
						stringb.Append(question4);
						stringb.Append(question5);
						stringb.Append(question6);
						stringb.Append(convictionType);
						stringb.Append(convictionState);
						stringb.Append(vetUnemployed6Months);
						stringb.Append(vetUnemployed4Weeks);
						stringb.Append(categoryF);
						stringb.Append(dateMailed);
						stringb.Append(longTermUnemploymentYN);
						stringb.Append(deprecated08);
						stringb.Append(question7);
						stringb.Append(signatureOnFileForm9175);
						stringb.Append(unemployed27ConsecutiveWeeks);
						stringb.Append(unemploymentCompensation);
						stringb.Append(unemploymentBeginDate);
						stringb.Append(unemploymentEndDate);
						stringb.Append(declarationDate);
						stringb.Append(longTermUnemploymentState);
						stringb.Append(deprecated09);
						stringb.Append(employerNameNew);
						stringb.Append(employerAddressNew);
						stringb.Append(employerAddress2New);
						stringb.Append(employerCityNew);
						stringb.Append(employerStateNew);
						stringb.Append(employerZipNew);
						stringb.Append(employerPhoneNew);
						stringb.Append(employerPhoneExtNew);

						// Add this record to results string array
						results.Add(stringb.ToString());
					}
					else
					{
						Console.WriteLine("Error: Invalid state abbreviation in ReadLinesToData. Cannot proceed.");
					}


				}  // end parse data Alabama loop

				try
				{
					// Write results to file
					if (!File.Exists(filePathWrite))
					{
						// Create a file to write to.
						File.WriteAllLines(filePathWrite, results, Encoding.UTF8);
						Console.WriteLine("Results file created! " + filePathWrite.ToString());
					}
					else
					{
						int resultsFileIncrement = 1;
						string newFilePath = filePathWrite.Substring(0, filePathWrite.Length - 4);

						if (File.Exists(newFilePath + resultsFileIncrement + ".txt"))
						{
							while (File.Exists(newFilePath + resultsFileIncrement.ToString() + ".txt"))
							{
								if (File.Exists(newFilePath + resultsFileIncrement.ToString() + ".txt"))
								{
									resultsFileIncrement++;
									Console.WriteLine("Incremented name of results file. " + newFilePath + resultsFileIncrement.ToString() + ".txt");
								}
								else
								{
									try
									{
										File.WriteAllLines(newFilePath + resultsFileIncrement + ".txt", results, Encoding.UTF8);
										Console.WriteLine("Results file created! " + newFilePath + resultsFileIncrement.ToString() + ".txt");
									}
									catch
									{
										Console.WriteLine("File create error: " + newFilePath + resultsFileIncrement.ToString() + ".txt");
									}
								}

							} // end increment loop
						}
						else
						{
							try
							{
								File.WriteAllLines(newFilePath + resultsFileIncrement + ".txt", results, Encoding.UTF8);
								Console.WriteLine("Results file created!");
							}
							catch
							{
								Console.WriteLine("File create error: " + newFilePath + resultsFileIncrement + ".txt");
							}
						}
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("Some other write file error. " + e);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("General error. " + e);
			}

			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}