using System;
using System.IO;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlaUI.UIA3;

   

namespace TodoWpfApp.UnitTests
{
    [TestClass]
    public class MainWindowTests
    {
        [TestMethod]
        public void Title_CheckTitle_CheckEqualToTodoWpfApp()
        {
            var app = FlaUI.Core.Application.Launch(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TodoWpfApp.exe"));
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                Assert.AreEqual(window.Title, "TodoWpfApp");
            }
            app.Close();
        }

        [TestMethod]
        public void TodoItemView_CheckTodoItemViewExists_TodoItemViewExists()
        {
            var app = FlaUI.Core.Application.Launch(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TodoWpfApp.exe"));
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                var cf = new ConditionFactory(new UIA3PropertyLibrary());
                var todoItem = window.FindFirstChild(cf.ByClassName("TodoItemView"));
                Assert.IsNotNull(todoItem);
            }
            app.Close();
        }

        [TestMethod]
        public void NewTodoItemView_CheckNewTodoItemViewExists_NewTodoItemViewExists()
        {
            var app = FlaUI.Core.Application.Launch(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TodoWpfApp.exe"));
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                var cf = new ConditionFactory(new UIA3PropertyLibrary());
                var todoItem = window.FindFirstChild(cf.ByClassName("NewTodoItemView"));
                Assert.IsNotNull(todoItem);
            }
            app.Close();
        }
    }
}
