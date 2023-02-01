# DealerOnTest

This is an implementation of the Sales Tax prompt from the perspective of building an API. The user will send a Postman request to the API, and it will spit out a JSON formatted answer. To this end, it is assumed that the input data has been standardized in a way that the API can consume it (via the attached Postman collection).

The core of this implementation is the TaxDecorator abstract class, which wraps each product with as many TaxDecorator subclasses as required. Each subclass has the ability to apply a separate tax rate. The total is then returned from the GetPrice method, along with an out parameter to keep track of the tax amount.

![image](https://user-images.githubusercontent.com/43661059/216128632-b7cb1f1d-c38a-4b87-b0c8-b354dab78911.png)


VS Code Commands:
dotnet restore
dotnet run Program.cs

VS:
\Restore Nuget packages
\Run program

Postman

[![Run in Postman](https://run.pstmn.io/button.svg)](https://app.getpostman.com/run-collection/7428663-ae4fc273-9b93-4c52-999c-7e1e87ed3c4c?action=collection%2Ffork&collection-url=entityId%3D7428663-ae4fc273-9b93-4c52-999c-7e1e87ed3c4c%26entityType%3Dcollection%26workspaceId%3Daa99e921-248f-480f-8f24-46181bf82a7a)

Click the button above and import a copy of the collection to your Postman desktop app.
