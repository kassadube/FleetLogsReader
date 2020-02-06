<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
  </startup>
  <connectionStrings>
    <!--<add name="DefaultConnection" connectionString="Data Source=(LocalDb)\v11.0;Initial Catalog=logData;Integrated Security=SSPI;AttachDBFilename=c:\users\noams\documents\visual studio 2013\Projects\FleetLogsReader\UnitTestLogReader\Data\logDataPSA.mdf" providerName="System.Data.SqlClient" />-->
    <add name="DefaultConnection" connectionString="Data Source=207.232.46.176;Initial Catalog=LogDataQA;User ID=sa;Password=Aa111111" providerName="System.Data.SqlClient" />
  </connectionStrings>
  <appSettings>
    <add key="DAYS" value="1"/>
    <add key="SITE_DIR" value="C:\inetpub\wwwroot\FleetLogs"/>
    <add key="SITE_LOG_DIR" value="\\10.169.1.20\c$\inetpub\wwwroot\fleet\Logs"/>
    <add key="DIR" value="C:\asp.net\FleetLogsReader\UnitTestLogReader\Data\Logs\QA\Logs"/>
    <add key="LOG_DIR" value="C:\asp.net\FleetLogsReader\UnitTestLogReader\Data\QA\Archive"/>
    <add key="ARCHIVE_DIR" value="C:\asp.net\FleetLogsReader\UnitTestLogReader\Data\Logs\QA\rar"/>
  </appSettings>
  <system.net>
    <mailSettings>
      <smtp from="PointerFleet@pointer.com">
        <network host="207.232.46.10" port="25" userName="name" password="secret" defaultCredentials="true" />
      </smtp>
    </mailSettings>
  </system.net>
</configuration>