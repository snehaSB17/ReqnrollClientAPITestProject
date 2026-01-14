using NUnit.Framework.Interfaces;
using Reqnroll;
using Reqnroll.BoDi;
using ReqnrollClientAPITestProject.Models;

namespace ReqnrollClientAPITestProject.Support
{
    [Binding]
    public sealed class ObjectsHooks
    {
        // For additional details on Reqnroll hooks see https://go.reqnroll.net/doc-hooks

        private readonly IObjectContainer _objectContainer;
        private readonly FeatureContext _featureContext;

        public ObjectsHooks(IObjectContainer objectContainer, FeatureContext featureContext)
        {
            _objectContainer = objectContainer;
            _featureContext = featureContext;
        }

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            // Choose your strategy:
            
            //var jsonFilesRepo = new JsonFilesRepository();
            //_objectContainer.RegisterInstanceAs(jsonFilesRepo);
            // Choose your strategy:
           
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            // Example of ordering the execution of hooks
            // See https://go.reqnroll.net/doc-hooks#hook-execution-order

            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}