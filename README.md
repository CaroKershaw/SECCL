# SecclAPI Technical Test
This repository contains the solution for the SecclAPI technical test. The goal of this test is to demonstrate the ability to build a connection between the SECCL API and a front-end UI with a simple middleware layer for data manipulation.

# Prerequisites
Before you begin, ensure you have met the following requirements:

Microsoft .NET 7.0, Git, Angular CLI 16.2.2, Node 18.17.1, Visual Studio 2022

# Authentication
Open the appsettings.json file.

Replace the placeholders for the API credentials with the provided credentials:

"SecclApi": {
  "BaseUrl": "https://pfolio-api-staging.seccl.tech",
  "FirmId": "P1IMX",
  "UserId": "nelahi6642@4tmail.net",
  "Password": "DemoBDM1"

This is needed for the POST {{apiRoute}}/authenticate endpoint which is used to acquire an access token
  
# Fetching Data from SECCL
After successful authentication, you can fetch data from SECCL using the following steps:

Authentication: Ensure you have completed the authentication step to obtain an access token.

Use the access token as a Bearer token in your API requests.

Implement a GET request to retrieve portfolio data from the SECCL API using the following endpoint:

GET {{apiRoute}}/portfolio/{{firmId}}/
apiRoute: Replace with the base URL mentioned in the appsettings.json file.
firmId: Use the firm ID provided in the credentials.
This request will return portfolio data from SECCL.

# Project Structure
The project structure follows a standard .NET Core application structure. Here is an overview of the important folders and files:

Models: Contains data models for the application, including AuthResponse and Portfolio.

Services: Includes services for authentication (AuthService) and portfolio data retrieval (PortfolioService).

Program.cs: The entry point of the application.

# Usage
To use this project, follow the steps above. The project can be customized and extended as needed to meet the requirements of the technical test.

# Deployment
This project is intended for the technical test environment. If you wish to deploy it to a production environment, please follow standard deployment practices for .NET Core web applications.

# Contributing
Contributions are welcome! If you have suggestions, improvements, or find any issues, please open an issue or submit a pull request.
