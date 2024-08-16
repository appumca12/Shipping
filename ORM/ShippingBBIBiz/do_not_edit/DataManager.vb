Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Reflection

Imports OrmLib

Namespace ShippingBiz
    Public Class DataManager : Inherits DataManagerBase

        Public Sub New(ByVal dsn As String)
            MyBase.New(dsn, OrmDataSet.NewDataSet())
            CustomSetting.DsnStr = dsn
        End Sub

        Public Sub New(ByVal connection As SqlConnection)
            MyBase.New(connection, OrmDataSet.NewDataSet())
        End Sub

        Public Sub New(ByVal transaction As SqlTransaction)
            MyBase.New(transaction, OrmDataSet.NewDataSet())
        End Sub

        Friend lookups As lookups

        Friend Function GetLookups() As lookups
            If lookups Is Nothing Then
                lookups = New Lookups(Me.Dsn)
            End If
            Return lookups
        End Function


		Public Function Newsysdiagrams(name As System.String, _
			principal_id As System.Data.SqlTypes.SqlInt32, _
			diagram_id As System.Int32) As ShippingBiz.sysdiagrams
			Dim dr As DataRow = DataSet.Tables("sysdiagrams").NewRow()
			DataSet.Tables("sysdiagrams").Rows.Add(dr)
            Dim _sysdiagrams As New ShippingBiz.sysdiagrams(Me, dr)
            
			_sysdiagrams.name = name
			_sysdiagrams.principal_id = principal_id
			_sysdiagrams.diagram_id = diagram_id
            
            Return _sysdiagrams
		End Function

		Public Function Getsysdiagrams(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.sysdiagrams
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("sysdiagrams", relations), ds, false)
			
			Dim sysdiagramsRow As DataRow = GetRow(ds, "sysdiagrams")
			
			If sysdiagramsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.sysdiagrams(Me, sysdiagramsRow)
			
		End Function


		Public Function GetsysdiagramsFromDataSet(ByVal diagram_id As System.Int32) As ShippingBiz.sysdiagrams
		
			Dim sysdiagramsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("sysdiagrams").Rows
				If (CType(dr("diagram_id"), System.Int32)).ToString() = diagram_id.ToString() Then
					sysdiagramsRow = dr
					Exit For
				End If
			Next

			If sysdiagramsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.sysdiagrams(Me, sysdiagramsRow)
			
		End Function
		Public Function GetsysdiagramsCollection() As ShippingBiz.sysdiagramsCollection
			Return GetsysdiagramsCollection(FetchPath.sysdiagrams)
		End Function

		Public Function GetsysdiagramsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.sysdiagramsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("sysdiagrams", relations), ds, true)
			
			Dim sysdiagramsList() As DataRow = GetRows(ds, "sysdiagrams")

			If sysdiagramsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.sysdiagramsCollection = New ShippingBiz.sysdiagramsCollection()

			Dim dr As DataRow
			For Each dr In sysdiagramsList
				a.Add(New ShippingBiz.sysdiagrams(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetsysdiagramsCollectionFromDataSet() As ShippingBiz.sysdiagramsCollection
			Dim sysdiagramsList() As DataRow = GetRows(DataSet, "sysdiagrams")
			Dim a As New ShippingBiz.sysdiagramsCollection()
			Dim dr As DataRow

			For Each dr In sysdiagramsList
				a.Add(New ShippingBiz.sysdiagrams(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_AccessLevel(ByRef parentTB_MenuItems As ShippingBiz.TB_MenuItems, _
			ByRef parentTB_Users As ShippingBiz.TB_Users) As ShippingBiz.TB_AccessLevel
			Dim dr As DataRow = DataSet.Tables("TB_AccessLevel").NewRow()
			DataSet.Tables("TB_AccessLevel").Rows.Add(dr)
            Dim _TB_AccessLevel As New ShippingBiz.TB_AccessLevel(Me, dr)
            
			_TB_AccessLevel.TB_MenuItems = parentTB_MenuItems
			_TB_AccessLevel.TB_Users = parentTB_Users
            
            Return _TB_AccessLevel
		End Function

		Public Function GetTB_AccessLevel(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AccessLevel
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_AccessLevel", relations), ds, false)
			
			Dim TB_AccessLevelRow As DataRow = GetRow(ds, "TB_AccessLevel")
			
			If TB_AccessLevelRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_AccessLevel(Me, TB_AccessLevelRow)
			
		End Function


		Public Function GetTB_AccessLevelFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_AccessLevel
		
			Dim TB_AccessLevelRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_AccessLevel").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_AccessLevelRow = dr
					Exit For
				End If
			Next

			If TB_AccessLevelRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_AccessLevel(Me, TB_AccessLevelRow)
			
		End Function
		Public Function GetTB_AccessLevelCollection() As ShippingBiz.TB_AccessLevelCollection
			Return GetTB_AccessLevelCollection(FetchPath.TB_AccessLevel)
		End Function

		Public Function GetTB_AccessLevelCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AccessLevelCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_AccessLevel", relations), ds, true)
			
			Dim TB_AccessLevelList() As DataRow = GetRows(ds, "TB_AccessLevel")

			If TB_AccessLevelList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_AccessLevelCollection = New ShippingBiz.TB_AccessLevelCollection()

			Dim dr As DataRow
			For Each dr In TB_AccessLevelList
				a.Add(New ShippingBiz.TB_AccessLevel(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_AccessLevelCollectionFromDataSet() As ShippingBiz.TB_AccessLevelCollection
			Dim TB_AccessLevelList() As DataRow = GetRows(DataSet, "TB_AccessLevel")
			Dim a As New ShippingBiz.TB_AccessLevelCollection()
			Dim dr As DataRow

			For Each dr In TB_AccessLevelList
				a.Add(New ShippingBiz.TB_AccessLevel(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Account() As ShippingBiz.TB_Account
			Dim dr As DataRow = DataSet.Tables("TB_Account").NewRow()
			DataSet.Tables("TB_Account").Rows.Add(dr)
            Dim _TB_Account As New ShippingBiz.TB_Account(Me, dr)
            

            
            Return _TB_Account
		End Function

		Public Function GetTB_Account(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Account
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Account", relations), ds, false)
			
			Dim TB_AccountRow As DataRow = GetRow(ds, "TB_Account")
			
			If TB_AccountRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Account(Me, TB_AccountRow)
			
		End Function


		Public Function GetTB_AccountFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Account
		
			Dim TB_AccountRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Account").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_AccountRow = dr
					Exit For
				End If
			Next

			If TB_AccountRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Account(Me, TB_AccountRow)
			
		End Function
		Public Function GetTB_AccountCollection() As ShippingBiz.TB_AccountCollection
			Return GetTB_AccountCollection(FetchPath.TB_Account)
		End Function

		Public Function GetTB_AccountCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AccountCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Account", relations), ds, true)
			
			Dim TB_AccountList() As DataRow = GetRows(ds, "TB_Account")

			If TB_AccountList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_AccountCollection = New ShippingBiz.TB_AccountCollection()

			Dim dr As DataRow
			For Each dr In TB_AccountList
				a.Add(New ShippingBiz.TB_Account(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_AccountCollectionFromDataSet() As ShippingBiz.TB_AccountCollection
			Dim TB_AccountList() As DataRow = GetRows(DataSet, "TB_Account")
			Dim a As New ShippingBiz.TB_AccountCollection()
			Dim dr As DataRow

			For Each dr In TB_AccountList
				a.Add(New ShippingBiz.TB_Account(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Agents(Line As System.String, _
			Port As System.String, _
			AgentName As System.String, _
			Address As System.String) As ShippingBiz.TB_Agents
			Dim dr As DataRow = DataSet.Tables("TB_Agents").NewRow()
			DataSet.Tables("TB_Agents").Rows.Add(dr)
            Dim _TB_Agents As New ShippingBiz.TB_Agents(Me, dr)
            
			_TB_Agents.Line = Line
			_TB_Agents.Port = Port
			_TB_Agents.AgentName = AgentName
			_TB_Agents.Address = Address
            
            Return _TB_Agents
		End Function

		Public Function GetTB_Agents(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Agents
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Agents", relations), ds, false)
			
			Dim TB_AgentsRow As DataRow = GetRow(ds, "TB_Agents")
			
			If TB_AgentsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Agents(Me, TB_AgentsRow)
			
		End Function


		Public Function GetTB_AgentsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Agents
		
			Dim TB_AgentsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Agents").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_AgentsRow = dr
					Exit For
				End If
			Next

			If TB_AgentsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Agents(Me, TB_AgentsRow)
			
		End Function
		Public Function GetTB_AgentsCollection() As ShippingBiz.TB_AgentsCollection
			Return GetTB_AgentsCollection(FetchPath.TB_Agents)
		End Function

		Public Function GetTB_AgentsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AgentsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Agents", relations), ds, true)
			
			Dim TB_AgentsList() As DataRow = GetRows(ds, "TB_Agents")

			If TB_AgentsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_AgentsCollection = New ShippingBiz.TB_AgentsCollection()

			Dim dr As DataRow
			For Each dr In TB_AgentsList
				a.Add(New ShippingBiz.TB_Agents(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_AgentsCollectionFromDataSet() As ShippingBiz.TB_AgentsCollection
			Dim TB_AgentsList() As DataRow = GetRows(DataSet, "TB_Agents")
			Dim a As New ShippingBiz.TB_AgentsCollection()
			Dim dr As DataRow

			For Each dr In TB_AgentsList
				a.Add(New ShippingBiz.TB_Agents(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_AUTAdditionalDocs(JobCode As System.String, _
			Seq As System.Data.SqlTypes.SqlByte, _
			HtmlContent As System.String) As ShippingBiz.TB_AUTAdditionalDocs
			Dim dr As DataRow = DataSet.Tables("TB_AUTAdditionalDocs").NewRow()
			DataSet.Tables("TB_AUTAdditionalDocs").Rows.Add(dr)
            Dim _TB_AUTAdditionalDocs As New ShippingBiz.TB_AUTAdditionalDocs(Me, dr)
            
			_TB_AUTAdditionalDocs.JobCode = JobCode
			_TB_AUTAdditionalDocs.Seq = Seq
			_TB_AUTAdditionalDocs.HtmlContent = HtmlContent
            
            Return _TB_AUTAdditionalDocs
		End Function

		Public Function GetTB_AUTAdditionalDocs(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AUTAdditionalDocs
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_AUTAdditionalDocs", relations), ds, false)
			
			Dim TB_AUTAdditionalDocsRow As DataRow = GetRow(ds, "TB_AUTAdditionalDocs")
			
			If TB_AUTAdditionalDocsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_AUTAdditionalDocs(Me, TB_AUTAdditionalDocsRow)
			
		End Function


		Public Function GetTB_AUTAdditionalDocsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_AUTAdditionalDocs
		
			Dim TB_AUTAdditionalDocsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_AUTAdditionalDocs").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_AUTAdditionalDocsRow = dr
					Exit For
				End If
			Next

			If TB_AUTAdditionalDocsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_AUTAdditionalDocs(Me, TB_AUTAdditionalDocsRow)
			
		End Function
		Public Function GetTB_AUTAdditionalDocsCollection() As ShippingBiz.TB_AUTAdditionalDocsCollection
			Return GetTB_AUTAdditionalDocsCollection(FetchPath.TB_AUTAdditionalDocs)
		End Function

		Public Function GetTB_AUTAdditionalDocsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AUTAdditionalDocsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_AUTAdditionalDocs", relations), ds, true)
			
			Dim TB_AUTAdditionalDocsList() As DataRow = GetRows(ds, "TB_AUTAdditionalDocs")

			If TB_AUTAdditionalDocsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_AUTAdditionalDocsCollection = New ShippingBiz.TB_AUTAdditionalDocsCollection()

			Dim dr As DataRow
			For Each dr In TB_AUTAdditionalDocsList
				a.Add(New ShippingBiz.TB_AUTAdditionalDocs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_AUTAdditionalDocsCollectionFromDataSet() As ShippingBiz.TB_AUTAdditionalDocsCollection
			Dim TB_AUTAdditionalDocsList() As DataRow = GetRows(DataSet, "TB_AUTAdditionalDocs")
			Dim a As New ShippingBiz.TB_AUTAdditionalDocsCollection()
			Dim dr As DataRow

			For Each dr In TB_AUTAdditionalDocsList
				a.Add(New ShippingBiz.TB_AUTAdditionalDocs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_AUTDummy(LogID As System.Guid) As ShippingBiz.TB_AUTDummy
			Dim dr As DataRow = DataSet.Tables("TB_AUTDummy").NewRow()
			DataSet.Tables("TB_AUTDummy").Rows.Add(dr)
            Dim _TB_AUTDummy As New ShippingBiz.TB_AUTDummy(Me, dr)
            
			_TB_AUTDummy.LogID = LogID
            
            Return _TB_AUTDummy
		End Function

		Public Function GetTB_AUTDummy(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AUTDummy
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_AUTDummy", relations), ds, false)
			
			Dim TB_AUTDummyRow As DataRow = GetRow(ds, "TB_AUTDummy")
			
			If TB_AUTDummyRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_AUTDummy(Me, TB_AUTDummyRow)
			
		End Function


		Public Function GetTB_AUTDummyFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_AUTDummy
		
			Dim TB_AUTDummyRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_AUTDummy").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_AUTDummyRow = dr
					Exit For
				End If
			Next

			If TB_AUTDummyRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_AUTDummy(Me, TB_AUTDummyRow)
			
		End Function
		Public Function GetTB_AUTDummyCollection() As ShippingBiz.TB_AUTDummyCollection
			Return GetTB_AUTDummyCollection(FetchPath.TB_AUTDummy)
		End Function

		Public Function GetTB_AUTDummyCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AUTDummyCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_AUTDummy", relations), ds, true)
			
			Dim TB_AUTDummyList() As DataRow = GetRows(ds, "TB_AUTDummy")

			If TB_AUTDummyList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_AUTDummyCollection = New ShippingBiz.TB_AUTDummyCollection()

			Dim dr As DataRow
			For Each dr In TB_AUTDummyList
				a.Add(New ShippingBiz.TB_AUTDummy(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_AUTDummyCollectionFromDataSet() As ShippingBiz.TB_AUTDummyCollection
			Dim TB_AUTDummyList() As DataRow = GetRows(DataSet, "TB_AUTDummy")
			Dim a As New ShippingBiz.TB_AUTDummyCollection()
			Dim dr As DataRow

			For Each dr In TB_AUTDummyList
				a.Add(New ShippingBiz.TB_AUTDummy(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_AUTDummyLog() As ShippingBiz.TB_AUTDummyLog
			Dim dr As DataRow = DataSet.Tables("TB_AUTDummyLog").NewRow()
			DataSet.Tables("TB_AUTDummyLog").Rows.Add(dr)
            Dim _TB_AUTDummyLog As New ShippingBiz.TB_AUTDummyLog(Me, dr)
            

            
            Return _TB_AUTDummyLog
		End Function

		Public Function GetTB_AUTDummyLog(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AUTDummyLog
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_AUTDummyLog", relations), ds, false)
			
			Dim TB_AUTDummyLogRow As DataRow = GetRow(ds, "TB_AUTDummyLog")
			
			If TB_AUTDummyLogRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_AUTDummyLog(Me, TB_AUTDummyLogRow)
			
		End Function


		Public Function GetTB_AUTDummyLogFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_AUTDummyLog
		
			Dim TB_AUTDummyLogRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_AUTDummyLog").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_AUTDummyLogRow = dr
					Exit For
				End If
			Next

			If TB_AUTDummyLogRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_AUTDummyLog(Me, TB_AUTDummyLogRow)
			
		End Function
		Public Function GetTB_AUTDummyLogCollection() As ShippingBiz.TB_AUTDummyLogCollection
			Return GetTB_AUTDummyLogCollection(FetchPath.TB_AUTDummyLog)
		End Function

		Public Function GetTB_AUTDummyLogCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AUTDummyLogCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_AUTDummyLog", relations), ds, true)
			
			Dim TB_AUTDummyLogList() As DataRow = GetRows(ds, "TB_AUTDummyLog")

			If TB_AUTDummyLogList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_AUTDummyLogCollection = New ShippingBiz.TB_AUTDummyLogCollection()

			Dim dr As DataRow
			For Each dr In TB_AUTDummyLogList
				a.Add(New ShippingBiz.TB_AUTDummyLog(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_AUTDummyLogCollectionFromDataSet() As ShippingBiz.TB_AUTDummyLogCollection
			Dim TB_AUTDummyLogList() As DataRow = GetRows(DataSet, "TB_AUTDummyLog")
			Dim a As New ShippingBiz.TB_AUTDummyLogCollection()
			Dim dr As DataRow

			For Each dr In TB_AUTDummyLogList
				a.Add(New ShippingBiz.TB_AUTDummyLog(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_AUTJobLogs(JobCode As System.String, _
			RequestBy As System.String, _
			CreateTime As System.Data.SqlTypes.SqlDateTime, _
			CancelJob As System.String, _
			Remarks As System.String) As ShippingBiz.TB_AUTJobLogs
			Dim dr As DataRow = DataSet.Tables("TB_AUTJobLogs").NewRow()
			DataSet.Tables("TB_AUTJobLogs").Rows.Add(dr)
            Dim _TB_AUTJobLogs As New ShippingBiz.TB_AUTJobLogs(Me, dr)
            
			_TB_AUTJobLogs.JobCode = JobCode
			_TB_AUTJobLogs.RequestBy = RequestBy
			_TB_AUTJobLogs.CreateTime = CreateTime
			_TB_AUTJobLogs.CancelJob = CancelJob
			_TB_AUTJobLogs.Remarks = Remarks
            
            Return _TB_AUTJobLogs
		End Function

		Public Function GetTB_AUTJobLogs(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AUTJobLogs
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_AUTJobLogs", relations), ds, false)
			
			Dim TB_AUTJobLogsRow As DataRow = GetRow(ds, "TB_AUTJobLogs")
			
			If TB_AUTJobLogsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_AUTJobLogs(Me, TB_AUTJobLogsRow)
			
		End Function


		Public Function GetTB_AUTJobLogsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_AUTJobLogs
		
			Dim TB_AUTJobLogsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_AUTJobLogs").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_AUTJobLogsRow = dr
					Exit For
				End If
			Next

			If TB_AUTJobLogsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_AUTJobLogs(Me, TB_AUTJobLogsRow)
			
		End Function
		Public Function GetTB_AUTJobLogsCollection() As ShippingBiz.TB_AUTJobLogsCollection
			Return GetTB_AUTJobLogsCollection(FetchPath.TB_AUTJobLogs)
		End Function

		Public Function GetTB_AUTJobLogsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AUTJobLogsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_AUTJobLogs", relations), ds, true)
			
			Dim TB_AUTJobLogsList() As DataRow = GetRows(ds, "TB_AUTJobLogs")

			If TB_AUTJobLogsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_AUTJobLogsCollection = New ShippingBiz.TB_AUTJobLogsCollection()

			Dim dr As DataRow
			For Each dr In TB_AUTJobLogsList
				a.Add(New ShippingBiz.TB_AUTJobLogs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_AUTJobLogsCollectionFromDataSet() As ShippingBiz.TB_AUTJobLogsCollection
			Dim TB_AUTJobLogsList() As DataRow = GetRows(DataSet, "TB_AUTJobLogs")
			Dim a As New ShippingBiz.TB_AUTJobLogsCollection()
			Dim dr As DataRow

			For Each dr In TB_AUTJobLogsList
				a.Add(New ShippingBiz.TB_AUTJobLogs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_AUTJobLogsDetail(ID As System.Guid, _
			DocumentID As System.Guid, _
			Document As System.String, _
			DocumentStatus As System.String, _
			GenerateTime As System.Data.SqlTypes.SqlDateTime, _
			ByRef parentTB_AUTJobLogs As ShippingBiz.TB_AUTJobLogs) As ShippingBiz.TB_AUTJobLogsDetail
			Dim dr As DataRow = DataSet.Tables("TB_AUTJobLogsDetail").NewRow()
			DataSet.Tables("TB_AUTJobLogsDetail").Rows.Add(dr)
            Dim _TB_AUTJobLogsDetail As New ShippingBiz.TB_AUTJobLogsDetail(Me, dr)
            
			_TB_AUTJobLogsDetail.ID = ID
			_TB_AUTJobLogsDetail.DocumentID = DocumentID
			_TB_AUTJobLogsDetail.Document = Document
			_TB_AUTJobLogsDetail.DocumentStatus = DocumentStatus
			_TB_AUTJobLogsDetail.GenerateTime = GenerateTime
			_TB_AUTJobLogsDetail.TB_AUTJobLogs = parentTB_AUTJobLogs
            
            Return _TB_AUTJobLogsDetail
		End Function

		Public Function GetTB_AUTJobLogsDetail(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AUTJobLogsDetail
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_AUTJobLogsDetail", relations), ds, false)
			
			Dim TB_AUTJobLogsDetailRow As DataRow = GetRow(ds, "TB_AUTJobLogsDetail")
			
			If TB_AUTJobLogsDetailRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_AUTJobLogsDetail(Me, TB_AUTJobLogsDetailRow)
			
		End Function


		Public Function GetTB_AUTJobLogsDetailFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_AUTJobLogsDetail
		
			Dim TB_AUTJobLogsDetailRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_AUTJobLogsDetail").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_AUTJobLogsDetailRow = dr
					Exit For
				End If
			Next

			If TB_AUTJobLogsDetailRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_AUTJobLogsDetail(Me, TB_AUTJobLogsDetailRow)
			
		End Function
		Public Function GetTB_AUTJobLogsDetailCollection() As ShippingBiz.TB_AUTJobLogsDetailCollection
			Return GetTB_AUTJobLogsDetailCollection(FetchPath.TB_AUTJobLogsDetail)
		End Function

		Public Function GetTB_AUTJobLogsDetailCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AUTJobLogsDetailCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_AUTJobLogsDetail", relations), ds, true)
			
			Dim TB_AUTJobLogsDetailList() As DataRow = GetRows(ds, "TB_AUTJobLogsDetail")

			If TB_AUTJobLogsDetailList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_AUTJobLogsDetailCollection = New ShippingBiz.TB_AUTJobLogsDetailCollection()

			Dim dr As DataRow
			For Each dr In TB_AUTJobLogsDetailList
				a.Add(New ShippingBiz.TB_AUTJobLogsDetail(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_AUTJobLogsDetailCollectionFromDataSet() As ShippingBiz.TB_AUTJobLogsDetailCollection
			Dim TB_AUTJobLogsDetailList() As DataRow = GetRows(DataSet, "TB_AUTJobLogsDetail")
			Dim a As New ShippingBiz.TB_AUTJobLogsDetailCollection()
			Dim dr As DataRow

			For Each dr In TB_AUTJobLogsDetailList
				a.Add(New ShippingBiz.TB_AUTJobLogsDetail(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_AUTJobs(JobCode As System.String) As ShippingBiz.TB_AUTJobs
			Dim dr As DataRow = DataSet.Tables("TB_AUTJobs").NewRow()
			DataSet.Tables("TB_AUTJobs").Rows.Add(dr)
            Dim _TB_AUTJobs As New ShippingBiz.TB_AUTJobs(Me, dr)
            
			_TB_AUTJobs.JobCode = JobCode
            
            Return _TB_AUTJobs
		End Function

		Public Function GetTB_AUTJobs(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AUTJobs
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_AUTJobs", relations), ds, false)
			
			Dim TB_AUTJobsRow As DataRow = GetRow(ds, "TB_AUTJobs")
			
			If TB_AUTJobsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_AUTJobs(Me, TB_AUTJobsRow)
			
		End Function


		Public Function GetTB_AUTJobsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_AUTJobs
		
			Dim TB_AUTJobsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_AUTJobs").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_AUTJobsRow = dr
					Exit For
				End If
			Next

			If TB_AUTJobsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_AUTJobs(Me, TB_AUTJobsRow)
			
		End Function
		Public Function GetTB_AUTJobsCollection() As ShippingBiz.TB_AUTJobsCollection
			Return GetTB_AUTJobsCollection(FetchPath.TB_AUTJobs)
		End Function

		Public Function GetTB_AUTJobsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AUTJobsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_AUTJobs", relations), ds, true)
			
			Dim TB_AUTJobsList() As DataRow = GetRows(ds, "TB_AUTJobs")

			If TB_AUTJobsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_AUTJobsCollection = New ShippingBiz.TB_AUTJobsCollection()

			Dim dr As DataRow
			For Each dr In TB_AUTJobsList
				a.Add(New ShippingBiz.TB_AUTJobs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_AUTJobsCollectionFromDataSet() As ShippingBiz.TB_AUTJobsCollection
			Dim TB_AUTJobsList() As DataRow = GetRows(DataSet, "TB_AUTJobs")
			Dim a As New ShippingBiz.TB_AUTJobsCollection()
			Dim dr As DataRow

			For Each dr In TB_AUTJobsList
				a.Add(New ShippingBiz.TB_AUTJobs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_autoLog(BLID As System.Guid) As ShippingBiz.TB_autoLog
			Dim dr As DataRow = DataSet.Tables("TB_autoLog").NewRow()
			DataSet.Tables("TB_autoLog").Rows.Add(dr)
            Dim _TB_autoLog As New ShippingBiz.TB_autoLog(Me, dr)
            
			_TB_autoLog.BLID = BLID
            
            Return _TB_autoLog
		End Function

		Public Function GetTB_autoLog(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_autoLog
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_autoLog", relations), ds, false)
			
			Dim TB_autoLogRow As DataRow = GetRow(ds, "TB_autoLog")
			
			If TB_autoLogRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_autoLog(Me, TB_autoLogRow)
			
		End Function


		Public Function GetTB_autoLogFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_autoLog
		
			Dim TB_autoLogRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_autoLog").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_autoLogRow = dr
					Exit For
				End If
			Next

			If TB_autoLogRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_autoLog(Me, TB_autoLogRow)
			
		End Function
		Public Function GetTB_autoLogCollection() As ShippingBiz.TB_autoLogCollection
			Return GetTB_autoLogCollection(FetchPath.TB_autoLog)
		End Function

		Public Function GetTB_autoLogCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_autoLogCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_autoLog", relations), ds, true)
			
			Dim TB_autoLogList() As DataRow = GetRows(ds, "TB_autoLog")

			If TB_autoLogList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_autoLogCollection = New ShippingBiz.TB_autoLogCollection()

			Dim dr As DataRow
			For Each dr In TB_autoLogList
				a.Add(New ShippingBiz.TB_autoLog(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_autoLogCollectionFromDataSet() As ShippingBiz.TB_autoLogCollection
			Dim TB_autoLogList() As DataRow = GetRows(DataSet, "TB_autoLog")
			Dim a As New ShippingBiz.TB_autoLogCollection()
			Dim dr As DataRow

			For Each dr In TB_autoLogList
				a.Add(New ShippingBiz.TB_autoLog(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_AUTSchedule(ID As System.Guid, _
			JobCode As System.String) As ShippingBiz.TB_AUTSchedule
			Dim dr As DataRow = DataSet.Tables("TB_AUTSchedule").NewRow()
			DataSet.Tables("TB_AUTSchedule").Rows.Add(dr)
            Dim _TB_AUTSchedule As New ShippingBiz.TB_AUTSchedule(Me, dr)
            
			_TB_AUTSchedule.ID = ID
			_TB_AUTSchedule.JobCode = JobCode
            
            Return _TB_AUTSchedule
		End Function

		Public Function GetTB_AUTSchedule(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AUTSchedule
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_AUTSchedule", relations), ds, false)
			
			Dim TB_AUTScheduleRow As DataRow = GetRow(ds, "TB_AUTSchedule")
			
			If TB_AUTScheduleRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_AUTSchedule(Me, TB_AUTScheduleRow)
			
		End Function


		Public Function GetTB_AUTScheduleFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_AUTSchedule
		
			Dim TB_AUTScheduleRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_AUTSchedule").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_AUTScheduleRow = dr
					Exit For
				End If
			Next

			If TB_AUTScheduleRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_AUTSchedule(Me, TB_AUTScheduleRow)
			
		End Function
		Public Function GetTB_AUTScheduleCollection() As ShippingBiz.TB_AUTScheduleCollection
			Return GetTB_AUTScheduleCollection(FetchPath.TB_AUTSchedule)
		End Function

		Public Function GetTB_AUTScheduleCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AUTScheduleCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_AUTSchedule", relations), ds, true)
			
			Dim TB_AUTScheduleList() As DataRow = GetRows(ds, "TB_AUTSchedule")

			If TB_AUTScheduleList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_AUTScheduleCollection = New ShippingBiz.TB_AUTScheduleCollection()

			Dim dr As DataRow
			For Each dr In TB_AUTScheduleList
				a.Add(New ShippingBiz.TB_AUTSchedule(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_AUTScheduleCollectionFromDataSet() As ShippingBiz.TB_AUTScheduleCollection
			Dim TB_AUTScheduleList() As DataRow = GetRows(DataSet, "TB_AUTSchedule")
			Dim a As New ShippingBiz.TB_AUTScheduleCollection()
			Dim dr As DataRow

			For Each dr In TB_AUTScheduleList
				a.Add(New ShippingBiz.TB_AUTSchedule(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_AUTSettings(MailServer As System.String, _
			MailUserName As System.String, _
			MailPassword As System.String) As ShippingBiz.TB_AUTSettings
			Dim dr As DataRow = DataSet.Tables("TB_AUTSettings").NewRow()
			DataSet.Tables("TB_AUTSettings").Rows.Add(dr)
            Dim _TB_AUTSettings As New ShippingBiz.TB_AUTSettings(Me, dr)
            
			_TB_AUTSettings.MailServer = MailServer
			_TB_AUTSettings.MailUserName = MailUserName
			_TB_AUTSettings.MailPassword = MailPassword
            
            Return _TB_AUTSettings
		End Function

		Public Function GetTB_AUTSettings(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AUTSettings
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_AUTSettings", relations), ds, false)
			
			Dim TB_AUTSettingsRow As DataRow = GetRow(ds, "TB_AUTSettings")
			
			If TB_AUTSettingsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_AUTSettings(Me, TB_AUTSettingsRow)
			
		End Function


		Public Function GetTB_AUTSettingsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_AUTSettings
		
			Dim TB_AUTSettingsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_AUTSettings").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_AUTSettingsRow = dr
					Exit For
				End If
			Next

			If TB_AUTSettingsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_AUTSettings(Me, TB_AUTSettingsRow)
			
		End Function
		Public Function GetTB_AUTSettingsCollection() As ShippingBiz.TB_AUTSettingsCollection
			Return GetTB_AUTSettingsCollection(FetchPath.TB_AUTSettings)
		End Function

		Public Function GetTB_AUTSettingsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_AUTSettingsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_AUTSettings", relations), ds, true)
			
			Dim TB_AUTSettingsList() As DataRow = GetRows(ds, "TB_AUTSettings")

			If TB_AUTSettingsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_AUTSettingsCollection = New ShippingBiz.TB_AUTSettingsCollection()

			Dim dr As DataRow
			For Each dr In TB_AUTSettingsList
				a.Add(New ShippingBiz.TB_AUTSettings(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_AUTSettingsCollectionFromDataSet() As ShippingBiz.TB_AUTSettingsCollection
			Dim TB_AUTSettingsList() As DataRow = GetRows(DataSet, "TB_AUTSettings")
			Dim a As New ShippingBiz.TB_AUTSettingsCollection()
			Dim dr As DataRow

			For Each dr In TB_AUTSettingsList
				a.Add(New ShippingBiz.TB_AUTSettings(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Booking(BookingNo As System.String, _
			BookingDate As System.Data.SqlTypes.SqlDateTime) As ShippingBiz.TB_Booking
			Dim dr As DataRow = DataSet.Tables("TB_Booking").NewRow()
			DataSet.Tables("TB_Booking").Rows.Add(dr)
            Dim _TB_Booking As New ShippingBiz.TB_Booking(Me, dr)
            
			_TB_Booking.BookingNo = BookingNo
			_TB_Booking.BookingDate = BookingDate
            
            Return _TB_Booking
		End Function

		Public Function GetTB_Booking(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Booking
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Booking", relations), ds, false)
			
			Dim TB_BookingRow As DataRow = GetRow(ds, "TB_Booking")
			
			If TB_BookingRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Booking(Me, TB_BookingRow)
			
		End Function


		Public Function GetTB_BookingFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Booking
		
			Dim TB_BookingRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Booking").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_BookingRow = dr
					Exit For
				End If
			Next

			If TB_BookingRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Booking(Me, TB_BookingRow)
			
		End Function
		Public Function GetTB_BookingCollection() As ShippingBiz.TB_BookingCollection
			Return GetTB_BookingCollection(FetchPath.TB_Booking)
		End Function

		Public Function GetTB_BookingCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_BookingCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Booking", relations), ds, true)
			
			Dim TB_BookingList() As DataRow = GetRows(ds, "TB_Booking")

			If TB_BookingList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_BookingCollection = New ShippingBiz.TB_BookingCollection()

			Dim dr As DataRow
			For Each dr In TB_BookingList
				a.Add(New ShippingBiz.TB_Booking(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_BookingCollectionFromDataSet() As ShippingBiz.TB_BookingCollection
			Dim TB_BookingList() As DataRow = GetRows(DataSet, "TB_Booking")
			Dim a As New ShippingBiz.TB_BookingCollection()
			Dim dr As DataRow

			For Each dr In TB_BookingList
				a.Add(New ShippingBiz.TB_Booking(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_BookingCns(CnType As System.String, _
			CnSize As System.String, _
			NoOfCns As System.Data.SqlTypes.SqlInt64, _
			ByRef parentTB_Booking As ShippingBiz.TB_Booking) As ShippingBiz.TB_BookingCns
			Dim dr As DataRow = DataSet.Tables("TB_BookingCns").NewRow()
			DataSet.Tables("TB_BookingCns").Rows.Add(dr)
            Dim _TB_BookingCns As New ShippingBiz.TB_BookingCns(Me, dr)
            
			_TB_BookingCns.CnType = CnType
			_TB_BookingCns.CnSize = CnSize
			_TB_BookingCns.NoOfCns = NoOfCns
			_TB_BookingCns.TB_Booking = parentTB_Booking
            
            Return _TB_BookingCns
		End Function

		Public Function GetTB_BookingCns(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_BookingCns
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_BookingCns", relations), ds, false)
			
			Dim TB_BookingCnsRow As DataRow = GetRow(ds, "TB_BookingCns")
			
			If TB_BookingCnsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_BookingCns(Me, TB_BookingCnsRow)
			
		End Function


		Public Function GetTB_BookingCnsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_BookingCns
		
			Dim TB_BookingCnsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_BookingCns").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_BookingCnsRow = dr
					Exit For
				End If
			Next

			If TB_BookingCnsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_BookingCns(Me, TB_BookingCnsRow)
			
		End Function
		Public Function GetTB_BookingCnsCollection() As ShippingBiz.TB_BookingCnsCollection
			Return GetTB_BookingCnsCollection(FetchPath.TB_BookingCns)
		End Function

		Public Function GetTB_BookingCnsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_BookingCnsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_BookingCns", relations), ds, true)
			
			Dim TB_BookingCnsList() As DataRow = GetRows(ds, "TB_BookingCns")

			If TB_BookingCnsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_BookingCnsCollection = New ShippingBiz.TB_BookingCnsCollection()

			Dim dr As DataRow
			For Each dr In TB_BookingCnsList
				a.Add(New ShippingBiz.TB_BookingCns(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_BookingCnsCollectionFromDataSet() As ShippingBiz.TB_BookingCnsCollection
			Dim TB_BookingCnsList() As DataRow = GetRows(DataSet, "TB_BookingCns")
			Dim a As New ShippingBiz.TB_BookingCnsCollection()
			Dim dr As DataRow

			For Each dr In TB_BookingCnsList
				a.Add(New ShippingBiz.TB_BookingCns(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_BookingDeposits() As ShippingBiz.TB_BookingDeposits
			Dim dr As DataRow = DataSet.Tables("TB_BookingDeposits").NewRow()
			DataSet.Tables("TB_BookingDeposits").Rows.Add(dr)
            Dim _TB_BookingDeposits As New ShippingBiz.TB_BookingDeposits(Me, dr)
            

            
            Return _TB_BookingDeposits
		End Function

		Public Function GetTB_BookingDeposits(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_BookingDeposits
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_BookingDeposits", relations), ds, false)
			
			Dim TB_BookingDepositsRow As DataRow = GetRow(ds, "TB_BookingDeposits")
			
			If TB_BookingDepositsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_BookingDeposits(Me, TB_BookingDepositsRow)
			
		End Function


		Public Function GetTB_BookingDepositsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_BookingDeposits
		
			Dim TB_BookingDepositsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_BookingDeposits").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_BookingDepositsRow = dr
					Exit For
				End If
			Next

			If TB_BookingDepositsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_BookingDeposits(Me, TB_BookingDepositsRow)
			
		End Function
		Public Function GetTB_BookingDepositsCollection() As ShippingBiz.TB_BookingDepositsCollection
			Return GetTB_BookingDepositsCollection(FetchPath.TB_BookingDeposits)
		End Function

		Public Function GetTB_BookingDepositsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_BookingDepositsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_BookingDeposits", relations), ds, true)
			
			Dim TB_BookingDepositsList() As DataRow = GetRows(ds, "TB_BookingDeposits")

			If TB_BookingDepositsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_BookingDepositsCollection = New ShippingBiz.TB_BookingDepositsCollection()

			Dim dr As DataRow
			For Each dr In TB_BookingDepositsList
				a.Add(New ShippingBiz.TB_BookingDeposits(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_BookingDepositsCollectionFromDataSet() As ShippingBiz.TB_BookingDepositsCollection
			Dim TB_BookingDepositsList() As DataRow = GetRows(DataSet, "TB_BookingDeposits")
			Dim a As New ShippingBiz.TB_BookingDepositsCollection()
			Dim dr As DataRow

			For Each dr In TB_BookingDepositsList
				a.Add(New ShippingBiz.TB_BookingDeposits(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_BookingDetails(BaseOn As System.String, _
			ByRef parentTB_Booking As ShippingBiz.TB_Booking) As ShippingBiz.TB_BookingDetails
			Dim dr As DataRow = DataSet.Tables("TB_BookingDetails").NewRow()
			DataSet.Tables("TB_BookingDetails").Rows.Add(dr)
            Dim _TB_BookingDetails As New ShippingBiz.TB_BookingDetails(Me, dr)
            
			_TB_BookingDetails.BaseOn = BaseOn
			_TB_BookingDetails.TB_Booking = parentTB_Booking
            
            Return _TB_BookingDetails
		End Function

		Public Function GetTB_BookingDetails(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_BookingDetails
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_BookingDetails", relations), ds, false)
			
			Dim TB_BookingDetailsRow As DataRow = GetRow(ds, "TB_BookingDetails")
			
			If TB_BookingDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_BookingDetails(Me, TB_BookingDetailsRow)
			
		End Function


		Public Function GetTB_BookingDetailsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_BookingDetails
		
			Dim TB_BookingDetailsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_BookingDetails").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_BookingDetailsRow = dr
					Exit For
				End If
			Next

			If TB_BookingDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_BookingDetails(Me, TB_BookingDetailsRow)
			
		End Function
		Public Function GetTB_BookingDetailsCollection() As ShippingBiz.TB_BookingDetailsCollection
			Return GetTB_BookingDetailsCollection(FetchPath.TB_BookingDetails)
		End Function

		Public Function GetTB_BookingDetailsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_BookingDetailsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_BookingDetails", relations), ds, true)
			
			Dim TB_BookingDetailsList() As DataRow = GetRows(ds, "TB_BookingDetails")

			If TB_BookingDetailsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_BookingDetailsCollection = New ShippingBiz.TB_BookingDetailsCollection()

			Dim dr As DataRow
			For Each dr In TB_BookingDetailsList
				a.Add(New ShippingBiz.TB_BookingDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_BookingDetailsCollectionFromDataSet() As ShippingBiz.TB_BookingDetailsCollection
			Dim TB_BookingDetailsList() As DataRow = GetRows(DataSet, "TB_BookingDetails")
			Dim a As New ShippingBiz.TB_BookingDetailsCollection()
			Dim dr As DataRow

			For Each dr In TB_BookingDetailsList
				a.Add(New ShippingBiz.TB_BookingDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_BookingReleasCntrs(CnType As System.String, _
			CnSize As System.String, _
			NoOfCntrs As System.Data.SqlTypes.SqlInt16, _
			ByRef parentTB_BookingRelease As ShippingBiz.TB_BookingRelease) As ShippingBiz.TB_BookingReleasCntrs
			Dim dr As DataRow = DataSet.Tables("TB_BookingReleasCntrs").NewRow()
			DataSet.Tables("TB_BookingReleasCntrs").Rows.Add(dr)
            Dim _TB_BookingReleasCntrs As New ShippingBiz.TB_BookingReleasCntrs(Me, dr)
            
			_TB_BookingReleasCntrs.CnType = CnType
			_TB_BookingReleasCntrs.CnSize = CnSize
			_TB_BookingReleasCntrs.NoOfCntrs = NoOfCntrs
			_TB_BookingReleasCntrs.TB_BookingRelease = parentTB_BookingRelease
            
            Return _TB_BookingReleasCntrs
		End Function

		Public Function GetTB_BookingReleasCntrs(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_BookingReleasCntrs
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_BookingReleasCntrs", relations), ds, false)
			
			Dim TB_BookingReleasCntrsRow As DataRow = GetRow(ds, "TB_BookingReleasCntrs")
			
			If TB_BookingReleasCntrsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_BookingReleasCntrs(Me, TB_BookingReleasCntrsRow)
			
		End Function


		Public Function GetTB_BookingReleasCntrsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_BookingReleasCntrs
		
			Dim TB_BookingReleasCntrsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_BookingReleasCntrs").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_BookingReleasCntrsRow = dr
					Exit For
				End If
			Next

			If TB_BookingReleasCntrsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_BookingReleasCntrs(Me, TB_BookingReleasCntrsRow)
			
		End Function
		Public Function GetTB_BookingReleasCntrsCollection() As ShippingBiz.TB_BookingReleasCntrsCollection
			Return GetTB_BookingReleasCntrsCollection(FetchPath.TB_BookingReleasCntrs)
		End Function

		Public Function GetTB_BookingReleasCntrsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_BookingReleasCntrsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_BookingReleasCntrs", relations), ds, true)
			
			Dim TB_BookingReleasCntrsList() As DataRow = GetRows(ds, "TB_BookingReleasCntrs")

			If TB_BookingReleasCntrsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_BookingReleasCntrsCollection = New ShippingBiz.TB_BookingReleasCntrsCollection()

			Dim dr As DataRow
			For Each dr In TB_BookingReleasCntrsList
				a.Add(New ShippingBiz.TB_BookingReleasCntrs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_BookingReleasCntrsCollectionFromDataSet() As ShippingBiz.TB_BookingReleasCntrsCollection
			Dim TB_BookingReleasCntrsList() As DataRow = GetRows(DataSet, "TB_BookingReleasCntrs")
			Dim a As New ShippingBiz.TB_BookingReleasCntrsCollection()
			Dim dr As DataRow

			For Each dr In TB_BookingReleasCntrsList
				a.Add(New ShippingBiz.TB_BookingReleasCntrs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_BookingRelease(RequestTime As System.Data.SqlTypes.SqlDateTime) As ShippingBiz.TB_BookingRelease
			Dim dr As DataRow = DataSet.Tables("TB_BookingRelease").NewRow()
			DataSet.Tables("TB_BookingRelease").Rows.Add(dr)
            Dim _TB_BookingRelease As New ShippingBiz.TB_BookingRelease(Me, dr)
            
			_TB_BookingRelease.RequestTime = RequestTime
            
            Return _TB_BookingRelease
		End Function

		Public Function GetTB_BookingRelease(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_BookingRelease
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_BookingRelease", relations), ds, false)
			
			Dim TB_BookingReleaseRow As DataRow = GetRow(ds, "TB_BookingRelease")
			
			If TB_BookingReleaseRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_BookingRelease(Me, TB_BookingReleaseRow)
			
		End Function


		Public Function GetTB_BookingReleaseFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_BookingRelease
		
			Dim TB_BookingReleaseRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_BookingRelease").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_BookingReleaseRow = dr
					Exit For
				End If
			Next

			If TB_BookingReleaseRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_BookingRelease(Me, TB_BookingReleaseRow)
			
		End Function
		Public Function GetTB_BookingReleaseCollection() As ShippingBiz.TB_BookingReleaseCollection
			Return GetTB_BookingReleaseCollection(FetchPath.TB_BookingRelease)
		End Function

		Public Function GetTB_BookingReleaseCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_BookingReleaseCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_BookingRelease", relations), ds, true)
			
			Dim TB_BookingReleaseList() As DataRow = GetRows(ds, "TB_BookingRelease")

			If TB_BookingReleaseList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_BookingReleaseCollection = New ShippingBiz.TB_BookingReleaseCollection()

			Dim dr As DataRow
			For Each dr In TB_BookingReleaseList
				a.Add(New ShippingBiz.TB_BookingRelease(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_BookingReleaseCollectionFromDataSet() As ShippingBiz.TB_BookingReleaseCollection
			Dim TB_BookingReleaseList() As DataRow = GetRows(DataSet, "TB_BookingRelease")
			Dim a As New ShippingBiz.TB_BookingReleaseCollection()
			Dim dr As DataRow

			For Each dr In TB_BookingReleaseList
				a.Add(New ShippingBiz.TB_BookingRelease(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_CalculationBase(ExchangeRateInward As System.String, _
			ExchangeRateOutward As System.String, _
			DetentionInwardStartTime As System.String, _
			DetentionOutwardStartTime As System.String, _
			TaxDutyInward As System.String, _
			TaxDutyOutward As System.String, _
			IsTaxDutyJoin As System.Data.SqlTypes.SqlBoolean) As ShippingBiz.TB_CalculationBase
			Dim dr As DataRow = DataSet.Tables("TB_CalculationBase").NewRow()
			DataSet.Tables("TB_CalculationBase").Rows.Add(dr)
            Dim _TB_CalculationBase As New ShippingBiz.TB_CalculationBase(Me, dr)
            
			_TB_CalculationBase.ExchangeRateInward = ExchangeRateInward
			_TB_CalculationBase.ExchangeRateOutward = ExchangeRateOutward
			_TB_CalculationBase.DetentionInwardStartTime = DetentionInwardStartTime
			_TB_CalculationBase.DetentionOutwardStartTime = DetentionOutwardStartTime
			_TB_CalculationBase.TaxDutyInward = TaxDutyInward
			_TB_CalculationBase.TaxDutyOutward = TaxDutyOutward
			_TB_CalculationBase.IsTaxDutyJoin = IsTaxDutyJoin
            
            Return _TB_CalculationBase
		End Function

		Public Function GetTB_CalculationBase(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_CalculationBase
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_CalculationBase", relations), ds, false)
			
			Dim TB_CalculationBaseRow As DataRow = GetRow(ds, "TB_CalculationBase")
			
			If TB_CalculationBaseRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_CalculationBase(Me, TB_CalculationBaseRow)
			
		End Function


		Public Function GetTB_CalculationBaseFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_CalculationBase
		
			Dim TB_CalculationBaseRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_CalculationBase").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_CalculationBaseRow = dr
					Exit For
				End If
			Next

			If TB_CalculationBaseRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_CalculationBase(Me, TB_CalculationBaseRow)
			
		End Function
		Public Function GetTB_CalculationBaseCollection() As ShippingBiz.TB_CalculationBaseCollection
			Return GetTB_CalculationBaseCollection(FetchPath.TB_CalculationBase)
		End Function

		Public Function GetTB_CalculationBaseCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_CalculationBaseCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_CalculationBase", relations), ds, true)
			
			Dim TB_CalculationBaseList() As DataRow = GetRows(ds, "TB_CalculationBase")

			If TB_CalculationBaseList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_CalculationBaseCollection = New ShippingBiz.TB_CalculationBaseCollection()

			Dim dr As DataRow
			For Each dr In TB_CalculationBaseList
				a.Add(New ShippingBiz.TB_CalculationBase(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_CalculationBaseCollectionFromDataSet() As ShippingBiz.TB_CalculationBaseCollection
			Dim TB_CalculationBaseList() As DataRow = GetRows(DataSet, "TB_CalculationBase")
			Dim a As New ShippingBiz.TB_CalculationBaseCollection()
			Dim dr As DataRow

			For Each dr In TB_CalculationBaseList
				a.Add(New ShippingBiz.TB_CalculationBase(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_ChgLevelDetails(CnType As System.String, _
			SOC As System.String, _
			ShipmentType As System.String, _
			Imco As System.String, _
			Amount20 As System.Data.SqlTypes.SqlDouble, _
			Amount40 As System.Data.SqlTypes.SqlDouble, _
			ByRef parentTB_ChgLevelMaster As ShippingBiz.TB_ChgLevelMaster) As ShippingBiz.TB_ChgLevelDetails
			Dim dr As DataRow = DataSet.Tables("TB_ChgLevelDetails").NewRow()
			DataSet.Tables("TB_ChgLevelDetails").Rows.Add(dr)
            Dim _TB_ChgLevelDetails As New ShippingBiz.TB_ChgLevelDetails(Me, dr)
            
			_TB_ChgLevelDetails.CnType = CnType
			_TB_ChgLevelDetails.SOC = SOC
			_TB_ChgLevelDetails.ShipmentType = ShipmentType
			_TB_ChgLevelDetails.Imco = Imco
			_TB_ChgLevelDetails.Amount20 = Amount20
			_TB_ChgLevelDetails.Amount40 = Amount40
			_TB_ChgLevelDetails.TB_ChgLevelMaster = parentTB_ChgLevelMaster
            
            Return _TB_ChgLevelDetails
		End Function

		Public Function GetTB_ChgLevelDetails(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ChgLevelDetails
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_ChgLevelDetails", relations), ds, false)
			
			Dim TB_ChgLevelDetailsRow As DataRow = GetRow(ds, "TB_ChgLevelDetails")
			
			If TB_ChgLevelDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ChgLevelDetails(Me, TB_ChgLevelDetailsRow)
			
		End Function


		Public Function GetTB_ChgLevelDetailsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_ChgLevelDetails
		
			Dim TB_ChgLevelDetailsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_ChgLevelDetails").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_ChgLevelDetailsRow = dr
					Exit For
				End If
			Next

			If TB_ChgLevelDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ChgLevelDetails(Me, TB_ChgLevelDetailsRow)
			
		End Function
		Public Function GetTB_ChgLevelDetailsCollection() As ShippingBiz.TB_ChgLevelDetailsCollection
			Return GetTB_ChgLevelDetailsCollection(FetchPath.TB_ChgLevelDetails)
		End Function

		Public Function GetTB_ChgLevelDetailsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ChgLevelDetailsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_ChgLevelDetails", relations), ds, true)
			
			Dim TB_ChgLevelDetailsList() As DataRow = GetRows(ds, "TB_ChgLevelDetails")

			If TB_ChgLevelDetailsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_ChgLevelDetailsCollection = New ShippingBiz.TB_ChgLevelDetailsCollection()

			Dim dr As DataRow
			For Each dr In TB_ChgLevelDetailsList
				a.Add(New ShippingBiz.TB_ChgLevelDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_ChgLevelDetailsCollectionFromDataSet() As ShippingBiz.TB_ChgLevelDetailsCollection
			Dim TB_ChgLevelDetailsList() As DataRow = GetRows(DataSet, "TB_ChgLevelDetails")
			Dim a As New ShippingBiz.TB_ChgLevelDetailsCollection()
			Dim dr As DataRow

			For Each dr In TB_ChgLevelDetailsList
				a.Add(New ShippingBiz.TB_ChgLevelDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_ChgLevelMaster() As ShippingBiz.TB_ChgLevelMaster
			Dim dr As DataRow = DataSet.Tables("TB_ChgLevelMaster").NewRow()
			DataSet.Tables("TB_ChgLevelMaster").Rows.Add(dr)
            Dim _TB_ChgLevelMaster As New ShippingBiz.TB_ChgLevelMaster(Me, dr)
            

            
            Return _TB_ChgLevelMaster
		End Function

		Public Function GetTB_ChgLevelMaster(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ChgLevelMaster
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_ChgLevelMaster", relations), ds, false)
			
			Dim TB_ChgLevelMasterRow As DataRow = GetRow(ds, "TB_ChgLevelMaster")
			
			If TB_ChgLevelMasterRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ChgLevelMaster(Me, TB_ChgLevelMasterRow)
			
		End Function


		Public Function GetTB_ChgLevelMasterFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_ChgLevelMaster
		
			Dim TB_ChgLevelMasterRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_ChgLevelMaster").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_ChgLevelMasterRow = dr
					Exit For
				End If
			Next

			If TB_ChgLevelMasterRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ChgLevelMaster(Me, TB_ChgLevelMasterRow)
			
		End Function
		Public Function GetTB_ChgLevelMasterCollection() As ShippingBiz.TB_ChgLevelMasterCollection
			Return GetTB_ChgLevelMasterCollection(FetchPath.TB_ChgLevelMaster)
		End Function

		Public Function GetTB_ChgLevelMasterCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ChgLevelMasterCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_ChgLevelMaster", relations), ds, true)
			
			Dim TB_ChgLevelMasterList() As DataRow = GetRows(ds, "TB_ChgLevelMaster")

			If TB_ChgLevelMasterList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_ChgLevelMasterCollection = New ShippingBiz.TB_ChgLevelMasterCollection()

			Dim dr As DataRow
			For Each dr In TB_ChgLevelMasterList
				a.Add(New ShippingBiz.TB_ChgLevelMaster(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_ChgLevelMasterCollectionFromDataSet() As ShippingBiz.TB_ChgLevelMasterCollection
			Dim TB_ChgLevelMasterList() As DataRow = GetRows(DataSet, "TB_ChgLevelMaster")
			Dim a As New ShippingBiz.TB_ChgLevelMasterCollection()
			Dim dr As DataRow

			For Each dr In TB_ChgLevelMasterList
				a.Add(New ShippingBiz.TB_ChgLevelMaster(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Clients(lName As System.String) As ShippingBiz.TB_Clients
			Dim dr As DataRow = DataSet.Tables("TB_Clients").NewRow()
			DataSet.Tables("TB_Clients").Rows.Add(dr)
            Dim _TB_Clients As New ShippingBiz.TB_Clients(Me, dr)
            
			_TB_Clients.lName = lName
            
            Return _TB_Clients
		End Function

		Public Function GetTB_Clients(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Clients
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Clients", relations), ds, false)
			
			Dim TB_ClientsRow As DataRow = GetRow(ds, "TB_Clients")
			
			If TB_ClientsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Clients(Me, TB_ClientsRow)
			
		End Function


		Public Function GetTB_ClientsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Clients
		
			Dim TB_ClientsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Clients").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_ClientsRow = dr
					Exit For
				End If
			Next

			If TB_ClientsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Clients(Me, TB_ClientsRow)
			
		End Function
		Public Function GetTB_ClientsCollection() As ShippingBiz.TB_ClientsCollection
			Return GetTB_ClientsCollection(FetchPath.TB_Clients)
		End Function

		Public Function GetTB_ClientsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ClientsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Clients", relations), ds, true)
			
			Dim TB_ClientsList() As DataRow = GetRows(ds, "TB_Clients")

			If TB_ClientsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_ClientsCollection = New ShippingBiz.TB_ClientsCollection()

			Dim dr As DataRow
			For Each dr In TB_ClientsList
				a.Add(New ShippingBiz.TB_Clients(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_ClientsCollectionFromDataSet() As ShippingBiz.TB_ClientsCollection
			Dim TB_ClientsList() As DataRow = GetRows(DataSet, "TB_Clients")
			Dim a As New ShippingBiz.TB_ClientsCollection()
			Dim dr As DataRow

			For Each dr In TB_ClientsList
				a.Add(New ShippingBiz.TB_Clients(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Cluses(CluseGroup As System.String, _
			Description As System.String) As ShippingBiz.TB_Cluses
			Dim dr As DataRow = DataSet.Tables("TB_Cluses").NewRow()
			DataSet.Tables("TB_Cluses").Rows.Add(dr)
            Dim _TB_Cluses As New ShippingBiz.TB_Cluses(Me, dr)
            
			_TB_Cluses.CluseGroup = CluseGroup
			_TB_Cluses.Description = Description
            
            Return _TB_Cluses
		End Function

		Public Function GetTB_Cluses(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Cluses
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Cluses", relations), ds, false)
			
			Dim TB_ClusesRow As DataRow = GetRow(ds, "TB_Cluses")
			
			If TB_ClusesRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Cluses(Me, TB_ClusesRow)
			
		End Function


		Public Function GetTB_ClusesFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Cluses
		
			Dim TB_ClusesRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Cluses").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_ClusesRow = dr
					Exit For
				End If
			Next

			If TB_ClusesRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Cluses(Me, TB_ClusesRow)
			
		End Function
		Public Function GetTB_ClusesCollection() As ShippingBiz.TB_ClusesCollection
			Return GetTB_ClusesCollection(FetchPath.TB_Cluses)
		End Function

		Public Function GetTB_ClusesCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ClusesCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Cluses", relations), ds, true)
			
			Dim TB_ClusesList() As DataRow = GetRows(ds, "TB_Cluses")

			If TB_ClusesList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_ClusesCollection = New ShippingBiz.TB_ClusesCollection()

			Dim dr As DataRow
			For Each dr In TB_ClusesList
				a.Add(New ShippingBiz.TB_Cluses(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_ClusesCollectionFromDataSet() As ShippingBiz.TB_ClusesCollection
			Dim TB_ClusesList() As DataRow = GetRows(DataSet, "TB_Cluses")
			Dim a As New ShippingBiz.TB_ClusesCollection()
			Dim dr As DataRow

			For Each dr In TB_ClusesList
				a.Add(New ShippingBiz.TB_Cluses(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_CODE() As ShippingBiz.TB_CODE
			Dim dr As DataRow = DataSet.Tables("TB_CODE").NewRow()
			DataSet.Tables("TB_CODE").Rows.Add(dr)
            Dim _TB_CODE As New ShippingBiz.TB_CODE(Me, dr)
            

            
            Return _TB_CODE
		End Function

		Public Function GetTB_CODE(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_CODE
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_CODE", relations), ds, false)
			
			Dim TB_CODERow As DataRow = GetRow(ds, "TB_CODE")
			
			If TB_CODERow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_CODE(Me, TB_CODERow)
			
		End Function


		Public Function GetTB_CODEFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_CODE
		
			Dim TB_CODERow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_CODE").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_CODERow = dr
					Exit For
				End If
			Next

			If TB_CODERow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_CODE(Me, TB_CODERow)
			
		End Function
		Public Function GetTB_CODECollection() As ShippingBiz.TB_CODECollection
			Return GetTB_CODECollection(FetchPath.TB_CODE)
		End Function

		Public Function GetTB_CODECollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_CODECollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_CODE", relations), ds, true)
			
			Dim TB_CODEList() As DataRow = GetRows(ds, "TB_CODE")

			If TB_CODEList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_CODECollection = New ShippingBiz.TB_CODECollection()

			Dim dr As DataRow
			For Each dr In TB_CODEList
				a.Add(New ShippingBiz.TB_CODE(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_CODECollectionFromDataSet() As ShippingBiz.TB_CODECollection
			Dim TB_CODEList() As DataRow = GetRows(DataSet, "TB_CODE")
			Dim a As New ShippingBiz.TB_CODECollection()
			Dim dr As DataRow

			For Each dr In TB_CODEList
				a.Add(New ShippingBiz.TB_CODE(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_CodeMaster(GroupCode As System.String, _
			GroupName As System.String) As ShippingBiz.TB_CodeMaster
			Dim dr As DataRow = DataSet.Tables("TB_CodeMaster").NewRow()
			DataSet.Tables("TB_CodeMaster").Rows.Add(dr)
            Dim _TB_CodeMaster As New ShippingBiz.TB_CodeMaster(Me, dr)
            
			_TB_CodeMaster.GroupCode = GroupCode
			_TB_CodeMaster.GroupName = GroupName
            
            Return _TB_CodeMaster
		End Function

		Public Function GetTB_CodeMaster(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_CodeMaster
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_CodeMaster", relations), ds, false)
			
			Dim TB_CodeMasterRow As DataRow = GetRow(ds, "TB_CodeMaster")
			
			If TB_CodeMasterRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_CodeMaster(Me, TB_CodeMasterRow)
			
		End Function


		Public Function GetTB_CodeMasterFromDataSet(ByVal GroupCode As System.String) As ShippingBiz.TB_CodeMaster
		
			Dim TB_CodeMasterRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_CodeMaster").Rows
				If (CType(dr("GroupCode"), System.String)).ToString() = GroupCode.ToString() Then
					TB_CodeMasterRow = dr
					Exit For
				End If
			Next

			If TB_CodeMasterRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_CodeMaster(Me, TB_CodeMasterRow)
			
		End Function
		Public Function GetTB_CodeMasterCollection() As ShippingBiz.TB_CodeMasterCollection
			Return GetTB_CodeMasterCollection(FetchPath.TB_CodeMaster)
		End Function

		Public Function GetTB_CodeMasterCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_CodeMasterCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_CodeMaster", relations), ds, true)
			
			Dim TB_CodeMasterList() As DataRow = GetRows(ds, "TB_CodeMaster")

			If TB_CodeMasterList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_CodeMasterCollection = New ShippingBiz.TB_CodeMasterCollection()

			Dim dr As DataRow
			For Each dr In TB_CodeMasterList
				a.Add(New ShippingBiz.TB_CodeMaster(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_CodeMasterCollectionFromDataSet() As ShippingBiz.TB_CodeMasterCollection
			Dim TB_CodeMasterList() As DataRow = GetRows(DataSet, "TB_CodeMaster")
			Dim a As New ShippingBiz.TB_CodeMasterCollection()
			Dim dr As DataRow

			For Each dr In TB_CodeMasterList
				a.Add(New ShippingBiz.TB_CodeMaster(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Company(CompanyName As System.String, _
			CompanyAddress As System.String, _
			Tel As System.String, _
			Fax As System.String, _
			EDICODE As System.String) As ShippingBiz.TB_Company
			Dim dr As DataRow = DataSet.Tables("TB_Company").NewRow()
			DataSet.Tables("TB_Company").Rows.Add(dr)
            Dim _TB_Company As New ShippingBiz.TB_Company(Me, dr)
            
			_TB_Company.CompanyName = CompanyName
			_TB_Company.CompanyAddress = CompanyAddress
			_TB_Company.Tel = Tel
			_TB_Company.Fax = Fax
			_TB_Company.EDICODE = EDICODE
            
            Return _TB_Company
		End Function

		Public Function GetTB_Company(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Company
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Company", relations), ds, false)
			
			Dim TB_CompanyRow As DataRow = GetRow(ds, "TB_Company")
			
			If TB_CompanyRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Company(Me, TB_CompanyRow)
			
		End Function


		Public Function GetTB_CompanyFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Company
		
			Dim TB_CompanyRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Company").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_CompanyRow = dr
					Exit For
				End If
			Next

			If TB_CompanyRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Company(Me, TB_CompanyRow)
			
		End Function
		Public Function GetTB_CompanyCollection() As ShippingBiz.TB_CompanyCollection
			Return GetTB_CompanyCollection(FetchPath.TB_Company)
		End Function

		Public Function GetTB_CompanyCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_CompanyCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
            FillDataSet(CreateSql("TB_Company", relations), ds, True)
			
			Dim TB_CompanyList() As DataRow = GetRows(ds, "TB_Company")

			If TB_CompanyList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_CompanyCollection = New ShippingBiz.TB_CompanyCollection()

			Dim dr As DataRow
			For Each dr In TB_CompanyList
				a.Add(New ShippingBiz.TB_Company(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_CompanyCollectionFromDataSet() As ShippingBiz.TB_CompanyCollection
			Dim TB_CompanyList() As DataRow = GetRows(DataSet, "TB_Company")
			Dim a As New ShippingBiz.TB_CompanyCollection()
			Dim dr As DataRow

			For Each dr In TB_CompanyList
				a.Add(New ShippingBiz.TB_Company(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Country(CountryCode As System.String, _
			CountryName As System.String) As ShippingBiz.TB_Country
			Dim dr As DataRow = DataSet.Tables("TB_Country").NewRow()
			DataSet.Tables("TB_Country").Rows.Add(dr)
            Dim _TB_Country As New ShippingBiz.TB_Country(Me, dr)
            
			_TB_Country.CountryCode = CountryCode
			_TB_Country.CountryName = CountryName
            
            Return _TB_Country
		End Function

		Public Function GetTB_Country(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Country
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Country", relations), ds, false)
			
			Dim TB_CountryRow As DataRow = GetRow(ds, "TB_Country")
			
			If TB_CountryRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Country(Me, TB_CountryRow)
			
		End Function


		Public Function GetTB_CountryFromDataSet(ByVal CountryCode As System.String) As ShippingBiz.TB_Country
		
			Dim TB_CountryRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Country").Rows
				If (CType(dr("CountryCode"), System.String)).ToString() = CountryCode.ToString() Then
					TB_CountryRow = dr
					Exit For
				End If
			Next

			If TB_CountryRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Country(Me, TB_CountryRow)
			
		End Function
		Public Function GetTB_CountryCollection() As ShippingBiz.TB_CountryCollection
			Return GetTB_CountryCollection(FetchPath.TB_Country)
		End Function

		Public Function GetTB_CountryCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_CountryCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Country", relations), ds, true)
			
			Dim TB_CountryList() As DataRow = GetRows(ds, "TB_Country")

			If TB_CountryList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_CountryCollection = New ShippingBiz.TB_CountryCollection()

			Dim dr As DataRow
			For Each dr In TB_CountryList
				a.Add(New ShippingBiz.TB_Country(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_CountryCollectionFromDataSet() As ShippingBiz.TB_CountryCollection
			Dim TB_CountryList() As DataRow = GetRows(DataSet, "TB_Country")
			Dim a As New ShippingBiz.TB_CountryCollection()
			Dim dr As DataRow

			For Each dr In TB_CountryList
				a.Add(New ShippingBiz.TB_Country(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_CustomMenu() As ShippingBiz.TB_CustomMenu
			Dim dr As DataRow = DataSet.Tables("TB_CustomMenu").NewRow()
			DataSet.Tables("TB_CustomMenu").Rows.Add(dr)
            Dim _TB_CustomMenu As New ShippingBiz.TB_CustomMenu(Me, dr)
            

            
            Return _TB_CustomMenu
		End Function

		Public Function GetTB_CustomMenu(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_CustomMenu
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_CustomMenu", relations), ds, false)
			
			Dim TB_CustomMenuRow As DataRow = GetRow(ds, "TB_CustomMenu")
			
			If TB_CustomMenuRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_CustomMenu(Me, TB_CustomMenuRow)
			
		End Function


		Public Function GetTB_CustomMenuFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_CustomMenu
		
			Dim TB_CustomMenuRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_CustomMenu").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_CustomMenuRow = dr
					Exit For
				End If
			Next

			If TB_CustomMenuRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_CustomMenu(Me, TB_CustomMenuRow)
			
		End Function
		Public Function GetTB_CustomMenuCollection() As ShippingBiz.TB_CustomMenuCollection
			Return GetTB_CustomMenuCollection(FetchPath.TB_CustomMenu)
		End Function

		Public Function GetTB_CustomMenuCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_CustomMenuCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_CustomMenu", relations), ds, true)
			
			Dim TB_CustomMenuList() As DataRow = GetRows(ds, "TB_CustomMenu")

			If TB_CustomMenuList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_CustomMenuCollection = New ShippingBiz.TB_CustomMenuCollection()

			Dim dr As DataRow
			For Each dr In TB_CustomMenuList
				a.Add(New ShippingBiz.TB_CustomMenu(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_CustomMenuCollectionFromDataSet() As ShippingBiz.TB_CustomMenuCollection
			Dim TB_CustomMenuList() As DataRow = GetRows(DataSet, "TB_CustomMenu")
			Dim a As New ShippingBiz.TB_CustomMenuCollection()
			Dim dr As DataRow

			For Each dr In TB_CustomMenuList
				a.Add(New ShippingBiz.TB_CustomMenu(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Damage(ReportDate As System.Data.SqlTypes.SqlDateTime, _
			Description As System.String, _
			ByRef parentTB_EcsContainers As ShippingBiz.TB_EcsContainers) As ShippingBiz.TB_Damage
			Dim dr As DataRow = DataSet.Tables("TB_Damage").NewRow()
			DataSet.Tables("TB_Damage").Rows.Add(dr)
            Dim _TB_Damage As New ShippingBiz.TB_Damage(Me, dr)
            
			_TB_Damage.ReportDate = ReportDate
			_TB_Damage.Description = Description
			_TB_Damage.TB_EcsContainers = parentTB_EcsContainers
            
            Return _TB_Damage
		End Function

		Public Function GetTB_Damage(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Damage
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Damage", relations), ds, false)
			
			Dim TB_DamageRow As DataRow = GetRow(ds, "TB_Damage")
			
			If TB_DamageRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Damage(Me, TB_DamageRow)
			
		End Function


		Public Function GetTB_DamageFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Damage
		
			Dim TB_DamageRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Damage").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_DamageRow = dr
					Exit For
				End If
			Next

			If TB_DamageRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Damage(Me, TB_DamageRow)
			
		End Function
		Public Function GetTB_DamageCollection() As ShippingBiz.TB_DamageCollection
			Return GetTB_DamageCollection(FetchPath.TB_Damage)
		End Function

		Public Function GetTB_DamageCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_DamageCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Damage", relations), ds, true)
			
			Dim TB_DamageList() As DataRow = GetRows(ds, "TB_Damage")

			If TB_DamageList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_DamageCollection = New ShippingBiz.TB_DamageCollection()

			Dim dr As DataRow
			For Each dr In TB_DamageList
				a.Add(New ShippingBiz.TB_Damage(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_DamageCollectionFromDataSet() As ShippingBiz.TB_DamageCollection
			Dim TB_DamageList() As DataRow = GetRows(DataSet, "TB_Damage")
			Dim a As New ShippingBiz.TB_DamageCollection()
			Dim dr As DataRow

			For Each dr In TB_DamageList
				a.Add(New ShippingBiz.TB_Damage(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Deposits() As ShippingBiz.TB_Deposits
			Dim dr As DataRow = DataSet.Tables("TB_Deposits").NewRow()
			DataSet.Tables("TB_Deposits").Rows.Add(dr)
            Dim _TB_Deposits As New ShippingBiz.TB_Deposits(Me, dr)
            

            
            Return _TB_Deposits
		End Function

		Public Function GetTB_Deposits(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Deposits
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Deposits", relations), ds, false)
			
			Dim TB_DepositsRow As DataRow = GetRow(ds, "TB_Deposits")
			
			If TB_DepositsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Deposits(Me, TB_DepositsRow)
			
		End Function


		Public Function GetTB_DepositsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Deposits
		
			Dim TB_DepositsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Deposits").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_DepositsRow = dr
					Exit For
				End If
			Next

			If TB_DepositsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Deposits(Me, TB_DepositsRow)
			
		End Function
		Public Function GetTB_DepositsCollection() As ShippingBiz.TB_DepositsCollection
			Return GetTB_DepositsCollection(FetchPath.TB_Deposits)
		End Function

		Public Function GetTB_DepositsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_DepositsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Deposits", relations), ds, true)
			
			Dim TB_DepositsList() As DataRow = GetRows(ds, "TB_Deposits")

			If TB_DepositsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_DepositsCollection = New ShippingBiz.TB_DepositsCollection()

			Dim dr As DataRow
			For Each dr In TB_DepositsList
				a.Add(New ShippingBiz.TB_Deposits(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_DepositsCollectionFromDataSet() As ShippingBiz.TB_DepositsCollection
			Dim TB_DepositsList() As DataRow = GetRows(DataSet, "TB_Deposits")
			Dim a As New ShippingBiz.TB_DepositsCollection()
			Dim dr As DataRow

			For Each dr In TB_DepositsList
				a.Add(New ShippingBiz.TB_Deposits(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_DetentionBase(ImpExp As System.String, _
			ApplyDate As System.Data.SqlTypes.SqlDateTime, _
			Validity As System.Data.SqlTypes.SqlDateTime) As ShippingBiz.TB_DetentionBase
			Dim dr As DataRow = DataSet.Tables("TB_DetentionBase").NewRow()
			DataSet.Tables("TB_DetentionBase").Rows.Add(dr)
            Dim _TB_DetentionBase As New ShippingBiz.TB_DetentionBase(Me, dr)
            
			_TB_DetentionBase.ImpExp = ImpExp
			_TB_DetentionBase.ApplyDate = ApplyDate
			_TB_DetentionBase.Validity = Validity
            
            Return _TB_DetentionBase
		End Function

		Public Function GetTB_DetentionBase(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_DetentionBase
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_DetentionBase", relations), ds, false)
			
			Dim TB_DetentionBaseRow As DataRow = GetRow(ds, "TB_DetentionBase")
			
			If TB_DetentionBaseRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_DetentionBase(Me, TB_DetentionBaseRow)
			
		End Function


		Public Function GetTB_DetentionBaseFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_DetentionBase
		
			Dim TB_DetentionBaseRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_DetentionBase").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_DetentionBaseRow = dr
					Exit For
				End If
			Next

			If TB_DetentionBaseRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_DetentionBase(Me, TB_DetentionBaseRow)
			
		End Function
		Public Function GetTB_DetentionBaseCollection() As ShippingBiz.TB_DetentionBaseCollection
			Return GetTB_DetentionBaseCollection(FetchPath.TB_DetentionBase)
		End Function

		Public Function GetTB_DetentionBaseCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_DetentionBaseCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_DetentionBase", relations), ds, true)
			
			Dim TB_DetentionBaseList() As DataRow = GetRows(ds, "TB_DetentionBase")

			If TB_DetentionBaseList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_DetentionBaseCollection = New ShippingBiz.TB_DetentionBaseCollection()

			Dim dr As DataRow
			For Each dr In TB_DetentionBaseList
				a.Add(New ShippingBiz.TB_DetentionBase(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_DetentionBaseCollectionFromDataSet() As ShippingBiz.TB_DetentionBaseCollection
			Dim TB_DetentionBaseList() As DataRow = GetRows(DataSet, "TB_DetentionBase")
			Dim a As New ShippingBiz.TB_DetentionBaseCollection()
			Dim dr As DataRow

			For Each dr In TB_DetentionBaseList
				a.Add(New ShippingBiz.TB_DetentionBase(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_DetentionBaseDetails(CnType As System.String, _
			DayFrom As System.Data.SqlTypes.SqlInt16, _
			DayTo As System.Data.SqlTypes.SqlInt16, _
			Amount20 As System.Data.SqlTypes.SqlDouble, _
			Amount40 As System.Data.SqlTypes.SqlDouble, _
			Amount45 As System.Data.SqlTypes.SqlDouble, _
			ByRef parentTB_DetentionBase As ShippingBiz.TB_DetentionBase) As ShippingBiz.TB_DetentionBaseDetails
			Dim dr As DataRow = DataSet.Tables("TB_DetentionBaseDetails").NewRow()
			DataSet.Tables("TB_DetentionBaseDetails").Rows.Add(dr)
            Dim _TB_DetentionBaseDetails As New ShippingBiz.TB_DetentionBaseDetails(Me, dr)
            
			_TB_DetentionBaseDetails.CnType = CnType
			_TB_DetentionBaseDetails.DayFrom = DayFrom
			_TB_DetentionBaseDetails.DayTo = DayTo
			_TB_DetentionBaseDetails.Amount20 = Amount20
			_TB_DetentionBaseDetails.Amount40 = Amount40
			_TB_DetentionBaseDetails.Amount45 = Amount45
			_TB_DetentionBaseDetails.TB_DetentionBase = parentTB_DetentionBase
            
            Return _TB_DetentionBaseDetails
		End Function

		Public Function GetTB_DetentionBaseDetails(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_DetentionBaseDetails
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_DetentionBaseDetails", relations), ds, false)
			
			Dim TB_DetentionBaseDetailsRow As DataRow = GetRow(ds, "TB_DetentionBaseDetails")
			
			If TB_DetentionBaseDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_DetentionBaseDetails(Me, TB_DetentionBaseDetailsRow)
			
		End Function


		Public Function GetTB_DetentionBaseDetailsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_DetentionBaseDetails
		
			Dim TB_DetentionBaseDetailsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_DetentionBaseDetails").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_DetentionBaseDetailsRow = dr
					Exit For
				End If
			Next

			If TB_DetentionBaseDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_DetentionBaseDetails(Me, TB_DetentionBaseDetailsRow)
			
		End Function
		Public Function GetTB_DetentionBaseDetailsCollection() As ShippingBiz.TB_DetentionBaseDetailsCollection
			Return GetTB_DetentionBaseDetailsCollection(FetchPath.TB_DetentionBaseDetails)
		End Function

		Public Function GetTB_DetentionBaseDetailsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_DetentionBaseDetailsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_DetentionBaseDetails", relations), ds, true)
			
			Dim TB_DetentionBaseDetailsList() As DataRow = GetRows(ds, "TB_DetentionBaseDetails")

			If TB_DetentionBaseDetailsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_DetentionBaseDetailsCollection = New ShippingBiz.TB_DetentionBaseDetailsCollection()

			Dim dr As DataRow
			For Each dr In TB_DetentionBaseDetailsList
				a.Add(New ShippingBiz.TB_DetentionBaseDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_DetentionBaseDetailsCollectionFromDataSet() As ShippingBiz.TB_DetentionBaseDetailsCollection
			Dim TB_DetentionBaseDetailsList() As DataRow = GetRows(DataSet, "TB_DetentionBaseDetails")
			Dim a As New ShippingBiz.TB_DetentionBaseDetailsCollection()
			Dim dr As DataRow

			For Each dr In TB_DetentionBaseDetailsList
				a.Add(New ShippingBiz.TB_DetentionBaseDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Documets(LineCode As System.String, _
			DocumentType As System.String) As ShippingBiz.TB_Documets
			Dim dr As DataRow = DataSet.Tables("TB_Documets").NewRow()
			DataSet.Tables("TB_Documets").Rows.Add(dr)
            Dim _TB_Documets As New ShippingBiz.TB_Documets(Me, dr)
            
			_TB_Documets.LineCode = LineCode
			_TB_Documets.DocumentType = DocumentType
            
            Return _TB_Documets
		End Function

		Public Function GetTB_Documets(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Documets
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Documets", relations), ds, false)
			
			Dim TB_DocumetsRow As DataRow = GetRow(ds, "TB_Documets")
			
			If TB_DocumetsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Documets(Me, TB_DocumetsRow)
			
		End Function


		Public Function GetTB_DocumetsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Documets
		
			Dim TB_DocumetsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Documets").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_DocumetsRow = dr
					Exit For
				End If
			Next

			If TB_DocumetsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Documets(Me, TB_DocumetsRow)
			
		End Function
		Public Function GetTB_DocumetsCollection() As ShippingBiz.TB_DocumetsCollection
			Return GetTB_DocumetsCollection(FetchPath.TB_Documets)
		End Function

		Public Function GetTB_DocumetsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_DocumetsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Documets", relations), ds, true)
			
			Dim TB_DocumetsList() As DataRow = GetRows(ds, "TB_Documets")

			If TB_DocumetsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_DocumetsCollection = New ShippingBiz.TB_DocumetsCollection()

			Dim dr As DataRow
			For Each dr In TB_DocumetsList
				a.Add(New ShippingBiz.TB_Documets(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_DocumetsCollectionFromDataSet() As ShippingBiz.TB_DocumetsCollection
			Dim TB_DocumetsList() As DataRow = GetRows(DataSet, "TB_Documets")
			Dim a As New ShippingBiz.TB_DocumetsCollection()
			Dim dr As DataRow

			For Each dr In TB_DocumetsList
				a.Add(New ShippingBiz.TB_Documets(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_DocumetsDetail(FieldDescription As System.String, _
			FieldName As System.String, _
			Visible As System.Data.SqlTypes.SqlBoolean, _
			nTop As System.Data.SqlTypes.SqlSingle, _
			nLeft As System.Data.SqlTypes.SqlSingle, _
			nHight As System.Data.SqlTypes.SqlSingle, _
			nWidth As System.Data.SqlTypes.SqlSingle, _
			ByRef parentTB_Documets As ShippingBiz.TB_Documets) As ShippingBiz.TB_DocumetsDetail
			Dim dr As DataRow = DataSet.Tables("TB_DocumetsDetail").NewRow()
			DataSet.Tables("TB_DocumetsDetail").Rows.Add(dr)
            Dim _TB_DocumetsDetail As New ShippingBiz.TB_DocumetsDetail(Me, dr)
            
			_TB_DocumetsDetail.FieldDescription = FieldDescription
			_TB_DocumetsDetail.FieldName = FieldName
			_TB_DocumetsDetail.Visible = Visible
			_TB_DocumetsDetail.nTop = nTop
			_TB_DocumetsDetail.nLeft = nLeft
			_TB_DocumetsDetail.nHight = nHight
			_TB_DocumetsDetail.nWidth = nWidth
			_TB_DocumetsDetail.TB_Documets = parentTB_Documets
            
            Return _TB_DocumetsDetail
		End Function

		Public Function GetTB_DocumetsDetail(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_DocumetsDetail
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_DocumetsDetail", relations), ds, false)
			
			Dim TB_DocumetsDetailRow As DataRow = GetRow(ds, "TB_DocumetsDetail")
			
			If TB_DocumetsDetailRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_DocumetsDetail(Me, TB_DocumetsDetailRow)
			
		End Function


		Public Function GetTB_DocumetsDetailFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_DocumetsDetail
		
			Dim TB_DocumetsDetailRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_DocumetsDetail").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_DocumetsDetailRow = dr
					Exit For
				End If
			Next

			If TB_DocumetsDetailRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_DocumetsDetail(Me, TB_DocumetsDetailRow)
			
		End Function
		Public Function GetTB_DocumetsDetailCollection() As ShippingBiz.TB_DocumetsDetailCollection
			Return GetTB_DocumetsDetailCollection(FetchPath.TB_DocumetsDetail)
		End Function

		Public Function GetTB_DocumetsDetailCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_DocumetsDetailCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_DocumetsDetail", relations), ds, true)
			
			Dim TB_DocumetsDetailList() As DataRow = GetRows(ds, "TB_DocumetsDetail")

			If TB_DocumetsDetailList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_DocumetsDetailCollection = New ShippingBiz.TB_DocumetsDetailCollection()

			Dim dr As DataRow
			For Each dr In TB_DocumetsDetailList
				a.Add(New ShippingBiz.TB_DocumetsDetail(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_DocumetsDetailCollectionFromDataSet() As ShippingBiz.TB_DocumetsDetailCollection
			Dim TB_DocumetsDetailList() As DataRow = GetRows(DataSet, "TB_DocumetsDetail")
			Dim a As New ShippingBiz.TB_DocumetsDetailCollection()
			Dim dr As DataRow

			For Each dr In TB_DocumetsDetailList
				a.Add(New ShippingBiz.TB_DocumetsDetail(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_EcsContainers(Line As System.String, _
			CntrNo As System.String, _
			CnSize As System.String, _
			CnType As System.String, _
			DischargeTo As System.String, _
			InStatus As System.String, _
			ByRef parentTB_Voyage As ShippingBiz.TB_Voyage) As ShippingBiz.TB_EcsContainers
			Dim dr As DataRow = DataSet.Tables("TB_EcsContainers").NewRow()
			DataSet.Tables("TB_EcsContainers").Rows.Add(dr)
            Dim _TB_EcsContainers As New ShippingBiz.TB_EcsContainers(Me, dr)
            
			_TB_EcsContainers.Line = Line
			_TB_EcsContainers.CntrNo = CntrNo
			_TB_EcsContainers.CnSize = CnSize
			_TB_EcsContainers.CnType = CnType
			_TB_EcsContainers.DischargeTo = DischargeTo
			_TB_EcsContainers.InStatus = InStatus
			_TB_EcsContainers.TB_Voyage = parentTB_Voyage
            
            Return _TB_EcsContainers
		End Function

		Public Function GetTB_EcsContainers(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_EcsContainers
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_EcsContainers", relations), ds, false)
			
			Dim TB_EcsContainersRow As DataRow = GetRow(ds, "TB_EcsContainers")
			
			If TB_EcsContainersRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_EcsContainers(Me, TB_EcsContainersRow)
			
		End Function


		Public Function GetTB_EcsContainersFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_EcsContainers
		
			Dim TB_EcsContainersRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_EcsContainers").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_EcsContainersRow = dr
					Exit For
				End If
			Next

			If TB_EcsContainersRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_EcsContainers(Me, TB_EcsContainersRow)
			
		End Function
		Public Function GetTB_EcsContainersCollection() As ShippingBiz.TB_EcsContainersCollection
			Return GetTB_EcsContainersCollection(FetchPath.TB_EcsContainers)
		End Function

		Public Function GetTB_EcsContainersCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_EcsContainersCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_EcsContainers", relations), ds, true)
			
			Dim TB_EcsContainersList() As DataRow = GetRows(ds, "TB_EcsContainers")

			If TB_EcsContainersList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_EcsContainersCollection = New ShippingBiz.TB_EcsContainersCollection()

			Dim dr As DataRow
			For Each dr In TB_EcsContainersList
				a.Add(New ShippingBiz.TB_EcsContainers(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_EcsContainersCollectionFromDataSet() As ShippingBiz.TB_EcsContainersCollection
			Dim TB_EcsContainersList() As DataRow = GetRows(DataSet, "TB_EcsContainers")
			Dim a As New ShippingBiz.TB_EcsContainersCollection()
			Dim dr As DataRow

			For Each dr In TB_EcsContainersList
				a.Add(New ShippingBiz.TB_EcsContainers(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_EcsMoves(ByRef parentTB_EcsContainers As ShippingBiz.TB_EcsContainers) As ShippingBiz.TB_EcsMoves
			Dim dr As DataRow = DataSet.Tables("TB_EcsMoves").NewRow()
			DataSet.Tables("TB_EcsMoves").Rows.Add(dr)
            Dim _TB_EcsMoves As New ShippingBiz.TB_EcsMoves(Me, dr)
            
			_TB_EcsMoves.TB_EcsContainers = parentTB_EcsContainers
            
            Return _TB_EcsMoves
		End Function

		Public Function GetTB_EcsMoves(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_EcsMoves
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_EcsMoves", relations), ds, false)
			
			Dim TB_EcsMovesRow As DataRow = GetRow(ds, "TB_EcsMoves")
			
			If TB_EcsMovesRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_EcsMoves(Me, TB_EcsMovesRow)
			
		End Function


		Public Function GetTB_EcsMovesFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_EcsMoves
		
			Dim TB_EcsMovesRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_EcsMoves").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_EcsMovesRow = dr
					Exit For
				End If
			Next

			If TB_EcsMovesRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_EcsMoves(Me, TB_EcsMovesRow)
			
		End Function
		Public Function GetTB_EcsMovesCollection() As ShippingBiz.TB_EcsMovesCollection
			Return GetTB_EcsMovesCollection(FetchPath.TB_EcsMoves)
		End Function

		Public Function GetTB_EcsMovesCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_EcsMovesCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_EcsMoves", relations), ds, true)
			
			Dim TB_EcsMovesList() As DataRow = GetRows(ds, "TB_EcsMoves")

			If TB_EcsMovesList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_EcsMovesCollection = New ShippingBiz.TB_EcsMovesCollection()

			Dim dr As DataRow
			For Each dr In TB_EcsMovesList
				a.Add(New ShippingBiz.TB_EcsMoves(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_EcsMovesCollectionFromDataSet() As ShippingBiz.TB_EcsMovesCollection
			Dim TB_EcsMovesList() As DataRow = GetRows(DataSet, "TB_EcsMoves")
			Dim a As New ShippingBiz.TB_EcsMovesCollection()
			Dim dr As DataRow

			For Each dr In TB_EcsMovesList
				a.Add(New ShippingBiz.TB_EcsMoves(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_EcsReserveContainers(CntrNo As System.String) As ShippingBiz.TB_EcsReserveContainers
			Dim dr As DataRow = DataSet.Tables("TB_EcsReserveContainers").NewRow()
			DataSet.Tables("TB_EcsReserveContainers").Rows.Add(dr)
            Dim _TB_EcsReserveContainers As New ShippingBiz.TB_EcsReserveContainers(Me, dr)
            
			_TB_EcsReserveContainers.CntrNo = CntrNo
            
            Return _TB_EcsReserveContainers
		End Function

		Public Function GetTB_EcsReserveContainers(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_EcsReserveContainers
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_EcsReserveContainers", relations), ds, false)
			
			Dim TB_EcsReserveContainersRow As DataRow = GetRow(ds, "TB_EcsReserveContainers")
			
			If TB_EcsReserveContainersRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_EcsReserveContainers(Me, TB_EcsReserveContainersRow)
			
		End Function


		Public Function GetTB_EcsReserveContainersFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_EcsReserveContainers
		
			Dim TB_EcsReserveContainersRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_EcsReserveContainers").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_EcsReserveContainersRow = dr
					Exit For
				End If
			Next

			If TB_EcsReserveContainersRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_EcsReserveContainers(Me, TB_EcsReserveContainersRow)
			
		End Function
		Public Function GetTB_EcsReserveContainersCollection() As ShippingBiz.TB_EcsReserveContainersCollection
			Return GetTB_EcsReserveContainersCollection(FetchPath.TB_EcsReserveContainers)
		End Function

		Public Function GetTB_EcsReserveContainersCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_EcsReserveContainersCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_EcsReserveContainers", relations), ds, true)
			
			Dim TB_EcsReserveContainersList() As DataRow = GetRows(ds, "TB_EcsReserveContainers")

			If TB_EcsReserveContainersList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_EcsReserveContainersCollection = New ShippingBiz.TB_EcsReserveContainersCollection()

			Dim dr As DataRow
			For Each dr In TB_EcsReserveContainersList
				a.Add(New ShippingBiz.TB_EcsReserveContainers(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_EcsReserveContainersCollectionFromDataSet() As ShippingBiz.TB_EcsReserveContainersCollection
			Dim TB_EcsReserveContainersList() As DataRow = GetRows(DataSet, "TB_EcsReserveContainers")
			Dim a As New ShippingBiz.TB_EcsReserveContainersCollection()
			Dim dr As DataRow

			For Each dr In TB_EcsReserveContainersList
				a.Add(New ShippingBiz.TB_EcsReserveContainers(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_EventMail(EventCode As System.String) As ShippingBiz.TB_EventMail
			Dim dr As DataRow = DataSet.Tables("TB_EventMail").NewRow()
			DataSet.Tables("TB_EventMail").Rows.Add(dr)
            Dim _TB_EventMail As New ShippingBiz.TB_EventMail(Me, dr)
            
			_TB_EventMail.EventCode = EventCode
            
            Return _TB_EventMail
		End Function

		Public Function GetTB_EventMail(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_EventMail
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_EventMail", relations), ds, false)
			
			Dim TB_EventMailRow As DataRow = GetRow(ds, "TB_EventMail")
			
			If TB_EventMailRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_EventMail(Me, TB_EventMailRow)
			
		End Function


		Public Function GetTB_EventMailFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_EventMail
		
			Dim TB_EventMailRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_EventMail").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_EventMailRow = dr
					Exit For
				End If
			Next

			If TB_EventMailRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_EventMail(Me, TB_EventMailRow)
			
		End Function
		Public Function GetTB_EventMailCollection() As ShippingBiz.TB_EventMailCollection
			Return GetTB_EventMailCollection(FetchPath.TB_EventMail)
		End Function

		Public Function GetTB_EventMailCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_EventMailCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_EventMail", relations), ds, true)
			
			Dim TB_EventMailList() As DataRow = GetRows(ds, "TB_EventMail")

			If TB_EventMailList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_EventMailCollection = New ShippingBiz.TB_EventMailCollection()

			Dim dr As DataRow
			For Each dr In TB_EventMailList
				a.Add(New ShippingBiz.TB_EventMail(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_EventMailCollectionFromDataSet() As ShippingBiz.TB_EventMailCollection
			Dim TB_EventMailList() As DataRow = GetRows(DataSet, "TB_EventMail")
			Dim a As New ShippingBiz.TB_EventMailCollection()
			Dim dr As DataRow

			For Each dr In TB_EventMailList
				a.Add(New ShippingBiz.TB_EventMail(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Exchange(ExchangeDate As System.Data.SqlTypes.SqlDateTime) As ShippingBiz.TB_Exchange
			Dim dr As DataRow = DataSet.Tables("TB_Exchange").NewRow()
			DataSet.Tables("TB_Exchange").Rows.Add(dr)
            Dim _TB_Exchange As New ShippingBiz.TB_Exchange(Me, dr)
            
			_TB_Exchange.ExchangeDate = ExchangeDate
            
            Return _TB_Exchange
		End Function

		Public Function GetTB_Exchange(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Exchange
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Exchange", relations), ds, false)
			
			Dim TB_ExchangeRow As DataRow = GetRow(ds, "TB_Exchange")
			
			If TB_ExchangeRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Exchange(Me, TB_ExchangeRow)
			
		End Function


		Public Function GetTB_ExchangeFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Exchange
		
			Dim TB_ExchangeRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Exchange").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_ExchangeRow = dr
					Exit For
				End If
			Next

			If TB_ExchangeRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Exchange(Me, TB_ExchangeRow)
			
		End Function
		Public Function GetTB_ExchangeCollection() As ShippingBiz.TB_ExchangeCollection
			Return GetTB_ExchangeCollection(FetchPath.TB_Exchange)
		End Function

		Public Function GetTB_ExchangeCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ExchangeCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Exchange", relations), ds, true)
			
			Dim TB_ExchangeList() As DataRow = GetRows(ds, "TB_Exchange")

			If TB_ExchangeList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_ExchangeCollection = New ShippingBiz.TB_ExchangeCollection()

			Dim dr As DataRow
			For Each dr In TB_ExchangeList
				a.Add(New ShippingBiz.TB_Exchange(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_ExchangeCollectionFromDataSet() As ShippingBiz.TB_ExchangeCollection
			Dim TB_ExchangeList() As DataRow = GetRows(DataSet, "TB_Exchange")
			Dim a As New ShippingBiz.TB_ExchangeCollection()
			Dim dr As DataRow

			For Each dr In TB_ExchangeList
				a.Add(New ShippingBiz.TB_Exchange(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_ExchangeDetails(CurCode As System.String, _
			THCRate As System.Data.SqlTypes.SqlDecimal, _
			FRTRate As System.Data.SqlTypes.SqlDecimal, _
			ByRef parentTB_Exchange As ShippingBiz.TB_Exchange) As ShippingBiz.TB_ExchangeDetails
			Dim dr As DataRow = DataSet.Tables("TB_ExchangeDetails").NewRow()
			DataSet.Tables("TB_ExchangeDetails").Rows.Add(dr)
            Dim _TB_ExchangeDetails As New ShippingBiz.TB_ExchangeDetails(Me, dr)
            
			_TB_ExchangeDetails.CurCode = CurCode
			_TB_ExchangeDetails.THCRate = THCRate
			_TB_ExchangeDetails.FRTRate = FRTRate
			_TB_ExchangeDetails.TB_Exchange = parentTB_Exchange
            
            Return _TB_ExchangeDetails
		End Function

		Public Function GetTB_ExchangeDetails(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ExchangeDetails
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_ExchangeDetails", relations), ds, false)
			
			Dim TB_ExchangeDetailsRow As DataRow = GetRow(ds, "TB_ExchangeDetails")
			
			If TB_ExchangeDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ExchangeDetails(Me, TB_ExchangeDetailsRow)
			
		End Function


		Public Function GetTB_ExchangeDetailsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_ExchangeDetails
		
			Dim TB_ExchangeDetailsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_ExchangeDetails").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_ExchangeDetailsRow = dr
					Exit For
				End If
			Next

			If TB_ExchangeDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ExchangeDetails(Me, TB_ExchangeDetailsRow)
			
		End Function
		Public Function GetTB_ExchangeDetailsCollection() As ShippingBiz.TB_ExchangeDetailsCollection
			Return GetTB_ExchangeDetailsCollection(FetchPath.TB_ExchangeDetails)
		End Function

		Public Function GetTB_ExchangeDetailsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ExchangeDetailsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_ExchangeDetails", relations), ds, true)
			
			Dim TB_ExchangeDetailsList() As DataRow = GetRows(ds, "TB_ExchangeDetails")

			If TB_ExchangeDetailsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_ExchangeDetailsCollection = New ShippingBiz.TB_ExchangeDetailsCollection()

			Dim dr As DataRow
			For Each dr In TB_ExchangeDetailsList
				a.Add(New ShippingBiz.TB_ExchangeDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_ExchangeDetailsCollectionFromDataSet() As ShippingBiz.TB_ExchangeDetailsCollection
			Dim TB_ExchangeDetailsList() As DataRow = GetRows(DataSet, "TB_ExchangeDetails")
			Dim a As New ShippingBiz.TB_ExchangeDetailsCollection()
			Dim dr As DataRow

			For Each dr In TB_ExchangeDetailsList
				a.Add(New ShippingBiz.TB_ExchangeDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_ExpInvoice(Description As System.String, _
			ByRef parentTB_OutwardBLS As ShippingBiz.TB_OutwardBLS) As ShippingBiz.TB_ExpInvoice
			Dim dr As DataRow = DataSet.Tables("TB_ExpInvoice").NewRow()
			DataSet.Tables("TB_ExpInvoice").Rows.Add(dr)
            Dim _TB_ExpInvoice As New ShippingBiz.TB_ExpInvoice(Me, dr)
            
			_TB_ExpInvoice.Description = Description
			_TB_ExpInvoice.TB_OutwardBLS = parentTB_OutwardBLS
            
            Return _TB_ExpInvoice
		End Function

		Public Function GetTB_ExpInvoice(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ExpInvoice
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_ExpInvoice", relations), ds, false)
			
			Dim TB_ExpInvoiceRow As DataRow = GetRow(ds, "TB_ExpInvoice")
			
			If TB_ExpInvoiceRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ExpInvoice(Me, TB_ExpInvoiceRow)
			
		End Function


		Public Function GetTB_ExpInvoiceFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_ExpInvoice
		
			Dim TB_ExpInvoiceRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_ExpInvoice").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_ExpInvoiceRow = dr
					Exit For
				End If
			Next

			If TB_ExpInvoiceRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ExpInvoice(Me, TB_ExpInvoiceRow)
			
		End Function
		Public Function GetTB_ExpInvoiceCollection() As ShippingBiz.TB_ExpInvoiceCollection
			Return GetTB_ExpInvoiceCollection(FetchPath.TB_ExpInvoice)
		End Function

		Public Function GetTB_ExpInvoiceCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ExpInvoiceCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_ExpInvoice", relations), ds, true)
			
			Dim TB_ExpInvoiceList() As DataRow = GetRows(ds, "TB_ExpInvoice")

			If TB_ExpInvoiceList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_ExpInvoiceCollection = New ShippingBiz.TB_ExpInvoiceCollection()

			Dim dr As DataRow
			For Each dr In TB_ExpInvoiceList
				a.Add(New ShippingBiz.TB_ExpInvoice(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_ExpInvoiceCollectionFromDataSet() As ShippingBiz.TB_ExpInvoiceCollection
			Dim TB_ExpInvoiceList() As DataRow = GetRows(DataSet, "TB_ExpInvoice")
			Dim a As New ShippingBiz.TB_ExpInvoiceCollection()
			Dim dr As DataRow

			For Each dr In TB_ExpInvoiceList
				a.Add(New ShippingBiz.TB_ExpInvoice(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_ExpInvoiceDetails(Seq As System.Data.SqlTypes.SqlInt16, _
			ChargesCode As System.String, _
			Currency As System.String, _
			Amount As System.Data.SqlTypes.SqlDouble, _
			IRRAmount As System.Data.SqlTypes.SqlDouble, _
			ByRef parentTB_ExpInvoice As ShippingBiz.TB_ExpInvoice) As ShippingBiz.TB_ExpInvoiceDetails
			Dim dr As DataRow = DataSet.Tables("TB_ExpInvoiceDetails").NewRow()
			DataSet.Tables("TB_ExpInvoiceDetails").Rows.Add(dr)
            Dim _TB_ExpInvoiceDetails As New ShippingBiz.TB_ExpInvoiceDetails(Me, dr)
            
			_TB_ExpInvoiceDetails.Seq = Seq
			_TB_ExpInvoiceDetails.ChargesCode = ChargesCode
			_TB_ExpInvoiceDetails.Currency = Currency
			_TB_ExpInvoiceDetails.Amount = Amount
			_TB_ExpInvoiceDetails.IRRAmount = IRRAmount
			_TB_ExpInvoiceDetails.TB_ExpInvoice = parentTB_ExpInvoice
            
            Return _TB_ExpInvoiceDetails
		End Function

		Public Function GetTB_ExpInvoiceDetails(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ExpInvoiceDetails
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_ExpInvoiceDetails", relations), ds, false)
			
			Dim TB_ExpInvoiceDetailsRow As DataRow = GetRow(ds, "TB_ExpInvoiceDetails")
			
			If TB_ExpInvoiceDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ExpInvoiceDetails(Me, TB_ExpInvoiceDetailsRow)
			
		End Function


		Public Function GetTB_ExpInvoiceDetailsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_ExpInvoiceDetails
		
			Dim TB_ExpInvoiceDetailsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_ExpInvoiceDetails").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_ExpInvoiceDetailsRow = dr
					Exit For
				End If
			Next

			If TB_ExpInvoiceDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ExpInvoiceDetails(Me, TB_ExpInvoiceDetailsRow)
			
		End Function
		Public Function GetTB_ExpInvoiceDetailsCollection() As ShippingBiz.TB_ExpInvoiceDetailsCollection
			Return GetTB_ExpInvoiceDetailsCollection(FetchPath.TB_ExpInvoiceDetails)
		End Function

		Public Function GetTB_ExpInvoiceDetailsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ExpInvoiceDetailsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_ExpInvoiceDetails", relations), ds, true)
			
			Dim TB_ExpInvoiceDetailsList() As DataRow = GetRows(ds, "TB_ExpInvoiceDetails")

			If TB_ExpInvoiceDetailsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_ExpInvoiceDetailsCollection = New ShippingBiz.TB_ExpInvoiceDetailsCollection()

			Dim dr As DataRow
			For Each dr In TB_ExpInvoiceDetailsList
				a.Add(New ShippingBiz.TB_ExpInvoiceDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_ExpInvoiceDetailsCollectionFromDataSet() As ShippingBiz.TB_ExpInvoiceDetailsCollection
			Dim TB_ExpInvoiceDetailsList() As DataRow = GetRows(DataSet, "TB_ExpInvoiceDetails")
			Dim a As New ShippingBiz.TB_ExpInvoiceDetailsCollection()
			Dim dr As DataRow

			For Each dr In TB_ExpInvoiceDetailsList
				a.Add(New ShippingBiz.TB_ExpInvoiceDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_ExpRecivedItems(Seq As System.Data.SqlTypes.SqlInt16, _
			PaymentType As System.String, _
			Currency As System.String, _
			Amount As System.Data.SqlTypes.SqlDouble, _
			ByRef parentTB_ExpInvoice As ShippingBiz.TB_ExpInvoice) As ShippingBiz.TB_ExpRecivedItems
			Dim dr As DataRow = DataSet.Tables("TB_ExpRecivedItems").NewRow()
			DataSet.Tables("TB_ExpRecivedItems").Rows.Add(dr)
            Dim _TB_ExpRecivedItems As New ShippingBiz.TB_ExpRecivedItems(Me, dr)
            
			_TB_ExpRecivedItems.Seq = Seq
			_TB_ExpRecivedItems.PaymentType = PaymentType
			_TB_ExpRecivedItems.Currency = Currency
			_TB_ExpRecivedItems.Amount = Amount
			_TB_ExpRecivedItems.TB_ExpInvoice = parentTB_ExpInvoice
            
            Return _TB_ExpRecivedItems
		End Function

		Public Function GetTB_ExpRecivedItems(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ExpRecivedItems
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_ExpRecivedItems", relations), ds, false)
			
			Dim TB_ExpRecivedItemsRow As DataRow = GetRow(ds, "TB_ExpRecivedItems")
			
			If TB_ExpRecivedItemsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ExpRecivedItems(Me, TB_ExpRecivedItemsRow)
			
		End Function


		Public Function GetTB_ExpRecivedItemsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_ExpRecivedItems
		
			Dim TB_ExpRecivedItemsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_ExpRecivedItems").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_ExpRecivedItemsRow = dr
					Exit For
				End If
			Next

			If TB_ExpRecivedItemsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ExpRecivedItems(Me, TB_ExpRecivedItemsRow)
			
		End Function
		Public Function GetTB_ExpRecivedItemsCollection() As ShippingBiz.TB_ExpRecivedItemsCollection
			Return GetTB_ExpRecivedItemsCollection(FetchPath.TB_ExpRecivedItems)
		End Function

		Public Function GetTB_ExpRecivedItemsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ExpRecivedItemsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_ExpRecivedItems", relations), ds, true)
			
			Dim TB_ExpRecivedItemsList() As DataRow = GetRows(ds, "TB_ExpRecivedItems")

			If TB_ExpRecivedItemsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_ExpRecivedItemsCollection = New ShippingBiz.TB_ExpRecivedItemsCollection()

			Dim dr As DataRow
			For Each dr In TB_ExpRecivedItemsList
				a.Add(New ShippingBiz.TB_ExpRecivedItems(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_ExpRecivedItemsCollectionFromDataSet() As ShippingBiz.TB_ExpRecivedItemsCollection
			Dim TB_ExpRecivedItemsList() As DataRow = GetRows(DataSet, "TB_ExpRecivedItems")
			Dim a As New ShippingBiz.TB_ExpRecivedItemsCollection()
			Dim dr As DataRow

			For Each dr In TB_ExpRecivedItemsList
				a.Add(New ShippingBiz.TB_ExpRecivedItems(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_FaxActions(DocumentCode As System.String) As ShippingBiz.TB_FaxActions
			Dim dr As DataRow = DataSet.Tables("TB_FaxActions").NewRow()
			DataSet.Tables("TB_FaxActions").Rows.Add(dr)
            Dim _TB_FaxActions As New ShippingBiz.TB_FaxActions(Me, dr)
            
			_TB_FaxActions.DocumentCode = DocumentCode
            
            Return _TB_FaxActions
		End Function

		Public Function GetTB_FaxActions(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_FaxActions
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_FaxActions", relations), ds, false)
			
			Dim TB_FaxActionsRow As DataRow = GetRow(ds, "TB_FaxActions")
			
			If TB_FaxActionsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_FaxActions(Me, TB_FaxActionsRow)
			
		End Function


		Public Function GetTB_FaxActionsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_FaxActions
		
			Dim TB_FaxActionsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_FaxActions").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_FaxActionsRow = dr
					Exit For
				End If
			Next

			If TB_FaxActionsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_FaxActions(Me, TB_FaxActionsRow)
			
		End Function
		Public Function GetTB_FaxActionsCollection() As ShippingBiz.TB_FaxActionsCollection
			Return GetTB_FaxActionsCollection(FetchPath.TB_FaxActions)
		End Function

		Public Function GetTB_FaxActionsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_FaxActionsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_FaxActions", relations), ds, true)
			
			Dim TB_FaxActionsList() As DataRow = GetRows(ds, "TB_FaxActions")

			If TB_FaxActionsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_FaxActionsCollection = New ShippingBiz.TB_FaxActionsCollection()

			Dim dr As DataRow
			For Each dr In TB_FaxActionsList
				a.Add(New ShippingBiz.TB_FaxActions(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_FaxActionsCollectionFromDataSet() As ShippingBiz.TB_FaxActionsCollection
			Dim TB_FaxActionsList() As DataRow = GetRows(DataSet, "TB_FaxActions")
			Dim a As New ShippingBiz.TB_FaxActionsCollection()
			Dim dr As DataRow

			For Each dr In TB_FaxActionsList
				a.Add(New ShippingBiz.TB_FaxActions(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_FaxStatus() As ShippingBiz.TB_FaxStatus
			Dim dr As DataRow = DataSet.Tables("TB_FaxStatus").NewRow()
			DataSet.Tables("TB_FaxStatus").Rows.Add(dr)
            Dim _TB_FaxStatus As New ShippingBiz.TB_FaxStatus(Me, dr)
            

            
            Return _TB_FaxStatus
		End Function

		Public Function GetTB_FaxStatus(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_FaxStatus
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_FaxStatus", relations), ds, false)
			
			Dim TB_FaxStatusRow As DataRow = GetRow(ds, "TB_FaxStatus")
			
			If TB_FaxStatusRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_FaxStatus(Me, TB_FaxStatusRow)
			
		End Function


		Public Function GetTB_FaxStatusFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_FaxStatus
		
			Dim TB_FaxStatusRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_FaxStatus").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_FaxStatusRow = dr
					Exit For
				End If
			Next

			If TB_FaxStatusRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_FaxStatus(Me, TB_FaxStatusRow)
			
		End Function
		Public Function GetTB_FaxStatusCollection() As ShippingBiz.TB_FaxStatusCollection
			Return GetTB_FaxStatusCollection(FetchPath.TB_FaxStatus)
		End Function

		Public Function GetTB_FaxStatusCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_FaxStatusCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_FaxStatus", relations), ds, true)
			
			Dim TB_FaxStatusList() As DataRow = GetRows(ds, "TB_FaxStatus")

			If TB_FaxStatusList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_FaxStatusCollection = New ShippingBiz.TB_FaxStatusCollection()

			Dim dr As DataRow
			For Each dr In TB_FaxStatusList
				a.Add(New ShippingBiz.TB_FaxStatus(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_FaxStatusCollectionFromDataSet() As ShippingBiz.TB_FaxStatusCollection
			Dim TB_FaxStatusList() As DataRow = GetRows(DataSet, "TB_FaxStatus")
			Dim a As New ShippingBiz.TB_FaxStatusCollection()
			Dim dr As DataRow

			For Each dr In TB_FaxStatusList
				a.Add(New ShippingBiz.TB_FaxStatus(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Inquery(ClinetID As System.Guid, _
			InqueryDate As System.Data.SqlTypes.SqlDateTime, _
			InqueryValidity As System.Data.SqlTypes.SqlDateTime, _
			PrincipalReference As System.String, _
			POL As System.String, _
			POD As System.String) As ShippingBiz.TB_Inquery
			Dim dr As DataRow = DataSet.Tables("TB_Inquery").NewRow()
			DataSet.Tables("TB_Inquery").Rows.Add(dr)
            Dim _TB_Inquery As New ShippingBiz.TB_Inquery(Me, dr)
            
			_TB_Inquery.ClinetID = ClinetID
			_TB_Inquery.InqueryDate = InqueryDate
			_TB_Inquery.InqueryValidity = InqueryValidity
			_TB_Inquery.PrincipalReference = PrincipalReference
			_TB_Inquery.POL = POL
			_TB_Inquery.POD = POD
            
            Return _TB_Inquery
		End Function

		Public Function GetTB_Inquery(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Inquery
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Inquery", relations), ds, false)
			
			Dim TB_InqueryRow As DataRow = GetRow(ds, "TB_Inquery")
			
			If TB_InqueryRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Inquery(Me, TB_InqueryRow)
			
		End Function


		Public Function GetTB_InqueryFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Inquery
		
			Dim TB_InqueryRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Inquery").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_InqueryRow = dr
					Exit For
				End If
			Next

			If TB_InqueryRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Inquery(Me, TB_InqueryRow)
			
		End Function
		Public Function GetTB_InqueryCollection() As ShippingBiz.TB_InqueryCollection
			Return GetTB_InqueryCollection(FetchPath.TB_Inquery)
		End Function

		Public Function GetTB_InqueryCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InqueryCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Inquery", relations), ds, true)
			
			Dim TB_InqueryList() As DataRow = GetRows(ds, "TB_Inquery")

			If TB_InqueryList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_InqueryCollection = New ShippingBiz.TB_InqueryCollection()

			Dim dr As DataRow
			For Each dr In TB_InqueryList
				a.Add(New ShippingBiz.TB_Inquery(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_InqueryCollectionFromDataSet() As ShippingBiz.TB_InqueryCollection
			Dim TB_InqueryList() As DataRow = GetRows(DataSet, "TB_Inquery")
			Dim a As New ShippingBiz.TB_InqueryCollection()
			Dim dr As DataRow

			For Each dr In TB_InqueryList
				a.Add(New ShippingBiz.TB_Inquery(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_InqueryDetails(CnSize As System.String, _
			CnType As System.String, _
			IsDG As System.Data.SqlTypes.SqlBoolean, _
			Amount As System.Data.SqlTypes.SqlDecimal, _
			ByRef parentTB_Inquery As ShippingBiz.TB_Inquery) As ShippingBiz.TB_InqueryDetails
			Dim dr As DataRow = DataSet.Tables("TB_InqueryDetails").NewRow()
			DataSet.Tables("TB_InqueryDetails").Rows.Add(dr)
            Dim _TB_InqueryDetails As New ShippingBiz.TB_InqueryDetails(Me, dr)
            
			_TB_InqueryDetails.CnSize = CnSize
			_TB_InqueryDetails.CnType = CnType
			_TB_InqueryDetails.IsDG = IsDG
			_TB_InqueryDetails.Amount = Amount
			_TB_InqueryDetails.TB_Inquery = parentTB_Inquery
            
            Return _TB_InqueryDetails
		End Function

		Public Function GetTB_InqueryDetails(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InqueryDetails
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_InqueryDetails", relations), ds, false)
			
			Dim TB_InqueryDetailsRow As DataRow = GetRow(ds, "TB_InqueryDetails")
			
			If TB_InqueryDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InqueryDetails(Me, TB_InqueryDetailsRow)
			
		End Function


		Public Function GetTB_InqueryDetailsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_InqueryDetails
		
			Dim TB_InqueryDetailsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_InqueryDetails").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_InqueryDetailsRow = dr
					Exit For
				End If
			Next

			If TB_InqueryDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InqueryDetails(Me, TB_InqueryDetailsRow)
			
		End Function
		Public Function GetTB_InqueryDetailsCollection() As ShippingBiz.TB_InqueryDetailsCollection
			Return GetTB_InqueryDetailsCollection(FetchPath.TB_InqueryDetails)
		End Function

		Public Function GetTB_InqueryDetailsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InqueryDetailsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_InqueryDetails", relations), ds, true)
			
			Dim TB_InqueryDetailsList() As DataRow = GetRows(ds, "TB_InqueryDetails")

			If TB_InqueryDetailsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_InqueryDetailsCollection = New ShippingBiz.TB_InqueryDetailsCollection()

			Dim dr As DataRow
			For Each dr In TB_InqueryDetailsList
				a.Add(New ShippingBiz.TB_InqueryDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_InqueryDetailsCollectionFromDataSet() As ShippingBiz.TB_InqueryDetailsCollection
			Dim TB_InqueryDetailsList() As DataRow = GetRows(DataSet, "TB_InqueryDetails")
			Dim a As New ShippingBiz.TB_InqueryDetailsCollection()
			Dim dr As DataRow

			For Each dr In TB_InqueryDetailsList
				a.Add(New ShippingBiz.TB_InqueryDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Invoice(Description As System.String, _
			ByRef parentTB_InwardBLS As ShippingBiz.TB_InwardBLS) As ShippingBiz.TB_Invoice
			Dim dr As DataRow = DataSet.Tables("TB_Invoice").NewRow()
			DataSet.Tables("TB_Invoice").Rows.Add(dr)
            Dim _TB_Invoice As New ShippingBiz.TB_Invoice(Me, dr)
            
			_TB_Invoice.Description = Description
			_TB_Invoice.TB_InwardBLS = parentTB_InwardBLS
            
            Return _TB_Invoice
		End Function

		Public Function GetTB_Invoice(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Invoice
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Invoice", relations), ds, false)
			
			Dim TB_InvoiceRow As DataRow = GetRow(ds, "TB_Invoice")
			
			If TB_InvoiceRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Invoice(Me, TB_InvoiceRow)
			
		End Function


		Public Function GetTB_InvoiceFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Invoice
		
			Dim TB_InvoiceRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Invoice").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_InvoiceRow = dr
					Exit For
				End If
			Next

			If TB_InvoiceRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Invoice(Me, TB_InvoiceRow)
			
		End Function
		Public Function GetTB_InvoiceCollection() As ShippingBiz.TB_InvoiceCollection
			Return GetTB_InvoiceCollection(FetchPath.TB_Invoice)
		End Function

		Public Function GetTB_InvoiceCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InvoiceCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Invoice", relations), ds, true)
			
			Dim TB_InvoiceList() As DataRow = GetRows(ds, "TB_Invoice")

			If TB_InvoiceList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_InvoiceCollection = New ShippingBiz.TB_InvoiceCollection()

			Dim dr As DataRow
			For Each dr In TB_InvoiceList
				a.Add(New ShippingBiz.TB_Invoice(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_InvoiceCollectionFromDataSet() As ShippingBiz.TB_InvoiceCollection
			Dim TB_InvoiceList() As DataRow = GetRows(DataSet, "TB_Invoice")
			Dim a As New ShippingBiz.TB_InvoiceCollection()
			Dim dr As DataRow

			For Each dr In TB_InvoiceList
				a.Add(New ShippingBiz.TB_Invoice(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_InvoiceDetails(Seq As System.Data.SqlTypes.SqlInt16, _
			ChargesCode As System.String, _
			Remarks As System.String, _
			Currency As System.String, _
			Amount As System.Data.SqlTypes.SqlDouble, _
			IRRAmount As System.Data.SqlTypes.SqlDouble, _
			ByRef parentTB_Invoice As ShippingBiz.TB_Invoice) As ShippingBiz.TB_InvoiceDetails
			Dim dr As DataRow = DataSet.Tables("TB_InvoiceDetails").NewRow()
			DataSet.Tables("TB_InvoiceDetails").Rows.Add(dr)
            Dim _TB_InvoiceDetails As New ShippingBiz.TB_InvoiceDetails(Me, dr)
            
			_TB_InvoiceDetails.Seq = Seq
			_TB_InvoiceDetails.ChargesCode = ChargesCode
			_TB_InvoiceDetails.Remarks = Remarks
			_TB_InvoiceDetails.Currency = Currency
			_TB_InvoiceDetails.Amount = Amount
			_TB_InvoiceDetails.IRRAmount = IRRAmount
			_TB_InvoiceDetails.TB_Invoice = parentTB_Invoice
            
            Return _TB_InvoiceDetails
		End Function

		Public Function GetTB_InvoiceDetails(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InvoiceDetails
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_InvoiceDetails", relations), ds, false)
			
			Dim TB_InvoiceDetailsRow As DataRow = GetRow(ds, "TB_InvoiceDetails")
			
			If TB_InvoiceDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InvoiceDetails(Me, TB_InvoiceDetailsRow)
			
		End Function


		Public Function GetTB_InvoiceDetailsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_InvoiceDetails
		
			Dim TB_InvoiceDetailsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_InvoiceDetails").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_InvoiceDetailsRow = dr
					Exit For
				End If
			Next

			If TB_InvoiceDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InvoiceDetails(Me, TB_InvoiceDetailsRow)
			
		End Function
		Public Function GetTB_InvoiceDetailsCollection() As ShippingBiz.TB_InvoiceDetailsCollection
			Return GetTB_InvoiceDetailsCollection(FetchPath.TB_InvoiceDetails)
		End Function

		Public Function GetTB_InvoiceDetailsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InvoiceDetailsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_InvoiceDetails", relations), ds, true)
			
			Dim TB_InvoiceDetailsList() As DataRow = GetRows(ds, "TB_InvoiceDetails")

			If TB_InvoiceDetailsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_InvoiceDetailsCollection = New ShippingBiz.TB_InvoiceDetailsCollection()

			Dim dr As DataRow
			For Each dr In TB_InvoiceDetailsList
				a.Add(New ShippingBiz.TB_InvoiceDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_InvoiceDetailsCollectionFromDataSet() As ShippingBiz.TB_InvoiceDetailsCollection
			Dim TB_InvoiceDetailsList() As DataRow = GetRows(DataSet, "TB_InvoiceDetails")
			Dim a As New ShippingBiz.TB_InvoiceDetailsCollection()
			Dim dr As DataRow

			For Each dr In TB_InvoiceDetailsList
				a.Add(New ShippingBiz.TB_InvoiceDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_InwardBLS(Service As System.String, _
			Line As System.String, _
			BlNo As System.String, _
			POL As System.String, _
			POD As System.String, _
			TermsOfPayment As System.String) As ShippingBiz.TB_InwardBLS
			Dim dr As DataRow = DataSet.Tables("TB_InwardBLS").NewRow()
			DataSet.Tables("TB_InwardBLS").Rows.Add(dr)
            Dim _TB_InwardBLS As New ShippingBiz.TB_InwardBLS(Me, dr)
            
			_TB_InwardBLS.Service = Service
			_TB_InwardBLS.Line = Line
			_TB_InwardBLS.BlNo = BlNo
			_TB_InwardBLS.POL = POL
			_TB_InwardBLS.POD = POD
			_TB_InwardBLS.TermsOfPayment = TermsOfPayment
            
            Return _TB_InwardBLS
		End Function

		Public Function GetTB_InwardBLS(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardBLS
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_InwardBLS", relations), ds, false)
			
			Dim TB_InwardBLSRow As DataRow = GetRow(ds, "TB_InwardBLS")
			
			If TB_InwardBLSRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardBLS(Me, TB_InwardBLSRow)
			
		End Function


		Public Function GetTB_InwardBLSFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_InwardBLS
		
			Dim TB_InwardBLSRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_InwardBLS").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_InwardBLSRow = dr
					Exit For
				End If
			Next

			If TB_InwardBLSRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardBLS(Me, TB_InwardBLSRow)
			
		End Function
		Public Function GetTB_InwardBLSCollection() As ShippingBiz.TB_InwardBLSCollection
			Return GetTB_InwardBLSCollection(FetchPath.TB_InwardBLS)
		End Function

		Public Function GetTB_InwardBLSCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardBLSCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_InwardBLS", relations), ds, true)
			
			Dim TB_InwardBLSList() As DataRow = GetRows(ds, "TB_InwardBLS")

			If TB_InwardBLSList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_InwardBLSCollection = New ShippingBiz.TB_InwardBLSCollection()

			Dim dr As DataRow
			For Each dr In TB_InwardBLSList
				a.Add(New ShippingBiz.TB_InwardBLS(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_InwardBLSCollectionFromDataSet() As ShippingBiz.TB_InwardBLSCollection
			Dim TB_InwardBLSList() As DataRow = GetRows(DataSet, "TB_InwardBLS")
			Dim a As New ShippingBiz.TB_InwardBLSCollection()
			Dim dr As DataRow

			For Each dr In TB_InwardBLSList
				a.Add(New ShippingBiz.TB_InwardBLS(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_InwardBlsComments(CommentType As System.String, _
			Comment As System.String, _
			ByRef parentTB_InwardBLS As ShippingBiz.TB_InwardBLS) As ShippingBiz.TB_InwardBlsComments
			Dim dr As DataRow = DataSet.Tables("TB_InwardBlsComments").NewRow()
			DataSet.Tables("TB_InwardBlsComments").Rows.Add(dr)
            Dim _TB_InwardBlsComments As New ShippingBiz.TB_InwardBlsComments(Me, dr)
            
			_TB_InwardBlsComments.CommentType = CommentType
			_TB_InwardBlsComments.Comment = Comment
			_TB_InwardBlsComments.TB_InwardBLS = parentTB_InwardBLS
            
            Return _TB_InwardBlsComments
		End Function

		Public Function GetTB_InwardBlsComments(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardBlsComments
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_InwardBlsComments", relations), ds, false)
			
			Dim TB_InwardBlsCommentsRow As DataRow = GetRow(ds, "TB_InwardBlsComments")
			
			If TB_InwardBlsCommentsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardBlsComments(Me, TB_InwardBlsCommentsRow)
			
		End Function


		Public Function GetTB_InwardBlsCommentsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_InwardBlsComments
		
			Dim TB_InwardBlsCommentsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_InwardBlsComments").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_InwardBlsCommentsRow = dr
					Exit For
				End If
			Next

			If TB_InwardBlsCommentsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardBlsComments(Me, TB_InwardBlsCommentsRow)
			
		End Function
		Public Function GetTB_InwardBlsCommentsCollection() As ShippingBiz.TB_InwardBlsCommentsCollection
			Return GetTB_InwardBlsCommentsCollection(FetchPath.TB_InwardBlsComments)
		End Function

		Public Function GetTB_InwardBlsCommentsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardBlsCommentsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_InwardBlsComments", relations), ds, true)
			
			Dim TB_InwardBlsCommentsList() As DataRow = GetRows(ds, "TB_InwardBlsComments")

			If TB_InwardBlsCommentsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_InwardBlsCommentsCollection = New ShippingBiz.TB_InwardBlsCommentsCollection()

			Dim dr As DataRow
			For Each dr In TB_InwardBlsCommentsList
				a.Add(New ShippingBiz.TB_InwardBlsComments(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_InwardBlsCommentsCollectionFromDataSet() As ShippingBiz.TB_InwardBlsCommentsCollection
			Dim TB_InwardBlsCommentsList() As DataRow = GetRows(DataSet, "TB_InwardBlsComments")
			Dim a As New ShippingBiz.TB_InwardBlsCommentsCollection()
			Dim dr As DataRow

			For Each dr In TB_InwardBlsCommentsList
				a.Add(New ShippingBiz.TB_InwardBlsComments(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTb_InwardBlsFrs(ByRef parentTB_InwardBLS As ShippingBiz.TB_InwardBLS) As ShippingBiz.Tb_InwardBlsFrs
			Dim dr As DataRow = DataSet.Tables("Tb_InwardBlsFrs").NewRow()
			DataSet.Tables("Tb_InwardBlsFrs").Rows.Add(dr)
            Dim _Tb_InwardBlsFrs As New ShippingBiz.Tb_InwardBlsFrs(Me, dr)
            
			_Tb_InwardBlsFrs.TB_InwardBLS = parentTB_InwardBLS
            
            Return _Tb_InwardBlsFrs
		End Function

		Public Function GetTb_InwardBlsFrs(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.Tb_InwardBlsFrs
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("Tb_InwardBlsFrs", relations), ds, false)
			
			Dim Tb_InwardBlsFrsRow As DataRow = GetRow(ds, "Tb_InwardBlsFrs")
			
			If Tb_InwardBlsFrsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.Tb_InwardBlsFrs(Me, Tb_InwardBlsFrsRow)
			
		End Function


		Public Function GetTb_InwardBlsFrsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.Tb_InwardBlsFrs
		
			Dim Tb_InwardBlsFrsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("Tb_InwardBlsFrs").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					Tb_InwardBlsFrsRow = dr
					Exit For
				End If
			Next

			If Tb_InwardBlsFrsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.Tb_InwardBlsFrs(Me, Tb_InwardBlsFrsRow)
			
		End Function
		Public Function GetTb_InwardBlsFrsCollection() As ShippingBiz.Tb_InwardBlsFrsCollection
			Return GetTb_InwardBlsFrsCollection(FetchPath.Tb_InwardBlsFrs)
		End Function

		Public Function GetTb_InwardBlsFrsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.Tb_InwardBlsFrsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("Tb_InwardBlsFrs", relations), ds, true)
			
			Dim Tb_InwardBlsFrsList() As DataRow = GetRows(ds, "Tb_InwardBlsFrs")

			If Tb_InwardBlsFrsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.Tb_InwardBlsFrsCollection = New ShippingBiz.Tb_InwardBlsFrsCollection()

			Dim dr As DataRow
			For Each dr In Tb_InwardBlsFrsList
				a.Add(New ShippingBiz.Tb_InwardBlsFrs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTb_InwardBlsFrsCollectionFromDataSet() As ShippingBiz.Tb_InwardBlsFrsCollection
			Dim Tb_InwardBlsFrsList() As DataRow = GetRows(DataSet, "Tb_InwardBlsFrs")
			Dim a As New ShippingBiz.Tb_InwardBlsFrsCollection()
			Dim dr As DataRow

			For Each dr In Tb_InwardBlsFrsList
				a.Add(New ShippingBiz.Tb_InwardBlsFrs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_InwardBlsGoods(ByRef parentTB_InwardBLS As ShippingBiz.TB_InwardBLS) As ShippingBiz.TB_InwardBlsGoods
			Dim dr As DataRow = DataSet.Tables("TB_InwardBlsGoods").NewRow()
			DataSet.Tables("TB_InwardBlsGoods").Rows.Add(dr)
            Dim _TB_InwardBlsGoods As New ShippingBiz.TB_InwardBlsGoods(Me, dr)
            
			_TB_InwardBlsGoods.TB_InwardBLS = parentTB_InwardBLS
            
            Return _TB_InwardBlsGoods
		End Function

		Public Function GetTB_InwardBlsGoods(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardBlsGoods
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_InwardBlsGoods", relations), ds, false)
			
			Dim TB_InwardBlsGoodsRow As DataRow = GetRow(ds, "TB_InwardBlsGoods")
			
			If TB_InwardBlsGoodsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardBlsGoods(Me, TB_InwardBlsGoodsRow)
			
		End Function


		Public Function GetTB_InwardBlsGoodsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_InwardBlsGoods
		
			Dim TB_InwardBlsGoodsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_InwardBlsGoods").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_InwardBlsGoodsRow = dr
					Exit For
				End If
			Next

			If TB_InwardBlsGoodsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardBlsGoods(Me, TB_InwardBlsGoodsRow)
			
		End Function
		Public Function GetTB_InwardBlsGoodsCollection() As ShippingBiz.TB_InwardBlsGoodsCollection
			Return GetTB_InwardBlsGoodsCollection(FetchPath.TB_InwardBlsGoods)
		End Function

		Public Function GetTB_InwardBlsGoodsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardBlsGoodsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_InwardBlsGoods", relations), ds, true)
			
			Dim TB_InwardBlsGoodsList() As DataRow = GetRows(ds, "TB_InwardBlsGoods")

			If TB_InwardBlsGoodsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_InwardBlsGoodsCollection = New ShippingBiz.TB_InwardBlsGoodsCollection()

			Dim dr As DataRow
			For Each dr In TB_InwardBlsGoodsList
				a.Add(New ShippingBiz.TB_InwardBlsGoods(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_InwardBlsGoodsCollectionFromDataSet() As ShippingBiz.TB_InwardBlsGoodsCollection
			Dim TB_InwardBlsGoodsList() As DataRow = GetRows(DataSet, "TB_InwardBlsGoods")
			Dim a As New ShippingBiz.TB_InwardBlsGoodsCollection()
			Dim dr As DataRow

			For Each dr In TB_InwardBlsGoodsList
				a.Add(New ShippingBiz.TB_InwardBlsGoods(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_InwardBlsNames(ByRef parentTB_InwardBLS As ShippingBiz.TB_InwardBLS) As ShippingBiz.TB_InwardBlsNames
			Dim dr As DataRow = DataSet.Tables("TB_InwardBlsNames").NewRow()
			DataSet.Tables("TB_InwardBlsNames").Rows.Add(dr)
            Dim _TB_InwardBlsNames As New ShippingBiz.TB_InwardBlsNames(Me, dr)
            
			_TB_InwardBlsNames.TB_InwardBLS = parentTB_InwardBLS
            
            Return _TB_InwardBlsNames
		End Function

		Public Function GetTB_InwardBlsNames(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardBlsNames
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_InwardBlsNames", relations), ds, false)
			
			Dim TB_InwardBlsNamesRow As DataRow = GetRow(ds, "TB_InwardBlsNames")
			
			If TB_InwardBlsNamesRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardBlsNames(Me, TB_InwardBlsNamesRow)
			
		End Function


		Public Function GetTB_InwardBlsNamesFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_InwardBlsNames
		
			Dim TB_InwardBlsNamesRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_InwardBlsNames").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_InwardBlsNamesRow = dr
					Exit For
				End If
			Next

			If TB_InwardBlsNamesRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardBlsNames(Me, TB_InwardBlsNamesRow)
			
		End Function
		Public Function GetTB_InwardBlsNamesCollection() As ShippingBiz.TB_InwardBlsNamesCollection
			Return GetTB_InwardBlsNamesCollection(FetchPath.TB_InwardBlsNames)
		End Function

		Public Function GetTB_InwardBlsNamesCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardBlsNamesCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_InwardBlsNames", relations), ds, true)
			
			Dim TB_InwardBlsNamesList() As DataRow = GetRows(ds, "TB_InwardBlsNames")

			If TB_InwardBlsNamesList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_InwardBlsNamesCollection = New ShippingBiz.TB_InwardBlsNamesCollection()

			Dim dr As DataRow
			For Each dr In TB_InwardBlsNamesList
				a.Add(New ShippingBiz.TB_InwardBlsNames(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_InwardBlsNamesCollectionFromDataSet() As ShippingBiz.TB_InwardBlsNamesCollection
			Dim TB_InwardBlsNamesList() As DataRow = GetRows(DataSet, "TB_InwardBlsNames")
			Dim a As New ShippingBiz.TB_InwardBlsNamesCollection()
			Dim dr As DataRow

			For Each dr In TB_InwardBlsNamesList
				a.Add(New ShippingBiz.TB_InwardBlsNames(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_InwardCharges(Seq As System.Data.SqlTypes.SqlInt16, _
			ChargesCode As System.String, _
			Currency As System.String, _
			Qty As System.Data.SqlTypes.SqlInt16, _
			Rate As System.Data.SqlTypes.SqlDouble, _
			Amount As System.Data.SqlTypes.SqlDouble, _
			PayAt As System.String, _
			ByRef parentTB_InwardBLS As ShippingBiz.TB_InwardBLS) As ShippingBiz.TB_InwardCharges
			Dim dr As DataRow = DataSet.Tables("TB_InwardCharges").NewRow()
			DataSet.Tables("TB_InwardCharges").Rows.Add(dr)
            Dim _TB_InwardCharges As New ShippingBiz.TB_InwardCharges(Me, dr)
            
			_TB_InwardCharges.Seq = Seq
			_TB_InwardCharges.ChargesCode = ChargesCode
			_TB_InwardCharges.Currency = Currency
			_TB_InwardCharges.Qty = Qty
			_TB_InwardCharges.Rate = Rate
			_TB_InwardCharges.Amount = Amount
			_TB_InwardCharges.PayAt = PayAt
			_TB_InwardCharges.TB_InwardBLS = parentTB_InwardBLS
            
            Return _TB_InwardCharges
		End Function

		Public Function GetTB_InwardCharges(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardCharges
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_InwardCharges", relations), ds, false)
			
			Dim TB_InwardChargesRow As DataRow = GetRow(ds, "TB_InwardCharges")
			
			If TB_InwardChargesRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardCharges(Me, TB_InwardChargesRow)
			
		End Function


		Public Function GetTB_InwardChargesFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_InwardCharges
		
			Dim TB_InwardChargesRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_InwardCharges").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_InwardChargesRow = dr
					Exit For
				End If
			Next

			If TB_InwardChargesRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardCharges(Me, TB_InwardChargesRow)
			
		End Function
		Public Function GetTB_InwardChargesCollection() As ShippingBiz.TB_InwardChargesCollection
			Return GetTB_InwardChargesCollection(FetchPath.TB_InwardCharges)
		End Function

		Public Function GetTB_InwardChargesCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardChargesCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_InwardCharges", relations), ds, true)
			
			Dim TB_InwardChargesList() As DataRow = GetRows(ds, "TB_InwardCharges")

			If TB_InwardChargesList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_InwardChargesCollection = New ShippingBiz.TB_InwardChargesCollection()

			Dim dr As DataRow
			For Each dr In TB_InwardChargesList
				a.Add(New ShippingBiz.TB_InwardCharges(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_InwardChargesCollectionFromDataSet() As ShippingBiz.TB_InwardChargesCollection
			Dim TB_InwardChargesList() As DataRow = GetRows(DataSet, "TB_InwardCharges")
			Dim a As New ShippingBiz.TB_InwardChargesCollection()
			Dim dr As DataRow

			For Each dr In TB_InwardChargesList
				a.Add(New ShippingBiz.TB_InwardCharges(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_InwardCnsImco(ByRef parentTB_InwardCntrs As ShippingBiz.TB_InwardCntrs) As ShippingBiz.TB_InwardCnsImco
			Dim dr As DataRow = DataSet.Tables("TB_InwardCnsImco").NewRow()
			DataSet.Tables("TB_InwardCnsImco").Rows.Add(dr)
            Dim _TB_InwardCnsImco As New ShippingBiz.TB_InwardCnsImco(Me, dr)
            
			_TB_InwardCnsImco.TB_InwardCntrs = parentTB_InwardCntrs
            
            Return _TB_InwardCnsImco
		End Function

		Public Function GetTB_InwardCnsImco(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardCnsImco
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_InwardCnsImco", relations), ds, false)
			
			Dim TB_InwardCnsImcoRow As DataRow = GetRow(ds, "TB_InwardCnsImco")
			
			If TB_InwardCnsImcoRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardCnsImco(Me, TB_InwardCnsImcoRow)
			
		End Function


		Public Function GetTB_InwardCnsImcoFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_InwardCnsImco
		
			Dim TB_InwardCnsImcoRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_InwardCnsImco").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_InwardCnsImcoRow = dr
					Exit For
				End If
			Next

			If TB_InwardCnsImcoRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardCnsImco(Me, TB_InwardCnsImcoRow)
			
		End Function
		Public Function GetTB_InwardCnsImcoCollection() As ShippingBiz.TB_InwardCnsImcoCollection
			Return GetTB_InwardCnsImcoCollection(FetchPath.TB_InwardCnsImco)
		End Function

		Public Function GetTB_InwardCnsImcoCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardCnsImcoCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_InwardCnsImco", relations), ds, true)
			
			Dim TB_InwardCnsImcoList() As DataRow = GetRows(ds, "TB_InwardCnsImco")

			If TB_InwardCnsImcoList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_InwardCnsImcoCollection = New ShippingBiz.TB_InwardCnsImcoCollection()

			Dim dr As DataRow
			For Each dr In TB_InwardCnsImcoList
				a.Add(New ShippingBiz.TB_InwardCnsImco(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_InwardCnsImcoCollectionFromDataSet() As ShippingBiz.TB_InwardCnsImcoCollection
			Dim TB_InwardCnsImcoList() As DataRow = GetRows(DataSet, "TB_InwardCnsImco")
			Dim a As New ShippingBiz.TB_InwardCnsImcoCollection()
			Dim dr As DataRow

			For Each dr In TB_InwardCnsImcoList
				a.Add(New ShippingBiz.TB_InwardCnsImco(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_InwardCnsPkgs(PackageType As System.String, _
			NoOFPkgs As System.Data.SqlTypes.SqlInt64, _
			ByRef parentTB_InwardCntrs As ShippingBiz.TB_InwardCntrs) As ShippingBiz.TB_InwardCnsPkgs
			Dim dr As DataRow = DataSet.Tables("TB_InwardCnsPkgs").NewRow()
			DataSet.Tables("TB_InwardCnsPkgs").Rows.Add(dr)
            Dim _TB_InwardCnsPkgs As New ShippingBiz.TB_InwardCnsPkgs(Me, dr)
            
			_TB_InwardCnsPkgs.PackageType = PackageType
			_TB_InwardCnsPkgs.NoOFPkgs = NoOFPkgs
			_TB_InwardCnsPkgs.TB_InwardCntrs = parentTB_InwardCntrs
            
            Return _TB_InwardCnsPkgs
		End Function

		Public Function GetTB_InwardCnsPkgs(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardCnsPkgs
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_InwardCnsPkgs", relations), ds, false)
			
			Dim TB_InwardCnsPkgsRow As DataRow = GetRow(ds, "TB_InwardCnsPkgs")
			
			If TB_InwardCnsPkgsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardCnsPkgs(Me, TB_InwardCnsPkgsRow)
			
		End Function


		Public Function GetTB_InwardCnsPkgsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_InwardCnsPkgs
		
			Dim TB_InwardCnsPkgsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_InwardCnsPkgs").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_InwardCnsPkgsRow = dr
					Exit For
				End If
			Next

			If TB_InwardCnsPkgsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardCnsPkgs(Me, TB_InwardCnsPkgsRow)
			
		End Function
		Public Function GetTB_InwardCnsPkgsCollection() As ShippingBiz.TB_InwardCnsPkgsCollection
			Return GetTB_InwardCnsPkgsCollection(FetchPath.TB_InwardCnsPkgs)
		End Function

		Public Function GetTB_InwardCnsPkgsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardCnsPkgsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_InwardCnsPkgs", relations), ds, true)
			
			Dim TB_InwardCnsPkgsList() As DataRow = GetRows(ds, "TB_InwardCnsPkgs")

			If TB_InwardCnsPkgsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_InwardCnsPkgsCollection = New ShippingBiz.TB_InwardCnsPkgsCollection()

			Dim dr As DataRow
			For Each dr In TB_InwardCnsPkgsList
				a.Add(New ShippingBiz.TB_InwardCnsPkgs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_InwardCnsPkgsCollectionFromDataSet() As ShippingBiz.TB_InwardCnsPkgsCollection
			Dim TB_InwardCnsPkgsList() As DataRow = GetRows(DataSet, "TB_InwardCnsPkgs")
			Dim a As New ShippingBiz.TB_InwardCnsPkgsCollection()
			Dim dr As DataRow

			For Each dr In TB_InwardCnsPkgsList
				a.Add(New ShippingBiz.TB_InwardCnsPkgs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_InwardCnsTemprature(ByRef parentTB_InwardCntrs As ShippingBiz.TB_InwardCntrs) As ShippingBiz.TB_InwardCnsTemprature
			Dim dr As DataRow = DataSet.Tables("TB_InwardCnsTemprature").NewRow()
			DataSet.Tables("TB_InwardCnsTemprature").Rows.Add(dr)
            Dim _TB_InwardCnsTemprature As New ShippingBiz.TB_InwardCnsTemprature(Me, dr)
            
			_TB_InwardCnsTemprature.TB_InwardCntrs = parentTB_InwardCntrs
            
            Return _TB_InwardCnsTemprature
		End Function

		Public Function GetTB_InwardCnsTemprature(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardCnsTemprature
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_InwardCnsTemprature", relations), ds, false)
			
			Dim TB_InwardCnsTempratureRow As DataRow = GetRow(ds, "TB_InwardCnsTemprature")
			
			If TB_InwardCnsTempratureRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardCnsTemprature(Me, TB_InwardCnsTempratureRow)
			
		End Function


		Public Function GetTB_InwardCnsTempratureFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_InwardCnsTemprature
		
			Dim TB_InwardCnsTempratureRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_InwardCnsTemprature").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_InwardCnsTempratureRow = dr
					Exit For
				End If
			Next

			If TB_InwardCnsTempratureRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardCnsTemprature(Me, TB_InwardCnsTempratureRow)
			
		End Function
		Public Function GetTB_InwardCnsTempratureCollection() As ShippingBiz.TB_InwardCnsTempratureCollection
			Return GetTB_InwardCnsTempratureCollection(FetchPath.TB_InwardCnsTemprature)
		End Function

		Public Function GetTB_InwardCnsTempratureCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardCnsTempratureCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_InwardCnsTemprature", relations), ds, true)
			
			Dim TB_InwardCnsTempratureList() As DataRow = GetRows(ds, "TB_InwardCnsTemprature")

			If TB_InwardCnsTempratureList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_InwardCnsTempratureCollection = New ShippingBiz.TB_InwardCnsTempratureCollection()

			Dim dr As DataRow
			For Each dr In TB_InwardCnsTempratureList
				a.Add(New ShippingBiz.TB_InwardCnsTemprature(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_InwardCnsTempratureCollectionFromDataSet() As ShippingBiz.TB_InwardCnsTempratureCollection
			Dim TB_InwardCnsTempratureList() As DataRow = GetRows(DataSet, "TB_InwardCnsTemprature")
			Dim a As New ShippingBiz.TB_InwardCnsTempratureCollection()
			Dim dr As DataRow

			For Each dr In TB_InwardCnsTempratureList
				a.Add(New ShippingBiz.TB_InwardCnsTemprature(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_InwardCntrs(CntrNo As System.String, _
			CnSize As System.String, _
			CnType As System.String, _
			TW As System.Data.SqlTypes.SqlInt64, _
			FLE As System.String, _
			SOC As System.String, _
			ByRef parentTB_InwardBLS As ShippingBiz.TB_InwardBLS) As ShippingBiz.TB_InwardCntrs
			Dim dr As DataRow = DataSet.Tables("TB_InwardCntrs").NewRow()
			DataSet.Tables("TB_InwardCntrs").Rows.Add(dr)
            Dim _TB_InwardCntrs As New ShippingBiz.TB_InwardCntrs(Me, dr)
            
			_TB_InwardCntrs.CntrNo = CntrNo
			_TB_InwardCntrs.CnSize = CnSize
			_TB_InwardCntrs.CnType = CnType
			_TB_InwardCntrs.TW = TW
			_TB_InwardCntrs.FLE = FLE
			_TB_InwardCntrs.SOC = SOC
			_TB_InwardCntrs.TB_InwardBLS = parentTB_InwardBLS
            
            Return _TB_InwardCntrs
		End Function

		Public Function GetTB_InwardCntrs(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardCntrs
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_InwardCntrs", relations), ds, false)
			
			Dim TB_InwardCntrsRow As DataRow = GetRow(ds, "TB_InwardCntrs")
			
			If TB_InwardCntrsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardCntrs(Me, TB_InwardCntrsRow)
			
		End Function


		Public Function GetTB_InwardCntrsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_InwardCntrs
		
			Dim TB_InwardCntrsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_InwardCntrs").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_InwardCntrsRow = dr
					Exit For
				End If
			Next

			If TB_InwardCntrsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardCntrs(Me, TB_InwardCntrsRow)
			
		End Function
		Public Function GetTB_InwardCntrsCollection() As ShippingBiz.TB_InwardCntrsCollection
			Return GetTB_InwardCntrsCollection(FetchPath.TB_InwardCntrs)
		End Function

		Public Function GetTB_InwardCntrsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardCntrsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_InwardCntrs", relations), ds, true)
			
			Dim TB_InwardCntrsList() As DataRow = GetRows(ds, "TB_InwardCntrs")

			If TB_InwardCntrsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_InwardCntrsCollection = New ShippingBiz.TB_InwardCntrsCollection()

			Dim dr As DataRow
			For Each dr In TB_InwardCntrsList
				a.Add(New ShippingBiz.TB_InwardCntrs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_InwardCntrsCollectionFromDataSet() As ShippingBiz.TB_InwardCntrsCollection
			Dim TB_InwardCntrsList() As DataRow = GetRows(DataSet, "TB_InwardCntrs")
			Dim a As New ShippingBiz.TB_InwardCntrsCollection()
			Dim dr As DataRow

			For Each dr In TB_InwardCntrsList
				a.Add(New ShippingBiz.TB_InwardCntrs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_InwardCntrsCharges(ChargesCode As System.String, _
			Currency As System.String, _
			UnitRate As System.Data.SqlTypes.SqlDecimal, _
			Terms As System.String, _
			ByRef parentTB_InwardCntrs As ShippingBiz.TB_InwardCntrs) As ShippingBiz.TB_InwardCntrsCharges
			Dim dr As DataRow = DataSet.Tables("TB_InwardCntrsCharges").NewRow()
			DataSet.Tables("TB_InwardCntrsCharges").Rows.Add(dr)
            Dim _TB_InwardCntrsCharges As New ShippingBiz.TB_InwardCntrsCharges(Me, dr)
            
			_TB_InwardCntrsCharges.ChargesCode = ChargesCode
			_TB_InwardCntrsCharges.Currency = Currency
			_TB_InwardCntrsCharges.UnitRate = UnitRate
			_TB_InwardCntrsCharges.Terms = Terms
			_TB_InwardCntrsCharges.TB_InwardCntrs = parentTB_InwardCntrs
            
            Return _TB_InwardCntrsCharges
		End Function

		Public Function GetTB_InwardCntrsCharges(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardCntrsCharges
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_InwardCntrsCharges", relations), ds, false)
			
			Dim TB_InwardCntrsChargesRow As DataRow = GetRow(ds, "TB_InwardCntrsCharges")
			
			If TB_InwardCntrsChargesRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardCntrsCharges(Me, TB_InwardCntrsChargesRow)
			
		End Function


		Public Function GetTB_InwardCntrsChargesFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_InwardCntrsCharges
		
			Dim TB_InwardCntrsChargesRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_InwardCntrsCharges").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_InwardCntrsChargesRow = dr
					Exit For
				End If
			Next

			If TB_InwardCntrsChargesRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardCntrsCharges(Me, TB_InwardCntrsChargesRow)
			
		End Function
		Public Function GetTB_InwardCntrsChargesCollection() As ShippingBiz.TB_InwardCntrsChargesCollection
			Return GetTB_InwardCntrsChargesCollection(FetchPath.TB_InwardCntrsCharges)
		End Function

		Public Function GetTB_InwardCntrsChargesCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardCntrsChargesCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_InwardCntrsCharges", relations), ds, true)
			
			Dim TB_InwardCntrsChargesList() As DataRow = GetRows(ds, "TB_InwardCntrsCharges")

			If TB_InwardCntrsChargesList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_InwardCntrsChargesCollection = New ShippingBiz.TB_InwardCntrsChargesCollection()

			Dim dr As DataRow
			For Each dr In TB_InwardCntrsChargesList
				a.Add(New ShippingBiz.TB_InwardCntrsCharges(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_InwardCntrsChargesCollectionFromDataSet() As ShippingBiz.TB_InwardCntrsChargesCollection
			Dim TB_InwardCntrsChargesList() As DataRow = GetRows(DataSet, "TB_InwardCntrsCharges")
			Dim a As New ShippingBiz.TB_InwardCntrsChargesCollection()
			Dim dr As DataRow

			For Each dr In TB_InwardCntrsChargesList
				a.Add(New ShippingBiz.TB_InwardCntrsCharges(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_InwardDiscount(ByRef parentTB_InwardBLS As ShippingBiz.TB_InwardBLS) As ShippingBiz.TB_InwardDiscount
			Dim dr As DataRow = DataSet.Tables("TB_InwardDiscount").NewRow()
			DataSet.Tables("TB_InwardDiscount").Rows.Add(dr)
            Dim _TB_InwardDiscount As New ShippingBiz.TB_InwardDiscount(Me, dr)
            
			_TB_InwardDiscount.TB_InwardBLS = parentTB_InwardBLS
            
            Return _TB_InwardDiscount
		End Function

		Public Function GetTB_InwardDiscount(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardDiscount
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_InwardDiscount", relations), ds, false)
			
			Dim TB_InwardDiscountRow As DataRow = GetRow(ds, "TB_InwardDiscount")
			
			If TB_InwardDiscountRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardDiscount(Me, TB_InwardDiscountRow)
			
		End Function


		Public Function GetTB_InwardDiscountFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_InwardDiscount
		
			Dim TB_InwardDiscountRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_InwardDiscount").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_InwardDiscountRow = dr
					Exit For
				End If
			Next

			If TB_InwardDiscountRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardDiscount(Me, TB_InwardDiscountRow)
			
		End Function
		Public Function GetTB_InwardDiscountCollection() As ShippingBiz.TB_InwardDiscountCollection
			Return GetTB_InwardDiscountCollection(FetchPath.TB_InwardDiscount)
		End Function

		Public Function GetTB_InwardDiscountCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardDiscountCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_InwardDiscount", relations), ds, true)
			
			Dim TB_InwardDiscountList() As DataRow = GetRows(ds, "TB_InwardDiscount")

			If TB_InwardDiscountList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_InwardDiscountCollection = New ShippingBiz.TB_InwardDiscountCollection()

			Dim dr As DataRow
			For Each dr In TB_InwardDiscountList
				a.Add(New ShippingBiz.TB_InwardDiscount(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_InwardDiscountCollectionFromDataSet() As ShippingBiz.TB_InwardDiscountCollection
			Dim TB_InwardDiscountList() As DataRow = GetRows(DataSet, "TB_InwardDiscount")
			Dim a As New ShippingBiz.TB_InwardDiscountCollection()
			Dim dr As DataRow

			For Each dr In TB_InwardDiscountList
				a.Add(New ShippingBiz.TB_InwardDiscount(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_InwardStatus(ByRef parentTB_InwardBLS As ShippingBiz.TB_InwardBLS) As ShippingBiz.TB_InwardStatus
			Dim dr As DataRow = DataSet.Tables("TB_InwardStatus").NewRow()
			DataSet.Tables("TB_InwardStatus").Rows.Add(dr)
            Dim _TB_InwardStatus As New ShippingBiz.TB_InwardStatus(Me, dr)
            
			_TB_InwardStatus.TB_InwardBLS = parentTB_InwardBLS
            
            Return _TB_InwardStatus
		End Function

		Public Function GetTB_InwardStatus(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardStatus
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_InwardStatus", relations), ds, false)
			
			Dim TB_InwardStatusRow As DataRow = GetRow(ds, "TB_InwardStatus")
			
			If TB_InwardStatusRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardStatus(Me, TB_InwardStatusRow)
			
		End Function


		Public Function GetTB_InwardStatusFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_InwardStatus
		
			Dim TB_InwardStatusRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_InwardStatus").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_InwardStatusRow = dr
					Exit For
				End If
			Next

			If TB_InwardStatusRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_InwardStatus(Me, TB_InwardStatusRow)
			
		End Function
		Public Function GetTB_InwardStatusCollection() As ShippingBiz.TB_InwardStatusCollection
			Return GetTB_InwardStatusCollection(FetchPath.TB_InwardStatus)
		End Function

		Public Function GetTB_InwardStatusCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_InwardStatusCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_InwardStatus", relations), ds, true)
			
			Dim TB_InwardStatusList() As DataRow = GetRows(ds, "TB_InwardStatus")

			If TB_InwardStatusList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_InwardStatusCollection = New ShippingBiz.TB_InwardStatusCollection()

			Dim dr As DataRow
			For Each dr In TB_InwardStatusList
				a.Add(New ShippingBiz.TB_InwardStatus(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_InwardStatusCollectionFromDataSet() As ShippingBiz.TB_InwardStatusCollection
			Dim TB_InwardStatusList() As DataRow = GetRows(DataSet, "TB_InwardStatus")
			Dim a As New ShippingBiz.TB_InwardStatusCollection()
			Dim dr As DataRow

			For Each dr In TB_InwardStatusList
				a.Add(New ShippingBiz.TB_InwardStatus(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_ISOType(SizeIS As System.Data.SqlTypes.SqlByte, _
			TypeIS As System.Data.SqlTypes.SqlByte, _
			HeightIS As System.Data.SqlTypes.SqlByte, _
			DispName As System.String, _
			ISOValue As System.String, _
			WHLCode As System.String, _
			TareWeight As System.Data.SqlTypes.SqlDecimal, _
			WHLSize As System.String, _
			WHLType As System.String, _
			WHLHeight As System.String, _
			PSOType As System.String, _
			TEU As System.Data.SqlTypes.SqlByte) As ShippingBiz.TB_ISOType
			Dim dr As DataRow = DataSet.Tables("TB_ISOType").NewRow()
			DataSet.Tables("TB_ISOType").Rows.Add(dr)
            Dim _TB_ISOType As New ShippingBiz.TB_ISOType(Me, dr)
            
			_TB_ISOType.SizeIS = SizeIS
			_TB_ISOType.TypeIS = TypeIS
			_TB_ISOType.HeightIS = HeightIS
			_TB_ISOType.DispName = DispName
			_TB_ISOType.ISOValue = ISOValue
			_TB_ISOType.WHLCode = WHLCode
			_TB_ISOType.TareWeight = TareWeight
			_TB_ISOType.WHLSize = WHLSize
			_TB_ISOType.WHLType = WHLType
			_TB_ISOType.WHLHeight = WHLHeight
			_TB_ISOType.PSOType = PSOType
			_TB_ISOType.TEU = TEU
            
            Return _TB_ISOType
		End Function

		Public Function GetTB_ISOType(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ISOType
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_ISOType", relations), ds, false)
			
			Dim TB_ISOTypeRow As DataRow = GetRow(ds, "TB_ISOType")
			
			If TB_ISOTypeRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ISOType(Me, TB_ISOTypeRow)
			
		End Function


		Public Function GetTB_ISOTypeFromDataSet(ByVal ISOTypeID As System.Guid) As ShippingBiz.TB_ISOType
		
			Dim TB_ISOTypeRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_ISOType").Rows
				If (CType(dr("ISOTypeID"), System.Guid)).ToString() = ISOTypeID.ToString() Then
					TB_ISOTypeRow = dr
					Exit For
				End If
			Next

			If TB_ISOTypeRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ISOType(Me, TB_ISOTypeRow)
			
		End Function
		Public Function GetTB_ISOTypeCollection() As ShippingBiz.TB_ISOTypeCollection
			Return GetTB_ISOTypeCollection(FetchPath.TB_ISOType)
		End Function

		Public Function GetTB_ISOTypeCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ISOTypeCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_ISOType", relations), ds, true)
			
			Dim TB_ISOTypeList() As DataRow = GetRows(ds, "TB_ISOType")

			If TB_ISOTypeList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_ISOTypeCollection = New ShippingBiz.TB_ISOTypeCollection()

			Dim dr As DataRow
			For Each dr In TB_ISOTypeList
				a.Add(New ShippingBiz.TB_ISOType(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_ISOTypeCollectionFromDataSet() As ShippingBiz.TB_ISOTypeCollection
			Dim TB_ISOTypeList() As DataRow = GetRows(DataSet, "TB_ISOType")
			Dim a As New ShippingBiz.TB_ISOTypeCollection()
			Dim dr As DataRow

			For Each dr In TB_ISOTypeList
				a.Add(New ShippingBiz.TB_ISOType(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Lines(LineCode As System.String, _
			LineName As System.String, _
			EDICode As System.String) As ShippingBiz.TB_Lines
			Dim dr As DataRow = DataSet.Tables("TB_Lines").NewRow()
			DataSet.Tables("TB_Lines").Rows.Add(dr)
            Dim _TB_Lines As New ShippingBiz.TB_Lines(Me, dr)
            
			_TB_Lines.LineCode = LineCode
			_TB_Lines.LineName = LineName
			_TB_Lines.EDICode = EDICode
            
            Return _TB_Lines
		End Function

		Public Function GetTB_Lines(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Lines
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Lines", relations), ds, false)
			
			Dim TB_LinesRow As DataRow = GetRow(ds, "TB_Lines")
			
			If TB_LinesRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Lines(Me, TB_LinesRow)
			
		End Function


		Public Function GetTB_LinesFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Lines
		
			Dim TB_LinesRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Lines").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_LinesRow = dr
					Exit For
				End If
			Next

			If TB_LinesRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Lines(Me, TB_LinesRow)
			
		End Function
		Public Function GetTB_LinesCollection() As ShippingBiz.TB_LinesCollection
			Return GetTB_LinesCollection(FetchPath.TB_Lines)
		End Function

		Public Function GetTB_LinesCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_LinesCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Lines", relations), ds, true)
			
			Dim TB_LinesList() As DataRow = GetRows(ds, "TB_Lines")

			If TB_LinesList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_LinesCollection = New ShippingBiz.TB_LinesCollection()

			Dim dr As DataRow
			For Each dr In TB_LinesList
				a.Add(New ShippingBiz.TB_Lines(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_LinesCollectionFromDataSet() As ShippingBiz.TB_LinesCollection
			Dim TB_LinesList() As DataRow = GetRows(DataSet, "TB_Lines")
			Dim a As New ShippingBiz.TB_LinesCollection()
			Dim dr As DataRow

			For Each dr In TB_LinesList
				a.Add(New ShippingBiz.TB_Lines(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Log(DataID As System.Guid, _
			TableNM As System.String) As ShippingBiz.TB_Log
			Dim dr As DataRow = DataSet.Tables("TB_Log").NewRow()
			DataSet.Tables("TB_Log").Rows.Add(dr)
            Dim _TB_Log As New ShippingBiz.TB_Log(Me, dr)
            
			_TB_Log.DataID = DataID
			_TB_Log.TableNM = TableNM
            
            Return _TB_Log
		End Function

		Public Function GetTB_Log(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Log
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Log", relations), ds, false)
			
			Dim TB_LogRow As DataRow = GetRow(ds, "TB_Log")
			
			If TB_LogRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Log(Me, TB_LogRow)
			
		End Function


		Public Function GetTB_LogFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Log
		
			Dim TB_LogRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Log").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_LogRow = dr
					Exit For
				End If
			Next

			If TB_LogRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Log(Me, TB_LogRow)
			
		End Function
		Public Function GetTB_LogCollection() As ShippingBiz.TB_LogCollection
			Return GetTB_LogCollection(FetchPath.TB_Log)
		End Function

		Public Function GetTB_LogCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_LogCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Log", relations), ds, true)
			
			Dim TB_LogList() As DataRow = GetRows(ds, "TB_Log")

			If TB_LogList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_LogCollection = New ShippingBiz.TB_LogCollection()

			Dim dr As DataRow
			For Each dr In TB_LogList
				a.Add(New ShippingBiz.TB_Log(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_LogCollectionFromDataSet() As ShippingBiz.TB_LogCollection
			Dim TB_LogList() As DataRow = GetRows(DataSet, "TB_Log")
			Dim a As New ShippingBiz.TB_LogCollection()
			Dim dr As DataRow

			For Each dr In TB_LogList
				a.Add(New ShippingBiz.TB_Log(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_LogDetails() As ShippingBiz.TB_LogDetails
			Dim dr As DataRow = DataSet.Tables("TB_LogDetails").NewRow()
			DataSet.Tables("TB_LogDetails").Rows.Add(dr)
            Dim _TB_LogDetails As New ShippingBiz.TB_LogDetails(Me, dr)
            

            
            Return _TB_LogDetails
		End Function

		Public Function GetTB_LogDetails(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_LogDetails
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_LogDetails", relations), ds, false)
			
			Dim TB_LogDetailsRow As DataRow = GetRow(ds, "TB_LogDetails")
			
			If TB_LogDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_LogDetails(Me, TB_LogDetailsRow)
			
		End Function


		Public Function GetTB_LogDetailsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_LogDetails
		
			Dim TB_LogDetailsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_LogDetails").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_LogDetailsRow = dr
					Exit For
				End If
			Next

			If TB_LogDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_LogDetails(Me, TB_LogDetailsRow)
			
		End Function
		Public Function GetTB_LogDetailsCollection() As ShippingBiz.TB_LogDetailsCollection
			Return GetTB_LogDetailsCollection(FetchPath.TB_LogDetails)
		End Function

		Public Function GetTB_LogDetailsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_LogDetailsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_LogDetails", relations), ds, true)
			
			Dim TB_LogDetailsList() As DataRow = GetRows(ds, "TB_LogDetails")

			If TB_LogDetailsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_LogDetailsCollection = New ShippingBiz.TB_LogDetailsCollection()

			Dim dr As DataRow
			For Each dr In TB_LogDetailsList
				a.Add(New ShippingBiz.TB_LogDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_LogDetailsCollectionFromDataSet() As ShippingBiz.TB_LogDetailsCollection
			Dim TB_LogDetailsList() As DataRow = GetRows(DataSet, "TB_LogDetails")
			Dim a As New ShippingBiz.TB_LogDetailsCollection()
			Dim dr As DataRow

			For Each dr In TB_LogDetailsList
				a.Add(New ShippingBiz.TB_LogDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_LogMaster() As ShippingBiz.TB_LogMaster
			Dim dr As DataRow = DataSet.Tables("TB_LogMaster").NewRow()
			DataSet.Tables("TB_LogMaster").Rows.Add(dr)
            Dim _TB_LogMaster As New ShippingBiz.TB_LogMaster(Me, dr)
            

            
            Return _TB_LogMaster
		End Function

		Public Function GetTB_LogMaster(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_LogMaster
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_LogMaster", relations), ds, false)
			
			Dim TB_LogMasterRow As DataRow = GetRow(ds, "TB_LogMaster")
			
			If TB_LogMasterRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_LogMaster(Me, TB_LogMasterRow)
			
		End Function


		Public Function GetTB_LogMasterFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_LogMaster
		
			Dim TB_LogMasterRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_LogMaster").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_LogMasterRow = dr
					Exit For
				End If
			Next

			If TB_LogMasterRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_LogMaster(Me, TB_LogMasterRow)
			
		End Function
		Public Function GetTB_LogMasterCollection() As ShippingBiz.TB_LogMasterCollection
			Return GetTB_LogMasterCollection(FetchPath.TB_LogMaster)
		End Function

		Public Function GetTB_LogMasterCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_LogMasterCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_LogMaster", relations), ds, true)
			
			Dim TB_LogMasterList() As DataRow = GetRows(ds, "TB_LogMaster")

			If TB_LogMasterList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_LogMasterCollection = New ShippingBiz.TB_LogMasterCollection()

			Dim dr As DataRow
			For Each dr In TB_LogMasterList
				a.Add(New ShippingBiz.TB_LogMaster(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_LogMasterCollectionFromDataSet() As ShippingBiz.TB_LogMasterCollection
			Dim TB_LogMasterList() As DataRow = GetRows(DataSet, "TB_LogMaster")
			Dim a As New ShippingBiz.TB_LogMasterCollection()
			Dim dr As DataRow

			For Each dr In TB_LogMasterList
				a.Add(New ShippingBiz.TB_LogMaster(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_MenuItems(ItemLevel As System.String, _
			ItemKey As System.String) As ShippingBiz.TB_MenuItems
			Dim dr As DataRow = DataSet.Tables("TB_MenuItems").NewRow()
			DataSet.Tables("TB_MenuItems").Rows.Add(dr)
            Dim _TB_MenuItems As New ShippingBiz.TB_MenuItems(Me, dr)
            
			_TB_MenuItems.ItemLevel = ItemLevel
			_TB_MenuItems.ItemKey = ItemKey
            
            Return _TB_MenuItems
		End Function

		Public Function GetTB_MenuItems(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_MenuItems
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_MenuItems", relations), ds, false)
			
			Dim TB_MenuItemsRow As DataRow = GetRow(ds, "TB_MenuItems")
			
			If TB_MenuItemsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_MenuItems(Me, TB_MenuItemsRow)
			
		End Function


		Public Function GetTB_MenuItemsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_MenuItems
		
			Dim TB_MenuItemsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_MenuItems").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_MenuItemsRow = dr
					Exit For
				End If
			Next

			If TB_MenuItemsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_MenuItems(Me, TB_MenuItemsRow)
			
		End Function
		Public Function GetTB_MenuItemsCollection() As ShippingBiz.TB_MenuItemsCollection
			Return GetTB_MenuItemsCollection(FetchPath.TB_MenuItems)
		End Function

		Public Function GetTB_MenuItemsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_MenuItemsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_MenuItems", relations), ds, true)
			
			Dim TB_MenuItemsList() As DataRow = GetRows(ds, "TB_MenuItems")

			If TB_MenuItemsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_MenuItemsCollection = New ShippingBiz.TB_MenuItemsCollection()

			Dim dr As DataRow
			For Each dr In TB_MenuItemsList
				a.Add(New ShippingBiz.TB_MenuItems(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_MenuItemsCollectionFromDataSet() As ShippingBiz.TB_MenuItemsCollection
			Dim TB_MenuItemsList() As DataRow = GetRows(DataSet, "TB_MenuItems")
			Dim a As New ShippingBiz.TB_MenuItemsCollection()
			Dim dr As DataRow

			For Each dr In TB_MenuItemsList
				a.Add(New ShippingBiz.TB_MenuItems(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_NOSPaymentTyps(PaymentType As System.String, _
			Description As System.String) As ShippingBiz.TB_NOSPaymentTyps
			Dim dr As DataRow = DataSet.Tables("TB_NOSPaymentTyps").NewRow()
			DataSet.Tables("TB_NOSPaymentTyps").Rows.Add(dr)
            Dim _TB_NOSPaymentTyps As New ShippingBiz.TB_NOSPaymentTyps(Me, dr)
            
			_TB_NOSPaymentTyps.PaymentType = PaymentType
			_TB_NOSPaymentTyps.Description = Description
            
            Return _TB_NOSPaymentTyps
		End Function

		Public Function GetTB_NOSPaymentTyps(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_NOSPaymentTyps
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_NOSPaymentTyps", relations), ds, false)
			
			Dim TB_NOSPaymentTypsRow As DataRow = GetRow(ds, "TB_NOSPaymentTyps")
			
			If TB_NOSPaymentTypsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_NOSPaymentTyps(Me, TB_NOSPaymentTypsRow)
			
		End Function


		Public Function GetTB_NOSPaymentTypsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_NOSPaymentTyps
		
			Dim TB_NOSPaymentTypsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_NOSPaymentTyps").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_NOSPaymentTypsRow = dr
					Exit For
				End If
			Next

			If TB_NOSPaymentTypsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_NOSPaymentTyps(Me, TB_NOSPaymentTypsRow)
			
		End Function
		Public Function GetTB_NOSPaymentTypsCollection() As ShippingBiz.TB_NOSPaymentTypsCollection
			Return GetTB_NOSPaymentTypsCollection(FetchPath.TB_NOSPaymentTyps)
		End Function

		Public Function GetTB_NOSPaymentTypsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_NOSPaymentTypsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_NOSPaymentTyps", relations), ds, true)
			
			Dim TB_NOSPaymentTypsList() As DataRow = GetRows(ds, "TB_NOSPaymentTyps")

			If TB_NOSPaymentTypsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_NOSPaymentTypsCollection = New ShippingBiz.TB_NOSPaymentTypsCollection()

			Dim dr As DataRow
			For Each dr In TB_NOSPaymentTypsList
				a.Add(New ShippingBiz.TB_NOSPaymentTyps(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_NOSPaymentTypsCollectionFromDataSet() As ShippingBiz.TB_NOSPaymentTypsCollection
			Dim TB_NOSPaymentTypsList() As DataRow = GetRows(DataSet, "TB_NOSPaymentTyps")
			Dim a As New ShippingBiz.TB_NOSPaymentTypsCollection()
			Dim dr As DataRow

			For Each dr In TB_NOSPaymentTypsList
				a.Add(New ShippingBiz.TB_NOSPaymentTyps(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Objects() As ShippingBiz.TB_Objects
			Dim dr As DataRow = DataSet.Tables("TB_Objects").NewRow()
			DataSet.Tables("TB_Objects").Rows.Add(dr)
            Dim _TB_Objects As New ShippingBiz.TB_Objects(Me, dr)
            

            
            Return _TB_Objects
		End Function

		Public Function GetTB_Objects(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Objects
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Objects", relations), ds, false)
			
			Dim TB_ObjectsRow As DataRow = GetRow(ds, "TB_Objects")
			
			If TB_ObjectsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Objects(Me, TB_ObjectsRow)
			
		End Function


		Public Function GetTB_ObjectsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Objects
		
			Dim TB_ObjectsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Objects").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_ObjectsRow = dr
					Exit For
				End If
			Next

			If TB_ObjectsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Objects(Me, TB_ObjectsRow)
			
		End Function
		Public Function GetTB_ObjectsCollection() As ShippingBiz.TB_ObjectsCollection
			Return GetTB_ObjectsCollection(FetchPath.TB_Objects)
		End Function

		Public Function GetTB_ObjectsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ObjectsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Objects", relations), ds, true)
			
			Dim TB_ObjectsList() As DataRow = GetRows(ds, "TB_Objects")

			If TB_ObjectsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_ObjectsCollection = New ShippingBiz.TB_ObjectsCollection()

			Dim dr As DataRow
			For Each dr In TB_ObjectsList
				a.Add(New ShippingBiz.TB_Objects(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_ObjectsCollectionFromDataSet() As ShippingBiz.TB_ObjectsCollection
			Dim TB_ObjectsList() As DataRow = GetRows(DataSet, "TB_Objects")
			Dim a As New ShippingBiz.TB_ObjectsCollection()
			Dim dr As DataRow

			For Each dr In TB_ObjectsList
				a.Add(New ShippingBiz.TB_Objects(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_ObjectsUser(ObjectLine As System.String, _
			ObjectGroup As System.String, _
			ObjectName As System.String) As ShippingBiz.TB_ObjectsUser
			Dim dr As DataRow = DataSet.Tables("TB_ObjectsUser").NewRow()
			DataSet.Tables("TB_ObjectsUser").Rows.Add(dr)
            Dim _TB_ObjectsUser As New ShippingBiz.TB_ObjectsUser(Me, dr)
            
			_TB_ObjectsUser.ObjectLine = ObjectLine
			_TB_ObjectsUser.ObjectGroup = ObjectGroup
			_TB_ObjectsUser.ObjectName = ObjectName
            
            Return _TB_ObjectsUser
		End Function

		Public Function GetTB_ObjectsUser(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ObjectsUser
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_ObjectsUser", relations), ds, false)
			
			Dim TB_ObjectsUserRow As DataRow = GetRow(ds, "TB_ObjectsUser")
			
			If TB_ObjectsUserRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ObjectsUser(Me, TB_ObjectsUserRow)
			
		End Function


		Public Function GetTB_ObjectsUserFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_ObjectsUser
		
			Dim TB_ObjectsUserRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_ObjectsUser").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_ObjectsUserRow = dr
					Exit For
				End If
			Next

			If TB_ObjectsUserRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ObjectsUser(Me, TB_ObjectsUserRow)
			
		End Function
		Public Function GetTB_ObjectsUserCollection() As ShippingBiz.TB_ObjectsUserCollection
			Return GetTB_ObjectsUserCollection(FetchPath.TB_ObjectsUser)
		End Function

		Public Function GetTB_ObjectsUserCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ObjectsUserCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_ObjectsUser", relations), ds, true)
			
			Dim TB_ObjectsUserList() As DataRow = GetRows(ds, "TB_ObjectsUser")

			If TB_ObjectsUserList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_ObjectsUserCollection = New ShippingBiz.TB_ObjectsUserCollection()

			Dim dr As DataRow
			For Each dr In TB_ObjectsUserList
				a.Add(New ShippingBiz.TB_ObjectsUser(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_ObjectsUserCollectionFromDataSet() As ShippingBiz.TB_ObjectsUserCollection
			Dim TB_ObjectsUserList() As DataRow = GetRows(DataSet, "TB_ObjectsUser")
			Dim a As New ShippingBiz.TB_ObjectsUserCollection()
			Dim dr As DataRow

			For Each dr In TB_ObjectsUserList
				a.Add(New ShippingBiz.TB_ObjectsUser(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_OutwardBLS(Service As System.String, _
			BlNo As System.String, _
			POL As System.String, _
			POD As System.String, _
			NoOfBls As System.Data.SqlTypes.SqlInt16, _
			TermsOfPayment As System.String) As ShippingBiz.TB_OutwardBLS
			Dim dr As DataRow = DataSet.Tables("TB_OutwardBLS").NewRow()
			DataSet.Tables("TB_OutwardBLS").Rows.Add(dr)
            Dim _TB_OutwardBLS As New ShippingBiz.TB_OutwardBLS(Me, dr)
            
			_TB_OutwardBLS.Service = Service
			_TB_OutwardBLS.BlNo = BlNo
			_TB_OutwardBLS.POL = POL
			_TB_OutwardBLS.POD = POD
			_TB_OutwardBLS.NoOfBls = NoOfBls
			_TB_OutwardBLS.TermsOfPayment = TermsOfPayment
            
            Return _TB_OutwardBLS
		End Function

		Public Function GetTB_OutwardBLS(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardBLS
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_OutwardBLS", relations), ds, false)
			
			Dim TB_OutwardBLSRow As DataRow = GetRow(ds, "TB_OutwardBLS")
			
			If TB_OutwardBLSRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardBLS(Me, TB_OutwardBLSRow)
			
		End Function


		Public Function GetTB_OutwardBLSFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_OutwardBLS
		
			Dim TB_OutwardBLSRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_OutwardBLS").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_OutwardBLSRow = dr
					Exit For
				End If
			Next

			If TB_OutwardBLSRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardBLS(Me, TB_OutwardBLSRow)
			
		End Function
		Public Function GetTB_OutwardBLSCollection() As ShippingBiz.TB_OutwardBLSCollection
			Return GetTB_OutwardBLSCollection(FetchPath.TB_OutwardBLS)
		End Function

		Public Function GetTB_OutwardBLSCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardBLSCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_OutwardBLS", relations), ds, true)
			
			Dim TB_OutwardBLSList() As DataRow = GetRows(ds, "TB_OutwardBLS")

			If TB_OutwardBLSList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_OutwardBLSCollection = New ShippingBiz.TB_OutwardBLSCollection()

			Dim dr As DataRow
			For Each dr In TB_OutwardBLSList
				a.Add(New ShippingBiz.TB_OutwardBLS(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_OutwardBLSCollectionFromDataSet() As ShippingBiz.TB_OutwardBLSCollection
			Dim TB_OutwardBLSList() As DataRow = GetRows(DataSet, "TB_OutwardBLS")
			Dim a As New ShippingBiz.TB_OutwardBLSCollection()
			Dim dr As DataRow

			For Each dr In TB_OutwardBLSList
				a.Add(New ShippingBiz.TB_OutwardBLS(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_OutwardBlsComments(BLID As System.Guid, _
			CommentType As System.String, _
			Comment As System.String) As ShippingBiz.TB_OutwardBlsComments
			Dim dr As DataRow = DataSet.Tables("TB_OutwardBlsComments").NewRow()
			DataSet.Tables("TB_OutwardBlsComments").Rows.Add(dr)
            Dim _TB_OutwardBlsComments As New ShippingBiz.TB_OutwardBlsComments(Me, dr)
            
			_TB_OutwardBlsComments.BLID = BLID
			_TB_OutwardBlsComments.CommentType = CommentType
			_TB_OutwardBlsComments.Comment = Comment
            
            Return _TB_OutwardBlsComments
		End Function

		Public Function GetTB_OutwardBlsComments(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardBlsComments
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_OutwardBlsComments", relations), ds, false)
			
			Dim TB_OutwardBlsCommentsRow As DataRow = GetRow(ds, "TB_OutwardBlsComments")
			
			If TB_OutwardBlsCommentsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardBlsComments(Me, TB_OutwardBlsCommentsRow)
			
		End Function


		Public Function GetTB_OutwardBlsCommentsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_OutwardBlsComments
		
			Dim TB_OutwardBlsCommentsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_OutwardBlsComments").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_OutwardBlsCommentsRow = dr
					Exit For
				End If
			Next

			If TB_OutwardBlsCommentsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardBlsComments(Me, TB_OutwardBlsCommentsRow)
			
		End Function
		Public Function GetTB_OutwardBlsCommentsCollection() As ShippingBiz.TB_OutwardBlsCommentsCollection
			Return GetTB_OutwardBlsCommentsCollection(FetchPath.TB_OutwardBlsComments)
		End Function

		Public Function GetTB_OutwardBlsCommentsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardBlsCommentsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_OutwardBlsComments", relations), ds, true)
			
			Dim TB_OutwardBlsCommentsList() As DataRow = GetRows(ds, "TB_OutwardBlsComments")

			If TB_OutwardBlsCommentsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_OutwardBlsCommentsCollection = New ShippingBiz.TB_OutwardBlsCommentsCollection()

			Dim dr As DataRow
			For Each dr In TB_OutwardBlsCommentsList
				a.Add(New ShippingBiz.TB_OutwardBlsComments(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_OutwardBlsCommentsCollectionFromDataSet() As ShippingBiz.TB_OutwardBlsCommentsCollection
			Dim TB_OutwardBlsCommentsList() As DataRow = GetRows(DataSet, "TB_OutwardBlsComments")
			Dim a As New ShippingBiz.TB_OutwardBlsCommentsCollection()
			Dim dr As DataRow

			For Each dr In TB_OutwardBlsCommentsList
				a.Add(New ShippingBiz.TB_OutwardBlsComments(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTb_OutwardBlsFrs(ByRef parentTB_OutwardBLS As ShippingBiz.TB_OutwardBLS) As ShippingBiz.Tb_OutwardBlsFrs
			Dim dr As DataRow = DataSet.Tables("Tb_OutwardBlsFrs").NewRow()
			DataSet.Tables("Tb_OutwardBlsFrs").Rows.Add(dr)
            Dim _Tb_OutwardBlsFrs As New ShippingBiz.Tb_OutwardBlsFrs(Me, dr)
            
			_Tb_OutwardBlsFrs.TB_OutwardBLS = parentTB_OutwardBLS
            
            Return _Tb_OutwardBlsFrs
		End Function

		Public Function GetTb_OutwardBlsFrs(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.Tb_OutwardBlsFrs
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("Tb_OutwardBlsFrs", relations), ds, false)
			
			Dim Tb_OutwardBlsFrsRow As DataRow = GetRow(ds, "Tb_OutwardBlsFrs")
			
			If Tb_OutwardBlsFrsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.Tb_OutwardBlsFrs(Me, Tb_OutwardBlsFrsRow)
			
		End Function


		Public Function GetTb_OutwardBlsFrsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.Tb_OutwardBlsFrs
		
			Dim Tb_OutwardBlsFrsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("Tb_OutwardBlsFrs").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					Tb_OutwardBlsFrsRow = dr
					Exit For
				End If
			Next

			If Tb_OutwardBlsFrsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.Tb_OutwardBlsFrs(Me, Tb_OutwardBlsFrsRow)
			
		End Function
		Public Function GetTb_OutwardBlsFrsCollection() As ShippingBiz.Tb_OutwardBlsFrsCollection
			Return GetTb_OutwardBlsFrsCollection(FetchPath.Tb_OutwardBlsFrs)
		End Function

		Public Function GetTb_OutwardBlsFrsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.Tb_OutwardBlsFrsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("Tb_OutwardBlsFrs", relations), ds, true)
			
			Dim Tb_OutwardBlsFrsList() As DataRow = GetRows(ds, "Tb_OutwardBlsFrs")

			If Tb_OutwardBlsFrsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.Tb_OutwardBlsFrsCollection = New ShippingBiz.Tb_OutwardBlsFrsCollection()

			Dim dr As DataRow
			For Each dr In Tb_OutwardBlsFrsList
				a.Add(New ShippingBiz.Tb_OutwardBlsFrs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTb_OutwardBlsFrsCollectionFromDataSet() As ShippingBiz.Tb_OutwardBlsFrsCollection
			Dim Tb_OutwardBlsFrsList() As DataRow = GetRows(DataSet, "Tb_OutwardBlsFrs")
			Dim a As New ShippingBiz.Tb_OutwardBlsFrsCollection()
			Dim dr As DataRow

			For Each dr In Tb_OutwardBlsFrsList
				a.Add(New ShippingBiz.Tb_OutwardBlsFrs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_OutwardBlsGoods(ByRef parentTB_OutwardBLS As ShippingBiz.TB_OutwardBLS) As ShippingBiz.TB_OutwardBlsGoods
			Dim dr As DataRow = DataSet.Tables("TB_OutwardBlsGoods").NewRow()
			DataSet.Tables("TB_OutwardBlsGoods").Rows.Add(dr)
            Dim _TB_OutwardBlsGoods As New ShippingBiz.TB_OutwardBlsGoods(Me, dr)
            
			_TB_OutwardBlsGoods.TB_OutwardBLS = parentTB_OutwardBLS
            
            Return _TB_OutwardBlsGoods
		End Function

		Public Function GetTB_OutwardBlsGoods(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardBlsGoods
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_OutwardBlsGoods", relations), ds, false)
			
			Dim TB_OutwardBlsGoodsRow As DataRow = GetRow(ds, "TB_OutwardBlsGoods")
			
			If TB_OutwardBlsGoodsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardBlsGoods(Me, TB_OutwardBlsGoodsRow)
			
		End Function


		Public Function GetTB_OutwardBlsGoodsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_OutwardBlsGoods
		
			Dim TB_OutwardBlsGoodsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_OutwardBlsGoods").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_OutwardBlsGoodsRow = dr
					Exit For
				End If
			Next

			If TB_OutwardBlsGoodsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardBlsGoods(Me, TB_OutwardBlsGoodsRow)
			
		End Function
		Public Function GetTB_OutwardBlsGoodsCollection() As ShippingBiz.TB_OutwardBlsGoodsCollection
			Return GetTB_OutwardBlsGoodsCollection(FetchPath.TB_OutwardBlsGoods)
		End Function

		Public Function GetTB_OutwardBlsGoodsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardBlsGoodsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_OutwardBlsGoods", relations), ds, true)
			
			Dim TB_OutwardBlsGoodsList() As DataRow = GetRows(ds, "TB_OutwardBlsGoods")

			If TB_OutwardBlsGoodsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_OutwardBlsGoodsCollection = New ShippingBiz.TB_OutwardBlsGoodsCollection()

			Dim dr As DataRow
			For Each dr In TB_OutwardBlsGoodsList
				a.Add(New ShippingBiz.TB_OutwardBlsGoods(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_OutwardBlsGoodsCollectionFromDataSet() As ShippingBiz.TB_OutwardBlsGoodsCollection
			Dim TB_OutwardBlsGoodsList() As DataRow = GetRows(DataSet, "TB_OutwardBlsGoods")
			Dim a As New ShippingBiz.TB_OutwardBlsGoodsCollection()
			Dim dr As DataRow

			For Each dr In TB_OutwardBlsGoodsList
				a.Add(New ShippingBiz.TB_OutwardBlsGoods(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_OutwardBlsNames(ByRef parentTB_OutwardBLS As ShippingBiz.TB_OutwardBLS) As ShippingBiz.TB_OutwardBlsNames
			Dim dr As DataRow = DataSet.Tables("TB_OutwardBlsNames").NewRow()
			DataSet.Tables("TB_OutwardBlsNames").Rows.Add(dr)
            Dim _TB_OutwardBlsNames As New ShippingBiz.TB_OutwardBlsNames(Me, dr)
            
			_TB_OutwardBlsNames.TB_OutwardBLS = parentTB_OutwardBLS
            
            Return _TB_OutwardBlsNames
		End Function

		Public Function GetTB_OutwardBlsNames(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardBlsNames
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_OutwardBlsNames", relations), ds, false)
			
			Dim TB_OutwardBlsNamesRow As DataRow = GetRow(ds, "TB_OutwardBlsNames")
			
			If TB_OutwardBlsNamesRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardBlsNames(Me, TB_OutwardBlsNamesRow)
			
		End Function


		Public Function GetTB_OutwardBlsNamesFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_OutwardBlsNames
		
			Dim TB_OutwardBlsNamesRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_OutwardBlsNames").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_OutwardBlsNamesRow = dr
					Exit For
				End If
			Next

			If TB_OutwardBlsNamesRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardBlsNames(Me, TB_OutwardBlsNamesRow)
			
		End Function
		Public Function GetTB_OutwardBlsNamesCollection() As ShippingBiz.TB_OutwardBlsNamesCollection
			Return GetTB_OutwardBlsNamesCollection(FetchPath.TB_OutwardBlsNames)
		End Function

		Public Function GetTB_OutwardBlsNamesCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardBlsNamesCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_OutwardBlsNames", relations), ds, true)
			
			Dim TB_OutwardBlsNamesList() As DataRow = GetRows(ds, "TB_OutwardBlsNames")

			If TB_OutwardBlsNamesList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_OutwardBlsNamesCollection = New ShippingBiz.TB_OutwardBlsNamesCollection()

			Dim dr As DataRow
			For Each dr In TB_OutwardBlsNamesList
				a.Add(New ShippingBiz.TB_OutwardBlsNames(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_OutwardBlsNamesCollectionFromDataSet() As ShippingBiz.TB_OutwardBlsNamesCollection
			Dim TB_OutwardBlsNamesList() As DataRow = GetRows(DataSet, "TB_OutwardBlsNames")
			Dim a As New ShippingBiz.TB_OutwardBlsNamesCollection()
			Dim dr As DataRow

			For Each dr In TB_OutwardBlsNamesList
				a.Add(New ShippingBiz.TB_OutwardBlsNames(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_OutwardBlsTemplate() As ShippingBiz.TB_OutwardBlsTemplate
			Dim dr As DataRow = DataSet.Tables("TB_OutwardBlsTemplate").NewRow()
			DataSet.Tables("TB_OutwardBlsTemplate").Rows.Add(dr)
            Dim _TB_OutwardBlsTemplate As New ShippingBiz.TB_OutwardBlsTemplate(Me, dr)
            

            
            Return _TB_OutwardBlsTemplate
		End Function

		Public Function GetTB_OutwardBlsTemplate(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardBlsTemplate
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_OutwardBlsTemplate", relations), ds, false)
			
			Dim TB_OutwardBlsTemplateRow As DataRow = GetRow(ds, "TB_OutwardBlsTemplate")
			
			If TB_OutwardBlsTemplateRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardBlsTemplate(Me, TB_OutwardBlsTemplateRow)
			
		End Function


		Public Function GetTB_OutwardBlsTemplateFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_OutwardBlsTemplate
		
			Dim TB_OutwardBlsTemplateRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_OutwardBlsTemplate").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_OutwardBlsTemplateRow = dr
					Exit For
				End If
			Next

			If TB_OutwardBlsTemplateRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardBlsTemplate(Me, TB_OutwardBlsTemplateRow)
			
		End Function
		Public Function GetTB_OutwardBlsTemplateCollection() As ShippingBiz.TB_OutwardBlsTemplateCollection
			Return GetTB_OutwardBlsTemplateCollection(FetchPath.TB_OutwardBlsTemplate)
		End Function

		Public Function GetTB_OutwardBlsTemplateCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardBlsTemplateCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_OutwardBlsTemplate", relations), ds, true)
			
			Dim TB_OutwardBlsTemplateList() As DataRow = GetRows(ds, "TB_OutwardBlsTemplate")

			If TB_OutwardBlsTemplateList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_OutwardBlsTemplateCollection = New ShippingBiz.TB_OutwardBlsTemplateCollection()

			Dim dr As DataRow
			For Each dr In TB_OutwardBlsTemplateList
				a.Add(New ShippingBiz.TB_OutwardBlsTemplate(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_OutwardBlsTemplateCollectionFromDataSet() As ShippingBiz.TB_OutwardBlsTemplateCollection
			Dim TB_OutwardBlsTemplateList() As DataRow = GetRows(DataSet, "TB_OutwardBlsTemplate")
			Dim a As New ShippingBiz.TB_OutwardBlsTemplateCollection()
			Dim dr As DataRow

			For Each dr In TB_OutwardBlsTemplateList
				a.Add(New ShippingBiz.TB_OutwardBlsTemplate(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_OutwardCharges(Seq As System.Data.SqlTypes.SqlInt16, _
			ChargesCode As System.String, _
			Currency As System.String, _
			Qty As System.Data.SqlTypes.SqlInt16, _
			Rate As System.Data.SqlTypes.SqlDouble, _
			Amount As System.Data.SqlTypes.SqlDouble, _
			PayAt As System.String, _
			ByRef parentTB_OutwardBLS As ShippingBiz.TB_OutwardBLS) As ShippingBiz.TB_OutwardCharges
			Dim dr As DataRow = DataSet.Tables("TB_OutwardCharges").NewRow()
			DataSet.Tables("TB_OutwardCharges").Rows.Add(dr)
            Dim _TB_OutwardCharges As New ShippingBiz.TB_OutwardCharges(Me, dr)
            
			_TB_OutwardCharges.Seq = Seq
			_TB_OutwardCharges.ChargesCode = ChargesCode
			_TB_OutwardCharges.Currency = Currency
			_TB_OutwardCharges.Qty = Qty
			_TB_OutwardCharges.Rate = Rate
			_TB_OutwardCharges.Amount = Amount
			_TB_OutwardCharges.PayAt = PayAt
			_TB_OutwardCharges.TB_OutwardBLS = parentTB_OutwardBLS
            
            Return _TB_OutwardCharges
		End Function

		Public Function GetTB_OutwardCharges(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardCharges
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_OutwardCharges", relations), ds, false)
			
			Dim TB_OutwardChargesRow As DataRow = GetRow(ds, "TB_OutwardCharges")
			
			If TB_OutwardChargesRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardCharges(Me, TB_OutwardChargesRow)
			
		End Function


		Public Function GetTB_OutwardChargesFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_OutwardCharges
		
			Dim TB_OutwardChargesRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_OutwardCharges").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_OutwardChargesRow = dr
					Exit For
				End If
			Next

			If TB_OutwardChargesRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardCharges(Me, TB_OutwardChargesRow)
			
		End Function
		Public Function GetTB_OutwardChargesCollection() As ShippingBiz.TB_OutwardChargesCollection
			Return GetTB_OutwardChargesCollection(FetchPath.TB_OutwardCharges)
		End Function

		Public Function GetTB_OutwardChargesCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardChargesCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_OutwardCharges", relations), ds, true)
			
			Dim TB_OutwardChargesList() As DataRow = GetRows(ds, "TB_OutwardCharges")

			If TB_OutwardChargesList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_OutwardChargesCollection = New ShippingBiz.TB_OutwardChargesCollection()

			Dim dr As DataRow
			For Each dr In TB_OutwardChargesList
				a.Add(New ShippingBiz.TB_OutwardCharges(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_OutwardChargesCollectionFromDataSet() As ShippingBiz.TB_OutwardChargesCollection
			Dim TB_OutwardChargesList() As DataRow = GetRows(DataSet, "TB_OutwardCharges")
			Dim a As New ShippingBiz.TB_OutwardChargesCollection()
			Dim dr As DataRow

			For Each dr In TB_OutwardChargesList
				a.Add(New ShippingBiz.TB_OutwardCharges(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_OutwardCnsImco(ByRef parentTB_OutwardCntrs As ShippingBiz.TB_OutwardCntrs) As ShippingBiz.TB_OutwardCnsImco
			Dim dr As DataRow = DataSet.Tables("TB_OutwardCnsImco").NewRow()
			DataSet.Tables("TB_OutwardCnsImco").Rows.Add(dr)
            Dim _TB_OutwardCnsImco As New ShippingBiz.TB_OutwardCnsImco(Me, dr)
            
			_TB_OutwardCnsImco.TB_OutwardCntrs = parentTB_OutwardCntrs
            
            Return _TB_OutwardCnsImco
		End Function

		Public Function GetTB_OutwardCnsImco(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardCnsImco
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_OutwardCnsImco", relations), ds, false)
			
			Dim TB_OutwardCnsImcoRow As DataRow = GetRow(ds, "TB_OutwardCnsImco")
			
			If TB_OutwardCnsImcoRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardCnsImco(Me, TB_OutwardCnsImcoRow)
			
		End Function


		Public Function GetTB_OutwardCnsImcoFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_OutwardCnsImco
		
			Dim TB_OutwardCnsImcoRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_OutwardCnsImco").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_OutwardCnsImcoRow = dr
					Exit For
				End If
			Next

			If TB_OutwardCnsImcoRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardCnsImco(Me, TB_OutwardCnsImcoRow)
			
		End Function
		Public Function GetTB_OutwardCnsImcoCollection() As ShippingBiz.TB_OutwardCnsImcoCollection
			Return GetTB_OutwardCnsImcoCollection(FetchPath.TB_OutwardCnsImco)
		End Function

		Public Function GetTB_OutwardCnsImcoCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardCnsImcoCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_OutwardCnsImco", relations), ds, true)
			
			Dim TB_OutwardCnsImcoList() As DataRow = GetRows(ds, "TB_OutwardCnsImco")

			If TB_OutwardCnsImcoList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_OutwardCnsImcoCollection = New ShippingBiz.TB_OutwardCnsImcoCollection()

			Dim dr As DataRow
			For Each dr In TB_OutwardCnsImcoList
				a.Add(New ShippingBiz.TB_OutwardCnsImco(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_OutwardCnsImcoCollectionFromDataSet() As ShippingBiz.TB_OutwardCnsImcoCollection
			Dim TB_OutwardCnsImcoList() As DataRow = GetRows(DataSet, "TB_OutwardCnsImco")
			Dim a As New ShippingBiz.TB_OutwardCnsImcoCollection()
			Dim dr As DataRow

			For Each dr In TB_OutwardCnsImcoList
				a.Add(New ShippingBiz.TB_OutwardCnsImco(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_OutwardCnsPkgs(PackageType As System.String, _
			NoOFPkgs As System.Data.SqlTypes.SqlInt64, _
			ByRef parentTB_OutwardCntrs As ShippingBiz.TB_OutwardCntrs) As ShippingBiz.TB_OutwardCnsPkgs
			Dim dr As DataRow = DataSet.Tables("TB_OutwardCnsPkgs").NewRow()
			DataSet.Tables("TB_OutwardCnsPkgs").Rows.Add(dr)
            Dim _TB_OutwardCnsPkgs As New ShippingBiz.TB_OutwardCnsPkgs(Me, dr)
            
			_TB_OutwardCnsPkgs.PackageType = PackageType
			_TB_OutwardCnsPkgs.NoOFPkgs = NoOFPkgs
			_TB_OutwardCnsPkgs.TB_OutwardCntrs = parentTB_OutwardCntrs
            
            Return _TB_OutwardCnsPkgs
		End Function

		Public Function GetTB_OutwardCnsPkgs(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardCnsPkgs
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_OutwardCnsPkgs", relations), ds, false)
			
			Dim TB_OutwardCnsPkgsRow As DataRow = GetRow(ds, "TB_OutwardCnsPkgs")
			
			If TB_OutwardCnsPkgsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardCnsPkgs(Me, TB_OutwardCnsPkgsRow)
			
		End Function


		Public Function GetTB_OutwardCnsPkgsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_OutwardCnsPkgs
		
			Dim TB_OutwardCnsPkgsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_OutwardCnsPkgs").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_OutwardCnsPkgsRow = dr
					Exit For
				End If
			Next

			If TB_OutwardCnsPkgsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardCnsPkgs(Me, TB_OutwardCnsPkgsRow)
			
		End Function
		Public Function GetTB_OutwardCnsPkgsCollection() As ShippingBiz.TB_OutwardCnsPkgsCollection
			Return GetTB_OutwardCnsPkgsCollection(FetchPath.TB_OutwardCnsPkgs)
		End Function

		Public Function GetTB_OutwardCnsPkgsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardCnsPkgsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_OutwardCnsPkgs", relations), ds, true)
			
			Dim TB_OutwardCnsPkgsList() As DataRow = GetRows(ds, "TB_OutwardCnsPkgs")

			If TB_OutwardCnsPkgsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_OutwardCnsPkgsCollection = New ShippingBiz.TB_OutwardCnsPkgsCollection()

			Dim dr As DataRow
			For Each dr In TB_OutwardCnsPkgsList
				a.Add(New ShippingBiz.TB_OutwardCnsPkgs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_OutwardCnsPkgsCollectionFromDataSet() As ShippingBiz.TB_OutwardCnsPkgsCollection
			Dim TB_OutwardCnsPkgsList() As DataRow = GetRows(DataSet, "TB_OutwardCnsPkgs")
			Dim a As New ShippingBiz.TB_OutwardCnsPkgsCollection()
			Dim dr As DataRow

			For Each dr In TB_OutwardCnsPkgsList
				a.Add(New ShippingBiz.TB_OutwardCnsPkgs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_OutwardCnsTemprature(ByRef parentTB_OutwardCntrs As ShippingBiz.TB_OutwardCntrs) As ShippingBiz.TB_OutwardCnsTemprature
			Dim dr As DataRow = DataSet.Tables("TB_OutwardCnsTemprature").NewRow()
			DataSet.Tables("TB_OutwardCnsTemprature").Rows.Add(dr)
            Dim _TB_OutwardCnsTemprature As New ShippingBiz.TB_OutwardCnsTemprature(Me, dr)
            
			_TB_OutwardCnsTemprature.TB_OutwardCntrs = parentTB_OutwardCntrs
            
            Return _TB_OutwardCnsTemprature
		End Function

		Public Function GetTB_OutwardCnsTemprature(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardCnsTemprature
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_OutwardCnsTemprature", relations), ds, false)
			
			Dim TB_OutwardCnsTempratureRow As DataRow = GetRow(ds, "TB_OutwardCnsTemprature")
			
			If TB_OutwardCnsTempratureRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardCnsTemprature(Me, TB_OutwardCnsTempratureRow)
			
		End Function


		Public Function GetTB_OutwardCnsTempratureFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_OutwardCnsTemprature
		
			Dim TB_OutwardCnsTempratureRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_OutwardCnsTemprature").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_OutwardCnsTempratureRow = dr
					Exit For
				End If
			Next

			If TB_OutwardCnsTempratureRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardCnsTemprature(Me, TB_OutwardCnsTempratureRow)
			
		End Function
		Public Function GetTB_OutwardCnsTempratureCollection() As ShippingBiz.TB_OutwardCnsTempratureCollection
			Return GetTB_OutwardCnsTempratureCollection(FetchPath.TB_OutwardCnsTemprature)
		End Function

		Public Function GetTB_OutwardCnsTempratureCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardCnsTempratureCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_OutwardCnsTemprature", relations), ds, true)
			
			Dim TB_OutwardCnsTempratureList() As DataRow = GetRows(ds, "TB_OutwardCnsTemprature")

			If TB_OutwardCnsTempratureList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_OutwardCnsTempratureCollection = New ShippingBiz.TB_OutwardCnsTempratureCollection()

			Dim dr As DataRow
			For Each dr In TB_OutwardCnsTempratureList
				a.Add(New ShippingBiz.TB_OutwardCnsTemprature(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_OutwardCnsTempratureCollectionFromDataSet() As ShippingBiz.TB_OutwardCnsTempratureCollection
			Dim TB_OutwardCnsTempratureList() As DataRow = GetRows(DataSet, "TB_OutwardCnsTemprature")
			Dim a As New ShippingBiz.TB_OutwardCnsTempratureCollection()
			Dim dr As DataRow

			For Each dr In TB_OutwardCnsTempratureList
				a.Add(New ShippingBiz.TB_OutwardCnsTemprature(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_OutwardCntrs(CntrNo As System.String, _
			CnSize As System.String, _
			CnType As System.String, _
			TW As System.Data.SqlTypes.SqlInt64, _
			SOC As System.String, _
			ByRef parentTB_OutwardBLS As ShippingBiz.TB_OutwardBLS) As ShippingBiz.TB_OutwardCntrs
			Dim dr As DataRow = DataSet.Tables("TB_OutwardCntrs").NewRow()
			DataSet.Tables("TB_OutwardCntrs").Rows.Add(dr)
            Dim _TB_OutwardCntrs As New ShippingBiz.TB_OutwardCntrs(Me, dr)
            
			_TB_OutwardCntrs.CntrNo = CntrNo
			_TB_OutwardCntrs.CnSize = CnSize
			_TB_OutwardCntrs.CnType = CnType
			_TB_OutwardCntrs.TW = TW
			_TB_OutwardCntrs.SOC = SOC
			_TB_OutwardCntrs.TB_OutwardBLS = parentTB_OutwardBLS
            
            Return _TB_OutwardCntrs
		End Function

		Public Function GetTB_OutwardCntrs(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardCntrs
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_OutwardCntrs", relations), ds, false)
			
			Dim TB_OutwardCntrsRow As DataRow = GetRow(ds, "TB_OutwardCntrs")
			
			If TB_OutwardCntrsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardCntrs(Me, TB_OutwardCntrsRow)
			
		End Function


		Public Function GetTB_OutwardCntrsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_OutwardCntrs
		
			Dim TB_OutwardCntrsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_OutwardCntrs").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_OutwardCntrsRow = dr
					Exit For
				End If
			Next

			If TB_OutwardCntrsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardCntrs(Me, TB_OutwardCntrsRow)
			
		End Function
		Public Function GetTB_OutwardCntrsCollection() As ShippingBiz.TB_OutwardCntrsCollection
			Return GetTB_OutwardCntrsCollection(FetchPath.TB_OutwardCntrs)
		End Function

		Public Function GetTB_OutwardCntrsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardCntrsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_OutwardCntrs", relations), ds, true)
			
			Dim TB_OutwardCntrsList() As DataRow = GetRows(ds, "TB_OutwardCntrs")

			If TB_OutwardCntrsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_OutwardCntrsCollection = New ShippingBiz.TB_OutwardCntrsCollection()

			Dim dr As DataRow
			For Each dr In TB_OutwardCntrsList
				a.Add(New ShippingBiz.TB_OutwardCntrs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_OutwardCntrsCollectionFromDataSet() As ShippingBiz.TB_OutwardCntrsCollection
			Dim TB_OutwardCntrsList() As DataRow = GetRows(DataSet, "TB_OutwardCntrs")
			Dim a As New ShippingBiz.TB_OutwardCntrsCollection()
			Dim dr As DataRow

			For Each dr In TB_OutwardCntrsList
				a.Add(New ShippingBiz.TB_OutwardCntrs(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_OutwardCntrsCharges(ChargesCode As System.String, _
			Currency As System.String, _
			UnitRate As System.Data.SqlTypes.SqlDecimal, _
			MEARate As System.Data.SqlTypes.SqlDecimal, _
			WGTrate As System.Data.SqlTypes.SqlDecimal, _
			FromPlace As System.String, _
			ToPlace As System.String, _
			MinRate As System.Data.SqlTypes.SqlDecimal, _
			Terms As System.String, _
			RealAmount As System.Data.SqlTypes.SqlDecimal, _
			ByRef parentTB_OutwardCntrs As ShippingBiz.TB_OutwardCntrs) As ShippingBiz.TB_OutwardCntrsCharges
			Dim dr As DataRow = DataSet.Tables("TB_OutwardCntrsCharges").NewRow()
			DataSet.Tables("TB_OutwardCntrsCharges").Rows.Add(dr)
            Dim _TB_OutwardCntrsCharges As New ShippingBiz.TB_OutwardCntrsCharges(Me, dr)
            
			_TB_OutwardCntrsCharges.ChargesCode = ChargesCode
			_TB_OutwardCntrsCharges.Currency = Currency
			_TB_OutwardCntrsCharges.UnitRate = UnitRate
			_TB_OutwardCntrsCharges.MEARate = MEARate
			_TB_OutwardCntrsCharges.WGTrate = WGTrate
			_TB_OutwardCntrsCharges.FromPlace = FromPlace
			_TB_OutwardCntrsCharges.ToPlace = ToPlace
			_TB_OutwardCntrsCharges.MinRate = MinRate
			_TB_OutwardCntrsCharges.Terms = Terms
			_TB_OutwardCntrsCharges.RealAmount = RealAmount
			_TB_OutwardCntrsCharges.TB_OutwardCntrs = parentTB_OutwardCntrs
            
            Return _TB_OutwardCntrsCharges
		End Function

		Public Function GetTB_OutwardCntrsCharges(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardCntrsCharges
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_OutwardCntrsCharges", relations), ds, false)
			
			Dim TB_OutwardCntrsChargesRow As DataRow = GetRow(ds, "TB_OutwardCntrsCharges")
			
			If TB_OutwardCntrsChargesRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardCntrsCharges(Me, TB_OutwardCntrsChargesRow)
			
		End Function


		Public Function GetTB_OutwardCntrsChargesFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_OutwardCntrsCharges
		
			Dim TB_OutwardCntrsChargesRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_OutwardCntrsCharges").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_OutwardCntrsChargesRow = dr
					Exit For
				End If
			Next

			If TB_OutwardCntrsChargesRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardCntrsCharges(Me, TB_OutwardCntrsChargesRow)
			
		End Function
		Public Function GetTB_OutwardCntrsChargesCollection() As ShippingBiz.TB_OutwardCntrsChargesCollection
			Return GetTB_OutwardCntrsChargesCollection(FetchPath.TB_OutwardCntrsCharges)
		End Function

		Public Function GetTB_OutwardCntrsChargesCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardCntrsChargesCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_OutwardCntrsCharges", relations), ds, true)
			
			Dim TB_OutwardCntrsChargesList() As DataRow = GetRows(ds, "TB_OutwardCntrsCharges")

			If TB_OutwardCntrsChargesList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_OutwardCntrsChargesCollection = New ShippingBiz.TB_OutwardCntrsChargesCollection()

			Dim dr As DataRow
			For Each dr In TB_OutwardCntrsChargesList
				a.Add(New ShippingBiz.TB_OutwardCntrsCharges(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_OutwardCntrsChargesCollectionFromDataSet() As ShippingBiz.TB_OutwardCntrsChargesCollection
			Dim TB_OutwardCntrsChargesList() As DataRow = GetRows(DataSet, "TB_OutwardCntrsCharges")
			Dim a As New ShippingBiz.TB_OutwardCntrsChargesCollection()
			Dim dr As DataRow

			For Each dr In TB_OutwardCntrsChargesList
				a.Add(New ShippingBiz.TB_OutwardCntrsCharges(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_OutwardDiscount(ByRef parentTB_OutwardBLS As ShippingBiz.TB_OutwardBLS) As ShippingBiz.TB_OutwardDiscount
			Dim dr As DataRow = DataSet.Tables("TB_OutwardDiscount").NewRow()
			DataSet.Tables("TB_OutwardDiscount").Rows.Add(dr)
            Dim _TB_OutwardDiscount As New ShippingBiz.TB_OutwardDiscount(Me, dr)
            
			_TB_OutwardDiscount.TB_OutwardBLS = parentTB_OutwardBLS
            
            Return _TB_OutwardDiscount
		End Function

		Public Function GetTB_OutwardDiscount(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardDiscount
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_OutwardDiscount", relations), ds, false)
			
			Dim TB_OutwardDiscountRow As DataRow = GetRow(ds, "TB_OutwardDiscount")
			
			If TB_OutwardDiscountRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardDiscount(Me, TB_OutwardDiscountRow)
			
		End Function


		Public Function GetTB_OutwardDiscountFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_OutwardDiscount
		
			Dim TB_OutwardDiscountRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_OutwardDiscount").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_OutwardDiscountRow = dr
					Exit For
				End If
			Next

			If TB_OutwardDiscountRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_OutwardDiscount(Me, TB_OutwardDiscountRow)
			
		End Function
		Public Function GetTB_OutwardDiscountCollection() As ShippingBiz.TB_OutwardDiscountCollection
			Return GetTB_OutwardDiscountCollection(FetchPath.TB_OutwardDiscount)
		End Function

		Public Function GetTB_OutwardDiscountCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_OutwardDiscountCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_OutwardDiscount", relations), ds, true)
			
			Dim TB_OutwardDiscountList() As DataRow = GetRows(ds, "TB_OutwardDiscount")

			If TB_OutwardDiscountList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_OutwardDiscountCollection = New ShippingBiz.TB_OutwardDiscountCollection()

			Dim dr As DataRow
			For Each dr In TB_OutwardDiscountList
				a.Add(New ShippingBiz.TB_OutwardDiscount(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_OutwardDiscountCollectionFromDataSet() As ShippingBiz.TB_OutwardDiscountCollection
			Dim TB_OutwardDiscountList() As DataRow = GetRows(DataSet, "TB_OutwardDiscount")
			Dim a As New ShippingBiz.TB_OutwardDiscountCollection()
			Dim dr As DataRow

			For Each dr In TB_OutwardDiscountList
				a.Add(New ShippingBiz.TB_OutwardDiscount(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_PermitDetails(ByRef parentTB_EcsContainers As ShippingBiz.TB_EcsContainers, _
			ByRef parentTB_Permits As ShippingBiz.TB_Permits) As ShippingBiz.TB_PermitDetails
			Dim dr As DataRow = DataSet.Tables("TB_PermitDetails").NewRow()
			DataSet.Tables("TB_PermitDetails").Rows.Add(dr)
            Dim _TB_PermitDetails As New ShippingBiz.TB_PermitDetails(Me, dr)
            
			_TB_PermitDetails.TB_EcsContainers = parentTB_EcsContainers
			_TB_PermitDetails.TB_Permits = parentTB_Permits
            
            Return _TB_PermitDetails
		End Function

		Public Function GetTB_PermitDetails(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_PermitDetails
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_PermitDetails", relations), ds, false)
			
			Dim TB_PermitDetailsRow As DataRow = GetRow(ds, "TB_PermitDetails")
			
			If TB_PermitDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_PermitDetails(Me, TB_PermitDetailsRow)
			
		End Function


		Public Function GetTB_PermitDetailsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_PermitDetails
		
			Dim TB_PermitDetailsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_PermitDetails").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_PermitDetailsRow = dr
					Exit For
				End If
			Next

			If TB_PermitDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_PermitDetails(Me, TB_PermitDetailsRow)
			
		End Function
		Public Function GetTB_PermitDetailsCollection() As ShippingBiz.TB_PermitDetailsCollection
			Return GetTB_PermitDetailsCollection(FetchPath.TB_PermitDetails)
		End Function

		Public Function GetTB_PermitDetailsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_PermitDetailsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_PermitDetails", relations), ds, true)
			
			Dim TB_PermitDetailsList() As DataRow = GetRows(ds, "TB_PermitDetails")

			If TB_PermitDetailsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_PermitDetailsCollection = New ShippingBiz.TB_PermitDetailsCollection()

			Dim dr As DataRow
			For Each dr In TB_PermitDetailsList
				a.Add(New ShippingBiz.TB_PermitDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_PermitDetailsCollectionFromDataSet() As ShippingBiz.TB_PermitDetailsCollection
			Dim TB_PermitDetailsList() As DataRow = GetRows(DataSet, "TB_PermitDetails")
			Dim a As New ShippingBiz.TB_PermitDetailsCollection()
			Dim dr As DataRow

			For Each dr In TB_PermitDetailsList
				a.Add(New ShippingBiz.TB_PermitDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Permits(PermitNo As System.String, _
			Status As System.String, _
			Goods As System.String, _
			FPOD As System.String) As ShippingBiz.TB_Permits
			Dim dr As DataRow = DataSet.Tables("TB_Permits").NewRow()
			DataSet.Tables("TB_Permits").Rows.Add(dr)
            Dim _TB_Permits As New ShippingBiz.TB_Permits(Me, dr)
            
			_TB_Permits.PermitNo = PermitNo
			_TB_Permits.Status = Status
			_TB_Permits.Goods = Goods
			_TB_Permits.FPOD = FPOD
            
            Return _TB_Permits
		End Function

		Public Function GetTB_Permits(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Permits
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Permits", relations), ds, false)
			
			Dim TB_PermitsRow As DataRow = GetRow(ds, "TB_Permits")
			
			If TB_PermitsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Permits(Me, TB_PermitsRow)
			
		End Function


		Public Function GetTB_PermitsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Permits
		
			Dim TB_PermitsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Permits").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_PermitsRow = dr
					Exit For
				End If
			Next

			If TB_PermitsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Permits(Me, TB_PermitsRow)
			
		End Function
		Public Function GetTB_PermitsCollection() As ShippingBiz.TB_PermitsCollection
			Return GetTB_PermitsCollection(FetchPath.TB_Permits)
		End Function

		Public Function GetTB_PermitsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_PermitsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Permits", relations), ds, true)
			
			Dim TB_PermitsList() As DataRow = GetRows(ds, "TB_Permits")

			If TB_PermitsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_PermitsCollection = New ShippingBiz.TB_PermitsCollection()

			Dim dr As DataRow
			For Each dr In TB_PermitsList
				a.Add(New ShippingBiz.TB_Permits(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_PermitsCollectionFromDataSet() As ShippingBiz.TB_PermitsCollection
			Dim TB_PermitsList() As DataRow = GetRows(DataSet, "TB_Permits")
			Dim a As New ShippingBiz.TB_PermitsCollection()
			Dim dr As DataRow

			For Each dr In TB_PermitsList
				a.Add(New ShippingBiz.TB_Permits(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_PInvoice(Description As System.String, _
			ByRef parentTB_InwardBLS As ShippingBiz.TB_InwardBLS) As ShippingBiz.TB_PInvoice
			Dim dr As DataRow = DataSet.Tables("TB_PInvoice").NewRow()
			DataSet.Tables("TB_PInvoice").Rows.Add(dr)
            Dim _TB_PInvoice As New ShippingBiz.TB_PInvoice(Me, dr)
            
			_TB_PInvoice.Description = Description
			_TB_PInvoice.TB_InwardBLS = parentTB_InwardBLS
            
            Return _TB_PInvoice
		End Function

		Public Function GetTB_PInvoice(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_PInvoice
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_PInvoice", relations), ds, false)
			
			Dim TB_PInvoiceRow As DataRow = GetRow(ds, "TB_PInvoice")
			
			If TB_PInvoiceRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_PInvoice(Me, TB_PInvoiceRow)
			
		End Function


		Public Function GetTB_PInvoiceFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_PInvoice
		
			Dim TB_PInvoiceRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_PInvoice").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_PInvoiceRow = dr
					Exit For
				End If
			Next

			If TB_PInvoiceRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_PInvoice(Me, TB_PInvoiceRow)
			
		End Function
		Public Function GetTB_PInvoiceCollection() As ShippingBiz.TB_PInvoiceCollection
			Return GetTB_PInvoiceCollection(FetchPath.TB_PInvoice)
		End Function

		Public Function GetTB_PInvoiceCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_PInvoiceCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_PInvoice", relations), ds, true)
			
			Dim TB_PInvoiceList() As DataRow = GetRows(ds, "TB_PInvoice")

			If TB_PInvoiceList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_PInvoiceCollection = New ShippingBiz.TB_PInvoiceCollection()

			Dim dr As DataRow
			For Each dr In TB_PInvoiceList
				a.Add(New ShippingBiz.TB_PInvoice(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_PInvoiceCollectionFromDataSet() As ShippingBiz.TB_PInvoiceCollection
			Dim TB_PInvoiceList() As DataRow = GetRows(DataSet, "TB_PInvoice")
			Dim a As New ShippingBiz.TB_PInvoiceCollection()
			Dim dr As DataRow

			For Each dr In TB_PInvoiceList
				a.Add(New ShippingBiz.TB_PInvoice(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_PInvoiceDetails(Seq As System.Data.SqlTypes.SqlInt16, _
			ChargesCode As System.String, _
			Remarks As System.String, _
			Currency As System.String, _
			Amount As System.Data.SqlTypes.SqlDouble, _
			ByRef parentTB_PInvoice As ShippingBiz.TB_PInvoice) As ShippingBiz.TB_PInvoiceDetails
			Dim dr As DataRow = DataSet.Tables("TB_PInvoiceDetails").NewRow()
			DataSet.Tables("TB_PInvoiceDetails").Rows.Add(dr)
            Dim _TB_PInvoiceDetails As New ShippingBiz.TB_PInvoiceDetails(Me, dr)
            
			_TB_PInvoiceDetails.Seq = Seq
			_TB_PInvoiceDetails.ChargesCode = ChargesCode
			_TB_PInvoiceDetails.Remarks = Remarks
			_TB_PInvoiceDetails.Currency = Currency
			_TB_PInvoiceDetails.Amount = Amount
			_TB_PInvoiceDetails.TB_PInvoice = parentTB_PInvoice
            
            Return _TB_PInvoiceDetails
		End Function

		Public Function GetTB_PInvoiceDetails(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_PInvoiceDetails
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_PInvoiceDetails", relations), ds, false)
			
			Dim TB_PInvoiceDetailsRow As DataRow = GetRow(ds, "TB_PInvoiceDetails")
			
			If TB_PInvoiceDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_PInvoiceDetails(Me, TB_PInvoiceDetailsRow)
			
		End Function


		Public Function GetTB_PInvoiceDetailsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_PInvoiceDetails
		
			Dim TB_PInvoiceDetailsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_PInvoiceDetails").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_PInvoiceDetailsRow = dr
					Exit For
				End If
			Next

			If TB_PInvoiceDetailsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_PInvoiceDetails(Me, TB_PInvoiceDetailsRow)
			
		End Function
		Public Function GetTB_PInvoiceDetailsCollection() As ShippingBiz.TB_PInvoiceDetailsCollection
			Return GetTB_PInvoiceDetailsCollection(FetchPath.TB_PInvoiceDetails)
		End Function

		Public Function GetTB_PInvoiceDetailsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_PInvoiceDetailsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_PInvoiceDetails", relations), ds, true)
			
			Dim TB_PInvoiceDetailsList() As DataRow = GetRows(ds, "TB_PInvoiceDetails")

			If TB_PInvoiceDetailsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_PInvoiceDetailsCollection = New ShippingBiz.TB_PInvoiceDetailsCollection()

			Dim dr As DataRow
			For Each dr In TB_PInvoiceDetailsList
				a.Add(New ShippingBiz.TB_PInvoiceDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_PInvoiceDetailsCollectionFromDataSet() As ShippingBiz.TB_PInvoiceDetailsCollection
			Dim TB_PInvoiceDetailsList() As DataRow = GetRows(DataSet, "TB_PInvoiceDetails")
			Dim a As New ShippingBiz.TB_PInvoiceDetailsCollection()
			Dim dr As DataRow

			For Each dr In TB_PInvoiceDetailsList
				a.Add(New ShippingBiz.TB_PInvoiceDetails(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Ports(PortCode As System.String, _
			PortName As System.String, _
			Country As System.String) As ShippingBiz.TB_Ports
			Dim dr As DataRow = DataSet.Tables("TB_Ports").NewRow()
			DataSet.Tables("TB_Ports").Rows.Add(dr)
            Dim _TB_Ports As New ShippingBiz.TB_Ports(Me, dr)
            
			_TB_Ports.PortCode = PortCode
			_TB_Ports.PortName = PortName
			_TB_Ports.Country = Country
            
            Return _TB_Ports
		End Function

		Public Function GetTB_Ports(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Ports
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Ports", relations), ds, false)
			
			Dim TB_PortsRow As DataRow = GetRow(ds, "TB_Ports")
			
			If TB_PortsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Ports(Me, TB_PortsRow)
			
		End Function


		Public Function GetTB_PortsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Ports
		
			Dim TB_PortsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Ports").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_PortsRow = dr
					Exit For
				End If
			Next

			If TB_PortsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Ports(Me, TB_PortsRow)
			
		End Function
		Public Function GetTB_PortsCollection() As ShippingBiz.TB_PortsCollection
			Return GetTB_PortsCollection(FetchPath.TB_Ports)
		End Function

		Public Function GetTB_PortsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_PortsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Ports", relations), ds, true)
			
			Dim TB_PortsList() As DataRow = GetRows(ds, "TB_Ports")

			If TB_PortsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_PortsCollection = New ShippingBiz.TB_PortsCollection()

			Dim dr As DataRow
			For Each dr In TB_PortsList
				a.Add(New ShippingBiz.TB_Ports(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_PortsCollectionFromDataSet() As ShippingBiz.TB_PortsCollection
			Dim TB_PortsList() As DataRow = GetRows(DataSet, "TB_Ports")
			Dim a As New ShippingBiz.TB_PortsCollection()
			Dim dr As DataRow

			For Each dr In TB_PortsList
				a.Add(New ShippingBiz.TB_Ports(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_RecivedItems(ID As System.Guid, _
			Seq As System.Data.SqlTypes.SqlInt16, _
			PaymentType As System.String, _
			Currency As System.String, _
			Amount As System.Data.SqlTypes.SqlDouble, _
			ByRef parentTB_Invoice As ShippingBiz.TB_Invoice) As ShippingBiz.TB_RecivedItems
			Dim dr As DataRow = DataSet.Tables("TB_RecivedItems").NewRow()
			DataSet.Tables("TB_RecivedItems").Rows.Add(dr)
            Dim _TB_RecivedItems As New ShippingBiz.TB_RecivedItems(Me, dr)
            
			_TB_RecivedItems.ID = ID
			_TB_RecivedItems.Seq = Seq
			_TB_RecivedItems.PaymentType = PaymentType
			_TB_RecivedItems.Currency = Currency
			_TB_RecivedItems.Amount = Amount
			_TB_RecivedItems.TB_Invoice = parentTB_Invoice
            
            Return _TB_RecivedItems
		End Function

		Public Function GetTB_RecivedItems(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_RecivedItems
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_RecivedItems", relations), ds, false)
			
			Dim TB_RecivedItemsRow As DataRow = GetRow(ds, "TB_RecivedItems")
			
			If TB_RecivedItemsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_RecivedItems(Me, TB_RecivedItemsRow)
			
		End Function


		Public Function GetTB_RecivedItemsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_RecivedItems
		
			Dim TB_RecivedItemsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_RecivedItems").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_RecivedItemsRow = dr
					Exit For
				End If
			Next

			If TB_RecivedItemsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_RecivedItems(Me, TB_RecivedItemsRow)
			
		End Function
		Public Function GetTB_RecivedItemsCollection() As ShippingBiz.TB_RecivedItemsCollection
			Return GetTB_RecivedItemsCollection(FetchPath.TB_RecivedItems)
		End Function

		Public Function GetTB_RecivedItemsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_RecivedItemsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_RecivedItems", relations), ds, true)
			
			Dim TB_RecivedItemsList() As DataRow = GetRows(ds, "TB_RecivedItems")

			If TB_RecivedItemsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_RecivedItemsCollection = New ShippingBiz.TB_RecivedItemsCollection()

			Dim dr As DataRow
			For Each dr In TB_RecivedItemsList
				a.Add(New ShippingBiz.TB_RecivedItems(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_RecivedItemsCollectionFromDataSet() As ShippingBiz.TB_RecivedItemsCollection
			Dim TB_RecivedItemsList() As DataRow = GetRows(DataSet, "TB_RecivedItems")
			Dim a As New ShippingBiz.TB_RecivedItemsCollection()
			Dim dr As DataRow

			For Each dr In TB_RecivedItemsList
				a.Add(New ShippingBiz.TB_RecivedItems(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Reference() As ShippingBiz.TB_Reference
			Dim dr As DataRow = DataSet.Tables("TB_Reference").NewRow()
			DataSet.Tables("TB_Reference").Rows.Add(dr)
            Dim _TB_Reference As New ShippingBiz.TB_Reference(Me, dr)
            

            
            Return _TB_Reference
		End Function

		Public Function GetTB_Reference(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Reference
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Reference", relations), ds, false)
			
			Dim TB_ReferenceRow As DataRow = GetRow(ds, "TB_Reference")
			
			If TB_ReferenceRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Reference(Me, TB_ReferenceRow)
			
		End Function


		Public Function GetTB_ReferenceFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Reference
		
			Dim TB_ReferenceRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Reference").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_ReferenceRow = dr
					Exit For
				End If
			Next

			If TB_ReferenceRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Reference(Me, TB_ReferenceRow)
			
		End Function
		Public Function GetTB_ReferenceCollection() As ShippingBiz.TB_ReferenceCollection
			Return GetTB_ReferenceCollection(FetchPath.TB_Reference)
		End Function

		Public Function GetTB_ReferenceCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ReferenceCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Reference", relations), ds, true)
			
			Dim TB_ReferenceList() As DataRow = GetRows(ds, "TB_Reference")

			If TB_ReferenceList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_ReferenceCollection = New ShippingBiz.TB_ReferenceCollection()

			Dim dr As DataRow
			For Each dr In TB_ReferenceList
				a.Add(New ShippingBiz.TB_Reference(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_ReferenceCollectionFromDataSet() As ShippingBiz.TB_ReferenceCollection
			Dim TB_ReferenceList() As DataRow = GetRows(DataSet, "TB_Reference")
			Dim a As New ShippingBiz.TB_ReferenceCollection()
			Dim dr As DataRow

			For Each dr In TB_ReferenceList
				a.Add(New ShippingBiz.TB_Reference(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_ReleaseLetterSeq() As ShippingBiz.TB_ReleaseLetterSeq
			Dim dr As DataRow = DataSet.Tables("TB_ReleaseLetterSeq").NewRow()
			DataSet.Tables("TB_ReleaseLetterSeq").Rows.Add(dr)
            Dim _TB_ReleaseLetterSeq As New ShippingBiz.TB_ReleaseLetterSeq(Me, dr)
            

            
            Return _TB_ReleaseLetterSeq
		End Function

		Public Function GetTB_ReleaseLetterSeq(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ReleaseLetterSeq
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_ReleaseLetterSeq", relations), ds, false)
			
			Dim TB_ReleaseLetterSeqRow As DataRow = GetRow(ds, "TB_ReleaseLetterSeq")
			
			If TB_ReleaseLetterSeqRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ReleaseLetterSeq(Me, TB_ReleaseLetterSeqRow)
			
		End Function


		Public Function GetTB_ReleaseLetterSeqFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_ReleaseLetterSeq
		
			Dim TB_ReleaseLetterSeqRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_ReleaseLetterSeq").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_ReleaseLetterSeqRow = dr
					Exit For
				End If
			Next

			If TB_ReleaseLetterSeqRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ReleaseLetterSeq(Me, TB_ReleaseLetterSeqRow)
			
		End Function
		Public Function GetTB_ReleaseLetterSeqCollection() As ShippingBiz.TB_ReleaseLetterSeqCollection
			Return GetTB_ReleaseLetterSeqCollection(FetchPath.TB_ReleaseLetterSeq)
		End Function

		Public Function GetTB_ReleaseLetterSeqCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ReleaseLetterSeqCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_ReleaseLetterSeq", relations), ds, true)
			
			Dim TB_ReleaseLetterSeqList() As DataRow = GetRows(ds, "TB_ReleaseLetterSeq")

			If TB_ReleaseLetterSeqList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_ReleaseLetterSeqCollection = New ShippingBiz.TB_ReleaseLetterSeqCollection()

			Dim dr As DataRow
			For Each dr In TB_ReleaseLetterSeqList
				a.Add(New ShippingBiz.TB_ReleaseLetterSeq(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_ReleaseLetterSeqCollectionFromDataSet() As ShippingBiz.TB_ReleaseLetterSeqCollection
			Dim TB_ReleaseLetterSeqList() As DataRow = GetRows(DataSet, "TB_ReleaseLetterSeq")
			Dim a As New ShippingBiz.TB_ReleaseLetterSeqCollection()
			Dim dr As DataRow

			For Each dr In TB_ReleaseLetterSeqList
				a.Add(New ShippingBiz.TB_ReleaseLetterSeq(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_ReportCustomFields(ReportName As System.String, _
			ReportFrindlyName As System.String, _
			FieldName As System.String, _
			FieldFriendlyName As System.String) As ShippingBiz.TB_ReportCustomFields
			Dim dr As DataRow = DataSet.Tables("TB_ReportCustomFields").NewRow()
			DataSet.Tables("TB_ReportCustomFields").Rows.Add(dr)
            Dim _TB_ReportCustomFields As New ShippingBiz.TB_ReportCustomFields(Me, dr)
            
			_TB_ReportCustomFields.ReportName = ReportName
			_TB_ReportCustomFields.ReportFrindlyName = ReportFrindlyName
			_TB_ReportCustomFields.FieldName = FieldName
			_TB_ReportCustomFields.FieldFriendlyName = FieldFriendlyName
            
            Return _TB_ReportCustomFields
		End Function

		Public Function GetTB_ReportCustomFields(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ReportCustomFields
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_ReportCustomFields", relations), ds, false)
			
			Dim TB_ReportCustomFieldsRow As DataRow = GetRow(ds, "TB_ReportCustomFields")
			
			If TB_ReportCustomFieldsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ReportCustomFields(Me, TB_ReportCustomFieldsRow)
			
		End Function


		Public Function GetTB_ReportCustomFieldsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_ReportCustomFields
		
			Dim TB_ReportCustomFieldsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_ReportCustomFields").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_ReportCustomFieldsRow = dr
					Exit For
				End If
			Next

			If TB_ReportCustomFieldsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_ReportCustomFields(Me, TB_ReportCustomFieldsRow)
			
		End Function
		Public Function GetTB_ReportCustomFieldsCollection() As ShippingBiz.TB_ReportCustomFieldsCollection
			Return GetTB_ReportCustomFieldsCollection(FetchPath.TB_ReportCustomFields)
		End Function

		Public Function GetTB_ReportCustomFieldsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_ReportCustomFieldsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_ReportCustomFields", relations), ds, true)
			
			Dim TB_ReportCustomFieldsList() As DataRow = GetRows(ds, "TB_ReportCustomFields")

			If TB_ReportCustomFieldsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_ReportCustomFieldsCollection = New ShippingBiz.TB_ReportCustomFieldsCollection()

			Dim dr As DataRow
			For Each dr In TB_ReportCustomFieldsList
				a.Add(New ShippingBiz.TB_ReportCustomFields(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_ReportCustomFieldsCollectionFromDataSet() As ShippingBiz.TB_ReportCustomFieldsCollection
			Dim TB_ReportCustomFieldsList() As DataRow = GetRows(DataSet, "TB_ReportCustomFields")
			Dim a As New ShippingBiz.TB_ReportCustomFieldsCollection()
			Dim dr As DataRow

			For Each dr In TB_ReportCustomFieldsList
				a.Add(New ShippingBiz.TB_ReportCustomFields(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_SCNIDS() As ShippingBiz.TB_SCNIDS
			Dim dr As DataRow = DataSet.Tables("TB_SCNIDS").NewRow()
			DataSet.Tables("TB_SCNIDS").Rows.Add(dr)
            Dim _TB_SCNIDS As New ShippingBiz.TB_SCNIDS(Me, dr)
            

            
            Return _TB_SCNIDS
		End Function

		Public Function GetTB_SCNIDS(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_SCNIDS
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_SCNIDS", relations), ds, false)
			
			Dim TB_SCNIDSRow As DataRow = GetRow(ds, "TB_SCNIDS")
			
			If TB_SCNIDSRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_SCNIDS(Me, TB_SCNIDSRow)
			
		End Function


		Public Function GetTB_SCNIDSFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_SCNIDS
		
			Dim TB_SCNIDSRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_SCNIDS").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_SCNIDSRow = dr
					Exit For
				End If
			Next

			If TB_SCNIDSRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_SCNIDS(Me, TB_SCNIDSRow)
			
		End Function
		Public Function GetTB_SCNIDSCollection() As ShippingBiz.TB_SCNIDSCollection
			Return GetTB_SCNIDSCollection(FetchPath.TB_SCNIDS)
		End Function

		Public Function GetTB_SCNIDSCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_SCNIDSCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_SCNIDS", relations), ds, true)
			
			Dim TB_SCNIDSList() As DataRow = GetRows(ds, "TB_SCNIDS")

			If TB_SCNIDSList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_SCNIDSCollection = New ShippingBiz.TB_SCNIDSCollection()

			Dim dr As DataRow
			For Each dr In TB_SCNIDSList
				a.Add(New ShippingBiz.TB_SCNIDS(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_SCNIDSCollectionFromDataSet() As ShippingBiz.TB_SCNIDSCollection
			Dim TB_SCNIDSList() As DataRow = GetRows(DataSet, "TB_SCNIDS")
			Dim a As New ShippingBiz.TB_SCNIDSCollection()
			Dim dr As DataRow

			For Each dr In TB_SCNIDSList
				a.Add(New ShippingBiz.TB_SCNIDS(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Seq(SeqType As System.String, _
			SeqYear As System.String, _
			Seq As System.Data.SqlTypes.SqlInt64) As ShippingBiz.TB_Seq
			Dim dr As DataRow = DataSet.Tables("TB_Seq").NewRow()
			DataSet.Tables("TB_Seq").Rows.Add(dr)
            Dim _TB_Seq As New ShippingBiz.TB_Seq(Me, dr)
            
			_TB_Seq.SeqType = SeqType
			_TB_Seq.SeqYear = SeqYear
			_TB_Seq.Seq = Seq
            
            Return _TB_Seq
		End Function

		Public Function GetTB_Seq(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Seq
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Seq", relations), ds, false)
			
			Dim TB_SeqRow As DataRow = GetRow(ds, "TB_Seq")
			
			If TB_SeqRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Seq(Me, TB_SeqRow)
			
		End Function


		Public Function GetTB_SeqFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Seq
		
			Dim TB_SeqRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Seq").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_SeqRow = dr
					Exit For
				End If
			Next

			If TB_SeqRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Seq(Me, TB_SeqRow)
			
		End Function
		Public Function GetTB_SeqCollection() As ShippingBiz.TB_SeqCollection
			Return GetTB_SeqCollection(FetchPath.TB_Seq)
		End Function

		Public Function GetTB_SeqCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_SeqCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Seq", relations), ds, true)
			
			Dim TB_SeqList() As DataRow = GetRows(ds, "TB_Seq")

			If TB_SeqList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_SeqCollection = New ShippingBiz.TB_SeqCollection()

			Dim dr As DataRow
			For Each dr In TB_SeqList
				a.Add(New ShippingBiz.TB_Seq(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_SeqCollectionFromDataSet() As ShippingBiz.TB_SeqCollection
			Dim TB_SeqList() As DataRow = GetRows(DataSet, "TB_Seq")
			Dim a As New ShippingBiz.TB_SeqCollection()
			Dim dr As DataRow

			For Each dr In TB_SeqList
				a.Add(New ShippingBiz.TB_Seq(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_SOF(Port As System.String, _
			ByRef parentTB_Voyage As ShippingBiz.TB_Voyage) As ShippingBiz.TB_SOF
			Dim dr As DataRow = DataSet.Tables("TB_SOF").NewRow()
			DataSet.Tables("TB_SOF").Rows.Add(dr)
            Dim _TB_SOF As New ShippingBiz.TB_SOF(Me, dr)
            
			_TB_SOF.Port = Port
			_TB_SOF.TB_Voyage = parentTB_Voyage
            
            Return _TB_SOF
		End Function

		Public Function GetTB_SOF(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_SOF
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_SOF", relations), ds, false)
			
			Dim TB_SOFRow As DataRow = GetRow(ds, "TB_SOF")
			
			If TB_SOFRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_SOF(Me, TB_SOFRow)
			
		End Function


		Public Function GetTB_SOFFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_SOF
		
			Dim TB_SOFRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_SOF").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_SOFRow = dr
					Exit For
				End If
			Next

			If TB_SOFRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_SOF(Me, TB_SOFRow)
			
		End Function
		Public Function GetTB_SOFCollection() As ShippingBiz.TB_SOFCollection
			Return GetTB_SOFCollection(FetchPath.TB_SOF)
		End Function

		Public Function GetTB_SOFCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_SOFCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_SOF", relations), ds, true)
			
			Dim TB_SOFList() As DataRow = GetRows(ds, "TB_SOF")

			If TB_SOFList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_SOFCollection = New ShippingBiz.TB_SOFCollection()

			Dim dr As DataRow
			For Each dr In TB_SOFList
				a.Add(New ShippingBiz.TB_SOF(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_SOFCollectionFromDataSet() As ShippingBiz.TB_SOFCollection
			Dim TB_SOFList() As DataRow = GetRows(DataSet, "TB_SOF")
			Dim a As New ShippingBiz.TB_SOFCollection()
			Dim dr As DataRow

			For Each dr In TB_SOFList
				a.Add(New ShippingBiz.TB_SOF(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_TaxBase(ChargesCode As System.String, _
			ApplyDate As System.Data.SqlTypes.SqlDateTime, _
			validity As System.Data.SqlTypes.SqlDateTime, _
			Port As System.String, _
			Tax As System.Data.SqlTypes.SqlDecimal, _
			TOLL As System.Data.SqlTypes.SqlDecimal) As ShippingBiz.TB_TaxBase
			Dim dr As DataRow = DataSet.Tables("TB_TaxBase").NewRow()
			DataSet.Tables("TB_TaxBase").Rows.Add(dr)
            Dim _TB_TaxBase As New ShippingBiz.TB_TaxBase(Me, dr)
            
			_TB_TaxBase.ChargesCode = ChargesCode
			_TB_TaxBase.ApplyDate = ApplyDate
			_TB_TaxBase.validity = validity
			_TB_TaxBase.Port = Port
			_TB_TaxBase.Tax = Tax
			_TB_TaxBase.TOLL = TOLL
            
            Return _TB_TaxBase
		End Function

		Public Function GetTB_TaxBase(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_TaxBase
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_TaxBase", relations), ds, false)
			
			Dim TB_TaxBaseRow As DataRow = GetRow(ds, "TB_TaxBase")
			
			If TB_TaxBaseRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_TaxBase(Me, TB_TaxBaseRow)
			
		End Function


		Public Function GetTB_TaxBaseFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_TaxBase
		
			Dim TB_TaxBaseRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_TaxBase").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_TaxBaseRow = dr
					Exit For
				End If
			Next

			If TB_TaxBaseRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_TaxBase(Me, TB_TaxBaseRow)
			
		End Function
		Public Function GetTB_TaxBaseCollection() As ShippingBiz.TB_TaxBaseCollection
			Return GetTB_TaxBaseCollection(FetchPath.TB_TaxBase)
		End Function

		Public Function GetTB_TaxBaseCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_TaxBaseCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_TaxBase", relations), ds, true)
			
			Dim TB_TaxBaseList() As DataRow = GetRows(ds, "TB_TaxBase")

			If TB_TaxBaseList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_TaxBaseCollection = New ShippingBiz.TB_TaxBaseCollection()

			Dim dr As DataRow
			For Each dr In TB_TaxBaseList
				a.Add(New ShippingBiz.TB_TaxBase(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_TaxBaseCollectionFromDataSet() As ShippingBiz.TB_TaxBaseCollection
			Dim TB_TaxBaseList() As DataRow = GetRows(DataSet, "TB_TaxBase")
			Dim a As New ShippingBiz.TB_TaxBaseCollection()
			Dim dr As DataRow

			For Each dr In TB_TaxBaseList
				a.Add(New ShippingBiz.TB_TaxBase(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Users(UserFirstName As System.String, _
			UserLastName As System.String, _
			UserAccount As System.String, _
			UserCode As System.String, _
			Password As System.String) As ShippingBiz.TB_Users
			Dim dr As DataRow = DataSet.Tables("TB_Users").NewRow()
			DataSet.Tables("TB_Users").Rows.Add(dr)
            Dim _TB_Users As New ShippingBiz.TB_Users(Me, dr)
            
			_TB_Users.UserFirstName = UserFirstName
			_TB_Users.UserLastName = UserLastName
			_TB_Users.UserAccount = UserAccount
			_TB_Users.UserCode = UserCode
			_TB_Users.Password = Password
            
            Return _TB_Users
		End Function

		Public Function GetTB_Users(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Users
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Users", relations), ds, false)
			
			Dim TB_UsersRow As DataRow = GetRow(ds, "TB_Users")
			
			If TB_UsersRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Users(Me, TB_UsersRow)
			
		End Function


		Public Function GetTB_UsersFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Users
		
			Dim TB_UsersRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Users").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_UsersRow = dr
					Exit For
				End If
			Next

			If TB_UsersRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Users(Me, TB_UsersRow)
			
		End Function
		Public Function GetTB_UsersCollection() As ShippingBiz.TB_UsersCollection
			Return GetTB_UsersCollection(FetchPath.TB_Users)
		End Function

		Public Function GetTB_UsersCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_UsersCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Users", relations), ds, true)
			
			Dim TB_UsersList() As DataRow = GetRows(ds, "TB_Users")

			If TB_UsersList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_UsersCollection = New ShippingBiz.TB_UsersCollection()

			Dim dr As DataRow
			For Each dr In TB_UsersList
				a.Add(New ShippingBiz.TB_Users(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_UsersCollectionFromDataSet() As ShippingBiz.TB_UsersCollection
			Dim TB_UsersList() As DataRow = GetRows(DataSet, "TB_Users")
			Dim a As New ShippingBiz.TB_UsersCollection()
			Dim dr As DataRow

			For Each dr In TB_UsersList
				a.Add(New ShippingBiz.TB_Users(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_UsersDept(ID As System.Guid, _
			UserID As System.Guid, _
			Department As System.String) As ShippingBiz.TB_UsersDept
			Dim dr As DataRow = DataSet.Tables("TB_UsersDept").NewRow()
			DataSet.Tables("TB_UsersDept").Rows.Add(dr)
            Dim _TB_UsersDept As New ShippingBiz.TB_UsersDept(Me, dr)
            
			_TB_UsersDept.ID = ID
			_TB_UsersDept.UserID = UserID
			_TB_UsersDept.Department = Department
            
            Return _TB_UsersDept
		End Function

		Public Function GetTB_UsersDept(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_UsersDept
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_UsersDept", relations), ds, false)
			
			Dim TB_UsersDeptRow As DataRow = GetRow(ds, "TB_UsersDept")
			
			If TB_UsersDeptRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_UsersDept(Me, TB_UsersDeptRow)
			
		End Function


		Public Function GetTB_UsersDeptFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_UsersDept
		
			Dim TB_UsersDeptRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_UsersDept").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_UsersDeptRow = dr
					Exit For
				End If
			Next

			If TB_UsersDeptRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_UsersDept(Me, TB_UsersDeptRow)
			
		End Function
		Public Function GetTB_UsersDeptCollection() As ShippingBiz.TB_UsersDeptCollection
			Return GetTB_UsersDeptCollection(FetchPath.TB_UsersDept)
		End Function

		Public Function GetTB_UsersDeptCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_UsersDeptCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_UsersDept", relations), ds, true)
			
			Dim TB_UsersDeptList() As DataRow = GetRows(ds, "TB_UsersDept")

			If TB_UsersDeptList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_UsersDeptCollection = New ShippingBiz.TB_UsersDeptCollection()

			Dim dr As DataRow
			For Each dr In TB_UsersDeptList
				a.Add(New ShippingBiz.TB_UsersDept(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_UsersDeptCollectionFromDataSet() As ShippingBiz.TB_UsersDeptCollection
			Dim TB_UsersDeptList() As DataRow = GetRows(DataSet, "TB_UsersDept")
			Dim a As New ShippingBiz.TB_UsersDeptCollection()
			Dim dr As DataRow

			For Each dr In TB_UsersDeptList
				a.Add(New ShippingBiz.TB_UsersDept(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_UsersLine(UserID As System.Guid, _
			Line As System.String) As ShippingBiz.TB_UsersLine
			Dim dr As DataRow = DataSet.Tables("TB_UsersLine").NewRow()
			DataSet.Tables("TB_UsersLine").Rows.Add(dr)
            Dim _TB_UsersLine As New ShippingBiz.TB_UsersLine(Me, dr)
            
			_TB_UsersLine.UserID = UserID
			_TB_UsersLine.Line = Line
            
            Return _TB_UsersLine
		End Function

		Public Function GetTB_UsersLine(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_UsersLine
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_UsersLine", relations), ds, false)
			
			Dim TB_UsersLineRow As DataRow = GetRow(ds, "TB_UsersLine")
			
			If TB_UsersLineRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_UsersLine(Me, TB_UsersLineRow)
			
		End Function


		Public Function GetTB_UsersLineFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_UsersLine
		
			Dim TB_UsersLineRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_UsersLine").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_UsersLineRow = dr
					Exit For
				End If
			Next

			If TB_UsersLineRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_UsersLine(Me, TB_UsersLineRow)
			
		End Function
		Public Function GetTB_UsersLineCollection() As ShippingBiz.TB_UsersLineCollection
			Return GetTB_UsersLineCollection(FetchPath.TB_UsersLine)
		End Function

		Public Function GetTB_UsersLineCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_UsersLineCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_UsersLine", relations), ds, true)
			
			Dim TB_UsersLineList() As DataRow = GetRows(ds, "TB_UsersLine")

			If TB_UsersLineList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_UsersLineCollection = New ShippingBiz.TB_UsersLineCollection()

			Dim dr As DataRow
			For Each dr In TB_UsersLineList
				a.Add(New ShippingBiz.TB_UsersLine(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_UsersLineCollectionFromDataSet() As ShippingBiz.TB_UsersLineCollection
			Dim TB_UsersLineList() As DataRow = GetRows(DataSet, "TB_UsersLine")
			Dim a As New ShippingBiz.TB_UsersLineCollection()
			Dim dr As DataRow

			For Each dr In TB_UsersLineList
				a.Add(New ShippingBiz.TB_UsersLine(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Vessels(VesselCode As System.String, _
			VesselName As System.String) As ShippingBiz.TB_Vessels
			Dim dr As DataRow = DataSet.Tables("TB_Vessels").NewRow()
			DataSet.Tables("TB_Vessels").Rows.Add(dr)
            Dim _TB_Vessels As New ShippingBiz.TB_Vessels(Me, dr)
            
			_TB_Vessels.VesselCode = VesselCode
			_TB_Vessels.VesselName = VesselName
            
            Return _TB_Vessels
		End Function

		Public Function GetTB_Vessels(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Vessels
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Vessels", relations), ds, false)
			
			Dim TB_VesselsRow As DataRow = GetRow(ds, "TB_Vessels")
			
			If TB_VesselsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Vessels(Me, TB_VesselsRow)
			
		End Function


		Public Function GetTB_VesselsFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Vessels
		
			Dim TB_VesselsRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Vessels").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_VesselsRow = dr
					Exit For
				End If
			Next

			If TB_VesselsRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Vessels(Me, TB_VesselsRow)
			
		End Function
		Public Function GetTB_VesselsCollection() As ShippingBiz.TB_VesselsCollection
			Return GetTB_VesselsCollection(FetchPath.TB_Vessels)
		End Function

		Public Function GetTB_VesselsCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_VesselsCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Vessels", relations), ds, true)
			
			Dim TB_VesselsList() As DataRow = GetRows(ds, "TB_Vessels")

			If TB_VesselsList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_VesselsCollection = New ShippingBiz.TB_VesselsCollection()

			Dim dr As DataRow
			For Each dr In TB_VesselsList
				a.Add(New ShippingBiz.TB_Vessels(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_VesselsCollectionFromDataSet() As ShippingBiz.TB_VesselsCollection
			Dim TB_VesselsList() As DataRow = GetRows(DataSet, "TB_Vessels")
			Dim a As New ShippingBiz.TB_VesselsCollection()
			Dim dr As DataRow

			For Each dr In TB_VesselsList
				a.Add(New ShippingBiz.TB_Vessels(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function

		Public Function NewTB_Voyage(VoyageNo As System.String, _
			Carrier As System.String, _
			StartDate As System.Data.SqlTypes.SqlDateTime, _
			ByRef parentTB_Vessels As ShippingBiz.TB_Vessels) As ShippingBiz.TB_Voyage
			Dim dr As DataRow = DataSet.Tables("TB_Voyage").NewRow()
			DataSet.Tables("TB_Voyage").Rows.Add(dr)
            Dim _TB_Voyage As New ShippingBiz.TB_Voyage(Me, dr)
            
			_TB_Voyage.VoyageNo = VoyageNo
			_TB_Voyage.Carrier = Carrier
			_TB_Voyage.StartDate = StartDate
			_TB_Voyage.TB_Vessels = parentTB_Vessels
            
            Return _TB_Voyage
		End Function

		Public Function GetTB_Voyage(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_Voyage
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			FillDataSet(CreateSql("TB_Voyage", relations), ds, false)
			
			Dim TB_VoyageRow As DataRow = GetRow(ds, "TB_Voyage")
			
			If TB_VoyageRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Voyage(Me, TB_VoyageRow)
			
		End Function


		Public Function GetTB_VoyageFromDataSet(ByVal ID As System.Guid) As ShippingBiz.TB_Voyage
		
			Dim TB_VoyageRow As DataRow = Nothing
			Dim dr As DataRow

			For Each dr In DataSet.Tables("TB_Voyage").Rows
				If (CType(dr("ID"), System.Guid)).ToString() = ID.ToString() Then
					TB_VoyageRow = dr
					Exit For
				End If
			Next

			If TB_VoyageRow Is Nothing Then Return Nothing
			Return New ShippingBiz.TB_Voyage(Me, TB_VoyageRow)
			
		End Function
		Public Function GetTB_VoyageCollection() As ShippingBiz.TB_VoyageCollection
			Return GetTB_VoyageCollection(FetchPath.TB_Voyage)
		End Function

		Public Function GetTB_VoyageCollection(ByVal ParamArray relations() As DataManagerBase.FetchPathRelation) As ShippingBiz.TB_VoyageCollection
		
			Dim ds As DataSet = OrmDataSet.NewDataSet()
			
			FillDataSet(CreateSql("TB_Voyage", relations), ds, true)
			
			Dim TB_VoyageList() As DataRow = GetRows(ds, "TB_Voyage")

			If TB_VoyageList Is Nothing Then Return Nothing

			Dim a As ShippingBiz.TB_VoyageCollection = New ShippingBiz.TB_VoyageCollection()

			Dim dr As DataRow
			For Each dr In TB_VoyageList
				a.Add(New ShippingBiz.TB_Voyage(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
			
		End Function

		Public Function GetTB_VoyageCollectionFromDataSet() As ShippingBiz.TB_VoyageCollection
			Dim TB_VoyageList() As DataRow = GetRows(DataSet, "TB_Voyage")
			Dim a As New ShippingBiz.TB_VoyageCollection()
			Dim dr As DataRow

			For Each dr In TB_VoyageList
				a.Add(New ShippingBiz.TB_Voyage(Me, dr))
			Next

			' must be added afterwards
			a.DataManager = Me

			Return a
		End Function


    End Class
End Namespace