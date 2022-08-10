# Secure and protect a ASP.NET Web App against SQL Injection

This repository demonstrates how to build a ASP.NET Web application secured with Okta and protected against SQL Injection.

**Prerequisites:**

- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
- [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- An [Okta Developer Account](https://developer.okta.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)  

## Getting Started

Run the following command to clone this repository:

```bash
git clone https://github.com/aluminec/Okta_DotNet_SQL_Injection.git
cd Okta_DotNet_SQL_Injection
```

### Create an App Integration in Okta

Go to [Okta](https://developer.okta.com/signup/) and create a free developer account.

After creating the account open the **Applications** configuration pane by selecting **Applications > Applications**. 

Click on **Create App Integration** selecting a Sign-In method of "OIDC - OpenID Connect" and select an Application type of "Web Application".

### Configure your app to use Okta’s redirect model

Create a copy of `appsettings.json` named `appsettings.Development.json` and complete the following sections:

1) Open the App Integration you've created and go to the tab **General** to get your Client Id and Client Secret.

Replace the values in `appsettings.Development.json` with the `OktaDomain`, `ClientId` and `ClientSecret`.

```OktaDomain``` is found in the global header located in the upper-right corner of the dashboard.

```
Okta": {
  "OktaDomain": "https://${yourOktaDomain}",
  "ClientId": "${clientId}",
  "ClientSecret": "${clientSecret}",
  "AuthorizationServerId": "default"
}
```

2) Go to the **Login** section on the tab **General** and update these fields using your `applicationUrl`:

**Sign-in redirect URIs:** `{applicationUrl}/authorization-code/callback`   
**Sign-out redirect URIs:** `{applicationUrl}/signout/callback`


3) Complete the `ConnectionStrings`:

```
"ConnectionStrings": {
   "SqlServer": "${connectionStrings}"
},
```

### Create the SQL Server Database

Open the Package Manager Console on Visual Studio and run the following commands:

```
Add-Migration ProductsMigration
Update-Database
```

These commands will create a database that will be seeded with some test data on `Program.cs`

### Run the Web App 

Click on "Sign In" to authenticate the user, the Web application will redirect the browser to the Okta-hosted sign-in page. 

## Links

This example uses the following open source libraries from Okta:

* [Okta with ASP.NET](https://github.com/okta/okta-aspnet)
* [Create Okta Developer Account](https://developer.okta.com/signup/)

## Help

Please post any questions as comments on the [blog post][blog], or visit our [Okta Developer Forums](https://devforum.okta.com/).
