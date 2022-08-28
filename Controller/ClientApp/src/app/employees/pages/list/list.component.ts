import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/interfaces/employee.interface';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
})
export class ListComponent implements OnInit {
  employeeId: string = '';

  employee: Employee | undefined;
  employees: Employee[] = [];

  showError: boolean = false;

  constructor(private _employeService: EmployeeService) {}

  ngOnInit(): void {
    this.getEmployees();
  }

  getEmployees() {
    this._employeService.getEmployees().subscribe({
      next: (employees) => (this.employees = employees),
      error: (error) => console.log(error),
    });
  }

  getEmployeesById(id: number | string) {
    this._employeService.getEmployeeById(id).subscribe({
      next: (employee) => (this.employee = employee),
      error: (error) => console.log(error),
    });
  }

  search() {
    this.employee = undefined;
    this.employees = [];

    if (this.employeeId) {
      this.getEmployeesById(this.employeeId);
    } else {
      this.getEmployees();
    }
  }
}
