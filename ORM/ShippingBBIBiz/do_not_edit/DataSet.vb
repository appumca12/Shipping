
Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Runtime.Serialization
Imports OrmLib

namespace ShippingBiz
		public class OrmDataSet
		
		private Sub New()
		End Sub
		
		public Shared Function NewDataSet() As DataSet
			
            Dim ds As DataSet = New DataSet("OrmDataSet")
			
			InitDb(ds)

			ds.EnforceConstraints = true
			ds.CaseSensitive = false
			
			NewDataSet = ds
			
		End Function
		
		
		private Shared Sub InitDb(ByRef ds As DataSet)
		
			
			Dim sysdiagramsTable as DataTable = ds.Tables.Add("sysdiagrams")
			sysdiagramsTable.Columns.Add("name", GetType(System.String))
			sysdiagramsTable.Columns("name").AllowDBNull = false
			sysdiagramsTable.Columns("name").ReadOnly = false
			
			sysdiagramsTable.Columns("name").MaxLength = 256

			sysdiagramsTable.Columns.Add("principal_id", GetType(System.Int32))
			sysdiagramsTable.Columns("principal_id").AllowDBNull = false
			sysdiagramsTable.Columns("principal_id").ReadOnly = false
			
			sysdiagramsTable.Columns.Add("diagram_id", GetType(System.Int32))
			sysdiagramsTable.Columns("diagram_id").AllowDBNull = false
			sysdiagramsTable.Columns("diagram_id").ReadOnly = false
			
			sysdiagramsTable.Columns.Add("version", GetType(System.Int32))
			sysdiagramsTable.Columns("version").AllowDBNull = true
			sysdiagramsTable.Columns("version").ReadOnly = false
			
			sysdiagramsTable.Columns.Add("definition", GetType(System.Byte()))
			sysdiagramsTable.Columns("definition").AllowDBNull = true
			sysdiagramsTable.Columns("definition").ReadOnly = false
			
			sysdiagramsTable.PrimaryKey = new DataColumn(){sysdiagramsTable.Columns("diagram_id")}
			
			Dim TB_AccessLevelTable as DataTable = ds.Tables.Add("TB_AccessLevel")
			TB_AccessLevelTable.Columns.Add("ID", GetType(System.Guid))
			TB_AccessLevelTable.Columns("ID").AllowDBNull = false
			TB_AccessLevelTable.Columns("ID").ReadOnly = false
			
			TB_AccessLevelTable.Columns.Add("UserID", GetType(System.Guid))
			TB_AccessLevelTable.Columns("UserID").AllowDBNull = false
			TB_AccessLevelTable.Columns("UserID").ReadOnly = false
			
			TB_AccessLevelTable.Columns.Add("MenuItemID", GetType(System.Guid))
			TB_AccessLevelTable.Columns("MenuItemID").AllowDBNull = false
			TB_AccessLevelTable.Columns("MenuItemID").ReadOnly = false
			
			TB_AccessLevelTable.Columns.Add("Accessble", GetType(System.Boolean))
			TB_AccessLevelTable.Columns("Accessble").AllowDBNull = true
			TB_AccessLevelTable.Columns("Accessble").ReadOnly = false
			
			TB_AccessLevelTable.PrimaryKey = new DataColumn(){TB_AccessLevelTable.Columns("ID")}
			
			Dim TB_AccountTable as DataTable = ds.Tables.Add("TB_Account")
			TB_AccountTable.Columns.Add("ID", GetType(System.Guid))
			TB_AccountTable.Columns("ID").AllowDBNull = false
			TB_AccountTable.Columns("ID").ReadOnly = false
			
			TB_AccountTable.Columns.Add("Line", GetType(System.String))
			TB_AccountTable.Columns("Line").AllowDBNull = true
			TB_AccountTable.Columns("Line").ReadOnly = false
			
			TB_AccountTable.Columns("Line").MaxLength = 20

			TB_AccountTable.Columns.Add("ChargeCode", GetType(System.String))
			TB_AccountTable.Columns("ChargeCode").AllowDBNull = true
			TB_AccountTable.Columns("ChargeCode").ReadOnly = false
			
			TB_AccountTable.Columns("ChargeCode").MaxLength = 20

			TB_AccountTable.Columns.Add("Level1", GetType(System.String))
			TB_AccountTable.Columns("Level1").AllowDBNull = true
			TB_AccountTable.Columns("Level1").ReadOnly = false
			
			TB_AccountTable.Columns("Level1").MaxLength = 20

			TB_AccountTable.Columns.Add("Level2", GetType(System.String))
			TB_AccountTable.Columns("Level2").AllowDBNull = true
			TB_AccountTable.Columns("Level2").ReadOnly = false
			
			TB_AccountTable.Columns("Level2").MaxLength = 20

			TB_AccountTable.Columns.Add("Level3", GetType(System.String))
			TB_AccountTable.Columns("Level3").AllowDBNull = true
			TB_AccountTable.Columns("Level3").ReadOnly = false
			
			TB_AccountTable.Columns("Level3").MaxLength = 20

			TB_AccountTable.Columns.Add("Description", GetType(System.String))
			TB_AccountTable.Columns("Description").AllowDBNull = true
			TB_AccountTable.Columns("Description").ReadOnly = false
			
			TB_AccountTable.Columns("Description").MaxLength = 200

			TB_AccountTable.Columns.Add("Port", GetType(System.String))
			TB_AccountTable.Columns("Port").AllowDBNull = true
			TB_AccountTable.Columns("Port").ReadOnly = false
			
			TB_AccountTable.Columns("Port").MaxLength = 10

			TB_AccountTable.Columns.Add("Level4", GetType(System.String))
			TB_AccountTable.Columns("Level4").AllowDBNull = true
			TB_AccountTable.Columns("Level4").ReadOnly = false
			
			TB_AccountTable.Columns("Level4").MaxLength = 20

			TB_AccountTable.PrimaryKey = new DataColumn(){TB_AccountTable.Columns("ID")}
			
			Dim TB_AgentsTable as DataTable = ds.Tables.Add("TB_Agents")
			TB_AgentsTable.Columns.Add("ID", GetType(System.Guid))
			TB_AgentsTable.Columns("ID").AllowDBNull = false
			TB_AgentsTable.Columns("ID").ReadOnly = false
			
			TB_AgentsTable.Columns.Add("Line", GetType(System.String))
			TB_AgentsTable.Columns("Line").AllowDBNull = false
			TB_AgentsTable.Columns("Line").ReadOnly = false
			
			TB_AgentsTable.Columns("Line").MaxLength = 20

			TB_AgentsTable.Columns.Add("Port", GetType(System.String))
			TB_AgentsTable.Columns("Port").AllowDBNull = false
			TB_AgentsTable.Columns("Port").ReadOnly = false
			
			TB_AgentsTable.Columns("Port").MaxLength = 10

			TB_AgentsTable.Columns.Add("AgentName", GetType(System.String))
			TB_AgentsTable.Columns("AgentName").AllowDBNull = false
			TB_AgentsTable.Columns("AgentName").ReadOnly = false
			
			TB_AgentsTable.Columns("AgentName").MaxLength = 1000

			TB_AgentsTable.Columns.Add("Address", GetType(System.String))
			TB_AgentsTable.Columns("Address").AllowDBNull = false
			TB_AgentsTable.Columns("Address").ReadOnly = false
			
			TB_AgentsTable.Columns("Address").MaxLength = 1000

			TB_AgentsTable.Columns.Add("Tel", GetType(System.String))
			TB_AgentsTable.Columns("Tel").AllowDBNull = true
			TB_AgentsTable.Columns("Tel").ReadOnly = false
			
			TB_AgentsTable.Columns("Tel").MaxLength = 40

			TB_AgentsTable.Columns.Add("Fax", GetType(System.String))
			TB_AgentsTable.Columns("Fax").AllowDBNull = true
			TB_AgentsTable.Columns("Fax").ReadOnly = false
			
			TB_AgentsTable.Columns("Fax").MaxLength = 40

			TB_AgentsTable.Columns.Add("Code", GetType(System.String))
			TB_AgentsTable.Columns("Code").AllowDBNull = true
			TB_AgentsTable.Columns("Code").ReadOnly = false
			
			TB_AgentsTable.Columns("Code").MaxLength = 20

			TB_AgentsTable.Columns.Add("DetentionClause", GetType(System.String))
			TB_AgentsTable.Columns("DetentionClause").AllowDBNull = true
			TB_AgentsTable.Columns("DetentionClause").ReadOnly = false
			
			TB_AgentsTable.PrimaryKey = new DataColumn(){TB_AgentsTable.Columns("ID")}
			
			Dim TB_AUTAdditionalDocsTable as DataTable = ds.Tables.Add("TB_AUTAdditionalDocs")
			TB_AUTAdditionalDocsTable.Columns.Add("ID", GetType(System.Guid))
			TB_AUTAdditionalDocsTable.Columns("ID").AllowDBNull = false
			TB_AUTAdditionalDocsTable.Columns("ID").ReadOnly = false
			
			TB_AUTAdditionalDocsTable.Columns.Add("JobCode", GetType(System.String))
			TB_AUTAdditionalDocsTable.Columns("JobCode").AllowDBNull = false
			TB_AUTAdditionalDocsTable.Columns("JobCode").ReadOnly = false
			
			TB_AUTAdditionalDocsTable.Columns("JobCode").MaxLength = 10

			TB_AUTAdditionalDocsTable.Columns.Add("Seq", GetType(System.Byte))
			TB_AUTAdditionalDocsTable.Columns("Seq").AllowDBNull = false
			TB_AUTAdditionalDocsTable.Columns("Seq").ReadOnly = false
			
			TB_AUTAdditionalDocsTable.Columns.Add("HtmlContent", GetType(System.String))
			TB_AUTAdditionalDocsTable.Columns("HtmlContent").AllowDBNull = false
			TB_AUTAdditionalDocsTable.Columns("HtmlContent").ReadOnly = false
			
			TB_AUTAdditionalDocsTable.PrimaryKey = new DataColumn(){TB_AUTAdditionalDocsTable.Columns("ID")}
			
			Dim TB_AUTDummyTable as DataTable = ds.Tables.Add("TB_AUTDummy")
			TB_AUTDummyTable.Columns.Add("ID", GetType(System.Guid))
			TB_AUTDummyTable.Columns("ID").AllowDBNull = false
			TB_AUTDummyTable.Columns("ID").ReadOnly = false
			
			TB_AUTDummyTable.Columns.Add("JobCode", GetType(System.String))
			TB_AUTDummyTable.Columns("JobCode").AllowDBNull = true
			TB_AUTDummyTable.Columns("JobCode").ReadOnly = false
			
			TB_AUTDummyTable.Columns("JobCode").MaxLength = 2

			TB_AUTDummyTable.Columns.Add("RequestBy", GetType(System.String))
			TB_AUTDummyTable.Columns("RequestBy").AllowDBNull = true
			TB_AUTDummyTable.Columns("RequestBy").ReadOnly = false
			
			TB_AUTDummyTable.Columns("RequestBy").MaxLength = 10

			TB_AUTDummyTable.Columns.Add("Remarks", GetType(System.String))
			TB_AUTDummyTable.Columns("Remarks").AllowDBNull = true
			TB_AUTDummyTable.Columns("Remarks").ReadOnly = false
			
			TB_AUTDummyTable.Columns("Remarks").MaxLength = 1000

			TB_AUTDummyTable.Columns.Add("Result", GetType(System.Int32))
			TB_AUTDummyTable.Columns("Result").AllowDBNull = true
			TB_AUTDummyTable.Columns("Result").ReadOnly = false
			
			TB_AUTDummyTable.Columns.Add("ErrMsg", GetType(System.String))
			TB_AUTDummyTable.Columns("ErrMsg").AllowDBNull = true
			TB_AUTDummyTable.Columns("ErrMsg").ReadOnly = false
			
			TB_AUTDummyTable.Columns("ErrMsg").MaxLength = 1000

			TB_AUTDummyTable.Columns.Add("VoyageID", GetType(System.Guid))
			TB_AUTDummyTable.Columns("VoyageID").AllowDBNull = true
			TB_AUTDummyTable.Columns("VoyageID").ReadOnly = false
			
			TB_AUTDummyTable.Columns.Add("Port", GetType(System.String))
			TB_AUTDummyTable.Columns("Port").AllowDBNull = true
			TB_AUTDummyTable.Columns("Port").ReadOnly = false
			
			TB_AUTDummyTable.Columns("Port").MaxLength = 5

			TB_AUTDummyTable.Columns.Add("Priority", GetType(System.String))
			TB_AUTDummyTable.Columns("Priority").AllowDBNull = true
			TB_AUTDummyTable.Columns("Priority").ReadOnly = false
			
			TB_AUTDummyTable.Columns("Priority").MaxLength = 2

			TB_AUTDummyTable.Columns.Add("IsResend", GetType(System.String))
			TB_AUTDummyTable.Columns("IsResend").AllowDBNull = true
			TB_AUTDummyTable.Columns("IsResend").ReadOnly = false
			
			TB_AUTDummyTable.Columns("IsResend").MaxLength = 1

			TB_AUTDummyTable.Columns.Add("DateTime", GetType(System.DateTime))
			TB_AUTDummyTable.Columns("DateTime").AllowDBNull = false
			TB_AUTDummyTable.Columns("DateTime").ReadOnly = false
			
			TB_AUTDummyTable.Columns.Add("LogID", GetType(System.Guid))
			TB_AUTDummyTable.Columns("LogID").AllowDBNull = false
			TB_AUTDummyTable.Columns("LogID").ReadOnly = false
			
			TB_AUTDummyTable.PrimaryKey = new DataColumn(){TB_AUTDummyTable.Columns("ID")}
			
			Dim TB_AUTDummyLogTable as DataTable = ds.Tables.Add("TB_AUTDummyLog")
			TB_AUTDummyLogTable.Columns.Add("ID", GetType(System.Guid))
			TB_AUTDummyLogTable.Columns("ID").AllowDBNull = false
			TB_AUTDummyLogTable.Columns("ID").ReadOnly = false
			
			TB_AUTDummyLogTable.Columns.Add("BlNo", GetType(System.String))
			TB_AUTDummyLogTable.Columns("BlNo").AllowDBNull = true
			TB_AUTDummyLogTable.Columns("BlNo").ReadOnly = false
			
			TB_AUTDummyLogTable.Columns("BlNo").MaxLength = 25

			TB_AUTDummyLogTable.Columns.Add("JobCode", GetType(System.String))
			TB_AUTDummyLogTable.Columns("JobCode").AllowDBNull = true
			TB_AUTDummyLogTable.Columns("JobCode").ReadOnly = false
			
			TB_AUTDummyLogTable.Columns("JobCode").MaxLength = 10

			TB_AUTDummyLogTable.Columns.Add("Error", GetType(System.String))
			TB_AUTDummyLogTable.Columns("Error").AllowDBNull = true
			TB_AUTDummyLogTable.Columns("Error").ReadOnly = false
			
			TB_AUTDummyLogTable.PrimaryKey = new DataColumn(){TB_AUTDummyLogTable.Columns("ID")}
			
			Dim TB_AUTJobLogsTable as DataTable = ds.Tables.Add("TB_AUTJobLogs")
			TB_AUTJobLogsTable.Columns.Add("ID", GetType(System.Guid))
			TB_AUTJobLogsTable.Columns("ID").AllowDBNull = false
			TB_AUTJobLogsTable.Columns("ID").ReadOnly = false
			
			TB_AUTJobLogsTable.Columns.Add("JobCode", GetType(System.String))
			TB_AUTJobLogsTable.Columns("JobCode").AllowDBNull = false
			TB_AUTJobLogsTable.Columns("JobCode").ReadOnly = false
			
			TB_AUTJobLogsTable.Columns("JobCode").MaxLength = 10

			TB_AUTJobLogsTable.Columns.Add("RequestBy", GetType(System.String))
			TB_AUTJobLogsTable.Columns("RequestBy").AllowDBNull = false
			TB_AUTJobLogsTable.Columns("RequestBy").ReadOnly = false
			
			TB_AUTJobLogsTable.Columns("RequestBy").MaxLength = 10

			TB_AUTJobLogsTable.Columns.Add("CreateTime", GetType(System.DateTime))
			TB_AUTJobLogsTable.Columns("CreateTime").AllowDBNull = false
			TB_AUTJobLogsTable.Columns("CreateTime").ReadOnly = false
			
			TB_AUTJobLogsTable.Columns.Add("FinishedTime", GetType(System.DateTime))
			TB_AUTJobLogsTable.Columns("FinishedTime").AllowDBNull = true
			TB_AUTJobLogsTable.Columns("FinishedTime").ReadOnly = false
			
			TB_AUTJobLogsTable.Columns.Add("CancelJob", GetType(System.String))
			TB_AUTJobLogsTable.Columns("CancelJob").AllowDBNull = false
			TB_AUTJobLogsTable.Columns("CancelJob").ReadOnly = false
			
			TB_AUTJobLogsTable.Columns("CancelJob").MaxLength = 1

			TB_AUTJobLogsTable.Columns.Add("Remarks", GetType(System.String))
			TB_AUTJobLogsTable.Columns("Remarks").AllowDBNull = false
			TB_AUTJobLogsTable.Columns("Remarks").ReadOnly = false
			
			TB_AUTJobLogsTable.Columns("Remarks").MaxLength = 200

			TB_AUTJobLogsTable.Columns.Add("Port", GetType(System.String))
			TB_AUTJobLogsTable.Columns("Port").AllowDBNull = true
			TB_AUTJobLogsTable.Columns("Port").ReadOnly = false
			
			TB_AUTJobLogsTable.Columns("Port").MaxLength = 5

			TB_AUTJobLogsTable.Columns.Add("VoyageID", GetType(System.Guid))
			TB_AUTJobLogsTable.Columns("VoyageID").AllowDBNull = true
			TB_AUTJobLogsTable.Columns("VoyageID").ReadOnly = false
			
			TB_AUTJobLogsTable.Columns.Add("Priority", GetType(System.String))
			TB_AUTJobLogsTable.Columns("Priority").AllowDBNull = true
			TB_AUTJobLogsTable.Columns("Priority").ReadOnly = false
			
			TB_AUTJobLogsTable.Columns("Priority").MaxLength = 10

			TB_AUTJobLogsTable.Columns.Add("CancelBy", GetType(System.String))
			TB_AUTJobLogsTable.Columns("CancelBy").AllowDBNull = true
			TB_AUTJobLogsTable.Columns("CancelBy").ReadOnly = false
			
			TB_AUTJobLogsTable.Columns("CancelBy").MaxLength = 10

			TB_AUTJobLogsTable.Columns.Add("CancelTime", GetType(System.DateTime))
			TB_AUTJobLogsTable.Columns("CancelTime").AllowDBNull = true
			TB_AUTJobLogsTable.Columns("CancelTime").ReadOnly = false
			
			TB_AUTJobLogsTable.PrimaryKey = new DataColumn(){TB_AUTJobLogsTable.Columns("ID")}
			
			Dim TB_AUTJobLogsDetailTable as DataTable = ds.Tables.Add("TB_AUTJobLogsDetail")
			TB_AUTJobLogsDetailTable.Columns.Add("ID", GetType(System.Guid))
			TB_AUTJobLogsDetailTable.Columns("ID").AllowDBNull = false
			TB_AUTJobLogsDetailTable.Columns("ID").ReadOnly = false
			
			TB_AUTJobLogsDetailTable.Columns.Add("JobID", GetType(System.Guid))
			TB_AUTJobLogsDetailTable.Columns("JobID").AllowDBNull = false
			TB_AUTJobLogsDetailTable.Columns("JobID").ReadOnly = false
			
			TB_AUTJobLogsDetailTable.Columns.Add("DocumentID", GetType(System.Guid))
			TB_AUTJobLogsDetailTable.Columns("DocumentID").AllowDBNull = false
			TB_AUTJobLogsDetailTable.Columns("DocumentID").ReadOnly = false
			
			TB_AUTJobLogsDetailTable.Columns.Add("Document", GetType(System.String))
			TB_AUTJobLogsDetailTable.Columns("Document").AllowDBNull = false
			TB_AUTJobLogsDetailTable.Columns("Document").ReadOnly = false
			
			TB_AUTJobLogsDetailTable.Columns.Add("DocumentStatus", GetType(System.String))
			TB_AUTJobLogsDetailTable.Columns("DocumentStatus").AllowDBNull = false
			TB_AUTJobLogsDetailTable.Columns("DocumentStatus").ReadOnly = false
			
			TB_AUTJobLogsDetailTable.Columns("DocumentStatus").MaxLength = 10

			TB_AUTJobLogsDetailTable.Columns.Add("GenerateTime", GetType(System.DateTime))
			TB_AUTJobLogsDetailTable.Columns("GenerateTime").AllowDBNull = false
			TB_AUTJobLogsDetailTable.Columns("GenerateTime").ReadOnly = false
			
			TB_AUTJobLogsDetailTable.Columns.Add("SentTime", GetType(System.DateTime))
			TB_AUTJobLogsDetailTable.Columns("SentTime").AllowDBNull = true
			TB_AUTJobLogsDetailTable.Columns("SentTime").ReadOnly = false
			
			TB_AUTJobLogsDetailTable.Columns.Add("Result", GetType(System.String))
			TB_AUTJobLogsDetailTable.Columns("Result").AllowDBNull = true
			TB_AUTJobLogsDetailTable.Columns("Result").ReadOnly = false
			
			TB_AUTJobLogsDetailTable.Columns.Add("sKey", GetType(System.String))
			TB_AUTJobLogsDetailTable.Columns("sKey").AllowDBNull = true
			TB_AUTJobLogsDetailTable.Columns("sKey").ReadOnly = false
			
			TB_AUTJobLogsDetailTable.Columns("sKey").MaxLength = 20

			TB_AUTJobLogsDetailTable.PrimaryKey = new DataColumn(){TB_AUTJobLogsDetailTable.Columns("ID")}
			
			Dim TB_AUTJobsTable as DataTable = ds.Tables.Add("TB_AUTJobs")
			TB_AUTJobsTable.Columns.Add("ID", GetType(System.Guid))
			TB_AUTJobsTable.Columns("ID").AllowDBNull = false
			TB_AUTJobsTable.Columns("ID").ReadOnly = false
			
			TB_AUTJobsTable.Columns.Add("JobCode", GetType(System.String))
			TB_AUTJobsTable.Columns("JobCode").AllowDBNull = false
			TB_AUTJobsTable.Columns("JobCode").ReadOnly = false
			
			TB_AUTJobsTable.Columns("JobCode").MaxLength = 10

			TB_AUTJobsTable.Columns.Add("JobName", GetType(System.String))
			TB_AUTJobsTable.Columns("JobName").AllowDBNull = true
			TB_AUTJobsTable.Columns("JobName").ReadOnly = false
			
			TB_AUTJobsTable.Columns("JobName").MaxLength = 50

			TB_AUTJobsTable.Columns.Add("RecipiantAsTo", GetType(System.String))
			TB_AUTJobsTable.Columns("RecipiantAsTo").AllowDBNull = true
			TB_AUTJobsTable.Columns("RecipiantAsTo").ReadOnly = false
			
			TB_AUTJobsTable.Columns("RecipiantAsTo").MaxLength = 255

			TB_AUTJobsTable.Columns.Add("RecipiantAsCC", GetType(System.String))
			TB_AUTJobsTable.Columns("RecipiantAsCC").AllowDBNull = true
			TB_AUTJobsTable.Columns("RecipiantAsCC").ReadOnly = false
			
			TB_AUTJobsTable.Columns("RecipiantAsCC").MaxLength = 255

			TB_AUTJobsTable.Columns.Add("HTMLContent", GetType(System.String))
			TB_AUTJobsTable.Columns("HTMLContent").AllowDBNull = true
			TB_AUTJobsTable.Columns("HTMLContent").ReadOnly = false
			
			TB_AUTJobsTable.Columns.Add("PIC", GetType(System.String))
			TB_AUTJobsTable.Columns("PIC").AllowDBNull = true
			TB_AUTJobsTable.Columns("PIC").ReadOnly = false
			
			TB_AUTJobsTable.Columns("PIC").MaxLength = 200

			TB_AUTJobsTable.PrimaryKey = new DataColumn(){TB_AUTJobsTable.Columns("ID")}
			
			Dim TB_autoLogTable as DataTable = ds.Tables.Add("TB_autoLog")
			TB_autoLogTable.Columns.Add("ID", GetType(System.Guid))
			TB_autoLogTable.Columns("ID").AllowDBNull = false
			TB_autoLogTable.Columns("ID").ReadOnly = false
			
			TB_autoLogTable.Columns.Add("BLID", GetType(System.Guid))
			TB_autoLogTable.Columns("BLID").AllowDBNull = false
			TB_autoLogTable.Columns("BLID").ReadOnly = false
			
			TB_autoLogTable.Columns.Add("FaxNo", GetType(System.String))
			TB_autoLogTable.Columns("FaxNo").AllowDBNull = true
			TB_autoLogTable.Columns("FaxNo").ReadOnly = false
			
			TB_autoLogTable.Columns("FaxNo").MaxLength = 100

			TB_autoLogTable.Columns.Add("DocumentType", GetType(System.String))
			TB_autoLogTable.Columns("DocumentType").AllowDBNull = true
			TB_autoLogTable.Columns("DocumentType").ReadOnly = false
			
			TB_autoLogTable.Columns("DocumentType").MaxLength = 2

			TB_autoLogTable.Columns.Add("DocumentStatus", GetType(System.String))
			TB_autoLogTable.Columns("DocumentStatus").AllowDBNull = true
			TB_autoLogTable.Columns("DocumentStatus").ReadOnly = false
			
			TB_autoLogTable.Columns("DocumentStatus").MaxLength = 1

			TB_autoLogTable.Columns.Add("Subject", GetType(System.String))
			TB_autoLogTable.Columns("Subject").AllowDBNull = true
			TB_autoLogTable.Columns("Subject").ReadOnly = false
			
			TB_autoLogTable.Columns("Subject").MaxLength = 510

			TB_autoLogTable.Columns.Add("GenerateTime", GetType(System.DateTime))
			TB_autoLogTable.Columns("GenerateTime").AllowDBNull = true
			TB_autoLogTable.Columns("GenerateTime").ReadOnly = false
			
			TB_autoLogTable.Columns.Add("SentTime", GetType(System.DateTime))
			TB_autoLogTable.Columns("SentTime").AllowDBNull = true
			TB_autoLogTable.Columns("SentTime").ReadOnly = false
			
			TB_autoLogTable.Columns.Add("FaxLog", GetType(System.String))
			TB_autoLogTable.Columns("FaxLog").AllowDBNull = true
			TB_autoLogTable.Columns("FaxLog").ReadOnly = false
			
			TB_autoLogTable.Columns.Add("IsReportedGenerate", GetType(System.String))
			TB_autoLogTable.Columns("IsReportedGenerate").AllowDBNull = true
			TB_autoLogTable.Columns("IsReportedGenerate").ReadOnly = false
			
			TB_autoLogTable.Columns("IsReportedGenerate").MaxLength = 1

			TB_autoLogTable.Columns.Add("IsreportedFailed", GetType(System.String))
			TB_autoLogTable.Columns("IsreportedFailed").AllowDBNull = true
			TB_autoLogTable.Columns("IsreportedFailed").ReadOnly = false
			
			TB_autoLogTable.Columns("IsreportedFailed").MaxLength = 1

			TB_autoLogTable.PrimaryKey = new DataColumn(){TB_autoLogTable.Columns("ID")}
			
			Dim TB_AUTScheduleTable as DataTable = ds.Tables.Add("TB_AUTSchedule")
			TB_AUTScheduleTable.Columns.Add("ID", GetType(System.Guid))
			TB_AUTScheduleTable.Columns("ID").AllowDBNull = false
			TB_AUTScheduleTable.Columns("ID").ReadOnly = false
			
			TB_AUTScheduleTable.Columns.Add("JobCode", GetType(System.String))
			TB_AUTScheduleTable.Columns("JobCode").AllowDBNull = false
			TB_AUTScheduleTable.Columns("JobCode").ReadOnly = false
			
			TB_AUTScheduleTable.Columns("JobCode").MaxLength = 10

			TB_AUTScheduleTable.Columns.Add("Saturday", GetType(System.Boolean))
			TB_AUTScheduleTable.Columns("Saturday").AllowDBNull = true
			TB_AUTScheduleTable.Columns("Saturday").ReadOnly = false
			
			TB_AUTScheduleTable.Columns.Add("Sunday", GetType(System.Boolean))
			TB_AUTScheduleTable.Columns("Sunday").AllowDBNull = true
			TB_AUTScheduleTable.Columns("Sunday").ReadOnly = false
			
			TB_AUTScheduleTable.Columns.Add("Monday", GetType(System.Boolean))
			TB_AUTScheduleTable.Columns("Monday").AllowDBNull = true
			TB_AUTScheduleTable.Columns("Monday").ReadOnly = false
			
			TB_AUTScheduleTable.Columns.Add("Tuesday", GetType(System.Boolean))
			TB_AUTScheduleTable.Columns("Tuesday").AllowDBNull = true
			TB_AUTScheduleTable.Columns("Tuesday").ReadOnly = false
			
			TB_AUTScheduleTable.Columns.Add("Wednesday", GetType(System.Boolean))
			TB_AUTScheduleTable.Columns("Wednesday").AllowDBNull = true
			TB_AUTScheduleTable.Columns("Wednesday").ReadOnly = false
			
			TB_AUTScheduleTable.Columns.Add("Thursday", GetType(System.Boolean))
			TB_AUTScheduleTable.Columns("Thursday").AllowDBNull = true
			TB_AUTScheduleTable.Columns("Thursday").ReadOnly = false
			
			TB_AUTScheduleTable.Columns.Add("Friday", GetType(System.Boolean))
			TB_AUTScheduleTable.Columns("Friday").AllowDBNull = true
			TB_AUTScheduleTable.Columns("Friday").ReadOnly = false
			
			TB_AUTScheduleTable.Columns.Add("Time", GetType(System.DateTime))
			TB_AUTScheduleTable.Columns("Time").AllowDBNull = true
			TB_AUTScheduleTable.Columns("Time").ReadOnly = false
			
			TB_AUTScheduleTable.PrimaryKey = new DataColumn(){TB_AUTScheduleTable.Columns("ID")}
			
			Dim TB_AUTSettingsTable as DataTable = ds.Tables.Add("TB_AUTSettings")
			TB_AUTSettingsTable.Columns.Add("ID", GetType(System.Guid))
			TB_AUTSettingsTable.Columns("ID").AllowDBNull = false
			TB_AUTSettingsTable.Columns("ID").ReadOnly = false
			
			TB_AUTSettingsTable.Columns.Add("MailServer", GetType(System.String))
			TB_AUTSettingsTable.Columns("MailServer").AllowDBNull = false
			TB_AUTSettingsTable.Columns("MailServer").ReadOnly = false
			
			TB_AUTSettingsTable.Columns("MailServer").MaxLength = 50

			TB_AUTSettingsTable.Columns.Add("MailUserName", GetType(System.String))
			TB_AUTSettingsTable.Columns("MailUserName").AllowDBNull = false
			TB_AUTSettingsTable.Columns("MailUserName").ReadOnly = false
			
			TB_AUTSettingsTable.Columns("MailUserName").MaxLength = 50

			TB_AUTSettingsTable.Columns.Add("MailPassword", GetType(System.String))
			TB_AUTSettingsTable.Columns("MailPassword").AllowDBNull = false
			TB_AUTSettingsTable.Columns("MailPassword").ReadOnly = false
			
			TB_AUTSettingsTable.Columns("MailPassword").MaxLength = 50

			TB_AUTSettingsTable.Columns.Add("FAXServer", GetType(System.String))
			TB_AUTSettingsTable.Columns("FAXServer").AllowDBNull = true
			TB_AUTSettingsTable.Columns("FAXServer").ReadOnly = false
			
			TB_AUTSettingsTable.Columns("FAXServer").MaxLength = 50

			TB_AUTSettingsTable.Columns.Add("FaxUserName", GetType(System.String))
			TB_AUTSettingsTable.Columns("FaxUserName").AllowDBNull = true
			TB_AUTSettingsTable.Columns("FaxUserName").ReadOnly = false
			
			TB_AUTSettingsTable.Columns("FaxUserName").MaxLength = 50

			TB_AUTSettingsTable.Columns.Add("FaxPassword", GetType(System.String))
			TB_AUTSettingsTable.Columns("FaxPassword").AllowDBNull = true
			TB_AUTSettingsTable.Columns("FaxPassword").ReadOnly = false
			
			TB_AUTSettingsTable.Columns("FaxPassword").MaxLength = 50

			TB_AUTSettingsTable.Columns.Add("FaxServerMailBox", GetType(System.String))
			TB_AUTSettingsTable.Columns("FaxServerMailBox").AllowDBNull = true
			TB_AUTSettingsTable.Columns("FaxServerMailBox").ReadOnly = false
			
			TB_AUTSettingsTable.Columns("FaxServerMailBox").MaxLength = 50

			TB_AUTSettingsTable.Columns.Add("AutomationProfile", GetType(System.String))
			TB_AUTSettingsTable.Columns("AutomationProfile").AllowDBNull = true
			TB_AUTSettingsTable.Columns("AutomationProfile").ReadOnly = false
			
			TB_AUTSettingsTable.Columns("AutomationProfile").MaxLength = 50

			TB_AUTSettingsTable.Columns.Add("SentDocFolder", GetType(System.String))
			TB_AUTSettingsTable.Columns("SentDocFolder").AllowDBNull = true
			TB_AUTSettingsTable.Columns("SentDocFolder").ReadOnly = false
			
			TB_AUTSettingsTable.Columns("SentDocFolder").MaxLength = 100

			TB_AUTSettingsTable.PrimaryKey = new DataColumn(){TB_AUTSettingsTable.Columns("ID")}
			
			Dim TB_BookingTable as DataTable = ds.Tables.Add("TB_Booking")
			TB_BookingTable.Columns.Add("ID", GetType(System.Guid))
			TB_BookingTable.Columns("ID").AllowDBNull = false
			TB_BookingTable.Columns("ID").ReadOnly = false
			
			TB_BookingTable.Columns.Add("BookingNo", GetType(System.String))
			TB_BookingTable.Columns("BookingNo").AllowDBNull = false
			TB_BookingTable.Columns("BookingNo").ReadOnly = false
			
			TB_BookingTable.Columns("BookingNo").MaxLength = 25

			TB_BookingTable.Columns.Add("BookingDate", GetType(System.DateTime))
			TB_BookingTable.Columns("BookingDate").AllowDBNull = false
			TB_BookingTable.Columns("BookingDate").ReadOnly = false
			
			TB_BookingTable.Columns.Add("Line", GetType(System.String))
			TB_BookingTable.Columns("Line").AllowDBNull = true
			TB_BookingTable.Columns("Line").ReadOnly = false
			
			TB_BookingTable.Columns("Line").MaxLength = 20

			TB_BookingTable.Columns.Add("ClientID", GetType(System.Guid))
			TB_BookingTable.Columns("ClientID").AllowDBNull = true
			TB_BookingTable.Columns("ClientID").ReadOnly = false
			
			TB_BookingTable.Columns.Add("ClientRepID", GetType(System.Guid))
			TB_BookingTable.Columns("ClientRepID").AllowDBNull = true
			TB_BookingTable.Columns("ClientRepID").ReadOnly = false
			
			TB_BookingTable.Columns.Add("Validity", GetType(System.DateTime))
			TB_BookingTable.Columns("Validity").AllowDBNull = true
			TB_BookingTable.Columns("Validity").ReadOnly = false
			
			TB_BookingTable.Columns.Add("POL", GetType(System.String))
			TB_BookingTable.Columns("POL").AllowDBNull = true
			TB_BookingTable.Columns("POL").ReadOnly = false
			
			TB_BookingTable.Columns("POL").MaxLength = 10

			TB_BookingTable.Columns.Add("POLFreeDays", GetType(System.Int16))
			TB_BookingTable.Columns("POLFreeDays").AllowDBNull = true
			TB_BookingTable.Columns("POLFreeDays").ReadOnly = false
			
			TB_BookingTable.Columns.Add("POD", GetType(System.String))
			TB_BookingTable.Columns("POD").AllowDBNull = true
			TB_BookingTable.Columns("POD").ReadOnly = false
			
			TB_BookingTable.Columns("POD").MaxLength = 10

			TB_BookingTable.Columns.Add("PODFreeDays", GetType(System.Int16))
			TB_BookingTable.Columns("PODFreeDays").AllowDBNull = true
			TB_BookingTable.Columns("PODFreeDays").ReadOnly = false
			
			TB_BookingTable.Columns.Add("POT", GetType(System.String))
			TB_BookingTable.Columns("POT").AllowDBNull = true
			TB_BookingTable.Columns("POT").ReadOnly = false
			
			TB_BookingTable.Columns("POT").MaxLength = 10

			TB_BookingTable.Columns.Add("FPOD", GetType(System.String))
			TB_BookingTable.Columns("FPOD").AllowDBNull = true
			TB_BookingTable.Columns("FPOD").ReadOnly = false
			
			TB_BookingTable.Columns("FPOD").MaxLength = 10

			TB_BookingTable.Columns.Add("Goods", GetType(System.String))
			TB_BookingTable.Columns("Goods").AllowDBNull = true
			TB_BookingTable.Columns("Goods").ReadOnly = false
			
			TB_BookingTable.Columns("Goods").MaxLength = 500

			TB_BookingTable.Columns.Add("Depot", GetType(System.String))
			TB_BookingTable.Columns("Depot").AllowDBNull = true
			TB_BookingTable.Columns("Depot").ReadOnly = false
			
			TB_BookingTable.Columns("Depot").MaxLength = 20

			TB_BookingTable.Columns.Add("PrincipalReference", GetType(System.String))
			TB_BookingTable.Columns("PrincipalReference").AllowDBNull = true
			TB_BookingTable.Columns("PrincipalReference").ReadOnly = false
			
			TB_BookingTable.Columns("PrincipalReference").MaxLength = 40

			TB_BookingTable.Columns.Add("PrincipalConfirm", GetType(System.DateTime))
			TB_BookingTable.Columns("PrincipalConfirm").AllowDBNull = true
			TB_BookingTable.Columns("PrincipalConfirm").ReadOnly = false
			
			TB_BookingTable.Columns.Add("SalesMan", GetType(System.Guid))
			TB_BookingTable.Columns("SalesMan").AllowDBNull = true
			TB_BookingTable.Columns("SalesMan").ReadOnly = false
			
			TB_BookingTable.Columns.Add("Status", GetType(System.String))
			TB_BookingTable.Columns("Status").AllowDBNull = true
			TB_BookingTable.Columns("Status").ReadOnly = false
			
			TB_BookingTable.Columns("Status").MaxLength = 20

			TB_BookingTable.Columns.Add("Terms", GetType(System.String))
			TB_BookingTable.Columns("Terms").AllowDBNull = true
			TB_BookingTable.Columns("Terms").ReadOnly = false
			
			TB_BookingTable.Columns("Terms").MaxLength = 20

			TB_BookingTable.Columns.Add("Remarks", GetType(System.String))
			TB_BookingTable.Columns("Remarks").AllowDBNull = true
			TB_BookingTable.Columns("Remarks").ReadOnly = false
			
			TB_BookingTable.Columns.Add("ExchangeFrt", GetType(System.Decimal))
			TB_BookingTable.Columns("ExchangeFrt").AllowDBNull = true
			TB_BookingTable.Columns("ExchangeFrt").ReadOnly = false
			
			TB_BookingTable.Columns.Add("ExchangeTHC", GetType(System.Decimal))
			TB_BookingTable.Columns("ExchangeTHC").AllowDBNull = true
			TB_BookingTable.Columns("ExchangeTHC").ReadOnly = false
			
			TB_BookingTable.Columns.Add("InvoiceInIrr", GetType(System.Boolean))
			TB_BookingTable.Columns("InvoiceInIrr").AllowDBNull = true
			TB_BookingTable.Columns("InvoiceInIrr").ReadOnly = false
			
			TB_BookingTable.Columns.Add("Package", GetType(System.String))
			TB_BookingTable.Columns("Package").AllowDBNull = true
			TB_BookingTable.Columns("Package").ReadOnly = false
			
			TB_BookingTable.Columns("Package").MaxLength = 10

			TB_BookingTable.Columns.Add("ExceptedMtyPickup", GetType(System.DateTime))
			TB_BookingTable.Columns("ExceptedMtyPickup").AllowDBNull = true
			TB_BookingTable.Columns("ExceptedMtyPickup").ReadOnly = false
			
			TB_BookingTable.Columns.Add("BLToBeUsed", GetType(System.String))
			TB_BookingTable.Columns("BLToBeUsed").AllowDBNull = true
			TB_BookingTable.Columns("BLToBeUsed").ReadOnly = false
			
			TB_BookingTable.Columns("BLToBeUsed").MaxLength = 10

			TB_BookingTable.Columns.Add("SOC", GetType(System.String))
			TB_BookingTable.Columns("SOC").AllowDBNull = true
			TB_BookingTable.Columns("SOC").ReadOnly = false
			
			TB_BookingTable.Columns("SOC").MaxLength = 10

			TB_BookingTable.Columns.Add("UNNO", GetType(System.String))
			TB_BookingTable.Columns("UNNO").AllowDBNull = true
			TB_BookingTable.Columns("UNNO").ReadOnly = false
			
			TB_BookingTable.Columns("UNNO").MaxLength = 20

			TB_BookingTable.Columns.Add("IMDGCode", GetType(System.String))
			TB_BookingTable.Columns("IMDGCode").AllowDBNull = true
			TB_BookingTable.Columns("IMDGCode").ReadOnly = false
			
			TB_BookingTable.Columns("IMDGCode").MaxLength = 20

			TB_BookingTable.Columns.Add("PakingGroup", GetType(System.String))
			TB_BookingTable.Columns("PakingGroup").AllowDBNull = true
			TB_BookingTable.Columns("PakingGroup").ReadOnly = false
			
			TB_BookingTable.Columns("PakingGroup").MaxLength = 20

			TB_BookingTable.Columns.Add("PageNumber", GetType(System.Int16))
			TB_BookingTable.Columns("PageNumber").AllowDBNull = true
			TB_BookingTable.Columns("PageNumber").ReadOnly = false
			
			TB_BookingTable.Columns.Add("SwitchBLIn", GetType(System.String))
			TB_BookingTable.Columns("SwitchBLIn").AllowDBNull = true
			TB_BookingTable.Columns("SwitchBLIn").ReadOnly = false
			
			TB_BookingTable.Columns("SwitchBLIn").MaxLength = 5

			TB_BookingTable.Columns.Add("PackageType", GetType(System.String))
			TB_BookingTable.Columns("PackageType").AllowDBNull = true
			TB_BookingTable.Columns("PackageType").ReadOnly = false
			
			TB_BookingTable.Columns("PackageType").MaxLength = 10

			TB_BookingTable.Columns.Add("Payer", GetType(System.String))
			TB_BookingTable.Columns("Payer").AllowDBNull = true
			TB_BookingTable.Columns("Payer").ReadOnly = false
			
			TB_BookingTable.Columns("Payer").MaxLength = 510

			TB_BookingTable.PrimaryKey = new DataColumn(){TB_BookingTable.Columns("ID")}
			
			Dim TB_BookingCnsTable as DataTable = ds.Tables.Add("TB_BookingCns")
			TB_BookingCnsTable.Columns.Add("ID", GetType(System.Guid))
			TB_BookingCnsTable.Columns("ID").AllowDBNull = false
			TB_BookingCnsTable.Columns("ID").ReadOnly = false
			
			TB_BookingCnsTable.Columns.Add("PID", GetType(System.Guid))
			TB_BookingCnsTable.Columns("PID").AllowDBNull = false
			TB_BookingCnsTable.Columns("PID").ReadOnly = false
			
			TB_BookingCnsTable.Columns.Add("CnType", GetType(System.String))
			TB_BookingCnsTable.Columns("CnType").AllowDBNull = false
			TB_BookingCnsTable.Columns("CnType").ReadOnly = false
			
			TB_BookingCnsTable.Columns("CnType").MaxLength = 20

			TB_BookingCnsTable.Columns.Add("CnSize", GetType(System.String))
			TB_BookingCnsTable.Columns("CnSize").AllowDBNull = false
			TB_BookingCnsTable.Columns("CnSize").ReadOnly = false
			
			TB_BookingCnsTable.Columns("CnSize").MaxLength = 20

			TB_BookingCnsTable.Columns.Add("NoOfCns", GetType(System.Int64))
			TB_BookingCnsTable.Columns("NoOfCns").AllowDBNull = false
			TB_BookingCnsTable.Columns("NoOfCns").ReadOnly = false
			
			TB_BookingCnsTable.PrimaryKey = new DataColumn(){TB_BookingCnsTable.Columns("ID")}
			
			Dim TB_BookingDepositsTable as DataTable = ds.Tables.Add("TB_BookingDeposits")
			TB_BookingDepositsTable.Columns.Add("ID", GetType(System.Guid))
			TB_BookingDepositsTable.Columns("ID").AllowDBNull = false
			TB_BookingDepositsTable.Columns("ID").ReadOnly = false
			
			TB_BookingDepositsTable.Columns.Add("BookingID", GetType(System.Guid))
			TB_BookingDepositsTable.Columns("BookingID").AllowDBNull = false
			TB_BookingDepositsTable.Columns("BookingID").ReadOnly = false
			
			TB_BookingDepositsTable.Columns.Add("ChargesCodes", GetType(System.String))
			TB_BookingDepositsTable.Columns("ChargesCodes").AllowDBNull = true
			TB_BookingDepositsTable.Columns("ChargesCodes").ReadOnly = false
			
			TB_BookingDepositsTable.Columns("ChargesCodes").MaxLength = 20

			TB_BookingDepositsTable.Columns.Add("Remarks", GetType(System.String))
			TB_BookingDepositsTable.Columns("Remarks").AllowDBNull = true
			TB_BookingDepositsTable.Columns("Remarks").ReadOnly = false
			
			TB_BookingDepositsTable.Columns("Remarks").MaxLength = 500

			TB_BookingDepositsTable.Columns.Add("Amount", GetType(System.Double))
			TB_BookingDepositsTable.Columns("Amount").AllowDBNull = true
			TB_BookingDepositsTable.Columns("Amount").ReadOnly = false
			
			TB_BookingDepositsTable.Columns.Add("ReturnBackDate", GetType(System.DateTime))
			TB_BookingDepositsTable.Columns("ReturnBackDate").AllowDBNull = true
			TB_BookingDepositsTable.Columns("ReturnBackDate").ReadOnly = false
			
			TB_BookingDepositsTable.Columns.Add("ReturnBackAmount", GetType(System.Decimal))
			TB_BookingDepositsTable.Columns("ReturnBackAmount").AllowDBNull = true
			TB_BookingDepositsTable.Columns("ReturnBackAmount").ReadOnly = false
			
			TB_BookingDepositsTable.Columns.Add("ReturnBackRef", GetType(System.String))
			TB_BookingDepositsTable.Columns("ReturnBackRef").AllowDBNull = true
			TB_BookingDepositsTable.Columns("ReturnBackRef").ReadOnly = false
			
			TB_BookingDepositsTable.Columns("ReturnBackRef").MaxLength = 25

			TB_BookingDepositsTable.Columns.Add("PaidRef", GetType(System.String))
			TB_BookingDepositsTable.Columns("PaidRef").AllowDBNull = true
			TB_BookingDepositsTable.Columns("PaidRef").ReadOnly = false
			
			TB_BookingDepositsTable.Columns("PaidRef").MaxLength = 50

			TB_BookingDepositsTable.PrimaryKey = new DataColumn(){TB_BookingDepositsTable.Columns("ID")}
			
			Dim TB_BookingDetailsTable as DataTable = ds.Tables.Add("TB_BookingDetails")
			TB_BookingDetailsTable.Columns.Add("ID", GetType(System.Guid))
			TB_BookingDetailsTable.Columns("ID").AllowDBNull = false
			TB_BookingDetailsTable.Columns("ID").ReadOnly = false
			
			TB_BookingDetailsTable.Columns.Add("BookingID", GetType(System.Guid))
			TB_BookingDetailsTable.Columns("BookingID").AllowDBNull = false
			TB_BookingDetailsTable.Columns("BookingID").ReadOnly = false
			
			TB_BookingDetailsTable.Columns.Add("ChargeItem", GetType(System.String))
			TB_BookingDetailsTable.Columns("ChargeItem").AllowDBNull = true
			TB_BookingDetailsTable.Columns("ChargeItem").ReadOnly = false
			
			TB_BookingDetailsTable.Columns("ChargeItem").MaxLength = 20

			TB_BookingDetailsTable.Columns.Add("CnSize", GetType(System.String))
			TB_BookingDetailsTable.Columns("CnSize").AllowDBNull = true
			TB_BookingDetailsTable.Columns("CnSize").ReadOnly = false
			
			TB_BookingDetailsTable.Columns("CnSize").MaxLength = 20

			TB_BookingDetailsTable.Columns.Add("CnType", GetType(System.String))
			TB_BookingDetailsTable.Columns("CnType").AllowDBNull = true
			TB_BookingDetailsTable.Columns("CnType").ReadOnly = false
			
			TB_BookingDetailsTable.Columns("CnType").MaxLength = 20

			TB_BookingDetailsTable.Columns.Add("QTShipper", GetType(System.Double))
			TB_BookingDetailsTable.Columns("QTShipper").AllowDBNull = true
			TB_BookingDetailsTable.Columns("QTShipper").ReadOnly = false
			
			TB_BookingDetailsTable.Columns.Add("QTCarrier", GetType(System.Double))
			TB_BookingDetailsTable.Columns("QTCarrier").AllowDBNull = true
			TB_BookingDetailsTable.Columns("QTCarrier").ReadOnly = false
			
			TB_BookingDetailsTable.Columns.Add("TotalCntrs", GetType(System.Int16))
			TB_BookingDetailsTable.Columns("TotalCntrs").AllowDBNull = true
			TB_BookingDetailsTable.Columns("TotalCntrs").ReadOnly = false
			
			TB_BookingDetailsTable.Columns.Add("Payebleat", GetType(System.String))
			TB_BookingDetailsTable.Columns("Payebleat").AllowDBNull = true
			TB_BookingDetailsTable.Columns("Payebleat").ReadOnly = false
			
			TB_BookingDetailsTable.Columns("Payebleat").MaxLength = 10

			TB_BookingDetailsTable.Columns.Add("BaseOn", GetType(System.String))
			TB_BookingDetailsTable.Columns("BaseOn").AllowDBNull = false
			TB_BookingDetailsTable.Columns("BaseOn").ReadOnly = false
			
			TB_BookingDetailsTable.Columns("BaseOn").MaxLength = 20

			TB_BookingDetailsTable.Columns.Add("CurCode", GetType(System.String))
			TB_BookingDetailsTable.Columns("CurCode").AllowDBNull = true
			TB_BookingDetailsTable.Columns("CurCode").ReadOnly = false
			
			TB_BookingDetailsTable.Columns("CurCode").MaxLength = 20

			TB_BookingDetailsTable.Columns.Add("SlotRate", GetType(System.Double))
			TB_BookingDetailsTable.Columns("SlotRate").AllowDBNull = true
			TB_BookingDetailsTable.Columns("SlotRate").ReadOnly = false
			
			TB_BookingDetailsTable.PrimaryKey = new DataColumn(){TB_BookingDetailsTable.Columns("ID")}
			
			Dim TB_BookingReleasCntrsTable as DataTable = ds.Tables.Add("TB_BookingReleasCntrs")
			TB_BookingReleasCntrsTable.Columns.Add("ID", GetType(System.Guid))
			TB_BookingReleasCntrsTable.Columns("ID").AllowDBNull = false
			TB_BookingReleasCntrsTable.Columns("ID").ReadOnly = false
			
			TB_BookingReleasCntrsTable.Columns.Add("ReleaseID", GetType(System.Guid))
			TB_BookingReleasCntrsTable.Columns("ReleaseID").AllowDBNull = false
			TB_BookingReleasCntrsTable.Columns("ReleaseID").ReadOnly = false
			
			TB_BookingReleasCntrsTable.Columns.Add("CnType", GetType(System.String))
			TB_BookingReleasCntrsTable.Columns("CnType").AllowDBNull = false
			TB_BookingReleasCntrsTable.Columns("CnType").ReadOnly = false
			
			TB_BookingReleasCntrsTable.Columns("CnType").MaxLength = 20

			TB_BookingReleasCntrsTable.Columns.Add("CnSize", GetType(System.String))
			TB_BookingReleasCntrsTable.Columns("CnSize").AllowDBNull = false
			TB_BookingReleasCntrsTable.Columns("CnSize").ReadOnly = false
			
			TB_BookingReleasCntrsTable.Columns("CnSize").MaxLength = 20

			TB_BookingReleasCntrsTable.Columns.Add("NoOfCntrs", GetType(System.Int16))
			TB_BookingReleasCntrsTable.Columns("NoOfCntrs").AllowDBNull = false
			TB_BookingReleasCntrsTable.Columns("NoOfCntrs").ReadOnly = false
			
			TB_BookingReleasCntrsTable.PrimaryKey = new DataColumn(){TB_BookingReleasCntrsTable.Columns("ID")}
			
			Dim TB_BookingReleaseTable as DataTable = ds.Tables.Add("TB_BookingRelease")
			TB_BookingReleaseTable.Columns.Add("ID", GetType(System.Guid))
			TB_BookingReleaseTable.Columns("ID").AllowDBNull = false
			TB_BookingReleaseTable.Columns("ID").ReadOnly = false
			
			TB_BookingReleaseTable.Columns.Add("BookingID", GetType(System.Guid))
			TB_BookingReleaseTable.Columns("BookingID").AllowDBNull = true
			TB_BookingReleaseTable.Columns("BookingID").ReadOnly = false
			
			TB_BookingReleaseTable.Columns.Add("Reference", GetType(System.String))
			TB_BookingReleaseTable.Columns("Reference").AllowDBNull = true
			TB_BookingReleaseTable.Columns("Reference").ReadOnly = false
			
			TB_BookingReleaseTable.Columns("Reference").MaxLength = 24

			TB_BookingReleaseTable.Columns.Add("RequestTime", GetType(System.DateTime))
			TB_BookingReleaseTable.Columns("RequestTime").AllowDBNull = false
			TB_BookingReleaseTable.Columns("RequestTime").ReadOnly = false
			
			TB_BookingReleaseTable.Columns.Add("IssueDate", GetType(System.DateTime))
			TB_BookingReleaseTable.Columns("IssueDate").AllowDBNull = true
			TB_BookingReleaseTable.Columns("IssueDate").ReadOnly = false
			
			TB_BookingReleaseTable.Columns.Add("IssueOffice", GetType(System.String))
			TB_BookingReleaseTable.Columns("IssueOffice").AllowDBNull = true
			TB_BookingReleaseTable.Columns("IssueOffice").ReadOnly = false
			
			TB_BookingReleaseTable.Columns("IssueOffice").MaxLength = 20

			TB_BookingReleaseTable.PrimaryKey = new DataColumn(){TB_BookingReleaseTable.Columns("ID")}
			
			Dim TB_CalculationBaseTable as DataTable = ds.Tables.Add("TB_CalculationBase")
			TB_CalculationBaseTable.Columns.Add("ID", GetType(System.Guid))
			TB_CalculationBaseTable.Columns("ID").AllowDBNull = false
			TB_CalculationBaseTable.Columns("ID").ReadOnly = false
			
			TB_CalculationBaseTable.Columns.Add("ExchangeRateInward", GetType(System.String))
			TB_CalculationBaseTable.Columns("ExchangeRateInward").AllowDBNull = false
			TB_CalculationBaseTable.Columns("ExchangeRateInward").ReadOnly = false
			
			TB_CalculationBaseTable.Columns("ExchangeRateInward").MaxLength = 10

			TB_CalculationBaseTable.Columns.Add("ExchangeRateOutward", GetType(System.String))
			TB_CalculationBaseTable.Columns("ExchangeRateOutward").AllowDBNull = false
			TB_CalculationBaseTable.Columns("ExchangeRateOutward").ReadOnly = false
			
			TB_CalculationBaseTable.Columns("ExchangeRateOutward").MaxLength = 10

			TB_CalculationBaseTable.Columns.Add("DetentionInwardStartTime", GetType(System.String))
			TB_CalculationBaseTable.Columns("DetentionInwardStartTime").AllowDBNull = false
			TB_CalculationBaseTable.Columns("DetentionInwardStartTime").ReadOnly = false
			
			TB_CalculationBaseTable.Columns("DetentionInwardStartTime").MaxLength = 10

			TB_CalculationBaseTable.Columns.Add("DetentionOutwardStartTime", GetType(System.String))
			TB_CalculationBaseTable.Columns("DetentionOutwardStartTime").AllowDBNull = false
			TB_CalculationBaseTable.Columns("DetentionOutwardStartTime").ReadOnly = false
			
			TB_CalculationBaseTable.Columns("DetentionOutwardStartTime").MaxLength = 50

			TB_CalculationBaseTable.Columns.Add("TaxDutyInward", GetType(System.String))
			TB_CalculationBaseTable.Columns("TaxDutyInward").AllowDBNull = false
			TB_CalculationBaseTable.Columns("TaxDutyInward").ReadOnly = false
			
			TB_CalculationBaseTable.Columns("TaxDutyInward").MaxLength = 10

			TB_CalculationBaseTable.Columns.Add("TaxDutyOutward", GetType(System.String))
			TB_CalculationBaseTable.Columns("TaxDutyOutward").AllowDBNull = false
			TB_CalculationBaseTable.Columns("TaxDutyOutward").ReadOnly = false
			
			TB_CalculationBaseTable.Columns("TaxDutyOutward").MaxLength = 10

			TB_CalculationBaseTable.Columns.Add("IsTaxDutyJoin", GetType(System.Boolean))
			TB_CalculationBaseTable.Columns("IsTaxDutyJoin").AllowDBNull = false
			TB_CalculationBaseTable.Columns("IsTaxDutyJoin").ReadOnly = false
			
			TB_CalculationBaseTable.Columns.Add("ReferenceFormula", GetType(System.String))
			TB_CalculationBaseTable.Columns("ReferenceFormula").AllowDBNull = true
			TB_CalculationBaseTable.Columns("ReferenceFormula").ReadOnly = false
			
			TB_CalculationBaseTable.Columns("ReferenceFormula").MaxLength = 50

			TB_CalculationBaseTable.Columns.Add("InvoiceFormula", GetType(System.String))
			TB_CalculationBaseTable.Columns("InvoiceFormula").AllowDBNull = true
			TB_CalculationBaseTable.Columns("InvoiceFormula").ReadOnly = false
			
			TB_CalculationBaseTable.Columns("InvoiceFormula").MaxLength = 50

			TB_CalculationBaseTable.PrimaryKey = new DataColumn(){TB_CalculationBaseTable.Columns("ID")}
			
			Dim TB_ChgLevelDetailsTable as DataTable = ds.Tables.Add("TB_ChgLevelDetails")
			TB_ChgLevelDetailsTable.Columns.Add("ID", GetType(System.Guid))
			TB_ChgLevelDetailsTable.Columns("ID").AllowDBNull = false
			TB_ChgLevelDetailsTable.Columns("ID").ReadOnly = false
			
			TB_ChgLevelDetailsTable.Columns.Add("MasterID", GetType(System.Guid))
			TB_ChgLevelDetailsTable.Columns("MasterID").AllowDBNull = false
			TB_ChgLevelDetailsTable.Columns("MasterID").ReadOnly = false
			
			TB_ChgLevelDetailsTable.Columns.Add("CnType", GetType(System.String))
			TB_ChgLevelDetailsTable.Columns("CnType").AllowDBNull = false
			TB_ChgLevelDetailsTable.Columns("CnType").ReadOnly = false
			
			TB_ChgLevelDetailsTable.Columns("CnType").MaxLength = 20

			TB_ChgLevelDetailsTable.Columns.Add("SOC", GetType(System.String))
			TB_ChgLevelDetailsTable.Columns("SOC").AllowDBNull = false
			TB_ChgLevelDetailsTable.Columns("SOC").ReadOnly = false
			
			TB_ChgLevelDetailsTable.Columns("SOC").MaxLength = 20

			TB_ChgLevelDetailsTable.Columns.Add("ShipmentType", GetType(System.String))
			TB_ChgLevelDetailsTable.Columns("ShipmentType").AllowDBNull = false
			TB_ChgLevelDetailsTable.Columns("ShipmentType").ReadOnly = false
			
			TB_ChgLevelDetailsTable.Columns("ShipmentType").MaxLength = 20

			TB_ChgLevelDetailsTable.Columns.Add("Imco", GetType(System.String))
			TB_ChgLevelDetailsTable.Columns("Imco").AllowDBNull = false
			TB_ChgLevelDetailsTable.Columns("Imco").ReadOnly = false
			
			TB_ChgLevelDetailsTable.Columns("Imco").MaxLength = 20

			TB_ChgLevelDetailsTable.Columns.Add("IsFull", GetType(System.String))
			TB_ChgLevelDetailsTable.Columns("IsFull").AllowDBNull = true
			TB_ChgLevelDetailsTable.Columns("IsFull").ReadOnly = false
			
			TB_ChgLevelDetailsTable.Columns("IsFull").MaxLength = 20

			TB_ChgLevelDetailsTable.Columns.Add("Amount20", GetType(System.Double))
			TB_ChgLevelDetailsTable.Columns("Amount20").AllowDBNull = false
			TB_ChgLevelDetailsTable.Columns("Amount20").ReadOnly = false
			
			TB_ChgLevelDetailsTable.Columns.Add("Amount40", GetType(System.Double))
			TB_ChgLevelDetailsTable.Columns("Amount40").AllowDBNull = false
			TB_ChgLevelDetailsTable.Columns("Amount40").ReadOnly = false
			
			TB_ChgLevelDetailsTable.Columns.Add("Amount45", GetType(System.Double))
			TB_ChgLevelDetailsTable.Columns("Amount45").AllowDBNull = true
			TB_ChgLevelDetailsTable.Columns("Amount45").ReadOnly = false
			
			TB_ChgLevelDetailsTable.PrimaryKey = new DataColumn(){TB_ChgLevelDetailsTable.Columns("ID")}
			
			Dim TB_ChgLevelMasterTable as DataTable = ds.Tables.Add("TB_ChgLevelMaster")
			TB_ChgLevelMasterTable.Columns.Add("ID", GetType(System.Guid))
			TB_ChgLevelMasterTable.Columns("ID").AllowDBNull = false
			TB_ChgLevelMasterTable.Columns("ID").ReadOnly = false
			
			TB_ChgLevelMasterTable.Columns.Add("ImportExport", GetType(System.String))
			TB_ChgLevelMasterTable.Columns("ImportExport").AllowDBNull = true
			TB_ChgLevelMasterTable.Columns("ImportExport").ReadOnly = false
			
			TB_ChgLevelMasterTable.Columns("ImportExport").MaxLength = 20

			TB_ChgLevelMasterTable.Columns.Add("ApplyDate", GetType(System.DateTime))
			TB_ChgLevelMasterTable.Columns("ApplyDate").AllowDBNull = true
			TB_ChgLevelMasterTable.Columns("ApplyDate").ReadOnly = false
			
			TB_ChgLevelMasterTable.Columns.Add("Validity", GetType(System.DateTime))
			TB_ChgLevelMasterTable.Columns("Validity").AllowDBNull = true
			TB_ChgLevelMasterTable.Columns("Validity").ReadOnly = false
			
			TB_ChgLevelMasterTable.Columns.Add("Seq", GetType(System.Int16))
			TB_ChgLevelMasterTable.Columns("Seq").AllowDBNull = true
			TB_ChgLevelMasterTable.Columns("Seq").ReadOnly = false
			
			TB_ChgLevelMasterTable.Columns.Add("ChargeItem", GetType(System.String))
			TB_ChgLevelMasterTable.Columns("ChargeItem").AllowDBNull = true
			TB_ChgLevelMasterTable.Columns("ChargeItem").ReadOnly = false
			
			TB_ChgLevelMasterTable.Columns("ChargeItem").MaxLength = 20

			TB_ChgLevelMasterTable.Columns.Add("IsDeposit", GetType(System.Boolean))
			TB_ChgLevelMasterTable.Columns("IsDeposit").AllowDBNull = true
			TB_ChgLevelMasterTable.Columns("IsDeposit").ReadOnly = false
			
			TB_ChgLevelMasterTable.Columns.Add("BaseOn", GetType(System.String))
			TB_ChgLevelMasterTable.Columns("BaseOn").AllowDBNull = true
			TB_ChgLevelMasterTable.Columns("BaseOn").ReadOnly = false
			
			TB_ChgLevelMasterTable.Columns("BaseOn").MaxLength = 20

			TB_ChgLevelMasterTable.Columns.Add("CurCode", GetType(System.String))
			TB_ChgLevelMasterTable.Columns("CurCode").AllowDBNull = true
			TB_ChgLevelMasterTable.Columns("CurCode").ReadOnly = false
			
			TB_ChgLevelMasterTable.Columns("CurCode").MaxLength = 20

			TB_ChgLevelMasterTable.Columns.Add("DefaultAmount", GetType(System.Double))
			TB_ChgLevelMasterTable.Columns("DefaultAmount").AllowDBNull = true
			TB_ChgLevelMasterTable.Columns("DefaultAmount").ReadOnly = false
			
			TB_ChgLevelMasterTable.Columns.Add("DividInLCL", GetType(System.Boolean))
			TB_ChgLevelMasterTable.Columns("DividInLCL").AllowDBNull = true
			TB_ChgLevelMasterTable.Columns("DividInLCL").ReadOnly = false
			
			TB_ChgLevelMasterTable.Columns.Add("Condition", GetType(System.String))
			TB_ChgLevelMasterTable.Columns("Condition").AllowDBNull = true
			TB_ChgLevelMasterTable.Columns("Condition").ReadOnly = false
			
			TB_ChgLevelMasterTable.Columns("Condition").MaxLength = 20

			TB_ChgLevelMasterTable.Columns.Add("Description", GetType(System.String))
			TB_ChgLevelMasterTable.Columns("Description").AllowDBNull = true
			TB_ChgLevelMasterTable.Columns("Description").ReadOnly = false
			
			TB_ChgLevelMasterTable.Columns("Description").MaxLength = 500

			TB_ChgLevelMasterTable.Columns.Add("Tax", GetType(System.Decimal))
			TB_ChgLevelMasterTable.Columns("Tax").AllowDBNull = true
			TB_ChgLevelMasterTable.Columns("Tax").ReadOnly = false
			
			TB_ChgLevelMasterTable.Columns.Add("Toll", GetType(System.Decimal))
			TB_ChgLevelMasterTable.Columns("Toll").AllowDBNull = true
			TB_ChgLevelMasterTable.Columns("Toll").ReadOnly = false
			
			TB_ChgLevelMasterTable.Columns.Add("Port", GetType(System.String))
			TB_ChgLevelMasterTable.Columns("Port").AllowDBNull = true
			TB_ChgLevelMasterTable.Columns("Port").ReadOnly = false
			
			TB_ChgLevelMasterTable.Columns("Port").MaxLength = 10

			TB_ChgLevelMasterTable.Columns.Add("Line", GetType(System.String))
			TB_ChgLevelMasterTable.Columns("Line").AllowDBNull = true
			TB_ChgLevelMasterTable.Columns("Line").ReadOnly = false
			
			TB_ChgLevelMasterTable.Columns("Line").MaxLength = 20

			TB_ChgLevelMasterTable.Columns.Add("ClientID", GetType(System.Guid))
			TB_ChgLevelMasterTable.Columns("ClientID").AllowDBNull = true
			TB_ChgLevelMasterTable.Columns("ClientID").ReadOnly = false
			
			TB_ChgLevelMasterTable.PrimaryKey = new DataColumn(){TB_ChgLevelMasterTable.Columns("ID")}
			
			Dim TB_ClientsTable as DataTable = ds.Tables.Add("TB_Clients")
			TB_ClientsTable.Columns.Add("ID", GetType(System.Guid))
			TB_ClientsTable.Columns("ID").AllowDBNull = false
			TB_ClientsTable.Columns("ID").ReadOnly = false
			
			TB_ClientsTable.Columns.Add("lName", GetType(System.String))
			TB_ClientsTable.Columns("lName").AllowDBNull = false
			TB_ClientsTable.Columns("lName").ReadOnly = false
			
			TB_ClientsTable.Columns("lName").MaxLength = 500

			TB_ClientsTable.Columns.Add("lAddress", GetType(System.String))
			TB_ClientsTable.Columns("lAddress").AllowDBNull = true
			TB_ClientsTable.Columns("lAddress").ReadOnly = false
			
			TB_ClientsTable.Columns("lAddress").MaxLength = 1000

			TB_ClientsTable.Columns.Add("fName", GetType(System.String))
			TB_ClientsTable.Columns("fName").AllowDBNull = true
			TB_ClientsTable.Columns("fName").ReadOnly = false
			
			TB_ClientsTable.Columns("fName").MaxLength = 500

			TB_ClientsTable.Columns.Add("fAddress", GetType(System.String))
			TB_ClientsTable.Columns("fAddress").AllowDBNull = true
			TB_ClientsTable.Columns("fAddress").ReadOnly = false
			
			TB_ClientsTable.Columns("fAddress").MaxLength = 1000

			TB_ClientsTable.Columns.Add("Email", GetType(System.String))
			TB_ClientsTable.Columns("Email").AllowDBNull = true
			TB_ClientsTable.Columns("Email").ReadOnly = false
			
			TB_ClientsTable.Columns("Email").MaxLength = 500

			TB_ClientsTable.Columns.Add("Fax", GetType(System.String))
			TB_ClientsTable.Columns("Fax").AllowDBNull = true
			TB_ClientsTable.Columns("Fax").ReadOnly = false
			
			TB_ClientsTable.Columns("Fax").MaxLength = 500

			TB_ClientsTable.Columns.Add("TEL", GetType(System.String))
			TB_ClientsTable.Columns("TEL").AllowDBNull = true
			TB_ClientsTable.Columns("TEL").ReadOnly = false
			
			TB_ClientsTable.Columns("TEL").MaxLength = 500

			TB_ClientsTable.Columns.Add("Country", GetType(System.String))
			TB_ClientsTable.Columns("Country").AllowDBNull = true
			TB_ClientsTable.Columns("Country").ReadOnly = false
			
			TB_ClientsTable.Columns("Country").MaxLength = 20

			TB_ClientsTable.Columns.Add("Remarks", GetType(System.String))
			TB_ClientsTable.Columns("Remarks").AllowDBNull = true
			TB_ClientsTable.Columns("Remarks").ReadOnly = false
			
			TB_ClientsTable.Columns("Remarks").MaxLength = 500

			TB_ClientsTable.Columns.Add("AccountA", GetType(System.String))
			TB_ClientsTable.Columns("AccountA").AllowDBNull = true
			TB_ClientsTable.Columns("AccountA").ReadOnly = false
			
			TB_ClientsTable.Columns("AccountA").MaxLength = 100

			TB_ClientsTable.Columns.Add("AccountB", GetType(System.String))
			TB_ClientsTable.Columns("AccountB").AllowDBNull = true
			TB_ClientsTable.Columns("AccountB").ReadOnly = false
			
			TB_ClientsTable.Columns("AccountB").MaxLength = 100

			TB_ClientsTable.Columns.Add("AccountC", GetType(System.String))
			TB_ClientsTable.Columns("AccountC").AllowDBNull = true
			TB_ClientsTable.Columns("AccountC").ReadOnly = false
			
			TB_ClientsTable.Columns("AccountC").MaxLength = 100

			TB_ClientsTable.Columns.Add("POBOX", GetType(System.String))
			TB_ClientsTable.Columns("POBOX").AllowDBNull = true
			TB_ClientsTable.Columns("POBOX").ReadOnly = false
			
			TB_ClientsTable.Columns("POBOX").MaxLength = 30

			TB_ClientsTable.Columns.Add("RegestrationNo", GetType(System.String))
			TB_ClientsTable.Columns("RegestrationNo").AllowDBNull = true
			TB_ClientsTable.Columns("RegestrationNo").ReadOnly = false
			
			TB_ClientsTable.Columns("RegestrationNo").MaxLength = 40

			TB_ClientsTable.Columns.Add("EconomicNo", GetType(System.String))
			TB_ClientsTable.Columns("EconomicNo").AllowDBNull = true
			TB_ClientsTable.Columns("EconomicNo").ReadOnly = false
			
			TB_ClientsTable.Columns("EconomicNo").MaxLength = 40

			TB_ClientsTable.Columns.Add("IsReal", GetType(System.Boolean))
			TB_ClientsTable.Columns("IsReal").AllowDBNull = true
			TB_ClientsTable.Columns("IsReal").ReadOnly = false
			
			TB_ClientsTable.Columns.Add("ClientCode", GetType(System.String))
			TB_ClientsTable.Columns("ClientCode").AllowDBNull = true
			TB_ClientsTable.Columns("ClientCode").ReadOnly = false
			
			TB_ClientsTable.Columns("ClientCode").MaxLength = 30

			TB_ClientsTable.Columns.Add("Mobile", GetType(System.String))
			TB_ClientsTable.Columns("Mobile").AllowDBNull = true
			TB_ClientsTable.Columns("Mobile").ReadOnly = false
			
			TB_ClientsTable.Columns("Mobile").MaxLength = 25

			TB_ClientsTable.Columns.Add("SendDocsByFax", GetType(System.Boolean))
			TB_ClientsTable.Columns("SendDocsByFax").AllowDBNull = true
			TB_ClientsTable.Columns("SendDocsByFax").ReadOnly = false
			
			TB_ClientsTable.Columns.Add("SendDocsByEmail", GetType(System.Boolean))
			TB_ClientsTable.Columns("SendDocsByEmail").AllowDBNull = true
			TB_ClientsTable.Columns("SendDocsByEmail").ReadOnly = false
			
			TB_ClientsTable.Columns.Add("NationalCode", GetType(System.String))
			TB_ClientsTable.Columns("NationalCode").AllowDBNull = true
			TB_ClientsTable.Columns("NationalCode").ReadOnly = false
			
			TB_ClientsTable.Columns("NationalCode").MaxLength = 20

			TB_ClientsTable.Columns.Add("NationalID", GetType(System.String))
			TB_ClientsTable.Columns("NationalID").AllowDBNull = true
			TB_ClientsTable.Columns("NationalID").ReadOnly = false
			
			TB_ClientsTable.Columns("NationalID").MaxLength = 20

			TB_ClientsTable.Columns.Add("City", GetType(System.String))
			TB_ClientsTable.Columns("City").AllowDBNull = true
			TB_ClientsTable.Columns("City").ReadOnly = false
			
			TB_ClientsTable.Columns("City").MaxLength = 10

			TB_ClientsTable.Columns.Add("State", GetType(System.String))
			TB_ClientsTable.Columns("State").AllowDBNull = true
			TB_ClientsTable.Columns("State").ReadOnly = false
			
			TB_ClientsTable.Columns("State").MaxLength = 10

			TB_ClientsTable.Columns.Add("AccountStatus", GetType(System.String))
			TB_ClientsTable.Columns("AccountStatus").AllowDBNull = true
			TB_ClientsTable.Columns("AccountStatus").ReadOnly = false
			
			TB_ClientsTable.Columns("AccountStatus").MaxLength = 20

			TB_ClientsTable.Columns.Add("Deposit", GetType(System.Int64))
			TB_ClientsTable.Columns("Deposit").AllowDBNull = true
            TB_ClientsTable.Columns("Deposit").ReadOnly = False

            TB_ClientsTable.Columns.Add("WebUserId", GetType(System.String))
            TB_ClientsTable.Columns("WebUserId").AllowDBNull = True
            TB_ClientsTable.Columns("WebUserId").ReadOnly = False

            TB_ClientsTable.Columns.Add("WebUserPass", GetType(System.String))
            TB_ClientsTable.Columns("WebUserPass").AllowDBNull = True
            TB_ClientsTable.Columns("WebUserPass").ReadOnly = False

            TB_ClientsTable.Columns.Add("WebInactive", GetType(System.Boolean))
            TB_ClientsTable.Columns("WebInactive").AllowDBNull = True
            TB_ClientsTable.Columns("WebInactive").ReadOnly = False

            TB_ClientsTable.Columns.Add("ClientType", GetType(System.String))
            TB_ClientsTable.Columns("ClientType").AllowDBNull = True
            TB_ClientsTable.Columns("ClientType").ReadOnly = False

			TB_ClientsTable.PrimaryKey = new DataColumn(){TB_ClientsTable.Columns("ID")}
			
			Dim TB_ClusesTable as DataTable = ds.Tables.Add("TB_Cluses")
			TB_ClusesTable.Columns.Add("ID", GetType(System.Guid))
			TB_ClusesTable.Columns("ID").AllowDBNull = false
			TB_ClusesTable.Columns("ID").ReadOnly = false
			
			TB_ClusesTable.Columns.Add("CluseGroup", GetType(System.String))
			TB_ClusesTable.Columns("CluseGroup").AllowDBNull = false
			TB_ClusesTable.Columns("CluseGroup").ReadOnly = false
			
			TB_ClusesTable.Columns("CluseGroup").MaxLength = 20

			TB_ClusesTable.Columns.Add("Description", GetType(System.String))
			TB_ClusesTable.Columns("Description").AllowDBNull = false
			TB_ClusesTable.Columns("Description").ReadOnly = false
			
			TB_ClusesTable.Columns("Description").MaxLength = 500

			TB_ClusesTable.Columns.Add("Detail", GetType(System.String))
			TB_ClusesTable.Columns("Detail").AllowDBNull = true
			TB_ClusesTable.Columns("Detail").ReadOnly = false
			
			TB_ClusesTable.PrimaryKey = new DataColumn(){TB_ClusesTable.Columns("ID")}
			
			Dim TB_CODETable as DataTable = ds.Tables.Add("TB_CODE")
			TB_CODETable.Columns.Add("ID", GetType(System.Guid))
			TB_CODETable.Columns("ID").AllowDBNull = false
			TB_CODETable.Columns("ID").ReadOnly = false
			
			TB_CODETable.Columns.Add("GroupCode", GetType(System.String))
			TB_CODETable.Columns("GroupCode").AllowDBNull = true
			TB_CODETable.Columns("GroupCode").ReadOnly = false
			
			TB_CODETable.Columns("GroupCode").MaxLength = 4

			TB_CODETable.Columns.Add("STDCode", GetType(System.String))
			TB_CODETable.Columns("STDCode").AllowDBNull = true
			TB_CODETable.Columns("STDCode").ReadOnly = false
			
			TB_CODETable.Columns("STDCode").MaxLength = 20

			TB_CODETable.Columns.Add("NextCode", GetType(System.String))
			TB_CODETable.Columns("NextCode").AllowDBNull = true
			TB_CODETable.Columns("NextCode").ReadOnly = false
			
			TB_CODETable.Columns("NextCode").MaxLength = 500

			TB_CODETable.Columns.Add("MEANING", GetType(System.String))
			TB_CODETable.Columns("MEANING").AllowDBNull = true
			TB_CODETable.Columns("MEANING").ReadOnly = false
			
			TB_CODETable.Columns("MEANING").MaxLength = 500

			TB_CODETable.Columns.Add("MEANINGF", GetType(System.String))
			TB_CODETable.Columns("MEANINGF").AllowDBNull = true
			TB_CODETable.Columns("MEANINGF").ReadOnly = false
			
			TB_CODETable.Columns("MEANINGF").MaxLength = 500

			TB_CODETable.Columns.Add("IsEditeble", GetType(System.Boolean))
			TB_CODETable.Columns("IsEditeble").AllowDBNull = true
			TB_CODETable.Columns("IsEditeble").ReadOnly = false
			
			TB_CODETable.PrimaryKey = new DataColumn(){TB_CODETable.Columns("ID")}
			
			Dim TB_CodeMasterTable as DataTable = ds.Tables.Add("TB_CodeMaster")
			TB_CodeMasterTable.Columns.Add("ID", GetType(System.Guid))
			TB_CodeMasterTable.Columns("ID").AllowDBNull = false
			TB_CodeMasterTable.Columns("ID").ReadOnly = false
			
			TB_CodeMasterTable.Columns.Add("GroupCode", GetType(System.String))
			TB_CodeMasterTable.Columns("GroupCode").AllowDBNull = false
			TB_CodeMasterTable.Columns("GroupCode").ReadOnly = false
			
			TB_CodeMasterTable.Columns("GroupCode").MaxLength = 4

			TB_CodeMasterTable.Columns.Add("GroupName", GetType(System.String))
			TB_CodeMasterTable.Columns("GroupName").AllowDBNull = false
			TB_CodeMasterTable.Columns("GroupName").ReadOnly = false
			
			TB_CodeMasterTable.Columns("GroupName").MaxLength = 500

			TB_CodeMasterTable.Columns.Add("IsSystemCode", GetType(System.Boolean))
			TB_CodeMasterTable.Columns("IsSystemCode").AllowDBNull = true
			TB_CodeMasterTable.Columns("IsSystemCode").ReadOnly = false
			
			TB_CodeMasterTable.PrimaryKey = new DataColumn(){TB_CodeMasterTable.Columns("GroupCode")}
			
			Dim TB_CompanyTable as DataTable = ds.Tables.Add("TB_Company")
			TB_CompanyTable.Columns.Add("ID", GetType(System.Guid))
			TB_CompanyTable.Columns("ID").AllowDBNull = false
			TB_CompanyTable.Columns("ID").ReadOnly = false
			
			TB_CompanyTable.Columns.Add("CompanyName", GetType(System.String))
			TB_CompanyTable.Columns("CompanyName").AllowDBNull = false
			TB_CompanyTable.Columns("CompanyName").ReadOnly = false
			
			TB_CompanyTable.Columns("CompanyName").MaxLength = 500

			TB_CompanyTable.Columns.Add("CompanyAddress", GetType(System.String))
			TB_CompanyTable.Columns("CompanyAddress").AllowDBNull = false
			TB_CompanyTable.Columns("CompanyAddress").ReadOnly = false
			
			TB_CompanyTable.Columns("CompanyAddress").MaxLength = 1000

			TB_CompanyTable.Columns.Add("Tel", GetType(System.String))
			TB_CompanyTable.Columns("Tel").AllowDBNull = false
			TB_CompanyTable.Columns("Tel").ReadOnly = false
			
			TB_CompanyTable.Columns("Tel").MaxLength = 40

			TB_CompanyTable.Columns.Add("Fax", GetType(System.String))
			TB_CompanyTable.Columns("Fax").AllowDBNull = false
			TB_CompanyTable.Columns("Fax").ReadOnly = false
			
			TB_CompanyTable.Columns("Fax").MaxLength = 40

			TB_CompanyTable.Columns.Add("EDICODE", GetType(System.String))
			TB_CompanyTable.Columns("EDICODE").AllowDBNull = false
			TB_CompanyTable.Columns("EDICODE").ReadOnly = false
			
			TB_CompanyTable.Columns("EDICODE").MaxLength = 20

			TB_CompanyTable.Columns.Add("DomainName", GetType(System.String))
			TB_CompanyTable.Columns("DomainName").AllowDBNull = true
			TB_CompanyTable.Columns("DomainName").ReadOnly = false
			
			TB_CompanyTable.Columns("DomainName").MaxLength = 500

			TB_CompanyTable.Columns.Add("POP3", GetType(System.String))
			TB_CompanyTable.Columns("POP3").AllowDBNull = true
			TB_CompanyTable.Columns("POP3").ReadOnly = false
			
			TB_CompanyTable.Columns("POP3").MaxLength = 500

			TB_CompanyTable.Columns.Add("SMTP", GetType(System.String))
			TB_CompanyTable.Columns("SMTP").AllowDBNull = true
			TB_CompanyTable.Columns("SMTP").ReadOnly = false
			
			TB_CompanyTable.Columns("SMTP").MaxLength = 500

			TB_CompanyTable.Columns.Add("CompanyFName", GetType(System.String))
			TB_CompanyTable.Columns("CompanyFName").AllowDBNull = true
			TB_CompanyTable.Columns("CompanyFName").ReadOnly = false
			
			TB_CompanyTable.Columns("CompanyFName").MaxLength = 500

			TB_CompanyTable.Columns.Add("CompantFAddress", GetType(System.String))
			TB_CompanyTable.Columns("CompantFAddress").AllowDBNull = true
			TB_CompanyTable.Columns("CompantFAddress").ReadOnly = false
			
			TB_CompanyTable.Columns("CompantFAddress").MaxLength = 1000

			TB_CompanyTable.Columns.Add("CompanyFTel", GetType(System.String))
			TB_CompanyTable.Columns("CompanyFTel").AllowDBNull = true
			TB_CompanyTable.Columns("CompanyFTel").ReadOnly = false
			
			TB_CompanyTable.Columns("CompanyFTel").MaxLength = 40

			TB_CompanyTable.Columns.Add("CompanyFFax", GetType(System.String))
			TB_CompanyTable.Columns("CompanyFFax").AllowDBNull = true
			TB_CompanyTable.Columns("CompanyFFax").ReadOnly = false
			
			TB_CompanyTable.Columns("CompanyFFax").MaxLength = 40

			TB_CompanyTable.Columns.Add("CompanyAccount", GetType(System.String))
			TB_CompanyTable.Columns("CompanyAccount").AllowDBNull = true
			TB_CompanyTable.Columns("CompanyAccount").ReadOnly = false
			
			TB_CompanyTable.Columns.Add("DetentionBySlab", GetType(System.Boolean))
			TB_CompanyTable.Columns("DetentionBySlab").AllowDBNull = true
			TB_CompanyTable.Columns("DetentionBySlab").ReadOnly = false
			
			TB_CompanyTable.Columns.Add("POBOX", GetType(System.String))
			TB_CompanyTable.Columns("POBOX").AllowDBNull = true
			TB_CompanyTable.Columns("POBOX").ReadOnly = false
			
			TB_CompanyTable.Columns("POBOX").MaxLength = 30

			TB_CompanyTable.Columns.Add("RegestrationNo", GetType(System.String))
			TB_CompanyTable.Columns("RegestrationNo").AllowDBNull = true
			TB_CompanyTable.Columns("RegestrationNo").ReadOnly = false
			
			TB_CompanyTable.Columns("RegestrationNo").MaxLength = 40

			TB_CompanyTable.Columns.Add("EconomicNo", GetType(System.String))
			TB_CompanyTable.Columns("EconomicNo").AllowDBNull = true
			TB_CompanyTable.Columns("EconomicNo").ReadOnly = false
			
			TB_CompanyTable.Columns("EconomicNo").MaxLength = 40

			TB_CompanyTable.Columns.Add("SOCEDICode", GetType(System.String))
			TB_CompanyTable.Columns("SOCEDICode").AllowDBNull = true
			TB_CompanyTable.Columns("SOCEDICode").ReadOnly = false
			
			TB_CompanyTable.Columns("SOCEDICode").MaxLength = 10

			TB_CompanyTable.Columns.Add("CompanyBranchAdrs", GetType(System.String))
			TB_CompanyTable.Columns("CompanyBranchAdrs").AllowDBNull = true
			TB_CompanyTable.Columns("CompanyBranchAdrs").ReadOnly = false
			
			TB_CompanyTable.Columns("CompanyBranchAdrs").MaxLength = 500

			TB_CompanyTable.Columns.Add("CompanyLBranchAdrs", GetType(System.String))
			TB_CompanyTable.Columns("CompanyLBranchAdrs").AllowDBNull = true
			TB_CompanyTable.Columns("CompanyLBranchAdrs").ReadOnly = false
			
			TB_CompanyTable.Columns("CompanyLBranchAdrs").MaxLength = 500

			TB_CompanyTable.PrimaryKey = new DataColumn(){TB_CompanyTable.Columns("ID")}
			
			Dim TB_CountryTable as DataTable = ds.Tables.Add("TB_Country")
			TB_CountryTable.Columns.Add("CountryCode", GetType(System.String))
			TB_CountryTable.Columns("CountryCode").AllowDBNull = false
			TB_CountryTable.Columns("CountryCode").ReadOnly = false
			
			TB_CountryTable.Columns("CountryCode").MaxLength = 4

			TB_CountryTable.Columns.Add("CountryName", GetType(System.String))
			TB_CountryTable.Columns("CountryName").AllowDBNull = false
			TB_CountryTable.Columns("CountryName").ReadOnly = false
			
			TB_CountryTable.Columns("CountryName").MaxLength = 500

			TB_CountryTable.Columns.Add("FCountryName", GetType(System.String))
			TB_CountryTable.Columns("FCountryName").AllowDBNull = true
			TB_CountryTable.Columns("FCountryName").ReadOnly = false
			
			TB_CountryTable.Columns("FCountryName").MaxLength = 500

			TB_CountryTable.Columns.Add("ID", GetType(System.Guid))
			TB_CountryTable.Columns("ID").AllowDBNull = false
			TB_CountryTable.Columns("ID").ReadOnly = false
			
			TB_CountryTable.PrimaryKey = new DataColumn(){TB_CountryTable.Columns("CountryCode")}
			
			Dim TB_CustomMenuTable as DataTable = ds.Tables.Add("TB_CustomMenu")
			TB_CustomMenuTable.Columns.Add("ID", GetType(System.Guid))
			TB_CustomMenuTable.Columns("ID").AllowDBNull = false
			TB_CustomMenuTable.Columns("ID").ReadOnly = false
			
			TB_CustomMenuTable.Columns.Add("Line", GetType(System.String))
			TB_CustomMenuTable.Columns("Line").AllowDBNull = true
			TB_CustomMenuTable.Columns("Line").ReadOnly = false
			
			TB_CustomMenuTable.Columns("Line").MaxLength = 20

			TB_CustomMenuTable.Columns.Add("MenuGroup", GetType(System.String))
			TB_CustomMenuTable.Columns("MenuGroup").AllowDBNull = true
			TB_CustomMenuTable.Columns("MenuGroup").ReadOnly = false
			
			TB_CustomMenuTable.Columns("MenuGroup").MaxLength = 100

			TB_CustomMenuTable.Columns.Add("MenuItem", GetType(System.String))
			TB_CustomMenuTable.Columns("MenuItem").AllowDBNull = true
			TB_CustomMenuTable.Columns("MenuItem").ReadOnly = false
			
			TB_CustomMenuTable.Columns("MenuItem").MaxLength = 100

			TB_CustomMenuTable.Columns.Add("FormName", GetType(System.String))
			TB_CustomMenuTable.Columns("FormName").AllowDBNull = true
			TB_CustomMenuTable.Columns("FormName").ReadOnly = false
			
			TB_CustomMenuTable.Columns("FormName").MaxLength = 100

			TB_CustomMenuTable.PrimaryKey = new DataColumn(){TB_CustomMenuTable.Columns("ID")}
			
			Dim TB_DamageTable as DataTable = ds.Tables.Add("TB_Damage")
			TB_DamageTable.Columns.Add("ID", GetType(System.Guid))
			TB_DamageTable.Columns("ID").AllowDBNull = false
			TB_DamageTable.Columns("ID").ReadOnly = false
			
			TB_DamageTable.Columns.Add("CntrID", GetType(System.Guid))
			TB_DamageTable.Columns("CntrID").AllowDBNull = false
			TB_DamageTable.Columns("CntrID").ReadOnly = false
			
			TB_DamageTable.Columns.Add("ReportDate", GetType(System.DateTime))
			TB_DamageTable.Columns("ReportDate").AllowDBNull = false
			TB_DamageTable.Columns("ReportDate").ReadOnly = false
			
			TB_DamageTable.Columns.Add("Description", GetType(System.String))
			TB_DamageTable.Columns("Description").AllowDBNull = false
			TB_DamageTable.Columns("Description").ReadOnly = false
			
			TB_DamageTable.Columns("Description").MaxLength = 500

			TB_DamageTable.Columns.Add("DamageOn", GetType(System.String))
			TB_DamageTable.Columns("DamageOn").AllowDBNull = true
			TB_DamageTable.Columns("DamageOn").ReadOnly = false
			
			TB_DamageTable.Columns("DamageOn").MaxLength = 20

			TB_DamageTable.Columns.Add("RepairShop", GetType(System.String))
			TB_DamageTable.Columns("RepairShop").AllowDBNull = true
			TB_DamageTable.Columns("RepairShop").ReadOnly = false
			
			TB_DamageTable.Columns("RepairShop").MaxLength = 500

			TB_DamageTable.Columns.Add("StartRepair", GetType(System.DateTime))
			TB_DamageTable.Columns("StartRepair").AllowDBNull = true
			TB_DamageTable.Columns("StartRepair").ReadOnly = false
			
			TB_DamageTable.Columns.Add("FinishedRepair", GetType(System.DateTime))
			TB_DamageTable.Columns("FinishedRepair").AllowDBNull = true
			TB_DamageTable.Columns("FinishedRepair").ReadOnly = false
			
			TB_DamageTable.Columns.Add("RepairCost", GetType(System.Double))
			TB_DamageTable.Columns("RepairCost").AllowDBNull = true
			TB_DamageTable.Columns("RepairCost").ReadOnly = false
			
			TB_DamageTable.Columns.Add("Currency", GetType(System.String))
			TB_DamageTable.Columns("Currency").AllowDBNull = true
			TB_DamageTable.Columns("Currency").ReadOnly = false
			
			TB_DamageTable.Columns("Currency").MaxLength = 20

			TB_DamageTable.Columns.Add("InvoiceTo", GetType(System.Guid))
			TB_DamageTable.Columns("InvoiceTo").AllowDBNull = true
			TB_DamageTable.Columns("InvoiceTo").ReadOnly = false
			
			TB_DamageTable.Columns.Add("InvoiceAmount", GetType(System.Double))
			TB_DamageTable.Columns("InvoiceAmount").AllowDBNull = true
			TB_DamageTable.Columns("InvoiceAmount").ReadOnly = false
			
			TB_DamageTable.Columns.Add("InvCurrency", GetType(System.String))
			TB_DamageTable.Columns("InvCurrency").AllowDBNull = true
			TB_DamageTable.Columns("InvCurrency").ReadOnly = false
			
			TB_DamageTable.Columns("InvCurrency").MaxLength = 20

			TB_DamageTable.PrimaryKey = new DataColumn(){TB_DamageTable.Columns("ID")}
			
			Dim TB_DepositsTable as DataTable = ds.Tables.Add("TB_Deposits")
			TB_DepositsTable.Columns.Add("ID", GetType(System.Guid))
			TB_DepositsTable.Columns("ID").AllowDBNull = false
			TB_DepositsTable.Columns("ID").ReadOnly = false
			
			TB_DepositsTable.Columns.Add("BLID", GetType(System.Guid))
			TB_DepositsTable.Columns("BLID").AllowDBNull = false
			TB_DepositsTable.Columns("BLID").ReadOnly = false
			
			TB_DepositsTable.Columns.Add("ChargesCodes", GetType(System.String))
			TB_DepositsTable.Columns("ChargesCodes").AllowDBNull = true
			TB_DepositsTable.Columns("ChargesCodes").ReadOnly = false
			
			TB_DepositsTable.Columns("ChargesCodes").MaxLength = 20

			TB_DepositsTable.Columns.Add("Remarks", GetType(System.String))
			TB_DepositsTable.Columns("Remarks").AllowDBNull = true
			TB_DepositsTable.Columns("Remarks").ReadOnly = false
			
			TB_DepositsTable.Columns("Remarks").MaxLength = 500

			TB_DepositsTable.Columns.Add("Amount", GetType(System.Double))
			TB_DepositsTable.Columns("Amount").AllowDBNull = true
			TB_DepositsTable.Columns("Amount").ReadOnly = false
			
			TB_DepositsTable.Columns.Add("ReturnBackDate", GetType(System.DateTime))
			TB_DepositsTable.Columns("ReturnBackDate").AllowDBNull = true
			TB_DepositsTable.Columns("ReturnBackDate").ReadOnly = false
			
			TB_DepositsTable.Columns.Add("ReturnBackAmount", GetType(System.Decimal))
			TB_DepositsTable.Columns("ReturnBackAmount").AllowDBNull = true
			TB_DepositsTable.Columns("ReturnBackAmount").ReadOnly = false
			
			TB_DepositsTable.Columns.Add("ReturnBackRef", GetType(System.String))
			TB_DepositsTable.Columns("ReturnBackRef").AllowDBNull = true
			TB_DepositsTable.Columns("ReturnBackRef").ReadOnly = false
			
			TB_DepositsTable.Columns("ReturnBackRef").MaxLength = 25

			TB_DepositsTable.Columns.Add("PaidRef", GetType(System.String))
			TB_DepositsTable.Columns("PaidRef").AllowDBNull = true
			TB_DepositsTable.Columns("PaidRef").ReadOnly = false
			
			TB_DepositsTable.Columns("PaidRef").MaxLength = 50

			TB_DepositsTable.PrimaryKey = new DataColumn(){TB_DepositsTable.Columns("ID")}
			
			Dim TB_DetentionBaseTable as DataTable = ds.Tables.Add("TB_DetentionBase")
			TB_DetentionBaseTable.Columns.Add("ID", GetType(System.Guid))
			TB_DetentionBaseTable.Columns("ID").AllowDBNull = false
			TB_DetentionBaseTable.Columns("ID").ReadOnly = false
			
			TB_DetentionBaseTable.Columns.Add("ImpExp", GetType(System.String))
			TB_DetentionBaseTable.Columns("ImpExp").AllowDBNull = false
			TB_DetentionBaseTable.Columns("ImpExp").ReadOnly = false
			
			TB_DetentionBaseTable.Columns("ImpExp").MaxLength = 20

			TB_DetentionBaseTable.Columns.Add("ApplyDate", GetType(System.DateTime))
			TB_DetentionBaseTable.Columns("ApplyDate").AllowDBNull = false
			TB_DetentionBaseTable.Columns("ApplyDate").ReadOnly = false
			
			TB_DetentionBaseTable.Columns.Add("Validity", GetType(System.DateTime))
			TB_DetentionBaseTable.Columns("Validity").AllowDBNull = false
			TB_DetentionBaseTable.Columns("Validity").ReadOnly = false
			
			TB_DetentionBaseTable.Columns.Add("Remarks", GetType(System.String))
			TB_DetentionBaseTable.Columns("Remarks").AllowDBNull = true
			TB_DetentionBaseTable.Columns("Remarks").ReadOnly = false
			
			TB_DetentionBaseTable.Columns("Remarks").MaxLength = 500

			TB_DetentionBaseTable.Columns.Add("Tax", GetType(System.Decimal))
			TB_DetentionBaseTable.Columns("Tax").AllowDBNull = true
			TB_DetentionBaseTable.Columns("Tax").ReadOnly = false
			
			TB_DetentionBaseTable.Columns.Add("Toll", GetType(System.Decimal))
			TB_DetentionBaseTable.Columns("Toll").AllowDBNull = true
			TB_DetentionBaseTable.Columns("Toll").ReadOnly = false
			
			TB_DetentionBaseTable.Columns.Add("IsBase", GetType(System.String))
			TB_DetentionBaseTable.Columns("IsBase").AllowDBNull = true
			TB_DetentionBaseTable.Columns("IsBase").ReadOnly = false
			
			TB_DetentionBaseTable.Columns("IsBase").MaxLength = 10

			TB_DetentionBaseTable.Columns.Add("Currency", GetType(System.String))
			TB_DetentionBaseTable.Columns("Currency").AllowDBNull = true
			TB_DetentionBaseTable.Columns("Currency").ReadOnly = false
			
			TB_DetentionBaseTable.Columns("Currency").MaxLength = 10

			TB_DetentionBaseTable.Columns.Add("Clause", GetType(System.String))
			TB_DetentionBaseTable.Columns("Clause").AllowDBNull = true
			TB_DetentionBaseTable.Columns("Clause").ReadOnly = false
			
			TB_DetentionBaseTable.Columns("Clause").MaxLength = 510

			TB_DetentionBaseTable.Columns.Add("FClause", GetType(System.String))
			TB_DetentionBaseTable.Columns("FClause").AllowDBNull = true
			TB_DetentionBaseTable.Columns("FClause").ReadOnly = false
			
			TB_DetentionBaseTable.Columns("FClause").MaxLength = 510

			TB_DetentionBaseTable.Columns.Add("Line", GetType(System.String))
			TB_DetentionBaseTable.Columns("Line").AllowDBNull = true
			TB_DetentionBaseTable.Columns("Line").ReadOnly = false
			
			TB_DetentionBaseTable.Columns("Line").MaxLength = 10

			TB_DetentionBaseTable.PrimaryKey = new DataColumn(){TB_DetentionBaseTable.Columns("ID")}
			
			Dim TB_DetentionBaseDetailsTable as DataTable = ds.Tables.Add("TB_DetentionBaseDetails")
			TB_DetentionBaseDetailsTable.Columns.Add("ID", GetType(System.Guid))
			TB_DetentionBaseDetailsTable.Columns("ID").AllowDBNull = false
			TB_DetentionBaseDetailsTable.Columns("ID").ReadOnly = false
			
			TB_DetentionBaseDetailsTable.Columns.Add("BaseID", GetType(System.Guid))
			TB_DetentionBaseDetailsTable.Columns("BaseID").AllowDBNull = false
			TB_DetentionBaseDetailsTable.Columns("BaseID").ReadOnly = false
			
			TB_DetentionBaseDetailsTable.Columns.Add("CnType", GetType(System.String))
			TB_DetentionBaseDetailsTable.Columns("CnType").AllowDBNull = false
			TB_DetentionBaseDetailsTable.Columns("CnType").ReadOnly = false
			
			TB_DetentionBaseDetailsTable.Columns("CnType").MaxLength = 20

			TB_DetentionBaseDetailsTable.Columns.Add("DayFrom", GetType(System.Int16))
			TB_DetentionBaseDetailsTable.Columns("DayFrom").AllowDBNull = false
			TB_DetentionBaseDetailsTable.Columns("DayFrom").ReadOnly = false
			
			TB_DetentionBaseDetailsTable.Columns.Add("DayTo", GetType(System.Int16))
			TB_DetentionBaseDetailsTable.Columns("DayTo").AllowDBNull = false
			TB_DetentionBaseDetailsTable.Columns("DayTo").ReadOnly = false
			
			TB_DetentionBaseDetailsTable.Columns.Add("Amount20", GetType(System.Double))
			TB_DetentionBaseDetailsTable.Columns("Amount20").AllowDBNull = false
			TB_DetentionBaseDetailsTable.Columns("Amount20").ReadOnly = false
			
			TB_DetentionBaseDetailsTable.Columns.Add("Amount40", GetType(System.Double))
			TB_DetentionBaseDetailsTable.Columns("Amount40").AllowDBNull = false
			TB_DetentionBaseDetailsTable.Columns("Amount40").ReadOnly = false
			
			TB_DetentionBaseDetailsTable.Columns.Add("Amount45", GetType(System.Double))
			TB_DetentionBaseDetailsTable.Columns("Amount45").AllowDBNull = false
			TB_DetentionBaseDetailsTable.Columns("Amount45").ReadOnly = false
			
			TB_DetentionBaseDetailsTable.PrimaryKey = new DataColumn(){TB_DetentionBaseDetailsTable.Columns("ID")}
			
			Dim TB_DocumetsTable as DataTable = ds.Tables.Add("TB_Documets")
			TB_DocumetsTable.Columns.Add("ID", GetType(System.Guid))
			TB_DocumetsTable.Columns("ID").AllowDBNull = false
			TB_DocumetsTable.Columns("ID").ReadOnly = false
			
			TB_DocumetsTable.Columns.Add("LineCode", GetType(System.String))
			TB_DocumetsTable.Columns("LineCode").AllowDBNull = false
			TB_DocumetsTable.Columns("LineCode").ReadOnly = false
			
			TB_DocumetsTable.Columns("LineCode").MaxLength = 20

			TB_DocumetsTable.Columns.Add("DocumentType", GetType(System.String))
			TB_DocumetsTable.Columns("DocumentType").AllowDBNull = false
			TB_DocumetsTable.Columns("DocumentType").ReadOnly = false
			
			TB_DocumetsTable.Columns("DocumentType").MaxLength = 20

			TB_DocumetsTable.Columns.Add("Remarks", GetType(System.String))
			TB_DocumetsTable.Columns("Remarks").AllowDBNull = true
			TB_DocumetsTable.Columns("Remarks").ReadOnly = false
			
			TB_DocumetsTable.Columns("Remarks").MaxLength = 500

			TB_DocumetsTable.Columns.Add("FreeDocument", GetType(System.String))
			TB_DocumetsTable.Columns("FreeDocument").AllowDBNull = true
			TB_DocumetsTable.Columns("FreeDocument").ReadOnly = false
			
			TB_DocumetsTable.Columns.Add("PaperSize", GetType(System.String))
			TB_DocumetsTable.Columns("PaperSize").AllowDBNull = true
			TB_DocumetsTable.Columns("PaperSize").ReadOnly = false
			
			TB_DocumetsTable.Columns("PaperSize").MaxLength = 100

			TB_DocumetsTable.PrimaryKey = new DataColumn(){TB_DocumetsTable.Columns("ID")}
			
			Dim TB_DocumetsDetailTable as DataTable = ds.Tables.Add("TB_DocumetsDetail")
			TB_DocumetsDetailTable.Columns.Add("ID", GetType(System.Guid))
			TB_DocumetsDetailTable.Columns("ID").AllowDBNull = false
			TB_DocumetsDetailTable.Columns("ID").ReadOnly = false
			
			TB_DocumetsDetailTable.Columns.Add("DocumentID", GetType(System.Guid))
			TB_DocumetsDetailTable.Columns("DocumentID").AllowDBNull = false
			TB_DocumetsDetailTable.Columns("DocumentID").ReadOnly = false
			
			TB_DocumetsDetailTable.Columns.Add("FieldDescription", GetType(System.String))
			TB_DocumetsDetailTable.Columns("FieldDescription").AllowDBNull = false
			TB_DocumetsDetailTable.Columns("FieldDescription").ReadOnly = false
			
			TB_DocumetsDetailTable.Columns("FieldDescription").MaxLength = 500

			TB_DocumetsDetailTable.Columns.Add("FieldName", GetType(System.String))
			TB_DocumetsDetailTable.Columns("FieldName").AllowDBNull = false
			TB_DocumetsDetailTable.Columns("FieldName").ReadOnly = false
			
			TB_DocumetsDetailTable.Columns("FieldName").MaxLength = 500

			TB_DocumetsDetailTable.Columns.Add("Visible", GetType(System.Boolean))
			TB_DocumetsDetailTable.Columns("Visible").AllowDBNull = false
			TB_DocumetsDetailTable.Columns("Visible").ReadOnly = false
			
			TB_DocumetsDetailTable.Columns.Add("nTop", GetType(System.Single))
			TB_DocumetsDetailTable.Columns("nTop").AllowDBNull = false
			TB_DocumetsDetailTable.Columns("nTop").ReadOnly = false
			
			TB_DocumetsDetailTable.Columns.Add("nLeft", GetType(System.Single))
			TB_DocumetsDetailTable.Columns("nLeft").AllowDBNull = false
			TB_DocumetsDetailTable.Columns("nLeft").ReadOnly = false
			
			TB_DocumetsDetailTable.Columns.Add("nHight", GetType(System.Single))
			TB_DocumetsDetailTable.Columns("nHight").AllowDBNull = false
			TB_DocumetsDetailTable.Columns("nHight").ReadOnly = false
			
			TB_DocumetsDetailTable.Columns.Add("nWidth", GetType(System.Single))
			TB_DocumetsDetailTable.Columns("nWidth").AllowDBNull = false
			TB_DocumetsDetailTable.Columns("nWidth").ReadOnly = false
			
			TB_DocumetsDetailTable.Columns.Add("FontName", GetType(System.String))
			TB_DocumetsDetailTable.Columns("FontName").AllowDBNull = true
			TB_DocumetsDetailTable.Columns("FontName").ReadOnly = false
			
			TB_DocumetsDetailTable.Columns("FontName").MaxLength = 100

			TB_DocumetsDetailTable.Columns.Add("FontSize", GetType(System.Double))
			TB_DocumetsDetailTable.Columns("FontSize").AllowDBNull = true
			TB_DocumetsDetailTable.Columns("FontSize").ReadOnly = false
			
			TB_DocumetsDetailTable.Columns.Add("FontItalic", GetType(System.Boolean))
			TB_DocumetsDetailTable.Columns("FontItalic").AllowDBNull = true
			TB_DocumetsDetailTable.Columns("FontItalic").ReadOnly = false
			
			TB_DocumetsDetailTable.Columns.Add("FontUnderLine", GetType(System.Boolean))
			TB_DocumetsDetailTable.Columns("FontUnderLine").AllowDBNull = true
			TB_DocumetsDetailTable.Columns("FontUnderLine").ReadOnly = false
			
			TB_DocumetsDetailTable.Columns.Add("FontBold", GetType(System.Boolean))
			TB_DocumetsDetailTable.Columns("FontBold").AllowDBNull = true
			TB_DocumetsDetailTable.Columns("FontBold").ReadOnly = false
			
			TB_DocumetsDetailTable.Columns.Add("FontStrickOut", GetType(System.Boolean))
			TB_DocumetsDetailTable.Columns("FontStrickOut").AllowDBNull = true
			TB_DocumetsDetailTable.Columns("FontStrickOut").ReadOnly = false
			
			TB_DocumetsDetailTable.PrimaryKey = new DataColumn(){TB_DocumetsDetailTable.Columns("ID")}
			
			Dim TB_EcsContainersTable as DataTable = ds.Tables.Add("TB_EcsContainers")
			TB_EcsContainersTable.Columns.Add("ID", GetType(System.Guid))
			TB_EcsContainersTable.Columns("ID").AllowDBNull = false
			TB_EcsContainersTable.Columns("ID").ReadOnly = false
			
			TB_EcsContainersTable.Columns.Add("Line", GetType(System.String))
			TB_EcsContainersTable.Columns("Line").AllowDBNull = false
			TB_EcsContainersTable.Columns("Line").ReadOnly = false
			
			TB_EcsContainersTable.Columns("Line").MaxLength = 20

			TB_EcsContainersTable.Columns.Add("InVoyageID", GetType(System.Guid))
			TB_EcsContainersTable.Columns("InVoyageID").AllowDBNull = false
			TB_EcsContainersTable.Columns("InVoyageID").ReadOnly = false
			
			TB_EcsContainersTable.Columns.Add("CntrNo", GetType(System.String))
			TB_EcsContainersTable.Columns("CntrNo").AllowDBNull = false
			TB_EcsContainersTable.Columns("CntrNo").ReadOnly = false
			
			TB_EcsContainersTable.Columns("CntrNo").MaxLength = 24

			TB_EcsContainersTable.Columns.Add("CnSize", GetType(System.String))
			TB_EcsContainersTable.Columns("CnSize").AllowDBNull = false
			TB_EcsContainersTable.Columns("CnSize").ReadOnly = false
			
			TB_EcsContainersTable.Columns("CnSize").MaxLength = 20

			TB_EcsContainersTable.Columns.Add("CnType", GetType(System.String))
			TB_EcsContainersTable.Columns("CnType").AllowDBNull = false
			TB_EcsContainersTable.Columns("CnType").ReadOnly = false
			
			TB_EcsContainersTable.Columns("CnType").MaxLength = 20

			TB_EcsContainersTable.Columns.Add("DischargeTo", GetType(System.String))
			TB_EcsContainersTable.Columns("DischargeTo").AllowDBNull = false
			TB_EcsContainersTable.Columns("DischargeTo").ReadOnly = false
			
			TB_EcsContainersTable.Columns("DischargeTo").MaxLength = 10

			TB_EcsContainersTable.Columns.Add("InStatus", GetType(System.String))
			TB_EcsContainersTable.Columns("InStatus").AllowDBNull = false
			TB_EcsContainersTable.Columns("InStatus").ReadOnly = false
			
			TB_EcsContainersTable.Columns("InStatus").MaxLength = 20

			TB_EcsContainersTable.Columns.Add("InCellNo", GetType(System.String))
			TB_EcsContainersTable.Columns("InCellNo").AllowDBNull = true
			TB_EcsContainersTable.Columns("InCellNo").ReadOnly = false
			
			TB_EcsContainersTable.Columns("InCellNo").MaxLength = 12

			TB_EcsContainersTable.Columns.Add("BookingID", GetType(System.Guid))
			TB_EcsContainersTable.Columns("BookingID").AllowDBNull = true
			TB_EcsContainersTable.Columns("BookingID").ReadOnly = false
			
			TB_EcsContainersTable.Columns.Add("OutVoyageID", GetType(System.Guid))
			TB_EcsContainersTable.Columns("OutVoyageID").AllowDBNull = true
			TB_EcsContainersTable.Columns("OutVoyageID").ReadOnly = false
			
			TB_EcsContainersTable.Columns.Add("OutStatus", GetType(System.String))
			TB_EcsContainersTable.Columns("OutStatus").AllowDBNull = true
			TB_EcsContainersTable.Columns("OutStatus").ReadOnly = false
			
			TB_EcsContainersTable.Columns("OutStatus").MaxLength = 20

			TB_EcsContainersTable.Columns.Add("OutCellNo", GetType(System.String))
			TB_EcsContainersTable.Columns("OutCellNo").AllowDBNull = true
			TB_EcsContainersTable.Columns("OutCellNo").ReadOnly = false
			
			TB_EcsContainersTable.Columns("OutCellNo").MaxLength = 12

			TB_EcsContainersTable.Columns.Add("ReturnTo", GetType(System.String))
			TB_EcsContainersTable.Columns("ReturnTo").AllowDBNull = true
			TB_EcsContainersTable.Columns("ReturnTo").ReadOnly = false
			
			TB_EcsContainersTable.Columns("ReturnTo").MaxLength = 10

			TB_EcsContainersTable.Columns.Add("Destination", GetType(System.String))
			TB_EcsContainersTable.Columns("Destination").AllowDBNull = true
			TB_EcsContainersTable.Columns("Destination").ReadOnly = false
			
			TB_EcsContainersTable.Columns("Destination").MaxLength = 10

			TB_EcsContainersTable.Columns.Add("LastDepot", GetType(System.String))
			TB_EcsContainersTable.Columns("LastDepot").AllowDBNull = true
			TB_EcsContainersTable.Columns("LastDepot").ReadOnly = false
			
			TB_EcsContainersTable.Columns("LastDepot").MaxLength = 20

			TB_EcsContainersTable.Columns.Add("LastStatus", GetType(System.String))
			TB_EcsContainersTable.Columns("LastStatus").AllowDBNull = true
			TB_EcsContainersTable.Columns("LastStatus").ReadOnly = false
			
			TB_EcsContainersTable.Columns("LastStatus").MaxLength = 20

			TB_EcsContainersTable.Columns.Add("LastStatusDate", GetType(System.DateTime))
			TB_EcsContainersTable.Columns("LastStatusDate").AllowDBNull = true
			TB_EcsContainersTable.Columns("LastStatusDate").ReadOnly = false
			
			TB_EcsContainersTable.Columns.Add("IsTerminate", GetType(System.Boolean))
			TB_EcsContainersTable.Columns("IsTerminate").AllowDBNull = false
			TB_EcsContainersTable.Columns("IsTerminate").ReadOnly = false
			
			TB_EcsContainersTable.Columns.Add("ExportPermit", GetType(System.String))
			TB_EcsContainersTable.Columns("ExportPermit").AllowDBNull = true
			TB_EcsContainersTable.Columns("ExportPermit").ReadOnly = false
			
			TB_EcsContainersTable.Columns("ExportPermit").MaxLength = 20

			TB_EcsContainersTable.Columns.Add("InDjwazNo", GetType(System.String))
			TB_EcsContainersTable.Columns("InDjwazNo").AllowDBNull = true
			TB_EcsContainersTable.Columns("InDjwazNo").ReadOnly = false
			
			TB_EcsContainersTable.Columns("InDjwazNo").MaxLength = 20

			TB_EcsContainersTable.Columns.Add("SOC", GetType(System.String))
			TB_EcsContainersTable.Columns("SOC").AllowDBNull = true
			TB_EcsContainersTable.Columns("SOC").ReadOnly = false
			
			TB_EcsContainersTable.Columns("SOC").MaxLength = 20

			TB_EcsContainersTable.Columns.Add("SpecialOpr", GetType(System.String))
			TB_EcsContainersTable.Columns("SpecialOpr").AllowDBNull = true
			TB_EcsContainersTable.Columns("SpecialOpr").ReadOnly = false
			
			TB_EcsContainersTable.Columns("SpecialOpr").MaxLength = 10

			TB_EcsContainersTable.PrimaryKey = new DataColumn(){TB_EcsContainersTable.Columns("ID")}
			
			Dim TB_EcsMovesTable as DataTable = ds.Tables.Add("TB_EcsMoves")
			TB_EcsMovesTable.Columns.Add("ID", GetType(System.Guid))
			TB_EcsMovesTable.Columns("ID").AllowDBNull = false
			TB_EcsMovesTable.Columns("ID").ReadOnly = false
			
			TB_EcsMovesTable.Columns.Add("CntrID", GetType(System.Guid))
			TB_EcsMovesTable.Columns("CntrID").AllowDBNull = false
			TB_EcsMovesTable.Columns("CntrID").ReadOnly = false
			
			TB_EcsMovesTable.Columns.Add("Status", GetType(System.String))
			TB_EcsMovesTable.Columns("Status").AllowDBNull = true
			TB_EcsMovesTable.Columns("Status").ReadOnly = false
			
			TB_EcsMovesTable.Columns("Status").MaxLength = 20

			TB_EcsMovesTable.Columns.Add("StatusDate", GetType(System.DateTime))
			TB_EcsMovesTable.Columns("StatusDate").AllowDBNull = true
			TB_EcsMovesTable.Columns("StatusDate").ReadOnly = false
			
			TB_EcsMovesTable.Columns.Add("StatusDateToLine", GetType(System.DateTime))
			TB_EcsMovesTable.Columns("StatusDateToLine").AllowDBNull = true
			TB_EcsMovesTable.Columns("StatusDateToLine").ReadOnly = false
			
			TB_EcsMovesTable.Columns.Add("Depot", GetType(System.String))
			TB_EcsMovesTable.Columns("Depot").AllowDBNull = true
			TB_EcsMovesTable.Columns("Depot").ReadOnly = false
			
			TB_EcsMovesTable.Columns("Depot").MaxLength = 20

			TB_EcsMovesTable.Columns.Add("Remarks", GetType(System.String))
			TB_EcsMovesTable.Columns("Remarks").AllowDBNull = true
			TB_EcsMovesTable.Columns("Remarks").ReadOnly = false
			
			TB_EcsMovesTable.Columns("Remarks").MaxLength = 500

			TB_EcsMovesTable.Columns.Add("IsReported", GetType(System.Boolean))
			TB_EcsMovesTable.Columns("IsReported").AllowDBNull = true
			TB_EcsMovesTable.Columns("IsReported").ReadOnly = false
			
			TB_EcsMovesTable.PrimaryKey = new DataColumn(){TB_EcsMovesTable.Columns("ID")}
			
			Dim TB_EcsReserveContainersTable as DataTable = ds.Tables.Add("TB_EcsReserveContainers")
			TB_EcsReserveContainersTable.Columns.Add("ID", GetType(System.Guid))
			TB_EcsReserveContainersTable.Columns("ID").AllowDBNull = false
			TB_EcsReserveContainersTable.Columns("ID").ReadOnly = false
			
			TB_EcsReserveContainersTable.Columns.Add("CntrNo", GetType(System.String))
			TB_EcsReserveContainersTable.Columns("CntrNo").AllowDBNull = false
			TB_EcsReserveContainersTable.Columns("CntrNo").ReadOnly = false
			
			TB_EcsReserveContainersTable.Columns("CntrNo").MaxLength = 11

			TB_EcsReserveContainersTable.PrimaryKey = new DataColumn(){TB_EcsReserveContainersTable.Columns("ID")}
			
			Dim TB_EventMailTable as DataTable = ds.Tables.Add("TB_EventMail")
			TB_EventMailTable.Columns.Add("ID", GetType(System.Guid))
			TB_EventMailTable.Columns("ID").AllowDBNull = false
			TB_EventMailTable.Columns("ID").ReadOnly = false
			
			TB_EventMailTable.Columns.Add("EventCode", GetType(System.String))
			TB_EventMailTable.Columns("EventCode").AllowDBNull = false
			TB_EventMailTable.Columns("EventCode").ReadOnly = false
			
			TB_EventMailTable.Columns("EventCode").MaxLength = 10

			TB_EventMailTable.Columns.Add("MailTo", GetType(System.String))
			TB_EventMailTable.Columns("MailTo").AllowDBNull = true
			TB_EventMailTable.Columns("MailTo").ReadOnly = false
			
			TB_EventMailTable.Columns.Add("MailCC", GetType(System.String))
			TB_EventMailTable.Columns("MailCC").AllowDBNull = true
			TB_EventMailTable.Columns("MailCC").ReadOnly = false
			
			TB_EventMailTable.Columns.Add("MailBCC", GetType(System.String))
			TB_EventMailTable.Columns("MailBCC").AllowDBNull = true
			TB_EventMailTable.Columns("MailBCC").ReadOnly = false
			
			TB_EventMailTable.Columns.Add("PORT", GetType(System.String))
			TB_EventMailTable.Columns("PORT").AllowDBNull = true
			TB_EventMailTable.Columns("PORT").ReadOnly = false
			
			TB_EventMailTable.Columns("PORT").MaxLength = 5

			TB_EventMailTable.Columns.Add("HTMLContent", GetType(System.String))
			TB_EventMailTable.Columns("HTMLContent").AllowDBNull = true
			TB_EventMailTable.Columns("HTMLContent").ReadOnly = false
			
			TB_EventMailTable.Columns("HTMLContent").MaxLength = 8000

			TB_EventMailTable.PrimaryKey = new DataColumn(){TB_EventMailTable.Columns("ID")}
			
			Dim TB_ExchangeTable as DataTable = ds.Tables.Add("TB_Exchange")
			TB_ExchangeTable.Columns.Add("ID", GetType(System.Guid))
			TB_ExchangeTable.Columns("ID").AllowDBNull = false
			TB_ExchangeTable.Columns("ID").ReadOnly = false
			
			TB_ExchangeTable.Columns.Add("ExchangeDate", GetType(System.DateTime))
			TB_ExchangeTable.Columns("ExchangeDate").AllowDBNull = false
			TB_ExchangeTable.Columns("ExchangeDate").ReadOnly = false
			
			TB_ExchangeTable.PrimaryKey = new DataColumn(){TB_ExchangeTable.Columns("ID")}
			
			Dim TB_ExchangeDetailsTable as DataTable = ds.Tables.Add("TB_ExchangeDetails")
			TB_ExchangeDetailsTable.Columns.Add("ID", GetType(System.Guid))
			TB_ExchangeDetailsTable.Columns("ID").AllowDBNull = false
			TB_ExchangeDetailsTable.Columns("ID").ReadOnly = false
			
			TB_ExchangeDetailsTable.Columns.Add("MasterID", GetType(System.Guid))
			TB_ExchangeDetailsTable.Columns("MasterID").AllowDBNull = false
			TB_ExchangeDetailsTable.Columns("MasterID").ReadOnly = false
			
			TB_ExchangeDetailsTable.Columns.Add("CurCode", GetType(System.String))
			TB_ExchangeDetailsTable.Columns("CurCode").AllowDBNull = false
			TB_ExchangeDetailsTable.Columns("CurCode").ReadOnly = false
			
			TB_ExchangeDetailsTable.Columns("CurCode").MaxLength = 10

			TB_ExchangeDetailsTable.Columns.Add("THCRate", GetType(System.Decimal))
			TB_ExchangeDetailsTable.Columns("THCRate").AllowDBNull = false
			TB_ExchangeDetailsTable.Columns("THCRate").ReadOnly = false
			
			TB_ExchangeDetailsTable.Columns.Add("FRTRate", GetType(System.Decimal))
			TB_ExchangeDetailsTable.Columns("FRTRate").AllowDBNull = false
            TB_ExchangeDetailsTable.Columns("FRTRate").ReadOnly = False

            TB_ExchangeDetailsTable.Columns.Add("DETNRate", GetType(System.Decimal))
            TB_ExchangeDetailsTable.Columns("DETNRate").AllowDBNull = False
            TB_ExchangeDetailsTable.Columns("DETNRate").ReadOnly = False
			
			TB_ExchangeDetailsTable.PrimaryKey = new DataColumn(){TB_ExchangeDetailsTable.Columns("ID")}
			
			Dim TB_ExpInvoiceTable as DataTable = ds.Tables.Add("TB_ExpInvoice")
			TB_ExpInvoiceTable.Columns.Add("ID", GetType(System.Guid))
			TB_ExpInvoiceTable.Columns("ID").AllowDBNull = false
			TB_ExpInvoiceTable.Columns("ID").ReadOnly = false
			
			TB_ExpInvoiceTable.Columns.Add("BLID", GetType(System.Guid))
			TB_ExpInvoiceTable.Columns("BLID").AllowDBNull = false
			TB_ExpInvoiceTable.Columns("BLID").ReadOnly = false
			
			TB_ExpInvoiceTable.Columns.Add("InvoiceNo", GetType(System.String))
			TB_ExpInvoiceTable.Columns("InvoiceNo").AllowDBNull = true
			TB_ExpInvoiceTable.Columns("InvoiceNo").ReadOnly = false
			
			TB_ExpInvoiceTable.Columns("InvoiceNo").MaxLength = 20

			TB_ExpInvoiceTable.Columns.Add("Description", GetType(System.String))
			TB_ExpInvoiceTable.Columns("Description").AllowDBNull = false
			TB_ExpInvoiceTable.Columns("Description").ReadOnly = false
			
			TB_ExpInvoiceTable.Columns("Description").MaxLength = 500

			TB_ExpInvoiceTable.Columns.Add("IssueTime", GetType(System.DateTime))
			TB_ExpInvoiceTable.Columns("IssueTime").AllowDBNull = true
			TB_ExpInvoiceTable.Columns("IssueTime").ReadOnly = false
			
			TB_ExpInvoiceTable.Columns.Add("IssueBy", GetType(System.String))
			TB_ExpInvoiceTable.Columns("IssueBy").AllowDBNull = true
			TB_ExpInvoiceTable.Columns("IssueBy").ReadOnly = false
			
			TB_ExpInvoiceTable.Columns("IssueBy").MaxLength = 30

			TB_ExpInvoiceTable.Columns.Add("ConfirmTime", GetType(System.DateTime))
			TB_ExpInvoiceTable.Columns("ConfirmTime").AllowDBNull = true
			TB_ExpInvoiceTable.Columns("ConfirmTime").ReadOnly = false
			
			TB_ExpInvoiceTable.Columns.Add("ConfirmBy", GetType(System.String))
			TB_ExpInvoiceTable.Columns("ConfirmBy").AllowDBNull = true
			TB_ExpInvoiceTable.Columns("ConfirmBy").ReadOnly = false
			
			TB_ExpInvoiceTable.Columns("ConfirmBy").MaxLength = 30

			TB_ExpInvoiceTable.Columns.Add("Status", GetType(System.String))
			TB_ExpInvoiceTable.Columns("Status").AllowDBNull = true
			TB_ExpInvoiceTable.Columns("Status").ReadOnly = false
			
			TB_ExpInvoiceTable.Columns("Status").MaxLength = 20

			TB_ExpInvoiceTable.Columns.Add("IssueOffice", GetType(System.String))
			TB_ExpInvoiceTable.Columns("IssueOffice").AllowDBNull = true
			TB_ExpInvoiceTable.Columns("IssueOffice").ReadOnly = false
			
			TB_ExpInvoiceTable.Columns("IssueOffice").MaxLength = 20

			TB_ExpInvoiceTable.Columns.Add("ConfirmOffice", GetType(System.String))
			TB_ExpInvoiceTable.Columns("ConfirmOffice").AllowDBNull = true
			TB_ExpInvoiceTable.Columns("ConfirmOffice").ReadOnly = false
			
			TB_ExpInvoiceTable.Columns("ConfirmOffice").MaxLength = 20

			TB_ExpInvoiceTable.PrimaryKey = new DataColumn(){TB_ExpInvoiceTable.Columns("ID")}
			
			Dim TB_ExpInvoiceDetailsTable as DataTable = ds.Tables.Add("TB_ExpInvoiceDetails")
			TB_ExpInvoiceDetailsTable.Columns.Add("ID", GetType(System.Guid))
			TB_ExpInvoiceDetailsTable.Columns("ID").AllowDBNull = false
			TB_ExpInvoiceDetailsTable.Columns("ID").ReadOnly = false
			
			TB_ExpInvoiceDetailsTable.Columns.Add("InvoiceID", GetType(System.Guid))
			TB_ExpInvoiceDetailsTable.Columns("InvoiceID").AllowDBNull = false
			TB_ExpInvoiceDetailsTable.Columns("InvoiceID").ReadOnly = false
			
			TB_ExpInvoiceDetailsTable.Columns.Add("Seq", GetType(System.Int16))
			TB_ExpInvoiceDetailsTable.Columns("Seq").AllowDBNull = false
			TB_ExpInvoiceDetailsTable.Columns("Seq").ReadOnly = false
			
			TB_ExpInvoiceDetailsTable.Columns.Add("Remarks", GetType(System.String))
			TB_ExpInvoiceDetailsTable.Columns("Remarks").AllowDBNull = true
			TB_ExpInvoiceDetailsTable.Columns("Remarks").ReadOnly = false
			
			TB_ExpInvoiceDetailsTable.Columns("Remarks").MaxLength = 500

			TB_ExpInvoiceDetailsTable.Columns.Add("ChargesCode", GetType(System.String))
			TB_ExpInvoiceDetailsTable.Columns("ChargesCode").AllowDBNull = false
			TB_ExpInvoiceDetailsTable.Columns("ChargesCode").ReadOnly = false
			
			TB_ExpInvoiceDetailsTable.Columns("ChargesCode").MaxLength = 20

			TB_ExpInvoiceDetailsTable.Columns.Add("Currency", GetType(System.String))
			TB_ExpInvoiceDetailsTable.Columns("Currency").AllowDBNull = false
			TB_ExpInvoiceDetailsTable.Columns("Currency").ReadOnly = false
			
			TB_ExpInvoiceDetailsTable.Columns("Currency").MaxLength = 20

			TB_ExpInvoiceDetailsTable.Columns.Add("Amount", GetType(System.Double))
			TB_ExpInvoiceDetailsTable.Columns("Amount").AllowDBNull = false
			TB_ExpInvoiceDetailsTable.Columns("Amount").ReadOnly = false
			
			TB_ExpInvoiceDetailsTable.Columns.Add("IRRAmount", GetType(System.Double))
			TB_ExpInvoiceDetailsTable.Columns("IRRAmount").AllowDBNull = false
			TB_ExpInvoiceDetailsTable.Columns("IRRAmount").ReadOnly = false
			
			TB_ExpInvoiceDetailsTable.PrimaryKey = new DataColumn(){TB_ExpInvoiceDetailsTable.Columns("ID")}
			
			Dim TB_ExpRecivedItemsTable as DataTable = ds.Tables.Add("TB_ExpRecivedItems")
			TB_ExpRecivedItemsTable.Columns.Add("ID", GetType(System.Guid))
			TB_ExpRecivedItemsTable.Columns("ID").AllowDBNull = false
			TB_ExpRecivedItemsTable.Columns("ID").ReadOnly = false
			
			TB_ExpRecivedItemsTable.Columns.Add("InvoiceID", GetType(System.Guid))
			TB_ExpRecivedItemsTable.Columns("InvoiceID").AllowDBNull = false
			TB_ExpRecivedItemsTable.Columns("InvoiceID").ReadOnly = false
			
			TB_ExpRecivedItemsTable.Columns.Add("Seq", GetType(System.Int16))
			TB_ExpRecivedItemsTable.Columns("Seq").AllowDBNull = false
			TB_ExpRecivedItemsTable.Columns("Seq").ReadOnly = false
			
			TB_ExpRecivedItemsTable.Columns.Add("Description", GetType(System.String))
			TB_ExpRecivedItemsTable.Columns("Description").AllowDBNull = true
			TB_ExpRecivedItemsTable.Columns("Description").ReadOnly = false
			
			TB_ExpRecivedItemsTable.Columns("Description").MaxLength = 500

			TB_ExpRecivedItemsTable.Columns.Add("PaymentType", GetType(System.String))
			TB_ExpRecivedItemsTable.Columns("PaymentType").AllowDBNull = false
			TB_ExpRecivedItemsTable.Columns("PaymentType").ReadOnly = false
			
			TB_ExpRecivedItemsTable.Columns("PaymentType").MaxLength = 20

			TB_ExpRecivedItemsTable.Columns.Add("Bank", GetType(System.String))
			TB_ExpRecivedItemsTable.Columns("Bank").AllowDBNull = true
			TB_ExpRecivedItemsTable.Columns("Bank").ReadOnly = false
			
			TB_ExpRecivedItemsTable.Columns("Bank").MaxLength = 20

			TB_ExpRecivedItemsTable.Columns.Add("Currency", GetType(System.String))
			TB_ExpRecivedItemsTable.Columns("Currency").AllowDBNull = false
			TB_ExpRecivedItemsTable.Columns("Currency").ReadOnly = false
			
			TB_ExpRecivedItemsTable.Columns("Currency").MaxLength = 20

			TB_ExpRecivedItemsTable.Columns.Add("Amount", GetType(System.Double))
			TB_ExpRecivedItemsTable.Columns("Amount").AllowDBNull = false
			TB_ExpRecivedItemsTable.Columns("Amount").ReadOnly = false
			
			TB_ExpRecivedItemsTable.Columns.Add("IrrAmount", GetType(System.Int64))
			TB_ExpRecivedItemsTable.Columns("IrrAmount").AllowDBNull = true
			TB_ExpRecivedItemsTable.Columns("IrrAmount").ReadOnly = false
			
			TB_ExpRecivedItemsTable.Columns.Add("PaidDate", GetType(System.String))
			TB_ExpRecivedItemsTable.Columns("PaidDate").AllowDBNull = true
			TB_ExpRecivedItemsTable.Columns("PaidDate").ReadOnly = false
			
			TB_ExpRecivedItemsTable.Columns("PaidDate").MaxLength = 10

			TB_ExpRecivedItemsTable.Columns.Add("PaidRef", GetType(System.String))
			TB_ExpRecivedItemsTable.Columns("PaidRef").AllowDBNull = true
			TB_ExpRecivedItemsTable.Columns("PaidRef").ReadOnly = false
			
			TB_ExpRecivedItemsTable.Columns("PaidRef").MaxLength = 15

			TB_ExpRecivedItemsTable.Columns.Add("ReceivedType", GetType(System.String))
			TB_ExpRecivedItemsTable.Columns("ReceivedType").AllowDBNull = true
			TB_ExpRecivedItemsTable.Columns("ReceivedType").ReadOnly = false
			
			TB_ExpRecivedItemsTable.Columns("ReceivedType").MaxLength = 10

			TB_ExpRecivedItemsTable.PrimaryKey = new DataColumn(){TB_ExpRecivedItemsTable.Columns("ID")}
			
			Dim TB_FaxActionsTable as DataTable = ds.Tables.Add("TB_FaxActions")
			TB_FaxActionsTable.Columns.Add("ID", GetType(System.Guid))
			TB_FaxActionsTable.Columns("ID").AllowDBNull = false
			TB_FaxActionsTable.Columns("ID").ReadOnly = false
			
			TB_FaxActionsTable.Columns.Add("DocumentCode", GetType(System.String))
			TB_FaxActionsTable.Columns("DocumentCode").AllowDBNull = false
			TB_FaxActionsTable.Columns("DocumentCode").ReadOnly = false
			
			TB_FaxActionsTable.Columns("DocumentCode").MaxLength = 100

			TB_FaxActionsTable.Columns.Add("Description", GetType(System.String))
			TB_FaxActionsTable.Columns("Description").AllowDBNull = true
			TB_FaxActionsTable.Columns("Description").ReadOnly = false
			
			TB_FaxActionsTable.Columns("Description").MaxLength = 100

			TB_FaxActionsTable.Columns.Add("DefualtFaxLine", GetType(System.String))
			TB_FaxActionsTable.Columns("DefualtFaxLine").AllowDBNull = true
			TB_FaxActionsTable.Columns("DefualtFaxLine").ReadOnly = false
			
			TB_FaxActionsTable.Columns("DefualtFaxLine").MaxLength = 20

			TB_FaxActionsTable.Columns.Add("RecipiantAsTo", GetType(System.String))
			TB_FaxActionsTable.Columns("RecipiantAsTo").AllowDBNull = true
			TB_FaxActionsTable.Columns("RecipiantAsTo").ReadOnly = false
			
			TB_FaxActionsTable.Columns.Add("RecipiantAsCC", GetType(System.String))
			TB_FaxActionsTable.Columns("RecipiantAsCC").AllowDBNull = true
			TB_FaxActionsTable.Columns("RecipiantAsCC").ReadOnly = false
			
			TB_FaxActionsTable.Columns.Add("IsInAction", GetType(System.Boolean))
			TB_FaxActionsTable.Columns("IsInAction").AllowDBNull = true
			TB_FaxActionsTable.Columns("IsInAction").ReadOnly = false
			
			TB_FaxActionsTable.Columns.Add("ActionID", GetType(System.Guid))
			TB_FaxActionsTable.Columns("ActionID").AllowDBNull = true
			TB_FaxActionsTable.Columns("ActionID").ReadOnly = false
			
			TB_FaxActionsTable.Columns.Add("LastActionTime", GetType(System.DateTime))
			TB_FaxActionsTable.Columns("LastActionTime").AllowDBNull = true
			TB_FaxActionsTable.Columns("LastActionTime").ReadOnly = false
			
			TB_FaxActionsTable.PrimaryKey = new DataColumn(){TB_FaxActionsTable.Columns("ID")}
			
			Dim TB_FaxStatusTable as DataTable = ds.Tables.Add("TB_FaxStatus")
			TB_FaxStatusTable.Columns.Add("ID", GetType(System.Guid))
			TB_FaxStatusTable.Columns("ID").AllowDBNull = false
			TB_FaxStatusTable.Columns("ID").ReadOnly = false
			
			TB_FaxStatusTable.Columns.Add("BLID", GetType(System.Guid))
			TB_FaxStatusTable.Columns("BLID").AllowDBNull = true
			TB_FaxStatusTable.Columns("BLID").ReadOnly = false
			
			TB_FaxStatusTable.Columns.Add("DocumentType", GetType(System.String))
			TB_FaxStatusTable.Columns("DocumentType").AllowDBNull = true
			TB_FaxStatusTable.Columns("DocumentType").ReadOnly = false
			
			TB_FaxStatusTable.Columns("DocumentType").MaxLength = 20

			TB_FaxStatusTable.Columns.Add("GenerateDate", GetType(System.DateTime))
			TB_FaxStatusTable.Columns("GenerateDate").AllowDBNull = true
			TB_FaxStatusTable.Columns("GenerateDate").ReadOnly = false
			
			TB_FaxStatusTable.Columns.Add("SentDate", GetType(System.DateTime))
			TB_FaxStatusTable.Columns("SentDate").AllowDBNull = true
			TB_FaxStatusTable.Columns("SentDate").ReadOnly = false
			
			TB_FaxStatusTable.Columns.Add("Status", GetType(System.String))
			TB_FaxStatusTable.Columns("Status").AllowDBNull = true
			TB_FaxStatusTable.Columns("Status").ReadOnly = false
			
			TB_FaxStatusTable.Columns("Status").MaxLength = 6

			TB_FaxStatusTable.Columns.Add("IsMailSent", GetType(System.Boolean))
			TB_FaxStatusTable.Columns("IsMailSent").AllowDBNull = true
			TB_FaxStatusTable.Columns("IsMailSent").ReadOnly = false
			
			TB_FaxStatusTable.Columns.Add("FaxLog", GetType(System.String))
			TB_FaxStatusTable.Columns("FaxLog").AllowDBNull = true
			TB_FaxStatusTable.Columns("FaxLog").ReadOnly = false
			
			TB_FaxStatusTable.Columns.Add("SavedPath", GetType(System.String))
			TB_FaxStatusTable.Columns("SavedPath").AllowDBNull = true
			TB_FaxStatusTable.Columns("SavedPath").ReadOnly = false
			
			TB_FaxStatusTable.Columns("SavedPath").MaxLength = 100

			TB_FaxStatusTable.PrimaryKey = new DataColumn(){TB_FaxStatusTable.Columns("ID")}
			
			Dim TB_InqueryTable as DataTable = ds.Tables.Add("TB_Inquery")
			TB_InqueryTable.Columns.Add("ID", GetType(System.Guid))
			TB_InqueryTable.Columns("ID").AllowDBNull = false
			TB_InqueryTable.Columns("ID").ReadOnly = false
			
			TB_InqueryTable.Columns.Add("ClinetID", GetType(System.Guid))
			TB_InqueryTable.Columns("ClinetID").AllowDBNull = false
			TB_InqueryTable.Columns("ClinetID").ReadOnly = false
			
			TB_InqueryTable.Columns.Add("InqueryDate", GetType(System.DateTime))
			TB_InqueryTable.Columns("InqueryDate").AllowDBNull = false
			TB_InqueryTable.Columns("InqueryDate").ReadOnly = false
			
			TB_InqueryTable.Columns.Add("InqueryValidity", GetType(System.DateTime))
			TB_InqueryTable.Columns("InqueryValidity").AllowDBNull = false
			TB_InqueryTable.Columns("InqueryValidity").ReadOnly = false
			
			TB_InqueryTable.Columns.Add("PrincipalReference", GetType(System.String))
			TB_InqueryTable.Columns("PrincipalReference").AllowDBNull = false
			TB_InqueryTable.Columns("PrincipalReference").ReadOnly = false
			
			TB_InqueryTable.Columns("PrincipalReference").MaxLength = 25

			TB_InqueryTable.Columns.Add("POL", GetType(System.String))
			TB_InqueryTable.Columns("POL").AllowDBNull = false
			TB_InqueryTable.Columns("POL").ReadOnly = false
			
			TB_InqueryTable.Columns("POL").MaxLength = 10

			TB_InqueryTable.Columns.Add("POD", GetType(System.String))
			TB_InqueryTable.Columns("POD").AllowDBNull = false
			TB_InqueryTable.Columns("POD").ReadOnly = false
			
			TB_InqueryTable.Columns("POD").MaxLength = 10

			TB_InqueryTable.PrimaryKey = new DataColumn(){TB_InqueryTable.Columns("ID")}
			
			Dim TB_InqueryDetailsTable as DataTable = ds.Tables.Add("TB_InqueryDetails")
			TB_InqueryDetailsTable.Columns.Add("ID", GetType(System.Guid))
			TB_InqueryDetailsTable.Columns("ID").AllowDBNull = false
			TB_InqueryDetailsTable.Columns("ID").ReadOnly = false
			
			TB_InqueryDetailsTable.Columns.Add("MasterID", GetType(System.Guid))
			TB_InqueryDetailsTable.Columns("MasterID").AllowDBNull = false
			TB_InqueryDetailsTable.Columns("MasterID").ReadOnly = false
			
			TB_InqueryDetailsTable.Columns.Add("CnSize", GetType(System.String))
			TB_InqueryDetailsTable.Columns("CnSize").AllowDBNull = false
			TB_InqueryDetailsTable.Columns("CnSize").ReadOnly = false
			
			TB_InqueryDetailsTable.Columns("CnSize").MaxLength = 10

			TB_InqueryDetailsTable.Columns.Add("CnType", GetType(System.String))
			TB_InqueryDetailsTable.Columns("CnType").AllowDBNull = false
			TB_InqueryDetailsTable.Columns("CnType").ReadOnly = false
			
			TB_InqueryDetailsTable.Columns("CnType").MaxLength = 10

			TB_InqueryDetailsTable.Columns.Add("IsDG", GetType(System.Boolean))
			TB_InqueryDetailsTable.Columns("IsDG").AllowDBNull = false
			TB_InqueryDetailsTable.Columns("IsDG").ReadOnly = false
			
			TB_InqueryDetailsTable.Columns.Add("Amount", GetType(System.Decimal))
			TB_InqueryDetailsTable.Columns("Amount").AllowDBNull = false
			TB_InqueryDetailsTable.Columns("Amount").ReadOnly = false
			
			TB_InqueryDetailsTable.PrimaryKey = new DataColumn(){TB_InqueryDetailsTable.Columns("ID")}
			
			Dim TB_InvoiceTable as DataTable = ds.Tables.Add("TB_Invoice")
			TB_InvoiceTable.Columns.Add("ID", GetType(System.Guid))
			TB_InvoiceTable.Columns("ID").AllowDBNull = false
			TB_InvoiceTable.Columns("ID").ReadOnly = false
			
			TB_InvoiceTable.Columns.Add("BLID", GetType(System.Guid))
			TB_InvoiceTable.Columns("BLID").AllowDBNull = false
			TB_InvoiceTable.Columns("BLID").ReadOnly = false
			
			TB_InvoiceTable.Columns.Add("InvoiceNo", GetType(System.String))
			TB_InvoiceTable.Columns("InvoiceNo").AllowDBNull = true
			TB_InvoiceTable.Columns("InvoiceNo").ReadOnly = false
			
			TB_InvoiceTable.Columns("InvoiceNo").MaxLength = 10

			TB_InvoiceTable.Columns.Add("Description", GetType(System.String))
			TB_InvoiceTable.Columns("Description").AllowDBNull = false
			TB_InvoiceTable.Columns("Description").ReadOnly = false
			
			TB_InvoiceTable.Columns("Description").MaxLength = 500

			TB_InvoiceTable.Columns.Add("IssueTime", GetType(System.DateTime))
			TB_InvoiceTable.Columns("IssueTime").AllowDBNull = true
			TB_InvoiceTable.Columns("IssueTime").ReadOnly = false
			
			TB_InvoiceTable.Columns.Add("IssueBy", GetType(System.String))
			TB_InvoiceTable.Columns("IssueBy").AllowDBNull = true
			TB_InvoiceTable.Columns("IssueBy").ReadOnly = false
			
			TB_InvoiceTable.Columns("IssueBy").MaxLength = 30

			TB_InvoiceTable.Columns.Add("ConfirmTime", GetType(System.DateTime))
			TB_InvoiceTable.Columns("ConfirmTime").AllowDBNull = true
			TB_InvoiceTable.Columns("ConfirmTime").ReadOnly = false
			
			TB_InvoiceTable.Columns.Add("ConfirmBy", GetType(System.String))
			TB_InvoiceTable.Columns("ConfirmBy").AllowDBNull = true
			TB_InvoiceTable.Columns("ConfirmBy").ReadOnly = false
			
			TB_InvoiceTable.Columns("ConfirmBy").MaxLength = 30

			TB_InvoiceTable.Columns.Add("Status", GetType(System.String))
			TB_InvoiceTable.Columns("Status").AllowDBNull = true
			TB_InvoiceTable.Columns("Status").ReadOnly = false
			
			TB_InvoiceTable.Columns("Status").MaxLength = 20

			TB_InvoiceTable.Columns.Add("IssueOffice", GetType(System.String))
			TB_InvoiceTable.Columns("IssueOffice").AllowDBNull = true
			TB_InvoiceTable.Columns("IssueOffice").ReadOnly = false
			
			TB_InvoiceTable.Columns("IssueOffice").MaxLength = 20

			TB_InvoiceTable.Columns.Add("ConfirmOffice", GetType(System.String))
			TB_InvoiceTable.Columns("ConfirmOffice").AllowDBNull = true
			TB_InvoiceTable.Columns("ConfirmOffice").ReadOnly = false
			
			TB_InvoiceTable.Columns("ConfirmOffice").MaxLength = 20

			TB_InvoiceTable.PrimaryKey = new DataColumn(){TB_InvoiceTable.Columns("ID")}
			
			Dim TB_InvoiceDetailsTable as DataTable = ds.Tables.Add("TB_InvoiceDetails")
			TB_InvoiceDetailsTable.Columns.Add("ID", GetType(System.Guid))
			TB_InvoiceDetailsTable.Columns("ID").AllowDBNull = false
			TB_InvoiceDetailsTable.Columns("ID").ReadOnly = false
			
			TB_InvoiceDetailsTable.Columns.Add("InvoiceID", GetType(System.Guid))
			TB_InvoiceDetailsTable.Columns("InvoiceID").AllowDBNull = false
			TB_InvoiceDetailsTable.Columns("InvoiceID").ReadOnly = false
			
			TB_InvoiceDetailsTable.Columns.Add("Seq", GetType(System.Int16))
			TB_InvoiceDetailsTable.Columns("Seq").AllowDBNull = false
			TB_InvoiceDetailsTable.Columns("Seq").ReadOnly = false
			
			TB_InvoiceDetailsTable.Columns.Add("ChargesCode", GetType(System.String))
			TB_InvoiceDetailsTable.Columns("ChargesCode").AllowDBNull = false
			TB_InvoiceDetailsTable.Columns("ChargesCode").ReadOnly = false
			
			TB_InvoiceDetailsTable.Columns("ChargesCode").MaxLength = 20

			TB_InvoiceDetailsTable.Columns.Add("Remarks", GetType(System.String))
			TB_InvoiceDetailsTable.Columns("Remarks").AllowDBNull = false
			TB_InvoiceDetailsTable.Columns("Remarks").ReadOnly = false
			
			TB_InvoiceDetailsTable.Columns("Remarks").MaxLength = 500

			TB_InvoiceDetailsTable.Columns.Add("Currency", GetType(System.String))
			TB_InvoiceDetailsTable.Columns("Currency").AllowDBNull = false
			TB_InvoiceDetailsTable.Columns("Currency").ReadOnly = false
			
			TB_InvoiceDetailsTable.Columns("Currency").MaxLength = 20

			TB_InvoiceDetailsTable.Columns.Add("Amount", GetType(System.Double))
			TB_InvoiceDetailsTable.Columns("Amount").AllowDBNull = false
			TB_InvoiceDetailsTable.Columns("Amount").ReadOnly = false
			
			TB_InvoiceDetailsTable.Columns.Add("IRRAmount", GetType(System.Double))
			TB_InvoiceDetailsTable.Columns("IRRAmount").AllowDBNull = false
			TB_InvoiceDetailsTable.Columns("IRRAmount").ReadOnly = false
			
			TB_InvoiceDetailsTable.PrimaryKey = new DataColumn(){TB_InvoiceDetailsTable.Columns("ID")}
			
			Dim TB_InwardBLSTable as DataTable = ds.Tables.Add("TB_InwardBLS")
			TB_InwardBLSTable.Columns.Add("ID", GetType(System.Guid))
			TB_InwardBLSTable.Columns("ID").AllowDBNull = false
			TB_InwardBLSTable.Columns("ID").ReadOnly = false
			
			TB_InwardBLSTable.Columns.Add("Service", GetType(System.String))
			TB_InwardBLSTable.Columns("Service").AllowDBNull = false
			TB_InwardBLSTable.Columns("Service").ReadOnly = false
			
			TB_InwardBLSTable.Columns("Service").MaxLength = 20

			TB_InwardBLSTable.Columns.Add("Line", GetType(System.String))
			TB_InwardBLSTable.Columns("Line").AllowDBNull = false
			TB_InwardBLSTable.Columns("Line").ReadOnly = false
			
			TB_InwardBLSTable.Columns("Line").MaxLength = 20

			TB_InwardBLSTable.Columns.Add("BlNo", GetType(System.String))
			TB_InwardBLSTable.Columns("BlNo").AllowDBNull = false
			TB_InwardBLSTable.Columns("BlNo").ReadOnly = false
			
			TB_InwardBLSTable.Columns("BlNo").MaxLength = 70

			TB_InwardBLSTable.Columns.Add("IssuePlace", GetType(System.String))
			TB_InwardBLSTable.Columns("IssuePlace").AllowDBNull = true
			TB_InwardBLSTable.Columns("IssuePlace").ReadOnly = false
			
			TB_InwardBLSTable.Columns("IssuePlace").MaxLength = 10

			TB_InwardBLSTable.Columns.Add("IssueDate", GetType(System.DateTime))
			TB_InwardBLSTable.Columns("IssueDate").AllowDBNull = true
			TB_InwardBLSTable.Columns("IssueDate").ReadOnly = false
			
			TB_InwardBLSTable.Columns.Add("OnBoardDate", GetType(System.DateTime))
			TB_InwardBLSTable.Columns("OnBoardDate").AllowDBNull = true
			TB_InwardBLSTable.Columns("OnBoardDate").ReadOnly = false
			
			TB_InwardBLSTable.Columns.Add("POR", GetType(System.String))
			TB_InwardBLSTable.Columns("POR").AllowDBNull = true
			TB_InwardBLSTable.Columns("POR").ReadOnly = false
			
			TB_InwardBLSTable.Columns("POR").MaxLength = 10

			TB_InwardBLSTable.Columns.Add("POL", GetType(System.String))
			TB_InwardBLSTable.Columns("POL").AllowDBNull = false
			TB_InwardBLSTable.Columns("POL").ReadOnly = false
			
			TB_InwardBLSTable.Columns("POL").MaxLength = 10

			TB_InwardBLSTable.Columns.Add("POT", GetType(System.String))
			TB_InwardBLSTable.Columns("POT").AllowDBNull = true
			TB_InwardBLSTable.Columns("POT").ReadOnly = false
			
			TB_InwardBLSTable.Columns("POT").MaxLength = 10

			TB_InwardBLSTable.Columns.Add("POD", GetType(System.String))
			TB_InwardBLSTable.Columns("POD").AllowDBNull = false
			TB_InwardBLSTable.Columns("POD").ReadOnly = false
			
			TB_InwardBLSTable.Columns("POD").MaxLength = 10

			TB_InwardBLSTable.Columns.Add("FPOD", GetType(System.String))
			TB_InwardBLSTable.Columns("FPOD").AllowDBNull = true
			TB_InwardBLSTable.Columns("FPOD").ReadOnly = false
			
			TB_InwardBLSTable.Columns("FPOD").MaxLength = 10

			TB_InwardBLSTable.Columns.Add("PreVoyageID", GetType(System.Guid))
			TB_InwardBLSTable.Columns("PreVoyageID").AllowDBNull = true
			TB_InwardBLSTable.Columns("PreVoyageID").ReadOnly = false
			
			TB_InwardBLSTable.Columns.Add("VoyageID", GetType(System.Guid))
			TB_InwardBLSTable.Columns("VoyageID").AllowDBNull = true
			TB_InwardBLSTable.Columns("VoyageID").ReadOnly = false
			
			TB_InwardBLSTable.Columns.Add("NoOfBls", GetType(System.Int16))
			TB_InwardBLSTable.Columns("NoOfBls").AllowDBNull = true
			TB_InwardBLSTable.Columns("NoOfBls").ReadOnly = false
			
			TB_InwardBLSTable.Columns.Add("TermsOfPayment", GetType(System.String))
			TB_InwardBLSTable.Columns("TermsOfPayment").AllowDBNull = false
			TB_InwardBLSTable.Columns("TermsOfPayment").ReadOnly = false
			
			TB_InwardBLSTable.Columns("TermsOfPayment").MaxLength = 20

			TB_InwardBLSTable.Columns.Add("ClientID", GetType(System.Guid))
			TB_InwardBLSTable.Columns("ClientID").AllowDBNull = true
			TB_InwardBLSTable.Columns("ClientID").ReadOnly = false
			
			TB_InwardBLSTable.Columns.Add("FCLType", GetType(System.String))
			TB_InwardBLSTable.Columns("FCLType").AllowDBNull = true
			TB_InwardBLSTable.Columns("FCLType").ReadOnly = false
			
			TB_InwardBLSTable.Columns("FCLType").MaxLength = 20

			TB_InwardBLSTable.Columns.Add("Remarks", GetType(System.String))
			TB_InwardBLSTable.Columns("Remarks").AllowDBNull = true
			TB_InwardBLSTable.Columns("Remarks").ReadOnly = false
			
			TB_InwardBLSTable.Columns.Add("Reference", GetType(System.Int64))
			TB_InwardBLSTable.Columns("Reference").AllowDBNull = true
			TB_InwardBLSTable.Columns("Reference").ReadOnly = false
			
			TB_InwardBLSTable.Columns.Add("MailRelease", GetType(System.Boolean))
			TB_InwardBLSTable.Columns("MailRelease").AllowDBNull = true
			TB_InwardBLSTable.Columns("MailRelease").ReadOnly = false
			
			TB_InwardBLSTable.Columns.Add("MailReleaseRem", GetType(System.String))
			TB_InwardBLSTable.Columns("MailReleaseRem").AllowDBNull = true
			TB_InwardBLSTable.Columns("MailReleaseRem").ReadOnly = false
			
			TB_InwardBLSTable.Columns.Add("FrtCoverdCarr", GetType(System.String))
			TB_InwardBLSTable.Columns("FrtCoverdCarr").AllowDBNull = true
			TB_InwardBLSTable.Columns("FrtCoverdCarr").ReadOnly = false
			
			TB_InwardBLSTable.Columns("FrtCoverdCarr").MaxLength = 20

			TB_InwardBLSTable.Columns.Add("FrtCoverdBlNo", GetType(System.String))
			TB_InwardBLSTable.Columns("FrtCoverdBlNo").AllowDBNull = true
			TB_InwardBLSTable.Columns("FrtCoverdBlNo").ReadOnly = false
			
			TB_InwardBLSTable.Columns("FrtCoverdBlNo").MaxLength = 70

			TB_InwardBLSTable.Columns.Add("Status", GetType(System.String))
			TB_InwardBLSTable.Columns("Status").AllowDBNull = true
			TB_InwardBLSTable.Columns("Status").ReadOnly = false
			
			TB_InwardBLSTable.Columns("Status").MaxLength = 20

			TB_InwardBLSTable.Columns.Add("LcNo", GetType(System.String))
			TB_InwardBLSTable.Columns("LcNo").AllowDBNull = true
			TB_InwardBLSTable.Columns("LcNo").ReadOnly = false
			
			TB_InwardBLSTable.Columns("LcNo").MaxLength = 40

			TB_InwardBLSTable.Columns.Add("BLStatus", GetType(System.String))
			TB_InwardBLSTable.Columns("BLStatus").AllowDBNull = true
			TB_InwardBLSTable.Columns("BLStatus").ReadOnly = false
			
			TB_InwardBLSTable.Columns("BLStatus").MaxLength = 20

			TB_InwardBLSTable.Columns.Add("BookingID", GetType(System.Guid))
			TB_InwardBLSTable.Columns("BookingID").AllowDBNull = true
			TB_InwardBLSTable.Columns("BookingID").ReadOnly = false
			
			TB_InwardBLSTable.Columns.Add("BookingNo", GetType(System.String))
			TB_InwardBLSTable.Columns("BookingNo").AllowDBNull = true
			TB_InwardBLSTable.Columns("BookingNo").ReadOnly = false
			
			TB_InwardBLSTable.Columns("BookingNo").MaxLength = 50

			TB_InwardBLSTable.Columns.Add("MBL", GetType(System.String))
			TB_InwardBLSTable.Columns("MBL").AllowDBNull = true
			TB_InwardBLSTable.Columns("MBL").ReadOnly = false
			
			TB_InwardBLSTable.Columns("MBL").MaxLength = 50

			TB_InwardBLSTable.Columns.Add("FwdLine", GetType(System.String))
			TB_InwardBLSTable.Columns("FwdLine").AllowDBNull = true
			TB_InwardBLSTable.Columns("FwdLine").ReadOnly = false
			
			TB_InwardBLSTable.Columns("FwdLine").MaxLength = 50

			TB_InwardBLSTable.Columns.Add("FwAgent", GetType(System.String))
			TB_InwardBLSTable.Columns("FwAgent").AllowDBNull = true
			TB_InwardBLSTable.Columns("FwAgent").ReadOnly = false
			
			TB_InwardBLSTable.Columns("FwAgent").MaxLength = 50

			TB_InwardBLSTable.Columns.Add("JobNumber", GetType(System.String))
			TB_InwardBLSTable.Columns("JobNumber").AllowDBNull = true
			TB_InwardBLSTable.Columns("JobNumber").ReadOnly = false
			
			TB_InwardBLSTable.Columns("JobNumber").MaxLength = 50

			TB_InwardBLSTable.Columns.Add("IssueFU", GetType(System.Boolean))
			TB_InwardBLSTable.Columns("IssueFU").AllowDBNull = true
			TB_InwardBLSTable.Columns("IssueFU").ReadOnly = false
			
			TB_InwardBLSTable.Columns.Add("FinalizeDate", GetType(System.DateTime))
			TB_InwardBLSTable.Columns("FinalizeDate").AllowDBNull = true
			TB_InwardBLSTable.Columns("FinalizeDate").ReadOnly = false
			
			TB_InwardBLSTable.Columns.Add("FinalizeStatus", GetType(System.String))
			TB_InwardBLSTable.Columns("FinalizeStatus").AllowDBNull = true
			TB_InwardBLSTable.Columns("FinalizeStatus").ReadOnly = false
			
			TB_InwardBLSTable.Columns("FinalizeStatus").MaxLength = 10

			TB_InwardBLSTable.Columns.Add("TFCCode", GetType(System.String))
			TB_InwardBLSTable.Columns("TFCCode").AllowDBNull = true
			TB_InwardBLSTable.Columns("TFCCode").ReadOnly = false
			
			TB_InwardBLSTable.Columns("TFCCode").MaxLength = 20

			TB_InwardBLSTable.Columns.Add("BarCode", GetType(System.String))
			TB_InwardBLSTable.Columns("BarCode").AllowDBNull = true
			TB_InwardBLSTable.Columns("BarCode").ReadOnly = false
			
			TB_InwardBLSTable.Columns("BarCode").MaxLength = 25

			TB_InwardBLSTable.Columns.Add("HSCode", GetType(System.String))
			TB_InwardBLSTable.Columns("HSCode").AllowDBNull = true
			TB_InwardBLSTable.Columns("HSCode").ReadOnly = false
			
            TB_InwardBLSTable.Columns("HSCode").MaxLength = 200

            'appu
            TB_InwardBLSTable.Columns.Add("AgentID", GetType(System.Guid))
            TB_InwardBLSTable.Columns("AgentID").AllowDBNull = True
            TB_InwardBLSTable.Columns("AgentID").ReadOnly = False

            TB_InwardBLSTable.Columns.Add("Depot", GetType(System.String))
            TB_InwardBLSTable.Columns("Depot").AllowDBNull = True
            TB_InwardBLSTable.Columns("Depot").ReadOnly = False

            TB_InwardBLSTable.Columns.Add("DetnCurrency", GetType(System.String))
            TB_InwardBLSTable.Columns("DetnCurrency").AllowDBNull = True
            TB_InwardBLSTable.Columns("DetnCurrency").ReadOnly = False

            TB_InwardBLSTable.Columns.Add("RegNo", GetType(System.String))
            TB_InwardBLSTable.Columns("RegNo").AllowDBNull = True
            TB_InwardBLSTable.Columns("RegNo").ReadOnly = False

			TB_InwardBLSTable.PrimaryKey = new DataColumn(){TB_InwardBLSTable.Columns("ID")}
			
			Dim TB_InwardBlsCommentsTable as DataTable = ds.Tables.Add("TB_InwardBlsComments")
			TB_InwardBlsCommentsTable.Columns.Add("ID", GetType(System.Guid))
			TB_InwardBlsCommentsTable.Columns("ID").AllowDBNull = false
			TB_InwardBlsCommentsTable.Columns("ID").ReadOnly = false
			
			TB_InwardBlsCommentsTable.Columns.Add("BLID", GetType(System.Guid))
			TB_InwardBlsCommentsTable.Columns("BLID").AllowDBNull = false
			TB_InwardBlsCommentsTable.Columns("BLID").ReadOnly = false
			
			TB_InwardBlsCommentsTable.Columns.Add("CommentType", GetType(System.String))
			TB_InwardBlsCommentsTable.Columns("CommentType").AllowDBNull = false
			TB_InwardBlsCommentsTable.Columns("CommentType").ReadOnly = false
			
			TB_InwardBlsCommentsTable.Columns("CommentType").MaxLength = 10

			TB_InwardBlsCommentsTable.Columns.Add("Comment", GetType(System.String))
			TB_InwardBlsCommentsTable.Columns("Comment").AllowDBNull = false
			TB_InwardBlsCommentsTable.Columns("Comment").ReadOnly = false
			
			TB_InwardBlsCommentsTable.Columns.Add("CommentDate", GetType(System.DateTime))
			TB_InwardBlsCommentsTable.Columns("CommentDate").AllowDBNull = true
			TB_InwardBlsCommentsTable.Columns("CommentDate").ReadOnly = false
			
			TB_InwardBlsCommentsTable.PrimaryKey = new DataColumn(){TB_InwardBlsCommentsTable.Columns("ID")}
			
			Dim Tb_InwardBlsFrsTable as DataTable = ds.Tables.Add("Tb_InwardBlsFrs")
			Tb_InwardBlsFrsTable.Columns.Add("ID", GetType(System.Guid))
			Tb_InwardBlsFrsTable.Columns("ID").AllowDBNull = false
			Tb_InwardBlsFrsTable.Columns("ID").ReadOnly = false
			
			Tb_InwardBlsFrsTable.Columns.Add("BLID", GetType(System.Guid))
			Tb_InwardBlsFrsTable.Columns("BLID").AllowDBNull = false
			Tb_InwardBlsFrsTable.Columns("BLID").ReadOnly = false
			
			Tb_InwardBlsFrsTable.Columns.Add("FCnee", GetType(System.String))
			Tb_InwardBlsFrsTable.Columns("FCnee").AllowDBNull = true
			Tb_InwardBlsFrsTable.Columns("FCnee").ReadOnly = false
			
			Tb_InwardBlsFrsTable.Columns.Add("FGoods", GetType(System.String))
			Tb_InwardBlsFrsTable.Columns("FGoods").AllowDBNull = true
			Tb_InwardBlsFrsTable.Columns("FGoods").ReadOnly = false
			
			Tb_InwardBlsFrsTable.Columns.Add("FPkgs", GetType(System.String))
			Tb_InwardBlsFrsTable.Columns("FPkgs").AllowDBNull = true
			Tb_InwardBlsFrsTable.Columns("FPkgs").ReadOnly = false
			
			Tb_InwardBlsFrsTable.PrimaryKey = new DataColumn(){Tb_InwardBlsFrsTable.Columns("ID")}
			
			Dim TB_InwardBlsGoodsTable as DataTable = ds.Tables.Add("TB_InwardBlsGoods")
			TB_InwardBlsGoodsTable.Columns.Add("ID", GetType(System.Guid))
			TB_InwardBlsGoodsTable.Columns("ID").AllowDBNull = false
			TB_InwardBlsGoodsTable.Columns("ID").ReadOnly = false
			
			TB_InwardBlsGoodsTable.Columns.Add("BLID", GetType(System.Guid))
			TB_InwardBlsGoodsTable.Columns("BLID").AllowDBNull = false
			TB_InwardBlsGoodsTable.Columns("BLID").ReadOnly = false
			
			TB_InwardBlsGoodsTable.Columns.Add("Goods", GetType(System.String))
			TB_InwardBlsGoodsTable.Columns("Goods").AllowDBNull = true
			TB_InwardBlsGoodsTable.Columns("Goods").ReadOnly = false
			
			TB_InwardBlsGoodsTable.Columns.Add("Marks", GetType(System.String))
			TB_InwardBlsGoodsTable.Columns("Marks").AllowDBNull = true
			TB_InwardBlsGoodsTable.Columns("Marks").ReadOnly = false
			
			TB_InwardBlsGoodsTable.Columns.Add("MainCom", GetType(System.String))
			TB_InwardBlsGoodsTable.Columns("MainCom").AllowDBNull = true
			TB_InwardBlsGoodsTable.Columns("MainCom").ReadOnly = false
			
			TB_InwardBlsGoodsTable.Columns("MainCom").MaxLength = 500

			TB_InwardBlsGoodsTable.Columns.Add("TTW", GetType(System.Int64))
			TB_InwardBlsGoodsTable.Columns("TTW").AllowDBNull = true
			TB_InwardBlsGoodsTable.Columns("TTW").ReadOnly = false
			
			TB_InwardBlsGoodsTable.Columns.Add("TGW", GetType(System.Decimal))
			TB_InwardBlsGoodsTable.Columns("TGW").AllowDBNull = true
			TB_InwardBlsGoodsTable.Columns("TGW").ReadOnly = false
			
			TB_InwardBlsGoodsTable.Columns.Add("TTLPkgs", GetType(System.Int64))
			TB_InwardBlsGoodsTable.Columns("TTLPkgs").AllowDBNull = true
			TB_InwardBlsGoodsTable.Columns("TTLPkgs").ReadOnly = false
			
			TB_InwardBlsGoodsTable.Columns.Add("TTLCBM", GetType(System.Decimal))
			TB_InwardBlsGoodsTable.Columns("TTLCBM").AllowDBNull = true
			TB_InwardBlsGoodsTable.Columns("TTLCBM").ReadOnly = false
			
			TB_InwardBlsGoodsTable.Columns.Add("TTLNET", GetType(System.Decimal))
			TB_InwardBlsGoodsTable.Columns("TTLNET").AllowDBNull = true
			TB_InwardBlsGoodsTable.Columns("TTLNET").ReadOnly = false
			
			TB_InwardBlsGoodsTable.PrimaryKey = new DataColumn(){TB_InwardBlsGoodsTable.Columns("ID")}
			
			Dim TB_InwardBlsNamesTable as DataTable = ds.Tables.Add("TB_InwardBlsNames")
			TB_InwardBlsNamesTable.Columns.Add("ID", GetType(System.Guid))
			TB_InwardBlsNamesTable.Columns("ID").AllowDBNull = false
			TB_InwardBlsNamesTable.Columns("ID").ReadOnly = false
			
			TB_InwardBlsNamesTable.Columns.Add("BLID", GetType(System.Guid))
			TB_InwardBlsNamesTable.Columns("BLID").AllowDBNull = false
			TB_InwardBlsNamesTable.Columns("BLID").ReadOnly = false
			
			TB_InwardBlsNamesTable.Columns.Add("Shipper", GetType(System.String))
			TB_InwardBlsNamesTable.Columns("Shipper").AllowDBNull = true
			TB_InwardBlsNamesTable.Columns("Shipper").ReadOnly = false
			
			TB_InwardBlsNamesTable.Columns.Add("Cnee", GetType(System.String))
			TB_InwardBlsNamesTable.Columns("Cnee").AllowDBNull = True
			TB_InwardBlsNamesTable.Columns("Cnee").ReadOnly = False

			TB_InwardBlsNamesTable.Columns.Add("CneeAdd", GetType(System.String))
			TB_InwardBlsNamesTable.Columns("CneeAdd").AllowDBNull = True
			TB_InwardBlsNamesTable.Columns("CneeAdd").ReadOnly = False

			TB_InwardBlsNamesTable.Columns.Add("Notify1", GetType(System.String))
			TB_InwardBlsNamesTable.Columns("Notify1").AllowDBNull = true
			TB_InwardBlsNamesTable.Columns("Notify1").ReadOnly = false
			
			TB_InwardBlsNamesTable.Columns.Add("Notify2", GetType(System.String))
			TB_InwardBlsNamesTable.Columns("Notify2").AllowDBNull = true
			TB_InwardBlsNamesTable.Columns("Notify2").ReadOnly = false
			
			TB_InwardBlsNamesTable.Columns.Add("Notify3", GetType(System.String))
			TB_InwardBlsNamesTable.Columns("Notify3").AllowDBNull = true
			TB_InwardBlsNamesTable.Columns("Notify3").ReadOnly = false
			
			TB_InwardBlsNamesTable.Columns.Add("Messers", GetType(System.String))
			TB_InwardBlsNamesTable.Columns("Messers").AllowDBNull = true
			TB_InwardBlsNamesTable.Columns("Messers").ReadOnly = false
			
			TB_InwardBlsNamesTable.Columns("Messers").MaxLength = 500

			TB_InwardBlsNamesTable.Columns.Add("ShipperID", GetType(System.String))
			TB_InwardBlsNamesTable.Columns("ShipperID").AllowDBNull = true
			TB_InwardBlsNamesTable.Columns("ShipperID").ReadOnly = false
			
			TB_InwardBlsNamesTable.Columns("ShipperID").MaxLength = 50

			TB_InwardBlsNamesTable.Columns.Add("CneeID", GetType(System.String))
			TB_InwardBlsNamesTable.Columns("CneeID").AllowDBNull = true
			TB_InwardBlsNamesTable.Columns("CneeID").ReadOnly = false
			
			TB_InwardBlsNamesTable.Columns("CneeID").MaxLength = 50

			TB_InwardBlsNamesTable.Columns.Add("Notify1ID", GetType(System.String))
			TB_InwardBlsNamesTable.Columns("Notify1ID").AllowDBNull = true
			TB_InwardBlsNamesTable.Columns("Notify1ID").ReadOnly = false
			
			TB_InwardBlsNamesTable.Columns("Notify1ID").MaxLength = 50

			TB_InwardBlsNamesTable.Columns.Add("Notify2ID", GetType(System.String))
			TB_InwardBlsNamesTable.Columns("Notify2ID").AllowDBNull = true
			TB_InwardBlsNamesTable.Columns("Notify2ID").ReadOnly = false
			
			TB_InwardBlsNamesTable.Columns("Notify2ID").MaxLength = 50

			TB_InwardBlsNamesTable.Columns.Add("Notify3ID", GetType(System.String))
			TB_InwardBlsNamesTable.Columns("Notify3ID").AllowDBNull = true
			TB_InwardBlsNamesTable.Columns("Notify3ID").ReadOnly = false
			
			TB_InwardBlsNamesTable.Columns("Notify3ID").MaxLength = 50

			TB_InwardBlsNamesTable.Columns.Add("Forwarder", GetType(System.String))
			TB_InwardBlsNamesTable.Columns("Forwarder").AllowDBNull = true
			TB_InwardBlsNamesTable.Columns("Forwarder").ReadOnly = false
			
			TB_InwardBlsNamesTable.Columns.Add("ForwarderID", GetType(System.String))
			TB_InwardBlsNamesTable.Columns("ForwarderID").AllowDBNull = true
			TB_InwardBlsNamesTable.Columns("ForwarderID").ReadOnly = false
			
			TB_InwardBlsNamesTable.Columns("ForwarderID").MaxLength = 50

			TB_InwardBlsNamesTable.PrimaryKey = new DataColumn(){TB_InwardBlsNamesTable.Columns("ID")}
			
			Dim TB_InwardChargesTable as DataTable = ds.Tables.Add("TB_InwardCharges")
			TB_InwardChargesTable.Columns.Add("ID", GetType(System.Guid))
			TB_InwardChargesTable.Columns("ID").AllowDBNull = false
			TB_InwardChargesTable.Columns("ID").ReadOnly = false
			
			TB_InwardChargesTable.Columns.Add("BLID", GetType(System.Guid))
			TB_InwardChargesTable.Columns("BLID").AllowDBNull = false
			TB_InwardChargesTable.Columns("BLID").ReadOnly = false
			
			TB_InwardChargesTable.Columns.Add("Seq", GetType(System.Int16))
			TB_InwardChargesTable.Columns("Seq").AllowDBNull = false
			TB_InwardChargesTable.Columns("Seq").ReadOnly = false
			
			TB_InwardChargesTable.Columns.Add("ChargesCode", GetType(System.String))
			TB_InwardChargesTable.Columns("ChargesCode").AllowDBNull = false
			TB_InwardChargesTable.Columns("ChargesCode").ReadOnly = false
			
			TB_InwardChargesTable.Columns("ChargesCode").MaxLength = 20

			TB_InwardChargesTable.Columns.Add("Currency", GetType(System.String))
			TB_InwardChargesTable.Columns("Currency").AllowDBNull = false
			TB_InwardChargesTable.Columns("Currency").ReadOnly = false
			
			TB_InwardChargesTable.Columns("Currency").MaxLength = 20

			TB_InwardChargesTable.Columns.Add("Qty", GetType(System.Int16))
			TB_InwardChargesTable.Columns("Qty").AllowDBNull = false
			TB_InwardChargesTable.Columns("Qty").ReadOnly = false
			
			TB_InwardChargesTable.Columns.Add("Rate", GetType(System.Double))
			TB_InwardChargesTable.Columns("Rate").AllowDBNull = false
			TB_InwardChargesTable.Columns("Rate").ReadOnly = false
			
			TB_InwardChargesTable.Columns.Add("Amount", GetType(System.Double))
			TB_InwardChargesTable.Columns("Amount").AllowDBNull = false
			TB_InwardChargesTable.Columns("Amount").ReadOnly = false
			
			TB_InwardChargesTable.Columns.Add("PayAt", GetType(System.String))
			TB_InwardChargesTable.Columns("PayAt").AllowDBNull = false
			TB_InwardChargesTable.Columns("PayAt").ReadOnly = false
			
			TB_InwardChargesTable.Columns("PayAt").MaxLength = 10

			TB_InwardChargesTable.Columns.Add("ChargesBase", GetType(System.String))
			TB_InwardChargesTable.Columns("ChargesBase").AllowDBNull = true
			TB_InwardChargesTable.Columns("ChargesBase").ReadOnly = false
			
			TB_InwardChargesTable.Columns("ChargesBase").MaxLength = 20

			TB_InwardChargesTable.Columns.Add("Terms", GetType(System.String))
			TB_InwardChargesTable.Columns("Terms").AllowDBNull = true
			TB_InwardChargesTable.Columns("Terms").ReadOnly = false
			
			TB_InwardChargesTable.Columns("Terms").MaxLength = 20

			TB_InwardChargesTable.Columns.Add("ActPlaceExRate", GetType(System.Decimal))
			TB_InwardChargesTable.Columns("ActPlaceExRate").AllowDBNull = true
			TB_InwardChargesTable.Columns("ActPlaceExRate").ReadOnly = false
			
			TB_InwardChargesTable.Columns.Add("MeaUnitOfCharge", GetType(System.String))
			TB_InwardChargesTable.Columns("MeaUnitOfCharge").AllowDBNull = true
			TB_InwardChargesTable.Columns("MeaUnitOfCharge").ReadOnly = false
			
			TB_InwardChargesTable.Columns("MeaUnitOfCharge").MaxLength = 10

			TB_InwardChargesTable.Columns.Add("FromPlace", GetType(System.String))
			TB_InwardChargesTable.Columns("FromPlace").AllowDBNull = true
			TB_InwardChargesTable.Columns("FromPlace").ReadOnly = false
			
			TB_InwardChargesTable.Columns("FromPlace").MaxLength = 10

			TB_InwardChargesTable.Columns.Add("ToPlace", GetType(System.String))
			TB_InwardChargesTable.Columns("ToPlace").AllowDBNull = true
			TB_InwardChargesTable.Columns("ToPlace").ReadOnly = false
			
			TB_InwardChargesTable.Columns("ToPlace").MaxLength = 10

			TB_InwardChargesTable.Columns.Add("PayAtBranch", GetType(System.String))
			TB_InwardChargesTable.Columns("PayAtBranch").AllowDBNull = true
			TB_InwardChargesTable.Columns("PayAtBranch").ReadOnly = false
			
			TB_InwardChargesTable.Columns("PayAtBranch").MaxLength = 2

			TB_InwardChargesTable.Columns.Add("PayAtExRate", GetType(System.Decimal))
			TB_InwardChargesTable.Columns("PayAtExRate").AllowDBNull = true
			TB_InwardChargesTable.Columns("PayAtExRate").ReadOnly = false
			
			TB_InwardChargesTable.Columns.Add("PayAtPc", GetType(System.String))
			TB_InwardChargesTable.Columns("PayAtPc").AllowDBNull = true
			TB_InwardChargesTable.Columns("PayAtPc").ReadOnly = false
			
			TB_InwardChargesTable.Columns("PayAtPc").MaxLength = 1

			TB_InwardChargesTable.Columns.Add("InvoiceAmount", GetType(System.Decimal))
			TB_InwardChargesTable.Columns("InvoiceAmount").AllowDBNull = true
			TB_InwardChargesTable.Columns("InvoiceAmount").ReadOnly = false
			
			TB_InwardChargesTable.Columns.Add("RealAmount", GetType(System.Double))
			TB_InwardChargesTable.Columns("RealAmount").AllowDBNull = true
			TB_InwardChargesTable.Columns("RealAmount").ReadOnly = false
			
			TB_InwardChargesTable.PrimaryKey = new DataColumn(){TB_InwardChargesTable.Columns("ID")}
			
			Dim TB_InwardCnsImcoTable as DataTable = ds.Tables.Add("TB_InwardCnsImco")
			TB_InwardCnsImcoTable.Columns.Add("ID", GetType(System.Guid))
			TB_InwardCnsImcoTable.Columns("ID").AllowDBNull = false
			TB_InwardCnsImcoTable.Columns("ID").ReadOnly = false
			
			TB_InwardCnsImcoTable.Columns.Add("CntrID", GetType(System.Guid))
			TB_InwardCnsImcoTable.Columns("CntrID").AllowDBNull = false
			TB_InwardCnsImcoTable.Columns("CntrID").ReadOnly = false
			
			TB_InwardCnsImcoTable.Columns.Add("UNNO", GetType(System.String))
			TB_InwardCnsImcoTable.Columns("UNNO").AllowDBNull = true
			TB_InwardCnsImcoTable.Columns("UNNO").ReadOnly = false
			
			TB_InwardCnsImcoTable.Columns("UNNO").MaxLength = 20

			TB_InwardCnsImcoTable.Columns.Add("IMDGCode", GetType(System.String))
			TB_InwardCnsImcoTable.Columns("IMDGCode").AllowDBNull = true
			TB_InwardCnsImcoTable.Columns("IMDGCode").ReadOnly = false
			
			TB_InwardCnsImcoTable.Columns("IMDGCode").MaxLength = 20

			TB_InwardCnsImcoTable.Columns.Add("FlashPoint", GetType(System.Double))
			TB_InwardCnsImcoTable.Columns("FlashPoint").AllowDBNull = true
			TB_InwardCnsImcoTable.Columns("FlashPoint").ReadOnly = false
			
			TB_InwardCnsImcoTable.Columns.Add("PakingGroup", GetType(System.String))
			TB_InwardCnsImcoTable.Columns("PakingGroup").AllowDBNull = true
			TB_InwardCnsImcoTable.Columns("PakingGroup").ReadOnly = false
			
			TB_InwardCnsImcoTable.Columns("PakingGroup").MaxLength = 20

			TB_InwardCnsImcoTable.Columns.Add("PageNumber", GetType(System.Int64))
			TB_InwardCnsImcoTable.Columns("PageNumber").AllowDBNull = true
			TB_InwardCnsImcoTable.Columns("PageNumber").ReadOnly = false
			
			TB_InwardCnsImcoTable.Columns.Add("EMSNumber", GetType(System.Int64))
			TB_InwardCnsImcoTable.Columns("EMSNumber").AllowDBNull = true
			TB_InwardCnsImcoTable.Columns("EMSNumber").ReadOnly = false
			
			TB_InwardCnsImcoTable.PrimaryKey = new DataColumn(){TB_InwardCnsImcoTable.Columns("ID")}
			
			Dim TB_InwardCnsPkgsTable as DataTable = ds.Tables.Add("TB_InwardCnsPkgs")
			TB_InwardCnsPkgsTable.Columns.Add("ID", GetType(System.Guid))
			TB_InwardCnsPkgsTable.Columns("ID").AllowDBNull = false
			TB_InwardCnsPkgsTable.Columns("ID").ReadOnly = false
			
			TB_InwardCnsPkgsTable.Columns.Add("CntrID", GetType(System.Guid))
			TB_InwardCnsPkgsTable.Columns("CntrID").AllowDBNull = false
			TB_InwardCnsPkgsTable.Columns("CntrID").ReadOnly = false
			
			TB_InwardCnsPkgsTable.Columns.Add("PackageType", GetType(System.String))
			TB_InwardCnsPkgsTable.Columns("PackageType").AllowDBNull = false
			TB_InwardCnsPkgsTable.Columns("PackageType").ReadOnly = false
			
			TB_InwardCnsPkgsTable.Columns("PackageType").MaxLength = 20

            TB_InwardCnsPkgsTable.Columns.Add("NoOFPkgs", GetType(System.Decimal))
            TB_InwardCnsPkgsTable.Columns("NoOFPkgs").AllowDBNull = True
			TB_InwardCnsPkgsTable.Columns("NoOFPkgs").ReadOnly = false
			
			TB_InwardCnsPkgsTable.Columns.Add("GW", GetType(System.Single))
			TB_InwardCnsPkgsTable.Columns("GW").AllowDBNull = true
			TB_InwardCnsPkgsTable.Columns("GW").ReadOnly = false
			
			TB_InwardCnsPkgsTable.Columns.Add("CBM", GetType(System.Single))
			TB_InwardCnsPkgsTable.Columns("CBM").AllowDBNull = true
			TB_InwardCnsPkgsTable.Columns("CBM").ReadOnly = false
			
			TB_InwardCnsPkgsTable.Columns.Add("NET", GetType(System.Double))
			TB_InwardCnsPkgsTable.Columns("NET").AllowDBNull = true
			TB_InwardCnsPkgsTable.Columns("NET").ReadOnly = false
			
			TB_InwardCnsPkgsTable.Columns.Add("FlashPoint", GetType(System.Double))
			TB_InwardCnsPkgsTable.Columns("FlashPoint").AllowDBNull = true
			TB_InwardCnsPkgsTable.Columns("FlashPoint").ReadOnly = false
			
			TB_InwardCnsPkgsTable.Columns.Add("IMDGCode", GetType(System.String))
			TB_InwardCnsPkgsTable.Columns("IMDGCode").AllowDBNull = true
			TB_InwardCnsPkgsTable.Columns("IMDGCode").ReadOnly = false
			
			TB_InwardCnsPkgsTable.Columns("IMDGCode").MaxLength = 20

			TB_InwardCnsPkgsTable.Columns.Add("PakingGroup", GetType(System.Int64))
			TB_InwardCnsPkgsTable.Columns("PakingGroup").AllowDBNull = true
			TB_InwardCnsPkgsTable.Columns("PakingGroup").ReadOnly = false
			
			TB_InwardCnsPkgsTable.Columns.Add("PageNumber", GetType(System.Int64))
			TB_InwardCnsPkgsTable.Columns("PageNumber").AllowDBNull = true
			TB_InwardCnsPkgsTable.Columns("PageNumber").ReadOnly = false
			
            'TB_InwardCnsPkgsTable.Columns.Add("EMSNumber", GetType(System.Int64))
            'TB_InwardCnsPkgsTable.Columns("EMSNumber").AllowDBNull = true
            'TB_InwardCnsPkgsTable.Columns("EMSNumber").ReadOnly = false

            TB_InwardCnsPkgsTable.Columns.Add("EMSNumber", GetType(System.String))
            TB_InwardCnsPkgsTable.Columns("EMSNumber").AllowDBNull = True
            TB_InwardCnsPkgsTable.Columns("EMSNumber").ReadOnly = False
			
			TB_InwardCnsPkgsTable.PrimaryKey = new DataColumn(){TB_InwardCnsPkgsTable.Columns("ID")}
			
			Dim TB_InwardCnsTempratureTable as DataTable = ds.Tables.Add("TB_InwardCnsTemprature")
			TB_InwardCnsTempratureTable.Columns.Add("ID", GetType(System.Guid))
			TB_InwardCnsTempratureTable.Columns("ID").AllowDBNull = false
			TB_InwardCnsTempratureTable.Columns("ID").ReadOnly = false
			
			TB_InwardCnsTempratureTable.Columns.Add("CntrID", GetType(System.Guid))
			TB_InwardCnsTempratureTable.Columns("CntrID").AllowDBNull = false
			TB_InwardCnsTempratureTable.Columns("CntrID").ReadOnly = false
			
			TB_InwardCnsTempratureTable.Columns.Add("TempMin", GetType(System.Single))
			TB_InwardCnsTempratureTable.Columns("TempMin").AllowDBNull = true
			TB_InwardCnsTempratureTable.Columns("TempMin").ReadOnly = false
			
			TB_InwardCnsTempratureTable.Columns.Add("TempMax", GetType(System.Single))
			TB_InwardCnsTempratureTable.Columns("TempMax").AllowDBNull = true
			TB_InwardCnsTempratureTable.Columns("TempMax").ReadOnly = false
			
			TB_InwardCnsTempratureTable.Columns.Add("TemperatureBase", GetType(System.String))
			TB_InwardCnsTempratureTable.Columns("TemperatureBase").AllowDBNull = true
			TB_InwardCnsTempratureTable.Columns("TemperatureBase").ReadOnly = false
			
			TB_InwardCnsTempratureTable.Columns("TemperatureBase").MaxLength = 20

			TB_InwardCnsTempratureTable.PrimaryKey = new DataColumn(){TB_InwardCnsTempratureTable.Columns("ID")}
			
			Dim TB_InwardCntrsTable as DataTable = ds.Tables.Add("TB_InwardCntrs")
			TB_InwardCntrsTable.Columns.Add("ID", GetType(System.Guid))
			TB_InwardCntrsTable.Columns("ID").AllowDBNull = false
			TB_InwardCntrsTable.Columns("ID").ReadOnly = false
			
			TB_InwardCntrsTable.Columns.Add("BLID", GetType(System.Guid))
			TB_InwardCntrsTable.Columns("BLID").AllowDBNull = false
			TB_InwardCntrsTable.Columns("BLID").ReadOnly = false
			
			TB_InwardCntrsTable.Columns.Add("CntrNo", GetType(System.String))
			TB_InwardCntrsTable.Columns("CntrNo").AllowDBNull = false
			TB_InwardCntrsTable.Columns("CntrNo").ReadOnly = false
			
			TB_InwardCntrsTable.Columns("CntrNo").MaxLength = 24

			TB_InwardCntrsTable.Columns.Add("CnSize", GetType(System.String))
			TB_InwardCntrsTable.Columns("CnSize").AllowDBNull = false
			TB_InwardCntrsTable.Columns("CnSize").ReadOnly = false
			
			TB_InwardCntrsTable.Columns("CnSize").MaxLength = 20

			TB_InwardCntrsTable.Columns.Add("CnType", GetType(System.String))
			TB_InwardCntrsTable.Columns("CnType").AllowDBNull = false
			TB_InwardCntrsTable.Columns("CnType").ReadOnly = false
			
			TB_InwardCntrsTable.Columns("CnType").MaxLength = 20

			TB_InwardCntrsTable.Columns.Add("SealNo", GetType(System.String))
			TB_InwardCntrsTable.Columns("SealNo").AllowDBNull = true
			TB_InwardCntrsTable.Columns("SealNo").ReadOnly = false
			
			TB_InwardCntrsTable.Columns("SealNo").MaxLength = 30

			TB_InwardCntrsTable.Columns.Add("TW", GetType(System.Int64))
			TB_InwardCntrsTable.Columns("TW").AllowDBNull = false
			TB_InwardCntrsTable.Columns("TW").ReadOnly = false
			
			TB_InwardCntrsTable.Columns.Add("GW", GetType(System.Decimal))
			TB_InwardCntrsTable.Columns("GW").AllowDBNull = true
			TB_InwardCntrsTable.Columns("GW").ReadOnly = false
			
			TB_InwardCntrsTable.Columns.Add("CBM", GetType(System.Decimal))
			TB_InwardCntrsTable.Columns("CBM").AllowDBNull = true
			TB_InwardCntrsTable.Columns("CBM").ReadOnly = false
			
			TB_InwardCntrsTable.Columns.Add("NET", GetType(System.Decimal))
			TB_InwardCntrsTable.Columns("NET").AllowDBNull = true
			TB_InwardCntrsTable.Columns("NET").ReadOnly = false
			
			TB_InwardCntrsTable.Columns.Add("FLE", GetType(System.String))
			TB_InwardCntrsTable.Columns("FLE").AllowDBNull = false
			TB_InwardCntrsTable.Columns("FLE").ReadOnly = false
			
			TB_InwardCntrsTable.Columns("FLE").MaxLength = 20

			TB_InwardCntrsTable.Columns.Add("SOC", GetType(System.String))
			TB_InwardCntrsTable.Columns("SOC").AllowDBNull = false
			TB_InwardCntrsTable.Columns("SOC").ReadOnly = false
			
			TB_InwardCntrsTable.Columns("SOC").MaxLength = 20

			TB_InwardCntrsTable.Columns.Add("PackageType", GetType(System.String))
			TB_InwardCntrsTable.Columns("PackageType").AllowDBNull = true
			TB_InwardCntrsTable.Columns("PackageType").ReadOnly = false
			
			TB_InwardCntrsTable.Columns("PackageType").MaxLength = 20

			TB_InwardCntrsTable.Columns.Add("NoOFPkgs", GetType(System.Int64))
			TB_InwardCntrsTable.Columns("NoOFPkgs").AllowDBNull = true
			TB_InwardCntrsTable.Columns("NoOFPkgs").ReadOnly = false
			
			TB_InwardCntrsTable.Columns.Add("Goods", GetType(System.String))
			TB_InwardCntrsTable.Columns("Goods").AllowDBNull = true
			TB_InwardCntrsTable.Columns("Goods").ReadOnly = false
			
			TB_InwardCntrsTable.Columns("Goods").MaxLength = 500

			TB_InwardCntrsTable.Columns.Add("IsOOG", GetType(System.Boolean))
			TB_InwardCntrsTable.Columns("IsOOG").AllowDBNull = true
			TB_InwardCntrsTable.Columns("IsOOG").ReadOnly = false
			
			TB_InwardCntrsTable.Columns.Add("Marks", GetType(System.String))
			TB_InwardCntrsTable.Columns("Marks").AllowDBNull = true
			TB_InwardCntrsTable.Columns("Marks").ReadOnly = false
			
			TB_InwardCntrsTable.Columns("Marks").MaxLength = 8000

			TB_InwardCntrsTable.Columns.Add("POLTerm", GetType(System.String))
			TB_InwardCntrsTable.Columns("POLTerm").AllowDBNull = true
			TB_InwardCntrsTable.Columns("POLTerm").ReadOnly = false
			
			TB_InwardCntrsTable.Columns("POLTerm").MaxLength = 10

			TB_InwardCntrsTable.Columns.Add("PODTerm", GetType(System.String))
			TB_InwardCntrsTable.Columns("PODTerm").AllowDBNull = true
			TB_InwardCntrsTable.Columns("PODTerm").ReadOnly = false
			
			TB_InwardCntrsTable.Columns("PODTerm").MaxLength = 10

			TB_InwardCntrsTable.PrimaryKey = new DataColumn(){TB_InwardCntrsTable.Columns("ID")}
			
			Dim TB_InwardCntrsChargesTable as DataTable = ds.Tables.Add("TB_InwardCntrsCharges")
			TB_InwardCntrsChargesTable.Columns.Add("ID", GetType(System.Guid))
			TB_InwardCntrsChargesTable.Columns("ID").AllowDBNull = false
			TB_InwardCntrsChargesTable.Columns("ID").ReadOnly = false
			
			TB_InwardCntrsChargesTable.Columns.Add("CntrID", GetType(System.Guid))
			TB_InwardCntrsChargesTable.Columns("CntrID").AllowDBNull = false
			TB_InwardCntrsChargesTable.Columns("CntrID").ReadOnly = false
			
			TB_InwardCntrsChargesTable.Columns.Add("ChargesCode", GetType(System.String))
			TB_InwardCntrsChargesTable.Columns("ChargesCode").AllowDBNull = false
			TB_InwardCntrsChargesTable.Columns("ChargesCode").ReadOnly = false
			
			TB_InwardCntrsChargesTable.Columns("ChargesCode").MaxLength = 10

			TB_InwardCntrsChargesTable.Columns.Add("Currency", GetType(System.String))
			TB_InwardCntrsChargesTable.Columns("Currency").AllowDBNull = false
			TB_InwardCntrsChargesTable.Columns("Currency").ReadOnly = false
			
			TB_InwardCntrsChargesTable.Columns("Currency").MaxLength = 10

			TB_InwardCntrsChargesTable.Columns.Add("UnitRate", GetType(System.Decimal))
			TB_InwardCntrsChargesTable.Columns("UnitRate").AllowDBNull = false
			TB_InwardCntrsChargesTable.Columns("UnitRate").ReadOnly = false
			
			TB_InwardCntrsChargesTable.Columns.Add("MEARate", GetType(System.Decimal))
			TB_InwardCntrsChargesTable.Columns("MEARate").AllowDBNull = true
			TB_InwardCntrsChargesTable.Columns("MEARate").ReadOnly = false
			
			TB_InwardCntrsChargesTable.Columns.Add("WGTrate", GetType(System.Decimal))
			TB_InwardCntrsChargesTable.Columns("WGTrate").AllowDBNull = true
			TB_InwardCntrsChargesTable.Columns("WGTrate").ReadOnly = false
			
			TB_InwardCntrsChargesTable.Columns.Add("FromPlace", GetType(System.String))
			TB_InwardCntrsChargesTable.Columns("FromPlace").AllowDBNull = true
			TB_InwardCntrsChargesTable.Columns("FromPlace").ReadOnly = false
			
			TB_InwardCntrsChargesTable.Columns("FromPlace").MaxLength = 5

			TB_InwardCntrsChargesTable.Columns.Add("ToPlace", GetType(System.String))
			TB_InwardCntrsChargesTable.Columns("ToPlace").AllowDBNull = true
			TB_InwardCntrsChargesTable.Columns("ToPlace").ReadOnly = false
			
			TB_InwardCntrsChargesTable.Columns("ToPlace").MaxLength = 5

			TB_InwardCntrsChargesTable.Columns.Add("MinRate", GetType(System.Decimal))
			TB_InwardCntrsChargesTable.Columns("MinRate").AllowDBNull = true
			TB_InwardCntrsChargesTable.Columns("MinRate").ReadOnly = false
			
			TB_InwardCntrsChargesTable.Columns.Add("Terms", GetType(System.String))
			TB_InwardCntrsChargesTable.Columns("Terms").AllowDBNull = false
			TB_InwardCntrsChargesTable.Columns("Terms").ReadOnly = false
			
			TB_InwardCntrsChargesTable.Columns("Terms").MaxLength = 10

			TB_InwardCntrsChargesTable.Columns.Add("RealAmount", GetType(System.Decimal))
			TB_InwardCntrsChargesTable.Columns("RealAmount").AllowDBNull = true
			TB_InwardCntrsChargesTable.Columns("RealAmount").ReadOnly = false
			
			TB_InwardCntrsChargesTable.PrimaryKey = new DataColumn(){TB_InwardCntrsChargesTable.Columns("ID")}
			
			Dim TB_InwardDiscountTable as DataTable = ds.Tables.Add("TB_InwardDiscount")
			TB_InwardDiscountTable.Columns.Add("ID", GetType(System.Guid))
			TB_InwardDiscountTable.Columns("ID").AllowDBNull = false
			TB_InwardDiscountTable.Columns("ID").ReadOnly = false
			
			TB_InwardDiscountTable.Columns.Add("BLID", GetType(System.Guid))
			TB_InwardDiscountTable.Columns("BLID").AllowDBNull = false
			TB_InwardDiscountTable.Columns("BLID").ReadOnly = false
			
			TB_InwardDiscountTable.Columns.Add("dFreeDays", GetType(System.Int32))
			TB_InwardDiscountTable.Columns("dFreeDays").AllowDBNull = true
			TB_InwardDiscountTable.Columns("dFreeDays").ReadOnly = false
			
			TB_InwardDiscountTable.Columns.Add("dPercent", GetType(System.Int32))
			TB_InwardDiscountTable.Columns("dPercent").AllowDBNull = true
			TB_InwardDiscountTable.Columns("dPercent").ReadOnly = false
			
			TB_InwardDiscountTable.Columns.Add("dAmount", GetType(System.Int64))
			TB_InwardDiscountTable.Columns("dAmount").AllowDBNull = true
			TB_InwardDiscountTable.Columns("dAmount").ReadOnly = false
			
			TB_InwardDiscountTable.Columns.Add("LineSetel", GetType(System.DateTime))
			TB_InwardDiscountTable.Columns("LineSetel").AllowDBNull = true
			TB_InwardDiscountTable.Columns("LineSetel").ReadOnly = false
			
			TB_InwardDiscountTable.Columns.Add("IsFDaysAsDiscount", GetType(System.Boolean))
			TB_InwardDiscountTable.Columns("IsFDaysAsDiscount").AllowDBNull = true
			TB_InwardDiscountTable.Columns("IsFDaysAsDiscount").ReadOnly = false
			
			TB_InwardDiscountTable.Columns.Add("SpecialCalculate", GetType(System.Boolean))
			TB_InwardDiscountTable.Columns("SpecialCalculate").AllowDBNull = true
			TB_InwardDiscountTable.Columns("SpecialCalculate").ReadOnly = false
			
			TB_InwardDiscountTable.Columns.Add("PerDay20", GetType(System.Double))
			TB_InwardDiscountTable.Columns("PerDay20").AllowDBNull = true
			TB_InwardDiscountTable.Columns("PerDay20").ReadOnly = false
			
			TB_InwardDiscountTable.Columns.Add("PerDay40", GetType(System.Double))
			TB_InwardDiscountTable.Columns("PerDay40").AllowDBNull = true
			TB_InwardDiscountTable.Columns("PerDay40").ReadOnly = false
			
			TB_InwardDiscountTable.Columns.Add("PerDay45", GetType(System.Double))
			TB_InwardDiscountTable.Columns("PerDay45").AllowDBNull = true
			TB_InwardDiscountTable.Columns("PerDay45").ReadOnly = false
			
			TB_InwardDiscountTable.Columns.Add("DetentionID", GetType(System.Guid))
			TB_InwardDiscountTable.Columns("DetentionID").AllowDBNull = true
			TB_InwardDiscountTable.Columns("DetentionID").ReadOnly = false
			
			TB_InwardDiscountTable.Columns.Add("NoTax", GetType(System.String))
			TB_InwardDiscountTable.Columns("NoTax").AllowDBNull = true
			TB_InwardDiscountTable.Columns("NoTax").ReadOnly = false
			
			TB_InwardDiscountTable.Columns("NoTax").MaxLength = 10

			TB_InwardDiscountTable.PrimaryKey = new DataColumn(){TB_InwardDiscountTable.Columns("ID")}
			
			Dim TB_InwardStatusTable as DataTable = ds.Tables.Add("TB_InwardStatus")
			TB_InwardStatusTable.Columns.Add("ID", GetType(System.Guid))
			TB_InwardStatusTable.Columns("ID").AllowDBNull = false
			TB_InwardStatusTable.Columns("ID").ReadOnly = false
			
			TB_InwardStatusTable.Columns.Add("BLID", GetType(System.Guid))
			TB_InwardStatusTable.Columns("BLID").AllowDBNull = false
			TB_InwardStatusTable.Columns("BLID").ReadOnly = false
			
			TB_InwardStatusTable.Columns.Add("DoOffice", GetType(System.String))
			TB_InwardStatusTable.Columns("DoOffice").AllowDBNull = true
			TB_InwardStatusTable.Columns("DoOffice").ReadOnly = false
			
			TB_InwardStatusTable.Columns("DoOffice").MaxLength = 20

			TB_InwardStatusTable.Columns.Add("DoDate", GetType(System.DateTime))
			TB_InwardStatusTable.Columns("DoDate").AllowDBNull = true
			TB_InwardStatusTable.Columns("DoDate").ReadOnly = false
			
			TB_InwardStatusTable.Columns.Add("Detention", GetType(System.Double))
			TB_InwardStatusTable.Columns("Detention").AllowDBNull = true
			TB_InwardStatusTable.Columns("Detention").ReadOnly = false
			
			TB_InwardStatusTable.Columns.Add("Discont", GetType(System.Single))
			TB_InwardStatusTable.Columns("Discont").AllowDBNull = true
			TB_InwardStatusTable.Columns("Discont").ReadOnly = false
			
			TB_InwardStatusTable.Columns.Add("SetelmentDate", GetType(System.DateTime))
			TB_InwardStatusTable.Columns("SetelmentDate").AllowDBNull = true
			TB_InwardStatusTable.Columns("SetelmentDate").ReadOnly = false
			
			TB_InwardStatusTable.Columns.Add("InvoiceToClinet", GetType(System.Double))
			TB_InwardStatusTable.Columns("InvoiceToClinet").AllowDBNull = true
			TB_InwardStatusTable.Columns("InvoiceToClinet").ReadOnly = false
			
			TB_InwardStatusTable.Columns.Add("ReportToCarrier", GetType(System.Double))
			TB_InwardStatusTable.Columns("ReportToCarrier").AllowDBNull = true
			TB_InwardStatusTable.Columns("ReportToCarrier").ReadOnly = false
			
			TB_InwardStatusTable.Columns.Add("Closed", GetType(System.DateTime))
			TB_InwardStatusTable.Columns("Closed").AllowDBNull = true
			TB_InwardStatusTable.Columns("Closed").ReadOnly = false
			
			TB_InwardStatusTable.PrimaryKey = new DataColumn(){TB_InwardStatusTable.Columns("ID")}
			
			Dim TB_ISOTypeTable as DataTable = ds.Tables.Add("TB_ISOType")
			TB_ISOTypeTable.Columns.Add("ISOTypeID", GetType(System.Guid))
			TB_ISOTypeTable.Columns("ISOTypeID").AllowDBNull = false
			TB_ISOTypeTable.Columns("ISOTypeID").ReadOnly = false
			
			TB_ISOTypeTable.Columns.Add("SizeIS", GetType(System.Byte))
			TB_ISOTypeTable.Columns("SizeIS").AllowDBNull = false
			TB_ISOTypeTable.Columns("SizeIS").ReadOnly = false
			
			TB_ISOTypeTable.Columns.Add("TypeIS", GetType(System.Byte))
			TB_ISOTypeTable.Columns("TypeIS").AllowDBNull = false
			TB_ISOTypeTable.Columns("TypeIS").ReadOnly = false
			
			TB_ISOTypeTable.Columns.Add("HeightIS", GetType(System.Byte))
			TB_ISOTypeTable.Columns("HeightIS").AllowDBNull = false
			TB_ISOTypeTable.Columns("HeightIS").ReadOnly = false
			
			TB_ISOTypeTable.Columns.Add("DispName", GetType(System.String))
			TB_ISOTypeTable.Columns("DispName").AllowDBNull = false
			TB_ISOTypeTable.Columns("DispName").ReadOnly = false
			
			TB_ISOTypeTable.Columns("DispName").MaxLength = 10

			TB_ISOTypeTable.Columns.Add("ISOValue", GetType(System.String))
			TB_ISOTypeTable.Columns("ISOValue").AllowDBNull = false
			TB_ISOTypeTable.Columns("ISOValue").ReadOnly = false
			
			TB_ISOTypeTable.Columns("ISOValue").MaxLength = 10

			TB_ISOTypeTable.Columns.Add("WHLCode", GetType(System.String))
			TB_ISOTypeTable.Columns("WHLCode").AllowDBNull = false
			TB_ISOTypeTable.Columns("WHLCode").ReadOnly = false
			
			TB_ISOTypeTable.Columns("WHLCode").MaxLength = 50

			TB_ISOTypeTable.Columns.Add("TareWeight", GetType(System.Decimal))
			TB_ISOTypeTable.Columns("TareWeight").AllowDBNull = false
			TB_ISOTypeTable.Columns("TareWeight").ReadOnly = false
			
			TB_ISOTypeTable.Columns.Add("WHLSize", GetType(System.String))
			TB_ISOTypeTable.Columns("WHLSize").AllowDBNull = false
			TB_ISOTypeTable.Columns("WHLSize").ReadOnly = false
			
			TB_ISOTypeTable.Columns("WHLSize").MaxLength = 2

			TB_ISOTypeTable.Columns.Add("WHLType", GetType(System.String))
			TB_ISOTypeTable.Columns("WHLType").AllowDBNull = false
			TB_ISOTypeTable.Columns("WHLType").ReadOnly = false
			
			TB_ISOTypeTable.Columns("WHLType").MaxLength = 2

			TB_ISOTypeTable.Columns.Add("WHLHeight", GetType(System.String))
			TB_ISOTypeTable.Columns("WHLHeight").AllowDBNull = false
			TB_ISOTypeTable.Columns("WHLHeight").ReadOnly = false
			
			TB_ISOTypeTable.Columns("WHLHeight").MaxLength = 2

			TB_ISOTypeTable.Columns.Add("PSOType", GetType(System.String))
			TB_ISOTypeTable.Columns("PSOType").AllowDBNull = false
			TB_ISOTypeTable.Columns("PSOType").ReadOnly = false
			
			TB_ISOTypeTable.Columns("PSOType").MaxLength = 5

			TB_ISOTypeTable.Columns.Add("TEU", GetType(System.Byte))
			TB_ISOTypeTable.Columns("TEU").AllowDBNull = false
			TB_ISOTypeTable.Columns("TEU").ReadOnly = false
			
			TB_ISOTypeTable.Columns.Add("OurType", GetType(System.String))
			TB_ISOTypeTable.Columns("OurType").AllowDBNull = true
			TB_ISOTypeTable.Columns("OurType").ReadOnly = false
			
			TB_ISOTypeTable.Columns("OurType").MaxLength = 10

			TB_ISOTypeTable.Columns.Add("InGroup", GetType(System.String))
			TB_ISOTypeTable.Columns("InGroup").AllowDBNull = true
			TB_ISOTypeTable.Columns("InGroup").ReadOnly = false
			
			TB_ISOTypeTable.Columns("InGroup").MaxLength = 10

			TB_ISOTypeTable.PrimaryKey = new DataColumn(){TB_ISOTypeTable.Columns("ISOTypeID")}
			
			Dim TB_LinesTable as DataTable = ds.Tables.Add("TB_Lines")
			TB_LinesTable.Columns.Add("ID", GetType(System.Guid))
			TB_LinesTable.Columns("ID").AllowDBNull = false
			TB_LinesTable.Columns("ID").ReadOnly = false
			
			TB_LinesTable.Columns.Add("LineCode", GetType(System.String))
			TB_LinesTable.Columns("LineCode").AllowDBNull = false
			TB_LinesTable.Columns("LineCode").ReadOnly = false
			
			TB_LinesTable.Columns("LineCode").MaxLength = 20

			TB_LinesTable.Columns.Add("LineName", GetType(System.String))
			TB_LinesTable.Columns("LineName").AllowDBNull = false
			TB_LinesTable.Columns("LineName").ReadOnly = false
			
			TB_LinesTable.Columns("LineName").MaxLength = 500

			TB_LinesTable.Columns.Add("EDICode", GetType(System.String))
			TB_LinesTable.Columns("EDICode").AllowDBNull = false
			TB_LinesTable.Columns("EDICode").ReadOnly = false
			
			TB_LinesTable.Columns("EDICode").MaxLength = 20

			TB_LinesTable.Columns.Add("Address", GetType(System.String))
			TB_LinesTable.Columns("Address").AllowDBNull = true
			TB_LinesTable.Columns("Address").ReadOnly = false
			
			TB_LinesTable.Columns("Address").MaxLength = 500

			TB_LinesTable.Columns.Add("Country", GetType(System.String))
			TB_LinesTable.Columns("Country").AllowDBNull = true
			TB_LinesTable.Columns("Country").ReadOnly = false
			
			TB_LinesTable.Columns("Country").MaxLength = 20

			TB_LinesTable.PrimaryKey = new DataColumn(){TB_LinesTable.Columns("ID")}
			
			Dim TB_LogTable as DataTable = ds.Tables.Add("TB_Log")
			TB_LogTable.Columns.Add("ID", GetType(System.Guid))
			TB_LogTable.Columns("ID").AllowDBNull = false
			TB_LogTable.Columns("ID").ReadOnly = false
			
			TB_LogTable.Columns.Add("DataID", GetType(System.Guid))
			TB_LogTable.Columns("DataID").AllowDBNull = false
			TB_LogTable.Columns("DataID").ReadOnly = false
			
			TB_LogTable.Columns.Add("TableNM", GetType(System.String))
			TB_LogTable.Columns("TableNM").AllowDBNull = false
			TB_LogTable.Columns("TableNM").ReadOnly = false
			
			TB_LogTable.Columns("TableNM").MaxLength = 500

			TB_LogTable.Columns.Add("Remarks", GetType(System.String))
			TB_LogTable.Columns("Remarks").AllowDBNull = true
			TB_LogTable.Columns("Remarks").ReadOnly = false
			
			TB_LogTable.Columns("Remarks").MaxLength = 500

			TB_LogTable.Columns.Add("Action", GetType(System.String))
			TB_LogTable.Columns("Action").AllowDBNull = true
			TB_LogTable.Columns("Action").ReadOnly = false
			
			TB_LogTable.Columns("Action").MaxLength = 100

			TB_LogTable.Columns.Add("LogText", GetType(System.String))
			TB_LogTable.Columns("LogText").AllowDBNull = true
			TB_LogTable.Columns("LogText").ReadOnly = false
			
			TB_LogTable.Columns.Add("LastUpdate", GetType(System.DateTime))
			TB_LogTable.Columns("LastUpdate").AllowDBNull = true
			TB_LogTable.Columns("LastUpdate").ReadOnly = false
			
			TB_LogTable.Columns.Add("LastUser", GetType(System.String))
			TB_LogTable.Columns("LastUser").AllowDBNull = true
			TB_LogTable.Columns("LastUser").ReadOnly = false
			
			TB_LogTable.Columns("LastUser").MaxLength = 30

			TB_LogTable.PrimaryKey = new DataColumn(){TB_LogTable.Columns("ID")}
			
			Dim TB_LogDetailsTable as DataTable = ds.Tables.Add("TB_LogDetails")
			TB_LogDetailsTable.Columns.Add("ID", GetType(System.Guid))
			TB_LogDetailsTable.Columns("ID").AllowDBNull = false
			TB_LogDetailsTable.Columns("ID").ReadOnly = false
			
			TB_LogDetailsTable.Columns.Add("LogID", GetType(System.Guid))
			TB_LogDetailsTable.Columns("LogID").AllowDBNull = true
			TB_LogDetailsTable.Columns("LogID").ReadOnly = false
			
			TB_LogDetailsTable.Columns.Add("FieldName", GetType(System.String))
			TB_LogDetailsTable.Columns("FieldName").AllowDBNull = true
			TB_LogDetailsTable.Columns("FieldName").ReadOnly = false
			
			TB_LogDetailsTable.Columns("FieldName").MaxLength = 100

			TB_LogDetailsTable.Columns.Add("OldValue", GetType(System.String))
			TB_LogDetailsTable.Columns("OldValue").AllowDBNull = true
			TB_LogDetailsTable.Columns("OldValue").ReadOnly = false
			
			TB_LogDetailsTable.Columns.Add("NewValue", GetType(System.String))
			TB_LogDetailsTable.Columns("NewValue").AllowDBNull = true
			TB_LogDetailsTable.Columns("NewValue").ReadOnly = false
			
			TB_LogDetailsTable.PrimaryKey = new DataColumn(){TB_LogDetailsTable.Columns("ID")}
			
			Dim TB_LogMasterTable as DataTable = ds.Tables.Add("TB_LogMaster")
			TB_LogMasterTable.Columns.Add("ID", GetType(System.Guid))
			TB_LogMasterTable.Columns("ID").AllowDBNull = false
			TB_LogMasterTable.Columns("ID").ReadOnly = false
			
			TB_LogMasterTable.Columns.Add("TBName", GetType(System.String))
			TB_LogMasterTable.Columns("TBName").AllowDBNull = true
			TB_LogMasterTable.Columns("TBName").ReadOnly = false
			
			TB_LogMasterTable.Columns("TBName").MaxLength = 100

			TB_LogMasterTable.Columns.Add("TableKey", GetType(System.Guid))
			TB_LogMasterTable.Columns("TableKey").AllowDBNull = true
			TB_LogMasterTable.Columns("TableKey").ReadOnly = false
			
			TB_LogMasterTable.Columns.Add("ActionUser", GetType(System.String))
			TB_LogMasterTable.Columns("ActionUser").AllowDBNull = true
			TB_LogMasterTable.Columns("ActionUser").ReadOnly = false
			
			TB_LogMasterTable.Columns("ActionUser").MaxLength = 100

			TB_LogMasterTable.Columns.Add("ActionTime", GetType(System.DateTime))
			TB_LogMasterTable.Columns("ActionTime").AllowDBNull = true
			TB_LogMasterTable.Columns("ActionTime").ReadOnly = false
			
			TB_LogMasterTable.Columns.Add("ActionType", GetType(System.String))
			TB_LogMasterTable.Columns("ActionType").AllowDBNull = true
			TB_LogMasterTable.Columns("ActionType").ReadOnly = false
			
			TB_LogMasterTable.Columns("ActionType").MaxLength = 20

			TB_LogMasterTable.PrimaryKey = new DataColumn(){TB_LogMasterTable.Columns("ID")}
			
			Dim TB_MenuItemsTable as DataTable = ds.Tables.Add("TB_MenuItems")
			TB_MenuItemsTable.Columns.Add("ID", GetType(System.Guid))
			TB_MenuItemsTable.Columns("ID").AllowDBNull = false
			TB_MenuItemsTable.Columns("ID").ReadOnly = false
			
			TB_MenuItemsTable.Columns.Add("Description", GetType(System.String))
			TB_MenuItemsTable.Columns("Description").AllowDBNull = true
			TB_MenuItemsTable.Columns("Description").ReadOnly = false
			
			TB_MenuItemsTable.Columns("Description").MaxLength = 100

			TB_MenuItemsTable.Columns.Add("ItemLevel", GetType(System.String))
			TB_MenuItemsTable.Columns("ItemLevel").AllowDBNull = false
			TB_MenuItemsTable.Columns("ItemLevel").ReadOnly = false
			
			TB_MenuItemsTable.Columns("ItemLevel").MaxLength = 100

			TB_MenuItemsTable.Columns.Add("ItemKey", GetType(System.String))
			TB_MenuItemsTable.Columns("ItemKey").AllowDBNull = false
			TB_MenuItemsTable.Columns("ItemKey").ReadOnly = false
			
			TB_MenuItemsTable.Columns("ItemKey").MaxLength = 100

			TB_MenuItemsTable.PrimaryKey = new DataColumn(){TB_MenuItemsTable.Columns("ID")}
			
			Dim TB_NOSPaymentTypsTable as DataTable = ds.Tables.Add("TB_NOSPaymentTyps")
			TB_NOSPaymentTypsTable.Columns.Add("ID", GetType(System.Guid))
			TB_NOSPaymentTypsTable.Columns("ID").AllowDBNull = false
			TB_NOSPaymentTypsTable.Columns("ID").ReadOnly = false
			
			TB_NOSPaymentTypsTable.Columns.Add("PaymentType", GetType(System.String))
			TB_NOSPaymentTypsTable.Columns("PaymentType").AllowDBNull = false
			TB_NOSPaymentTypsTable.Columns("PaymentType").ReadOnly = false
			
			TB_NOSPaymentTypsTable.Columns("PaymentType").MaxLength = 20

			TB_NOSPaymentTypsTable.Columns.Add("Description", GetType(System.String))
			TB_NOSPaymentTypsTable.Columns("Description").AllowDBNull = false
			TB_NOSPaymentTypsTable.Columns("Description").ReadOnly = false
			
			TB_NOSPaymentTypsTable.Columns("Description").MaxLength = 510

			TB_NOSPaymentTypsTable.Columns.Add("Line", GetType(System.String))
			TB_NOSPaymentTypsTable.Columns("Line").AllowDBNull = true
			TB_NOSPaymentTypsTable.Columns("Line").ReadOnly = false
			
			TB_NOSPaymentTypsTable.Columns("Line").MaxLength = 10

			TB_NOSPaymentTypsTable.Columns.Add("Port", GetType(System.String))
			TB_NOSPaymentTypsTable.Columns("Port").AllowDBNull = true
			TB_NOSPaymentTypsTable.Columns("Port").ReadOnly = false
			
			TB_NOSPaymentTypsTable.Columns("Port").MaxLength = 5

			TB_NOSPaymentTypsTable.Columns.Add("BANK", GetType(System.String))
			TB_NOSPaymentTypsTable.Columns("BANK").AllowDBNull = true
			TB_NOSPaymentTypsTable.Columns("BANK").ReadOnly = false
			
			TB_NOSPaymentTypsTable.Columns("BANK").MaxLength = 10

			TB_NOSPaymentTypsTable.Columns.Add("DBAccount", GetType(System.String))
			TB_NOSPaymentTypsTable.Columns("DBAccount").AllowDBNull = true
			TB_NOSPaymentTypsTable.Columns("DBAccount").ReadOnly = false
			
			TB_NOSPaymentTypsTable.Columns("DBAccount").MaxLength = 20

			TB_NOSPaymentTypsTable.Columns.Add("DBLevel1", GetType(System.String))
			TB_NOSPaymentTypsTable.Columns("DBLevel1").AllowDBNull = true
			TB_NOSPaymentTypsTable.Columns("DBLevel1").ReadOnly = false
			
			TB_NOSPaymentTypsTable.Columns("DBLevel1").MaxLength = 20

			TB_NOSPaymentTypsTable.Columns.Add("DBLevel2", GetType(System.String))
			TB_NOSPaymentTypsTable.Columns("DBLevel2").AllowDBNull = true
			TB_NOSPaymentTypsTable.Columns("DBLevel2").ReadOnly = false
			
			TB_NOSPaymentTypsTable.Columns("DBLevel2").MaxLength = 20

			TB_NOSPaymentTypsTable.Columns.Add("DBLevel3", GetType(System.String))
			TB_NOSPaymentTypsTable.Columns("DBLevel3").AllowDBNull = true
			TB_NOSPaymentTypsTable.Columns("DBLevel3").ReadOnly = false
			
			TB_NOSPaymentTypsTable.Columns("DBLevel3").MaxLength = 20

			TB_NOSPaymentTypsTable.Columns.Add("DBLevel4", GetType(System.String))
			TB_NOSPaymentTypsTable.Columns("DBLevel4").AllowDBNull = true
			TB_NOSPaymentTypsTable.Columns("DBLevel4").ReadOnly = false
			
			TB_NOSPaymentTypsTable.Columns("DBLevel4").MaxLength = 20

			TB_NOSPaymentTypsTable.Columns.Add("DBLevel5", GetType(System.String))
			TB_NOSPaymentTypsTable.Columns("DBLevel5").AllowDBNull = true
			TB_NOSPaymentTypsTable.Columns("DBLevel5").ReadOnly = false
			
			TB_NOSPaymentTypsTable.Columns("DBLevel5").MaxLength = 20

			TB_NOSPaymentTypsTable.PrimaryKey = new DataColumn(){TB_NOSPaymentTypsTable.Columns("ID")}
			
			Dim TB_ObjectsTable as DataTable = ds.Tables.Add("TB_Objects")
			TB_ObjectsTable.Columns.Add("ID", GetType(System.Guid))
			TB_ObjectsTable.Columns("ID").AllowDBNull = false
			TB_ObjectsTable.Columns("ID").ReadOnly = false
			
			TB_ObjectsTable.Columns.Add("ObjectName", GetType(System.String))
			TB_ObjectsTable.Columns("ObjectName").AllowDBNull = true
			TB_ObjectsTable.Columns("ObjectName").ReadOnly = false
			
			TB_ObjectsTable.Columns("ObjectName").MaxLength = 100

			TB_ObjectsTable.Columns.Add("ObjectContent", GetType(System.Byte()))
			TB_ObjectsTable.Columns("ObjectContent").AllowDBNull = true
			TB_ObjectsTable.Columns("ObjectContent").ReadOnly = false
			
			TB_ObjectsTable.Columns.Add("Remarks", GetType(System.String))
			TB_ObjectsTable.Columns("Remarks").AllowDBNull = true
			TB_ObjectsTable.Columns("Remarks").ReadOnly = false
			
			TB_ObjectsTable.Columns("Remarks").MaxLength = 100

			TB_ObjectsTable.Columns.Add("CreateDate", GetType(System.DateTime))
			TB_ObjectsTable.Columns("CreateDate").AllowDBNull = true
			TB_ObjectsTable.Columns("CreateDate").ReadOnly = false
			
			TB_ObjectsTable.Columns.Add("ModifyDate", GetType(System.DateTime))
			TB_ObjectsTable.Columns("ModifyDate").AllowDBNull = true
			TB_ObjectsTable.Columns("ModifyDate").ReadOnly = false
			
			TB_ObjectsTable.PrimaryKey = new DataColumn(){TB_ObjectsTable.Columns("ID")}
			
			Dim TB_ObjectsUserTable as DataTable = ds.Tables.Add("TB_ObjectsUser")
			TB_ObjectsUserTable.Columns.Add("ID", GetType(System.Guid))
			TB_ObjectsUserTable.Columns("ID").AllowDBNull = false
			TB_ObjectsUserTable.Columns("ID").ReadOnly = false
			
			TB_ObjectsUserTable.Columns.Add("ObjectLine", GetType(System.String))
			TB_ObjectsUserTable.Columns("ObjectLine").AllowDBNull = false
			TB_ObjectsUserTable.Columns("ObjectLine").ReadOnly = false
			
			TB_ObjectsUserTable.Columns("ObjectLine").MaxLength = 10

			TB_ObjectsUserTable.Columns.Add("ObjectGroup", GetType(System.String))
			TB_ObjectsUserTable.Columns("ObjectGroup").AllowDBNull = false
			TB_ObjectsUserTable.Columns("ObjectGroup").ReadOnly = false
			
			TB_ObjectsUserTable.Columns("ObjectGroup").MaxLength = 10

			TB_ObjectsUserTable.Columns.Add("ObjectName", GetType(System.String))
			TB_ObjectsUserTable.Columns("ObjectName").AllowDBNull = false
			TB_ObjectsUserTable.Columns("ObjectName").ReadOnly = false
			
			TB_ObjectsUserTable.Columns("ObjectName").MaxLength = 50

			TB_ObjectsUserTable.Columns.Add("ObjectRemarks", GetType(System.String))
			TB_ObjectsUserTable.Columns("ObjectRemarks").AllowDBNull = true
			TB_ObjectsUserTable.Columns("ObjectRemarks").ReadOnly = false
			
			TB_ObjectsUserTable.Columns("ObjectRemarks").MaxLength = 510

			TB_ObjectsUserTable.Columns.Add("ObjectContent", GetType(System.Byte()))
			TB_ObjectsUserTable.Columns("ObjectContent").AllowDBNull = true
			TB_ObjectsUserTable.Columns("ObjectContent").ReadOnly = false
			
			TB_ObjectsUserTable.PrimaryKey = new DataColumn(){TB_ObjectsUserTable.Columns("ID")}
			
			Dim TB_OutwardBLSTable as DataTable = ds.Tables.Add("TB_OutwardBLS")
			TB_OutwardBLSTable.Columns.Add("ID", GetType(System.Guid))
			TB_OutwardBLSTable.Columns("ID").AllowDBNull = false
			TB_OutwardBLSTable.Columns("ID").ReadOnly = false
			
			TB_OutwardBLSTable.Columns.Add("Service", GetType(System.String))
			TB_OutwardBLSTable.Columns("Service").AllowDBNull = false
			TB_OutwardBLSTable.Columns("Service").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("Service").MaxLength = 20

			TB_OutwardBLSTable.Columns.Add("Line", GetType(System.String))
			TB_OutwardBLSTable.Columns("Line").AllowDBNull = true
			TB_OutwardBLSTable.Columns("Line").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("Line").MaxLength = 20

			TB_OutwardBLSTable.Columns.Add("BlNo", GetType(System.String))
			TB_OutwardBLSTable.Columns("BlNo").AllowDBNull = false
			TB_OutwardBLSTable.Columns("BlNo").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("BlNo").MaxLength = 70

			TB_OutwardBLSTable.Columns.Add("IssuePlace", GetType(System.String))
			TB_OutwardBLSTable.Columns("IssuePlace").AllowDBNull = true
			TB_OutwardBLSTable.Columns("IssuePlace").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("IssuePlace").MaxLength = 10

			TB_OutwardBLSTable.Columns.Add("IssueDate", GetType(System.DateTime))
			TB_OutwardBLSTable.Columns("IssueDate").AllowDBNull = true
			TB_OutwardBLSTable.Columns("IssueDate").ReadOnly = false
			
			TB_OutwardBLSTable.Columns.Add("OnBoardDate", GetType(System.DateTime))
			TB_OutwardBLSTable.Columns("OnBoardDate").AllowDBNull = true
			TB_OutwardBLSTable.Columns("OnBoardDate").ReadOnly = false
			
			TB_OutwardBLSTable.Columns.Add("POR", GetType(System.String))
			TB_OutwardBLSTable.Columns("POR").AllowDBNull = true
			TB_OutwardBLSTable.Columns("POR").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("POR").MaxLength = 10

			TB_OutwardBLSTable.Columns.Add("POL", GetType(System.String))
			TB_OutwardBLSTable.Columns("POL").AllowDBNull = false
			TB_OutwardBLSTable.Columns("POL").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("POL").MaxLength = 10

			TB_OutwardBLSTable.Columns.Add("POT", GetType(System.String))
			TB_OutwardBLSTable.Columns("POT").AllowDBNull = true
			TB_OutwardBLSTable.Columns("POT").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("POT").MaxLength = 10

			TB_OutwardBLSTable.Columns.Add("POD", GetType(System.String))
			TB_OutwardBLSTable.Columns("POD").AllowDBNull = false
			TB_OutwardBLSTable.Columns("POD").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("POD").MaxLength = 10

			TB_OutwardBLSTable.Columns.Add("FPOD", GetType(System.String))
			TB_OutwardBLSTable.Columns("FPOD").AllowDBNull = true
			TB_OutwardBLSTable.Columns("FPOD").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("FPOD").MaxLength = 10

			TB_OutwardBLSTable.Columns.Add("PreVoyageID", GetType(System.Guid))
			TB_OutwardBLSTable.Columns("PreVoyageID").AllowDBNull = true
			TB_OutwardBLSTable.Columns("PreVoyageID").ReadOnly = false
			
			TB_OutwardBLSTable.Columns.Add("VoyageID", GetType(System.Guid))
			TB_OutwardBLSTable.Columns("VoyageID").AllowDBNull = true
			TB_OutwardBLSTable.Columns("VoyageID").ReadOnly = false
			
			TB_OutwardBLSTable.Columns.Add("NoOfBls", GetType(System.Int16))
			TB_OutwardBLSTable.Columns("NoOfBls").AllowDBNull = false
			TB_OutwardBLSTable.Columns("NoOfBls").ReadOnly = false
			
			TB_OutwardBLSTable.Columns.Add("TermsOfPayment", GetType(System.String))
			TB_OutwardBLSTable.Columns("TermsOfPayment").AllowDBNull = false
			TB_OutwardBLSTable.Columns("TermsOfPayment").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("TermsOfPayment").MaxLength = 20

			TB_OutwardBLSTable.Columns.Add("ClientID", GetType(System.Guid))
			TB_OutwardBLSTable.Columns("ClientID").AllowDBNull = true
			TB_OutwardBLSTable.Columns("ClientID").ReadOnly = false
			
			TB_OutwardBLSTable.Columns.Add("FCLType", GetType(System.String))
			TB_OutwardBLSTable.Columns("FCLType").AllowDBNull = true
			TB_OutwardBLSTable.Columns("FCLType").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("FCLType").MaxLength = 20

			TB_OutwardBLSTable.Columns.Add("Remarks", GetType(System.String))
			TB_OutwardBLSTable.Columns("Remarks").AllowDBNull = true
			TB_OutwardBLSTable.Columns("Remarks").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("Remarks").MaxLength = 500

			TB_OutwardBLSTable.Columns.Add("Reference", GetType(System.Int64))
			TB_OutwardBLSTable.Columns("Reference").AllowDBNull = true
			TB_OutwardBLSTable.Columns("Reference").ReadOnly = false
			
			TB_OutwardBLSTable.Columns.Add("MailRelease", GetType(System.Boolean))
			TB_OutwardBLSTable.Columns("MailRelease").AllowDBNull = true
			TB_OutwardBLSTable.Columns("MailRelease").ReadOnly = false
			
			TB_OutwardBLSTable.Columns.Add("MailReleaseRem", GetType(System.String))
			TB_OutwardBLSTable.Columns("MailReleaseRem").AllowDBNull = true
			TB_OutwardBLSTable.Columns("MailReleaseRem").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("MailReleaseRem").MaxLength = 500

			TB_OutwardBLSTable.Columns.Add("FrtCoverdCarr", GetType(System.String))
			TB_OutwardBLSTable.Columns("FrtCoverdCarr").AllowDBNull = true
			TB_OutwardBLSTable.Columns("FrtCoverdCarr").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("FrtCoverdCarr").MaxLength = 20

			TB_OutwardBLSTable.Columns.Add("FrtCoverdBlNo", GetType(System.String))
			TB_OutwardBLSTable.Columns("FrtCoverdBlNo").AllowDBNull = true
			TB_OutwardBLSTable.Columns("FrtCoverdBlNo").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("FrtCoverdBlNo").MaxLength = 70

			TB_OutwardBLSTable.Columns.Add("Status", GetType(System.String))
			TB_OutwardBLSTable.Columns("Status").AllowDBNull = true
			TB_OutwardBLSTable.Columns("Status").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("Status").MaxLength = 20

			TB_OutwardBLSTable.Columns.Add("LcNo", GetType(System.String))
			TB_OutwardBLSTable.Columns("LcNo").AllowDBNull = true
			TB_OutwardBLSTable.Columns("LcNo").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("LcNo").MaxLength = 40

			TB_OutwardBLSTable.Columns.Add("BlStatus", GetType(System.String))
			TB_OutwardBLSTable.Columns("BlStatus").AllowDBNull = true
			TB_OutwardBLSTable.Columns("BlStatus").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("BlStatus").MaxLength = 20

			TB_OutwardBLSTable.Columns.Add("BookingID", GetType(System.Guid))
			TB_OutwardBLSTable.Columns("BookingID").AllowDBNull = true
			TB_OutwardBLSTable.Columns("BookingID").ReadOnly = false
			
			TB_OutwardBLSTable.Columns.Add("BookingNo", GetType(System.String))
			TB_OutwardBLSTable.Columns("BookingNo").AllowDBNull = true
			TB_OutwardBLSTable.Columns("BookingNo").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("BookingNo").MaxLength = 50

			TB_OutwardBLSTable.Columns.Add("MBL", GetType(System.String))
			TB_OutwardBLSTable.Columns("MBL").AllowDBNull = true
			TB_OutwardBLSTable.Columns("MBL").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("MBL").MaxLength = 50

			TB_OutwardBLSTable.Columns.Add("FwdLine", GetType(System.String))
			TB_OutwardBLSTable.Columns("FwdLine").AllowDBNull = true
			TB_OutwardBLSTable.Columns("FwdLine").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("FwdLine").MaxLength = 50

			TB_OutwardBLSTable.Columns.Add("FwAgent", GetType(System.String))
			TB_OutwardBLSTable.Columns("FwAgent").AllowDBNull = true
			TB_OutwardBLSTable.Columns("FwAgent").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("FwAgent").MaxLength = 50

			TB_OutwardBLSTable.Columns.Add("JobNumber", GetType(System.String))
			TB_OutwardBLSTable.Columns("JobNumber").AllowDBNull = true
			TB_OutwardBLSTable.Columns("JobNumber").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("JobNumber").MaxLength = 50

			TB_OutwardBLSTable.Columns.Add("TFCCode", GetType(System.String))
			TB_OutwardBLSTable.Columns("TFCCode").AllowDBNull = true
			TB_OutwardBLSTable.Columns("TFCCode").ReadOnly = false
			
			TB_OutwardBLSTable.Columns("TFCCode").MaxLength = 20

			TB_OutwardBLSTable.Columns.Add("BarCode", GetType(System.String))
			TB_OutwardBLSTable.Columns("BarCode").AllowDBNull = true
			TB_OutwardBLSTable.Columns("BarCode").ReadOnly = false
			
            TB_OutwardBLSTable.Columns("BarCode").MaxLength = 25

            TB_OutwardBLSTable.Columns.Add("AgentID", GetType(System.Guid))
            TB_OutwardBLSTable.Columns("AgentID").AllowDBNull = True
            TB_OutwardBLSTable.Columns("AgentID").ReadOnly = False

            TB_OutwardBLSTable.Columns.Add("BarCode2", GetType(System.String))
            TB_OutwardBLSTable.Columns("BarCode2").AllowDBNull = True
            TB_OutwardBLSTable.Columns("BarCode2").ReadOnly = False

            TB_OutwardBLSTable.Columns("BarCode2").MaxLength = 25

            TB_OutwardBLSTable.Columns.Add("BarCode3", GetType(System.String))
            TB_OutwardBLSTable.Columns("BarCode3").AllowDBNull = True
            TB_OutwardBLSTable.Columns("BarCode3").ReadOnly = False

            TB_OutwardBLSTable.Columns.Add("Depot", GetType(System.String))
            TB_OutwardBLSTable.Columns("Depot").AllowDBNull = True
            TB_OutwardBLSTable.Columns("Depot").ReadOnly = False


            TB_OutwardBLSTable.Columns("BarCode3").MaxLength = 25

			TB_OutwardBLSTable.PrimaryKey = new DataColumn(){TB_OutwardBLSTable.Columns("ID")}
			
			Dim TB_OutwardBlsCommentsTable as DataTable = ds.Tables.Add("TB_OutwardBlsComments")
			TB_OutwardBlsCommentsTable.Columns.Add("ID", GetType(System.Guid))
			TB_OutwardBlsCommentsTable.Columns("ID").AllowDBNull = false
			TB_OutwardBlsCommentsTable.Columns("ID").ReadOnly = false
			
			TB_OutwardBlsCommentsTable.Columns.Add("BLID", GetType(System.Guid))
			TB_OutwardBlsCommentsTable.Columns("BLID").AllowDBNull = false
			TB_OutwardBlsCommentsTable.Columns("BLID").ReadOnly = false
			
			TB_OutwardBlsCommentsTable.Columns.Add("CommentType", GetType(System.String))
			TB_OutwardBlsCommentsTable.Columns("CommentType").AllowDBNull = false
			TB_OutwardBlsCommentsTable.Columns("CommentType").ReadOnly = false
			
			TB_OutwardBlsCommentsTable.Columns("CommentType").MaxLength = 10

			TB_OutwardBlsCommentsTable.Columns.Add("Comment", GetType(System.String))
			TB_OutwardBlsCommentsTable.Columns("Comment").AllowDBNull = false
			TB_OutwardBlsCommentsTable.Columns("Comment").ReadOnly = false
			
			TB_OutwardBlsCommentsTable.Columns.Add("CommentDate", GetType(System.DateTime))
			TB_OutwardBlsCommentsTable.Columns("CommentDate").AllowDBNull = true
			TB_OutwardBlsCommentsTable.Columns("CommentDate").ReadOnly = false
			
			TB_OutwardBlsCommentsTable.PrimaryKey = new DataColumn(){TB_OutwardBlsCommentsTable.Columns("ID")}
			
			Dim Tb_OutwardBlsFrsTable as DataTable = ds.Tables.Add("Tb_OutwardBlsFrs")
			Tb_OutwardBlsFrsTable.Columns.Add("ID", GetType(System.Guid))
			Tb_OutwardBlsFrsTable.Columns("ID").AllowDBNull = false
			Tb_OutwardBlsFrsTable.Columns("ID").ReadOnly = false
			
			Tb_OutwardBlsFrsTable.Columns.Add("BLID", GetType(System.Guid))
			Tb_OutwardBlsFrsTable.Columns("BLID").AllowDBNull = false
			Tb_OutwardBlsFrsTable.Columns("BLID").ReadOnly = false
			
			Tb_OutwardBlsFrsTable.Columns.Add("FCnee", GetType(System.String))
			Tb_OutwardBlsFrsTable.Columns("FCnee").AllowDBNull = true
			Tb_OutwardBlsFrsTable.Columns("FCnee").ReadOnly = false
			
			Tb_OutwardBlsFrsTable.Columns.Add("FGoods", GetType(System.String))
			Tb_OutwardBlsFrsTable.Columns("FGoods").AllowDBNull = true
			Tb_OutwardBlsFrsTable.Columns("FGoods").ReadOnly = false
			
			Tb_OutwardBlsFrsTable.Columns.Add("FPkgs", GetType(System.String))
			Tb_OutwardBlsFrsTable.Columns("FPkgs").AllowDBNull = true
			Tb_OutwardBlsFrsTable.Columns("FPkgs").ReadOnly = false
			
			Tb_OutwardBlsFrsTable.PrimaryKey = new DataColumn(){Tb_OutwardBlsFrsTable.Columns("ID")}
			
			Dim TB_OutwardBlsGoodsTable as DataTable = ds.Tables.Add("TB_OutwardBlsGoods")
			TB_OutwardBlsGoodsTable.Columns.Add("ID", GetType(System.Guid))
			TB_OutwardBlsGoodsTable.Columns("ID").AllowDBNull = false
			TB_OutwardBlsGoodsTable.Columns("ID").ReadOnly = false
			
			TB_OutwardBlsGoodsTable.Columns.Add("BLID", GetType(System.Guid))
			TB_OutwardBlsGoodsTable.Columns("BLID").AllowDBNull = false
			TB_OutwardBlsGoodsTable.Columns("BLID").ReadOnly = false
			
			TB_OutwardBlsGoodsTable.Columns.Add("Goods", GetType(System.String))
			TB_OutwardBlsGoodsTable.Columns("Goods").AllowDBNull = true
			TB_OutwardBlsGoodsTable.Columns("Goods").ReadOnly = false
			
			TB_OutwardBlsGoodsTable.Columns.Add("Marks", GetType(System.String))
			TB_OutwardBlsGoodsTable.Columns("Marks").AllowDBNull = true
			TB_OutwardBlsGoodsTable.Columns("Marks").ReadOnly = false
			
			TB_OutwardBlsGoodsTable.Columns.Add("MainCom", GetType(System.String))
			TB_OutwardBlsGoodsTable.Columns("MainCom").AllowDBNull = true
			TB_OutwardBlsGoodsTable.Columns("MainCom").ReadOnly = false
			
			TB_OutwardBlsGoodsTable.Columns("MainCom").MaxLength = 500

			TB_OutwardBlsGoodsTable.Columns.Add("TTW", GetType(System.Int64))
			TB_OutwardBlsGoodsTable.Columns("TTW").AllowDBNull = true
			TB_OutwardBlsGoodsTable.Columns("TTW").ReadOnly = false
			
			TB_OutwardBlsGoodsTable.Columns.Add("TGW", GetType(System.Double))
			TB_OutwardBlsGoodsTable.Columns("TGW").AllowDBNull = true
			TB_OutwardBlsGoodsTable.Columns("TGW").ReadOnly = false
			
			TB_OutwardBlsGoodsTable.Columns.Add("TTLPkgs", GetType(System.Int64))
			TB_OutwardBlsGoodsTable.Columns("TTLPkgs").AllowDBNull = true
			TB_OutwardBlsGoodsTable.Columns("TTLPkgs").ReadOnly = false
			
			TB_OutwardBlsGoodsTable.Columns.Add("TTLCBM", GetType(System.Double))
			TB_OutwardBlsGoodsTable.Columns("TTLCBM").AllowDBNull = true
			TB_OutwardBlsGoodsTable.Columns("TTLCBM").ReadOnly = false
			
			TB_OutwardBlsGoodsTable.Columns.Add("TTLNET", GetType(System.Double))
			TB_OutwardBlsGoodsTable.Columns("TTLNET").AllowDBNull = true
			TB_OutwardBlsGoodsTable.Columns("TTLNET").ReadOnly = false
			
			TB_OutwardBlsGoodsTable.PrimaryKey = new DataColumn(){TB_OutwardBlsGoodsTable.Columns("ID")}
			
			Dim TB_OutwardBlsNamesTable as DataTable = ds.Tables.Add("TB_OutwardBlsNames")
			TB_OutwardBlsNamesTable.Columns.Add("ID", GetType(System.Guid))
			TB_OutwardBlsNamesTable.Columns("ID").AllowDBNull = false
			TB_OutwardBlsNamesTable.Columns("ID").ReadOnly = false
			
			TB_OutwardBlsNamesTable.Columns.Add("BLID", GetType(System.Guid))
			TB_OutwardBlsNamesTable.Columns("BLID").AllowDBNull = false
			TB_OutwardBlsNamesTable.Columns("BLID").ReadOnly = false
			
			TB_OutwardBlsNamesTable.Columns.Add("Shipper", GetType(System.String))
			TB_OutwardBlsNamesTable.Columns("Shipper").AllowDBNull = true
			TB_OutwardBlsNamesTable.Columns("Shipper").ReadOnly = false
			
			TB_OutwardBlsNamesTable.Columns.Add("Cnee", GetType(System.String))
			TB_OutwardBlsNamesTable.Columns("Cnee").AllowDBNull = true
			TB_OutwardBlsNamesTable.Columns("Cnee").ReadOnly = false
			
			TB_OutwardBlsNamesTable.Columns.Add("Notify1", GetType(System.String))
			TB_OutwardBlsNamesTable.Columns("Notify1").AllowDBNull = true
			TB_OutwardBlsNamesTable.Columns("Notify1").ReadOnly = false
			
			TB_OutwardBlsNamesTable.Columns.Add("Notify2", GetType(System.String))
			TB_OutwardBlsNamesTable.Columns("Notify2").AllowDBNull = true
			TB_OutwardBlsNamesTable.Columns("Notify2").ReadOnly = false
			
			TB_OutwardBlsNamesTable.Columns.Add("Notify3", GetType(System.String))
			TB_OutwardBlsNamesTable.Columns("Notify3").AllowDBNull = true
			TB_OutwardBlsNamesTable.Columns("Notify3").ReadOnly = false
			
			TB_OutwardBlsNamesTable.Columns.Add("Messers", GetType(System.String))
			TB_OutwardBlsNamesTable.Columns("Messers").AllowDBNull = true
			TB_OutwardBlsNamesTable.Columns("Messers").ReadOnly = false
			
			TB_OutwardBlsNamesTable.Columns("Messers").MaxLength = 500

			TB_OutwardBlsNamesTable.Columns.Add("ShipperID", GetType(System.String))
			TB_OutwardBlsNamesTable.Columns("ShipperID").AllowDBNull = true
			TB_OutwardBlsNamesTable.Columns("ShipperID").ReadOnly = false
			
			TB_OutwardBlsNamesTable.Columns("ShipperID").MaxLength = 50

			TB_OutwardBlsNamesTable.Columns.Add("CneeID", GetType(System.String))
			TB_OutwardBlsNamesTable.Columns("CneeID").AllowDBNull = true
			TB_OutwardBlsNamesTable.Columns("CneeID").ReadOnly = false
			
			TB_OutwardBlsNamesTable.Columns("CneeID").MaxLength = 50

			TB_OutwardBlsNamesTable.Columns.Add("Notify1ID", GetType(System.String))
			TB_OutwardBlsNamesTable.Columns("Notify1ID").AllowDBNull = true
			TB_OutwardBlsNamesTable.Columns("Notify1ID").ReadOnly = false
			
			TB_OutwardBlsNamesTable.Columns("Notify1ID").MaxLength = 50

			TB_OutwardBlsNamesTable.Columns.Add("Notify2ID", GetType(System.String))
			TB_OutwardBlsNamesTable.Columns("Notify2ID").AllowDBNull = true
			TB_OutwardBlsNamesTable.Columns("Notify2ID").ReadOnly = false
			
			TB_OutwardBlsNamesTable.Columns("Notify2ID").MaxLength = 50

			TB_OutwardBlsNamesTable.Columns.Add("Notify3ID", GetType(System.String))
			TB_OutwardBlsNamesTable.Columns("Notify3ID").AllowDBNull = true
			TB_OutwardBlsNamesTable.Columns("Notify3ID").ReadOnly = false
			
			TB_OutwardBlsNamesTable.Columns("Notify3ID").MaxLength = 50

			TB_OutwardBlsNamesTable.Columns.Add("Forwarder", GetType(System.String))
			TB_OutwardBlsNamesTable.Columns("Forwarder").AllowDBNull = true
			TB_OutwardBlsNamesTable.Columns("Forwarder").ReadOnly = false
			
			TB_OutwardBlsNamesTable.Columns.Add("ForwarderID", GetType(System.String))
			TB_OutwardBlsNamesTable.Columns("ForwarderID").AllowDBNull = true
			TB_OutwardBlsNamesTable.Columns("ForwarderID").ReadOnly = false
			
			TB_OutwardBlsNamesTable.Columns("ForwarderID").MaxLength = 50

			TB_OutwardBlsNamesTable.PrimaryKey = new DataColumn(){TB_OutwardBlsNamesTable.Columns("ID")}
			
			Dim TB_OutwardBlsTemplateTable as DataTable = ds.Tables.Add("TB_OutwardBlsTemplate")
			TB_OutwardBlsTemplateTable.Columns.Add("ID", GetType(System.Guid))
			TB_OutwardBlsTemplateTable.Columns("ID").AllowDBNull = false
			TB_OutwardBlsTemplateTable.Columns("ID").ReadOnly = false
			
			TB_OutwardBlsTemplateTable.Columns.Add("BLID", GetType(System.Guid))
			TB_OutwardBlsTemplateTable.Columns("BLID").AllowDBNull = true
			TB_OutwardBlsTemplateTable.Columns("BLID").ReadOnly = false
			
			TB_OutwardBlsTemplateTable.Columns.Add("XML", GetType(System.String))
			TB_OutwardBlsTemplateTable.Columns("XML").AllowDBNull = true
			TB_OutwardBlsTemplateTable.Columns("XML").ReadOnly = false
			
			TB_OutwardBlsTemplateTable.PrimaryKey = new DataColumn(){TB_OutwardBlsTemplateTable.Columns("ID")}
			
			Dim TB_OutwardChargesTable as DataTable = ds.Tables.Add("TB_OutwardCharges")
			TB_OutwardChargesTable.Columns.Add("ID", GetType(System.Guid))
			TB_OutwardChargesTable.Columns("ID").AllowDBNull = false
			TB_OutwardChargesTable.Columns("ID").ReadOnly = false
			
			TB_OutwardChargesTable.Columns.Add("BLID", GetType(System.Guid))
			TB_OutwardChargesTable.Columns("BLID").AllowDBNull = false
			TB_OutwardChargesTable.Columns("BLID").ReadOnly = false
			
			TB_OutwardChargesTable.Columns.Add("Seq", GetType(System.Int16))
			TB_OutwardChargesTable.Columns("Seq").AllowDBNull = false
			TB_OutwardChargesTable.Columns("Seq").ReadOnly = false
			
			TB_OutwardChargesTable.Columns.Add("ChargesCode", GetType(System.String))
			TB_OutwardChargesTable.Columns("ChargesCode").AllowDBNull = false
			TB_OutwardChargesTable.Columns("ChargesCode").ReadOnly = false
			
			TB_OutwardChargesTable.Columns("ChargesCode").MaxLength = 20

			TB_OutwardChargesTable.Columns.Add("Currency", GetType(System.String))
			TB_OutwardChargesTable.Columns("Currency").AllowDBNull = false
			TB_OutwardChargesTable.Columns("Currency").ReadOnly = false
			
			TB_OutwardChargesTable.Columns("Currency").MaxLength = 20

			TB_OutwardChargesTable.Columns.Add("Qty", GetType(System.Int16))
			TB_OutwardChargesTable.Columns("Qty").AllowDBNull = false
			TB_OutwardChargesTable.Columns("Qty").ReadOnly = false
			
			TB_OutwardChargesTable.Columns.Add("Rate", GetType(System.Double))
			TB_OutwardChargesTable.Columns("Rate").AllowDBNull = false
			TB_OutwardChargesTable.Columns("Rate").ReadOnly = false
			
			TB_OutwardChargesTable.Columns.Add("Amount", GetType(System.Double))
			TB_OutwardChargesTable.Columns("Amount").AllowDBNull = false
			TB_OutwardChargesTable.Columns("Amount").ReadOnly = false
			
			TB_OutwardChargesTable.Columns.Add("PayAt", GetType(System.String))
			TB_OutwardChargesTable.Columns("PayAt").AllowDBNull = false
			TB_OutwardChargesTable.Columns("PayAt").ReadOnly = false
			
			TB_OutwardChargesTable.Columns("PayAt").MaxLength = 10

			TB_OutwardChargesTable.Columns.Add("ChargesBase", GetType(System.String))
			TB_OutwardChargesTable.Columns("ChargesBase").AllowDBNull = true
			TB_OutwardChargesTable.Columns("ChargesBase").ReadOnly = false
			
			TB_OutwardChargesTable.Columns("ChargesBase").MaxLength = 20

			TB_OutwardChargesTable.Columns.Add("Terms", GetType(System.String))
			TB_OutwardChargesTable.Columns("Terms").AllowDBNull = true
			TB_OutwardChargesTable.Columns("Terms").ReadOnly = false
			
			TB_OutwardChargesTable.Columns("Terms").MaxLength = 20

			TB_OutwardChargesTable.Columns.Add("TariffClass", GetType(System.String))
			TB_OutwardChargesTable.Columns("TariffClass").AllowDBNull = true
			TB_OutwardChargesTable.Columns("TariffClass").ReadOnly = false
			
			TB_OutwardChargesTable.Columns("TariffClass").MaxLength = 20

			TB_OutwardChargesTable.Columns.Add("ActPlaceExRate", GetType(System.Decimal))
			TB_OutwardChargesTable.Columns("ActPlaceExRate").AllowDBNull = true
			TB_OutwardChargesTable.Columns("ActPlaceExRate").ReadOnly = false
			
			TB_OutwardChargesTable.Columns.Add("MeaUnitOfCharge", GetType(System.String))
			TB_OutwardChargesTable.Columns("MeaUnitOfCharge").AllowDBNull = true
			TB_OutwardChargesTable.Columns("MeaUnitOfCharge").ReadOnly = false
			
			TB_OutwardChargesTable.Columns("MeaUnitOfCharge").MaxLength = 10

			TB_OutwardChargesTable.Columns.Add("FromPlace", GetType(System.String))
			TB_OutwardChargesTable.Columns("FromPlace").AllowDBNull = true
			TB_OutwardChargesTable.Columns("FromPlace").ReadOnly = false
			
			TB_OutwardChargesTable.Columns("FromPlace").MaxLength = 10

			TB_OutwardChargesTable.Columns.Add("ToPlace", GetType(System.String))
			TB_OutwardChargesTable.Columns("ToPlace").AllowDBNull = true
			TB_OutwardChargesTable.Columns("ToPlace").ReadOnly = false
			
			TB_OutwardChargesTable.Columns("ToPlace").MaxLength = 10

			TB_OutwardChargesTable.Columns.Add("PayAtBranch", GetType(System.String))
			TB_OutwardChargesTable.Columns("PayAtBranch").AllowDBNull = true
			TB_OutwardChargesTable.Columns("PayAtBranch").ReadOnly = false
			
			TB_OutwardChargesTable.Columns("PayAtBranch").MaxLength = 2

			TB_OutwardChargesTable.Columns.Add("PayAtExRate", GetType(System.Decimal))
			TB_OutwardChargesTable.Columns("PayAtExRate").AllowDBNull = true
			TB_OutwardChargesTable.Columns("PayAtExRate").ReadOnly = false
			
			TB_OutwardChargesTable.Columns.Add("PayAtPc", GetType(System.String))
			TB_OutwardChargesTable.Columns("PayAtPc").AllowDBNull = true
			TB_OutwardChargesTable.Columns("PayAtPc").ReadOnly = false
			
			TB_OutwardChargesTable.Columns("PayAtPc").MaxLength = 1

			TB_OutwardChargesTable.Columns.Add("InvoiceAmount", GetType(System.Decimal))
			TB_OutwardChargesTable.Columns("InvoiceAmount").AllowDBNull = true
			TB_OutwardChargesTable.Columns("InvoiceAmount").ReadOnly = false
			
			TB_OutwardChargesTable.Columns.Add("RealAmount", GetType(System.Double))
			TB_OutwardChargesTable.Columns("RealAmount").AllowDBNull = true
			TB_OutwardChargesTable.Columns("RealAmount").ReadOnly = false
			
			TB_OutwardChargesTable.PrimaryKey = new DataColumn(){TB_OutwardChargesTable.Columns("ID")}
			
			Dim TB_OutwardCnsImcoTable as DataTable = ds.Tables.Add("TB_OutwardCnsImco")
			TB_OutwardCnsImcoTable.Columns.Add("ID", GetType(System.Guid))
			TB_OutwardCnsImcoTable.Columns("ID").AllowDBNull = false
			TB_OutwardCnsImcoTable.Columns("ID").ReadOnly = false
			
			TB_OutwardCnsImcoTable.Columns.Add("CntrID", GetType(System.Guid))
			TB_OutwardCnsImcoTable.Columns("CntrID").AllowDBNull = false
			TB_OutwardCnsImcoTable.Columns("CntrID").ReadOnly = false
			
			TB_OutwardCnsImcoTable.Columns.Add("UNNO", GetType(System.String))
			TB_OutwardCnsImcoTable.Columns("UNNO").AllowDBNull = true
			TB_OutwardCnsImcoTable.Columns("UNNO").ReadOnly = false
			
			TB_OutwardCnsImcoTable.Columns("UNNO").MaxLength = 20

			TB_OutwardCnsImcoTable.Columns.Add("IMDGCode", GetType(System.String))
			TB_OutwardCnsImcoTable.Columns("IMDGCode").AllowDBNull = true
			TB_OutwardCnsImcoTable.Columns("IMDGCode").ReadOnly = false
			
			TB_OutwardCnsImcoTable.Columns("IMDGCode").MaxLength = 20

			TB_OutwardCnsImcoTable.Columns.Add("FlashPoint", GetType(System.Double))
			TB_OutwardCnsImcoTable.Columns("FlashPoint").AllowDBNull = true
			TB_OutwardCnsImcoTable.Columns("FlashPoint").ReadOnly = false
			
			TB_OutwardCnsImcoTable.Columns.Add("PakingGroup", GetType(System.String))
			TB_OutwardCnsImcoTable.Columns("PakingGroup").AllowDBNull = true
			TB_OutwardCnsImcoTable.Columns("PakingGroup").ReadOnly = false
			
			TB_OutwardCnsImcoTable.Columns("PakingGroup").MaxLength = 20

			TB_OutwardCnsImcoTable.Columns.Add("PageNumber", GetType(System.Int64))
			TB_OutwardCnsImcoTable.Columns("PageNumber").AllowDBNull = true
			TB_OutwardCnsImcoTable.Columns("PageNumber").ReadOnly = false
			
			TB_OutwardCnsImcoTable.Columns.Add("EMSNumber", GetType(System.Int64))
			TB_OutwardCnsImcoTable.Columns("EMSNumber").AllowDBNull = true
			TB_OutwardCnsImcoTable.Columns("EMSNumber").ReadOnly = false
			
			TB_OutwardCnsImcoTable.PrimaryKey = new DataColumn(){TB_OutwardCnsImcoTable.Columns("ID")}
			
			Dim TB_OutwardCnsPkgsTable as DataTable = ds.Tables.Add("TB_OutwardCnsPkgs")
			TB_OutwardCnsPkgsTable.Columns.Add("ID", GetType(System.Guid))
			TB_OutwardCnsPkgsTable.Columns("ID").AllowDBNull = false
			TB_OutwardCnsPkgsTable.Columns("ID").ReadOnly = false
			
			TB_OutwardCnsPkgsTable.Columns.Add("CntrID", GetType(System.Guid))
			TB_OutwardCnsPkgsTable.Columns("CntrID").AllowDBNull = false
			TB_OutwardCnsPkgsTable.Columns("CntrID").ReadOnly = false
			
			TB_OutwardCnsPkgsTable.Columns.Add("PackageType", GetType(System.String))
			TB_OutwardCnsPkgsTable.Columns("PackageType").AllowDBNull = false
			TB_OutwardCnsPkgsTable.Columns("PackageType").ReadOnly = false
			
			TB_OutwardCnsPkgsTable.Columns("PackageType").MaxLength = 20

			TB_OutwardCnsPkgsTable.Columns.Add("NoOFPkgs", GetType(System.Int64))
			TB_OutwardCnsPkgsTable.Columns("NoOFPkgs").AllowDBNull = false
			TB_OutwardCnsPkgsTable.Columns("NoOFPkgs").ReadOnly = false
			
			TB_OutwardCnsPkgsTable.Columns.Add("GW", GetType(System.Single))
			TB_OutwardCnsPkgsTable.Columns("GW").AllowDBNull = true
			TB_OutwardCnsPkgsTable.Columns("GW").ReadOnly = false
			
			TB_OutwardCnsPkgsTable.Columns.Add("CBM", GetType(System.Single))
			TB_OutwardCnsPkgsTable.Columns("CBM").AllowDBNull = true
			TB_OutwardCnsPkgsTable.Columns("CBM").ReadOnly = false
			
			TB_OutwardCnsPkgsTable.Columns.Add("NET", GetType(System.Double))
			TB_OutwardCnsPkgsTable.Columns("NET").AllowDBNull = true
			TB_OutwardCnsPkgsTable.Columns("NET").ReadOnly = false
			
			TB_OutwardCnsPkgsTable.Columns.Add("FlashPoint", GetType(System.Double))
			TB_OutwardCnsPkgsTable.Columns("FlashPoint").AllowDBNull = true
			TB_OutwardCnsPkgsTable.Columns("FlashPoint").ReadOnly = false
			
			TB_OutwardCnsPkgsTable.Columns.Add("IMDGCode", GetType(System.String))
			TB_OutwardCnsPkgsTable.Columns("IMDGCode").AllowDBNull = true
			TB_OutwardCnsPkgsTable.Columns("IMDGCode").ReadOnly = false
			
			TB_OutwardCnsPkgsTable.Columns("IMDGCode").MaxLength = 20

			TB_OutwardCnsPkgsTable.Columns.Add("PakingGroup", GetType(System.Int64))
			TB_OutwardCnsPkgsTable.Columns("PakingGroup").AllowDBNull = true
			TB_OutwardCnsPkgsTable.Columns("PakingGroup").ReadOnly = false
			
			TB_OutwardCnsPkgsTable.Columns.Add("PageNumber", GetType(System.Int64))
			TB_OutwardCnsPkgsTable.Columns("PageNumber").AllowDBNull = true
			TB_OutwardCnsPkgsTable.Columns("PageNumber").ReadOnly = false
			
			TB_OutwardCnsPkgsTable.Columns.Add("EMSNumber", GetType(System.Int64))
			TB_OutwardCnsPkgsTable.Columns("EMSNumber").AllowDBNull = true
			TB_OutwardCnsPkgsTable.Columns("EMSNumber").ReadOnly = false
			
			TB_OutwardCnsPkgsTable.PrimaryKey = new DataColumn(){TB_OutwardCnsPkgsTable.Columns("ID")}
			
			Dim TB_OutwardCnsTempratureTable as DataTable = ds.Tables.Add("TB_OutwardCnsTemprature")
			TB_OutwardCnsTempratureTable.Columns.Add("ID", GetType(System.Guid))
			TB_OutwardCnsTempratureTable.Columns("ID").AllowDBNull = false
			TB_OutwardCnsTempratureTable.Columns("ID").ReadOnly = false
			
			TB_OutwardCnsTempratureTable.Columns.Add("CntrID", GetType(System.Guid))
			TB_OutwardCnsTempratureTable.Columns("CntrID").AllowDBNull = false
			TB_OutwardCnsTempratureTable.Columns("CntrID").ReadOnly = false
			
			TB_OutwardCnsTempratureTable.Columns.Add("TempMin", GetType(System.Single))
			TB_OutwardCnsTempratureTable.Columns("TempMin").AllowDBNull = true
			TB_OutwardCnsTempratureTable.Columns("TempMin").ReadOnly = false
			
			TB_OutwardCnsTempratureTable.Columns.Add("TempMax", GetType(System.Single))
			TB_OutwardCnsTempratureTable.Columns("TempMax").AllowDBNull = true
			TB_OutwardCnsTempratureTable.Columns("TempMax").ReadOnly = false
			
			TB_OutwardCnsTempratureTable.Columns.Add("TemperatureBase", GetType(System.String))
			TB_OutwardCnsTempratureTable.Columns("TemperatureBase").AllowDBNull = true
			TB_OutwardCnsTempratureTable.Columns("TemperatureBase").ReadOnly = false
			
			TB_OutwardCnsTempratureTable.Columns("TemperatureBase").MaxLength = 20

			TB_OutwardCnsTempratureTable.PrimaryKey = new DataColumn(){TB_OutwardCnsTempratureTable.Columns("ID")}
			
			Dim TB_OutwardCntrsTable as DataTable = ds.Tables.Add("TB_OutwardCntrs")
			TB_OutwardCntrsTable.Columns.Add("ID", GetType(System.Guid))
			TB_OutwardCntrsTable.Columns("ID").AllowDBNull = false
			TB_OutwardCntrsTable.Columns("ID").ReadOnly = false
			
			TB_OutwardCntrsTable.Columns.Add("BLID", GetType(System.Guid))
			TB_OutwardCntrsTable.Columns("BLID").AllowDBNull = false
			TB_OutwardCntrsTable.Columns("BLID").ReadOnly = false
			
			TB_OutwardCntrsTable.Columns.Add("CntrNo", GetType(System.String))
			TB_OutwardCntrsTable.Columns("CntrNo").AllowDBNull = false
			TB_OutwardCntrsTable.Columns("CntrNo").ReadOnly = false
			
			TB_OutwardCntrsTable.Columns("CntrNo").MaxLength = 24

			TB_OutwardCntrsTable.Columns.Add("CnSize", GetType(System.String))
			TB_OutwardCntrsTable.Columns("CnSize").AllowDBNull = false
			TB_OutwardCntrsTable.Columns("CnSize").ReadOnly = false
			
			TB_OutwardCntrsTable.Columns("CnSize").MaxLength = 20

			TB_OutwardCntrsTable.Columns.Add("CnType", GetType(System.String))
			TB_OutwardCntrsTable.Columns("CnType").AllowDBNull = false
			TB_OutwardCntrsTable.Columns("CnType").ReadOnly = false
			
			TB_OutwardCntrsTable.Columns("CnType").MaxLength = 20

			TB_OutwardCntrsTable.Columns.Add("SealNo", GetType(System.String))
			TB_OutwardCntrsTable.Columns("SealNo").AllowDBNull = true
			TB_OutwardCntrsTable.Columns("SealNo").ReadOnly = false
			
			TB_OutwardCntrsTable.Columns("SealNo").MaxLength = 30

			TB_OutwardCntrsTable.Columns.Add("TW", GetType(System.Int64))
			TB_OutwardCntrsTable.Columns("TW").AllowDBNull = false
			TB_OutwardCntrsTable.Columns("TW").ReadOnly = false
			
			TB_OutwardCntrsTable.Columns.Add("GW", GetType(System.Single))
			TB_OutwardCntrsTable.Columns("GW").AllowDBNull = true
			TB_OutwardCntrsTable.Columns("GW").ReadOnly = false
			
			TB_OutwardCntrsTable.Columns.Add("CBM", GetType(System.Single))
			TB_OutwardCntrsTable.Columns("CBM").AllowDBNull = true
			TB_OutwardCntrsTable.Columns("CBM").ReadOnly = false
			
			TB_OutwardCntrsTable.Columns.Add("NET", GetType(System.Double))
			TB_OutwardCntrsTable.Columns("NET").AllowDBNull = true
			TB_OutwardCntrsTable.Columns("NET").ReadOnly = false
			
			TB_OutwardCntrsTable.Columns.Add("FLE", GetType(System.String))
			TB_OutwardCntrsTable.Columns("FLE").AllowDBNull = true
			TB_OutwardCntrsTable.Columns("FLE").ReadOnly = false
			
			TB_OutwardCntrsTable.Columns("FLE").MaxLength = 20

			TB_OutwardCntrsTable.Columns.Add("SOC", GetType(System.String))
			TB_OutwardCntrsTable.Columns("SOC").AllowDBNull = false
			TB_OutwardCntrsTable.Columns("SOC").ReadOnly = false
			
			TB_OutwardCntrsTable.Columns("SOC").MaxLength = 20

			TB_OutwardCntrsTable.Columns.Add("PackageType", GetType(System.String))
			TB_OutwardCntrsTable.Columns("PackageType").AllowDBNull = true
			TB_OutwardCntrsTable.Columns("PackageType").ReadOnly = false
			
			TB_OutwardCntrsTable.Columns("PackageType").MaxLength = 20

			TB_OutwardCntrsTable.Columns.Add("NoOFPkgs", GetType(System.Int64))
			TB_OutwardCntrsTable.Columns("NoOFPkgs").AllowDBNull = true
			TB_OutwardCntrsTable.Columns("NoOFPkgs").ReadOnly = false
			
			TB_OutwardCntrsTable.Columns.Add("Goods", GetType(System.String))
			TB_OutwardCntrsTable.Columns("Goods").AllowDBNull = true
			TB_OutwardCntrsTable.Columns("Goods").ReadOnly = false
			
			TB_OutwardCntrsTable.Columns("Goods").MaxLength = 500

			TB_OutwardCntrsTable.Columns.Add("IsOOG", GetType(System.Boolean))
			TB_OutwardCntrsTable.Columns("IsOOG").AllowDBNull = true
			TB_OutwardCntrsTable.Columns("IsOOG").ReadOnly = false
			
			TB_OutwardCntrsTable.Columns.Add("POLTerm", GetType(System.String))
			TB_OutwardCntrsTable.Columns("POLTerm").AllowDBNull = true
			TB_OutwardCntrsTable.Columns("POLTerm").ReadOnly = false
			
			TB_OutwardCntrsTable.Columns("POLTerm").MaxLength = 10

			TB_OutwardCntrsTable.Columns.Add("PODTerm", GetType(System.String))
			TB_OutwardCntrsTable.Columns("PODTerm").AllowDBNull = true
			TB_OutwardCntrsTable.Columns("PODTerm").ReadOnly = false
			
			TB_OutwardCntrsTable.Columns("PODTerm").MaxLength = 10

			TB_OutwardCntrsTable.PrimaryKey = new DataColumn(){TB_OutwardCntrsTable.Columns("ID")}
			
			Dim TB_OutwardCntrsChargesTable as DataTable = ds.Tables.Add("TB_OutwardCntrsCharges")
			TB_OutwardCntrsChargesTable.Columns.Add("ID", GetType(System.Guid))
			TB_OutwardCntrsChargesTable.Columns("ID").AllowDBNull = false
			TB_OutwardCntrsChargesTable.Columns("ID").ReadOnly = false
			
			TB_OutwardCntrsChargesTable.Columns.Add("CntrID", GetType(System.Guid))
			TB_OutwardCntrsChargesTable.Columns("CntrID").AllowDBNull = false
			TB_OutwardCntrsChargesTable.Columns("CntrID").ReadOnly = false
			
			TB_OutwardCntrsChargesTable.Columns.Add("ChargesCode", GetType(System.String))
			TB_OutwardCntrsChargesTable.Columns("ChargesCode").AllowDBNull = false
			TB_OutwardCntrsChargesTable.Columns("ChargesCode").ReadOnly = false
			
			TB_OutwardCntrsChargesTable.Columns("ChargesCode").MaxLength = 10

			TB_OutwardCntrsChargesTable.Columns.Add("Currency", GetType(System.String))
			TB_OutwardCntrsChargesTable.Columns("Currency").AllowDBNull = false
			TB_OutwardCntrsChargesTable.Columns("Currency").ReadOnly = false
			
			TB_OutwardCntrsChargesTable.Columns("Currency").MaxLength = 10

			TB_OutwardCntrsChargesTable.Columns.Add("UnitRate", GetType(System.Decimal))
			TB_OutwardCntrsChargesTable.Columns("UnitRate").AllowDBNull = false
			TB_OutwardCntrsChargesTable.Columns("UnitRate").ReadOnly = false
			
			TB_OutwardCntrsChargesTable.Columns.Add("MEARate", GetType(System.Decimal))
			TB_OutwardCntrsChargesTable.Columns("MEARate").AllowDBNull = false
			TB_OutwardCntrsChargesTable.Columns("MEARate").ReadOnly = false
			
			TB_OutwardCntrsChargesTable.Columns.Add("WGTrate", GetType(System.Decimal))
			TB_OutwardCntrsChargesTable.Columns("WGTrate").AllowDBNull = false
			TB_OutwardCntrsChargesTable.Columns("WGTrate").ReadOnly = false
			
			TB_OutwardCntrsChargesTable.Columns.Add("FromPlace", GetType(System.String))
			TB_OutwardCntrsChargesTable.Columns("FromPlace").AllowDBNull = false
			TB_OutwardCntrsChargesTable.Columns("FromPlace").ReadOnly = false
			
			TB_OutwardCntrsChargesTable.Columns("FromPlace").MaxLength = 5

			TB_OutwardCntrsChargesTable.Columns.Add("ToPlace", GetType(System.String))
			TB_OutwardCntrsChargesTable.Columns("ToPlace").AllowDBNull = false
			TB_OutwardCntrsChargesTable.Columns("ToPlace").ReadOnly = false
			
			TB_OutwardCntrsChargesTable.Columns("ToPlace").MaxLength = 5

			TB_OutwardCntrsChargesTable.Columns.Add("MinRate", GetType(System.Decimal))
			TB_OutwardCntrsChargesTable.Columns("MinRate").AllowDBNull = false
			TB_OutwardCntrsChargesTable.Columns("MinRate").ReadOnly = false
			
			TB_OutwardCntrsChargesTable.Columns.Add("Terms", GetType(System.String))
			TB_OutwardCntrsChargesTable.Columns("Terms").AllowDBNull = false
			TB_OutwardCntrsChargesTable.Columns("Terms").ReadOnly = false
			
			TB_OutwardCntrsChargesTable.Columns("Terms").MaxLength = 10

			TB_OutwardCntrsChargesTable.Columns.Add("RealAmount", GetType(System.Decimal))
			TB_OutwardCntrsChargesTable.Columns("RealAmount").AllowDBNull = false
			TB_OutwardCntrsChargesTable.Columns("RealAmount").ReadOnly = false
			
			TB_OutwardCntrsChargesTable.PrimaryKey = new DataColumn(){TB_OutwardCntrsChargesTable.Columns("ID")}
			
			Dim TB_OutwardDiscountTable as DataTable = ds.Tables.Add("TB_OutwardDiscount")
			TB_OutwardDiscountTable.Columns.Add("ID", GetType(System.Guid))
			TB_OutwardDiscountTable.Columns("ID").AllowDBNull = false
			TB_OutwardDiscountTable.Columns("ID").ReadOnly = false
			
			TB_OutwardDiscountTable.Columns.Add("BLID", GetType(System.Guid))
			TB_OutwardDiscountTable.Columns("BLID").AllowDBNull = false
			TB_OutwardDiscountTable.Columns("BLID").ReadOnly = false
			
			TB_OutwardDiscountTable.Columns.Add("dFreeDays", GetType(System.Int32))
			TB_OutwardDiscountTable.Columns("dFreeDays").AllowDBNull = true
			TB_OutwardDiscountTable.Columns("dFreeDays").ReadOnly = false
			
			TB_OutwardDiscountTable.Columns.Add("dPercent", GetType(System.Int32))
			TB_OutwardDiscountTable.Columns("dPercent").AllowDBNull = true
			TB_OutwardDiscountTable.Columns("dPercent").ReadOnly = false
			
			TB_OutwardDiscountTable.Columns.Add("dAmount", GetType(System.Int64))
			TB_OutwardDiscountTable.Columns("dAmount").AllowDBNull = true
			TB_OutwardDiscountTable.Columns("dAmount").ReadOnly = false
			
			TB_OutwardDiscountTable.Columns.Add("LineSetel", GetType(System.DateTime))
			TB_OutwardDiscountTable.Columns("LineSetel").AllowDBNull = true
			TB_OutwardDiscountTable.Columns("LineSetel").ReadOnly = false
			
			TB_OutwardDiscountTable.Columns.Add("IsFDaysAsDiscount", GetType(System.Boolean))
			TB_OutwardDiscountTable.Columns("IsFDaysAsDiscount").AllowDBNull = true
			TB_OutwardDiscountTable.Columns("IsFDaysAsDiscount").ReadOnly = false
			
			TB_OutwardDiscountTable.Columns.Add("SpecialCalculate", GetType(System.Boolean))
			TB_OutwardDiscountTable.Columns("SpecialCalculate").AllowDBNull = true
			TB_OutwardDiscountTable.Columns("SpecialCalculate").ReadOnly = false
			
			TB_OutwardDiscountTable.Columns.Add("PerDay20", GetType(System.Double))
			TB_OutwardDiscountTable.Columns("PerDay20").AllowDBNull = true
			TB_OutwardDiscountTable.Columns("PerDay20").ReadOnly = false
			
			TB_OutwardDiscountTable.Columns.Add("PerDay40", GetType(System.Double))
			TB_OutwardDiscountTable.Columns("PerDay40").AllowDBNull = true
			TB_OutwardDiscountTable.Columns("PerDay40").ReadOnly = false
			
			TB_OutwardDiscountTable.Columns.Add("PerDay45", GetType(System.Double))
			TB_OutwardDiscountTable.Columns("PerDay45").AllowDBNull = true
			TB_OutwardDiscountTable.Columns("PerDay45").ReadOnly = false
			
			TB_OutwardDiscountTable.Columns.Add("DetentionID", GetType(System.Guid))
			TB_OutwardDiscountTable.Columns("DetentionID").AllowDBNull = true
			TB_OutwardDiscountTable.Columns("DetentionID").ReadOnly = false
			
			TB_OutwardDiscountTable.Columns.Add("NoTax", GetType(System.String))
			TB_OutwardDiscountTable.Columns("NoTax").AllowDBNull = true
			TB_OutwardDiscountTable.Columns("NoTax").ReadOnly = false
			
			TB_OutwardDiscountTable.Columns("NoTax").MaxLength = 10

			TB_OutwardDiscountTable.PrimaryKey = new DataColumn(){TB_OutwardDiscountTable.Columns("ID")}
			
			Dim TB_PermitDetailsTable as DataTable = ds.Tables.Add("TB_PermitDetails")
			TB_PermitDetailsTable.Columns.Add("ID", GetType(System.Guid))
			TB_PermitDetailsTable.Columns("ID").AllowDBNull = false
			TB_PermitDetailsTable.Columns("ID").ReadOnly = false
			
			TB_PermitDetailsTable.Columns.Add("PermitID", GetType(System.Guid))
			TB_PermitDetailsTable.Columns("PermitID").AllowDBNull = false
			TB_PermitDetailsTable.Columns("PermitID").ReadOnly = false
			
			TB_PermitDetailsTable.Columns.Add("CntrID", GetType(System.Guid))
			TB_PermitDetailsTable.Columns("CntrID").AllowDBNull = false
			TB_PermitDetailsTable.Columns("CntrID").ReadOnly = false
			
			TB_PermitDetailsTable.Columns.Add("FLE", GetType(System.String))
			TB_PermitDetailsTable.Columns("FLE").AllowDBNull = true
			TB_PermitDetailsTable.Columns("FLE").ReadOnly = false
			
			TB_PermitDetailsTable.Columns("FLE").MaxLength = 20

			TB_PermitDetailsTable.Columns.Add("GW", GetType(System.Double))
			TB_PermitDetailsTable.Columns("GW").AllowDBNull = true
            TB_PermitDetailsTable.Columns("GW").ReadOnly = False

            TB_PermitDetailsTable.Columns.Add("VGM", GetType(System.Double))
            TB_PermitDetailsTable.Columns("VGM").AllowDBNull = True
            TB_PermitDetailsTable.Columns("VGM").ReadOnly = False
			
			TB_PermitDetailsTable.Columns.Add("PackageType", GetType(System.String))
			TB_PermitDetailsTable.Columns("PackageType").AllowDBNull = true
			TB_PermitDetailsTable.Columns("PackageType").ReadOnly = false
			
			TB_PermitDetailsTable.Columns("PackageType").MaxLength = 20

			TB_PermitDetailsTable.Columns.Add("NoOFPkgs", GetType(System.Int64))
			TB_PermitDetailsTable.Columns("NoOFPkgs").AllowDBNull = true
			TB_PermitDetailsTable.Columns("NoOFPkgs").ReadOnly = false
			
			TB_PermitDetailsTable.Columns.Add("SealNo", GetType(System.String))
			TB_PermitDetailsTable.Columns("SealNo").AllowDBNull = true
			TB_PermitDetailsTable.Columns("SealNo").ReadOnly = false
			
			TB_PermitDetailsTable.Columns("SealNo").MaxLength = 30

			TB_PermitDetailsTable.Columns.Add("TempMin", GetType(System.Decimal))
			TB_PermitDetailsTable.Columns("TempMin").AllowDBNull = true
			TB_PermitDetailsTable.Columns("TempMin").ReadOnly = false
			
			TB_PermitDetailsTable.Columns.Add("TempMax", GetType(System.Decimal))
			TB_PermitDetailsTable.Columns("TempMax").AllowDBNull = true
			TB_PermitDetailsTable.Columns("TempMax").ReadOnly = false
			
			TB_PermitDetailsTable.PrimaryKey = new DataColumn(){TB_PermitDetailsTable.Columns("ID")}
			
			Dim TB_PermitsTable as DataTable = ds.Tables.Add("TB_Permits")
			TB_PermitsTable.Columns.Add("ID", GetType(System.Guid))
			TB_PermitsTable.Columns("ID").AllowDBNull = false
			TB_PermitsTable.Columns("ID").ReadOnly = false
			
			TB_PermitsTable.Columns.Add("PermitNo", GetType(System.String))
			TB_PermitsTable.Columns("PermitNo").AllowDBNull = false
			TB_PermitsTable.Columns("PermitNo").ReadOnly = false
			
			TB_PermitsTable.Columns("PermitNo").MaxLength = 30

			TB_PermitsTable.Columns.Add("Status", GetType(System.String))
			TB_PermitsTable.Columns("Status").AllowDBNull = false
			TB_PermitsTable.Columns("Status").ReadOnly = false
			
			TB_PermitsTable.Columns("Status").MaxLength = 20

			TB_PermitsTable.Columns.Add("Goods", GetType(System.String))
			TB_PermitsTable.Columns("Goods").AllowDBNull = false
			TB_PermitsTable.Columns("Goods").ReadOnly = false
			
			TB_PermitsTable.Columns("Goods").MaxLength = 500

			TB_PermitsTable.Columns.Add("FPOD", GetType(System.String))
			TB_PermitsTable.Columns("FPOD").AllowDBNull = false
			TB_PermitsTable.Columns("FPOD").ReadOnly = false
			
			TB_PermitsTable.Columns("FPOD").MaxLength = 10

			TB_PermitsTable.Columns.Add("POT", GetType(System.String))
			TB_PermitsTable.Columns("POT").AllowDBNull = true
			TB_PermitsTable.Columns("POT").ReadOnly = false
			
			TB_PermitsTable.Columns("POT").MaxLength = 10

			TB_PermitsTable.Columns.Add("IMDGCode", GetType(System.String))
			TB_PermitsTable.Columns("IMDGCode").AllowDBNull = true
			TB_PermitsTable.Columns("IMDGCode").ReadOnly = false
			
			TB_PermitsTable.Columns("IMDGCode").MaxLength = 20

			TB_PermitsTable.Columns.Add("UNNumber", GetType(System.String))
			TB_PermitsTable.Columns("UNNumber").AllowDBNull = true
			TB_PermitsTable.Columns("UNNumber").ReadOnly = false
			
			TB_PermitsTable.Columns("UNNumber").MaxLength = 20

			TB_PermitsTable.Columns.Add("FlashPoint", GetType(System.Double))
			TB_PermitsTable.Columns("FlashPoint").AllowDBNull = true
			TB_PermitsTable.Columns("FlashPoint").ReadOnly = false
			
			TB_PermitsTable.Columns.Add("PackingGroup", GetType(System.String))
			TB_PermitsTable.Columns("PackingGroup").AllowDBNull = true
			TB_PermitsTable.Columns("PackingGroup").ReadOnly = false
			
			TB_PermitsTable.Columns("PackingGroup").MaxLength = 20

			TB_PermitsTable.Columns.Add("PageNumber", GetType(System.Int64))
			TB_PermitsTable.Columns("PageNumber").AllowDBNull = true
			TB_PermitsTable.Columns("PageNumber").ReadOnly = false
			
			TB_PermitsTable.Columns.Add("EMSNumber", GetType(System.Int64))
			TB_PermitsTable.Columns("EMSNumber").AllowDBNull = true
            TB_PermitsTable.Columns("EMSNumber").ReadOnly = False

            TB_PermitsTable.Columns.Add("Depot", GetType(System.String))
            TB_PermitsTable.Columns("Depot").AllowDBNull = False
            TB_PermitsTable.Columns("Depot").ReadOnly = False
			
			TB_PermitsTable.PrimaryKey = new DataColumn(){TB_PermitsTable.Columns("ID")}
			
			Dim TB_PInvoiceTable as DataTable = ds.Tables.Add("TB_PInvoice")
			TB_PInvoiceTable.Columns.Add("ID", GetType(System.Guid))
			TB_PInvoiceTable.Columns("ID").AllowDBNull = false
			TB_PInvoiceTable.Columns("ID").ReadOnly = false
			
			TB_PInvoiceTable.Columns.Add("BLID", GetType(System.Guid))
			TB_PInvoiceTable.Columns("BLID").AllowDBNull = false
			TB_PInvoiceTable.Columns("BLID").ReadOnly = false
			
			TB_PInvoiceTable.Columns.Add("InvoiceNo", GetType(System.String))
			TB_PInvoiceTable.Columns("InvoiceNo").AllowDBNull = true
			TB_PInvoiceTable.Columns("InvoiceNo").ReadOnly = false
			
			TB_PInvoiceTable.Columns("InvoiceNo").MaxLength = 25

			TB_PInvoiceTable.Columns.Add("Description", GetType(System.String))
			TB_PInvoiceTable.Columns("Description").AllowDBNull = false
			TB_PInvoiceTable.Columns("Description").ReadOnly = false
			
			TB_PInvoiceTable.Columns("Description").MaxLength = 500

			TB_PInvoiceTable.Columns.Add("IssueTime", GetType(System.DateTime))
			TB_PInvoiceTable.Columns("IssueTime").AllowDBNull = true
			TB_PInvoiceTable.Columns("IssueTime").ReadOnly = false
			
			TB_PInvoiceTable.Columns.Add("IssueBy", GetType(System.Guid))
			TB_PInvoiceTable.Columns("IssueBy").AllowDBNull = true
			TB_PInvoiceTable.Columns("IssueBy").ReadOnly = false
			
			TB_PInvoiceTable.PrimaryKey = new DataColumn(){TB_PInvoiceTable.Columns("ID")}
			
			Dim TB_PInvoiceDetailsTable as DataTable = ds.Tables.Add("TB_PInvoiceDetails")
			TB_PInvoiceDetailsTable.Columns.Add("ID", GetType(System.Guid))
			TB_PInvoiceDetailsTable.Columns("ID").AllowDBNull = false
			TB_PInvoiceDetailsTable.Columns("ID").ReadOnly = false
			
			TB_PInvoiceDetailsTable.Columns.Add("InvoiceID", GetType(System.Guid))
			TB_PInvoiceDetailsTable.Columns("InvoiceID").AllowDBNull = false
			TB_PInvoiceDetailsTable.Columns("InvoiceID").ReadOnly = false
			
			TB_PInvoiceDetailsTable.Columns.Add("Seq", GetType(System.Int16))
			TB_PInvoiceDetailsTable.Columns("Seq").AllowDBNull = false
			TB_PInvoiceDetailsTable.Columns("Seq").ReadOnly = false
			
			TB_PInvoiceDetailsTable.Columns.Add("ChargesCode", GetType(System.String))
			TB_PInvoiceDetailsTable.Columns("ChargesCode").AllowDBNull = false
			TB_PInvoiceDetailsTable.Columns("ChargesCode").ReadOnly = false
			
			TB_PInvoiceDetailsTable.Columns("ChargesCode").MaxLength = 20

			TB_PInvoiceDetailsTable.Columns.Add("Remarks", GetType(System.String))
			TB_PInvoiceDetailsTable.Columns("Remarks").AllowDBNull = false
			TB_PInvoiceDetailsTable.Columns("Remarks").ReadOnly = false
			
			TB_PInvoiceDetailsTable.Columns("Remarks").MaxLength = 500

			TB_PInvoiceDetailsTable.Columns.Add("Currency", GetType(System.String))
			TB_PInvoiceDetailsTable.Columns("Currency").AllowDBNull = false
			TB_PInvoiceDetailsTable.Columns("Currency").ReadOnly = false
			
			TB_PInvoiceDetailsTable.Columns("Currency").MaxLength = 20

			TB_PInvoiceDetailsTable.Columns.Add("Amount", GetType(System.Double))
			TB_PInvoiceDetailsTable.Columns("Amount").AllowDBNull = false
			TB_PInvoiceDetailsTable.Columns("Amount").ReadOnly = false
			
			TB_PInvoiceDetailsTable.PrimaryKey = new DataColumn(){TB_PInvoiceDetailsTable.Columns("ID")}
			
			Dim TB_PortsTable as DataTable = ds.Tables.Add("TB_Ports")
			TB_PortsTable.Columns.Add("ID", GetType(System.Guid))
			TB_PortsTable.Columns("ID").AllowDBNull = false
			TB_PortsTable.Columns("ID").ReadOnly = false
			
			TB_PortsTable.Columns.Add("PortCode", GetType(System.String))
			TB_PortsTable.Columns("PortCode").AllowDBNull = false
			TB_PortsTable.Columns("PortCode").ReadOnly = false
			
			TB_PortsTable.Columns("PortCode").MaxLength = 10

			TB_PortsTable.Columns.Add("PortName", GetType(System.String))
			TB_PortsTable.Columns("PortName").AllowDBNull = false
			TB_PortsTable.Columns("PortName").ReadOnly = false
			
			TB_PortsTable.Columns("PortName").MaxLength = 500

			TB_PortsTable.Columns.Add("FPortName", GetType(System.String))
			TB_PortsTable.Columns("FPortName").AllowDBNull = true
			TB_PortsTable.Columns("FPortName").ReadOnly = false
			
			TB_PortsTable.Columns("FPortName").MaxLength = 500

			TB_PortsTable.Columns.Add("Country", GetType(System.String))
			TB_PortsTable.Columns("Country").AllowDBNull = false
			TB_PortsTable.Columns("Country").ReadOnly = false
			
			TB_PortsTable.Columns("Country").MaxLength = 4

			TB_PortsTable.Columns.Add("EDIIPCODE", GetType(System.String))
			TB_PortsTable.Columns("EDIIPCODE").AllowDBNull = true
			TB_PortsTable.Columns("EDIIPCODE").ReadOnly = false
			
			TB_PortsTable.Columns("EDIIPCODE").MaxLength = 5

			TB_PortsTable.PrimaryKey = new DataColumn(){TB_PortsTable.Columns("ID")}
			
			Dim TB_RecivedItemsTable as DataTable = ds.Tables.Add("TB_RecivedItems")
			TB_RecivedItemsTable.Columns.Add("ID", GetType(System.Guid))
			TB_RecivedItemsTable.Columns("ID").AllowDBNull = false
			TB_RecivedItemsTable.Columns("ID").ReadOnly = false
			
			TB_RecivedItemsTable.Columns.Add("InvoiceID", GetType(System.Guid))
			TB_RecivedItemsTable.Columns("InvoiceID").AllowDBNull = false
			TB_RecivedItemsTable.Columns("InvoiceID").ReadOnly = false
			
			TB_RecivedItemsTable.Columns.Add("Seq", GetType(System.Int16))
			TB_RecivedItemsTable.Columns("Seq").AllowDBNull = false
			TB_RecivedItemsTable.Columns("Seq").ReadOnly = false
			
			TB_RecivedItemsTable.Columns.Add("Description", GetType(System.String))
			TB_RecivedItemsTable.Columns("Description").AllowDBNull = true
			TB_RecivedItemsTable.Columns("Description").ReadOnly = false
			
			TB_RecivedItemsTable.Columns("Description").MaxLength = 500

			TB_RecivedItemsTable.Columns.Add("PaymentType", GetType(System.String))
			TB_RecivedItemsTable.Columns("PaymentType").AllowDBNull = false
			TB_RecivedItemsTable.Columns("PaymentType").ReadOnly = false
			
			TB_RecivedItemsTable.Columns("PaymentType").MaxLength = 20

			TB_RecivedItemsTable.Columns.Add("Bank", GetType(System.String))
			TB_RecivedItemsTable.Columns("Bank").AllowDBNull = true
			TB_RecivedItemsTable.Columns("Bank").ReadOnly = false
			
			TB_RecivedItemsTable.Columns("Bank").MaxLength = 20

			TB_RecivedItemsTable.Columns.Add("Currency", GetType(System.String))
			TB_RecivedItemsTable.Columns("Currency").AllowDBNull = false
			TB_RecivedItemsTable.Columns("Currency").ReadOnly = false
			
			TB_RecivedItemsTable.Columns("Currency").MaxLength = 20

			TB_RecivedItemsTable.Columns.Add("Amount", GetType(System.Double))
			TB_RecivedItemsTable.Columns("Amount").AllowDBNull = false
			TB_RecivedItemsTable.Columns("Amount").ReadOnly = false
			
			TB_RecivedItemsTable.Columns.Add("IrrAmount", GetType(System.Int64))
			TB_RecivedItemsTable.Columns("IrrAmount").AllowDBNull = true
			TB_RecivedItemsTable.Columns("IrrAmount").ReadOnly = false
			
			TB_RecivedItemsTable.Columns.Add("PaidDate", GetType(System.String))
			TB_RecivedItemsTable.Columns("PaidDate").AllowDBNull = true
			TB_RecivedItemsTable.Columns("PaidDate").ReadOnly = false
			
			TB_RecivedItemsTable.Columns("PaidDate").MaxLength = 10

			TB_RecivedItemsTable.Columns.Add("PaidRef", GetType(System.String))
			TB_RecivedItemsTable.Columns("PaidRef").AllowDBNull = true
			TB_RecivedItemsTable.Columns("PaidRef").ReadOnly = false
			
			TB_RecivedItemsTable.Columns("PaidRef").MaxLength = 15

			TB_RecivedItemsTable.Columns.Add("ReceivedType", GetType(System.String))
			TB_RecivedItemsTable.Columns("ReceivedType").AllowDBNull = true
			TB_RecivedItemsTable.Columns("ReceivedType").ReadOnly = false
			
			TB_RecivedItemsTable.Columns("ReceivedType").MaxLength = 10

			TB_RecivedItemsTable.PrimaryKey = new DataColumn(){TB_RecivedItemsTable.Columns("ID")}
			
			Dim TB_ReferenceTable as DataTable = ds.Tables.Add("TB_Reference")
			TB_ReferenceTable.Columns.Add("ID", GetType(System.Guid))
			TB_ReferenceTable.Columns("ID").AllowDBNull = false
			TB_ReferenceTable.Columns("ID").ReadOnly = false
			
			TB_ReferenceTable.Columns.Add("Code", GetType(System.String))
			TB_ReferenceTable.Columns("Code").AllowDBNull = true
			TB_ReferenceTable.Columns("Code").ReadOnly = false
			
			TB_ReferenceTable.Columns("Code").MaxLength = 100

			TB_ReferenceTable.Columns.Add("Section", GetType(System.String))
			TB_ReferenceTable.Columns("Section").AllowDBNull = true
			TB_ReferenceTable.Columns("Section").ReadOnly = false
			
			TB_ReferenceTable.Columns("Section").MaxLength = 100

			TB_ReferenceTable.Columns.Add("InternalCode", GetType(System.String))
			TB_ReferenceTable.Columns("InternalCode").AllowDBNull = true
			TB_ReferenceTable.Columns("InternalCode").ReadOnly = false
			
			TB_ReferenceTable.Columns("InternalCode").MaxLength = 100

			TB_ReferenceTable.PrimaryKey = new DataColumn(){TB_ReferenceTable.Columns("ID")}
			
			Dim TB_ReleaseLetterSeqTable as DataTable = ds.Tables.Add("TB_ReleaseLetterSeq")
			TB_ReleaseLetterSeqTable.Columns.Add("ID", GetType(System.Guid))
			TB_ReleaseLetterSeqTable.Columns("ID").AllowDBNull = false
			TB_ReleaseLetterSeqTable.Columns("ID").ReadOnly = false
			
			TB_ReleaseLetterSeqTable.Columns.Add("LastSeq", GetType(System.String))
			TB_ReleaseLetterSeqTable.Columns("LastSeq").AllowDBNull = true
			TB_ReleaseLetterSeqTable.Columns("LastSeq").ReadOnly = false
			
			TB_ReleaseLetterSeqTable.Columns("LastSeq").MaxLength = 12

			TB_ReleaseLetterSeqTable.Columns.Add("MaxSeq", GetType(System.String))
			TB_ReleaseLetterSeqTable.Columns("MaxSeq").AllowDBNull = true
			TB_ReleaseLetterSeqTable.Columns("MaxSeq").ReadOnly = false
			
			TB_ReleaseLetterSeqTable.Columns("MaxSeq").MaxLength = 12

			TB_ReleaseLetterSeqTable.PrimaryKey = new DataColumn(){TB_ReleaseLetterSeqTable.Columns("ID")}
			
			Dim TB_ReportCustomFieldsTable as DataTable = ds.Tables.Add("TB_ReportCustomFields")
			TB_ReportCustomFieldsTable.Columns.Add("ID", GetType(System.Guid))
			TB_ReportCustomFieldsTable.Columns("ID").AllowDBNull = false
			TB_ReportCustomFieldsTable.Columns("ID").ReadOnly = false
			
			TB_ReportCustomFieldsTable.Columns.Add("ReportName", GetType(System.String))
			TB_ReportCustomFieldsTable.Columns("ReportName").AllowDBNull = false
			TB_ReportCustomFieldsTable.Columns("ReportName").ReadOnly = false
			
			TB_ReportCustomFieldsTable.Columns("ReportName").MaxLength = 50

			TB_ReportCustomFieldsTable.Columns.Add("ReportFrindlyName", GetType(System.String))
			TB_ReportCustomFieldsTable.Columns("ReportFrindlyName").AllowDBNull = false
			TB_ReportCustomFieldsTable.Columns("ReportFrindlyName").ReadOnly = false
			
			TB_ReportCustomFieldsTable.Columns("ReportFrindlyName").MaxLength = 100

			TB_ReportCustomFieldsTable.Columns.Add("FieldName", GetType(System.String))
			TB_ReportCustomFieldsTable.Columns("FieldName").AllowDBNull = false
			TB_ReportCustomFieldsTable.Columns("FieldName").ReadOnly = false
			
			TB_ReportCustomFieldsTable.Columns("FieldName").MaxLength = 50

			TB_ReportCustomFieldsTable.Columns.Add("FieldFriendlyName", GetType(System.String))
			TB_ReportCustomFieldsTable.Columns("FieldFriendlyName").AllowDBNull = false
			TB_ReportCustomFieldsTable.Columns("FieldFriendlyName").ReadOnly = false
			
			TB_ReportCustomFieldsTable.Columns("FieldFriendlyName").MaxLength = 100

			TB_ReportCustomFieldsTable.Columns.Add("DataContent", GetType(System.Byte()))
			TB_ReportCustomFieldsTable.Columns("DataContent").AllowDBNull = true
			TB_ReportCustomFieldsTable.Columns("DataContent").ReadOnly = false
			
			TB_ReportCustomFieldsTable.PrimaryKey = new DataColumn(){TB_ReportCustomFieldsTable.Columns("ID")}
			
			Dim TB_SCNIDSTable as DataTable = ds.Tables.Add("TB_SCNIDS")
			TB_SCNIDSTable.Columns.Add("ID", GetType(System.Guid))
			TB_SCNIDSTable.Columns("ID").AllowDBNull = false
			TB_SCNIDSTable.Columns("ID").ReadOnly = false
			
			TB_SCNIDSTable.Columns.Add("SCNID", GetType(System.String))
			TB_SCNIDSTable.Columns("SCNID").AllowDBNull = true
			TB_SCNIDSTable.Columns("SCNID").ReadOnly = false
			
			TB_SCNIDSTable.Columns("SCNID").MaxLength = 50

			TB_SCNIDSTable.Columns.Add("Name", GetType(System.String))
			TB_SCNIDSTable.Columns("Name").AllowDBNull = true
			TB_SCNIDSTable.Columns("Name").ReadOnly = false
			
			TB_SCNIDSTable.Columns("Name").MaxLength = 510

			TB_SCNIDSTable.Columns.Add("TEL", GetType(System.String))
			TB_SCNIDSTable.Columns("TEL").AllowDBNull = true
			TB_SCNIDSTable.Columns("TEL").ReadOnly = false
			
			TB_SCNIDSTable.Columns("TEL").MaxLength = 50

			TB_SCNIDSTable.PrimaryKey = new DataColumn(){TB_SCNIDSTable.Columns("ID")}
			
			Dim TB_SeqTable as DataTable = ds.Tables.Add("TB_Seq")
			TB_SeqTable.Columns.Add("ID", GetType(System.Guid))
			TB_SeqTable.Columns("ID").AllowDBNull = false
			TB_SeqTable.Columns("ID").ReadOnly = false
			
			TB_SeqTable.Columns.Add("SeqType", GetType(System.String))
			TB_SeqTable.Columns("SeqType").AllowDBNull = false
			TB_SeqTable.Columns("SeqType").ReadOnly = false
			
			TB_SeqTable.Columns("SeqType").MaxLength = 20

			TB_SeqTable.Columns.Add("Office", GetType(System.String))
			TB_SeqTable.Columns("Office").AllowDBNull = false
			TB_SeqTable.Columns("Office").ReadOnly = false
			
			TB_SeqTable.Columns("Office").MaxLength = 20

			TB_SeqTable.Columns.Add("SeqYear", GetType(System.String))
			TB_SeqTable.Columns("SeqYear").AllowDBNull = false
			TB_SeqTable.Columns("SeqYear").ReadOnly = false
			
			TB_SeqTable.Columns("SeqYear").MaxLength = 8

			TB_SeqTable.Columns.Add("Seq", GetType(System.Int64))
			TB_SeqTable.Columns("Seq").AllowDBNull = false
			TB_SeqTable.Columns("Seq").ReadOnly = false
			
			TB_SeqTable.Columns.Add("Line", GetType(System.String))
			TB_SeqTable.Columns("Line").AllowDBNull = true
			TB_SeqTable.Columns("Line").ReadOnly = false
			
			TB_SeqTable.Columns("Line").MaxLength = 10

			TB_SeqTable.PrimaryKey = new DataColumn(){TB_SeqTable.Columns("ID")}
			
			Dim TB_SOFTable as DataTable = ds.Tables.Add("TB_SOF")
			TB_SOFTable.Columns.Add("ID", GetType(System.Guid))
			TB_SOFTable.Columns("ID").AllowDBNull = false
			TB_SOFTable.Columns("ID").ReadOnly = false
			
			TB_SOFTable.Columns.Add("VoyageID", GetType(System.Guid))
			TB_SOFTable.Columns("VoyageID").AllowDBNull = false
			TB_SOFTable.Columns("VoyageID").ReadOnly = false
			
			TB_SOFTable.Columns.Add("Port", GetType(System.String))
			TB_SOFTable.Columns("Port").AllowDBNull = false
			TB_SOFTable.Columns("Port").ReadOnly = false
			
			TB_SOFTable.Columns("Port").MaxLength = 10

			TB_SOFTable.Columns.Add("ArrivalAnchorage", GetType(System.DateTime))
			TB_SOFTable.Columns("ArrivalAnchorage").AllowDBNull = true
			TB_SOFTable.Columns("ArrivalAnchorage").ReadOnly = false
			
			TB_SOFTable.Columns.Add("Pilot", GetType(System.DateTime))
			TB_SOFTable.Columns("Pilot").AllowDBNull = true
			TB_SOFTable.Columns("Pilot").ReadOnly = false
			
			TB_SOFTable.Columns.Add("Arrival", GetType(System.DateTime))
			TB_SOFTable.Columns("Arrival").AllowDBNull = true
			TB_SOFTable.Columns("Arrival").ReadOnly = false
			
			TB_SOFTable.Columns.Add("Berthed", GetType(System.DateTime))
			TB_SOFTable.Columns("Berthed").AllowDBNull = true
			TB_SOFTable.Columns("Berthed").ReadOnly = false
			
			TB_SOFTable.Columns.Add("Jetty", GetType(System.Byte))
			TB_SOFTable.Columns("Jetty").AllowDBNull = true
			TB_SOFTable.Columns("Jetty").ReadOnly = false
			
			TB_SOFTable.Columns.Add("FreePraGrnt", GetType(System.DateTime))
			TB_SOFTable.Columns("FreePraGrnt").AllowDBNull = true
			TB_SOFTable.Columns("FreePraGrnt").ReadOnly = false
			
			TB_SOFTable.Columns.Add("CustomInspect", GetType(System.DateTime))
			TB_SOFTable.Columns("CustomInspect").AllowDBNull = true
			TB_SOFTable.Columns("CustomInspect").ReadOnly = false
			
			TB_SOFTable.Columns.Add("GangOnBoard", GetType(System.DateTime))
			TB_SOFTable.Columns("GangOnBoard").AllowDBNull = true
			TB_SOFTable.Columns("GangOnBoard").ReadOnly = false
			
			TB_SOFTable.Columns.Add("DschCmnc", GetType(System.DateTime))
			TB_SOFTable.Columns("DschCmnc").AllowDBNull = true
			TB_SOFTable.Columns("DschCmnc").ReadOnly = false
			
			TB_SOFTable.Columns.Add("DschCmpl", GetType(System.DateTime))
			TB_SOFTable.Columns("DschCmpl").AllowDBNull = true
			TB_SOFTable.Columns("DschCmpl").ReadOnly = false
			
			TB_SOFTable.Columns.Add("LoadCmnc", GetType(System.DateTime))
			TB_SOFTable.Columns("LoadCmnc").AllowDBNull = true
			TB_SOFTable.Columns("LoadCmnc").ReadOnly = false
			
			TB_SOFTable.Columns.Add("LoadCmpl", GetType(System.DateTime))
			TB_SOFTable.Columns("LoadCmpl").AllowDBNull = true
			TB_SOFTable.Columns("LoadCmpl").ReadOnly = false
			
			TB_SOFTable.Columns.Add("DocOnBoard", GetType(System.DateTime))
			TB_SOFTable.Columns("DocOnBoard").AllowDBNull = true
			TB_SOFTable.Columns("DocOnBoard").ReadOnly = false
			
			TB_SOFTable.Columns.Add("PClear", GetType(System.DateTime))
			TB_SOFTable.Columns("PClear").AllowDBNull = true
			TB_SOFTable.Columns("PClear").ReadOnly = false
			
			TB_SOFTable.Columns.Add("Unberthed", GetType(System.DateTime))
			TB_SOFTable.Columns("Unberthed").AllowDBNull = true
			TB_SOFTable.Columns("Unberthed").ReadOnly = false
			
			TB_SOFTable.Columns.Add("Sailed", GetType(System.DateTime))
			TB_SOFTable.Columns("Sailed").AllowDBNull = true
			TB_SOFTable.Columns("Sailed").ReadOnly = false
			
			TB_SOFTable.Columns.Add("NextPort", GetType(System.String))
			TB_SOFTable.Columns("NextPort").AllowDBNull = true
			TB_SOFTable.Columns("NextPort").ReadOnly = false
			
			TB_SOFTable.Columns("NextPort").MaxLength = 10

			TB_SOFTable.Columns.Add("ETANextPort", GetType(System.DateTime))
			TB_SOFTable.Columns("ETANextPort").AllowDBNull = true
			TB_SOFTable.Columns("ETANextPort").ReadOnly = false
			
			TB_SOFTable.Columns.Add("IFOArrival", GetType(System.Double))
			TB_SOFTable.Columns("IFOArrival").AllowDBNull = true
			TB_SOFTable.Columns("IFOArrival").ReadOnly = false
			
			TB_SOFTable.Columns.Add("MDOArrival", GetType(System.Double))
			TB_SOFTable.Columns("MDOArrival").AllowDBNull = true
			TB_SOFTable.Columns("MDOArrival").ReadOnly = false
			
			TB_SOFTable.Columns.Add("FWaterArrival", GetType(System.Double))
			TB_SOFTable.Columns("FWaterArrival").AllowDBNull = true
			TB_SOFTable.Columns("FWaterArrival").ReadOnly = false
			
			TB_SOFTable.Columns.Add("IFOSup", GetType(System.Double))
			TB_SOFTable.Columns("IFOSup").AllowDBNull = true
			TB_SOFTable.Columns("IFOSup").ReadOnly = false
			
			TB_SOFTable.Columns.Add("MDOSup", GetType(System.Double))
			TB_SOFTable.Columns("MDOSup").AllowDBNull = true
			TB_SOFTable.Columns("MDOSup").ReadOnly = false
			
			TB_SOFTable.Columns.Add("FWaterSup", GetType(System.Double))
			TB_SOFTable.Columns("FWaterSup").AllowDBNull = true
			TB_SOFTable.Columns("FWaterSup").ReadOnly = false
			
			TB_SOFTable.Columns.Add("IFODep", GetType(System.Double))
			TB_SOFTable.Columns("IFODep").AllowDBNull = true
			TB_SOFTable.Columns("IFODep").ReadOnly = false
			
			TB_SOFTable.Columns.Add("MDODep", GetType(System.Double))
			TB_SOFTable.Columns("MDODep").AllowDBNull = true
			TB_SOFTable.Columns("MDODep").ReadOnly = false
			
			TB_SOFTable.Columns.Add("FWaterDep", GetType(System.Double))
			TB_SOFTable.Columns("FWaterDep").AllowDBNull = true
			TB_SOFTable.Columns("FWaterDep").ReadOnly = false
			
			TB_SOFTable.Columns.Add("DrftArvlFor", GetType(System.Double))
			TB_SOFTable.Columns("DrftArvlFor").AllowDBNull = true
			TB_SOFTable.Columns("DrftArvlFor").ReadOnly = false
			
			TB_SOFTable.Columns.Add("DrftArvlAft", GetType(System.Double))
			TB_SOFTable.Columns("DrftArvlAft").AllowDBNull = true
			TB_SOFTable.Columns("DrftArvlAft").ReadOnly = false
			
			TB_SOFTable.Columns.Add("DrftDepFor", GetType(System.Double))
			TB_SOFTable.Columns("DrftDepFor").AllowDBNull = true
			TB_SOFTable.Columns("DrftDepFor").ReadOnly = false
			
			TB_SOFTable.Columns.Add("DrftDepAft", GetType(System.Double))
			TB_SOFTable.Columns("DrftDepAft").AllowDBNull = true
			TB_SOFTable.Columns("DrftDepAft").ReadOnly = false
			
			TB_SOFTable.Columns.Add("DjwazNo", GetType(System.String))
			TB_SOFTable.Columns("DjwazNo").AllowDBNull = true
			TB_SOFTable.Columns("DjwazNo").ReadOnly = false
			
			TB_SOFTable.Columns("DjwazNo").MaxLength = 30

			TB_SOFTable.Columns.Add("ETA", GetType(System.DateTime))
			TB_SOFTable.Columns("ETA").AllowDBNull = true
			TB_SOFTable.Columns("ETA").ReadOnly = false
			
			TB_SOFTable.PrimaryKey = new DataColumn(){TB_SOFTable.Columns("ID")}
			
			Dim TB_TaxBaseTable as DataTable = ds.Tables.Add("TB_TaxBase")
			TB_TaxBaseTable.Columns.Add("ID", GetType(System.Guid))
			TB_TaxBaseTable.Columns("ID").AllowDBNull = false
			TB_TaxBaseTable.Columns("ID").ReadOnly = false
			
			TB_TaxBaseTable.Columns.Add("ChargesCode", GetType(System.String))
			TB_TaxBaseTable.Columns("ChargesCode").AllowDBNull = false
			TB_TaxBaseTable.Columns("ChargesCode").ReadOnly = false
			
			TB_TaxBaseTable.Columns("ChargesCode").MaxLength = 10

			TB_TaxBaseTable.Columns.Add("ApplyDate", GetType(System.DateTime))
			TB_TaxBaseTable.Columns("ApplyDate").AllowDBNull = false
			TB_TaxBaseTable.Columns("ApplyDate").ReadOnly = false
			
			TB_TaxBaseTable.Columns.Add("validity", GetType(System.DateTime))
			TB_TaxBaseTable.Columns("validity").AllowDBNull = false
			TB_TaxBaseTable.Columns("validity").ReadOnly = false
			
			TB_TaxBaseTable.Columns.Add("Port", GetType(System.String))
			TB_TaxBaseTable.Columns("Port").AllowDBNull = false
			TB_TaxBaseTable.Columns("Port").ReadOnly = false
			
			TB_TaxBaseTable.Columns("Port").MaxLength = 5

			TB_TaxBaseTable.Columns.Add("Tax", GetType(System.Decimal))
			TB_TaxBaseTable.Columns("Tax").AllowDBNull = false
			TB_TaxBaseTable.Columns("Tax").ReadOnly = false
			
			TB_TaxBaseTable.Columns.Add("TOLL", GetType(System.Decimal))
			TB_TaxBaseTable.Columns("TOLL").AllowDBNull = false
			TB_TaxBaseTable.Columns("TOLL").ReadOnly = false
			
			TB_TaxBaseTable.PrimaryKey = new DataColumn(){TB_TaxBaseTable.Columns("ID")}
			
			Dim TB_UsersTable as DataTable = ds.Tables.Add("TB_Users")
			TB_UsersTable.Columns.Add("ID", GetType(System.Guid))
			TB_UsersTable.Columns("ID").AllowDBNull = false
			TB_UsersTable.Columns("ID").ReadOnly = false
			
			TB_UsersTable.Columns.Add("UserFirstName", GetType(System.String))
			TB_UsersTable.Columns("UserFirstName").AllowDBNull = false
			TB_UsersTable.Columns("UserFirstName").ReadOnly = false
			
			TB_UsersTable.Columns("UserFirstName").MaxLength = 100

			TB_UsersTable.Columns.Add("UserLastName", GetType(System.String))
			TB_UsersTable.Columns("UserLastName").AllowDBNull = false
			TB_UsersTable.Columns("UserLastName").ReadOnly = false
			
			TB_UsersTable.Columns("UserLastName").MaxLength = 100

			TB_UsersTable.Columns.Add("UserAccount", GetType(System.String))
			TB_UsersTable.Columns("UserAccount").AllowDBNull = false
			TB_UsersTable.Columns("UserAccount").ReadOnly = false
			
			TB_UsersTable.Columns("UserAccount").MaxLength = 30

			TB_UsersTable.Columns.Add("UserCode", GetType(System.String))
			TB_UsersTable.Columns("UserCode").AllowDBNull = false
			TB_UsersTable.Columns("UserCode").ReadOnly = false
			
			TB_UsersTable.Columns("UserCode").MaxLength = 4

			TB_UsersTable.Columns.Add("Password", GetType(System.String))
			TB_UsersTable.Columns("Password").AllowDBNull = false
			TB_UsersTable.Columns("Password").ReadOnly = false
			
			TB_UsersTable.Columns("Password").MaxLength = 20

			TB_UsersTable.Columns.Add("EmailOffice", GetType(System.String))
			TB_UsersTable.Columns("EmailOffice").AllowDBNull = true
			TB_UsersTable.Columns("EmailOffice").ReadOnly = false
			
			TB_UsersTable.Columns("EmailOffice").MaxLength = 100

			TB_UsersTable.Columns.Add("EmailHome", GetType(System.String))
			TB_UsersTable.Columns("EmailHome").AllowDBNull = true
			TB_UsersTable.Columns("EmailHome").ReadOnly = false
			
			TB_UsersTable.Columns("EmailHome").MaxLength = 100

			TB_UsersTable.Columns.Add("TEL", GetType(System.String))
			TB_UsersTable.Columns("TEL").AllowDBNull = true
			TB_UsersTable.Columns("TEL").ReadOnly = false
			
			TB_UsersTable.Columns("TEL").MaxLength = 40

			TB_UsersTable.Columns.Add("IsSalesAdmin", GetType(System.Boolean))
			TB_UsersTable.Columns("IsSalesAdmin").AllowDBNull = true
			TB_UsersTable.Columns("IsSalesAdmin").ReadOnly = false
			
			TB_UsersTable.Columns.Add("IsAccountAdmin", GetType(System.Boolean))
			TB_UsersTable.Columns("IsAccountAdmin").AllowDBNull = true
			TB_UsersTable.Columns("IsAccountAdmin").ReadOnly = false
			
			TB_UsersTable.Columns.Add("IsDocAdmin", GetType(System.Boolean))
			TB_UsersTable.Columns("IsDocAdmin").AllowDBNull = true
			TB_UsersTable.Columns("IsDocAdmin").ReadOnly = false
			
			TB_UsersTable.Columns.Add("IsEcsAdmin", GetType(System.Boolean))
			TB_UsersTable.Columns("IsEcsAdmin").AllowDBNull = true
			TB_UsersTable.Columns("IsEcsAdmin").ReadOnly = false
			
			TB_UsersTable.Columns.Add("BookingViewer", GetType(System.Boolean))
			TB_UsersTable.Columns("BookingViewer").AllowDBNull = true
			TB_UsersTable.Columns("BookingViewer").ReadOnly = false
			
			TB_UsersTable.PrimaryKey = new DataColumn(){TB_UsersTable.Columns("ID")}
			
			Dim TB_UsersDeptTable as DataTable = ds.Tables.Add("TB_UsersDept")
			TB_UsersDeptTable.Columns.Add("ID", GetType(System.Guid))
			TB_UsersDeptTable.Columns("ID").AllowDBNull = false
			TB_UsersDeptTable.Columns("ID").ReadOnly = false
			
			TB_UsersDeptTable.Columns.Add("UserID", GetType(System.Guid))
			TB_UsersDeptTable.Columns("UserID").AllowDBNull = false
			TB_UsersDeptTable.Columns("UserID").ReadOnly = false
			
			TB_UsersDeptTable.Columns.Add("Department", GetType(System.String))
			TB_UsersDeptTable.Columns("Department").AllowDBNull = false
			TB_UsersDeptTable.Columns("Department").ReadOnly = false
			
			TB_UsersDeptTable.Columns("Department").MaxLength = 20

			TB_UsersDeptTable.PrimaryKey = new DataColumn(){TB_UsersDeptTable.Columns("ID")}
			
			Dim TB_UsersLineTable as DataTable = ds.Tables.Add("TB_UsersLine")
			TB_UsersLineTable.Columns.Add("ID", GetType(System.Guid))
			TB_UsersLineTable.Columns("ID").AllowDBNull = false
			TB_UsersLineTable.Columns("ID").ReadOnly = false
			
			TB_UsersLineTable.Columns.Add("UserID", GetType(System.Guid))
			TB_UsersLineTable.Columns("UserID").AllowDBNull = false
			TB_UsersLineTable.Columns("UserID").ReadOnly = false
			
			TB_UsersLineTable.Columns.Add("Line", GetType(System.String))
			TB_UsersLineTable.Columns("Line").AllowDBNull = false
			TB_UsersLineTable.Columns("Line").ReadOnly = false
			
			TB_UsersLineTable.Columns("Line").MaxLength = 20

			TB_UsersLineTable.PrimaryKey = new DataColumn(){TB_UsersLineTable.Columns("ID")}
			
			Dim TB_VesselsTable as DataTable = ds.Tables.Add("TB_Vessels")
			TB_VesselsTable.Columns.Add("ID", GetType(System.Guid))
			TB_VesselsTable.Columns("ID").AllowDBNull = false
			TB_VesselsTable.Columns("ID").ReadOnly = false
			
			TB_VesselsTable.Columns.Add("VesselCode", GetType(System.String))
			TB_VesselsTable.Columns("VesselCode").AllowDBNull = false
			TB_VesselsTable.Columns("VesselCode").ReadOnly = false
			
			TB_VesselsTable.Columns("VesselCode").MaxLength = 20

			TB_VesselsTable.Columns.Add("VesselName", GetType(System.String))
			TB_VesselsTable.Columns("VesselName").AllowDBNull = false
			TB_VesselsTable.Columns("VesselName").ReadOnly = false
			
			TB_VesselsTable.Columns("VesselName").MaxLength = 500

			TB_VesselsTable.Columns.Add("DeadWeight", GetType(System.Double))
			TB_VesselsTable.Columns("DeadWeight").AllowDBNull = true
			TB_VesselsTable.Columns("DeadWeight").ReadOnly = false
			
			TB_VesselsTable.Columns.Add("Capacity", GetType(System.Int64))
			TB_VesselsTable.Columns("Capacity").AllowDBNull = true
			TB_VesselsTable.Columns("Capacity").ReadOnly = false
			
			TB_VesselsTable.Columns.Add("GW", GetType(System.Double))
			TB_VesselsTable.Columns("GW").AllowDBNull = true
			TB_VesselsTable.Columns("GW").ReadOnly = false
			
			TB_VesselsTable.Columns.Add("NET", GetType(System.Double))
			TB_VesselsTable.Columns("NET").AllowDBNull = true
			TB_VesselsTable.Columns("NET").ReadOnly = false
			
			TB_VesselsTable.Columns.Add("Speed", GetType(System.Double))
			TB_VesselsTable.Columns("Speed").AllowDBNull = true
			TB_VesselsTable.Columns("Speed").ReadOnly = false
			
			TB_VesselsTable.Columns.Add("OfficalNo", GetType(System.String))
			TB_VesselsTable.Columns("OfficalNo").AllowDBNull = true
			TB_VesselsTable.Columns("OfficalNo").ReadOnly = false
			
			TB_VesselsTable.Columns("OfficalNo").MaxLength = 500

			TB_VesselsTable.Columns.Add("CallLetter", GetType(System.String))
			TB_VesselsTable.Columns("CallLetter").AllowDBNull = true
			TB_VesselsTable.Columns("CallLetter").ReadOnly = false
			
			TB_VesselsTable.Columns("CallLetter").MaxLength = 500

			TB_VesselsTable.Columns.Add("BuiltDate", GetType(System.DateTime))
			TB_VesselsTable.Columns("BuiltDate").AllowDBNull = true
			TB_VesselsTable.Columns("BuiltDate").ReadOnly = false
			
			TB_VesselsTable.Columns.Add("Nationality", GetType(System.String))
			TB_VesselsTable.Columns("Nationality").AllowDBNull = true
			TB_VesselsTable.Columns("Nationality").ReadOnly = false
			
			TB_VesselsTable.Columns("Nationality").MaxLength = 4

			TB_VesselsTable.Columns.Add("VesselAccount", GetType(System.String))
			TB_VesselsTable.Columns("VesselAccount").AllowDBNull = true
			TB_VesselsTable.Columns("VesselAccount").ReadOnly = false
			
            TB_VesselsTable.Columns("VesselAccount").MaxLength = 25

            TB_VesselsTable.Columns.Add("IMONo", GetType(System.String))
            TB_VesselsTable.Columns("IMONo").AllowDBNull = True
            TB_VesselsTable.Columns("IMONo").ReadOnly = False

            TB_VesselsTable.Columns("IMONo").MaxLength = 10

			TB_VesselsTable.PrimaryKey = new DataColumn(){TB_VesselsTable.Columns("ID")}
			
			Dim TB_VoyageTable as DataTable = ds.Tables.Add("TB_Voyage")
			TB_VoyageTable.Columns.Add("ID", GetType(System.Guid))
			TB_VoyageTable.Columns("ID").AllowDBNull = false
			TB_VoyageTable.Columns("ID").ReadOnly = false
			
			TB_VoyageTable.Columns.Add("VesselID", GetType(System.Guid))
			TB_VoyageTable.Columns("VesselID").AllowDBNull = false
			TB_VoyageTable.Columns("VesselID").ReadOnly = false
			
			TB_VoyageTable.Columns.Add("VoyageNo", GetType(System.String))
			TB_VoyageTable.Columns("VoyageNo").AllowDBNull = false
			TB_VoyageTable.Columns("VoyageNo").ReadOnly = false
			
			TB_VoyageTable.Columns("VoyageNo").MaxLength = 30

			TB_VoyageTable.Columns.Add("Carrier", GetType(System.String))
			TB_VoyageTable.Columns("Carrier").AllowDBNull = false
			TB_VoyageTable.Columns("Carrier").ReadOnly = false
			
			TB_VoyageTable.Columns("Carrier").MaxLength = 20

			TB_VoyageTable.Columns.Add("Service", GetType(System.String))
			TB_VoyageTable.Columns("Service").AllowDBNull = true
			TB_VoyageTable.Columns("Service").ReadOnly = false
			
			TB_VoyageTable.Columns("Service").MaxLength = 20

			TB_VoyageTable.Columns.Add("StartDate", GetType(System.DateTime))
			TB_VoyageTable.Columns("StartDate").AllowDBNull = false
			TB_VoyageTable.Columns("StartDate").ReadOnly = false
			
			TB_VoyageTable.Columns.Add("ExchangeFrt", GetType(System.Double))
			TB_VoyageTable.Columns("ExchangeFrt").AllowDBNull = true
			TB_VoyageTable.Columns("ExchangeFrt").ReadOnly = false
			
			TB_VoyageTable.Columns.Add("ExchangeThc", GetType(System.Double))
			TB_VoyageTable.Columns("ExchangeThc").AllowDBNull = true
			TB_VoyageTable.Columns("ExchangeThc").ReadOnly = false
			
			TB_VoyageTable.Columns.Add("DjwazNo", GetType(System.String))
			TB_VoyageTable.Columns("DjwazNo").AllowDBNull = true
			TB_VoyageTable.Columns("DjwazNo").ReadOnly = false
			
			TB_VoyageTable.Columns("DjwazNo").MaxLength = 100

			TB_VoyageTable.Columns.Add("Master", GetType(System.String))
			TB_VoyageTable.Columns("Master").AllowDBNull = true
			TB_VoyageTable.Columns("Master").ReadOnly = false
			
			TB_VoyageTable.Columns("Master").MaxLength = 100

			TB_VoyageTable.Columns.Add("SLOT", GetType(System.String))
			TB_VoyageTable.Columns("SLOT").AllowDBNull = true
			TB_VoyageTable.Columns("SLOT").ReadOnly = false
			
			TB_VoyageTable.Columns("SLOT").MaxLength = 20

			TB_VoyageTable.Columns.Add("VoyageAccount", GetType(System.String))
			TB_VoyageTable.Columns("VoyageAccount").AllowDBNull = true
			TB_VoyageTable.Columns("VoyageAccount").ReadOnly = false
			
			TB_VoyageTable.Columns("VoyageAccount").MaxLength = 25

			TB_VoyageTable.Columns.Add("TFCCode", GetType(System.String))
			TB_VoyageTable.Columns("TFCCode").AllowDBNull = true
			TB_VoyageTable.Columns("TFCCode").ReadOnly = false
			
			TB_VoyageTable.Columns("TFCCode").MaxLength = 15

			TB_VoyageTable.PrimaryKey = new DataColumn(){TB_VoyageTable.Columns("ID")}

			ds.Relations.Add("MenuItemIDTB_AccessLevel",new DataColumn(){ds.Tables("TB_MenuItems").Columns("ID")},new DataColumn(){ds.Tables("TB_AccessLevel").Columns("MenuItemID")},true)
			ds.Relations("MenuItemIDTB_AccessLevel").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("UserIDTB_AccessLevel",new DataColumn(){ds.Tables("TB_Users").Columns("ID")},new DataColumn(){ds.Tables("TB_AccessLevel").Columns("UserID")},true)
			ds.Relations("UserIDTB_AccessLevel").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("JobIDTB_AUTJobLogsDetail",new DataColumn(){ds.Tables("TB_AUTJobLogs").Columns("ID")},new DataColumn(){ds.Tables("TB_AUTJobLogsDetail").Columns("JobID")},true)
			ds.Relations("JobIDTB_AUTJobLogsDetail").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("ClientIDTB_Booking",new DataColumn(){ds.Tables("TB_Clients").Columns("ID")},new DataColumn(){ds.Tables("TB_Booking").Columns("ClientID")},true)
			ds.Relations("ClientIDTB_Booking").ChildKeyConstraint.DeleteRule = Rule.None


			ds.Relations.Add("PIDTB_BookingCns",new DataColumn(){ds.Tables("TB_Booking").Columns("ID")},new DataColumn(){ds.Tables("TB_BookingCns").Columns("PID")},true)
			ds.Relations("PIDTB_BookingCns").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BookingIDTB_BookingDetails",new DataColumn(){ds.Tables("TB_Booking").Columns("ID")},new DataColumn(){ds.Tables("TB_BookingDetails").Columns("BookingID")},true)
			ds.Relations("BookingIDTB_BookingDetails").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("ReleaseIDTB_BookingReleasCntrs",new DataColumn(){ds.Tables("TB_BookingRelease").Columns("ID")},new DataColumn(){ds.Tables("TB_BookingReleasCntrs").Columns("ReleaseID")},true)
			ds.Relations("ReleaseIDTB_BookingReleasCntrs").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BookingIDTB_BookingRelease",new DataColumn(){ds.Tables("TB_Booking").Columns("ID")},new DataColumn(){ds.Tables("TB_BookingRelease").Columns("BookingID")},true)
			ds.Relations("BookingIDTB_BookingRelease").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("MasterIDTB_ChgLevelDetails",new DataColumn(){ds.Tables("TB_ChgLevelMaster").Columns("ID")},new DataColumn(){ds.Tables("TB_ChgLevelDetails").Columns("MasterID")},true)
			ds.Relations("MasterIDTB_ChgLevelDetails").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("GroupCodeTB_CODE",new DataColumn(){ds.Tables("TB_CodeMaster").Columns("GroupCode")},new DataColumn(){ds.Tables("TB_CODE").Columns("GroupCode")},true)
			ds.Relations("GroupCodeTB_CODE").ChildKeyConstraint.DeleteRule = Rule.None


			ds.Relations.Add("CntrIDTB_Damage",new DataColumn(){ds.Tables("TB_EcsContainers").Columns("ID")},new DataColumn(){ds.Tables("TB_Damage").Columns("CntrID")},true)
			ds.Relations("CntrIDTB_Damage").ChildKeyConstraint.DeleteRule = Rule.None


			ds.Relations.Add("BaseIDTB_DetentionBaseDetails",new DataColumn(){ds.Tables("TB_DetentionBase").Columns("ID")},new DataColumn(){ds.Tables("TB_DetentionBaseDetails").Columns("BaseID")},true)
			ds.Relations("BaseIDTB_DetentionBaseDetails").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("DocumentIDTB_DocumetsDetail",new DataColumn(){ds.Tables("TB_Documets").Columns("ID")},new DataColumn(){ds.Tables("TB_DocumetsDetail").Columns("DocumentID")},true)
			ds.Relations("DocumentIDTB_DocumetsDetail").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BookingIDTB_EcsContainers",new DataColumn(){ds.Tables("TB_Booking").Columns("ID")},new DataColumn(){ds.Tables("TB_EcsContainers").Columns("BookingID")},true)
			ds.Relations("BookingIDTB_EcsContainers").ChildKeyConstraint.DeleteRule = Rule.None


			ds.Relations.Add("InVoyageIDTB_EcsContainers",new DataColumn(){ds.Tables("TB_Voyage").Columns("ID")},new DataColumn(){ds.Tables("TB_EcsContainers").Columns("InVoyageID")},true)
			ds.Relations("InVoyageIDTB_EcsContainers").ChildKeyConstraint.DeleteRule = Rule.None


			ds.Relations.Add("CntrIDTB_EcsMoves",new DataColumn(){ds.Tables("TB_EcsContainers").Columns("ID")},new DataColumn(){ds.Tables("TB_EcsMoves").Columns("CntrID")},true)
			ds.Relations("CntrIDTB_EcsMoves").ChildKeyConstraint.DeleteRule = Rule.None


			ds.Relations.Add("MasterIDTB_ExchangeDetails",new DataColumn(){ds.Tables("TB_Exchange").Columns("ID")},new DataColumn(){ds.Tables("TB_ExchangeDetails").Columns("MasterID")},true)
			ds.Relations("MasterIDTB_ExchangeDetails").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BLIDTB_ExpInvoice",new DataColumn(){ds.Tables("TB_OutwardBLS").Columns("ID")},new DataColumn(){ds.Tables("TB_ExpInvoice").Columns("BLID")},true)
			ds.Relations("BLIDTB_ExpInvoice").ChildKeyConstraint.DeleteRule = Rule.None


			ds.Relations.Add("InvoiceIDTB_ExpInvoiceDetails",new DataColumn(){ds.Tables("TB_ExpInvoice").Columns("ID")},new DataColumn(){ds.Tables("TB_ExpInvoiceDetails").Columns("InvoiceID")},true)
			ds.Relations("InvoiceIDTB_ExpInvoiceDetails").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("InvoiceIDTB_ExpRecivedItems",new DataColumn(){ds.Tables("TB_ExpInvoice").Columns("ID")},new DataColumn(){ds.Tables("TB_ExpRecivedItems").Columns("InvoiceID")},true)
			ds.Relations("InvoiceIDTB_ExpRecivedItems").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("MasterIDTB_InqueryDetails",new DataColumn(){ds.Tables("TB_Inquery").Columns("ID")},new DataColumn(){ds.Tables("TB_InqueryDetails").Columns("MasterID")},true)
			ds.Relations("MasterIDTB_InqueryDetails").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BLIDTB_Invoice",new DataColumn(){ds.Tables("TB_InwardBLS").Columns("ID")},new DataColumn(){ds.Tables("TB_Invoice").Columns("BLID")},true)
			ds.Relations("BLIDTB_Invoice").ChildKeyConstraint.DeleteRule = Rule.None


			ds.Relations.Add("InvoiceIDTB_InvoiceDetails",new DataColumn(){ds.Tables("TB_Invoice").Columns("ID")},new DataColumn(){ds.Tables("TB_InvoiceDetails").Columns("InvoiceID")},true)
			ds.Relations("InvoiceIDTB_InvoiceDetails").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("ClientIDTB_InwardBLS",new DataColumn(){ds.Tables("TB_Clients").Columns("ID")},new DataColumn(){ds.Tables("TB_InwardBLS").Columns("ClientID")},true)
			ds.Relations("ClientIDTB_InwardBLS").ChildKeyConstraint.DeleteRule = Rule.None


			ds.Relations.Add("VoyageIDTB_InwardBLS",new DataColumn(){ds.Tables("TB_Voyage").Columns("ID")},new DataColumn(){ds.Tables("TB_InwardBLS").Columns("VoyageID")},true)
			ds.Relations("VoyageIDTB_InwardBLS").ChildKeyConstraint.DeleteRule = Rule.None


			ds.Relations.Add("BLIDTB_InwardBlsComments",new DataColumn(){ds.Tables("TB_InwardBLS").Columns("ID")},new DataColumn(){ds.Tables("TB_InwardBlsComments").Columns("BLID")},true)
			ds.Relations("BLIDTB_InwardBlsComments").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BLIDTb_InwardBlsFrs",new DataColumn(){ds.Tables("TB_InwardBLS").Columns("ID")},new DataColumn(){ds.Tables("Tb_InwardBlsFrs").Columns("BLID")},true)
			ds.Relations("BLIDTb_InwardBlsFrs").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BLIDTB_InwardBlsGoods",new DataColumn(){ds.Tables("TB_InwardBLS").Columns("ID")},new DataColumn(){ds.Tables("TB_InwardBlsGoods").Columns("BLID")},true)
			ds.Relations("BLIDTB_InwardBlsGoods").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BLIDTB_InwardBlsNames",new DataColumn(){ds.Tables("TB_InwardBLS").Columns("ID")},new DataColumn(){ds.Tables("TB_InwardBlsNames").Columns("BLID")},true)
			ds.Relations("BLIDTB_InwardBlsNames").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BLIDTB_InwardCharges",new DataColumn(){ds.Tables("TB_InwardBLS").Columns("ID")},new DataColumn(){ds.Tables("TB_InwardCharges").Columns("BLID")},true)
			ds.Relations("BLIDTB_InwardCharges").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("CntrIDTB_InwardCnsImco",new DataColumn(){ds.Tables("TB_InwardCntrs").Columns("ID")},new DataColumn(){ds.Tables("TB_InwardCnsImco").Columns("CntrID")},true)
			ds.Relations("CntrIDTB_InwardCnsImco").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("CntrIDTB_InwardCnsPkgs",new DataColumn(){ds.Tables("TB_InwardCntrs").Columns("ID")},new DataColumn(){ds.Tables("TB_InwardCnsPkgs").Columns("CntrID")},true)
			ds.Relations("CntrIDTB_InwardCnsPkgs").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("CntrIDTB_InwardCnsTemprature",new DataColumn(){ds.Tables("TB_InwardCntrs").Columns("ID")},new DataColumn(){ds.Tables("TB_InwardCnsTemprature").Columns("CntrID")},true)
			ds.Relations("CntrIDTB_InwardCnsTemprature").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BLIDTB_InwardCntrs",new DataColumn(){ds.Tables("TB_InwardBLS").Columns("ID")},new DataColumn(){ds.Tables("TB_InwardCntrs").Columns("BLID")},true)
			ds.Relations("BLIDTB_InwardCntrs").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("CntrIDTB_InwardCntrsCharges",new DataColumn(){ds.Tables("TB_InwardCntrs").Columns("ID")},new DataColumn(){ds.Tables("TB_InwardCntrsCharges").Columns("CntrID")},true)
			ds.Relations("CntrIDTB_InwardCntrsCharges").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BLIDTB_InwardDiscount",new DataColumn(){ds.Tables("TB_InwardBLS").Columns("ID")},new DataColumn(){ds.Tables("TB_InwardDiscount").Columns("BLID")},true)
			ds.Relations("BLIDTB_InwardDiscount").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BLIDTB_InwardStatus",new DataColumn(){ds.Tables("TB_InwardBLS").Columns("ID")},new DataColumn(){ds.Tables("TB_InwardStatus").Columns("BLID")},true)
			ds.Relations("BLIDTB_InwardStatus").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("LogIDTB_LogDetails",new DataColumn(){ds.Tables("TB_LogMaster").Columns("ID")},new DataColumn(){ds.Tables("TB_LogDetails").Columns("LogID")},true)
			ds.Relations("LogIDTB_LogDetails").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BookingIDTB_OutwardBLS",new DataColumn(){ds.Tables("TB_Booking").Columns("ID")},new DataColumn(){ds.Tables("TB_OutwardBLS").Columns("BookingID")},true)
			ds.Relations("BookingIDTB_OutwardBLS").ChildKeyConstraint.DeleteRule = Rule.None


			ds.Relations.Add("ClientIDTB_OutwardBLS",new DataColumn(){ds.Tables("TB_Clients").Columns("ID")},new DataColumn(){ds.Tables("TB_OutwardBLS").Columns("ClientID")},true)
			ds.Relations("ClientIDTB_OutwardBLS").ChildKeyConstraint.DeleteRule = Rule.None


			ds.Relations.Add("BLIDTb_OutwardBlsFrs",new DataColumn(){ds.Tables("TB_OutwardBLS").Columns("ID")},new DataColumn(){ds.Tables("Tb_OutwardBlsFrs").Columns("BLID")},true)
			ds.Relations("BLIDTb_OutwardBlsFrs").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BLIDTB_OutwardBlsGoods",new DataColumn(){ds.Tables("TB_OutwardBLS").Columns("ID")},new DataColumn(){ds.Tables("TB_OutwardBlsGoods").Columns("BLID")},true)
			ds.Relations("BLIDTB_OutwardBlsGoods").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BLIDTB_OutwardBlsNames",new DataColumn(){ds.Tables("TB_OutwardBLS").Columns("ID")},new DataColumn(){ds.Tables("TB_OutwardBlsNames").Columns("BLID")},true)
			ds.Relations("BLIDTB_OutwardBlsNames").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BLIDTB_OutwardCharges",new DataColumn(){ds.Tables("TB_OutwardBLS").Columns("ID")},new DataColumn(){ds.Tables("TB_OutwardCharges").Columns("BLID")},true)
			ds.Relations("BLIDTB_OutwardCharges").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("CntrIDTB_OutwardCnsImco",new DataColumn(){ds.Tables("TB_OutwardCntrs").Columns("ID")},new DataColumn(){ds.Tables("TB_OutwardCnsImco").Columns("CntrID")},true)
			ds.Relations("CntrIDTB_OutwardCnsImco").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("CntrIDTB_OutwardCnsPkgs",new DataColumn(){ds.Tables("TB_OutwardCntrs").Columns("ID")},new DataColumn(){ds.Tables("TB_OutwardCnsPkgs").Columns("CntrID")},true)
			ds.Relations("CntrIDTB_OutwardCnsPkgs").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("CntrIDTB_OutwardCnsTemprature",new DataColumn(){ds.Tables("TB_OutwardCntrs").Columns("ID")},new DataColumn(){ds.Tables("TB_OutwardCnsTemprature").Columns("CntrID")},true)
			ds.Relations("CntrIDTB_OutwardCnsTemprature").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BLIDTB_OutwardCntrs",new DataColumn(){ds.Tables("TB_OutwardBLS").Columns("ID")},new DataColumn(){ds.Tables("TB_OutwardCntrs").Columns("BLID")},true)
			ds.Relations("BLIDTB_OutwardCntrs").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("CntrIDTB_OutwardCntrsCharges",new DataColumn(){ds.Tables("TB_OutwardCntrs").Columns("ID")},new DataColumn(){ds.Tables("TB_OutwardCntrsCharges").Columns("CntrID")},true)
			ds.Relations("CntrIDTB_OutwardCntrsCharges").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BLIDTB_OutwardDiscount",new DataColumn(){ds.Tables("TB_OutwardBLS").Columns("ID")},new DataColumn(){ds.Tables("TB_OutwardDiscount").Columns("BLID")},true)
			ds.Relations("BLIDTB_OutwardDiscount").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("CntrIDTB_PermitDetails",new DataColumn(){ds.Tables("TB_EcsContainers").Columns("ID")},new DataColumn(){ds.Tables("TB_PermitDetails").Columns("CntrID")},true)
			ds.Relations("CntrIDTB_PermitDetails").ChildKeyConstraint.DeleteRule = Rule.None


			ds.Relations.Add("PermitIDTB_PermitDetails",new DataColumn(){ds.Tables("TB_Permits").Columns("ID")},new DataColumn(){ds.Tables("TB_PermitDetails").Columns("PermitID")},true)
			ds.Relations("PermitIDTB_PermitDetails").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("BLIDTB_PInvoice",new DataColumn(){ds.Tables("TB_InwardBLS").Columns("ID")},new DataColumn(){ds.Tables("TB_PInvoice").Columns("BLID")},true)
			ds.Relations("BLIDTB_PInvoice").ChildKeyConstraint.DeleteRule = Rule.None


			ds.Relations.Add("InvoiceIDTB_PInvoiceDetails",new DataColumn(){ds.Tables("TB_PInvoice").Columns("ID")},new DataColumn(){ds.Tables("TB_PInvoiceDetails").Columns("InvoiceID")},true)
			ds.Relations("InvoiceIDTB_PInvoiceDetails").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("InvoiceIDTB_RecivedItems",new DataColumn(){ds.Tables("TB_Invoice").Columns("ID")},new DataColumn(){ds.Tables("TB_RecivedItems").Columns("InvoiceID")},true)
			ds.Relations("InvoiceIDTB_RecivedItems").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("VoyageIDTB_SOF",new DataColumn(){ds.Tables("TB_Voyage").Columns("ID")},new DataColumn(){ds.Tables("TB_SOF").Columns("VoyageID")},true)
			ds.Relations("VoyageIDTB_SOF").ChildKeyConstraint.DeleteRule = Rule.Cascade


			ds.Relations.Add("VesselIDTB_Voyage",new DataColumn(){ds.Tables("TB_Vessels").Columns("ID")},new DataColumn(){ds.Tables("TB_Voyage").Columns("VesselID")},true)
			ds.Relations("VesselIDTB_Voyage").ChildKeyConstraint.DeleteRule = Rule.Cascade


		End Sub
	End Class
End Namespace
		
		