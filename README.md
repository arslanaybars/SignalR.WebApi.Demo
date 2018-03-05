# SignalR.WebApi.Demo
This application prepared for training about SignalR and the following technologies

- SignalR
- ASP.NET MVC
- ASP.NET WEB API
- Entity Framework
- SQL Server
- jQuery

In our scenario, we have form pages while the user reading the forms if there is an updated from any other application (Desktop, Web, Mobile) to api our endpoint (api/forms with post method). We notify the user who is on the forms detail page and have admin permission. If the user would like to new added form we showed him/her the created form after he confirms to redirection.

example json request to our endpoint

    {
      "Title": "HELLO",
      "Description": "NEW REQUEST FORM",
      "Content": "This content gonna be amazing, This content gonna be amazing",
      "CreateTime": "2018-03-02 17:15:45",
      "Users": [
        {
          "Id": "1"
        },
        {
          "Id": "3"
        }
      ]
    }

the api endpoint triggered our hub methods works.

![work gif](https://github.com/arslanaybars/SignalR.WebApi.Demo/blob/master/media/SignalR.WebApi.Demo.gif)

![work gif](https://github.com/arslanaybars/SignalR.WebApi.Demo/blob/master/media/SignalR.WebApi.Demo.jpg)

# Notes
Dummy data is in the seed method. after you change the connection string. Run following command in nuget package manager console

> Update-Database

then the database should be ready :)

!! Check the Hub Connection IP in FormsController class 
!! Check the Details.chtml redirection IP

## References
- Bora Kasmer: [mssql database ile signalR etkilesimleri](http://www.borakasmer.com/mssql-database-ile-signalr-etkilesimleri/)
- Microsoft : [introduction to signalR](https://docs.microsoft.com/en-us/aspnet/signalr/overview/getting-started/introduction-to-signalr)
