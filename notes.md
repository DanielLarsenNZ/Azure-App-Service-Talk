# Azure App Service Talk

## Chapters
1. 10' Intro: PaaS story, Integration story, built on Azure Websites (now Web Apps)
2. 10' Web Apps, Mobile Apps, GitHub Deployments in New Portal, Portal updates, Azure API Explorer
3. 10' API App Marketplace, Lego for integrators, PaaS story (upgrades)
4. 10' Hello Logic Apps, API, Scripted Deployment
5. 10' Build your own API App
6. 10' Outro


## 2. Web Apps, Mobile Apps, GitHub Deployments in New Portal, Portal updates, Azure API Explorer

* New in Mobile Apps: 
 * Integration with on-premise resources (like SQL Server) via Hybrid Connection Manager.
 * Integration with SaaS systems (via API Apps Services and Connectors). 
 * Staging slots
 * WebJobs
 * Better scaling options, and more.

-------------------------------------------------------------------------------
## 3. API App Marketplace, Lego for integrators, PaaS story

* Compose connectors and API Apps into a Business Process.
 * a la WCF LOB Connectors
* away from strong typing.
* mulesoft connectors - mullet pattern - business up front, party in the back.
* encapsulating complexity
* yellow pages, nz post, xero

* Upgrades

-------------------------------------------------------------------------------
## 4. Hello Logic Apps, API, Scripted Deployment

### Demo - Simple Logic App
1. Create OneDrive Connector
1. Create Logic App
1. Add Recurrence
1. Add OneDrive
1. Add HTTP, POST -> http://requestb.in/ovs9phov

### Demo - API Trigger
http://azure.microsoft.com/en-us/documentation/articles/app-service-logic-use-logic-app-features/
1. Copy Endpoint URL -> Postman
2. Postman - Basic auth, default:{Primary Access Key}
3. Content-Type: application/json
4. /run?api-version=2015-02-01-preview
4. body = 
    {
        "name" : "DansApiTrigger",
        "outputs" : { "property" : "value" }
    }

* Demo manual trigger

* Demo scripted creation via API/Powershell?
 * Logic App Workflow Management API - https://msdn.microsoft.com/en-us/library/azure/dn948513.aspx
 * Logic App Workflow Definition Language - https://msdn.microsoft.com/en-us/library/azure/dn948512.aspx
-------------------------------------------------------------------------------


## Build your own API App
* Swagger is the service definition (Like WSDL for REST) to create pluggable interfaces
* JSON is the data format
* Apparently you can use also use Java, PHP, Node.js, or Python for your API Apps - I have not seen examples yet.


http://azure.microsoft.com/en-us/documentation/articles/app-service-dotnet-create-api-app-visual-studio/
http://azure.microsoft.com/en-us/documentation/articles/app-service-dotnet-deploy-api-app/

-------------------------------------------------------------------------------


## Key Points to cover
* Australia Geo not supported yet
* You can connect to on-premise resources like SQL Server with a Hybrid Connection.
* You need to upgrade to Azure SDK 2.5.1.
* Error Responses appear to be swallowed with "an error has occurred". I return my own 500 response with a message.



## Questions
* Any changes for Mobile Apps?
* Are API Connector Apps OSS?
* Where/how do Web Roles / Worker Roles fit in?
* What is a Gateway App?


## Fact check
* Resource Group = VM? Affinity?




## Links and references
* Azure App Service Launch: https://channel9.msdn.com/Events/Microsoft-Azure/Scott-Guthrie-March-24-2015-Announcement/Azure-App-Service-announcement
* This is the best summary of App Service that I have read: http://www.infoworld.com/article/2904348/application-development/first-look-microsoft-azure-app-services-cloud-development.html
* Azure API explorer https://resources.azure.com/subscriptions/036c9926-0ea1-4d2e-bff0-321e7e6f96e1/resourceGroups/Sydney/providers/Microsoft.Web/sites/jukebox30

* Reviews: 
 * http://www.codit.eu/blog/2015/03/24/welcome-azure-app-service-some-of-my-thoughts/
 * http://www.quicklearn.com/blog/2015/03/24/azure-app-service-biztalk-server-paas-done-right/
* Hello Logic Apps: http://azure.microsoft.com/en-us/documentation/articles/app-service-logic-create-a-logic-app/
* http://blogs.msdn.com/b/webdev/archive/2015/03/24/introducing-azure-api-apps.aspx
* http://azure.microsoft.com/en-us/documentation/articles/app-service-api-apps-why-best-platform/
* http://azure.microsoft.com/en-us/documentation/articles/app-service-dotnet-create-api-app/

* http://blogs.biztalk360.com/azure-api-app-and-logic-app-in-depth-look-into-hybrid-connector-marriage-between-cloud-and-on-premise/
* http://azure.microsoft.com/en-in/documentation/articles/app-service-logic-connector-pop3/
* http://azure.microsoft.com/en-us/documentation/articles/app-service-logic-connector-azurestorageblob/
* http://azure.microsoft.com/en-gb/documentation/articles/app-service-logic-use-logic-app-features/

## Demos
1. Read image from OneDrive, hit endpoint
1. Read image from Email attachments, save to Storage, hit endpoint
1. Read image from Email attachment, resize, save to Storage, hit endpoint