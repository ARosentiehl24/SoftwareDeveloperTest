import { Component, Input, OnInit } from '@angular/core';
import { Employee } from '../../models/interfaces/employee.interface';

@Component({
  selector: 'app-employee-info',
  templateUrl: './employee-info.component.html',
  styleUrls: ['./employee-info.component.css'],
})
export class EmployeeInfoComponent implements OnInit {
  @Input() employee: Employee | undefined;

  constructor() {}

  ngOnInit(): void {}
}
