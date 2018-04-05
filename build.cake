///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var xunitFramework =  Argument("WithTestingFramework", "2.0.3");

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(ctx =>
{
   // Executed BEFORE the first task.
   Information("Running tasks...");
});

Teardown(ctx =>
{
   // Executed AFTER the last task.
   Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
    {
        CleanDirectories(string.Format("./**/obj/{0}", configuration));
        CleanDirectories(string.Format("./**/bin/{0}", configuration));
    });

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        DotNetCoreRestore(new DotNetCoreRestoreSettings(){
            Sources = new[] { "https://api.nuget.org/v3/index.json" },
        });
    });

Task("Build")
    .Does(() =>
    {
        foreach(var path in GetProjects())
        {
            DotNetCoreBuild(path.FullPath,
            new DotNetCoreBuildSettings()
                    {
                        Configuration = configuration
                    });
        }
    });

Task("Test")
    .Does(() =>
    {
        var projects = GetFiles("./*Tests/*.csproj");
        var testResultsPath = Directory("./testresults");
        Information("Running tests");
        foreach(var project in projects)
        {
            Information("Running tests : " + project.GetFilenameWithoutExtension());
            
            var outputFilePath = MakeAbsolute(testResultsPath.Path).CombineWithFilePath(project.GetFilenameWithoutExtension());
            DotNetCoreTest(
                project.FullPath,
                new DotNetCoreTestSettings
                {
                    Configuration = "Release"
                });
        }
    });

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .Does(() =>
    {
        Information("Running integration");
    });

RunTarget(target);

public IEnumerable<FilePath> GetProjects()
{
    return GetFiles("./*/*.csproj")
        .ToList();
}