## Requirments(instalation):
1. [VS Community 2019](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16)
> Install C# and database with SQL server. 

2. [SQL SERVER Developer](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).
> Follow tutorial (https://phoenixnap.com/kb/install-sql-express) for a custom install. Is SQL EXPRESS, But the steps are the same.
If you choice the `basic mode` on installation, the user `sa` will not be active. You have to make additional changes:
	- enable user `sa`
	- enable Mixed Mode authentication
	- change password for user `sa`
	- restart the SqlServer service

3. [SSMS](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15).

## FIRST USE
1. Change connection string
In` AplicatieDemo_WebForms>InterfataUtilizator_WinForms>app.config` change connection string with yours. (Data Source; Password;) You can get these data from `SSMS`.

```XML
<add key="StringConectareBD" value="Data Source=DESKTOP-94046MR\SQLEXPRESS;Initial Catalog=DemoWeb;User ID=sa;Password=teo123;"/>
```
2. Restore demo database
Open SSMS -> Right click on `Databases`. `Restore database...`.On `Source` choose DB from `Device`. In select `Select backup device` choose `Add`, then the database backup file(**DemoWeb.bak**) and click `ok`.
3. Set as Startup Project the project `InterfataUtilizator_WinForms` using right click on the project name and select option `Set as Startup Project`
4. Rebuld `AplicatieDemo_WebForms` and run project. If everything is ok the data from DB will be loaded and displayed in the first form.



## Troubleshooting
1. Exception on line 50 (new SqlDataAdapter(cmd).Fill(ds);) in SqlDBHelper
```
	A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: Named Pipes Provider, error: 40 - Could not open a connection to SQL Server)"}	System.Data.SqlClient.SqlException
```
// The connection string is wrong. Test it in SSMS.


2. Exception on line 50 (new SqlDataAdapter(cmd).Fill(ds);) in SqlDBHelper
```
    Cannot open database \"DemoWeb\" requested by the login. The login failed.\r\nLogin failed for user 'sa'."}	System.Data.SqlClient.SqlException
```
// The database might not be restored from file **DemoWeb.bak** in SSMS.

3. Exception on running the project `InterfataUtilizator_WebForms`
```
Could not find a part of the path 'E:\...\AplicatieDemo_WebForms\AplicatieDemo_ArhitecturiMultiTier\InterfataUtilizator_WebForms\bin\roslyn\csc.exe'.
```

//Run this in the Package Manager Console:

//Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r