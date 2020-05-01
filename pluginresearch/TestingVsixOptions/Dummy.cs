using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.ProjectModel;
using Microsoft.VisualStudio.Web.CodeGeneration.DotNet;
using Microsoft.VisualStudio.Web.CodeGeneration.Templating;
using Microsoft.VisualStudio.Web.CodeGeneration.Templating.Compilation;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;

namespace TestingVsixOptions
{
    public class Dummy
    {
        private CommonProjectContext prCon = new CommonProjectContext();
        
        

        public async void dupa()
        {
            Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller.CommandLineGeneratorModel clgm = new CommandLineGeneratorModel();

            clgm.DataContextClass = "tociEntities1";
            clgm.ControllerName = "ApplyForms2Controller";
            clgm.GenerateReadWriteActions = true;
            clgm.IsRestController = false;
            clgm.NoViews = false;
            
            clgm.ControllerNamespace = "TestingVsixOptions.Controllers";
            clgm.ModelClass = "ApplyForm";
            clgm.RelativeFolderPath = ".\\TestingVsixOptions";
            clgm.Force = true;

            //ICodeGeneratorActionsService s = new CodeGeneratorActionsService();
            CommonProjectContext projectContext = new CommonProjectContext();
             

            projectContext.ProjectFullPath = @"C: \Users\bzapa\source\repos\TestingVsixOptions\TestingVsixOptions";
            projectContext.ProjectName = "TestingVsixOptions";
            projectContext.PackageDependencies = new List<DependencyDescription>();

            IApplicationInfo appInfo = new ApplicationInfo("TestingVsixOptions", @"C:\Users\bzapa\source\repos\TestingVsixOptions\TestingVsixOptions");

            

            ICodeGenAssemblyLoadContext codeGenAssemblyLoadContext = new DefaultAssemblyLoadContext();

            ICompilationService compilationService = new RoslynCompilationService(appInfo, codeGenAssemblyLoadContext, projectContext);
            ITemplating templating = new RazorTemplating(compilationService);
            IFilesLocator filesLocator = new FilesLocator();
            
            IFileSystem fileSystem = new DefaultFileSystem();
            

            ICodeGeneratorActionsService actionsService = new CodeGeneratorActionsService(templating, filesLocator, fileSystem);

            IServiceProvider serviceProvider = new ServiceContainer();
            ILogger logger = new ConsoleLogger();

            MvcControllerWithReadWriteActionGenerator cgb = new MvcControllerWithReadWriteActionGenerator(projectContext, appInfo, actionsService, serviceProvider, logger);

            await cgb.Generate(clgm);
            //t.RunSynchronously();


            //prCon.AssemblyFullPath = asem.;
        }
    }
}