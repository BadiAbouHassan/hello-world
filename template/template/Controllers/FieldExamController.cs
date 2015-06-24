using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using template.DBService;

namespace template.Controllers
{
    public class FieldExamController
    {

        private DBService.FieldExamService service;

        public FieldExamController()
        {
            this.service = new DBService.FieldExamService();
        }

        public int addFieldExamResult(FieldExam fieldExam)
        {
            return this.service.addFieldExamResult(fieldExam);
        }

        public List<FieldExam> getFieldExamResults(int examInstanceID)
        {
            return this.service.getFieldExamResult(examInstanceID);
        }
    }
}