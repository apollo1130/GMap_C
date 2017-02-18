﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TripToPrint.Core.Tests.SpecflowTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class GroupsGenerationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GroupsGeneration.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Groups Generation", "\tTest different scenarios of dividing placemarks by groups", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Groups Generation")))
            {
                TripToPrint.Core.Tests.SpecflowTests.GroupsGenerationFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("A single group: 1 placemark")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Groups Generation")]
        public virtual void ASingleGroup1Placemark()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A single group: 1 placemark", ((string[])(null)));
#line 4
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Longitude",
                        "Latitude",
                        "Name"});
            table1.AddRow(new string[] {
                        "45.91142",
                        "10.8345",
                        "1"});
#line 5
 testRunner.Given("I have these placemarks in my folder:", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Group Index",
                        "Name"});
            table2.AddRow(new string[] {
                        "0",
                        "1"});
#line 8
 testRunner.Then("these placemarks will be assigned to the following groups:", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("A single group: 6 placemark")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Groups Generation")]
        public virtual void ASingleGroup6Placemark()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A single group: 6 placemark", ((string[])(null)));
#line 12
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Longitude",
                        "Latitude",
                        "Name"});
            table3.AddRow(new string[] {
                        "28.55633",
                        "-16.3357",
                        "1"});
            table3.AddRow(new string[] {
                        "28.54533",
                        "-16.22867",
                        "2"});
            table3.AddRow(new string[] {
                        "28.50945",
                        "-16.18511",
                        "3"});
            table3.AddRow(new string[] {
                        "28.48714",
                        "-16.31343",
                        "4"});
            table3.AddRow(new string[] {
                        "28.48649",
                        "-16.31535",
                        "5"});
            table3.AddRow(new string[] {
                        "28.49828",
                        "-16.37672",
                        "6"});
#line 13
 testRunner.Given("I have these placemarks in my folder:", ((string)(null)), table3, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Group Index",
                        "Name"});
            table4.AddRow(new string[] {
                        "0",
                        "1"});
            table4.AddRow(new string[] {
                        "0",
                        "2"});
            table4.AddRow(new string[] {
                        "0",
                        "3"});
            table4.AddRow(new string[] {
                        "0",
                        "4"});
            table4.AddRow(new string[] {
                        "0",
                        "5"});
            table4.AddRow(new string[] {
                        "0",
                        "6"});
#line 21
 testRunner.Then("these placemarks will be assigned to the following groups:", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("For two groups: 4 + 3 placemarks")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Groups Generation")]
        public virtual void ForTwoGroups43Placemarks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("For two groups: 4 + 3 placemarks", ((string[])(null)));
#line 30
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Longitude",
                        "Latitude",
                        "Name"});
            table5.AddRow(new string[] {
                        "28.0552",
                        "-16.73494",
                        "Restaurante La Gula @ Los Cristianos"});
            table5.AddRow(new string[] {
                        "28.05622",
                        "-16.72488",
                        "El Aderno @ Los Cristianos"});
            table5.AddRow(new string[] {
                        "28.05273",
                        "-16.71508",
                        "Panaria @ Los Cristianos"});
            table5.AddRow(new string[] {
                        "28.05145",
                        "-16.72196",
                        "El Pincho @ Los Cristianos"});
            table5.AddRow(new string[] {
                        "28.03397",
                        "-16.6412",
                        "La Dulce Emilia @ Guargacho"});
            table5.AddRow(new string[] {
                        "28.11924",
                        "-16.67092",
                        "Restaurante El Chamo @ La Escalona"});
            table5.AddRow(new string[] {
                        "28.12183",
                        "-16.7406",
                        "Tandem Paragliding @ Adeje"});
#line 31
 testRunner.Given("I have these placemarks in my folder:", ((string)(null)), table5, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Group Index",
                        "Name"});
            table6.AddRow(new string[] {
                        "0",
                        "Restaurante La Gula @ Los Cristianos"});
            table6.AddRow(new string[] {
                        "0",
                        "El Aderno @ Los Cristianos"});
            table6.AddRow(new string[] {
                        "0",
                        "Panaria @ Los Cristianos"});
            table6.AddRow(new string[] {
                        "0",
                        "El Pincho @ Los Cristianos"});
            table6.AddRow(new string[] {
                        "1",
                        "La Dulce Emilia @ Guargacho"});
            table6.AddRow(new string[] {
                        "1",
                        "Restaurante El Chamo @ La Escalona"});
            table6.AddRow(new string[] {
                        "1",
                        "Tandem Paragliding @ Adeje"});
#line 40
 testRunner.Then("these placemarks will be assigned to the following groups:", ((string)(null)), table6, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("For two groups: 8 + 1 placemarks")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Groups Generation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("unclear")]
        public virtual void ForTwoGroups81Placemarks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("For two groups: 8 + 1 placemarks", new string[] {
                        "unclear"});
#line 51
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Longitude",
                        "Latitude",
                        "Name"});
            table7.AddRow(new string[] {
                        "28.47526",
                        "-16.41868",
                        "1"});
            table7.AddRow(new string[] {
                        "28.46999",
                        "-16.38628",
                        "2"});
            table7.AddRow(new string[] {
                        "28.49828",
                        "-16.37672",
                        "3"});
            table7.AddRow(new string[] {
                        "28.48451",
                        "-16.34342",
                        "4"});
            table7.AddRow(new string[] {
                        "28.48649",
                        "-16.31535",
                        "5"});
            table7.AddRow(new string[] {
                        "28.48714",
                        "-16.31343",
                        "6"});
            table7.AddRow(new string[] {
                        "28.46661",
                        "-16.31083",
                        "7"});
            table7.AddRow(new string[] {
                        "28.46139",
                        "-16.30462",
                        "8"});
            table7.AddRow(new string[] {
                        "28.54533",
                        "-16.22867",
                        "9"});
#line 52
 testRunner.Given("I have these placemarks in my folder:", ((string)(null)), table7, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Group Index",
                        "Name"});
            table8.AddRow(new string[] {
                        "1",
                        "1"});
            table8.AddRow(new string[] {
                        "1",
                        "2"});
            table8.AddRow(new string[] {
                        "1",
                        "3"});
            table8.AddRow(new string[] {
                        "0",
                        "4"});
            table8.AddRow(new string[] {
                        "0",
                        "5"});
            table8.AddRow(new string[] {
                        "0",
                        "6"});
            table8.AddRow(new string[] {
                        "0",
                        "7"});
            table8.AddRow(new string[] {
                        "0",
                        "8"});
            table8.AddRow(new string[] {
                        "0",
                        "9"});
#line 63
 testRunner.Then("these placemarks will be assigned to the following groups:", ((string)(null)), table8, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("For three group: 4 + 5 + 1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Groups Generation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("unclear")]
        public virtual void ForThreeGroup451()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("For three group: 4 + 5 + 1", new string[] {
                        "unclear"});
#line 85
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Longitude",
                        "Latitude",
                        "Name"});
            table9.AddRow(new string[] {
                        "28.47526",
                        "-16.41868",
                        "1"});
            table9.AddRow(new string[] {
                        "28.46999",
                        "-16.38628",
                        "2"});
            table9.AddRow(new string[] {
                        "28.49828",
                        "-16.37672",
                        "3"});
            table9.AddRow(new string[] {
                        "28.48451",
                        "-16.34342",
                        "4"});
            table9.AddRow(new string[] {
                        "28.48649",
                        "-16.31535",
                        "5"});
            table9.AddRow(new string[] {
                        "28.48714",
                        "-16.31343",
                        "6"});
            table9.AddRow(new string[] {
                        "28.46661",
                        "-16.31083",
                        "7"});
            table9.AddRow(new string[] {
                        "28.46139",
                        "-16.30462",
                        "8"});
            table9.AddRow(new string[] {
                        "28.54533",
                        "-16.22867",
                        "9"});
            table9.AddRow(new string[] {
                        "28.49947",
                        "-16.40842",
                        "10"});
#line 86
 testRunner.Given("I have these placemarks in my folder:", ((string)(null)), table9, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Group Index",
                        "Name"});
            table10.AddRow(new string[] {
                        "1",
                        "1"});
            table10.AddRow(new string[] {
                        "1",
                        "2"});
            table10.AddRow(new string[] {
                        "1",
                        "3"});
            table10.AddRow(new string[] {
                        "0",
                        "4"});
            table10.AddRow(new string[] {
                        "0",
                        "5"});
            table10.AddRow(new string[] {
                        "0",
                        "6"});
            table10.AddRow(new string[] {
                        "0",
                        "7"});
            table10.AddRow(new string[] {
                        "0",
                        "8"});
            table10.AddRow(new string[] {
                        "0",
                        "9"});
            table10.AddRow(new string[] {
                        "1",
                        "10"});
#line 98
 testRunner.Then("these placemarks will be assigned to the following groups:", ((string)(null)), table10, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
