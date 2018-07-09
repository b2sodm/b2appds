
/////////////////////////////
//    Readme.txt
/////////////////////////////



The system starts at Index.aspx.
The first time user can click Sign up.
Fill up his/her details and click Register(SignUp).

Users can start at Index.aspx, and click on the menu / list.

The system uses database.
The program uses sql connection.
The program uses MSSQL or SQLEXPRESS.
Data base settings at models/DbSetting. 

Other settings at \myappds\.vs\config or at applicationhost.config.

<!--
    IIS configuration sections.

    For schema documentation, see
    %IIS_BIN%\config\schema\IIS_schema.xml.
    
    Please make a backup of this file before making any changes to it.

    NOTE: The following environment variables are available to be used
          within this file and are understood by the IIS Express.

          %IIS_USER_HOME% - The IIS Express home directory for the user
          %IIS_SITES_HOME% - The default home directory for sites
          %IIS_BIN% - The location of the IIS Express binaries
          %SYSTEMDRIVE% - The drive letter of %IIS_BIN%
-->
<configuration>
    <!--
        The <configSections> section controls the registration of sections.
        Section is the basic unit of deployment, locking, searching and
        containment for configuration settings.
        
        Every section belongs to one section group.
        A section group is a container of logically-related sections.
        
        Sections cannot be nested.
        Section groups may be nested.
        
        <section
            name=""  [Required, Collection Key] [XML name of the section]
            allowDefinition="Everywhere" [MachineOnly|MachineToApplication|AppHostOnly|Everywhere] [Level where it can be set]
            overrideModeDefault="Allow"  [Allow|Deny] [Default delegation mode]
            allowLocation="true"  [true|false] [Allowed in location tags]
        />
        
        The recommended way to unlock sections is by using a location tag:
        <location path="Default Web Site" overrideMode="Allow">
            <system.webServer>
                <asp />
            </system.webServer>
        </location>

    -->

	<system.applicationHost>
        
        <sites>
            <site name="WebSite1" id="1" serverAutoStart="true">
                <application path="/">
                    <virtualDirectory path="/" physicalPath="%IIS_SITES_HOME%\WebSite1" />
                </application>
                <bindings>
                    <binding protocol="http" bindingInformation=":8080:localhost" />
                </bindings>
            </site>
            <site name="myappds" id="2">
                <application path="/" applicationPool="Clr4IntegratedAppPool">
                    <virtualDirectory path="/" physicalPath="C:\Users\UserName\Documents\My Web Sites\WebSite1\myappds\myappds" />
                </application>
                <bindings>
                    <binding protocol="http" bindingInformation="*:49167:localhost" />
                </bindings>
            </site>
            <site name="myappcald" id="3">
                <application path="/" applicationPool="Clr4IntegratedAppPool">
                    <virtualDirectory path="/" physicalPath="C:\Users\UserName\Documents\My Web Sites\WebSite1\myappds\myappcald" />
                </application>
                <bindings>
                    <binding protocol="http" bindingInformation="*:49368:localhost" />
                </bindings>
            </site>
            <siteDefaults>
                <logFile logFormat="W3C" directory="%IIS_USER_HOME%\Logs" />
                <traceFailedRequestsLogging directory="%IIS_USER_HOME%\TraceLogFiles" enabled="true" maxLogFileSizeKB="1024" />
            </siteDefaults>
            <applicationDefaults applicationPool="Clr4IntegratedAppPool" />
            <virtualDirectoryDefaults allowSubDirConfig="true" />
        </sites>

        <webLimits />

    </system.applicationHost>

    <system.webServer>

        <defaultDocument enabled="true">
            <files>
                <add value="Default.htm" />
                <add value="Default.asp" />
                <add value="index.htm" />
                <add value="index.html" />
                <add value="iisstart.htm" />
                <add value="default.aspx" />
            </files>
        </defaultDocument>

        <directoryBrowse enabled="true" />

    </system.webServer>
    
</configuration>

////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//    Enjoy!
//
//////////////////////////////////////////////
