~~~~~~~~~~ What is this application about? ~~~~~~~~~~
This is a Single Page Application(SPA) demonstrating a sample ecommerce application. 

Pages in the application:
1. Home page: It displays a list of products with prices. Prices are displayed in the currency of the country selected from the dropdown given on the page. These products can be added to basket. User can navigate to basket details page from home page.
2. Basket details page: This page shows the list of products added to the basket. It also shows the subtotal of all items, shipping price and total. Products can be removed from the basket on this page. User can navigate to home page or checkout/order placed page from this page.
3. Order Placed page: This page thanks user for placing order and provides an order number.
4. Path not found page: When user tries to navigate to a path which is not present, this page is displayed.

~~~~~~~~~~ Parts of the application ~~~~~~~~~~

This application consists of two parts
- SampleECommerce_Backend
- SampleECommerce_WebAPP

~~~~~~~~~~ Backend ~~~~~~~~~~
Technologies used:
- .NET Core 3.1 Web API
- C#
- Microsoft.MSTest and FluentAssertion 6.6

Projects: 
- SampleECommerce.WebAPI: API layer containing controllers and action methods
- SampleECommerce.Service: Business layer
- SampleECommerce.Repository: Repository layer returning static data. Persistent storage is not used.
- SampleECommerce.Models: contains models.

- SampleECommerce.WebAPI.Test: tests for controller action methods
- SampleECommerce.Service.Test: tests for business layer

~~~~~~~~~~ Frontend ~~~~~~~~~~
Technologies used:
- Angular version 8
- REDUX store to maintain the application's state
- Container component architecture
- jasmine 3+ and Karma 4+

Unit tests are written for Reducer, product list and cart details component. 

~~~~~~~~~~ Project set up ~~~~~~~~~~
Prerequisits:
- .NET Core Version 3.1
- Visual Studio 2019 / 2022
- Node latest version
- Angular CLI 8+

Steps to run WebApp:
1. Open the command prompt and browse to the folder where package.json is placed. 
2. Run "npm install". It will install all required node_modules. 
3. Run "ng-serve".
4. Open the app in browser.

Steps to run Backend:
1. Open solution in Visual Studio.
2. Set SampleECommerce.WebAPI as start up project.
3. Run by pressing ctrl+F5.





