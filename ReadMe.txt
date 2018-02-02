Work Log
*******************
Date:1/30/2018
Author: Geoff Fox
Project:
*******************

Task #1 Setup in-memory database, Entity and DbContext

Task #2 Add IicketItemsController

TIPS:
#1 return _context.TicketItems.AsNoTracking();  //to turn off Db tracking
#2 return explicitly IEnumerable<> OR if not possible List<>
#3 use in *.proj
	<DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="2.0.0" />
	line command > dotnet watch run (in the right directory)
#4 Use logging to console to see what is happening and SampleData Class
	SampleData.InitialData(app.ApplicationServices, loggerFactory, context);

* Documentation for the API (like wisdel)
*****************************************
#1 Add Nuget Packages Swashbuckle - Swagger   [NuGet: Swashbuckle.AspNetCore]
#2 In ConfigureServices():
	services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info{Title="Concert API:, Version= "v1"}));
   In Configure():
    app.UseSwagger();
	app.UseSwaggerUI( c => {
		c.SwaggerEndPoint("/swagger/v1/swagger.json", "Ticket API V1");
	});

TIPS:
For GUI: localhost:52299/swagger
Ref: docs.microsoft.com look for swagger