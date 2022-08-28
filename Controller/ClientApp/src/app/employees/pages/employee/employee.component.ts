import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';
import { switchMap } from 'rxjs';
import { Employee } from '../../models/interfaces/employee.interface';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
})
export class EmployeeComponent implements OnInit {
  employee: Employee | undefined;

  showError: boolean = false;

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _employeeService: EmployeeService
  ) {}

  ngOnInit(): void {
    this._activatedRoute.params
      .pipe(switchMap(({ id }) => this._employeeService.getEmployeeById(id)))
      .subscribe({
        next: (employee) => (this.employee = employee),
        error: (error) => console.log(error),
      });
  }
}
