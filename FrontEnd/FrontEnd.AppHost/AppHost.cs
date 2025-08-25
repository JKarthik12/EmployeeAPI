var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Front_end_app>("front-end-app");

builder.Build().Run();
