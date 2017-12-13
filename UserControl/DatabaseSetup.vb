Imports System
Imports System.Configuration
Imports System.Data.Common
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.VisualStudio.TeamSystem.Data.UnitTesting

<TestClass()> _
Public Class DatabaseSetup

    <AssemblyInitialize()> _
    Public Shared Sub InitializeAssembly(ByVal ctx As TestContext)
        ' 根據組態檔中的設定來設定
        ' 測試資料庫
        DatabaseTestClass.TestService.DeployDatabaseProject()
        DatabaseTestClass.TestService.GenerateData()
    End Sub

End Class
