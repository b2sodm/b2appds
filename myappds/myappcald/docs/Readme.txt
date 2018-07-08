
The system starts at Index.aspx.
The first time user can click Sign up.
Fill up his/her details and click Register(SignUp).

Users can start at Index.aspx, and click on the menu / list.

The system uses database.
The program uses sql connection.
The program uses MSSQL or SQLEXPRESS
Data base settings at models/DbSetting. 

Other settings at \myappds\.vs\config.

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