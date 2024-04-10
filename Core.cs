using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net;



namespace NAV_HR_WINDOW
{
    public class Core
    {

        
        //Retrieving the noSeries from Navision
        public DataTable getNumberSeries ( ) 
	    {
		    try
		    {

				//NoSeries_Service.NoSerialIntegration_Service NSeriess = new NoSeries_Service.NoSerialIntegration_Service();
				NoSeries_Service.NoSerialIntegration_Service NSeries = new NoSeries_Service.NoSerialIntegration_Service ( );

				//passing the credential to access the webservice. The user must have access on Navision and also active on the domain
				//NSeries.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria.com" );
				NSeries.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
				NSeries.PreAuthenticate = true;

			    List<NoSeries.NoSerialIntegration_Filter> NSeriesFilterArray = new List<NoSeries.NoSerialIntegration_Filter> ( );
			    NoSeries.NoSerialIntegration_Filter NSeriesFilter = new NoSeries.NoSerialIntegration_Filter ( );
			    NSeriesFilter.Field = NoSeries.NoSerialIntegration_Fields.Code;
			    NSeriesFilter.Criteria = "*";

			    
		    }
		    catch (Exception ex)
		    {
			    //Logger.Logger applog = new Logger.Logger ( );
			    //applog.FileSource = "NAV - Interface";
			    //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
			    //applog.Logger ( ex.Message );
				
		    }
		    return null;

	    }

	    //Retrieving the responsibility center from Navision
	    public DataTable getResponsibiltyCenters (string _type )
	    {
		    DataTable tblRC = new DataTable ( "RC" );
		    try 
		    {
				RCenter_Service.ResponsibilityCenter_Service RC = new RCenter_Service.ResponsibilityCenter_Service ( );
			    //passing the credential to access the webservice. The user must have access on Navision and also active on the domain
			    //RC.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria.com" );
				RC.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
				RC.PreAuthenticate = true;
			    List<RCenter_Service.ResponsibilityCenter_Filter> RCFilterArray = new List<RCenter_Service.ResponsibilityCenter_Filter> ( );
				RCenter_Service.ResponsibilityCenter_Filter RCFilter = new RCenter_Service.ResponsibilityCenter_Filter ( );
                if (_type == "Appraisal")
                {
                    RCFilter.Field = RCenter_Service.ResponsibilityCenter_Fields.Confirmation;
                    RCFilter.Criteria = "true";
                }
                else 
                {
                    RCFilter.Field = RCenter_Service.ResponsibilityCenter_Fields.Code;
                    RCFilter.Criteria = "*";
                }
			    
			    RCFilterArray.Add ( RCFilter );

                // Runs the actual search.
                RCenter_Service.ResponsibilityCenter[] results = RC.ReadMultiple ( RCFilterArray.ToArray ( ), null, 1000 );

			    // creating table datable to hold the responsibility centers from NAV
			    

			    tblRC.Columns.Add ( new DataColumn ( "Code", typeof ( string ) ) );
			    tblRC.Columns.Add ( new DataColumn ( "Name", typeof ( string ) ) );
			    int i = 0;
			    while (i < results.Length)
			    {

				    tblRC.Rows.Add ( results[i].Code, results[i].Name );
				    i++;
			    }

			    
		    }
		    catch (Exception ex)
		    {
                //return ex.Message;
			    //Logger.Logger applog = new Logger.Logger ( );
			    //applog.FileSource = "NAV - Interface";
			    //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
			    //applog.Logger ( ex.Message );
		    }


            return tblRC;

	    }

        public string getResponsibiltyCenterss(string _type)
        {
            DataTable tblRC = new DataTable("RC");
            try
            {
                RCenter_Service.ResponsibilityCenter_Service RC = new RCenter_Service.ResponsibilityCenter_Service();
                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain
                //RC.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria.com" );

                RC.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                RC.PreAuthenticate = true;
                List<RCenter_Service.ResponsibilityCenter_Filter> RCFilterArray = new List<RCenter_Service.ResponsibilityCenter_Filter>();
                RCenter_Service.ResponsibilityCenter_Filter RCFilter = new RCenter_Service.ResponsibilityCenter_Filter();
                if (_type == "Appraisal")
                {
                    RCFilter.Field = RCenter_Service.ResponsibilityCenter_Fields.Confirmation;
                    RCFilter.Criteria = "true";
                }
                else
                {
                    RCFilter.Field = RCenter_Service.ResponsibilityCenter_Fields.Code;
                    RCFilter.Criteria = "*";
                }

                RCFilterArray.Add(RCFilter);

                // Runs the actual search.
                RCenter_Service.ResponsibilityCenter[] results = RC.ReadMultiple(RCFilterArray.ToArray(), null, 1000);

                // creating table datable to hold the responsibility centers from NAV


                tblRC.Columns.Add(new DataColumn("Code", typeof(string)));
                tblRC.Columns.Add(new DataColumn("Name", typeof(string)));
                int i = 0;
                while (i < results.Length)
                {

                    tblRC.Rows.Add(results[i].Code, results[i].Name);
                    i++;
                }


            }
            catch (Exception ex)
            {
                return "An error occurred: " + ex.Message;
                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
                //applog.Logger ( ex.Message );
            }


            return tblRC.Rows.Count.ToString();

        }

        //Retrieving leave types from Navision
        public DataTable getLeaveTypes ( )
	    {
		    // creating table datable to hold the leave types from NAV
		    DataTable tblLeaveTypes = new DataTable ( "LeaveTypes" );
		    try 
		    {

				LeaveTypes_Service.LeaveTypes_Service LTypes = new LeaveTypes_Service.LeaveTypes_Service ( );
				//passing the credential to access the webservice. The user must have access on Navision and also active on the domain

				//LTypes.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria.com" );
				LTypes.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
				LTypes.PreAuthenticate = true;
			    List<LeaveTypes_Service.LeaveTypes_Filter> LeaveTypeFilterArray = new List<LeaveTypes_Service.LeaveTypes_Filter> ( );

				LeaveTypes_Service.LeaveTypes_Filter LTypeFilter = new LeaveTypes_Service.LeaveTypes_Filter ( );
			    LTypeFilter.Field = LeaveTypes_Service.LeaveTypes_Fields.Code;
			    LTypeFilter.Criteria = "*";
			    LeaveTypeFilterArray.Add ( LTypeFilter );

				// Runs the actual search.
				LeaveTypes_Service.LeaveTypes[] results = LTypes.ReadMultiple ( LeaveTypeFilterArray.ToArray ( ), null, 100 );

			    

			    tblLeaveTypes.Columns.Add ( new DataColumn ( "Code", typeof ( string ) ) );
			    tblLeaveTypes.Columns.Add ( new DataColumn ( "Description", typeof ( string ) ) );
			    int i = 0;
			    while (i < results.Length)
			    {

				    tblLeaveTypes.Rows.Add ( results[i].Code, results[i].Description );
				    i++;
			    }

			    

		    }
		    catch (Exception ex)
		    {
				
			    //Logger.Logger applog = new Logger.Logger ( );
			    //applog.FileSource = "NAV - Interface";
			    //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
			    //applog.Logger ( ex.Message );
		    }

		    return tblLeaveTypes;

	    }

	    //Retrieving HR Setup details from Navision
	    public DataTable getHRSetup ( )
	    {
		    DataTable tblHRSetup = new DataTable ( "HRSetup" );
		    try 
		    {

				HRSetup_Service.HRSetup_Service hrSetup = new HRSetup_Service.HRSetup_Service ( );
				//passing the credential to access the webservice. The user must have access on Navision and also active on the domain

				//hrSetup.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria.com" );
				hrSetup.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
				hrSetup.PreAuthenticate = true;
			    List<HRSetup_Service.HRSetup_Filter> hrSetupFilterArray = new List<HRSetup_Service.HRSetup_Filter> ( );

				HRSetup_Service.HRSetup_Filter hrSetupFilter = new HRSetup_Service.HRSetup_Filter ( );
			    hrSetupFilter.Field = HRSetup_Service.HRSetup_Fields.Appraisal_Nos;
			    hrSetupFilter.Criteria = "*";
			    hrSetupFilterArray.Add ( hrSetupFilter );

				// Runs the actual search.
				HRSetup_Service.HRSetup[] results = hrSetup.ReadMultiple ( hrSetupFilterArray.ToArray ( ), null, 100 );

			    // creating table datable to hold HR setup from NAV
			    

			    tblHRSetup.Columns.Add ( new DataColumn ( "CurLeavePeriod", typeof ( string ) ) );
			    tblHRSetup.Columns.Add ( new DataColumn ( "LeaveAppBefore", typeof ( int ) ) );
			    tblHRSetup.Columns.Add ( new DataColumn ( "TrainingAppBefore", typeof ( int ) ) );
                tblHRSetup.Columns.Add (new DataColumn  ( "MealAmount", typeof(double)));

                int i = 0;
			    while (i < results.Length)
			    {

				    tblHRSetup.Rows.Add ( results[i].Current_Leave_Period, results[i].Leave_Application_Before, results[i].Training_Application_Before, results[i].Meal_Amount);

                    


                    i++;
			    }

			    

		    }
		    catch (Exception ex)
		    {
			    //Logger.Logger applog = new Logger.Logger ( );
			    //applog.FileSource = "NAV - Interface";
			    //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
			    //applog.Logger ( ex.Message );
		    }

		    return tblHRSetup;

	    }


        public decimal getItemQuantityInStore(string itemNo)
        {
            
            try
            {
                ItemLedgerEntries_Service.ItemLedgerEntries_Service itemledgerEntries = new ItemLedgerEntries_Service.ItemLedgerEntries_Service();

                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain

                itemledgerEntries.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                itemledgerEntries.PreAuthenticate = true;
                List<ItemLedgerEntries_Service.ItemLedgerEntries_Filter> itemLedgerFilterArray = new List<ItemLedgerEntries_Service.ItemLedgerEntries_Filter>();


                ItemLedgerEntries_Service.ItemLedgerEntries_Filter itemLedgerFilter = new ItemLedgerEntries_Service.ItemLedgerEntries_Filter();

                itemLedgerFilter.Field = ItemLedgerEntries_Service.ItemLedgerEntries_Fields.Item_No;
                itemLedgerFilter.Criteria = itemNo;
                itemLedgerFilterArray.Add(itemLedgerFilter);

                // Runs the actual search.
                ItemLedgerEntries_Service.ItemLedgerEntries[] results = itemledgerEntries.ReadMultiple(itemLedgerFilterArray.ToArray(), null, 10000);


                decimal QtyInStore = 0;
                for (int i = 0; i < results.Length; i++)
                {

                    QtyInStore = QtyInStore + results[i].Quantity;

                }

                return QtyInStore;

                

                

            }
            catch (Exception ex)
            {

                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }
            
            return 0;

        }


        //Retrieving EmployeeDetails details from Navision
        public DataTable getProbationConfirmationList()
        {
            DataTable tblProbationConfirmationList = new DataTable("ProbationConfirmations");
            try
            {

                ProbationConfirmationList_Service.ProbationConfirmationList_Service empConfirmationList = new ProbationConfirmationList_Service.ProbationConfirmationList_Service();
                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain

                //empList.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria.com" );
                empConfirmationList.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                empConfirmationList.PreAuthenticate = true;
                List<ProbationConfirmationList_Service.ProbationConfirmationList_Filter> empListFilterArray = new List<ProbationConfirmationList_Service.ProbationConfirmationList_Filter>();

                ProbationConfirmationList_Service.ProbationConfirmationList_Filter empListFilter = new ProbationConfirmationList_Service.ProbationConfirmationList_Filter();
                empListFilter.Field = ProbationConfirmationList_Service.ProbationConfirmationList_Fields.Application_No;
                empListFilter.Criteria = "*";
                empListFilterArray.Add(empListFilter);

                // Runs the actual search.

                ProbationConfirmationList_Service.ProbationConfirmationList[] results = empConfirmationList.ReadMultiple(empListFilterArray.ToArray(), null, 1000);

                tblProbationConfirmationList.Columns.Add(new DataColumn("ApplicationNo", typeof(string)));
                tblProbationConfirmationList.Columns.Add(new DataColumn("EmployeeNo", typeof(string)));
                tblProbationConfirmationList.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
                tblProbationConfirmationList.Columns.Add(new DataColumn("EmploymentDate", typeof(DateTime)));
                tblProbationConfirmationList.Columns.Add(new DataColumn("AppraisalType", typeof(string)));
               

                int i = 0;
                while (i < results.Length)
                {


                    tblProbationConfirmationList.Rows.Add(results[i].Application_No,results[i].Employee_No, results[i].Employee_Name, results[i].Date_of_Employment, results[i].Appraisal_Type );
                    i++;
                }


            }
            catch (Exception ex)
            {
                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
                //applog.Logger ( ex.Message );
            }

            return tblProbationConfirmationList;
        }

        public ConfirmationProbation getProbationConfirmation(string _applicationNo )
        {
            
            ConfirmationProbation __ConfirmationProbation = new ConfirmationProbation();

            try
            {

                ProbationConfirmationCard_Service.ConfirmationCard_Service empConfirmation = new ProbationConfirmationCard_Service.ConfirmationCard_Service();
                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain

                //empList.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria.com" );
                empConfirmation.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                empConfirmation.PreAuthenticate = true;
                List<ProbationConfirmationCard_Service.ConfirmationCard_Filter> empConfFilterArray = new List<ProbationConfirmationCard_Service.ConfirmationCard_Filter>();

                ProbationConfirmationCard_Service.ConfirmationCard_Filter empConfFilter = new ProbationConfirmationCard_Service.ConfirmationCard_Filter();
                empConfFilter.Field = ProbationConfirmationCard_Service.ConfirmationCard_Fields.Application_No;
                empConfFilter.Criteria = _applicationNo;
                empConfFilterArray.Add(empConfFilter);

                // Runs the actual search.

                ProbationConfirmationCard_Service.HR_Confirmation_KPI_A gg;
                ProbationConfirmationCard_Service.HR_Confirmation_KPI_C dd;


                // ProbationConfirmationCard_Service.Appraisal_Type.

                ProbationConfirmationCard_Service.ConfirmationCard[] results = empConfirmation.ReadMultiple(empConfFilterArray.ToArray(), null, 1000);

                int i = 0;
                while (i < results.Length)
                {

                    var _ConfirmationProbation = new ConfirmationProbation

                        {
                            ApplicationNo = results[0].Application_No,
                            DevelopmentAreas = results[0].Development_Areas,
                            Comment = results[0].Comment,
                            AppraisalType = results[0].Appraisal_Type.ToString(),
                            Department = results[0].Department,
                            EmployeeComment = results[0].Employee_Comment,
                            EmployeeName = results[0].Employee_Name,
                            EmployeeNo = results[0].Employee_No,
                            EmploymentDate = results[0].Date_of_Employment,
                            EndDate = results[0].End_Date,
                            StartDate = results[0].Start_Date,
                            KPI_Score = results[0].KPI_Score,
                            Level = results[0].Level,
                            Responsibility_Center = results[0].Responsibility_Center,
                            ReviewDate = results[0].Date_of_Review,
                            Score = results[0].Score,
                            Second_Line_Supervisor = results[0].Second_Line_Supervisor,
                            Second_Line_Supervisor_Comment = results[0].Second_Line_Supervisor_Comment,
                            Status = results[0].Status.ToString(),
                            Supervisor = results[0].Supervisor,
                            Training_Ideas = results[0].Training_Ideas,
                            User_ID = results[0].User_ID,
                            HR_Confirmation_Lines = results[0].HR_Confirmation_Lines,
                            HR_CONFIRMATION_KPI_A = results[0].HR_Confirmation_KPI_A,
                            HR_CONFIRMATION_KPI_B = results[0].HR_KPI_Confirmation_B,
                            HR_CONFIRMATION_KPI_C = results[0].HR_Confirmation_KPI_C,
                            HR_CONFIRMATION_KPI_D = results[0].HR_Confirmation_KPI_D,

                        };
                    i++;
                    __ConfirmationProbation = _ConfirmationProbation;
                }
                

            }
            catch (Exception ex)
            {
                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
                //applog.Logger ( ex.Message );
            }

            return __ConfirmationProbation;
        }


        //Retrieving EmployeeDetails details from Navision
        public bool getEmployeeDetail (string userID )
	    {
		    DataTable tblEmployeeDetails = new DataTable ( "EmployeeDetails" );
		    try
		    {


                HREmployeeList.HREmployeeListNew_Service empList = new HREmployeeList.HREmployeeListNew_Service( );
				//passing the credential to access the webservice. The user must have access on Navision and also active on the domain

				empList.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
				empList.PreAuthenticate = true;
			    List<HREmployeeList.HREmployeeListNew_Filter> empListFilterArray = new List<HREmployeeList.HREmployeeListNew_Filter> ( );

                HREmployeeList.HREmployeeListNew_Filter empListFilter = new HREmployeeList.HREmployeeListNew_Filter( );
			    empListFilter.Field = HREmployeeList.HREmployeeListNew_Fields.User_ID; 
			    empListFilter.Criteria = userID;
			    empListFilterArray.Add ( empListFilter );

                // Runs the actual search.

                HREmployeeList.HREmployeeListNew[] results = empList.ReadMultiple ( empListFilterArray.ToArray ( ), null, 1000 );

			    tblEmployeeDetails.Columns.Add ( new DataColumn ( "No", typeof ( string ) ) );
			    tblEmployeeDetails.Columns.Add ( new DataColumn ( "UserID", typeof ( string ) ) );
			    tblEmployeeDetails.Columns.Add ( new DataColumn ( "FirstName", typeof ( string ) ) );
			    tblEmployeeDetails.Columns.Add ( new DataColumn ( "MiddleName", typeof ( string ) ) );
			    tblEmployeeDetails.Columns.Add ( new DataColumn ( "LastName", typeof ( string ) ) );
			    tblEmployeeDetails.Columns.Add ( new DataColumn ( "JobTitle", typeof ( string ) ) );
			    tblEmployeeDetails.Columns.Add ( new DataColumn ( "ContractType", typeof ( string ) ) );
			    tblEmployeeDetails.Columns.Add ( new DataColumn ( "CompanyEmail", typeof ( string ) ) );

			    //tblEmployeeDetails.Columns.Add ( new DataColumn ( "DepartmentCode", typeof ( string ) ) );

			    int i = 0;
			    while (i < results.Length)
			    {
                    

                    tblEmployeeDetails.Rows.Add ( results[i].No, results[i].User_ID, results[i].First_Name, results[i].Middle_Name, results[i].Last_Name, results[i].Job_Title, results[i].Employment_Type, results[i].Company_E_Mail );
				    i++;
			    }

			    
		    }
		    catch (Exception ex)
		    {

                return false;
			    //Logger.Logger applog = new Logger.Logger ( );
			    //applog.FileSource = "NAV - Interface";
			    //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
			    //applog.Logger ( ex.Message );
		    }

            //return tblEmployeeDetails;

            return true;

	    }

        public DataTable getEmployeeDetails(string userID)
        {
            DataTable tblEmployeeDetails = new DataTable("EmployeeDetails");
            try
            {

                HREmployeeList.HREmployeeListNew_Service empList = new HREmployeeList.HREmployeeListNew_Service();
                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain

                empList.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                empList.PreAuthenticate = true;
                List<HREmployeeList.HREmployeeListNew_Filter> empListFilterArray = new List<HREmployeeList.HREmployeeListNew_Filter>();

                HREmployeeList.HREmployeeListNew_Filter empListFilter = new HREmployeeList.HREmployeeListNew_Filter();
                empListFilter.Field = HREmployeeList.HREmployeeListNew_Fields.User_ID;
                empListFilter.Criteria = userID;
                empListFilterArray.Add(empListFilter);

                // Runs the actual search.

                HREmployeeList.HREmployeeListNew[] results = empList.ReadMultiple(empListFilterArray.ToArray(), null, 1000);

                tblEmployeeDetails.Columns.Add(new DataColumn("No", typeof(string)));
                tblEmployeeDetails.Columns.Add(new DataColumn("UserID", typeof(string)));
                tblEmployeeDetails.Columns.Add(new DataColumn("FirstName", typeof(string)));
                tblEmployeeDetails.Columns.Add(new DataColumn("MiddleName", typeof(string)));
                tblEmployeeDetails.Columns.Add(new DataColumn("LastName", typeof(string)));
                tblEmployeeDetails.Columns.Add(new DataColumn("JobTitle", typeof(string)));
                tblEmployeeDetails.Columns.Add(new DataColumn("ContractType", typeof(string)));
                tblEmployeeDetails.Columns.Add(new DataColumn("CompanyEmail", typeof(string)));

                //tblEmployeeDetails.Columns.Add ( new DataColumn ( "DepartmentCode", typeof ( string ) ) );

                int i = 0;
                while (i < results.Length)
                {

                    tblEmployeeDetails.Rows.Add(results[i].No, results[i].User_ID, results[i].First_Name, results[i].Middle_Name, results[i].Last_Name, results[i].Job_Title, results[i].Employment_Type, results[i].Company_E_Mail);
                    i++;

                }


            }
            catch (Exception ex)
            {

                //return false;
                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
                //applog.Logger ( ex.Message );

            }

            return tblEmployeeDetails;

           // return true;

        }


        //Retrieving the list of leave applications per employee
        public DataTable getLeaveAcknowledgmentList ( string UserID )
	    {
		    DataTable tblLeaveAckList = new DataTable ( "LeaveAckList" );
		    try
		    {

			    LeaveAcknowledgmentList.LeaveAcknowledgmentList_Service myLeaveAppAcks = new LeaveAcknowledgmentList.LeaveAcknowledgmentList_Service ( );
			    
			    //passing the credential to access the webservice. The user must have access on Navision and also active on the domain

			    //myLeaveAppAcks.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria.com" );
				myLeaveAppAcks.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
				myLeaveAppAcks.PreAuthenticate = true;

			    List<LeaveAcknowledgmentList.LeaveAcknowledgmentList_Filter> myLeavesAckFilterArray = new List<LeaveAcknowledgmentList.LeaveAcknowledgmentList_Filter> ( );


			    LeaveAcknowledgmentList.LeaveAcknowledgmentList_Filter myLeavesAckListFilter = new LeaveAcknowledgmentList.LeaveAcknowledgmentList_Filter ( );


			    LeaveAcknowledgmentList.LeaveAcknowledgmentList_Filter myLeavesAckStatusFilter = new LeaveAcknowledgmentList.LeaveAcknowledgmentList_Filter ( );


			    myLeavesAckListFilter.Field = LeaveAcknowledgmentList.LeaveAcknowledgmentList_Fields.User_ID ;
			    myLeavesAckListFilter.Criteria = UserID;

			    myLeavesAckStatusFilter.Field = LeaveAcknowledgmentList.LeaveAcknowledgmentList_Fields.Status;
			    myLeavesAckStatusFilter.Criteria = "<>Approved&<>Updated";
			    //myLeavesStatusFilter.Criteria = "<> Resumed & <> Posted";
			    //myLeavesAckStatusFilter.Criteria = "*";

			    myLeavesAckFilterArray.Add ( myLeavesAckListFilter );
			    myLeavesAckFilterArray.Add ( myLeavesAckStatusFilter );

			    // Runs the actual search.

			    LeaveAcknowledgmentList.LeaveAcknowledgmentList [] results = myLeaveAppAcks.ReadMultiple ( myLeavesAckFilterArray.ToArray ( ), null, 1000 );

			    tblLeaveAckList.Columns.Add ( new DataColumn ( "ApplicationNo", typeof ( string ) ) );
			    tblLeaveAckList.Columns.Add ( new DataColumn ( "LeaveNo", typeof ( string ) ) );
			    tblLeaveAckList.Columns.Add ( new DataColumn ( "DaysApplied", typeof ( string ) ) );
			    tblLeaveAckList.Columns.Add ( new DataColumn ( "Status", typeof ( string ) ) );
			    tblLeaveAckList.Columns.Add ( new DataColumn ( "UserID", typeof ( string ) ) );


			    int i = 0;
			    while (i < results.Length)
			    {

				    tblLeaveAckList.Rows.Add ( results[i].No , results[i].Leave_No , results[i].Days_Applied , results[i].Status , results[i].User_ID  );
				    i++;

			    }


		    }
		    catch (Exception ex)
		    {
			    //Logger.Logger applog = new Logger.Logger ( );
			    //applog.FileSource = "NAV - Interface";
			    //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
			    //applog.Logger ( ex.Message );
		    }

		    return tblLeaveAckList;

	    }


	    //Retrieving the list of Posted leave applications per employee
	   // public DataTable getPostedLeaveApplicationList ( string EmployeeNo )
	   // {
		  //  DataTable tblApplicationList = new DataTable ( "ApplicationList" );
		  //  try
		  //  {

			 //   LeaveApplicationList.LeaveApplicationAll_Service myLeaveApps = new LeaveApplicationList.LeaveApplicationAll_Service ( );
				////passing the credential to access the webservice. The user must have access on Navision and also active on the domain

				////myLeaveApps.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria.com" );
				//myLeaveApps.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
				//myLeaveApps.PreAuthenticate = true;
			 //   List<LeaveApplicationList.LeaveApplicationAll_Filter> myLeavesListFilterArray = new List<LeaveApplicationList.LeaveApplicationAll_Filter> ( );

			 //   LeaveApplicationList.LeaveApplicationAll_Filter myLeavesListFilter = new LeaveApplicationList.LeaveApplicationAll_Filter ( );
			 //   LeaveApplicationList.LeaveApplicationAll_Filter myLeavesStatusFilter = new LeaveApplicationList.LeaveApplicationAll_Filter ( );


			 //   myLeavesListFilter.Field = LeaveApplicationList.LeaveApplicationAll_Fields.Employee_No;
			 //   myLeavesListFilter.Criteria = EmployeeNo;

			 //   myLeavesStatusFilter.Field = LeaveApplicationList.LeaveApplicationAll_Fields.Status;
			 //   //myLeavesStatusFilter.Criteria = "<> Resumed & <> Posted";
			 //   myLeavesStatusFilter.Criteria = "Posted";

			 //   myLeavesListFilterArray.Add ( myLeavesListFilter );
			 //   myLeavesListFilterArray.Add ( myLeavesStatusFilter );

			 //   // Runs the actual search.

			 //   LeaveApplicationList.LeaveApplicationAll[] results = myLeaveApps.ReadMultiple ( myLeavesListFilterArray.ToArray ( ), null, 1000 );

			 //   tblApplicationList.Columns.Add ( new DataColumn ( "ApplicationNo", typeof ( string ) ) );
			 //   tblApplicationList.Columns.Add ( new DataColumn ( "EmployeeNo", typeof ( string ) ) );
			 //   tblApplicationList.Columns.Add ( new DataColumn ( "EmployeeName", typeof ( string ) ) );
			 //   tblApplicationList.Columns.Add ( new DataColumn ( "LeaveType", typeof ( string ) ) );
			 //   tblApplicationList.Columns.Add ( new DataColumn ( "DaysApplied", typeof ( string ) ) );
			 //   tblApplicationList.Columns.Add ( new DataColumn ( "StartDate", typeof ( DateTime ) ) );
			 //   tblApplicationList.Columns.Add ( new DataColumn ( "EndDate", typeof ( DateTime ) ) );
			 //   tblApplicationList.Columns.Add ( new DataColumn ( "Releaver", typeof ( string ) ) );
			 //   tblApplicationList.Columns.Add ( new DataColumn ( "Status", typeof ( string ) ) );


			 //   int i = 0;
			 //   while (i < results.Length)
			 //   {

				//    tblApplicationList.Rows.Add ( results[i].Application_Code, results[i].Employee_No, results[i].Names, results[i].Leave_Type, results[i].Days_Applied, results[i].Start_Date, results[i].Return_Date, results[i].Reliever_Name, results[i].Status );
				//    i++;
			 //   }


		  //  }
		  //  catch (Exception ex)
		  //  {
			 //   //Logger.Logger applog = new Logger.Logger ( );
			 //   //applog.FileSource = "NAV - Interface";
			 //   //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
			 //   //applog.Logger ( ex.Message );
		  //  }

		  //  return tblApplicationList;
	   // }


	    //Retrieving the list of leave applications per employee
	    public DataTable getLeaveApplicationList (string EmployeeNo )
	    {
		    DataTable tblApplicationList = new DataTable ( "ApplicationList" );
		    try
		    {

				LeaveApplicationList_Service.LeaveApplicationAll_Service myLeaveApps = new LeaveApplicationList_Service.LeaveApplicationAll_Service ( );
			    //passing the credential to access the webservice. The user must have access on Navision and also active on the domain

			    //myLeaveApps.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria.com" );
				myLeaveApps.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
				myLeaveApps.PreAuthenticate = true;
			    List<LeaveApplicationList_Service.LeaveApplicationAll_Filter> myLeavesListFilterArray = new List<LeaveApplicationList_Service.LeaveApplicationAll_Filter> ( );

				LeaveApplicationList_Service.LeaveApplicationAll_Filter myLeavesListFilter = new LeaveApplicationList_Service.LeaveApplicationAll_Filter ( );
				LeaveApplicationList_Service.LeaveApplicationAll_Filter myLeavesStatusFilter = new LeaveApplicationList_Service.LeaveApplicationAll_Filter ( );


			    myLeavesListFilter.Field = LeaveApplicationList_Service.LeaveApplicationAll_Fields.Employee_No;
			    myLeavesListFilter.Criteria = EmployeeNo;

			    myLeavesStatusFilter.Field = LeaveApplicationList_Service.LeaveApplicationAll_Fields.Status ;
			    myLeavesStatusFilter.Criteria = "<> Resumed & <> Posted & <> Canceled";

			    myLeavesListFilterArray.Add ( myLeavesListFilter );
			    myLeavesListFilterArray.Add ( myLeavesStatusFilter );

				// Runs the actual search.

				LeaveApplicationList_Service.LeaveApplicationAll[]  results = myLeaveApps.ReadMultiple ( myLeavesListFilterArray.ToArray ( ), null, 1000 );

			    tblApplicationList.Columns.Add ( new DataColumn ( "ApplicationNo", typeof ( string ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "EmployeeNo", typeof ( string ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "EmployeeName", typeof ( string ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "LeaveType", typeof ( string ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "DaysApplied", typeof ( string ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "StartDate", typeof (  DateTime ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "EndDate", typeof ( DateTime ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "Releaver", typeof ( string ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "Status", typeof ( string ) ) );


			    int i = 0;
			    while (i < results.Length)
			    {

				    tblApplicationList.Rows.Add ( results[i].Application_Code, results[i].Employee_No, results[i].Names, results[i].Leave_Type, results[i].Days_Applied, results[i].Start_Date, results[i].Return_Date , results[i].Reliever_Name, results[i].Status  );
				    i++;
			    }


		    }
		    catch (Exception ex)
		    {
			    //Logger.Logger applog = new Logger.Logger ( );
			    //applog.FileSource = "NAV - Interface";
			    //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
			    //applog.Logger ( ex.Message );
		    }

		    return tblApplicationList;
	    }


	    //Retrieving Account chart
	   // public DataTable getAccountChart ( string EmployeeNo )
	   // {
		  //  DataTable tblApplicationList = new DataTable ( "AccountChart" );
		  //  try
		  //  {

			 //   AccountChart.AccChart_Service acChart = new AccountChart.AccChart_Service ( );
			 //   acChart.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria" );
				

				//acChart.PreAuthenticate = true;

			 //   List<AccountChart.AccChart_Filter> myAccChartFilterArray = new List<AccountChart.AccChart_Filter> ( );
			 //   AccountChart.AccChart_Filter myAccChartFilter = new AccountChart.AccChart_Filter ( );

			 //   myAccChartFilter.Field = AccountChart.AccChart_Fields.Account_Type;
 

			 //   LeaveApplicationList.LeaveApplicationAll_Service myLeaveApps = new LeaveApplicationList.LeaveApplicationAll_Service ( );
			 //   //passing the credential to access the webservice. The user must have access on Navision and also active on the domain

			 //   myLeaveApps.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria" );
			 //   myLeaveApps.PreAuthenticate = true;
			 //   List<LeaveApplicationList.LeaveApplicationAll_Filter> myLeavesListFilterArray = new List<LeaveApplicationList.LeaveApplicationAll_Filter> ( );

			 //   LeaveApplicationList.LeaveApplicationAll_Filter myLeavesListFilter = new LeaveApplicationList.LeaveApplicationAll_Filter ( );
			 //   LeaveApplicationList.LeaveApplicationAll_Filter myLeavesStatusFilter = new LeaveApplicationList.LeaveApplicationAll_Filter ( );


			 //   myLeavesListFilter.Field = LeaveApplicationList.LeaveApplicationAll_Fields.Employee_No;
			 //   myLeavesListFilter.Criteria = EmployeeNo;

			 //   myLeavesStatusFilter.Field = LeaveApplicationList.LeaveApplicationAll_Fields.Status;
			 //   myLeavesStatusFilter.Criteria = "<> Resumed & <> Posted";

			 //   myLeavesListFilterArray.Add ( myLeavesListFilter );
			 //   myLeavesListFilterArray.Add ( myLeavesStatusFilter );

			 //   // Runs the actual search.

			 //   LeaveApplicationList.LeaveApplicationAll[] results = myLeaveApps.ReadMultiple ( myLeavesListFilterArray.ToArray ( ), null, 1000 );

			 //   tblApplicationList.Columns.Add ( new DataColumn ( "ApplicationNo", typeof ( string ) ) );
			 //   tblApplicationList.Columns.Add ( new DataColumn ( "EmployeeNo", typeof ( string ) ) );
			 //   tblApplicationList.Columns.Add ( new DataColumn ( "EmployeeName", typeof ( string ) ) );
			 //   tblApplicationList.Columns.Add ( new DataColumn ( "LeaveType", typeof ( string ) ) );
			 //   tblApplicationList.Columns.Add ( new DataColumn ( "DaysApplied", typeof ( string ) ) );
			 //   tblApplicationList.Columns.Add ( new DataColumn ( "StartDate", typeof ( DateTime ) ) );
			 //   tblApplicationList.Columns.Add ( new DataColumn ( "EndDate", typeof ( DateTime ) ) );
			 //   tblApplicationList.Columns.Add ( new DataColumn ( "Releaver", typeof ( string ) ) );
			 //   tblApplicationList.Columns.Add ( new DataColumn ( "Status", typeof ( string ) ) );


			 //   int i = 0;
			 //   while (i < results.Length)
			 //   {

				//    tblApplicationList.Rows.Add ( results[i].Application_Code, results[i].Employee_No, results[i].Names, results[i].Leave_Type, results[i].Days_Applied, results[i].Start_Date, results[i].Return_Date, results[i].Reliever_Name, results[i].Status );
				//    i++;
			 //   }


		  //  }
		  //  catch (Exception ex)
		  //  {
			 //   //Logger.Logger applog = new Logger.Logger ( );
			 //   //applog.FileSource = "NAV - Interface";
			 //   //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
			 //   //applog.Logger ( ex.Message );
		  //  }

		  //  return tblApplicationList;
	   // }


	    //Retrieving employee Leave for edit
	    public DataTable getLeaveApplicationForEdit ( string LeaveNo )
	    {
		    DataTable tblApplicationList = new DataTable ( "ApplicationList" );
		    try
		    {
				LeaveCard_Service.LeaveApplication_Service myLeaveApp = new LeaveCard_Service.LeaveApplication_Service ( );  
			    
			    //passing the credential to access the webservice. The user must have access on Navision and also active on the domain

			    //myLeaveApp.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria.com" );
				myLeaveApp.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
				myLeaveApp.PreAuthenticate = true;
			    List<LeaveCard_Service.LeaveApplication_Filter> myLeaveListFilterArray = new List<LeaveCard_Service.LeaveApplication_Filter> ( );

				LeaveCard_Service.LeaveApplication_Filter myLeaveListFilter = new LeaveCard_Service.LeaveApplication_Filter ( );

			    myLeaveListFilter.Field = LeaveCard_Service.LeaveApplication_Fields.Application_Code; 
			    myLeaveListFilter.Criteria = LeaveNo;
			    myLeaveListFilterArray.Add ( myLeaveListFilter );

				// Runs the actual search.

				LeaveCard_Service.LeaveApplication[]   results = myLeaveApp.ReadMultiple ( myLeaveListFilterArray.ToArray ( ), null, 1000 );

			    tblApplicationList.Columns.Add ( new DataColumn ( "ApplicationNo", typeof ( string ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "EmployeeNo", typeof ( string ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "EmployeeName", typeof ( string ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "LeaveType", typeof ( string ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "DaysApplied", typeof ( string ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "StartDate", typeof ( DateTime ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "EndDate", typeof ( DateTime ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "Releaver", typeof ( string ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "Status", typeof ( string ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "ApplicationDate", typeof ( DateTime ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "LeavePeriod", typeof ( string ) ) );
			    tblApplicationList.Columns.Add ( new DataColumn ( "Responsibility_Center", typeof ( string ) ) );
			    

			    int i = 0;
			    while (i < results.Length)
			    {

				    tblApplicationList.Rows.Add ( results[i].Application_Code, results[i].Employee_No, results[i].EmpName, results[i].Leave_Type, results[i].Days_Applied, results[i].Start_Date, results[i].Return_Date, results[i].Reliever_Name, results[i].Status, results[i].Application_Date, results[i].Leave_Period, results[i].Responsibility_Center );

				    i++;

			    }


		    }
		    catch (Exception ex)
		    {
			    //Logger.Logger applog = new Logger.Logger ( );
			    //applog.FileSource = "NAV - Interface";
			    //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
			    //applog.Logger ( ex.Message );
		    }

		    return tblApplicationList;
	    }



        public DataTable getApprovalEntries(string DocNo)
        {
            DataTable tblApprovalEntries = new DataTable("ApprovalEntries");
            try
            {
                SHFApprovalEntries.SHFApprovalEntries_Service myApprovalEntries = new SHFApprovalEntries.SHFApprovalEntries_Service();
                
                myApprovalEntries.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                myApprovalEntries.PreAuthenticate = true;


                List<SHFApprovalEntries.SHFApprovalEntries_Filter> myApprovalEntryFilterArray = new List<SHFApprovalEntries.SHFApprovalEntries_Filter>();

                SHFApprovalEntries.SHFApprovalEntries_Filter myApprovalEntryFilter = new SHFApprovalEntries.SHFApprovalEntries_Filter();

                myApprovalEntryFilter.Field = SHFApprovalEntries.SHFApprovalEntries_Fields.Document_No;
                myApprovalEntryFilter.Criteria = DocNo;
                myApprovalEntryFilterArray.Add(myApprovalEntryFilter);


                // Runs the actual search.

                SHFApprovalEntries.SHFApprovalEntries[] results = myApprovalEntries.ReadMultiple(myApprovalEntryFilterArray.ToArray(), null, 1000);

                tblApprovalEntries.Columns.Add(new DataColumn("DocumentNo", typeof(string)));
                tblApprovalEntries.Columns.Add(new DataColumn("ApprovalID", typeof(string)));
                tblApprovalEntries.Columns.Add(new DataColumn("Status", typeof(string)));


                int i = 0;

                while (i < results.Length)
                {

                    tblApprovalEntries.Rows.Add(results[i].Document_No, results[i].Approver_ID, results[i].Status);
                    i++;

                }


            }
            catch (Exception ex)
            {
                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
                //applog.Logger ( ex.Message );
            }

            return tblApprovalEntries;
        }


        public DataTable getLeaveApprovalEntries(string LeaveNo)
        {
            DataTable tblApprovalEntries = new DataTable("ApprovalEntries");
            try
            {

                ApprovalEntries.SHFApprovalEntries_Service myApprovalEntries = new ApprovalEntries.SHFApprovalEntries_Service();

                myApprovalEntries.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                myApprovalEntries.PreAuthenticate = true;
                List<ApprovalEntries.SHFApprovalEntries_Filter> myApprovalEntryFilterArray = new List<ApprovalEntries.SHFApprovalEntries_Filter>();

                ApprovalEntries.SHFApprovalEntries_Filter myApprovalEntryFilter = new ApprovalEntries.SHFApprovalEntries_Filter();

                myApprovalEntryFilter.Field = ApprovalEntries.SHFApprovalEntries_Fields.Document_No;
                myApprovalEntryFilter.Criteria = LeaveNo;
                myApprovalEntryFilterArray.Add(myApprovalEntryFilter);


                // Runs the actual search.

                ApprovalEntries.SHFApprovalEntries[] results = myApprovalEntries.ReadMultiple(myApprovalEntryFilterArray.ToArray(), null, 1000);

                tblApprovalEntries.Columns.Add(new DataColumn("DocumentNo", typeof(string)));
                tblApprovalEntries.Columns.Add(new DataColumn("ApprovalID", typeof(string)));
                tblApprovalEntries.Columns.Add(new DataColumn("Status", typeof(string)));


                int i = 0;

                while (i < results.Length)
                {

                    tblApprovalEntries.Rows.Add(results[i].Document_No, results[i].Approver_ID, results[i].Status);

                    i++;

                }


            }
            catch (Exception ex)
            {
                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
                //applog.Logger ( ex.Message );
            }

            return tblApprovalEntries;
        }


       // Retrieving EmployeeDetails details from Navision
        public DataTable getEmployee (string no )
	    {
		    DataTable tblEmployee = new DataTable ( "Employee" );
		    try
		    {

				EmployeeCard_Service.HREmployeeCard_Service empCard = new EmployeeCard_Service.HREmployeeCard_Service();
				//EmployeeCard.EmployeeCard_Service empCard = new EmployeeCard.EmployeeCard_Service ( );
				//passing the credential to access the webservice. The user must have access on Navision and also active on the domain

				// empCard.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria.com" );
				empCard.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
				empCard.PreAuthenticate = true;
			    List<EmployeeCard_Service.HREmployeeCard_Filter> empCardFilterArray = new List<EmployeeCard_Service.HREmployeeCard_Filter> ( );

				EmployeeCard_Service.HREmployeeCard_Filter empCardFilter = new EmployeeCard_Service.HREmployeeCard_Filter( );
			    empCardFilter.Field = EmployeeCard_Service.HREmployeeCard_Fields.No; 
			    empCardFilter.Criteria = no;
			    empCardFilterArray.Add ( empCardFilter );

				// Runs the actual search.

				EmployeeCard_Service.HREmployeeCard[]  results = empCard.ReadMultiple ( empCardFilterArray.ToArray ( ), null, 5 );


                tblEmployee.Columns.Add(new DataColumn("No", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("Title", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("UserID", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("FirstName", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("MiddleName", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("LastName", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("JobTitle", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("ContractType", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("CompanyEmail", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("Status", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("DepartmentCode", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("ApplicantName", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("JobDescription", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("SupervisorManager", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("SupervisorName", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("SupervisorEmail", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("TotalLeaveDays", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("LeaveBalance", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("TotalLeaveTaken", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("EmploymentDate", typeof(string)));
                tblEmployee.Columns.Add(new DataColumn("JobLevel", typeof(string)));


                int i = 0;
                while (i < results.Length)

                {
                    
                    tblEmployee.Rows.Add(results[0].No, results[i].Title, results[i].User_ID, results[i].First_Name, results[i].Middle_Name, results[i].Last_Name, results[i].Job_Title, results[i].Contract_Type, results[i].Company_E_Mail, results[i].Status, results[0].Department_Code, results[i].Title + '.' + results[i].Last_Name + ' ' + results[i].First_Name + ' ' + results[i].Middle_Name, results[i].Job_Description, results[i].Supervisor_Manager, results[i].SupervisorNames, results[i].SupervisorNames, results[i].Total_Leave_Days, (results[i].Total_Leave_Days - results[i].Total_Leave_Taken), results[i].Total_Leave_Taken, results[i].Date_Of_Joining_the_Company, results[i].Job_Level);

                    

                    i++;
                }


            }
		    catch (Exception ex)
		    {
			    //Logger.Logger applog = new Logger.Logger ( );
			    //applog.FileSource = "NAV - Interface";
			    //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
			    //applog.Logger ( ex.Message );
		    }

		    return tblEmployee;
	    }



        //Retrieving EmployeeDetails details from Navision

        public DataTable getPaymentCodes(string _type)
        {
            DataTable tblLocationCode = new DataTable("LocationCode");
            try
            {

                LocationCodes_Service.LocationCodes_Service locationCode = new LocationCodes_Service.LocationCodes_Service();
                locationCode.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                locationCode.PreAuthenticate = true;
                List<LocationCodes_Service.LocationCodes_Filter> lCodeFilterArray = new List<LocationCodes_Service.LocationCodes_Filter>();

                LocationCodes_Service.LocationCodes_Filter lCodeFilter = new LocationCodes_Service.LocationCodes_Filter();
                lCodeFilter.Field = LocationCodes_Service.LocationCodes_Fields.Code ;
                lCodeFilter.Criteria = _type;

                lCodeFilterArray.Add(lCodeFilter);

                if (_type== "ADVERTS")
                {

                    LocationCodes_Service.LocationCodes_Filter lsBlockedFilter = new LocationCodes_Service.LocationCodes_Filter();
                    lsBlockedFilter.Field = LocationCodes_Service.LocationCodes_Fields.Blocked;
                    lsBlockedFilter.Criteria = "No";
                    lCodeFilterArray.Add(lsBlockedFilter);
                }



                // Runs the actual search.

                LocationCodes_Service.LocationCodes[] results = locationCode.ReadMultiple(lCodeFilterArray.ToArray(), null, 100);


                tblLocationCode.Columns.Add(new DataColumn("Code", typeof(string)));
                tblLocationCode.Columns.Add(new DataColumn("Name", typeof(string)));



                int i = 0;
                while (i < results.Length)

                {

                    tblLocationCode.Rows.Add(results[0].Code, results[i].Name);



                    i++;
                }


            }
            catch (Exception ex)
            {
                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
                //applog.Logger ( ex.Message );
            }

            return tblLocationCode;
        }


        public DataTable getLocationCode(string no)
        {
            DataTable tblLocationCode = new DataTable("LocationCode");
            try
            {

                LocationCodes_Service.LocationCodes_Service locationCode = new LocationCodes_Service.LocationCodes_Service();
                
                locationCode.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                locationCode.PreAuthenticate = true;
                List<LocationCodes_Service.LocationCodes_Filter> lCodeFilterArray = new List<LocationCodes_Service.LocationCodes_Filter>();

                LocationCodes_Service.LocationCodes_Filter lCodeFilter = new LocationCodes_Service.LocationCodes_Filter();
                lCodeFilter.Field = LocationCodes_Service.LocationCodes_Fields.Global_Dimension_No;
                lCodeFilter.Criteria = no;
                lCodeFilterArray.Add(lCodeFilter);

                

                // Runs the actual search.

                LocationCodes_Service.LocationCodes[] results = locationCode.ReadMultiple(lCodeFilterArray.ToArray(), null, 100);


                tblLocationCode.Columns.Add(new DataColumn("Code", typeof(string)));
                tblLocationCode.Columns.Add(new DataColumn("Name", typeof(string)));
               
              

                int i = 0;
                while (i < results.Length)

                {

                    tblLocationCode.Rows.Add(results[0].Code, results[i].Name);

                    

                    i++;
                }


            }
            catch (Exception ex)
            {
                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
                //applog.Logger ( ex.Message );
            }

            return tblLocationCode;
        }


        public DataTable getIssueingStore()
        {
            DataTable tblIssueingStore = new DataTable("IssueingStore");
            try
            {

                LocationList_Service.LocationList_Service locationlist = new LocationList_Service.LocationList_Service();
                //EmployeeCard.EmployeeCard_Service empCard = new EmployeeCard.EmployeeCard_Service ( );
                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain

                // empCard.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria.com" );
                locationlist.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                locationlist.PreAuthenticate = true;
                List<LocationList_Service.LocationList_Filter> lCodeFilterArray = new List<LocationList_Service.LocationList_Filter>();

                LocationList_Service.LocationList_Filter lCodeFilter = new LocationList_Service.LocationList_Filter();
                lCodeFilter.Field = LocationList_Service.LocationList_Fields.Code;
                lCodeFilter.Criteria = "*";
                lCodeFilterArray.Add(lCodeFilter);

                // Runs the actual search.

                LocationList_Service.LocationList[] results = locationlist.ReadMultiple(lCodeFilterArray.ToArray(), null, 1000);

                tblIssueingStore.Columns.Add(new DataColumn("Code", typeof(string)));
                tblIssueingStore.Columns.Add(new DataColumn("Name", typeof(string)));

                int i = 0;
                while (i < results.Length)

                {

                    tblIssueingStore.Rows.Add(results[i].Code, results[i].Name);
                    i++;
                }

            }
            catch (Exception ex)
            {
                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
                //applog.Logger ( ex.Message );
            }

            return tblIssueingStore;

        }


        public String UpdateEmployeeLastAckLeaveNo ( string no, string lastLeaveCode )
	    {

		    try
		    {
				//EmployeeCard.EmployeeCard_Service empCard = new EmployeeCard.EmployeeCard_Service();
				EmployeeCard_Service.HREmployeeCard_Service empCard = new EmployeeCard_Service.HREmployeeCard_Service ( );
				//passing the credential to access the webservice. The user must have access on Navision and also active on the domain
				
				empCard.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
				//empCard.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria.com" );
			    empCard.PreAuthenticate = true;
			    List<EmployeeCard_Service.HREmployeeCard_Filter> empCardFilterArray = new List<EmployeeCard_Service.HREmployeeCard_Filter> ( );

				EmployeeCard_Service.HREmployeeCard_Filter empCardFilter = new EmployeeCard_Service.HREmployeeCard_Filter ( );
			    empCardFilter.Field = EmployeeCard_Service.HREmployeeCard_Fields.No;
			    empCardFilter.Criteria = no;
			    empCardFilterArray.Add ( empCardFilter );

				// Runs the actual search.

				EmployeeCard_Service.HREmployeeCard[] results = empCard.ReadMultiple ( empCardFilterArray.ToArray ( ), null, 100 );
			    if (results.Length > 0)
			    {

					//results[0].LastLeaveCode = lastLeaveCode;
					//results[0].LastLeaveAckCode  = lastLeaveCode;
				   // empCard.Update ( ref results[0] );
				    return "success";

			    }

			    return "No Record Found";

		    }
		    catch (Exception ex)
		    {
			    //Logger.Logger applog = new Logger.Logger ( );
			    //applog.FileSource = "NAV - Interface";
			    //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
			    //applog.Logger ( ex.Message );
			    return ex.Message;

		    }


	    }
	    
	    
	    public String   UpdateEmployeeLastLeaveNo ( string no, string lastLeaveCode )
	    {
		    
		    try
		    {

				EmployeeCard_Service.HREmployeeCard_Service empCard = new EmployeeCard_Service.HREmployeeCard_Service ( );
			    //passing the credential to access the webservice. The user must have access on Navision and also active on the domain

			    //empCard.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria.com" );
				empCard.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
				empCard.PreAuthenticate = true;
			    List<EmployeeCard_Service.HREmployeeCard_Filter> empCardFilterArray = new List<EmployeeCard_Service.HREmployeeCard_Filter> ( );

				EmployeeCard_Service.HREmployeeCard_Filter empCardFilter = new EmployeeCard_Service.HREmployeeCard_Filter ( );
			    empCardFilter.Field = EmployeeCard_Service.HREmployeeCard_Fields.No;
			    empCardFilter.Criteria = no;
			    empCardFilterArray.Add ( empCardFilter );

				// Runs the actual search.

				EmployeeCard_Service.HREmployeeCard[] results = empCard.ReadMultiple ( empCardFilterArray.ToArray ( ), null, 5 );
			    if(results.Length > 0 )
			    {

					//results[0].LastLeaveCode = lastLeaveCode;
					//empCard.Update ( ref results[0] );

					//results[0].Leave_Status = EmployeeCard_Service.Leave_Status.On_Leave;



					return "success";
 
			    }
			    return "No Record Found";

		    }
		    catch (Exception ex)
		    {
			    //Logger.Logger applog = new Logger.Logger ( );
			    //applog.FileSource = "NAV - Interface";
			    //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
			    //applog.Logger ( ex.Message );
			    return ex.Message;

		    }

		    
	    }




	    //Retrieving EmployeeDetails details from Navision
	    public DataTable getEmployeeReleaver ( string deptCode )
	    {
		    DataTable tblReleavers = new DataTable ( "Releavers" );
		    try
		    {

				ReLeavers_Service.Releavers_Service empReleavers = new ReLeavers_Service.Releavers_Service ( );

				//passing the credential to access the webservice. The user must have access on Navision and also active on the domain

				//empReleavers.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria" );
				empReleavers.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
				empReleavers.PreAuthenticate = true;
			    List<ReLeavers_Service.Releavers_Filter> empReleaversFilterArray = new List<ReLeavers_Service.Releavers_Filter> ( );

				ReLeavers_Service.Releavers_Filter empReleaversFilterArrayFilter = new ReLeavers_Service.Releavers_Filter ( );
			    empReleaversFilterArrayFilter.Field = ReLeavers_Service.Releavers_Fields.Department_Code;
			    empReleaversFilterArrayFilter.Criteria = deptCode;
			    empReleaversFilterArray.Add ( empReleaversFilterArrayFilter );

				// Runs the actual search.
				ReLeavers_Service.Releavers[] results = empReleavers.ReadMultiple ( empReleaversFilterArray.ToArray ( ), null, 100 );


			    tblReleavers.Columns.Add ( new DataColumn ( "No", typeof ( string ) ) );
			    tblReleavers.Columns.Add ( new DataColumn ( "DepartmentCode", typeof ( string ) ) );
			    tblReleavers.Columns.Add ( new DataColumn ( "LastName", typeof ( string ) ) );
			    tblReleavers.Columns.Add ( new DataColumn ( "FirstName", typeof ( string ) ) );
			    tblReleavers.Columns.Add ( new DataColumn ( "MiddleName", typeof ( string ) ) );
			    tblReleavers.Columns.Add ( new DataColumn ( "LeaveStatus", typeof ( string ) ) );


			    int i = 0;
			    while (i < results.Length)
			    {

				    tblReleavers.Rows.Add ( results[i].No, results[i].Department_Code, results[i].Last_Name, results[i].First_Name, results[i].Middle_Name, results[i].Leave_Status );
				    i++;
			    }

		    }
		    catch(Exception ex)
		    {

			    //Logger.Logger applog = new Logger.Logger ( );
			    //applog.FileSource = "NAV - Interface";
			    //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
			    //applog.Logger ( ex.Message );

		    }
		    return tblReleavers;
		    

	    }

        public CanteenApplication getCanteenApplication(string ticketNo)
        {
            //DataTable tblCanteenApp = new DataTable("CanteenApp");
            CanteenApplication _CanteenApplication = new CanteenApplication();
            try
            {


                 
                HRCanteenApplication_Service.HRCanteenApplicationCard_Service empCanteenApp = new HRCanteenApplication_Service.HRCanteenApplicationCard_Service();
                empCanteenApp.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                empCanteenApp.PreAuthenticate = true;

                List<HRCanteenApplication_Service.HRCanteenApplicationCard_Filter> empCanteenFilterArray = new List<HRCanteenApplication_Service.HRCanteenApplicationCard_Filter>();

                HRCanteenApplication_Service.HRCanteenApplicationCard_Filter CanteenFilter = new HRCanteenApplication_Service.HRCanteenApplicationCard_Filter();
                CanteenFilter.Field = HRCanteenApplication_Service.HRCanteenApplicationCard_Fields.Ticket_No;                CanteenFilter.Criteria = ticketNo;
                empCanteenFilterArray.Add(CanteenFilter);

                // Runs the actual search.
                HRCanteenApplication_Service.HRCanteenApplicationCard[] results = empCanteenApp.ReadMultiple(empCanteenFilterArray.ToArray(), null, 100);

                //HRCanteenApplicationList_Service.HRCanteenApplicationList_Fields.
                //tblCanteenApp.Columns.Add(new DataColumn("EmployeeNo", typeof(string)));
                //tblCanteenApp.Columns.Add(new DataColumn("DepartmentCode", typeof(string)));
                //tblCanteenApp.Columns.Add(new DataColumn("TicketNo", typeof(string)));
                //tblCanteenApp.Columns.Add(new DataColumn("Status", typeof(string)));
                //tblCanteenApp.Columns.Add(new DataColumn("Posted", typeof(string)));
                //tblCanteenApp.Columns.Add(new DataColumn("VisitorName", typeof(string)));
                //tblCanteenApp.Columns.Add(new DataColumn("RequestType", typeof(string)));
                //tblCanteenApp.Columns.Add(new DataColumn("ResponsibilityCenter", typeof(string)));
                //tblCanteenApp.Columns.Add(new DataColumn("RequestDate", typeof(DateTime)));
                //tblCanteenApp.Columns.Add(new DataColumn("Amount", typeof(decimal)));

                int i = 0;
                while (i < results.Length)
                {
                    _CanteenApplication.Ticket_No = results[i].Employee_No;
                    _CanteenApplication.Amount = results[i].Amount;
                    _CanteenApplication.ApplicationDate = results[i].Date;
                    _CanteenApplication.DepartmentCode = results[i].Department_Code;
                    _CanteenApplication.DepartmentName = results[i].Department_Name;
                    _CanteenApplication.StartDate = results[i].Start_Date;
                    _CanteenApplication.Status = results[i].Status.ToString();
                    _CanteenApplication.EmployeeNo = results[i].Employee_No;
                    _CanteenApplication.EmployeeName = results[i].Employee_Name;
                    _CanteenApplication.PayrollPeriod = results[i].Payroll_Period;
                    _CanteenApplication.RequestType = results[i].Request_Type.ToString();
                    _CanteenApplication.Responsibility_Center = results[i].Responsibility_Center;
                    _CanteenApplication.Transaction_Code = results[i].Transaction_Code;
                    _CanteenApplication.Transaction_Name = results[i].Transaction_Name;
                    _CanteenApplication.Visitor_Name = results[i].Visitor_Name;


                    //tblCanteenApp.Rows.Add(results[i].Employee_No, results[i].Department_Code, results[i].Ticket_No, results[i].Status, results[i].Posted, results[i].Visitor_Name, results[i].Request_Type, results[i].Responsibility_Center, results[i].Date, results[i].Amount);
                    i++;

                }

            }
            catch (Exception ex)
            {

                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }
            return _CanteenApplication;


        }

        public DataTable getCanteenApplications(string empNo)
        {
            DataTable tblCanteenApp = new DataTable("CanteenApp");
            try
            {

                HRCanteenApplicationList_Service.HRCanteenApplicationList_Service empCanteenApp = new HRCanteenApplicationList_Service.HRCanteenApplicationList_Service();
                empCanteenApp.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                empCanteenApp.PreAuthenticate = true;
                List<HRCanteenApplicationList_Service.HRCanteenApplicationList_Filter> empCanteenFilterArray = new List<HRCanteenApplicationList_Service.HRCanteenApplicationList_Filter>();
                HRCanteenApplicationList_Service.HRCanteenApplicationList_Filter CanteenFilter = new HRCanteenApplicationList_Service.HRCanteenApplicationList_Filter();
                CanteenFilter.Field = HRCanteenApplicationList_Service.HRCanteenApplicationList_Fields.Employee_No;
                CanteenFilter.Criteria = empNo;
                empCanteenFilterArray.Add(CanteenFilter);

                // Runs the actual search.
                HRCanteenApplicationList_Service.HRCanteenApplicationList[] results = empCanteenApp.ReadMultiple(empCanteenFilterArray.ToArray(), null, 100);

                //HRCanteenApplicationList_Service.HRCanteenApplicationList_Fields.

                tblCanteenApp.Columns.Add(new DataColumn("EmployeeNo", typeof(string)));
                tblCanteenApp.Columns.Add(new DataColumn("DepartmentCode", typeof(string)));
                tblCanteenApp.Columns.Add(new DataColumn("TicketNo", typeof(string)));
                tblCanteenApp.Columns.Add(new DataColumn("Status", typeof(string)));
                tblCanteenApp.Columns.Add(new DataColumn("Posted", typeof(string)));
                tblCanteenApp.Columns.Add(new DataColumn("VisitorName", typeof(string)));
                tblCanteenApp.Columns.Add(new DataColumn("RequestType", typeof(string)));
                tblCanteenApp.Columns.Add(new DataColumn("ResponsibilityCenter", typeof(string)));
                tblCanteenApp.Columns.Add(new DataColumn("RequestDate", typeof(DateTime)));
                tblCanteenApp.Columns.Add(new DataColumn("Amount", typeof(decimal)));

                int i = 0;
                while (i < results.Length)
                {
                    
                    tblCanteenApp.Rows.Add(results[i].Employee_No, results[i].Department_Code, results[i].Ticket_No, results[i].Status, results[i].Posted, results[i].Visitor_Name, results[i].Request_Type, results[i].Responsibility_Center, results[i].Date, results[i].Amount);
                    i++;
                }



            }
            catch (Exception ex)
            {

                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }
            return tblCanteenApp;


        }

        public bool DeleteStaffClaimLine(string _key)
        {
            try
            {

                StaffClaimLine_Service.StaffClaimLine_Service StaffClaimLine = new StaffClaimLine_Service.StaffClaimLine_Service();
                StaffClaimLine.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                StaffClaimLine.PreAuthenticate = true;
                StaffClaimLine.Delete(_key);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteAdvanceRequestLine(string _key)
        {
            try
            {

                StaffAdvanceLines_Service.StaffAdvanceLines_Service staffAdvLine = new StaffAdvanceLines_Service.StaffAdvanceLines_Service();
                staffAdvLine.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                staffAdvLine.PreAuthenticate = true;
                staffAdvLine.Delete(_key);
               
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public String UpdateRetirementRequestLine(RetirementLine retirementLine_)
        {
            try

            {
                WorkRetirementLine_Service.RetirementLine _retirementLine = new WorkRetirementLine_Service.RetirementLine();

                WorkRetirementLine_Service.RetirementLine_Service staffRetirementLine = new WorkRetirementLine_Service.RetirementLine_Service();
                staffRetirementLine.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                staffRetirementLine.PreAuthenticate = true;
                _retirementLine = staffRetirementLine.Read(retirementLine_.SurrenderDocNo,retirementLine_.LineNo );
                _retirementLine.Actual_Spent = retirementLine_.AmountSpent;
                staffRetirementLine.Update(ref _retirementLine);


                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        public String  DeleteRetirementRequestLine(string _key)
        {
            try

            {

                
                WorkRetirementLine_Service.RetirementLine_Service staffRetirementLine = new WorkRetirementLine_Service.RetirementLine_Service();
                staffRetirementLine.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                staffRetirementLine.PreAuthenticate = true;
                staffRetirementLine.Delete(_key);

                //staffRetirementLine.Read();

                return "Success";
            }
            catch (Exception ex)
            {
                return  ex.Message;
            }

        }

        public bool DeleteProbationConfirmationLine(string _key)
        {
            try
            {

                ProbationConfirmationLines.ConfirmationLines_Service confirmationLine_ = new ProbationConfirmationLines.ConfirmationLines_Service();
                confirmationLine_.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                confirmationLine_.PreAuthenticate = true;
                //confirmationLine_.Update(_key);
                //    PaymentRequestLines_Service.PaymentLine iii;
                //iii.d


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public bool DeletePaymentRequestLine(string _key)
        {
            try
            {

                PaymentRequestLines_Service.PaymentLine_Service paymentReqLine = new PaymentRequestLines_Service.PaymentLine_Service();
                paymentReqLine.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                paymentReqLine.PreAuthenticate = true;
                paymentReqLine.Delete(_key);
                //    PaymentRequestLines_Service.PaymentLine iii;
                //iii.d
                

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public bool DeleteStoreRequisitionLine(string _key)
        {
            try {

                StoreRequisitionLine_Service.Store_Requisition_Line_Service storeReqLine = new StoreRequisitionLine_Service.Store_Requisition_Line_Service();
                storeReqLine.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                storeReqLine.PreAuthenticate = true;
                storeReqLine.Delete(_key);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }

        public StoreRequisition getStoreRequisition(string docNo)
        {
            
            StoreRequisition _StoreReq = new StoreRequisition();
            try
            {
                
                //StaffClaimList_Service.StaffClaimList_Service empClaims

                StoreRequisition_Service.StoreRequisitionHeder_Service stoteReq = new StoreRequisition_Service.StoreRequisitionHeder_Service();
                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain
                //empReleavers.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria" );
                stoteReq.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                stoteReq.PreAuthenticate = true;
                List<StoreRequisition_Service.StoreRequisitionHeder_Filter> storeReqFilterArray = new List<StoreRequisition_Service.StoreRequisitionHeder_Filter>();

                StoreRequisition_Service.StoreRequisitionHeder_Filter storeReqFilter = new StoreRequisition_Service.StoreRequisitionHeder_Filter();
                storeReqFilter.Field = StoreRequisition_Service.StoreRequisitionHeder_Fields.No;
                storeReqFilter.Criteria = docNo;
                storeReqFilterArray.Add(storeReqFilter);

                //StoreRequisition_Service.Status.r
                // Runs the actual search.
                StoreRequisition_Service.StoreRequisitionHeder[] results = stoteReq.ReadMultiple(storeReqFilterArray.ToArray(), null, 100);

                _StoreReq.StoreRequisitionLines = results[0].Store_Requisition_Line;
                _StoreReq.DocumentNo  = results[0].No;
                _StoreReq.FunctionName = results[0].Function_Name;
                _StoreReq.BudgetCenterName = results[0].Budget_Center_Name;
                _StoreReq.IssueingStore = results[0].Issuing_Store;
                _StoreReq.Request_Date = results[0].Request_date;
                _StoreReq.Require_Date = results[0].Required_Date;
                _StoreReq.Responsibility_Center = results[0].Responsibility_Center;
                _StoreReq.Status = results[0].Status.ToString();
                _StoreReq.RequestDescription = results[0].Request_Description;
                _StoreReq.Location = results[0].Global_Dimension_1_Code;
                _StoreReq.BusinessUnit = results[0].Shortcut_Dimension_2_Code;
                
            }
            catch (Exception ex)
            {

                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }
            return _StoreReq;


        }

        public DataTable getStoreRequisitions(string empID)
        {
            DataTable tblStoreRequisitions = new DataTable("StoreRequisitions");
            try
            {

                //StaffClaimList_Service.StaffClaimList_Service empClaims

                StoreRequisitionList_Service.StoreRequisitionList_Service stoteReq = new StoreRequisitionList_Service.StoreRequisitionList_Service();
                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain
                //empReleavers.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria" );
                stoteReq.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                stoteReq.PreAuthenticate = true;
                List<StoreRequisitionList_Service.StoreRequisitionList_Filter> storeReqFilterArray = new List<StoreRequisitionList_Service.StoreRequisitionList_Filter>();

                StoreRequisitionList_Service.StoreRequisitionList_Filter storeReqFilter = new StoreRequisitionList_Service.StoreRequisitionList_Filter();
                storeReqFilter.Field = StoreRequisitionList_Service.StoreRequisitionList_Fields.User_ID;
                storeReqFilter.Criteria = empID;
                storeReqFilterArray.Add(storeReqFilter);

                // Runs the actual search.
                StoreRequisitionList_Service.StoreRequisitionList[] results = stoteReq.ReadMultiple(storeReqFilterArray.ToArray(), null, 100);

                //HRCanteenApplicationList_Service.HRCanteenApplicationList_Fields.

                

                //results[i].Budget_Center_Name
                //    results[i].Function_Name
                //    results[i].Issuing_Store
                //    results[i].No
                //    results[i].Request_date
                //     results[i].Required_Date
                //    results[i].Responsibility_Center
                //    results[i].Status
                //    results[i].Request_Description


                //String txtBudget_Center_Name;
                // String Issuing_Store;
                //  DateTime dteRequest_Date;
                //  DateTime dteRequire_Date;
                //String txtDocumentNo;
                // String txtFunctionName;
                //String txtStatus;
                //String txtRequestDescription;
                //String txtResponsibility_Center;

                tblStoreRequisitions.Columns.Add(new DataColumn("DocumentNo", typeof(string)));
                tblStoreRequisitions.Columns.Add(new DataColumn("UserID", typeof(string)));
                tblStoreRequisitions.Columns.Add(new DataColumn("RequestDate", typeof(DateTime)));
                tblStoreRequisitions.Columns.Add(new DataColumn("IssuingStore", typeof(string)));
                tblStoreRequisitions.Columns.Add(new DataColumn("Description", typeof(string)));
                tblStoreRequisitions.Columns.Add(new DataColumn("TotalAmount", typeof(string)));
                tblStoreRequisitions.Columns.Add(new DataColumn("Status", typeof(string)));
               
                int i = 0;
                while (i < results.Length)
                {

                    tblStoreRequisitions.Rows.Add(results[i].No, results[i].User_ID, results[i].Request_date, results[i].Issuing_Store,   results[i].Request_Description, results[i].TotalAmount, results[i].Status );
                    i++;

                }



            }
            catch (Exception ex)
            {

                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }
            return tblStoreRequisitions;


        }

        public StaffClaim getStaffClaim(string documentNo)
        {
            DataTable tblStaffClaim = new DataTable("StaffClaim");
            StaffClaim _staffClaim = new StaffClaim ();
            try
            {


                StaffClaim_Service.StaffClaim_Service empClaims = new StaffClaim_Service.StaffClaim_Service();

                 

                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain
                //empReleavers.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria" );
                empClaims.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                empClaims.PreAuthenticate = true;
                List<StaffClaim_Service.StaffClaim_Filter> empClaimFilterArray = new List<StaffClaim_Service.StaffClaim_Filter>();
                StaffClaim_Service.StaffClaim_Filter ClaimFilter = new StaffClaim_Service.StaffClaim_Filter();
                ClaimFilter.Field = StaffClaim_Service.StaffClaim_Fields.No;
                ClaimFilter.Criteria = documentNo;
                empClaimFilterArray.Add(ClaimFilter);

                
                // Runs the actual search.
                StaffClaim_Service.StaffClaim[] results = empClaims.ReadMultiple(empClaimFilterArray.ToArray(), null, 100);

                _staffClaim.BudgetCenterName = results[0].Budget_Center_Name;
                _staffClaim.FunctionName = results[0].Function_Name;
                _staffClaim.DocumentNo = results[0].No;
                _staffClaim.AccountNo = results[0].Account_No;
                _staffClaim.Cashier = results[0].Cashier;
                _staffClaim.Paye = results[0].Payee;
                _staffClaim.Purpose = results[0].Purpose;

                string _status = results[0].Status.ToString();

                switch (_status)
                {

                    case "Approved": 
                        _staffClaim.Status = "Approved";
                        break;

                    case "Cancelled": 
                        _staffClaim.Status = "Cancelled";
                        break;
                    case "Checking": 
                        _staffClaim.Status = "Checking";
                        break;
                    case "Cheque_Printing": 
                        _staffClaim.Status = "Cheque_Printing";
                        break;
                    case "Pending": 
                        _staffClaim.Status = "Pending";
                        break;
                    case "Pending_Approval": 
                        _staffClaim.Status = "Pending_Approval";
                        break;
                    case "Posted": 
                        _staffClaim.Status = "Posted";
                        break;

                    default:    
                        _staffClaim.Status = "";
                        break;
                }

                _staffClaim.BankName = results[0].Bank_Name ;
                _staffClaim.BankAccountNo = results[0].Paying_Bank_Account;
                _staffClaim.ClaimDate = results[0].Date;
                _staffClaim.TotalNetAmount = results[0].Total_Net_Amount;
                _staffClaim.PVLines = results[0].PVLines;
                _staffClaim.ClaimDate = results[0].Date;
                _staffClaim.Responsibility_Center = results[0].Responsibility_Center;

                

            }
            catch (Exception ex)
            {

                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }
            return _staffClaim;


        }

        public PaymentRequest getPaymentRequest(string docNo)
        {
            PaymentRequest __PaymentRequest = new PaymentRequest();
            try
            {
                PaymentRequest_Service.Payment_Request_Lines  bb= new PaymentRequest_Service.Payment_Request_Lines();
                
                

                PaymentRequest_Service.PaymentRequest_Service paymentRequest = new PaymentRequest_Service.PaymentRequest_Service();
                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain
                //empReleavers.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria" );
                paymentRequest.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                paymentRequest.PreAuthenticate = true;
                List<PaymentRequest_Service.PaymentRequest_Filter> paymentRequestFilterArray = new List<PaymentRequest_Service.PaymentRequest_Filter>();
                PaymentRequest_Service.PaymentRequest_Filter paymentRequestFilter = new PaymentRequest_Service.PaymentRequest_Filter();
                paymentRequestFilter.Field = PaymentRequest_Service.PaymentRequest_Fields.No;
                paymentRequestFilter.Criteria = docNo;
                paymentRequestFilterArray.Add(paymentRequestFilter);
               
                // Runs the actual search.
                PaymentRequest_Service.PaymentRequest[] results = paymentRequest.ReadMultiple(paymentRequestFilterArray.ToArray(), null, 100);

                var _PaymentRequest = new PaymentRequest
                {
                    Bank_Name = results[0].Bank_Name,
                    Cashier = results[0].Cashier,
                    Cheque_Type = results[0].Cheque_Type.ToString(),
                    Budget_Center_Name = results[0].Budget_Center_Name,
                    Cheque_No = results[0].Cheque_No,
                    DocumentNo = results[0].No,
                    Function_Name = results[0].Function_Name,
                    On_Behalf_Of = results[0].On_Behalf_Of,
                    Payee = results[0].Payee,
                    Payee_Account_Number = results[0].Payee_Account_Number,
                    Payment_Narration = results[0].Payment_Narration,
                    Paying_Bank_Account = results[0].Paying_Bank_Account,
                    Payment_Release_Date = results[0].Payment_Release_Date,
                    Pay_Mode = results[0].Pay_Mode.ToString (),
                    RequestDate = results[0].Date,
                    Status = results[0].Status.ToString(),
                    Responsibility_Center = results[0].Responsibility_Center,
                    Total_Payment_Amount = results[0].Total_Payment_Amount,
                    Total_Payment_Amount_LCY = results[0].Total_Payment_Amount_LCY,
                    Total_Retention_Amount = results[0].Total_Retention_Amount,
                    Total_VAT_Amount = results[0].Total_VAT_Amount,
                    Total_Witholding_Tax_Amount = results[0].Total_Witholding_Tax_Amount,
                    Total_Payment_Amount_Total_Witholding_Tax_Amount__Total_VAT_Amount__Total_Retention_Amount = results[0]._Total_Payment_Amount_Total_Witholding_Tax_Amount__Total_VAT_Amount__Total_Retention_Amount,
                    PaymentRequisitionLines = results[0].PVLines,
                    Location= results[0].Global_Dimension_1_Code,
                    Bussiness_Unit = results[0].Shortcut_Dimension_2_Code
                };

                

                __PaymentRequest = _PaymentRequest;
      


            }
            catch (Exception ex)
            {

                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }
            return __PaymentRequest;


        }

        public DataTable getPaymentVoucherList(string empNo)
        {
            DataTable tblPaymentRequest = new DataTable("PaymentRequest");
            try
            {

                //StaffClaimList_Service.StaffClaimList_Service empClaims

                PaymentRequestList_Service.PaymentRequestList_Service paymentRequest = new PaymentRequestList_Service.PaymentRequestList_Service();
                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain
                //empReleavers.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria" );
                paymentRequest.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                paymentRequest.PreAuthenticate = true;
                List<PaymentRequestList_Service.PaymentRequestList_Filter> paymentRequestFilterArray = new List<PaymentRequestList_Service.PaymentRequestList_Filter>();
                PaymentRequestList_Service.PaymentRequestList_Filter paymentRequestFilter = new PaymentRequestList_Service.PaymentRequestList_Filter();
                paymentRequestFilter.Field = PaymentRequestList_Service.PaymentRequestList_Fields.Cashier;
                paymentRequestFilter.Criteria = empNo;
                paymentRequestFilterArray.Add(paymentRequestFilter);

                // Runs the actual search.
                PaymentRequestList_Service.PaymentRequestList[] results = paymentRequest.ReadMultiple(paymentRequestFilterArray.ToArray(), null, 100);

                //HRCanteenApplicationList_Service.HRCanteenApplicationList_Fields.
                tblPaymentRequest.Columns.Add(new DataColumn("DocumentNo", typeof(string)));
                tblPaymentRequest.Columns.Add(new DataColumn("UserID", typeof(string)));
                tblPaymentRequest.Columns.Add(new DataColumn("Payee", typeof(string)));
                tblPaymentRequest.Columns.Add(new DataColumn("Narration", typeof(string)));
                tblPaymentRequest.Columns.Add(new DataColumn("Date", typeof(DateTime)));
                tblPaymentRequest.Columns.Add(new DataColumn("Status", typeof(string)));
                tblPaymentRequest.Columns.Add(new DataColumn("Cheque_No", typeof(string)));
                tblPaymentRequest.Columns.Add(new DataColumn("TotalAmount", typeof(decimal)));
                tblPaymentRequest.Columns.Add(new DataColumn("VatAmount", typeof(decimal)));
                tblPaymentRequest.Columns.Add(new DataColumn("WHTAmount", typeof(decimal)));
                tblPaymentRequest.Columns.Add(new DataColumn("NetAmount", typeof(decimal)));


                int i = 0;
                while (i < results.Length)
                {

                    tblPaymentRequest.Rows.Add(results[i].No, "Test", results[i].Cashier, "", results[i].Date, results[i].Status, results[i].Cheque_No, results[i].Total_Payment_Amount, results[i].Total_VAT_Amount, results[i].Total_Witholding_Tax_Amount, results[i].Total_Net_Amount);
                    i++;

                }



            }
            catch (Exception ex)
            {

                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }
            return tblPaymentRequest;


        }

        public DataTable getStaffAdvanceList(string accNo)
        {
            DataTable tblStaffAdvance = new DataTable("StaffAdvance");
            try
            {

                StaffAdvanceList_Service.StaffAdvanceRequests_Service staffAdavnce = new StaffAdvanceList_Service.StaffAdvanceRequests_Service();


                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain
                
                staffAdavnce.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                staffAdavnce.PreAuthenticate = true;
                List<StaffAdvanceList_Service.StaffAdvanceRequests_Filter> staffAdvanceFilterArray = new List<StaffAdvanceList_Service.StaffAdvanceRequests_Filter>();

                StaffAdvanceList_Service.StaffAdvanceRequests_Filter staffAdvanceFilter = new StaffAdvanceList_Service.StaffAdvanceRequests_Filter();
                staffAdvanceFilter.Field = StaffAdvanceList_Service.StaffAdvanceRequests_Fields.Cashier;
                staffAdvanceFilter.Criteria = accNo;
                staffAdvanceFilterArray.Add(staffAdvanceFilter);

                // Runs the actual search.
                StaffAdvanceList_Service.StaffAdvanceRequests[] results = staffAdavnce.ReadMultiple(staffAdvanceFilterArray.ToArray(), null, 100);

                //HRCanteenApplicationList_Service.HRCanteenApplicationList_Fields.
                tblStaffAdvance.Columns.Add(new DataColumn("DocumentNo", typeof(string)));
                tblStaffAdvance.Columns.Add(new DataColumn("AccountNo", typeof(string)));
                tblStaffAdvance.Columns.Add(new DataColumn("Payee", typeof(string)));
                tblStaffAdvance.Columns.Add(new DataColumn("Date", typeof(DateTime)));
                tblStaffAdvance.Columns.Add(new DataColumn("TotalAmount", typeof(decimal)));
                tblStaffAdvance.Columns.Add(new DataColumn("Status", typeof(string)));
           
                int i = 0;
                while (i < results.Length)
                {

                    tblStaffAdvance.Rows.Add(results[i].No, results[i].Account_No, results[i].Payee, results[i].Date, results[i].Total_Net_Amount, results[i].Status);
                    i++;

                }



            }
            catch (Exception ex)
            {

                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }
            return tblStaffAdvance;


        }


        public DataTable getWorkRetirementList(string accNo)
        {
            DataTable tblWorkRetirement = new DataTable("WorkRetirement");
            try
            {

                WorkRetirementList_Service.WorkRetirementList_Service workRetirement = new WorkRetirementList_Service.WorkRetirementList_Service();

                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain

                workRetirement.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                workRetirement.PreAuthenticate = true;
                List<WorkRetirementList_Service.WorkRetirementList_Filter> workRetirementFilterArray = new List<WorkRetirementList_Service.WorkRetirementList_Filter>();

                WorkRetirementList_Service.WorkRetirementList_Filter workRetirementFilter = new WorkRetirementList_Service.WorkRetirementList_Filter();
                workRetirementFilter.Field = WorkRetirementList_Service.WorkRetirementList_Fields.Account_No;
                workRetirementFilter.Criteria = "*";
                workRetirementFilterArray.Add(workRetirementFilter);

                // Runs the actual search.
                WorkRetirementList_Service.WorkRetirementList[] results = workRetirement.ReadMultiple(workRetirementFilterArray.ToArray(), null, 100);

                //HRCanteenApplicationList_Service.HRCanteenApplicationList_Fields.
                tblWorkRetirement.Columns.Add(new DataColumn("DocumentNo", typeof(string)));
                tblWorkRetirement.Columns.Add(new DataColumn("AccountNo", typeof(string)));
                tblWorkRetirement.Columns.Add(new DataColumn("Payee", typeof(string)));
                tblWorkRetirement.Columns.Add(new DataColumn("Date", typeof(DateTime)));
                tblWorkRetirement.Columns.Add(new DataColumn("TotalAmount", typeof(decimal)));
                tblWorkRetirement.Columns.Add(new DataColumn("Status", typeof(string)));
                tblWorkRetirement.Columns.Add(new DataColumn("UserID", typeof(string)));

                int i = 0;
                while (i < results.Length)
                {

                    tblWorkRetirement.Rows.Add(results[i].No, results[i].Account_No, results[i].Payee, results[i].Surrender_Date, results[i].Amount, results[i].Status, results[i].User_ID);
                    i++;

                }



            }
            catch (Exception ex)
            {

                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }
            return tblWorkRetirement;


        }


        public WorkRetirement getWorkRetirement(string docNo)
        {
            WorkRetirement __WorkRetirement = new WorkRetirement();

            try
            {

                WorkRetirement_Service.WorkRetirement_Service workRetirement = new WorkRetirement_Service.WorkRetirement_Service();

                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain

                workRetirement.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                workRetirement.PreAuthenticate = true;
                List<WorkRetirement_Service.WorkRetirement_Filter> workRetirementFilterArray = new List<WorkRetirement_Service.WorkRetirement_Filter>();

                WorkRetirement_Service.WorkRetirement_Filter workRetirementFilter = new WorkRetirement_Service.WorkRetirement_Filter();
                workRetirementFilter.Field = WorkRetirement_Service.WorkRetirement_Fields.No;
                workRetirementFilter.Criteria = docNo;
                workRetirementFilterArray.Add(workRetirementFilter);

                // Runs the actual search.
                WorkRetirement_Service.WorkRetirement[] results = workRetirement.ReadMultiple(workRetirementFilterArray.ToArray(), null, 100);

                var _WorkRetirement = new WorkRetirement
                {
                    Bank_Code = results[0].Bank_Code,
                    Cashier = results[0].Cashier,
                    Cheque_No = results[0].Cheque_No,
                    DocumentNo = results[0].No,
                    Imprest_Issue_Doc_No = results[0].Imprest_Issue_Doc_No,
                    ChequeDate = results[0].Cheque_Date,
                    Pay_Mode = results[0].Pay_Mode.ToString(),
                    Imprest_Issue_Date = results[0].Imprest_Issue_Date,
                    Surrender_Date = results[0].Surrender_Date,
                    Status = results[0].Status.ToString(),
                    Responsibility_Center = results[0].Responsibility_Center,
                    Description2 = results[0].Description2,
                    WorkAdvanceLines = results[0].ImprestLines
                    
                };

                __WorkRetirement = _WorkRetirement;

            }
            catch (Exception ex)
            {

                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }

            return __WorkRetirement;

        }


        public CashAdvanceRequest getStaffAdvance(string docNo)
        {
            CashAdvanceRequest  __CashAdvanceRequest    = new CashAdvanceRequest();

            try
            {

                StaffAdvanceRequest_Service.StaffAdvanceRequest_Service staffAdavnce = new StaffAdvanceRequest_Service.StaffAdvanceRequest_Service();


                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain

                staffAdavnce.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                staffAdavnce.PreAuthenticate = true;
                List<StaffAdvanceRequest_Service.StaffAdvanceRequest_Filter> staffAdvanceFilterArray = new List<StaffAdvanceRequest_Service.StaffAdvanceRequest_Filter>();

                StaffAdvanceRequest_Service.StaffAdvanceRequest_Filter staffAdvanceFilter = new StaffAdvanceRequest_Service.StaffAdvanceRequest_Filter();
                staffAdvanceFilter.Field = StaffAdvanceRequest_Service.StaffAdvanceRequest_Fields.No;
                staffAdvanceFilter.Criteria = docNo;
                staffAdvanceFilterArray.Add(staffAdvanceFilter);

                // Runs the actual search.
                StaffAdvanceRequest_Service.StaffAdvanceRequest[] results = staffAdavnce.ReadMultiple(staffAdvanceFilterArray.ToArray(), null, 100);
                
                var _CashAdvanceRequest = new CashAdvanceRequest
                {
                    LocationCode = results[0].Global_Dimension_1_Code,
                    BusinessUnit = results[0].Shortcut_Dimension_2_Code,
                    Payee_Account_Number = results[0].Account_No,
                    Bank_Name = results[0].Bank_Name,
                    Cashier = results[0].Cashier,
                    Budget_Center_Name = results[0].Budget_Center_Name,
                    Cheque_No = results[0].Cheque_No,
                    DocumentNo = results[0].No,
                    Function_Name = results[0].Function_Name,
                    Payee = results[0].Payee,
                    Payment_Narration = results[0].Purpose,
                    Paying_Bank_Account = results[0].Paying_Bank_Account,
                    Payment_Release_Date = results[0].Payment_Release_Date,
                    Pay_Mode = results[0].Pay_Mode.ToString(),
                    RequestDate = results[0].Date,
                    Status = results[0].Status.ToString(),
                    Responsibility_Center = results[0].Responsibility_Center,
                    Total_Payment_Amount = results[0].Total_Net_Amount,
                    Total_Payment_Amount_LCY = results[0].Total_Net_Amount_LCY,
                    CashAdvanceRequestLines = results[0].PVLines
                };

                __CashAdvanceRequest = _CashAdvanceRequest;

            }
            catch (Exception ex)
            {

                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }
            return __CashAdvanceRequest;
            
        }

        public DataTable getPaymentRequestList(string empNo)
        {
            DataTable tblPaymentRequest = new DataTable("PaymentRequest");
            try
            {

                //StaffClaimList_Service.StaffClaimList_Service empClaims

                PaymentRequestList_Service.PaymentRequestList_Service paymentRequest = new PaymentRequestList_Service.PaymentRequestList_Service();
                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain
                //empReleavers.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria" );
                paymentRequest.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                paymentRequest.PreAuthenticate = true;
                List<PaymentRequestList_Service.PaymentRequestList_Filter> paymentRequestFilterArray = new List<PaymentRequestList_Service.PaymentRequestList_Filter>();
                PaymentRequestList_Service.PaymentRequestList_Filter paymentRequestFilter = new PaymentRequestList_Service.PaymentRequestList_Filter();
                paymentRequestFilter.Field = PaymentRequestList_Service.PaymentRequestList_Fields.Cashier;
                paymentRequestFilter.Criteria = "*";
                paymentRequestFilterArray.Add(paymentRequestFilter);

                // Runs the actual search.
                PaymentRequestList_Service.PaymentRequestList[] results = paymentRequest.ReadMultiple(paymentRequestFilterArray.ToArray(), null, 100);

                //HRCanteenApplicationList_Service.HRCanteenApplicationList_Fields.
                tblPaymentRequest.Columns.Add(new DataColumn("DocumentNo", typeof(string)));
                tblPaymentRequest.Columns.Add(new DataColumn("UserID", typeof(string)));
                tblPaymentRequest.Columns.Add(new DataColumn("Payee", typeof(string)));
                tblPaymentRequest.Columns.Add(new DataColumn("Narration", typeof(string)));
                tblPaymentRequest.Columns.Add(new DataColumn("Date", typeof(DateTime)));
                tblPaymentRequest.Columns.Add(new DataColumn("Status", typeof(string)));
                tblPaymentRequest.Columns.Add(new DataColumn("Cheque_No", typeof(string)));
                tblPaymentRequest.Columns.Add(new DataColumn("TotalAmount", typeof(decimal)));
                tblPaymentRequest.Columns.Add(new DataColumn("VatAmount", typeof(decimal)));
                tblPaymentRequest.Columns.Add(new DataColumn("WHTAmount", typeof(decimal)));
                tblPaymentRequest.Columns.Add(new DataColumn("NetAmount", typeof(decimal)));



                int i = 0;
                while (i < results.Length)
                {

                    tblPaymentRequest.Rows.Add(results[i].No,"Test", results[i].Payee , results[i].Payment_Narration, results[i].Date, results[i].Status, results[i].Cheque_No, results[i].Total_Payment_Amount, results[i].Total_VAT_Amount, results[i].Total_Witholding_Tax_Amount, results[i].Total_Net_Amount);
                    i++;

                }



            }
            catch (Exception ex)
            {

                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }
            return tblPaymentRequest;


        }

        public DataTable getStaffClaimList(string empNo)
        {
            DataTable tblStaffClaim = new DataTable("StaffClaim");
            try
            {

                //StaffClaimList_Service.StaffClaimList_Service empClaims
                    
                StaffClaimList_Service.StaffClaimList_Service empClaims = new StaffClaimList_Service.StaffClaimList_Service();
                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain
                //empReleavers.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria" );
                empClaims.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                empClaims.PreAuthenticate = true;
                List<StaffClaimList_Service.StaffClaimList_Filter> empClaimsFilterArray = new List<StaffClaimList_Service.StaffClaimList_Filter>();
                StaffClaimList_Service.StaffClaimList_Filter ClaimFilter = new StaffClaimList_Service.StaffClaimList_Filter();
                ClaimFilter.Field = StaffClaimList_Service.StaffClaimList_Fields.Account_No;
                ClaimFilter.Criteria = empNo;
                empClaimsFilterArray.Add(ClaimFilter);

                // Runs the actual search.
                StaffClaimList_Service.StaffClaimList[] results = empClaims.ReadMultiple(empClaimsFilterArray.ToArray(), null, 100);

                //HRCanteenApplicationList_Service.HRCanteenApplicationList_Fields.
                tblStaffClaim.Columns.Add(new DataColumn("DocumentNo", typeof(string)));
                tblStaffClaim.Columns.Add(new DataColumn("AccountNo", typeof(string)));
                tblStaffClaim.Columns.Add(new DataColumn("Cashier", typeof(string)));
                tblStaffClaim.Columns.Add(new DataColumn("Payee", typeof(string)));
                tblStaffClaim.Columns.Add(new DataColumn("Purpose", typeof(string)));
                tblStaffClaim.Columns.Add(new DataColumn("Status", typeof(string)));
                tblStaffClaim.Columns.Add(new DataColumn("BankName", typeof(string)));
                tblStaffClaim.Columns.Add(new DataColumn("BankAccount", typeof(string)));
                tblStaffClaim.Columns.Add(new DataColumn("RequestDate", typeof(DateTime)));
                tblStaffClaim.Columns.Add(new DataColumn("Amount", typeof(decimal)));

                int i = 0;
                while (i < results.Length)
                {
                     
                    tblStaffClaim.Rows.Add(results[i].No, results[i].Account_No, results[i].Cashier, results[i].Payee, results[i].Purpose, results[i].Status, results[i].Bank_Name, results[i].Paying_Bank_Account, results[i].Date, results[i].Total_Net_Amount);
                    i++;

                }



            }
            catch (Exception ex)
            {

                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }
            return tblStaffClaim;


        }



        public string SendStoreReqApproval(string RequisitionCode)
        {
            
            try
            {

                

                string _status = "";
                General_Service.pfagetbalance _General_Service = new General_Service.pfagetbalance();
                _General_Service.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _status = (_General_Service.OnSendStoreReqApprovalRequest(RequisitionCode) == true) ? "Success" : "Fail";

                

                return _status;

            }
            catch (Exception ex)
            {
                return ex.Message;
                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }
            //  return tblReleavers;


        }


        public string SendCanteenApp(string leaveCode)
        {
            DataTable tblReleavers = new DataTable("Releavers");
            try
            {

                string _status = "";
                General_Service.pfagetbalance _General_Service = new General_Service.pfagetbalance();
                _General_Service.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _status = (_General_Service.SendHRCanteen(leaveCode) == true) ? "Success" : "Fail";

                return _status;


            }
            catch (Exception ex)
            {
                return ex.Message;
                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }
            //  return tblReleavers;


        }


        public string SendCashAdvanceApproval(string advanceCode)
        {
            DataTable tblReleavers = new DataTable("Releavers");
            try
            {

                string _status = "";
                General_Service.pfagetbalance _General_Service = new General_Service.pfagetbalance();
                _General_Service.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                //_status = (_General_Service.SendCashAdvanceRequest(advanceCode) == true) ? "Success" : "Fail";

               

                return _status;


            }
            catch (Exception ex)
            {
                return ex.Message;
                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }
            //  return tblReleavers;


        }

        public string SendCashRetirementApproval(string advanceCode)
        {
            DataTable tblReleavers = new DataTable("Releavers");
            try
            {

                string _status = "";
                General_Service.pfagetbalance _General_Service = new General_Service.pfagetbalance();
                _General_Service.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _status = (_General_Service.SendCashAdvanceRetirementRequest(advanceCode) == true) ? "Success" : "Fail";

                return _status;

            }
            catch (Exception ex)
            {
                return ex.Message;
                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }
            //  return tblReleavers;

        }

        public string SendAppraisalForApproval(string AppraisalNo)
        {

            try
            {

                string _status;
                General_Service.pfagetbalance _General_Service = new General_Service.pfagetbalance();
                _General_Service.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _status = (_General_Service.SendAppraisalGoalSettingSecond(AppraisalNo) == true) ? "Success" : "Fail";

                return _status;

            }
            catch (Exception ex)
            {
                return ex.Message;

            }

        }

        public string SendAppraisalToSupervisor(string AppraisalNo)
        {
            
            try
            {

                string _status;
                General_Service.pfagetbalance _General_Service = new General_Service.pfagetbalance();
                _General_Service.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _status = (_General_Service.SendAppraisalToSupervisor(AppraisalNo) == true) ? "Success" : "Fail";

                return _status;

            }
            catch (Exception ex)
            {
                return ex.Message;

            }

        }

        public string SendLeaveApproval(string leaveCode)
        {
            DataTable tblReleavers = new DataTable("Releavers");
            try
            {
               
                string _status = "";
                General_Service.pfagetbalance _General_Service = new General_Service.pfagetbalance();
                _General_Service.Credentials = new  NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _status = (_General_Service.SendLeaveApprovalRequest(leaveCode) == true) ? "Success"  : "Fail"  ;

                //_status = (_General_Service.SendCashAdvanceRequest(leaveCode) == true) ? "Success" : "Fail";

                return _status;

              
            }
            catch (Exception ex)
            {
                return ex.Message;
                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location; 
                //applog.Logger ( ex.Message );

            }
          //  return tblReleavers;


        }

        public string SendPaymentApproval(string paymentCode)
        {
            
            try
            {

                string _status = "";
                General_Service.pfagetbalance _General_Service = new General_Service.pfagetbalance();
                _General_Service.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _status = (_General_Service.SendPaymentRequest(paymentCode) == true) ? "Success" : "Fail";
                return _status;

            }
            catch (Exception ex)
            {
                return ex.Message;
                
            }
            


        }

        public string CreateCanteenApplication(CanteenApplication _canteenApp)
        {

            //DateTime dat = Convert.ToDateTime ( "1986-03-24T00:00:00" );
            //Label2.Text = dat.ToString ( "yyyy-MM-dd" );  
            
            try
            {

                HRCanteenApplication_Service.HRCanteenApplicationCard CanteenApp = new HRCanteenApplication_Service.HRCanteenApplicationCard();

                if (_canteenApp.RequestType == "Employee") 
                    {
                    CanteenApp.Request_Type = HRCanteenApplication_Service.Request_Type.Employee;
                } else {
                    CanteenApp.Request_Type = HRCanteenApplication_Service.Request_Type.Visitor;
                }

                //CanteenApp.DateSpecified = true;
                //CanteenApp.Date = Convert.ToDateTime(_canteenApp.ApplicationDate);
                CanteenApp.Amount = _canteenApp.Amount;
                CanteenApp.Employee_No = _canteenApp.EmployeeNo;
                CanteenApp.Department_Code = _canteenApp.DepartmentCode;
                CanteenApp.Responsibility_Center = _canteenApp.Responsibility_Center;
                

                HRCanteenApplication_Service.HRCanteenApplicationCard_Service CanteenAppService = new HRCanteenApplication_Service.HRCanteenApplicationCard_Service();
                CanteenAppService.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                CanteenAppService.PreAuthenticate = true;

                CanteenAppService.Create(ref CanteenApp);
              
                return "Success :" + CanteenApp.Ticket_No;
            }
            catch (Exception ex)
            {
                return ex.Message;

            }



        }


        


        public string CreateStoreRequisition(StoreRequisition storeRequisition_)
        {

            try
            {

                StoreRequisition_Service.StoreRequisitionHeder_Service _StoreReq = new StoreRequisition_Service.StoreRequisitionHeder_Service();
                _StoreReq.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _StoreReq.PreAuthenticate = true;

                StoreRequisition_Service.StoreRequisitionHeder _storeRequisition = new StoreRequisition_Service.StoreRequisitionHeder();
                _StoreReq.Create(ref _storeRequisition);
                
                _storeRequisition.Issuing_Store = storeRequisition_.IssueingStore;
                _storeRequisition.User_ID = storeRequisition_.UserID;
                _storeRequisition.Request_date = storeRequisition_.Request_Date;
                _storeRequisition.Required_Date = storeRequisition_.Require_Date;
                _storeRequisition.Responsibility_Center = storeRequisition_.Responsibility_Center;
                _storeRequisition.Store_Requisition_Line = storeRequisition_.StoreRequisitionLines;
                _storeRequisition.User_ID = storeRequisition_.UserID;
                _storeRequisition.Self_Service = true;
                _storeRequisition.SS_User_ID = storeRequisition_.UserID;
                _storeRequisition.Request_Description = storeRequisition_.RequestDescription;
                _storeRequisition.Global_Dimension_1_Code = storeRequisition_.Location;
                _storeRequisition.Shortcut_Dimension_2_Code = storeRequisition_.BusinessUnit;

                string _status = storeRequisition_.Status;

                switch (_status)
                {

                    case "Open":
                        _storeRequisition.Status = StoreRequisition_Service.Status.Open;
                        break;
                    case "Cancelled":
                        _storeRequisition.Status = StoreRequisition_Service.Status.Cancelled;
                        break;
                    case "Pending_Approval":
                        _storeRequisition.Status = StoreRequisition_Service.Status.Pending_Approval;
                        break;
                    case "Pending_Prepayment":
                        _storeRequisition.Status = StoreRequisition_Service.Status.Pending_Prepayment;
                        break;
                    case "Posted":
                        _storeRequisition.Status = StoreRequisition_Service.Status.Posted;
                        break;
                    case "Released":
                        _storeRequisition.Status = StoreRequisition_Service.Status.Released;
                        break;
                    
                    default:
                        _storeRequisition.Status = StoreRequisition_Service.Status.Open;
                        break;
                }

                _StoreReq.Update(ref _storeRequisition);

                General_Service.pfagetbalance _General_Service = new General_Service.pfagetbalance();
                _General_Service.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
               _status = (_General_Service.UpdateUserIDSS(_storeRequisition.No, "STORE") == true) ? "Success" : "Fail";

                return _status;

                //return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }



        }

        public string UpdateStoreRequisition(StoreRequisition storeRequisition_)
        {

            try
            {
                StoreRequisition_Service.StoreRequisitionHeder _storeRequisition = new StoreRequisition_Service.StoreRequisitionHeder();
                // _storeRequisition.Budget_Center_Name = storeRequisition_.BudgetCenterName;
                // _storeRequisition.Function_Name = storeRequisition_.FunctionName;
                
                StoreRequisition_Service.StoreRequisitionHeder_Service _StoreReq = new StoreRequisition_Service.StoreRequisitionHeder_Service();
                _StoreReq.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _StoreReq.PreAuthenticate = true;
                _storeRequisition = _StoreReq.Read(storeRequisition_.DocumentNo);

               // _storeRequisition.No = storeRequisition_.DocumentNo;
                _storeRequisition.Issuing_Store = storeRequisition_.IssueingStore;
                _storeRequisition.No = storeRequisition_.DocumentNo;
                _storeRequisition.Request_date = storeRequisition_.Request_Date;
                _storeRequisition.Required_Date = storeRequisition_.Require_Date;
                _storeRequisition.Responsibility_Center = storeRequisition_.Responsibility_Center;
                _storeRequisition.Store_Requisition_Line = storeRequisition_.StoreRequisitionLines;
                _storeRequisition.Request_Description = storeRequisition_.RequestDescription;

                string _status = storeRequisition_.Status;
                switch (_status)
                {
                    case "Open":
                        _storeRequisition.Status = StoreRequisition_Service.Status.Open;
                        break;
                    case "Cancelled":
                        _storeRequisition.Status = StoreRequisition_Service.Status.Cancelled;
                        break;
                    case "Pending_Approval":
                        _storeRequisition.Status = StoreRequisition_Service.Status.Pending_Approval;
                        break;
                    case "Pending_Prepayment":
                        _storeRequisition.Status = StoreRequisition_Service.Status.Pending_Prepayment;
                        break;
                    case "Posted":
                        _storeRequisition.Status = StoreRequisition_Service.Status.Posted;
                        break;
                    case "Released":
                        _storeRequisition.Status = StoreRequisition_Service.Status.Released;
                        break;

                    default:
                        _storeRequisition.Status = StoreRequisition_Service.Status.Open;
                        break;
                }

                _StoreReq.Update(ref _storeRequisition);
                return "Success";

            }
            catch (Exception ex)
            {
                return "" + ex.Message;

            }

            

        }

        public String CreateStaffClaim(StaffClaim staffClaim_)
        {

            //DateTime dat = Convert.ToDateTime ( "1986-03-24T00:00:00" );
            //Label2.Text = dat.ToString ( "yyyy-MM-dd" );  

            try
            {
                StaffClaim_Service.StaffClaim_Service StaffClaimService = new StaffClaim_Service.StaffClaim_Service();
                StaffClaimService.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                StaffClaimService.PreAuthenticate = true;

                StaffClaim_Service.StaffClaim _staffClaim = new StaffClaim_Service.StaffClaim();
                StaffClaimService.Create(ref _staffClaim);

                _staffClaim.Account_No = staffClaim_.AccountNo;
                //_staffClaim.Budget_Center_Name = staffClaim_.BudgetCenterName;
                _staffClaim.Cashier = staffClaim_.Cashier;
                _staffClaim.Date = staffClaim_.ClaimDate;
               // _staffClaim.No = staffClaim_.DocumentNo;
               // _staffClaim.Payee = staffClaim_.Paye;
               // _staffClaim.Function_Name = staffClaim_.FunctionName;
                _staffClaim.Purpose = staffClaim_.Purpose;
                _staffClaim.Responsibility_Center = staffClaim_.Responsibility_Center;
                _staffClaim.Total_Net_Amount = staffClaim_.TotalNetAmount;

                string _status = staffClaim_.Status;
                switch (_status)
                {

                    case "Approved":
                        _staffClaim.Status = StaffClaim_Service.Status.Approved;
                        break;
                    case "Cancelled":
                        _staffClaim.Status = StaffClaim_Service.Status.Cancelled;
                        break;
                    case "Checking":
                        _staffClaim.Status = StaffClaim_Service.Status.Checking;
                        break;
                    case "Cheque_Printing":
                        _staffClaim.Status = StaffClaim_Service.Status.Cheque_Printing;
                        break;
                    case "Pending":
                        _staffClaim.Status = StaffClaim_Service.Status.Pending;
                        break;
                    case "Pending_Approval":
                        _staffClaim.Status = StaffClaim_Service.Status.Pending_Approval;
                        break;
                    case "Posted":
                        _staffClaim.Status = StaffClaim_Service.Status.Posted;
                        break;
                    default:
                        _staffClaim.Status = StaffClaim_Service.Status.Pending;
                        break;
                }

                _staffClaim.PVLines = staffClaim_.PVLines;

                
                StaffClaimService.Update(ref _staffClaim);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }

        }

        public DataTable getRecieptPaymentTypeList(string _type)
        {
            DataTable tblrpType = new DataTable("EmployeeDetails");
            try
            {

                RecieptPaymentTypesList_Service.ReceiptAndPaymentTypesList_Service rptype = new RecieptPaymentTypesList_Service.ReceiptAndPaymentTypesList_Service();
                
                //EmployeeList.EmployeeList_Service empList = new EmployeeList.EmployeeList_Service();
                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain
                //empList.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria.com" );

                rptype.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                rptype.PreAuthenticate = true;
                List<RecieptPaymentTypesList_Service.ReceiptAndPaymentTypesList_Filter> rptypeListFilterArray = new List<RecieptPaymentTypesList_Service.ReceiptAndPaymentTypesList_Filter>();

                RecieptPaymentTypesList_Service.ReceiptAndPaymentTypesList_Filter empListFilter = new RecieptPaymentTypesList_Service.ReceiptAndPaymentTypesList_Filter();
                empListFilter.Field = RecieptPaymentTypesList_Service.ReceiptAndPaymentTypesList_Fields.Type;
                empListFilter.Criteria = _type;
                rptypeListFilterArray.Add(empListFilter);

                // Runs the actual search.

                RecieptPaymentTypesList_Service.ReceiptAndPaymentTypesList[] results = rptype.ReadMultiple(rptypeListFilterArray.ToArray(), null, 1000);

                tblrpType.Columns.Add(new DataColumn("AdvanceType", typeof(string)));
                tblrpType.Columns.Add(new DataColumn("AccountType", typeof(string)));
                tblrpType.Columns.Add(new DataColumn("AccountNo", typeof(string)));
                tblrpType.Columns.Add(new DataColumn("AccountName", typeof(string)));

                int i = 0;
                while (i < results.Length)

                {
                    
                    tblrpType.Rows.Add(results[i].Code, results[i].Account_Type, results[i].G_L_Account, results[i].Description);
                    i++;

                }

            }
            catch (Exception ex)
            {

                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
                //applog.Logger ( ex.Message );

            }

            return tblrpType;
        }

        public DataTable getItemList(string _type)
        {
            DataTable tblStoreItems = new DataTable("ItemList");
            try
            {

                ItemList_Service.ItemList_Service _itemlist = new ItemList_Service.ItemList_Service();
                
                //EmployeeList.EmployeeList_Service empList = new EmployeeList.EmployeeList_Service();
                //passing the credential to access the webservice. The user must have access on Navision and also active on the domain
                //empList.Credentials = new NetworkCredential ( "coretec", "Ibukun@lag", "pensure-nigeria.com" );

                _itemlist.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _itemlist.PreAuthenticate = true;
                List<ItemList_Service.ItemList_Filter> rptypeListFilterArray = new List<ItemList_Service.ItemList_Filter>();
                ItemList_Service.ItemList_Filter itemListFilter = new ItemList_Service.ItemList_Filter();
                itemListFilter.Field = ItemList_Service.ItemList_Fields.Type;
                itemListFilter.Criteria = _type;
                rptypeListFilterArray.Add(itemListFilter);

                // Runs the actual search.
                //ItemList_Service.Type.Non_Inventory
                //ItemList_Service.Type.Inventory
                //ItemList_Service.Type.Service

                ItemList_Service.ItemList[] results = _itemlist.ReadMultiple(rptypeListFilterArray.ToArray(), null, 1000);

                tblStoreItems.Columns.Add(new DataColumn("No", typeof(string)));
                tblStoreItems.Columns.Add(new DataColumn("Description", typeof(string)));
                tblStoreItems.Columns.Add(new DataColumn("Unit_Cost", typeof(decimal)));
                tblStoreItems.Columns.Add(new DataColumn("Unit_Price", typeof(decimal)));
                tblStoreItems.Columns.Add(new DataColumn("Inventory", typeof(decimal)));
                tblStoreItems.Columns.Add(new DataColumn("UnitOfMeasure", typeof(string)));
                tblStoreItems.Columns.Add(new DataColumn("Location", typeof(string)));



                //results[i].No
                //results[i].Description
                //results[i].Unit_Cost
                //results[i].Unit_Price
                //results[i].Inventory
                //results[i].Base_Unit_of_Measure

                int i = 0;

                while (i < results.Length)

                {

                    tblStoreItems.Rows.Add(results[i].No , results[i].Description, results[i].Last_Direct_Cost, results[i].Unit_Price, results[i].Inventory, results[i].Base_Unit_of_Measure, results[i].Location_Filter);
                    i++;
                    

                }

            }
            catch (Exception ex)
            {

                //Logger.Logger applog = new Logger.Logger ( );
                //applog.FileSource = "NAV - Interface";
                //applog.FilePath = System.Reflection.Assembly.GetExecutingAssembly ( ).Location;
                //applog.Logger ( ex.Message );

            }

            return tblStoreItems;
        }


        public string CreateProbationConfirmation(ConfirmationProbation ConfirmationProbation_)
        {

            ProbationConfirmationCard_Service.ConfirmationCard_Service ConfirmationProbationReq = new ProbationConfirmationCard_Service.ConfirmationCard_Service();
            ConfirmationProbationReq.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
            ConfirmationProbationReq.PreAuthenticate = true;

            ProbationConfirmationCard_Service.ConfirmationCard _ConfirmationProbation = new ProbationConfirmationCard_Service.ConfirmationCard();
            ConfirmationProbationReq.Create(ref _ConfirmationProbation);

            try
            {
               
                _ConfirmationProbation.Comment = ConfirmationProbation_.Comment;
                _ConfirmationProbation.Employee_Comment = ConfirmationProbation_.EmployeeComment;
                _ConfirmationProbation.Responsibility_Center = ConfirmationProbation_.Responsibility_Center;
                _ConfirmationProbation.KPI_Score = ConfirmationProbation_.KPI_Score;
                _ConfirmationProbation.Score = ConfirmationProbation_.Score;
                _ConfirmationProbation.Start_Date = ConfirmationProbation_.StartDate;
                _ConfirmationProbation.End_Date = ConfirmationProbation_.EndDate;
                _ConfirmationProbation.Employee_Name = ConfirmationProbation_.EmployeeName;
                _ConfirmationProbation.Employee_No = ConfirmationProbation_.EmployeeNo;
                _ConfirmationProbation.Date_of_Employment = ConfirmationProbation_.EmploymentDate;
                _ConfirmationProbation.Date_of_Review = ConfirmationProbation_.ReviewDate;
                _ConfirmationProbation.Department = ConfirmationProbation_.Department;
                _ConfirmationProbation.Development_Areas = ConfirmationProbation_.DevelopmentAreas;
                _ConfirmationProbation.Training_Ideas = ConfirmationProbation_.Training_Ideas;
                _ConfirmationProbation.Supervisor = ConfirmationProbation_.Supervisor;
                _ConfirmationProbation.Second_Line_Supervisor = ConfirmationProbation_.Second_Line_Supervisor;
                _ConfirmationProbation.Second_Line_Supervisor_Comment = ConfirmationProbation_.Second_Line_Supervisor_Comment;

                string _AppraisalType = ConfirmationProbation_.AppraisalType.ToString();
                switch (_AppraisalType) 
                {
                    case "Probation":
                        _ConfirmationProbation.Appraisal_Type = ProbationConfirmationCard_Service.Appraisal_Type.Probation;
                        break;
                    case "_Confirmation":
                        _ConfirmationProbation.Appraisal_Type = ProbationConfirmationCard_Service.Appraisal_Type._Confirmation;
                        break;
                    default:
                        _ConfirmationProbation.Appraisal_Type = ProbationConfirmationCard_Service.Appraisal_Type.Probation;
                        break;
                }



                string _status = ConfirmationProbation_.Status.ToString();

                switch (_status)
                {
                    case "New":
                        _ConfirmationProbation.Status = ProbationConfirmationCard_Service.Status.New;
                        break;
                    case "Pending_Approval":
                        _ConfirmationProbation.Status = ProbationConfirmationCard_Service.Status.Pending_Approval;
                        break;
                    case "Approved":
                        _ConfirmationProbation.Status = ProbationConfirmationCard_Service.Status.Approved;
                        break;
                    case "HR":
                        _ConfirmationProbation.Status = ProbationConfirmationCard_Service.Status.HR;
                        break;
                    
                    default:
                        _ConfirmationProbation.Status = ProbationConfirmationCard_Service.Status.New;
                        break;
                }

                _ConfirmationProbation.HR_Confirmation_Lines = ConfirmationProbation_.HR_Confirmation_Lines;


                ConfirmationProbationReq.Update(ref _ConfirmationProbation);
                
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }


        }


        public string UpdateProbationConfirmation(ConfirmationProbation ConfirmationProbation_)
        {

            ProbationConfirmationCard_Service.ConfirmationCard_Service ConfirmationProbationReq = new ProbationConfirmationCard_Service.ConfirmationCard_Service();
            ConfirmationProbationReq.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
            ConfirmationProbationReq.PreAuthenticate = true;

            try
            {

                ProbationConfirmationCard_Service.ConfirmationCard _ConfirmationProbation = new ProbationConfirmationCard_Service.ConfirmationCard();
                _ConfirmationProbation = ConfirmationProbationReq.Read(ConfirmationProbation_.ApplicationNo);


                _ConfirmationProbation.Comment = ConfirmationProbation_.Comment;
                _ConfirmationProbation.Employee_Comment = ConfirmationProbation_.EmployeeComment;
                _ConfirmationProbation.Responsibility_Center = ConfirmationProbation_.Responsibility_Center;
                _ConfirmationProbation.KPI_Score = ConfirmationProbation_.KPI_Score;
                _ConfirmationProbation.Score = ConfirmationProbation_.Score;
                _ConfirmationProbation.Start_Date = ConfirmationProbation_.StartDate;
                _ConfirmationProbation.End_Date = ConfirmationProbation_.EndDate;
                _ConfirmationProbation.Employee_Name = ConfirmationProbation_.EmployeeName;
                _ConfirmationProbation.Employee_No = ConfirmationProbation_.EmployeeNo;
                _ConfirmationProbation.Date_of_Employment = ConfirmationProbation_.EmploymentDate;
                _ConfirmationProbation.Date_of_Review = ConfirmationProbation_.ReviewDate;
                _ConfirmationProbation.Department = ConfirmationProbation_.Department;
                _ConfirmationProbation.Development_Areas = ConfirmationProbation_.DevelopmentAreas;
                _ConfirmationProbation.Training_Ideas = ConfirmationProbation_.Training_Ideas;
                _ConfirmationProbation.Supervisor = ConfirmationProbation_.Supervisor;
                _ConfirmationProbation.Second_Line_Supervisor = ConfirmationProbation_.Second_Line_Supervisor;
                _ConfirmationProbation.Second_Line_Supervisor_Comment = ConfirmationProbation_.Second_Line_Supervisor_Comment;

                string _AppraisalType = ConfirmationProbation_.AppraisalType.ToString();
                switch (_AppraisalType)
                {
                    case "Probation":
                        _ConfirmationProbation.Appraisal_Type = ProbationConfirmationCard_Service.Appraisal_Type.Probation;
                        break;
                    case "_Confirmation":
                        _ConfirmationProbation.Appraisal_Type = ProbationConfirmationCard_Service.Appraisal_Type._Confirmation;
                        break;
                    default:
                        _ConfirmationProbation.Appraisal_Type = ProbationConfirmationCard_Service.Appraisal_Type.Probation;
                        break;
                }



                string _status = ConfirmationProbation_.Status.ToString();

                switch (_status)
                {
                    case "New":
                        _ConfirmationProbation.Status = ProbationConfirmationCard_Service.Status.New;
                        break;
                    case "Pending_Approval":
                        _ConfirmationProbation.Status = ProbationConfirmationCard_Service.Status.Pending_Approval;
                        break;
                    case "Approved":
                        _ConfirmationProbation.Status = ProbationConfirmationCard_Service.Status.Approved;
                        break;
                    case "HR":
                        _ConfirmationProbation.Status = ProbationConfirmationCard_Service.Status.HR;
                        break;

                    default:
                        _ConfirmationProbation.Status = ProbationConfirmationCard_Service.Status.New;
                        break;
                }

                _ConfirmationProbation.HR_Confirmation_Lines = ConfirmationProbation_.HR_Confirmation_Lines;


                ConfirmationProbationReq.Update(ref _ConfirmationProbation);

                return "Success";




            }
            catch (Exception ex)
            {
                return ex.Message;

            }



        }


        public string CreatePaymentRequest(PaymentRequest PaymentRequest_)
        {

            PaymentRequest_Service.PaymentRequest_Service pmtRequest = new PaymentRequest_Service.PaymentRequest_Service();
            pmtRequest.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
            pmtRequest.PreAuthenticate = true;
            PaymentRequest_Service.PaymentRequest _PaymentRequest = new PaymentRequest_Service.PaymentRequest();
            pmtRequest.Create(ref _PaymentRequest);

            try
            {
 
                _PaymentRequest.Payee_Account_Number = PaymentRequest_.Payee_Account_Number;
                _PaymentRequest.Payment_Release_Date = PaymentRequest_.Payment_Release_Date;             
                _PaymentRequest.Global_Dimension_1_Code = PaymentRequest_.Location;
                _PaymentRequest.Shortcut_Dimension_2_Code = PaymentRequest_.Bussiness_Unit;

                _PaymentRequest.Date = PaymentRequest_.RequestDate;
                _PaymentRequest.Responsibility_Center = PaymentRequest_.Responsibility_Center;
                _PaymentRequest.Self_Service = true;
                _PaymentRequest.Self_ServiceSpecified = true;
                _PaymentRequest.SS_User_ID = PaymentRequest_.SS_UserID;

                //string _status = PaymentRequest_.Status;
                //switch (_status)
                //{

                //    case "Approved":
                //        _PaymentRequest.Status = PaymentRequest_Service.Status.Approved;
                //        break;
                //    case "Cancelled":
                //        _PaymentRequest.Status = PaymentRequest_Service.Status.Cancelled;
                //        break;
                //    case "Checking":
                //        _PaymentRequest.Status = PaymentRequest_Service.Status.Checking;
                //        break;
                //    case "Cheque_Printing":
                //        _PaymentRequest.Status = PaymentRequest_Service.Status.Cheque_Printing;
                //        break;
                //    case "Pending":
                //        _PaymentRequest.Status = PaymentRequest_Service.Status.Pending;
                //        break;
                //    case "Pending_Approval":
                //        _PaymentRequest.Status = PaymentRequest_Service.Status.Pending_Approval;
                //        break;
                //    case "Posted":
                //        _PaymentRequest.Status = PaymentRequest_Service.Status.Posted;
                //        break;
                //    default:
                //        _PaymentRequest.Status = PaymentRequest_Service.Status.Rejected;
                //        break;
                //}

                _PaymentRequest.PVLines = PaymentRequest_.PaymentRequisitionLines;
                pmtRequest.Update(ref _PaymentRequest);

                string _status = "";
             
                General_Service.pfagetbalance _General_Service = new General_Service.pfagetbalance();
                _General_Service.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _status = (_General_Service.UpdatePaymentReqCashier(_PaymentRequest.No) == true) ? "Success" : "Fail";

                //_General_Service.GetItemInStore()

                return _status;

            }
            catch (Exception ex)
            {
                return ex.Message;

            }


        }


        public string UpdatePaymentRequest(PaymentRequest PaymentRequest_)
        {

            PaymentRequest_Service.PaymentRequest_Service pmtRequest= new PaymentRequest_Service.PaymentRequest_Service();
            pmtRequest.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
            pmtRequest.PreAuthenticate = true;
                       
            try
            {

                PaymentRequest_Service.PaymentRequest _PaymentRequest = new PaymentRequest_Service.PaymentRequest();
                _PaymentRequest = pmtRequest.Read(PaymentRequest_.DocumentNo);

                _PaymentRequest.Bank_Name = PaymentRequest_.Bank_Name;
               // _PaymentRequest.Budget_Center_Name = PaymentRequest_.Budget_Center_Name;
                _PaymentRequest.Cashier = PaymentRequest_.Cashier;
                _PaymentRequest.Cheque_No = PaymentRequest_.Cheque_No;

                if (PaymentRequest_.Cheque_Type == "Computer_Check")
                {
                    _PaymentRequest.Cheque_Type = PaymentRequest_Service.Cheque_Type.Computer_Check;
                }
                else if(PaymentRequest_.Cheque_Type == "Manual_Check")
                {
                    _PaymentRequest.Cheque_Type = PaymentRequest_Service.Cheque_Type.Manual_Check;
                }
                else
                {
                    _PaymentRequest.Cheque_Type = PaymentRequest_Service.Cheque_Type._blank_;
                }

               // _PaymentRequest.No = PaymentRequest_.DocumentNo;
               // _PaymentRequest.Function_Name = PaymentRequest_.Function_Name;
                _PaymentRequest.On_Behalf_Of = PaymentRequest_.On_Behalf_Of;
                _PaymentRequest.Payee = PaymentRequest_.Payee;
                _PaymentRequest.Payee_Account_Number = PaymentRequest_.Payee_Account_Number;
                _PaymentRequest.Paying_Bank_Account = PaymentRequest_.Paying_Bank_Account;
                _PaymentRequest.Payment_Narration = PaymentRequest_.Payment_Narration;
                _PaymentRequest.Payment_Release_Date = PaymentRequest_.Payment_Release_Date;

               // _PaymentRequest.Pay_Mode = PaymentRequest_.Pay_Mode;

                if (PaymentRequest_.Pay_Mode == "Cash")
                {
                    _PaymentRequest.Pay_Mode = PaymentRequest_Service.Pay_Mode.Cash;
                }
                else if (PaymentRequest_.Cheque_Type == "Cheque")
                {
                    _PaymentRequest.Pay_Mode = PaymentRequest_Service.Pay_Mode.Cheque;
                }
                else
                {
                    _PaymentRequest.Pay_Mode = PaymentRequest_Service.Pay_Mode._blank_;
                }



                _PaymentRequest.Date = PaymentRequest_.RequestDate;
                _PaymentRequest.Responsibility_Center = PaymentRequest_.Responsibility_Center;
               _PaymentRequest.Total_Payment_Amount = PaymentRequest_.Total_Payment_Amount;
                _PaymentRequest.Total_Payment_Amount_LCY = PaymentRequest_.Total_Payment_Amount_LCY;
                _PaymentRequest.Total_Retention_Amount = PaymentRequest_.Total_Retention_Amount;
                _PaymentRequest.Total_VAT_Amount = PaymentRequest_.Total_VAT_Amount;
                _PaymentRequest.Total_Witholding_Tax_Amount = PaymentRequest_.Total_Witholding_Tax_Amount;
                _PaymentRequest._Total_Payment_Amount_Total_Witholding_Tax_Amount__Total_VAT_Amount__Total_Retention_Amount = PaymentRequest_.Total_Payment_Amount_Total_Witholding_Tax_Amount__Total_VAT_Amount__Total_Retention_Amount;
                

                string _status = PaymentRequest_.Status;
                switch (_status)
                {

                    case "Approved":
                        _PaymentRequest.Status = PaymentRequest_Service.Status.Approved;
                        break;
                    case "Cancelled":
                        _PaymentRequest.Status = PaymentRequest_Service.Status.Cancelled;
                        break;
                    case "Checking":
                        _PaymentRequest.Status = PaymentRequest_Service.Status.Checking;
                        break;
                    case "Cheque_Printing":
                        _PaymentRequest.Status = PaymentRequest_Service.Status.Cheque_Printing;
                        break;
                    case "Pending":
                        _PaymentRequest.Status = PaymentRequest_Service.Status.Pending;
                        break;
                    case "Pending_Approval":
                        _PaymentRequest.Status = PaymentRequest_Service.Status.Pending_Approval;
                        break;
                    case "Posted":
                        _PaymentRequest.Status = PaymentRequest_Service.Status.Posted;
                        break;
                    default:
                        _PaymentRequest.Status = PaymentRequest_Service.Status.Rejected;
                        break;
                }
                
                _PaymentRequest.PVLines = PaymentRequest_.PaymentRequisitionLines;


                pmtRequest.Update(ref _PaymentRequest);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }



        }


        public string CreateAdvanceRequest(CashAdvanceRequest CashAdvanceRequest_)
        {

            StaffAdvanceRequest_Service.StaffAdvanceRequest_Service staffAdvRequest = new StaffAdvanceRequest_Service.StaffAdvanceRequest_Service();
            staffAdvRequest.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
            staffAdvRequest.PreAuthenticate = true;

            try
            {

                StaffAdvanceRequest_Service.StaffAdvanceRequest _StaffAdvanceRequest = new StaffAdvanceRequest_Service.StaffAdvanceRequest();
                staffAdvRequest.Create(ref _StaffAdvanceRequest);

                //_StaffAdvanceRequest.Cashier = CashAdvanceRequest_.Cashier;

                _StaffAdvanceRequest.Shortcut_Dimension_2_Code = CashAdvanceRequest_.BusinessUnit;
                _StaffAdvanceRequest.Bank_Name = CashAdvanceRequest_.Bank_Name;
                _StaffAdvanceRequest.Self_ServiceSpecified = true;
                _StaffAdvanceRequest.Self_Service = true;
                _StaffAdvanceRequest.SS_User_ID = CashAdvanceRequest_.UserID;
                _StaffAdvanceRequest.Cheque_No = CashAdvanceRequest_.Cheque_No;
                _StaffAdvanceRequest.Global_Dimension_1_Code = CashAdvanceRequest_.LocationCode;
                
                _StaffAdvanceRequest.Paying_Bank_Account = CashAdvanceRequest_.Paying_Bank_Account;
                _StaffAdvanceRequest.Purpose = CashAdvanceRequest_.Payment_Narration;
                _StaffAdvanceRequest.Payment_Release_Date = CashAdvanceRequest_.Payment_Release_Date;
                _StaffAdvanceRequest.Date = CashAdvanceRequest_.RequestDate;
                
                if (CashAdvanceRequest_.Pay_Mode == "Cash")
                {
                    _StaffAdvanceRequest.Pay_Mode = StaffAdvanceRequest_Service.Pay_Mode.Cash;
                }
                else if (CashAdvanceRequest_.Cheque_Type == "Cheque")
                {
                    _StaffAdvanceRequest.Pay_Mode = StaffAdvanceRequest_Service.Pay_Mode.Cheque;
                }
                else
                {
                    _StaffAdvanceRequest.Pay_Mode = StaffAdvanceRequest_Service.Pay_Mode._blank_;
                }



                _StaffAdvanceRequest.Date = CashAdvanceRequest_.RequestDate;
                _StaffAdvanceRequest.Responsibility_Center = CashAdvanceRequest_.Responsibility_Center;
                _StaffAdvanceRequest.Total_Net_Amount = CashAdvanceRequest_.Total_Payment_Amount;
                _StaffAdvanceRequest.Total_Net_AmountSpecified = true;
                _StaffAdvanceRequest.Total_Net_Amount_LCY = CashAdvanceRequest_.Total_Payment_Amount_LCY;



                string _status = CashAdvanceRequest_.Status;
                switch (_status)
                {

                    case "Approved":
                        _StaffAdvanceRequest.Status = StaffAdvanceRequest_Service.Status.Approved;
                        break;
                    case "Cancelled":
                        _StaffAdvanceRequest.Status = StaffAdvanceRequest_Service.Status.Cancelled;
                        break;
                    case "Checking":
                        _StaffAdvanceRequest.Status = StaffAdvanceRequest_Service.Status.Checking;
                        break;
                    case "Cheque_Printing":
                        _StaffAdvanceRequest.Status = StaffAdvanceRequest_Service.Status.Cheque_Printing;
                        break;
                    case "Pending":
                        _StaffAdvanceRequest.Status = StaffAdvanceRequest_Service.Status.Pending;
                        break;
                    case "Pending_Approval":
                        _StaffAdvanceRequest.Status = StaffAdvanceRequest_Service.Status.Pending_Approval;
                        break;
                    case "Posted":
                        _StaffAdvanceRequest.Status = StaffAdvanceRequest_Service.Status.Posted;
                        break;
                    default:
                        _StaffAdvanceRequest.Status = StaffAdvanceRequest_Service.Status.Pending;
                        break;
                }

                _StaffAdvanceRequest.PVLines = CashAdvanceRequest_.CashAdvanceRequestLines;

                staffAdvRequest.Update(ref _StaffAdvanceRequest);


                General_Service.pfagetbalance _General_Service = new General_Service.pfagetbalance();
                _General_Service.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _status = (_General_Service.UpdateUserIDSS(_StaffAdvanceRequest.No, "CA") == true) ? "Success" : "Fail";
                return _status;

            }
            catch (Exception ex)
            {
                return ex.Message;

            }



        }


        public string CreateRetirementRequest(WorkRetirement WorkRetirement_)
        {

            WorkRetirement_Service.WorkRetirement_Service workRetireRequest = new WorkRetirement_Service.WorkRetirement_Service();
            workRetireRequest.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
            workRetireRequest.PreAuthenticate = true;

            try
            {

                WorkRetirement_Service.WorkRetirement _StaffRetirementRequest = new WorkRetirement_Service.WorkRetirement();
                workRetireRequest.Create(ref _StaffRetirementRequest);

                //_StaffRetirementRequest.Bank_Code = WorkRetirement_.Bank_Code;
               
                //_StaffRetirementRequest.Cheque_No = WorkRetirement_.Cheque_No;

                //_StaffRetirementRequest.Cheque_Date = WorkRetirement_.ChequeDate;
                _StaffRetirementRequest.Responsibility_Center = WorkRetirement_.Responsibility_Center;
                _StaffRetirementRequest.Imprest_Issue_Doc_No = WorkRetirement_.Imprest_Issue_Doc_No;
                _StaffRetirementRequest.Cheque_Date = WorkRetirement_.ChequeDate;
                _StaffRetirementRequest.Allow_Overexpenditure = true;
                _StaffRetirementRequest.Self_ServiceSpecified = true;
                _StaffRetirementRequest.SS_User_ID = WorkRetirement_.UserID;
                _StaffRetirementRequest.Self_Service = true;    
                workRetireRequest.Update(ref _StaffRetirementRequest);

                string _status;
                General_Service.pfagetbalance _General_Service = new General_Service.pfagetbalance();
                _General_Service.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _status = (_General_Service.UpdateUserIDSS(_StaffRetirementRequest.No, "CADRET") == true) ? "Success" : "Fail";
                //return _status;


                return "Success | " + _StaffRetirementRequest.No;

            }

            catch (Exception ex)
            {
                return ex.Message;

            }

        }


        public string UpdateRetirementRequest(WorkRetirement WorkRetirement_)
        {

            WorkRetirement_Service.WorkRetirement_Service workRetireRequest = new WorkRetirement_Service.WorkRetirement_Service();
            workRetireRequest.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
            workRetireRequest.PreAuthenticate = true;

            //StaffAdvanceRequest_Service.Account_Type.

            try
            {

                WorkRetirement_Service.WorkRetirement _StaffRetirementRequest = new WorkRetirement_Service.WorkRetirement();
                _StaffRetirementRequest = workRetireRequest.Read(WorkRetirement_.DocumentNo);

                //_StaffRetirementRequest.Bank_Code = WorkRetirement_.Bank_Code;
                //_StaffRetirementRequest.Cashier = WorkRetirement_.Cashier;
                //_StaffRetirementRequest.Cheque_No = WorkRetirement_.Cheque_No;
                
                _StaffRetirementRequest.Cheque_Date = WorkRetirement_.ChequeDate;
               // _StaffRetirementRequest.Description2 = WorkRetirement_.Description2;
                _StaffRetirementRequest.Imprest_Issue_Doc_No = WorkRetirement_.Imprest_Issue_Doc_No;
                _StaffRetirementRequest.Responsibility_Center = WorkRetirement_.Responsibility_Center;

                // _StaffRetirementRequest.Pay_Mode = WorkRetirement_.Pay_Mode;


                //if (WorkRetirement_.Pay_Mode == "Cash")
                //{
                //    _StaffRetirementRequest.Pay_Mode = WorkRetirement_Service.Pay_Mode.Cash;
                //}
                //else if (WorkRetirement_.Pay_Mode == "Cheque")
                //{
                //    _StaffRetirementRequest.Pay_Mode = WorkRetirement_Service.Pay_Mode.Cheque;
                //}
                //else
                //{
                //    _StaffRetirementRequest.Pay_Mode = WorkRetirement_Service.Pay_Mode._blank_;
                //}



                //_StaffRetirementRequest.da = CashAdvanceRequest_.RequestDate;
                //_StaffRetirementRequest.Responsibility_Center = CashAdvanceRequest_.Responsibility_Center;
                //_StaffRetirementRequest.Total_Net_Amount = CashAdvanceRequest_.Total_Payment_Amount;
                //_StaffRetirementRequest.Total_Net_AmountSpecified = true;
                //_StaffRetirementRequest.Total_Net_Amount_LCY = CashAdvanceRequest_.Total_Payment_Amount_LCY;



                //string _status = WorkRetirement_.Status;
                //switch (_status)
                //{

                //    case "Approved":
                //        _StaffRetirementRequest.Status = WorkRetirement_Service.Status.Approved;
                //        break;
                //    case "Cancelled":
                //        _StaffRetirementRequest.Status = WorkRetirement_Service.Status.Cancelled;
                //        break;
                //    case "Checking":
                //        _StaffRetirementRequest.Status = WorkRetirement_Service.Status.Checking;
                //        break;
                //    case "Cheque_Printing":
                //        _StaffRetirementRequest.Status = WorkRetirement_Service.Status.Cheque_Printing;
                //        break;
                //    case "Pending":
                //        _StaffRetirementRequest.Status = WorkRetirement_Service.Status.Pending;
                //        break;
                //    case "Pending_Approval":
                //        _StaffRetirementRequest.Status = WorkRetirement_Service.Status.Pending_Approval;
                //        break;
                //    case "Posted":
                //        _StaffRetirementRequest.Status = WorkRetirement_Service.Status.Posted;
                //        break;
                //    default:
                //        _StaffRetirementRequest.Status = WorkRetirement_Service.Status.Pending;
                //        break;
                //}

                //_StaffRetirementRequest.ImprestLines = WorkRetirement_.WorkAdvanceLines;

                workRetireRequest.Update(ref _StaffRetirementRequest);

                return "Success";

            }
            catch (Exception ex)
            {
                return ex.Message;

            }



        }




        public string UpdateAdvanceRequest(CashAdvanceRequest CashAdvanceRequest_)
        {

            StaffAdvanceRequest_Service.StaffAdvanceRequest_Service staffAdvRequest = new StaffAdvanceRequest_Service.StaffAdvanceRequest_Service();
            staffAdvRequest.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
            staffAdvRequest.PreAuthenticate = true;

            //StaffAdvanceRequest_Service.Account_Type.

            try
            {

                StaffAdvanceRequest_Service.StaffAdvanceRequest _StaffAdvanceRequest = new StaffAdvanceRequest_Service.StaffAdvanceRequest();
                _StaffAdvanceRequest = staffAdvRequest.Read(CashAdvanceRequest_.DocumentNo);

                _StaffAdvanceRequest.Bank_Name = CashAdvanceRequest_.Bank_Name;
                // _PaymentRequest.Budget_Center_Name = PaymentRequest_.Budget_Center_Name;
                _StaffAdvanceRequest.Cashier = CashAdvanceRequest_.Cashier;
                _StaffAdvanceRequest.Cheque_No = CashAdvanceRequest_.Cheque_No;

                //if (CashAdvanceRequest_.Cheque_Type == "Computer_Check")
                //{
                //    _StaffAdvanceRequest.c = PaymentRequest_Service.Cheque_Type.Computer_Check;
                //}
                //else if (CashAdvanceRequest_.Cheque_Type == "Manual_Check")
                //{
                //    _StaffAdvanceRequest.Cheque_Type = PaymentRequest_Service.Cheque_Type.Manual_Check;
                //}
                //else
                //{
                //    _StaffAdvanceRequest.Cheque_Type = PaymentRequest_Service.Cheque_Type._blank_;
                //}

                // _PaymentRequest.No = PaymentRequest_.DocumentNo;
                // _PaymentRequest.Function_Name = PaymentRequest_.Function_Name;
                //_StaffAdvanceRequest.on = CashAdvanceRequest_.On_Behalf_Of;
                _StaffAdvanceRequest.Payee = CashAdvanceRequest_.Payee;
                //_StaffAdvanceRequest.Payee_Account_Number = CashAdvanceRequest_.Payee_Account_Number;
                _StaffAdvanceRequest.Paying_Bank_Account = CashAdvanceRequest_.Paying_Bank_Account;
               // _StaffAdvanceRequest.Purpose  = CashAdvanceRequest_.Payment_Narration;
                _StaffAdvanceRequest.Payment_Release_Date = CashAdvanceRequest_.Payment_Release_Date;
                _StaffAdvanceRequest.Date = CashAdvanceRequest_.RequestDate;
                // _PaymentRequest.Pay_Mode = PaymentRequest_.Pay_Mode;

                if (CashAdvanceRequest_.Pay_Mode == "Cash")
                {
                    _StaffAdvanceRequest.Pay_Mode = StaffAdvanceRequest_Service.Pay_Mode.Cash;
                }
                else if (CashAdvanceRequest_.Cheque_Type == "Cheque")
                {
                    _StaffAdvanceRequest.Pay_Mode = StaffAdvanceRequest_Service.Pay_Mode.Cheque;
                }
                else
                {
                    _StaffAdvanceRequest.Pay_Mode = StaffAdvanceRequest_Service.Pay_Mode._blank_;
                }



                _StaffAdvanceRequest.Date = CashAdvanceRequest_.RequestDate;
                _StaffAdvanceRequest.Responsibility_Center = CashAdvanceRequest_.Responsibility_Center;
                _StaffAdvanceRequest.Total_Net_Amount = CashAdvanceRequest_.Total_Payment_Amount;
                _StaffAdvanceRequest.Total_Net_AmountSpecified = true;
                _StaffAdvanceRequest.Total_Net_Amount_LCY = CashAdvanceRequest_.Total_Payment_Amount_LCY;
              


                string _status = CashAdvanceRequest_.Status;
                switch (_status)
                {

                    case "Approved":
                        _StaffAdvanceRequest.Status = StaffAdvanceRequest_Service.Status.Approved;
                        break;
                    case "Cancelled":
                        _StaffAdvanceRequest.Status = StaffAdvanceRequest_Service.Status.Cancelled;
                        break;
                    case "Checking":
                        _StaffAdvanceRequest.Status = StaffAdvanceRequest_Service.Status.Checking;
                        break;
                    case "Cheque_Printing":
                        _StaffAdvanceRequest.Status = StaffAdvanceRequest_Service.Status.Cheque_Printing;
                        break;
                    case "Pending":
                        _StaffAdvanceRequest.Status = StaffAdvanceRequest_Service.Status.Pending;
                        break;
                    case "Pending_Approval":
                        _StaffAdvanceRequest.Status = StaffAdvanceRequest_Service.Status.Pending_Approval;
                        break;
                    case "Posted":
                        _StaffAdvanceRequest.Status = StaffAdvanceRequest_Service.Status.Posted;
                        break;
                    default:
                        _StaffAdvanceRequest.Status = StaffAdvanceRequest_Service.Status.Pending;
                        break;
                }

                _StaffAdvanceRequest.PVLines = CashAdvanceRequest_.CashAdvanceRequestLines;
                
                staffAdvRequest.Update(ref _StaffAdvanceRequest);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }



        }

        public string UpdateStaffClaim(StaffClaim staffClaim_)
        {

            StaffClaim_Service.StaffClaim_Service StaffClaimService = new StaffClaim_Service.StaffClaim_Service();
            StaffClaimService.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
            StaffClaimService.PreAuthenticate = true;



            try
            {
                
                StaffClaim_Service.StaffClaim _staffClaim = new StaffClaim_Service.StaffClaim();

                _staffClaim = StaffClaimService.Read(staffClaim_.DocumentNo);

                _staffClaim.Account_No = staffClaim_.AccountNo;
               // _staffClaim.Budget_Center_Name = staffClaim_.BudgetCenterName;
                _staffClaim.Cashier = staffClaim_.Cashier;
                _staffClaim.Date = staffClaim_.ClaimDate;
                _staffClaim.No = staffClaim_.DocumentNo;
                _staffClaim.Payee = staffClaim_.Paye;
               // _staffClaim.Function_Name = staffClaim_.FunctionName;
                _staffClaim.Purpose = staffClaim_.Purpose;
                _staffClaim.Responsibility_Center = staffClaim_.Responsibility_Center;
                _staffClaim.Total_Net_Amount = staffClaim_.TotalNetAmount;

                string _status = staffClaim_.Status;
                switch (_status)
                {

                    case "Approved":
                        _staffClaim.Status = StaffClaim_Service.Status.Approved;
                        break;
                    case "Cancelled":
                        _staffClaim.Status = StaffClaim_Service.Status.Cancelled;
                        break;
                    case "Checking":
                        _staffClaim.Status = StaffClaim_Service.Status.Checking;
                        break;
                    case "Cheque_Printing":
                        _staffClaim.Status = StaffClaim_Service.Status.Cheque_Printing;
                        break;
                    case "Pending":
                        _staffClaim.Status = StaffClaim_Service.Status.Pending;
                        break;
                    case "Pending_Approval":
                        _staffClaim.Status = StaffClaim_Service.Status.Pending_Approval;
                        break;
                    case "Posted":
                        _staffClaim.Status = StaffClaim_Service.Status.Posted;
                        break;
                    default:
                        _staffClaim.Status = StaffClaim_Service.Status.Pending;
                        break;
                }

                _staffClaim.PVLines = staffClaim_.PVLines;
                StaffClaimService.Update(ref _staffClaim);
               
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }



        }

        public AppraisalRequest getAppraisalRequest(string AppraisalNo)
        {

            AppraisalRequest AppraisalReq = new AppraisalRequest();
            try
            {
                HR_AppraisalH_Service.HRAppraisalH AppraisalH = new HR_AppraisalH_Service.HRAppraisalH();
                HR_AppraisalH_Service.HRAppraisalH_Service hRAppraisalH = new HR_AppraisalH_Service.HRAppraisalH_Service();
                hRAppraisalH.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                hRAppraisalH.PreAuthenticate = true;
                hRAppraisalH.Create(ref AppraisalH);
                AppraisalReq.Appraisal_Date = AppraisalH.Appraisal_Date;
                AppraisalReq.Appraisal_Half = AppraisalH.Appraisal_Half;
                AppraisalReq.Appraisal_No = AppraisalH.Appraisal_No;
                AppraisalReq.Appraisal_Period = AppraisalH.Appraisal_Period;
                AppraisalReq.Appraisal_Type = AppraisalH.Appraisal_Type;
                AppraisalReq.Current_Location = AppraisalH.Current_Location;
                AppraisalReq.DepartmentName = AppraisalH.Department;
                AppraisalReq.EmployeeNo = AppraisalH.Employee_No;
                AppraisalReq.Responsibility_Center = AppraisalH.Responsibility_Center;
                AppraisalReq.Date_Of_Last_Promotion_Notch = AppraisalH.Date_Of_Last_Promotion_Notch;
                AppraisalReq.SelfEvaluations = getAppraisalSelfEvaluationList2(AppraisalH.Appraisal_No);

                return AppraisalReq;
            }
            catch (Exception ex)
            {
                AppraisalReq.ExceptionMessage = ex.Message;
                return AppraisalReq;

            }

        }

        public AppraisalRequest CreateAppraisal(string  userName)
        {

            AppraisalRequest AppraisalReq = new AppraisalRequest();
            try

            {

                HR_AppraisalH_Service.HRAppraisalH AppraisalH = new HR_AppraisalH_Service.HRAppraisalH();
                HR_AppraisalH_Service.HRAppraisalH_Service hRAppraisalH = new HR_AppraisalH_Service.HRAppraisalH_Service();
                hRAppraisalH.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                hRAppraisalH.PreAuthenticate = true;
                hRAppraisalH.Create(ref AppraisalH);
                AppraisalReq.Appraisal_No = AppraisalH.Appraisal_No;

                AppraisalH.SS_User_ID = userName;
                AppraisalH.Self_Service = true;

                hRAppraisalH.Update(ref AppraisalH);


                //HR_AppraisalH_Service.HRAppraisalH AppraisalH = new HR_AppraisalH_Service.HRAppraisalH();
                //HR_AppraisalH_Service.HRAppraisalH_Service hRAppraisalH = new HR_AppraisalH_Service.HRAppraisalH_Service();
                //hRAppraisalH.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                //hRAppraisalH.PreAuthenticate = true;
                //hRAppraisalH.Create(ref AppraisalH);
                //AppraisalReq.Appraisal_Date = AppraisalH.Appraisal_Date;
                //AppraisalReq.Appraisal_Half  = AppraisalH.Appraisal_Half ;
                //AppraisalReq.Appraisal_No = AppraisalH.Appraisal_No;
                //AppraisalReq.Appraisal_Period = AppraisalH.Appraisal_Period;
                //AppraisalReq.Appraisal_Type = AppraisalH.Appraisal_Type;
                //AppraisalReq.Current_Location = AppraisalH.Current_Location;
                //AppraisalReq.DepartmentName = AppraisalH.Department;
                //AppraisalReq.EmployeeNo = AppraisalH.Employee_No;
                //AppraisalReq.Responsibility_Center = AppraisalH.Responsibility_Center;
                //AppraisalReq.Date_Of_Last_Promotion_Notch = AppraisalH.Date_Of_Last_Promotion_Notch;
                //AppraisalReq.SelfEvaluations = getAppraisalSelfEvaluationList(AppraisalH.Appraisal_No);
                //return AppraisalReq;

                string _status;
                General_Service.pfagetbalance _General_Service = new General_Service.pfagetbalance();
                _General_Service.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _status = (_General_Service.UpdateUserIDSS(AppraisalH.Appraisal_No, "APPRAISAL") == true) ? "Success" : "Fail";

                //return _status;

                AppraisalReq.ExceptionMessage = _status;
                return AppraisalReq;

            }

                catch (Exception ex)

            {
                AppraisalReq.ExceptionMessage = ex.Message;
                return AppraisalReq;

            }

        }


        public string updateAppraisalComment(AppraisalRequest _appraisalRequest) 
        {
            try 
            {
                HR_AppraisalH_Service.HRAppraisalH AppraisalH = new HR_AppraisalH_Service.HRAppraisalH();
                HR_AppraisalH_Service.HRAppraisalH_Service hRAppraisalH = new HR_AppraisalH_Service.HRAppraisalH_Service();
                hRAppraisalH.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                hRAppraisalH.PreAuthenticate = true;

                AppraisalH.Appraisal_No = _appraisalRequest.Appraisal_No;
                AppraisalH.Employee_Comment = _appraisalRequest.EmployeeComment;
                AppraisalH.Supervisor_Comment = _appraisalRequest.SupervisorComment;
                AppraisalH.HOD_Comment = _appraisalRequest.HODComment;
                AppraisalH.MD_Comment = _appraisalRequest.MDComment;
                AppraisalH.Key = _appraisalRequest.Key;
                AppraisalH.Responsibility_Center = _appraisalRequest.Responsibility_Center;
                
                hRAppraisalH.Update(ref AppraisalH);
                return "Updated Successfully";
            }
            catch (Exception ex) 
            {
                return ex.Message;
            }

        }

        public List<AppraisalRequest> getStaffAppraisal(string appraisalNo, string employeeNo )
        {

            List<AppraisalRequest> lstAppraisalReq = new List<AppraisalRequest>();
            try
            {
                HR_AppraisalH_Service.HRAppraisalH AppraisalH = new HR_AppraisalH_Service.HRAppraisalH();
                HR_AppraisalH_Service.HRAppraisalH_Service hRAppraisalH = new HR_AppraisalH_Service.HRAppraisalH_Service();
                hRAppraisalH.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                hRAppraisalH.PreAuthenticate = true;

                List<HR_AppraisalH_Service.HRAppraisalH_Filter> StaffAppraisalFilterArray = new List<HR_AppraisalH_Service.HRAppraisalH_Filter>();

                HR_AppraisalH_Service.HRAppraisalH_Filter StaffAppraisalFilter = new HR_AppraisalH_Service.HRAppraisalH_Filter();
                if (employeeNo == "") { 

                    StaffAppraisalFilter.Field = HR_AppraisalH_Service.HRAppraisalH_Fields.Appraisal_No;
                    StaffAppraisalFilter.Criteria = appraisalNo;
                }
                else { 

                    StaffAppraisalFilter.Field = HR_AppraisalH_Service.HRAppraisalH_Fields.Employee_No;
                    StaffAppraisalFilter.Criteria = employeeNo;
                }

                StaffAppraisalFilterArray.Add(StaffAppraisalFilter);

                // Runs the actual search.

                HR_AppraisalH_Service.HRAppraisalH[] results = hRAppraisalH.ReadMultiple(StaffAppraisalFilterArray.ToArray(), null, 1000);

                int i = 0;

                while (i < results.Length)
                {
                    
                    AppraisalRequest AppraisalReq = new AppraisalRequest();
                    AppraisalReq.Appraisal_Date = results[i].Appraisal_Date;
                    AppraisalReq.Appraisal_Half = results[i].Appraisal_Half;
                    AppraisalReq.Appraisal_No = results[i].Appraisal_No;
                    AppraisalReq.Appraisal_Period = results[i].Appraisal_Period;
                    AppraisalReq.Appraisal_Type = results[i].Appraisal_Type;
                    AppraisalReq.Current_Location = results[i].Current_Location;
                    AppraisalReq.DepartmentName = results[i].Department;
                    AppraisalReq.EmployeeNo = results[i].Employee_No;
                    AppraisalReq.Responsibility_Center = results[i].Responsibility_Center;
                    AppraisalReq.Date_Of_Last_Promotion_Notch = results[i].Date_Of_Last_Promotion_Notch;
                    AppraisalReq.SelfEvaluations = getAppraisalSelfEvaluationList(appraisalNo);
                    AppraisalReq.Status = results[i].Status.ToString();
                    AppraisalReq.JobTitle = results[i].Job_Title.ToString();
                    AppraisalReq.EmployeeName = results[i].Employee_Name.ToString();

                    AppraisalReq.Key = results[i].Key.ToString();

                    AppraisalReq.EmployeeComment = results[i].Employee_Comment == null ? "" : results[i].Employee_Comment.ToString();
                    AppraisalReq.SupervisorComment = results[i].Supervisor_Comment == null ? "" : results[i].Supervisor_Comment.ToString();
                    AppraisalReq.HODComment = results[i].HOD_Comment == null ? "" : results[i].HOD_Comment.ToString();
                    AppraisalReq.MDComment = results[i].MD_Comment == null ? "" : results[i].MD_Comment.ToString();


                    lstAppraisalReq.Add(AppraisalReq);
                    i++;

                }

                return lstAppraisalReq;

            }
            catch (Exception ex)
            {
                
                AppraisalRequest AppraisalReq = new AppraisalRequest();
                AppraisalReq.ExceptionMessage = ex.Message;
                lstAppraisalReq.Add(AppraisalReq);
                return lstAppraisalReq;

            }



        }


        public List<CareerDevelopmentQuestion> GetCareerDevelopments(string appraisalNo)
        {
            List<CareerDevelopmentQuestion> lstCareerDevQuestions = new List<CareerDevelopmentQuestion>();
            try
            {

                HRAppraisalCareerDev.HRAppraisalCareerDevQues nn = new HRAppraisalCareerDev.HRAppraisalCareerDevQues();
                
                HRAppraisalCareerDev.HRAppraisalCareerDevQues_Service _careerdev = new HRAppraisalCareerDev.HRAppraisalCareerDevQues_Service();

                _careerdev.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _careerdev.PreAuthenticate = true;
                List<HRAppraisalCareerDev.HRAppraisalCareerDevQues_Filter> _careerdevFilterArray = new List<HRAppraisalCareerDev.HRAppraisalCareerDevQues_Filter>();

                HRAppraisalCareerDev.HRAppraisalCareerDevQues_Filter _careerdevFilter = new HRAppraisalCareerDev.HRAppraisalCareerDevQues_Filter();

                _careerdevFilter.Field = HRAppraisalCareerDev.HRAppraisalCareerDevQues_Fields.Appraisal_Code;
                _careerdevFilter.Criteria = appraisalNo;
                _careerdevFilterArray.Add(_careerdevFilter);
                // Runs the actual search.
                HRAppraisalCareerDev.HRAppraisalCareerDevQues[] results = _careerdev.ReadMultiple(_careerdevFilterArray.ToArray(), null, 100);

                int i = 0;
                while (i < results.Length)
                {

                    CareerDevelopmentQuestion _careerDevQuestion = new CareerDevelopmentQuestion();
                    _careerDevQuestion.AppraisalNo = results[i].Appraisal_Code;
                    _careerDevQuestion.Question = results[i].Question;
                    _careerDevQuestion.Answer = results[i].Answer;
                    _careerDevQuestion.Key = results[i].Key;
                    lstCareerDevQuestions.Add(_careerDevQuestion);
                    i++;

                }
                return lstCareerDevQuestions;
            }
            catch (Exception ex)
            {
                CareerDevelopmentQuestion _careerDevQuestion = new CareerDevelopmentQuestion();
                _careerDevQuestion.Exceptions = ex.Message;
                lstCareerDevQuestions.Add(_careerDevQuestion);
                return lstCareerDevQuestions;

            }

            //return nothin;


        }

        public string UpdateCareerDevelopments(CareerDevelopmentQuestion careerDevelopment)
        {
            List<CareerDevelopmentQuestion> lstCareerDevQuestions = new List<CareerDevelopmentQuestion>();
            try
            {

                HRAppraisalCareerDev.HRAppraisalCareerDevQues _careerDevelopment = new HRAppraisalCareerDev.HRAppraisalCareerDevQues();

                HRAppraisalCareerDev.HRAppraisalCareerDevQues_Service _careerdev = new HRAppraisalCareerDev.HRAppraisalCareerDevQues_Service();

                _careerdev.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _careerdev.PreAuthenticate = true;

                if (careerDevelopment.AppraisalNo != "" && careerDevelopment.Answer != "")
                {
                    _careerDevelopment.Answer = careerDevelopment.Answer;
                    _careerDevelopment.Key = careerDevelopment.Key;
                    _careerDevelopment.Appraisal_Code = careerDevelopment.AppraisalNo;
                    _careerDevelopment.Question = careerDevelopment.Question;
                    _careerdev.Update(ref _careerDevelopment);
                    return "Successfully Updated";

                }
                else 
                {
                    return "No Action Performed";
                }





               
            }
            catch (Exception ex)
            {
                
                return ex.Message;

            }

            //return nothin;


        }



        //get list of financial KPI created
        public List<Behavoural> getKPIFinancial(string appraisalno)
        {
            
            try
            {
                List<Behavoural> lstBehavoural = new List<Behavoural>();

                HRAppraisalKPIFinance.HRAppraisalKPIB nn = new HRAppraisalKPIFinance.HRAppraisalKPIB();

                HRAppraisalKPIFinance.HRAppraisalKPIB_Service _financial = new HRAppraisalKPIFinance.HRAppraisalKPIB_Service();

                _financial.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _financial.PreAuthenticate = true;
                List<HRAppraisalKPIFinance.HRAppraisalKPIB_Filter> _financialFilterArray = new List<HRAppraisalKPIFinance.HRAppraisalKPIB_Filter>();

                HRAppraisalKPIFinance.HRAppraisalKPIB_Filter _financialFilter = new HRAppraisalKPIFinance.HRAppraisalKPIB_Filter();

                _financialFilter.Field = HRAppraisalKPIFinance.HRAppraisalKPIB_Fields.Appraisal_No;
                _financialFilter.Criteria = appraisalno;
                _financialFilterArray.Add(_financialFilter);
                // Runs the actual search.
                HRAppraisalKPIFinance.HRAppraisalKPIB[] results = _financial.ReadMultiple(_financialFilterArray.ToArray(), null, 100);

                int i = 0;

                while (i < results.Length)
                {

                    Behavoural _SelfBehavoural = new Behavoural();
                    _SelfBehavoural.Appraisal_No = results[i].Appraisal_No;
                    _SelfBehavoural.TargetObjective = results[i].Planned_Targets_Objectives;
                    _SelfBehavoural.Description = results[i].Description;
                    _SelfBehavoural.Timing = results[i].Timing.ToString();
                    //_SelfBehavoural.Weight = results[i].Weight;
                    _SelfBehavoural.Weight = results[i].Target_Score_Percent;
                    _SelfBehavoural.Ratings = results[i].Ratings;
                    _SelfBehavoural.Score = results[i].Score;
                    _SelfBehavoural.Supervisor_Score = results[i].Self_Rating;
                    _SelfBehavoural.Key = results[i].Key;
                    lstBehavoural.Add(_SelfBehavoural);

                    i++;

                }

                return lstBehavoural;







            }
            catch (Exception ex)
            {

                return null;
            }

            //return nothin;


        }
        //creates and update financial KPI
        public string createKPIFinancial(Behavoural kpiFinancial)
        {

            try
            {
                List<Behavoural> lstBehavoural = new List<Behavoural>();

                HRAppraisalKPIFinance.HRAppraisalKPIB _kpiFinancial = new HRAppraisalKPIFinance.HRAppraisalKPIB();

                HRAppraisalKPIFinance.HRAppraisalKPIB_Service _financial = new HRAppraisalKPIFinance.HRAppraisalKPIB_Service();

                _financial.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _financial.PreAuthenticate = true;

                if (kpiFinancial.Key == "")
                    {
                    
                    string _timing = kpiFinancial.Timing;
                    switch (_timing)
                    {
                        case "Daily":
                            _kpiFinancial.Timing = HRAppraisalKPIFinance.Timing.Daily;
                            break;

                        case "Weekly":
                            _kpiFinancial.Timing = HRAppraisalKPIFinance.Timing.Weekly;
                            break;
                       
                        case "Hourly":
                            _kpiFinancial.Timing = HRAppraisalKPIFinance.Timing.Hourly;
                            break;
                        case "Monthly":
                            _kpiFinancial.Timing = HRAppraisalKPIFinance.Timing.Monthly;
                            break;
                        case "Quarterly":
                            _kpiFinancial.Timing = HRAppraisalKPIFinance.Timing.Quarterly;
                            break;

                        case "Biannual":
                            _kpiFinancial.Timing = HRAppraisalKPIFinance.Timing.Biannual;
                            break;

                        default:
                            _kpiFinancial.Timing = HRAppraisalKPIFinance.Timing.All_Year; ;
                            break;
                    };
                    _kpiFinancial.TimingSpecified = true;
                    _kpiFinancial.Appraisal_No = kpiFinancial.Appraisal_No;
                    _kpiFinancial.Planned_Targets_Objectives = kpiFinancial.TargetObjective;
                    _kpiFinancial.Description = kpiFinancial.Description;
                    //_kpiFinancial.Weight = kpiFinancial.Weight;
                    _kpiFinancial.Target_Score_Percent = kpiFinancial.Weight;
                    _kpiFinancial.Target_Score_PercentSpecified = true;
                    //_kpiFinancial.WeightSpecified = true;
                    _kpiFinancial.Ratings = kpiFinancial.Ratings;
                    _kpiFinancial.Score = kpiFinancial.Score;
                    _kpiFinancial.Appraisal_Period = kpiFinancial.AppraisalPeriod ;

                    if (kpiFinancial.AppraisalHalf == 1)
                    {
                        _kpiFinancial.Half = HRAppraisalKPIFinance.Half.First;
                    }
                    else if (kpiFinancial.AppraisalHalf == 2)
                    {
                        _kpiFinancial.Half = HRAppraisalKPIFinance.Half.Second;
                    }
                    else 
                    {
                        _kpiFinancial.Half = HRAppraisalKPIFinance.Half._blank_;
                    }
                    _kpiFinancial.HalfSpecified = true;
                    _financial.Create(ref _kpiFinancial);
                    return "Successfully Created";

                }
                else 
                {
                    
                    _kpiFinancial.Appraisal_No = kpiFinancial.Appraisal_No;
                    _kpiFinancial.Planned_Targets_Objectives = kpiFinancial.TargetObjective;
                    _kpiFinancial.Description = kpiFinancial.Description;


                    string _timing = kpiFinancial.Timing;
                    switch (_timing)
                    {

                        case "Weekly":
                            _kpiFinancial.Timing = HRAppraisalKPIFinance.Timing.Weekly;
                            break;
                        case "Daily":
                            _kpiFinancial.Timing = HRAppraisalKPIFinance.Timing.Daily;
                            break;
                        case "Hourly":
                            _kpiFinancial.Timing = HRAppraisalKPIFinance.Timing.Hourly;
                            break;
                        case "Monthly":
                            _kpiFinancial.Timing = HRAppraisalKPIFinance.Timing.Monthly;
                            break;
                        case "Quarterly":
                            _kpiFinancial.Timing = HRAppraisalKPIFinance.Timing.Quarterly;
                            break;
                        case "Biannual":
                            _kpiFinancial.Timing = HRAppraisalKPIFinance.Timing.Biannual;
                            break;
                        default:
                            _kpiFinancial.Timing = HRAppraisalKPIFinance.Timing.All_Year; ;
                            break;
                    };
                    _kpiFinancial.TimingSpecified = true;
                    //_kpiFinancial.Weight = kpiFinancial.Weight;
                    _kpiFinancial.Target_Score_Percent = kpiFinancial.Weight;
                    _kpiFinancial.Target_Score_PercentSpecified = true;
                    _kpiFinancial.Ratings = kpiFinancial.Ratings;
                    _kpiFinancial.Score = kpiFinancial.Score;
                    _kpiFinancial.Key = kpiFinancial.Key;
                    _financial.Update(ref _kpiFinancial);
                    return "Successfully Updated";
                };
                

            }
            catch (Exception ex)
            {

                return ex.Message;
            }

            //return nothin;


        }



        //get list of customer KPI created
        public List<Behavoural> getKPICustomer(string appraisalno)
        {

            try
            {
                List<Behavoural> lstBehavoural = new List<Behavoural>();

                HRAppraisalKPICustomer.HRAppraisalKPIC nn = new HRAppraisalKPICustomer.HRAppraisalKPIC();

                HRAppraisalKPICustomer.HRAppraisalKPIC_Service _customer = new HRAppraisalKPICustomer.HRAppraisalKPIC_Service();

                _customer.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _customer.PreAuthenticate = true;
                List<HRAppraisalKPICustomer.HRAppraisalKPIC_Filter> _customerFilterArray = new List<HRAppraisalKPICustomer.HRAppraisalKPIC_Filter>();

                HRAppraisalKPICustomer.HRAppraisalKPIC_Filter _customerFilter = new HRAppraisalKPICustomer.HRAppraisalKPIC_Filter();

                _customerFilter.Field = HRAppraisalKPICustomer.HRAppraisalKPIC_Fields.Appraisal_No;
                _customerFilter.Criteria = appraisalno;
                _customerFilterArray.Add(_customerFilter);
                // Runs the actual search.
                HRAppraisalKPICustomer.HRAppraisalKPIC[] results = _customer.ReadMultiple(_customerFilterArray.ToArray(), null, 100);

                int i = 0;

                while (i < results.Length)
                {

                    Behavoural _SelfBehavoural = new Behavoural();
                    _SelfBehavoural.Appraisal_No = results[i].Appraisal_No;
                    _SelfBehavoural.TargetObjective = results[i].Planned_Targets_Objectives;
                    _SelfBehavoural.Description = results[i].Description;
                    _SelfBehavoural.Timing = results[i].Timing.ToString();
                    //_SelfBehavoural.Weight = results[i].Weight;
                    _SelfBehavoural.Weight = results[i].Target_Score_Percent;
                    _SelfBehavoural.Ratings = results[i].Ratings;
                    _SelfBehavoural.Score = results[i].Score;
                    _SelfBehavoural.Supervisor_Score = results[i].Self_Rating;
                    _SelfBehavoural.Key = results[i].Key;
                    lstBehavoural.Add(_SelfBehavoural);

                    i++;

                }

                return lstBehavoural;

            }
            catch (Exception ex)
            {

                return null;
            }

            //return nothin;


        }

        //creates and update customer KPI
        public string createKPICustomer(Behavoural kpiCustomer)
        {

            try
            {
                List<Behavoural> lstBehavoural = new List<Behavoural>();

                HRAppraisalKPICustomer.HRAppraisalKPIC _kpiCustomer = new HRAppraisalKPICustomer.HRAppraisalKPIC();

                HRAppraisalKPICustomer.HRAppraisalKPIC_Service _customer = new HRAppraisalKPICustomer.HRAppraisalKPIC_Service();

                _customer.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _customer.PreAuthenticate = true;
                if (kpiCustomer.Key == "")
                {
                    string _timing = kpiCustomer.Timing;
                    switch (_timing)
                    {
                        case "Daily":
                            _kpiCustomer.Timing = HRAppraisalKPICustomer.Timing.Daily;
                            break;

                        case "Weekly":
                            _kpiCustomer.Timing = HRAppraisalKPICustomer.Timing.Weekly;
                            break;

                        case "Hourly":
                            _kpiCustomer.Timing = HRAppraisalKPICustomer.Timing.Hourly;
                            break;
                        case "Monthly":
                            _kpiCustomer.Timing = HRAppraisalKPICustomer.Timing.Monthly;
                            break;
                        case "Quarterly":
                            _kpiCustomer.Timing = HRAppraisalKPICustomer.Timing.Quarterly;
                            break;

                        case "Biannual":
                            _kpiCustomer.Timing = HRAppraisalKPICustomer.Timing.Biannual;
                            break;

                        default:
                            _kpiCustomer.Timing = HRAppraisalKPICustomer.Timing.All_Year; ;
                            break;
                    };
                    _kpiCustomer.TimingSpecified = true;
                    _kpiCustomer.Appraisal_No = kpiCustomer.Appraisal_No;
                    _kpiCustomer.Planned_Targets_Objectives = kpiCustomer.TargetObjective;
                    _kpiCustomer.Description = kpiCustomer.Description;
                    //_kpiFinancial.Weight = kpiFinancial.Weight;
                    _kpiCustomer.Target_Score_Percent = kpiCustomer.Weight;
                    _kpiCustomer.Target_Score_PercentSpecified = true;
                    //_kpiFinancial.WeightSpecified = true;
                    _kpiCustomer.Ratings = kpiCustomer.Ratings;
                    _kpiCustomer.Score = kpiCustomer.Score;
                    _kpiCustomer.Appraisal_Period = kpiCustomer.AppraisalPeriod;

                    if (kpiCustomer.AppraisalHalf == 1)
                    {
                        _kpiCustomer.Half = HRAppraisalKPICustomer.Half.First;
                    }
                    else if (kpiCustomer.AppraisalHalf == 2)
                    {
                        _kpiCustomer.Half = HRAppraisalKPICustomer.Half.Second;
                    }
                    else
                    {
                        _kpiCustomer.Half = HRAppraisalKPICustomer.Half._blank_;
                    }
                    _kpiCustomer.HalfSpecified = true;
                    _customer.Create(ref _kpiCustomer);
                    return "Successfully Created";

                }
                else
                {

                    _kpiCustomer.Appraisal_No = kpiCustomer.Appraisal_No;
                    _kpiCustomer.Planned_Targets_Objectives = kpiCustomer.TargetObjective;
                    _kpiCustomer.Description = kpiCustomer.Description;


                    string _timing = kpiCustomer.Timing;
                    switch (_timing)
                    {

                        case "Weekly":
                            _kpiCustomer.Timing = HRAppraisalKPICustomer.Timing.Weekly;
                            break;
                        case "Daily":
                            _kpiCustomer.Timing = HRAppraisalKPICustomer.Timing.Daily;
                            break;
                        case "Hourly":
                            _kpiCustomer.Timing = HRAppraisalKPICustomer.Timing.Hourly;
                            break;
                        case "Monthly":
                            _kpiCustomer.Timing = HRAppraisalKPICustomer.Timing.Monthly;
                            break;
                        case "Quarterly":
                            _kpiCustomer.Timing = HRAppraisalKPICustomer.Timing.Quarterly;
                            break;
                        case "Biannual":
                            _kpiCustomer.Timing = HRAppraisalKPICustomer.Timing.Biannual;
                            break;
                        default:
                            _kpiCustomer.Timing = HRAppraisalKPICustomer.Timing.All_Year; ;
                            break;
                    };
                    _kpiCustomer.TimingSpecified = true;
                    //_kpiFinancial.Weight = kpiFinancial.Weight;
                    _kpiCustomer.Target_Score_Percent = kpiCustomer.Weight;
                    _kpiCustomer.Target_Score_PercentSpecified = true;
                    _kpiCustomer.Ratings = kpiCustomer.Ratings;
                    _kpiCustomer.Score = kpiCustomer.Score;
                    _kpiCustomer.Key = kpiCustomer.Key;
                    _customer.Update(ref _kpiCustomer);
                    return "Successfully Updated";
                };


            }
            catch (Exception ex)
            {

                return ex.Message;
            }

            //return nothin;


        }



        //get list of internal process KPI created
        public List<Behavoural> getKPIInternal(string appraisalno)
        {

            try
            {
                List<Behavoural> lstBehavoural = new List<Behavoural>();

                HRAppraisalKPIInternal.HRAppraisalKPID nn = new HRAppraisalKPIInternal.HRAppraisalKPID();

                HRAppraisalKPIInternal.HRAppraisalKPID_Service _internal = new HRAppraisalKPIInternal.HRAppraisalKPID_Service();

                _internal.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _internal.PreAuthenticate = true;
                List<HRAppraisalKPIInternal.HRAppraisalKPID_Filter> _internalFilterArray = new List<HRAppraisalKPIInternal.HRAppraisalKPID_Filter>();

                HRAppraisalKPIInternal.HRAppraisalKPID_Filter _internalFilter = new HRAppraisalKPIInternal.HRAppraisalKPID_Filter();

                _internalFilter.Field = HRAppraisalKPIInternal.HRAppraisalKPID_Fields.Appraisal_No;
                _internalFilter.Criteria = appraisalno;
                _internalFilterArray.Add(_internalFilter);
                // Runs the actual search.
                HRAppraisalKPIInternal.HRAppraisalKPID[] results = _internal.ReadMultiple(_internalFilterArray.ToArray(), null, 100);

                int i = 0;

                while (i < results.Length)
                {

                    Behavoural _SelfBehavoural = new Behavoural();
                    _SelfBehavoural.Appraisal_No = results[i].Appraisal_No;
                    _SelfBehavoural.TargetObjective = results[i].Planned_Targets_Objectives;
                    _SelfBehavoural.Description = results[i].Description;
                    _SelfBehavoural.Timing = results[i].Timing.ToString();
                    //_SelfBehavoural.Weight = results[i].Weight;
                    _SelfBehavoural.Weight = results[i].Target_Score_Percent;
                    _SelfBehavoural.Ratings = results[i].Ratings;
                    _SelfBehavoural.Score = results[i].Score;
                    _SelfBehavoural.Supervisor_Score = results[i].Self_Rating;
                    _SelfBehavoural.Key = results[i].Key;
                    lstBehavoural.Add(_SelfBehavoural);

                    i++;

                }

                return lstBehavoural;

            }
            catch (Exception ex)
            {

                return null;
            }

            //return nothin;


        }

        //creates and update internal process KPI
        public string createKPIInternal(Behavoural kpiInternal)
        {

            try
            {
                List<Behavoural> lstBehavoural = new List<Behavoural>();

                HRAppraisalKPIInternal.HRAppraisalKPID _kpiInternal = new HRAppraisalKPIInternal.HRAppraisalKPID();

                HRAppraisalKPIInternal.HRAppraisalKPID_Service _internal = new HRAppraisalKPIInternal.HRAppraisalKPID_Service();

                _internal.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _internal.PreAuthenticate = true;
                if (kpiInternal.Key == "")
                {
                    string _timing = kpiInternal.Timing;
                    switch (_timing)
                    {
                        case "Daily":
                            _kpiInternal.Timing = HRAppraisalKPIInternal.Timing.Daily;
                            break;

                        case "Weekly":
                            _kpiInternal.Timing = HRAppraisalKPIInternal.Timing.Weekly;
                            break;

                        case "Hourly":
                            _kpiInternal.Timing = HRAppraisalKPIInternal.Timing.Hourly;
                            break;
                        case "Monthly":
                            _kpiInternal.Timing = HRAppraisalKPIInternal.Timing.Monthly;
                            break;
                        case "Quarterly":
                            _kpiInternal.Timing = HRAppraisalKPIInternal.Timing.Quarterly;
                            break;

                        case "Biannual":
                            _kpiInternal.Timing = HRAppraisalKPIInternal.Timing.Biannual;
                            break;

                        default:
                            _kpiInternal.Timing = HRAppraisalKPIInternal.Timing.All_Year; ;
                            break;
                    };
                    _kpiInternal.TimingSpecified = true;
                    _kpiInternal.Appraisal_No = kpiInternal.Appraisal_No;
                    _kpiInternal.Planned_Targets_Objectives = kpiInternal.TargetObjective;
                    _kpiInternal.Description = kpiInternal.Description;
                    _kpiInternal.Target_Score_Percent = kpiInternal.Weight;
                    _kpiInternal.Target_Score_PercentSpecified = true;
                    _kpiInternal.Ratings = kpiInternal.Ratings;
                    _kpiInternal.Score = kpiInternal.Score;
                    _kpiInternal.Appraisal_Period = kpiInternal.AppraisalPeriod;

                    if (kpiInternal.AppraisalHalf == 1)
                    {
                        _kpiInternal.Half = HRAppraisalKPIInternal.Half.First;
                    }
                    else if (kpiInternal.AppraisalHalf == 2)
                    {
                        _kpiInternal.Half = HRAppraisalKPIInternal.Half.Second;
                    }
                    else
                    {
                        _kpiInternal.Half = HRAppraisalKPIInternal.Half._blank_;
                    }
                    _kpiInternal.HalfSpecified = true;
                    _internal.Create(ref _kpiInternal);
                    return "Successfully Created";

                }
                else
                {

                    _kpiInternal.Appraisal_No = kpiInternal.Appraisal_No;
                    _kpiInternal.Planned_Targets_Objectives = kpiInternal.TargetObjective;
                    _kpiInternal.Description = kpiInternal.Description;


                    string _timing = kpiInternal.Timing;
                    switch (_timing)
                    {

                        case "Weekly":
                            _kpiInternal.Timing = HRAppraisalKPIInternal.Timing.Weekly;
                            break;
                        case "Daily":
                            _kpiInternal.Timing = HRAppraisalKPIInternal.Timing.Daily;
                            break;
                        case "Hourly":
                            _kpiInternal.Timing = HRAppraisalKPIInternal.Timing.Hourly;
                            break;
                        case "Monthly":
                            _kpiInternal.Timing = HRAppraisalKPIInternal.Timing.Monthly;
                            break;
                        case "Quarterly":
                            _kpiInternal.Timing = HRAppraisalKPIInternal.Timing.Quarterly;
                            break;
                        case "Biannual":
                            _kpiInternal.Timing = HRAppraisalKPIInternal.Timing.Biannual;
                            break;
                        default:
                            _kpiInternal.Timing = HRAppraisalKPIInternal.Timing.All_Year; ;
                            break;
                    };
                    _kpiInternal.TimingSpecified = true;
                    //_kpiFinancial.Weight = kpiFinancial.Weight;
                    _kpiInternal.Target_Score_Percent = kpiInternal.Weight;
                    _kpiInternal.Target_Score_PercentSpecified = true;
                    _kpiInternal.Ratings = kpiInternal.Ratings;
                    _kpiInternal.Score = kpiInternal.Score;
                    _kpiInternal.Key = kpiInternal.Key;
                    _internal.Update(ref _kpiInternal);
                    return "Successfully Updated";
                };


            }
            catch (Exception ex)
            {

                return ex.Message;
            }

            //return nothin;


        }



        //get list of learning and growth KPI created
        public List<Behavoural> getKPILearning(string appraisalno)
        {

            try
            {
                List<Behavoural> lstBehavoural = new List<Behavoural>();

                HRAppraisalKPILearning.HRAppraisalKPIE nn = new HRAppraisalKPILearning.HRAppraisalKPIE();

                HRAppraisalKPILearning.HRAppraisalKPIE_Service _learning = new HRAppraisalKPILearning.HRAppraisalKPIE_Service();

                _learning.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _learning.PreAuthenticate = true;
                List<HRAppraisalKPILearning.HRAppraisalKPIE_Filter> _learningFilterArray = new List<HRAppraisalKPILearning.HRAppraisalKPIE_Filter>();

                HRAppraisalKPILearning.HRAppraisalKPIE_Filter _learningFilter = new HRAppraisalKPILearning.HRAppraisalKPIE_Filter();

                _learningFilter.Field = HRAppraisalKPILearning.HRAppraisalKPIE_Fields.Appraisal_No;
                _learningFilter.Criteria = appraisalno;
                _learningFilterArray.Add(_learningFilter);
                // Runs the actual search.
                HRAppraisalKPILearning.HRAppraisalKPIE[] results = _learning.ReadMultiple(_learningFilterArray.ToArray(), null, 100);

                int i = 0;

                while (i < results.Length)
                {

                    Behavoural _SelfBehavoural = new Behavoural();
                    _SelfBehavoural.Appraisal_No = results[i].Appraisal_No;
                    _SelfBehavoural.TargetObjective = results[i].Planned_Targets_Objectives;
                    _SelfBehavoural.Description = results[i].Description;
                    _SelfBehavoural.Timing = results[i].Timing.ToString();
                    //_SelfBehavoural.Weight = results[i].Weight;
                    _SelfBehavoural.Weight = results[i].Target_Score_Percent;
                    _SelfBehavoural.Ratings = results[i].Ratings;
                    _SelfBehavoural.Score = results[i].Score;
                    _SelfBehavoural.Supervisor_Score = results[i].Self_Rating;
                    _SelfBehavoural.Key = results[i].Key;
                    lstBehavoural.Add(_SelfBehavoural);

                    i++;

                }

                return lstBehavoural;

            }
            catch (Exception ex)
            {

                return null;
            }

            //return nothin;


        }

        //creates and update internal process KPI
        public string createKPILearning(Behavoural kpiLearning)
        {

            try
            {
                List<Behavoural> lstBehavoural = new List<Behavoural>();

                HRAppraisalKPILearning.HRAppraisalKPIE _kpiLearning = new HRAppraisalKPILearning.HRAppraisalKPIE();

                HRAppraisalKPILearning.HRAppraisalKPIE_Service _learning = new HRAppraisalKPILearning.HRAppraisalKPIE_Service();

                _learning.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _learning.PreAuthenticate = true;
                if (kpiLearning.Key == "")
                {
                    string _timing = kpiLearning.Timing;
                    switch (_timing)
                    {
                        case "Daily":
                            _kpiLearning.Timing = HRAppraisalKPILearning.Timing.Daily;
                            break;

                        case "Weekly":
                            _kpiLearning.Timing = HRAppraisalKPILearning.Timing.Weekly;
                            break;

                        case "Hourly":
                            _kpiLearning.Timing = HRAppraisalKPILearning.Timing.Hourly;
                            break;
                        case "Monthly":
                            _kpiLearning.Timing = HRAppraisalKPILearning.Timing.Monthly;
                            break;
                        case "Quarterly":
                            _kpiLearning.Timing = HRAppraisalKPILearning.Timing.Quarterly;
                            break;

                        case "Biannual":
                            _kpiLearning.Timing = HRAppraisalKPILearning.Timing.Biannual;
                            break;

                        default:
                            _kpiLearning.Timing = HRAppraisalKPILearning.Timing.All_Year; ;
                            break;
                    };
                    _kpiLearning.TimingSpecified = true;
                    _kpiLearning.Appraisal_No = kpiLearning.Appraisal_No;
                    _kpiLearning.Planned_Targets_Objectives = kpiLearning.TargetObjective;
                    _kpiLearning.Description = kpiLearning.Description;
                    _kpiLearning.Target_Score_Percent = kpiLearning.Weight;
                    _kpiLearning.Target_Score_PercentSpecified = true;
                    _kpiLearning.Ratings = kpiLearning.Ratings;
                    _kpiLearning.Score = kpiLearning.Score;
                    _kpiLearning.Appraisal_Period = kpiLearning.AppraisalPeriod;

                    if (kpiLearning.AppraisalHalf == 1)
                    {
                        _kpiLearning.Half = HRAppraisalKPILearning.Half.First;
                    }
                    else if (kpiLearning.AppraisalHalf == 2)
                    {
                        _kpiLearning.Half = HRAppraisalKPILearning.Half.Second;
                    }
                    else
                    {
                        _kpiLearning.Half = HRAppraisalKPILearning.Half._blank_;
                    }
                    _kpiLearning.HalfSpecified = true;
                    _learning.Create(ref _kpiLearning);
                    return "Successfully Created";

                }
                else
                {

                    _kpiLearning.Appraisal_No = kpiLearning.Appraisal_No;
                    _kpiLearning.Planned_Targets_Objectives = kpiLearning.TargetObjective;
                    _kpiLearning.Description = kpiLearning.Description;


                    string _timing = kpiLearning.Timing;
                    switch (_timing)
                    {

                        case "Weekly":
                            _kpiLearning.Timing = HRAppraisalKPILearning.Timing.Weekly;
                            break;
                        case "Daily":
                            _kpiLearning.Timing = HRAppraisalKPILearning.Timing.Daily;
                            break;
                        case "Hourly":
                            _kpiLearning.Timing = HRAppraisalKPILearning.Timing.Hourly;
                            break;
                        case "Monthly":
                            _kpiLearning.Timing = HRAppraisalKPILearning.Timing.Monthly;
                            break;
                        case "Quarterly":
                            _kpiLearning.Timing = HRAppraisalKPILearning.Timing.Quarterly;
                            break;
                        case "Biannual":
                            _kpiLearning.Timing = HRAppraisalKPILearning.Timing.Biannual;
                            break;
                        default:
                            _kpiLearning.Timing = HRAppraisalKPILearning.Timing.All_Year; ;
                            break;
                    };
                    _kpiLearning.TimingSpecified = true;
                    //_kpiFinancial.Weight = kpiFinancial.Weight;
                    _kpiLearning.Target_Score_Percent = kpiLearning.Weight;
                    _kpiLearning.Target_Score_PercentSpecified = true;
                    _kpiLearning.Ratings = kpiLearning.Ratings;
                    _kpiLearning.Score = kpiLearning.Score;
                    _kpiLearning.Key = kpiLearning.Key;
                    _learning.Update(ref _kpiLearning);
                    return "Successfully Updated";
                };


            }
            catch (Exception ex)
            {

                return ex.Message;
            }

            //return nothin;


        }



        public List<Behavoural> getAppraisalBehavoural(string requestType, string appraisalNo)
        {

            List<Behavoural> lstBehavoural = new List<Behavoural>();
            try
            {

                HR_AppraisalBehavour_Service.HRAppraisalBehavoirA_Service HRBehavoural = new HR_AppraisalBehavour_Service.HRAppraisalBehavoirA_Service();
                HRBehavoural.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                HRBehavoural.PreAuthenticate = true;

                List<HR_AppraisalBehavour_Service.HRAppraisalBehavoirA_Filter> BehavouralFilterArray = new List<HR_AppraisalBehavour_Service.HRAppraisalBehavoirA_Filter>();

                HR_AppraisalBehavour_Service.HRAppraisalBehavoirA_Filter BehavouralFilter1 = new HR_AppraisalBehavour_Service.HRAppraisalBehavoirA_Filter();

                HR_AppraisalBehavour_Service.HRAppraisalBehavoirA_Filter BehavouralFilter2 = new HR_AppraisalBehavour_Service.HRAppraisalBehavoirA_Filter();

                BehavouralFilter1.Field = HR_AppraisalBehavour_Service.HRAppraisalBehavoirA_Fields.Behavioural_Group;
                BehavouralFilter1.Criteria = requestType;
                BehavouralFilterArray.Add(BehavouralFilter1);

                BehavouralFilter2.Field = HR_AppraisalBehavour_Service.HRAppraisalBehavoirA_Fields.Appraisal_No;
                BehavouralFilter2.Criteria = appraisalNo;
                BehavouralFilterArray.Add(BehavouralFilter2);

                HR_AppraisalBehavour_Service.HRAppraisalBehavoirA[] results = HRBehavoural.ReadMultiple(BehavouralFilterArray.ToArray(), null, 1000);

                int i = 0;

                while (i < results.Length)
                {

                    Behavoural _SelfBehavoural = new Behavoural();
                    _SelfBehavoural.Appraisal_No = results[i].Appraisal_No;
                    _SelfBehavoural.TargetObjective = results[i].Planned_Targets_Objectives;
                    _SelfBehavoural.Description = results[i].Description;
                    _SelfBehavoural.Timing = results[i].Timing.ToString() ;
                    _SelfBehavoural.Weight = results[i].Weight;
                    _SelfBehavoural.ActualResult = results[i].Actual_Results_Self;
                    _SelfBehavoural.AgreedScore = results[i].Agreed_Score;
                    _SelfBehavoural.Key = results[i].Key;

                    lstBehavoural.Add(_SelfBehavoural);

                    i++;

                }

                return lstBehavoural;

            }
            catch (Exception ex)
            {
                return lstBehavoural;

            }



        }

        public List<SelfEvaluationList> getAppraisalSelfEvaluationList2(string AppraisalNo)
        {

            List<SelfEvaluationList> lstSelfEvaluation = new List<SelfEvaluationList>();
            try
            {

                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Service HRSelfEvalList = new HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Service();

                HRSelfEvalList.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                HRSelfEvalList.PreAuthenticate = true;

                List<HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter> SelfEvaluationFilterArray = new List<HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter>();

                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter SelfEvaluationFilter = new HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter();

                SelfEvaluationFilter.Field = HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Fields.Code;
                SelfEvaluationFilter.Criteria = AppraisalNo;
                SelfEvaluationFilterArray.Add(SelfEvaluationFilter);

                //UpdateAppraisalSelfEvaluation

                // Runs the actual search.

                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation[] results = HRSelfEvalList.ReadMultiple(SelfEvaluationFilterArray.ToArray(), null, 1000);

                int i = 0;

                while (i < results.Length)
                {

                    SelfEvaluationList _SelfEvaluation = new SelfEvaluationList();
                    _SelfEvaluation.Appraisal_No = results[i].Code;
                    //_SelfEvaluation.Appraisal_Period = results[i].;
                    _SelfEvaluation.Description = results[i].Description;
                    _SelfEvaluation.Key = results[i].Key;
                    _SelfEvaluation.SelfEvaluation = results[i].Self_Evaluation;

                    lstSelfEvaluation.Add(_SelfEvaluation);
                    i++;

                }

                return lstSelfEvaluation;

            }
            catch (Exception ex)
            {
                return lstSelfEvaluation;

            }

        }


        public List<SelfEvaluationList> getAppraisalSelfEvaluationList(string AppraisalNo)
        {
            List<SelfEvaluationList> lstSelfEvaluation = new List<SelfEvaluationList>();
            try
            {
                
                HR_AppraisalSelfEvaluationList_Service.SelfEvaluation_Service HRSelfEvalList = new HR_AppraisalSelfEvaluationList_Service.SelfEvaluation_Service();
                HRSelfEvalList.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                HRSelfEvalList.PreAuthenticate = true;

                List<HR_AppraisalSelfEvaluationList_Service.SelfEvaluation_Filter> SelfEvaluationFilterArray = new List<HR_AppraisalSelfEvaluationList_Service.SelfEvaluation_Filter>();

                HR_AppraisalSelfEvaluationList_Service.SelfEvaluation_Filter SelfEvaluationFilter = new HR_AppraisalSelfEvaluationList_Service.SelfEvaluation_Filter();

                SelfEvaluationFilter.Field = HR_AppraisalSelfEvaluationList_Service.SelfEvaluation_Fields.Appraisal_No;
                SelfEvaluationFilter.Criteria = AppraisalNo;
                SelfEvaluationFilterArray.Add(SelfEvaluationFilter);

                //UpdateAppraisalSelfEvaluation

                // Runs the actual search.

                HR_AppraisalSelfEvaluationList_Service.SelfEvaluation[] results = HRSelfEvalList.ReadMultiple(SelfEvaluationFilterArray.ToArray(), null, 1000);

                int i = 0;

                while (i < results.Length)
                {

                    SelfEvaluationList _SelfEvaluation = new SelfEvaluationList();
                    _SelfEvaluation.Appraisal_No = results[i].Appraisal_No;
                    _SelfEvaluation.Appraisal_Period = results[i].Appraisal_Period;
                    _SelfEvaluation.Description = results[i].Description;
                    
                    


                    lstSelfEvaluation.Add(_SelfEvaluation);
                    i++;

                }

                return lstSelfEvaluation;

            }
            catch (Exception ex)
            {
                return lstSelfEvaluation;

            }



        }

        //updating the self evaluations on the appraisal card

        public string UpdateAppraisalBehavoural(Behavoural _appraisalBehavoural)
        {

            try
            {

                HR_AppraisalBehavour_Service.HRAppraisalBehavoirA appraisalBehavoural = new HR_AppraisalBehavour_Service.HRAppraisalBehavoirA();

                HR_AppraisalBehavour_Service.HRAppraisalBehavoirA_Service HRappraisalBehavoural = new HR_AppraisalBehavour_Service.HRAppraisalBehavoirA_Service();
                HRappraisalBehavoural.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                HRappraisalBehavoural.PreAuthenticate = true;

                //List<HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter> SelfEvaluationFilterArray = new List<HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter>();

                //HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter SelfEvaluationFilter1 = new HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter();

                //HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter SelfEvaluationFilter2 = new HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter();

                //SelfEvaluationFilter1.Field = HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Fields.Code;
                //SelfEvaluationFilter1.Criteria = _selfEvaluation.Appraisal_No;
                //SelfEvaluationFilterArray.Add(SelfEvaluationFilter1);

                //SelfEvaluationFilter2.Field = HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Fields.Description;
                //SelfEvaluationFilter2.Criteria = _selfEvaluation.Description;
                //SelfEvaluationFilterArray.Add(SelfEvaluationFilter2);
                // Runs the actual search.
                //HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation[] results = HRSelfEvaluation.ReadMultiple(SelfEvaluationFilterArray.ToArray(), null, 1000);

                //if (results.Length > 0 && requestype == 0)
                //{

                appraisalBehavoural.Key = _appraisalBehavoural.Key;
                appraisalBehavoural.Actual_Results_Self = _appraisalBehavoural.ActualResult;
                appraisalBehavoural.Actual_Results_SelfSpecified = true;
                appraisalBehavoural.Appraisal_No = _appraisalBehavoural.Appraisal_No;
                //selfEvaluation.Code = results[0].Code;
                //selfEvaluation.Description = results[0].Description;
                //selfEvaluation.Self_Evaluation = _selfEvaluation.Self_Evaluation;
                //selfEvaluation.Key = _selfEvaluation.Key;

                HRappraisalBehavoural.Update(ref appraisalBehavoural);

                    return "update Successfull";
                //}
                //else if (results.Length > 0 && requestype == 1)
                //{
                //    return results[0].Self_Evaluation.ToString() + " | " + results[0].Key.ToString();
                //}
                //else
                //{
                //    selfEvaluation.Code = _selfEvaluation.Appraisal_No;
                //    selfEvaluation.Description = _selfEvaluation.Description;
                //    selfEvaluation.Self_Evaluation = _selfEvaluation.Self_Evaluation;
                //    HRSelfEvaluation.Create(ref selfEvaluation);
                //    return "create Successfull";
                //}


            }
            catch (Exception ex)
            {
                return ex.Message;

            }

        }

        public SelfEvaluation getAppraisalSelfEvaluationKey(SelfEvaluation _selfEvaluation)
        {
            var selfEval = new SelfEvaluation();
            try
            {
                
                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation selfEvaluation = new HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation();

                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Service HRSelfEvaluation = new HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Service();
                HRSelfEvaluation.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                HRSelfEvaluation.PreAuthenticate = true;

                List<HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter> SelfEvaluationFilterArray = new List<HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter>();

                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter SelfEvaluationFilter1 = new HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter();

                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter SelfEvaluationFilter2 = new HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter();

                SelfEvaluationFilter1.Field = HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Fields.Code;
                SelfEvaluationFilter1.Criteria = _selfEvaluation.Appraisal_No;
                SelfEvaluationFilterArray.Add(SelfEvaluationFilter1);

                SelfEvaluationFilter2.Field = HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Fields.Description;
                SelfEvaluationFilter2.Criteria = _selfEvaluation.Description;
                SelfEvaluationFilterArray.Add(SelfEvaluationFilter2);


                // Runs the actual search.

                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation[] results = HRSelfEvaluation.ReadMultiple(SelfEvaluationFilterArray.ToArray(), null, 1000);

                //updating staff self evaluation
                
                if (results.Length > 0 )
                {
                    
                    selfEval.Key = results[0].Key.ToString();
                    selfEval.Self_Evaluation = results[0].Self_Evaluation.ToString();
                    return selfEval;

                }
                //retrieve the key of the self evaluation entry
                else 
                {
                    selfEval.Key = "";
                    selfEval.Self_Evaluation = "";
                    
                    return selfEval;

                }

            }
            catch (Exception ex)
            {
                selfEval.Exception_Message = ex.Message;
                return selfEval;

            }



        }
        //get all self evaluation responses for an appraisal document
        public List<SelfEvaluation> getSelfEvaluationResponse(string appraisalNo)
        {
            List<SelfEvaluation> _selfEvaluations = new List<SelfEvaluation>();
            try
            {

                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation selfEvaluation = new HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation();

                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Service HRSelfEvaluation = new HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Service();
                HRSelfEvaluation.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                HRSelfEvaluation.PreAuthenticate = true;

                List<HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter> SelfEvaluationFilterArray = new List<HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter>();

                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter SelfEvaluationFilter1 = new HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter();


                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter SelfEvaluationFilter2 = new HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter();

                SelfEvaluationFilter1.Field = HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Fields.Code;
                SelfEvaluationFilter1.Criteria = appraisalNo;
                SelfEvaluationFilterArray.Add(SelfEvaluationFilter1);

                //SelfEvaluationFilter2.Field = HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Fields.Description;
                //SelfEvaluationFilter2.Criteria = _selfEvaluation.Description;
                //SelfEvaluationFilterArray.Add(SelfEvaluationFilter2);

                // Runs the actual search.

                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation[] results = HRSelfEvaluation.ReadMultiple(SelfEvaluationFilterArray.ToArray(), null, 1000);

                for (int i = 0; i < results.Length; i++) 
                {
                    var selfEval = new SelfEvaluation()
                    {
                        Description = results[i].Description,
                        Self_Evaluation = results[i].Self_Evaluation,
                        LineNo = results[i].Line_No,
                        Key = results[i].Key
                    };
                    _selfEvaluations.Add(selfEval);
                }
                return _selfEvaluations;
            }
            catch (Exception ex)
            {
                var selfEval = new SelfEvaluation()
                {
                    Description = "",
                    Self_Evaluation = "",
                    Key = "",
                    Exception_Message= ex.Message
                };
                _selfEvaluations.Add(selfEval);
                return _selfEvaluations;

            }

        }

        public SelfEvaluation CreateAppraisalSelfEvaluation(SelfEvaluation _selfEvaluation)
        {
            
            try
            {

                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation selfEvaluation = new HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation();

                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Service HRSelfEvaluation = new HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Service();
                HRSelfEvaluation.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                HRSelfEvaluation.PreAuthenticate = true;

                selfEvaluation.Code = _selfEvaluation.Appraisal_No;
                selfEvaluation.Description = _selfEvaluation.Description;
                selfEvaluation.Self_Evaluation = _selfEvaluation.Self_Evaluation;
                HRSelfEvaluation.Create(ref selfEvaluation);
                _selfEvaluation.LineNo = selfEvaluation.Line_No;

                return _selfEvaluation;

            }
            catch (Exception ex)
            {

                _selfEvaluation.Exception_Message = ex.Message;
                return _selfEvaluation;

            }

        }

        public string UpdateAppraisalSelfEvaluation(SelfEvaluation _selfEvaluation)
        {

            try
            {

                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation selfEvaluation = new HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation();

                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Service HRSelfEvaluation = new HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Service();
                HRSelfEvaluation.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                HRSelfEvaluation.PreAuthenticate = true;

                List<HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter> SelfEvaluationFilterArray = new List<HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter>();

                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter SelfEvaluationFilter1 = new HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter();


                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter SelfEvaluationFilter2 = new HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Filter();

                SelfEvaluationFilter1.Field = HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Fields.Code;
                SelfEvaluationFilter1.Criteria = _selfEvaluation.Appraisal_No;
                SelfEvaluationFilterArray.Add(SelfEvaluationFilter1);

                SelfEvaluationFilter2.Field = HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation_Fields.Line_No;
                SelfEvaluationFilter2.Criteria = _selfEvaluation.LineNo.ToString();
                SelfEvaluationFilterArray.Add(SelfEvaluationFilter2);

                // Runs the actual search.

                HR_AppraisalSelfEvaluation_Service.HRAppraisalSelfEvaluation[] results = HRSelfEvaluation.ReadMultiple(SelfEvaluationFilterArray.ToArray(), null, 1000);

                //updating staff self evaluation
                if (results.Length > 0 )
                {
                    
                    //selfEvaluation.Code = results[0].Code;

                    selfEvaluation.Self_Evaluation = _selfEvaluation.Self_Evaluation;
                    selfEvaluation.Line_No = _selfEvaluation.LineNo;
                    selfEvaluation.Code = _selfEvaluation.Appraisal_No;
                    selfEvaluation.Key = _selfEvaluation.Key;
                    HRSelfEvaluation.Update(ref selfEvaluation);

                    return "update Successfull";
                }
                else 
                {
                    return "No Record Found";
                }
                //retrieve the key of the self evaluation entry
                //else if (results.Length > 0 && requestype == 1)
                //{
                //    //return key only if staff has not enter staff evaluation before
                //    if (results[0].Self_Evaluation  != null)
                //    {

                //        return results[0].Self_Evaluation.ToString() + " | " + results[0].Key.ToString();
                //    }
                //    //return self evaluation and key if staff has provided evaluation before
                //    else
                //    {
                        
                //        return " " + " | " + results[0].Key.ToString();
                //    }

                //}
                //create new evaluation if it does not exist
                //else
                //{

                //    //selfEvaluation.Code = _selfEvaluation.Appraisal_No;
                //    //selfEvaluation.Description = _selfEvaluation.Description;
                //    //selfEvaluation.Self_Evaluation = _selfEvaluation.Self_Evaluation;
                //    //HRSelfEvaluation.Create(ref selfEvaluation);
                //    //return "create Successfull";
                //    return "";

                //}

                
            }
            catch (Exception ex)
            {
                return ex.Message;

            }



        }


        public string   CreateLeaveApplication (LeaveApplication LvApp ) 
	    {
		
		    //DateTime dat = Convert.ToDateTime ( "1986-03-24T00:00:00" );
		    //Label2.Text = dat.ToString ( "yyyy-MM-dd" );  

		    try
		    {
                
                LeaveCard_Service.LeaveApplication LeaveApp = new LeaveCard_Service.LeaveApplication ( );
			    LeaveApp.Reliever = LvApp.Reliever;
			    LeaveApp.Application_Date = Convert.ToDateTime ( LvApp.Application_Date );
			   	LeaveApp.Leave_Period = LvApp.Leave_Period;
			    LeaveApp.Leave_Type = LvApp.Leave_Type;
			    LeaveApp.Responsibility_Center = LvApp.Responsibility_Center;
                LeaveApp.Start_Date = Convert.ToDateTime(LvApp.Start_Date);
                LeaveApp.Start_DateSpecified = true;
                LeaveApp.Days_Applied = LvApp.Days_Applied;
                LeaveApp.Days_AppliedSpecified = true;
                LeaveApp.HR_Leave_Reliver_SubForm = LvApp.ReLeaverForm;
                LeaveApp.Self_Service = true;
                LeaveApp.Self_ServiceSpecified = true;
                LeaveApp.SS_User_ID = LvApp.UserName;
                LeaveApp.Employee_ID = LvApp.Employee_No; 
                LeaveCard_Service.LeaveApplication_Service lvAppService = new LeaveCard_Service.LeaveApplication_Service ( );

			    //lvAppService.Credentials = new NetworkCredential ( LvApp.UserName , LvApp.Password , "pensure-nigeria" );
                lvAppService.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                lvAppService.PreAuthenticate = true;
			    lvAppService.Create ( ref  LeaveApp );


			   //LeaveApp.Start_Date = LvApp.Start_Date.ToString ( "dd/MM/yyyy" );
			   //LeaveApp.Days_Applied = LvApp.Days_Applied;
			   //LeaveApp.isApprovalSent = true;
			   //lvAppService.Update ( ref LeaveApp );
               //DateTime.ToString ( "dd/MM/yyyy" );//
               //LeaveApp.isApprovalSent = true;
               //LeaveApp.Status = LeaveCard.Status.Pending_Approval;     
               //lvAppService.Update ( ref LeaveApp );
               //UpdateEmployeeLastLeaveNo ( LvApp.Employee_No, LeaveApp.Application_Code );

                string _status;
                General_Service.pfagetbalance _General_Service = new General_Service.pfagetbalance();
                _General_Service.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                _status = (_General_Service.UpdateLeaveApp(LeaveApp.Application_Code) == true) ? "Success" : "Fail";
                
                return _status;
                

            }
		    catch (Exception ex)
		    {
			    return ex.Message ;

		    }
		    


	    }


	    public string updateLeaveApplication ( LeaveApplication LvApp )
	    {

		    
		    try
		    {


                LeaveCard_Service.LeaveApplication_Service lvAppService = new LeaveCard_Service.LeaveApplication_Service ( );
                lvAppService.Credentials = new NetworkCredential("fundadmin2", "@Pass2023Galaxy1", "pensure-nigeria");
                lvAppService.PreAuthenticate = true;

			    List<LeaveCard_Service.LeaveApplication_Filter> LeaveCardFilterArray = new List<LeaveCard_Service.LeaveApplication_Filter> ( );
                LeaveCard_Service.LeaveApplication_Filter LeaveCardFilter = new LeaveCard_Service.LeaveApplication_Filter ( );
			    LeaveCardFilter.Field = LeaveCard_Service.LeaveApplication_Fields.Application_Code;
			    LeaveCardFilter.Criteria = LvApp.LeaveNumber;
			    LeaveCardFilterArray.Add ( LeaveCardFilter );
                LeaveCard_Service.LeaveApplication[] results = lvAppService.ReadMultiple ( LeaveCardFilterArray.ToArray ( ), null, 5 );



				if (results.Length > 0)
			    {

				    results[0].Application_Date = Convert.ToDateTime ( LvApp.Application_Date );
				    results[0].Reliever = LvApp.Reliever;
				    results[0].Employee_No = LvApp.Employee_No;
				    results[0].Leave_Period = LvApp.Leave_Period;
				    results[0].Leave_Type = LvApp.Leave_Type;
				    results[0].Responsibility_Center = LvApp.Responsibility_Center;

                    results[0].Start_Date = Convert.ToDateTime ( LvApp.Start_Date  );
                    results[0].Start_DateSpecified = true;
                    results[0].Days_Applied  = LvApp.Days_Applied  ;
                    results[0].Days_AppliedSpecified = true;
                   // results[0].Status = LeaveCard_Service.Status.Pending_Approval;
                    results[0].HR_Leave_Reliver_SubForm = LvApp.ReLeaverForm;

                    lvAppService.Update ( ref results[0] );

				    return "Success";

			    }
			    return "No Record Found";

		    }
		    catch (Exception ex)
		    {
			    return ex.Message;

		    }

	    }


    }
    public class ResponsibilityCenter { 
    
    }

    public class LeaveApplication
    {
	    String txtUserName;
	    String txtpassword;
	    String txtLeaveNo;
	    String txtResponsibility_Center;
	    String txtReliever;
	    DateTime dteApplication_Date;
	    String txtEmployee_No;
	    String txtLeave_Period;
	    DateTime dteStart_Date;
	    int intLeaveDays;
	    string  txtLeaveType;
        LeaveCard_Service.HR_Leave_Reliver_SubForm[] txtReLeaverForm;

        
        public LeaveCard_Service.HR_Leave_Reliver_SubForm[] ReLeaverForm
        {
            get { return txtReLeaverForm; }
            set { txtReLeaverForm = value; }
        }


        public string LeaveNumber
	    {
		    get { return txtLeaveNo; }
		    set { txtLeaveNo = value; }
	    }

	    public string UserName
	    {
		    get { return txtUserName; }
		    set { txtUserName = value; }
	    }

	    public string Password
	    {
		    get { return txtpassword; }
		    set { txtpassword = value; }
	    }

	    public string Leave_Type
	    {
		    get { return txtLeaveType; }
		    set { txtLeaveType = value; }
	    }

	    public string Responsibility_Center
	    {
		    get { return txtResponsibility_Center; }
		    set { txtResponsibility_Center = value; }
	    }

	    public string Reliever
	    {
		    get { return txtReliever; }
		    set { txtReliever = value; }
	    }

	    public DateTime Application_Date
	    {
		    get { return dteApplication_Date; }
		    set { dteApplication_Date = value; }
	    }


	    public string Employee_No
	    {
		    get { return txtEmployee_No; }
		    set { txtEmployee_No = value; }
	    }
	    public string Leave_Period
	    {
		    get { return txtLeave_Period; }
		    set { txtLeave_Period = value; }
	    }
	    public DateTime Start_Date
	    {
		    get { return dteStart_Date; }
		    set { dteStart_Date = value; }
	    }

	    public int Days_Applied
	    {
		    get { return intLeaveDays; }
		    set { intLeaveDays = value; }
	    }

	    
    }

    public class CanteenApplication
    {
        String txtRequestType;
        String txtEmployee_No;
        String txtDeptCode;
        Decimal numAmount;
        DateTime dteApplication_Date;
        String txtResponsibility_Center;

        string txtDepartment_Name;
        string txtEmployee_Name;
        DateTime txtPayroll_Period;
        DateTime dteStart_Date;

        string txtStatus;
        string txtTicket_No;
        string txtTransaction_Code;
        string txtTransaction_Name;
        string txtVisitor_Name;

        public string Visitor_Name
        {
            get { return txtVisitor_Name; }
            set { txtVisitor_Name = value; }
        }

        public string Transaction_Name
        {
            get { return txtTransaction_Name; }
            set { txtTransaction_Name = value; }
        }

        public string Transaction_Code
        {
            get { return txtTransaction_Code; }
            set { txtTransaction_Code = value; }
        }

        public string Ticket_No
        {
            get { return txtTicket_No; }
            set { txtTicket_No = value; }
        }

        public string Status
        {
            get { return txtStatus; }
            set { txtStatus = value; }
        }

        public DateTime StartDate
        {
            get { return dteStart_Date; }
            set { dteStart_Date = value; }
        }

        public DateTime PayrollPeriod
        {
            get { return txtPayroll_Period; }
            set { txtPayroll_Period = value; }
        }

        public string EmployeeName
        {
            get { return txtEmployee_Name; }
            set { txtEmployee_Name = value; }
        }

        public string DepartmentName
        {
            get { return txtDepartment_Name; }
            set { txtDepartment_Name = value; }
        }

        public string RequestType
        {
            get { return txtRequestType; }
            set { txtRequestType = value; }
        }

        public string EmployeeNo
        {
            get { return txtEmployee_No; }
            set { txtEmployee_No = value; }
        }

        public string DepartmentCode
        {
            get { return txtDeptCode; }
            set { txtDeptCode = value; }
        }

        public Decimal Amount
        {
            get { return numAmount; }
            set { numAmount = value; }
        }

        public string Responsibility_Center
        {
            get { return txtResponsibility_Center; }
            set { txtResponsibility_Center = value; }
        }

        public DateTime ApplicationDate
        {
            get { return dteApplication_Date; }
            set { dteApplication_Date = value; }
        }

    }

    public class AppraisalRequest
    {
        List<SelfEvaluationList> lstSelfEvaluations;
        HR_AppraisalH_Service.Appraisal_Half txtAppraisal_Half;
        String txtAppraisal_No;
        String txtAppraisal_Period;
        String txtAppraisal_Type;
        DateTime dteAppraisal_Date;
        String txtContract_Type;
        string txtCurrent_Location;
        string txtDepartment_Name;
        string txtDeptCode;
        string Desired_Department;
        string txtEmployee_Name;
        string txtEmployee_No;
        string txtStatus;
        string txtResponsibility_Center;
        string txtExceptionMessage;
        string txtJobTitle;
        

        string txtEmployeeComment;
        string txtHODComment;
        string txtSupervisorComment;
        string txtMDComment;

        string txtKey;

        DateTime dteDate_Of_Last_Promotion_Notch;

        public List<SelfEvaluationList> SelfEvaluations
        {
            get { return lstSelfEvaluations; }
            set { lstSelfEvaluations = value; }
        }

        public string Key
        {
            get { return txtKey; }
            set { txtKey = value; }
        }

        public string EmployeeComment
        {
            get { return txtEmployeeComment; }
            set { txtEmployeeComment = value; }
        }

        public string HODComment
        {
            get { return txtHODComment; }
            set { txtHODComment = value; }
        }

        public string SupervisorComment
        {
            get { return txtSupervisorComment; }
            set { txtSupervisorComment = value; }
        }

        public string MDComment
        {
            get { return txtMDComment; }
            set { txtMDComment = value; }
        }

        public string EmployeeName
        {
            get { return txtEmployee_Name; }
            set { txtEmployee_Name = value; }
        }

        public string JobTitle
        {
            get { return txtJobTitle; }
            set { txtJobTitle = value; }
        }

        public string ExceptionMessage
        {
            get { return txtExceptionMessage; }
            set { txtExceptionMessage = value; }
        }

        public HR_AppraisalH_Service.Appraisal_Half Appraisal_Half
        {
            get { return txtAppraisal_Half; }
            set { txtAppraisal_Half = value; }
        }

        public string Appraisal_No
        {
            get { return txtAppraisal_No; }
            set { txtAppraisal_No = value; }
        }

        public string Appraisal_Period
        {
            get { return txtAppraisal_Period; }
            set { txtAppraisal_Period = value; }
        }

        public string Appraisal_Type
        {
            get { return txtAppraisal_Type; }
            set { txtAppraisal_Type = value; }
        }

        public string Status
        {
            get { return txtStatus; }
            set { txtStatus = value; }
        }

        public DateTime Appraisal_Date
        {
            get { return dteAppraisal_Date; }
            set { dteAppraisal_Date = value; }
        }

        public DateTime Date_Of_Last_Promotion_Notch
        {
            get { return dteDate_Of_Last_Promotion_Notch; }
            set { dteDate_Of_Last_Promotion_Notch = value; }
        }


        public string Contract_Type
        {
            get { return txtContract_Type; }
            set { txtContract_Type = value; }
        }

        public string DepartmentName
        {
            get { return txtDepartment_Name; }
            set { txtDepartment_Name = value; }
        }

        public string EmployeeNo
        {
            get { return txtEmployee_No; }
            set { txtEmployee_No = value; }
        }

        public string DepartmentCode
        {
            get { return txtDeptCode; }
            set { txtDeptCode = value; }
        }

        public string Current_Location
        {
            get { return txtCurrent_Location; }
            set { txtCurrent_Location = value; }
        }

        public string Responsibility_Center
        {
            get { return txtResponsibility_Center; }
            set { txtResponsibility_Center = value; }
        }

    }


    public class SelfEvaluationList
    {

        
        String txtAppraisal_No;
        String txtAppraisal_Period;
        String txtDescription;
        String txtKey;
        String txtSelfEvaluation;

        public string SelfEvaluation
        {
            get { return txtSelfEvaluation; }
            set { txtSelfEvaluation = value; }
        }

        public string Key
        {
            get { return txtKey; }
            set { txtKey = value; }
        }


        public string Appraisal_No
        {
            get { return txtAppraisal_No; }
            set { txtAppraisal_No = value; }
        }

        public string Appraisal_Period
        {
            get { return txtAppraisal_Period; }
            set { txtAppraisal_Period = value; }
        }

        public string Description
        {
            get { return txtDescription; }
            set { txtDescription = value; }
        }

     


    }


    public class Behavoural
    {

        String txtAppraisal_No;
        String txtTargetObjective;
        String txtDescription;
        String txtTiming;
        String txtKey;
        String txtAppraisalPeriod;
        int txtAppraisalHalf;
        decimal txtWeight;
        decimal txtActualResult;
        decimal txtAgreedScore;
        string txtRatings;
        decimal txtScore;
        decimal txtSupervisor_Score;

        public string AppraisalPeriod
        {
            get { return txtAppraisalPeriod; }
            set { txtAppraisalPeriod = value; }
        }

        public int AppraisalHalf
        {
            get { return txtAppraisalHalf; }
            set { txtAppraisalHalf = value; }
        }

        public decimal Supervisor_Score
        {
            get { return txtSupervisor_Score; }
            set { txtSupervisor_Score = value; }
        }

        public decimal Score
        {
            get { return txtScore; }
            set { txtScore = value; }
        }

        public string Ratings
        {
            get { return txtRatings; }
            set { txtRatings = value; }
        }

        public string Key
        {
            get { return txtKey; }
            set { txtKey = value; }
        }

        public string Appraisal_No
        {
            get { return txtAppraisal_No; }
            set { txtAppraisal_No = value; }
        }

        public string TargetObjective
        {
            get { return txtTargetObjective; }
            set { txtTargetObjective = value; }
        }

        public string Description
        {
            get { return txtDescription; }
            set { txtDescription = value; }
        }

        public string Timing
        {
            get { return txtTiming; }
            set { txtTiming = value; }
        }

        public decimal Weight
        {
            get { return txtWeight; }
            set { txtWeight = value; }
        }

        public decimal ActualResult
        {
            get { return txtActualResult; }
            set { txtActualResult = value; }
        }

        public decimal AgreedScore
        {
            get { return txtAgreedScore; }
            set { txtAgreedScore = value; }
        }




    }

    public class SelfEvaluation
    {


        String txtAppraisal_No;
        String txtDescription;
        String txtSelf_Evaluation;
        String txtSelf_EvaluationKey;
        int txtSelf_LineNo;
        String txtException_Message;


        public int LineNo
        {
            get { return txtSelf_LineNo; }
            set { txtSelf_LineNo = value; }
        }

        public string Exception_Message
        {
            get { return txtException_Message; }
            set { txtException_Message = value; }
        }
        public string Key
        {
            get { return txtSelf_EvaluationKey; }
            set { txtSelf_EvaluationKey = value; }
        }

        public string Appraisal_No
        {
            get { return txtAppraisal_No; }
            set { txtAppraisal_No = value; }
        }

        public string Self_Evaluation
        {
            get { return txtSelf_Evaluation; }
            set { txtSelf_Evaluation = value; }
        }

        public string Description
        {
            get { return txtDescription; }
            set { txtDescription = value; }
        }




    }





    public class RetirementLine{

        public Decimal AmountSpent { get; set; }
        public int LineNo { get; set; }
        public String SurrenderDocNo { get; set; }

    }


    public class CareerDevelopmentQuestion
    {

        public string AppraisalNo { get; set; }
        public string Key { get; set; }
        public String Question { get; set; }
        public String Answer { get; set; }
        public String Exceptions { get; set; }

    }


    public class StaffClaim
    {
        String txtAccount_No;
        String txtBudget_Center_Name;
        String txtCashier;
        Decimal numTotalNetAmount;
        DateTime dteApplication_Date;
        String txtDocumentNo;
        String txtPaye;
        String txtFunctionName;
        String txtPurpose;
        String txtStatus;
        String txtResponsibility_Center;
        String txtBankName;
        String txtBankAccountNo;

        NAV_HR_WINDOW.StaffClaim_Service.Staff_Claim_Lines[] objPVLines;

        
        public  NAV_HR_WINDOW.StaffClaim_Service.Staff_Claim_Lines[] PVLines
        {
            get { return objPVLines; }
            set { objPVLines = value; }
        }

        public string BankAccountNo
        {
            get { return txtBankAccountNo; }
            set { txtBankAccountNo = value; }
        }

        public string BankName
        {
            get { return txtBankName; }
            set { txtBankName = value; }
        }

        public string AccountNo
        {
            get { return txtAccount_No; }
            set { txtAccount_No = value; }
        }

        public string BudgetCenterName
        {
            get { return txtBudget_Center_Name; }
            set { txtBudget_Center_Name = value; }
        }

        public string Cashier
        {
            get { return txtCashier; }
            set { txtCashier = value; }
        }

        public Decimal TotalNetAmount
        {
            get { return numTotalNetAmount; }
            set { numTotalNetAmount = value; }
        }

        public string Status
        {
            get { return txtStatus; }
            set { txtStatus = value; }
        }

        public string Purpose
        {
            get { return txtPurpose; }
            set { txtPurpose = value; }
        }

        public string FunctionName
        {
            get { return txtFunctionName; }
            set { txtFunctionName = value; }
        }

        public string Paye
        {
            get { return txtPaye; }
            set { txtPaye = value; }
        }

        public string DocumentNo
        {
            get { return txtDocumentNo; }
            set { txtDocumentNo = value; }
        }

        public string Responsibility_Center
        {
            get { return txtResponsibility_Center; }
            set { txtResponsibility_Center = value; }
        }

        public DateTime ClaimDate
        {
            get { return dteApplication_Date; }
            set { dteApplication_Date = value; }
        }

    }
    
    public class StoreRequisition
    {
        String txtBudget_Center_Name;
        
        DateTime dteRequest_Date;
        DateTime dteRequire_Date;
        String txtDocumentNo;
        String txtFunctionName;
        String txtStatus;
        String txtRequestDescription;
        String txtResponsibility_Center;
        String txtUserID;
        String txtLocation;
        String txtBusinessUnit;
        String txtIssueingStore;

        NAV_HR_WINDOW.StoreRequisition_Service.Store_Requisition_Line[] storeReqLines;

        public NAV_HR_WINDOW.StoreRequisition_Service.Store_Requisition_Line[] StoreRequisitionLines
        {
            get { return storeReqLines; }
            set { storeReqLines = value; }
        }

        public string IssueingStore
        {
            get { return txtIssueingStore; }
            set { txtIssueingStore = value; }
        }

        public string Location
        {
            get { return txtLocation; }
            set { txtLocation = value; }
        }
        public string BusinessUnit
        {
            get { return txtBusinessUnit; }
            set { txtBusinessUnit = value; }
        }

        public string UserID
        {
            get { return txtUserID; }
            set { txtUserID = value; }
        }

        

        public string RequestDescription
        {
            get { return txtRequestDescription; }
            set { txtRequestDescription = value; }
        }


        public string BudgetCenterName
        {
            get { return txtBudget_Center_Name; }
            set { txtBudget_Center_Name = value; }
        }

        public string Status
        {
            get { return txtStatus; }
            set { txtStatus = value; }
        }

       

        public string FunctionName
        {
            get { return txtFunctionName; }
            set { txtFunctionName = value; }
        }

       

        public string DocumentNo
        {
            get { return txtDocumentNo; }
            set { txtDocumentNo = value; }
        }

        public string Responsibility_Center
        {
            get { return txtResponsibility_Center; }
            set { txtResponsibility_Center = value; }
        }

        public DateTime Request_Date
        {
            get { return dteRequest_Date; }
            set { dteRequest_Date = value; }
        }

        public DateTime Require_Date
        {
            get { return dteRequire_Date; }
            set { dteRequire_Date = value; }
        }

    }


    public class PaymentRequest
    {
        string txtBank_Name;
        string txtBudget_Center_Name;
        string txtCashier;
        string txtCheque_No;
        string txtCheque_Type;
        DateTime dteDate;
        string txtFunction_Name;
        string txtNo;
        string txtOn_Behalf_Of;
        string txtPayee;
        string txtPayee_Account_Number;
        string txtPaying_Bank_Account;
        string txtPayment_Narration;
        DateTime dtePayment_Release_Date;
        string txtPay_Mode;
        string txtResponsibility_Center;
        string txtStatus;
        string txtLocation;
        string txtBusinessUnit;
        decimal numTotal_Payment_Amount;
        decimal numTotal_Payment_Amount_LCY;
        decimal numTotal_Retention_Amount;
        decimal numTotal_VAT_Amount;
        decimal numTotal_Witholding_Tax_Amount;
        decimal numTotal_Payment_Amount_Total_Witholding_Tax_Amount__Total_VAT_Amount__Total_Retention_Amount;
        NAV_HR_WINDOW.PaymentRequest_Service.Payment_Request_Lines[] paymentReqLines;
        string txtSS_UserID;


        public NAV_HR_WINDOW.PaymentRequest_Service.Payment_Request_Lines[] PaymentRequisitionLines
        {
            get { return paymentReqLines; }
            set { paymentReqLines = value; }
        }

        public string Bank_Name
        {
            get { return txtBank_Name; }
            set { txtBank_Name = value; }
        }

        public string Location
        {
            get { return txtLocation; }
            set { txtLocation = value; }
        }

        public string Bussiness_Unit
        {
            get { return txtBusinessUnit; }
            set { txtBusinessUnit = value; }
        }


        public string SS_UserID
        {
            get { return txtSS_UserID; }
            set { txtSS_UserID = value; }
        }

        public string Budget_Center_Name
        {
            get { return txtBudget_Center_Name; }
            set { txtBudget_Center_Name = value; }
        }

        public string Cashier
        {
            get { return txtCashier; }
            set { txtCashier = value; }
        }

        public string Cheque_No
        {
            get { return txtCheque_No; }
            set { txtCheque_No = value; }
        }

        public string Cheque_Type
        {
            get { return txtCheque_Type; }
            set { txtCheque_Type = value; }
        }
        public DateTime RequestDate
        {
            get { return dteDate; }
            set { dteDate = value; }
        }

        public string Function_Name
        {
            get { return txtFunction_Name; }
            set { txtFunction_Name = value; }
        }

        public string DocumentNo
        {
            get { return txtNo; }
            set { txtNo = value; }
        }

        public string On_Behalf_Of
        {
            get { return txtOn_Behalf_Of; }
            set { txtOn_Behalf_Of = value; }
        }

        public string Payee
        {
            get { return txtPayee; }
            set { txtPayee = value; }
        }

        public string Payee_Account_Number
        {
            get { return txtPayee_Account_Number; }
            set { txtPayee_Account_Number = value; }
        }

        public string Paying_Bank_Account
        {
            get { return txtPaying_Bank_Account; }
            set { txtPaying_Bank_Account = value; }
        }

        public string Payment_Narration
        {
            get { return txtPayment_Narration; }
            set { txtPayment_Narration = value; }
        }
        public DateTime Payment_Release_Date
        {
            get { return dtePayment_Release_Date; }
            set { dtePayment_Release_Date = value; }
        }

        public string Pay_Mode
        {
            get { return txtPay_Mode; }
            set { txtPay_Mode = value; }
        }

        public string  Status
        {
            get { return txtStatus; }
            set { txtStatus = value; }
        }

        public decimal Total_Payment_Amount
        {
            get { return numTotal_Payment_Amount; }
            set { numTotal_Payment_Amount = value; }
        }

        public decimal Total_Payment_Amount_Total_Witholding_Tax_Amount__Total_VAT_Amount__Total_Retention_Amount
        {
            get { return numTotal_Payment_Amount_Total_Witholding_Tax_Amount__Total_VAT_Amount__Total_Retention_Amount; }
            set { numTotal_Payment_Amount_Total_Witholding_Tax_Amount__Total_VAT_Amount__Total_Retention_Amount = value; }
        }

        public decimal Total_Witholding_Tax_Amount
        {
            get { return numTotal_Witholding_Tax_Amount; }
            set { numTotal_Witholding_Tax_Amount = value; }
        }

        public decimal Total_VAT_Amount
        {
            get { return numTotal_VAT_Amount; }
            set { numTotal_VAT_Amount = value; }
        }

        public decimal Total_Retention_Amount
        {
            get { return numTotal_Retention_Amount; }
            set { numTotal_Retention_Amount = value; }
        }

        public decimal Total_Payment_Amount_LCY
        {
            get { return numTotal_Payment_Amount_LCY; }
            set { numTotal_Payment_Amount_LCY = value; }
        }

        public string Responsibility_Center
        {
            get { return txtResponsibility_Center; }
            set { txtResponsibility_Center = value; }
        }
    

    }

    public class CashAdvanceRequest
    {
        string txtBusinessUnit;
        string txtLocationCode;
        string txtBank_Name;
        string txtBudget_Center_Name;
        string txtCashier;
        string txtCheque_No;
        string txtCheque_Type;
        DateTime dteDate;
        string txtFunction_Name;
        string txtNo;
        string txtOn_Behalf_Of;
        string txtPayee;
        string txtPayee_Account_Number;
        string txtPaying_Bank_Account;
        string txtPayment_Narration;
        DateTime dtePayment_Release_Date;
        string txtPay_Mode;
        string txtResponsibility_Center;
        string txtStatus;
        string txtUserID;
        decimal numTotal_Payment_Amount;
        decimal numTotal_Payment_Amount_LCY;
        decimal numTotal_Retention_Amount;
        decimal numTotal_VAT_Amount;
        decimal numTotal_Witholding_Tax_Amount;
        decimal numTotal_Payment_Amount_Total_Witholding_Tax_Amount__Total_VAT_Amount__Total_Retention_Amount;
        NAV_HR_WINDOW.StaffAdvanceRequest_Service.Staff_Advance_Lines[] CashAdvReqLines;



        public NAV_HR_WINDOW.StaffAdvanceRequest_Service.Staff_Advance_Lines[] CashAdvanceRequestLines
        {
            get { return CashAdvReqLines; }
            set { CashAdvReqLines = value; }
        }

        public string UserID
        {
            get { return txtUserID; }
            set { txtUserID = value; }
        }

        public string BusinessUnit
        {
            get { return txtBusinessUnit; }
            set { txtBusinessUnit = value; }
        }

        public string LocationCode
        {
            get { return txtLocationCode; }
            set { txtLocationCode = value; }
        }

        public string Bank_Name
        {
            get { return txtBank_Name; }
            set { txtBank_Name = value; }
        }

        public string Budget_Center_Name
        {
            get { return txtBudget_Center_Name; }
            set { txtBudget_Center_Name = value; }
        }

        public string Cashier
        {
            get { return txtCashier; }
            set { txtCashier = value; }
        }

        public string Cheque_No
        {
            get { return txtCheque_No; }
            set { txtCheque_No = value; }
        }

        public string Cheque_Type
        {
            get { return txtCheque_Type; }
            set { txtCheque_Type = value; }
        }
        public DateTime RequestDate
        {
            get { return dteDate; }
            set { dteDate = value; }
        }

        public string Function_Name
        {
            get { return txtFunction_Name; }
            set { txtFunction_Name = value; }
        }

        public string DocumentNo
        {
            get { return txtNo; }
            set { txtNo = value; }
        }

        public string On_Behalf_Of
        {
            get { return txtOn_Behalf_Of; }
            set { txtOn_Behalf_Of = value; }
        }

        public string Payee
        {
            get { return txtPayee; }
            set { txtPayee = value; }
        }

        public string Payee_Account_Number
        {
            get { return txtPayee_Account_Number; }
            set { txtPayee_Account_Number = value; }
        }

        public string Paying_Bank_Account
        {
            get { return txtPaying_Bank_Account; }
            set { txtPaying_Bank_Account = value; }
        }

        public string Payment_Narration
        {
            get { return txtPayment_Narration; }
            set { txtPayment_Narration = value; }
        }
        public DateTime Payment_Release_Date
        {
            get { return dtePayment_Release_Date; }
            set { dtePayment_Release_Date = value; }
        }

        public string Pay_Mode
        {
            get { return txtPay_Mode; }
            set { txtPay_Mode = value; }
        }

        public string Status
        {
            get { return txtStatus; }
            set { txtStatus = value; }
        }

        public decimal Total_Payment_Amount
        {
            get { return numTotal_Payment_Amount; }
            set { numTotal_Payment_Amount = value; }
        }

        public decimal Total_Payment_Amount_Total_Witholding_Tax_Amount__Total_VAT_Amount__Total_Retention_Amount
        {
            get { return numTotal_Payment_Amount_Total_Witholding_Tax_Amount__Total_VAT_Amount__Total_Retention_Amount; }
            set { numTotal_Payment_Amount_Total_Witholding_Tax_Amount__Total_VAT_Amount__Total_Retention_Amount = value; }
        }

        public decimal Total_Witholding_Tax_Amount
        {
            get { return numTotal_Witholding_Tax_Amount; }
            set { numTotal_Witholding_Tax_Amount = value; }
        }

        public decimal Total_VAT_Amount
        {
            get { return numTotal_VAT_Amount; }
            set { numTotal_VAT_Amount = value; }
        }

        public decimal Total_Retention_Amount
        {
            get { return numTotal_Retention_Amount; }
            set { numTotal_Retention_Amount = value; }
        }

        public decimal Total_Payment_Amount_LCY
        {
            get { return numTotal_Payment_Amount_LCY; }
            set { numTotal_Payment_Amount_LCY = value; }
        }

        public string Responsibility_Center
        {
            get { return txtResponsibility_Center; }
            set { txtResponsibility_Center = value; }
        }


    }


    public class WorkRetirement
    {

        string txtBank_Code;
        string txtCashier;
        string txtCheque_No;
        string txtNo;
        string txtImprest_Issue_Doc_No;
        DateTime dteChequeDate;
        DateTime dteImprest_Issue_Date;
        DateTime dteSurrender_Date;
        string txtPay_Mode;
        string txtStatus;
        string txtDescription2;
        string txtResponsibility_Center;
        string txtUserID;

        NAV_HR_WINDOW.WorkRetirement_Service.Staff_Advanc_Surrender_Details[] _WorkAdvanceLines;

        public NAV_HR_WINDOW.WorkRetirement_Service.Staff_Advanc_Surrender_Details[] WorkAdvanceLines
        {
            get { return _WorkAdvanceLines; }
            set { _WorkAdvanceLines = value; }
        }

        public string UserID
        {
            get { return txtUserID; }
            set { txtUserID = value; }
        }

        public string Description2
        {
            get { return txtDescription2; }
            set { txtDescription2 = value; }
        }

        public string Bank_Code
        {
            get { return txtBank_Code; }
            set { txtBank_Code = value; }
        }

        public string Imprest_Issue_Doc_No
        {
            get { return txtImprest_Issue_Doc_No; }
            set { txtImprest_Issue_Doc_No = value; }
        }

        public string Cashier
        {
            get { return txtCashier; }
            set { txtCashier = value; }
        }

        public string Cheque_No
        {
            get { return txtCheque_No; }
            set { txtCheque_No = value; }
        }

        public DateTime Imprest_Issue_Date
        {
            get { return dteImprest_Issue_Date; }
            set { dteImprest_Issue_Date = value; }
        }

        public DateTime Surrender_Date
        {
            get { return dteSurrender_Date; }
            set { dteSurrender_Date = value; }
        }
        public DateTime ChequeDate
        {
            get { return dteChequeDate; }
            set { dteChequeDate = value; }
        }

        

        public string DocumentNo
        {
            get { return txtNo; }
            set { txtNo = value; }
        }

        public string Pay_Mode
        {
            get { return txtPay_Mode; }
            set { txtPay_Mode = value; }
        }

        public string Status
        {
            get { return txtStatus; }
            set { txtStatus = value; }
        }

             public string Responsibility_Center
        {
            get { return txtResponsibility_Center; }
            set { txtResponsibility_Center = value; }
        }


    }


    public class ConfirmationProbation
    {

        string txtApplicationNo;
        string txtComment;
        DateTime dteEmploymentDate;
        DateTime dteReviewDate;
        string txtDepartment;
        string txtDevelopmentAreas;
        string txtEmployeeComment;
        string txtEmployeeName;
        string txtEmployeeNo;
        DateTime dteEnd_Date;
        DateTime dteStart_Date;
        string txtAppraisalType;
        decimal txtKPI_Score;
        string txtLevel;
        string txtResponsibility_Center;
        decimal txtScore;
        string txtSecond_Line_Supervisor;
        string txtSecond_Line_Supervisor_Comment;
        string txtStatus;
        string txtSupervisor;
        string txtTraining_Ideas;
        string txtUser_ID;

        NAV_HR_WINDOW.ProbationConfirmationCard_Service.HR_Confirmation_KPI_A[] _hr_Confirmation_kpi_a;
        NAV_HR_WINDOW.ProbationConfirmationCard_Service.HR_Confirmation_KPI_C[] _hr_Confirmation_kpi_c;
        NAV_HR_WINDOW.ProbationConfirmationCard_Service.HR_Confirmation_KPI_D[] _hr_Confirmation_kpi_d;
        NAV_HR_WINDOW.ProbationConfirmationCard_Service.HR_KPI_Confirmation_B[] _hr_Confirmation_kpi_b;
        NAV_HR_WINDOW.ProbationConfirmationCard_Service.HR_Confirmation_Lines[] _HR_Confirmation_Lines;

        public NAV_HR_WINDOW.ProbationConfirmationCard_Service.HR_Confirmation_KPI_D[] HR_CONFIRMATION_KPI_D
        {
            get { return _hr_Confirmation_kpi_d; }
            set { _hr_Confirmation_kpi_d = value; }
        }

        public NAV_HR_WINDOW.ProbationConfirmationCard_Service.HR_Confirmation_KPI_C[] HR_CONFIRMATION_KPI_C
        {
            get { return _hr_Confirmation_kpi_c; }
            set { _hr_Confirmation_kpi_c = value; }
        }

        public NAV_HR_WINDOW.ProbationConfirmationCard_Service.HR_KPI_Confirmation_B[] HR_CONFIRMATION_KPI_B
        {
            get { return _hr_Confirmation_kpi_b; }
            set { _hr_Confirmation_kpi_b = value; }
        }

        public NAV_HR_WINDOW.ProbationConfirmationCard_Service.HR_Confirmation_KPI_A[] HR_CONFIRMATION_KPI_A
        {
            get { return _hr_Confirmation_kpi_a; }
            set { _hr_Confirmation_kpi_a = value; }
        }

        public NAV_HR_WINDOW.ProbationConfirmationCard_Service.HR_Confirmation_Lines[] HR_Confirmation_Lines
        {
            get { return _HR_Confirmation_Lines; }
            set { _HR_Confirmation_Lines = value; }
        }
        

        public string Status
        {
            get { return txtStatus; }
            set { txtStatus = value; }
        }

        public string User_ID
        {
            get { return txtUser_ID; }
            set { txtUser_ID = value; }
        }

        public string Training_Ideas
        {
            get { return txtTraining_Ideas; }
            set { txtTraining_Ideas = value; }
        }

        public string Supervisor
        {
            get { return txtSupervisor; }
            set { txtSupervisor = value; }
        }

        public string Second_Line_Supervisor_Comment
        {
            get { return txtSecond_Line_Supervisor_Comment; }
            set { txtSecond_Line_Supervisor_Comment = value; }
        }

        public string Second_Line_Supervisor
        {
            get { return txtSecond_Line_Supervisor; }
            set { txtSecond_Line_Supervisor = value; }
        }

        public decimal Score
        {
            get { return txtScore; }
            set { txtScore = value; }
        }

        public string Responsibility_Center
        {
            get { return txtResponsibility_Center; }
            set { txtResponsibility_Center = value; }
        }
        public string Level
        {
            get { return txtLevel; }
            set { txtLevel = value; }
        }



        public decimal KPI_Score
        {
            get { return txtKPI_Score; }
            set { txtKPI_Score = value; }
        }

        public string AppraisalType
        {
            get { return txtAppraisalType; }
            set { txtAppraisalType = value; }
        }

        public DateTime StartDate
        {
            get { return dteStart_Date; }
            set { dteStart_Date = value; }
        }

        public DateTime EndDate
        {
            get { return dteEnd_Date; }
            set { dteEnd_Date = value; }
        }
            
       
        public string EmployeeNo
        {
            get { return txtEmployeeNo; }
            set { txtEmployeeNo = value; }
        }

        public string ApplicationNo
        {
            get { return txtApplicationNo; }
            set { txtApplicationNo = value; }
        }

        public string Comment
        {
            get { return txtComment; }
            set { txtComment = value; }
        }

        public DateTime EmploymentDate
        {
            get { return dteEmploymentDate; }
            set { dteEmploymentDate = value; }
        }

        public DateTime ReviewDate
        {
            get { return dteReviewDate; }
            set { dteReviewDate = value; }
        }

        public string Department
        {
            get { return txtDepartment; }
            set { txtDepartment = value; }
        }

        public string EmployeeName
        {
            get { return txtEmployeeName; }
            set { txtEmployeeName = value; }
        }

        public string EmployeeComment
        {
            get { return txtEmployeeComment; }
            set { txtEmployeeComment = value; }
        }

        public string DevelopmentAreas
        {
            get { return txtDevelopmentAreas; }
            set { txtDevelopmentAreas = value; }
        }
    }

}


