using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Utils.Reports;
namespace SeleniumAssessment
{
    internal class Program
    {
        static void Main(string[] args)
        {


            IWebDriver chrome = new ChromeDriver();
            LoginPage loginPage = new LoginPage(chrome);
            loginPage.CheckLoginButtonwithvalidinput();
            ////loginPage.Check_Login_Button_with_invalid_account_input();
            loginPage.Check_login_with_empty_data_return_fails();
            loginPage.Check_Login_Button_with_invalid_password_input();
            loginPage.Check_work_for_Register_button();
            RegisterPage registerPage = new RegisterPage(chrome);
            registerPage.Check_work_for_Login_button();
           // registerPage.Check_register_with_empty_data_return_fails();
            registerPage.CheckRegisterButtonwithvalidinput();
            registerPage.Check_Register_Button_with_exists_data_input();
            HomePage homePage = new HomePage(chrome);
            homePage.Check_list_movie_button_redirect_to_list_page();
            homePage.Check_add_movie_button_redirect_to_add_page();
            homePage.Check_value_in_total_movie_not_null();
            CreatePage createPage = new CreatePage(chrome);
            createPage.Check_work_for_View_button();
            createPage.CheckAddButtonwithvalidinput();
            createPage.Check_add_movie_with_empty_data_return_fails();
            ListPage listPage = new ListPage(chrome);
            listPage.Check_work_for_Delete_button();
            listPage.Check_work_for_Update_button();
            listPage.Check_work_for_Add_button();
            UpdatePage updatePage = new UpdatePage(chrome);
            updatePage.CheckUpdateButtonwithvalidinput();
            updatePage.Check_update_movie_with_empty_data_return_fails();
            updatePage.Check_work_for_View_button();
            DeletePage deletePage = new DeletePage(chrome);
            deletePage.Check_delete_button_display_Dialog_box();
            deletePage.Check_dialog_box_Delete_button_delete_element();
            deletePage.Check_dialog_box_Cancel_button_return_list_page();

            ExtentReporting.EndReporting();

        }
    }
}
