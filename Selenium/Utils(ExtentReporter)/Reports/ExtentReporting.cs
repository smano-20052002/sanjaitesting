using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
namespace Utils.Reports
{
    public class ExtentReporting
    {
        public static ExtentReports extentReports;
        public static ExtentTest extentTest;
        public static ExtentReports StartReporting()
        {
            
            if(extentReports == null )
            {
                extentReports = new ExtentReports();
                var htmlReporter = new ExtentSparkReporter("C://Users/mano.selvaraj/Desktop/assessmentseleniumreport1.html");
                extentReports.AttachReporter(htmlReporter);
            }
            return extentReports;
        }
        public static void CreateTest(string testName)
        {
            extentTest = StartReporting().CreateTest(testName);
        }
        public static void EndReporting()
        {
            StartReporting().Flush();
        }
        public static void LogInfo(string info)
        {
            extentTest.Info(info);
        }
        public static void LogPass(string info)
        {
            extentTest.Pass(info);
        }
        public static void LogFail(string info)
        {
            extentTest.Fail(info);
        }
        public static void LogScreenshot(string info,string image)
        {
            extentTest.Info(info,MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }
    }
   
    

}
