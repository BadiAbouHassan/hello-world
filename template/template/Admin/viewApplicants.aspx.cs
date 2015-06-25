using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;
using template.DBService;

namespace template.Admin
{
    public partial class viewApplicants : System.Web.UI.Page
    {
        ApplicantController appService ;
        List<Applicant> applicants;
        protected void Page_Load(object sender, EventArgs e)
        {
            appService = new ApplicantController();
           

            try
            {
                errMsgDiv.Style.Add("display", "none");
                successMsgDiv.Style.Add("display", "none");

                //get the logged user
                DBModel.User loggedAdmin = (DBModel.User)Session["logged_user"];

                //chck the role of the user
                Role UserRole = loggedAdmin.role;

                if (Request.QueryString["applicants"] != null)
                {
                    if (UserRole.roleName == "superadmin")
                    {
                        applicants = (new ApplicantService()).getAllApplicantsNotActivated();

                    }
                    else
                    {
                        applicants = (new ApplicantService()).getAllApplicantsOfClubNotActivated(loggedAdmin);
                    }
                }
                else
                {
                   
                    if (UserRole.roleName == "superadmin")
                    {
                        applicants = appService.getApplicants();

                    }
                    else
                    {
                        applicants = appService.getAllApplicantsOfAdminClub(loggedAdmin); //only view the applicants of the hunting club of the admin
                    }
                }
                if (applicants.Count != 0)
                {
                    for (int i = 0; i < applicants.Count; i++)
                    {
                        TableRow tRow = new TableRow();
                        Table1.Rows.Add(tRow);

                        // Create a new cell and add it to the row.
                        TableCell IDCell = new TableCell();
                        IDCell.Text = applicants[i].applicantID.ToString();
                        tRow.Cells.Add(IDCell);

                        TableCell usernameCell = new TableCell();
                        usernameCell.Text = applicants[i].username;
                        tRow.Cells.Add(usernameCell);

                        TableCell nameCell = new TableCell();
                        nameCell.Text = applicants[i].firstname + " " + applicants[i].middlename + " " + applicants[i].lastname;
                        tRow.Cells.Add(nameCell);

                        TableCell GenderCell = new TableCell();
                        GenderCell.Text = applicants[i].gender;
                        tRow.Cells.Add(GenderCell);

                        TableCell dOBCell = new TableCell();
                        dOBCell.Text = applicants[i].dateOfBirth;
                        tRow.Cells.Add(dOBCell);

                        TableCell poBCell = new TableCell();
                        poBCell.Text = applicants[i].placeOfBirth;
                        tRow.Cells.Add(poBCell);

                        TableCell registrationCell = new TableCell();
                        registrationCell.Text = applicants[i].registrationNb;
                        tRow.Cells.Add(registrationCell);

                        TableCell nationalityCell = new TableCell();
                        nationalityCell.Text = applicants[i].nationality;
                        tRow.Cells.Add(nationalityCell);

                        TableCell bloodTypeCell = new TableCell();
                        bloodTypeCell.Text = applicants[i].bloodType;
                        tRow.Cells.Add(bloodTypeCell);

                        TableCell professionCell = new TableCell();
                        professionCell.Text = applicants[i].profession;
                        tRow.Cells.Add(professionCell);

                        TableCell emailCell = new TableCell();
                        emailCell.Text = applicants[i].email;
                        tRow.Cells.Add(emailCell);

                        TableCell mailCell = new TableCell();
                        mailCell.Text = applicants[i].mailAddress;
                        tRow.Cells.Add(mailCell);

                        TableCell faxCell = new TableCell();
                        faxCell.Text = applicants[i].fax;
                        tRow.Cells.Add(faxCell);

                        TableCell cityCell = new TableCell();
                        cityCell.Text = applicants[i].city;
                        tRow.Cells.Add(cityCell);

                        TableCell addressCell = new TableCell();
                        addressCell.Text = applicants[i].applicantAddress;
                        tRow.Cells.Add(addressCell);

                        TableCell cellularCell = new TableCell();
                        cellularCell.Text = applicants[i].cellular;
                        tRow.Cells.Add(cellularCell);

                        TableCell phoneCell = new TableCell();
                        phoneCell.Text = applicants[i].phone;
                        tRow.Cells.Add(phoneCell);

                        TableCell actionsCell = new TableCell();
                        actionsCell.Text = "<div class='dropdown'>" +
                          "<button class='btn btn-default dropdown-toggle' type='button' id='dropdownMenu1' data-toggle='dropdown' aria-haspopup='true' aria-expanded='true'>" +
                          "  Actions" +
                          "  <span class='caret'></span>" +
                          "</button>" +
                          "<ul class='dropdown-menu' aria-labelledby='dropdownMenu1'>" +
                          "  <li><a href='/Admin/assignExamSchedule.aspx?applicantID=" + applicants[i].applicantID + "'>Assign Exam Schedule</a></li>" +
                          "  <li><a href='/Admin/activateExam.aspx?applicantID=" + applicants[i].applicantID + "'>Activate Exam</a></li>" +
                          "  <li><a href='/Admin/addFieldExamResult.aspx?applicantID=" + applicants[i].applicantID + "'>Field Exam Result</a></li>" +
                          "  <li><a href='/Admin/editApplicant.aspx?applicantID=" + applicants[i].applicantID + "'>Edit</a></li>" +
                          "</ul>" +
                        "</div>";
                        tRow.Cells.Add(actionsCell);

                        TableCell deleteCell = new TableCell();
                        Button btn = new Button();
                        btn.Text = "Delete";
                        btn.Click += new EventHandler(delete_Click);
                        deleteCell.Controls.Add(btn);
                       // deleteCell.Text = "<a href='/Admin/deleteCourse.aspx?courseID=" + applicants[i].applicantID + "'>Delete</a>";
                        tRow.Cells.Add(deleteCell);

                       
                    }
                }
            }
            catch (Exception ex)
            {
                errMsgDiv.Style.Remove("display");
                errMsg.Text = ex.Message;
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = sender as Button;
                TableCell cell = button.Parent as TableCell;
                TableRow row = cell.Parent as TableRow;
                int index = Table1.Rows.GetRowIndex(row);
                appService.deleteApplicant(applicants[index-1].applicantID);
                successMsgDiv.Style.Remove("display");
                successMsg.Text = "Deleted Sucessfully";

            }
            catch (Exception ex)
            {
                errMsgDiv.Style.Remove("display");
                errMsg.Text = ex.Message;
            }


        }
    }
}