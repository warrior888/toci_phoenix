using System;
using Extensibility;
using EnvDTE;
using EnvDTE80;

namespace MyAddIn
{
    public class Connect : IDTExtensibility2
    {
        private DTE2 _applicationObject;
        private AddIn _addInInstance;

        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            _applicationObject = (DTE2)application;
            _addInInstance = (AddIn)addInInst;
            
            switch (connectMode)
            {
                case ext_ConnectMode.ext_cm_AfterStartup:

                    // The add-in has been loaded after Visual Studio was loaded. Since Visual Studio
                    // is fully initialized, we can initialize the add-in
                    InitializeAddIn();
                    break;

                case ext_ConnectMode.ext_cm_Startup:

                    // The add-in has been loaded with Visual Studio. Do nothing until Visual Studio
                    // is fully initialized (the OnStartupComplete method will be called)
                    break;
            }
        }

        public void OnStartupComplete(ref Array custom)
        {
            InitializeAddIn();
        }

        private void InitializeAddIn()
        {
            EnvDTE80.Solution2 solution2;
            EnvDTE.Project project;
            EnvDTE.ProjectItem folderProjectItem;
            string projectItemTemplate;
            string language = null;
            string extension = null;
            string folderFullName;
            string existingProjectItem1FullName;
            string existingProjectItem2FullName;

            try
            {
                solution2 = (EnvDTE80.Solution2)_applicationObject.Solution;

                if (_applicationObject.Solution.Projects.Count > 0)
                {
                    project = _applicationObject.Solution.Projects.Item(1);

                    language = "CSharp";
                    extension = ".cs";
              
                    /*
                    switch (project.CodeModel.Language)
                    {
                        case EnvDTE.CodeModelLanguageConstants.vsCMLanguageCSharp:

                            language = "CSharp";
                            extension = ".cs";
                            break;

                        case EnvDTE.CodeModelLanguageConstants.vsCMLanguageVB:

                            language = "VisualBasic";
                            extension = ".vb";
                            break;
                    }*/

                    if (!String.IsNullOrEmpty(language))
                    {
                        // Get the template for "class" files for the given language
                        projectItemTemplate = solution2.GetProjectItemTemplate("Class", language);

                        // Add a new file from the template under the project
                        project.ProjectItems.AddFromTemplate(projectItemTemplate, "NewClassInProject" + extension);

                        // Create a new folder under the project
                        folderProjectItem = project.ProjectItems.AddFolder("My folder");
                        /*
                                                // Add a new file from the template under the folder
                                                folderProjectItem.ProjectItems.AddFromTemplate(projectItemTemplate, "NewClassInFolder" + extension);

                                                // Create existing files in the "My Documents" folder

                                                folderFullName = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                                                existingProjectItem1FullName = System.IO.Path.Combine(folderFullName, "ExistingClass1" + extension);
                                                System.IO.File.WriteAllText(existingProjectItem1FullName, "");

                                                existingProjectItem2FullName = System.IO.Path.Combine(folderFullName, "ExistingClass2" + extension);
                                                System.IO.File.WriteAllText(existingProjectItem2FullName, "");

                                                // Add an existing file to the project creating a copy under the project
                                                project.ProjectItems.AddFromFileCopy(existingProjectItem1FullName);

                                                // Add another existing file to the project from its original location (link)
                                                project.ProjectItems.AddFromFile(existingProjectItem2FullName);
                          */

                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
        {
        }

        public void OnAddInsUpdate(ref Array custom)
        {
        }

        public void OnBeginShutdown(ref Array custom)
        {
        }
    }
}