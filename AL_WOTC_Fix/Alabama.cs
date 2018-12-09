using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AL_WOTC_Fix
{
	class Alabama
	{
		// Declare variables
		private readonly string inputString;
		private int inputIndex = 0;              // Track location in input string

		IList varList = new List<String>();
		IList varLengthList = new List<String>();

		string consultantID;
		string fein;
		string ssn;
		string employeeFirstName;
		string employeeMiddleName;
		string employeeLastName;
		string employeeStreet1;
		string employeeCity;
		string employeeState;
		string employeeZip;
		string employeePhone;
		string employeeDOB;
		string katrinaEmployee;
		string katrinaCounty;
		string katrinaStreet;
		string katrinaCity;
		string katrinaState;
		string katrinaZip;
		string deprecated01;
		string deprecated02;
		string deprecated03;
		string deprecated04;
		string pinPassword;
		string signatureOnFile;
		string dateSignatureEmployee;
		string targetGroup;
		string dateGaveInfo;
		string dateOffered;
		string dateHired;
		string dateStarted;
		string jobCounty;
		string jobState;
		string newEmployee;
		string dateSignatureEmployer01;
		string wage;
		string onetCode;
		string rehire;
		string veteran;
		string vetDisabled;
		string vetRecentDischarge;
		string vetUnemployment;
		string snap01;
		string snap02;
		string vocRehab;
		string ticketToWork;
		string veteranAffairs;
		string tanf01;
		string tanf02;
		string tanf03;
		string tanf04;
		string primaryRecipientName;
		string primaryRecipientCity;
		string primaryRecipientState;
		string felon;
		string dateConviction;
		string dateRelease;
		string empowermentZone;
		string ruralRenewalYN;
		string ruralRenewalCounty;
		string ssi;
		string documentSources01;
		string documentSources02;
		string documentSources03;
		string documentSources04;
		string consultantYN;
		string dateSignatureEmployer02;
		string outOfStateBenefitsCity;
		string outOfStateBenefitsState;
		string representativeName;
		string deprecated05;
		string deprecated06;
		string deprecated07;
		string version8850;
		string version9061;
		string form9062;
		string question2;
		string question3;
		string question4;
		string question5;
		string question6;
		string convictionType;
		string convictionState;
		string vetUnemployed6Months;
		string vetUnemployed4Weeks;
		string categoryF;
		string dateMailed;
		string longTermUnemploymentYN;
		string deprecated08;
		string question7;
		string signatureOnFileForm9175;
		string unemployed27ConsecutiveWeeks;
		string unemploymentCompensation;
		string unemploymentBeginDate;
		string unemploymentEndDate;
		string declarationDate;
		string longTermUnemploymentState;
		string deprecated09;
		string employerNameNew;
		string employerAddressNew;
		string employerAddress2New;
		string employerCityNew;
		string employerStateNew;
		string employerZipNew;
		string employerPhoneNew;
		string employerPhoneExtNew;

		// Set variable lengths
		int consultantIDLength = 12;
		int feinLength = 9;
		int ssnLength = 9;
		int employeeFirstNameLength = 10;
		int employeeMiddleNameLength = 1;
		int employeeLastNameLength = 19;
		int employeeStreet1Length = 30;
		int employeeCityLength = 20;
		int employeeStateLength = 2;
		int employeeZipLength = 5;
		int employeePhoneLength = 10;
		int employeeDOBLength = 8;
		int katrinaEmployeeLength = 1;
		int katrinaCountyLength = 20;
		int katrinaStreetLength = 30;
		int katrinaCityLength = 20;
		int katrinaStateLength = 2;
		int katrinaZipLength = 5;
		int deprecated01Length = 1;
		int deprecated02Length = 1;
		int deprecated03Length = 1;
		int deprecated04Length = 1;
		int pinPasswordLength = 20;
		int signatureOnFileLength = 1;
		int dateSignatureEmployeeLength = 8;
		int targetGroupLength = 1;
		int dateGaveInfoLength = 8;
		int dateOfferedLength = 8;
		int dateHiredLength = 8;
		int dateStartedLength = 8;
		int jobCountyLength = 20;
		int jobStateLength = 2;
		int newEmployeeLength = 1;
		int dateSignatureEmployer01Length = 8;
		int wageLength = 4;
		int onetCodeLength = 2;
		int rehireLength = 1;
		int veteranLength = 1;
		int vetDisabledLength = 1;
		int vetRecentDischargeLength = 1;
		int vetUnemploymentLength = 1;
		int snap01Length = 1;
		int snap02Length = 1;
		int vocRehabLength = 1;
		int ticketToWorkLength = 1;
		int veteranAffairsLength = 1;
		int tanf01Length = 1;
		int tanf02Length = 1;
		int tanf03Lengthv
		int tanf04Length = 1;
		int primaryRecipientNameLength = 30;
		int primaryRecipientCityLength = 20;
		int primaryRecipientStateLength = 2;
		int felonLength = 1;
		int dateConvictionLength = 8;
		int dateReleaseLength = 8;
		int empowermentZoneLength = 1;
		int ruralRenewalYNLength = 1;
		int ruralRenewalCountyLength = 20;
		int ssiLength = 1;
		int documentSources01Length = 80;
		int documentSources02Length = 80;
		int documentSources03Length = 80;
		int documentSources04Length = 80;
		int consultantYNLength = 1;
		int dateSignatureEmployer02Length = 8;
		int outOfStateBenefitsCityLength = 20;
		int outOfStateBenefitsStateLength = 2;
		int representativeNameLength = 12;
		int deprecated05Length = 1;
		int deprecated06Length = 1;
		int deprecated07Length = 1;
		int version8850Length = 2;
		int version9061Length = 2;
		int form9062Length = 1;
		int question2Length = 1;
		int question3Length = 1;
		int question4Length = 1;
		int question5Length = 1;
		int question6Length = 1;
		int convictionTypeLength = 1;
		int convictionStateLength = 2;
		int vetUnemployed6MonthsLength = 1;
		int vetUnemployed4WeeksLength = 1;
		int categoryFLength = 1;
		int dateMailedLength = 8;
		int longTermUnemploymentYNLength = 1;
		int deprecated08Length = 1;
		int question7Length = 1;
		int signatureOnFileForm9175Length = 1;
		int unemployed27ConsecutiveWeeksLength = 1;
		int unemploymentCompensationLength = 1;
		int unemploymentBeginDateLength = 8;
		int unemploymentEndDateLength = 8;
		int declarationDateLength = 8;
		int longTermUnemploymentStateLength = 2;
		int deprecated09Length = 56;
		int employerNameNewLength = 50;
		int employerAddressNewLength = 30;
		int employerAddress2NewLength = 30;
		int employerCityNewLength = 20;
		int employerStateNewLength = 2;
		int employerZipNewLength = 5;
		int employerPhoneNewLength = 10;
		int employerPhoneExtNewLength = 4;

		public string ConsultantID { get => consultantID; set => consultantID = value; }
		public string Fein { get => fein; set => fein = value; }
		public string Ssn { get => ssn; set => ssn = value; }
		public string EmployeeFirstName { get => employeeFirstName; set => employeeFirstName = value; }
		public string EmployeeMiddleName { get => employeeMiddleName; set => employeeMiddleName = value; }
		public string EmployeeLastName { get => employeeLastName; set => employeeLastName = value; }
		public string EmployeeStreet1 { get => employeeStreet1; set => employeeStreet1 = value; }
		public string EmployeeCity { get => employeeCity; set => employeeCity = value; }
		public string EmployeeState { get => employeeState; set => employeeState = value; }
		public string EmployeeZip { get => employeeZip; set => employeeZip = value; }
		public string EmployeePhone { get => employeePhone; set => employeePhone = value; }
		public string EmployeeDOB { get => employeeDOB; set => employeeDOB = value; }
		public string KatrinaEmployee { get => katrinaEmployee; set => katrinaEmployee = value; }
		public string KatrinaCounty { get => katrinaCounty; set => katrinaCounty = value; }
		public string KatrinaStreet { get => katrinaStreet; set => katrinaStreet = value; }
		public string KatrinaCity { get => katrinaCity; set => katrinaCity = value; }
		public string KatrinaState { get => katrinaState; set => katrinaState = value; }
		public string KatrinaZip { get => katrinaZip; set => katrinaZip = value; }
		public string Deprecated01 { get => deprecated01; set => deprecated01 = value; }
		public string Deprecated02 { get => deprecated02; set => deprecated02 = value; }
		public string Deprecated03 { get => deprecated03; set => deprecated03 = value; }
		public string Deprecated04 { get => deprecated04; set => deprecated04 = value; }
		public string PinPassword { get => pinPassword; set => pinPassword = value; }
		public string SignatureOnFile { get => signatureOnFile; set => signatureOnFile = value; }
		public string DateSignatureEmployee { get => dateSignatureEmployee; set => dateSignatureEmployee = value; }
		public string TargetGroup { get => targetGroup; set => targetGroup = value; }
		public string DateGaveInfo { get => dateGaveInfo; set => dateGaveInfo = value; }
		public string DateOffered { get => dateOffered; set => dateOffered = value; }
		public string DateHired { get => dateHired; set => dateHired = value; }
		public string DateStarted { get => dateStarted; set => dateStarted = value; }
		public string JobCounty { get => jobCounty; set => jobCounty = value; }
		public string JobState { get => jobState; set => jobState = value; }
		public string NewEmployee { get => newEmployee; set => newEmployee = value; }
		public string DateSignatureEmployer01 { get => dateSignatureEmployer01; set => dateSignatureEmployer01 = value; }
		public string Wage { get => wage; set => wage = value; }
		public string OnetCode { get => onetCode; set => onetCode = value; }
		public string Rehire { get => rehire; set => rehire = value; }
		public string Veteran { get => veteran; set => veteran = value; }
		public string VetDisabled { get => vetDisabled; set => vetDisabled = value; }
		public string VetRecentDischarge { get => vetRecentDischarge; set => vetRecentDischarge = value; }
		public string VetUnemployment { get => vetUnemployment; set => vetUnemployment = value; }
		public string Snap01 { get => snap01; set => snap01 = value; }
		public string Snap02 { get => snap02; set => snap02 = value; }
		public string VocRehab { get => vocRehab; set => vocRehab = value; }
		public string TicketToWork { get => ticketToWork; set => ticketToWork = value; }
		public string VeteranAffairs { get => veteranAffairs; set => veteranAffairs = value; }
		public string Tanf01 { get => tanf01; set => tanf01 = value; }
		public string Tanf02 { get => tanf02; set => tanf02 = value; }
		public string Tanf03 { get => tanf03; set => tanf03 = value; }
		public string Tanf04 { get => tanf04; set => tanf04 = value; }
		public string PrimaryRecipientName { get => primaryRecipientName; set => primaryRecipientName = value; }
		public string PrimaryRecipientCity { get => primaryRecipientCity; set => primaryRecipientCity = value; }
		public string PrimaryRecipientState { get => primaryRecipientState; set => primaryRecipientState = value; }
		public string Felon { get => felon; set => felon = value; }
		public string DateConviction { get => dateConviction; set => dateConviction = value; }
		public string DateRelease { get => dateRelease; set => dateRelease = value; }
		public string EmpowermentZone { get => empowermentZone; set => empowermentZone = value; }
		public string RuralRenewalYN { get => ruralRenewalYN; set => ruralRenewalYN = value; }
		public string RuralRenewalCounty { get => ruralRenewalCounty; set => ruralRenewalCounty = value; }
		public string Ssi { get => ssi; set => ssi = value; }
		public string DocumentSources01 { get => documentSources01; set => documentSources01 = value; }
		public string DocumentSources02 { get => documentSources02; set => documentSources02 = value; }
		public string DocumentSources03 { get => documentSources03; set => documentSources03 = value; }
		public string DocumentSources04 { get => documentSources04; set => documentSources04 = value; }
		public string ConsultantYN { get => consultantYN; set => consultantYN = value; }
		public string DateSignatureEmployer02 { get => dateSignatureEmployer02; set => dateSignatureEmployer02 = value; }
		public string OutOfStateBenefitsCity { get => outOfStateBenefitsCity; set => outOfStateBenefitsCity = value; }
		public string OutOfStateBenefitsState { get => outOfStateBenefitsState; set => outOfStateBenefitsState = value; }
		public string RepresentativeName { get => representativeName; set => representativeName = value; }
		public string Deprecated05 { get => deprecated05; set => deprecated05 = value; }
		public string Deprecated06 { get => deprecated06; set => deprecated06 = value; }
		public string Deprecated07 { get => deprecated07; set => deprecated07 = value; }
		public string Version8850 { get => version8850; set => version8850 = value; }
		public string Version9061 { get => version9061; set => version9061 = value; }
		public string Form9062 { get => form9062; set => form9062 = value; }
		public string Question2 { get => question2; set => question2 = value; }
		public string Question3 { get => question3; set => question3 = value; }
		public string Question4 { get => question4; set => question4 = value; }
		public string Question5 { get => question5; set => question5 = value; }
		public string Question6 { get => question6; set => question6 = value; }
		public string ConvictionType { get => convictionType; set => convictionType = value; }
		public string ConvictionState { get => convictionState; set => convictionState = value; }
		public string VetUnemployed6Months { get => vetUnemployed6Months; set => vetUnemployed6Months = value; }
		public string VetUnemployed4Weeks { get => vetUnemployed4Weeks; set => vetUnemployed4Weeks = value; }
		public string CategoryF { get => categoryF; set => categoryF = value; }
		public string DateMailed { get => dateMailed; set => dateMailed = value; }
		public string LongTermUnemploymentYN { get => longTermUnemploymentYN; set => longTermUnemploymentYN = value; }
		public string Deprecated08 { get => deprecated08; set => deprecated08 = value; }
		public string Question7 { get => question7; set => question7 = value; }
		public string SignatureOnFileForm9175 { get => signatureOnFileForm9175; set => signatureOnFileForm9175 = value; }
		public string Unemployed27ConsecutiveWeeks { get => unemployed27ConsecutiveWeeks; set => unemployed27ConsecutiveWeeks = value; }
		public string UnemploymentCompensation { get => unemploymentCompensation; set => unemploymentCompensation = value; }
		public string UnemploymentBeginDate { get => unemploymentBeginDate; set => unemploymentBeginDate = value; }
		public string UnemploymentEndDate { get => unemploymentEndDate; set => unemploymentEndDate = value; }
		public string DeclarationDate { get => declarationDate; set => declarationDate = value; }
		public string LongTermUnemploymentState { get => longTermUnemploymentState; set => longTermUnemploymentState = value; }
		public string Deprecated09 { get => deprecated09; set => deprecated09 = value; }
		public string EmployerNameNew { get => employerNameNew; set => employerNameNew = value; }
		public string EmployerAddressNew { get => employerAddressNew; set => employerAddressNew = value; }
		public string EmployerAddress2New { get => employerAddress2New; set => employerAddress2New = value; }
		public string EmployerCityNew { get => employerCityNew; set => employerCityNew = value; }
		public string EmployerStateNew { get => employerStateNew; set => employerStateNew = value; }
		public string EmployerZipNew { get => employerZipNew; set => employerZipNew = value; }
		public string EmployerPhoneNew { get => employerPhoneNew; set => employerPhoneNew = value; }
		public string EmployerPhoneExtNew { get => employerPhoneExtNew; set => employerPhoneExtNew = value; }
		public int ConsultantIDLength { get => consultantIDLength; set => consultantIDLength = value; }
		public int FeinLength { get => feinLength; set => feinLength = value; }
		public int SsnLength { get => ssnLength; set => ssnLength = value; }
		public int EmployeeFirstNameLength { get => employeeFirstNameLength; set => employeeFirstNameLength = value; }
		public int EmployeeMiddleNameLength { get => employeeMiddleNameLength; set => employeeMiddleNameLength = value; }
		public int EmployeeLastNameLength { get => employeeLastNameLength; set => employeeLastNameLength = value; }
		public int EmployeeStreet1Length { get => employeeStreet1Length; set => employeeStreet1Length = value; }
		public int EmployeeCityLength { get => employeeCityLength; set => employeeCityLength = value; }
		public int EmployeeStateLength { get => employeeStateLength; set => employeeStateLength = value; }
		public int EmployeeZipLength { get => employeeZipLength; set => employeeZipLength = value; }
		public int EmployeePhoneLength { get => employeePhoneLength; set => employeePhoneLength = value; }
		public int EmployeeDOBLength { get => employeeDOBLength; set => employeeDOBLength = value; }
		public int KatrinaEmployeeLength { get => katrinaEmployeeLength; set => katrinaEmployeeLength = value; }
		public int KatrinaCountyLength { get => katrinaCountyLength; set => katrinaCountyLength = value; }
		public int KatrinaStreetLength { get => katrinaStreetLength; set => katrinaStreetLength = value; }
		public int KatrinaCityLength { get => katrinaCityLength; set => katrinaCityLength = value; }
		public int KatrinaStateLength { get => katrinaStateLength; set => katrinaStateLength = value; }
		public int KatrinaZipLength { get => katrinaZipLength; set => katrinaZipLength = value; }
		public int Deprecated01Length { get => deprecated01Length; set => deprecated01Length = value; }
		public int Deprecated02Length { get => deprecated02Length; set => deprecated02Length = value; }
		public int Deprecated03Length { get => deprecated03Length; set => deprecated03Length = value; }
		public int Deprecated04Length { get => deprecated04Length; set => deprecated04Length = value; }
		public int PinPasswordLength { get => pinPasswordLength; set => pinPasswordLength = value; }
		public int SignatureOnFileLength { get => signatureOnFileLength; set => signatureOnFileLength = value; }
		public int DateSignatureEmployeeLength { get => dateSignatureEmployeeLength; set => dateSignatureEmployeeLength = value; }
		public int TargetGroupLength { get => targetGroupLength; set => targetGroupLength = value; }
		public int DateGaveInfoLength { get => dateGaveInfoLength; set => dateGaveInfoLength = value; }
		public int DateOfferedLength { get => dateOfferedLength; set => dateOfferedLength = value; }
		public int DateHiredLength { get => dateHiredLength; set => dateHiredLength = value; }
		public int DateStartedLength { get => dateStartedLength; set => dateStartedLength = value; }
		public int JobCountyLength { get => jobCountyLength; set => jobCountyLength = value; }
		public int JobStateLength { get => jobStateLength; set => jobStateLength = value; }
		public int NewEmployeeLength { get => newEmployeeLength; set => newEmployeeLength = value; }
		public int DateSignatureEmployer01Length { get => dateSignatureEmployer01Length; set => dateSignatureEmployer01Length = value; }
		public int WageLength { get => wageLength; set => wageLength = value; }
		public int OnetCodeLength { get => onetCodeLength; set => onetCodeLength = value; }
		public int RehireLength { get => rehireLength; set => rehireLength = value; }
		public int VeteranLength { get => veteranLength; set => veteranLength = value; }
		public int VetDisabledLength { get => vetDisabledLength; set => vetDisabledLength = value; }
		public int VetRecentDischargeLength { get => vetRecentDischargeLength; set => vetRecentDischargeLength = value; }
		public int VetUnemploymentLength { get => vetUnemploymentLength; set => vetUnemploymentLength = value; }
		public int Snap01Length { get => snap01Length; set => snap01Length = value; }
		public int Snap02Length { get => snap02Length; set => snap02Length = value; }
		public int VocRehabLength { get => vocRehabLength; set => vocRehabLength = value; }
		public int TicketToWorkLength { get => ticketToWorkLength; set => ticketToWorkLength = value; }
		public int VeteranAffairsLength { get => veteranAffairsLength; set => veteranAffairsLength = value; }
		public int Tanf01Length { get => tanf01Length; set => tanf01Length = value; }
		public int Tanf02Length { get => tanf02Length; set => tanf02Length = value; }
		public int Tanf03Lengthv { get => tanf03Lengthv; set => tanf03Lengthv = value; }
		public int Tanf04Length { get => tanf04Length; set => tanf04Length = value; }
		public int PrimaryRecipientNameLength { get => primaryRecipientNameLength; set => primaryRecipientNameLength = value; }
		public int PrimaryRecipientCityLength { get => primaryRecipientCityLength; set => primaryRecipientCityLength = value; }
		public int PrimaryRecipientStateLength { get => primaryRecipientStateLength; set => primaryRecipientStateLength = value; }
		public int FelonLength { get => felonLength; set => felonLength = value; }
		public int DateConvictionLength { get => dateConvictionLength; set => dateConvictionLength = value; }
		public int DateReleaseLength { get => dateReleaseLength; set => dateReleaseLength = value; }
		public int EmpowermentZoneLength { get => empowermentZoneLength; set => empowermentZoneLength = value; }
		public int RuralRenewalYNLength { get => ruralRenewalYNLength; set => ruralRenewalYNLength = value; }
		public int RuralRenewalCountyLength { get => ruralRenewalCountyLength; set => ruralRenewalCountyLength = value; }
		public int SsiLength { get => ssiLength; set => ssiLength = value; }
		public int DocumentSources01Length { get => documentSources01Length; set => documentSources01Length = value; }
		public int DocumentSources02Length { get => documentSources02Length; set => documentSources02Length = value; }
		public int DocumentSources03Length { get => documentSources03Length; set => documentSources03Length = value; }
		public int DocumentSources04Length { get => documentSources04Length; set => documentSources04Length = value; }
		public int ConsultantYNLength { get => consultantYNLength; set => consultantYNLength = value; }
		public int DateSignatureEmployer02Length { get => dateSignatureEmployer02Length; set => dateSignatureEmployer02Length = value; }
		public int OutOfStateBenefitsCityLength { get => outOfStateBenefitsCityLength; set => outOfStateBenefitsCityLength = value; }
		public int OutOfStateBenefitsStateLength { get => outOfStateBenefitsStateLength; set => outOfStateBenefitsStateLength = value; }
		public int RepresentativeNameLength { get => representativeNameLength; set => representativeNameLength = value; }
		public int Deprecated05Length { get => deprecated05Length; set => deprecated05Length = value; }
		public int Deprecated06Length { get => deprecated06Length; set => deprecated06Length = value; }
		public int Deprecated07Length { get => deprecated07Length; set => deprecated07Length = value; }
		public int Version8850Length { get => version8850Length; set => version8850Length = value; }
		public int Version9061Length { get => version9061Length; set => version9061Length = value; }
		public int Form9062Length { get => form9062Length; set => form9062Length = value; }
		public int Question2Length { get => question2Length; set => question2Length = value; }
		public int Question3Length { get => question3Length; set => question3Length = value; }
		public int Question4Length { get => question4Length; set => question4Length = value; }
		public int Question5Length { get => question5Length; set => question5Length = value; }
		public int Question6Length { get => question6Length; set => question6Length = value; }
		public int ConvictionTypeLength { get => convictionTypeLength; set => convictionTypeLength = value; }
		public int ConvictionStateLength { get => convictionStateLength; set => convictionStateLength = value; }
		public int VetUnemployed6MonthsLength { get => vetUnemployed6MonthsLength; set => vetUnemployed6MonthsLength = value; }
		public int VetUnemployed4WeeksLength { get => vetUnemployed4WeeksLength; set => vetUnemployed4WeeksLength = value; }
		public int CategoryFLength { get => categoryFLength; set => categoryFLength = value; }
		public int DateMailedLength { get => dateMailedLength; set => dateMailedLength = value; }
		public int LongTermUnemploymentYNLength { get => longTermUnemploymentYNLength; set => longTermUnemploymentYNLength = value; }
		public int Deprecated08Length { get => deprecated08Length; set => deprecated08Length = value; }
		public int Question7Length { get => question7Length; set => question7Length = value; }
		public int SignatureOnFileForm9175Length { get => signatureOnFileForm9175Length; set => signatureOnFileForm9175Length = value; }
		public int Unemployed27ConsecutiveWeeksLength { get => unemployed27ConsecutiveWeeksLength; set => unemployed27ConsecutiveWeeksLength = value; }
		public int UnemploymentCompensationLength { get => unemploymentCompensationLength; set => unemploymentCompensationLength = value; }
		public int UnemploymentBeginDateLength { get => unemploymentBeginDateLength; set => unemploymentBeginDateLength = value; }
		public int UnemploymentEndDateLength { get => unemploymentEndDateLength; set => unemploymentEndDateLength = value; }
		public int DeclarationDateLength { get => declarationDateLength; set => declarationDateLength = value; }
		public int LongTermUnemploymentStateLength { get => longTermUnemploymentStateLength; set => longTermUnemploymentStateLength = value; }
		public int Deprecated09Length { get => deprecated09Length; set => deprecated09Length = value; }
		public int EmployerNameNewLength { get => employerNameNewLength; set => employerNameNewLength = value; }
		public int EmployerAddressNewLength { get => employerAddressNewLength; set => employerAddressNewLength = value; }
		public int EmployerAddress2NewLength { get => employerAddress2NewLength; set => employerAddress2NewLength = value; }
		public int EmployerCityNewLength { get => employerCityNewLength; set => employerCityNewLength = value; }
		public int EmployerStateNewLength { get => employerStateNewLength; set => employerStateNewLength = value; }
		public int EmployerZipNewLength { get => employerZipNewLength; set => employerZipNewLength = value; }
		public int EmployerPhoneNewLength { get => employerPhoneNewLength; set => employerPhoneNewLength = value; }
		public int EmployerPhoneExtNewLength { get => employerPhoneExtNewLength; set => employerPhoneExtNewLength = value; }

		// Set variable order
		varList.Add(ConsultantID);
		varLengthList.Add(ConsultantIDLength);


		// Initialize variables
		ConsultantID = inputString[i].Substring(inputIndex, ConsultantIDLength);
		inputIndex += ConsultantIDLength;

		Fein = inputString[i].Substring(inputIndex, FeinLength);
		inputIndex += FeinLength;

		ssn = inputString[i].Substring(21, 9);                      // SSN 9 digits, preserve leading zero
		employeeFirstName = inputString[i].Substring(30, 10);
		employeeMiddleName = inputString[i].Substring(40, 1);
		employeeLastName = inputString[i].Substring(41, 19);
		employeeStreet1 = inputString[i].Substring(60, 30);
		employeeCity = inputString[i].Substring(90, 20);
		employeeState = inputString[i].Substring(110, 2);
		employeeZip = inputString[i].Substring(112, 5);
		employeePhone = inputString[i].Substring(117, 10);
		employeeDOB = inputString[i].Substring(127, 8);             // format mmddccyy
		katrinaEmployee = inputString[i].Substring(135, 1);
		katrinaCounty = inputString[i].Substring(136, 20);
		katrinaStreet = inputString[i].Substring(156, 30);
		katrinaCity = inputString[i].Substring(186, 20);
		katrinaState = inputString[i].Substring(206, 2);
		katrinaZip = inputString[i].Substring(208, 5);
		deprecated01 = inputString[i].Substring(213, 1);
		deprecated02 = inputString[i].Substring(214, 1);
		deprecated03 = inputString[i].Substring(215, 1);
		deprecated04 = inputString[i].Substring(216, 1);
		pinPassword = inputString[i].Substring(217, 20);
		signatureOnFile = inputString[i].Substring(237, 1);
		dateSignatureEmployee = inputString[i].Substring(238, 8);   // format mmddccyy
		targetGroup = inputString[i].Substring(246, 1);             // 4 or 6
		dateGaveInfo = inputString[i].Substring(247, 8);            // format mmddccyy
		dateOffered = inputString[i].Substring(255, 8);             // format mmddccyy
		dateHired = inputString[i].Substring(263, 8);               // format mmddccyy
		dateStarted = inputString[i].Substring(271, 8);             // format mmddccyy
		jobCounty = inputString[i].Substring(279, 20);              // Hurricane Katrina relief
		jobState = inputString[i].Substring(299, 2);                // Hurricane Katrina relief
		newEmployee = inputString[i].Substring(301, 1);             // Hurricane Katrina relief
		dateSignatureEmployer01 = inputString[i].Substring(302, 8); // format mmddccyy
		wage = inputString[i].Substring(310, 4);                    // preserve leading/trailing zero
		onetCode = inputString[i].Substring(314, 2);                // 2 numeric digits
		rehire = inputString[i].Substring(316, 1);
		veteran = inputString[i].Substring(317, 1);
		vetDisabled = inputString[i].Substring(318, 1);
		vetRecentDischarge = inputString[i].Substring(319, 1);
		vetUnemployment = inputString[i].Substring(320, 1);
		snap01 = inputString[i].Substring(321, 1);
		snap02 = inputString[i].Substring(322, 1);
		vocRehab = inputString[i].Substring(323, 1);
		ticketToWork = inputString[i].Substring(324, 1);
		veteranAffairs = inputString[i].Substring(325, 1);
		tanf01 = inputString[i].Substring(326, 1);
		tanf02 = inputString[i].Substring(327, 1);
		tanf03 = inputString[i].Substring(328, 1);
		tanf04 = inputString[i].Substring(329, 1);
		primaryRecipientName = inputString[i].Substring(330, 30);
		primaryRecipientCity = inputString[i].Substring(360, 20);
		primaryRecipientState = inputString[i].Substring(380, 2);
		felon = inputString[i].Substring(382, 1);
		dateConviction = inputString[i].Substring(383, 8);
		dateRelease = inputString[i].Substring(391, 8);
		empowermentZone = inputString[i].Substring(399, 1);
		ruralRenewalYN = inputString[i].Substring(400, 1);
		ruralRenewalCounty = inputString[i].Substring(401, 20);
		ssi = inputString[i].Substring(421, 1);
		documentSources01 = inputString[i].Substring(422, 80);
		documentSources02 = inputString[i].Substring(502, 80);
		documentSources03 = inputString[i].Substring(582, 80);
		documentSources04 = inputString[i].Substring(662, 80);
		consultantYN = inputString[i].Substring(742, 1);                // C for Consultant or E for Employer
		dateSignatureEmployer02 = inputString[i].Substring(743, 8);     // format mmddccyy
		outOfStateBenefitsCity = inputString[i].Substring(751, 20);
		outOfStateBenefitsState = inputString[i].Substring(771, 2);
		representativeName = inputString[i].Substring(773, 12);
		deprecated05 = inputString[i].Substring(785, 1);                // ARRA Vet, deprecated 2012
		deprecated06 = inputString[i].Substring(786, 1);                // ARRA Youth, deprecated 2012
		deprecated07 = inputString[i].Substring(787, 1);                // Vow to Hire Heroes, deprecated 2012
		version8850 = inputString[i].Substring(788, 2);                 // 16 = 2016
		version9061 = inputString[i].Substring(790, 2);                 // 16 = 2016, 17 = 2017
		form9062 = inputString[i].Substring(792, 1);                    // not used as of Oct 2018, assume N
		question2 = inputString[i].Substring(793, 1);                   // form 8850 questions 1-6
		question3 = inputString[i].Substring(794, 1);
		question4 = inputString[i].Substring(795, 1);
		question5 = inputString[i].Substring(796, 1);
		question6 = inputString[i].Substring(797, 1);
		convictionType = inputString[i].Substring(798, 1);              // F = Federal, S = State
		convictionState = inputString[i].Substring(799, 2);
		vetUnemployed6Months = inputString[i].Substring(801, 1);
		vetUnemployed4Weeks = inputString[i].Substring(802, 1);
		categoryF = inputString[i].Substring(803, 1);                   // form 9061 question 19
		dateMailed = inputString[i].Substring(804, 8);                  // Mail date (only if ok with state for catchup, otherwise blank)
		longTermUnemploymentYN = inputString[i].Substring(812, 1);
		deprecated08 = inputString[i].Substring(813, 1);
		question7 = inputString[i].Substring(814, 1);                   // form 8850 question 7 LTU
		signatureOnFileForm9175 = inputString[i].Substring(815, 1);     // not used yet
		unemployed27ConsecutiveWeeks = inputString[i].Substring(816, 1);// not used yet
		unemploymentCompensation = inputString[i].Substring(817, 1);    // not used yet
		unemploymentBeginDate = inputString[i].Substring(818, 8);       // not used yet
		unemploymentEndDate = inputString[i].Substring(826, 8);         // not used yet
		declarationDate = inputString[i].Substring(834, 8);             // not used yet
		longTermUnemploymentState = inputString[i].Substring(842, 2);   // ties to previous long term unemployment fields
		deprecated09 = inputString[i].Substring(844, 56);               // not used yet
		employerNameNew = inputString[i].Substring(900, 50);            // only for establishing a new employer
		employerAddressNew = inputString[i].Substring(950, 30);         // only for establishing a new employer
		employerAddress2New = inputString[i].Substring(980, 30);        // only for establishing a new employer
		employerCityNew = inputString[i].Substring(1010, 20);           // only for establishing a new employer
		employerStateNew = inputString[i].Substring(1030, 2);           // only for establishing a new employer
		employerZipNew = inputString[i].Substring(1032, 5);             // only for establishing a new employer
		employerPhoneNew = inputString[i].Substring(1037, 10);          // only for establishing a new employer
		employerPhoneExtNew = inputString[i].Substring(1047, 4);        // only for establishing a new employer

	}
}
