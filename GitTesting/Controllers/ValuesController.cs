using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GitTesting.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "SBI", "SBI" };
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetPC()
        {
            return new string[] { "PC", "PC" };
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        public IActionResult GetSum(int a,int b)
        {
            var response = a+b;
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetStudent()
        {
            var response = DatatableToChartList();
            return Ok(response);
        }
        [HttpGet]
        public IActionResult GetEmployee()
        {
            var response = ListToChartList();
            return Ok(response);
        }
        private List<object> DatatableToChartList()
        {
            Console.WriteLine("Datatable To List");
            List<object> stdlList = new List<object>();
            List<object> stdlList2 = new List<object>();
            List<object> finalList = new List<object>();
             var dtStudent = GetStudentDT();
             foreach (DataRow item in dtStudent.Rows)
            {
                List<string> rowsValue = new List<string>();
                List<object> rowsdValue = new List<object>();
                foreach (DataColumn col in dtStudent.Columns)
                {
                    var colValue = item[col.ColumnName];
                    rowsValue.Add(colValue.ToString());
                    rowsdValue.Add(colValue);
                }

                stdlList.Add(rowsValue);
                stdlList2.Add(rowsdValue);
            }
           // finalList.Add(stdlList);
            finalList.Add(stdlList2);
            Console.WriteLine("Datatable Converted To List" + finalList);
            return stdlList2;
        }
        private  List<object> ListToChartList()
        {
            Console.WriteLine("List To List");
            List<object> emplList = new List<object>();
            List<object> finalList = new List<object>();
             var lstEmpDet = GetEmployees();
            EmployeeDetail obj = new EmployeeDetail();
            foreach (var item in lstEmpDet)
            {
                List<object> rowsdValue = new List<object>();
                foreach (var prop in item.GetType().GetProperties())
                {
                    try
                    {
                        object val = prop.GetValue(item, null);
                        rowsdValue.Add(val);
                        //propertyInfo.SetValue(obj, Convert.ChangeType(item[prop.Name], propertyInfo.PropertyType), null);
                        // item.[prop.Name]
                    }
                    catch
                    {
                        continue;
                    }
                }

                emplList.Add(rowsdValue);
            }
            Console.WriteLine("Datatable Converted To List" + emplList);
            return emplList;
        }
        private List<EmployeeDetail> GetEmployees()
        {
            List<EmployeeDetail> empDetails = new List<EmployeeDetail>();
            EmployeeDetail emp = new EmployeeDetail() { Id = 1, City = "Delhi", Country = "India", CreatedDate = DateTime.Now, FirstName = "Ashish", IsPermanent = true, LastName = "Sinha", Mobile = "9742745384", ModifiedDate = DateTime.Now, Pincode = 812001, Salary = 5000, State = "Bihar" };
            empDetails.Add(emp);
            emp = new EmployeeDetail() { Id = 2, City = "Bangalore", Country = "India", CreatedDate = DateTime.Now, FirstName = "Subba", IsPermanent = true, LastName = "Reddy", Mobile = "5555555555", ModifiedDate = DateTime.Now, Pincode = 560098, Salary = 10000, State = "Karnataka" };
            empDetails.Add(emp);
            emp = new EmployeeDetail() { Id = 3, City = "Mumbai", Country = "India", CreatedDate = DateTime.Now, FirstName = "Anup", IsPermanent = false, LastName = "Sinha", Mobile = "666666666", ModifiedDate = DateTime.Now, Pincode = 812001, Salary = 8000, State = "Bihar" };
            empDetails.Add(emp);
            return empDetails;
        }
        private DataTable GetStudentDT()
        {
            DataTable dt = new DataTable("Student");
            dt.Columns.Add("StudentId", typeof(Int32));
            dt.Columns.Add("StudentName", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("MobileNo", typeof(string));
            //Data  
            dt.Rows.Add(1, "Manish", "Hyderabad", "0000000000");
            dt.Rows.Add(2, "Venkat", "Hyderabad", "111111111");
            dt.Rows.Add(3, "Namit", "Pune", "1222222222");
            dt.Rows.Add(4, "Abhinav", "Bhagalpur", "3333333333");
            return dt;
        }
        public class EmployeeDetail
        {
            public EmployeeDetail()
            {
               
            }
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string Mobile { get; set; }
            public DateTime? CreatedDate { get; set; }
            public bool? IsPermanent { get; set; }
            public decimal? Salary { get; set; }
            public int? Pincode { get; set; }
            public DateTime? ModifiedDate { get; set; }
           

        }
    }
}
