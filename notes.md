# Azure App Service Talk

## Chapters
1. 10' Intro: PaaS story, Integration story, build on Azure Websites (now Web Apps)
2. 10' Web Apps, GitHub Deployments in New Portal, Portal updates, Azure API Explorer
3. 10' API App Marketplace, Lego for integrators, PaaS story (upgrades)
4. 10' Hello Logic Apps, API, Scripted Deployment
5. 10' Build your own API App
6. 10' Outro

-------------------------------------------------------------------------------
## Hello Logic Apps

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
4. body = 
    {
        "name" : "DansApiTrigger",
        "outputs" : { "property" : "value" }
    }

* Demo manual trigger

* Demo scripted creation via API/Powershell?
 * Logic App Workflow Management API - https://msdn.microsoft.com/en-us/library/azure/dn948513.aspx
-------------------------------------------------------------------------------


## Points to cover
* Australia Geo not supported yet


## Questions
* Any changes for Mobile Apps?
* Are API Connector Apps OSS?
* Where/how do Web Roles / Worker Roles fit in?
* What is a Gateway App?


## Links and references
* Azure API explorer https://resources.azure.com/subscriptions/036c9926-0ea1-4d2e-bff0-321e7e6f96e1/resourceGroups/Sydney/providers/Microsoft.Web/sites/jukebox30
* Review by an Integrator: http://www.codit.eu/blog/2015/03/24/welcome-azure-app-service-some-of-my-thoughts/
* Hello Logic Apps: http://azure.microsoft.com/en-us/documentation/articles/app-service-logic-create-a-logic-app/
* http://blogs.msdn.com/b/webdev/archive/2015/03/24/introducing-azure-api-apps.aspx
* http://azure.microsoft.com/en-us/documentation/articles/app-service-api-apps-why-best-platform/
* http://azure.microsoft.com/en-us/documentation/articles/app-service-dotnet-create-api-app/
* http://requestb.in/ovs9phov?inspect