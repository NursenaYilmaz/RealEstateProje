﻿namespace REALESTATE_DAPPER_API.Dtos.EmployeeDtos
{
	public class GetByIdEmployeeDto
	{
		public int EmployeeID { get; set; }

		public string EmployeeName { get; set; }
		public string EmployeeTitle { get; set; }
		public string Mail { get; set; }
		public string PhoneNumber { get; set; }
		public string ImageUrl { get; set; }
		public bool Status { get; set; }
	}
}
